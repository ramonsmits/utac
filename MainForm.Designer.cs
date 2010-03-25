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
 * FileName: 	MainForm.Designer.cs
 * Namespace: 	utac
 * Author: 		bof (bjoern@n4rf.de)
 * Created: 	2008-02-01
 * -----------------------------------------------------------------------
 * -------------------------------------------------------- Description *-
 * ------------------------------------------------------------------------
 * MainForm automated Designer Class
 */
 
namespace utac
{
	partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.groupBoxActualTemp = new System.Windows.Forms.GroupBox();
            this.pictureBoxTemp = new System.Windows.Forms.PictureBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statuslabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.temperLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tempgraph = new ZedGraph.ZedGraphControl();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.buttongraph = new System.Windows.Forms.Button();
            this.imageList3 = new System.Windows.Forms.ImageList(this.components);
            this.externalCMDCheckTimer = new System.Windows.Forms.Timer(this.components);
            this.buttonlist = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.resetMaxMinValuesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetGraphScaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.imageListToolStrip = new System.Windows.Forms.ImageList(this.components);
            this.groupBoxActualHumidty = new System.Windows.Forms.GroupBox();
            this.pictureBoxHum = new System.Windows.Forms.PictureBox();
            this.groupBoxMinMaxValues = new System.Windows.Forms.GroupBox();
            this.labelMaxHumVal = new System.Windows.Forms.Label();
            this.labelMinHumVal = new System.Windows.Forms.Label();
            this.labelMaxTempVal = new System.Windows.Forms.Label();
            this.labelMinTempVal = new System.Windows.Forms.Label();
            this.labelMaxHum = new System.Windows.Forms.Label();
            this.labelMinHum = new System.Windows.Forms.Label();
            this.labelMaxTemp = new System.Windows.Forms.Label();
            this.labelMinTemp = new System.Windows.Forms.Label();
            this.mynotifyicon = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBoxDevice = new System.Windows.Forms.GroupBox();
            this.DeviceButton = new System.Windows.Forms.Button();
            this.groupBoxActualTemp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTemp)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.groupBoxActualHumidty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHum)).BeginInit();
            this.groupBoxMinMaxValues.SuspendLayout();
            this.groupBoxDevice.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.Timer1Tick);
            // 
            // groupBoxActualTemp
            // 
            this.groupBoxActualTemp.Controls.Add(this.pictureBoxTemp);
            this.groupBoxActualTemp.Location = new System.Drawing.Point(12, 12);
            this.groupBoxActualTemp.Name = "groupBoxActualTemp";
            this.groupBoxActualTemp.Size = new System.Drawing.Size(192, 60);
            this.groupBoxActualTemp.TabIndex = 7;
            this.groupBoxActualTemp.TabStop = false;
            this.groupBoxActualTemp.Text = "Actual Temp";
            // 
            // pictureBoxTemp
            // 
            this.pictureBoxTemp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxTemp.Location = new System.Drawing.Point(6, 19);
            this.pictureBoxTemp.Name = "pictureBoxTemp";
            this.pictureBoxTemp.Size = new System.Drawing.Size(180, 35);
            this.pictureBoxTemp.TabIndex = 2;
            this.pictureBoxTemp.TabStop = false;
            // 
            // statusStrip
            // 
            this.statusStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statuslabel,
            this.temperLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 461);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.ShowItemToolTips = true;
            this.statusStrip.Size = new System.Drawing.Size(799, 22);
            this.statusStrip.TabIndex = 17;
            this.statusStrip.Text = "statusStrip";
            // 
            // statuslabel
            // 
            this.statuslabel.AutoSize = false;
            this.statuslabel.Name = "statuslabel";
            this.statuslabel.Size = new System.Drawing.Size(714, 17);
            this.statuslabel.Spring = true;
            this.statuslabel.Text = " ";
            this.statuslabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // temperLabel
            // 
            this.temperLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.temperLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.temperLabel.Name = "temperLabel";
            this.temperLabel.Size = new System.Drawing.Size(70, 17);
            this.temperLabel.Text = "temperLabel";
            this.temperLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tempgraph
            // 
            this.tempgraph.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tempgraph.EditButtons = System.Windows.Forms.MouseButtons.None;
            this.tempgraph.IsEnableHPan = false;
            this.tempgraph.IsEnableHZoom = false;
            this.tempgraph.IsEnableVPan = false;
            this.tempgraph.IsPrintFillPage = false;
            this.tempgraph.IsPrintKeepAspectRatio = false;
            this.tempgraph.IsPrintScaleAll = false;
            this.tempgraph.LinkButtons = System.Windows.Forms.MouseButtons.None;
            this.tempgraph.Location = new System.Drawing.Point(316, 12);
            this.tempgraph.Name = "tempgraph";
            this.tempgraph.PanButtons = System.Windows.Forms.MouseButtons.None;
            this.tempgraph.PanButtons2 = System.Windows.Forms.MouseButtons.None;
            this.tempgraph.ScrollGrace = 0;
            this.tempgraph.ScrollMaxX = 0;
            this.tempgraph.ScrollMaxY = 0;
            this.tempgraph.ScrollMaxY2 = 0;
            this.tempgraph.ScrollMinX = 0;
            this.tempgraph.ScrollMinY = 0;
            this.tempgraph.ScrollMinY2 = 0;
            this.tempgraph.SelectButtons = System.Windows.Forms.MouseButtons.Middle;
            this.tempgraph.Size = new System.Drawing.Size(471, 443);
            this.tempgraph.TabIndex = 19;
            this.tempgraph.ZoomButtons2 = System.Windows.Forms.MouseButtons.Left;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 295);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(273, 160);
            this.listBox1.TabIndex = 3;
            // 
            // buttongraph
            // 
            this.buttongraph.ImageList = this.imageList3;
            this.buttongraph.Location = new System.Drawing.Point(291, 12);
            this.buttongraph.Name = "buttongraph";
            this.buttongraph.Size = new System.Drawing.Size(19, 443);
            this.buttongraph.TabIndex = 20;
            this.buttongraph.UseVisualStyleBackColor = true;
            this.buttongraph.Click += new System.EventHandler(this.ButtongraphClick);
            // 
            // imageList3
            // 
            this.imageList3.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList3.ImageStream")));
            this.imageList3.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList3.Images.SetKeyName(0, "arrows_left.png");
            this.imageList3.Images.SetKeyName(1, "arrows_right.png");
            // 
            // externalCMDCheckTimer
            // 
            this.externalCMDCheckTimer.Enabled = true;
            this.externalCMDCheckTimer.Tick += new System.EventHandler(this.ExternalCMDCheckTimerTick);
            // 
            // buttonlist
            // 
            this.buttonlist.ImageIndex = 0;
            this.buttonlist.ImageList = this.imageList2;
            this.buttonlist.Location = new System.Drawing.Point(12, 269);
            this.buttonlist.Name = "buttonlist";
            this.buttonlist.Size = new System.Drawing.Size(273, 20);
            this.buttonlist.TabIndex = 24;
            this.buttonlist.UseVisualStyleBackColor = true;
            this.buttonlist.Click += new System.EventHandler(this.ButtonlistClick);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "arrows_up.png");
            this.imageList2.Images.SetKeyName(1, "arrows_down.png");
            // 
            // toolStrip
            // 
            this.toolStrip.AutoSize = false;
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripSeparator1,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripSeparator2,
            this.toolStripSplitButton1,
            this.toolStripSeparator3,
            this.toolStripButton5,
            this.toolStripButton6,
            this.toolStripButton7});
            this.toolStrip.Location = new System.Drawing.Point(12, 234);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(273, 32);
            this.toolStrip.TabIndex = 25;
            this.toolStrip.Text = "toolStrip";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.ToolStripButton1Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.AutoSize = false;
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.Click += new System.EventHandler(this.ToolStripButton2Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AutoSize = false;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(10, 32);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.AutoSize = false;
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton3.Text = "toolStripButton3";
            this.toolStripButton3.Click += new System.EventHandler(this.ToolStripButton3Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.AutoSize = false;
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton4.Text = "toolStripButton4";
            this.toolStripButton4.Click += new System.EventHandler(this.ToolStripButton4Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.AutoSize = false;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(10, 32);
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetMaxMinValuesToolStripMenuItem,
            this.resetGraphScaleToolStripMenuItem});
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(32, 29);
            this.toolStripSplitButton1.Text = "toolStripSplitButton1";
            // 
            // resetMaxMinValuesToolStripMenuItem
            // 
            this.resetMaxMinValuesToolStripMenuItem.Name = "resetMaxMinValuesToolStripMenuItem";
            this.resetMaxMinValuesToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.resetMaxMinValuesToolStripMenuItem.Text = "Reset Max/Min Values";
            this.resetMaxMinValuesToolStripMenuItem.Click += new System.EventHandler(this.ResetMaxMinValuesToolStripMenuItemClick);
            // 
            // resetGraphScaleToolStripMenuItem
            // 
            this.resetGraphScaleToolStripMenuItem.Name = "resetGraphScaleToolStripMenuItem";
            this.resetGraphScaleToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.resetGraphScaleToolStripMenuItem.Text = "Reset Graph Scale";
            this.resetGraphScaleToolStripMenuItem.Click += new System.EventHandler(this.ResetGraphScaleToolStripMenuItemClick);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.AutoSize = false;
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton5.Text = "toolStripButton5";
            this.toolStripButton5.Click += new System.EventHandler(this.ToolStripButton5Click);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.AutoSize = false;
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton6.Text = "toolStripButton6";
            this.toolStripButton6.Click += new System.EventHandler(this.ToolStripButton6Click);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.AutoSize = false;
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton7.Text = "toolStripButton7";
            this.toolStripButton7.Click += new System.EventHandler(this.ToolStripButton7Click);
            // 
            // imageListToolStrip
            // 
            this.imageListToolStrip.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListToolStrip.ImageStream")));
            this.imageListToolStrip.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListToolStrip.Images.SetKeyName(0, "arrow_refresh.png");
            this.imageListToolStrip.Images.SetKeyName(1, "clock.png");
            this.imageListToolStrip.Images.SetKeyName(2, "xhtml.png");
            this.imageListToolStrip.Images.SetKeyName(3, "world.png");
            this.imageListToolStrip.Images.SetKeyName(4, "bricks.png");
            this.imageListToolStrip.Images.SetKeyName(5, "wrench.png");
            this.imageListToolStrip.Images.SetKeyName(6, "information.png");
            this.imageListToolStrip.Images.SetKeyName(7, "door_in.png");
            // 
            // groupBoxActualHumidty
            // 
            this.groupBoxActualHumidty.Controls.Add(this.pictureBoxHum);
            this.groupBoxActualHumidty.Location = new System.Drawing.Point(12, 78);
            this.groupBoxActualHumidty.Name = "groupBoxActualHumidty";
            this.groupBoxActualHumidty.Size = new System.Drawing.Size(267, 65);
            this.groupBoxActualHumidty.TabIndex = 26;
            this.groupBoxActualHumidty.TabStop = false;
            this.groupBoxActualHumidty.Text = "Actual Humidity";
            // 
            // pictureBoxHum
            // 
            this.pictureBoxHum.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxHum.Location = new System.Drawing.Point(6, 19);
            this.pictureBoxHum.Name = "pictureBoxHum";
            this.pictureBoxHum.Size = new System.Drawing.Size(255, 40);
            this.pictureBoxHum.TabIndex = 2;
            this.pictureBoxHum.TabStop = false;
            // 
            // groupBoxMinMaxValues
            // 
            this.groupBoxMinMaxValues.Controls.Add(this.labelMaxHumVal);
            this.groupBoxMinMaxValues.Controls.Add(this.labelMinHumVal);
            this.groupBoxMinMaxValues.Controls.Add(this.labelMaxTempVal);
            this.groupBoxMinMaxValues.Controls.Add(this.labelMinTempVal);
            this.groupBoxMinMaxValues.Controls.Add(this.labelMaxHum);
            this.groupBoxMinMaxValues.Controls.Add(this.labelMinHum);
            this.groupBoxMinMaxValues.Controls.Add(this.labelMaxTemp);
            this.groupBoxMinMaxValues.Controls.Add(this.labelMinTemp);
            this.groupBoxMinMaxValues.Location = new System.Drawing.Point(12, 143);
            this.groupBoxMinMaxValues.Name = "groupBoxMinMaxValues";
            this.groupBoxMinMaxValues.Size = new System.Drawing.Size(273, 88);
            this.groupBoxMinMaxValues.TabIndex = 27;
            this.groupBoxMinMaxValues.TabStop = false;
            this.groupBoxMinMaxValues.Text = "Min / Max Values";
            // 
            // labelMaxHumVal
            // 
            this.labelMaxHumVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMaxHumVal.Location = new System.Drawing.Point(112, 67);
            this.labelMaxHumVal.Name = "labelMaxHumVal";
            this.labelMaxHumVal.Size = new System.Drawing.Size(149, 10);
            this.labelMaxHumVal.TabIndex = 7;
            this.labelMaxHumVal.Text = "MAx. Humidity:";
            this.labelMaxHumVal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelMinHumVal
            // 
            this.labelMinHumVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMinHumVal.Location = new System.Drawing.Point(112, 51);
            this.labelMinHumVal.Name = "labelMinHumVal";
            this.labelMinHumVal.Size = new System.Drawing.Size(149, 10);
            this.labelMinHumVal.TabIndex = 6;
            this.labelMinHumVal.Text = "Min. Humidity:";
            this.labelMinHumVal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelMaxTempVal
            // 
            this.labelMaxTempVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMaxTempVal.Location = new System.Drawing.Point(112, 35);
            this.labelMaxTempVal.Name = "labelMaxTempVal";
            this.labelMaxTempVal.Size = new System.Drawing.Size(149, 10);
            this.labelMaxTempVal.TabIndex = 5;
            this.labelMaxTempVal.Text = "Max. Temperature:";
            this.labelMaxTempVal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelMinTempVal
            // 
            this.labelMinTempVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMinTempVal.Location = new System.Drawing.Point(112, 19);
            this.labelMinTempVal.Name = "labelMinTempVal";
            this.labelMinTempVal.Size = new System.Drawing.Size(149, 10);
            this.labelMinTempVal.TabIndex = 4;
            this.labelMinTempVal.Text = "Min. Temperature:";
            this.labelMinTempVal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelMaxHum
            // 
            this.labelMaxHum.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMaxHum.Location = new System.Drawing.Point(6, 67);
            this.labelMaxHum.Name = "labelMaxHum";
            this.labelMaxHum.Size = new System.Drawing.Size(100, 16);
            this.labelMaxHum.TabIndex = 3;
            this.labelMaxHum.Text = "MAx. Humidity:";
            // 
            // labelMinHum
            // 
            this.labelMinHum.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMinHum.Location = new System.Drawing.Point(6, 51);
            this.labelMinHum.Name = "labelMinHum";
            this.labelMinHum.Size = new System.Drawing.Size(100, 16);
            this.labelMinHum.TabIndex = 2;
            this.labelMinHum.Text = "Min. Humidity:";
            // 
            // labelMaxTemp
            // 
            this.labelMaxTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMaxTemp.Location = new System.Drawing.Point(6, 35);
            this.labelMaxTemp.Name = "labelMaxTemp";
            this.labelMaxTemp.Size = new System.Drawing.Size(100, 16);
            this.labelMaxTemp.TabIndex = 1;
            this.labelMaxTemp.Text = "Max. Temperature:";
            // 
            // labelMinTemp
            // 
            this.labelMinTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMinTemp.Location = new System.Drawing.Point(6, 19);
            this.labelMinTemp.Name = "labelMinTemp";
            this.labelMinTemp.Size = new System.Drawing.Size(100, 16);
            this.labelMinTemp.TabIndex = 0;
            this.labelMinTemp.Text = "Min. Temperature:";
            // 
            // mynotifyicon
            // 
            this.mynotifyicon.Icon = ((System.Drawing.Icon)(resources.GetObject("mynotifyicon.Icon")));
            this.mynotifyicon.Text = "UTAC";
            this.mynotifyicon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon1MouseDoubleClick);
            // 
            // groupBoxDevice
            // 
            this.groupBoxDevice.Controls.Add(this.DeviceButton);
            this.groupBoxDevice.Location = new System.Drawing.Point(214, 12);
            this.groupBoxDevice.Name = "groupBoxDevice";
            this.groupBoxDevice.Size = new System.Drawing.Size(65, 60);
            this.groupBoxDevice.TabIndex = 28;
            this.groupBoxDevice.TabStop = false;
            this.groupBoxDevice.Text = "Device";
            // 
            // DeviceButton
            // 
            this.DeviceButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeviceButton.Location = new System.Drawing.Point(6, 19);
            this.DeviceButton.Name = "DeviceButton";
            this.DeviceButton.Size = new System.Drawing.Size(56, 35);
            this.DeviceButton.TabIndex = 0;
            this.DeviceButton.Text = "1";
            this.DeviceButton.UseVisualStyleBackColor = true;
            this.DeviceButton.Click += new System.EventHandler(this.DeviceButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 483);
            this.Controls.Add(this.groupBoxDevice);
            this.Controls.Add(this.groupBoxMinMaxValues);
            this.Controls.Add(this.groupBoxActualHumidty);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.buttonlist);
            this.Controls.Add(this.buttongraph);
            this.Controls.Add(this.tempgraph);
            this.Controls.Add(this.groupBoxActualTemp);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.listBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "UTAC";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFormFormClosed);
            this.Resize += new System.EventHandler(this.MainFormResize);
            this.groupBoxActualTemp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTemp)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.groupBoxActualHumidty.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHum)).EndInit();
            this.groupBoxMinMaxValues.ResumeLayout(false);
            this.groupBoxDevice.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.ToolStripStatusLabel temperLabel;
		private System.Windows.Forms.ToolStripMenuItem resetGraphScaleToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem resetMaxMinValuesToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
		private System.Windows.Forms.PictureBox pictureBoxHum;
		private System.Windows.Forms.GroupBox groupBoxActualHumidty;
		private System.Windows.Forms.GroupBox groupBoxMinMaxValues;
		private System.Windows.Forms.Label labelMaxHum;
		private System.Windows.Forms.Label labelMinHum;
		private System.Windows.Forms.Label labelMaxTemp;
		private System.Windows.Forms.Label labelMinTemp;
		private System.Windows.Forms.Label labelMinTempVal;
		private System.Windows.Forms.Label labelMaxTempVal;
		private System.Windows.Forms.Label labelMinHumVal;
		private System.Windows.Forms.Label labelMaxHumVal;
		private System.Windows.Forms.NotifyIcon mynotifyicon;
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.ImageList imageListToolStrip;
		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripButton toolStripButton7;
		private System.Windows.Forms.ToolStripButton toolStripButton6;
		private System.Windows.Forms.ToolStripButton toolStripButton5;
		private System.Windows.Forms.ToolStripButton toolStripButton4;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton toolStripButton3;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton toolStripButton2;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
		private System.Windows.Forms.GroupBox groupBoxActualTemp;
		private System.Windows.Forms.ImageList imageList3;
		private System.Windows.Forms.ImageList imageList2;
		private System.Windows.Forms.Button buttonlist;
		private System.Windows.Forms.Timer externalCMDCheckTimer;
		private System.Windows.Forms.Button buttongraph;
		private ZedGraph.ZedGraphControl tempgraph;
		private System.Windows.Forms.PictureBox pictureBoxTemp;
		private System.Windows.Forms.ToolStripStatusLabel statuslabel;

        private System.Windows.Forms.Timer timer;
		private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.GroupBox groupBoxDevice;
        private System.Windows.Forms.Button DeviceButton;
        public System.Windows.Forms.ListBox listBox1;

	
	}
}

