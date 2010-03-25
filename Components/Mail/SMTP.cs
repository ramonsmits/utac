/*
 * UTAC - USB TEMPer Advanced Control
 * -----------------------------------------------------------------------
 * Homepage: http://utac.n4rf.net
 * Bugtracker: http://bugtracker.n4rf.net
 * SourceForge Project Page: http://sourceforge.net/projects/utac/
 * Mail Contact: info@n4rf.net
 * -----------------------------------------------------------------------
 * 
 * UTAC is a GUI for the TEMPer and TEMPerHum USB Thermometer
 * Copyright (C) Bjoern Boettcher 2008
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 * 
 * -----------------------------------------------------------------------
 * --------------------------------------------------* File Information *-
 * -----------------------------------------------------------------------
 * FileName: 	SMTP.cs
 * Namespace: 	utac.Components.Mail
 * Author: 		bof (bjoern@n4rf.de)
 * Created: 	2008-04-30
 * -----------------------------------------------------------------------
 * -------------------------------------------------------- Description *-
 * -----------------------------------------------------------------------
 * This Class handle the Communcation to the SMTP Server
 * 
 */

using System;
using System.Collections;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace utac.Components.Mail
{
	public class SmtpException : ApplicationException
	{
		public SmtpException(string message) : base(message)
		{
		}
	}

	/// <summary>
	/// Indicates the type of message to be sent
	/// </summary>
	public enum MessageType
	{
		// The message is plain text
		Text = 0,
		// The message is HTML
		HTML = 1
	}

	

	
	/// <summary>
	/// A mail message that can be sent using the Smtp class
	/// </summary>
	public class MailMessage
	{
		private string _emailFrom = "";
		public string EmailFrom
		{
			get { return _emailFrom; }
			set { _emailFrom = value; }
		}
		
		private string _emailSubject = "";
		public string EmailSubject
		{
			get { return _emailSubject; }
			set { _emailSubject = value; }
		}
		
		private ArrayList _emailTo = null;
		public ArrayList EmailTo
		{
			get { return _emailTo; }
		}
		public void AddEmailTo(string email)
		{
			if(_emailTo == null)
				_emailTo = new ArrayList();
			_emailTo.Add(email);
		}
		
		private string _emailMessage = "";
		public string EmailMessage
		{
			get { return _emailMessage; }
			set { _emailMessage = value; }
		}
		
		private MessageType _emailMessageType = MessageType.Text;
		public MessageType EmailMessageType
		{
			get { return _emailMessageType; }
			set { _emailMessageType = value; }
		}
	}

	/// <summary>
	/// SMTP Class
	/// </summary>
	public class Smtp
	{
		#region Class properties
		private string _serverSmtp = "";
		public string SmtpServer
		{
			get { return _serverSmtp; }
			set { _serverSmtp = value; }
		}

		private int _portSmtp = 25;
		public int SmtpPort
		{
			get { return _portSmtp; }
			set { _portSmtp = value; }
		}
		
		private string _userSmtp = "";
		public string SmtpUser
		{
			get { return _userSmtp; }
			set { _userSmtp = value; }
		}
		
		private string _passwordSmtp = "";
		public string SmtpPassword
		{
			get { return _passwordSmtp; }
			set { _passwordSmtp = value; }
		}

		#endregion

	    #region Public methods

		
		/// <summary>
		/// Sends the e-mail based on the properties set for this object
		/// </summary>
		/// <param name="msg">MailMessage</param>
		public void SendEmail(MailMessage msg)
		{
		    if(_serverSmtp == "" || msg.EmailFrom == "" || msg.EmailSubject == "" || msg.EmailTo == null)
			{
				throw new SmtpException("Invalid Smtp or email parameters.");
			}

			// open a connection to the Smtp server
			using(TcpClient smtpSocket = new TcpClient(_serverSmtp, _portSmtp))
				using(NetworkStream ns = smtpSocket.GetStream())
			{
				// get response from Smtp server
				int code = GetSmtpResponse(ReadBuffer(ns));
				if(code != 220)
				{
					throw new SmtpException("Error connecting to Smtp server. (" + code + ")");
				}
				// EHLO
				WriteBuffer(ns, "ehlo UTAC\r\n");
				// get response from Smtp server
				string buffer = ReadBuffer(ns);
				code = GetSmtpResponse(buffer);
				if(code != 250)
				{
					throw new SmtpException("Error initiating communication with Smtp server. (" + code + ")");
				}
				// check for AUTH=LOGIN
				if(buffer.IndexOf("AUTH=LOGIN") >= 0)
				{
					// AUTH LOGIN
					WriteBuffer(ns, "auth login\r\n");
					// get response from Smtp server
					code = GetSmtpResponse(ReadBuffer(ns));
					if(code != 334)
					{
						throw new SmtpException("Error initiating Auth=Login. (" + code + ")");
					}

					// username:
					WriteBuffer(ns, Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(_userSmtp)) + "\r\n");
					// get response from Smtp server
					code = GetSmtpResponse(ReadBuffer(ns));
					if(code != 334)
					{
						throw new SmtpException("Error setting Auth user name. (" + code + ")");
					}
					// password:
					WriteBuffer(ns, Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(_passwordSmtp)) + "\r\n");
					// get response from Smtp server
					code = GetSmtpResponse(ReadBuffer(ns));
					if(code != 235)
					{
						throw new SmtpException("Error setting Auth password. (" + code + ")");
					}
				}

				// MAIL FROM:
				WriteBuffer(ns, "mail from: <" + msg.EmailFrom + ">\r\n");
				// get response from Smtp server
				code = GetSmtpResponse(ReadBuffer(ns));
				if(code != 250)
				{
					throw new SmtpException("Error setting sender email address. (" + code + ")");
				}



				// RCPT TO:
				foreach(string sEmailTo in msg.EmailTo)
				{
					WriteBuffer(ns, "rcpt to:<" + sEmailTo + ">\r\n");
					// get response from Smtp server
					code = GetSmtpResponse(ReadBuffer(ns));
					if(code != 250 && code != 251)
					{
						throw new SmtpException("Error setting receipient email address. (" + code + ")");
					}
				}
				// DATA
				WriteBuffer(ns, "data\r\n");
				// get response from Smtp server
				code = GetSmtpResponse(ReadBuffer(ns));
				if(code != 354)
				{
					throw new SmtpException("Error starting email body. (" + code + ")");
				}
				// Repeat the from and to addresses in the data section
				WriteBuffer(ns, "from:<" + msg.EmailFrom + ">\r\n");
				foreach(string sEmailTo in msg.EmailTo)
				{
					WriteBuffer(ns, "to:<" + sEmailTo + ">\r\n");
				}
                WriteBuffer(ns, "date: " + DateTime.Now.ToString("r") + ">\r\n"); // Inserted for compatibility 2010.01.05
				WriteBuffer(ns, "Subject:" + msg.EmailSubject + "\r\n");
				switch(msg.EmailMessageType)
				{
					case MessageType.Text:
						// send text message
						WriteBuffer(ns, "\r\n" + msg.EmailMessage + "\r\n.\r\n");
						break;
					case MessageType.HTML:
						// send HTML message
						WriteBuffer(ns, "MIME-Version: 1.0\r\n");
						WriteBuffer(ns, "Content-type: text/html\r\n");
						WriteBuffer(ns, "\r\n" + msg.EmailMessage + "\r\n.\r\n");
						break;
				}
				// get response from Smtp server
				code = GetSmtpResponse(ReadBuffer(ns));
				if(code != 250)
				{
					throw new SmtpException("Error setting email body. (" + code + ")");
				}

				// QUIT
				WriteBuffer(ns, "quit\r\n");

			}

		}

		#endregion
		#region Private methods

		/// <summary>
		/// Looks for an Smtp response code inside a repsonse string
		/// </summary>
		/// <param name="sResponse">The response string to be searched</param>
		/// <returns>The int value of the Smtp reponse code</returns>
		private static int GetSmtpResponse(string sResponse)
		{
			int response = 0;
			int iSpace = sResponse.IndexOf(" ");
			int iDash = sResponse.IndexOf("-");
			if(iDash > 0 && iDash < iSpace)
				iSpace = sResponse.IndexOf("-");
			
			try
			{
				if(iSpace > 0)
					response = int.Parse(sResponse.Substring(0, iSpace));
			}
			catch(Exception)
			{
				// error - ignore it
			}
			
			return response;
		}
		
		/// <summary>
		/// Write a string to the network stream
		/// </summary>
		/// <param name="ns">The network stream on which to write</param>
		/// <param name="sBuffer">>The string to write to the stream</param>
		private static void WriteBuffer(Stream ns, string sBuffer)
		{
			try
			{
				byte[] buffer = Encoding.ASCII.GetBytes(sBuffer);
				ns.Write(buffer, 0, buffer.Length);
			}
			catch(IOException)
			{
				// error writing to stream
				throw new SmtpException("Error sending data to Smtp server.");
			}
		}
		
		/// <summary>
		/// Reads a response from the network stream
		/// </summary>
		/// <param name="ns">The network stream from which to read</param>
		/// <returns>A string representing the reponse rea</returns>
		private static string ReadBuffer(NetworkStream ns)
		{
			byte[] buffer = new byte[1024];
			int i=0;
		    int timeout = Environment.TickCount;
			
			try
			{
				// wait for data to show up on the stream
				while(!ns.DataAvailable && ((Environment.TickCount - timeout) < 20000))
				{
					System.Threading.Thread.Sleep(100);
				}
				if(!ns.DataAvailable)
					throw new SmtpException("No response received from Smtp server.");
				
				// read while there's data on the stream
				while(i < buffer.Length && ns.DataAvailable)
				{
				    int b = ns.ReadByte();
				    buffer[i++] = (byte)b;
				}
			}
			catch(IOException)
			{
				// error reading from stream
				throw new SmtpException("Error receiving data from Smtp server.");
			}
			
			return Encoding.ASCII.GetString(buffer);
		}
		#endregion
	}
}

