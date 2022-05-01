namespace MU_ToolKit
{
	// Token: 0x0200002A RID: 42
	public partial class Form_DropManager : global::System.Windows.Forms.Form
	{
		// Token: 0x060005F7 RID: 1527 RVA: 0x00065A1F File Offset: 0x00063C1F
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060005FC RID: 1532 RVA: 0x00065FA8 File Offset: 0x000641A8
		private void InitializeComponent()
		{
			this.menuStrip1 = new global::System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.saveAsToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.pictureBox_New_iPicture = new global::System.Windows.Forms.PictureBox();
			this.groupBox7 = new global::System.Windows.Forms.GroupBox();
			this.label17 = new global::System.Windows.Forms.Label();
			this.numericUpDown_New_MobMaxLv = new global::System.Windows.Forms.NumericUpDown();
			this.label18 = new global::System.Windows.Forms.Label();
			this.label19 = new global::System.Windows.Forms.Label();
			this.numericUpDown_New_MobMinLv = new global::System.Windows.Forms.NumericUpDown();
			this.comboBox_New_Map = new global::System.Windows.Forms.ComboBox();
			this.comboBox_New_Mob = new global::System.Windows.Forms.ComboBox();
			this.label20 = new global::System.Windows.Forms.Label();
			this.numericUpDown_New_DropRate = new global::System.Windows.Forms.NumericUpDown();
			this.groupBox5 = new global::System.Windows.Forms.GroupBox();
			this.label12 = new global::System.Windows.Forms.Label();
			this.label13 = new global::System.Windows.Forms.Label();
			this.numericUpDown_New_ItemMinLv = new global::System.Windows.Forms.NumericUpDown();
			this.numericUpDown_New_ItemMaxLv = new global::System.Windows.Forms.NumericUpDown();
			this.checkBox_New_Skill = new global::System.Windows.Forms.CheckBox();
			this.numericUpDown_New_Durability = new global::System.Windows.Forms.NumericUpDown();
			this.checkBox_New_Luck = new global::System.Windows.Forms.CheckBox();
			this.label14 = new global::System.Windows.Forms.Label();
			this.label15 = new global::System.Windows.Forms.Label();
			this.groupBox6 = new global::System.Windows.Forms.GroupBox();
			this.checkBox_New_RandomExc = new global::System.Windows.Forms.CheckBox();
			this.radioButton_New_ExcWings = new global::System.Windows.Forms.RadioButton();
			this.radioButton_New_ExcArmor = new global::System.Windows.Forms.RadioButton();
			this.radioButton_New_ExcWeapon = new global::System.Windows.Forms.RadioButton();
			this.checkBox_New_ExcOpt6 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_New_ExcOpt5 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_New_ExcOpt4 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_New_ExcOpt3 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_New_ExcOpt2 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_New_ExcOpt1 = new global::System.Windows.Forms.CheckBox();
			this.comboBox_New_Opt = new global::System.Windows.Forms.ComboBox();
			this.comboBox_New_Ancient = new global::System.Windows.Forms.ComboBox();
			this.label16 = new global::System.Windows.Forms.Label();
			this.label21 = new global::System.Windows.Forms.Label();
			this.listBox_New_iIndex = new global::System.Windows.Forms.ListBox();
			this.label22 = new global::System.Windows.Forms.Label();
			this.listBox_New_iGroup = new global::System.Windows.Forms.ListBox();
			this.groupBox2 = new global::System.Windows.Forms.GroupBox();
			this.button_Existing_RemoveSelected = new global::System.Windows.Forms.Button();
			this.button_Existing_UpdateSelected = new global::System.Windows.Forms.Button();
			this.groupBox4 = new global::System.Windows.Forms.GroupBox();
			this.label9 = new global::System.Windows.Forms.Label();
			this.numericUpDown_Existing_MobMaxLv = new global::System.Windows.Forms.NumericUpDown();
			this.label8 = new global::System.Windows.Forms.Label();
			this.label6 = new global::System.Windows.Forms.Label();
			this.numericUpDown_Existing_MobMinLv = new global::System.Windows.Forms.NumericUpDown();
			this.comboBox_Existing_Map = new global::System.Windows.Forms.ComboBox();
			this.comboBox_Existing_Mob = new global::System.Windows.Forms.ComboBox();
			this.label7 = new global::System.Windows.Forms.Label();
			this.numericUpDown_Existing_DropRate = new global::System.Windows.Forms.NumericUpDown();
			this.label10 = new global::System.Windows.Forms.Label();
			this.groupBox3 = new global::System.Windows.Forms.GroupBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.numericUpDown_Existing_ItemMinLv = new global::System.Windows.Forms.NumericUpDown();
			this.numericUpDown_Existing_ItemMaxLv = new global::System.Windows.Forms.NumericUpDown();
			this.checkBox_Existing_Skill = new global::System.Windows.Forms.CheckBox();
			this.numericUpDown_Existing_Durability = new global::System.Windows.Forms.NumericUpDown();
			this.checkBox_Existing_Luck = new global::System.Windows.Forms.CheckBox();
			this.label5 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.groupBox_NewItem_ExcOpt = new global::System.Windows.Forms.GroupBox();
			this.checkBox_Existing_RandomExc = new global::System.Windows.Forms.CheckBox();
			this.radioButton_Existing_ExcWings = new global::System.Windows.Forms.RadioButton();
			this.radioButton_Existing_ExcArmor = new global::System.Windows.Forms.RadioButton();
			this.radioButton_Existing_ExcWeapon = new global::System.Windows.Forms.RadioButton();
			this.checkBox_Existing_ExcOpt6 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_Existing_ExcOpt5 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_Existing_ExcOpt4 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_Existing_ExcOpt3 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_Existing_ExcOpt2 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_Existing_ExcOpt1 = new global::System.Windows.Forms.CheckBox();
			this.comboBox_Existing_Opt = new global::System.Windows.Forms.ComboBox();
			this.comboBox_Existing_Ancient = new global::System.Windows.Forms.ComboBox();
			this.label4 = new global::System.Windows.Forms.Label();
			this.listBox_DropItems = new global::System.Windows.Forms.ListBox();
			this.label11 = new global::System.Windows.Forms.Label();
			this.button_New_Add = new global::System.Windows.Forms.Button();
			this.menuStrip1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox_New_iPicture).BeginInit();
			this.groupBox7.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_New_MobMaxLv).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_New_MobMinLv).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_New_DropRate).BeginInit();
			this.groupBox5.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_New_ItemMinLv).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_New_ItemMaxLv).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_New_Durability).BeginInit();
			this.groupBox6.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox4.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Existing_MobMaxLv).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Existing_MobMinLv).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Existing_DropRate).BeginInit();
			this.groupBox3.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Existing_ItemMinLv).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Existing_ItemMaxLv).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Existing_Durability).BeginInit();
			this.groupBox_NewItem_ExcOpt.SuspendLayout();
			base.SuspendLayout();
			this.menuStrip1.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.menuStrip1.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.fileToolStripMenuItem
			});
			this.menuStrip1.Location = new global::System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new global::System.Drawing.Size(845, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			this.fileToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.newToolStripMenuItem,
				this.openToolStripMenuItem,
				this.saveAsToolStripMenuItem
			});
			this.fileToolStripMenuItem.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new global::System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.Size = new global::System.Drawing.Size(122, 22);
			this.newToolStripMenuItem.Text = "New";
			this.newToolStripMenuItem.Click += new global::System.EventHandler(this.newToolStripMenuItem_Click);
			this.openToolStripMenuItem.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new global::System.Drawing.Size(122, 22);
			this.openToolStripMenuItem.Text = "Open";
			this.openToolStripMenuItem.Click += new global::System.EventHandler(this.openToolStripMenuItem_Click);
			this.saveAsToolStripMenuItem.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.Size = new global::System.Drawing.Size(122, 22);
			this.saveAsToolStripMenuItem.Text = "Save (As)";
			this.saveAsToolStripMenuItem.Click += new global::System.EventHandler(this.saveAsToolStripMenuItem_Click);
			this.groupBox1.Controls.Add(this.pictureBox_New_iPicture);
			this.groupBox1.Controls.Add(this.groupBox7);
			this.groupBox1.Controls.Add(this.numericUpDown_New_DropRate);
			this.groupBox1.Controls.Add(this.groupBox5);
			this.groupBox1.Controls.Add(this.label21);
			this.groupBox1.Controls.Add(this.listBox_New_iIndex);
			this.groupBox1.Controls.Add(this.label22);
			this.groupBox1.Controls.Add(this.listBox_New_iGroup);
			this.groupBox1.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.groupBox1.Location = new global::System.Drawing.Point(12, 234);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(819, 210);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Add new Entry";
			this.pictureBox_New_iPicture.BackColor = global::System.Drawing.Color.Black;
			this.pictureBox_New_iPicture.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox_New_iPicture.Location = new global::System.Drawing.Point(6, 126);
			this.pictureBox_New_iPicture.Name = "pictureBox_New_iPicture";
			this.pictureBox_New_iPicture.Size = new global::System.Drawing.Size(128, 78);
			this.pictureBox_New_iPicture.TabIndex = 34;
			this.pictureBox_New_iPicture.TabStop = false;
			this.groupBox7.Controls.Add(this.label17);
			this.groupBox7.Controls.Add(this.numericUpDown_New_MobMaxLv);
			this.groupBox7.Controls.Add(this.label18);
			this.groupBox7.Controls.Add(this.label19);
			this.groupBox7.Controls.Add(this.numericUpDown_New_MobMinLv);
			this.groupBox7.Controls.Add(this.comboBox_New_Map);
			this.groupBox7.Controls.Add(this.comboBox_New_Mob);
			this.groupBox7.Controls.Add(this.label20);
			this.groupBox7.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.groupBox7.Location = new global::System.Drawing.Point(654, 19);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new global::System.Drawing.Size(159, 122);
			this.groupBox7.TabIndex = 30;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Drop Options";
			this.label17.AutoSize = true;
			this.label17.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label17.Location = new global::System.Drawing.Point(26, 97);
			this.label17.Name = "label17";
			this.label17.Size = new global::System.Drawing.Size(62, 15);
			this.label17.TabIndex = 26;
			this.label17.Text = "Max Level:";
			this.numericUpDown_New_MobMaxLv.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.numericUpDown_New_MobMaxLv.Location = new global::System.Drawing.Point(93, 95);
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.numericUpDown_New_MobMaxLv;
			int[] array = new int[4];
			array[0] = 150;
			numericUpDown.Maximum = new decimal(array);
			this.numericUpDown_New_MobMaxLv.Name = "numericUpDown_New_MobMaxLv";
			this.numericUpDown_New_MobMaxLv.Size = new global::System.Drawing.Size(45, 23);
			this.numericUpDown_New_MobMaxLv.TabIndex = 27;
			this.label18.AutoSize = true;
			this.label18.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label18.Location = new global::System.Drawing.Point(26, 71);
			this.label18.Name = "label18";
			this.label18.Size = new global::System.Drawing.Size(61, 15);
			this.label18.TabIndex = 22;
			this.label18.Text = "Min Level:";
			this.label19.AutoSize = true;
			this.label19.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label19.Location = new global::System.Drawing.Point(6, 21);
			this.label19.Name = "label19";
			this.label19.Size = new global::System.Drawing.Size(34, 15);
			this.label19.TabIndex = 22;
			this.label19.Text = "Map:";
			this.numericUpDown_New_MobMinLv.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.numericUpDown_New_MobMinLv.Location = new global::System.Drawing.Point(93, 68);
			this.numericUpDown_New_MobMinLv.Name = "numericUpDown_New_MobMinLv";
			this.numericUpDown_New_MobMinLv.Size = new global::System.Drawing.Size(45, 23);
			this.numericUpDown_New_MobMinLv.TabIndex = 23;
			this.comboBox_New_Map.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.comboBox_New_Map.FormattingEnabled = true;
			this.comboBox_New_Map.Location = new global::System.Drawing.Point(46, 17);
			this.comboBox_New_Map.Name = "comboBox_New_Map";
			this.comboBox_New_Map.Size = new global::System.Drawing.Size(107, 23);
			this.comboBox_New_Map.TabIndex = 23;
			this.comboBox_New_Map.Leave += new global::System.EventHandler(this.comboBox_VerifyValidItem);
			this.comboBox_New_Mob.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.comboBox_New_Mob.FormattingEnabled = true;
			this.comboBox_New_Mob.Location = new global::System.Drawing.Point(46, 42);
			this.comboBox_New_Mob.Name = "comboBox_New_Mob";
			this.comboBox_New_Mob.Size = new global::System.Drawing.Size(107, 23);
			this.comboBox_New_Mob.TabIndex = 25;
			this.comboBox_New_Mob.Leave += new global::System.EventHandler(this.comboBox_VerifyValidItem);
			this.label20.AutoSize = true;
			this.label20.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label20.Location = new global::System.Drawing.Point(6, 46);
			this.label20.Name = "label20";
			this.label20.Size = new global::System.Drawing.Size(35, 15);
			this.label20.TabIndex = 24;
			this.label20.Text = "Mob:";
			this.numericUpDown_New_DropRate.DecimalPlaces = 2;
			this.numericUpDown_New_DropRate.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.numericUpDown_New_DropRate.Location = new global::System.Drawing.Point(727, 147);
			this.numericUpDown_New_DropRate.Name = "numericUpDown_New_DropRate";
			this.numericUpDown_New_DropRate.Size = new global::System.Drawing.Size(50, 23);
			this.numericUpDown_New_DropRate.TabIndex = 31;
			this.numericUpDown_New_DropRate.UpDownAlign = global::System.Windows.Forms.LeftRightAlignment.Left;
			this.groupBox5.Controls.Add(this.label12);
			this.groupBox5.Controls.Add(this.label13);
			this.groupBox5.Controls.Add(this.numericUpDown_New_ItemMinLv);
			this.groupBox5.Controls.Add(this.numericUpDown_New_ItemMaxLv);
			this.groupBox5.Controls.Add(this.checkBox_New_Skill);
			this.groupBox5.Controls.Add(this.numericUpDown_New_Durability);
			this.groupBox5.Controls.Add(this.checkBox_New_Luck);
			this.groupBox5.Controls.Add(this.label14);
			this.groupBox5.Controls.Add(this.label15);
			this.groupBox5.Controls.Add(this.groupBox6);
			this.groupBox5.Controls.Add(this.comboBox_New_Opt);
			this.groupBox5.Controls.Add(this.comboBox_New_Ancient);
			this.groupBox5.Controls.Add(this.label16);
			this.groupBox5.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.groupBox5.Location = new global::System.Drawing.Point(303, 18);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new global::System.Drawing.Size(345, 180);
			this.groupBox5.TabIndex = 27;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Item Options";
			this.label12.AutoSize = true;
			this.label12.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label12.Location = new global::System.Drawing.Point(6, 18);
			this.label12.Name = "label12";
			this.label12.Size = new global::System.Drawing.Size(61, 15);
			this.label12.TabIndex = 1;
			this.label12.Text = "Min Level:";
			this.label13.AutoSize = true;
			this.label13.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label13.Location = new global::System.Drawing.Point(6, 42);
			this.label13.Name = "label13";
			this.label13.Size = new global::System.Drawing.Size(62, 15);
			this.label13.TabIndex = 2;
			this.label13.Text = "Max Level:";
			this.numericUpDown_New_ItemMinLv.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.numericUpDown_New_ItemMinLv.Location = new global::System.Drawing.Point(71, 17);
			this.numericUpDown_New_ItemMinLv.Name = "numericUpDown_New_ItemMinLv";
			this.numericUpDown_New_ItemMinLv.Size = new global::System.Drawing.Size(58, 23);
			this.numericUpDown_New_ItemMinLv.TabIndex = 3;
			this.numericUpDown_New_ItemMaxLv.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.numericUpDown_New_ItemMaxLv.Location = new global::System.Drawing.Point(71, 41);
			global::System.Windows.Forms.NumericUpDown numericUpDown2 = this.numericUpDown_New_ItemMaxLv;
			int[] array2 = new int[4];
			array2[0] = 15;
			numericUpDown2.Maximum = new decimal(array2);
			this.numericUpDown_New_ItemMaxLv.Name = "numericUpDown_New_ItemMaxLv";
			this.numericUpDown_New_ItemMaxLv.Size = new global::System.Drawing.Size(58, 23);
			this.numericUpDown_New_ItemMaxLv.TabIndex = 4;
			this.checkBox_New_Skill.AutoSize = true;
			this.checkBox_New_Skill.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox_New_Skill.Location = new global::System.Drawing.Point(17, 142);
			this.checkBox_New_Skill.Name = "checkBox_New_Skill";
			this.checkBox_New_Skill.Size = new global::System.Drawing.Size(47, 19);
			this.checkBox_New_Skill.TabIndex = 5;
			this.checkBox_New_Skill.Text = "Skill";
			this.checkBox_New_Skill.UseVisualStyleBackColor = true;
			this.numericUpDown_New_Durability.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.numericUpDown_New_Durability.Location = new global::System.Drawing.Point(73, 114);
			global::System.Windows.Forms.NumericUpDown numericUpDown3 = this.numericUpDown_New_Durability;
			int[] array3 = new int[4];
			array3[0] = 255;
			numericUpDown3.Maximum = new decimal(array3);
			this.numericUpDown_New_Durability.Name = "numericUpDown_New_Durability";
			this.numericUpDown_New_Durability.Size = new global::System.Drawing.Size(56, 23);
			this.numericUpDown_New_Durability.TabIndex = 21;
			global::System.Windows.Forms.NumericUpDown numericUpDown4 = this.numericUpDown_New_Durability;
			int[] array4 = new int[4];
			array4[0] = 255;
			numericUpDown4.Value = new decimal(array4);
			this.checkBox_New_Luck.AutoSize = true;
			this.checkBox_New_Luck.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox_New_Luck.Location = new global::System.Drawing.Point(76, 142);
			this.checkBox_New_Luck.Name = "checkBox_New_Luck";
			this.checkBox_New_Luck.Size = new global::System.Drawing.Size(51, 19);
			this.checkBox_New_Luck.TabIndex = 6;
			this.checkBox_New_Luck.Text = "Luck";
			this.checkBox_New_Luck.UseVisualStyleBackColor = true;
			this.label14.AutoSize = true;
			this.label14.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label14.Location = new global::System.Drawing.Point(6, 117);
			this.label14.Name = "label14";
			this.label14.Size = new global::System.Drawing.Size(61, 15);
			this.label14.TabIndex = 20;
			this.label14.Text = "Durability:";
			this.label15.AutoSize = true;
			this.label15.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label15.Location = new global::System.Drawing.Point(6, 67);
			this.label15.Name = "label15";
			this.label15.Size = new global::System.Drawing.Size(47, 15);
			this.label15.TabIndex = 7;
			this.label15.Text = "Option:";
			this.groupBox6.BackColor = global::System.Drawing.Color.Transparent;
			this.groupBox6.Controls.Add(this.checkBox_New_RandomExc);
			this.groupBox6.Controls.Add(this.radioButton_New_ExcWings);
			this.groupBox6.Controls.Add(this.radioButton_New_ExcArmor);
			this.groupBox6.Controls.Add(this.radioButton_New_ExcWeapon);
			this.groupBox6.Controls.Add(this.checkBox_New_ExcOpt6);
			this.groupBox6.Controls.Add(this.checkBox_New_ExcOpt5);
			this.groupBox6.Controls.Add(this.checkBox_New_ExcOpt4);
			this.groupBox6.Controls.Add(this.checkBox_New_ExcOpt3);
			this.groupBox6.Controls.Add(this.checkBox_New_ExcOpt2);
			this.groupBox6.Controls.Add(this.checkBox_New_ExcOpt1);
			this.groupBox6.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.groupBox6.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.groupBox6.Location = new global::System.Drawing.Point(135, 19);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new global::System.Drawing.Size(204, 151);
			this.groupBox6.TabIndex = 19;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Excellent Options     ";
			this.checkBox_New_RandomExc.AutoSize = true;
			this.checkBox_New_RandomExc.BackColor = global::System.Drawing.SystemColors.Control;
			this.checkBox_New_RandomExc.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox_New_RandomExc.Location = new global::System.Drawing.Point(107, 0);
			this.checkBox_New_RandomExc.Name = "checkBox_New_RandomExc";
			this.checkBox_New_RandomExc.Size = new global::System.Drawing.Size(71, 19);
			this.checkBox_New_RandomExc.TabIndex = 21;
			this.checkBox_New_RandomExc.Text = "Random";
			this.checkBox_New_RandomExc.UseVisualStyleBackColor = false;
			this.radioButton_New_ExcWings.AutoSize = true;
			this.radioButton_New_ExcWings.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.radioButton_New_ExcWings.Location = new global::System.Drawing.Point(136, 18);
			this.radioButton_New_ExcWings.Name = "radioButton_New_ExcWings";
			this.radioButton_New_ExcWings.Size = new global::System.Drawing.Size(58, 19);
			this.radioButton_New_ExcWings.TabIndex = 14;
			this.radioButton_New_ExcWings.Text = "Wings";
			this.radioButton_New_ExcWings.UseVisualStyleBackColor = true;
			this.radioButton_New_ExcWings.CheckedChanged += new global::System.EventHandler(this.radioButton_New_ExcWings_CheckedChanged);
			this.radioButton_New_ExcArmor.AutoSize = true;
			this.radioButton_New_ExcArmor.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.radioButton_New_ExcArmor.Location = new global::System.Drawing.Point(78, 18);
			this.radioButton_New_ExcArmor.Name = "radioButton_New_ExcArmor";
			this.radioButton_New_ExcArmor.Size = new global::System.Drawing.Size(59, 19);
			this.radioButton_New_ExcArmor.TabIndex = 13;
			this.radioButton_New_ExcArmor.Text = "Armor";
			this.radioButton_New_ExcArmor.UseVisualStyleBackColor = true;
			this.radioButton_New_ExcArmor.CheckedChanged += new global::System.EventHandler(this.radioButton_New_ExcArmor_CheckedChanged);
			this.radioButton_New_ExcWeapon.AutoSize = true;
			this.radioButton_New_ExcWeapon.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.radioButton_New_ExcWeapon.Location = new global::System.Drawing.Point(6, 18);
			this.radioButton_New_ExcWeapon.Name = "radioButton_New_ExcWeapon";
			this.radioButton_New_ExcWeapon.Size = new global::System.Drawing.Size(69, 19);
			this.radioButton_New_ExcWeapon.TabIndex = 12;
			this.radioButton_New_ExcWeapon.Text = "Weapon";
			this.radioButton_New_ExcWeapon.UseVisualStyleBackColor = true;
			this.radioButton_New_ExcWeapon.CheckedChanged += new global::System.EventHandler(this.radioButton_New_ExcWeapon_CheckedChanged);
			this.checkBox_New_ExcOpt6.AutoSize = true;
			this.checkBox_New_ExcOpt6.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox_New_ExcOpt6.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.checkBox_New_ExcOpt6.Location = new global::System.Drawing.Point(6, 133);
			this.checkBox_New_ExcOpt6.Name = "checkBox_New_ExcOpt6";
			this.checkBox_New_ExcOpt6.Size = new global::System.Drawing.Size(82, 19);
			this.checkBox_New_ExcOpt6.TabIndex = 20;
			this.checkBox_New_ExcOpt6.Text = "checkBox6";
			this.checkBox_New_ExcOpt6.UseVisualStyleBackColor = true;
			this.checkBox_New_ExcOpt5.AutoSize = true;
			this.checkBox_New_ExcOpt5.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox_New_ExcOpt5.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.checkBox_New_ExcOpt5.Location = new global::System.Drawing.Point(6, 115);
			this.checkBox_New_ExcOpt5.Name = "checkBox_New_ExcOpt5";
			this.checkBox_New_ExcOpt5.Size = new global::System.Drawing.Size(82, 19);
			this.checkBox_New_ExcOpt5.TabIndex = 19;
			this.checkBox_New_ExcOpt5.Text = "checkBox5";
			this.checkBox_New_ExcOpt5.UseVisualStyleBackColor = true;
			this.checkBox_New_ExcOpt4.AutoSize = true;
			this.checkBox_New_ExcOpt4.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox_New_ExcOpt4.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.checkBox_New_ExcOpt4.Location = new global::System.Drawing.Point(6, 97);
			this.checkBox_New_ExcOpt4.Name = "checkBox_New_ExcOpt4";
			this.checkBox_New_ExcOpt4.Size = new global::System.Drawing.Size(82, 19);
			this.checkBox_New_ExcOpt4.TabIndex = 18;
			this.checkBox_New_ExcOpt4.Text = "checkBox4";
			this.checkBox_New_ExcOpt4.UseVisualStyleBackColor = true;
			this.checkBox_New_ExcOpt3.AutoSize = true;
			this.checkBox_New_ExcOpt3.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox_New_ExcOpt3.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.checkBox_New_ExcOpt3.Location = new global::System.Drawing.Point(6, 78);
			this.checkBox_New_ExcOpt3.Name = "checkBox_New_ExcOpt3";
			this.checkBox_New_ExcOpt3.Size = new global::System.Drawing.Size(82, 19);
			this.checkBox_New_ExcOpt3.TabIndex = 17;
			this.checkBox_New_ExcOpt3.Text = "checkBox3";
			this.checkBox_New_ExcOpt3.UseVisualStyleBackColor = true;
			this.checkBox_New_ExcOpt2.AutoSize = true;
			this.checkBox_New_ExcOpt2.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox_New_ExcOpt2.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.checkBox_New_ExcOpt2.Location = new global::System.Drawing.Point(6, 60);
			this.checkBox_New_ExcOpt2.Name = "checkBox_New_ExcOpt2";
			this.checkBox_New_ExcOpt2.Size = new global::System.Drawing.Size(82, 19);
			this.checkBox_New_ExcOpt2.TabIndex = 16;
			this.checkBox_New_ExcOpt2.Text = "checkBox2";
			this.checkBox_New_ExcOpt2.UseVisualStyleBackColor = true;
			this.checkBox_New_ExcOpt1.AutoSize = true;
			this.checkBox_New_ExcOpt1.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox_New_ExcOpt1.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.checkBox_New_ExcOpt1.Location = new global::System.Drawing.Point(6, 42);
			this.checkBox_New_ExcOpt1.Name = "checkBox_New_ExcOpt1";
			this.checkBox_New_ExcOpt1.Size = new global::System.Drawing.Size(82, 19);
			this.checkBox_New_ExcOpt1.TabIndex = 15;
			this.checkBox_New_ExcOpt1.Text = "checkBox1";
			this.checkBox_New_ExcOpt1.UseVisualStyleBackColor = true;
			this.comboBox_New_Opt.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_New_Opt.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.comboBox_New_Opt.FormattingEnabled = true;
			this.comboBox_New_Opt.Location = new global::System.Drawing.Point(64, 65);
			this.comboBox_New_Opt.Name = "comboBox_New_Opt";
			this.comboBox_New_Opt.Size = new global::System.Drawing.Size(65, 23);
			this.comboBox_New_Opt.TabIndex = 8;
			this.comboBox_New_Ancient.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_New_Ancient.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.comboBox_New_Ancient.FormattingEnabled = true;
			this.comboBox_New_Ancient.Location = new global::System.Drawing.Point(64, 90);
			this.comboBox_New_Ancient.Name = "comboBox_New_Ancient";
			this.comboBox_New_Ancient.Size = new global::System.Drawing.Size(65, 23);
			this.comboBox_New_Ancient.TabIndex = 10;
			this.label16.AutoSize = true;
			this.label16.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label16.Location = new global::System.Drawing.Point(6, 92);
			this.label16.Name = "label16";
			this.label16.Size = new global::System.Drawing.Size(51, 15);
			this.label16.TabIndex = 9;
			this.label16.Text = "Ancient:";
			this.label21.AutoSize = true;
			this.label21.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label21.Location = new global::System.Drawing.Point(659, 150);
			this.label21.Name = "label21";
			this.label21.Size = new global::System.Drawing.Size(62, 15);
			this.label21.TabIndex = 32;
			this.label21.Text = "Drop Rate:";
			this.listBox_New_iIndex.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.listBox_New_iIndex.FormattingEnabled = true;
			this.listBox_New_iIndex.ItemHeight = 15;
			this.listBox_New_iIndex.Location = new global::System.Drawing.Point(140, 20);
			this.listBox_New_iIndex.Name = "listBox_New_iIndex";
			this.listBox_New_iIndex.Size = new global::System.Drawing.Size(156, 184);
			this.listBox_New_iIndex.TabIndex = 32;
			this.listBox_New_iIndex.SelectedIndexChanged += new global::System.EventHandler(this.listBox_New_iIndex_SelectedIndexChanged);
			this.label22.AutoSize = true;
			this.label22.Font = new global::System.Drawing.Font("Segoe UI", 11f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label22.Location = new global::System.Drawing.Point(775, 148);
			this.label22.Name = "label22";
			this.label22.Size = new global::System.Drawing.Size(21, 20);
			this.label22.TabIndex = 33;
			this.label22.Text = "%";
			this.listBox_New_iGroup.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.listBox_New_iGroup.FormattingEnabled = true;
			this.listBox_New_iGroup.ItemHeight = 15;
			this.listBox_New_iGroup.Location = new global::System.Drawing.Point(6, 20);
			this.listBox_New_iGroup.Name = "listBox_New_iGroup";
			this.listBox_New_iGroup.Size = new global::System.Drawing.Size(128, 94);
			this.listBox_New_iGroup.TabIndex = 31;
			this.listBox_New_iGroup.SelectedIndexChanged += new global::System.EventHandler(this.listBox_New_iGroup_SelectedIndexChanged);
			this.groupBox2.Controls.Add(this.button_Existing_RemoveSelected);
			this.groupBox2.Controls.Add(this.button_Existing_UpdateSelected);
			this.groupBox2.Controls.Add(this.groupBox4);
			this.groupBox2.Controls.Add(this.numericUpDown_Existing_DropRate);
			this.groupBox2.Controls.Add(this.label10);
			this.groupBox2.Controls.Add(this.groupBox3);
			this.groupBox2.Controls.Add(this.listBox_DropItems);
			this.groupBox2.Controls.Add(this.label11);
			this.groupBox2.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.groupBox2.Location = new global::System.Drawing.Point(12, 35);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new global::System.Drawing.Size(819, 194);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Existing Entries";
			this.button_Existing_RemoveSelected.Location = new global::System.Drawing.Point(6, 163);
			this.button_Existing_RemoveSelected.Name = "button_Existing_RemoveSelected";
			this.button_Existing_RemoveSelected.Size = new global::System.Drawing.Size(203, 21);
			this.button_Existing_RemoveSelected.TabIndex = 31;
			this.button_Existing_RemoveSelected.Text = "Remove Selected";
			this.button_Existing_RemoveSelected.UseVisualStyleBackColor = true;
			this.button_Existing_RemoveSelected.Click += new global::System.EventHandler(this.button_Existing_RemoveSelected_Click);
			this.button_Existing_UpdateSelected.Location = new global::System.Drawing.Point(566, 149);
			this.button_Existing_UpdateSelected.Name = "button_Existing_UpdateSelected";
			this.button_Existing_UpdateSelected.Size = new global::System.Drawing.Size(247, 39);
			this.button_Existing_UpdateSelected.TabIndex = 30;
			this.button_Existing_UpdateSelected.Text = "Update Selected Entry";
			this.button_Existing_UpdateSelected.UseVisualStyleBackColor = true;
			this.button_Existing_UpdateSelected.Click += new global::System.EventHandler(this.button_Existing_UpdateSelected_Click);
			this.groupBox4.Controls.Add(this.label9);
			this.groupBox4.Controls.Add(this.numericUpDown_Existing_MobMaxLv);
			this.groupBox4.Controls.Add(this.label8);
			this.groupBox4.Controls.Add(this.label6);
			this.groupBox4.Controls.Add(this.numericUpDown_Existing_MobMinLv);
			this.groupBox4.Controls.Add(this.comboBox_Existing_Map);
			this.groupBox4.Controls.Add(this.comboBox_Existing_Mob);
			this.groupBox4.Controls.Add(this.label7);
			this.groupBox4.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.groupBox4.Location = new global::System.Drawing.Point(566, 18);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new global::System.Drawing.Size(247, 98);
			this.groupBox4.TabIndex = 27;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Drop Options";
			this.label9.AutoSize = true;
			this.label9.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label9.Location = new global::System.Drawing.Point(125, 71);
			this.label9.Name = "label9";
			this.label9.Size = new global::System.Drawing.Size(62, 15);
			this.label9.TabIndex = 26;
			this.label9.Text = "Max Level:";
			this.numericUpDown_Existing_MobMaxLv.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.numericUpDown_Existing_MobMaxLv.Location = new global::System.Drawing.Point(196, 68);
			global::System.Windows.Forms.NumericUpDown numericUpDown5 = this.numericUpDown_Existing_MobMaxLv;
			int[] array5 = new int[4];
			array5[0] = 150;
			numericUpDown5.Maximum = new decimal(array5);
			this.numericUpDown_Existing_MobMaxLv.Name = "numericUpDown_Existing_MobMaxLv";
			this.numericUpDown_Existing_MobMaxLv.Size = new global::System.Drawing.Size(45, 23);
			this.numericUpDown_Existing_MobMaxLv.TabIndex = 27;
			this.label8.AutoSize = true;
			this.label8.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label8.Location = new global::System.Drawing.Point(6, 71);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(61, 15);
			this.label8.TabIndex = 22;
			this.label8.Text = "Min Level:";
			this.label6.AutoSize = true;
			this.label6.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label6.Location = new global::System.Drawing.Point(6, 21);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(34, 15);
			this.label6.TabIndex = 22;
			this.label6.Text = "Map:";
			this.numericUpDown_Existing_MobMinLv.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.numericUpDown_Existing_MobMinLv.Location = new global::System.Drawing.Point(73, 68);
			this.numericUpDown_Existing_MobMinLv.Name = "numericUpDown_Existing_MobMinLv";
			this.numericUpDown_Existing_MobMinLv.Size = new global::System.Drawing.Size(45, 23);
			this.numericUpDown_Existing_MobMinLv.TabIndex = 23;
			this.comboBox_Existing_Map.AutoCompleteMode = global::System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.comboBox_Existing_Map.AutoCompleteSource = global::System.Windows.Forms.AutoCompleteSource.ListItems;
			this.comboBox_Existing_Map.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.comboBox_Existing_Map.FormattingEnabled = true;
			this.comboBox_Existing_Map.Location = new global::System.Drawing.Point(46, 17);
			this.comboBox_Existing_Map.Name = "comboBox_Existing_Map";
			this.comboBox_Existing_Map.Size = new global::System.Drawing.Size(195, 23);
			this.comboBox_Existing_Map.TabIndex = 23;
			this.comboBox_Existing_Map.Leave += new global::System.EventHandler(this.comboBox_VerifyValidItem);
			this.comboBox_Existing_Mob.AutoCompleteMode = global::System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.comboBox_Existing_Mob.AutoCompleteSource = global::System.Windows.Forms.AutoCompleteSource.ListItems;
			this.comboBox_Existing_Mob.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.comboBox_Existing_Mob.FormattingEnabled = true;
			this.comboBox_Existing_Mob.Location = new global::System.Drawing.Point(46, 42);
			this.comboBox_Existing_Mob.Name = "comboBox_Existing_Mob";
			this.comboBox_Existing_Mob.Size = new global::System.Drawing.Size(195, 23);
			this.comboBox_Existing_Mob.TabIndex = 25;
			this.comboBox_Existing_Mob.Leave += new global::System.EventHandler(this.comboBox_VerifyValidItem);
			this.label7.AutoSize = true;
			this.label7.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label7.Location = new global::System.Drawing.Point(6, 46);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(35, 15);
			this.label7.TabIndex = 24;
			this.label7.Text = "Mob:";
			this.numericUpDown_Existing_DropRate.DecimalPlaces = 2;
			this.numericUpDown_Existing_DropRate.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.numericUpDown_Existing_DropRate.Location = new global::System.Drawing.Point(706, 122);
			this.numericUpDown_Existing_DropRate.Name = "numericUpDown_Existing_DropRate";
			this.numericUpDown_Existing_DropRate.Size = new global::System.Drawing.Size(50, 23);
			this.numericUpDown_Existing_DropRate.TabIndex = 28;
			this.numericUpDown_Existing_DropRate.UpDownAlign = global::System.Windows.Forms.LeftRightAlignment.Left;
			this.label10.AutoSize = true;
			this.label10.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label10.Location = new global::System.Drawing.Point(611, 126);
			this.label10.Name = "label10";
			this.label10.Size = new global::System.Drawing.Size(89, 15);
			this.label10.TabIndex = 28;
			this.label10.Text = "Item Drop Rate:";
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.Controls.Add(this.numericUpDown_Existing_ItemMinLv);
			this.groupBox3.Controls.Add(this.numericUpDown_Existing_ItemMaxLv);
			this.groupBox3.Controls.Add(this.checkBox_Existing_Skill);
			this.groupBox3.Controls.Add(this.numericUpDown_Existing_Durability);
			this.groupBox3.Controls.Add(this.checkBox_Existing_Luck);
			this.groupBox3.Controls.Add(this.label5);
			this.groupBox3.Controls.Add(this.label3);
			this.groupBox3.Controls.Add(this.groupBox_NewItem_ExcOpt);
			this.groupBox3.Controls.Add(this.comboBox_Existing_Opt);
			this.groupBox3.Controls.Add(this.comboBox_Existing_Ancient);
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.groupBox3.Location = new global::System.Drawing.Point(215, 18);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new global::System.Drawing.Size(345, 170);
			this.groupBox3.TabIndex = 26;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Item Options";
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.Location = new global::System.Drawing.Point(6, 18);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(61, 15);
			this.label1.TabIndex = 1;
			this.label1.Text = "Min Level:";
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.Location = new global::System.Drawing.Point(6, 42);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(62, 15);
			this.label2.TabIndex = 2;
			this.label2.Text = "Max Level:";
			this.numericUpDown_Existing_ItemMinLv.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.numericUpDown_Existing_ItemMinLv.Location = new global::System.Drawing.Point(71, 17);
			this.numericUpDown_Existing_ItemMinLv.Name = "numericUpDown_Existing_ItemMinLv";
			this.numericUpDown_Existing_ItemMinLv.Size = new global::System.Drawing.Size(58, 23);
			this.numericUpDown_Existing_ItemMinLv.TabIndex = 3;
			this.numericUpDown_Existing_ItemMaxLv.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.numericUpDown_Existing_ItemMaxLv.Location = new global::System.Drawing.Point(71, 41);
			global::System.Windows.Forms.NumericUpDown numericUpDown6 = this.numericUpDown_Existing_ItemMaxLv;
			int[] array6 = new int[4];
			array6[0] = 15;
			numericUpDown6.Maximum = new decimal(array6);
			this.numericUpDown_Existing_ItemMaxLv.Name = "numericUpDown_Existing_ItemMaxLv";
			this.numericUpDown_Existing_ItemMaxLv.Size = new global::System.Drawing.Size(58, 23);
			this.numericUpDown_Existing_ItemMaxLv.TabIndex = 4;
			this.checkBox_Existing_Skill.AutoSize = true;
			this.checkBox_Existing_Skill.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox_Existing_Skill.Location = new global::System.Drawing.Point(17, 142);
			this.checkBox_Existing_Skill.Name = "checkBox_Existing_Skill";
			this.checkBox_Existing_Skill.Size = new global::System.Drawing.Size(47, 19);
			this.checkBox_Existing_Skill.TabIndex = 5;
			this.checkBox_Existing_Skill.Text = "Skill";
			this.checkBox_Existing_Skill.UseVisualStyleBackColor = true;
			this.numericUpDown_Existing_Durability.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.numericUpDown_Existing_Durability.Location = new global::System.Drawing.Point(73, 114);
			global::System.Windows.Forms.NumericUpDown numericUpDown7 = this.numericUpDown_Existing_Durability;
			int[] array7 = new int[4];
			array7[0] = 255;
			numericUpDown7.Maximum = new decimal(array7);
			this.numericUpDown_Existing_Durability.Name = "numericUpDown_Existing_Durability";
			this.numericUpDown_Existing_Durability.Size = new global::System.Drawing.Size(56, 23);
			this.numericUpDown_Existing_Durability.TabIndex = 21;
			global::System.Windows.Forms.NumericUpDown numericUpDown8 = this.numericUpDown_Existing_Durability;
			int[] array8 = new int[4];
			array8[0] = 255;
			numericUpDown8.Value = new decimal(array8);
			this.checkBox_Existing_Luck.AutoSize = true;
			this.checkBox_Existing_Luck.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox_Existing_Luck.Location = new global::System.Drawing.Point(76, 142);
			this.checkBox_Existing_Luck.Name = "checkBox_Existing_Luck";
			this.checkBox_Existing_Luck.Size = new global::System.Drawing.Size(51, 19);
			this.checkBox_Existing_Luck.TabIndex = 6;
			this.checkBox_Existing_Luck.Text = "Luck";
			this.checkBox_Existing_Luck.UseVisualStyleBackColor = true;
			this.label5.AutoSize = true;
			this.label5.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label5.Location = new global::System.Drawing.Point(6, 117);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(61, 15);
			this.label5.TabIndex = 20;
			this.label5.Text = "Durability:";
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.Location = new global::System.Drawing.Point(6, 67);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(47, 15);
			this.label3.TabIndex = 7;
			this.label3.Text = "Option:";
			this.groupBox_NewItem_ExcOpt.BackColor = global::System.Drawing.Color.Transparent;
			this.groupBox_NewItem_ExcOpt.Controls.Add(this.checkBox_Existing_RandomExc);
			this.groupBox_NewItem_ExcOpt.Controls.Add(this.radioButton_Existing_ExcWings);
			this.groupBox_NewItem_ExcOpt.Controls.Add(this.radioButton_Existing_ExcArmor);
			this.groupBox_NewItem_ExcOpt.Controls.Add(this.radioButton_Existing_ExcWeapon);
			this.groupBox_NewItem_ExcOpt.Controls.Add(this.checkBox_Existing_ExcOpt6);
			this.groupBox_NewItem_ExcOpt.Controls.Add(this.checkBox_Existing_ExcOpt5);
			this.groupBox_NewItem_ExcOpt.Controls.Add(this.checkBox_Existing_ExcOpt4);
			this.groupBox_NewItem_ExcOpt.Controls.Add(this.checkBox_Existing_ExcOpt3);
			this.groupBox_NewItem_ExcOpt.Controls.Add(this.checkBox_Existing_ExcOpt2);
			this.groupBox_NewItem_ExcOpt.Controls.Add(this.checkBox_Existing_ExcOpt1);
			this.groupBox_NewItem_ExcOpt.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.groupBox_NewItem_ExcOpt.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.groupBox_NewItem_ExcOpt.Location = new global::System.Drawing.Point(135, 11);
			this.groupBox_NewItem_ExcOpt.Name = "groupBox_NewItem_ExcOpt";
			this.groupBox_NewItem_ExcOpt.Size = new global::System.Drawing.Size(204, 151);
			this.groupBox_NewItem_ExcOpt.TabIndex = 19;
			this.groupBox_NewItem_ExcOpt.TabStop = false;
			this.groupBox_NewItem_ExcOpt.Text = "Excellent Options     ";
			this.checkBox_Existing_RandomExc.AutoSize = true;
			this.checkBox_Existing_RandomExc.BackColor = global::System.Drawing.SystemColors.Control;
			this.checkBox_Existing_RandomExc.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox_Existing_RandomExc.Location = new global::System.Drawing.Point(107, 0);
			this.checkBox_Existing_RandomExc.Name = "checkBox_Existing_RandomExc";
			this.checkBox_Existing_RandomExc.Size = new global::System.Drawing.Size(71, 19);
			this.checkBox_Existing_RandomExc.TabIndex = 21;
			this.checkBox_Existing_RandomExc.Text = "Random";
			this.checkBox_Existing_RandomExc.UseVisualStyleBackColor = false;
			this.radioButton_Existing_ExcWings.AutoSize = true;
			this.radioButton_Existing_ExcWings.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.radioButton_Existing_ExcWings.Location = new global::System.Drawing.Point(136, 18);
			this.radioButton_Existing_ExcWings.Name = "radioButton_Existing_ExcWings";
			this.radioButton_Existing_ExcWings.Size = new global::System.Drawing.Size(58, 19);
			this.radioButton_Existing_ExcWings.TabIndex = 14;
			this.radioButton_Existing_ExcWings.Text = "Wings";
			this.radioButton_Existing_ExcWings.UseVisualStyleBackColor = true;
			this.radioButton_Existing_ExcWings.CheckedChanged += new global::System.EventHandler(this.radioButton_Existing_ExcWings_CheckedChanged);
			this.radioButton_Existing_ExcArmor.AutoSize = true;
			this.radioButton_Existing_ExcArmor.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.radioButton_Existing_ExcArmor.Location = new global::System.Drawing.Point(78, 18);
			this.radioButton_Existing_ExcArmor.Name = "radioButton_Existing_ExcArmor";
			this.radioButton_Existing_ExcArmor.Size = new global::System.Drawing.Size(59, 19);
			this.radioButton_Existing_ExcArmor.TabIndex = 13;
			this.radioButton_Existing_ExcArmor.Text = "Armor";
			this.radioButton_Existing_ExcArmor.UseVisualStyleBackColor = true;
			this.radioButton_Existing_ExcArmor.CheckedChanged += new global::System.EventHandler(this.radioButton_Existing_ExcArmor_CheckedChanged);
			this.radioButton_Existing_ExcWeapon.AutoSize = true;
			this.radioButton_Existing_ExcWeapon.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.radioButton_Existing_ExcWeapon.Location = new global::System.Drawing.Point(6, 18);
			this.radioButton_Existing_ExcWeapon.Name = "radioButton_Existing_ExcWeapon";
			this.radioButton_Existing_ExcWeapon.Size = new global::System.Drawing.Size(69, 19);
			this.radioButton_Existing_ExcWeapon.TabIndex = 12;
			this.radioButton_Existing_ExcWeapon.Text = "Weapon";
			this.radioButton_Existing_ExcWeapon.UseVisualStyleBackColor = true;
			this.radioButton_Existing_ExcWeapon.CheckedChanged += new global::System.EventHandler(this.radioButton_Existing_ExcWeapon_CheckedChanged);
			this.checkBox_Existing_ExcOpt6.AutoSize = true;
			this.checkBox_Existing_ExcOpt6.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox_Existing_ExcOpt6.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.checkBox_Existing_ExcOpt6.Location = new global::System.Drawing.Point(6, 133);
			this.checkBox_Existing_ExcOpt6.Name = "checkBox_Existing_ExcOpt6";
			this.checkBox_Existing_ExcOpt6.Size = new global::System.Drawing.Size(82, 19);
			this.checkBox_Existing_ExcOpt6.TabIndex = 20;
			this.checkBox_Existing_ExcOpt6.Text = "checkBox6";
			this.checkBox_Existing_ExcOpt6.UseVisualStyleBackColor = true;
			this.checkBox_Existing_ExcOpt5.AutoSize = true;
			this.checkBox_Existing_ExcOpt5.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox_Existing_ExcOpt5.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.checkBox_Existing_ExcOpt5.Location = new global::System.Drawing.Point(6, 115);
			this.checkBox_Existing_ExcOpt5.Name = "checkBox_Existing_ExcOpt5";
			this.checkBox_Existing_ExcOpt5.Size = new global::System.Drawing.Size(82, 19);
			this.checkBox_Existing_ExcOpt5.TabIndex = 19;
			this.checkBox_Existing_ExcOpt5.Text = "checkBox5";
			this.checkBox_Existing_ExcOpt5.UseVisualStyleBackColor = true;
			this.checkBox_Existing_ExcOpt4.AutoSize = true;
			this.checkBox_Existing_ExcOpt4.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox_Existing_ExcOpt4.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.checkBox_Existing_ExcOpt4.Location = new global::System.Drawing.Point(6, 97);
			this.checkBox_Existing_ExcOpt4.Name = "checkBox_Existing_ExcOpt4";
			this.checkBox_Existing_ExcOpt4.Size = new global::System.Drawing.Size(82, 19);
			this.checkBox_Existing_ExcOpt4.TabIndex = 18;
			this.checkBox_Existing_ExcOpt4.Text = "checkBox4";
			this.checkBox_Existing_ExcOpt4.UseVisualStyleBackColor = true;
			this.checkBox_Existing_ExcOpt3.AutoSize = true;
			this.checkBox_Existing_ExcOpt3.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox_Existing_ExcOpt3.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.checkBox_Existing_ExcOpt3.Location = new global::System.Drawing.Point(6, 78);
			this.checkBox_Existing_ExcOpt3.Name = "checkBox_Existing_ExcOpt3";
			this.checkBox_Existing_ExcOpt3.Size = new global::System.Drawing.Size(82, 19);
			this.checkBox_Existing_ExcOpt3.TabIndex = 17;
			this.checkBox_Existing_ExcOpt3.Text = "checkBox3";
			this.checkBox_Existing_ExcOpt3.UseVisualStyleBackColor = true;
			this.checkBox_Existing_ExcOpt2.AutoSize = true;
			this.checkBox_Existing_ExcOpt2.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox_Existing_ExcOpt2.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.checkBox_Existing_ExcOpt2.Location = new global::System.Drawing.Point(6, 60);
			this.checkBox_Existing_ExcOpt2.Name = "checkBox_Existing_ExcOpt2";
			this.checkBox_Existing_ExcOpt2.Size = new global::System.Drawing.Size(82, 19);
			this.checkBox_Existing_ExcOpt2.TabIndex = 16;
			this.checkBox_Existing_ExcOpt2.Text = "checkBox2";
			this.checkBox_Existing_ExcOpt2.UseVisualStyleBackColor = true;
			this.checkBox_Existing_ExcOpt1.AutoSize = true;
			this.checkBox_Existing_ExcOpt1.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox_Existing_ExcOpt1.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.checkBox_Existing_ExcOpt1.Location = new global::System.Drawing.Point(6, 42);
			this.checkBox_Existing_ExcOpt1.Name = "checkBox_Existing_ExcOpt1";
			this.checkBox_Existing_ExcOpt1.Size = new global::System.Drawing.Size(82, 19);
			this.checkBox_Existing_ExcOpt1.TabIndex = 15;
			this.checkBox_Existing_ExcOpt1.Text = "checkBox1";
			this.checkBox_Existing_ExcOpt1.UseVisualStyleBackColor = true;
			this.comboBox_Existing_Opt.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_Existing_Opt.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.comboBox_Existing_Opt.FormattingEnabled = true;
			this.comboBox_Existing_Opt.Location = new global::System.Drawing.Point(64, 65);
			this.comboBox_Existing_Opt.Name = "comboBox_Existing_Opt";
			this.comboBox_Existing_Opt.Size = new global::System.Drawing.Size(65, 23);
			this.comboBox_Existing_Opt.TabIndex = 8;
			this.comboBox_Existing_Ancient.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_Existing_Ancient.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.comboBox_Existing_Ancient.FormattingEnabled = true;
			this.comboBox_Existing_Ancient.Location = new global::System.Drawing.Point(64, 90);
			this.comboBox_Existing_Ancient.Name = "comboBox_Existing_Ancient";
			this.comboBox_Existing_Ancient.Size = new global::System.Drawing.Size(65, 23);
			this.comboBox_Existing_Ancient.TabIndex = 10;
			this.label4.AutoSize = true;
			this.label4.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label4.Location = new global::System.Drawing.Point(6, 92);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(51, 15);
			this.label4.TabIndex = 9;
			this.label4.Text = "Ancient:";
			this.listBox_DropItems.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.listBox_DropItems.FormattingEnabled = true;
			this.listBox_DropItems.ItemHeight = 15;
			this.listBox_DropItems.Location = new global::System.Drawing.Point(6, 18);
			this.listBox_DropItems.Name = "listBox_DropItems";
			this.listBox_DropItems.Size = new global::System.Drawing.Size(203, 139);
			this.listBox_DropItems.TabIndex = 0;
			this.listBox_DropItems.SelectedIndexChanged += new global::System.EventHandler(this.listBox_DropItems_SelectedIndexChanged);
			this.label11.AutoSize = true;
			this.label11.Font = new global::System.Drawing.Font("Segoe UI", 11f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label11.Location = new global::System.Drawing.Point(754, 122);
			this.label11.Name = "label11";
			this.label11.Size = new global::System.Drawing.Size(21, 20);
			this.label11.TabIndex = 29;
			this.label11.Text = "%";
			this.button_New_Add.Location = new global::System.Drawing.Point(666, 408);
			this.button_New_Add.Name = "button_New_Add";
			this.button_New_Add.Size = new global::System.Drawing.Size(159, 30);
			this.button_New_Add.TabIndex = 31;
			this.button_New_Add.Text = "Add";
			this.button_New_Add.UseVisualStyleBackColor = true;
			this.button_New_Add.Click += new global::System.EventHandler(this.button_New_Add_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(845, 456);
			base.Controls.Add(this.button_New_Add);
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.menuStrip1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.MainMenuStrip = this.menuStrip1;
			base.MaximizeBox = false;
			base.Name = "Form_DropManager";
			base.ShowIcon = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MU DropManager Editor";
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.Form_DropManager_FormClosed);
			base.Load += new global::System.EventHandler(this.Form_DropManager_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox_New_iPicture).EndInit();
			this.groupBox7.ResumeLayout(false);
			this.groupBox7.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_New_MobMaxLv).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_New_MobMinLv).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_New_DropRate).EndInit();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_New_ItemMinLv).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_New_ItemMaxLv).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_New_Durability).EndInit();
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Existing_MobMaxLv).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Existing_MobMinLv).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Existing_DropRate).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Existing_ItemMinLv).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Existing_ItemMaxLv).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Existing_Durability).EndInit();
			this.groupBox_NewItem_ExcOpt.ResumeLayout(false);
			this.groupBox_NewItem_ExcOpt.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040003A7 RID: 935
		private global::System.Windows.Forms.Button button_Existing_RemoveSelected;

		// Token: 0x040003A8 RID: 936
		private global::System.Windows.Forms.Button button_Existing_UpdateSelected;

		// Token: 0x040003A9 RID: 937
		private global::System.Windows.Forms.Button button_New_Add;

		// Token: 0x040003AE RID: 942
		public global::System.Windows.Forms.CheckBox checkBox_Existing_ExcOpt1;

		// Token: 0x040003AF RID: 943
		public global::System.Windows.Forms.CheckBox checkBox_Existing_ExcOpt2;

		// Token: 0x040003B0 RID: 944
		public global::System.Windows.Forms.CheckBox checkBox_Existing_ExcOpt3;

		// Token: 0x040003B1 RID: 945
		public global::System.Windows.Forms.CheckBox checkBox_Existing_ExcOpt4;

		// Token: 0x040003B2 RID: 946
		public global::System.Windows.Forms.CheckBox checkBox_Existing_ExcOpt5;

		// Token: 0x040003B3 RID: 947
		public global::System.Windows.Forms.CheckBox checkBox_Existing_ExcOpt6;

		// Token: 0x040003B4 RID: 948
		private global::System.Windows.Forms.CheckBox checkBox_Existing_Luck;

		// Token: 0x040003B5 RID: 949
		private global::System.Windows.Forms.CheckBox checkBox_Existing_RandomExc;

		// Token: 0x040003B6 RID: 950
		private global::System.Windows.Forms.CheckBox checkBox_Existing_Skill;

		// Token: 0x040003B7 RID: 951
		public global::System.Windows.Forms.CheckBox checkBox_New_ExcOpt1;

		// Token: 0x040003B8 RID: 952
		public global::System.Windows.Forms.CheckBox checkBox_New_ExcOpt2;

		// Token: 0x040003B9 RID: 953
		public global::System.Windows.Forms.CheckBox checkBox_New_ExcOpt3;

		// Token: 0x040003BA RID: 954
		public global::System.Windows.Forms.CheckBox checkBox_New_ExcOpt4;

		// Token: 0x040003BB RID: 955
		public global::System.Windows.Forms.CheckBox checkBox_New_ExcOpt5;

		// Token: 0x040003BC RID: 956
		public global::System.Windows.Forms.CheckBox checkBox_New_ExcOpt6;

		// Token: 0x040003BD RID: 957
		private global::System.Windows.Forms.CheckBox checkBox_New_Luck;

		// Token: 0x040003BE RID: 958
		private global::System.Windows.Forms.CheckBox checkBox_New_RandomExc;

		// Token: 0x040003BF RID: 959
		private global::System.Windows.Forms.CheckBox checkBox_New_Skill;

		// Token: 0x040003C0 RID: 960
		private global::System.Windows.Forms.ComboBox comboBox_Existing_Ancient;

		// Token: 0x040003C1 RID: 961
		private global::System.Windows.Forms.ComboBox comboBox_Existing_Map;

		// Token: 0x040003C2 RID: 962
		private global::System.Windows.Forms.ComboBox comboBox_Existing_Mob;

		// Token: 0x040003C3 RID: 963
		private global::System.Windows.Forms.ComboBox comboBox_Existing_Opt;

		// Token: 0x040003C4 RID: 964
		private global::System.Windows.Forms.ComboBox comboBox_New_Ancient;

		// Token: 0x040003C5 RID: 965
		private global::System.Windows.Forms.ComboBox comboBox_New_Map;

		// Token: 0x040003C6 RID: 966
		private global::System.Windows.Forms.ComboBox comboBox_New_Mob;

		// Token: 0x040003C7 RID: 967
		private global::System.Windows.Forms.ComboBox comboBox_New_Opt;

		// Token: 0x040003C8 RID: 968
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040003CA RID: 970
		private global::System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;

		// Token: 0x040003CC RID: 972
		private global::System.Windows.Forms.GroupBox groupBox_NewItem_ExcOpt;

		// Token: 0x040003CD RID: 973
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x040003CE RID: 974
		private global::System.Windows.Forms.GroupBox groupBox2;

		// Token: 0x040003CF RID: 975
		private global::System.Windows.Forms.GroupBox groupBox3;

		// Token: 0x040003D0 RID: 976
		private global::System.Windows.Forms.GroupBox groupBox4;

		// Token: 0x040003D1 RID: 977
		private global::System.Windows.Forms.GroupBox groupBox5;

		// Token: 0x040003D2 RID: 978
		private global::System.Windows.Forms.GroupBox groupBox6;

		// Token: 0x040003D3 RID: 979
		private global::System.Windows.Forms.GroupBox groupBox7;

		// Token: 0x040003E6 RID: 998
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040003E7 RID: 999
		private global::System.Windows.Forms.Label label10;

		// Token: 0x040003E8 RID: 1000
		private global::System.Windows.Forms.Label label11;

		// Token: 0x040003E9 RID: 1001
		private global::System.Windows.Forms.Label label12;

		// Token: 0x040003EA RID: 1002
		private global::System.Windows.Forms.Label label13;

		// Token: 0x040003EB RID: 1003
		private global::System.Windows.Forms.Label label14;

		// Token: 0x040003EC RID: 1004
		private global::System.Windows.Forms.Label label15;

		// Token: 0x040003ED RID: 1005
		private global::System.Windows.Forms.Label label16;

		// Token: 0x040003EE RID: 1006
		private global::System.Windows.Forms.Label label17;

		// Token: 0x040003EF RID: 1007
		private global::System.Windows.Forms.Label label18;

		// Token: 0x040003F0 RID: 1008
		private global::System.Windows.Forms.Label label19;

		// Token: 0x040003F1 RID: 1009
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040003F2 RID: 1010
		private global::System.Windows.Forms.Label label20;

		// Token: 0x040003F3 RID: 1011
		private global::System.Windows.Forms.Label label21;

		// Token: 0x040003F4 RID: 1012
		private global::System.Windows.Forms.Label label22;

		// Token: 0x040003F5 RID: 1013
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040003F6 RID: 1014
		private global::System.Windows.Forms.Label label4;

		// Token: 0x040003F7 RID: 1015
		private global::System.Windows.Forms.Label label5;

		// Token: 0x040003F8 RID: 1016
		private global::System.Windows.Forms.Label label6;

		// Token: 0x040003F9 RID: 1017
		private global::System.Windows.Forms.Label label7;

		// Token: 0x040003FA RID: 1018
		private global::System.Windows.Forms.Label label8;

		// Token: 0x040003FB RID: 1019
		private global::System.Windows.Forms.Label label9;

		// Token: 0x040003FD RID: 1021
		private global::System.Windows.Forms.ListBox listBox_DropItems;

		// Token: 0x040003FE RID: 1022
		private global::System.Windows.Forms.ListBox listBox_New_iGroup;

		// Token: 0x040003FF RID: 1023
		private global::System.Windows.Forms.ListBox listBox_New_iIndex;

		// Token: 0x04000400 RID: 1024
		private global::System.Windows.Forms.MenuStrip menuStrip1;

		// Token: 0x04000406 RID: 1030
		private global::System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;

		// Token: 0x04000407 RID: 1031
		private global::System.Windows.Forms.NumericUpDown numericUpDown_Existing_DropRate;

		// Token: 0x04000408 RID: 1032
		private global::System.Windows.Forms.NumericUpDown numericUpDown_Existing_Durability;

		// Token: 0x04000409 RID: 1033
		private global::System.Windows.Forms.NumericUpDown numericUpDown_Existing_ItemMaxLv;

		// Token: 0x0400040A RID: 1034
		private global::System.Windows.Forms.NumericUpDown numericUpDown_Existing_ItemMinLv;

		// Token: 0x0400040B RID: 1035
		private global::System.Windows.Forms.NumericUpDown numericUpDown_Existing_MobMaxLv;

		// Token: 0x0400040C RID: 1036
		private global::System.Windows.Forms.NumericUpDown numericUpDown_Existing_MobMinLv;

		// Token: 0x0400040D RID: 1037
		private global::System.Windows.Forms.NumericUpDown numericUpDown_New_DropRate;

		// Token: 0x0400040E RID: 1038
		private global::System.Windows.Forms.NumericUpDown numericUpDown_New_Durability;

		// Token: 0x0400040F RID: 1039
		private global::System.Windows.Forms.NumericUpDown numericUpDown_New_ItemMaxLv;

		// Token: 0x04000410 RID: 1040
		private global::System.Windows.Forms.NumericUpDown numericUpDown_New_ItemMinLv;

		// Token: 0x04000411 RID: 1041
		private global::System.Windows.Forms.NumericUpDown numericUpDown_New_MobMaxLv;

		// Token: 0x04000412 RID: 1042
		private global::System.Windows.Forms.NumericUpDown numericUpDown_New_MobMinLv;

		// Token: 0x04000413 RID: 1043
		private global::System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;

		// Token: 0x04000414 RID: 1044
		private global::System.Windows.Forms.PictureBox pictureBox_New_iPicture;

		// Token: 0x04000415 RID: 1045
		private global::System.Windows.Forms.RadioButton radioButton_Existing_ExcArmor;

		// Token: 0x04000416 RID: 1046
		private global::System.Windows.Forms.RadioButton radioButton_Existing_ExcWeapon;

		// Token: 0x04000417 RID: 1047
		private global::System.Windows.Forms.RadioButton radioButton_Existing_ExcWings;

		// Token: 0x04000418 RID: 1048
		private global::System.Windows.Forms.RadioButton radioButton_New_ExcArmor;

		// Token: 0x04000419 RID: 1049
		private global::System.Windows.Forms.RadioButton radioButton_New_ExcWeapon;

		// Token: 0x0400041A RID: 1050
		private global::System.Windows.Forms.RadioButton radioButton_New_ExcWings;

		// Token: 0x0400041B RID: 1051
		private global::System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
	}
}
