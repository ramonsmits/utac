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
 * FileName: 	FtpClient.cs
 * Namespace: 	utac.Components.FtpClient
 * Author: 		bof (bjoern@n4rf.de)
 * Created: 	2008-02-06
 * -----------------------------------------------------------------------
 * -------------------------------------------------------- Description *-
 * -----------------------------------------------------------------------
 * FTP Client library in C#
 * Author: Jaimon Mathew
 * mailto:jaimonmathew@rediffmail.com
 * http://www.csharphelp.com/archives/archive9.html
 * 
 * Adapted for use by Dan Glass 07/03/03
 * 
 * Deprecated routines updated and a little bit modified 
 * for UTAC by Bjoern -bof- Boettcher 2008-02-06.
 * 
 */

using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace utac.Components.FtpClient
{

    public class FtpClient
    {

        public class FtpException : Exception
        {
            public FtpException(string message) : base(message) { }
            public FtpException(string message, Exception innerException) : base(message, innerException) { }
        }

        private static readonly int BUFFER_SIZE = 512;
        private static readonly Encoding ASCII = Encoding.ASCII;

        private bool verboseDebugging = false;

        // defaults
        private string server = "localhost";
        private string remotePath = ".";
        private string username = "anonymous";
        private string password = "anonymous@anonymous.net";
        private string message = null;
        private string result = null;

        private int port = 21;
        private int bytes = 0;
        private int resultCode = 0;
        private int maxto = 1600;

        private bool loggedin = false;
        private bool binMode = false;

        private readonly Byte[] buffer = new Byte[BUFFER_SIZE];
        private Socket clientSocket = null;

        private int timeoutSeconds = 10;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public FtpClient()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="server"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public FtpClient(string server, string username, string password)
        {
            this.server = server;
            this.username = username;
            this.password = password;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="server"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="timeoutSeconds"></param>
        /// <param name="port"></param>
        public FtpClient(string server, string username, string password, int timeoutSeconds, int port)
        {
            this.server = server;
            this.username = username;
            this.password = password;
            this.timeoutSeconds = timeoutSeconds;
            this.port = port;
        }

        /// <summary>
        /// Display all communications to the debug log
        /// </summary>
        public bool VerboseDebugging
        {
            get
            {
                return verboseDebugging;
            }
            set
            {
                verboseDebugging = value;
            }
        }
        /// <summary>
        /// Remote server port. Typically TCP 21
        /// </summary>
        public int Port
        {
            get
            {
                return port;
            }
            set
            {
                port = value;
            }
        }
        /// <summary>
        /// Timeout waiting for a response from server, in seconds.
        /// </summary>
        public int Timeout
        {
            get
            {
                return timeoutSeconds;
            }
            set
            {
                timeoutSeconds = value;
            }
        }
        /// <summary>
        /// Gets and Sets the name of the FTP server.
        /// </summary>
        /// <returns></returns>
        public string Server
        {
            get
            {
                return server;
            }
            set
            {
                server = value;
            }
        }
        /// <summary>
        /// Gets and Sets the port number.
        /// </summary>
        /// <returns></returns>
        public int RemotePort
        {
            get
            {
                return port;
            }
            set
            {
                port = value;
            }
        }
        /// <summary>
        /// GetS and Sets the remote directory.
        /// </summary>
        public string RemotePath
        {
            get
            {
                return remotePath;
            }
            set
            {
                remotePath = value;
            }

        }
        /// <summary>
        /// Gets and Sets the username.
        /// </summary>
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }
        /// <summary>
        /// Gets and Set the password.
        /// </summary>
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        /// <summary>
        /// If the value of mode is true, set binary mode for downloads, else, Ascii mode.
        /// </summary>
        public bool BinaryMode
        {
            get
            {
                return binMode;
            }
            set
            {
                //			if ( binMode == value ) return;
                binMode = value;
                if (value)
                {
                    sendCommand("TYPE I");
                }
                else
                {
                    sendCommand("TYPE A");
                }
                if (resultCode != 200) throw new FtpException(result.Substring(4));
            }
        }
        /// <summary>
        /// Login to the remote server.
        /// </summary>
        public void Login()
        {
            if (loggedin) Close();

            TEMPer.TEMPerInterface.log("Opening ftp connection.");

            Debug.WriteLine("Opening connection to " + server, "FtpClient");
            try
            {
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress addr = Dns.GetHostEntry(server).AddressList[0];
                IPEndPoint ep = new IPEndPoint(addr, port);
                clientSocket.Connect(ep);
            }
            catch (Exception ex)
            {
                // doubtfull
                if (clientSocket != null && clientSocket.Connected) clientSocket.Close();
                TEMPer.TEMPerInterface.log("Couldn't connect to remote server.");
                throw new FtpException("Couldn't connect to remote server", ex);
            }

            TEMPer.TEMPerInterface.log("Connected to remote server.");

            readResponse();

            if (resultCode != 220)
            {
                Close();
                if (result.Length > 5)
                    throw new FtpException(result.Substring(4));
                else
                    throw new FtpException("FTP returned no response code: " + result);
            }

            //            TEMPer.TEMPerInterface.log("Sending USER " + username);

            sendCommand("USER " + username);


            if (!(resultCode == 331 || resultCode == 230))
            {
                cleanup();
                throw new FtpException(result.Substring(4));
            }

            if (resultCode != 230)
            {

                //                TEMPer.TEMPerInterface.log("Sending PASS " + password);

                sendCommand("PASS " + password);

                if (!(resultCode == 230 || resultCode == 202))
                {
                    cleanup();
                    throw new FtpException(result.Substring(4));
                }
            }

            loggedin = true;

            Debug.WriteLine("Connected to " + server, "FtpClient");
            TEMPer.TEMPerInterface.log("Connected to " + server);

            ChangeDir(remotePath);
            BinaryMode = binMode;
        }

        /// <summary>
        /// Close the FTP connection.
        /// </summary>
        public void Close()
        {
            Debug.WriteLine("Closing connection to " + server, "FtpClient");

            if (clientSocket != null)
            {
                sendCommand("QUIT");
            }

            cleanup();
        }

        /// <summary>
        /// Return a string array containing the remote directory's file list.
        /// </summary>
        /// <returns></returns>
        public string[] GetFileList()
        {
            return GetFileList("*.*");
        }

        /// <summary>
        /// Return a string array containing the remote directory's file list.
        /// </summary>
        /// <param name="mask"></param>
        /// <returns></returns>
        public string[] GetFileList(string mask)
        {
            if (!loggedin) Login();

            Socket cSocket = createDataSocket();

            sendCommand("NLST " + mask);

            if (!(resultCode == 150 || resultCode == 125)) throw new FtpException(result.Substring(4));

            message = "";

            DateTime timeout = DateTime.Now.AddSeconds(timeoutSeconds);

            while (timeout > DateTime.Now)
            {
                int bytes = cSocket.Receive(buffer, buffer.Length, 0);
                message += ASCII.GetString(buffer, 0, bytes);

                if (bytes < buffer.Length) break;
            }

            string[] msg = message.Replace("\r", "").Split('\n');

            cSocket.Close();

            if (message.IndexOf("No such file or directory") != -1)
                msg = new string[] { };

            readResponse();

            if (resultCode != 226)
                msg = new string[] { };
            //	throw new FtpException(result.Substring(4));

            return msg;
        }

        /// <summary>
        /// Return the size of a file.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public long GetFileSize(string fileName)
        {
            if (!loggedin) Login();

            sendCommand("SIZE " + fileName);
            long size;

            if (resultCode == 213)
                size = long.Parse(result.Substring(4));

            else
                throw new FtpException(result.Substring(4));

            return size;
        }


        /// <summary>
        /// Download a file to the Assembly's local directory,
        /// keeping the same file name.
        /// </summary>
        /// <param name="remFileName"></param>
        public void Download(string remFileName)
        {
            Download(remFileName, "", false);
        }

        /// <summary>
        /// Download a remote file to the Assembly's local directory,
        /// keeping the same file name, and set the resume flag.
        /// </summary>
        /// <param name="remFileName"></param>
        /// <param name="resume"></param>
        public void Download(string remFileName, Boolean resume)
        {
            Download(remFileName, "", resume);
        }

        /// <summary>
        /// Download a remote file to a local file name which can include
        /// a path. The local file name will be created or overwritten,
        /// but the path must exist.
        /// </summary>
        /// <param name="remFileName"></param>
        /// <param name="locFileName"></param>
        public void Download(string remFileName, string locFileName)
        {
            Download(remFileName, locFileName, false);
        }

        /// <summary>
        /// Download a remote file to a local file name which can include
        /// a path, and set the resume flag. The local file name will be
        /// created or overwritten, but the path must exist.
        /// </summary>
        /// <param name="remFileName"></param>
        /// <param name="locFileName"></param>
        /// <param name="resume"></param>
        public void Download(string remFileName, string locFileName, Boolean resume)
        {
            if (!loggedin) Login();

            BinaryMode = true;

            Debug.WriteLine("Downloading file " + remFileName + " from " + server + "/" + remotePath, "FtpClient");

            if (locFileName.Equals(""))
            {
                locFileName = remFileName;
            }

            FileStream output;

            if (!File.Exists(locFileName))
                output = File.Create(locFileName);

            else
                output = new FileStream(locFileName, FileMode.Open);

            Socket cSocket = createDataSocket();

            if (resume)
            {
                if (output != null)
                {
                    long offset = output.Length;

                    if (offset > 0)
                    {
                        sendCommand("REST " + offset);
                        if (resultCode != 350)
                        {
                            //Server dosnt support resuming
                            /*
                                                    offset = 0;
                            */
                            Debug.WriteLine("Resuming not supported:" + result.Substring(4), "FtpClient");
                        }
                        else
                        {
                            Debug.WriteLine("Resuming at offset " + offset, "FtpClient");
                            output.Seek(offset, SeekOrigin.Begin);
                        }
                    }
                }
            }

            sendCommand("RETR " + remFileName);

            if (resultCode != 150 && resultCode != 125)
            {
                throw new FtpException(result.Substring(4));
            }

            DateTime timeout = DateTime.Now.AddSeconds(timeoutSeconds);

            while (timeout > DateTime.Now)
            {
                bytes = cSocket.Receive(buffer, buffer.Length, 0);
                if (output != null) output.Write(buffer, 0, bytes);

                if (bytes <= 0)
                {
                    break;
                }
            }

            if (output != null) output.Close();

            if (cSocket.Connected) cSocket.Close();

            readResponse();

            if (resultCode != 226 && resultCode != 250)
                throw new FtpException(result.Substring(4));
        }


        /// <summary>
        /// Upload a file.
        /// </summary>
        /// <param name="fileName"></param>
        public void Upload(string fileName)
        {
            Upload(fileName, false);
        }


        /// <summary>
        /// Upload a file and set the resume flag.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="resume"></param>
        public void Upload(string fileName, bool resume)
        {
            if (!loggedin) Login();

            Socket cSocket;
            long offset = 0;

            if (resume)
            {
                try
                {
                    BinaryMode = true;

                    offset = GetFileSize(Path.GetFileName(fileName));
                }
                catch (Exception)
                {
                    // file not exist
                    offset = 0;
                }
            }

            // open stream to read file
            FileStream input = null;
            try
            {
                input = new FileStream(fileName, FileMode.Open);
            }
            catch
            {

            }

            if (resume && input.Length < offset)
            {
                // different file size
                Debug.WriteLine("Overwriting " + fileName, "FtpClient");
                offset = 0;
            }
            else if (resume && input.Length == offset)
            {
                // file done
                input.Close();
                Debug.WriteLine("Skipping completed " + fileName + " - turn resume off to not detect.", "FtpClient");
                return;
            }

            // dont create untill we know that we need it
            cSocket = createDataSocket();

            if (offset > 0)
            {
                sendCommand("REST " + offset);
                if (resultCode != 350)
                {
                    Debug.WriteLine("Resuming not supported", "FtpClient");
                    offset = 0;
                }
            }

            sendCommand("STOR " + Path.GetFileName(fileName));

            if (resultCode != 125 && resultCode != 150) throw new FtpException(result.Substring(4));

            if (offset != 0)
            {
                Debug.WriteLine("Resuming at offset " + offset, "FtpClient");

                if (input != null) input.Seek(offset, SeekOrigin.Begin);
            }

            Debug.WriteLine("Uploading file " + fileName + " to " + remotePath, "FtpClient");

            DateTime timeout = DateTime.Now.AddSeconds(timeoutSeconds);

            if (input != null)
            {

                int sent = 0;

                bytes = input.Read(buffer, 0, buffer.Length);

                while (bytes > 0 && timeout > DateTime.Now)
                {
                    try
                    {
                        sent += cSocket.Send(buffer, sent, bytes - sent, SocketFlags.None);
                    }
                    catch (SocketException ex)
                    {
                        if (ex.SocketErrorCode == SocketError.WouldBlock ||
                           ex.SocketErrorCode == SocketError.IOPending ||
                          ex.SocketErrorCode == SocketError.NoBufferSpaceAvailable)
                        {
                            // socket buffer is probably full, wait and try again
                            System.Threading.Thread.Sleep(30);
                        }
                        else
                            throw ex;  // any serious error occurr
                    }

                    if (sent >= bytes)
                    {
                        sent = 0;
                        bytes = input.Read(buffer, 0, buffer.Length);
                    }

                }

            }


            if (input != null) input.Close();

            if (cSocket.Connected)
            {
                cSocket.Close();
            }

            readResponse();

            if (resultCode != 226 && resultCode != 250) throw new FtpException(result.Substring(4));
        }

        /// <summary>
        /// Upload a directory and its file contents
        /// </summary>
        /// <param name="path"></param>
        /// <param name="recurse">Whether to recurse sub directories</param>
        public void UploadDirectory(string path, bool recurse)
        {
            UploadDirectory(path, recurse, "*.*");
        }

        /// <summary>
        /// Upload a directory and its file contents
        /// </summary>
        /// <param name="path"></param>
        /// <param name="recurse">Whether to recurse sub directories</param>
        /// <param name="mask">Only upload files of the given mask - everything is '*.*'</param>
        public void UploadDirectory(string path, bool recurse, string mask)
        {
            string[] dirs = path.Replace("/", @"\").Split('\\');
            string rootDir = dirs[dirs.Length - 1];

            // make the root dir if it doed not exist
            if (GetFileList(rootDir).Length < 1) MakeDir(rootDir);

            ChangeDir(rootDir);

            foreach (string file in Directory.GetFiles(path, mask))
            {
                Upload(file, true);
            }
            if (recurse)
            {
                foreach (string directory in Directory.GetDirectories(path))
                {
                    UploadDirectory(directory, recurse, mask);
                }
            }

            ChangeDir("..");
        }

        /// <summary>
        /// Delete a file from the remote FTP server.
        /// </summary>
        /// <param name="fileName"></param>
        public void DeleteFile(string fileName)
        {
            if (!loggedin) Login();

            sendCommand("DELE " + fileName);

            if (resultCode != 250) throw new FtpException(result.Substring(4));

            Debug.WriteLine("Deleted file " + fileName, "FtpClient");
        }

        /// <summary>
        /// Rename a file on the remote FTP server.
        /// </summary>
        /// <param name="oldFileName"></param>
        /// <param name="newFileName"></param>
        /// <param name="overwrite">setting to false will throw exception if it exists</param>
        public void RenameFile(string oldFileName, string newFileName, bool overwrite)
        {
            if (!loggedin) Login();

            sendCommand("RNFR " + oldFileName);

            if (resultCode != 350) throw new FtpException(result.Substring(4));

            if (!overwrite && GetFileList(newFileName).Length > 0) throw new FtpException("File already exists");

            sendCommand("RNTO " + newFileName);

            if (resultCode != 250) throw new FtpException(result.Substring(4));

            Debug.WriteLine("Renamed file " + oldFileName + " to " + newFileName, "FtpClient");
        }

        /// <summary>
        /// Create a directory on the remote FTP server.
        /// </summary>
        /// <param name="dirName"></param>
        public void MakeDir(string dirName)
        {
            if (!loggedin) Login();

            sendCommand("MKD " + dirName);

            if (resultCode != 250 && resultCode != 257) throw new FtpException(result.Substring(4));

            Debug.WriteLine("Created directory " + dirName, "FtpClient");
        }

        /// <summary>
        /// Delete a directory on the remote FTP server.
        /// </summary>
        /// <param name="dirName"></param>
        public void RemoveDir(string dirName)
        {
            if (!loggedin) Login();

            sendCommand("RMD " + dirName);

            if (resultCode != 250) throw new FtpException(result.Substring(4));

            Debug.WriteLine("Removed directory " + dirName, "FtpClient");
        }

        /// <summary>
        /// Change the current working directory on the remote FTP server.
        /// </summary>
        /// <param name="dirName"></param>
        public void ChangeDir(string dirName)
        {
            if (dirName == null || dirName.Equals(".") || dirName.Length == 0)
            {
                return;
            }

            if (!loggedin) Login();

            sendCommand("CWD " + dirName);

            if (resultCode != 250) throw new FtpException(result.Substring(4));

            sendCommand("PWD");

            if (resultCode != 257) throw new FtpException(result.Substring(4));

            // gonna have to do better than ...
            remotePath = message.Split('"')[1];

            Debug.WriteLine("Current directory is " + remotePath, "FtpClient");
        }

        /// <summary>
        /// 
        /// </summary>
        private void readResponse()
        {
            message = "";
            result = readLine();

            if (result.Length > 3)
            {
                resultCode = int.Parse(result.Substring(0, 3));
            }
            else
            {
                result = "000 No string read from host.";
                resultCode = 0;
            }

            if (result.Length < 10) result += "No string read from host.";

            TEMPer.TEMPerInterface.log("Result:" + resultCode + ":" + result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string readLine()
        {
            int to = 0;
            while (clientSocket != null && clientSocket.Connected)
            {
                bytes = clientSocket.Receive(buffer, buffer.Length, 0);
                message += ASCII.GetString(buffer, 0, bytes);
                if (!clientSocket.Connected || clientSocket.Available == 0 || to > maxto)
                {
                    break;
                }
                to++;
            }

            if (to > maxto)
                TEMPer.TEMPerInterface.log("...Timed Out");

            // TEMPer.TEMPerInterface.log("Big Message:" + message);

            string[] msg = message.Split('\n');

            message = "";
            int k = 0;
            // Search for pattern ### xxxxxxxx
            while (k < msg.Length)
            {
                if (msg[k].Length > 4 && msg[k].Substring(3, 1).Equals(" "))
                {
                    // TEMPer.TEMPerInterface.log("Found token: msg[" + k + "]=" + msg[k]);
                    message = msg[k];
                }
                k++;
            }

            if (message.Length < 4 && to < maxto && clientSocket != null && clientSocket.Connected) return readLine(); // Get more...

            if (verboseDebugging)
            {
                for (int i = 0; i < msg.Length - 1; i++)
                {
                    Debug.Write(msg[i], "FtpClient");
                }
            }

            message.Replace('\r', ' ');
            message.Replace('\n', ' ');

            return message;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        private void sendCommand(String command)
        {
            if (verboseDebugging) Debug.WriteLine(command, "FtpClient");

            TEMPer.TEMPerInterface.log("Sending Command:" + command);

            Byte[] cmdBytes = Encoding.ASCII.GetBytes((command + "\r\n").ToCharArray());
            if (clientSocket != null && clientSocket.Connected)
            {
                clientSocket.Send(cmdBytes, cmdBytes.Length, 0);
                readResponse();
            }
        }

        /// <summary>
        /// when doing data transfers, we need to open another socket for it.
        /// </summary>
        /// <returns>Connected socket</returns>
        private Socket createDataSocket()
        {
            sendCommand("PASV");

            if (resultCode != 227) throw new FtpException(result.Substring(4));

            int index1 = result.IndexOf('(');
            int index2 = result.IndexOf(')');

            string ipData = result.Substring(index1 + 1, index2 - index1 - 1);

            int[] parts = new int[6];

            int len = ipData.Length;
            int partCount = 0;
            string buf = "";

            for (int i = 0; i < len && partCount <= 6; i++)
            {
                char ch = char.Parse(ipData.Substring(i, 1));

                if (char.IsDigit(ch))
                    buf += ch;

                else if (ch != ',')
                    throw new FtpException("Malformed PASV result: " + result);

                if (ch == ',' || i + 1 == len)
                {
                    try
                    {
                        parts[partCount++] = int.Parse(buf);
                        buf = "";
                    }
                    catch (Exception ex)
                    {
                        throw new FtpException("Malformed PASV result (not supported?): " + result, ex);
                    }
                }
            }

            string ipAddress = parts[0] + "." + parts[1] + "." + parts[2] + "." + parts[3];

            int myPort = (parts[4] << 8) + parts[5];

            Socket socket = null;

            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint ep = new IPEndPoint(Dns.GetHostEntry(ipAddress).AddressList[0], myPort);
                socket.Connect(ep);
            }
            catch (Exception ex)
            {
                // doubtfull....
                if (socket != null && socket.Connected) socket.Close();

                throw new FtpException("Can't connect to remote server", ex);
            }

            return socket;
        }

        /// <summary>
        /// Always release those sockets.
        /// </summary>
        private void cleanup()
        {
            if (clientSocket != null && clientSocket.Connected)
            {
                clientSocket.Close();
                clientSocket = null;
            }
            loggedin = false;
        }

        /// <summary>
        /// Destuctor
        /// </summary>
        ~FtpClient()
        {
            cleanup();
        }


        /**************************************************************************************************************/
        #region Async methods (auto generated)

        /*
				WinInetApi.FtpClient ftp = new WinInetApi.FtpClient();

				MethodInfo[] methods = ftp.GetType().GetMethods(BindingFlags.DeclaredOnly|BindingFlags.Instance|BindingFlags.Public);

				foreach ( MethodInfo method in methods )
				{
					string param = "";
					string values = "";
					foreach ( ParameterInfo i in  method.GetParameters() )
					{
						param += i.ParameterType.Name + " " + i.Name + ",";
						values += i.Name + ",";
					}
					

					Debug.WriteLine("private delegate " + method.ReturnType.Name + " " + method.Name + "Callback(" + param.TrimEnd(',') + ");");

					Debug.WriteLine("public System.IAsyncResult Begin" + method.Name + "( " + param + " System.AsyncCallback callback )");
					Debug.WriteLine("{");
					Debug.WriteLine("" + method.Name + "Callback ftpCallback = new " + method.Name + "Callback(" + values + " " + method.Name + ");");
					Debug.WriteLine("return ftpCallback.BeginInvoke(callback, null);");
					Debug.WriteLine("}");
					Debug.WriteLine("public void End" + method.Name + "(System.IAsyncResult asyncResult)");
					Debug.WriteLine("{");
					Debug.WriteLine(method.Name + "Callback fc = (" + method.Name + "Callback) ((AsyncResult)asyncResult).AsyncDelegate;");
					Debug.WriteLine("fc.EndInvoke(asyncResult);");
					Debug.WriteLine("}");
					//Debug.WriteLine(method);
				}
*/


        private delegate void LoginCallback();
        public IAsyncResult BeginLogin(AsyncCallback callback)
        {
            LoginCallback ftpCallback = Login;
            return ftpCallback.BeginInvoke(callback, null);
        }
        private delegate void CloseCallback();
        public IAsyncResult BeginClose(AsyncCallback callback)
        {
            CloseCallback ftpCallback = Close;
            return ftpCallback.BeginInvoke(callback, null);
        }
        private delegate String[] GetFileListCallback();
        public IAsyncResult BeginGetFileList(AsyncCallback callback)
        {
            GetFileListCallback ftpCallback = GetFileList;
            return ftpCallback.BeginInvoke(callback, null);
        }
        private delegate String[] GetFileListMaskCallback(String mask);
        public IAsyncResult BeginGetFileList(String mask, AsyncCallback callback)
        {
            GetFileListMaskCallback ftpCallback = GetFileList;
            return ftpCallback.BeginInvoke(mask, callback, null);
        }
        private delegate Int64 GetFileSizeCallback(String fileName);
        public IAsyncResult BeginGetFileSize(String fileName, AsyncCallback callback)
        {
            GetFileSizeCallback ftpCallback = GetFileSize;
            return ftpCallback.BeginInvoke(fileName, callback, null);
        }
        private delegate void DownloadCallback(String remFileName);
        public IAsyncResult BeginDownload(String remFileName, AsyncCallback callback)
        {
            DownloadCallback ftpCallback = Download;
            return ftpCallback.BeginInvoke(remFileName, callback, null);
        }
        private delegate void DownloadFileNameResumeCallback(String remFileName, Boolean resume);
        public IAsyncResult BeginDownload(String remFileName, Boolean resume, AsyncCallback callback)
        {
            DownloadFileNameResumeCallback ftpCallback = Download;
            return ftpCallback.BeginInvoke(remFileName, resume, callback, null);
        }
        private delegate void DownloadFileNameFileNameCallback(String remFileName, String locFileName);
        public IAsyncResult BeginDownload(String remFileName, String locFileName, AsyncCallback callback)
        {
            DownloadFileNameFileNameCallback ftpCallback = Download;
            return ftpCallback.BeginInvoke(remFileName, locFileName, callback, null);
        }
        private delegate void DownloadFileNameFileNameResumeCallback(String remFileName, String locFileName, Boolean resume);
        public IAsyncResult BeginDownload(String remFileName, String locFileName, Boolean resume, AsyncCallback callback)
        {
            DownloadFileNameFileNameResumeCallback ftpCallback = Download;
            return ftpCallback.BeginInvoke(remFileName, locFileName, resume, callback, null);
        }
        private delegate void UploadCallback(String fileName);
        public IAsyncResult BeginUpload(String fileName, AsyncCallback callback)
        {
            UploadCallback ftpCallback = Upload;
            return ftpCallback.BeginInvoke(fileName, callback, null);
        }
        private delegate void UploadFileNameResumeCallback(String fileName, Boolean resume);
        public IAsyncResult BeginUpload(String fileName, Boolean resume, AsyncCallback callback)
        {
            UploadFileNameResumeCallback ftpCallback = Upload;
            return ftpCallback.BeginInvoke(fileName, resume, callback, null);
        }
        private delegate void UploadDirectoryCallback(String path, Boolean recurse);
        public IAsyncResult BeginUploadDirectory(String path, Boolean recurse, AsyncCallback callback)
        {
            UploadDirectoryCallback ftpCallback = UploadDirectory;
            return ftpCallback.BeginInvoke(path, recurse, callback, null);
        }
        private delegate void UploadDirectoryPathRecurseMaskCallback(String path, Boolean recurse, String mask);
        public IAsyncResult BeginUploadDirectory(String path, Boolean recurse, String mask, AsyncCallback callback)
        {
            UploadDirectoryPathRecurseMaskCallback ftpCallback = UploadDirectory;
            return ftpCallback.BeginInvoke(path, recurse, mask, callback, null);
        }
        private delegate void DeleteFileCallback(String fileName);
        public IAsyncResult BeginDeleteFile(String fileName, AsyncCallback callback)
        {
            DeleteFileCallback ftpCallback = DeleteFile;
            return ftpCallback.BeginInvoke(fileName, callback, null);
        }
        private delegate void RenameFileCallback(String oldFileName, String newFileName, Boolean overwrite);
        public IAsyncResult BeginRenameFile(String oldFileName, String newFileName, Boolean overwrite, AsyncCallback callback)
        {
            RenameFileCallback ftpCallback = RenameFile;
            return ftpCallback.BeginInvoke(oldFileName, newFileName, overwrite, callback, null);
        }
        private delegate void MakeDirCallback(String dirName);
        public IAsyncResult BeginMakeDir(String dirName, AsyncCallback callback)
        {
            MakeDirCallback ftpCallback = MakeDir;
            return ftpCallback.BeginInvoke(dirName, callback, null);
        }
        private delegate void RemoveDirCallback(String dirName);
        public IAsyncResult BeginRemoveDir(String dirName, AsyncCallback callback)
        {
            RemoveDirCallback ftpCallback = RemoveDir;
            return ftpCallback.BeginInvoke(dirName, callback, null);
        }
        private delegate void ChangeDirCallback(String dirName);
        public IAsyncResult BeginChangeDir(String dirName, AsyncCallback callback)
        {
            ChangeDirCallback ftpCallback = ChangeDir;
            return ftpCallback.BeginInvoke(dirName, callback, null);
        }

        #endregion
    }
}
