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
 * FileName: 	XMLWebServer.cs
 * Namespace: 	utac.Components.WebServer
 * Author: 		bof (bjoern@n4rf.de)
 * Created: 	2008-02-12
 * -----------------------------------------------------------------------
 * -------------------------------------------------------- Description *-
 * -----------------------------------------------------------------------
 * This is the built in XMLWebServer
 */

using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using utac.Components.Settings;

namespace utac.Components.WebServer
{
    public class XMLWebServer
    {

        private TcpListener myListener;
        private int port = 5051;
        private static readonly string LogFileName = "LOG-XMLWEBSERVER.txt";

        readonly object stopLock = new object();
        /// <summary>
        /// Whether or not the thread has been asked to stop
        /// </summary>
        bool stopping = false;
        /// <summary>
        /// Whether or not the thread has stopped
        /// </summary>
        bool stopped = false;


        //The Start method which makes the TcpListener start listening on the
        //given port. It also calls a Thread on the method StartListen().
        public void Start()
        {
            port = GlobalVars.config_BIWXMLPort;
            stopping = false;
            stopped = false;
            try
            {
                Thread th = new Thread(StartListen);
                th.Start();
            }
            catch (Exception e)
            {
                log("An Exception Occurred while Listening :" + e.Message);
            }

        }

        /// <summary>
        /// This function send the Header Information to the client (Browser)
        /// </summary>
        /// <param name="sHttpVersion">HTTP Version</param>
        /// <param name="sMIMEHeader">Mime Type</param>
        /// <param name="iTotBytes">Total Bytes to be sent in the body</param>
        /// <param name="sStatusCode"></param>
        /// <param name="mySocket">Socket reference</param>
        /// <returns></returns>
        static void SendHeader(string sHttpVersion, string sMIMEHeader, int iTotBytes, string sStatusCode, ref Socket mySocket)
        {
            String sBuffer = "";
            // if Mime type is not provided set default to text/html
            if (sMIMEHeader.Length == 0)
            {
                sMIMEHeader = "text/html";  // Default Mime Type is text/html
            }

            sBuffer = sBuffer + sHttpVersion + sStatusCode + "\r\n";
            sBuffer = sBuffer + "Server: UTAC " + GlobalVars._UTACVERSION + " WebServer \r\n";
            sBuffer = sBuffer + "Content-Type: " + sMIMEHeader + "\r\n";
            sBuffer = sBuffer + "Accept-Ranges: bytes\r\n";
            sBuffer = sBuffer + "Content-Length: " + iTotBytes + "\r\n\r\n";
            Byte[] bSendData = Encoding.ASCII.GetBytes(sBuffer);
            SendToBrowser(bSendData, ref mySocket);

        }


        public static void log(string newLogLine)
        {
            DateTime dt = DateTime.Now;
            string currentDate = dt.ToString("yyyy-MM-dd HH:mm:ss");

            if (GlobalVars.config_log)
            {
                try
                {
                    StreamWriter SW;
                    SW = File.AppendText(LogFileName);
                    SW.WriteLine("[" + currentDate + "] " + newLogLine);
                    SW.Close();
                }
                catch (Exception) { }
            }
        }



        /// <summary>
        /// Overloaded Function, takes string, convert to bytes and calls
        /// overloaded sendToBrowserFunction.
        /// </summary>
        /// <param name="sData">The data to be sent to the browser(client)</param>
        /// <param name="mySocket">Socket reference</param>
        static void SendToBrowser(String sData, ref Socket mySocket)
        {
            SendToBrowser(Encoding.ASCII.GetBytes(sData), ref mySocket);
        }

        /// <summary>
        /// Sends data to the browser (client)
        /// </summary>
        /// <param name="bSendData">Byte Array</param>
        /// <param name="mySocket">Socket reference</param>
        static void SendToBrowser(Byte[] bSendData, ref Socket mySocket)
        {
            try
            {
                if (mySocket.Connected)
                {
                    int numBytes;
                    switch ((numBytes = mySocket.Send(bSendData, bSendData.Length, 0)))
                    {
                        case -1:
                            log("Socket Error cannot Send Packet");
                            break;
                        default:
                            log("No. of bytes send " + numBytes);
                            break;
                    }
                }
                else { log("Connection Dropped...."); }
            }
            catch (Exception e)
            {
                log("Error occured: " + e.Message);

            }
        }

        // TODO: The following method is unused
        //byte[] imageToByteArray(System.Drawing.Image imageIn)
        //{
        //    MemoryStream ms = new MemoryStream();
        //    imageIn.Save(ms,System.Drawing.Imaging.ImageFormat.Jpeg);
        //    return  ms.ToArray();
        //}

        /// <summary>
        /// Returns whether the thread has been asked to stop.
        /// This continues to return true even after the thread has stopped.
        /// </summary>
        public bool Stopping
        {
            get
            {
                lock (stopLock)
                {
                    return stopping;
                }
            }
        }
        /// <summary>
        /// Returns whether the thread has stopped.
        /// </summary>
        public bool Stopped
        {
            get
            {
                lock (stopLock)
                {
                    return stopped;
                }
            }
        }

        /// <summary>
        /// Tells the thread to stop, typically after completing its
        /// current work item. Also Stops the Listener who block the thread.
        /// </summary>
        public void Stop()
        {
            lock (stopLock)
            {
                try
                {
                    if (myListener != null)
                    {
                        myListener.Stop();
                    }
                }
                catch (Exception e) { log("TCPListener Stop: " + e.Message); }
                stopping = true;
            }
        }

        /// <summary>
        /// Called by the thread to indicate when it has stopped.
        /// </summary>
        void SetStopped()
        {
            lock (stopLock)
            {
                stopped = true;
            }
        }

        //This method Accepts new connection and
        //First it receives the welcome massage from the client,
        //Then it send the requested Data
        void StartListen()
        {
            String sRequest;
            //TODO: The following line has been removed because sMyWebServerRoot is never used
            //String sMyWebServerRoot = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)+"\\WebServer\\";

            Socket mySocket = null;
            try
            {
                myListener = new TcpListener(System.Net.IPAddress.Any, port);
                myListener.Start();
                while (!Stopping)
                {

                    //Accept a new connection
                    try
                    {
                        mySocket = myListener.AcceptSocket();
                    }
                    catch { }
                    if (mySocket != null)
                    {
                        if (mySocket.Connected)
                        {
                            log("New Connection: " + mySocket.RemoteEndPoint);

                            //make a byte array and receive data from the client
                            Byte[] bReceive = new Byte[1024];
                            mySocket.Receive(bReceive, bReceive.Length, 0);

                            //Convert Byte to String
                            string sBuffer = Encoding.ASCII.GetString(bReceive);

                            //At present we will only deal with GET type
                            if (sBuffer.Substring(0, 3) != "GET")
                            {
                                log("Only Get Method is supported.. Socket closed");
                                mySocket.Close();
                                return;
                            }

                            // Look for HTTP request
                            int iStartPos = sBuffer.IndexOf("HTTP", 1);
                            // Get the HTTP text and version e.g. it will return "HTTP/1.1"
                            string sHttpVersion = sBuffer.Substring(iStartPos, 8);
                            // Extract the Requested Type and Requested file/directory
                            sRequest = sBuffer.Substring(0, iStartPos - 1);
                            //Replace backslash with Forward Slash, if Any
                            sRequest.Replace("\\", "/");

                            //If file name is not supplied add forward slash to indicate
                            //that it is a directory and then we will look for the
                            //default file name..
                            if ((sRequest.IndexOf(".") < 1) && (!sRequest.EndsWith("/")))
                            {
                                sRequest = sRequest + "/";
                            }

                            //Extract the requested file name
                            iStartPos = sRequest.LastIndexOf("/") + 1;
                            String sRequestedFile = sRequest.Substring(iStartPos);

                            // Identify the File Name
                            log("File Requested : " + sRequestedFile);

                            if (GlobalVars.config_BIWXMLRefreshOnAccess)
                            {
                                GlobalVars.externalRefresh = true;
                                Thread.Sleep(400);
                            }

                            StringBuilder xmlMessage = new StringBuilder();
                            xmlMessage.Append("<utacxmlwebserver>\n");
                            xmlMessage.Append("<actual>\n");

                            if (GlobalVars.currentts.Length > 0)
                            {
                                int i;
                                for (i = 0; i < GlobalVars.devicecount; i++)
                                {
                                    xmlMessage.Append("<temp" + i + ">" + GlobalVars.currenttemp[i] + "</temp" + i + ">\n");
                                    xmlMessage.Append("<hum" + i + ">" + GlobalVars.currenthum[i] + "</hum" + i + ">\n");
                                    xmlMessage.Append("<timestamp" + i + ">" + GlobalVars.currentts[i] + "</timestamp" + i + ">\n");
                                }
                            }

                            else
                            {
                                xmlMessage.Append("<temp></temp>\n");
                                xmlMessage.Append("<timestamp></timestamp>\n");
                            }
                            xmlMessage.Append("</actual>\n");

                            xmlMessage.Append("</utacxmlwebserver>\n");
                            SendHeader(sHttpVersion, "text/xml", xmlMessage.ToString().Length, " 200 OK", ref mySocket);
                            SendToBrowser(xmlMessage.ToString(), ref mySocket);
                            mySocket.Close();
                        }
                    }
                    if (mySocket != null)
                    {
                        mySocket.Close();
                    }
                }
            }
            finally
            {
                SetStopped();
            }
        }
    }
}
