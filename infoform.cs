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
 * FileName: 	infoform.cs
 * Namespace: 	utac
 * Author: 		bof (bjoern@n4rf.de)
 * Created: 	2008-02-01
 * -----------------------------------------------------------------------
 * -------------------------------------------------------- Description *-
 * -----------------------------------------------------------------------
 * Info Dialog for UTAC, Version, Contact Links, etc.
 */

using System;
using System.Windows.Forms;
using utac.Components.Settings;

namespace utac
{
	/// <summary>
	/// Description of infoform.
	/// </summary>
	public partial class infoform : Form
	{
		public infoform()
		{
			InitializeComponent();
			this.Text = "UTAC :: "+GlobalVars.lang_programinfos;
			label_version.Text = GlobalVars._UTACVERSION;
			label_date.Text = GlobalVars._UTACDATE;
			labelVersion.Text = GlobalVars.lang_version+":";
			labelDate.Text = GlobalVars.lang_date+":";
			groupBoxProgramInfo.Text = GlobalVars.lang_programinfos;	
			groupBoxAbout.Text = GlobalVars.lang_about;
		}
		
		
		void Button1Click(object sender, EventArgs e)
		{
			Close();
		}

	    void LinkLabel3LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start("http://www.n4rf.net");
		}

	    void LinkLabel2LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start("mailto:info@n4rf.de");
		}

        void LinkLabel1LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start("http://blog.n4rf.net/solutions/utac");
		}

        void PictureBox2Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("http://www.n4rf.net");
		}
	}
}
