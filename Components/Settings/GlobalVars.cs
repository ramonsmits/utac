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
 * FileName: 	GlobalVars.cs
 * Namespace: 	utac.Components.Settings
 * Author: 		bof (bjoern@n4rf.de)
 * Created: 	2008-02-01
 * -----------------------------------------------------------------------
 * -------------------------------------------------------- Description *-
 * -----------------------------------------------------------------------
 * This class maintains all Global Variables and Config Values
 * 
 */

using System.Collections;
using System.Drawing;
using System.Threading;

namespace utac.Components.Settings
{
	public class GlobalVars
	{
		//#########################VERSION INFO
		//---------------------------------------------------------
		public static string _UTACVERSION = "0.1.2o";
		public static string _UTACDATE = "2010-MAR-24";
		
		
		//#########################CONFIG VALUES
		//---------------------------------------------------------
		
		//Output and Timer
		public static bool 		config_celsius = true;
		public static bool 		config_fahrenheit = false;
		public static bool 		config_timer = false;
		public static int 		config_timercount = 5;
		public static bool 		config_list = false;
		public static int		config_listitems = 100;
		
		//Graph
		public static bool 		config_graph = false;
		public static bool 		config_graph_auto = true;
		public static double	config_graph_min = 0;
		public static double	config_graph_max = 0;

        public static string    config_devicename1 = "";
        public static string    config_devicename2 = "";
        public static string    config_devicename3 = "";
        public static string    config_devicename4 = "";

		
		//File Recording
		public static bool 		config_recordtofile = false;
		public static bool 		config_dailyfiles = false;
		public static bool 		config_csv = true;
		public static bool 		config_txt = false;
		
		//FTP UPLOAD
		public static bool 		config_ftpactive = false;
		public static string 	config_filepath = "";
		public static string 	config_ftpserver = "";
		public static string 	config_ftpport = "";
		public static string 	config_ftpuser = "";
		public static string 	config_ftppass = "";
		public static string 	config_ftpuploaddir = "";
		public static bool 		config_ftpuploadgraph = false; //NEW VERSION 0.1.2
		
		//WEB URL Grabber
		public static string	config_url = "";
        public static string    wugid = "";
        public static string    wugpw = "";
		public static bool		config_urlactive = false;
        public static bool      wugactive = false;

		
		//Temper Device Comport and Version
		public static string	config_comport = "COM1";
		public static int		config_temperversion = 2;
		public static bool		config_temperautodetect = true;
		public static double 	config_calibration_temp = 0; //NEW VERSION 0.1.2
		public static double 	config_calibration_humidity = 0; //NEW VERSION 0.1.2


        public static double    config_tempcalo1 = 0;
        public static double    config_tempcalo2 = 0;
        public static double    config_tempcalo3 = 0;
        public static double    config_tempcalo4 = 0;


        public static double    config_tempcals1 = 0;
        public static double    config_tempcals2 = 0;
        public static double    config_tempcals3 = 0;
        public static double    config_tempcals4 = 0;


        public static double    config_humcalo1 = 0;
        public static double    config_humcalo2 = 0;
        public static double    config_humcalo3 = 0;
        public static double    config_humcalo4 = 0; 

        public static double    config_humcals1 = 0;
        public static double    config_humcals2 = 0;
        public static double    config_humcals3 = 0;
        public static double    config_humcals4 = 0;

        //NTC Temperature Compensation

        public static bool      config_hasntcdata = false;
        public static double[]  ntc_factors = new double[500];
        public static double[]  ntc_temps = new double[500];
        public static int       ntc_count = 0;

        public static bool config_hasntcbdata = false;
        public static double[] ntcb_factors = new double[500];
        public static double[] ntcb_temps = new double[500];
        public static int ntcb_count = 0;

		//Built in Webserver
		public static bool config_BIWActivated = false;
		public static int config_BIWPort = 5050;
		public static bool config_BIWRefresh = false;
		public static string config_BIWTitle = "USB Advanced Control Webserver";

		//Built in XML Webserver
		public static bool config_BIWXMLActivated = false;
		public static int config_BIWXMLPort = 5051;
		public static bool config_BIWXMLRefreshOnAccess = false;
		
		
		//DEBUG 
		public static bool config_faketemper = false;
		public static bool config_debug = false;
		public static bool config_log = false;
        public static bool config_rebootonerror = false;        
			
		
		//Proxy 
		public static bool config_proxyactivated = false;
		public static bool config_proxyuseauthetification = false;
		public static string config_proxyhost = "";
		public static string config_proxyport = "";
		public static string config_proxyuser = "";
		public static string config_proxypass = "";
		
		public static string config_langfile = "en.xml";
		
		//General
		public static bool config_autostart = false;
		public static bool config_startminimized = false;
		
		//E-Mail Server
		public static string config_mail_server = "";
		public static string config_mail_user = "";
		public static string config_mail_password = "";
		public static string config_mail_from = "";
		public static string config_mail_to = "";
		public static string config_mail_server_port = "";
		
		//Alert System
		public static double config_alert_tempmax1 = 0;
		public static double config_alert_tempmin1 = 0;
		public static double config_alert_hummax1 = 0;
		public static double config_alert_hummin1 = 0;
		public static bool config_alert_tempemail1 = false;
		public static bool config_alert_humemail1 = false;
		public static bool config_alert_temponscreen1 = false;
		public static bool config_alert_humonscreen1 = false;

        public static double config_alert_tempmax2 = 0;
        public static double config_alert_tempmin2 = 0;
        public static double config_alert_hummax2 = 0;
        public static double config_alert_hummin2 = 0;
        public static bool config_alert_tempemail2 = false;
        public static bool config_alert_humemail2 = false;
        public static bool config_alert_temponscreen2 = false;
        public static bool config_alert_humonscreen2 = false;

        public static double config_alert_tempmax3 = 0;
        public static double config_alert_tempmin3 = 0;
        public static double config_alert_hummax3 = 0;
        public static double config_alert_hummin3 = 0;
        public static bool config_alert_tempemail3 = false;
        public static bool config_alert_humemail3 = false;
        public static bool config_alert_temponscreen3 = false;
        public static bool config_alert_humonscreen3 = false;

        public static double config_alert_tempmax4 = 0;
        public static double config_alert_tempmin4 = 0;
        public static double config_alert_hummax4 = 0;
        public static double config_alert_hummin4 = 0;
        public static bool config_alert_tempemail4 = false;
        public static bool config_alert_humemail4 = false;
        public static bool config_alert_temponscreen4 = false;
        public static bool config_alert_humonscreen4 = false;		
				
	
		//#########################IN PROGRAMM VALUES
		//---------------------------------------------------------
		public static bool threadIsActive = false;
        public static bool refreshIsActive = false;
        public static bool uploadIsActive = false;
        public static bool urlthreadIsActive = false;
        public static bool ftpthreadIsActive = false;
        public static Thread theFtpThread;
        public static int ftpthreadCount = 0;
        public static int devicecount = 0;
        public static int displaydevice = 0;

        public static string[] currenttemp = new string[10];
        public static string[] currenthum = new string[10];
        public static string[] currentts = new string[10];
		public static bool errorStatus = false;
		public static Image[] graphPicture = new Image[10];
		public static bool externalRefresh = false;		
		// public static string TEMPerName = "n/a";
		
		//#########################MULTILANG VARS
		//---------------------------------------------------------
		
		//{VERSION 0.1.1}
		public static string lang_actualtemp = "_actualtemp";
		public static string lang_refreshtempmanual = "_refreshtempmanual";
		public static string lang_activatedeactivatetimer = "_activatedeactivatetimer";
		public static string lang_activatedeactivatexmlwebserver = "_activatedeactivatexmlwebserver";
		public static string lang_activatedeactivatewebserver = "_activatedeactivatewebserver";
		public static string lang_settings = "_settings";
		public static string lang_info = "_info";
		public static string lang_exit = "_exit";
		public static string lang_temperature = "_temperature";
		public static string lang_ok = "_ok";
		public static string lang_apply = "_apply";
		public static string lang_cancel = "_cancel";
		public static string lang_outputandtimer = "_outputandtimer";
		public static string lang_filerecording = "_filerecording";
		public static string lang_ftpupload = "_ftpupload";
		public static string lang_weburlgrabber = "_weburlgrabber";
		public static string lang_builtinwebserver = "_builtinwebserver";
		public static string lang_proxyanddebug = "_proxyanddebug";
		public static string lang_language = "_language";
		public static string lang_temper = "_temper";
		public static string lang_output = "_output";
		public static string lang_celsius = "_celsius";
		public static string lang_fahrenheit = "_fahrenheit";
		public static string lang_recordtolist = "_recordtolist";
		public static string lang_activategraph = "_activategraph";
		public static string lang_maxitems = "_maxitems";
		public static string lang_timer = "_timer";
		public static string lang_activated = "_activated";
		public static string lang_interval = "_interval";
		public static string lang_seconds = "_seconds";
		public static string lang_autodetection = "_autodetection";
		public static string lang_choosecomport = "_choosecomport";
		public static string lang_generatedailyfiles = "_generatedailyfiles";
		public static string lang_path = "_path";
		public static string lang_format = "_format";
		public static string lang_server = "_server";
		public static string lang_username = "_username";
		public static string lang_password = "_passwort";
		public static string lang_uploaddir ="_uploaddir";
		public static string lang_test = "_test";
		public static string lang_ftperror = "_ftperror";
		public static string lang_couldnotlogintoserver = "_couldnotlogintoserver";
		public static string lang_couldnotchangedirtouploaddirectory = "_couldnotchangedirtouploaddirectory";
		public static string lang_ftpsettingssuccessfullytested = "_ftpsettingssuccessfullytested";
		public static string lang_url = "_url";
		public static string lang_urltext1 = "_urltext1";
		public static string lang_example = "_example";
		public static string lang_webserver = "_webserver";
		public static string lang_enablemanualrefresh = "_enablemanualrefresh";
		public static string lang_port = "_port";
		public static string lang_title = "_title";
		public static string lang_refreshtemponaccess = "_refreshtemponaccess";
		public static string lang_useauthentification = "_useauthentification";
		public static string lang_faketemper = "_faketemper";
		public static string lang_enablelogfile = "_enablelogfile";
		public static string lang_date = "_date";
		public static string lang_author = "_author";
		public static string lang_version = "_version";
		public static string lang_couldnotuploadfile = "_couldnotuploadfile";
		public static string lang_couldnotfindtemperdevice = "_couldnotfindtemperdevice";
		public static string lang_error = "_error";
		public static string lang_errorrecordtofile = "_errorrecordtofile";
		public static string lang_nooutputpath = "_nooutputpath";
		public static string lang_builtinxmlwebserver = "_builtinxmlwebserver";
		public static string lang_proxysettings = "_proxysettings";
		public static string lang_debug = "_debug";
		public static string lang_urlerror = "_urlerror";
		public static string lang_urlreturn = "_urlreturn";
		public static string lang_manualtempupdate = "_manualtempupdate";
		public static string lang_refreshsite = "_refreshsite";
		public static string lang_about = "_about";
		public static string lang_programinfos = "_programinfos";
		public static string lang_checkforlatestversion = "_checkforlatestversion";
		
	
		//{VERSION 0.1.2}
		public static string lang_actualhumidity = "_actualhumidity";
		public static string lang_minmaxvalues = "_minmaxvalues";
		public static string lang_maxtemp = "_maxtemp";
		public static string lang_mintemp = "_mintemp";
		public static string lang_minhumidity = "_minhumidity";
		public static string lang_maxhumidty = "_maxhumidty";
		public static string lang_proxy = "_proxy";
		public static string lang_more = "_more";
		public static string lang_device = "_device";
		public static string lang_uploadgraph = "_uploadgraph";
		public static string lang_humidity = "_humidity";
		public static string lang_calibration = "_calibration";
		public static string lang_max = "_max";
		public static string lang_min = "_min";
		public static string lang_emailnotify = "_emailnotify";
		public static string lang_tempalert = "_tempalert";
		public static string lang_humalert = "_humalert";
		public static string lang_onscreennotify = "_onscreennotify";	
		public static string lang_email = "_email";
		public static string lang_emailsmtpsettings = "_emailsmtpsettings";
		public static string lang_fromaddress = "_fromaddres";
		public static string lang_receipientaddress = "_receipientaddress";
		public static string lang_autostart = "_autostart";
		public static string lang_startminimized = "_startminimized";
		public static string lang_utacstart = "_utacstart";
		public static string lang_alertsystem = "_alertsystem";
		public static string lang_resetmaxminvalues = "_resetmaxminvalues";
		public static string lang_resetgraphscale = "_resetgraphscale";
		public static string lang_autoscalegraph = "_autoscalegraph";
		public static string lang_graph = "_graph";
		public static string lang_general = "_general";
		public static string lang_ftprequirefilerecording = "_ftprequirefilerecording";
		
		public static string lang_maxtempalarm = "_maxtempalarm";
	    public static string lang_maxhumalarm = "_maxhumalarm";
	    public static string lang_mintempalarm = "_mintempalarm";
	    public static string lang_minhumalarm = "_minhumalarm";
	    public static string lang_close = "_close";
	    public static string lang_mailsuccessfullysent = "_mailsuccessfullysent";
		
	}

		
}
		

