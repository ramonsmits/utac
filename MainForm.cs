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
 * FileName: 	MainForm.cs
 * Namespace: 	utac
 * Author: 		bof (bjoern@n4rf.de)
 * Created: 	2008-02-01
 * -----------------------------------------------------------------------
 * -------------------------------------------------------- Description *-
 * -----------------------------------------------------------------------
 * MainForm of UTAC
 * Includes the basic working steps.
 */

using System;
using System.Drawing;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using utac.Components.FtpClient;
using utac.Components.LED;
using utac.Components.Settings;
using utac.Components.TEMPer;
using utac.Components.WebServer;
using utac.Components.AveragingSystem;
using utac.Components.AlertSystem;
using ZedGraph;



namespace utac
{

    

	/// <summary>
	/// MainForm of UTAC
	/// </summary>
	/// 
	public partial class MainForm : Form
	{
		private readonly WebServer myWebServer = new WebServer();
		private readonly XMLWebServer myXMLWebServer = new XMLWebServer();
		private static readonly string LogFileName = "LOG-UTAC.txt";
        //private static ArrayList ti = new ArrayList(0);
        private TEMPerInterface[] ti = new TEMPerInterface[10];
        private int dd = 0; // Display This Device
		// private TempHumAvgEngine AvgEngine=null;
		// private AlertForm Alert = new AlertForm();
        private AlertForm Alert = new AlertForm();

        [DllImport("user32.dll")]
        public static extern int ExitWindowsEx(int uFlags, int dwReason);

		public MainForm()
		{
			InitializeComponent();

            OpenCloseBox mybox = new OpenCloseBox();

            mybox.SetBounds((Screen.GetBounds(mybox).Width / 2) - (mybox.Width / 2),(Screen.GetBounds(mybox).Height / 2) - (mybox.Height / 2),mybox.Width, mybox.Height, BoundsSpecified.Location);


            mybox.Show();
            mybox.Refresh();

			progStart();

    		generateGraph(0);

            mybox.Dispose();

            startThread();
                         
		}

		//  This apparently runs each timer tick - basically does an update.
		void Timer1Tick(object sender, EventArgs e)
		{
				startThread();
		}
		
		void startThread(){
			// Thread reads the numbers, the calls refreshDisplay if necessary.
			if(!GlobalVars.threadIsActive){ // Return immediately if the thread is still running from last time.
				Thread ta = new Thread(gettempthread); 
				GlobalVars.threadIsActive = true;
				ta.Start();
            }
        }

        void refreshDisplay() {
            if(!GlobalVars.refreshIsActive) {
                GlobalVars.refreshIsActive = true;
                dd = GlobalVars.displaydevice;

                // Do we have any data?
                if(ti[dd].timestamps.Count > 0){
  				
                    // Grab the temperature.
					double TempDouble = TEMPerInterface.getTempDouble(ti[dd].temps[ti[dd].temps.Count-1]);
					string TempFullText = TEMPerInterface.getTempFullText(ti[dd].temps[ti[dd].temps.Count-1]);
					string TempFullTextLED= TEMPerInterface.getTempFullTextShort(ti[dd].temps[ti[dd].temps.Count-1]);
					
                    // Grab the Humidity
                    double HumDouble = 0;
					if(ti[dd].hums.Count > 0){
						HumDouble = TEMPerInterface.getHumDouble(ti[dd].hums[ti[dd].hums.Count-1]);
						string HumFullText = TEMPerInterface.getHumFullText(ti[dd].hums[ti[dd].hums.Count-1]);
						string HumFullTextLED= TEMPerInterface.getHumFullTextShort(ti[dd].hums[ti[dd].hums.Count-1]);
						LED humLED = new LED(Color.Blue,Color.Black);
						pictureBoxHum.Image = humLED.CreateLEDDisplay(HumFullTextLED);  // Display the humidity
 						// AvgEngine.AddValue(TempDouble,HumDouble);
					} else {
						// AvgEngine.AddValue(TempDouble,-99);
					}
					LED tempLED = new LED(Color.Blue,Color.Black);
					pictureBoxTemp.Image = tempLED.CreateLEDDisplay(TempFullTextLED); // Display the temperature


                    if(GlobalVars.config_list){	generateList();	} // Display List
					if(GlobalVars.config_graph){
                        //  Note - graphics are generated for all graphs here so we can upload them.
                        int i;
                        for (i = 0; i < GlobalVars.devicecount; i++)
                        {
                            generateGraph(i);
                        }
                        generateGraph(dd);

                    } // Display Graph
                    displaymaxmin(); //Display Max and Min Values
                    setnotify(); //SET LABEL FOR TASKBARICON
                }
                GlobalVars.refreshIsActive = false;
            }
        }

        //  Everthing that needs to run when there is new data goes here.
        void doUploads() {
            if(!GlobalVars.uploadIsActive) {
                GlobalVars.uploadIsActive = true;
                dd = GlobalVars.displaydevice;

                // Do we have any data?
                if(ti[dd].timestamps.Count > 0){

                    UpdateGlobals();

                    if (GlobalVars.config_urlactive || GlobalVars.wugactive)
                    {
                        //  Make this run in a separate thread because otherwise
                        //  the delay is too great for the interface.
                        //  However, can't use async call because we need to trash the stream after it loads.
                        if (!GlobalVars.urlthreadIsActive) // We're not even going to try to start a new one unless the old one is done.
                        {
                            Thread tug = new Thread(UrlGrabber);
                            tug.Start();
                        }
                        // UrlGrabber(); // Upload URL Grabber
                    }

					if(GlobalVars.config_recordtofile){
						RecordToFile();  // RECORDTOFILE
                        if (GlobalVars.config_ftpactive)
                        {
                            //  Make this run in a separate thread because otherwise
                            //  the delay is too great for the interface.
                            if (!GlobalVars.ftpthreadIsActive) // We're not even going to try to start a new one unless the old one is done.
                            {
                                GlobalVars.ftpthreadCount = 0;
                                GlobalVars.theFtpThread = new Thread(FtpUpload);
                                GlobalVars.theFtpThread.Start();
                            }
                            else
                            {
                                // If we pass through 4x without the FTP thread being done, then abort it.
                                if (GlobalVars.ftpthreadCount > 4)
                                {
                                    GlobalVars.ftpthreadCount = 0;
                                    GlobalVars.ftpthreadIsActive = false;
                                    GlobalVars.theFtpThread.Abort();
                                }
                                else
                                {

                                    GlobalVars.ftpthreadCount++;
                                }
                            }
                            // FtpUpload(); } // FTP UPLOAD
                        }
					}
                    Alert.CheckAll(); // Check for alert conditions
				}
                GlobalVars.uploadIsActive = false;
			}
		}
		
		
		void setnotify(){
			mynotifyicon.Text = "UTAC";
			if(ti[dd].temps.Count > 0) {
			  mynotifyicon.Text = mynotifyicon.Text + " ["+TEMPerInterface.getTempFullTextShort(ti[dd].temps[ti[dd].temps.Count-1]);
			  if(ti[dd].hums.Count > 0) {
			    mynotifyicon.Text = mynotifyicon.Text + " / "+TEMPerInterface.getHumFullTextShort(ti[dd].hums[ti[dd].hums.Count-1]);	
			  }
              mynotifyicon.Text = mynotifyicon.Text + "] ";
		    }		
		}
		
		
		void generateList(){	
			int i = 0;
			listBox1.Items.Clear();
			while (i < ti[dd].timestamps.Count){
				string TmpTempFullText= TEMPerInterface.getTempFullText(ti[dd].temps[i]);
				string listTxt = "["+ti[dd].timestamps[i].ToString() + "]   "+ TmpTempFullText;
				if(ti[dd].hums.Count > 0){
				string TmpHumFullText= TEMPerInterface.getHumFullText(ti[dd].hums[i]);
				listTxt = listTxt + " - " + TmpHumFullText;
				}
				listBox1.Items.Add(listTxt);
				i++;
			}
			listBox1.TopIndex = listBox1.Items.Count - 1;		
		}
		
		void displaymaxmin(){
 			if(ti[dd].tmax != -999){
			    labelMaxTempVal.Text = TEMPerInterface.getTempFullTextShort(ti[dd].tmax) + " - "+ti[dd].tmax_date;
			} else { labelMaxTempVal.Text = ""; }
			if(ti[dd].tmin != 999){
                labelMinTempVal.Text = TEMPerInterface.getTempFullTextShort(ti[dd].tmin) + " - " + ti[dd].tmin_date; ;
			} else { labelMinTempVal.Text = ""; }
			if(ti[dd].hmax != -999){
			    labelMaxHumVal.Text = TEMPerInterface.getHumFullTextShort(ti[dd].hmax) + " - "+ti[dd].hmax_date;
			} else { labelMaxHumVal.Text  = ""; }
			if(ti[dd].hmin != 999){
			    labelMinHumVal.Text = TEMPerInterface.getHumFullTextShort(ti[dd].hmin) + " - "+ti[dd].hmin_date;
			} else { labelMinHumVal.Text = ""; }
		} 
	
		void generateGraph( int devno ){
    
			PointPairList listTemp = new PointPairList();
			PointPairList listHum = new PointPairList();
            XDate myXDate;
			int i = 0;
            long maxdate=0, mindate=0, hoursrep=0;

            while (i < ti[devno].timestamps.Count){
				string dt = ti[devno].timestamps[i].ToString();
                if ( GlobalVars.config_fahrenheit )
				    myXDate = new XDate(Convert.ToInt32(dt.Substring(6,4)), Convert.ToInt32(dt.Substring(0,2)), Convert.ToInt32(dt.Substring(3,2)), Convert.ToInt32(dt.Substring(11,2)), Convert.ToInt32(dt.Substring(14,2)), Convert.ToInt32(dt.Substring(17,2)) );
                else
                    myXDate = new XDate(Convert.ToInt32(dt.Substring(6,4)), Convert.ToInt32(dt.Substring(3,2)), Convert.ToInt32(dt.Substring(0,2)), Convert.ToInt32(dt.Substring(11,2)), Convert.ToInt32(dt.Substring(14,2)), Convert.ToInt32(dt.Substring(17,2)) );
				listTemp.Add(myXDate,TEMPerInterface.getTempDouble(ti[devno].temps[i]));

                if (i == 0)
                    mindate = myXDate.DateTime.Ticks;
                maxdate = myXDate.DateTime.Ticks;


				if(ti[devno].hums.Count > 0) {
					listHum.Add(myXDate,TEMPerInterface.getHumDouble(ti[devno].hums[i]));
				}
				i++;
			}

            hoursrep = (maxdate - mindate)/10000/1000/60/60;
            // NOTE: 10k ticks per ms. 1000ms per sec. 60 sec per min.  60 min per hour.

            String foo = ti[devno].DeviceName + " Device #" + (devno + 1);

            switch (devno)
            {
                case 0:
                    if ( GlobalVars.config_devicename1.Length > 0 )
                        foo = GlobalVars.config_devicename1;
                    break;
                case 1:
                    if (GlobalVars.config_devicename2.Length > 0)
                        foo = GlobalVars.config_devicename2;
                    break;
                case 2:
                    if (GlobalVars.config_devicename3.Length > 0)
                        foo = GlobalVars.config_devicename3;
                    break;
                case 3:
                    if (GlobalVars.config_devicename4.Length > 0)
                        foo = GlobalVars.config_devicename4;
                    break;
                default:
                    break;
            }

            if (ti[devno].temps.Count > 0)
            {

                foo = foo.Replace("%t%", TEMPerInterface.getTempFullTextShort(ti[devno].temps[ti[devno].temps.Count - 1]));
                foo = foo.Replace("%h%", TEMPerInterface.getHumFullTextShort(ti[devno].hums[ti[devno].hums.Count - 1]));
                foo = foo.Replace("%d%", ti[devno].timestamps[ti[devno].timestamps.Count - 1].ToString());
            }

            tempgraph.GraphPane.Title.Text = foo;
    		tempgraph.GraphPane.Title.IsVisible = true;

			tempgraph.GraphPane.XAxis.Title.IsVisible = false;

            if(GlobalVars.config_fahrenheit)
            {
                tempgraph.GraphPane.YAxis.Title.Text = "°F";
            }
            else
            {
                tempgraph.GraphPane.YAxis.Title.Text = "°C";
            }

            if (ti[devno].DeviceName == "TEMPerHum" || GlobalVars.config_faketemper || GlobalVars.errorStatus)
            {
                tempgraph.GraphPane.AddY2Axis("RH");
                tempgraph.GraphPane.Y2Axis.Title.Text = "%RH";
                tempgraph.GraphPane.YAxis.Title.IsVisible = true;
                tempgraph.GraphPane.Y2Axis.Title.IsVisible = true;
                tempgraph.GraphPane.Y2Axis.IsVisible = true;
            }

            tempgraph.GraphPane.XAxis.Type = AxisType.Date;
			tempgraph.GraphPane.XAxis.Scale.FontSpec.IsBold = true ;
			tempgraph.GraphPane.XAxis.Scale.FontSpec.Size = 12;
			
			
			if(!GlobalVars.config_graph_auto){
				if(GlobalVars.config_graph_max <= GlobalVars.config_graph_min) {
					GlobalVars.config_graph_min = GlobalVars.config_graph_max-1;
				}
			    tempgraph.GraphPane.YAxis.Scale.Min = GlobalVars.config_graph_min;
			    tempgraph.GraphPane.YAxis.Scale.Max = GlobalVars.config_graph_max;

                if (ti[devno].DeviceName == "TEMPerHum" || GlobalVars.config_faketemper || GlobalVars.errorStatus)
                {
                    tempgraph.GraphPane.Y2Axis.Scale.Min = GlobalVars.config_graph_min;
                    tempgraph.GraphPane.Y2Axis.Scale.Max = GlobalVars.config_graph_max;
                }

			} else {
				tempgraph.GraphPane.YAxis.Scale.MaxAuto = true;
				tempgraph.GraphPane.YAxis.Scale.MinAuto = true;
                if (ti[devno].DeviceName == "TEMPerHum" || GlobalVars.config_faketemper || GlobalVars.errorStatus)
                {
                    tempgraph.GraphPane.Y2Axis.Scale.MaxAuto = true;
                    tempgraph.GraphPane.Y2Axis.Scale.MinAuto = true;
                }

			}

            if (hoursrep < 1)
            {
                tempgraph.GraphPane.XAxis.Scale.Format = "HH:mm:ss";
            }
            else if (hoursrep < 48)
            {
                tempgraph.GraphPane.XAxis.Scale.Format = "HH:mm";
            }
            else if (hoursrep < 168)
            {
                if (GlobalVars.config_fahrenheit)
                    tempgraph.GraphPane.XAxis.Scale.Format = "dd HH:mm";
                else
                    tempgraph.GraphPane.XAxis.Scale.Format = "dd HH:mm";
            }
            else
            {
                if (GlobalVars.config_fahrenheit)
                    tempgraph.GraphPane.XAxis.Scale.Format = "MM.dd.yyyy";
                else
                    tempgraph.GraphPane.XAxis.Scale.Format = "dd.MM.yyyy";
            }

    
            //if (GlobalVars.config_fahrenheit)
            //   tempgraph.GraphPane.XAxis.Scale.Format = "MM.dd.yyyy HH:mm:ss";
            //else
            //   tempgraph.GraphPane.XAxis.Scale.Format = "dd.MM.yyyy HH:mm:ss";
			
			
            // tempgraph.GraphPane.XAxis.Scale.FontSpec.Angle = 45;		
			// GlobalVars.graphPicture = tempgraph.GetImage();		//( Why is this here? )
			
            tempgraph.GraphPane.CurveList.Clear();

            LineItem myCurve;

            if (ti[devno].DeviceName == "TEMPerNTC" || ti[devno].DeviceName == "TEMPerNTCV2")
			    myCurve = tempgraph.GraphPane.AddCurve( "Temperature (External)", listTemp, Color.Red,SymbolType.Circle );
            else if (ti[devno].DeviceName == "TEMPerNTCINT")
                myCurve = tempgraph.GraphPane.AddCurve("Temperature (Internal)", listTemp, Color.Red, SymbolType.Circle);
            else
                myCurve = tempgraph.GraphPane.AddCurve( GlobalVars.lang_temperature, listTemp, Color.Red,SymbolType.Circle );

			myCurve.Line.IsSmooth = true;
			// myCurve.Line.Fill = new Fill( Color.White, Color.FromArgb( 120, 255, 0, 0), 45F );
			myCurve.Symbol.Fill = new Fill( Color.White );

         
            if (ti[devno].hums.Count > 0 && (ti[devno].DeviceName == "TEMPerHum" || GlobalVars.config_faketemper || GlobalVars.errorStatus))
            {
			 LineItem myCurve2 = tempgraph.GraphPane.AddCurve( GlobalVars.lang_humidity, listHum, Color.Blue,SymbolType.Circle );
			 myCurve2.Line.IsSmooth = true;
			// myCurve2.Line.Fill = new Fill( Color.White, Color.FromArgb( 120, 0, 0, 255), 45F );
			 myCurve2.Symbol.Fill = new Fill( Color.White );
             myCurve2.IsY2Axis = true;
			}

			tempgraph.GraphPane.Chart.Fill = new Fill( Color.White, Color.LightGoldenrodYellow, 45F );
			tempgraph.GraphPane.Fill = new Fill( Color.White, Color.FromArgb( 220, 220, 255 ), 45F );
			tempgraph.AxisChange();
			tempgraph.Refresh();
			GlobalVars.graphPicture[devno] = tempgraph.GetImage();
		}
		
		void UrlGrabber(){
            GlobalVars.urlthreadIsActive = true; // Lock this function
			WebClient Client = new WebClient ();
            double dewpt = 0;

          
			
			if(GlobalVars.config_proxyactivated){
				if(GlobalVars.config_proxyuseauthetification){
					Client.Proxy = new WebProxy(GlobalVars.config_proxyhost,Convert.ToInt32(GlobalVars.config_proxyport));
					Client.Proxy.Credentials = new NetworkCredential(GlobalVars.config_proxyuser,GlobalVars.config_proxypass);
				} else {
					Client.Proxy = new WebProxy(GlobalVars.config_proxyhost,Convert.ToInt32(GlobalVars.config_proxyport));
				}
			}
			
			String replaceString;

            if (GlobalVars.wugactive && ti[0].hums.Count > 0)
            {
                replaceString = "http://weatherstation.wunderground.com/weatherstation/updateweatherstation.php?ID=" + GlobalVars.wugid + "&PASSWORD="
                    + GlobalVars.wugpw + "&action=updateraw&dateutc=%date0%&tempf=%temp0%&humidity=%hum0%&dewptf=%dew0%&softwaretype=UTAC";

            }
            else if (GlobalVars.wugactive )
            {
                replaceString = "http://weatherstation.wunderground.com/weatherstation/updateweatherstation.php?ID=" + GlobalVars.wugid + "&PASSWORD="
                    + GlobalVars.wugpw + "&action=updateraw&dateutc=%date0%&tempf=%temp0%&softwaretype=UTAC";
            }
            else
            {
                replaceString = GlobalVars.config_url;
            }

            int i = 0;
            for (i = 0; i<GlobalVars.devicecount; i++)
            {

                // Calculate the DewPoint;

                if (ti[i].hums.Count > 0)
                {
                    double H, Dp;
                    double T, RH;

                    // Note: In Celsius

                    T = double.Parse(ti[i].temps[ti[i].temps.Count - 1].ToString());
                    RH = double.Parse(ti[i].hums[ti[i].hums.Count - 1].ToString());

                    H = (Math.Log10(RH) - 2) / 0.4343 + (17.62 * T) / (243.12 + T);
                    Dp = 243.12 * H / (17.62 - H); // this is the dew point in Celsius

                    if (GlobalVars.config_fahrenheit)
                    {
                        dewpt = TEMPerInterface.CtoF(Dp);
                    }
                    else
                    {
                        dewpt = Dp;
                    }
                }

                if ( ti[i].temps.Count > 0 )
                    replaceString = replaceString.Replace("%temp"+i+"%", TEMPerInterface.getTempDouble(ti[i].temps[ti[i].temps.Count - 1]).ToString());
                if (ti[i].hums.Count > 0)
                {
                    replaceString = replaceString.Replace("%hum" + i + "%", ti[i].hums[ti[i].hums.Count - 1].ToString());
                    replaceString = replaceString.Replace("%dew" + i + "%", dewpt.ToString());

                }

                if ( ti[i].timestamps.Count > 0)
                {
                 
                    replaceString = replaceString.Replace("%timestamp" + i + "%", ti[i].timestamps[ti[i].temps.Count - 1].ToString());                    
                }

                if (ti[i].utctimestamps.Count > 0)
                {
                    DateTime utctime = (DateTime)ti[i].utctimestamps[ti[i].temps.Count - 1];
                    replaceString = replaceString.Replace("%utc" + i + "%", Uri.EscapeDataString(utctime.ToString("yyyy-MM-dd HH:mm:ss")));
                }
            }
			
			try{
                Client.OpenRead(new Uri(replaceString)).Close(); // Had to make it blocking & close it to make sure it kept working.
			} catch (WebException ex) {
				showStatus(ex.Message);
			}

            // Calculate dewpoint.

            if ( ti[0].hums.Count > 0 ) {
                double H, Dp;
                double T, RH;

                // Note: In Celsius

                T = double.Parse(ti[0].temps[ti[0].temps.Count - 1].ToString());
                RH = double.Parse(ti[0].hums[ti[0].hums.Count - 1].ToString());

                H = (Math.Log10(RH) - 2) / 0.4343 + (17.62 * T) / (243.12 + T);
                Dp = 243.12 * H / (17.62 - H); // this is the dew point in Celsius

                if(GlobalVars.config_fahrenheit){
				    dewpt = TEMPerInterface.CtoF(Dp);
			    } else {
				    dewpt = Dp;
			    }
            }

            GlobalVars.urlthreadIsActive = false; // Unlock this function
            
		}

        void UpdateGlobals()
        {
            String replaceString = GlobalVars.config_url;
            int i;
            for (i = 0; i < GlobalVars.devicecount; i++)
            {
                GlobalVars.currenttemp[i]=TEMPerInterface.getTempDouble(ti[i].temps[ti[i].temps.Count - 1]).ToString("###0.00");
                if (ti[i].hums.Count > 0)
                {
                    GlobalVars.currenthum[i]= TEMPerInterface.getHumDouble(ti[i].hums[ti[i].hums.Count - 1]).ToString("###0.00");
                }
                GlobalVars.currentts[i]= ti[i].timestamps[ti[i].temps.Count - 1].ToString();
            }
       }



		
		void RecordToFile(){

            string Temp = null;
            string Hum = null;
            string TimeStamp = null;

			DateTime mydt = DateTime.Now;
			string currentday = mydt.ToString("yyyy-MM-dd");
			int i = 0;
			
			if(GlobalVars.config_filepath == "") {
				MessageBox.Show(GlobalVars.lang_nooutputpath,GlobalVars.lang_error);		
			} else {
                for (i = 0; i < GlobalVars.devicecount; i++)
                {
                    if (ti[i].timestamps.Count > 0)
                    {
                        Temp = TEMPerInterface.getTempDouble(ti[i].temps[ti[i].temps.Count - 1]).ToString("###0.00000");
                        Hum = TEMPerInterface.getHumDouble(ti[i].hums[ti[i].hums.Count - 1]).ToString("###0.00000");
                        TimeStamp = ti[i].timestamps[ti[i].timestamps.Count - 1].ToString();

                        if (GlobalVars.config_csv)
                        { // CSV means COMMA separated, not semicolon.
                            if (GlobalVars.config_dailyfiles)
                            {
                                AppendToFile(GlobalVars.config_filepath + "\\" + "TEMPer-" + currentday + ".csv", TimeStamp + "," + i + "," + Temp + "," + Hum);
                            }
                            else
                            {
                                AppendToFile(GlobalVars.config_filepath + "\\" + "TEMPer.csv", TimeStamp + "," + i + "," + Temp + "," + Hum);
                            }
                        }
                        else
                        {
                            if (GlobalVars.config_dailyfiles)
                            {
                                AppendToFile(GlobalVars.config_filepath + "\\" + "TEMPer-" + currentday + ".txt", TimeStamp + " " + i + " " + Temp + " " + Hum);
                            }
                            else
                            {
                                AppendToFile(GlobalVars.config_filepath + "\\" + "TEMPer.txt", TimeStamp + " " + i + " " + Temp + " " + Hum);
                            }
                        }
                    }
                }
			}
		}
		
		void FtpUpload(){
            GlobalVars.ftpthreadIsActive = true; // Lock this function
            updateTemperLabel(99);
			DateTime mydt = DateTime.Now;
			string currentday = mydt.ToString("yyyy-MM-dd");
			FtpClient myFtpClient = new FtpClient();
			myFtpClient.Server = GlobalVars.config_ftpserver;
			myFtpClient.Port = Convert.ToInt32(GlobalVars.config_ftpport);
			myFtpClient.Username = GlobalVars.config_ftpuser;
			myFtpClient.Password = GlobalVars.config_ftppass;
			bool ftperror = false;
            log("FTP Client Started: "+myFtpClient.Server+":"+myFtpClient.Port+"; "+myFtpClient.Username+"/"+myFtpClient.Password);
            try {
				myFtpClient.Login();
			} catch (FtpClient.FtpException ex) {
                log("FTP Client Login ERROR: " + ex.Message);
				showStatus("FTP ERROR: " + ex.Message);
				ftperror = true;
			}

            if (!ftperror)
                log("FTP Client Logged In");

            if (!ftperror){
				try {
					myFtpClient.ChangeDir(GlobalVars.config_ftpuploaddir);
				} catch (FtpClient.FtpException ex) {
					showStatus("FTP ERROR: "+ex.Message);
					ftperror = true;
				}
			}
			
			if (!ftperror){
				string myfilename;
				if(GlobalVars.config_csv){
					if(GlobalVars.config_dailyfiles){
						myfilename = GlobalVars.config_filepath+"\\"+"TEMPer-"+currentday+".csv";
					}
					else {
						myfilename = GlobalVars.config_filepath+"\\"+"TEMPer.csv";
					}
				}
				else {
					if(GlobalVars.config_dailyfiles){
						myfilename = GlobalVars.config_filepath+"\\"+"TEMPer-"+currentday+".txt";
					}
					else {
						myfilename = GlobalVars.config_filepath+"\\"+"TEMPer.txt";
					}
				}
				
				try {
                    myFtpClient.BinaryMode = false;
					myFtpClient.Upload(myfilename);
					
					
				} catch (FtpClient.FtpException ex) {
					showStatus(GlobalVars.lang_couldnotuploadfile+": "+ex.Message);
					ftperror = true;
				}
				
				if(GlobalVars.config_graph && GlobalVars.config_ftpuploadgraph){
                    int i;
                    for (i = 0; i < GlobalVars.devicecount; i++)
                    {
                        String graphuploadpath = GlobalVars.config_filepath + "\\" + "utac" + i + ".jpeg";

                        try
                        {
                            GlobalVars.graphPicture[i].Save(graphuploadpath, System.Drawing.Imaging.ImageFormat.Jpeg);
                            myFtpClient.BinaryMode = true;
                            myFtpClient.Upload(graphuploadpath);
                            // File.Delete(graphuploadpath);
                        }
                        catch (Exception ex)
                        {
                            showStatus(GlobalVars.lang_couldnotuploadfile + ": " + ex.Message);
                        }
                    }

				}
			}
			
			try {
 				myFtpClient.Close();
			} catch (Exception ex ){
                showStatus("FTP Close Error: " + ex.Message);
                GlobalVars.ftpthreadIsActive = false; // Unlock this function
                updateTemperLabel(99);
			}

            GlobalVars.ftpthreadIsActive = false; // Unlock this function
            updateTemperLabel(99);
			
		}

        void updateTemperLabel(int device)
        {
            string tl = GlobalVars.devicecount + " Devices: ";
            if (device < GlobalVars.devicecount)
            {
                tl = tl + "Reading D" + device;
            }
            else if (  GlobalVars.ftpthreadIsActive )
            {
                tl = tl + "FTP Upload";
            } else {
                tl = tl + "Idle";
            }
  
            temperLabel.Text = tl;
        }

 		void gettempthread()
		{

            int devindex = 0;
			Double TempC = -99;
			Double Hum = -99;
			Double[] tmpRead;


            Alert.Hide();

            for (devindex = 0; devindex < GlobalVars.devicecount; devindex++)
            {

                updateTemperLabel(devindex);

                if (GlobalVars.config_faketemper || GlobalVars.errorStatus)
                {
                    Random random = new Random();
                    TempC = random.Next(-40, 120);
                    Hum = random.Next(1, 99);
                }
                else
                {
                    tmpRead = ti[devindex].Read();
                    TempC = tmpRead[0];
                    Hum = tmpRead[1];
                }


                // Apply individual calibrations

                if (devindex < 4)
                {
                    switch (devindex)
                    {
                        case 0:
                            TempC = TempC + ((TempC * GlobalVars.config_tempcals1) / 100) + GlobalVars.config_tempcalo1;
                            Hum = Hum + ((Hum * GlobalVars.config_humcals1) / 100) + GlobalVars.config_humcalo1;
                            break;
                        case 1:
                            TempC = TempC + ((TempC * GlobalVars.config_tempcals2) / 100) + GlobalVars.config_tempcalo2;
                            Hum = Hum + ((Hum * GlobalVars.config_humcals2) / 100) + GlobalVars.config_humcalo2;
                            break;
                        case 2:
                            TempC = TempC + ((TempC * GlobalVars.config_tempcals3) / 100) + GlobalVars.config_tempcalo3;
                            Hum = Hum + ((Hum * GlobalVars.config_humcals3) / 100) + GlobalVars.config_humcalo3;
                            break;
                        case 3:
                            TempC = TempC + ((TempC * GlobalVars.config_tempcals4) / 100) + GlobalVars.config_tempcalo4;
                            Hum = Hum + ((Hum * GlobalVars.config_humcals4) / 100) + GlobalVars.config_humcalo4;
                            break;

                    }

                }

                DateTime dt = DateTime.Now;
                string currentDate = dt.ToString("dd/MM/yyyy HH:mm:ss");
                if (GlobalVars.config_fahrenheit)
                {
                    currentDate = dt.ToString("MM/dd/yyyy HH:mm:ss"); // Changed format to conform to US Excel expectations.
                }


                if (ti[devindex].hadBadReading)
                {

                    if (GlobalVars.config_rebootonerror)
                    {
                        log("Rebooting on error.");
                        ExitWindowsEx(2, 0x10); // Reboot, Force If Hung
                    }
                    TempC = -99; Hum = -99;
                }

                ti[devindex].timestamps.Add(currentDate);
                ti[devindex].utctimestamps.Add(DateTime.UtcNow);
                ti[devindex].temps.Add(TempC);
                if (ti[devindex].DeviceName == "TEMPerHum" || GlobalVars.config_faketemper || GlobalVars.errorStatus)
                {
                    ti[devindex].hums.Add(Hum);
                }
                else
                {
                    ti[devindex].hums.Add(-99);
                }                


                // Trim the arrays down to their max size if needed.
                while (ti[devindex].timestamps.Count > GlobalVars.config_listitems)
                {
                    ti[devindex].timestamps.RemoveAt(0);
                }
                while (ti[devindex].utctimestamps.Count > GlobalVars.config_listitems)
                {
                    ti[devindex].utctimestamps.RemoveAt(0);
                }
                while (ti[devindex].temps.Count > GlobalVars.config_listitems)
                {
                    ti[devindex].temps.RemoveAt(0);
                }
                while (ti[devindex].hums.Count > GlobalVars.config_listitems)
                {
                    ti[devindex].hums.RemoveAt(0);
                }

                if (TempC > ti[devindex].tmax)
                {
                    ti[devindex].tmax = TempC;
                    ti[devindex].tmax_date = currentDate;
                }

                if (TempC < ti[devindex].tmin)
                {
                    ti[devindex].tmin = TempC;
                    ti[devindex].tmin_date = currentDate;
                }

                if (Hum > ti[devindex].hmax)
                {
                    ti[devindex].hmax = Hum;
                    ti[devindex].hmax_date = currentDate;
                }

                if (Hum < ti[devindex].hmin)
                {
                    ti[devindex].hmin = Hum;
                    ti[devindex].hmin_date = currentDate;
                }

            }

            updateTemperLabel(99);
 
            GlobalVars.threadIsActive = false;
            refreshDisplay();
            doUploads();
		}

		public void progStat(){

			MultiLang.TransLateAll();
			MultiLangForm();
			
			try {
				if(myWebServer != null) 
				{
					myWebServer.Stop();
				}
				if(myXMLWebServer != null)
				{
					myXMLWebServer.Stop();
				}
			} catch{ }

			//WEB SERVER BUTTON
			if(GlobalVars.config_BIWActivated){
				toolStripButton4.Checked = true;
			} else {
				toolStripButton4.Checked = false;
			}
			
			//XML WEB SERVER BUTTON
			if(GlobalVars.config_BIWXMLActivated){
				toolStripButton3.Checked = true;
			} else {
				toolStripButton3.Checked = false;
			}
			
			//TIMER BUTTON
			if(GlobalVars.config_timer){
				toolStripButton2.Checked = true;
			} else {
				toolStripButton2.Checked = false;
			}
		
			if (GlobalVars.config_graph) {
				Width = 805;
				buttongraph.ImageIndex = 0;
			}
			else {
				Width = 320;
				buttongraph.ImageIndex = 1;
			}

		    if (GlobalVars.config_list) {
				listBox1.Visible = true;
				buttongraph.Height = 443;
				Height = 520;
				buttonlist.ImageIndex = 0;
			}
			else {
				listBox1.Visible = false;
				buttonlist.ImageIndex = 1;
				if (GlobalVars.config_graph) {
				Height = 520;
				buttongraph.Height = 443;
				} else {
				Height = 350;
				buttongraph.Height = 277;
				}

			}
			
			if(GlobalVars.config_BIWActivated){
			    if (myWebServer != null) myWebServer.Start();
			}
			if(GlobalVars.config_BIWXMLActivated){
			    if (myXMLWebServer != null) myXMLWebServer.Start();
			}
			
		
			//SET TIMER
			timer.Interval = Convert.ToInt32(GlobalVars.config_timercount*1000);
			if(GlobalVars.config_timer){
				timer.Enabled = true;
			} else{
				timer.Enabled = false;
			}	

		}
		
		public void progStart(){
			
			toolStrip.ImageList = imageListToolStrip;
			toolStrip.Items[0].ImageIndex = 0;
			toolStrip.Items[1].ImageIndex = 1;
			toolStrip.Items[3].ImageIndex = 2;
			toolStrip.Items[4].ImageIndex = 3;
			
			toolStrip.Items[6].ImageIndex = 4;
			
			toolStrip.Items[8].ImageIndex = 5;
			toolStrip.Items[9].ImageIndex = 6;
			toolStrip.Items[10].ImageIndex = 7;
			
			Config myconfig = new Config();
			myconfig.LoadConfig();
			progStat();			
			if(GlobalVars.config_temperautodetect){
				String[] ComPorts = TEMPerInterface.FindDevices(this.Handle);
				if(ComPorts.Length == 0 || ComPorts[0] == ""){
					MessageBox.Show(GlobalVars.lang_couldnotfindtemperdevice,GlobalVars.lang_error);
					GlobalVars.errorStatus = true;
                    GlobalVars.devicecount = 1;
                    ti[0] = new TEMPerInterface("ERR");
				} else {
                    GlobalVars.devicecount = ComPorts.Length;
                    int k,m;
                    m = 0;
                    for (k = 0; k < ComPorts.Length; k++)
                    {
                        try
                        {
                            ti[m]= new TEMPerInterface(ComPorts[k]);
                        }
                        catch (Exception e)
                        {
                            showStatus("TEMPer Error: " + e.Message + e.Source + e.StackTrace);
                            GlobalVars.errorStatus = true;                       
                        }
                        if (ti[m].DeviceName == "TEMPerNTC" || ti[m].DeviceName == "TEMPerNTCV2")
                        {
                            m++;
                            GlobalVars.devicecount++;
                            // log("Trying to register TEMPerNTCINT");
                            try
                            {
                                ti[m] = new TEMPerInterface(ComPorts[k], ti[m-1].m_SerialPort , "TEMPerNTCINT");
                                m++;
                            }
                            catch (Exception e)
                            {
                                showStatus("TEMPer Error: " + e.Message + e.Source + e.StackTrace);
                                GlobalVars.errorStatus = true;
                            }
                        }
                        m++;
                    }
				}
			} else {
				try{
				    ti[0] = new TEMPerInterface(GlobalVars.config_comport);				 
				} catch (Exception e) {
					showStatus("TEMPer Error: "+e.Message+e.Source+e.StackTrace);
					GlobalVars.errorStatus = true;
                    GlobalVars.devicecount = 1;
                    ti[0] = new TEMPerInterface("ERR");
				}
			}

            // Load the NTC curve.  NTC_10K_1.txt

            FileStream input = null;

            if (File.Exists(Application.StartupPath + "\\NTC_10K_1.txt"))
            {
                input = new FileStream(Application.StartupPath + "\\NTC_10K_1.txt", FileMode.Open);
            }
            else
            {
                input = null;
            }
          
            String mybuffer="";
            String[] keys;
            int thebyte = 0;
            
            if (input != null && input.CanRead)
            {
                log("Found NTC_10K_1.txt: " + input.Length.ToString());

                

                while (input.Position < input.Length) {
                    do
                    {
                        thebyte = input.ReadByte();
                        if ( thebyte >= (int) ' ' )
                            mybuffer += Convert.ToChar(thebyte);
                    } while (thebyte >= (int) ' ' && input.Position < input.Length);

                    if (mybuffer.Length> 2 && mybuffer.Substring(0, 1) != "*")
                    {
                        // log("Line Read: "+mybuffer);
                        keys = mybuffer.Split(';');

                        GlobalVars.ntc_temps[GlobalVars.ntc_count] = Convert.ToDouble(keys[0], new CultureInfo("en-US"));
                        GlobalVars.ntc_factors[GlobalVars.ntc_count] = Convert.ToDouble(keys[1], new CultureInfo("en-US"));
                        GlobalVars.ntc_count++;
                    }
                    
                    mybuffer = "";
                }
                
                input.Close();

                input.Dispose();

                log("Loaded "+GlobalVars.ntc_count+" NTC Factors.");

                if (GlobalVars.ntc_count > 5) GlobalVars.config_hasntcdata = true;

                
            }


            // Load the other NTC curve.  _NTC_10K_1.txt

            if (File.Exists(Application.StartupPath + "\\_NTC_10K_1.txt"))
            {
                input = new FileStream(Application.StartupPath + "\\_NTC_10K_1.txt", FileMode.Open);
            }
            else
            {
                input = null;
            }

            mybuffer = "";
            thebyte = 0;


            if (input != null && input.CanRead)
            {
                log("Found _NTC_10K_1.txt: " + input.Length.ToString());


                while (input.Position < input.Length)
                {
                    do
                    {
                        thebyte = input.ReadByte();
                        if (thebyte >= (int)' ')
                            mybuffer += Convert.ToChar(thebyte);
                    } while (thebyte >= (int)' ' && input.Position < input.Length);

                    if (mybuffer.Length > 2 && mybuffer.Substring(0, 1) != "*")
                    {
                        // log("Line Read: "+mybuffer);
                        keys = mybuffer.Split(';');

                        GlobalVars.ntcb_temps[GlobalVars.ntcb_count] = Convert.ToDouble(keys[0], new CultureInfo("en-US"));
                        GlobalVars.ntcb_factors[GlobalVars.ntcb_count] = Convert.ToDouble(keys[1], new CultureInfo("en-US"));
                        GlobalVars.ntcb_count++;
                    }

                    mybuffer = "";
                }

                input.Close();

                log("Loaded " + GlobalVars.ntcb_count + " older NTC Factors.");

                if (GlobalVars.ntcb_count > 5) GlobalVars.config_hasntcbdata = true;


            }

			
			// AvgEngine = new TempHumAvgEngine();
			Text = "UTAC :: "+GlobalVars._UTACVERSION;
			if(GlobalVars.config_startminimized) {
				 WindowState = FormWindowState.Minimized;
				 Hide();
				 Visible = false;
			}
			progStat();       			
		}
		
		
		public void progEnd(){

            OpenCloseBox mybox = new OpenCloseBox();

            mybox.label2.Text = "Closing...";
            mybox.Text = "UTAC Closing...";

            mybox.SetBounds((Screen.GetBounds(mybox).Width / 2) - (mybox.Width / 2), (Screen.GetBounds(mybox).Height / 2) - (mybox.Height / 2), mybox.Width, mybox.Height, BoundsSpecified.Location);


            mybox.Show();
            mybox.Refresh();

            Alert.Hide();

			try {
				if(myWebServer != null) myWebServer.Stop();
				if(myXMLWebServer != null)myXMLWebServer.Stop();
  			} catch{}

            DateTime timeout = DateTime.Now.AddSeconds(15);

            while ((GlobalVars.refreshIsActive || GlobalVars.uploadIsActive || GlobalVars.threadIsActive 
                || GlobalVars.urlthreadIsActive || GlobalVars.ftpthreadIsActive) && timeout > DateTime.Now) Thread.Sleep(0);

            Thread.Sleep(500);

			Config myconfig = new Config();
			myconfig.SaveConfig();

            mybox.Dispose();

        }
		
		void MainFormFormClosed(object sender, FormClosedEventArgs e)
		{
			progEnd();
		}
		
	
		void showStatus(string mystatus){
			DateTime dt = DateTime.Now;
			string currentDate = dt.ToString("yyyy-MM-dd HH:mm:ss");

            mystatus.Replace('\r', ' ');
            mystatus.Replace('\n', ' ');

            log(mystatus);
			
            if ( mystatus.Length > 25 )
			    statuslabel.Text = "["+currentDate+"]: "+mystatus.Substring(0, 20)+ "...";
            else
                statuslabel.Text = "[" + currentDate + "]: " + mystatus;

			statuslabel.Visible = true;
			statuslabel.ToolTipText = mystatus;
			statusStrip.Refresh();
			
			
			if(GlobalVars.config_log){
			log(mystatus);
			}
		}
		
		
		public static void log(string newLogLine){
			DateTime dt = DateTime.Now;
			string currentDate = dt.ToString("yyyy-MM-dd HH:mm:ss");
			
			if(GlobalVars.config_log){
			try {
				StreamWriter SW;
				SW=File.AppendText(LogFileName);
				SW.WriteLine("["+currentDate+"] "+newLogLine);
				SW.Close();
				} catch (Exception) {}
			}
		}
		
		void  AppendToFile(string Filename, string TextToAdd)
		{
			try {
				StreamWriter SW;
				SW=File.AppendText(Filename);
                SW.WriteLine(TextToAdd);
				SW.Close();
			} catch (IOException ex){
				showStatus(GlobalVars.lang_errorrecordtofile +": "+ ex);
			}
		}
				
		void MultiLangForm(){
			groupBoxActualTemp.Text = GlobalVars.lang_actualtemp;
			groupBoxActualHumidty.Text = GlobalVars.lang_actualhumidity;
			groupBoxMinMaxValues.Text = GlobalVars.lang_minmaxvalues;
			toolStrip.Items[0].ToolTipText = GlobalVars.lang_refreshtempmanual;
			toolStrip.Items[1].ToolTipText = GlobalVars.lang_activatedeactivatetimer;
			toolStrip.Items[3].ToolTipText = GlobalVars.lang_activatedeactivatexmlwebserver;
			toolStrip.Items[4].ToolTipText = GlobalVars.lang_activatedeactivatewebserver;
			
			toolStrip.Items[6].ToolTipText = GlobalVars.lang_more;
			
			toolStrip.Items[8].ToolTipText = GlobalVars.lang_settings;
			toolStrip.Items[9].ToolTipText = GlobalVars.lang_info;
			toolStrip.Items[10].ToolTipText = GlobalVars.lang_exit;
			labelMaxTemp.Text = GlobalVars.lang_maxtemp;
			labelMinTemp.Text = GlobalVars.lang_mintemp;
			labelMaxHum.Text = GlobalVars.lang_maxhumidty;
			labelMinHum.Text = GlobalVars.lang_minhumidity;
			
			// temperLabel.Text =  GlobalVars.lang_device+": "+GlobalVars.TEMPerName;
			
			labelMinTemp.Text = GlobalVars.lang_mintemp;
			labelMaxTemp.Text = GlobalVars.lang_maxtemp;
			labelMinHum.Text = GlobalVars.lang_minhumidity;
			labelMaxHum.Text = GlobalVars.lang_maxhumidty;
			
			resetGraphScaleToolStripMenuItem.Text = GlobalVars.lang_resetgraphscale;
			resetMaxMinValuesToolStripMenuItem.Text = GlobalVars.lang_resetmaxminvalues;
			
		
			
		}
		
		
		void ButtongraphClick(object sender, EventArgs e)
		{
			if (GlobalVars.config_graph) {GlobalVars.config_graph = false;}
			else { GlobalVars.config_graph = true; }
			progStat();
		}
		
		
		void ExternalCMDCheckTimerTick(object sender, EventArgs e)
		{
			if(GlobalVars.externalRefresh){
				GlobalVars.externalRefresh = false;
				startThread();
			}
		}
		
		void ButtonlistClick(object sender, EventArgs e)
		{
			if (GlobalVars.config_list) {GlobalVars.config_list = false;}
			else { GlobalVars.config_list = true; }
			progStat();
		}
		
		
		void ToolStripButton5Click(object sender, EventArgs e)
		{
			advancedsettings mysettings = new advancedsettings();
			mysettings.ShowDialog();
			progStat();
		}
		
		void ToolStripButton6Click(object sender, EventArgs e)
		{
			infoform myinfo = new infoform();
			myinfo.ShowDialog();
		}
		
		
		void ToolStripButton7Click(object sender, EventArgs e)
		{
			Close();
		}
		
		void ToolStripButton1Click(object sender, EventArgs e)
		{
			startThread();
		}
		
		void ToolStripButton2Click(object sender, EventArgs e)
		{
			if(GlobalVars.config_timer){
				GlobalVars.config_timer = false;
			} else {
				GlobalVars.config_timer = true;
			}
			progStat();
		}
		
		void ToolStripButton3Click(object sender, EventArgs e)
		{
			if(GlobalVars.config_BIWXMLActivated){
				GlobalVars.config_BIWXMLActivated = false;
			} else {
				GlobalVars.config_BIWXMLActivated = true;
			}
			progStat();
		}
		
		void ToolStripButton4Click(object sender, EventArgs e)
		{
			if(GlobalVars.config_BIWActivated){
				GlobalVars.config_BIWActivated = false;
			} else {
				GlobalVars.config_BIWActivated = true;
			}
			progStat();
		}
		
		void NotifyIcon1MouseDoubleClick(object sender, MouseEventArgs e)
		{
			Show();
			WindowState = FormWindowState.Normal;
			mynotifyicon.Visible = false;
		}
		
		void MainFormResize(object sender, EventArgs e)
		{
			switch (WindowState)
			{
			    case FormWindowState.Minimized:
			        mynotifyicon.Visible = true;
			        Hide();
			        break;
			    case FormWindowState.Normal:
			        mynotifyicon.Visible = false;
			        break;
			}
		}
		
		void resetMinMax(){
            int i;
            for (i = 0; i < GlobalVars.devicecount; i++)
            {
                ti[i].tmax = -999;
                ti[i].tmin = 999;
                ti[i].hmax = -999;
                ti[i].hmin = 999;
            }

		    labelMaxTempVal.Text = "";
		    labelMinTempVal.Text = "";
		    labelMaxHumVal.Text  = "";
		    labelMinHumVal.Text = "";
		}
		
		void ResetMaxMinValuesToolStripMenuItemClick(object sender, EventArgs e)
		{
			resetMinMax();
		}
		
		void ResetGraphScaleToolStripMenuItemClick(object sender, EventArgs e)
		{
			tempgraph.ZoomOutAll(tempgraph.GraphPane);
			GlobalVars.config_graph_auto = true;
			generateGraph(0);
		}

        private void DeviceButton_Click(object sender, EventArgs e)
        {
            GlobalVars.displaydevice++;
            if (GlobalVars.displaydevice >= GlobalVars.devicecount)
                GlobalVars.displaydevice = 0;
            DeviceButton.Text = (GlobalVars.displaydevice + 1).ToString();
            refreshDisplay();
        }
	
	}
}


