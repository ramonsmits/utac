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
 * FileName: 	AlertForm.cs
 * Namespace: 	utac.Components.AlertSystem
 * Author: 		bof (bjoern@n4rf.net)
 * Created: 	2008-05-14
 * -----------------------------------------------------------------------
 * -------------------------------------------------------- Description *-
 * -----------------------------------------------------------------------
 * Form and Working Class for the Alert System
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using utac.Components.Settings;
using utac.Components.TEMPer;
using utac.Components.Mail;

namespace utac.Components.AlertSystem
{
    /// <summary>
    /// Description of AlertForm.
    /// </summary>
    public partial class AlertForm : Form
    {
        public AlertForm()
        {
            InitializeComponent();
        }

        void ButtonCloseClick(object sender, EventArgs e)
        {
            Hide();
        }

        public bool CheckAll()
        {
            bool k = false;
            if (GlobalVars.devicecount > 0)
                k = CheckMinMax(0, GlobalVars.config_alert_tempmax1, GlobalVars.config_alert_tempmin1, GlobalVars.config_alert_hummax1,
                  GlobalVars.config_alert_hummin1, GlobalVars.config_devicename1, GlobalVars.config_alert_tempemail1,
                  GlobalVars.config_alert_temponscreen1, GlobalVars.config_alert_humemail1, GlobalVars.config_alert_humonscreen1);
            if (GlobalVars.devicecount > 1)
                k = CheckMinMax(1, GlobalVars.config_alert_tempmax2, GlobalVars.config_alert_tempmin2, GlobalVars.config_alert_hummax2,
                    GlobalVars.config_alert_hummin2, GlobalVars.config_devicename2, GlobalVars.config_alert_tempemail2,
                    GlobalVars.config_alert_temponscreen2, GlobalVars.config_alert_humemail2, GlobalVars.config_alert_humonscreen2);
            if (GlobalVars.devicecount > 2)
                k = CheckMinMax(2, GlobalVars.config_alert_tempmax3, GlobalVars.config_alert_tempmin3, GlobalVars.config_alert_hummax3,
                    GlobalVars.config_alert_hummin3, GlobalVars.config_devicename3, GlobalVars.config_alert_tempemail3,
                    GlobalVars.config_alert_temponscreen3, GlobalVars.config_alert_humemail3, GlobalVars.config_alert_humonscreen3);
            if (GlobalVars.devicecount > 4)
                k = CheckMinMax(0, GlobalVars.config_alert_tempmax4, GlobalVars.config_alert_tempmin4, GlobalVars.config_alert_hummax4,
                    GlobalVars.config_alert_hummin4, GlobalVars.config_devicename4, GlobalVars.config_alert_tempemail4,
                    GlobalVars.config_alert_temponscreen4, GlobalVars.config_alert_humemail4, GlobalVars.config_alert_humonscreen4);

            return k;
        }

        public bool CheckMinMax(int devno, double tmax, double tmin, double hmax, double hmin, string devname, bool alerttem, bool alerttos, bool alerthem, bool alerthos)
        {
            Text = "UTAC :: " + GlobalVars.lang_alertsystem;
            buttonClose.Text = GlobalVars.lang_close;
            bool alertTempMax = false;
            bool alertHumMax = false;
            bool alertTempMin = false;
            bool alertHumMin = false;
            double actTemp = -99;
            double actHum = -99;

            string msgText = "";

            if (GlobalVars.currenthum.Length > devno)
            {
                actHum = TEMPerInterface.getHumDouble(GlobalVars.currenthum[devno]);
                if (hmax <= actHum) { alertHumMax = true; }
                if (hmin >= actHum) { alertHumMin = true; }
            }
            if (GlobalVars.currenttemp.Length > devno)
            {
                actTemp = TEMPerInterface.getTempDoubleNC(GlobalVars.currenttemp[devno]);
                if (tmax <= actTemp) { alertTempMax = true; }
                if (tmin >= actTemp) { alertTempMin = true; }
            }

            if (devname.Length > 2)
                msgText += devname + " Reports:\r\n";

            msgText += "As of " + GlobalVars.currentts[devno].ToString() + " Temp = " + TEMPerInterface.getTempFullTextShortNC(actTemp) + " and Humidity = " + TEMPerInterface.getHumFullTextShort(actHum) + ".\r\n";
            if (GlobalVars.config_alert_tempemail1)
            {
                if (alertTempMax) { msgText += "This is above the maximum Temperature limit of " + tmax.ToString() + ".\r\n"; }
                if (alertTempMin) { msgText += "This is below the minimum Temperature limit of " + tmin.ToString() + ".\r\n"; }
            }
            if (GlobalVars.config_alert_humemail1)
            {
                if (alertHumMax) { msgText += "This is above the maximum Humidity limit of " + hmax.ToString() + ".\r\n"; }
                if (alertHumMin) { msgText += "This is below the minimum Humidity limit of " + hmin.ToString() + ".\r\n"; }
            }


            if (alertTempMax && alerttem)
            {
                SendMail.Send(GlobalVars.lang_maxtempalarm + " ("
                              + TEMPerInterface.getTempFullTextShortNC(actTemp) + " | "
                              + GlobalVars.currentts[devno].ToString() + ")", msgText, false);
            }
            else if (alertHumMax && alerthem)
            {
                SendMail.Send(GlobalVars.lang_maxhumalarm + " ("
                              + TEMPerInterface.getHumFullTextShort(actHum) + " | "
                              + GlobalVars.currentts[devno].ToString() + ")", msgText, false);
            }
            else if (alertTempMin && alerttem)
            {
                SendMail.Send(GlobalVars.lang_mintempalarm + " ("
                              + TEMPerInterface.getTempFullTextShortNC(actTemp) + " | "
                              + GlobalVars.currentts[devno].ToString() + ")", msgText, false);
            }
            else if (alertHumMin && alerthem)
            {
                SendMail.Send(GlobalVars.lang_minhumalarm + " ("
                              + TEMPerInterface.getHumFullTextShort(actHum) + " | "
                              + GlobalVars.currentts[devno].ToString() + ")", msgText, false);
            }



            if (((alertTempMax || alertTempMin) && alerttos)
               || ((alertHumMax || alertHumMin) && alerthos))
            {

                listBoxAlert.Items.Clear();

                if (alertTempMax && alerttos)
                {
                    listBoxAlert.Items.Add(GlobalVars.lang_maxtempalarm + " ("
                                           + TEMPerInterface.getTempFullTextShortNC(actTemp) + " | "
                                           + GlobalVars.currentts[devno].ToString() + ")");

                }
                if (alertHumMax && alerthos)
                {
                    listBoxAlert.Items.Add(GlobalVars.lang_maxhumalarm + " ("
                                           + TEMPerInterface.getHumFullTextShort(actHum) + " | "
                                           + GlobalVars.currentts[devno].ToString() + ")");
                }
                if (alertTempMin && alerttos)
                {
                    listBoxAlert.Items.Add(GlobalVars.lang_mintempalarm + " ("
                                           + TEMPerInterface.getTempFullTextShortNC(actTemp) + " | "
                                           + GlobalVars.currentts[devno].ToString() + ")");
                }
                if (alertHumMin && alerthos)
                {
                    listBoxAlert.Items.Add(GlobalVars.lang_minhumalarm + " ("
                                           + TEMPerInterface.getHumFullTextShort(actHum) + " | "
                                           + GlobalVars.currentts[devno].ToString() + ")");
                }

                SetBounds((Screen.GetBounds(this).Width / 2) - (this.Width / 2),
                          (Screen.GetBounds(this).Height / 2) - (this.Height / 2),
                          this.Width, this.Height, BoundsSpecified.Location);

                this.ShowDialog();

                return (true);

            }
            return (false);
        }

        public bool Check()
        {
            Text = "UTAC :: " + GlobalVars.lang_alertsystem;
            buttonClose.Text = GlobalVars.lang_close;
            bool alertTempMax = false;
            bool alertHumMax = false;
            bool alertTempMin = false;
            bool alertHumMin = false;
            double actTemp = -99;
            double actHum = -99;

            string msgText = "";

            if (GlobalVars.currenthum.Length > 0)
            {
                actHum = TEMPerInterface.getHumDouble(GlobalVars.currenthum[0]);
                if (GlobalVars.config_alert_hummax1 <= actHum) { alertHumMax = true; }
                if (GlobalVars.config_alert_hummin1 >= actHum) { alertHumMin = true; }
            }
            if (GlobalVars.currenttemp.Length > 0)
            {
                actTemp = TEMPerInterface.getTempDoubleNC(GlobalVars.currenttemp[0]);
                if (GlobalVars.config_alert_tempmax1 <= actTemp) { alertTempMax = true; }
                if (GlobalVars.config_alert_tempmin1 >= actTemp) { alertTempMin = true; }
            }

            if (GlobalVars.config_devicename1.Length > 2)
                msgText += GlobalVars.config_devicename1 + " Reports:\r\n";

            msgText += "As of " + GlobalVars.currentts[0].ToString() + " Temp = " + TEMPerInterface.getTempFullTextShortNC(actTemp) + " and Humidity = " + TEMPerInterface.getHumFullTextShort(actHum) + ".\r\n";
            if (GlobalVars.config_alert_tempemail1)
            {
                if (alertTempMax) { msgText += "This is above the maximum Temperature limit of " + GlobalVars.config_alert_tempmax1.ToString() + ".\r\n"; }
                if (alertTempMin) { msgText += "This is below the minimum Temperature limit of " + GlobalVars.config_alert_tempmin1.ToString() + ".\r\n"; }
            }
            if (GlobalVars.config_alert_humemail1)
            {
                if (alertHumMax) { msgText += "This is above the maximum Humidity limit of " + GlobalVars.config_alert_hummax1.ToString() + ".\r\n"; }
                if (alertHumMin) { msgText += "This is below the minimum Humidity limit of " + GlobalVars.config_alert_hummin1.ToString() + ".\r\n"; }
            }


            if (alertTempMax && GlobalVars.config_alert_tempemail1)
            {
                SendMail.Send(GlobalVars.lang_maxtempalarm + " ("
                              + TEMPerInterface.getTempFullTextShortNC(actTemp) + " | "
                              + GlobalVars.currentts[0].ToString() + ")", msgText, false);
            }
            else if (alertHumMax && GlobalVars.config_alert_humemail1)
            {
                SendMail.Send(GlobalVars.lang_maxhumalarm + " ("
                              + TEMPerInterface.getHumFullTextShort(actHum) + " | "
                              + GlobalVars.currentts[0].ToString() + ")", msgText, false);
            }
            else if (alertTempMin && GlobalVars.config_alert_tempemail1)
            {
                SendMail.Send(GlobalVars.lang_mintempalarm + " ("
                              + TEMPerInterface.getTempFullTextShortNC(actTemp) + " | "
                              + GlobalVars.currentts[0].ToString() + ")", msgText, false);
            }
            else if (alertHumMin && GlobalVars.config_alert_humemail1)
            {
                SendMail.Send(GlobalVars.lang_minhumalarm + " ("
                              + TEMPerInterface.getHumFullTextShort(actHum) + " | "
                              + GlobalVars.currentts[0].ToString() + ")", msgText, false);
            }



            if (((alertTempMax || alertTempMin) && GlobalVars.config_alert_temponscreen1)
               || ((alertHumMax || alertHumMin) && GlobalVars.config_alert_humonscreen1))
            {

                listBoxAlert.Items.Clear();

                if (alertTempMax && GlobalVars.config_alert_temponscreen1)
                {
                    listBoxAlert.Items.Add(GlobalVars.lang_maxtempalarm + " ("
                                           + TEMPerInterface.getTempFullTextShortNC(actTemp) + " | "
                                           + GlobalVars.currentts[0].ToString() + ")");

                }
                if (alertHumMax && GlobalVars.config_alert_humonscreen1)
                {
                    listBoxAlert.Items.Add(GlobalVars.lang_maxhumalarm + " ("
                                           + TEMPerInterface.getHumFullTextShort(actHum) + " | "
                                           + GlobalVars.currentts[0].ToString() + ")");
                }
                if (alertTempMin && GlobalVars.config_alert_temponscreen1)
                {
                    listBoxAlert.Items.Add(GlobalVars.lang_mintempalarm + " ("
                                           + TEMPerInterface.getTempFullTextShortNC(actTemp) + " | "
                                           + GlobalVars.currentts[0].ToString() + ")");
                }
                if (alertHumMin && GlobalVars.config_alert_humonscreen1)
                {
                    listBoxAlert.Items.Add(GlobalVars.lang_minhumalarm + " ("
                                           + TEMPerInterface.getHumFullTextShort(actHum) + " | "
                                           + GlobalVars.currentts[0].ToString() + ")");
                }

                SetBounds((Screen.GetBounds(this).Width / 2) - (this.Width / 2),
                          (Screen.GetBounds(this).Height / 2) - (this.Height / 2),
                          this.Width, this.Height, BoundsSpecified.Location);

                this.ShowDialog();

                return (true);

            }
            return (false);
        }
    }
}
