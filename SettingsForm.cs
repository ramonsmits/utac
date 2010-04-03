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
 * FileName: 	SettingsForm.cs
 * Namespace: 	utac
 * Author: 		bof (bjoern@n4rf.de)
 * Created: 	2008-02-01
 * -----------------------------------------------------------------------
 * -------------------------------------------------------- Description *-
 * ------------------------------------------------------------------------
 * This Form is for all Setting Controls
 */
using System;
using System.IO;
using System.Net;
using System.Windows.Forms;
using utac.Components.FtpClient;
using utac.Components.Settings;
using utac.Components.TEMPer;
using utac.Components.Mail;

namespace utac
{
    public partial class advancedsettings : Form
    {
        public advancedsettings()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            LoadConfig();
            MultiLangForm();

        }

        void LoadConfig()
        {
            //Output Timer
            radioCelsius.Checked = GlobalVars.config_celsius;
            radioFahrenheit.Checked = GlobalVars.config_fahrenheit;
            checkboxlist.Checked = GlobalVars.config_list;
            numericUpDownlistItems.Value = GlobalVars.config_listitems;

            checkboxtimer.Checked = GlobalVars.config_timer;
            timercount.Value = GlobalVars.config_timercount;

            //Graph
            checkboxgraph.Checked = GlobalVars.config_graph;
            checkBoxAutoSizeGraph.Checked = GlobalVars.config_graph_auto;
            numericUpDownGraphScaleMax.Value = Convert.ToDecimal(GlobalVars.config_graph_max);
            numericUpDownGraphScaleMin.Value = Convert.ToDecimal(GlobalVars.config_graph_min);

            //File Recording
            checkboxrecordtofile.Checked = GlobalVars.config_recordtofile;
            checkboxdailyfiles.Checked = GlobalVars.config_dailyfiles;
            radioCSV.Checked = GlobalVars.config_csv;
            radioTXT.Checked = GlobalVars.config_txt;
            textboxpath.Text = GlobalVars.config_filepath;

            //FTP Upload
            checkBoxftp.Checked = GlobalVars.config_ftpactive;
            textBox_ftpserver.Text = GlobalVars.config_ftpserver;
            textBox_ftpport.Text = GlobalVars.config_ftpport;
            textBox_ftpuser.Text = GlobalVars.config_ftpuser;
            textBox_ftppass.Text = GlobalVars.config_ftppass;
            textBox_ftpuploaddir.Text = GlobalVars.config_ftpuploaddir;
            checkBoxFTPUploadGraph.Checked = GlobalVars.config_ftpuploadgraph;

            //E-Mail 	
            textBoxEmailServer.Text = GlobalVars.config_mail_server;
            textBoxEmailPort.Text = GlobalVars.config_mail_server_port;
            textBoxEmailUsername.Text = GlobalVars.config_mail_user;
            textBoxEmailPassword.Text = GlobalVars.config_mail_password;
            textBoxEmailFromAddress.Text = GlobalVars.config_mail_from;
            textBoxEmailReceipientAddress.Text = GlobalVars.config_mail_to;

            //Web URL Grabber
            textBoxURL.Text = GlobalVars.config_url;
            WUG_ID.Text = GlobalVars.wugid;
            WUG_PW.Text = GlobalVars.wugpw;

            checkBoxURLactivated.Checked = GlobalVars.config_urlactive;
            WUG_Active.Checked = GlobalVars.wugactive;

            //BuiltIn Webserver
            checkBoxBIWActivated.Checked = GlobalVars.config_BIWActivated;
            updownBIWPort.Value = GlobalVars.config_BIWPort;
            checkBoxBIWEnableRefresh.Checked = GlobalVars.config_BIWRefresh;

            checkBoxBIWXMLActivated.Checked = GlobalVars.config_BIWXMLActivated;
            updownBIWXMLPort.Value = GlobalVars.config_BIWXMLPort;
            checkBoxBIWXMLRefresh.Checked = GlobalVars.config_BIWXMLRefreshOnAccess;
            textBoxBIW.Text = GlobalVars.config_BIWTitle;

            //Graphing
            textBoxDeviceName1.Text = GlobalVars.config_devicename1;
            textBoxDeviceName2.Text = GlobalVars.config_devicename2;
            textBoxDeviceName3.Text = GlobalVars.config_devicename3;
            textBoxDeviceName4.Text = GlobalVars.config_devicename4;
            
            //Proxy DEBUG
            checkBoxproxy.Checked = GlobalVars.config_proxyactivated;
            checkBoxuseauth.Checked = GlobalVars.config_proxyuseauthetification;
            textBoxproxyserver.Text = GlobalVars.config_proxyhost;
            textBoxproxyport.Text = GlobalVars.config_proxyport;
            textBoxproxyusername.Text = GlobalVars.config_proxyuser;
            textBoxproxypassword.Text = GlobalVars.config_proxypass;
            checkBoxdebug.Checked = GlobalVars.config_debug;
            checkBoxfaketemper.Checked = GlobalVars.config_faketemper;
            checkBoxLog.Checked = GlobalVars.config_log;
            checkBoxrebootonerror.Checked = GlobalVars.config_rebootonerror;
            
            //LangFile
            listBoxLangFile.Items.AddRange(MultiLang.getLangFiles());
            for (int i = 0; i < listBoxLangFile.Items.Count; i++)
            {
                if (listBoxLangFile.Items[i].ToString() == GlobalVars.config_langfile)
                {
                    listBoxLangFile.SelectedIndex = i;
                }
            }
            
            //TEMPer
            checkBoxTEMPerAutoDetect.Checked = GlobalVars.config_temperautodetect;
            numericUpDownTempCorrection.Value = Convert.ToDecimal(GlobalVars.config_calibration_temp);
            numericUpDownHumidityCorrection.Value = Convert.ToDecimal(GlobalVars.config_calibration_humidity);
            
            comboBoxCOMPorts.Items.Clear();
            comboBoxCOMPorts.Items.AddRange(TEMPerInterface.FindDevices(this.Handle));
            for (int i = 0; i < comboBoxCOMPorts.Items.Count; i++)
            {
                if (comboBoxCOMPorts.Items[i].ToString() == GlobalVars.config_comport)
                {
                    comboBoxCOMPorts.SelectedIndex = i;
                }
            }

            textBoxTempCalO1.Text = GlobalVars.config_tempcalo1.ToString();
            textBoxTempCalO2.Text = GlobalVars.config_tempcalo2.ToString();
            textBoxTempCalO3.Text = GlobalVars.config_tempcalo3.ToString();
            textBoxTempCalO4.Text = GlobalVars.config_tempcalo4.ToString();

            textBoxTempCalS1.Text = GlobalVars.config_tempcals1.ToString();
            textBoxTempCalS2.Text = GlobalVars.config_tempcals2.ToString();
            textBoxTempCalS3.Text = GlobalVars.config_tempcals3.ToString();
            textBoxTempCalS4.Text = GlobalVars.config_tempcals4.ToString();

            textBoxHumCalO1.Text = GlobalVars.config_humcalo1.ToString();
            textBoxHumCalO2.Text = GlobalVars.config_humcalo2.ToString();
            textBoxHumCalO3.Text = GlobalVars.config_humcalo3.ToString();
            textBoxHumCalO4.Text = GlobalVars.config_humcalo4.ToString();

            textBoxHumCalS1.Text = GlobalVars.config_humcals1.ToString();
            textBoxHumCalS2.Text = GlobalVars.config_humcals2.ToString();
            textBoxHumCalS3.Text = GlobalVars.config_humcals3.ToString();
            textBoxHumCalS4.Text = GlobalVars.config_humcals4.ToString();

            //General
            checkBoxAutoStart.Checked = GlobalVars.config_autostart;
            checkBoxStartMinimized.Checked = GlobalVars.config_startminimized;
            
            //Alert System
            numericUpDownTempMax1.Value = Convert.ToDecimal(GlobalVars.config_alert_tempmax1);
            numericUpDownTempMin1.Value = Convert.ToDecimal(GlobalVars.config_alert_tempmin1);
            numericUpDownHumMax1.Value = Convert.ToDecimal(GlobalVars.config_alert_hummax1);
            numericUpDownHumMin1.Value = Convert.ToDecimal(GlobalVars.config_alert_hummin1);
            checkBoxHumAlertEMailNotify1.Checked = GlobalVars.config_alert_humemail1;
            checkBoxHumAlertOnscreenNotify1.Checked = GlobalVars.config_alert_humonscreen1;
            checkBoxTempAlertEMailNotify1.Checked = GlobalVars.config_alert_tempemail1;
            checkBoxTempAlertOnscreenNotify1.Checked = GlobalVars.config_alert_temponscreen1;

            numericUpDownTempMax2.Value = Convert.ToDecimal(GlobalVars.config_alert_tempmax2);
            numericUpDownTempMin2.Value = Convert.ToDecimal(GlobalVars.config_alert_tempmin2);
            numericUpDownHumMax2.Value = Convert.ToDecimal(GlobalVars.config_alert_hummax2);
            numericUpDownHumMin2.Value = Convert.ToDecimal(GlobalVars.config_alert_hummin2);
            checkBoxHumAlertEMailNotify2.Checked = GlobalVars.config_alert_humemail2;
            checkBoxHumAlertOnscreenNotify2.Checked = GlobalVars.config_alert_humonscreen2;
            checkBoxTempAlertEMailNotify2.Checked = GlobalVars.config_alert_tempemail2;
            checkBoxTempAlertOnscreenNotify2.Checked = GlobalVars.config_alert_temponscreen2;

            numericUpDownTempMax3.Value = Convert.ToDecimal(GlobalVars.config_alert_tempmax3);
            numericUpDownTempMin3.Value = Convert.ToDecimal(GlobalVars.config_alert_tempmin3);
            numericUpDownHumMax3.Value = Convert.ToDecimal(GlobalVars.config_alert_hummax3);
            numericUpDownHumMin3.Value = Convert.ToDecimal(GlobalVars.config_alert_hummin3);
            checkBoxHumAlertEMailNotify3.Checked = GlobalVars.config_alert_humemail3;
            checkBoxHumAlertOnscreenNotify3.Checked = GlobalVars.config_alert_humonscreen3;
            checkBoxTempAlertEMailNotify3.Checked = GlobalVars.config_alert_tempemail3;
            checkBoxTempAlertOnscreenNotify3.Checked = GlobalVars.config_alert_temponscreen3;

            numericUpDownTempMax4.Value = Convert.ToDecimal(GlobalVars.config_alert_tempmax4);
            numericUpDownTempMin4.Value = Convert.ToDecimal(GlobalVars.config_alert_tempmin4);
            numericUpDownHumMax4.Value = Convert.ToDecimal(GlobalVars.config_alert_hummax4);
            numericUpDownHumMin4.Value = Convert.ToDecimal(GlobalVars.config_alert_hummin4);
            checkBoxHumAlertEMailNotify4.Checked = GlobalVars.config_alert_humemail4;
            checkBoxHumAlertOnscreenNotify4.Checked = GlobalVars.config_alert_humonscreen4;
            checkBoxTempAlertEMailNotify4.Checked = GlobalVars.config_alert_tempemail4;
            checkBoxTempAlertOnscreenNotify4.Checked = GlobalVars.config_alert_temponscreen4;

        }
        
        void SaveConfig()
        {
            //Output Timer
            GlobalVars.config_celsius = radioCelsius.Checked;
            GlobalVars.config_fahrenheit = radioFahrenheit.Checked;
            GlobalVars.config_list = checkboxlist.Checked;
            GlobalVars.config_listitems = Convert.ToInt32(numericUpDownlistItems.Value);
            GlobalVars.config_timer = checkboxtimer.Checked;
            GlobalVars.config_timercount = Convert.ToInt32(timercount.Value);

            //Graph
            GlobalVars.config_graph = checkboxgraph.Checked;
            GlobalVars.config_graph_auto = checkBoxAutoSizeGraph.Checked;
            GlobalVars.config_graph_max = Convert.ToDouble(numericUpDownGraphScaleMax.Value);
            GlobalVars.config_graph_min = Convert.ToDouble(numericUpDownGraphScaleMin.Value);

            GlobalVars.config_devicename1 = textBoxDeviceName1.Text;
            GlobalVars.config_devicename2 = textBoxDeviceName2.Text;
            GlobalVars.config_devicename3 = textBoxDeviceName3.Text;
            GlobalVars.config_devicename4 = textBoxDeviceName4.Text;

            //File Recording
            GlobalVars.config_recordtofile = checkboxrecordtofile.Checked;
            GlobalVars.config_dailyfiles = checkboxdailyfiles.Checked;
            GlobalVars.config_csv = radioCSV.Checked;
            GlobalVars.config_txt = radioTXT.Checked;
            GlobalVars.config_filepath = textboxpath.Text;

            //FTP Upload
            GlobalVars.config_ftpactive = checkBoxftp.Checked;
            GlobalVars.config_ftpserver = textBox_ftpserver.Text;
            GlobalVars.config_ftpport = textBox_ftpport.Text;
            GlobalVars.config_ftpuser = textBox_ftpuser.Text;
            GlobalVars.config_ftppass = textBox_ftppass.Text;
            GlobalVars.config_ftpuploaddir = textBox_ftpuploaddir.Text;
            GlobalVars.config_ftpuploadgraph = checkBoxFTPUploadGraph.Checked;


            //E-Mail 	
            GlobalVars.config_mail_server = textBoxEmailServer.Text;
            GlobalVars.config_mail_server_port = textBoxEmailPort.Text;
            GlobalVars.config_mail_user = textBoxEmailUsername.Text;
            GlobalVars.config_mail_password = textBoxEmailPassword.Text;
            GlobalVars.config_mail_from = textBoxEmailFromAddress.Text;
            GlobalVars.config_mail_to = textBoxEmailReceipientAddress.Text;

            //Web URL Grabber
            GlobalVars.config_url = textBoxURL.Text;
            GlobalVars.wugid = WUG_ID.Text;
            GlobalVars.wugpw = WUG_PW.Text;
            GlobalVars.config_urlactive = checkBoxURLactivated.Checked;
            GlobalVars.wugactive = WUG_Active.Checked;

            //BuiltIn Webserver
            GlobalVars.config_BIWActivated = checkBoxBIWActivated.Checked;
            GlobalVars.config_BIWPort = Convert.ToInt32(updownBIWPort.Value);
            GlobalVars.config_BIWRefresh = checkBoxBIWEnableRefresh.Checked;

            GlobalVars.config_BIWXMLActivated = checkBoxBIWXMLActivated.Checked;
            GlobalVars.config_BIWXMLPort = Convert.ToInt32(updownBIWXMLPort.Value);
            GlobalVars.config_BIWXMLRefreshOnAccess = checkBoxBIWXMLRefresh.Checked;
            GlobalVars.config_BIWTitle = textBoxBIW.Text;

            //Proxy DEBUG
            GlobalVars.config_proxyactivated = checkBoxproxy.Checked;
            GlobalVars.config_proxyuseauthetification = checkBoxuseauth.Checked;
            GlobalVars.config_proxyhost = textBoxproxyserver.Text;
            GlobalVars.config_proxyport = textBoxproxyport.Text;
            GlobalVars.config_proxyuser = textBoxproxyusername.Text;
            GlobalVars.config_proxypass = textBoxproxypassword.Text;
            GlobalVars.config_debug = checkBoxdebug.Checked;
            GlobalVars.config_faketemper = checkBoxfaketemper.Checked;
            GlobalVars.config_log = checkBoxLog.Checked;
            GlobalVars.config_rebootonerror = checkBoxrebootonerror.Checked;


            //TEMPer
            GlobalVars.config_temperautodetect = checkBoxTEMPerAutoDetect.Checked;
            if (comboBoxCOMPorts.SelectedIndex > -1)
            {
                GlobalVars.config_comport = comboBoxCOMPorts.Items[comboBoxCOMPorts.SelectedIndex].ToString();
            }

            GlobalVars.config_calibration_temp = Convert.ToDouble(numericUpDownTempCorrection.Value);
            GlobalVars.config_calibration_humidity = Convert.ToDouble(numericUpDownHumidityCorrection.Value);

            GlobalVars.config_tempcalo1 = Convert.ToDouble(textBoxTempCalO1.Text);
            GlobalVars.config_tempcalo2 = Convert.ToDouble(textBoxTempCalO2.Text);
            GlobalVars.config_tempcalo3 = Convert.ToDouble(textBoxTempCalO3.Text);
            GlobalVars.config_tempcalo4 = Convert.ToDouble(textBoxTempCalO4.Text);

            GlobalVars.config_tempcals1 = Convert.ToDouble(textBoxTempCalS1.Text);
            GlobalVars.config_tempcals2 = Convert.ToDouble(textBoxTempCalS2.Text);
            GlobalVars.config_tempcals3 = Convert.ToDouble(textBoxTempCalS3.Text);
            GlobalVars.config_tempcals4 = Convert.ToDouble(textBoxTempCalS4.Text);

            GlobalVars.config_humcalo1 = Convert.ToDouble(textBoxHumCalO1.Text);
            GlobalVars.config_humcalo2 = Convert.ToDouble(textBoxHumCalO2.Text);
            GlobalVars.config_humcalo3 = Convert.ToDouble(textBoxHumCalO3.Text);
            GlobalVars.config_humcalo4 = Convert.ToDouble(textBoxHumCalO4.Text);

            GlobalVars.config_humcals1 = Convert.ToDouble(textBoxHumCalS1.Text);
            GlobalVars.config_humcals2 = Convert.ToDouble(textBoxHumCalS2.Text);
            GlobalVars.config_humcals3 = Convert.ToDouble(textBoxHumCalS3.Text);
            GlobalVars.config_humcals4 = Convert.ToDouble(textBoxHumCalS4.Text);

            //LangFile
            GlobalVars.config_langfile = listBoxLangFile.Items[listBoxLangFile.SelectedIndex].ToString();

            //General
            GlobalVars.config_autostart = checkBoxAutoStart.Checked;
            GlobalVars.config_startminimized = checkBoxStartMinimized.Checked;

            //Alert System
            GlobalVars.config_alert_tempmax1 = Convert.ToDouble(numericUpDownTempMax1.Value);
            GlobalVars.config_alert_tempmin1 = Convert.ToDouble(numericUpDownTempMin1.Value);
            GlobalVars.config_alert_hummax1 = Convert.ToDouble(numericUpDownHumMax1.Value);
            GlobalVars.config_alert_hummin1 = Convert.ToDouble(numericUpDownHumMin1.Value);
            GlobalVars.config_alert_humemail1 = checkBoxHumAlertEMailNotify1.Checked;
            GlobalVars.config_alert_humonscreen1 = checkBoxHumAlertOnscreenNotify1.Checked;
            GlobalVars.config_alert_tempemail1 = checkBoxTempAlertEMailNotify1.Checked;
            GlobalVars.config_alert_temponscreen1 = checkBoxTempAlertOnscreenNotify1.Checked;

            GlobalVars.config_alert_tempmax2 = Convert.ToDouble(numericUpDownTempMax2.Value);
            GlobalVars.config_alert_tempmin2 = Convert.ToDouble(numericUpDownTempMin2.Value);
            GlobalVars.config_alert_hummax2 = Convert.ToDouble(numericUpDownHumMax2.Value);
            GlobalVars.config_alert_hummin2 = Convert.ToDouble(numericUpDownHumMin2.Value);
            GlobalVars.config_alert_humemail2 = checkBoxHumAlertEMailNotify2.Checked;
            GlobalVars.config_alert_humonscreen2 = checkBoxHumAlertOnscreenNotify2.Checked;
            GlobalVars.config_alert_tempemail2 = checkBoxTempAlertEMailNotify2.Checked;
            GlobalVars.config_alert_temponscreen2 = checkBoxTempAlertOnscreenNotify2.Checked;

            GlobalVars.config_alert_tempmax3 = Convert.ToDouble(numericUpDownTempMax3.Value);
            GlobalVars.config_alert_tempmin3 = Convert.ToDouble(numericUpDownTempMin3.Value);
            GlobalVars.config_alert_hummax3 = Convert.ToDouble(numericUpDownHumMax3.Value);
            GlobalVars.config_alert_hummin3 = Convert.ToDouble(numericUpDownHumMin3.Value);
            GlobalVars.config_alert_humemail3 = checkBoxHumAlertEMailNotify3.Checked;
            GlobalVars.config_alert_humonscreen3 = checkBoxHumAlertOnscreenNotify3.Checked;
            GlobalVars.config_alert_tempemail3 = checkBoxTempAlertEMailNotify3.Checked;
            GlobalVars.config_alert_temponscreen3 = checkBoxTempAlertOnscreenNotify3.Checked;

            GlobalVars.config_alert_tempmax4 = Convert.ToDouble(numericUpDownTempMax4.Value);
            GlobalVars.config_alert_tempmin4 = Convert.ToDouble(numericUpDownTempMin4.Value);
            GlobalVars.config_alert_hummax4 = Convert.ToDouble(numericUpDownHumMax4.Value);
            GlobalVars.config_alert_hummin4 = Convert.ToDouble(numericUpDownHumMin4.Value);
            GlobalVars.config_alert_humemail4 = checkBoxHumAlertEMailNotify4.Checked;
            GlobalVars.config_alert_humonscreen4 = checkBoxHumAlertOnscreenNotify4.Checked;
            GlobalVars.config_alert_tempemail4 = checkBoxTempAlertEMailNotify4.Checked;
            GlobalVars.config_alert_temponscreen4 = checkBoxTempAlertOnscreenNotify4.Checked;


            Config myconfig = new Config();
            myconfig.SaveConfig();

        }

        void langFileInfoUpdate()
        {
            string[] langFileInfo = MultiLang.getLangFileinfo(listBoxLangFile.SelectedItem.ToString());
            labelLFILanguageVal.Text = langFileInfo[0] + " / " + langFileInfo[1];
            labelLFIVersionVal.Text = langFileInfo[2];
            labelLFIDateVal.Text = langFileInfo[3];
            labelLFIAuthorVal.Text = langFileInfo[4];
            labelLFIAuthormailVal.Text = langFileInfo[5];
            labelLFSIAuthorwwwVal.Text = langFileInfo[6];
        }

        void ListBoxLangFileSelectedIndexChanged(object sender, EventArgs e)
        {
            langFileInfoUpdate();
        }

        void ButtonftptestClick(object sender, EventArgs e)
        {
            SaveConfig();
            bool ftperror = false;
            FtpClient myFtpClient = new FtpClient();
            myFtpClient.Server = GlobalVars.config_ftpserver;
            myFtpClient.Port = Convert.ToInt32(GlobalVars.config_ftpport);
            myFtpClient.Username = GlobalVars.config_ftpuser;
            myFtpClient.Password = GlobalVars.config_ftppass;

            try
            {
                myFtpClient.Login();
            }
            catch (FtpClient.FtpException ex)
            {
                MessageBox.Show(GlobalVars.lang_couldnotlogintoserver + ": " + ex.Message, GlobalVars.lang_ftperror);
                ftperror = true;
            }
            try
            {
                myFtpClient.ChangeDir(GlobalVars.config_ftpuploaddir);
            }
            catch (FtpClient.FtpException ex)
            {
                MessageBox.Show(GlobalVars.lang_couldnotchangedirtouploaddirectory + ": " + ex.Message, GlobalVars.lang_ftperror);
                ftperror = true;
            }
            try
            {
                myFtpClient.Close();
            }
            catch
            {

            }

            if (ftperror == false)
            {
                MessageBox.Show(GlobalVars.lang_ftpsettingssuccessfullytested, GlobalVars.lang_ftpsettingssuccessfullytested);
            }
        }

        void ButtonUrlGrabTestClick(object sender, EventArgs e)
        {
            SaveConfig();
            WebClient Client = new WebClient();

            if (GlobalVars.config_proxyactivated)
            {
                if (GlobalVars.config_proxyuseauthetification)
                {
                    Client.Proxy = new WebProxy(GlobalVars.config_proxyhost, Convert.ToInt32(GlobalVars.config_proxyport));
                    Client.Proxy.Credentials = new NetworkCredential(GlobalVars.config_proxyuser, GlobalVars.config_proxypass);
                }
                else
                {
                    Client.Proxy = new WebProxy(GlobalVars.config_proxyhost, Convert.ToInt32(GlobalVars.config_proxyport));
                }
            }

            Stream strm = null;
            bool urlerror = false;
            try
            {
                strm = Client.OpenRead(GlobalVars.config_url);
            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.Message, GlobalVars.lang_urlerror);
                urlerror = true;
            }

            if (urlerror == false)
            {
                StreamReader osr = new StreamReader(strm);
                string strContent;
                strContent = osr.ReadLine();
                while (osr.ReadLine() != null)
                {
                    strContent += osr.ReadLine() + "\r\n";
                }
                MessageBox.Show(strContent, GlobalVars.lang_urlreturn);
            }
        }

        void ButtonOkClick(object sender, EventArgs e)
        {
            SaveConfig();
            Close();
        }

        void ButtonApplyClick(object sender, EventArgs e)
        {
            SaveConfig();
            MultiLangForm();
        }

        void ButtonCancelClick(object sender, EventArgs e)
        {
            Close();
        }

        void ButtonFolderSelectClick(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                textboxpath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        void progStat()
        {
            comboBoxCOMPorts.Enabled = !checkBoxTEMPerAutoDetect.Checked;

            checkBoxftp.Enabled = checkboxrecordtofile.Checked;
            if (!checkboxrecordtofile.Checked)
            {
                checkBoxftp.Checked = false;
            }

            textboxpath.Enabled = checkboxrecordtofile.Checked;
            groupBoxFileRecordingFormat.Enabled = checkboxrecordtofile.Checked;

            //FTP Settings
            if (checkboxgraph.Checked && checkBoxftp.Checked)
            {
                checkBoxFTPUploadGraph.Enabled = true;
            }
            else
            {
                checkBoxFTPUploadGraph.Enabled = false;
            }
            textBox_ftpserver.Enabled = checkBoxftp.Checked;
            textBox_ftpport.Enabled = checkBoxftp.Checked;
            textBox_ftpuser.Enabled = checkBoxftp.Checked;
            textBox_ftppass.Enabled = checkBoxftp.Checked;
            textBox_ftpuploaddir.Enabled = checkBoxftp.Checked;
            buttonftptest.Enabled = checkBoxftp.Checked;

            //WebURL Grabber
            checkBoxURLactivated.Enabled = !(WUG_Active.Checked);
            if (WUG_Active.Checked) checkBoxURLactivated.Checked = false;
            textBoxURL.Enabled = checkBoxURLactivated.Checked;
            buttonUrlGrabTest.Enabled = checkBoxURLactivated.Checked;
            WUG_ID.Enabled = WUG_Active.Checked;
            WUG_PW.Enabled = WUG_Active.Checked;

            //Proxy
            checkBoxuseauth.Enabled = checkBoxproxy.Checked;
            textBoxproxyserver.Enabled = checkBoxproxy.Checked;
            textBoxproxyport.Enabled = checkBoxproxy.Checked;
            textBoxproxyusername.Enabled = checkBoxproxy.Checked;
            textBoxproxypassword.Enabled = checkBoxproxy.Checked;

            //Graph Scale
            numericUpDownGraphScaleMax.Enabled = !checkBoxAutoSizeGraph.Checked;
            numericUpDownGraphScaleMin.Enabled = !checkBoxAutoSizeGraph.Checked;
        }

        void MultiLangForm()
        {
            this.Text = "UTAC :: " + GlobalVars.lang_settings;
            OutputAndTimerTab.Text = GlobalVars.lang_outputandtimer;
            RecordingTab.Text = GlobalVars.lang_filerecording;
            FTPTab.Text = GlobalVars.lang_ftpupload;
            LanguageTab.Text = GlobalVars.lang_language;
            ProxyTab.Text = GlobalVars.lang_proxy;
            BuiltInWebServerTab.Text = GlobalVars.lang_builtinwebserver;
            WebUrlTab.Text = GlobalVars.lang_weburlgrabber;
            groupBoxOutput.Text = GlobalVars.lang_output;
            groupBoxTimer.Text = GlobalVars.lang_timer;
            radioCelsius.Text = GlobalVars.lang_celsius;
            radioFahrenheit.Text = GlobalVars.lang_fahrenheit;
            checkboxlist.Text = GlobalVars.lang_recordtolist;
            checkboxgraph.Text = GlobalVars.lang_activategraph;
            labelMaxitems.Text = GlobalVars.lang_maxitems;
            checkboxtimer.Text = GlobalVars.lang_activated;
            labelTimerInterval.Text = GlobalVars.lang_interval + ":";
            labelTimerSeconds.Text = GlobalVars.lang_seconds;
            checkBoxTEMPerAutoDetect.Text = GlobalVars.lang_autodetection;
            labelChooseCOMPort.Text = GlobalVars.lang_choosecomport + ":";
            checkboxrecordtofile.Text = GlobalVars.lang_activated;
            checkboxdailyfiles.Text = GlobalVars.lang_generatedailyfiles;
            labelFileRecordingPath.Text = GlobalVars.lang_path + ":";
            groupBoxFileRecordingFormat.Text = GlobalVars.lang_format;
            checkBoxftp.Text = GlobalVars.lang_activated;
            labelFTPServer.Text = GlobalVars.lang_server + ":";
            labelFTPUsername.Text = GlobalVars.lang_username + ":";
            labelFTPPassword.Text = GlobalVars.lang_password + ":";
            labelFTPUploadDir.Text = GlobalVars.lang_uploaddir + ":";
            buttonftptest.Text = GlobalVars.lang_test;
            groupBoxLanguage.Text = GlobalVars.lang_language;
            labelLFILanguage.Text = GlobalVars.lang_language + ":";
            labelLFIDate.Text = GlobalVars.lang_date + ":";
            labelLFIVersion.Text = GlobalVars.lang_version + ":";
            labelLFSIAuthor.Text = GlobalVars.lang_author + ":";
            labelURL.Text = GlobalVars.lang_url + ":";
            checkBoxURLactivated.Text = GlobalVars.lang_activated;
            buttonUrlGrabTest.Text = GlobalVars.lang_test;
            //labelURLText2.Text = GlobalVars.lang_urltext1;
            checkBoxBIWActivated.Text = GlobalVars.lang_activated;
            checkBoxBIWEnableRefresh.Text = GlobalVars.lang_enablemanualrefresh;
            labelBIWPort.Text = GlobalVars.lang_port;
            labelBIWTitle.Text = GlobalVars.lang_title + ":";
            groupBoxBIW.Text = GlobalVars.lang_builtinwebserver;
            groupBoxBIWXML.Text = GlobalVars.lang_builtinxmlwebserver;
            checkBoxBIWXMLActivated.Text = GlobalVars.lang_activated;
            checkBoxBIWXMLRefresh.Text = GlobalVars.lang_refreshtemponaccess;
            labelBIWXMLPort.Text = GlobalVars.lang_port;
            groupBoxProxySettings.Text = GlobalVars.lang_proxysettings;
            checkBoxproxy.Text = GlobalVars.lang_activated;
            checkBoxuseauth.Text = GlobalVars.lang_useauthentification;
            labelProxyServer.Text = GlobalVars.lang_server + ":";
            labelProxyUsername.Text = GlobalVars.lang_username + ":";
            labelProxyPassword.Text = GlobalVars.lang_password + ":";
            groupBoxDebug.Text = GlobalVars.lang_debug;
            checkBoxdebug.Text = GlobalVars.lang_debug;
            checkBoxfaketemper.Text = GlobalVars.lang_faketemper;
            checkBoxLog.Text = GlobalVars.lang_enablelogfile;
            buttonApply.Text = GlobalVars.lang_apply;
            buttonOk.Text = GlobalVars.lang_ok;
            buttonCancel.Text = GlobalVars.lang_cancel;
            checkBoxFTPUploadGraph.Text = GlobalVars.lang_uploadgraph;
            labelCalibrationTemperature.Text = GlobalVars.lang_temperature + ":";
            labelCalibrationHumidity.Text = GlobalVars.lang_humidity + ":";
            groupBoxCalibration.Text = GlobalVars.lang_calibration;
            checkBoxTempAlertEMailNotify1.Text = GlobalVars.lang_emailnotify;
            checkBoxHumAlertEMailNotify1.Text = GlobalVars.lang_emailnotify;
            checkBoxTempAlertOnscreenNotify1.Text = GlobalVars.lang_onscreennotify;
            checkBoxHumAlertOnscreenNotify1.Text = GlobalVars.lang_onscreennotify;
            groupBoxEMailSMTPSettings.Text = GlobalVars.lang_emailsmtpsettings;
            tabPageEMail.Text = GlobalVars.lang_email;
            labelEMailServerPort.Text = GlobalVars.lang_server;
            labelEMailUsername.Text = GlobalVars.lang_username;
            labelEMailPassword.Text = GlobalVars.lang_password;
            labelEMailFromAddress.Text = GlobalVars.lang_fromaddress;
            labelEMailReceipientAddress.Text = GlobalVars.lang_receipientaddress;
            groupBoxUTACStart.Text = GlobalVars.lang_utacstart;
            checkBoxAutoStart.Text = GlobalVars.lang_autostart;
            checkBoxStartMinimized.Text = GlobalVars.lang_startminimized;
            tabPageAlertSystem.Text = GlobalVars.lang_alertsystem;
            checkBoxAutoSizeGraph.Text = GlobalVars.lang_autoscalegraph;
            labelGraphMax.Text = GlobalVars.lang_max + ":";
            labelGraphMin.Text = GlobalVars.lang_min + ":";
            groupBoxGraph.Text = GlobalVars.lang_graph;
            GeneralTab.Text = GlobalVars.lang_general;
            labelFTPRequire.Text = GlobalVars.lang_ftprequirefilerecording;
            buttonEMailTest.Text = GlobalVars.lang_test;

        }


        void NumericUpDown3ValueChanged(object sender, EventArgs e)
        {

        }

        void CheckBoxTEMPerAutoDetectCheckedChanged(object sender, EventArgs e)
        {
            progStat();
        }

        void CheckBoxproxyCheckedChanged(object sender, EventArgs e)
        {
            progStat();
        }

        void CheckboxgraphCheckedChanged(object sender, EventArgs e)
        {
            progStat();
        }

        void CheckBoxftpCheckedChanged(object sender, EventArgs e)
        {
            progStat();
        }

        void CheckBoxFTPUploadGraphCheckedChanged(object sender, EventArgs e)
        {
            progStat();
        }

        void CheckboxrecordtofileCheckedChanged(object sender, EventArgs e)
        {
            progStat();
        }

        void CheckBoxURLactivatedCheckedChanged(object sender, EventArgs e)
        {
            progStat();
        }

        void CheckBoxAutoSizeGraphCheckedChanged(object sender, EventArgs e)
        {
            progStat();
        }

        void ButtonEMailTestClick(object sender, EventArgs e)
        {
            SaveConfig();
            SendMail.Send("UTAC TestMail", "", true);
        }

        void NumericUpDownGraphScaleMaxValueChanged(object sender, EventArgs e)
        {
            numericUpDownGraphScaleMax.Minimum = numericUpDownGraphScaleMin.Value + 1;
            numericUpDownGraphScaleMin.Maximum = numericUpDownGraphScaleMax.Value - 1;
        }

        void NumericUpDownGraphScaleMinValueChanged(object sender, EventArgs e)
        {
            numericUpDownGraphScaleMax.Minimum = numericUpDownGraphScaleMin.Value + 1;
            numericUpDownGraphScaleMin.Maximum = numericUpDownGraphScaleMax.Value - 1;
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void WUG_Active_CheckedChanged(object sender, EventArgs e)
        {
            progStat();
        }
    }
}
