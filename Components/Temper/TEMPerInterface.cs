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
 * FileName: 	TEMPerInterface.cs
 * Namespace: 	utac.Components.TEMPer
 * Author: 		bof (bjoern@n4rf.de)
 * Created: 	2008-02-27
 * -----------------------------------------------------------------------
 * -------------------------------------------------------- Description *-
 * -----------------------------------------------------------------------
 * The Communication Interface for the TEMPer
 */

using System;
using System.Collections.Generic;
using System.Collections;
using System.IO.Ports;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using utac.Components.Settings;
using System.IO;

namespace utac.Components.TEMPer
{
    public class TEMPerInterface
    {
        private readonly String m_PortName = null;
        public SerialPort m_SerialPort = null;
        private readonly int m_HIDDev = -1;
        private String m_CHic = null;
        private bool m_Init = false;
        private static readonly string LogFileName = "LOG-TEMPERINTERFACE.txt";
        private static readonly double myMinValue = -99;

        private decimal volt1 = 0;
        private String PGAGain = "1";

        public ArrayList timestamps = new ArrayList(0);
        public ArrayList utctimestamps = new ArrayList(0);
        public ArrayList temps = new ArrayList(0);
        public ArrayList hums = new ArrayList(0);


        //MIN MAX VARS NEW VERISON 0.1.2
        public double tmax = -999;
        public double tmin = 999;
        public string tmax_date = "";
        public string tmin_date = "";

        public double hmax = -999;
        public double hmin = 999;
        public string hmax_date = "";
        public string hmin_date = "";

        public bool hadBadReading = false;

        public string DeviceName = "n/a";

        #region Static Methods

        public static double CtoF(double celsius)
        {
            return (9 * celsius / 5 + 32);
        }


        public static double getTempDouble(object temp)
        {
            double tmpDouble;
            if (GlobalVars.config_fahrenheit)
            {
                tmpDouble = CtoF(Convert.ToDouble(temp));
            }
            else
            {
                tmpDouble = Convert.ToDouble(temp);
            }
            return tmpDouble;
        }

        // No Conversion, used in temperature min/max processing.
        public static double getTempDoubleNC(object temp)
        {
            double tmpDouble;
            tmpDouble = Convert.ToDouble(temp);
            return tmpDouble;
        }

        public static double getHumDouble(object hum)
        {
            double humDouble;
            humDouble = Convert.ToDouble(hum);
            return humDouble;
        }



        public static string getTempFullText(object temp)
        {
            double tmpDouble;
            string tmpString;
            tmpDouble = Convert.ToDouble(temp);
            if (tmpDouble == -99) tmpString = "-";
            else
            {
                if (GlobalVars.config_fahrenheit)
                {
                    tmpDouble = CtoF(Convert.ToDouble(temp));
                    tmpString = tmpDouble.ToString("###0.0000") + " °F";
                }
                else
                {
                    tmpDouble = Convert.ToDouble(temp);
                    tmpString = tmpDouble.ToString("###0.0000") + " °C";
                }
            }
            return tmpString;
        }


        public static string getTempFullTextHTML(object temp)
        {
            double tmpDouble;
            string tmpString;
            tmpDouble = Convert.ToDouble(temp);
            if (tmpDouble == -99) tmpString = "-";
            else
            {
                if (GlobalVars.config_fahrenheit)
                {
                    tmpDouble = CtoF(Convert.ToDouble(temp));
                    tmpString = tmpDouble.ToString("###0.0000") + " &deg;F";
                }
                else
                {
                    tmpDouble = Convert.ToDouble(temp);
                    tmpString = tmpDouble.ToString("###0.0000") + " &deg;C";
                }
            }
            return tmpString;
        }


        public static string getTempFullTextShortHTML(object temp)
        {
            double tmpDouble;
            string tmpString;
            tmpDouble = Convert.ToDouble(temp);
            if (tmpDouble == -99) tmpString = "-";
            else
            {
                if (GlobalVars.config_fahrenheit)
                {
                    tmpDouble = CtoF(Convert.ToDouble(temp));
                    tmpString = tmpDouble.ToString("###0.00") + " &deg;F";
                }
                else
                {
                    tmpDouble = Convert.ToDouble(temp);
                    tmpString = tmpDouble.ToString("###0.00") + " &deg;C";
                }
            }
            return tmpString;
        }

        public static string getHumFullTextHTML(object hum)
        {
            double tmpDouble;
            string tmpString;
            tmpDouble = Convert.ToDouble(hum);
            if (tmpDouble == -99) tmpString = "-";
            else tmpString = tmpDouble.ToString("###0.0000") + " %";
            return tmpString;
        }


        public static string getHumFullText(object hum)
        {
            double tmpDouble;
            string tmpString;
            tmpDouble = Convert.ToDouble(hum);
            if (tmpDouble == -99) tmpString = "-";
            else tmpString = tmpDouble.ToString("###0.0000") + " %";
            return tmpString;
        }


        public static string getHumFullTextShortHTML(object hum)
        {
            double tmpDouble;
            string tmpString;
            tmpDouble = Convert.ToDouble(hum);
            if (tmpDouble == -99) tmpString = "-";
            else tmpString = tmpDouble.ToString("###0.00") + " %";
            return tmpString;
        }


        public static string getHumFullTextShort(object hum)
        {
            string tmpString;
            double tmpDouble;
            tmpDouble = Convert.ToDouble(hum);
            if (tmpDouble == -99) tmpString = "-";
            else tmpString = tmpDouble.ToString("###0.00") + " %";
            return tmpString;
        }



        public static string getTempFullTextShort(object temp)
        {
            double tmpDouble;
            string tmpString;
            tmpDouble = Convert.ToDouble(temp);
            if (tmpDouble == -99) tmpString = "-";
            else
            {
                if (GlobalVars.config_fahrenheit)
                {
                    tmpDouble = CtoF(Convert.ToDouble(temp));
                    tmpString = tmpDouble.ToString("###0.00") + " °F";
                }
                else
                {
                    tmpDouble = Convert.ToDouble(temp);
                    tmpString = tmpDouble.ToString("###0.00") + " °C";
                }
            }
            return tmpString;
        }

        public static string getTempFullTextShortNC(object temp)
        {
            double tmpDouble;
            string tmpString;
            tmpDouble = Convert.ToDouble(temp);
            if (tmpDouble == -99) tmpString = "-";
            else
            {

                tmpDouble = Convert.ToDouble(temp);
                tmpString = tmpDouble.ToString("###0.00") + " °C";

            }
            return tmpString;
        }

        // Imported functions for the HID TEMPer device
        [DllImport("HidFTDll.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern void EMyCloseDevice();

        [DllImport("HidFTDll.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int EMyDetectDevice(long myhwnd);

        [DllImport("HidFTDll.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern bool EMyInitConfig(bool dOrc);

        [DllImport("HidFTDll.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern bool EMyReadEP(ref byte up1, ref byte up2, ref byte up3, ref byte up4, ref byte up5, ref byte up6);

        [DllImport("HidFTDll.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern bool EMyReadHid([MarshalAs(UnmanagedType.AnsiBStr)] ref string pcBuffer, byte btUrlIndex, int btUrlLen);

        [DllImport("HidFTDll.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern double EMyReadTemp(bool flag);

        [DllImport("HidFTDll.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern void EMySetCurrentDev(int nCurDev);

        [DllImport("HidFTDll.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern bool EMyWriteEP(ref byte fd1, ref byte fd2, ref byte fd3, ref byte fd4, ref byte fd5);

        [DllImport("HidFTDll.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern bool EMyWriteHid(ref char[] pcBuffer, byte btUrlIndex, int btUrlLen);

        [DllImport("HidFTDll.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern bool EMyWriteTempText(bool flag);

        [DllImport("kernel32.dll")]
        internal static extern Boolean GetCommProperties(IntPtr hFile, out COMMPROP cp);
        [StructLayout(LayoutKind.Sequential)]
        internal struct COMMPROP
        {
            internal UInt16 wPacketLength;
            internal UInt16 wPacketVersion;
            internal UInt32 dwServiceMask;
            internal UInt32 dwReserved1;
            internal UInt32 dwMaxTxQueue;
            internal UInt32 dwMaxRxQueue;
            internal UInt32 dwMaxBaud;
            internal UInt32 dwProvSubType;
            internal UInt32 dwProvCapabilities;
            internal UInt32 dwSettableParams;
            internal UInt32 dwSettableBaud;
            internal UInt16 wSettableData;
            internal UInt16 wSettableStopParity;
            internal UInt32 dwCurrentTxQueue;
            internal UInt32 dwCurrentRxQueue;
            internal UInt32 dwProvSpec1;
            internal UInt32 dwProvSpec2;
            internal Byte wcProvChar;
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern IntPtr CreateFile(String lpFileName,
                                                 UInt32 dwDesiredAccess, UInt32 dwShareMode,
                                                 IntPtr lpSecurityAttributes, UInt32 dwCreationDisposition,
                                                 UInt32 dwFlagsAndAttributes, IntPtr hTemplateFile);

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool CloseHandle(IntPtr hObject);

        [DllImport("user32.dll")]
        public static extern int ExitWindowsEx(int uFlags, int dwReason);

        public static bool CheckCOMPort(String COMPort)
        {
            try
            {
                IntPtr m_Port = CreateFile(COMPort, 0xC0000000u, 3u, IntPtr.Zero, 3u, 0x800u, IntPtr.Zero);
                if (m_Port.ToInt32() == -1) return false;

                COMMPROP m_CommProp;
                m_CommProp.dwProvSpec2 = 0;
                m_CommProp.wPacketLength = 64;
                m_CommProp.dwProvSpec1 = 0xE73CF52E;

                GetCommProperties(m_Port, out m_CommProp);

                CloseHandle(m_Port);
                log("COMMPROP:" + m_CommProp.dwProvSpec2);
                return m_CommProp.dwProvSpec2 == 1128813859 || m_CommProp.dwProvSpec2 == 1128813842;


            }
            catch (Exception e)
            {
                if (GlobalVars.config_log)
                {
                    log(e.Message);
                }
            }

            return false;
        }

        public static bool CommPortExists(String COMPort)
        {
            foreach (String Port in SerialPort.GetPortNames())
                if (COMPort == Port) return true;

            return false;
        }

        public static String[] FindDevices(IntPtr hndl)
        {
            List<String> found_ports = new List<String>();

            String[] ports = SerialPort.GetPortNames();
            if (ports == null) return null;

            for (int i = 0; i < ports.Length; i++)
            {
                String PortName = @"\\.\" + ports[i] + "\0";

                if (CheckCOMPort(PortName))
                    found_ports.Add(ports[i]);
            }

            // Find the HID devices
            int devCount = EMyDetectDevice((long)hndl);
            for (int iDev = 0; iDev < devCount; iDev++)
            {
                found_ports.Add("HID Device " + iDev.ToString());
            }

            found_ports.Sort();

            return found_ports.ToArray();
        }

        private double ReadSHT(string TH)
        {
            string str_temp = "";
            int xxx = 0;
            string str_msb = "";
            string str_lsb = "";

            try
            {

                if (m_SerialPort == null)
                {
                    log("Error - no serial port.");
                    return myMinValue;
                }

                // if (m_SerialPort.IsOpen) m_SerialPort.Close();

                if (!m_SerialPort.IsOpen)
                {
                    m_SerialPort.Open();
                }
                if (!m_SerialPort.IsOpen)
                {
                    log("Error Opening Serial Port.");
                    return myMinValue;

                }


                Delay(1);
                TransStart();  // Clock in 0000
                SDout(0);
                HiLowSCLK();
                SDout(0);
                HiLowSCLK();
                SDout(0);
                HiLowSCLK();
                SDout(0);
                HiLowSCLK();
                if (TH == "T") // Clock in Code 0011 ( Temperature )
                {
                    SDout(0);
                    HiLowSCLK();
                    SDout(0);
                    HiLowSCLK();
                    SDout(1);
                    HiLowSCLK();
                    SDout(1);
                    HiLowSCLK();
                }
                if (TH == "H") // Clock in Code 0101 ( Humidity )
                {
                    SDout(0);
                    HiLowSCLK();
                    SDout(1);
                    HiLowSCLK();
                    SDout(0);
                    HiLowSCLK();
                    SDout(1);
                    HiLowSCLK();
                }
                SDout(1);  // ACK                
                Sclk(1);
                Sclk(0);
                while ((SDin() == 1) & (xxx < 0x3e8)) // Wait until Input goes to Zero, up to 0x3e8ms
                {
                    Delay(1);
                    xxx++;
                }
                if (SDin() == 1) // If SDIN not zero, it's a bad reading.
                {
                    log("Error - Bad SHT Reading");
                    hadBadReading = true;
                }
                SDout(1);
                Sclk(1);
                string str_data = SDin().ToString(); // Read Back MS 8 bits
                HiLowSCLK();
                str_data = str_data + SDin().ToString();
                HiLowSCLK();
                str_data = str_data + SDin().ToString();
                HiLowSCLK();
                str_data = str_data + SDin().ToString();
                HiLowSCLK();
                str_data = str_data + SDin().ToString();
                HiLowSCLK();
                str_data = str_data + SDin().ToString();
                HiLowSCLK();
                str_data = str_data + SDin().ToString();
                HiLowSCLK();
                str_data = str_data + SDin().ToString();
                HiLowSCLK(); // Clock
                SDout(0);  // ACK
                Sclk(1);
                Sclk(0); // Clock
                SDout(1);
                Sclk(1);

                //ADDED 2/21/09
                Delay(1); // Added Delay
                str_data = str_data + SDin().ToString(); // Added Readback Bit


                HiLowSCLK(); // Clock
                str_data = str_data + SDin().ToString(); // Read Back LS 8 bits
                HiLowSCLK();
                str_data = str_data + SDin().ToString();
                HiLowSCLK();
                str_data = str_data + SDin().ToString();
                HiLowSCLK();
                str_data = str_data + SDin().ToString();
                HiLowSCLK();
                str_data = str_data + SDin().ToString();
                HiLowSCLK();
                str_data = str_data + SDin().ToString();
                HiLowSCLK();
                str_data = str_data + SDin().ToString();

                // REMOVED 2/21/09
                // HiLowSCLK();
                // str_data = str_data + SDin().ToString();

                SDout(1); // ACK
                Sclk(1);
                Sclk(0);
                SDout(1);
                if (TH == "T") // For temperature
                {
                    str_temp = Strings.Right(str_data, 14); // extract bottom 14 bits
                    str_msb = Strings.Left(str_temp, 6); // extract top 6 bits
                    str_lsb = Strings.Right(str_temp, 8); // extract bottom 8 bits

                }
                if (TH == "H") // For humidity
                {
                    str_temp = Strings.Right(str_data, 12); // extract bottom 12 bits
                    str_msb = Strings.Left(str_temp, 4); // extract top 4 bits
                    str_lsb = Strings.Right(str_temp, 8); // extract bottom 8 bits
                }

                //  Remove Gray Coding - alg:
                //  b0 = g0, and b(n)=g(n) xor b(n-1)

                double msb = Bin2Dec(str_msb);
                double lsb = Bin2Dec(str_lsb);
                // double tempdata = (msb * 256.0) + lsb; // This seems really suspicious
                double tempdata = Bin2Dec(str_temp);
                double ReadSHT = tempdata;
                // if (TH == "T") log("ReadSHT Raw: " + str_data + ":" + Bin2Dec(str_data));
                // log("ReadSHT Gray: " + degray + ":" + Bin2Dec(degray));
                Stop_IIC();
                // if (m_SerialPort.IsOpen)
                //    m_SerialPort.Close();
                return ReadSHT;

            }
            catch (Exception e)
            {
                log("Serial Port Error:" + e.Message);
                return myMinValue;
            }
        }




        private void TransStart()
        {
            SDout(1);
            Sclk(0);
            Sclk(1);
            SDout(0);
            Sclk(0);
            Sclk(1);
            SDout(1);
            Sclk(0);
        }

        private static double Bin2Dec(String strBin)
        {
            try
            {
                double lDec = 0.0;
                if (strBin == null || strBin.Length == 0)
                    strBin = "0";
                double lCount = Strings.Len(strBin);
                double t_double = lCount;
                for (double i = 1.0; i <= t_double; i++)
                {
                    lDec += Convert.ToInt32(Strings.Left(strBin, 1)) * Math.Pow(2.0, Strings.Len(strBin) - 1);
                    strBin = Strings.Right(strBin, Strings.Len(strBin) - 1);
                }
                return lDec;
            }
            catch (Exception e) { log(e.Message); }

            return myMinValue;
        }

        //  Delays are very system dependant.
        //  Also - optimization could be killing a for-loop delay.
        //  Replaced it with thread sleeping as a test.
        private static void Delay(int x)
        {
            //System.Threading.Thread.Sleep(x/10);
            System.Threading.Thread.Sleep(x * 1);
            // for (int i=x;i <= 3; i++);
        }

        #endregion

        #region Class Methods

        public TEMPerInterface(String device)
        {
            if (device.IndexOf("HID") < 0)
            {
                m_PortName = device;
                if (device == "ERR") m_PortName = null;
            }
            else
            {
                m_PortName = null;
                m_SerialPort = null;
                m_HIDDev = (int)Char.GetNumericValue(device[device.Length - 1]);
            }
            Init();
        }

        //  This one is used to add an additional interface to an already existing COMPort.
        public TEMPerInterface(String COMPort, SerialPort ThePort, String NewName)
        {
            log("Registered Virtual TEMPerInterface " + NewName);
            m_PortName = COMPort;
            m_SerialPort = ThePort;
            if (COMPort == "ERR") m_PortName = null;
            m_HIDDev = -1;
            DeviceName = NewName;
            m_CHic = "R";
            m_Init = true;
            // Init();
        }

        //  This one is used to add an additional interface to an already existing COMPort.
        public TEMPerInterface(int HIDDev, String NewName)
        {
            log("Registered Virtual TEMPerInterface " + NewName);
            m_PortName = null;
            m_SerialPort = null;
            m_HIDDev = HIDDev;
            DeviceName = NewName;
            m_CHic = "R";
            m_Init = true;
            // Init();
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
                catch (Exception)
                { }
            }
        }



        public void CheckDevice()
        {
            int i = 0;
            string aa = TEMPerName();
            while (i <= 20 && aa == "n/a")
            {
                aa = TEMPerName();
                i++; ;
            }
            DeviceName = aa;
            // GlobalVars.TEMPerName = aa;
        }

        private void Init()
        {
            if (m_PortName != null)
            {
                m_SerialPort = new SerialPort(m_PortName);
                m_CHic = "R";
                CheckDevice();
                if (CommPortExists(m_PortName))
                {
                    m_SerialPort.Open();

                    if (!m_SerialPort.IsOpen)
                    {
                        log("Error Opening Serial Port.");
                        return;
                    }


                    WriteP1P0(1, "0110000");
                    WriteP1P0(0, "00000000");
                    if (m_SerialPort.IsOpen)
                        m_SerialPort.Close();
                    m_Init = true;
                }
            }
            else if (m_HIDDev >= 0)
            {
                m_CHic = "R";
                CheckDevice();
                m_Init = true;
            }
        }

        public String PortName
        {
            get { return m_PortName; }
        }


        public string TEMPerName()
        {
            if (m_SerialPort != null)
            {
                byte y88 = (byte)Math.Round(ReadEEPROM(0x58));
                byte y89 = (byte)Math.Round(ReadEEPROM(0x59));
                if ((y88 == 0x58) & (y89 == 0x59)) { DeviceName = "TEMPerV1"; }
                if ((y88 == 0x58) & (y89 != 0x59)) { DeviceName = "TEMPerV2"; }
                if ((y88 == 0x59) & (y89 == 0x5A)) { DeviceName = "TEMPerHum"; }
                if ((y88 == 0x59) & (y89 == 0xFF)) { DeviceName = "TEMPerHum"; }
                if ((y88 == 0x5A) & (y89 == 0x5A)) { DeviceName = "TEMPerNTC"; }
                if ((y88 == 0x5A) & (y89 == 0xFF)) { DeviceName = "TEMPerNTCV2"; }
                log("Found: " + DeviceName + " (" + "y88: " + y88.ToString() + ", y89: " + y89.ToString() + ", chic: " + m_CHic);
            }
            else if (m_HIDDev >= 0)
            {
                EMySetCurrentDev(0);
                System.Threading.Thread.Sleep(100);
                EMyInitConfig(true);
                DeviceName = "TEMPerHID";
                log("Found: " + DeviceName + " (chic: " + m_CHic);
            }

            return DeviceName;
        }

        public void writeX(byte data)
        {
            string data_str = Dec2Bin(data);
            byte i = 0;
            do
            {
                byte ii = Convert.ToByte(Strings.Right(Strings.Left(data_str, i + 1), 1));
                SDout(ii);
                Delay(20);
                HiLowSCLK();
                i = (byte)(i + 1);
            }
            while (i <= 7);
        }

        public string Dec2Bin(double bDec)
        {
            string Dec2Bin = "";
            try
            {
                if (bDec > 255.0)
                {
                    Dec2Bin = "-1";
                }
                else
                {
                    string strBin = "";
                    while (bDec > 0.0)
                    {
                        strBin = (bDec % 2.0) + strBin;
                        bDec = Conversion.Fix(bDec / 2.0);
                    }
                    if (Strings.Len(strBin) < 9)
                    {
                        while (Strings.Len(strBin) < 8)
                        {
                            strBin = "0" + strBin;
                        }
                    }
                    Dec2Bin = strBin;
                }
            }
            catch (Exception)
            { }
            return Dec2Bin;
        }

        public double ReadEEPROM(byte EEadd)
        {
            if (m_SerialPort.IsOpen)
            {
                m_SerialPort.Close();
            }
            m_SerialPort.Open();

            if (!m_SerialPort.IsOpen)
            {
                log("Error Opening Serial Port.");
                return myMinValue;
            }


            Start_IIC();
            writeX(160);
            Delay(100);
            ReadACK();
            writeX(EEadd);
            Delay(100);
            ReadACK();
            Start_IIC();
            writeX(0xa1);
            Delay(100);
            ReadACK();
            string str_data = (SDin().ToString());
            HiLowSCLK();
            str_data = str_data + (SDin());
            HiLowSCLK();
            str_data = str_data + (SDin());
            HiLowSCLK();
            str_data = str_data + (SDin());
            HiLowSCLK();
            str_data = str_data + (SDin());
            HiLowSCLK();
            str_data = str_data + (SDin());
            HiLowSCLK();
            str_data = str_data + (SDin());
            HiLowSCLK();
            str_data = str_data + (SDin());
            HiLowSCLK();
            Stop_IIC();
            double ReadEEPROM = Bin2Dec(str_data);
            m_SerialPort.Close();
            return ReadEEPROM;
        }

        public void ReadACK()
        {
            byte tt = SDin();
            HiLowSCLK();
            if (tt == 1)
            {
                if (m_CHic == "T")
                {
                    m_CHic = "R"; ;
                }
                else
                {
                    m_CHic = "T";
                }
            }
        }

        private double[] ReadTEMPer()
        {
            double[] myReturn = { -99, -99 };
            try
            {
                if (m_SerialPort == null)
                    return myReturn;

                if (!m_Init)
                    Init();

                if (!m_Init)
                {
                    log("Error Initializing TEMPer.");
                    return myReturn;
                }

                if (!m_SerialPort.IsOpen)
                    m_SerialPort.Open();

                if (!m_SerialPort.IsOpen)
                {
                    log("Error Opening Serial Port.");
                    return myReturn;
                }


                double ReadTEMP = myMinValue;
                SDout(1);
                SDin();
                SDout(0);
                SDin();
                Start_IIC();
                SDout(1);
                HiLowSCLK();
                SDout(0);
                HiLowSCLK();
                SDout(0);
                HiLowSCLK();
                SDout(1);
                HiLowSCLK();
                SDout(1);
                HiLowSCLK();
                SDout(1);
                HiLowSCLK();
                SDout(1);
                HiLowSCLK();
                SDout(1);
                HiLowSCLK();
                Sclk(1);

                byte tt = SDin();
                HiLowSCLK();

                if (tt == 1)
                {
                    if (m_CHic == "T")
                        m_CHic = "R";
                    else
                        m_CHic = "T";
                }
                if (tt == 1)
                {
                    log("TEMPer ACK Failed.");
                    if (m_SerialPort.IsOpen)
                        m_SerialPort.Close();
                    return myReturn;
                }

                string str_data = SDin().ToString();
                HiLowSCLK();
                str_data = str_data + SDin().ToString();
                HiLowSCLK();
                str_data = str_data + SDin().ToString();
                HiLowSCLK();
                str_data = str_data + SDin().ToString();
                HiLowSCLK();
                str_data = str_data + SDin().ToString();
                HiLowSCLK();
                str_data = str_data + SDin().ToString();
                HiLowSCLK();
                str_data = str_data + SDin().ToString();
                HiLowSCLK();
                str_data = str_data + SDin().ToString();
                HiLowSCLK();
                SDin();
                HiLowSCLK();
                str_data = str_data + SDin().ToString();
                HiLowSCLK();
                str_data = str_data + SDin().ToString();
                HiLowSCLK();
                str_data = str_data + SDin().ToString();
                HiLowSCLK();
                str_data = str_data + SDin().ToString();
                HiLowSCLK();
                str_data = str_data + SDin().ToString();
                HiLowSCLK();
                str_data = str_data + SDin().ToString();
                HiLowSCLK();
                str_data = str_data + SDin().ToString();
                HiLowSCLK();
                str_data = str_data + SDin().ToString();
                Sclk(0);
                string FuHao = Strings.Left(str_data, 1);
                string str_temp = Strings.Left(str_data, 12);
                string str_msb = Strings.Left(str_temp, 4);
                string str_lsb = Strings.Right(str_temp, 8);
                double msb = Bin2Dec(str_msb);
                double lsb = Bin2Dec(str_lsb);
                double tempdata = (msb * 256.0) + lsb;
                switch (FuHao)
                {
                    case "0":
                        ReadTEMP = tempdata * 0.0625;
                        break;

                    case "1":
                        ReadTEMP = -(4096.0 - tempdata) * 0.0625;
                        break;
                }

                SDout(0);
                HiLowSCLK();
                Stop_IIC();

                if (m_SerialPort.IsOpen)
                    m_SerialPort.Close();
                log("Read TEMPer:" + ReadTEMP.ToString("###0.#####"));
                myReturn[0] = ReadTEMP + GlobalVars.config_calibration_temp;
                myReturn[1] = myMinValue;
                return myReturn;
            }
            catch (Exception e)
            {
                log(e.Message);
            }

            m_Init = false;
            myReturn[0] = myMinValue;
            myReturn[1] = myMinValue;
            if (m_SerialPort.IsOpen)
                m_SerialPort.Close();
            return myReturn;
        }

        private double[] ReadTEMPerHum()
        {
            decimal ReadTEMPsh10 = new decimal((ReadSHT("T") * 0.01) - 40.0);
            decimal C1 = -4M;
            decimal C2 = 0.0405M;
            object C3 = -2.8E-06;
            decimal T1 = 0.01M;
            decimal T2 = 0.00008M;
            Delay(4);
            int rh = (int)Math.Round(ReadSHT("H"));
            decimal rh_lin = Conversions.ToDecimal(Operators.AddObject(Operators.AddObject(Operators.MultiplyObject(Operators.MultiplyObject(C3, rh), rh), decimal.Multiply(C2, new decimal(rh))), C1));
            decimal rh_true = decimal.Add(decimal.Multiply(decimal.Subtract(ReadTEMPsh10, 25M), decimal.Add(T1, decimal.Multiply(T2, new decimal(rh)))), rh_lin);
            if (decimal.Compare(rh_true, 100M) > 0) { rh_true = 100M; }
            if (Convert.ToDouble(rh_true) < 0.1) { rh_true = 0.1M; }
            double[] myReturn = { -99, -99 };
            myReturn[0] = Convert.ToDouble(ReadTEMPsh10) + GlobalVars.config_calibration_temp;
            myReturn[1] = Convert.ToDouble(rh_true) + GlobalVars.config_calibration_humidity;
            log("TEMP: " + myReturn[0].ToString() + ", HUM: " + myReturn[1].ToString());
            return myReturn;
        }

        public double[] Read()
        {

            if (DeviceName == "TEMPerV1" || DeviceName == "TEMPerV2" || DeviceName == "TEMPerNTCINT")
            {
                return ReadTEMPer();
            }
            else if (DeviceName == "TEMPerHum")
            {
                return ReadTEMPerHum();
            }
            else if (DeviceName == "TEMPerNTC" || DeviceName == "TEMPerNTCV2")
            {
                return ReadTEMPerNTC();
            }
            else if (DeviceName == "TEMPerHID")
            {
                return ReadTEMPerHID();
            }
            else
            {
                return new double[] { -99, -99 };
            }
        }

        private void Start_IIC()
        {
            SDout(1);
            Sclk(1);
            SDout(0);
            Sclk(0);

        }

        private void Stop_IIC()
        {
            SDout(0);
            Sclk(1);
            SDout(1);
        }

        private void Sclk(byte ad01)
        {
            Delay(1);
            if (m_CHic == "T")
            {
                if (ad01 == 0)
                {
                    m_SerialPort.DtrEnable = true;
                }
                if (ad01 == 1)
                {
                    m_SerialPort.DtrEnable = false;
                }
            }
            if (m_CHic == "R")
            {
                if (ad01 == 0)
                {
                    m_SerialPort.DtrEnable = false;
                }
                if (ad01 == 1)
                {
                    m_SerialPort.DtrEnable = true;
                }
            }
        }

        private void HiLowSCLK()
        {
            Sclk(1);
            Sclk(0);
        }

        private byte SDin()
        {
            byte SDin = 0;
            Delay(1);
            SDout(1);
            Delay(50);
            Delay(50);
            bool a = m_SerialPort.CtsHolding;
            if (m_CHic == "T")
            {
                if (!a)
                {
                    SDin = 1;
                }
                else
                {
                    SDin = 0;
                }
            }
            if (m_CHic != "R")
            {
                return SDin;
            }
            if (!a)
            {
                return 0;
            }
            return 1;

        }

        private void SDout(byte ad01)
        {
            Delay(1);
            if (m_CHic == "T")
            {
                if (ad01 == 0)
                    m_SerialPort.RtsEnable = true;
                if (ad01 == 1)
                    m_SerialPort.RtsEnable = false;
            }
            if (m_CHic == "R")
            {
                if (ad01 == 0)
                    m_SerialPort.RtsEnable = false;
                if (ad01 == 1)
                    m_SerialPort.RtsEnable = true;
            }
        }

        private void WriteP1P0(byte P0123, String dataS)
        {
            Start_IIC();
            SDout(1);
            HiLowSCLK();
            SDout(0);
            HiLowSCLK();
            SDout(0);
            HiLowSCLK();
            SDout(1);
            HiLowSCLK();
            SDout(1);
            HiLowSCLK();
            SDout(1);
            HiLowSCLK();
            SDout(1);
            HiLowSCLK();
            SDout(0);
            HiLowSCLK();
            Sclk(1);
            Delay(200);
            byte tt = SDin();
            HiLowSCLK();
            if (tt == 1)
            {
                log("err1 ack by p1p0");
            }
            SDout(0);
            HiLowSCLK();
            SDout(0);
            HiLowSCLK();
            SDout(0);
            HiLowSCLK();
            SDout(0);
            HiLowSCLK();
            SDout(0);
            HiLowSCLK();
            SDout(0);
            HiLowSCLK();
            if (P0123 == 0)
            {
                SDout(0);
                HiLowSCLK();
                SDout(0);
                HiLowSCLK();
            }
            if (P0123 == 1)
            {
                SDout(0);
                HiLowSCLK();
                SDout(1);
                HiLowSCLK();
            }
            if (P0123 == 2)
            {
                SDout(1);
                HiLowSCLK();
                SDout(0);
                HiLowSCLK();
            }
            if (P0123 == 3)
            {
                SDout(1);
                HiLowSCLK();
                SDout(1);
                HiLowSCLK();
            }
            Sclk(1);
            Delay(200);
            SDin();
            HiLowSCLK();
            if (tt == 1)
            {
                log("err2 ack by p1p0");
            }
            byte xx = 1;
            do
            {
                if (Strings.Mid(dataS, xx, 1) == "1")
                {
                    SDout(1);
                }
                else
                {
                    SDout(0);
                }
                Delay(10);
                HiLowSCLK();
                xx = (byte)(xx + 1);
            }
            while (xx <= 8);
            Sclk(1);
            Delay(100);
            Delay(100);
            SDin();
            HiLowSCLK();
            SDout(0);
            HiLowSCLK();
            Stop_IIC();

        }


        private Double[] ReadTEMPerHID()
        {
            double[] myReturn = { myMinValue, myMinValue };
            double ReadTEMP = EMyReadTemp(true);

            log("Read TEMPer:" + ReadTEMP.ToString("###0.#####"));
            myReturn[0] = ReadTEMP + GlobalVars.config_calibration_temp;

            return myReturn;
        }


        private Double[] ReadTEMPerNTC()
        {
            double[] myReturn = { -99, -99 };

            // log("Last PGA Gain: " + PGAGain + " , volt1= " + volt1.ToString());

            if (Convert.ToDouble(volt1) < 0.25)
            {
                WriteED(0, "10001111");
                PGAGain = "PGA=8 ";
                volt1 = new decimal((ReadED(0) * 6.25E-05) / 8.0);
            }
            else if (Convert.ToDouble(volt1) < 0.05)
            {
                WriteED(0, "10001110");
                volt1 = new decimal((ReadED(0) * 6.25E-05) / 4.0);
                PGAGain = "PGA=4 ";
            }
            else if (decimal.Compare(volt1, decimal.One) < 0)
            {
                WriteED(0, "10001101");
                volt1 = new decimal((ReadED(0) * 6.25E-05) / 2.0);
                PGAGain = "PGA=2 ";
            }

            log("PGA Gain: " + PGAGain + " , volt1= " + volt1.ToString());

            if (!GlobalVars.config_hasntcdata) myReturn[0] = Convert.ToDouble(decimal.Divide(1, volt1));
            else
            {
                int tempcnt = 1;
                decimal volt2 = decimal.Divide(volt1, (decimal)0.004);

                // log("Interp volt1 is " + volt2.ToString());
                // 2009.09.02 Implemented Matti Picus' sign change to interpf calculation
                if (this.DeviceName == "TEMPerNTCV2" && GlobalVars.ntc_count > 0)
                {
                    while (tempcnt < GlobalVars.ntc_count && GlobalVars.ntc_factors[tempcnt] > Convert.ToDouble(volt2)) tempcnt++;
                    double interpf = (Convert.ToDouble(volt2) - GlobalVars.ntc_factors[tempcnt]) / (GlobalVars.ntc_factors[tempcnt - 1] - GlobalVars.ntc_factors[tempcnt]);
                    myReturn[0] = interpf * (GlobalVars.ntc_temps[tempcnt - 1] - GlobalVars.ntc_temps[tempcnt]) + GlobalVars.ntc_temps[tempcnt - 1];
                }
                else if (GlobalVars.ntcb_count > 0)
                {
                    while (tempcnt < GlobalVars.ntcb_count && GlobalVars.ntcb_factors[tempcnt] > Convert.ToDouble(volt2)) tempcnt++;
                    double interpf = (Convert.ToDouble(volt2) - GlobalVars.ntcb_factors[tempcnt]) / (GlobalVars.ntcb_factors[tempcnt - 1] - GlobalVars.ntcb_factors[tempcnt]);
                    myReturn[0] = interpf * (GlobalVars.ntcb_temps[tempcnt - 1] - GlobalVars.ntcb_temps[tempcnt]) + GlobalVars.ntcb_temps[tempcnt - 1];
                }

                // log("Interp chose " + tempcnt.ToString() + " out of " + GlobalVars.ntc_count.ToString());
                log("Read TEMPerNTC: " + myReturn[0].ToString());
            }
            // NTCdata = Conversions.ToDecimal(Strings.Format(Temp_NTC, "0.0000"));

            return myReturn;
        }


        public void WriteED(byte cs, string sdata)
        {
            byte tt;
            int delcnt;

            try
            {

                if (m_SerialPort == null)
                {
                    log("Error - No Serial Port.");
                    return;
                }

                if (!m_SerialPort.IsOpen)
                {
                    m_SerialPort.Open();
                }
                if (!m_SerialPort.IsOpen)
                {
                    log("Error Opening Serial Port in WriteED.");
                }

                Start_IIC();
                SDout(1);
                HiLowSCLK();
                SDout(0);
                HiLowSCLK();
                SDout(0);
                HiLowSCLK();
                SDout(1);
                HiLowSCLK();

                if ((cs / 4) % 2 == 1) SDout(1); else SDout(0);
                HiLowSCLK();
                if ((cs / 2) % 2 == 1) SDout(1); else SDout(0);
                HiLowSCLK();
                if ((cs / 1) % 2 == 1) SDout(1); else SDout(0);
                HiLowSCLK();

                SDout(0);
                HiLowSCLK();
                int timeOut = 0;
                timeOut = 0;
                do
                {
                    Delay(10);
                    tt = SDin();
                    if (tt == 0)
                    {
                        break;
                    }
                    timeOut++;
                }
                while (timeOut <= 100);

                if ((timeOut >= 100) & (tt == 1))
                    log("WriteED Timeout.");

                HiLowSCLK();
                if (tt == 1)
                {
                    if (m_CHic == "T")
                    {
                        m_CHic = "R";
                    }
                    else
                    {
                        m_CHic = "T";
                    }
                }
                if (tt == 1)
                {

                    log("WriteED ACK Error");
                    if (m_SerialPort.IsOpen)
                        m_SerialPort.Close();
                }
                else
                {
                    byte delcntb;
                    byte xx = 1;
                    do
                    {
                        if (Conversions.ToByte(Strings.Mid(sdata, xx, 1)) == Conversions.ToDouble("1"))
                        {
                            SDout(1);
                        }
                        else
                        {
                            SDout(0);
                        }
                        HiLowSCLK();
                        xx = (byte)(xx + 1);
                        delcntb = 8;
                    }
                    while (xx <= delcntb);
                    tt = SDin();
                    HiLowSCLK();
                    if (tt == 1)
                    {
                        if (m_CHic == "T")
                        {
                            m_CHic = "R";
                        }
                        else
                        {
                            m_CHic = "T";
                        }
                    }
                    xx = 1;
                    do
                    {
                        if (Conversions.ToByte(Strings.Mid(sdata, xx, 1)) == Conversions.ToDouble("1"))
                        {
                            SDout(1);
                        }
                        else
                        {
                            SDout(0);
                        }
                        HiLowSCLK();
                        xx = (byte)(xx + 1);
                        delcnt = 8;
                    }
                    while (xx <= delcnt);
                    Stop_IIC();
                    if (m_SerialPort.IsOpen)
                        m_SerialPort.Close();
                }
            }
            catch (Exception e)
            {
                log("Serial Port Error: " + e.Message);
            }
        }

        public double ReadED(byte cs)
        {
            byte tt;
            int delcnt;

            try
            {

                if (m_SerialPort == null)
                {
                    log("Error - No Serial Port.");
                    return myMinValue;
                }

                if (!m_SerialPort.IsOpen)
                {
                    m_SerialPort.Open();
                }
                if (!m_SerialPort.IsOpen)
                {
                    log("Error Opening Serial Port in ReadED.");
                    return myMinValue;
                }


                Start_IIC();
                SDout(1);
                HiLowSCLK();
                SDout(0);
                HiLowSCLK();
                SDout(0);
                HiLowSCLK();
                SDout(1);
                HiLowSCLK();

                if ((cs / 4) % 2 == 1) SDout(1); else SDout(0);
                HiLowSCLK();
                if ((cs / 2) % 2 == 1) SDout(1); else SDout(0);
                HiLowSCLK();
                if ((cs / 1) % 2 == 1) SDout(1); else SDout(0);
                HiLowSCLK();

                SDout(1);
                HiLowSCLK();
                int timeOut = 0;
                timeOut = 0;
                do
                {
                    Delay(10);
                    tt = SDin();
                    if (tt == 0)
                    {
                        break;
                    }
                    timeOut++;
                    delcnt = 100;
                }
                while (timeOut <= delcnt);
                if (timeOut >= 100)
                {
                    log("ReadED timeOut");
                }

                HiLowSCLK();
                switch (tt)
                {
                    case 1:
                        log("readED ACK err1");
                        break;

                    case 0:
                        {
                            string str_data = Conversions.ToString(SDin());
                            HiLowSCLK();
                            str_data = str_data + Conversions.ToString(SDin());
                            HiLowSCLK();
                            str_data = str_data + Conversions.ToString(SDin());
                            HiLowSCLK();
                            str_data = str_data + Conversions.ToString(SDin());
                            HiLowSCLK();
                            str_data = str_data + Conversions.ToString(SDin());
                            HiLowSCLK();
                            str_data = str_data + Conversions.ToString(SDin());
                            HiLowSCLK();
                            str_data = str_data + Conversions.ToString(SDin());
                            HiLowSCLK();
                            str_data = str_data + Conversions.ToString(SDin());
                            HiLowSCLK();
                            SDout(0);
                            HiLowSCLK();
                            str_data = str_data + Conversions.ToString(SDin());
                            HiLowSCLK();
                            str_data = str_data + Conversions.ToString(SDin());
                            HiLowSCLK();
                            str_data = str_data + Conversions.ToString(SDin());
                            HiLowSCLK();
                            str_data = str_data + Conversions.ToString(SDin());
                            HiLowSCLK();
                            str_data = str_data + Conversions.ToString(SDin());
                            HiLowSCLK();
                            str_data = str_data + Conversions.ToString(SDin());
                            HiLowSCLK();
                            str_data = str_data + Conversions.ToString(SDin());
                            HiLowSCLK();
                            str_data = str_data + Conversions.ToString(SDin());
                            Stop_IIC();

                            if (m_SerialPort.IsOpen)
                                m_SerialPort.Close();

                            string fig = Strings.Left(str_data, 1);
                            string str_msb = Strings.Mid(str_data, 2, 7);
                            string str_lsb = Strings.Right(str_data, 8);
                            double msb = Bin2Dec(str_msb);
                            double lsb = Bin2Dec(str_lsb);
                            double tempdata = (msb * 256.0) + lsb;
                            if (Conversions.ToDouble(fig) == 0.0)
                            {
                                // log("ReadED: " + str_data + " = " + tempdata.ToString());
                                return tempdata;
                            }
                            return (tempdata - 32768.0);
                        }
                }
                return myMinValue;
            }
            catch (Exception e)
            {
                log("Serial Port Error: " + e.Message);
                return myMinValue;
            }
        }
        #endregion
    }
}
