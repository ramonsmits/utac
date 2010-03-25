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
 * FileName: 	SettingsForm.Designer.cs
 * Namespace: 	utac
 * Author: 		bof (bjoern@n4rf.de)
 * Created: 	2008-02-01
 * -----------------------------------------------------------------------
 * -------------------------------------------------------- Description *-
 * ------------------------------------------------------------------------
 * Settingsform automated Designer Class
 */
 
namespace utac
{
	partial class advancedsettings
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(advancedsettings));
            this.checkBoxHumAlertOnscreenNotify1 = new System.Windows.Forms.CheckBox();
            this.checkBoxHumAlertOnscreenNotify2 = new System.Windows.Forms.CheckBox();
            this.numericUpDownTempMin2 = new System.Windows.Forms.NumericUpDown();
            this.checkBoxHumAlertOnscreenNotify3 = new System.Windows.Forms.CheckBox();
            this.checkBoxHumAlertOnscreenNotify4 = new System.Windows.Forms.CheckBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.CalTab = new System.Windows.Forms.TabControl();
            this.GeneralTab = new System.Windows.Forms.TabPage();
            this.groupBoxCalibration = new System.Windows.Forms.GroupBox();
            this.labelCalibrationHumidity = new System.Windows.Forms.Label();
            this.labelCalibrationTemperature = new System.Windows.Forms.Label();
            this.numericUpDownHumidityCorrection = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownTempCorrection = new System.Windows.Forms.NumericUpDown();
            this.groupBoxComPort = new System.Windows.Forms.GroupBox();
            this.checkBoxTEMPerAutoDetect = new System.Windows.Forms.CheckBox();
            this.labelChooseCOMPort = new System.Windows.Forms.Label();
            this.comboBoxCOMPorts = new System.Windows.Forms.ComboBox();
            this.groupBoxDebug = new System.Windows.Forms.GroupBox();
            this.checkBoxrebootonerror = new System.Windows.Forms.CheckBox();
            this.checkBoxLog = new System.Windows.Forms.CheckBox();
            this.checkBoxfaketemper = new System.Windows.Forms.CheckBox();
            this.checkBoxdebug = new System.Windows.Forms.CheckBox();
            this.groupBoxUTACStart = new System.Windows.Forms.GroupBox();
            this.checkBoxStartMinimized = new System.Windows.Forms.CheckBox();
            this.checkBoxAutoStart = new System.Windows.Forms.CheckBox();
            this.OutputAndTimerTab = new System.Windows.Forms.TabPage();
            this.groupBoxGraph = new System.Windows.Forms.GroupBox();
            this.labelGraphMin = new System.Windows.Forms.Label();
            this.checkBoxAutoSizeGraph = new System.Windows.Forms.CheckBox();
            this.labelGraphMax = new System.Windows.Forms.Label();
            this.numericUpDownGraphScaleMax = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownGraphScaleMin = new System.Windows.Forms.NumericUpDown();
            this.checkboxgraph = new System.Windows.Forms.CheckBox();
            this.groupBoxAverageSystem = new System.Windows.Forms.GroupBox();
            this.labelAverageInterval = new System.Windows.Forms.Label();
            this.comboBoxAverageType = new System.Windows.Forms.ComboBox();
            this.checkBoxAverageGraph = new System.Windows.Forms.CheckBox();
            this.checkBoxAverageList = new System.Windows.Forms.CheckBox();
            this.numericUpDownAverageInterval = new System.Windows.Forms.NumericUpDown();
            this.groupBoxOutput = new System.Windows.Forms.GroupBox();
            this.labelMaxitems = new System.Windows.Forms.Label();
            this.numericUpDownlistItems = new System.Windows.Forms.NumericUpDown();
            this.checkboxlist = new System.Windows.Forms.CheckBox();
            this.radioFahrenheit = new System.Windows.Forms.RadioButton();
            this.radioCelsius = new System.Windows.Forms.RadioButton();
            this.groupBoxTimer = new System.Windows.Forms.GroupBox();
            this.labelTimerSeconds = new System.Windows.Forms.Label();
            this.checkboxtimer = new System.Windows.Forms.CheckBox();
            this.labelTimerInterval = new System.Windows.Forms.Label();
            this.timercount = new System.Windows.Forms.NumericUpDown();
            this.RecordingTab = new System.Windows.Forms.TabPage();
            this.textboxpath = new System.Windows.Forms.TextBox();
            this.groupBoxFileRecordingFormat = new System.Windows.Forms.GroupBox();
            this.radioTXT = new System.Windows.Forms.RadioButton();
            this.radioCSV = new System.Windows.Forms.RadioButton();
            this.labelFileRecordingPath = new System.Windows.Forms.Label();
            this.buttonFolderSelect = new System.Windows.Forms.Button();
            this.checkboxdailyfiles = new System.Windows.Forms.CheckBox();
            this.checkboxrecordtofile = new System.Windows.Forms.CheckBox();
            this.FTPTab = new System.Windows.Forms.TabPage();
            this.labelFTPRequire = new System.Windows.Forms.Label();
            this.checkBoxFTPUploadGraph = new System.Windows.Forms.CheckBox();
            this.textBox_ftpport = new System.Windows.Forms.TextBox();
            this.textBox_ftpuploaddir = new System.Windows.Forms.TextBox();
            this.labelFTPUploadDir = new System.Windows.Forms.Label();
            this.buttonftptest = new System.Windows.Forms.Button();
            this.checkBoxftp = new System.Windows.Forms.CheckBox();
            this.labelFTPUsername = new System.Windows.Forms.Label();
            this.labelFTPPassword = new System.Windows.Forms.Label();
            this.labelFTPServer = new System.Windows.Forms.Label();
            this.textBox_ftppass = new System.Windows.Forms.TextBox();
            this.textBox_ftpuser = new System.Windows.Forms.TextBox();
            this.textBox_ftpserver = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.WebUrlTab = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label22 = new System.Windows.Forms.Label();
            this.WUG_Active = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.WUG_PW = new System.Windows.Forms.TextBox();
            this.WUG_ID = new System.Windows.Forms.TextBox();
            this.labelURL = new System.Windows.Forms.Label();
            this.buttonUrlGrabTest = new System.Windows.Forms.Button();
            this.labelURLText2 = new System.Windows.Forms.Label();
            this.checkBoxURLactivated = new System.Windows.Forms.CheckBox();
            this.textBoxURL = new System.Windows.Forms.TextBox();
            this.BuiltInWebServerTab = new System.Windows.Forms.TabPage();
            this.groupBoxBIWXML = new System.Windows.Forms.GroupBox();
            this.checkBoxBIWXMLRefresh = new System.Windows.Forms.CheckBox();
            this.checkBoxBIWXMLActivated = new System.Windows.Forms.CheckBox();
            this.labelBIWXMLPort = new System.Windows.Forms.Label();
            this.updownBIWXMLPort = new System.Windows.Forms.NumericUpDown();
            this.groupBoxBIW = new System.Windows.Forms.GroupBox();
            this.checkBoxBIWEnableRefresh = new System.Windows.Forms.CheckBox();
            this.checkBoxBIWActivated = new System.Windows.Forms.CheckBox();
            this.labelBIWPort = new System.Windows.Forms.Label();
            this.textBoxBIW = new System.Windows.Forms.TextBox();
            this.updownBIWPort = new System.Windows.Forms.NumericUpDown();
            this.labelBIWTitle = new System.Windows.Forms.Label();
            this.ProxyTab = new System.Windows.Forms.TabPage();
            this.groupBoxProxySettings = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxuseauth = new System.Windows.Forms.CheckBox();
            this.textBoxproxypassword = new System.Windows.Forms.TextBox();
            this.checkBoxproxy = new System.Windows.Forms.CheckBox();
            this.textBoxproxyusername = new System.Windows.Forms.TextBox();
            this.textBoxproxyport = new System.Windows.Forms.TextBox();
            this.textBoxproxyserver = new System.Windows.Forms.TextBox();
            this.labelProxyPassword = new System.Windows.Forms.Label();
            this.labelProxyUsername = new System.Windows.Forms.Label();
            this.labelProxyServer = new System.Windows.Forms.Label();
            this.LanguageTab = new System.Windows.Forms.TabPage();
            this.listBoxLangFile = new System.Windows.Forms.ListBox();
            this.groupBoxLanguage = new System.Windows.Forms.GroupBox();
            this.labelLFIVersionVal = new System.Windows.Forms.Label();
            this.labelLFILanguageVal = new System.Windows.Forms.Label();
            this.labelLFIDateVal = new System.Windows.Forms.Label();
            this.labelLFIAuthormailVal = new System.Windows.Forms.Label();
            this.labelLFSIAuthorwwwVal = new System.Windows.Forms.Label();
            this.labelLFIAuthorVal = new System.Windows.Forms.Label();
            this.labelLFIDate = new System.Windows.Forms.Label();
            this.labelLFIVersion = new System.Windows.Forms.Label();
            this.labelLFSIAuthor = new System.Windows.Forms.Label();
            this.labelLFILanguage = new System.Windows.Forms.Label();
            this.tabPageAlertSystem = new System.Windows.Forms.TabPage();
            this.label30 = new System.Windows.Forms.Label();
            this.checkBoxTempAlertOnscreenNotify4 = new System.Windows.Forms.CheckBox();
            this.checkBoxHumAlertEMailNotify4 = new System.Windows.Forms.CheckBox();
            this.checkBoxTempAlertEMailNotify4 = new System.Windows.Forms.CheckBox();
            this.numericUpDownTempMin4 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownTempMax4 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownHumMin4 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownHumMax4 = new System.Windows.Forms.NumericUpDown();
            this.label29 = new System.Windows.Forms.Label();
            this.checkBoxTempAlertOnscreenNotify3 = new System.Windows.Forms.CheckBox();
            this.checkBoxHumAlertEMailNotify3 = new System.Windows.Forms.CheckBox();
            this.checkBoxTempAlertEMailNotify3 = new System.Windows.Forms.CheckBox();
            this.numericUpDownTempMin3 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownTempMax3 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownHumMin3 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownHumMax3 = new System.Windows.Forms.NumericUpDown();
            this.label28 = new System.Windows.Forms.Label();
            this.checkBoxTempAlertOnscreenNotify2 = new System.Windows.Forms.CheckBox();
            this.checkBoxHumAlertEMailNotify2 = new System.Windows.Forms.CheckBox();
            this.checkBoxTempAlertEMailNotify2 = new System.Windows.Forms.CheckBox();
            this.numericUpDownTempMax2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownHumMin2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownHumMax2 = new System.Windows.Forms.NumericUpDown();
            this.label27 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.checkBoxTempAlertOnscreenNotify1 = new System.Windows.Forms.CheckBox();
            this.checkBoxHumAlertEMailNotify1 = new System.Windows.Forms.CheckBox();
            this.checkBoxTempAlertEMailNotify1 = new System.Windows.Forms.CheckBox();
            this.numericUpDownTempMin1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownTempMax1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownHumMin1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownHumMax1 = new System.Windows.Forms.NumericUpDown();
            this.tabPageEMail = new System.Windows.Forms.TabPage();
            this.groupBoxEMailSMTPSettings = new System.Windows.Forms.GroupBox();
            this.buttonEMailTest = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.labelEMailReceipientAddress = new System.Windows.Forms.Label();
            this.labelEMailFromAddress = new System.Windows.Forms.Label();
            this.labelEMailPassword = new System.Windows.Forms.Label();
            this.labelEMailUsername = new System.Windows.Forms.Label();
            this.labelEMailServerPort = new System.Windows.Forms.Label();
            this.textBoxEmailReceipientAddress = new System.Windows.Forms.TextBox();
            this.textBoxEmailFromAddress = new System.Windows.Forms.TextBox();
            this.textBoxEmailPassword = new System.Windows.Forms.TextBox();
            this.textBoxEmailUsername = new System.Windows.Forms.TextBox();
            this.textBoxEmailPort = new System.Windows.Forms.TextBox();
            this.textBoxEmailServer = new System.Windows.Forms.TextBox();
            this.tabGraphing = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxDeviceName4 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxDeviceName3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxDeviceName2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxDeviceName1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CalTabPage = new System.Windows.Forms.TabPage();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxHumCalS4 = new System.Windows.Forms.TextBox();
            this.textBoxHumCalO4 = new System.Windows.Forms.TextBox();
            this.textBoxTempCalS4 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxTempCalO4 = new System.Windows.Forms.TextBox();
            this.textBoxHumCalS3 = new System.Windows.Forms.TextBox();
            this.textBoxHumCalO3 = new System.Windows.Forms.TextBox();
            this.textBoxTempCalS3 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxTempCalO3 = new System.Windows.Forms.TextBox();
            this.textBoxHumCalS2 = new System.Windows.Forms.TextBox();
            this.textBoxHumCalO2 = new System.Windows.Forms.TextBox();
            this.textBoxTempCalS2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxTempCalO2 = new System.Windows.Forms.TextBox();
            this.textBoxHumCalS1 = new System.Windows.Forms.TextBox();
            this.textBoxHumCalO1 = new System.Windows.Forms.TextBox();
            this.textBoxTempCalS1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxTempCalO1 = new System.Windows.Forms.TextBox();
            this.buttonApply = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTempMin2)).BeginInit();
            this.CalTab.SuspendLayout();
            this.GeneralTab.SuspendLayout();
            this.groupBoxCalibration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHumidityCorrection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTempCorrection)).BeginInit();
            this.groupBoxComPort.SuspendLayout();
            this.groupBoxDebug.SuspendLayout();
            this.groupBoxUTACStart.SuspendLayout();
            this.OutputAndTimerTab.SuspendLayout();
            this.groupBoxGraph.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGraphScaleMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGraphScaleMin)).BeginInit();
            this.groupBoxAverageSystem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAverageInterval)).BeginInit();
            this.groupBoxOutput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownlistItems)).BeginInit();
            this.groupBoxTimer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timercount)).BeginInit();
            this.RecordingTab.SuspendLayout();
            this.groupBoxFileRecordingFormat.SuspendLayout();
            this.FTPTab.SuspendLayout();
            this.WebUrlTab.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.BuiltInWebServerTab.SuspendLayout();
            this.groupBoxBIWXML.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updownBIWXMLPort)).BeginInit();
            this.groupBoxBIW.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updownBIWPort)).BeginInit();
            this.ProxyTab.SuspendLayout();
            this.groupBoxProxySettings.SuspendLayout();
            this.LanguageTab.SuspendLayout();
            this.groupBoxLanguage.SuspendLayout();
            this.tabPageAlertSystem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTempMin4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTempMax4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHumMin4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHumMax4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTempMin3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTempMax3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHumMin3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHumMax3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTempMax2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHumMin2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHumMax2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTempMin1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTempMax1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHumMin1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHumMax1)).BeginInit();
            this.tabPageEMail.SuspendLayout();
            this.groupBoxEMailSMTPSettings.SuspendLayout();
            this.tabGraphing.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.CalTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxHumAlertOnscreenNotify1
            // 
            this.checkBoxHumAlertOnscreenNotify1.Location = new System.Drawing.Point(331, 39);
            this.checkBoxHumAlertOnscreenNotify1.Name = "checkBoxHumAlertOnscreenNotify1";
            this.checkBoxHumAlertOnscreenNotify1.Size = new System.Drawing.Size(78, 24);
            this.checkBoxHumAlertOnscreenNotify1.TabIndex = 44;
            this.checkBoxHumAlertOnscreenNotify1.Text = "On Screen";
            this.checkBoxHumAlertOnscreenNotify1.UseVisualStyleBackColor = true;
            // 
            // checkBoxHumAlertOnscreenNotify2
            // 
            this.checkBoxHumAlertOnscreenNotify2.Location = new System.Drawing.Point(331, 85);
            this.checkBoxHumAlertOnscreenNotify2.Name = "checkBoxHumAlertOnscreenNotify2";
            this.checkBoxHumAlertOnscreenNotify2.Size = new System.Drawing.Size(78, 24);
            this.checkBoxHumAlertOnscreenNotify2.TabIndex = 71;
            this.checkBoxHumAlertOnscreenNotify2.Text = "On Screen";
            this.checkBoxHumAlertOnscreenNotify2.UseVisualStyleBackColor = true;
            // 
            // numericUpDownTempMin2
            // 
            this.numericUpDownTempMin2.DecimalPlaces = 2;
            this.numericUpDownTempMin2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownTempMin2.Location = new System.Drawing.Point(103, 69);
            this.numericUpDownTempMin2.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownTempMin2.Name = "numericUpDownTempMin2";
            this.numericUpDownTempMin2.Size = new System.Drawing.Size(68, 20);
            this.numericUpDownTempMin2.TabIndex = 67;
            // 
            // checkBoxHumAlertOnscreenNotify3
            // 
            this.checkBoxHumAlertOnscreenNotify3.Location = new System.Drawing.Point(331, 131);
            this.checkBoxHumAlertOnscreenNotify3.Name = "checkBoxHumAlertOnscreenNotify3";
            this.checkBoxHumAlertOnscreenNotify3.Size = new System.Drawing.Size(78, 24);
            this.checkBoxHumAlertOnscreenNotify3.TabIndex = 84;
            this.checkBoxHumAlertOnscreenNotify3.Text = "On Screen";
            this.checkBoxHumAlertOnscreenNotify3.UseVisualStyleBackColor = true;
            // 
            // checkBoxHumAlertOnscreenNotify4
            // 
            this.checkBoxHumAlertOnscreenNotify4.Location = new System.Drawing.Point(331, 177);
            this.checkBoxHumAlertOnscreenNotify4.Name = "checkBoxHumAlertOnscreenNotify4";
            this.checkBoxHumAlertOnscreenNotify4.Size = new System.Drawing.Size(78, 24);
            this.checkBoxHumAlertOnscreenNotify4.TabIndex = 93;
            this.checkBoxHumAlertOnscreenNotify4.Text = "On Screen";
            this.checkBoxHumAlertOnscreenNotify4.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Location = new System.Drawing.Point(110, 262);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(89, 23);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.ButtonOkClick);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(314, 262);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(102, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
            // 
            // CalTab
            // 
            this.CalTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.CalTab.Controls.Add(this.GeneralTab);
            this.CalTab.Controls.Add(this.OutputAndTimerTab);
            this.CalTab.Controls.Add(this.RecordingTab);
            this.CalTab.Controls.Add(this.FTPTab);
            this.CalTab.Controls.Add(this.WebUrlTab);
            this.CalTab.Controls.Add(this.BuiltInWebServerTab);
            this.CalTab.Controls.Add(this.ProxyTab);
            this.CalTab.Controls.Add(this.LanguageTab);
            this.CalTab.Controls.Add(this.tabPageAlertSystem);
            this.CalTab.Controls.Add(this.tabPageEMail);
            this.CalTab.Controls.Add(this.tabGraphing);
            this.CalTab.Controls.Add(this.CalTabPage);
            this.CalTab.Location = new System.Drawing.Point(3, 5);
            this.CalTab.Multiline = true;
            this.CalTab.Name = "CalTab";
            this.CalTab.SelectedIndex = 0;
            this.CalTab.Size = new System.Drawing.Size(417, 251);
            this.CalTab.TabIndex = 0;
            // 
            // GeneralTab
            // 
            this.GeneralTab.Controls.Add(this.groupBoxCalibration);
            this.GeneralTab.Controls.Add(this.groupBoxComPort);
            this.GeneralTab.Controls.Add(this.groupBoxDebug);
            this.GeneralTab.Controls.Add(this.groupBoxUTACStart);
            this.GeneralTab.Location = new System.Drawing.Point(4, 40);
            this.GeneralTab.Name = "GeneralTab";
            this.GeneralTab.Padding = new System.Windows.Forms.Padding(3);
            this.GeneralTab.Size = new System.Drawing.Size(409, 207);
            this.GeneralTab.TabIndex = 9;
            this.GeneralTab.Text = "General";
            this.GeneralTab.UseVisualStyleBackColor = true;
            // 
            // groupBoxCalibration
            // 
            this.groupBoxCalibration.Controls.Add(this.labelCalibrationHumidity);
            this.groupBoxCalibration.Controls.Add(this.labelCalibrationTemperature);
            this.groupBoxCalibration.Controls.Add(this.numericUpDownHumidityCorrection);
            this.groupBoxCalibration.Controls.Add(this.numericUpDownTempCorrection);
            this.groupBoxCalibration.Location = new System.Drawing.Point(215, 102);
            this.groupBoxCalibration.Name = "groupBoxCalibration";
            this.groupBoxCalibration.Size = new System.Drawing.Size(188, 68);
            this.groupBoxCalibration.TabIndex = 38;
            this.groupBoxCalibration.TabStop = false;
            this.groupBoxCalibration.Text = "Global Calibration Offset";
            // 
            // labelCalibrationHumidity
            // 
            this.labelCalibrationHumidity.Location = new System.Drawing.Point(5, 42);
            this.labelCalibrationHumidity.Name = "labelCalibrationHumidity";
            this.labelCalibrationHumidity.Size = new System.Drawing.Size(59, 18);
            this.labelCalibrationHumidity.TabIndex = 36;
            this.labelCalibrationHumidity.Text = "Humidity:";
            // 
            // labelCalibrationTemperature
            // 
            this.labelCalibrationTemperature.Location = new System.Drawing.Point(5, 20);
            this.labelCalibrationTemperature.Name = "labelCalibrationTemperature";
            this.labelCalibrationTemperature.Size = new System.Drawing.Size(85, 18);
            this.labelCalibrationTemperature.TabIndex = 35;
            this.labelCalibrationTemperature.Text = "Temperature:";
            // 
            // numericUpDownHumidityCorrection
            // 
            this.numericUpDownHumidityCorrection.DecimalPlaces = 2;
            this.numericUpDownHumidityCorrection.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownHumidityCorrection.Location = new System.Drawing.Point(94, 40);
            this.numericUpDownHumidityCorrection.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownHumidityCorrection.Name = "numericUpDownHumidityCorrection";
            this.numericUpDownHumidityCorrection.Size = new System.Drawing.Size(68, 20);
            this.numericUpDownHumidityCorrection.TabIndex = 1;
            // 
            // numericUpDownTempCorrection
            // 
            this.numericUpDownTempCorrection.DecimalPlaces = 2;
            this.numericUpDownTempCorrection.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownTempCorrection.Location = new System.Drawing.Point(94, 18);
            this.numericUpDownTempCorrection.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownTempCorrection.Name = "numericUpDownTempCorrection";
            this.numericUpDownTempCorrection.Size = new System.Drawing.Size(68, 20);
            this.numericUpDownTempCorrection.TabIndex = 0;
            // 
            // groupBoxComPort
            // 
            this.groupBoxComPort.Controls.Add(this.checkBoxTEMPerAutoDetect);
            this.groupBoxComPort.Controls.Add(this.labelChooseCOMPort);
            this.groupBoxComPort.Controls.Add(this.comboBoxCOMPorts);
            this.groupBoxComPort.Location = new System.Drawing.Point(215, 6);
            this.groupBoxComPort.Name = "groupBoxComPort";
            this.groupBoxComPort.Size = new System.Drawing.Size(188, 90);
            this.groupBoxComPort.TabIndex = 37;
            this.groupBoxComPort.TabStop = false;
            this.groupBoxComPort.Text = "TEMPer COM Port";
            // 
            // checkBoxTEMPerAutoDetect
            // 
            this.checkBoxTEMPerAutoDetect.Location = new System.Drawing.Point(12, 19);
            this.checkBoxTEMPerAutoDetect.Name = "checkBoxTEMPerAutoDetect";
            this.checkBoxTEMPerAutoDetect.Size = new System.Drawing.Size(104, 24);
            this.checkBoxTEMPerAutoDetect.TabIndex = 2;
            this.checkBoxTEMPerAutoDetect.Text = "Auto Detect";
            this.checkBoxTEMPerAutoDetect.UseVisualStyleBackColor = true;
            this.checkBoxTEMPerAutoDetect.CheckedChanged += new System.EventHandler(this.CheckBoxTEMPerAutoDetectCheckedChanged);
            // 
            // labelChooseCOMPort
            // 
            this.labelChooseCOMPort.Location = new System.Drawing.Point(9, 43);
            this.labelChooseCOMPort.Name = "labelChooseCOMPort";
            this.labelChooseCOMPort.Size = new System.Drawing.Size(121, 18);
            this.labelChooseCOMPort.TabIndex = 34;
            this.labelChooseCOMPort.Text = "Choose Comport:";
            // 
            // comboBoxCOMPorts
            // 
            this.comboBoxCOMPorts.FormattingEnabled = true;
            this.comboBoxCOMPorts.Location = new System.Drawing.Point(12, 61);
            this.comboBoxCOMPorts.Name = "comboBoxCOMPorts";
            this.comboBoxCOMPorts.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCOMPorts.TabIndex = 3;
            // 
            // groupBoxDebug
            // 
            this.groupBoxDebug.Controls.Add(this.checkBoxrebootonerror);
            this.groupBoxDebug.Controls.Add(this.checkBoxLog);
            this.groupBoxDebug.Controls.Add(this.checkBoxfaketemper);
            this.groupBoxDebug.Controls.Add(this.checkBoxdebug);
            this.groupBoxDebug.Location = new System.Drawing.Point(6, 77);
            this.groupBoxDebug.Name = "groupBoxDebug";
            this.groupBoxDebug.Size = new System.Drawing.Size(203, 93);
            this.groupBoxDebug.TabIndex = 5;
            this.groupBoxDebug.TabStop = false;
            this.groupBoxDebug.Text = "Debug";
            // 
            // checkBoxrebootonerror
            // 
            this.checkBoxrebootonerror.Location = new System.Drawing.Point(10, 61);
            this.checkBoxrebootonerror.Name = "checkBoxrebootonerror";
            this.checkBoxrebootonerror.Size = new System.Drawing.Size(180, 24);
            this.checkBoxrebootonerror.TabIndex = 3;
            this.checkBoxrebootonerror.Text = "Reboot on Error";
            this.checkBoxrebootonerror.UseVisualStyleBackColor = true;
            // 
            // checkBoxLog
            // 
            this.checkBoxLog.Location = new System.Drawing.Point(110, 19);
            this.checkBoxLog.Name = "checkBoxLog";
            this.checkBoxLog.Size = new System.Drawing.Size(80, 24);
            this.checkBoxLog.TabIndex = 2;
            this.checkBoxLog.Text = "Make Log";
            this.checkBoxLog.UseVisualStyleBackColor = true;
            // 
            // checkBoxfaketemper
            // 
            this.checkBoxfaketemper.Location = new System.Drawing.Point(10, 40);
            this.checkBoxfaketemper.Name = "checkBoxfaketemper";
            this.checkBoxfaketemper.Size = new System.Drawing.Size(180, 24);
            this.checkBoxfaketemper.TabIndex = 1;
            this.checkBoxfaketemper.Text = "Emulate TEMPer";
            this.checkBoxfaketemper.UseVisualStyleBackColor = true;
            // 
            // checkBoxdebug
            // 
            this.checkBoxdebug.Location = new System.Drawing.Point(10, 19);
            this.checkBoxdebug.Name = "checkBoxdebug";
            this.checkBoxdebug.Size = new System.Drawing.Size(180, 24);
            this.checkBoxdebug.TabIndex = 0;
            this.checkBoxdebug.Text = "Activated";
            this.checkBoxdebug.UseVisualStyleBackColor = true;
            // 
            // groupBoxUTACStart
            // 
            this.groupBoxUTACStart.Controls.Add(this.checkBoxStartMinimized);
            this.groupBoxUTACStart.Controls.Add(this.checkBoxAutoStart);
            this.groupBoxUTACStart.Location = new System.Drawing.Point(6, 6);
            this.groupBoxUTACStart.Name = "groupBoxUTACStart";
            this.groupBoxUTACStart.Size = new System.Drawing.Size(203, 65);
            this.groupBoxUTACStart.TabIndex = 4;
            this.groupBoxUTACStart.TabStop = false;
            this.groupBoxUTACStart.Text = "UTAC Start";
            // 
            // checkBoxStartMinimized
            // 
            this.checkBoxStartMinimized.Location = new System.Drawing.Point(9, 38);
            this.checkBoxStartMinimized.Name = "checkBoxStartMinimized";
            this.checkBoxStartMinimized.Size = new System.Drawing.Size(121, 24);
            this.checkBoxStartMinimized.TabIndex = 1;
            this.checkBoxStartMinimized.Text = "Start minimized";
            this.checkBoxStartMinimized.UseVisualStyleBackColor = true;
            // 
            // checkBoxAutoStart
            // 
            this.checkBoxAutoStart.Location = new System.Drawing.Point(9, 15);
            this.checkBoxAutoStart.Name = "checkBoxAutoStart";
            this.checkBoxAutoStart.Size = new System.Drawing.Size(121, 24);
            this.checkBoxAutoStart.TabIndex = 0;
            this.checkBoxAutoStart.Text = "AutoStart UTAC";
            this.checkBoxAutoStart.UseVisualStyleBackColor = true;
            // 
            // OutputAndTimerTab
            // 
            this.OutputAndTimerTab.Controls.Add(this.groupBoxGraph);
            this.OutputAndTimerTab.Controls.Add(this.groupBoxAverageSystem);
            this.OutputAndTimerTab.Controls.Add(this.groupBoxOutput);
            this.OutputAndTimerTab.Controls.Add(this.groupBoxTimer);
            this.OutputAndTimerTab.Location = new System.Drawing.Point(4, 40);
            this.OutputAndTimerTab.Name = "OutputAndTimerTab";
            this.OutputAndTimerTab.Padding = new System.Windows.Forms.Padding(3);
            this.OutputAndTimerTab.Size = new System.Drawing.Size(409, 207);
            this.OutputAndTimerTab.TabIndex = 2;
            this.OutputAndTimerTab.Text = "Output / Timer";
            this.OutputAndTimerTab.UseVisualStyleBackColor = true;
            // 
            // groupBoxGraph
            // 
            this.groupBoxGraph.Controls.Add(this.labelGraphMin);
            this.groupBoxGraph.Controls.Add(this.checkBoxAutoSizeGraph);
            this.groupBoxGraph.Controls.Add(this.labelGraphMax);
            this.groupBoxGraph.Controls.Add(this.numericUpDownGraphScaleMax);
            this.groupBoxGraph.Controls.Add(this.numericUpDownGraphScaleMin);
            this.groupBoxGraph.Controls.Add(this.checkboxgraph);
            this.groupBoxGraph.Location = new System.Drawing.Point(187, 6);
            this.groupBoxGraph.Name = "groupBoxGraph";
            this.groupBoxGraph.Size = new System.Drawing.Size(212, 95);
            this.groupBoxGraph.TabIndex = 9;
            this.groupBoxGraph.TabStop = false;
            this.groupBoxGraph.Text = "Graph";
            // 
            // labelGraphMin
            // 
            this.labelGraphMin.Location = new System.Drawing.Point(111, 62);
            this.labelGraphMin.Name = "labelGraphMin";
            this.labelGraphMin.Size = new System.Drawing.Size(42, 23);
            this.labelGraphMin.TabIndex = 50;
            this.labelGraphMin.Text = "Min:";
            // 
            // checkBoxAutoSizeGraph
            // 
            this.checkBoxAutoSizeGraph.Location = new System.Drawing.Point(6, 34);
            this.checkBoxAutoSizeGraph.Name = "checkBoxAutoSizeGraph";
            this.checkBoxAutoSizeGraph.Size = new System.Drawing.Size(200, 24);
            this.checkBoxAutoSizeGraph.TabIndex = 56;
            this.checkBoxAutoSizeGraph.Text = "Auto Graph Scale";
            this.checkBoxAutoSizeGraph.UseVisualStyleBackColor = true;
            this.checkBoxAutoSizeGraph.CheckedChanged += new System.EventHandler(this.CheckBoxAutoSizeGraphCheckedChanged);
            // 
            // labelGraphMax
            // 
            this.labelGraphMax.Location = new System.Drawing.Point(6, 62);
            this.labelGraphMax.Name = "labelGraphMax";
            this.labelGraphMax.Size = new System.Drawing.Size(42, 23);
            this.labelGraphMax.TabIndex = 55;
            this.labelGraphMax.Text = "Max:";
            // 
            // numericUpDownGraphScaleMax
            // 
            this.numericUpDownGraphScaleMax.DecimalPlaces = 2;
            this.numericUpDownGraphScaleMax.Location = new System.Drawing.Point(50, 60);
            this.numericUpDownGraphScaleMax.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownGraphScaleMax.Name = "numericUpDownGraphScaleMax";
            this.numericUpDownGraphScaleMax.Size = new System.Drawing.Size(47, 20);
            this.numericUpDownGraphScaleMax.TabIndex = 53;
            this.numericUpDownGraphScaleMax.ValueChanged += new System.EventHandler(this.NumericUpDownGraphScaleMaxValueChanged);
            // 
            // numericUpDownGraphScaleMin
            // 
            this.numericUpDownGraphScaleMin.DecimalPlaces = 2;
            this.numericUpDownGraphScaleMin.Location = new System.Drawing.Point(159, 60);
            this.numericUpDownGraphScaleMin.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownGraphScaleMin.Name = "numericUpDownGraphScaleMin";
            this.numericUpDownGraphScaleMin.Size = new System.Drawing.Size(47, 20);
            this.numericUpDownGraphScaleMin.TabIndex = 54;
            this.numericUpDownGraphScaleMin.ValueChanged += new System.EventHandler(this.NumericUpDownGraphScaleMinValueChanged);
            // 
            // checkboxgraph
            // 
            this.checkboxgraph.Location = new System.Drawing.Point(6, 14);
            this.checkboxgraph.Name = "checkboxgraph";
            this.checkboxgraph.Size = new System.Drawing.Size(154, 24);
            this.checkboxgraph.TabIndex = 52;
            this.checkboxgraph.Text = "Activate Graph";
            this.checkboxgraph.UseVisualStyleBackColor = true;
            this.checkboxgraph.CheckedChanged += new System.EventHandler(this.CheckboxgraphCheckedChanged);
            // 
            // groupBoxAverageSystem
            // 
            this.groupBoxAverageSystem.Controls.Add(this.labelAverageInterval);
            this.groupBoxAverageSystem.Controls.Add(this.comboBoxAverageType);
            this.groupBoxAverageSystem.Controls.Add(this.checkBoxAverageGraph);
            this.groupBoxAverageSystem.Controls.Add(this.checkBoxAverageList);
            this.groupBoxAverageSystem.Controls.Add(this.numericUpDownAverageInterval);
            this.groupBoxAverageSystem.Location = new System.Drawing.Point(187, 102);
            this.groupBoxAverageSystem.Name = "groupBoxAverageSystem";
            this.groupBoxAverageSystem.Size = new System.Drawing.Size(212, 63);
            this.groupBoxAverageSystem.TabIndex = 8;
            this.groupBoxAverageSystem.TabStop = false;
            this.groupBoxAverageSystem.Text = "Average System";
            this.groupBoxAverageSystem.Visible = false;
            // 
            // labelAverageInterval
            // 
            this.labelAverageInterval.Location = new System.Drawing.Point(6, 40);
            this.labelAverageInterval.Name = "labelAverageInterval";
            this.labelAverageInterval.Size = new System.Drawing.Size(51, 18);
            this.labelAverageInterval.TabIndex = 7;
            this.labelAverageInterval.Text = "Interval:";
            // 
            // comboBoxAverageType
            // 
            this.comboBoxAverageType.FormattingEnabled = true;
            this.comboBoxAverageType.Items.AddRange(new object[] {
            "seconds",
            "minutes",
            "hours"});
            this.comboBoxAverageType.Location = new System.Drawing.Point(122, 38);
            this.comboBoxAverageType.Name = "comboBoxAverageType";
            this.comboBoxAverageType.Size = new System.Drawing.Size(86, 21);
            this.comboBoxAverageType.TabIndex = 6;
            // 
            // checkBoxAverageGraph
            // 
            this.checkBoxAverageGraph.Location = new System.Drawing.Point(113, 15);
            this.checkBoxAverageGraph.Name = "checkBoxAverageGraph";
            this.checkBoxAverageGraph.Size = new System.Drawing.Size(116, 24);
            this.checkBoxAverageGraph.TabIndex = 5;
            this.checkBoxAverageGraph.Text = "Average Graph";
            this.checkBoxAverageGraph.UseVisualStyleBackColor = true;
            // 
            // checkBoxAverageList
            // 
            this.checkBoxAverageList.Location = new System.Drawing.Point(6, 14);
            this.checkBoxAverageList.Name = "checkBoxAverageList";
            this.checkBoxAverageList.Size = new System.Drawing.Size(116, 24);
            this.checkBoxAverageList.TabIndex = 0;
            this.checkBoxAverageList.Text = "Average List";
            this.checkBoxAverageList.UseVisualStyleBackColor = true;
            // 
            // numericUpDownAverageInterval
            // 
            this.numericUpDownAverageInterval.Location = new System.Drawing.Point(60, 39);
            this.numericUpDownAverageInterval.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDownAverageInterval.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownAverageInterval.Name = "numericUpDownAverageInterval";
            this.numericUpDownAverageInterval.Size = new System.Drawing.Size(56, 20);
            this.numericUpDownAverageInterval.TabIndex = 4;
            this.numericUpDownAverageInterval.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // groupBoxOutput
            // 
            this.groupBoxOutput.Controls.Add(this.labelMaxitems);
            this.groupBoxOutput.Controls.Add(this.numericUpDownlistItems);
            this.groupBoxOutput.Controls.Add(this.checkboxlist);
            this.groupBoxOutput.Controls.Add(this.radioFahrenheit);
            this.groupBoxOutput.Controls.Add(this.radioCelsius);
            this.groupBoxOutput.Location = new System.Drawing.Point(9, 6);
            this.groupBoxOutput.Name = "groupBoxOutput";
            this.groupBoxOutput.Size = new System.Drawing.Size(172, 87);
            this.groupBoxOutput.TabIndex = 6;
            this.groupBoxOutput.TabStop = false;
            this.groupBoxOutput.Text = "Output";
            // 
            // labelMaxitems
            // 
            this.labelMaxitems.Location = new System.Drawing.Point(4, 40);
            this.labelMaxitems.Name = "labelMaxitems";
            this.labelMaxitems.Size = new System.Drawing.Size(77, 18);
            this.labelMaxitems.TabIndex = 13;
            this.labelMaxitems.Text = "Max. Items:";
            // 
            // numericUpDownlistItems
            // 
            this.numericUpDownlistItems.Location = new System.Drawing.Point(99, 38);
            this.numericUpDownlistItems.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numericUpDownlistItems.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownlistItems.Name = "numericUpDownlistItems";
            this.numericUpDownlistItems.Size = new System.Drawing.Size(63, 20);
            this.numericUpDownlistItems.TabIndex = 12;
            this.numericUpDownlistItems.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // checkboxlist
            // 
            this.checkboxlist.Location = new System.Drawing.Point(6, 59);
            this.checkboxlist.Name = "checkboxlist";
            this.checkboxlist.Size = new System.Drawing.Size(154, 24);
            this.checkboxlist.TabIndex = 10;
            this.checkboxlist.Text = "Record to List";
            this.checkboxlist.UseVisualStyleBackColor = true;
            // 
            // radioFahrenheit
            // 
            this.radioFahrenheit.Location = new System.Drawing.Point(86, 13);
            this.radioFahrenheit.Name = "radioFahrenheit";
            this.radioFahrenheit.Size = new System.Drawing.Size(76, 24);
            this.radioFahrenheit.TabIndex = 1;
            this.radioFahrenheit.Text = "Fahrenheit";
            this.radioFahrenheit.UseVisualStyleBackColor = true;
            // 
            // radioCelsius
            // 
            this.radioCelsius.Checked = true;
            this.radioCelsius.Location = new System.Drawing.Point(8, 13);
            this.radioCelsius.Name = "radioCelsius";
            this.radioCelsius.Size = new System.Drawing.Size(72, 24);
            this.radioCelsius.TabIndex = 0;
            this.radioCelsius.TabStop = true;
            this.radioCelsius.Text = "Celsius";
            this.radioCelsius.UseVisualStyleBackColor = true;
            // 
            // groupBoxTimer
            // 
            this.groupBoxTimer.Controls.Add(this.labelTimerSeconds);
            this.groupBoxTimer.Controls.Add(this.checkboxtimer);
            this.groupBoxTimer.Controls.Add(this.labelTimerInterval);
            this.groupBoxTimer.Controls.Add(this.timercount);
            this.groupBoxTimer.Location = new System.Drawing.Point(9, 95);
            this.groupBoxTimer.Name = "groupBoxTimer";
            this.groupBoxTimer.Size = new System.Drawing.Size(172, 70);
            this.groupBoxTimer.TabIndex = 7;
            this.groupBoxTimer.TabStop = false;
            this.groupBoxTimer.Text = "Timer";
            // 
            // labelTimerSeconds
            // 
            this.labelTimerSeconds.Location = new System.Drawing.Point(122, 45);
            this.labelTimerSeconds.Name = "labelTimerSeconds";
            this.labelTimerSeconds.Size = new System.Drawing.Size(26, 18);
            this.labelTimerSeconds.TabIndex = 6;
            this.labelTimerSeconds.Text = "sec.";
            // 
            // checkboxtimer
            // 
            this.checkboxtimer.Location = new System.Drawing.Point(6, 18);
            this.checkboxtimer.Name = "checkboxtimer";
            this.checkboxtimer.Size = new System.Drawing.Size(77, 24);
            this.checkboxtimer.TabIndex = 0;
            this.checkboxtimer.Text = "Activated";
            this.checkboxtimer.UseVisualStyleBackColor = true;
            // 
            // labelTimerInterval
            // 
            this.labelTimerInterval.Location = new System.Drawing.Point(3, 45);
            this.labelTimerInterval.Name = "labelTimerInterval";
            this.labelTimerInterval.Size = new System.Drawing.Size(51, 18);
            this.labelTimerInterval.TabIndex = 5;
            this.labelTimerInterval.Text = "Interval:";
            // 
            // timercount
            // 
            this.timercount.Location = new System.Drawing.Point(60, 43);
            this.timercount.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.timercount.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.timercount.Name = "timercount";
            this.timercount.Size = new System.Drawing.Size(56, 20);
            this.timercount.TabIndex = 4;
            this.timercount.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // RecordingTab
            // 
            this.RecordingTab.Controls.Add(this.textboxpath);
            this.RecordingTab.Controls.Add(this.groupBoxFileRecordingFormat);
            this.RecordingTab.Controls.Add(this.labelFileRecordingPath);
            this.RecordingTab.Controls.Add(this.buttonFolderSelect);
            this.RecordingTab.Controls.Add(this.checkboxdailyfiles);
            this.RecordingTab.Controls.Add(this.checkboxrecordtofile);
            this.RecordingTab.Location = new System.Drawing.Point(4, 40);
            this.RecordingTab.Name = "RecordingTab";
            this.RecordingTab.Padding = new System.Windows.Forms.Padding(3);
            this.RecordingTab.Size = new System.Drawing.Size(409, 207);
            this.RecordingTab.TabIndex = 1;
            this.RecordingTab.Text = "File Recording";
            this.RecordingTab.UseVisualStyleBackColor = true;
            // 
            // textboxpath
            // 
            this.textboxpath.Location = new System.Drawing.Point(41, 92);
            this.textboxpath.Name = "textboxpath";
            this.textboxpath.Size = new System.Drawing.Size(307, 20);
            this.textboxpath.TabIndex = 18;
            // 
            // groupBoxFileRecordingFormat
            // 
            this.groupBoxFileRecordingFormat.Controls.Add(this.radioTXT);
            this.groupBoxFileRecordingFormat.Controls.Add(this.radioCSV);
            this.groupBoxFileRecordingFormat.Location = new System.Drawing.Point(257, 19);
            this.groupBoxFileRecordingFormat.Name = "groupBoxFileRecordingFormat";
            this.groupBoxFileRecordingFormat.Size = new System.Drawing.Size(122, 54);
            this.groupBoxFileRecordingFormat.TabIndex = 8;
            this.groupBoxFileRecordingFormat.TabStop = false;
            this.groupBoxFileRecordingFormat.Text = "Format:";
            // 
            // radioTXT
            // 
            this.radioTXT.Location = new System.Drawing.Point(67, 19);
            this.radioTXT.Name = "radioTXT";
            this.radioTXT.Size = new System.Drawing.Size(49, 24);
            this.radioTXT.TabIndex = 21;
            this.radioTXT.Text = "TXT";
            this.radioTXT.UseVisualStyleBackColor = true;
            // 
            // radioCSV
            // 
            this.radioCSV.Checked = true;
            this.radioCSV.Location = new System.Drawing.Point(16, 19);
            this.radioCSV.Name = "radioCSV";
            this.radioCSV.Size = new System.Drawing.Size(50, 24);
            this.radioCSV.TabIndex = 20;
            this.radioCSV.TabStop = true;
            this.radioCSV.Text = "CSV";
            this.radioCSV.UseVisualStyleBackColor = true;
            // 
            // labelFileRecordingPath
            // 
            this.labelFileRecordingPath.Location = new System.Drawing.Point(3, 95);
            this.labelFileRecordingPath.Name = "labelFileRecordingPath";
            this.labelFileRecordingPath.Size = new System.Drawing.Size(46, 18);
            this.labelFileRecordingPath.TabIndex = 8;
            this.labelFileRecordingPath.Text = "Path:";
            // 
            // buttonFolderSelect
            // 
            this.buttonFolderSelect.ImageIndex = 0;
            this.buttonFolderSelect.Location = new System.Drawing.Point(354, 89);
            this.buttonFolderSelect.Name = "buttonFolderSelect";
            this.buttonFolderSelect.Size = new System.Drawing.Size(25, 25);
            this.buttonFolderSelect.TabIndex = 19;
            this.buttonFolderSelect.UseVisualStyleBackColor = true;
            this.buttonFolderSelect.Click += new System.EventHandler(this.ButtonFolderSelectClick);
            // 
            // checkboxdailyfiles
            // 
            this.checkboxdailyfiles.Location = new System.Drawing.Point(16, 49);
            this.checkboxdailyfiles.Name = "checkboxdailyfiles";
            this.checkboxdailyfiles.Size = new System.Drawing.Size(153, 24);
            this.checkboxdailyfiles.TabIndex = 17;
            this.checkboxdailyfiles.Text = "Generate Daily Files";
            this.checkboxdailyfiles.UseVisualStyleBackColor = true;
            // 
            // checkboxrecordtofile
            // 
            this.checkboxrecordtofile.Location = new System.Drawing.Point(16, 24);
            this.checkboxrecordtofile.Name = "checkboxrecordtofile";
            this.checkboxrecordtofile.Size = new System.Drawing.Size(104, 24);
            this.checkboxrecordtofile.TabIndex = 16;
            this.checkboxrecordtofile.Text = "Activated";
            this.checkboxrecordtofile.UseVisualStyleBackColor = true;
            this.checkboxrecordtofile.CheckedChanged += new System.EventHandler(this.CheckboxrecordtofileCheckedChanged);
            // 
            // FTPTab
            // 
            this.FTPTab.Controls.Add(this.labelFTPRequire);
            this.FTPTab.Controls.Add(this.checkBoxFTPUploadGraph);
            this.FTPTab.Controls.Add(this.textBox_ftpport);
            this.FTPTab.Controls.Add(this.textBox_ftpuploaddir);
            this.FTPTab.Controls.Add(this.labelFTPUploadDir);
            this.FTPTab.Controls.Add(this.buttonftptest);
            this.FTPTab.Controls.Add(this.checkBoxftp);
            this.FTPTab.Controls.Add(this.labelFTPUsername);
            this.FTPTab.Controls.Add(this.labelFTPPassword);
            this.FTPTab.Controls.Add(this.labelFTPServer);
            this.FTPTab.Controls.Add(this.textBox_ftppass);
            this.FTPTab.Controls.Add(this.textBox_ftpuser);
            this.FTPTab.Controls.Add(this.textBox_ftpserver);
            this.FTPTab.Controls.Add(this.label11);
            this.FTPTab.Location = new System.Drawing.Point(4, 40);
            this.FTPTab.Name = "FTPTab";
            this.FTPTab.Padding = new System.Windows.Forms.Padding(3);
            this.FTPTab.Size = new System.Drawing.Size(409, 207);
            this.FTPTab.TabIndex = 3;
            this.FTPTab.Text = "FTP Upload";
            this.FTPTab.UseVisualStyleBackColor = true;
            // 
            // labelFTPRequire
            // 
            this.labelFTPRequire.Location = new System.Drawing.Point(6, 149);
            this.labelFTPRequire.Name = "labelFTPRequire";
            this.labelFTPRequire.Size = new System.Drawing.Size(289, 23);
            this.labelFTPRequire.TabIndex = 34;
            this.labelFTPRequire.Text = "FTP Upload requires File Recording";
            // 
            // checkBoxFTPUploadGraph
            // 
            this.checkBoxFTPUploadGraph.Location = new System.Drawing.Point(95, 6);
            this.checkBoxFTPUploadGraph.Name = "checkBoxFTPUploadGraph";
            this.checkBoxFTPUploadGraph.Size = new System.Drawing.Size(140, 24);
            this.checkBoxFTPUploadGraph.TabIndex = 33;
            this.checkBoxFTPUploadGraph.Text = "Upload Graph";
            this.checkBoxFTPUploadGraph.UseVisualStyleBackColor = true;
            this.checkBoxFTPUploadGraph.CheckedChanged += new System.EventHandler(this.CheckBoxFTPUploadGraphCheckedChanged);
            // 
            // textBox_ftpport
            // 
            this.textBox_ftpport.Location = new System.Drawing.Point(358, 34);
            this.textBox_ftpport.Name = "textBox_ftpport";
            this.textBox_ftpport.Size = new System.Drawing.Size(36, 20);
            this.textBox_ftpport.TabIndex = 31;
            // 
            // textBox_ftpuploaddir
            // 
            this.textBox_ftpuploaddir.Location = new System.Drawing.Point(95, 111);
            this.textBox_ftpuploaddir.Name = "textBox_ftpuploaddir";
            this.textBox_ftpuploaddir.Size = new System.Drawing.Size(299, 20);
            this.textBox_ftpuploaddir.TabIndex = 30;
            // 
            // labelFTPUploadDir
            // 
            this.labelFTPUploadDir.Location = new System.Drawing.Point(6, 114);
            this.labelFTPUploadDir.Name = "labelFTPUploadDir";
            this.labelFTPUploadDir.Size = new System.Drawing.Size(80, 18);
            this.labelFTPUploadDir.TabIndex = 29;
            this.labelFTPUploadDir.Text = "Upload Dir:";
            // 
            // buttonftptest
            // 
            this.buttonftptest.ImageIndex = 6;
            this.buttonftptest.Location = new System.Drawing.Point(317, 60);
            this.buttonftptest.Name = "buttonftptest";
            this.buttonftptest.Size = new System.Drawing.Size(77, 45);
            this.buttonftptest.TabIndex = 27;
            this.buttonftptest.Text = "Test";
            this.buttonftptest.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonftptest.UseVisualStyleBackColor = true;
            this.buttonftptest.Click += new System.EventHandler(this.ButtonftptestClick);
            // 
            // checkBoxftp
            // 
            this.checkBoxftp.Location = new System.Drawing.Point(9, 6);
            this.checkBoxftp.Name = "checkBoxftp";
            this.checkBoxftp.Size = new System.Drawing.Size(77, 24);
            this.checkBoxftp.TabIndex = 26;
            this.checkBoxftp.Text = "Activated";
            this.checkBoxftp.UseVisualStyleBackColor = true;
            this.checkBoxftp.CheckedChanged += new System.EventHandler(this.CheckBoxftpCheckedChanged);
            // 
            // labelFTPUsername
            // 
            this.labelFTPUsername.Location = new System.Drawing.Point(6, 62);
            this.labelFTPUsername.Name = "labelFTPUsername";
            this.labelFTPUsername.Size = new System.Drawing.Size(80, 18);
            this.labelFTPUsername.TabIndex = 25;
            this.labelFTPUsername.Text = "Username:";
            // 
            // labelFTPPassword
            // 
            this.labelFTPPassword.Location = new System.Drawing.Point(6, 88);
            this.labelFTPPassword.Name = "labelFTPPassword";
            this.labelFTPPassword.Size = new System.Drawing.Size(80, 18);
            this.labelFTPPassword.TabIndex = 24;
            this.labelFTPPassword.Text = "Passwort:";
            // 
            // labelFTPServer
            // 
            this.labelFTPServer.Location = new System.Drawing.Point(6, 36);
            this.labelFTPServer.Name = "labelFTPServer";
            this.labelFTPServer.Size = new System.Drawing.Size(80, 18);
            this.labelFTPServer.TabIndex = 23;
            this.labelFTPServer.Text = "Server:";
            // 
            // textBox_ftppass
            // 
            this.textBox_ftppass.Location = new System.Drawing.Point(95, 86);
            this.textBox_ftppass.Name = "textBox_ftppass";
            this.textBox_ftppass.PasswordChar = '*';
            this.textBox_ftppass.Size = new System.Drawing.Size(216, 20);
            this.textBox_ftppass.TabIndex = 21;
            // 
            // textBox_ftpuser
            // 
            this.textBox_ftpuser.Location = new System.Drawing.Point(95, 60);
            this.textBox_ftpuser.Name = "textBox_ftpuser";
            this.textBox_ftpuser.Size = new System.Drawing.Size(216, 20);
            this.textBox_ftpuser.TabIndex = 20;
            // 
            // textBox_ftpserver
            // 
            this.textBox_ftpserver.Location = new System.Drawing.Point(95, 34);
            this.textBox_ftpserver.Name = "textBox_ftpserver";
            this.textBox_ftpserver.Size = new System.Drawing.Size(240, 20);
            this.textBox_ftpserver.TabIndex = 19;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(341, 36);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 23);
            this.label11.TabIndex = 32;
            this.label11.Text = ":";
            // 
            // WebUrlTab
            // 
            this.WebUrlTab.Controls.Add(this.groupBox2);
            this.WebUrlTab.Controls.Add(this.labelURL);
            this.WebUrlTab.Controls.Add(this.buttonUrlGrabTest);
            this.WebUrlTab.Controls.Add(this.labelURLText2);
            this.WebUrlTab.Controls.Add(this.checkBoxURLactivated);
            this.WebUrlTab.Controls.Add(this.textBoxURL);
            this.WebUrlTab.Location = new System.Drawing.Point(4, 40);
            this.WebUrlTab.Name = "WebUrlTab";
            this.WebUrlTab.Padding = new System.Windows.Forms.Padding(3);
            this.WebUrlTab.Size = new System.Drawing.Size(409, 207);
            this.WebUrlTab.TabIndex = 4;
            this.WebUrlTab.Text = "Web URL Grabber";
            this.WebUrlTab.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.WUG_Active);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.WUG_PW);
            this.groupBox2.Controls.Add(this.WUG_ID);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 132);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(409, 75);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Weather Underground Upload";
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(6, 23);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(258, 18);
            this.label22.TabIndex = 37;
            this.label22.Text = "Note: Uses device #0 only.";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // WUG_Active
            // 
            this.WUG_Active.Location = new System.Drawing.Point(270, 21);
            this.WUG_Active.Name = "WUG_Active";
            this.WUG_Active.Size = new System.Drawing.Size(77, 24);
            this.WUG_Active.TabIndex = 36;
            this.WUG_Active.Text = "Activated";
            this.WUG_Active.UseVisualStyleBackColor = true;
            this.WUG_Active.CheckedChanged += new System.EventHandler(this.WUG_Active_CheckedChanged);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(3, 51);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 18);
            this.label12.TabIndex = 33;
            this.label12.Text = "Station ID:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(200, 51);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(64, 18);
            this.label21.TabIndex = 35;
            this.label21.Text = "Password:";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label21.Click += new System.EventHandler(this.label21_Click);
            // 
            // WUG_PW
            // 
            this.WUG_PW.AcceptsTab = true;
            this.WUG_PW.Location = new System.Drawing.Point(270, 48);
            this.WUG_PW.Name = "WUG_PW";
            this.WUG_PW.Size = new System.Drawing.Size(103, 20);
            this.WUG_PW.TabIndex = 34;
            // 
            // WUG_ID
            // 
            this.WUG_ID.Location = new System.Drawing.Point(68, 48);
            this.WUG_ID.Name = "WUG_ID";
            this.WUG_ID.Size = new System.Drawing.Size(103, 20);
            this.WUG_ID.TabIndex = 32;
            // 
            // labelURL
            // 
            this.labelURL.Location = new System.Drawing.Point(6, 8);
            this.labelURL.Name = "labelURL";
            this.labelURL.Size = new System.Drawing.Size(34, 18);
            this.labelURL.TabIndex = 31;
            this.labelURL.Text = "URL:";
            this.labelURL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonUrlGrabTest
            // 
            this.buttonUrlGrabTest.ImageIndex = 6;
            this.buttonUrlGrabTest.Location = new System.Drawing.Point(317, 32);
            this.buttonUrlGrabTest.Name = "buttonUrlGrabTest";
            this.buttonUrlGrabTest.Size = new System.Drawing.Size(77, 25);
            this.buttonUrlGrabTest.TabIndex = 30;
            this.buttonUrlGrabTest.Text = "Test";
            this.buttonUrlGrabTest.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonUrlGrabTest.UseVisualStyleBackColor = true;
            this.buttonUrlGrabTest.Click += new System.EventHandler(this.ButtonUrlGrabTestClick);
            // 
            // labelURLText2
            // 
            this.labelURLText2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelURLText2.Location = new System.Drawing.Point(5, 60);
            this.labelURLText2.Name = "labelURLText2";
            this.labelURLText2.Size = new System.Drawing.Size(388, 56);
            this.labelURLText2.TabIndex = 28;
            this.labelURLText2.Text = resources.GetString("labelURLText2.Text");
            // 
            // checkBoxURLactivated
            // 
            this.checkBoxURLactivated.Location = new System.Drawing.Point(234, 32);
            this.checkBoxURLactivated.Name = "checkBoxURLactivated";
            this.checkBoxURLactivated.Size = new System.Drawing.Size(77, 24);
            this.checkBoxURLactivated.TabIndex = 27;
            this.checkBoxURLactivated.Text = "Activated";
            this.checkBoxURLactivated.UseVisualStyleBackColor = true;
            this.checkBoxURLactivated.CheckedChanged += new System.EventHandler(this.CheckBoxURLactivatedCheckedChanged);
            // 
            // textBoxURL
            // 
            this.textBoxURL.Location = new System.Drawing.Point(45, 6);
            this.textBoxURL.Name = "textBoxURL";
            this.textBoxURL.Size = new System.Drawing.Size(349, 20);
            this.textBoxURL.TabIndex = 0;
            // 
            // BuiltInWebServerTab
            // 
            this.BuiltInWebServerTab.Controls.Add(this.groupBoxBIWXML);
            this.BuiltInWebServerTab.Controls.Add(this.groupBoxBIW);
            this.BuiltInWebServerTab.Location = new System.Drawing.Point(4, 40);
            this.BuiltInWebServerTab.Name = "BuiltInWebServerTab";
            this.BuiltInWebServerTab.Padding = new System.Windows.Forms.Padding(3);
            this.BuiltInWebServerTab.Size = new System.Drawing.Size(409, 207);
            this.BuiltInWebServerTab.TabIndex = 6;
            this.BuiltInWebServerTab.Text = "Web Server";
            this.BuiltInWebServerTab.UseVisualStyleBackColor = true;
            // 
            // groupBoxBIWXML
            // 
            this.groupBoxBIWXML.Controls.Add(this.checkBoxBIWXMLRefresh);
            this.groupBoxBIWXML.Controls.Add(this.checkBoxBIWXMLActivated);
            this.groupBoxBIWXML.Controls.Add(this.labelBIWXMLPort);
            this.groupBoxBIWXML.Controls.Add(this.updownBIWXMLPort);
            this.groupBoxBIWXML.Location = new System.Drawing.Point(6, 95);
            this.groupBoxBIWXML.Name = "groupBoxBIWXML";
            this.groupBoxBIWXML.Size = new System.Drawing.Size(385, 68);
            this.groupBoxBIWXML.TabIndex = 41;
            this.groupBoxBIWXML.TabStop = false;
            this.groupBoxBIWXML.Text = "XML Web Server";
            // 
            // checkBoxBIWXMLRefresh
            // 
            this.checkBoxBIWXMLRefresh.Location = new System.Drawing.Point(18, 39);
            this.checkBoxBIWXMLRefresh.Name = "checkBoxBIWXMLRefresh";
            this.checkBoxBIWXMLRefresh.Size = new System.Drawing.Size(205, 24);
            this.checkBoxBIWXMLRefresh.TabIndex = 41;
            this.checkBoxBIWXMLRefresh.Text = "Refresh Temp on Access";
            this.checkBoxBIWXMLRefresh.UseVisualStyleBackColor = true;
            // 
            // checkBoxBIWXMLActivated
            // 
            this.checkBoxBIWXMLActivated.Location = new System.Drawing.Point(18, 16);
            this.checkBoxBIWXMLActivated.Name = "checkBoxBIWXMLActivated";
            this.checkBoxBIWXMLActivated.Size = new System.Drawing.Size(104, 24);
            this.checkBoxBIWXMLActivated.TabIndex = 1;
            this.checkBoxBIWXMLActivated.Text = "Activated";
            this.checkBoxBIWXMLActivated.UseVisualStyleBackColor = true;
            // 
            // labelBIWXMLPort
            // 
            this.labelBIWXMLPort.Location = new System.Drawing.Point(189, 18);
            this.labelBIWXMLPort.Name = "labelBIWXMLPort";
            this.labelBIWXMLPort.Size = new System.Drawing.Size(34, 18);
            this.labelBIWXMLPort.TabIndex = 39;
            this.labelBIWXMLPort.Text = "Port:";
            // 
            // updownBIWXMLPort
            // 
            this.updownBIWXMLPort.Location = new System.Drawing.Point(229, 16);
            this.updownBIWXMLPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.updownBIWXMLPort.Minimum = new decimal(new int[] {
            5050,
            0,
            0,
            0});
            this.updownBIWXMLPort.Name = "updownBIWXMLPort";
            this.updownBIWXMLPort.Size = new System.Drawing.Size(62, 20);
            this.updownBIWXMLPort.TabIndex = 38;
            this.updownBIWXMLPort.Value = new decimal(new int[] {
            5051,
            0,
            0,
            0});
            // 
            // groupBoxBIW
            // 
            this.groupBoxBIW.Controls.Add(this.checkBoxBIWEnableRefresh);
            this.groupBoxBIW.Controls.Add(this.checkBoxBIWActivated);
            this.groupBoxBIW.Controls.Add(this.labelBIWPort);
            this.groupBoxBIW.Controls.Add(this.textBoxBIW);
            this.groupBoxBIW.Controls.Add(this.updownBIWPort);
            this.groupBoxBIW.Controls.Add(this.labelBIWTitle);
            this.groupBoxBIW.Location = new System.Drawing.Point(6, 6);
            this.groupBoxBIW.Name = "groupBoxBIW";
            this.groupBoxBIW.Size = new System.Drawing.Size(385, 83);
            this.groupBoxBIW.TabIndex = 40;
            this.groupBoxBIW.TabStop = false;
            this.groupBoxBIW.Text = "Web Server";
            // 
            // checkBoxBIWEnableRefresh
            // 
            this.checkBoxBIWEnableRefresh.Location = new System.Drawing.Point(116, 16);
            this.checkBoxBIWEnableRefresh.Name = "checkBoxBIWEnableRefresh";
            this.checkBoxBIWEnableRefresh.Size = new System.Drawing.Size(147, 24);
            this.checkBoxBIWEnableRefresh.TabIndex = 40;
            this.checkBoxBIWEnableRefresh.Text = "Enable manual Refresh";
            this.checkBoxBIWEnableRefresh.UseVisualStyleBackColor = true;
            // 
            // checkBoxBIWActivated
            // 
            this.checkBoxBIWActivated.Location = new System.Drawing.Point(18, 16);
            this.checkBoxBIWActivated.Name = "checkBoxBIWActivated";
            this.checkBoxBIWActivated.Size = new System.Drawing.Size(92, 24);
            this.checkBoxBIWActivated.TabIndex = 1;
            this.checkBoxBIWActivated.Text = "Activated";
            this.checkBoxBIWActivated.UseVisualStyleBackColor = true;
            // 
            // labelBIWPort
            // 
            this.labelBIWPort.Location = new System.Drawing.Point(279, 18);
            this.labelBIWPort.Name = "labelBIWPort";
            this.labelBIWPort.Size = new System.Drawing.Size(34, 18);
            this.labelBIWPort.TabIndex = 39;
            this.labelBIWPort.Text = "Port:";
            // 
            // textBoxBIW
            // 
            this.textBoxBIW.Location = new System.Drawing.Point(58, 46);
            this.textBoxBIW.Name = "textBoxBIW";
            this.textBoxBIW.Size = new System.Drawing.Size(318, 20);
            this.textBoxBIW.TabIndex = 32;
            this.textBoxBIW.Text = "USB TEMPer Advanced Control";
            // 
            // updownBIWPort
            // 
            this.updownBIWPort.Location = new System.Drawing.Point(314, 16);
            this.updownBIWPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.updownBIWPort.Minimum = new decimal(new int[] {
            5050,
            0,
            0,
            0});
            this.updownBIWPort.Name = "updownBIWPort";
            this.updownBIWPort.Size = new System.Drawing.Size(62, 20);
            this.updownBIWPort.TabIndex = 38;
            this.updownBIWPort.Value = new decimal(new int[] {
            5050,
            0,
            0,
            0});
            // 
            // labelBIWTitle
            // 
            this.labelBIWTitle.Location = new System.Drawing.Point(18, 48);
            this.labelBIWTitle.Name = "labelBIWTitle";
            this.labelBIWTitle.Size = new System.Drawing.Size(34, 18);
            this.labelBIWTitle.TabIndex = 33;
            this.labelBIWTitle.Text = "Title:";
            // 
            // ProxyTab
            // 
            this.ProxyTab.Controls.Add(this.groupBoxProxySettings);
            this.ProxyTab.Location = new System.Drawing.Point(4, 40);
            this.ProxyTab.Name = "ProxyTab";
            this.ProxyTab.Padding = new System.Windows.Forms.Padding(3);
            this.ProxyTab.Size = new System.Drawing.Size(409, 207);
            this.ProxyTab.TabIndex = 5;
            this.ProxyTab.Text = "Proxy";
            this.ProxyTab.UseVisualStyleBackColor = true;
            // 
            // groupBoxProxySettings
            // 
            this.groupBoxProxySettings.Controls.Add(this.label3);
            this.groupBoxProxySettings.Controls.Add(this.checkBoxuseauth);
            this.groupBoxProxySettings.Controls.Add(this.textBoxproxypassword);
            this.groupBoxProxySettings.Controls.Add(this.checkBoxproxy);
            this.groupBoxProxySettings.Controls.Add(this.textBoxproxyusername);
            this.groupBoxProxySettings.Controls.Add(this.textBoxproxyport);
            this.groupBoxProxySettings.Controls.Add(this.textBoxproxyserver);
            this.groupBoxProxySettings.Controls.Add(this.labelProxyPassword);
            this.groupBoxProxySettings.Controls.Add(this.labelProxyUsername);
            this.groupBoxProxySettings.Controls.Add(this.labelProxyServer);
            this.groupBoxProxySettings.Location = new System.Drawing.Point(6, 8);
            this.groupBoxProxySettings.Name = "groupBoxProxySettings";
            this.groupBoxProxySettings.Size = new System.Drawing.Size(397, 130);
            this.groupBoxProxySettings.TabIndex = 1;
            this.groupBoxProxySettings.TabStop = false;
            this.groupBoxProxySettings.Text = "Proxy Settings";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(298, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = ":";
            // 
            // checkBoxuseauth
            // 
            this.checkBoxuseauth.Location = new System.Drawing.Point(132, 16);
            this.checkBoxuseauth.Name = "checkBoxuseauth";
            this.checkBoxuseauth.Size = new System.Drawing.Size(130, 24);
            this.checkBoxuseauth.TabIndex = 3;
            this.checkBoxuseauth.Text = "Use Authetication";
            this.checkBoxuseauth.UseVisualStyleBackColor = true;
            // 
            // textBoxproxypassword
            // 
            this.textBoxproxypassword.Location = new System.Drawing.Point(70, 98);
            this.textBoxproxypassword.Name = "textBoxproxypassword";
            this.textBoxproxypassword.Size = new System.Drawing.Size(283, 20);
            this.textBoxproxypassword.TabIndex = 3;
            // 
            // checkBoxproxy
            // 
            this.checkBoxproxy.Location = new System.Drawing.Point(6, 16);
            this.checkBoxproxy.Name = "checkBoxproxy";
            this.checkBoxproxy.Size = new System.Drawing.Size(104, 24);
            this.checkBoxproxy.TabIndex = 2;
            this.checkBoxproxy.Text = "Activated";
            this.checkBoxproxy.UseVisualStyleBackColor = true;
            this.checkBoxproxy.CheckedChanged += new System.EventHandler(this.CheckBoxproxyCheckedChanged);
            // 
            // textBoxproxyusername
            // 
            this.textBoxproxyusername.Location = new System.Drawing.Point(70, 72);
            this.textBoxproxyusername.Name = "textBoxproxyusername";
            this.textBoxproxyusername.Size = new System.Drawing.Size(283, 20);
            this.textBoxproxyusername.TabIndex = 2;
            // 
            // textBoxproxyport
            // 
            this.textBoxproxyport.Location = new System.Drawing.Point(310, 46);
            this.textBoxproxyport.Name = "textBoxproxyport";
            this.textBoxproxyport.Size = new System.Drawing.Size(42, 20);
            this.textBoxproxyport.TabIndex = 1;
            // 
            // textBoxproxyserver
            // 
            this.textBoxproxyserver.Location = new System.Drawing.Point(70, 46);
            this.textBoxproxyserver.Name = "textBoxproxyserver";
            this.textBoxproxyserver.Size = new System.Drawing.Size(225, 20);
            this.textBoxproxyserver.TabIndex = 0;
            // 
            // labelProxyPassword
            // 
            this.labelProxyPassword.Location = new System.Drawing.Point(6, 101);
            this.labelProxyPassword.Name = "labelProxyPassword";
            this.labelProxyPassword.Size = new System.Drawing.Size(72, 21);
            this.labelProxyPassword.TabIndex = 6;
            this.labelProxyPassword.Text = "Password:";
            // 
            // labelProxyUsername
            // 
            this.labelProxyUsername.Location = new System.Drawing.Point(6, 74);
            this.labelProxyUsername.Name = "labelProxyUsername";
            this.labelProxyUsername.Size = new System.Drawing.Size(72, 21);
            this.labelProxyUsername.TabIndex = 5;
            this.labelProxyUsername.Text = "Username:";
            // 
            // labelProxyServer
            // 
            this.labelProxyServer.Location = new System.Drawing.Point(6, 46);
            this.labelProxyServer.Name = "labelProxyServer";
            this.labelProxyServer.Size = new System.Drawing.Size(72, 21);
            this.labelProxyServer.TabIndex = 4;
            this.labelProxyServer.Text = "Server:";
            // 
            // LanguageTab
            // 
            this.LanguageTab.Controls.Add(this.listBoxLangFile);
            this.LanguageTab.Controls.Add(this.groupBoxLanguage);
            this.LanguageTab.Location = new System.Drawing.Point(4, 40);
            this.LanguageTab.Name = "LanguageTab";
            this.LanguageTab.Padding = new System.Windows.Forms.Padding(3);
            this.LanguageTab.Size = new System.Drawing.Size(409, 207);
            this.LanguageTab.TabIndex = 7;
            this.LanguageTab.Text = "Language";
            this.LanguageTab.UseVisualStyleBackColor = true;
            // 
            // listBoxLangFile
            // 
            this.listBoxLangFile.FormattingEnabled = true;
            this.listBoxLangFile.Location = new System.Drawing.Point(17, 21);
            this.listBoxLangFile.Name = "listBoxLangFile";
            this.listBoxLangFile.Size = new System.Drawing.Size(123, 134);
            this.listBoxLangFile.TabIndex = 1;
            this.listBoxLangFile.SelectedIndexChanged += new System.EventHandler(this.ListBoxLangFileSelectedIndexChanged);
            // 
            // groupBoxLanguage
            // 
            this.groupBoxLanguage.Controls.Add(this.labelLFIVersionVal);
            this.groupBoxLanguage.Controls.Add(this.labelLFILanguageVal);
            this.groupBoxLanguage.Controls.Add(this.labelLFIDateVal);
            this.groupBoxLanguage.Controls.Add(this.labelLFIAuthormailVal);
            this.groupBoxLanguage.Controls.Add(this.labelLFSIAuthorwwwVal);
            this.groupBoxLanguage.Controls.Add(this.labelLFIAuthorVal);
            this.groupBoxLanguage.Controls.Add(this.labelLFIDate);
            this.groupBoxLanguage.Controls.Add(this.labelLFIVersion);
            this.groupBoxLanguage.Controls.Add(this.labelLFSIAuthor);
            this.groupBoxLanguage.Controls.Add(this.labelLFILanguage);
            this.groupBoxLanguage.Location = new System.Drawing.Point(157, 17);
            this.groupBoxLanguage.Name = "groupBoxLanguage";
            this.groupBoxLanguage.Size = new System.Drawing.Size(227, 138);
            this.groupBoxLanguage.TabIndex = 0;
            this.groupBoxLanguage.TabStop = false;
            this.groupBoxLanguage.Text = "groupBox6";
            // 
            // labelLFIVersionVal
            // 
            this.labelLFIVersionVal.Location = new System.Drawing.Point(170, 49);
            this.labelLFIVersionVal.Name = "labelLFIVersionVal";
            this.labelLFIVersionVal.Size = new System.Drawing.Size(51, 23);
            this.labelLFIVersionVal.TabIndex = 9;
            this.labelLFIVersionVal.Text = "version";
            // 
            // labelLFILanguageVal
            // 
            this.labelLFILanguageVal.Location = new System.Drawing.Point(66, 26);
            this.labelLFILanguageVal.Name = "labelLFILanguageVal";
            this.labelLFILanguageVal.Size = new System.Drawing.Size(155, 23);
            this.labelLFILanguageVal.TabIndex = 8;
            this.labelLFILanguageVal.Text = "lang";
            // 
            // labelLFIDateVal
            // 
            this.labelLFIDateVal.Location = new System.Drawing.Point(48, 49);
            this.labelLFIDateVal.Name = "labelLFIDateVal";
            this.labelLFIDateVal.Size = new System.Drawing.Size(67, 23);
            this.labelLFIDateVal.TabIndex = 7;
            this.labelLFIDateVal.Text = "date";
            // 
            // labelLFIAuthormailVal
            // 
            this.labelLFIAuthormailVal.Location = new System.Drawing.Point(66, 112);
            this.labelLFIAuthormailVal.Name = "labelLFIAuthormailVal";
            this.labelLFIAuthormailVal.Size = new System.Drawing.Size(161, 23);
            this.labelLFIAuthormailVal.TabIndex = 6;
            this.labelLFIAuthormailVal.Text = "authormail";
            // 
            // labelLFSIAuthorwwwVal
            // 
            this.labelLFSIAuthorwwwVal.Location = new System.Drawing.Point(66, 95);
            this.labelLFSIAuthorwwwVal.Name = "labelLFSIAuthorwwwVal";
            this.labelLFSIAuthorwwwVal.Size = new System.Drawing.Size(155, 23);
            this.labelLFSIAuthorwwwVal.TabIndex = 5;
            this.labelLFSIAuthorwwwVal.Text = "authorwww";
            // 
            // labelLFIAuthorVal
            // 
            this.labelLFIAuthorVal.Location = new System.Drawing.Point(66, 72);
            this.labelLFIAuthorVal.Name = "labelLFIAuthorVal";
            this.labelLFIAuthorVal.Size = new System.Drawing.Size(155, 23);
            this.labelLFIAuthorVal.TabIndex = 4;
            this.labelLFIAuthorVal.Text = "author";
            // 
            // labelLFIDate
            // 
            this.labelLFIDate.Location = new System.Drawing.Point(6, 49);
            this.labelLFIDate.Name = "labelLFIDate";
            this.labelLFIDate.Size = new System.Drawing.Size(100, 23);
            this.labelLFIDate.TabIndex = 3;
            this.labelLFIDate.Text = "Date:";
            // 
            // labelLFIVersion
            // 
            this.labelLFIVersion.Location = new System.Drawing.Point(121, 49);
            this.labelLFIVersion.Name = "labelLFIVersion";
            this.labelLFIVersion.Size = new System.Drawing.Size(45, 23);
            this.labelLFIVersion.TabIndex = 2;
            this.labelLFIVersion.Text = "Version:";
            // 
            // labelLFSIAuthor
            // 
            this.labelLFSIAuthor.Location = new System.Drawing.Point(6, 72);
            this.labelLFSIAuthor.Name = "labelLFSIAuthor";
            this.labelLFSIAuthor.Size = new System.Drawing.Size(100, 23);
            this.labelLFSIAuthor.TabIndex = 1;
            this.labelLFSIAuthor.Text = "Author:";
            // 
            // labelLFILanguage
            // 
            this.labelLFILanguage.Location = new System.Drawing.Point(6, 26);
            this.labelLFILanguage.Name = "labelLFILanguage";
            this.labelLFILanguage.Size = new System.Drawing.Size(100, 23);
            this.labelLFILanguage.TabIndex = 0;
            this.labelLFILanguage.Text = "Language:";
            // 
            // tabPageAlertSystem
            // 
            this.tabPageAlertSystem.Controls.Add(this.label30);
            this.tabPageAlertSystem.Controls.Add(this.checkBoxTempAlertOnscreenNotify4);
            this.tabPageAlertSystem.Controls.Add(this.checkBoxHumAlertOnscreenNotify4);
            this.tabPageAlertSystem.Controls.Add(this.checkBoxHumAlertEMailNotify4);
            this.tabPageAlertSystem.Controls.Add(this.checkBoxTempAlertEMailNotify4);
            this.tabPageAlertSystem.Controls.Add(this.numericUpDownTempMin4);
            this.tabPageAlertSystem.Controls.Add(this.numericUpDownTempMax4);
            this.tabPageAlertSystem.Controls.Add(this.numericUpDownHumMin4);
            this.tabPageAlertSystem.Controls.Add(this.numericUpDownHumMax4);
            this.tabPageAlertSystem.Controls.Add(this.label29);
            this.tabPageAlertSystem.Controls.Add(this.checkBoxTempAlertOnscreenNotify3);
            this.tabPageAlertSystem.Controls.Add(this.checkBoxHumAlertOnscreenNotify3);
            this.tabPageAlertSystem.Controls.Add(this.checkBoxHumAlertEMailNotify3);
            this.tabPageAlertSystem.Controls.Add(this.checkBoxTempAlertEMailNotify3);
            this.tabPageAlertSystem.Controls.Add(this.numericUpDownTempMin3);
            this.tabPageAlertSystem.Controls.Add(this.numericUpDownTempMax3);
            this.tabPageAlertSystem.Controls.Add(this.numericUpDownHumMin3);
            this.tabPageAlertSystem.Controls.Add(this.numericUpDownHumMax3);
            this.tabPageAlertSystem.Controls.Add(this.label28);
            this.tabPageAlertSystem.Controls.Add(this.checkBoxTempAlertOnscreenNotify2);
            this.tabPageAlertSystem.Controls.Add(this.checkBoxHumAlertOnscreenNotify2);
            this.tabPageAlertSystem.Controls.Add(this.checkBoxHumAlertEMailNotify2);
            this.tabPageAlertSystem.Controls.Add(this.checkBoxTempAlertEMailNotify2);
            this.tabPageAlertSystem.Controls.Add(this.numericUpDownTempMin2);
            this.tabPageAlertSystem.Controls.Add(this.numericUpDownTempMax2);
            this.tabPageAlertSystem.Controls.Add(this.numericUpDownHumMin2);
            this.tabPageAlertSystem.Controls.Add(this.numericUpDownHumMax2);
            this.tabPageAlertSystem.Controls.Add(this.label27);
            this.tabPageAlertSystem.Controls.Add(this.label25);
            this.tabPageAlertSystem.Controls.Add(this.label26);
            this.tabPageAlertSystem.Controls.Add(this.label24);
            this.tabPageAlertSystem.Controls.Add(this.label23);
            this.tabPageAlertSystem.Controls.Add(this.checkBoxTempAlertOnscreenNotify1);
            this.tabPageAlertSystem.Controls.Add(this.checkBoxHumAlertOnscreenNotify1);
            this.tabPageAlertSystem.Controls.Add(this.checkBoxHumAlertEMailNotify1);
            this.tabPageAlertSystem.Controls.Add(this.checkBoxTempAlertEMailNotify1);
            this.tabPageAlertSystem.Controls.Add(this.numericUpDownTempMin1);
            this.tabPageAlertSystem.Controls.Add(this.numericUpDownTempMax1);
            this.tabPageAlertSystem.Controls.Add(this.numericUpDownHumMin1);
            this.tabPageAlertSystem.Controls.Add(this.numericUpDownHumMax1);
            this.tabPageAlertSystem.Location = new System.Drawing.Point(4, 40);
            this.tabPageAlertSystem.Name = "tabPageAlertSystem";
            this.tabPageAlertSystem.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAlertSystem.Size = new System.Drawing.Size(409, 207);
            this.tabPageAlertSystem.TabIndex = 10;
            this.tabPageAlertSystem.Text = "Alert System";
            this.tabPageAlertSystem.UseVisualStyleBackColor = true;
            // 
            // label30
            // 
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(6, 156);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(91, 29);
            this.label30.TabIndex = 95;
            this.label30.Text = "Device 4";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBoxTempAlertOnscreenNotify4
            // 
            this.checkBoxTempAlertOnscreenNotify4.Location = new System.Drawing.Point(166, 177);
            this.checkBoxTempAlertOnscreenNotify4.Name = "checkBoxTempAlertOnscreenNotify4";
            this.checkBoxTempAlertOnscreenNotify4.Size = new System.Drawing.Size(80, 24);
            this.checkBoxTempAlertOnscreenNotify4.TabIndex = 94;
            this.checkBoxTempAlertOnscreenNotify4.Text = "On Screen";
            this.checkBoxTempAlertOnscreenNotify4.UseVisualStyleBackColor = true;
            // 
            // checkBoxHumAlertEMailNotify4
            // 
            this.checkBoxHumAlertEMailNotify4.Location = new System.Drawing.Point(267, 177);
            this.checkBoxHumAlertEMailNotify4.Name = "checkBoxHumAlertEMailNotify4";
            this.checkBoxHumAlertEMailNotify4.Size = new System.Drawing.Size(58, 24);
            this.checkBoxHumAlertEMailNotify4.TabIndex = 91;
            this.checkBoxHumAlertEMailNotify4.Text = "E-Mail";
            this.checkBoxHumAlertEMailNotify4.UseVisualStyleBackColor = true;
            // 
            // checkBoxTempAlertEMailNotify4
            // 
            this.checkBoxTempAlertEMailNotify4.Location = new System.Drawing.Point(103, 177);
            this.checkBoxTempAlertEMailNotify4.Name = "checkBoxTempAlertEMailNotify4";
            this.checkBoxTempAlertEMailNotify4.Size = new System.Drawing.Size(57, 24);
            this.checkBoxTempAlertEMailNotify4.TabIndex = 92;
            this.checkBoxTempAlertEMailNotify4.Text = "E-Mail";
            this.checkBoxTempAlertEMailNotify4.UseVisualStyleBackColor = true;
            // 
            // numericUpDownTempMin4
            // 
            this.numericUpDownTempMin4.DecimalPlaces = 2;
            this.numericUpDownTempMin4.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownTempMin4.Location = new System.Drawing.Point(103, 161);
            this.numericUpDownTempMin4.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownTempMin4.Name = "numericUpDownTempMin4";
            this.numericUpDownTempMin4.Size = new System.Drawing.Size(68, 20);
            this.numericUpDownTempMin4.TabIndex = 89;
            // 
            // numericUpDownTempMax4
            // 
            this.numericUpDownTempMax4.DecimalPlaces = 2;
            this.numericUpDownTempMax4.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownTempMax4.Location = new System.Drawing.Point(177, 161);
            this.numericUpDownTempMax4.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownTempMax4.Name = "numericUpDownTempMax4";
            this.numericUpDownTempMax4.Size = new System.Drawing.Size(68, 20);
            this.numericUpDownTempMax4.TabIndex = 87;
            // 
            // numericUpDownHumMin4
            // 
            this.numericUpDownHumMin4.DecimalPlaces = 2;
            this.numericUpDownHumMin4.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownHumMin4.Location = new System.Drawing.Point(267, 161);
            this.numericUpDownHumMin4.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownHumMin4.Name = "numericUpDownHumMin4";
            this.numericUpDownHumMin4.Size = new System.Drawing.Size(68, 20);
            this.numericUpDownHumMin4.TabIndex = 90;
            // 
            // numericUpDownHumMax4
            // 
            this.numericUpDownHumMax4.DecimalPlaces = 2;
            this.numericUpDownHumMax4.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownHumMax4.Location = new System.Drawing.Point(341, 161);
            this.numericUpDownHumMax4.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownHumMax4.Name = "numericUpDownHumMax4";
            this.numericUpDownHumMax4.Size = new System.Drawing.Size(68, 20);
            this.numericUpDownHumMax4.TabIndex = 88;
            // 
            // label29
            // 
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(6, 110);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(91, 29);
            this.label29.TabIndex = 86;
            this.label29.Text = "Device 3";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBoxTempAlertOnscreenNotify3
            // 
            this.checkBoxTempAlertOnscreenNotify3.Location = new System.Drawing.Point(166, 131);
            this.checkBoxTempAlertOnscreenNotify3.Name = "checkBoxTempAlertOnscreenNotify3";
            this.checkBoxTempAlertOnscreenNotify3.Size = new System.Drawing.Size(80, 24);
            this.checkBoxTempAlertOnscreenNotify3.TabIndex = 85;
            this.checkBoxTempAlertOnscreenNotify3.Text = "On Screen";
            this.checkBoxTempAlertOnscreenNotify3.UseVisualStyleBackColor = true;
            // 
            // checkBoxHumAlertEMailNotify3
            // 
            this.checkBoxHumAlertEMailNotify3.Location = new System.Drawing.Point(267, 131);
            this.checkBoxHumAlertEMailNotify3.Name = "checkBoxHumAlertEMailNotify3";
            this.checkBoxHumAlertEMailNotify3.Size = new System.Drawing.Size(58, 24);
            this.checkBoxHumAlertEMailNotify3.TabIndex = 82;
            this.checkBoxHumAlertEMailNotify3.Text = "E-Mail";
            this.checkBoxHumAlertEMailNotify3.UseVisualStyleBackColor = true;
            // 
            // checkBoxTempAlertEMailNotify3
            // 
            this.checkBoxTempAlertEMailNotify3.Location = new System.Drawing.Point(103, 131);
            this.checkBoxTempAlertEMailNotify3.Name = "checkBoxTempAlertEMailNotify3";
            this.checkBoxTempAlertEMailNotify3.Size = new System.Drawing.Size(57, 24);
            this.checkBoxTempAlertEMailNotify3.TabIndex = 83;
            this.checkBoxTempAlertEMailNotify3.Text = "E-Mail";
            this.checkBoxTempAlertEMailNotify3.UseVisualStyleBackColor = true;
            // 
            // numericUpDownTempMin3
            // 
            this.numericUpDownTempMin3.DecimalPlaces = 2;
            this.numericUpDownTempMin3.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownTempMin3.Location = new System.Drawing.Point(103, 115);
            this.numericUpDownTempMin3.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownTempMin3.Name = "numericUpDownTempMin3";
            this.numericUpDownTempMin3.Size = new System.Drawing.Size(68, 20);
            this.numericUpDownTempMin3.TabIndex = 80;
            // 
            // numericUpDownTempMax3
            // 
            this.numericUpDownTempMax3.DecimalPlaces = 2;
            this.numericUpDownTempMax3.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownTempMax3.Location = new System.Drawing.Point(177, 115);
            this.numericUpDownTempMax3.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownTempMax3.Name = "numericUpDownTempMax3";
            this.numericUpDownTempMax3.Size = new System.Drawing.Size(68, 20);
            this.numericUpDownTempMax3.TabIndex = 78;
            // 
            // numericUpDownHumMin3
            // 
            this.numericUpDownHumMin3.DecimalPlaces = 2;
            this.numericUpDownHumMin3.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownHumMin3.Location = new System.Drawing.Point(267, 115);
            this.numericUpDownHumMin3.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownHumMin3.Name = "numericUpDownHumMin3";
            this.numericUpDownHumMin3.Size = new System.Drawing.Size(68, 20);
            this.numericUpDownHumMin3.TabIndex = 81;
            // 
            // numericUpDownHumMax3
            // 
            this.numericUpDownHumMax3.DecimalPlaces = 2;
            this.numericUpDownHumMax3.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownHumMax3.Location = new System.Drawing.Point(341, 115);
            this.numericUpDownHumMax3.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownHumMax3.Name = "numericUpDownHumMax3";
            this.numericUpDownHumMax3.Size = new System.Drawing.Size(68, 20);
            this.numericUpDownHumMax3.TabIndex = 79;
            // 
            // label28
            // 
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(6, 64);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(91, 29);
            this.label28.TabIndex = 77;
            this.label28.Text = "Device 2";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBoxTempAlertOnscreenNotify2
            // 
            this.checkBoxTempAlertOnscreenNotify2.Location = new System.Drawing.Point(166, 85);
            this.checkBoxTempAlertOnscreenNotify2.Name = "checkBoxTempAlertOnscreenNotify2";
            this.checkBoxTempAlertOnscreenNotify2.Size = new System.Drawing.Size(80, 24);
            this.checkBoxTempAlertOnscreenNotify2.TabIndex = 72;
            this.checkBoxTempAlertOnscreenNotify2.Text = "On Screen";
            this.checkBoxTempAlertOnscreenNotify2.UseVisualStyleBackColor = true;
            // 
            // checkBoxHumAlertEMailNotify2
            // 
            this.checkBoxHumAlertEMailNotify2.Location = new System.Drawing.Point(267, 85);
            this.checkBoxHumAlertEMailNotify2.Name = "checkBoxHumAlertEMailNotify2";
            this.checkBoxHumAlertEMailNotify2.Size = new System.Drawing.Size(58, 24);
            this.checkBoxHumAlertEMailNotify2.TabIndex = 69;
            this.checkBoxHumAlertEMailNotify2.Text = "E-Mail";
            this.checkBoxHumAlertEMailNotify2.UseVisualStyleBackColor = true;
            // 
            // checkBoxTempAlertEMailNotify2
            // 
            this.checkBoxTempAlertEMailNotify2.Location = new System.Drawing.Point(103, 85);
            this.checkBoxTempAlertEMailNotify2.Name = "checkBoxTempAlertEMailNotify2";
            this.checkBoxTempAlertEMailNotify2.Size = new System.Drawing.Size(57, 24);
            this.checkBoxTempAlertEMailNotify2.TabIndex = 70;
            this.checkBoxTempAlertEMailNotify2.Text = "E-Mail";
            this.checkBoxTempAlertEMailNotify2.UseVisualStyleBackColor = true;
            // 
            // numericUpDownTempMax2
            // 
            this.numericUpDownTempMax2.DecimalPlaces = 2;
            this.numericUpDownTempMax2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownTempMax2.Location = new System.Drawing.Point(177, 69);
            this.numericUpDownTempMax2.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownTempMax2.Name = "numericUpDownTempMax2";
            this.numericUpDownTempMax2.Size = new System.Drawing.Size(68, 20);
            this.numericUpDownTempMax2.TabIndex = 65;
            // 
            // numericUpDownHumMin2
            // 
            this.numericUpDownHumMin2.DecimalPlaces = 2;
            this.numericUpDownHumMin2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownHumMin2.Location = new System.Drawing.Point(267, 69);
            this.numericUpDownHumMin2.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownHumMin2.Name = "numericUpDownHumMin2";
            this.numericUpDownHumMin2.Size = new System.Drawing.Size(68, 20);
            this.numericUpDownHumMin2.TabIndex = 68;
            // 
            // numericUpDownHumMax2
            // 
            this.numericUpDownHumMax2.DecimalPlaces = 2;
            this.numericUpDownHumMax2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownHumMax2.Location = new System.Drawing.Point(341, 69);
            this.numericUpDownHumMax2.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownHumMax2.Name = "numericUpDownHumMax2";
            this.numericUpDownHumMax2.Size = new System.Drawing.Size(68, 20);
            this.numericUpDownHumMax2.TabIndex = 66;
            // 
            // label27
            // 
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(6, 18);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(91, 29);
            this.label27.TabIndex = 64;
            this.label27.Text = "Device 1";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(344, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(65, 15);
            this.label25.TabIndex = 63;
            this.label25.Text = "Hum Max";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label26
            // 
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(277, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(48, 15);
            this.label26.TabIndex = 62;
            this.label26.Text = "Hum Min";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label24
            // 
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(175, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(65, 15);
            this.label24.TabIndex = 61;
            this.label24.Text = "Temp Max";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(112, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(48, 15);
            this.label23.TabIndex = 60;
            this.label23.Text = "Temp Min";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBoxTempAlertOnscreenNotify1
            // 
            this.checkBoxTempAlertOnscreenNotify1.Location = new System.Drawing.Point(166, 39);
            this.checkBoxTempAlertOnscreenNotify1.Name = "checkBoxTempAlertOnscreenNotify1";
            this.checkBoxTempAlertOnscreenNotify1.Size = new System.Drawing.Size(80, 24);
            this.checkBoxTempAlertOnscreenNotify1.TabIndex = 44;
            this.checkBoxTempAlertOnscreenNotify1.Text = "On Screen";
            this.checkBoxTempAlertOnscreenNotify1.UseVisualStyleBackColor = true;
            // 
            // checkBoxHumAlertEMailNotify1
            // 
            this.checkBoxHumAlertEMailNotify1.Location = new System.Drawing.Point(267, 39);
            this.checkBoxHumAlertEMailNotify1.Name = "checkBoxHumAlertEMailNotify1";
            this.checkBoxHumAlertEMailNotify1.Size = new System.Drawing.Size(58, 24);
            this.checkBoxHumAlertEMailNotify1.TabIndex = 43;
            this.checkBoxHumAlertEMailNotify1.Text = "E-Mail";
            this.checkBoxHumAlertEMailNotify1.UseVisualStyleBackColor = true;
            // 
            // checkBoxTempAlertEMailNotify1
            // 
            this.checkBoxTempAlertEMailNotify1.Location = new System.Drawing.Point(103, 39);
            this.checkBoxTempAlertEMailNotify1.Name = "checkBoxTempAlertEMailNotify1";
            this.checkBoxTempAlertEMailNotify1.Size = new System.Drawing.Size(57, 24);
            this.checkBoxTempAlertEMailNotify1.TabIndex = 43;
            this.checkBoxTempAlertEMailNotify1.Text = "E-Mail";
            this.checkBoxTempAlertEMailNotify1.UseVisualStyleBackColor = true;
            // 
            // numericUpDownTempMin1
            // 
            this.numericUpDownTempMin1.DecimalPlaces = 2;
            this.numericUpDownTempMin1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownTempMin1.Location = new System.Drawing.Point(103, 18);
            this.numericUpDownTempMin1.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownTempMin1.Name = "numericUpDownTempMin1";
            this.numericUpDownTempMin1.Size = new System.Drawing.Size(68, 20);
            this.numericUpDownTempMin1.TabIndex = 38;
            // 
            // numericUpDownTempMax1
            // 
            this.numericUpDownTempMax1.DecimalPlaces = 2;
            this.numericUpDownTempMax1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownTempMax1.Location = new System.Drawing.Point(177, 18);
            this.numericUpDownTempMax1.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownTempMax1.Name = "numericUpDownTempMax1";
            this.numericUpDownTempMax1.Size = new System.Drawing.Size(68, 20);
            this.numericUpDownTempMax1.TabIndex = 37;
            // 
            // numericUpDownHumMin1
            // 
            this.numericUpDownHumMin1.DecimalPlaces = 2;
            this.numericUpDownHumMin1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownHumMin1.Location = new System.Drawing.Point(267, 18);
            this.numericUpDownHumMin1.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownHumMin1.Name = "numericUpDownHumMin1";
            this.numericUpDownHumMin1.Size = new System.Drawing.Size(68, 20);
            this.numericUpDownHumMin1.TabIndex = 38;
            // 
            // numericUpDownHumMax1
            // 
            this.numericUpDownHumMax1.DecimalPlaces = 2;
            this.numericUpDownHumMax1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownHumMax1.Location = new System.Drawing.Point(341, 18);
            this.numericUpDownHumMax1.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownHumMax1.Name = "numericUpDownHumMax1";
            this.numericUpDownHumMax1.Size = new System.Drawing.Size(68, 20);
            this.numericUpDownHumMax1.TabIndex = 37;
            // 
            // tabPageEMail
            // 
            this.tabPageEMail.Controls.Add(this.groupBoxEMailSMTPSettings);
            this.tabPageEMail.Location = new System.Drawing.Point(4, 40);
            this.tabPageEMail.Name = "tabPageEMail";
            this.tabPageEMail.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEMail.Size = new System.Drawing.Size(409, 207);
            this.tabPageEMail.TabIndex = 11;
            this.tabPageEMail.Text = "E-Mail";
            this.tabPageEMail.UseVisualStyleBackColor = true;
            // 
            // groupBoxEMailSMTPSettings
            // 
            this.groupBoxEMailSMTPSettings.Controls.Add(this.buttonEMailTest);
            this.groupBoxEMailSMTPSettings.Controls.Add(this.label15);
            this.groupBoxEMailSMTPSettings.Controls.Add(this.labelEMailReceipientAddress);
            this.groupBoxEMailSMTPSettings.Controls.Add(this.labelEMailFromAddress);
            this.groupBoxEMailSMTPSettings.Controls.Add(this.labelEMailPassword);
            this.groupBoxEMailSMTPSettings.Controls.Add(this.labelEMailUsername);
            this.groupBoxEMailSMTPSettings.Controls.Add(this.labelEMailServerPort);
            this.groupBoxEMailSMTPSettings.Controls.Add(this.textBoxEmailReceipientAddress);
            this.groupBoxEMailSMTPSettings.Controls.Add(this.textBoxEmailFromAddress);
            this.groupBoxEMailSMTPSettings.Controls.Add(this.textBoxEmailPassword);
            this.groupBoxEMailSMTPSettings.Controls.Add(this.textBoxEmailUsername);
            this.groupBoxEMailSMTPSettings.Controls.Add(this.textBoxEmailPort);
            this.groupBoxEMailSMTPSettings.Controls.Add(this.textBoxEmailServer);
            this.groupBoxEMailSMTPSettings.Location = new System.Drawing.Point(6, 6);
            this.groupBoxEMailSMTPSettings.Name = "groupBoxEMailSMTPSettings";
            this.groupBoxEMailSMTPSettings.Size = new System.Drawing.Size(397, 159);
            this.groupBoxEMailSMTPSettings.TabIndex = 40;
            this.groupBoxEMailSMTPSettings.TabStop = false;
            this.groupBoxEMailSMTPSettings.Text = "E-Mail SMTP Settings";
            // 
            // buttonEMailTest
            // 
            this.buttonEMailTest.Location = new System.Drawing.Point(316, 56);
            this.buttonEMailTest.Name = "buttonEMailTest";
            this.buttonEMailTest.Size = new System.Drawing.Size(75, 42);
            this.buttonEMailTest.TabIndex = 54;
            this.buttonEMailTest.Text = "button1";
            this.buttonEMailTest.UseVisualStyleBackColor = true;
            this.buttonEMailTest.Click += new System.EventHandler(this.ButtonEMailTestClick);
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(336, 31);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(13, 23);
            this.label15.TabIndex = 53;
            this.label15.Text = ":";
            // 
            // labelEMailReceipientAddress
            // 
            this.labelEMailReceipientAddress.Location = new System.Drawing.Point(6, 133);
            this.labelEMailReceipientAddress.Name = "labelEMailReceipientAddress";
            this.labelEMailReceipientAddress.Size = new System.Drawing.Size(105, 23);
            this.labelEMailReceipientAddress.TabIndex = 52;
            this.labelEMailReceipientAddress.Text = "Receipient Address:";
            // 
            // labelEMailFromAddress
            // 
            this.labelEMailFromAddress.Location = new System.Drawing.Point(6, 110);
            this.labelEMailFromAddress.Name = "labelEMailFromAddress";
            this.labelEMailFromAddress.Size = new System.Drawing.Size(105, 23);
            this.labelEMailFromAddress.TabIndex = 51;
            this.labelEMailFromAddress.Text = "From Address:";
            // 
            // labelEMailPassword
            // 
            this.labelEMailPassword.Location = new System.Drawing.Point(6, 84);
            this.labelEMailPassword.Name = "labelEMailPassword";
            this.labelEMailPassword.Size = new System.Drawing.Size(105, 23);
            this.labelEMailPassword.TabIndex = 50;
            this.labelEMailPassword.Text = "Password:";
            // 
            // labelEMailUsername
            // 
            this.labelEMailUsername.Location = new System.Drawing.Point(6, 58);
            this.labelEMailUsername.Name = "labelEMailUsername";
            this.labelEMailUsername.Size = new System.Drawing.Size(105, 23);
            this.labelEMailUsername.TabIndex = 49;
            this.labelEMailUsername.Text = "Username:";
            // 
            // labelEMailServerPort
            // 
            this.labelEMailServerPort.Location = new System.Drawing.Point(6, 32);
            this.labelEMailServerPort.Name = "labelEMailServerPort";
            this.labelEMailServerPort.Size = new System.Drawing.Size(105, 23);
            this.labelEMailServerPort.TabIndex = 48;
            this.labelEMailServerPort.Text = "Server / Port:";
            // 
            // textBoxEmailReceipientAddress
            // 
            this.textBoxEmailReceipientAddress.Location = new System.Drawing.Point(127, 132);
            this.textBoxEmailReceipientAddress.Name = "textBoxEmailReceipientAddress";
            this.textBoxEmailReceipientAddress.Size = new System.Drawing.Size(264, 20);
            this.textBoxEmailReceipientAddress.TabIndex = 9;
            // 
            // textBoxEmailFromAddress
            // 
            this.textBoxEmailFromAddress.Location = new System.Drawing.Point(127, 106);
            this.textBoxEmailFromAddress.Name = "textBoxEmailFromAddress";
            this.textBoxEmailFromAddress.Size = new System.Drawing.Size(264, 20);
            this.textBoxEmailFromAddress.TabIndex = 8;
            // 
            // textBoxEmailPassword
            // 
            this.textBoxEmailPassword.Location = new System.Drawing.Point(127, 80);
            this.textBoxEmailPassword.Name = "textBoxEmailPassword";
            this.textBoxEmailPassword.Size = new System.Drawing.Size(178, 20);
            this.textBoxEmailPassword.TabIndex = 7;
            // 
            // textBoxEmailUsername
            // 
            this.textBoxEmailUsername.Location = new System.Drawing.Point(127, 54);
            this.textBoxEmailUsername.Name = "textBoxEmailUsername";
            this.textBoxEmailUsername.Size = new System.Drawing.Size(178, 20);
            this.textBoxEmailUsername.TabIndex = 6;
            // 
            // textBoxEmailPort
            // 
            this.textBoxEmailPort.Location = new System.Drawing.Point(349, 28);
            this.textBoxEmailPort.Name = "textBoxEmailPort";
            this.textBoxEmailPort.Size = new System.Drawing.Size(42, 20);
            this.textBoxEmailPort.TabIndex = 5;
            // 
            // textBoxEmailServer
            // 
            this.textBoxEmailServer.Location = new System.Drawing.Point(127, 28);
            this.textBoxEmailServer.Name = "textBoxEmailServer";
            this.textBoxEmailServer.Size = new System.Drawing.Size(203, 20);
            this.textBoxEmailServer.TabIndex = 4;
            // 
            // tabGraphing
            // 
            this.tabGraphing.Controls.Add(this.label6);
            this.tabGraphing.Controls.Add(this.groupBox1);
            this.tabGraphing.Location = new System.Drawing.Point(4, 40);
            this.tabGraphing.Name = "tabGraphing";
            this.tabGraphing.Padding = new System.Windows.Forms.Padding(3);
            this.tabGraphing.Size = new System.Drawing.Size(409, 207);
            this.tabGraphing.TabIndex = 12;
            this.tabGraphing.Text = "Graphing";
            this.tabGraphing.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(10, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(388, 33);
            this.label6.TabIndex = 42;
            this.label6.Text = "You can put %d% for the timestamp, %t% for the temperature and %h% for the humidi" +
                "ty in the Graph Title.";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxDeviceName4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxDeviceName3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxDeviceName2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxDeviceName1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(3, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(385, 68);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Graph Titles";
            // 
            // textBoxDeviceName4
            // 
            this.textBoxDeviceName4.Location = new System.Drawing.Point(255, 39);
            this.textBoxDeviceName4.Name = "textBoxDeviceName4";
            this.textBoxDeviceName4.Size = new System.Drawing.Size(96, 20);
            this.textBoxDeviceName4.TabIndex = 38;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(194, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 18);
            this.label5.TabIndex = 39;
            this.label5.Text = "Device 4:";
            // 
            // textBoxDeviceName3
            // 
            this.textBoxDeviceName3.Location = new System.Drawing.Point(255, 13);
            this.textBoxDeviceName3.Name = "textBoxDeviceName3";
            this.textBoxDeviceName3.Size = new System.Drawing.Size(96, 20);
            this.textBoxDeviceName3.TabIndex = 36;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(194, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 18);
            this.label4.TabIndex = 37;
            this.label4.Text = "Device 3:";
            // 
            // textBoxDeviceName2
            // 
            this.textBoxDeviceName2.Location = new System.Drawing.Point(67, 39);
            this.textBoxDeviceName2.Name = "textBoxDeviceName2";
            this.textBoxDeviceName2.Size = new System.Drawing.Size(96, 20);
            this.textBoxDeviceName2.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 18);
            this.label1.TabIndex = 35;
            this.label1.Text = "Device 2:";
            // 
            // textBoxDeviceName1
            // 
            this.textBoxDeviceName1.Location = new System.Drawing.Point(67, 13);
            this.textBoxDeviceName1.Name = "textBoxDeviceName1";
            this.textBoxDeviceName1.Size = new System.Drawing.Size(96, 20);
            this.textBoxDeviceName1.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 18);
            this.label2.TabIndex = 33;
            this.label2.Text = "Device 1:";
            // 
            // CalTabPage
            // 
            this.CalTabPage.Controls.Add(this.label20);
            this.CalTabPage.Controls.Add(this.label19);
            this.CalTabPage.Controls.Add(this.label18);
            this.CalTabPage.Controls.Add(this.label17);
            this.CalTabPage.Controls.Add(this.label16);
            this.CalTabPage.Controls.Add(this.label14);
            this.CalTabPage.Controls.Add(this.label13);
            this.CalTabPage.Controls.Add(this.textBoxHumCalS4);
            this.CalTabPage.Controls.Add(this.textBoxHumCalO4);
            this.CalTabPage.Controls.Add(this.textBoxTempCalS4);
            this.CalTabPage.Controls.Add(this.label10);
            this.CalTabPage.Controls.Add(this.textBoxTempCalO4);
            this.CalTabPage.Controls.Add(this.textBoxHumCalS3);
            this.CalTabPage.Controls.Add(this.textBoxHumCalO3);
            this.CalTabPage.Controls.Add(this.textBoxTempCalS3);
            this.CalTabPage.Controls.Add(this.label9);
            this.CalTabPage.Controls.Add(this.textBoxTempCalO3);
            this.CalTabPage.Controls.Add(this.textBoxHumCalS2);
            this.CalTabPage.Controls.Add(this.textBoxHumCalO2);
            this.CalTabPage.Controls.Add(this.textBoxTempCalS2);
            this.CalTabPage.Controls.Add(this.label8);
            this.CalTabPage.Controls.Add(this.textBoxTempCalO2);
            this.CalTabPage.Controls.Add(this.textBoxHumCalS1);
            this.CalTabPage.Controls.Add(this.textBoxHumCalO1);
            this.CalTabPage.Controls.Add(this.textBoxTempCalS1);
            this.CalTabPage.Controls.Add(this.label7);
            this.CalTabPage.Controls.Add(this.textBoxTempCalO1);
            this.CalTabPage.Location = new System.Drawing.Point(4, 40);
            this.CalTabPage.Name = "CalTabPage";
            this.CalTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.CalTabPage.Size = new System.Drawing.Size(409, 207);
            this.CalTabPage.TabIndex = 13;
            this.CalTabPage.Text = "Cal";
            this.CalTabPage.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(7, 145);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(388, 47);
            this.label20.TabIndex = 59;
            this.label20.Text = resources.GetString("label20.Text");
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(207, 4);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(115, 18);
            this.label19.TabIndex = 58;
            this.label19.Text = "Humidity";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(66, 4);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(115, 18);
            this.label18.TabIndex = 57;
            this.label18.Text = "Temperature";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(267, 22);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(55, 18);
            this.label17.TabIndex = 56;
            this.label17.Text = "Slope";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(207, 22);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(55, 18);
            this.label16.TabIndex = 55;
            this.label16.Text = "Offset";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(126, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 18);
            this.label14.TabIndex = 54;
            this.label14.Text = "Slope";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(66, 22);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 18);
            this.label13.TabIndex = 53;
            this.label13.Text = "Offset";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxHumCalS4
            // 
            this.textBoxHumCalS4.Location = new System.Drawing.Point(268, 121);
            this.textBoxHumCalS4.Name = "textBoxHumCalS4";
            this.textBoxHumCalS4.Size = new System.Drawing.Size(54, 20);
            this.textBoxHumCalS4.TabIndex = 52;
            // 
            // textBoxHumCalO4
            // 
            this.textBoxHumCalO4.Location = new System.Drawing.Point(208, 122);
            this.textBoxHumCalO4.Name = "textBoxHumCalO4";
            this.textBoxHumCalO4.Size = new System.Drawing.Size(54, 20);
            this.textBoxHumCalO4.TabIndex = 51;
            // 
            // textBoxTempCalS4
            // 
            this.textBoxTempCalS4.Location = new System.Drawing.Point(127, 121);
            this.textBoxTempCalS4.Name = "textBoxTempCalS4";
            this.textBoxTempCalS4.Size = new System.Drawing.Size(54, 20);
            this.textBoxTempCalS4.TabIndex = 50;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(6, 124);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 18);
            this.label10.TabIndex = 49;
            this.label10.Text = "Device 4:";
            // 
            // textBoxTempCalO4
            // 
            this.textBoxTempCalO4.Location = new System.Drawing.Point(67, 121);
            this.textBoxTempCalO4.Name = "textBoxTempCalO4";
            this.textBoxTempCalO4.Size = new System.Drawing.Size(54, 20);
            this.textBoxTempCalO4.TabIndex = 48;
            // 
            // textBoxHumCalS3
            // 
            this.textBoxHumCalS3.Location = new System.Drawing.Point(268, 95);
            this.textBoxHumCalS3.Name = "textBoxHumCalS3";
            this.textBoxHumCalS3.Size = new System.Drawing.Size(54, 20);
            this.textBoxHumCalS3.TabIndex = 47;
            // 
            // textBoxHumCalO3
            // 
            this.textBoxHumCalO3.Location = new System.Drawing.Point(208, 96);
            this.textBoxHumCalO3.Name = "textBoxHumCalO3";
            this.textBoxHumCalO3.Size = new System.Drawing.Size(54, 20);
            this.textBoxHumCalO3.TabIndex = 46;
            // 
            // textBoxTempCalS3
            // 
            this.textBoxTempCalS3.Location = new System.Drawing.Point(127, 95);
            this.textBoxTempCalS3.Name = "textBoxTempCalS3";
            this.textBoxTempCalS3.Size = new System.Drawing.Size(54, 20);
            this.textBoxTempCalS3.TabIndex = 45;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(6, 98);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 18);
            this.label9.TabIndex = 44;
            this.label9.Text = "Device 3:";
            // 
            // textBoxTempCalO3
            // 
            this.textBoxTempCalO3.Location = new System.Drawing.Point(67, 95);
            this.textBoxTempCalO3.Name = "textBoxTempCalO3";
            this.textBoxTempCalO3.Size = new System.Drawing.Size(54, 20);
            this.textBoxTempCalO3.TabIndex = 43;
            // 
            // textBoxHumCalS2
            // 
            this.textBoxHumCalS2.Location = new System.Drawing.Point(268, 69);
            this.textBoxHumCalS2.Name = "textBoxHumCalS2";
            this.textBoxHumCalS2.Size = new System.Drawing.Size(54, 20);
            this.textBoxHumCalS2.TabIndex = 42;
            // 
            // textBoxHumCalO2
            // 
            this.textBoxHumCalO2.Location = new System.Drawing.Point(208, 70);
            this.textBoxHumCalO2.Name = "textBoxHumCalO2";
            this.textBoxHumCalO2.Size = new System.Drawing.Size(54, 20);
            this.textBoxHumCalO2.TabIndex = 41;
            // 
            // textBoxTempCalS2
            // 
            this.textBoxTempCalS2.Location = new System.Drawing.Point(127, 69);
            this.textBoxTempCalS2.Name = "textBoxTempCalS2";
            this.textBoxTempCalS2.Size = new System.Drawing.Size(54, 20);
            this.textBoxTempCalS2.TabIndex = 40;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(6, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 18);
            this.label8.TabIndex = 39;
            this.label8.Text = "Device 2:";
            // 
            // textBoxTempCalO2
            // 
            this.textBoxTempCalO2.Location = new System.Drawing.Point(67, 69);
            this.textBoxTempCalO2.Name = "textBoxTempCalO2";
            this.textBoxTempCalO2.Size = new System.Drawing.Size(54, 20);
            this.textBoxTempCalO2.TabIndex = 38;
            // 
            // textBoxHumCalS1
            // 
            this.textBoxHumCalS1.Location = new System.Drawing.Point(268, 43);
            this.textBoxHumCalS1.Name = "textBoxHumCalS1";
            this.textBoxHumCalS1.Size = new System.Drawing.Size(54, 20);
            this.textBoxHumCalS1.TabIndex = 37;
            // 
            // textBoxHumCalO1
            // 
            this.textBoxHumCalO1.Location = new System.Drawing.Point(208, 44);
            this.textBoxHumCalO1.Name = "textBoxHumCalO1";
            this.textBoxHumCalO1.Size = new System.Drawing.Size(54, 20);
            this.textBoxHumCalO1.TabIndex = 36;
            // 
            // textBoxTempCalS1
            // 
            this.textBoxTempCalS1.Location = new System.Drawing.Point(127, 43);
            this.textBoxTempCalS1.Name = "textBoxTempCalS1";
            this.textBoxTempCalS1.Size = new System.Drawing.Size(54, 20);
            this.textBoxTempCalS1.TabIndex = 35;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(6, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 18);
            this.label7.TabIndex = 34;
            this.label7.Text = "Device 1:";
            // 
            // textBoxTempCalO1
            // 
            this.textBoxTempCalO1.Location = new System.Drawing.Point(67, 43);
            this.textBoxTempCalO1.Name = "textBoxTempCalO1";
            this.textBoxTempCalO1.Size = new System.Drawing.Size(54, 20);
            this.textBoxTempCalO1.TabIndex = 33;
            // 
            // buttonApply
            // 
            this.buttonApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonApply.Location = new System.Drawing.Point(206, 262);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(102, 23);
            this.buttonApply.TabIndex = 4;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.ButtonApplyClick);
            // 
            // advancedsettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(424, 292);
            this.Controls.Add(this.CalTab);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "advancedsettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UTAC :: Settings";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTempMin2)).EndInit();
            this.CalTab.ResumeLayout(false);
            this.GeneralTab.ResumeLayout(false);
            this.groupBoxCalibration.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHumidityCorrection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTempCorrection)).EndInit();
            this.groupBoxComPort.ResumeLayout(false);
            this.groupBoxDebug.ResumeLayout(false);
            this.groupBoxUTACStart.ResumeLayout(false);
            this.OutputAndTimerTab.ResumeLayout(false);
            this.groupBoxGraph.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGraphScaleMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGraphScaleMin)).EndInit();
            this.groupBoxAverageSystem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAverageInterval)).EndInit();
            this.groupBoxOutput.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownlistItems)).EndInit();
            this.groupBoxTimer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.timercount)).EndInit();
            this.RecordingTab.ResumeLayout(false);
            this.RecordingTab.PerformLayout();
            this.groupBoxFileRecordingFormat.ResumeLayout(false);
            this.FTPTab.ResumeLayout(false);
            this.FTPTab.PerformLayout();
            this.WebUrlTab.ResumeLayout(false);
            this.WebUrlTab.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.BuiltInWebServerTab.ResumeLayout(false);
            this.groupBoxBIWXML.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.updownBIWXMLPort)).EndInit();
            this.groupBoxBIW.ResumeLayout(false);
            this.groupBoxBIW.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updownBIWPort)).EndInit();
            this.ProxyTab.ResumeLayout(false);
            this.groupBoxProxySettings.ResumeLayout(false);
            this.groupBoxProxySettings.PerformLayout();
            this.LanguageTab.ResumeLayout(false);
            this.groupBoxLanguage.ResumeLayout(false);
            this.tabPageAlertSystem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTempMin4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTempMax4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHumMin4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHumMax4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTempMin3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTempMax3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHumMin3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHumMax3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTempMax2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHumMin2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHumMax2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTempMin1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTempMax1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHumMin1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHumMax1)).EndInit();
            this.tabPageEMail.ResumeLayout(false);
            this.groupBoxEMailSMTPSettings.ResumeLayout(false);
            this.groupBoxEMailSMTPSettings.PerformLayout();
            this.tabGraphing.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.CalTabPage.ResumeLayout(false);
            this.CalTabPage.PerformLayout();
            this.ResumeLayout(false);

		}
		private System.Windows.Forms.Button buttonEMailTest;
		private System.Windows.Forms.Label labelGraphMin;
		private System.Windows.Forms.Label labelGraphMax;
		private System.Windows.Forms.Label labelFTPRequire;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown numericUpDownGraphScaleMin;
		private System.Windows.Forms.NumericUpDown numericUpDownGraphScaleMax;
		private System.Windows.Forms.GroupBox groupBoxGraph;
		private System.Windows.Forms.GroupBox groupBoxAverageSystem;
		private System.Windows.Forms.CheckBox checkBoxAverageGraph;
		private System.Windows.Forms.CheckBox checkBoxAverageList;
		private System.Windows.Forms.NumericUpDown numericUpDownAverageInterval;
		private System.Windows.Forms.ComboBox comboBoxAverageType;
		private System.Windows.Forms.Label labelAverageInterval;
		private System.Windows.Forms.CheckBox checkBoxAutoSizeGraph;
		private System.Windows.Forms.NumericUpDown numericUpDownHumMax1;
        private System.Windows.Forms.NumericUpDown numericUpDownHumMin1;
		private System.Windows.Forms.TabPage tabPageAlertSystem;
		private System.Windows.Forms.TabPage ProxyTab;
		private System.Windows.Forms.GroupBox groupBoxUTACStart;
		private System.Windows.Forms.TabPage tabPageEMail;
		private System.Windows.Forms.GroupBox groupBoxEMailSMTPSettings;
		private System.Windows.Forms.Label labelEMailReceipientAddress;
		private System.Windows.Forms.Label labelEMailFromAddress;
		private System.Windows.Forms.Label labelEMailPassword;
		private System.Windows.Forms.Label labelEMailUsername;
		private System.Windows.Forms.Label labelEMailServerPort;
		private System.Windows.Forms.TextBox textBoxEmailReceipientAddress;
		private System.Windows.Forms.TextBox textBoxEmailFromAddress;
		private System.Windows.Forms.TextBox textBoxEmailPassword;
		private System.Windows.Forms.TextBox textBoxEmailUsername;
		private System.Windows.Forms.TextBox textBoxEmailPort;
        private System.Windows.Forms.TextBox textBoxEmailServer;
        private System.Windows.Forms.CheckBox checkBoxHumAlertEMailNotify1;
		private System.Windows.Forms.Label labelCalibrationHumidity;
		private System.Windows.Forms.Label labelCalibrationTemperature;
		private System.Windows.Forms.GroupBox groupBoxCalibration;
		private System.Windows.Forms.CheckBox checkBoxFTPUploadGraph;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.CheckBox checkBoxStartMinimized;
		private System.Windows.Forms.CheckBox checkBoxAutoStart;
		private System.Windows.Forms.TabPage GeneralTab;
		private System.Windows.Forms.NumericUpDown numericUpDownHumidityCorrection;
		private System.Windows.Forms.NumericUpDown numericUpDownTempCorrection;
		private System.Windows.Forms.GroupBox groupBoxComPort;
		private System.Windows.Forms.GroupBox groupBoxProxySettings;
		private System.Windows.Forms.Label labelProxyPassword;
		private System.Windows.Forms.Label labelProxyUsername;
		private System.Windows.Forms.Label labelProxyServer;
		private System.Windows.Forms.GroupBox groupBoxDebug;
		private System.Windows.Forms.GroupBox groupBoxOutput;
		private System.Windows.Forms.GroupBox groupBoxTimer;
		private System.Windows.Forms.Label labelTimerSeconds;
		private System.Windows.Forms.Label labelTimerInterval;
		private System.Windows.Forms.GroupBox groupBoxFileRecordingFormat;
		private System.Windows.Forms.Label labelFileRecordingPath;
		private System.Windows.Forms.Label labelFTPUploadDir;
		private System.Windows.Forms.Label labelFTPUsername;
		private System.Windows.Forms.Label labelFTPPassword;
		private System.Windows.Forms.Label labelFTPServer;
        private System.Windows.Forms.Label labelURLText2;
		private System.Windows.Forms.Label labelURL;
		private System.Windows.Forms.Label labelBIWPort;
		private System.Windows.Forms.Label labelBIWTitle;
		private System.Windows.Forms.GroupBox groupBoxLanguage;
		private System.Windows.Forms.Label labelChooseCOMPort;
		private System.Windows.Forms.CheckBox checkBoxTEMPerAutoDetect;
		private System.Windows.Forms.GroupBox groupBoxBIW;
		private System.Windows.Forms.GroupBox groupBoxBIWXML;
		private System.Windows.Forms.Label labelBIWXMLPort;
		private System.Windows.Forms.Label labelMaxitems;
		private System.Windows.Forms.ComboBox comboBoxCOMPorts;
		private System.Windows.Forms.Button buttonFolderSelect;
		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonApply;
		private System.Windows.Forms.NumericUpDown numericUpDownlistItems;
		private System.Windows.Forms.TextBox textBoxBIW;
		private System.Windows.Forms.CheckBox checkBoxBIWXMLRefresh;
		private System.Windows.Forms.CheckBox checkBoxBIWEnableRefresh;
		private System.Windows.Forms.CheckBox checkBoxBIWXMLActivated;
		private System.Windows.Forms.NumericUpDown updownBIWXMLPort;
		private System.Windows.Forms.Button buttonUrlGrabTest;
		private System.Windows.Forms.TabPage OutputAndTimerTab;
		private System.Windows.Forms.TabPage RecordingTab;
		private System.Windows.Forms.TabPage FTPTab;
		private System.Windows.Forms.TabPage WebUrlTab;
		private System.Windows.Forms.Label labelLFILanguage;
		private System.Windows.Forms.Label labelLFSIAuthor;
		private System.Windows.Forms.Label labelLFIVersion;
		private System.Windows.Forms.Label labelLFIDate;
		private System.Windows.Forms.Label labelLFIAuthorVal;
		private System.Windows.Forms.Label labelLFSIAuthorwwwVal;
		private System.Windows.Forms.Label labelLFIAuthormailVal;
		private System.Windows.Forms.Label labelLFIDateVal;
		private System.Windows.Forms.Label labelLFILanguageVal;
		private System.Windows.Forms.Label labelLFIVersionVal;
		private System.Windows.Forms.ListBox listBoxLangFile;
		private System.Windows.Forms.TextBox textBoxproxyusername;
		private System.Windows.Forms.TextBox textBoxproxypassword;
		private System.Windows.Forms.NumericUpDown updownBIWPort;
		private System.Windows.Forms.CheckBox checkBoxBIWActivated;
		private System.Windows.Forms.CheckBox checkBoxLog;
		private System.Windows.Forms.RadioButton radioFahrenheit;
		private System.Windows.Forms.RadioButton radioCelsius;
		private System.Windows.Forms.TabPage LanguageTab;
		private System.Windows.Forms.TabPage BuiltInWebServerTab;
        private System.Windows.Forms.TabControl CalTab;
		private System.Windows.Forms.TextBox textBoxURL;
        private System.Windows.Forms.CheckBox checkBoxURLactivated;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox textBox_ftpserver;
		private System.Windows.Forms.TextBox textBox_ftpuser;
		private System.Windows.Forms.TextBox textBox_ftppass;
		private System.Windows.Forms.CheckBox checkBoxftp;
		private System.Windows.Forms.Button buttonftptest;
		private System.Windows.Forms.TextBox textBox_ftpuploaddir;
		private System.Windows.Forms.TextBox textBox_ftpport;
		private System.Windows.Forms.TextBox textboxpath;
		private System.Windows.Forms.CheckBox checkboxrecordtofile;
		private System.Windows.Forms.CheckBox checkboxdailyfiles;
		private System.Windows.Forms.RadioButton radioCSV;
		private System.Windows.Forms.RadioButton radioTXT;
		private System.Windows.Forms.CheckBox checkboxlist;
		private System.Windows.Forms.CheckBox checkboxgraph;
		private System.Windows.Forms.NumericUpDown timercount;
		private System.Windows.Forms.CheckBox checkboxtimer;
		private System.Windows.Forms.CheckBox checkBoxuseauth;
		private System.Windows.Forms.CheckBox checkBoxproxy;
		private System.Windows.Forms.TextBox textBoxproxyport;
		private System.Windows.Forms.TextBox textBoxproxyserver;
		private System.Windows.Forms.CheckBox checkBoxfaketemper;
		private System.Windows.Forms.CheckBox checkBoxdebug;
        private System.Windows.Forms.TabPage tabGraphing;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxDeviceName1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxDeviceName4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxDeviceName3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxDeviceName2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage CalTabPage;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBoxHumCalS4;
        private System.Windows.Forms.TextBox textBoxHumCalO4;
        private System.Windows.Forms.TextBox textBoxTempCalS4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxTempCalO4;
        private System.Windows.Forms.TextBox textBoxHumCalS3;
        private System.Windows.Forms.TextBox textBoxHumCalO3;
        private System.Windows.Forms.TextBox textBoxTempCalS3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxTempCalO3;
        private System.Windows.Forms.TextBox textBoxHumCalS2;
        private System.Windows.Forms.TextBox textBoxHumCalO2;
        private System.Windows.Forms.TextBox textBoxTempCalS2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxTempCalO2;
        private System.Windows.Forms.TextBox textBoxHumCalS1;
        private System.Windows.Forms.TextBox textBoxHumCalO1;
        private System.Windows.Forms.TextBox textBoxTempCalS1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxTempCalO1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox WUG_Active;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox WUG_PW;
        private System.Windows.Forms.TextBox WUG_ID;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.CheckBox checkBoxTempAlertOnscreenNotify1;
        private System.Windows.Forms.CheckBox checkBoxTempAlertEMailNotify1;
        private System.Windows.Forms.NumericUpDown numericUpDownTempMin1;
        private System.Windows.Forms.NumericUpDown numericUpDownTempMax1;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.CheckBox checkBoxTempAlertOnscreenNotify2;
        private System.Windows.Forms.CheckBox checkBoxHumAlertEMailNotify2;
        private System.Windows.Forms.CheckBox checkBoxTempAlertEMailNotify2;
        private System.Windows.Forms.NumericUpDown numericUpDownTempMax2;
        private System.Windows.Forms.NumericUpDown numericUpDownHumMin2;
        private System.Windows.Forms.NumericUpDown numericUpDownHumMax2;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.CheckBox checkBoxTempAlertOnscreenNotify4;
        private System.Windows.Forms.CheckBox checkBoxHumAlertEMailNotify4;
        private System.Windows.Forms.CheckBox checkBoxTempAlertEMailNotify4;
        private System.Windows.Forms.NumericUpDown numericUpDownTempMin4;
        private System.Windows.Forms.NumericUpDown numericUpDownTempMax4;
        private System.Windows.Forms.NumericUpDown numericUpDownHumMin4;
        private System.Windows.Forms.NumericUpDown numericUpDownHumMax4;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.CheckBox checkBoxTempAlertOnscreenNotify3;
        private System.Windows.Forms.CheckBox checkBoxHumAlertEMailNotify3;
        private System.Windows.Forms.CheckBox checkBoxTempAlertEMailNotify3;
        private System.Windows.Forms.NumericUpDown numericUpDownTempMin3;
        private System.Windows.Forms.NumericUpDown numericUpDownTempMax3;
        private System.Windows.Forms.NumericUpDown numericUpDownHumMin3;
        private System.Windows.Forms.NumericUpDown numericUpDownHumMax3;
        private System.Windows.Forms.CheckBox checkBoxHumAlertOnscreenNotify1;
        private System.Windows.Forms.CheckBox checkBoxHumAlertOnscreenNotify2;
        private System.Windows.Forms.NumericUpDown numericUpDownTempMin2;
        private System.Windows.Forms.CheckBox checkBoxHumAlertOnscreenNotify3;
        private System.Windows.Forms.CheckBox checkBoxHumAlertOnscreenNotify4;
        private System.Windows.Forms.CheckBox checkBoxrebootonerror;
		
	
	}
}
