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
 * InfoForm automated Designer Class
 */
 
namespace utac
{
	partial class infoform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(infoform));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBoxProgramInfo = new System.Windows.Forms.GroupBox();
            this.label_date = new System.Windows.Forms.Label();
            this.label_version = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.groupBoxAbout = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBoxProgramInfo.SuspendLayout();
            this.groupBoxAbout.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 36);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.WaitOnLoad = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(139, 283);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(52, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "UTAC";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(53, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 40);
            this.label2.TabIndex = 3;
            this.label2.Text = "USB TEMPer Advanced Control";
            // 
            // groupBoxProgramInfo
            // 
            this.groupBoxProgramInfo.Controls.Add(this.label_date);
            this.groupBoxProgramInfo.Controls.Add(this.label_version);
            this.groupBoxProgramInfo.Controls.Add(this.labelDate);
            this.groupBoxProgramInfo.Controls.Add(this.labelVersion);
            this.groupBoxProgramInfo.Location = new System.Drawing.Point(12, 54);
            this.groupBoxProgramInfo.Name = "groupBoxProgramInfo";
            this.groupBoxProgramInfo.Size = new System.Drawing.Size(202, 70);
            this.groupBoxProgramInfo.TabIndex = 4;
            this.groupBoxProgramInfo.TabStop = false;
            this.groupBoxProgramInfo.Text = "Version Info";
            // 
            // label_date
            // 
            this.label_date.Location = new System.Drawing.Point(68, 44);
            this.label_date.Name = "label_date";
            this.label_date.Size = new System.Drawing.Size(100, 23);
            this.label_date.TabIndex = 3;
            this.label_date.Text = "Date:";
            // 
            // label_version
            // 
            this.label_version.Location = new System.Drawing.Point(68, 22);
            this.label_version.Name = "label_version";
            this.label_version.Size = new System.Drawing.Size(100, 23);
            this.label_version.TabIndex = 2;
            this.label_version.Text = "Version:";
            // 
            // labelDate
            // 
            this.labelDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDate.Location = new System.Drawing.Point(12, 44);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(100, 23);
            this.labelDate.TabIndex = 1;
            this.labelDate.Text = "Date:";
            // 
            // labelVersion
            // 
            this.labelVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVersion.Location = new System.Drawing.Point(12, 22);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(100, 23);
            this.labelVersion.TabIndex = 0;
            this.labelVersion.Text = "Version:";
            // 
            // groupBoxAbout
            // 
            this.groupBoxAbout.Controls.Add(this.label5);
            this.groupBoxAbout.Controls.Add(this.label4);
            this.groupBoxAbout.Controls.Add(this.label3);
            this.groupBoxAbout.Location = new System.Drawing.Point(12, 130);
            this.groupBoxAbout.Name = "groupBoxAbout";
            this.groupBoxAbout.Size = new System.Drawing.Size(202, 147);
            this.groupBoxAbout.TabIndex = 5;
            this.groupBoxAbout.TabStop = false;
            this.groupBoxAbout.Text = "About";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 32);
            this.label3.TabIndex = 4;
            this.label3.Text = "Original program by Björn Böttcher http://www.n4rf.net/";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(185, 32);
            this.label4.TabIndex = 5;
            this.label4.Text = "Modified by Albert Huntington http://www.alsgh.com/";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(190, 44);
            this.label5.TabIndex = 6;
            this.label5.Text = "Open Source Code written in C# on free Microsoft Visual C# 2008 Express Edition.";
            // 
            // infoform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 311);
            this.Controls.Add(this.groupBoxAbout);
            this.Controls.Add(this.groupBoxProgramInfo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "infoform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UTAC :: info";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBoxProgramInfo.ResumeLayout(false);
            this.groupBoxAbout.ResumeLayout(false);
            this.ResumeLayout(false);

        }
		private System.Windows.Forms.GroupBox groupBoxProgramInfo;
		private System.Windows.Forms.GroupBox groupBoxAbout;
		private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Label labelVersion;
		private System.Windows.Forms.Label label_version;
		private System.Windows.Forms.Label label_date;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
	}
}
