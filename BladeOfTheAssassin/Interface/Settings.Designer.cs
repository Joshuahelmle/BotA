using BladeOfTheAssassin;
using InnerRage.Interface;
using System.ComponentModel;
using System.Windows.Forms;

namespace BladeOfTheAssassin.Interface {
	partial class Settings {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private IContainer components=null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing ) {
			if ( disposing&&( components!=null ) ) {
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.FormHeader = new System.Windows.Forms.Label();
            this.FormHeaderClose = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.tooltipHandler = new System.Windows.Forms.ToolTip(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.vt = new InnerRage.Interface.VerticalTabs();
            this.tabAbout = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rtfAbout = new System.Windows.Forms.RichTextBox();
            this.saveBTN = new System.Windows.Forms.Button();
            this.loadBTN = new System.Windows.Forms.Button();
            this.useSettingsBTN = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.FeintHp = new System.Windows.Forms.TextBox();
            this.RecupHP = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.FeintCB = new System.Windows.Forms.CheckBox();
            this.RecupCB = new System.Windows.Forms.CheckBox();
            this.Racials = new System.Windows.Forms.GroupBox();
            this.RacialBloodElfCB = new System.Windows.Forms.CheckBox();
            this.RacialHumanCB = new System.Windows.Forms.CheckBox();
            this.RacialTrollCB = new System.Windows.Forms.CheckBox();
            this.RacialOrcCB = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.LoCDelay = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.InterruptDelay = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.Trinket2BurstCb = new System.Windows.Forms.CheckBox();
            this.Trinket2LoCCB = new System.Windows.Forms.CheckBox();
            this.Trinket2CB = new System.Windows.Forms.CheckBox();
            this.Trinket1BurstCB = new System.Windows.Forms.CheckBox();
            this.Trinket1LoCCB = new System.Windows.Forms.CheckBox();
            this.Trinket1CB = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.InterruptKickCB = new System.Windows.Forms.CheckBox();
            this.Buffs = new System.Windows.Forms.GroupBox();
            this.OHPoisonBox = new System.Windows.Forms.ComboBox();
            this.applyPoisonsCB = new System.Windows.Forms.CheckBox();
            this.MHPoisonBox = new System.Windows.Forms.ComboBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.SRonlyOnBossCB = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.UseSRCB = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.SDonlyBossCB = new System.Windows.Forms.CheckBox();
            this.UseSDCB = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ARonlyBossCB = new System.Windows.Forms.CheckBox();
            this.UseARCB = new System.Windows.Forms.CheckBox();
            this.KSOnlyBossCB = new System.Windows.Forms.CheckBox();
            this.UseKSCB = new System.Windows.Forms.CheckBox();
            this.vt.SuspendLayout();
            this.tabAbout.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabSettings.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.Racials.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.Buffs.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // FormHeader
            // 
            this.FormHeader.BackColor = System.Drawing.Color.Firebrick;
            this.FormHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.FormHeader.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormHeader.ForeColor = System.Drawing.Color.White;
            this.FormHeader.Location = new System.Drawing.Point(0, 0);
            this.FormHeader.Name = "FormHeader";
            this.FormHeader.Size = new System.Drawing.Size(1030, 30);
            this.FormHeader.TabIndex = 0;
            this.FormHeader.Text = "InnerRage Settings";
            this.FormHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormHeaderClose
            // 
            this.FormHeaderClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FormHeaderClose.AutoSize = true;
            this.FormHeaderClose.BackColor = System.Drawing.Color.Black;
            this.FormHeaderClose.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormHeaderClose.ForeColor = System.Drawing.Color.MistyRose;
            this.FormHeaderClose.Location = new System.Drawing.Point(1007, 7);
            this.FormHeaderClose.Name = "FormHeaderClose";
            this.FormHeaderClose.Size = new System.Drawing.Size(19, 17);
            this.FormHeaderClose.TabIndex = 1;
            this.FormHeaderClose.Text = "X";
            this.FormHeaderClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tooltipHandler.SetToolTip(this.FormHeaderClose, "Close Window");
            this.FormHeaderClose.Click += new System.EventHandler(this.FormHeaderClose_Click_1);
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVersion.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lblVersion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblVersion.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblVersion.Location = new System.Drawing.Point(8, 468);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(190, 26);
            this.lblVersion.TabIndex = 3;
            this.lblVersion.Text = "Version 1.0.0.0";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // vt
            // 
            this.vt.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.vt.Controls.Add(this.tabAbout);
            this.vt.Controls.Add(this.tabSettings);
            this.vt.Controls.Add(this.tabPage1);
            this.vt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vt.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.vt.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vt.ItemSize = new System.Drawing.Size(30, 200);
            this.vt.Location = new System.Drawing.Point(0, 30);
            this.vt.Margin = new System.Windows.Forms.Padding(0);
            this.vt.Multiline = true;
            this.vt.MyBackColor = System.Drawing.Color.Transparent;
            this.vt.Name = "vt";
            this.vt.Padding = new System.Drawing.Point(0, 0);
            this.vt.SelectedIndex = 0;
            this.vt.Size = new System.Drawing.Size(1030, 471);
            this.vt.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.vt.TabBackgroundColor = System.Drawing.Color.Silver;
            this.vt.TabFont = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.vt.TabFontColor = System.Drawing.Color.SteelBlue;
            this.vt.TabIndex = 2;
            this.vt.TabSelectedBackgroundColor = System.Drawing.Color.DarkSlateGray;
            this.vt.TabSelectedFontColor = System.Drawing.Color.Silver;
            this.vt.TabTextHAlign = System.Drawing.StringAlignment.Near;
            this.vt.TabTextVAlign = System.Drawing.StringAlignment.Center;
            // 
            // tabAbout
            // 
            this.tabAbout.BackColor = System.Drawing.Color.DarkGray;
            this.tabAbout.Controls.Add(this.tableLayoutPanel1);
            this.tabAbout.Controls.Add(this.label3);
            this.tabAbout.Controls.Add(this.pictureBox1);
            this.tabAbout.Location = new System.Drawing.Point(204, 4);
            this.tabAbout.Name = "tabAbout";
            this.tabAbout.Padding = new System.Windows.Forms.Padding(3);
            this.tabAbout.Size = new System.Drawing.Size(822, 463);
            this.tabAbout.TabIndex = 1;
            this.tabAbout.Text = "About";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.rtfAbout, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.saveBTN, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.loadBTN, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.useSettingsBTN, 2, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(292, 77);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(487, 378);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // rtfAbout
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.rtfAbout, 3);
            this.rtfAbout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtfAbout.Location = new System.Drawing.Point(3, 3);
            this.rtfAbout.Name = "rtfAbout";
            this.rtfAbout.ReadOnly = true;
            this.rtfAbout.Size = new System.Drawing.Size(481, 324);
            this.rtfAbout.TabIndex = 0;
            this.rtfAbout.Text = "";
            // 
            // saveBTN
            // 
            this.saveBTN.AutoSize = true;
            this.saveBTN.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.saveBTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.saveBTN.Location = new System.Drawing.Point(3, 333);
            this.saveBTN.Name = "saveBTN";
            this.saveBTN.Size = new System.Drawing.Size(115, 42);
            this.saveBTN.TabIndex = 1;
            this.saveBTN.Text = "Save to File\r\n";
            this.saveBTN.UseVisualStyleBackColor = true;
            this.saveBTN.Click += new System.EventHandler(this.saveBTN_Click);
            // 
            // loadBTN
            // 
            this.loadBTN.AutoSize = true;
            this.loadBTN.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.loadBTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loadBTN.Location = new System.Drawing.Point(124, 333);
            this.loadBTN.Name = "loadBTN";
            this.loadBTN.Size = new System.Drawing.Size(115, 42);
            this.loadBTN.TabIndex = 2;
            this.loadBTN.Text = "Load from File";
            this.loadBTN.UseVisualStyleBackColor = true;
            this.loadBTN.Click += new System.EventHandler(this.loadBTN_Click);
            // 
            // useSettingsBTN
            // 
            this.useSettingsBTN.AutoSize = true;
            this.useSettingsBTN.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.useSettingsBTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.useSettingsBTN.Location = new System.Drawing.Point(245, 333);
            this.useSettingsBTN.Name = "useSettingsBTN";
            this.useSettingsBTN.Size = new System.Drawing.Size(239, 42);
            this.useSettingsBTN.TabIndex = 3;
            this.useSettingsBTN.Text = "Use Settings";
            this.useSettingsBTN.UseVisualStyleBackColor = true;
            this.useSettingsBTN.Click += new System.EventHandler(this.useSettingsBTN_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(285, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(491, 39);
            this.label3.TabIndex = 11;
            this.label3.Text = "Blade of the Assassin : Sneak em up";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, -3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(229, 463);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // tabSettings
            // 
            this.tabSettings.BackColor = System.Drawing.Color.DarkGray;
            this.tabSettings.Controls.Add(this.groupBox10);
            this.tabSettings.Controls.Add(this.Racials);
            this.tabSettings.Controls.Add(this.groupBox5);
            this.tabSettings.Controls.Add(this.groupBox4);
            this.tabSettings.Controls.Add(this.groupBox1);
            this.tabSettings.Controls.Add(this.Buffs);
            this.tabSettings.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabSettings.Location = new System.Drawing.Point(204, 4);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettings.Size = new System.Drawing.Size(822, 463);
            this.tabSettings.TabIndex = 2;
            this.tabSettings.Text = "Global";
            this.tabSettings.Click += new System.EventHandler(this.tabSettings_Click);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.FeintHp);
            this.groupBox10.Controls.Add(this.RecupHP);
            this.groupBox10.Controls.Add(this.label8);
            this.groupBox10.Controls.Add(this.label7);
            this.groupBox10.Controls.Add(this.FeintCB);
            this.groupBox10.Controls.Add(this.RecupCB);
            this.groupBox10.Location = new System.Drawing.Point(13, 237);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(415, 88);
            this.groupBox10.TabIndex = 10;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Defensives";
            // 
            // FeintHp
            // 
            this.FeintHp.Location = new System.Drawing.Point(271, 53);
            this.FeintHp.Name = "FeintHp";
            this.FeintHp.Size = new System.Drawing.Size(100, 26);
            this.FeintHp.TabIndex = 5;
            // 
            // RecupHP
            // 
            this.RecupHP.Location = new System.Drawing.Point(271, 24);
            this.RecupHP.Name = "RecupHP";
            this.RecupHP.Size = new System.Drawing.Size(100, 26);
            this.RecupHP.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(144, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 18);
            this.label8.TabIndex = 3;
            this.label8.Text = "on HP percentage:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(144, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 18);
            this.label7.TabIndex = 2;
            this.label7.Text = "on HP percentage:";
            // 
            // FeintCB
            // 
            this.FeintCB.AutoSize = true;
            this.FeintCB.Location = new System.Drawing.Point(7, 55);
            this.FeintCB.Name = "FeintCB";
            this.FeintCB.Size = new System.Drawing.Size(59, 22);
            this.FeintCB.TabIndex = 1;
            this.FeintCB.Text = "Feint";
            this.FeintCB.UseVisualStyleBackColor = true;
            // 
            // RecupCB
            // 
            this.RecupCB.AutoSize = true;
            this.RecupCB.Location = new System.Drawing.Point(7, 26);
            this.RecupCB.Name = "RecupCB";
            this.RecupCB.Size = new System.Drawing.Size(98, 22);
            this.RecupCB.TabIndex = 0;
            this.RecupCB.Text = "Recuperate";
            this.RecupCB.UseVisualStyleBackColor = true;
            // 
            // Racials
            // 
            this.Racials.Controls.Add(this.RacialBloodElfCB);
            this.Racials.Controls.Add(this.RacialHumanCB);
            this.Racials.Controls.Add(this.RacialTrollCB);
            this.Racials.Controls.Add(this.RacialOrcCB);
            this.Racials.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Racials.Location = new System.Drawing.Point(399, 6);
            this.Racials.Name = "Racials";
            this.Racials.Size = new System.Drawing.Size(157, 225);
            this.Racials.TabIndex = 8;
            this.Racials.TabStop = false;
            this.Racials.Text = "Racials";
            // 
            // RacialBloodElfCB
            // 
            this.RacialBloodElfCB.AutoSize = true;
            this.RacialBloodElfCB.Location = new System.Drawing.Point(6, 110);
            this.RacialBloodElfCB.Name = "RacialBloodElfCB";
            this.RacialBloodElfCB.Size = new System.Drawing.Size(121, 22);
            this.RacialBloodElfCB.TabIndex = 3;
            this.RacialBloodElfCB.Text = "Blood Elf Racial";
            this.RacialBloodElfCB.UseVisualStyleBackColor = true;
            // 
            // RacialHumanCB
            // 
            this.RacialHumanCB.AutoSize = true;
            this.RacialHumanCB.Location = new System.Drawing.Point(6, 82);
            this.RacialHumanCB.Name = "RacialHumanCB";
            this.RacialHumanCB.Size = new System.Drawing.Size(110, 22);
            this.RacialHumanCB.TabIndex = 2;
            this.RacialHumanCB.Text = "Human Racial";
            this.RacialHumanCB.UseVisualStyleBackColor = true;
            // 
            // RacialTrollCB
            // 
            this.RacialTrollCB.AutoSize = true;
            this.RacialTrollCB.Location = new System.Drawing.Point(6, 52);
            this.RacialTrollCB.Name = "RacialTrollCB";
            this.RacialTrollCB.Size = new System.Drawing.Size(93, 22);
            this.RacialTrollCB.TabIndex = 1;
            this.RacialTrollCB.Text = "Troll Racial";
            this.RacialTrollCB.UseVisualStyleBackColor = true;
            // 
            // RacialOrcCB
            // 
            this.RacialOrcCB.AutoSize = true;
            this.RacialOrcCB.Location = new System.Drawing.Point(6, 26);
            this.RacialOrcCB.Name = "RacialOrcCB";
            this.RacialOrcCB.Size = new System.Drawing.Size(87, 22);
            this.RacialOrcCB.TabIndex = 0;
            this.RacialOrcCB.Text = "Orc Racial";
            this.RacialOrcCB.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.LoCDelay);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.InterruptDelay);
            this.groupBox5.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(562, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(252, 225);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Timer";
            // 
            // LoCDelay
            // 
            this.LoCDelay.Location = new System.Drawing.Point(69, 124);
            this.LoCDelay.Name = "LoCDelay";
            this.LoCDelay.Size = new System.Drawing.Size(100, 26);
            this.LoCDelay.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(203, 18);
            this.label6.TabIndex = 2;
            this.label6.Text = "Loss of control clear delay in ms";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 18);
            this.label5.TabIndex = 1;
            this.label5.Text = "Interrupt delay in ms";
            // 
            // InterruptDelay
            // 
            this.InterruptDelay.Location = new System.Drawing.Point(69, 47);
            this.InterruptDelay.Name = "InterruptDelay";
            this.InterruptDelay.Size = new System.Drawing.Size(100, 26);
            this.InterruptDelay.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.Trinket2BurstCb);
            this.groupBox4.Controls.Add(this.Trinket2LoCCB);
            this.groupBox4.Controls.Add(this.Trinket2CB);
            this.groupBox4.Controls.Add(this.Trinket1BurstCB);
            this.groupBox4.Controls.Add(this.Trinket1LoCCB);
            this.groupBox4.Controls.Add(this.Trinket1CB);
            this.groupBox4.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(177, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(216, 225);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Trinkets";
            // 
            // Trinket2BurstCb
            // 
            this.Trinket2BurstCb.AutoSize = true;
            this.Trinket2BurstCb.Location = new System.Drawing.Point(27, 168);
            this.Trinket2BurstCb.Name = "Trinket2BurstCb";
            this.Trinket2BurstCb.Size = new System.Drawing.Size(75, 22);
            this.Trinket2BurstCb.TabIndex = 5;
            this.Trinket2BurstCb.Text = "to Burst";
            this.Trinket2BurstCb.UseVisualStyleBackColor = true;
            // 
            // Trinket2LoCCB
            // 
            this.Trinket2LoCCB.AutoSize = true;
            this.Trinket2LoCCB.Location = new System.Drawing.Point(27, 140);
            this.Trinket2LoCCB.Name = "Trinket2LoCCB";
            this.Trinket2LoCCB.Size = new System.Drawing.Size(137, 22);
            this.Trinket2LoCCB.TabIndex = 4;
            this.Trinket2LoCCB.Text = "on Loss of Control";
            this.Trinket2LoCCB.UseVisualStyleBackColor = true;
            // 
            // Trinket2CB
            // 
            this.Trinket2CB.AutoSize = true;
            this.Trinket2CB.Location = new System.Drawing.Point(7, 112);
            this.Trinket2CB.Name = "Trinket2CB";
            this.Trinket2CB.Size = new System.Drawing.Size(106, 22);
            this.Trinket2CB.TabIndex = 3;
            this.Trinket2CB.Text = "Use Trinket 2";
            this.Trinket2CB.UseVisualStyleBackColor = true;
            // 
            // Trinket1BurstCB
            // 
            this.Trinket1BurstCB.AutoSize = true;
            this.Trinket1BurstCB.Location = new System.Drawing.Point(27, 80);
            this.Trinket1BurstCB.Name = "Trinket1BurstCB";
            this.Trinket1BurstCB.Size = new System.Drawing.Size(75, 22);
            this.Trinket1BurstCB.TabIndex = 2;
            this.Trinket1BurstCB.Text = "to Burst";
            this.Trinket1BurstCB.UseVisualStyleBackColor = true;
            // 
            // Trinket1LoCCB
            // 
            this.Trinket1LoCCB.AutoSize = true;
            this.Trinket1LoCCB.Location = new System.Drawing.Point(27, 52);
            this.Trinket1LoCCB.Name = "Trinket1LoCCB";
            this.Trinket1LoCCB.Size = new System.Drawing.Size(135, 22);
            this.Trinket1LoCCB.TabIndex = 1;
            this.Trinket1LoCCB.Text = "on Loss of control";
            this.Trinket1LoCCB.UseVisualStyleBackColor = true;
            // 
            // Trinket1CB
            // 
            this.Trinket1CB.AutoSize = true;
            this.Trinket1CB.Location = new System.Drawing.Point(7, 24);
            this.Trinket1CB.Name = "Trinket1CB";
            this.Trinket1CB.Size = new System.Drawing.Size(106, 22);
            this.Trinket1CB.TabIndex = 0;
            this.Trinket1CB.Text = "Use Trinket 1";
            this.Trinket1CB.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.InterruptKickCB);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(6, 130);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(165, 101);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Interrupts";
            // 
            // InterruptKickCB
            // 
            this.InterruptKickCB.AutoSize = true;
            this.InterruptKickCB.Location = new System.Drawing.Point(6, 24);
            this.InterruptKickCB.Name = "InterruptKickCB";
            this.InterruptKickCB.Size = new System.Drawing.Size(52, 22);
            this.InterruptKickCB.TabIndex = 0;
            this.InterruptKickCB.Text = "Kick";
            this.InterruptKickCB.UseVisualStyleBackColor = true;
            // 
            // Buffs
            // 
            this.Buffs.Controls.Add(this.OHPoisonBox);
            this.Buffs.Controls.Add(this.applyPoisonsCB);
            this.Buffs.Controls.Add(this.MHPoisonBox);
            this.Buffs.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Buffs.Location = new System.Drawing.Point(6, 6);
            this.Buffs.Name = "Buffs";
            this.Buffs.Size = new System.Drawing.Size(165, 120);
            this.Buffs.TabIndex = 1;
            this.Buffs.TabStop = false;
            this.Buffs.Text = "Buffs";
            // 
            // OHPoisonBox
            // 
            this.OHPoisonBox.BackColor = System.Drawing.Color.Silver;
            this.OHPoisonBox.ForeColor = System.Drawing.Color.Black;
            this.OHPoisonBox.FormattingEnabled = true;
            this.OHPoisonBox.Items.AddRange(new object[] {
            "Crippling Poison",
            "Leeching Poison"});
            this.OHPoisonBox.Location = new System.Drawing.Point(6, 80);
            this.OHPoisonBox.Name = "OHPoisonBox";
            this.OHPoisonBox.Size = new System.Drawing.Size(153, 26);
            this.OHPoisonBox.TabIndex = 2;
            // 
            // applyPoisonsCB
            // 
            this.applyPoisonsCB.AutoSize = true;
            this.applyPoisonsCB.Checked = true;
            this.applyPoisonsCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.applyPoisonsCB.Location = new System.Drawing.Point(7, 24);
            this.applyPoisonsCB.Name = "applyPoisonsCB";
            this.applyPoisonsCB.Size = new System.Drawing.Size(114, 22);
            this.applyPoisonsCB.TabIndex = 1;
            this.applyPoisonsCB.Text = "Apply Poisons";
            this.applyPoisonsCB.UseVisualStyleBackColor = true;
            // 
            // MHPoisonBox
            // 
            this.MHPoisonBox.BackColor = System.Drawing.Color.Silver;
            this.MHPoisonBox.ForeColor = System.Drawing.Color.Black;
            this.MHPoisonBox.FormattingEnabled = true;
            this.MHPoisonBox.Items.AddRange(new object[] {
            "Deadly Poison",
            "Wound Poison"});
            this.MHPoisonBox.Location = new System.Drawing.Point(6, 48);
            this.MHPoisonBox.Name = "MHPoisonBox";
            this.MHPoisonBox.Size = new System.Drawing.Size(153, 26);
            this.MHPoisonBox.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.DarkGray;
            this.tabPage1.Controls.Add(this.SRonlyOnBossCB);
            this.tabPage1.Controls.Add(this.groupBox6);
            this.tabPage1.Controls.Add(this.UseSRCB);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(204, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(822, 463);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Talents";
            // 
            // SRonlyOnBossCB
            // 
            this.SRonlyOnBossCB.AutoSize = true;
            this.SRonlyOnBossCB.Location = new System.Drawing.Point(52, 45);
            this.SRonlyOnBossCB.Name = "SRonlyOnBossCB";
            this.SRonlyOnBossCB.Size = new System.Drawing.Size(111, 21);
            this.SRonlyOnBossCB.TabIndex = 3;
            this.SRonlyOnBossCB.Text = "onlyOnBoss";
            this.SRonlyOnBossCB.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Location = new System.Drawing.Point(551, 169);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(255, 265);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Assasination";
            // 
            // UseSRCB
            // 
            this.UseSRCB.AutoSize = true;
            this.UseSRCB.Location = new System.Drawing.Point(36, 18);
            this.UseSRCB.Name = "UseSRCB";
            this.UseSRCB.Size = new System.Drawing.Size(182, 21);
            this.UseSRCB.TabIndex = 2;
            this.UseSRCB.Text = "Use ShadowReflection";
            this.UseSRCB.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.SDonlyBossCB);
            this.groupBox3.Controls.Add(this.UseSDCB);
            this.groupBox3.Location = new System.Drawing.Point(274, 169);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(271, 265);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Subtlety";
            // 
            // SDonlyBossCB
            // 
            this.SDonlyBossCB.AutoSize = true;
            this.SDonlyBossCB.Location = new System.Drawing.Point(38, 66);
            this.SDonlyBossCB.Name = "SDonlyBossCB";
            this.SDonlyBossCB.Size = new System.Drawing.Size(119, 21);
            this.SDonlyBossCB.TabIndex = 1;
            this.SDonlyBossCB.Text = "only on Boss";
            this.SDonlyBossCB.UseVisualStyleBackColor = true;
            // 
            // UseSDCB
            // 
            this.UseSDCB.AutoSize = true;
            this.UseSDCB.Location = new System.Drawing.Point(23, 38);
            this.UseSDCB.Name = "UseSDCB";
            this.UseSDCB.Size = new System.Drawing.Size(157, 21);
            this.UseSDCB.TabIndex = 0;
            this.UseSDCB.Text = "Use ShadowDance";
            this.UseSDCB.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ARonlyBossCB);
            this.groupBox2.Controls.Add(this.UseARCB);
            this.groupBox2.Controls.Add(this.KSOnlyBossCB);
            this.groupBox2.Controls.Add(this.UseKSCB);
            this.groupBox2.Location = new System.Drawing.Point(14, 169);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(254, 265);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Combat";
            // 
            // ARonlyBossCB
            // 
            this.ARonlyBossCB.AutoSize = true;
            this.ARonlyBossCB.Location = new System.Drawing.Point(38, 150);
            this.ARonlyBossCB.Name = "ARonlyBossCB";
            this.ARonlyBossCB.Size = new System.Drawing.Size(119, 21);
            this.ARonlyBossCB.TabIndex = 3;
            this.ARonlyBossCB.Text = "only on Boss";
            this.ARonlyBossCB.UseVisualStyleBackColor = true;
            // 
            // UseARCB
            // 
            this.UseARCB.AutoSize = true;
            this.UseARCB.Location = new System.Drawing.Point(22, 122);
            this.UseARCB.Name = "UseARCB";
            this.UseARCB.Size = new System.Drawing.Size(167, 21);
            this.UseARCB.TabIndex = 2;
            this.UseARCB.Text = "Use AdrenalineRush";
            this.UseARCB.UseVisualStyleBackColor = true;
            // 
            // KSOnlyBossCB
            // 
            this.KSOnlyBossCB.AutoSize = true;
            this.KSOnlyBossCB.Location = new System.Drawing.Point(38, 67);
            this.KSOnlyBossCB.Name = "KSOnlyBossCB";
            this.KSOnlyBossCB.Size = new System.Drawing.Size(119, 21);
            this.KSOnlyBossCB.TabIndex = 1;
            this.KSOnlyBossCB.Text = "only on Boss";
            this.KSOnlyBossCB.UseVisualStyleBackColor = true;
            // 
            // UseKSCB
            // 
            this.UseKSCB.AutoSize = true;
            this.UseKSCB.Location = new System.Drawing.Point(22, 39);
            this.UseKSCB.Name = "UseKSCB";
            this.UseKSCB.Size = new System.Drawing.Size(139, 21);
            this.UseKSCB.TabIndex = 0;
            this.UseKSCB.Text = "Use KillingSpree";
            this.UseKSCB.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1030, 501);
            this.ControlBox = false;
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.vt);
            this.Controls.Add(this.FormHeaderClose);
            this.Controls.Add(this.FormHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Settings_Load);
            this.vt.ResumeLayout(false);
            this.tabAbout.ResumeLayout(false);
            this.tabAbout.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabSettings.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.Racials.ResumeLayout(false);
            this.Racials.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Buffs.ResumeLayout(false);
            this.Buffs.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private Label FormHeader;
        private Label FormHeaderClose;
		private Label lblVersion;
        private ToolTip tooltipHandler;
        private TabPage tabSettings;
        private TabPage tabAbout;
        private VerticalTabs vt;
        private GroupBox groupBox1;
        private CheckBox InterruptKickCB;
        private GroupBox Buffs;
        private CheckBox applyPoisonsCB;
        private ComboBox MHPoisonBox;
        private PictureBox pictureBox1;
        private Label label3;
        private TableLayoutPanel tableLayoutPanel1;
        private RichTextBox rtfAbout;
        private Button saveBTN;
        private Button loadBTN;
        private Button useSettingsBTN;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private GroupBox groupBox4;
        private CheckBox Trinket2BurstCb;
        private CheckBox Trinket2LoCCB;
        private CheckBox Trinket2CB;
        private CheckBox Trinket1BurstCB;
        private CheckBox Trinket1LoCCB;
        private CheckBox Trinket1CB;
        private GroupBox groupBox5;
        private TextBox LoCDelay;
        private Label label6;
        private Label label5;
        private TextBox InterruptDelay;
        private GroupBox Racials;
        private CheckBox RacialBloodElfCB;
        private CheckBox RacialHumanCB;
        private CheckBox RacialTrollCB;
        private CheckBox RacialOrcCB;
        private TabPage tabPage1;
        private GroupBox groupBox10;
        private TextBox FeintHp;
        private TextBox RecupHP;
        private Label label8;
        private Label label7;
        private CheckBox FeintCB;
        private CheckBox RecupCB;
        private ComboBox OHPoisonBox;
        private GroupBox groupBox3;
        private GroupBox groupBox2;
        private GroupBox groupBox6;
        private CheckBox ARonlyBossCB;
        private CheckBox UseARCB;
        private CheckBox KSOnlyBossCB;
        private CheckBox UseKSCB;
        private CheckBox SRonlyOnBossCB;
        private CheckBox UseSRCB;
        private CheckBox SDonlyBossCB;
        private CheckBox UseSDCB;
	}
}