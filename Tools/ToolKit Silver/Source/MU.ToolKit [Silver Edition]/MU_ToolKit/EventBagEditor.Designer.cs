namespace MU_ToolKit
{
	// Token: 0x02000025 RID: 37
	public partial class EventBagEditor : global::System.Windows.Forms.Form
	{
		// Token: 0x06000496 RID: 1174 RVA: 0x0001FFA5 File Offset: 0x0001E1A5
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000499 RID: 1177 RVA: 0x00020340 File Offset: 0x0001E540
		private void InitializeComponent()
		{
			this.menuStrip1 = new global::System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.saveAsToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.label2 = new global::System.Windows.Forms.Label();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.groupBox2 = new global::System.Windows.Forms.GroupBox();
			this.button_Map_Update = new global::System.Windows.Forms.Button();
			this.label3 = new global::System.Windows.Forms.Label();
			this.numericUpDown_Map_MaxMobLvl = new global::System.Windows.Forms.NumericUpDown();
			this.label1 = new global::System.Windows.Forms.Label();
			this.numericUpDown_Map_MinMobLvl = new global::System.Windows.Forms.NumericUpDown();
			this.checkBox_Map_Drop = new global::System.Windows.Forms.CheckBox();
			this.button_RemoveMap = new global::System.Windows.Forms.Button();
			this.button_AddMap = new global::System.Windows.Forms.Button();
			this.listBox_SelectedMaps = new global::System.Windows.Forms.ListBox();
			this.listBox_MapSelection = new global::System.Windows.Forms.ListBox();
			this.colorDialog1 = new global::System.Windows.Forms.ColorDialog();
			this.groupBox3 = new global::System.Windows.Forms.GroupBox();
			this.label11 = new global::System.Windows.Forms.Label();
			this.numericUpDown_ExcDropRate = new global::System.Windows.Forms.NumericUpDown();
			this.label12 = new global::System.Windows.Forms.Label();
			this.label9 = new global::System.Windows.Forms.Label();
			this.groupBox4 = new global::System.Windows.Forms.GroupBox();
			this.numericUpDown_BagLevel = new global::System.Windows.Forms.NumericUpDown();
			this.label8 = new global::System.Windows.Forms.Label();
			this.numericUpDown_BagDropRate = new global::System.Windows.Forms.NumericUpDown();
			this.label7 = new global::System.Windows.Forms.Label();
			this.label6 = new global::System.Windows.Forms.Label();
			this.comboBox_Bag_ItemIndex = new global::System.Windows.Forms.ComboBox();
			this.comboBox_Bag_ItemGroup = new global::System.Windows.Forms.ComboBox();
			this.numericUpDown_DropRate = new global::System.Windows.Forms.NumericUpDown();
			this.label5 = new global::System.Windows.Forms.Label();
			this.label10 = new global::System.Windows.Forms.Label();
			this.numericUpDown_BagZen = new global::System.Windows.Forms.NumericUpDown();
			this.label4 = new global::System.Windows.Forms.Label();
			this.textBox_EventName = new global::System.Windows.Forms.TextBox();
			this.groupBox5 = new global::System.Windows.Forms.GroupBox();
			this.label_FileName = new global::System.Windows.Forms.Label();
			this.groupBox7 = new global::System.Windows.Forms.GroupBox();
			this.button_Item_Remove = new global::System.Windows.Forms.Button();
			this.button_Item_Update = new global::System.Windows.Forms.Button();
			this.label16 = new global::System.Windows.Forms.Label();
			this.checkBox_Added_Exc = new global::System.Windows.Forms.CheckBox();
			this.label_ItemCount = new global::System.Windows.Forms.Label();
			this.listBox_AddedItems = new global::System.Windows.Forms.ListBox();
			this.pictureBox_Added_ItemPreview = new global::System.Windows.Forms.PictureBox();
			this.checkBox_Added_Option = new global::System.Windows.Forms.CheckBox();
			this.numericUpDown_Added_MinLevel = new global::System.Windows.Forms.NumericUpDown();
			this.label13 = new global::System.Windows.Forms.Label();
			this.checkBox_Added_Luck = new global::System.Windows.Forms.CheckBox();
			this.numericUpDown_Added_MaxLevel = new global::System.Windows.Forms.NumericUpDown();
			this.label14 = new global::System.Windows.Forms.Label();
			this.checkBox_Added_Skill = new global::System.Windows.Forms.CheckBox();
			this.groupBox6 = new global::System.Windows.Forms.GroupBox();
			this.pictureBox_Add_ItemPreview = new global::System.Windows.Forms.PictureBox();
			this.checkBox_Add_Exc = new global::System.Windows.Forms.CheckBox();
			this.checkBox_Add_Luck = new global::System.Windows.Forms.CheckBox();
			this.checkBox_Add_Option = new global::System.Windows.Forms.CheckBox();
			this.checkBox_Add_Skill = new global::System.Windows.Forms.CheckBox();
			this.label17 = new global::System.Windows.Forms.Label();
			this.label18 = new global::System.Windows.Forms.Label();
			this.button_AddItem = new global::System.Windows.Forms.Button();
			this.numericUpDown_Add_MaxLevel = new global::System.Windows.Forms.NumericUpDown();
			this.numericUpDown_Add_MinLevel = new global::System.Windows.Forms.NumericUpDown();
			this.listBox_Add_Index = new global::System.Windows.Forms.ListBox();
			this.listBox_Add_Group = new global::System.Windows.Forms.ListBox();
			this.menuStrip1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Map_MaxMobLvl).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Map_MinMobLvl).BeginInit();
			this.groupBox3.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_ExcDropRate).BeginInit();
			this.groupBox4.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_BagLevel).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_BagDropRate).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_DropRate).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_BagZen).BeginInit();
			this.groupBox5.SuspendLayout();
			this.groupBox7.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox_Added_ItemPreview).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Added_MinLevel).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Added_MaxLevel).BeginInit();
			this.groupBox6.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox_Add_ItemPreview).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Add_MaxLevel).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Add_MinLevel).BeginInit();
			base.SuspendLayout();
			this.menuStrip1.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.fileToolStripMenuItem
			});
			this.menuStrip1.Location = new global::System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new global::System.Drawing.Size(555, 25);
			this.menuStrip1.TabIndex = 4;
			this.menuStrip1.Text = "menuStrip1";
			this.fileToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.newToolStripMenuItem,
				this.openToolStripMenuItem,
				this.saveAsToolStripMenuItem
			});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new global::System.Drawing.Size(39, 21);
			this.fileToolStripMenuItem.Text = "File";
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.Size = new global::System.Drawing.Size(121, 22);
			this.newToolStripMenuItem.Text = "New";
			this.newToolStripMenuItem.Click += new global::System.EventHandler(this.newToolStripMenuItem_Click);
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new global::System.Drawing.Size(121, 22);
			this.openToolStripMenuItem.Text = "Open";
			this.openToolStripMenuItem.Click += new global::System.EventHandler(this.openToolStripMenuItem_Click);
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.Size = new global::System.Drawing.Size(121, 22);
			this.saveAsToolStripMenuItem.Text = "Save As";
			this.saveAsToolStripMenuItem.Click += new global::System.EventHandler(this.saveAsToolStripMenuItem_Click);
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(12, 31);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(239, 12);
			this.label2.TabIndex = 1;
			this.label2.Text = "Bag Type: [3 Sections, 8 Columns] ONLY!";
			this.groupBox1.Controls.Add(this.groupBox2);
			this.groupBox1.Controls.Add(this.button_RemoveMap);
			this.groupBox1.Controls.Add(this.button_AddMap);
			this.groupBox1.Controls.Add(this.listBox_SelectedMaps);
			this.groupBox1.Controls.Add(this.listBox_MapSelection);
			this.groupBox1.Location = new global::System.Drawing.Point(12, 57);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(527, 117);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Drop Location";
			this.groupBox2.Controls.Add(this.button_Map_Update);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.numericUpDown_Map_MaxMobLvl);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.numericUpDown_Map_MinMobLvl);
			this.groupBox2.Controls.Add(this.checkBox_Map_Drop);
			this.groupBox2.Location = new global::System.Drawing.Point(370, 18);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new global::System.Drawing.Size(147, 90);
			this.groupBox2.TabIndex = 10;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Selectd map options";
			this.button_Map_Update.Enabled = false;
			this.button_Map_Update.Location = new global::System.Drawing.Point(64, 63);
			this.button_Map_Update.Name = "button_Map_Update";
			this.button_Map_Update.Size = new global::System.Drawing.Size(77, 22);
			this.button_Map_Update.TabIndex = 7;
			this.button_Map_Update.Text = "Update";
			this.button_Map_Update.UseVisualStyleBackColor = true;
			this.button_Map_Update.Click += new global::System.EventHandler(this.button_Map_Update_Click);
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(3, 42);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(83, 12);
			this.label3.TabIndex = 4;
			this.label3.Text = "Max Mob Level";
			this.numericUpDown_Map_MaxMobLvl.Location = new global::System.Drawing.Point(87, 39);
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.numericUpDown_Map_MaxMobLvl;
			int[] array = new int[4];
			array[0] = 9999999;
			numericUpDown.Maximum = new decimal(array);
			this.numericUpDown_Map_MaxMobLvl.Name = "numericUpDown_Map_MaxMobLvl";
			this.numericUpDown_Map_MaxMobLvl.Size = new global::System.Drawing.Size(54, 21);
			this.numericUpDown_Map_MaxMobLvl.TabIndex = 5;
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(3, 18);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(83, 12);
			this.label1.TabIndex = 2;
			this.label1.Text = "Min Mob Level";
			this.numericUpDown_Map_MinMobLvl.Location = new global::System.Drawing.Point(87, 15);
			global::System.Windows.Forms.NumericUpDown numericUpDown2 = this.numericUpDown_Map_MinMobLvl;
			int[] array2 = new int[4];
			array2[0] = 9999999;
			numericUpDown2.Maximum = new decimal(array2);
			this.numericUpDown_Map_MinMobLvl.Name = "numericUpDown_Map_MinMobLvl";
			this.numericUpDown_Map_MinMobLvl.Size = new global::System.Drawing.Size(54, 21);
			this.numericUpDown_Map_MinMobLvl.TabIndex = 4;
			this.checkBox_Map_Drop.AutoSize = true;
			this.checkBox_Map_Drop.Location = new global::System.Drawing.Point(6, 65);
			this.checkBox_Map_Drop.Name = "checkBox_Map_Drop";
			this.checkBox_Map_Drop.Size = new global::System.Drawing.Size(48, 16);
			this.checkBox_Map_Drop.TabIndex = 6;
			this.checkBox_Map_Drop.Text = "Drop";
			this.checkBox_Map_Drop.UseVisualStyleBackColor = true;
			this.button_RemoveMap.Enabled = false;
			this.button_RemoveMap.Location = new global::System.Drawing.Point(151, 62);
			this.button_RemoveMap.Name = "button_RemoveMap";
			this.button_RemoveMap.Size = new global::System.Drawing.Size(68, 43);
			this.button_RemoveMap.TabIndex = 2;
			this.button_RemoveMap.Text = "<- Remove";
			this.button_RemoveMap.UseVisualStyleBackColor = true;
			this.button_RemoveMap.Click += new global::System.EventHandler(this.button_RemoveMap_Click);
			this.button_AddMap.Location = new global::System.Drawing.Point(151, 18);
			this.button_AddMap.Name = "button_AddMap";
			this.button_AddMap.Size = new global::System.Drawing.Size(68, 39);
			this.button_AddMap.TabIndex = 1;
			this.button_AddMap.Text = "Add ->";
			this.button_AddMap.UseVisualStyleBackColor = true;
			this.button_AddMap.Click += new global::System.EventHandler(this.button_AddMap_Click);
			this.listBox_SelectedMaps.FormattingEnabled = true;
			this.listBox_SelectedMaps.ItemHeight = 12;
			this.listBox_SelectedMaps.Location = new global::System.Drawing.Point(225, 18);
			this.listBox_SelectedMaps.Name = "listBox_SelectedMaps";
			this.listBox_SelectedMaps.Size = new global::System.Drawing.Size(139, 88);
			this.listBox_SelectedMaps.TabIndex = 3;
			this.listBox_SelectedMaps.SelectedIndexChanged += new global::System.EventHandler(this.listBox_SelectedMaps_SelectedIndexChanged);
			this.listBox_MapSelection.FormattingEnabled = true;
			this.listBox_MapSelection.ItemHeight = 12;
			this.listBox_MapSelection.Location = new global::System.Drawing.Point(6, 18);
			this.listBox_MapSelection.Name = "listBox_MapSelection";
			this.listBox_MapSelection.Size = new global::System.Drawing.Size(139, 88);
			this.listBox_MapSelection.TabIndex = 0;
			this.groupBox3.Controls.Add(this.label11);
			this.groupBox3.Controls.Add(this.numericUpDown_ExcDropRate);
			this.groupBox3.Controls.Add(this.label12);
			this.groupBox3.Controls.Add(this.label9);
			this.groupBox3.Controls.Add(this.groupBox4);
			this.groupBox3.Controls.Add(this.numericUpDown_DropRate);
			this.groupBox3.Controls.Add(this.label5);
			this.groupBox3.Controls.Add(this.label10);
			this.groupBox3.Controls.Add(this.numericUpDown_BagZen);
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Controls.Add(this.textBox_EventName);
			this.groupBox3.Location = new global::System.Drawing.Point(12, 180);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new global::System.Drawing.Size(527, 122);
			this.groupBox3.TabIndex = 6;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Drop Configs";
			this.label11.AutoSize = true;
			this.label11.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.label11.Location = new global::System.Drawing.Point(164, 95);
			this.label11.Name = "label11";
			this.label11.Size = new global::System.Drawing.Size(23, 20);
			this.label11.TabIndex = 17;
			this.label11.Text = "%";
			this.numericUpDown_ExcDropRate.DecimalPlaces = 1;
			this.numericUpDown_ExcDropRate.Location = new global::System.Drawing.Point(108, 95);
			this.numericUpDown_ExcDropRate.Name = "numericUpDown_ExcDropRate";
			this.numericUpDown_ExcDropRate.Size = new global::System.Drawing.Size(50, 21);
			this.numericUpDown_ExcDropRate.TabIndex = 11;
			this.label12.AutoSize = true;
			this.label12.Location = new global::System.Drawing.Point(6, 98);
			this.label12.Name = "label12";
			this.label12.Size = new global::System.Drawing.Size(125, 12);
			this.label12.TabIndex = 15;
			this.label12.Text = "Excellent Drop Rate:";
			this.label9.AutoSize = true;
			this.label9.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.label9.Location = new global::System.Drawing.Point(164, 71);
			this.label9.Name = "label9";
			this.label9.Size = new global::System.Drawing.Size(23, 20);
			this.label9.TabIndex = 14;
			this.label9.Text = "%";
			this.groupBox4.Controls.Add(this.numericUpDown_BagLevel);
			this.groupBox4.Controls.Add(this.label8);
			this.groupBox4.Controls.Add(this.numericUpDown_BagDropRate);
			this.groupBox4.Controls.Add(this.label7);
			this.groupBox4.Controls.Add(this.label6);
			this.groupBox4.Controls.Add(this.comboBox_Bag_ItemIndex);
			this.groupBox4.Controls.Add(this.comboBox_Bag_ItemGroup);
			this.groupBox4.Location = new global::System.Drawing.Point(280, 18);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new global::System.Drawing.Size(237, 96);
			this.groupBox4.TabIndex = 5;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Bag Item";
			this.numericUpDown_BagLevel.Location = new global::System.Drawing.Point(39, 67);
			global::System.Windows.Forms.NumericUpDown numericUpDown3 = this.numericUpDown_BagLevel;
			int[] array3 = new int[4];
			array3[0] = 255;
			numericUpDown3.Maximum = new decimal(array3);
			this.numericUpDown_BagLevel.Name = "numericUpDown_BagLevel";
			this.numericUpDown_BagLevel.Size = new global::System.Drawing.Size(53, 21);
			this.numericUpDown_BagLevel.TabIndex = 14;
			this.label8.AutoSize = true;
			this.label8.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.label8.Location = new global::System.Drawing.Point(206, 67);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(23, 20);
			this.label8.TabIndex = 11;
			this.label8.Text = "%";
			this.numericUpDown_BagDropRate.DecimalPlaces = 1;
			this.numericUpDown_BagDropRate.Location = new global::System.Drawing.Point(155, 67);
			this.numericUpDown_BagDropRate.Name = "numericUpDown_BagDropRate";
			this.numericUpDown_BagDropRate.Size = new global::System.Drawing.Size(49, 21);
			this.numericUpDown_BagDropRate.TabIndex = 15;
			this.label7.AutoSize = true;
			this.label7.Location = new global::System.Drawing.Point(98, 70);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(65, 12);
			this.label7.TabIndex = 9;
			this.label7.Text = "Drop Rate:";
			this.label6.AutoSize = true;
			this.label6.Location = new global::System.Drawing.Point(3, 70);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(41, 12);
			this.label6.TabIndex = 6;
			this.label6.Text = "Level:";
			this.comboBox_Bag_ItemIndex.AutoCompleteSource = global::System.Windows.Forms.AutoCompleteSource.ListItems;
			this.comboBox_Bag_ItemIndex.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_Bag_ItemIndex.FormattingEnabled = true;
			this.comboBox_Bag_ItemIndex.Location = new global::System.Drawing.Point(6, 42);
			this.comboBox_Bag_ItemIndex.Name = "comboBox_Bag_ItemIndex";
			this.comboBox_Bag_ItemIndex.Size = new global::System.Drawing.Size(223, 20);
			this.comboBox_Bag_ItemIndex.TabIndex = 13;
			this.comboBox_Bag_ItemGroup.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_Bag_ItemGroup.FormattingEnabled = true;
			this.comboBox_Bag_ItemGroup.Location = new global::System.Drawing.Point(6, 18);
			this.comboBox_Bag_ItemGroup.Name = "comboBox_Bag_ItemGroup";
			this.comboBox_Bag_ItemGroup.Size = new global::System.Drawing.Size(223, 20);
			this.comboBox_Bag_ItemGroup.TabIndex = 12;
			this.comboBox_Bag_ItemGroup.SelectedIndexChanged += new global::System.EventHandler(this.comboBox_Bag_ItemGroup_SelectedIndexChanged);
			this.numericUpDown_DropRate.DecimalPlaces = 1;
			this.numericUpDown_DropRate.Location = new global::System.Drawing.Point(108, 71);
			this.numericUpDown_DropRate.Name = "numericUpDown_DropRate";
			this.numericUpDown_DropRate.Size = new global::System.Drawing.Size(50, 21);
			this.numericUpDown_DropRate.TabIndex = 10;
			this.label5.AutoSize = true;
			this.label5.Location = new global::System.Drawing.Point(6, 54);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(29, 12);
			this.label5.TabIndex = 3;
			this.label5.Text = "Zen:";
			this.label10.AutoSize = true;
			this.label10.Location = new global::System.Drawing.Point(6, 73);
			this.label10.Name = "label10";
			this.label10.Size = new global::System.Drawing.Size(107, 12);
			this.label10.TabIndex = 12;
			this.label10.Text = "Normal Drop Rate:";
			this.numericUpDown_BagZen.Location = new global::System.Drawing.Point(78, 47);
			global::System.Windows.Forms.NumericUpDown numericUpDown4 = this.numericUpDown_BagZen;
			int[] array4 = new int[4];
			array4[0] = int.MaxValue;
			numericUpDown4.Maximum = new decimal(array4);
			this.numericUpDown_BagZen.Name = "numericUpDown_BagZen";
			this.numericUpDown_BagZen.Size = new global::System.Drawing.Size(196, 21);
			this.numericUpDown_BagZen.TabIndex = 9;
			this.label4.AutoSize = true;
			this.label4.Location = new global::System.Drawing.Point(6, 26);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(71, 12);
			this.label4.TabIndex = 1;
			this.label4.Text = "Event Name:";
			this.textBox_EventName.Location = new global::System.Drawing.Point(78, 23);
			this.textBox_EventName.Name = "textBox_EventName";
			this.textBox_EventName.Size = new global::System.Drawing.Size(196, 21);
			this.textBox_EventName.TabIndex = 8;
			this.groupBox5.Controls.Add(this.label_FileName);
			this.groupBox5.Controls.Add(this.groupBox7);
			this.groupBox5.Controls.Add(this.groupBox6);
			this.groupBox5.Location = new global::System.Drawing.Point(12, 307);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new global::System.Drawing.Size(527, 362);
			this.groupBox5.TabIndex = 7;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Bag Items";
			this.label_FileName.ForeColor = global::System.Drawing.Color.DarkGreen;
			this.label_FileName.Location = new global::System.Drawing.Point(108, 14);
			this.label_FileName.Name = "label_FileName";
			this.label_FileName.Size = new global::System.Drawing.Size(292, 14);
			this.label_FileName.TabIndex = 2;
			this.label_FileName.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.groupBox7.Controls.Add(this.button_Item_Remove);
			this.groupBox7.Controls.Add(this.button_Item_Update);
			this.groupBox7.Controls.Add(this.label16);
			this.groupBox7.Controls.Add(this.checkBox_Added_Exc);
			this.groupBox7.Controls.Add(this.label_ItemCount);
			this.groupBox7.Controls.Add(this.listBox_AddedItems);
			this.groupBox7.Controls.Add(this.pictureBox_Added_ItemPreview);
			this.groupBox7.Controls.Add(this.checkBox_Added_Option);
			this.groupBox7.Controls.Add(this.numericUpDown_Added_MinLevel);
			this.groupBox7.Controls.Add(this.label13);
			this.groupBox7.Controls.Add(this.checkBox_Added_Luck);
			this.groupBox7.Controls.Add(this.numericUpDown_Added_MaxLevel);
			this.groupBox7.Controls.Add(this.label14);
			this.groupBox7.Controls.Add(this.checkBox_Added_Skill);
			this.groupBox7.Location = new global::System.Drawing.Point(9, 213);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new global::System.Drawing.Size(508, 139);
			this.groupBox7.TabIndex = 1;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Existing Items";
			this.button_Item_Remove.Enabled = false;
			this.button_Item_Remove.Location = new global::System.Drawing.Point(6, 107);
			this.button_Item_Remove.Name = "button_Item_Remove";
			this.button_Item_Remove.Size = new global::System.Drawing.Size(172, 27);
			this.button_Item_Remove.TabIndex = 26;
			this.button_Item_Remove.Text = "Remove";
			this.button_Item_Remove.UseVisualStyleBackColor = true;
			this.button_Item_Remove.Click += new global::System.EventHandler(this.button_Item_Remove_Click);
			this.button_Item_Update.Enabled = false;
			this.button_Item_Update.Location = new global::System.Drawing.Point(310, 102);
			this.button_Item_Update.Name = "button_Item_Update";
			this.button_Item_Update.Size = new global::System.Drawing.Size(192, 31);
			this.button_Item_Update.TabIndex = 33;
			this.button_Item_Update.Text = "Update";
			this.button_Item_Update.UseVisualStyleBackColor = true;
			this.button_Item_Update.Click += new global::System.EventHandler(this.button_Item_Update_Click);
			this.label16.AutoSize = true;
			this.label16.Location = new global::System.Drawing.Point(145, 11);
			this.label16.Name = "label16";
			this.label16.Size = new global::System.Drawing.Size(35, 12);
			this.label16.TabIndex = 22;
			this.label16.Text = "/ 150";
			this.checkBox_Added_Exc.AutoSize = true;
			this.checkBox_Added_Exc.Location = new global::System.Drawing.Point(406, 81);
			this.checkBox_Added_Exc.Name = "checkBox_Added_Exc";
			this.checkBox_Added_Exc.Size = new global::System.Drawing.Size(78, 16);
			this.checkBox_Added_Exc.TabIndex = 32;
			this.checkBox_Added_Exc.Text = "Excellent";
			this.checkBox_Added_Exc.UseVisualStyleBackColor = true;
			this.label_ItemCount.AutoSize = true;
			this.label_ItemCount.Location = new global::System.Drawing.Point(123, 11);
			this.label_ItemCount.Name = "label_ItemCount";
			this.label_ItemCount.RightToLeft = global::System.Windows.Forms.RightToLeft.Yes;
			this.label_ItemCount.Size = new global::System.Drawing.Size(11, 12);
			this.label_ItemCount.TabIndex = 21;
			this.label_ItemCount.Text = "0";
			this.label_ItemCount.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.listBox_AddedItems.FormattingEnabled = true;
			this.listBox_AddedItems.ItemHeight = 12;
			this.listBox_AddedItems.Location = new global::System.Drawing.Point(6, 26);
			this.listBox_AddedItems.Name = "listBox_AddedItems";
			this.listBox_AddedItems.Size = new global::System.Drawing.Size(172, 76);
			this.listBox_AddedItems.TabIndex = 25;
			this.listBox_AddedItems.SelectedIndexChanged += new global::System.EventHandler(this.listBox_AddedItems_SelectedIndexChanged);
			this.pictureBox_Added_ItemPreview.BackColor = global::System.Drawing.Color.FromArgb(37, 47, 1);
			this.pictureBox_Added_ItemPreview.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox_Added_ItemPreview.Location = new global::System.Drawing.Point(184, 26);
			this.pictureBox_Added_ItemPreview.Name = "pictureBox_Added_ItemPreview";
			this.pictureBox_Added_ItemPreview.Size = new global::System.Drawing.Size(117, 108);
			this.pictureBox_Added_ItemPreview.TabIndex = 12;
			this.pictureBox_Added_ItemPreview.TabStop = false;
			this.checkBox_Added_Option.AutoSize = true;
			this.checkBox_Added_Option.Location = new global::System.Drawing.Point(316, 81);
			this.checkBox_Added_Option.Name = "checkBox_Added_Option";
			this.checkBox_Added_Option.Size = new global::System.Drawing.Size(60, 16);
			this.checkBox_Added_Option.TabIndex = 31;
			this.checkBox_Added_Option.Text = "Option";
			this.checkBox_Added_Option.UseVisualStyleBackColor = true;
			this.numericUpDown_Added_MinLevel.Location = new global::System.Drawing.Point(375, 26);
			global::System.Windows.Forms.NumericUpDown numericUpDown5 = this.numericUpDown_Added_MinLevel;
			int[] array5 = new int[4];
			array5[0] = 255;
			numericUpDown5.Maximum = new decimal(array5);
			this.numericUpDown_Added_MinLevel.Name = "numericUpDown_Added_MinLevel";
			this.numericUpDown_Added_MinLevel.Size = new global::System.Drawing.Size(53, 21);
			this.numericUpDown_Added_MinLevel.TabIndex = 27;
			this.label13.AutoSize = true;
			this.label13.Location = new global::System.Drawing.Point(313, 53);
			this.label13.Name = "label13";
			this.label13.Size = new global::System.Drawing.Size(59, 12);
			this.label13.TabIndex = 6;
			this.label13.Text = "Max Level";
			this.checkBox_Added_Luck.AutoSize = true;
			this.checkBox_Added_Luck.Location = new global::System.Drawing.Point(448, 53);
			this.checkBox_Added_Luck.Name = "checkBox_Added_Luck";
			this.checkBox_Added_Luck.Size = new global::System.Drawing.Size(48, 16);
			this.checkBox_Added_Luck.TabIndex = 30;
			this.checkBox_Added_Luck.Text = "Luck";
			this.checkBox_Added_Luck.UseVisualStyleBackColor = true;
			this.numericUpDown_Added_MaxLevel.Location = new global::System.Drawing.Point(375, 50);
			global::System.Windows.Forms.NumericUpDown numericUpDown6 = this.numericUpDown_Added_MaxLevel;
			int[] array6 = new int[4];
			array6[0] = 255;
			numericUpDown6.Maximum = new decimal(array6);
			this.numericUpDown_Added_MaxLevel.Name = "numericUpDown_Added_MaxLevel";
			this.numericUpDown_Added_MaxLevel.Size = new global::System.Drawing.Size(53, 21);
			this.numericUpDown_Added_MaxLevel.TabIndex = 28;
			this.label14.AutoSize = true;
			this.label14.Location = new global::System.Drawing.Point(313, 29);
			this.label14.Name = "label14";
			this.label14.Size = new global::System.Drawing.Size(65, 12);
			this.label14.TabIndex = 5;
			this.label14.Text = "Min Level:";
			this.checkBox_Added_Skill.AutoSize = true;
			this.checkBox_Added_Skill.Location = new global::System.Drawing.Point(448, 27);
			this.checkBox_Added_Skill.Name = "checkBox_Added_Skill";
			this.checkBox_Added_Skill.Size = new global::System.Drawing.Size(54, 16);
			this.checkBox_Added_Skill.TabIndex = 29;
			this.checkBox_Added_Skill.Text = "Skill";
			this.checkBox_Added_Skill.UseVisualStyleBackColor = true;
			this.groupBox6.Controls.Add(this.pictureBox_Add_ItemPreview);
			this.groupBox6.Controls.Add(this.checkBox_Add_Exc);
			this.groupBox6.Controls.Add(this.checkBox_Add_Luck);
			this.groupBox6.Controls.Add(this.checkBox_Add_Option);
			this.groupBox6.Controls.Add(this.checkBox_Add_Skill);
			this.groupBox6.Controls.Add(this.label17);
			this.groupBox6.Controls.Add(this.label18);
			this.groupBox6.Controls.Add(this.button_AddItem);
			this.groupBox6.Controls.Add(this.numericUpDown_Add_MaxLevel);
			this.groupBox6.Controls.Add(this.numericUpDown_Add_MinLevel);
			this.groupBox6.Controls.Add(this.listBox_Add_Index);
			this.groupBox6.Controls.Add(this.listBox_Add_Group);
			this.groupBox6.Location = new global::System.Drawing.Point(9, 28);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new global::System.Drawing.Size(508, 180);
			this.groupBox6.TabIndex = 0;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Item Selection";
			this.pictureBox_Add_ItemPreview.BackColor = global::System.Drawing.Color.FromArgb(37, 47, 1);
			this.pictureBox_Add_ItemPreview.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox_Add_ItemPreview.Location = new global::System.Drawing.Point(381, 16);
			this.pictureBox_Add_ItemPreview.Name = "pictureBox_Add_ItemPreview";
			this.pictureBox_Add_ItemPreview.Size = new global::System.Drawing.Size(119, 110);
			this.pictureBox_Add_ItemPreview.TabIndex = 29;
			this.pictureBox_Add_ItemPreview.TabStop = false;
			this.checkBox_Add_Exc.AutoSize = true;
			this.checkBox_Add_Exc.Location = new global::System.Drawing.Point(306, 148);
			this.checkBox_Add_Exc.Name = "checkBox_Add_Exc";
			this.checkBox_Add_Exc.Size = new global::System.Drawing.Size(78, 16);
			this.checkBox_Add_Exc.TabIndex = 23;
			this.checkBox_Add_Exc.Text = "Excellent";
			this.checkBox_Add_Exc.UseVisualStyleBackColor = true;
			this.checkBox_Add_Luck.AutoSize = true;
			this.checkBox_Add_Luck.Location = new global::System.Drawing.Point(182, 148);
			this.checkBox_Add_Luck.Name = "checkBox_Add_Luck";
			this.checkBox_Add_Luck.Size = new global::System.Drawing.Size(48, 16);
			this.checkBox_Add_Luck.TabIndex = 21;
			this.checkBox_Add_Luck.Text = "Luck";
			this.checkBox_Add_Luck.UseVisualStyleBackColor = true;
			this.checkBox_Add_Option.AutoSize = true;
			this.checkBox_Add_Option.Location = new global::System.Drawing.Point(241, 148);
			this.checkBox_Add_Option.Name = "checkBox_Add_Option";
			this.checkBox_Add_Option.Size = new global::System.Drawing.Size(60, 16);
			this.checkBox_Add_Option.TabIndex = 22;
			this.checkBox_Add_Option.Text = "Option";
			this.checkBox_Add_Option.UseVisualStyleBackColor = true;
			this.checkBox_Add_Skill.AutoSize = true;
			this.checkBox_Add_Skill.Location = new global::System.Drawing.Point(131, 148);
			this.checkBox_Add_Skill.Name = "checkBox_Add_Skill";
			this.checkBox_Add_Skill.Size = new global::System.Drawing.Size(54, 16);
			this.checkBox_Add_Skill.TabIndex = 20;
			this.checkBox_Add_Skill.Text = "Skill";
			this.checkBox_Add_Skill.UseVisualStyleBackColor = true;
			this.label17.AutoSize = true;
			this.label17.Location = new global::System.Drawing.Point(6, 135);
			this.label17.Name = "label17";
			this.label17.Size = new global::System.Drawing.Size(65, 12);
			this.label17.TabIndex = 23;
			this.label17.Text = "Min Level:";
			this.label18.AutoSize = true;
			this.label18.Location = new global::System.Drawing.Point(6, 159);
			this.label18.Name = "label18";
			this.label18.Size = new global::System.Drawing.Size(59, 12);
			this.label18.TabIndex = 24;
			this.label18.Text = "Max Level";
			this.button_AddItem.Location = new global::System.Drawing.Point(381, 131);
			this.button_AddItem.Name = "button_AddItem";
			this.button_AddItem.Size = new global::System.Drawing.Size(121, 43);
			this.button_AddItem.TabIndex = 24;
			this.button_AddItem.Text = "Add";
			this.button_AddItem.UseVisualStyleBackColor = true;
			this.button_AddItem.Click += new global::System.EventHandler(this.button_AddItem_Click);
			this.numericUpDown_Add_MaxLevel.Location = new global::System.Drawing.Point(68, 156);
			global::System.Windows.Forms.NumericUpDown numericUpDown7 = this.numericUpDown_Add_MaxLevel;
			int[] array7 = new int[4];
			array7[0] = 255;
			numericUpDown7.Maximum = new decimal(array7);
			this.numericUpDown_Add_MaxLevel.Name = "numericUpDown_Add_MaxLevel";
			this.numericUpDown_Add_MaxLevel.Size = new global::System.Drawing.Size(53, 21);
			this.numericUpDown_Add_MaxLevel.TabIndex = 19;
			this.numericUpDown_Add_MinLevel.Location = new global::System.Drawing.Point(68, 132);
			global::System.Windows.Forms.NumericUpDown numericUpDown8 = this.numericUpDown_Add_MinLevel;
			int[] array8 = new int[4];
			array8[0] = 255;
			numericUpDown8.Maximum = new decimal(array8);
			this.numericUpDown_Add_MinLevel.Name = "numericUpDown_Add_MinLevel";
			this.numericUpDown_Add_MinLevel.Size = new global::System.Drawing.Size(53, 21);
			this.numericUpDown_Add_MinLevel.TabIndex = 18;
			this.listBox_Add_Index.FormattingEnabled = true;
			this.listBox_Add_Index.ItemHeight = 12;
			this.listBox_Add_Index.Location = new global::System.Drawing.Point(184, 16);
			this.listBox_Add_Index.Name = "listBox_Add_Index";
			this.listBox_Add_Index.Size = new global::System.Drawing.Size(191, 112);
			this.listBox_Add_Index.TabIndex = 17;
			this.listBox_Add_Index.SelectedIndexChanged += new global::System.EventHandler(this.listBox_Add_Index_SelectedIndexChanged);
			this.listBox_Add_Group.FormattingEnabled = true;
			this.listBox_Add_Group.ItemHeight = 12;
			this.listBox_Add_Group.Location = new global::System.Drawing.Point(6, 16);
			this.listBox_Add_Group.Name = "listBox_Add_Group";
			this.listBox_Add_Group.Size = new global::System.Drawing.Size(172, 112);
			this.listBox_Add_Group.TabIndex = 16;
			this.listBox_Add_Group.SelectedIndexChanged += new global::System.EventHandler(this.listBox_Add_Group_SelectedIndexChanged);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(555, 680);
			base.Controls.Add(this.groupBox5);
			base.Controls.Add(this.groupBox3);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.menuStrip1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.MaximizeBox = false;
			base.Name = "EventBagEditor";
			base.ShowIcon = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "EventBag Editor (TXT)";
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.EventBagEditor_FormClosed);
			base.Load += new global::System.EventHandler(this.EventBagEditor_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Map_MaxMobLvl).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Map_MinMobLvl).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_ExcDropRate).EndInit();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_BagLevel).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_BagDropRate).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_DropRate).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_BagZen).EndInit();
			this.groupBox5.ResumeLayout(false);
			this.groupBox7.ResumeLayout(false);
			this.groupBox7.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox_Added_ItemPreview).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Added_MinLevel).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Added_MaxLevel).EndInit();
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox_Add_ItemPreview).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Add_MaxLevel).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Add_MinLevel).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400024C RID: 588
		private global::System.Windows.Forms.Button button_AddItem;

		// Token: 0x0400024D RID: 589
		private global::System.Windows.Forms.Button button_AddMap;

		// Token: 0x0400024E RID: 590
		private global::System.Windows.Forms.Button button_Item_Remove;

		// Token: 0x0400024F RID: 591
		private global::System.Windows.Forms.Button button_Item_Update;

		// Token: 0x04000250 RID: 592
		private global::System.Windows.Forms.Button button_Map_Update;

		// Token: 0x04000251 RID: 593
		private global::System.Windows.Forms.Button button_RemoveMap;

		// Token: 0x04000263 RID: 611
		private global::System.Windows.Forms.CheckBox checkBox_Add_Exc;

		// Token: 0x04000264 RID: 612
		private global::System.Windows.Forms.CheckBox checkBox_Add_Luck;

		// Token: 0x04000265 RID: 613
		private global::System.Windows.Forms.CheckBox checkBox_Add_Option;

		// Token: 0x04000266 RID: 614
		private global::System.Windows.Forms.CheckBox checkBox_Add_Skill;

		// Token: 0x04000267 RID: 615
		private global::System.Windows.Forms.CheckBox checkBox_Added_Exc;

		// Token: 0x04000268 RID: 616
		private global::System.Windows.Forms.CheckBox checkBox_Added_Luck;

		// Token: 0x04000269 RID: 617
		private global::System.Windows.Forms.CheckBox checkBox_Added_Option;

		// Token: 0x0400026A RID: 618
		private global::System.Windows.Forms.CheckBox checkBox_Added_Skill;

		// Token: 0x0400026B RID: 619
		private global::System.Windows.Forms.CheckBox checkBox_Map_Drop;

		// Token: 0x0400026C RID: 620
		private global::System.Windows.Forms.ColorDialog colorDialog1;

		// Token: 0x0400026D RID: 621
		private global::System.Windows.Forms.ComboBox comboBox_Bag_ItemGroup;

		// Token: 0x0400026E RID: 622
		private global::System.Windows.Forms.ComboBox comboBox_Bag_ItemIndex;

		// Token: 0x0400026F RID: 623
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000271 RID: 625
		private global::System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;

		// Token: 0x04000272 RID: 626
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x04000273 RID: 627
		private global::System.Windows.Forms.GroupBox groupBox2;

		// Token: 0x04000274 RID: 628
		private global::System.Windows.Forms.GroupBox groupBox3;

		// Token: 0x04000275 RID: 629
		private global::System.Windows.Forms.GroupBox groupBox4;

		// Token: 0x04000276 RID: 630
		private global::System.Windows.Forms.GroupBox groupBox5;

		// Token: 0x04000277 RID: 631
		private global::System.Windows.Forms.GroupBox groupBox6;

		// Token: 0x04000278 RID: 632
		private global::System.Windows.Forms.GroupBox groupBox7;

		// Token: 0x0400028C RID: 652
		private global::System.Windows.Forms.Label label_FileName;

		// Token: 0x0400028D RID: 653
		private global::System.Windows.Forms.Label label_ItemCount;

		// Token: 0x0400028E RID: 654
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400028F RID: 655
		private global::System.Windows.Forms.Label label10;

		// Token: 0x04000290 RID: 656
		private global::System.Windows.Forms.Label label11;

		// Token: 0x04000291 RID: 657
		private global::System.Windows.Forms.Label label12;

		// Token: 0x04000292 RID: 658
		private global::System.Windows.Forms.Label label13;

		// Token: 0x04000293 RID: 659
		private global::System.Windows.Forms.Label label14;

		// Token: 0x04000294 RID: 660
		private global::System.Windows.Forms.Label label16;

		// Token: 0x04000295 RID: 661
		private global::System.Windows.Forms.Label label17;

		// Token: 0x04000296 RID: 662
		private global::System.Windows.Forms.Label label18;

		// Token: 0x04000297 RID: 663
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000298 RID: 664
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000299 RID: 665
		private global::System.Windows.Forms.Label label4;

		// Token: 0x0400029A RID: 666
		private global::System.Windows.Forms.Label label5;

		// Token: 0x0400029B RID: 667
		private global::System.Windows.Forms.Label label6;

		// Token: 0x0400029C RID: 668
		private global::System.Windows.Forms.Label label7;

		// Token: 0x0400029D RID: 669
		private global::System.Windows.Forms.Label label8;

		// Token: 0x0400029E RID: 670
		private global::System.Windows.Forms.Label label9;

		// Token: 0x040002A0 RID: 672
		private global::System.Windows.Forms.ListBox listBox_Add_Group;

		// Token: 0x040002A1 RID: 673
		private global::System.Windows.Forms.ListBox listBox_Add_Index;

		// Token: 0x040002A2 RID: 674
		private global::System.Windows.Forms.ListBox listBox_AddedItems;

		// Token: 0x040002A3 RID: 675
		private global::System.Windows.Forms.ListBox listBox_MapSelection;

		// Token: 0x040002A4 RID: 676
		private global::System.Windows.Forms.ListBox listBox_SelectedMaps;

		// Token: 0x040002A6 RID: 678
		private global::System.Windows.Forms.MenuStrip menuStrip1;

		// Token: 0x040002A7 RID: 679
		private global::System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;

		// Token: 0x040002A8 RID: 680
		private global::System.Windows.Forms.NumericUpDown numericUpDown_Add_MaxLevel;

		// Token: 0x040002A9 RID: 681
		private global::System.Windows.Forms.NumericUpDown numericUpDown_Add_MinLevel;

		// Token: 0x040002AA RID: 682
		private global::System.Windows.Forms.NumericUpDown numericUpDown_Added_MaxLevel;

		// Token: 0x040002AB RID: 683
		private global::System.Windows.Forms.NumericUpDown numericUpDown_Added_MinLevel;

		// Token: 0x040002AC RID: 684
		private global::System.Windows.Forms.NumericUpDown numericUpDown_BagDropRate;

		// Token: 0x040002AD RID: 685
		private global::System.Windows.Forms.NumericUpDown numericUpDown_BagLevel;

		// Token: 0x040002AE RID: 686
		private global::System.Windows.Forms.NumericUpDown numericUpDown_BagZen;

		// Token: 0x040002AF RID: 687
		private global::System.Windows.Forms.NumericUpDown numericUpDown_DropRate;

		// Token: 0x040002B0 RID: 688
		private global::System.Windows.Forms.NumericUpDown numericUpDown_ExcDropRate;

		// Token: 0x040002B1 RID: 689
		private global::System.Windows.Forms.NumericUpDown numericUpDown_Map_MaxMobLvl;

		// Token: 0x040002B2 RID: 690
		private global::System.Windows.Forms.NumericUpDown numericUpDown_Map_MinMobLvl;

		// Token: 0x040002B3 RID: 691
		private global::System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;

		// Token: 0x040002B4 RID: 692
		private global::System.Windows.Forms.PictureBox pictureBox_Add_ItemPreview;

		// Token: 0x040002B5 RID: 693
		private global::System.Windows.Forms.PictureBox pictureBox_Added_ItemPreview;

		// Token: 0x040002B6 RID: 694
		private global::System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;

		// Token: 0x040002B8 RID: 696
		private global::System.Windows.Forms.TextBox textBox_EventName;
	}
}
