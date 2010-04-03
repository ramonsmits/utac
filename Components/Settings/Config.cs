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
 * FileName: 	Config.cs
 * Namespace: 	utac.Components.Settings
 * Author: 		bof (bjoern@n4rf.de)
 * Created: 	2008-02-06
 * -----------------------------------------------------------------------
 * -------------------------------------------------------- Description *-
 * -----------------------------------------------------------------------
 * This Class Load and Save the Configuration of utac
 * The Values are Load to the config_* Variables of GlobalVars
 * Class.
 */

using System.Windows.Forms;

namespace utac.Components.Settings
{
    public class Config
    {
        //  Had to add path to settings to get the settings file to load properly when
        //  program is autoloaded on reboot.
        readonly string defaultconfigFilename = Application.StartupPath + "\\utacsettings.xml";

        /// <summary>
        /// Add/Remove registry entries for windows startup.
        /// </summary>
        /// <param name="enable">if set to <c>true</c> [enable].</param>
        private static void SetStartup(bool enable)
        {
            string runKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";

            Microsoft.Win32.RegistryKey startupKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(runKey);

            if (enable)
            {
                if (startupKey.GetValue("UTAC") == null)
                {
                    startupKey.Close();
                    startupKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(runKey, true);
                    // Add startup reg key
                    startupKey.SetValue("UTAC", Application.ExecutablePath);
                    startupKey.Close();
                }
            }
            else
            {
                // remove startup
                startupKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(runKey, true);
                startupKey.DeleteValue("UTAC", false);
                startupKey.Close();
            }
        }

        public void SaveConfig()
        {
            Settings mysettings = new Settings(defaultconfigFilename, "utacsettings");

            //Output and Timer
            mysettings.WriteBool("main", "celsius", GlobalVars.config_celsius);
            mysettings.WriteBool("main", "fahrenheit", GlobalVars.config_fahrenheit);
            mysettings.WriteBool("main", "timer", GlobalVars.config_timer);
            mysettings.WriteInt("main", "timercount", GlobalVars.config_timercount);
            mysettings.WriteBool("main", "list", GlobalVars.config_list);
            mysettings.WriteInt("main", "listitems", GlobalVars.config_listitems);

            //Graph
            mysettings.WriteBool("main", "graph", GlobalVars.config_graph);
            mysettings.WriteBool("main", "graph_auto", GlobalVars.config_graph_auto);
            mysettings.WriteDouble("main", "graph_max", GlobalVars.config_graph_max);
            mysettings.WriteDouble("main", "graph_min", GlobalVars.config_graph_min);

            mysettings.WriteString("main", "devicename1", GlobalVars.config_devicename1);
            mysettings.WriteString("main", "devicename2", GlobalVars.config_devicename2);
            mysettings.WriteString("main", "devicename3", GlobalVars.config_devicename3);
            mysettings.WriteString("main", "devicename4", GlobalVars.config_devicename4);


            //File Recording
            mysettings.WriteBool("main", "recordtofile", GlobalVars.config_recordtofile);
            mysettings.WriteBool("main", "dailyfiles", GlobalVars.config_dailyfiles);
            mysettings.WriteBool("main", "csv", GlobalVars.config_csv);
            mysettings.WriteBool("main", "txt", GlobalVars.config_txt);

            //FTP UPLOAD
            mysettings.WriteString("main", "filepath", GlobalVars.config_filepath);
            mysettings.WriteString("main", "ftpserver", GlobalVars.config_ftpserver);
            mysettings.WriteString("main", "ftpport", GlobalVars.config_ftpport);
            mysettings.WriteString("main", "ftpuser", GlobalVars.config_ftpuser);
            mysettings.WriteString("main", "ftppass", GlobalVars.config_ftppass);
            mysettings.WriteString("main", "ftpuploaddir", GlobalVars.config_ftpuploaddir);
            mysettings.WriteBool("main", "ftpactive", GlobalVars.config_ftpactive);
            mysettings.WriteBool("main", "ftpuploadgraph", GlobalVars.config_ftpuploadgraph);

            //WEB URL Grabber
            mysettings.WriteString("main", "url", GlobalVars.config_url);
            mysettings.WriteString("main", "wugid", GlobalVars.wugid);
            mysettings.WriteString("main", "wugpw", GlobalVars.wugpw);
            mysettings.WriteBool("main", "urlactive", GlobalVars.config_urlactive);
            mysettings.WriteBool("main", "wugactive", GlobalVars.wugactive);


            //Temper Device Comport and Version
            mysettings.WriteString("main", "comport", GlobalVars.config_comport);
            mysettings.WriteInt("main", "temperversion", GlobalVars.config_temperversion);
            mysettings.WriteBool("main", "temperautodetect", GlobalVars.config_temperautodetect);

            mysettings.WriteDouble("main", "calibrationtemp", GlobalVars.config_calibration_temp);
            mysettings.WriteDouble("main", "calibrationhum", GlobalVars.config_calibration_humidity);

            mysettings.WriteDouble("main", "tempcalo1", GlobalVars.config_tempcalo1);
            mysettings.WriteDouble("main", "tempcalo2", GlobalVars.config_tempcalo2);
            mysettings.WriteDouble("main", "tempcalo3", GlobalVars.config_tempcalo3);
            mysettings.WriteDouble("main", "tempcalo4", GlobalVars.config_tempcalo4);


            mysettings.WriteDouble("main", "tempcals1", GlobalVars.config_tempcals1);
            mysettings.WriteDouble("main", "tempcals2", GlobalVars.config_tempcals2);
            mysettings.WriteDouble("main", "tempcals3", GlobalVars.config_tempcals3);
            mysettings.WriteDouble("main", "tempcals4", GlobalVars.config_tempcals4);

            mysettings.WriteDouble("main", "humcalo1", GlobalVars.config_humcalo1);
            mysettings.WriteDouble("main", "humcalo2", GlobalVars.config_humcalo2);
            mysettings.WriteDouble("main", "humcalo3", GlobalVars.config_humcalo3);
            mysettings.WriteDouble("main", "humcalo4", GlobalVars.config_humcalo4);

            mysettings.WriteDouble("main", "humcals1", GlobalVars.config_humcals1);
            mysettings.WriteDouble("main", "humcals2", GlobalVars.config_humcals2);
            mysettings.WriteDouble("main", "humcals3", GlobalVars.config_humcals3);
            mysettings.WriteDouble("main", "humcals4", GlobalVars.config_humcals4);

            //E-MAIL
            mysettings.WriteString("main", "mail_server", GlobalVars.config_mail_server);
            mysettings.WriteString("main", "mail_server_port", GlobalVars.config_mail_server_port);
            mysettings.WriteString("main", "mail_user", GlobalVars.config_mail_user);
            mysettings.WriteString("main", "mail_to", GlobalVars.config_mail_to);
            mysettings.WriteString("main", "mail_user", GlobalVars.config_mail_user);
            mysettings.WriteString("main", "mail_password", GlobalVars.config_mail_password);
            mysettings.WriteString("main", "mail_from", GlobalVars.config_mail_from);

            //Built in Webserver
            mysettings.WriteBool("main", "BIWActivated", GlobalVars.config_BIWActivated);
            mysettings.WriteInt("main", "BIWPort", GlobalVars.config_BIWPort);
            mysettings.WriteBool("main", "BIWRefresh", GlobalVars.config_BIWRefresh);
            mysettings.WriteString("main", "BIWTitle", GlobalVars.config_BIWTitle);

            //Built in XML Webserver
            mysettings.WriteBool("main", "BIWXMLActivated", GlobalVars.config_BIWXMLActivated);
            mysettings.WriteInt("main", "BIWXMLPort", GlobalVars.config_BIWXMLPort);
            mysettings.WriteBool("main", "BIWXMLRefreshOnAccess", GlobalVars.config_BIWXMLRefreshOnAccess);

            //DEBUG
            mysettings.WriteBool("main", "faketemper", GlobalVars.config_faketemper);
            mysettings.WriteBool("main", "debug", GlobalVars.config_debug);
            mysettings.WriteBool("main", "log", GlobalVars.config_log);
            mysettings.WriteBool("main", "rebootonerror", GlobalVars.config_rebootonerror);


            //Proxy
            mysettings.WriteBool("main", "proxyactivated", GlobalVars.config_proxyactivated);
            mysettings.WriteBool("main", "proxyuseauthetification", GlobalVars.config_proxyuseauthetification);
            mysettings.WriteString("main", "proxyhost", GlobalVars.config_proxyhost);
            mysettings.WriteString("main", "proxyport", GlobalVars.config_proxyport);
            mysettings.WriteString("main", "proxyuser", GlobalVars.config_proxyuser);
            mysettings.WriteString("main", "proxypass", GlobalVars.config_proxypass);

            //Language File
            mysettings.WriteString("main", "langfile", GlobalVars.config_langfile);



            //General
            mysettings.WriteBool("main", "autostart", GlobalVars.config_autostart);
            mysettings.WriteBool("main", "startminimized", GlobalVars.config_startminimized);

            //Alert System
            mysettings.WriteDouble("main", "alert_tempmax1", GlobalVars.config_alert_tempmax1);
            mysettings.WriteDouble("main", "alert_tempmin1", GlobalVars.config_alert_tempmin1);
            mysettings.WriteDouble("main", "alert_hummax1", GlobalVars.config_alert_hummax1);
            mysettings.WriteDouble("main", "alert_hummin1", GlobalVars.config_alert_hummin1);
            mysettings.WriteBool("main", "alert_humemail1", GlobalVars.config_alert_humemail1);
            mysettings.WriteBool("main", "alert_humonscreen1", GlobalVars.config_alert_humonscreen1);
            mysettings.WriteBool("main", "alert_tempemail1", GlobalVars.config_alert_tempemail1);
            mysettings.WriteBool("main", "alert_temponscreen1", GlobalVars.config_alert_temponscreen1);

            mysettings.WriteDouble("main", "alert_tempmax2", GlobalVars.config_alert_tempmax2);
            mysettings.WriteDouble("main", "alert_tempmin2", GlobalVars.config_alert_tempmin2);
            mysettings.WriteDouble("main", "alert_hummax2", GlobalVars.config_alert_hummax2);
            mysettings.WriteDouble("main", "alert_hummin2", GlobalVars.config_alert_hummin2);
            mysettings.WriteBool("main", "alert_humemail2", GlobalVars.config_alert_humemail2);
            mysettings.WriteBool("main", "alert_humonscreen2", GlobalVars.config_alert_humonscreen2);
            mysettings.WriteBool("main", "alert_tempemail2", GlobalVars.config_alert_tempemail2);
            mysettings.WriteBool("main", "alert_temponscreen2", GlobalVars.config_alert_temponscreen2);

            mysettings.WriteDouble("main", "alert_tempmax3", GlobalVars.config_alert_tempmax3);
            mysettings.WriteDouble("main", "alert_tempmin3", GlobalVars.config_alert_tempmin3);
            mysettings.WriteDouble("main", "alert_hummax3", GlobalVars.config_alert_hummax3);
            mysettings.WriteDouble("main", "alert_hummin3", GlobalVars.config_alert_hummin3);
            mysettings.WriteBool("main", "alert_humemail3", GlobalVars.config_alert_humemail3);
            mysettings.WriteBool("main", "alert_humonscreen3", GlobalVars.config_alert_humonscreen3);
            mysettings.WriteBool("main", "alert_tempemail3", GlobalVars.config_alert_tempemail3);
            mysettings.WriteBool("main", "alert_temponscreen3", GlobalVars.config_alert_temponscreen3);

            mysettings.WriteDouble("main", "alert_tempmax4", GlobalVars.config_alert_tempmax4);
            mysettings.WriteDouble("main", "alert_tempmin4", GlobalVars.config_alert_tempmin4);
            mysettings.WriteDouble("main", "alert_hummax4", GlobalVars.config_alert_hummax4);
            mysettings.WriteDouble("main", "alert_hummin4", GlobalVars.config_alert_hummin4);
            mysettings.WriteBool("main", "alert_humemail4", GlobalVars.config_alert_humemail4);
            mysettings.WriteBool("main", "alert_humonscreen4", GlobalVars.config_alert_humonscreen4);
            mysettings.WriteBool("main", "alert_tempemail4", GlobalVars.config_alert_tempemail4);
            mysettings.WriteBool("main", "alert_temponscreen4", GlobalVars.config_alert_temponscreen4);


            SetStartup(GlobalVars.config_autostart);

            mysettings.Save();

        }

        public void LoadConfig()
        {
            Settings mysettings = new Settings(defaultconfigFilename, "utacsettings");

            //Output and Timer
            GlobalVars.config_celsius = mysettings.ReadBool("main", "celsius", true);
            GlobalVars.config_fahrenheit = mysettings.ReadBool("main", "fahrenheit", false);
            GlobalVars.config_timer = mysettings.ReadBool("main", "timer", false);
            GlobalVars.config_timercount = mysettings.ReadInt("main", "timercount", 60);
            GlobalVars.config_list = mysettings.ReadBool("main", "list", false);
            GlobalVars.config_listitems = mysettings.ReadInt("main", "listitems", 100);

            //Graph
            GlobalVars.config_graph = mysettings.ReadBool("main", "graph", false);
            GlobalVars.config_graph_auto = mysettings.ReadBool("main", "graph_auto", true);
            GlobalVars.config_graph_max = mysettings.ReadDouble("main", "graph_max", 0);
            GlobalVars.config_graph_min = mysettings.ReadDouble("main", "graph_min", 0);

            GlobalVars.config_devicename1 = mysettings.ReadString("main", "devicename1", "");
            GlobalVars.config_devicename2 = mysettings.ReadString("main", "devicename2", "");
            GlobalVars.config_devicename3 = mysettings.ReadString("main", "devicename3", "");
            GlobalVars.config_devicename4 = mysettings.ReadString("main", "devicename4", "");


            //File Recording
            GlobalVars.config_recordtofile = mysettings.ReadBool("main", "recordtofile", false);
            GlobalVars.config_dailyfiles = mysettings.ReadBool("main", "dailyfiles", false);
            GlobalVars.config_csv = mysettings.ReadBool("main", "csv", true);
            GlobalVars.config_txt = mysettings.ReadBool("main", "txt", false);

            //FTP UPLOAD
            GlobalVars.config_filepath = mysettings.ReadString("main", "filepath", "");
            GlobalVars.config_ftpserver = mysettings.ReadString("main", "ftpserver", "");
            GlobalVars.config_ftpport = mysettings.ReadString("main", "ftpport", "21");
            GlobalVars.config_ftpuser = mysettings.ReadString("main", "ftpuser", "");
            GlobalVars.config_ftppass = mysettings.ReadString("main", "ftppass", "");
            GlobalVars.config_ftpuploaddir = mysettings.ReadString("main", "ftpuploaddir", "");
            GlobalVars.config_ftpactive = mysettings.ReadBool("main", "ftpactive", false);
            GlobalVars.config_ftpuploadgraph = mysettings.ReadBool("main", "ftpuploadgraph", false);

            //E-MAIL
            GlobalVars.config_mail_server = mysettings.ReadString("main", "mail_server", "");
            GlobalVars.config_mail_server_port = mysettings.ReadString("main", "mail_server_port", "25");
            GlobalVars.config_mail_user = mysettings.ReadString("main", "mail_user", "");
            GlobalVars.config_mail_to = mysettings.ReadString("main", "mail_to", "");
            GlobalVars.config_mail_user = mysettings.ReadString("main", "mail_user", "");
            GlobalVars.config_mail_password = mysettings.ReadString("main", "mail_password", "");
            GlobalVars.config_mail_from = mysettings.ReadString("main", "mail_from", "");


            //WEB URL Grabber
            GlobalVars.config_url = mysettings.ReadString("main", "url", "");
            GlobalVars.wugid = mysettings.ReadString("main", "wugid", "");
            GlobalVars.wugpw = mysettings.ReadString("main", "wugpw", "");
            GlobalVars.config_urlactive = mysettings.ReadBool("main", "urlactive", false);
            GlobalVars.wugactive = mysettings.ReadBool("main", "wugactive", false);


            //Temper Device Comport and Version
            GlobalVars.config_comport = mysettings.ReadString("main", "comport", "COM1");
            GlobalVars.config_temperversion = mysettings.ReadInt("main", "temperversion", 1);
            GlobalVars.config_temperautodetect = mysettings.ReadBool("main", "temperautodetect", true);

            GlobalVars.config_calibration_temp = mysettings.ReadDouble("main", "calibrationtemp", 0);
            GlobalVars.config_calibration_humidity = mysettings.ReadDouble("main", "calibrationhum", 0);

            GlobalVars.config_tempcalo1 = mysettings.ReadDouble("main", "tempcalo1", 0);
            GlobalVars.config_tempcalo2 = mysettings.ReadDouble("main", "tempcalo2", 0);
            GlobalVars.config_tempcalo3 = mysettings.ReadDouble("main", "tempcalo3", 0);
            GlobalVars.config_tempcalo4 = mysettings.ReadDouble("main", "tempcalo4", 0);

            GlobalVars.config_tempcals1 = mysettings.ReadDouble("main", "tempcals1", 0);
            GlobalVars.config_tempcals2 = mysettings.ReadDouble("main", "tempcals2", 0);
            GlobalVars.config_tempcals3 = mysettings.ReadDouble("main", "tempcals3", 0);
            GlobalVars.config_tempcals4 = mysettings.ReadDouble("main", "tempcals4", 0);


            GlobalVars.config_humcalo1 = mysettings.ReadDouble("main", "humcalo1", 0);
            GlobalVars.config_humcalo2 = mysettings.ReadDouble("main", "humcalo2", 0);
            GlobalVars.config_humcalo3 = mysettings.ReadDouble("main", "humcalo3", 0);
            GlobalVars.config_humcalo4 = mysettings.ReadDouble("main", "humcalo4", 0);

            GlobalVars.config_humcals1 = mysettings.ReadDouble("main", "humcals1", 0);
            GlobalVars.config_humcals2 = mysettings.ReadDouble("main", "humcals2", 0);
            GlobalVars.config_humcals3 = mysettings.ReadDouble("main", "humcals3", 0);
            GlobalVars.config_humcals4 = mysettings.ReadDouble("main", "humcals4", 0);

            //Built in Webserver
            GlobalVars.config_BIWActivated = mysettings.ReadBool("main", "BIWActivated", false);
            GlobalVars.config_BIWPort = mysettings.ReadInt("main", "BIWPort", 5050);
            GlobalVars.config_BIWRefresh = mysettings.ReadBool("main", "BIWRefresh", false);
            GlobalVars.config_BIWTitle = mysettings.ReadString("main", "BIWTitle", "USB TEMPer Advanced Control Web Server");

            //Built in XML Webserver
            GlobalVars.config_BIWXMLActivated = mysettings.ReadBool("main", "BIWXMLActivated", false);
            GlobalVars.config_BIWXMLPort = mysettings.ReadInt("main", "BIWXMLPort", 5051);
            GlobalVars.config_BIWXMLRefreshOnAccess = mysettings.ReadBool("main", "BIWXMLRefreshOnAccess", false);

            //DEBUG
            GlobalVars.config_faketemper = mysettings.ReadBool("main", "faketemper", false);
            GlobalVars.config_debug = mysettings.ReadBool("main", "debug", false);
            GlobalVars.config_log = mysettings.ReadBool("main", "log", false);
            GlobalVars.config_rebootonerror = mysettings.ReadBool("main", "rebootonerror", false);


            //Proxy
            GlobalVars.config_proxyactivated = mysettings.ReadBool("main", "proxyactivated", false);
            GlobalVars.config_proxyuseauthetification = mysettings.ReadBool("main", "proxyuseauthetification", false);
            GlobalVars.config_proxyhost = mysettings.ReadString("main", "proxyhost", "");
            GlobalVars.config_proxyport = mysettings.ReadString("main", "proxyport", "");
            GlobalVars.config_proxyuser = mysettings.ReadString("main", "proxyuser", "");
            GlobalVars.config_proxypass = mysettings.ReadString("main", "proxypass", "");

            //Language File
            GlobalVars.config_langfile = mysettings.ReadString("main", "langfile", "en.xml");

            //General
            GlobalVars.config_autostart = mysettings.ReadBool("main", "autostart", false);
            GlobalVars.config_startminimized = mysettings.ReadBool("main", "startminimized", false);

            //Alert System
            GlobalVars.config_alert_tempmax1 = mysettings.ReadDouble("main", "alert_tempmax1", 0);
            GlobalVars.config_alert_tempmin1 = mysettings.ReadDouble("main", "alert_tempmin1", 0);
            GlobalVars.config_alert_hummax1 = mysettings.ReadDouble("main", "alert_hummax1", 0);
            GlobalVars.config_alert_hummin1 = mysettings.ReadDouble("main", "alert_hummin1", 0);
            GlobalVars.config_alert_humemail1 = mysettings.ReadBool("main", "alert_humemail1", false);
            GlobalVars.config_alert_humonscreen1 = mysettings.ReadBool("main", "alert_humonscreen1", false);
            GlobalVars.config_alert_tempemail1 = mysettings.ReadBool("main", "alert_tempemail1", false);
            GlobalVars.config_alert_temponscreen1 = mysettings.ReadBool("main", "alert_temponscreen1", false);

            GlobalVars.config_alert_tempmax2 = mysettings.ReadDouble("main", "alert_tempmax2", 0);
            GlobalVars.config_alert_tempmin2 = mysettings.ReadDouble("main", "alert_tempmin2", 0);
            GlobalVars.config_alert_hummax2 = mysettings.ReadDouble("main", "alert_hummax2", 0);
            GlobalVars.config_alert_hummin2 = mysettings.ReadDouble("main", "alert_hummin2", 0);
            GlobalVars.config_alert_humemail2 = mysettings.ReadBool("main", "alert_humemail2", false);
            GlobalVars.config_alert_humonscreen2 = mysettings.ReadBool("main", "alert_humonscreen2", false);
            GlobalVars.config_alert_tempemail2 = mysettings.ReadBool("main", "alert_tempemail2", false);
            GlobalVars.config_alert_temponscreen2 = mysettings.ReadBool("main", "alert_temponscreen2", false);


            GlobalVars.config_alert_tempmax3 = mysettings.ReadDouble("main", "alert_tempmax3", 0);
            GlobalVars.config_alert_tempmin3 = mysettings.ReadDouble("main", "alert_tempmin3", 0);
            GlobalVars.config_alert_hummax3 = mysettings.ReadDouble("main", "alert_hummax3", 0);
            GlobalVars.config_alert_hummin3 = mysettings.ReadDouble("main", "alert_hummin3", 0);
            GlobalVars.config_alert_humemail3 = mysettings.ReadBool("main", "alert_humemail3", false);
            GlobalVars.config_alert_humonscreen3 = mysettings.ReadBool("main", "alert_humonscreen3", false);
            GlobalVars.config_alert_tempemail3 = mysettings.ReadBool("main", "alert_tempemail3", false);
            GlobalVars.config_alert_temponscreen3 = mysettings.ReadBool("main", "alert_temponscreen3", false);


            GlobalVars.config_alert_tempmax4 = mysettings.ReadDouble("main", "alert_tempmax4", 0);
            GlobalVars.config_alert_tempmin4 = mysettings.ReadDouble("main", "alert_tempmin4", 0);
            GlobalVars.config_alert_hummax4 = mysettings.ReadDouble("main", "alert_hummax4", 0);
            GlobalVars.config_alert_hummin4 = mysettings.ReadDouble("main", "alert_hummin4", 0);
            GlobalVars.config_alert_humemail4 = mysettings.ReadBool("main", "alert_humemail4", false);
            GlobalVars.config_alert_humonscreen4 = mysettings.ReadBool("main", "alert_humonscreen4", false);
            GlobalVars.config_alert_tempemail4 = mysettings.ReadBool("main", "alert_tempemail4", false);
            GlobalVars.config_alert_temponscreen4 = mysettings.ReadBool("main", "alert_temponscreen4", false);
        }
    }
}

