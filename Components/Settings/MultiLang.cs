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
 * FileName: 	MultiLang.cs
 * Namespace: 	utac.Components.Settings
 * Author: 		bof (bjoern@n4rf.de)
 * Created: 	2008-02-06
 * -----------------------------------------------------------------------
 * -------------------------------------------------------- Description *-
 * -----------------------------------------------------------------------
 * Multi Language Class
 */

using System.IO;

namespace utac.Components.Settings
{
	public class MultiLang
	{
		static Settings myLangFile; 

		#region Static Methods
		
		/// <summary>
		/// Get Information about a Language File
		/// </summary>
		/// <param name="myLangFile">Language File Name</param>
		/// <returns>
		/// Language File Information (string[7])
		/// </returns>
		/// <value>
		/// [0]: Language Name<br />
		/// [1]: Language Name in English<br />
		/// [2]: Version<br />
		/// [3]: Date<br />
		/// [4]: Author<br />
		/// [5]: Author E-Mail Adress<br />
		/// [6]: Author WWW Adress<br />
		/// </value>
		public static string[] getLangFileinfo(string myLangFile){
		    string[] langFileinfos = new string[7];

 			Settings myTmpLangs = new Settings(Settings.ApplicationPath+"\\Lang\\"+myLangFile,"utaclangfile");
			langFileinfos[0] = myTmpLangs.ReadString("infos","langname","");
			langFileinfos[1] = myTmpLangs.ReadString("infos","langglobalname","");
			langFileinfos[2] = myTmpLangs.ReadString("infos","version","");
			langFileinfos[3] = myTmpLangs.ReadString("infos","date","");
			langFileinfos[4] = myTmpLangs.ReadString("infos","author","");
			langFileinfos[5] = myTmpLangs.ReadString("infos","authormail","");
			langFileinfos[6] = myTmpLangs.ReadString("infos","authorwww","");
			return langFileinfos;
		}
		
		
		/// <summary>
		/// Get available Language Files
		/// </summary>
		/// <returns>
		/// Available Language Files  (string[])
		/// </returns>
		/// <value>
		/// Filenames (*.xml)<br />
		/// </value>
		public static string[] getLangFiles(){
			DirectoryInfo di = new DirectoryInfo(Settings.ApplicationPath+"\\Lang");
			FileInfo[] rgFiles = di.GetFiles("*.xml");
			string[] rgFileNames = new string[rgFiles.Length];
			int i = 0;
			foreach(FileInfo fi in rgFiles){
				rgFileNames[i] = fi.Name;
				i++;
			}
			return rgFileNames;
		}


	    public static void TransLateAll(){

            if (!Directory.Exists(Settings.ApplicationPath + "\\Lang"))
                Directory.CreateDirectory(Settings.ApplicationPath + "\\Lang");

			myLangFile = new Settings(Settings.ApplicationPath+"\\Lang\\"+GlobalVars.config_langfile,"utaclangfile");
			GlobalVars.lang_actualtemp = Translate("_actualtemp");
			GlobalVars.lang_refreshtempmanual = Translate("_refreshtempmanual");
			GlobalVars.lang_activatedeactivatetimer = Translate("_activatedeactivatetimer");
			GlobalVars.lang_activatedeactivatewebserver = Translate("_activatedeactivatewebserver");
			GlobalVars.lang_activatedeactivatexmlwebserver = Translate("_activatedeactivatexmlwebserver");
			GlobalVars.lang_settings = Translate("_settings");
			GlobalVars.lang_info = Translate("_info");
			GlobalVars.lang_exit = Translate("_exit");
			GlobalVars.lang_temperature = Translate("_temperature");
			GlobalVars.lang_ok = Translate("_ok");
			GlobalVars.lang_apply = Translate("_apply");
			GlobalVars.lang_cancel = Translate("_cancel");
			GlobalVars.lang_outputandtimer = Translate("_outputandtimer");
			GlobalVars.lang_filerecording = Translate("_filerecording");
			GlobalVars.lang_ftpupload = Translate("_ftpupload");
			GlobalVars.lang_weburlgrabber = Translate("_weburlgrabber");
			GlobalVars.lang_builtinwebserver = Translate("_builtinwebserver");
			GlobalVars.lang_proxyanddebug = Translate("_proxyanddebug");
			GlobalVars.lang_language = Translate("_language");
			GlobalVars.lang_temper = Translate("_temper");
			GlobalVars.lang_output = Translate("_output");
			GlobalVars.lang_celsius = Translate("_celsius");
			GlobalVars.lang_fahrenheit = Translate("_fahrenheit");
			GlobalVars.lang_recordtolist = Translate("_recordtolist");
			GlobalVars.lang_activategraph = Translate("_activategraph");
			GlobalVars.lang_maxitems = Translate("_maxitems");
			GlobalVars.lang_timer = Translate("_timer");
			GlobalVars.lang_activated = Translate("_activated");
			GlobalVars.lang_interval = Translate("_interval");
			GlobalVars.lang_seconds = Translate("_seconds");
			GlobalVars.lang_autodetection = Translate("_autodetection");
			GlobalVars.lang_choosecomport = Translate("_choosecomport");
			GlobalVars.lang_generatedailyfiles = Translate("_generatedailyfiles");
			GlobalVars.lang_path = Translate("_path");
			GlobalVars.lang_format = Translate("_format");
			GlobalVars.lang_server = Translate("_server");
			GlobalVars.lang_username = Translate("_username");
			GlobalVars.lang_password = Translate("_password");
			GlobalVars.lang_uploaddir = Translate("_uploaddir");
			GlobalVars.lang_test = Translate("_test");
			GlobalVars.lang_ftperror = Translate("_ftperror");
			GlobalVars.lang_couldnotlogintoserver = Translate("_couldnotlogintoserver");
			GlobalVars.lang_couldnotchangedirtouploaddirectory = Translate("_couldnotchangedirtouploaddirectory");
			GlobalVars.lang_ftpsettingssuccessfullytested = Translate("_ftpsettingssuccessfullytested");
			GlobalVars.lang_url = Translate("_url");
			GlobalVars.lang_urltext1 = Translate("_urltext1");
			GlobalVars.lang_example = Translate("_example");
			GlobalVars.lang_webserver = Translate("_webserver");
			GlobalVars.lang_enablemanualrefresh = Translate("_enablemanualrefresh");
			GlobalVars.lang_port = Translate("_port");
			GlobalVars.lang_title = Translate("_title");
			GlobalVars.lang_refreshtemponaccess = Translate("_refreshtemponaccess");
			GlobalVars.lang_useauthentification = Translate("_useauthentification");
			GlobalVars.lang_faketemper = Translate("_faketemper");
			GlobalVars.lang_enablelogfile = Translate("_enablelogfile");
			GlobalVars.lang_date = Translate("_date");
			GlobalVars.lang_author = Translate("_author");
			GlobalVars.lang_version = Translate("_version");
			GlobalVars.lang_couldnotuploadfile = Translate("_couldnotuploadfile");
			GlobalVars.lang_couldnotfindtemperdevice = Translate("_couldnotfindtemperdevice");
			GlobalVars.lang_error = Translate("_error");
			GlobalVars.lang_errorrecordtofile = Translate("_errorrecordtofile");
			GlobalVars.lang_nooutputpath = Translate("_nooutputpath");
			GlobalVars.lang_builtinxmlwebserver = Translate("_builtinxmlwebserver");
			GlobalVars.lang_proxysettings = Translate("_proxysettings");
			GlobalVars.lang_debug = Translate("_debug");
			GlobalVars.lang_urlerror = Translate("_urlerror");
			GlobalVars.lang_urlreturn = Translate("_urlreturn");
			GlobalVars.lang_refreshsite = Translate("_refreshsite");
			GlobalVars.lang_manualtempupdate = Translate("_manualtempupdate");
			GlobalVars.lang_about = Translate("_about");
			GlobalVars.lang_programinfos = Translate("_programinfos");
			GlobalVars.lang_checkforlatestversion = Translate("_checkforlatestversion");
			
			
			
			//{VERSION 0.1.2}
			GlobalVars.lang_actualhumidity = Translate("_actualhumidity");
			GlobalVars.lang_minmaxvalues = Translate("_minmaxvalues");
			GlobalVars.lang_maxtemp =  Translate("_maxtemp");
			GlobalVars.lang_mintemp =  Translate("_mintemp");
			GlobalVars.lang_minhumidity =  Translate("_minhumidity");
			GlobalVars.lang_maxhumidty =  Translate("_maxhumidty");
			GlobalVars.lang_proxy = Translate("_proxy");
			GlobalVars.lang_more = Translate("_more");
			GlobalVars.lang_device = Translate("_device");
			GlobalVars.lang_uploadgraph = Translate("_uploadgraph");
			GlobalVars.lang_humidity = Translate("_humidity");
			GlobalVars.lang_calibration = Translate("_calibration");
			GlobalVars.lang_max = Translate("_max");
			GlobalVars.lang_min = Translate("_min");
			GlobalVars.lang_emailnotify = Translate("_emailnotify");
			GlobalVars.lang_tempalert = Translate("_tempalert");
			GlobalVars.lang_humalert = Translate("_humalert");
			GlobalVars.lang_onscreennotify = Translate("_onscreennotify");
			GlobalVars.lang_email = Translate("_email");
			GlobalVars.lang_emailsmtpsettings = Translate("_emailsmtpsettings");
			GlobalVars.lang_fromaddress = Translate("_fromaddress");
			GlobalVars.lang_receipientaddress = Translate("_receipientaddress");
			GlobalVars.lang_autostart = Translate("_autostart");
			GlobalVars.lang_startminimized = Translate("_startminimized");
			GlobalVars.lang_utacstart = Translate("_utacstart");
			GlobalVars.lang_alertsystem = Translate("_alertsystem");
			GlobalVars.lang_resetmaxminvalues = Translate("_resetmaxminvalues");
			GlobalVars.lang_resetgraphscale = Translate("_resetgraphscale");
			GlobalVars.lang_autoscalegraph = Translate("_autoscalegraph");
			GlobalVars.lang_graph = Translate("_graph");
			GlobalVars.lang_general = Translate("_general");
			GlobalVars.lang_ftprequirefilerecording = Translate("_ftprequirefilerecording");

			GlobalVars.lang_maxtempalarm = Translate("_maxtempalarm");
			GlobalVars.lang_maxhumalarm = Translate("_maxhumalarm");
			GlobalVars.lang_mintempalarm = Translate("_mintempalarm");
			GlobalVars.lang_minhumalarm = Translate("_minhumalarm");
			GlobalVars.lang_close = Translate("_close");
			
			GlobalVars.lang_mailsuccessfullysent = Translate("_mailsuccessfullysent");
			
		}
		
		
		/// <summary>
		/// Translate a single string<br />
		/// </summary>
		/// <param name="translateInput">String to translagte</param>
		/// <returns>
		/// Translated String (string)
		/// </returns>
		 static string Translate(string translateInput){
			return myLangFile.ReadString("strings",translateInput,translateInput);
		 }

		#endregion
		
		
	}
}


