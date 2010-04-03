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
 * FileName: 	Settings.cs
 * Namespace: 	utac.Components.Settings
 * Author: 		bof (bjoern@n4rf.de)
 * Orig Author: http://wwww.heelana.com
 * Created: 	2008-02-01
 * -----------------------------------------------------------------------
 * -------------------------------------------------------- Description *-
 * -----------------------------------------------------------------------
 *	The Settings class provides an easy way to store
 *	and load application settings/options in an ini-file
 *	like structure. The class uses an XML file as its
 *	underlying database but hides all the XML details
 *	from the user. All data are written/read with a simple
 *	interface of Read/Write functions.
 *
 *	Like ini-files the Settings class stores settings in
 *	sections which contain name-value pairs, f.e.:
 *
 *	<Settings>
 *	   <LastDirectories>
 *		  <Dir1 value="c:\" />
 *		  <Dir2 value="c:\somedirectory" />
 *	   </LastDirectories>
 *	</Settings>
 *
 *	To use the class create an instance passing the
 *	file name. Use the Read/Write methods as needed.
 *	After writing to the file call the Save() method
 *	to flush the changes to disk.
 *
 *	Note that the section and name strings must follow
 *	the XML rules! Don't use spaces in section and
 *	name strings and don't begin with numbers.
 *
 *	For comments/questions email to mail@heelana.com or
 *	visit http://wwww.heelana.com
 */

using System;
using System.Xml;
using System.IO;
using System.Windows.Forms;

namespace utac.Components.Settings
{
    public class Settings
    {
        readonly XmlDocument doc;
        readonly string fileName;
        readonly string rootName;

        public Settings(string fileName, string rootName)
        {
            this.fileName = fileName;
            this.rootName = rootName;

            doc = new XmlDocument();

            try
            {
                doc.Load(fileName);
            }
            catch (FileNotFoundException)
            {
                CreateSettingsDocument();
            }
        }

        public Settings(string fileName)
            : this(fileName, "Settings")
        {
        }

        //Deletes all entries of a section
        public void ClearSection(string section)
        {
            XmlNode root = doc.DocumentElement;
            XmlNode s = root.SelectSingleNode('/' + rootName + '/' + section);

            if (s == null)
                return;  //not found
            s.RemoveAll();
        }

        //initializes a new settings file with the XML version
        //and the root node
        protected void CreateSettingsDocument()
        {
            doc.AppendChild(doc.CreateXmlDeclaration("1.0", null, null));
            doc.AppendChild(doc.CreateElement(rootName));
        }

        public void Flush()
        {
            try
            {
                doc.Save(fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //removes a section and all its entries
        public void RemoveSection(string section)
        {
            XmlNode root = doc.DocumentElement;
            XmlNode s = root.SelectSingleNode('/' + rootName + '/' + section);

            if (s != null)
                root.RemoveChild(s);
        }

        public void Save()
        {
            Flush();
        }


        public static string ApplicationPath
        {
            get
            {
                return Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            }
        }



        #region Read methods

        public bool ReadBool(string section, string name, bool defaultValue)
        {
            string s = ReadString(section, name, "");

            if (s == Boolean.TrueString)
                return true;
            else if (s == Boolean.FalseString)
                return false;
            else
                return defaultValue;
        }

        public DateTime ReadDateTime(string section, string name, DateTime defaultValue)
        {
            string s = ReadString(section, name, "");

            if (s == "")
                return defaultValue;
            else
            {
                try
                {
                    DateTime dt = Convert.ToDateTime(s);
                    return dt;
                }
                catch (FormatException)
                {
                    return defaultValue;
                }
            }
        }

        public double ReadDouble(string section, string name, double defaultValue)
        {
            string s = ReadString(section, name, "");

            if (s == "")
                return defaultValue;
            else
            {
                try
                {
                    double d = Convert.ToDouble(s);
                    return d;
                }
                catch (FormatException)
                {
                    return defaultValue;
                }
            }
        }

        public float ReadFloat(string section, string name, float defaultValue)
        {
            string s = ReadString(section, name, "");

            if (s == "")
                return defaultValue;
            else
            {
                try
                {
                    float f = Convert.ToSingle(s);
                    return f;
                }
                catch (FormatException)
                {
                    return defaultValue;
                }
            }
        }

        public int ReadInt(string section, string name, int defaultValue)
        {
            string s = ReadString(section, name, "");

            if (s == "")
                return defaultValue;
            else
            {
                try
                {
                    int n = Convert.ToInt32(s);
                    return n;
                }
                catch (FormatException)
                {
                    return defaultValue;
                }
            }
        }

        public long ReadLong(string section, string name, long defaultValue)
        {
            string s = ReadString(section, name, "");

            if (s == "")
                return defaultValue;
            else
            {
                try
                {
                    long l = Convert.ToInt64(s);
                    return l;
                }
                catch (FormatException)
                {
                    return defaultValue;
                }
            }
        }

        public short ReadShort(string section, string name, short defaultValue)
        {
            string s = ReadString(section, name, "");

            if (s == "")
                return defaultValue;
            else
            {
                try
                {
                    short n = Convert.ToInt16(s);
                    return n;
                }
                catch (FormatException)
                {
                    return defaultValue;
                }
            }
        }

        public string ReadString(string section, string name, string defaultValue)
        {
            XmlNode root = doc.DocumentElement;
            XmlNode s = root.SelectSingleNode('/' + rootName + '/' + section);

            if (s == null)
                return defaultValue;  //not found

            XmlNode n = s.SelectSingleNode(name);

            if (n == null)
                return defaultValue;  //not found

            XmlAttributeCollection attrs = n.Attributes;

            foreach (XmlAttribute attr in attrs)
            {
                if (attr.Name == "value")
                    return attr.Value;
            }

            return defaultValue;
        }

        public uint ReadUInt(string section, string name, uint defaultValue)
        {
            string s = ReadString(section, name, "");

            if (s == "")
                return defaultValue;
            else
            {
                try
                {
                    uint n = Convert.ToUInt32(s);
                    return n;
                }
                catch (FormatException)
                {
                    return defaultValue;
                }
            }
        }

        public ulong ReadULong(string section, string name, ulong defaultValue)
        {
            string s = ReadString(section, name, "");

            if (s == "")
                return defaultValue;
            else
            {
                try
                {
                    ulong l = Convert.ToUInt64(s);
                    return l;
                }
                catch (FormatException)
                {
                    return defaultValue;
                }
            }
        }

        public ushort ReadUShort(string section, string name, ushort defaultValue)
        {
            string s = ReadString(section, name, "");

            if (s == "")
                return defaultValue;
            else
            {
                try
                {
                    ushort n = Convert.ToUInt16(s);
                    return n;
                }
                catch (FormatException)
                {
                    return defaultValue;
                }
            }
        }

        #endregion


        #region Write methods

        public void WriteBool(string section, string name, bool value)
        {
            WriteString(section, name, value.ToString());
        }

        public void WriteDateTime(string section, string name, DateTime value)
        {
            WriteString(section, name, value.ToString());
        }

        public void WriteDouble(string section, string name, double value)
        {
            WriteString(section, name, value.ToString());
        }

        public void WriteFloat(string section, string name, float value)
        {
            WriteString(section, name, value.ToString());
        }

        public void WriteInt(string section, string name, int value)
        {
            WriteString(section, name, value.ToString());
        }

        public void WriteLong(string section, string name, long value)
        {
            WriteString(section, name, value.ToString());
        }

        public void WriteShort(string section, string name, short value)
        {
            WriteString(section, name, value.ToString());
        }

        public void WriteString(string section, string name, string value)
        {
            XmlNode root = doc.DocumentElement;
            XmlNode s = root.SelectSingleNode('/' + rootName + '/' + section);

            if (s == null)
                s = root.AppendChild(doc.CreateElement(section));

            XmlNode n = s.SelectSingleNode(name);

            if (n == null)
                n = s.AppendChild(doc.CreateElement(name));

            XmlAttribute attr = ((XmlElement)n).SetAttributeNode("value", "");
            attr.Value = value;
        }

        public void WriteUInt(string section, string name, uint value)
        {
            WriteString(section, name, value.ToString());
        }

        public void WriteULong(string section, string name, ulong value)
        {
            WriteString(section, name, value.ToString());
        }

        public void WriteUShort(string section, string name, ushort value)
        {
            WriteString(section, name, value.ToString());
        }

        #endregion

    }
}
