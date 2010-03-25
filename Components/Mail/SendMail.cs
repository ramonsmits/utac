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
 * FileName: 	SendMail.cs
 * Namespace: 	utac.Components.Mail
 * Author: 		bof (bjoern@n4rf.de)
 * Created: 	2008-04-30
 * -----------------------------------------------------------------------
 * -------------------------------------------------------- Description *-
 * -----------------------------------------------------------------------
 * With this class you can easily send mails with Settings from GlobalVars
 * so you just need a subject and a body message.
 * 
 */

using utac.Components.Settings;
using System.Windows.Forms;

namespace utac.Components.Mail
{
	/// <summary>
	/// Sendmail Class
	/// </summary>
	public class SendMail
	{
		/// <summary>
		/// Simple E-Mail Function, you just need Subject and Message
		/// the rest is taken from the GlobalVars
		/// </summary>
		/// <param name="subject">Subject for the Mail</param>
		/// <param name="message">Body Message for the Mail</param>
		public static void Send(string subject, string message, bool showDebug)
		{
			bool mailError = false;
			try{
				MailMessage msg = new MailMessage();
				msg.EmailFrom = GlobalVars.config_mail_from;
				msg.AddEmailTo(GlobalVars.config_mail_to);
				msg.EmailMessageType = MessageType.Text;
				msg.EmailMessage = message;
				msg.EmailSubject = subject;
				Smtp smtp = new Smtp();

                

                smtp.SmtpPort = System.Convert.ToInt16(GlobalVars.config_mail_server_port);
				smtp.SmtpServer = GlobalVars.config_mail_server;
				smtp.SmtpUser = GlobalVars.config_mail_user;
				smtp.SmtpPassword = GlobalVars.config_mail_password;
				smtp.SendEmail(msg);
			} catch (SmtpException e) {
				if (showDebug) {
					mailError = true;
					MessageBox.Show(e.ToString());
				}
			}
			if (showDebug && !mailError) {
				MessageBox.Show(GlobalVars.lang_mailsuccessfullysent);
			}
		}
	}
}
