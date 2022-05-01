namespace MU_ToolKit
{
	// Token: 0x02000022 RID: 34
	public partial class ShopEditor : global::System.Windows.Forms.Form
	{
		// Token: 0x06000479 RID: 1145 RVA: 0x0001BD64 File Offset: 0x00019F64
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600047C RID: 1148 RVA: 0x0001BEAC File Offset: 0x0001A0AC
		private void InitializeComponent()
		{
			this.pictureBox_Init_1x1 = new global::System.Windows.Forms.PictureBox();
			this.pictureBox_ShopPreview = new global::System.Windows.Forms.PictureBox();
			this.listBox_Group = new global::System.Windows.Forms.ListBox();
			this.listBox_Index = new global::System.Windows.Forms.ListBox();
			this.listBox_Level = new global::System.Windows.Forms.ListBox();
			this.listBox_Option = new global::System.Windows.Forms.ListBox();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.groupBox2 = new global::System.Windows.Forms.GroupBox();
			this.groupBox3 = new global::System.Windows.Forms.GroupBox();
			this.checkBox_DurLock = new global::System.Windows.Forms.CheckBox();
			this.numericUpDown_Durability = new global::System.Windows.Forms.NumericUpDown();
			this.checkBox_Luck = new global::System.Windows.Forms.CheckBox();
			this.checkBox_Skill = new global::System.Windows.Forms.CheckBox();
			this.groupBox5 = new global::System.Windows.Forms.GroupBox();
			this.radioButton_Ancient_Level2 = new global::System.Windows.Forms.RadioButton();
			this.radioButton_Ancient_Level1 = new global::System.Windows.Forms.RadioButton();
			this.radioButton_Ancient_None = new global::System.Windows.Forms.RadioButton();
			this.menuStrip1 = new global::System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.saveAsToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.pictureBox_ItemPreview = new global::System.Windows.Forms.PictureBox();
			this.button_Add = new global::System.Windows.Forms.Button();
			this.groupBox_NewItem_ExcOpt = new global::System.Windows.Forms.GroupBox();
			this.radioButton_ExcWings = new global::System.Windows.Forms.RadioButton();
			this.radioButton_ExcArmor = new global::System.Windows.Forms.RadioButton();
			this.radioButton_ExcWeapon = new global::System.Windows.Forms.RadioButton();
			this.checkBox_ExcOpt6 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_ExcOpt5 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_ExcOpt4 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_ExcOpt3 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_ExcOpt2 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_ExcOpt1 = new global::System.Windows.Forms.CheckBox();
			this.label_Size = new global::System.Windows.Forms.Label();
			this.button_Update = new global::System.Windows.Forms.Button();
			this.checkBox_FO = new global::System.Windows.Forms.CheckBox();
			this.label_FileName = new global::System.Windows.Forms.Label();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox_Init_1x1).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox_ShopPreview).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Durability).BeginInit();
			this.groupBox5.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox_ItemPreview).BeginInit();
			this.groupBox_NewItem_ExcOpt.SuspendLayout();
			base.SuspendLayout();
			this.pictureBox_Init_1x1.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBox_Init_1x1.BackgroundImage = Properties.Resources.Untitled_3;
			this.pictureBox_Init_1x1.Enabled = false;
			this.pictureBox_Init_1x1.Location = new global::System.Drawing.Point(412, 49);
			this.pictureBox_Init_1x1.Name = "pictureBox_Init_1x1";
			this.pictureBox_Init_1x1.Size = new global::System.Drawing.Size(27, 25);
			this.pictureBox_Init_1x1.TabIndex = 1;
			this.pictureBox_Init_1x1.TabStop = false;
			this.pictureBox_Init_1x1.Visible = false;
			this.pictureBox_ShopPreview.BackgroundImage = Properties.Resources.Untitled_2;
			this.pictureBox_ShopPreview.ErrorImage = null;
			this.pictureBox_ShopPreview.Image = Properties.Resources.Untitled_21;
			this.pictureBox_ShopPreview.Location = new global::System.Drawing.Point(395, 31);
			this.pictureBox_ShopPreview.Name = "pictureBox_ShopPreview";
			this.pictureBox_ShopPreview.Size = new global::System.Drawing.Size(244, 392);
			this.pictureBox_ShopPreview.TabIndex = 0;
			this.pictureBox_ShopPreview.TabStop = false;
			this.pictureBox_ShopPreview.Visible = false;
			this.listBox_Group.FormattingEnabled = true;
			this.listBox_Group.ItemHeight = 12;
			this.listBox_Group.Location = new global::System.Drawing.Point(12, 31);
			this.listBox_Group.Name = "listBox_Group";
			this.listBox_Group.Size = new global::System.Drawing.Size(158, 136);
			this.listBox_Group.TabIndex = 0;
			this.listBox_Group.SelectedIndexChanged += new global::System.EventHandler(this.listBox_Group_SelectedIndexChanged);
			this.listBox_Index.FormattingEnabled = true;
			this.listBox_Index.ItemHeight = 12;
			this.listBox_Index.Location = new global::System.Drawing.Point(176, 31);
			this.listBox_Index.Name = "listBox_Index";
			this.listBox_Index.Size = new global::System.Drawing.Size(213, 136);
			this.listBox_Index.TabIndex = 1;
			this.listBox_Index.SelectedIndexChanged += new global::System.EventHandler(this.listBox_Index_SelectedIndexChanged);
			this.listBox_Level.FormattingEnabled = true;
			this.listBox_Level.ItemHeight = 12;
			this.listBox_Level.Location = new global::System.Drawing.Point(7, 14);
			this.listBox_Level.Name = "listBox_Level";
			this.listBox_Level.Size = new global::System.Drawing.Size(41, 196);
			this.listBox_Level.TabIndex = 2;
			this.listBox_Option.FormattingEnabled = true;
			this.listBox_Option.ItemHeight = 12;
			this.listBox_Option.Location = new global::System.Drawing.Point(5, 14);
			this.listBox_Option.Name = "listBox_Option";
			this.listBox_Option.Size = new global::System.Drawing.Size(44, 100);
			this.listBox_Option.TabIndex = 3;
			this.groupBox1.Controls.Add(this.listBox_Level);
			this.groupBox1.Location = new global::System.Drawing.Point(12, 173);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(55, 215);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Level";
			this.groupBox2.Controls.Add(this.listBox_Option);
			this.groupBox2.Location = new global::System.Drawing.Point(73, 173);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new global::System.Drawing.Size(54, 120);
			this.groupBox2.TabIndex = 7;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Option";
			this.groupBox3.Controls.Add(this.checkBox_DurLock);
			this.groupBox3.Controls.Add(this.numericUpDown_Durability);
			this.groupBox3.Location = new global::System.Drawing.Point(73, 297);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new global::System.Drawing.Size(106, 42);
			this.groupBox3.TabIndex = 8;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Durability";
			this.checkBox_DurLock.AutoSize = true;
			this.checkBox_DurLock.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.checkBox_DurLock.Location = new global::System.Drawing.Point(54, 19);
			this.checkBox_DurLock.Name = "checkBox_DurLock";
			this.checkBox_DurLock.Size = new global::System.Drawing.Size(50, 17);
			this.checkBox_DurLock.TabIndex = 5;
			this.checkBox_DurLock.Text = "Lock";
			this.checkBox_DurLock.UseVisualStyleBackColor = true;
			this.numericUpDown_Durability.Location = new global::System.Drawing.Point(6, 18);
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.numericUpDown_Durability;
			int[] array = new int[4];
			array[0] = 255;
			numericUpDown.Maximum = new decimal(array);
			this.numericUpDown_Durability.Name = "numericUpDown_Durability";
			this.numericUpDown_Durability.Size = new global::System.Drawing.Size(44, 21);
			this.numericUpDown_Durability.TabIndex = 4;
			global::System.Windows.Forms.NumericUpDown numericUpDown2 = this.numericUpDown_Durability;
			int[] array2 = new int[4];
			array2[0] = 255;
			numericUpDown2.Value = new decimal(array2);
			this.numericUpDown_Durability.ValueChanged += new global::System.EventHandler(this.numericUpDown_Durability_ValueChanged);
			this.checkBox_Luck.AutoSize = true;
			this.checkBox_Luck.Location = new global::System.Drawing.Point(73, 344);
			this.checkBox_Luck.Name = "checkBox_Luck";
			this.checkBox_Luck.Size = new global::System.Drawing.Size(48, 16);
			this.checkBox_Luck.TabIndex = 6;
			this.checkBox_Luck.Text = "Luck";
			this.checkBox_Luck.UseVisualStyleBackColor = true;
			this.checkBox_Skill.AutoSize = true;
			this.checkBox_Skill.Location = new global::System.Drawing.Point(73, 366);
			this.checkBox_Skill.Name = "checkBox_Skill";
			this.checkBox_Skill.Size = new global::System.Drawing.Size(54, 16);
			this.checkBox_Skill.TabIndex = 7;
			this.checkBox_Skill.Text = "Skill";
			this.checkBox_Skill.UseVisualStyleBackColor = true;
			this.groupBox5.Controls.Add(this.radioButton_Ancient_Level2);
			this.groupBox5.Controls.Add(this.radioButton_Ancient_Level1);
			this.groupBox5.Controls.Add(this.radioButton_Ancient_None);
			this.groupBox5.Location = new global::System.Drawing.Point(133, 173);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new global::System.Drawing.Size(130, 63);
			this.groupBox5.TabIndex = 12;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Anceint Option";
			this.radioButton_Ancient_Level2.AutoSize = true;
			this.radioButton_Ancient_Level2.Location = new global::System.Drawing.Point(67, 39);
			this.radioButton_Ancient_Level2.Name = "radioButton_Ancient_Level2";
			this.radioButton_Ancient_Level2.Size = new global::System.Drawing.Size(65, 16);
			this.radioButton_Ancient_Level2.TabIndex = 10;
			this.radioButton_Ancient_Level2.Text = "Level 2";
			this.radioButton_Ancient_Level2.UseVisualStyleBackColor = true;
			this.radioButton_Ancient_Level1.AutoSize = true;
			this.radioButton_Ancient_Level1.Location = new global::System.Drawing.Point(6, 39);
			this.radioButton_Ancient_Level1.Name = "radioButton_Ancient_Level1";
			this.radioButton_Ancient_Level1.Size = new global::System.Drawing.Size(65, 16);
			this.radioButton_Ancient_Level1.TabIndex = 9;
			this.radioButton_Ancient_Level1.Text = "Level 1";
			this.radioButton_Ancient_Level1.UseVisualStyleBackColor = true;
			this.radioButton_Ancient_None.AutoSize = true;
			this.radioButton_Ancient_None.Checked = true;
			this.radioButton_Ancient_None.Location = new global::System.Drawing.Point(6, 18);
			this.radioButton_Ancient_None.Name = "radioButton_Ancient_None";
			this.radioButton_Ancient_None.Size = new global::System.Drawing.Size(47, 16);
			this.radioButton_Ancient_None.TabIndex = 8;
			this.radioButton_Ancient_None.TabStop = true;
			this.radioButton_Ancient_None.Text = "None";
			this.radioButton_Ancient_None.UseVisualStyleBackColor = true;
			this.menuStrip1.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.fileToolStripMenuItem
			});
			this.menuStrip1.Location = new global::System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new global::System.Drawing.Size(652, 25);
			this.menuStrip1.TabIndex = 13;
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
			this.pictureBox_ItemPreview.BackColor = global::System.Drawing.Color.FromArgb(37, 47, 1);
			this.pictureBox_ItemPreview.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox_ItemPreview.Location = new global::System.Drawing.Point(269, 173);
			this.pictureBox_ItemPreview.Name = "pictureBox_ItemPreview";
			this.pictureBox_ItemPreview.Size = new global::System.Drawing.Size(120, 94);
			this.pictureBox_ItemPreview.TabIndex = 14;
			this.pictureBox_ItemPreview.TabStop = false;
			this.button_Add.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.button_Add.Location = new global::System.Drawing.Point(96, 393);
			this.button_Add.Name = "button_Add";
			this.button_Add.Size = new global::System.Drawing.Size(83, 30);
			this.button_Add.TabIndex = 22;
			this.button_Add.Text = "Add Item";
			this.button_Add.UseVisualStyleBackColor = true;
			this.button_Add.Click += new global::System.EventHandler(this.button_Add_Click);
			this.groupBox_NewItem_ExcOpt.BackColor = global::System.Drawing.Color.Transparent;
			this.groupBox_NewItem_ExcOpt.Controls.Add(this.radioButton_ExcWings);
			this.groupBox_NewItem_ExcOpt.Controls.Add(this.radioButton_ExcArmor);
			this.groupBox_NewItem_ExcOpt.Controls.Add(this.radioButton_ExcWeapon);
			this.groupBox_NewItem_ExcOpt.Controls.Add(this.checkBox_ExcOpt6);
			this.groupBox_NewItem_ExcOpt.Controls.Add(this.checkBox_ExcOpt5);
			this.groupBox_NewItem_ExcOpt.Controls.Add(this.checkBox_ExcOpt4);
			this.groupBox_NewItem_ExcOpt.Controls.Add(this.checkBox_ExcOpt3);
			this.groupBox_NewItem_ExcOpt.Controls.Add(this.checkBox_ExcOpt2);
			this.groupBox_NewItem_ExcOpt.Controls.Add(this.checkBox_ExcOpt1);
			this.groupBox_NewItem_ExcOpt.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.groupBox_NewItem_ExcOpt.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.groupBox_NewItem_ExcOpt.Location = new global::System.Drawing.Point(185, 272);
			this.groupBox_NewItem_ExcOpt.Name = "groupBox_NewItem_ExcOpt";
			this.groupBox_NewItem_ExcOpt.Size = new global::System.Drawing.Size(204, 151);
			this.groupBox_NewItem_ExcOpt.TabIndex = 18;
			this.groupBox_NewItem_ExcOpt.TabStop = false;
			this.groupBox_NewItem_ExcOpt.Text = "Excellent Options";
			this.radioButton_ExcWings.AutoSize = true;
			this.radioButton_ExcWings.Location = new global::System.Drawing.Point(136, 18);
			this.radioButton_ExcWings.Name = "radioButton_ExcWings";
			this.radioButton_ExcWings.Size = new global::System.Drawing.Size(55, 17);
			this.radioButton_ExcWings.TabIndex = 14;
			this.radioButton_ExcWings.Text = "Wings";
			this.radioButton_ExcWings.UseVisualStyleBackColor = true;
			this.radioButton_ExcWings.CheckedChanged += new global::System.EventHandler(this.radioButton_Exc_CheckedChanged);
			this.radioButton_ExcArmor.AutoSize = true;
			this.radioButton_ExcArmor.Location = new global::System.Drawing.Point(78, 18);
			this.radioButton_ExcArmor.Name = "radioButton_ExcArmor";
			this.radioButton_ExcArmor.Size = new global::System.Drawing.Size(52, 17);
			this.radioButton_ExcArmor.TabIndex = 13;
			this.radioButton_ExcArmor.Text = "Armor";
			this.radioButton_ExcArmor.UseVisualStyleBackColor = true;
			this.radioButton_ExcArmor.CheckedChanged += new global::System.EventHandler(this.radioButton_Exc_CheckedChanged);
			this.radioButton_ExcWeapon.AutoSize = true;
			this.radioButton_ExcWeapon.Location = new global::System.Drawing.Point(6, 18);
			this.radioButton_ExcWeapon.Name = "radioButton_ExcWeapon";
			this.radioButton_ExcWeapon.Size = new global::System.Drawing.Size(66, 17);
			this.radioButton_ExcWeapon.TabIndex = 12;
			this.radioButton_ExcWeapon.Text = "Weapon";
			this.radioButton_ExcWeapon.UseVisualStyleBackColor = true;
			this.radioButton_ExcWeapon.CheckedChanged += new global::System.EventHandler(this.radioButton_Exc_CheckedChanged);
			this.checkBox_ExcOpt6.AutoSize = true;
			this.checkBox_ExcOpt6.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.checkBox_ExcOpt6.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.checkBox_ExcOpt6.Location = new global::System.Drawing.Point(6, 133);
			this.checkBox_ExcOpt6.Name = "checkBox_ExcOpt6";
			this.checkBox_ExcOpt6.Size = new global::System.Drawing.Size(80, 17);
			this.checkBox_ExcOpt6.TabIndex = 20;
			this.checkBox_ExcOpt6.Text = "checkBox6";
			this.checkBox_ExcOpt6.UseVisualStyleBackColor = true;
			this.checkBox_ExcOpt5.AutoSize = true;
			this.checkBox_ExcOpt5.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.checkBox_ExcOpt5.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.checkBox_ExcOpt5.Location = new global::System.Drawing.Point(6, 115);
			this.checkBox_ExcOpt5.Name = "checkBox_ExcOpt5";
			this.checkBox_ExcOpt5.Size = new global::System.Drawing.Size(80, 17);
			this.checkBox_ExcOpt5.TabIndex = 19;
			this.checkBox_ExcOpt5.Text = "checkBox5";
			this.checkBox_ExcOpt5.UseVisualStyleBackColor = true;
			this.checkBox_ExcOpt4.AutoSize = true;
			this.checkBox_ExcOpt4.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.checkBox_ExcOpt4.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.checkBox_ExcOpt4.Location = new global::System.Drawing.Point(6, 97);
			this.checkBox_ExcOpt4.Name = "checkBox_ExcOpt4";
			this.checkBox_ExcOpt4.Size = new global::System.Drawing.Size(80, 17);
			this.checkBox_ExcOpt4.TabIndex = 18;
			this.checkBox_ExcOpt4.Text = "checkBox4";
			this.checkBox_ExcOpt4.UseVisualStyleBackColor = true;
			this.checkBox_ExcOpt3.AutoSize = true;
			this.checkBox_ExcOpt3.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.checkBox_ExcOpt3.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.checkBox_ExcOpt3.Location = new global::System.Drawing.Point(6, 78);
			this.checkBox_ExcOpt3.Name = "checkBox_ExcOpt3";
			this.checkBox_ExcOpt3.Size = new global::System.Drawing.Size(80, 17);
			this.checkBox_ExcOpt3.TabIndex = 17;
			this.checkBox_ExcOpt3.Text = "checkBox3";
			this.checkBox_ExcOpt3.UseVisualStyleBackColor = true;
			this.checkBox_ExcOpt2.AutoSize = true;
			this.checkBox_ExcOpt2.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.checkBox_ExcOpt2.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.checkBox_ExcOpt2.Location = new global::System.Drawing.Point(6, 60);
			this.checkBox_ExcOpt2.Name = "checkBox_ExcOpt2";
			this.checkBox_ExcOpt2.Size = new global::System.Drawing.Size(80, 17);
			this.checkBox_ExcOpt2.TabIndex = 16;
			this.checkBox_ExcOpt2.Text = "checkBox2";
			this.checkBox_ExcOpt2.UseVisualStyleBackColor = true;
			this.checkBox_ExcOpt1.AutoSize = true;
			this.checkBox_ExcOpt1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.checkBox_ExcOpt1.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.checkBox_ExcOpt1.Location = new global::System.Drawing.Point(6, 42);
			this.checkBox_ExcOpt1.Name = "checkBox_ExcOpt1";
			this.checkBox_ExcOpt1.Size = new global::System.Drawing.Size(80, 17);
			this.checkBox_ExcOpt1.TabIndex = 15;
			this.checkBox_ExcOpt1.Text = "checkBox1";
			this.checkBox_ExcOpt1.UseVisualStyleBackColor = true;
			this.label_Size.AutoSize = true;
			this.label_Size.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.label_Size.Location = new global::System.Drawing.Point(363, 253);
			this.label_Size.Name = "label_Size";
			this.label_Size.Size = new global::System.Drawing.Size(25, 14);
			this.label_Size.TabIndex = 19;
			this.label_Size.Text = "1x1";
			this.button_Update.Enabled = false;
			this.button_Update.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			this.button_Update.Location = new global::System.Drawing.Point(12, 393);
			this.button_Update.Name = "button_Update";
			this.button_Update.Size = new global::System.Drawing.Size(78, 30);
			this.button_Update.TabIndex = 21;
			this.button_Update.Text = "Update Item";
			this.button_Update.UseVisualStyleBackColor = true;
			this.button_Update.Click += new global::System.EventHandler(this.button_Update_Click);
			this.checkBox_FO.AutoSize = true;
			this.checkBox_FO.Location = new global::System.Drawing.Point(133, 239);
			this.checkBox_FO.Name = "checkBox_FO";
			this.checkBox_FO.Size = new global::System.Drawing.Size(90, 28);
			this.checkBox_FO.TabIndex = 11;
			this.checkBox_FO.Text = "FO \r\n+15+28+Luck";
			this.checkBox_FO.UseVisualStyleBackColor = true;
			this.checkBox_FO.CheckedChanged += new global::System.EventHandler(this.checkBox_FO_CheckedChanged);
			this.label_FileName.BackColor = global::System.Drawing.Color.Black;
			this.label_FileName.ForeColor = global::System.Drawing.Color.White;
			this.label_FileName.Location = new global::System.Drawing.Point(412, 32);
			this.label_FileName.Name = "label_FileName";
			this.label_FileName.Size = new global::System.Drawing.Size(208, 15);
			this.label_FileName.TabIndex = 23;
			this.label_FileName.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(652, 434);
			base.Controls.Add(this.label_FileName);
			base.Controls.Add(this.checkBox_FO);
			base.Controls.Add(this.button_Update);
			base.Controls.Add(this.label_Size);
			base.Controls.Add(this.groupBox_NewItem_ExcOpt);
			base.Controls.Add(this.button_Add);
			base.Controls.Add(this.pictureBox_ItemPreview);
			base.Controls.Add(this.groupBox5);
			base.Controls.Add(this.checkBox_Skill);
			base.Controls.Add(this.checkBox_Luck);
			base.Controls.Add(this.groupBox3);
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.listBox_Index);
			base.Controls.Add(this.listBox_Group);
			base.Controls.Add(this.pictureBox_Init_1x1);
			base.Controls.Add(this.pictureBox_ShopPreview);
			base.Controls.Add(this.menuStrip1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.MaximizeBox = false;
			base.Name = "ShopEditor";
			base.ShowIcon = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Shop Editor";
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.ShopEditor_FormClosed);
			base.Load += new global::System.EventHandler(this.ShopEditor_Load);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox_Init_1x1).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox_ShopPreview).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Durability).EndInit();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox_ItemPreview).EndInit();
			this.groupBox_NewItem_ExcOpt.ResumeLayout(false);
			this.groupBox_NewItem_ExcOpt.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040001FB RID: 507
		private global::System.Windows.Forms.Button button_Add;

		// Token: 0x040001FC RID: 508
		private global::System.Windows.Forms.Button button_Update;

		// Token: 0x040001FF RID: 511
		private global::System.Windows.Forms.CheckBox checkBox_DurLock;

		// Token: 0x04000200 RID: 512
		public global::System.Windows.Forms.CheckBox checkBox_ExcOpt1;

		// Token: 0x04000201 RID: 513
		public global::System.Windows.Forms.CheckBox checkBox_ExcOpt2;

		// Token: 0x04000202 RID: 514
		public global::System.Windows.Forms.CheckBox checkBox_ExcOpt3;

		// Token: 0x04000203 RID: 515
		public global::System.Windows.Forms.CheckBox checkBox_ExcOpt4;

		// Token: 0x04000204 RID: 516
		public global::System.Windows.Forms.CheckBox checkBox_ExcOpt5;

		// Token: 0x04000205 RID: 517
		public global::System.Windows.Forms.CheckBox checkBox_ExcOpt6;

		// Token: 0x04000206 RID: 518
		private global::System.Windows.Forms.CheckBox checkBox_FO;

		// Token: 0x04000207 RID: 519
		private global::System.Windows.Forms.CheckBox checkBox_Luck;

		// Token: 0x04000208 RID: 520
		private global::System.Windows.Forms.CheckBox checkBox_Skill;

		// Token: 0x04000209 RID: 521
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400020B RID: 523
		private global::System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;

		// Token: 0x0400020C RID: 524
		private global::System.Windows.Forms.GroupBox groupBox_NewItem_ExcOpt;

		// Token: 0x0400020D RID: 525
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x0400020E RID: 526
		private global::System.Windows.Forms.GroupBox groupBox2;

		// Token: 0x0400020F RID: 527
		private global::System.Windows.Forms.GroupBox groupBox3;

		// Token: 0x04000210 RID: 528
		private global::System.Windows.Forms.GroupBox groupBox5;

		// Token: 0x04000225 RID: 549
		private global::System.Windows.Forms.Label label_FileName;

		// Token: 0x04000226 RID: 550
		private global::System.Windows.Forms.Label label_Size;

		// Token: 0x04000229 RID: 553
		private global::System.Windows.Forms.ListBox listBox_Group;

		// Token: 0x0400022A RID: 554
		private global::System.Windows.Forms.ListBox listBox_Index;

		// Token: 0x0400022B RID: 555
		private global::System.Windows.Forms.ListBox listBox_Level;

		// Token: 0x0400022C RID: 556
		private global::System.Windows.Forms.ListBox listBox_Option;

		// Token: 0x0400022D RID: 557
		private global::System.Windows.Forms.MenuStrip menuStrip1;

		// Token: 0x0400022E RID: 558
		private global::System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;

		// Token: 0x0400022F RID: 559
		private global::System.Windows.Forms.NumericUpDown numericUpDown_Durability;

		// Token: 0x04000232 RID: 562
		private global::System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;

		// Token: 0x04000233 RID: 563
		private global::System.Windows.Forms.PictureBox pictureBox_Init_1x1;

		// Token: 0x04000234 RID: 564
		private global::System.Windows.Forms.PictureBox pictureBox_ItemPreview;

		// Token: 0x04000235 RID: 565
		private global::System.Windows.Forms.PictureBox pictureBox_ShopPreview;

		// Token: 0x04000236 RID: 566
		private global::System.Windows.Forms.RadioButton radioButton_Ancient_Level1;

		// Token: 0x04000237 RID: 567
		private global::System.Windows.Forms.RadioButton radioButton_Ancient_Level2;

		// Token: 0x04000238 RID: 568
		private global::System.Windows.Forms.RadioButton radioButton_Ancient_None;

		// Token: 0x04000239 RID: 569
		private global::System.Windows.Forms.RadioButton radioButton_ExcArmor;

		// Token: 0x0400023A RID: 570
		private global::System.Windows.Forms.RadioButton radioButton_ExcWeapon;

		// Token: 0x0400023B RID: 571
		private global::System.Windows.Forms.RadioButton radioButton_ExcWings;

		// Token: 0x0400023C RID: 572
		private global::System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
	}
}
