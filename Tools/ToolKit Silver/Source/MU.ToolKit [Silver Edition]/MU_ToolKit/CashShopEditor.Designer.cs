namespace MU_ToolKit
{
	// Token: 0x0200000B RID: 11
	public partial class CashShopEditor : global::System.Windows.Forms.Form
	{
		// Token: 0x06000389 RID: 905 RVA: 0x00010C94 File Offset: 0x0000EE94
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600038F RID: 911 RVA: 0x00011C7C File Offset: 0x0000FE7C
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::MU_ToolKit.CashShopEditor));
			this.menuStrip1 = new global::System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.serverFilesToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.clientFilesToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.headCategoriesToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.addNewToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.subCategoriesToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.addNewToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.panel_ItemAdd = new global::System.Windows.Forms.Panel();
			this.groupBox2 = new global::System.Windows.Forms.GroupBox();
			this.comboBox_NewItem_CountType = new global::System.Windows.Forms.ComboBox();
			this.numericUpDown_NewItem_Count = new global::System.Windows.Forms.NumericUpDown();
			this.comboBox_NewItem_Coin = new global::System.Windows.Forms.ComboBox();
			this.numericUpDown_NewItem_Price = new global::System.Windows.Forms.NumericUpDown();
			this.textBox_NewItem_Name = new global::System.Windows.Forms.TextBox();
			this.label8 = new global::System.Windows.Forms.Label();
			this.richTextBox_NewItem_Info = new global::System.Windows.Forms.RichTextBox();
			this.label7 = new global::System.Windows.Forms.Label();
			this.label6 = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.groupBox_NewItem_ExcOpt = new global::System.Windows.Forms.GroupBox();
			this.radioButton_NewItem_ExcWings = new global::System.Windows.Forms.RadioButton();
			this.radioButton_NewItem_ExcArmor = new global::System.Windows.Forms.RadioButton();
			this.radioButton_NewItem_ExcWeapon = new global::System.Windows.Forms.RadioButton();
			this.checkBox_NewItem_ExcOpt6 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_NewItem_ExcOpt5 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_NewItem_ExcOpt4 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_NewItem_ExcOpt3 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_NewItem_ExcOpt2 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_NewItem_ExcOpt1 = new global::System.Windows.Forms.CheckBox();
			this.listBox_NewItem_ItemOption = new global::System.Windows.Forms.ListBox();
			this.checkBox_AddItem_FOItem = new global::System.Windows.Forms.CheckBox();
			this.checkBox_NewItem_Luck = new global::System.Windows.Forms.CheckBox();
			this.groupBox9 = new global::System.Windows.Forms.GroupBox();
			this.comboBox_Ancient = new global::System.Windows.Forms.ComboBox();
			this.label3 = new global::System.Windows.Forms.Label();
			this.checkBox_NewItem_Skill = new global::System.Windows.Forms.CheckBox();
			this.groupBox8 = new global::System.Windows.Forms.GroupBox();
			this.numericUpDown_NewItem_SocketCount = new global::System.Windows.Forms.NumericUpDown();
			this.label4 = new global::System.Windows.Forms.Label();
			this.groupBox6 = new global::System.Windows.Forms.GroupBox();
			this.numericUpDown_NewItem_Durability = new global::System.Windows.Forms.NumericUpDown();
			this.listBox_NewItem_ItemLevel = new global::System.Windows.Forms.ListBox();
			this.button_NewItem_Add = new global::System.Windows.Forms.Button();
			this.pictureBox_NewItem_ItemPreview = new global::System.Windows.Forms.PictureBox();
			this.listBox_NewItem_ItemIndex = new global::System.Windows.Forms.ListBox();
			this.listBox_NewItem_ItemGroup = new global::System.Windows.Forms.ListBox();
			this.panel_MainForm = new global::MU_ToolKit.MyPanel();
			this.panel_SubCatEnd = new global::MU_ToolKit.MyPanel();
			this.panel_CatFirst = new global::MU_ToolKit.MyPanel();
			this.textBox_Cat1 = new global::System.Windows.Forms.TextBox();
			this.textBox_SubCat1 = new global::System.Windows.Forms.TextBox();
			this.label_MaxPage = new global::System.Windows.Forms.Label();
			this.panel_ItemsPage1 = new global::MU_ToolKit.MyPanel();
			this.panel_Item = new global::MU_ToolKit.MyPanel();
			this.label_ItemPrice = new global::System.Windows.Forms.Label();
			this.label_ItemName = new global::System.Windows.Forms.Label();
			this.pictureBox_ItemImg = new global::System.Windows.Forms.PictureBox();
			this.panel8 = new global::MU_ToolKit.MyPanel();
			this.label_CurrPage = new global::System.Windows.Forms.Label();
			this.panel9 = new global::MU_ToolKit.MyPanel();
			this.panel_NextPage = new global::MU_ToolKit.MyPanel();
			this.panel_PrevPage = new global::MU_ToolKit.MyPanel();
			this.panel_SubCat1 = new global::MU_ToolKit.MyPanel();
			this.menuStrip1.SuspendLayout();
			this.panel_ItemAdd.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_NewItem_Count).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_NewItem_Price).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox_NewItem_ExcOpt.SuspendLayout();
			this.groupBox9.SuspendLayout();
			this.groupBox8.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_NewItem_SocketCount).BeginInit();
			this.groupBox6.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_NewItem_Durability).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox_NewItem_ItemPreview).BeginInit();
			this.panel_MainForm.SuspendLayout();
			this.panel_CatFirst.SuspendLayout();
			this.panel_ItemsPage1.SuspendLayout();
			this.panel_Item.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox_ItemImg).BeginInit();
			base.SuspendLayout();
			this.menuStrip1.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.fileToolStripMenuItem,
				this.editToolStripMenuItem
			});
			this.menuStrip1.Location = new global::System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new global::System.Drawing.Size(694, 25);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			this.fileToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.saveToolStripMenuItem1
			});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new global::System.Drawing.Size(39, 21);
			this.fileToolStripMenuItem.Text = "File";
			this.saveToolStripMenuItem1.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.serverFilesToolStripMenuItem,
				this.clientFilesToolStripMenuItem
			});
			this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
			this.saveToolStripMenuItem1.Size = new global::System.Drawing.Size(103, 22);
			this.saveToolStripMenuItem1.Text = "Save";
			this.serverFilesToolStripMenuItem.Name = "serverFilesToolStripMenuItem";
			this.serverFilesToolStripMenuItem.Size = new global::System.Drawing.Size(142, 22);
			this.serverFilesToolStripMenuItem.Text = "Server Files";
			this.serverFilesToolStripMenuItem.Click += new global::System.EventHandler(this.serverToolStripMenuItem_Click);
			this.clientFilesToolStripMenuItem.Name = "clientFilesToolStripMenuItem";
			this.clientFilesToolStripMenuItem.Size = new global::System.Drawing.Size(142, 22);
			this.clientFilesToolStripMenuItem.Text = "Client Files";
			this.clientFilesToolStripMenuItem.Click += new global::System.EventHandler(this.clientToolStripMenuItem_Click);
			this.editToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.headCategoriesToolStripMenuItem,
				this.subCategoriesToolStripMenuItem
			});
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new global::System.Drawing.Size(42, 21);
			this.editToolStripMenuItem.Text = "Edit";
			this.headCategoriesToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.addNewToolStripMenuItem
			});
			this.headCategoriesToolStripMenuItem.Name = "headCategoriesToolStripMenuItem";
			this.headCategoriesToolStripMenuItem.Size = new global::System.Drawing.Size(174, 22);
			this.headCategoriesToolStripMenuItem.Text = "Head Categories";
			this.addNewToolStripMenuItem.Name = "addNewToolStripMenuItem";
			this.addNewToolStripMenuItem.Size = new global::System.Drawing.Size(130, 22);
			this.addNewToolStripMenuItem.Text = "Add New";
			this.addNewToolStripMenuItem.Click += new global::System.EventHandler(this.addToolStripMenuItem_Cat_Click);
			this.subCategoriesToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.addNewToolStripMenuItem1
			});
			this.subCategoriesToolStripMenuItem.Name = "subCategoriesToolStripMenuItem";
			this.subCategoriesToolStripMenuItem.Size = new global::System.Drawing.Size(174, 22);
			this.subCategoriesToolStripMenuItem.Text = "Sub Categories";
			this.addNewToolStripMenuItem1.Name = "addNewToolStripMenuItem1";
			this.addNewToolStripMenuItem1.Size = new global::System.Drawing.Size(130, 22);
			this.addNewToolStripMenuItem1.Text = "Add New";
			this.addNewToolStripMenuItem1.Click += new global::System.EventHandler(this.addToolStripMenuItem_SubCat_Click);
			this.panel_ItemAdd.BackgroundImage = Properties.Resources.panel_ItemAdd_BackgroundImage;
			this.panel_ItemAdd.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Stretch;
			this.panel_ItemAdd.Controls.Add(this.groupBox2);
			this.panel_ItemAdd.Controls.Add(this.groupBox1);
			this.panel_ItemAdd.Controls.Add(this.button_NewItem_Add);
			this.panel_ItemAdd.Controls.Add(this.pictureBox_NewItem_ItemPreview);
			this.panel_ItemAdd.Controls.Add(this.listBox_NewItem_ItemIndex);
			this.panel_ItemAdd.Controls.Add(this.listBox_NewItem_ItemGroup);
			this.panel_ItemAdd.Location = new global::System.Drawing.Point(789, 25);
			this.panel_ItemAdd.Name = "panel_ItemAdd";
			this.panel_ItemAdd.Size = new global::System.Drawing.Size(344, 666);
			this.panel_ItemAdd.TabIndex = 2;
			this.panel_ItemAdd.Visible = false;
			this.groupBox2.BackColor = global::System.Drawing.Color.Transparent;
			this.groupBox2.Controls.Add(this.comboBox_NewItem_CountType);
			this.groupBox2.Controls.Add(this.numericUpDown_NewItem_Count);
			this.groupBox2.Controls.Add(this.comboBox_NewItem_Coin);
			this.groupBox2.Controls.Add(this.numericUpDown_NewItem_Price);
			this.groupBox2.Controls.Add(this.textBox_NewItem_Name);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.richTextBox_NewItem_Info);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 177);
			this.groupBox2.ForeColor = global::System.Drawing.Color.DarkGoldenrod;
			this.groupBox2.Location = new global::System.Drawing.Point(20, 188);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new global::System.Drawing.Size(303, 145);
			this.groupBox2.TabIndex = 21;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Cash Shop Item Options";
			this.comboBox_NewItem_CountType.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_NewItem_CountType.FormattingEnabled = true;
			this.comboBox_NewItem_CountType.Items.AddRange(new object[]
			{
				"Quantity"
			});
			this.comboBox_NewItem_CountType.Location = new global::System.Drawing.Point(73, 117);
			this.comboBox_NewItem_CountType.Name = "comboBox_NewItem_CountType";
			this.comboBox_NewItem_CountType.Size = new global::System.Drawing.Size(105, 21);
			this.comboBox_NewItem_CountType.TabIndex = 6;
			this.numericUpDown_NewItem_Count.Location = new global::System.Drawing.Point(73, 94);
			this.numericUpDown_NewItem_Count.Name = "numericUpDown_NewItem_Count";
			this.numericUpDown_NewItem_Count.Size = new global::System.Drawing.Size(105, 20);
			this.numericUpDown_NewItem_Count.TabIndex = 5;
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.numericUpDown_NewItem_Count;
			int[] array = new int[4];
			array[0] = 1;
			numericUpDown.Value = new decimal(array);
			this.comboBox_NewItem_Coin.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_NewItem_Coin.FormattingEnabled = true;
			this.comboBox_NewItem_Coin.Items.AddRange(new object[]
			{
				"W Coin (C)",
				"W Coin (P)",
				"Goblin Point"
			});
			this.comboBox_NewItem_Coin.Location = new global::System.Drawing.Point(73, 69);
			this.comboBox_NewItem_Coin.Name = "comboBox_NewItem_Coin";
			this.comboBox_NewItem_Coin.Size = new global::System.Drawing.Size(105, 21);
			this.comboBox_NewItem_Coin.TabIndex = 4;
			this.numericUpDown_NewItem_Price.Location = new global::System.Drawing.Point(73, 46);
			global::System.Windows.Forms.NumericUpDown numericUpDown2 = this.numericUpDown_NewItem_Price;
			int[] array2 = new int[4];
			array2[0] = 2000000000;
			numericUpDown2.Maximum = new decimal(array2);
			this.numericUpDown_NewItem_Price.Name = "numericUpDown_NewItem_Price";
			this.numericUpDown_NewItem_Price.Size = new global::System.Drawing.Size(105, 20);
			this.numericUpDown_NewItem_Price.TabIndex = 3;
			this.textBox_NewItem_Name.Location = new global::System.Drawing.Point(73, 21);
			this.textBox_NewItem_Name.Name = "textBox_NewItem_Name";
			this.textBox_NewItem_Name.Size = new global::System.Drawing.Size(105, 20);
			this.textBox_NewItem_Name.TabIndex = 2;
			this.label8.AutoSize = true;
			this.label8.Location = new global::System.Drawing.Point(181, 15);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(113, 13);
			this.label8.TabIndex = 28;
			this.label8.Text = "Info:  # = New line";
			this.richTextBox_NewItem_Info.Location = new global::System.Drawing.Point(184, 30);
			this.richTextBox_NewItem_Info.Name = "richTextBox_NewItem_Info";
			this.richTextBox_NewItem_Info.Size = new global::System.Drawing.Size(110, 107);
			this.richTextBox_NewItem_Info.TabIndex = 7;
			this.richTextBox_NewItem_Info.Text = "";
			this.label7.AutoSize = true;
			this.label7.Location = new global::System.Drawing.Point(12, 72);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(36, 13);
			this.label7.TabIndex = 26;
			this.label7.Text = "Coin:";
			this.label6.AutoSize = true;
			this.label6.Location = new global::System.Drawing.Point(12, 120);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(55, 13);
			this.label6.TabIndex = 25;
			this.label6.Text = "Counter:";
			this.label5.AutoSize = true;
			this.label5.Location = new global::System.Drawing.Point(12, 24);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(43, 13);
			this.label5.TabIndex = 24;
			this.label5.Text = "Name:";
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(12, 96);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(44, 13);
			this.label2.TabIndex = 23;
			this.label2.Text = "Count:";
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(12, 48);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(40, 13);
			this.label1.TabIndex = 22;
			this.label1.Text = "Price:";
			this.groupBox1.BackColor = global::System.Drawing.Color.Transparent;
			this.groupBox1.Controls.Add(this.groupBox_NewItem_ExcOpt);
			this.groupBox1.Controls.Add(this.listBox_NewItem_ItemOption);
			this.groupBox1.Controls.Add(this.checkBox_AddItem_FOItem);
			this.groupBox1.Controls.Add(this.checkBox_NewItem_Luck);
			this.groupBox1.Controls.Add(this.groupBox9);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.checkBox_NewItem_Skill);
			this.groupBox1.Controls.Add(this.groupBox8);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.groupBox6);
			this.groupBox1.Controls.Add(this.listBox_NewItem_ItemLevel);
			this.groupBox1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 177);
			this.groupBox1.ForeColor = global::System.Drawing.Color.Goldenrod;
			this.groupBox1.Location = new global::System.Drawing.Point(20, 339);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(303, 271);
			this.groupBox1.TabIndex = 20;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Item Properties";
			this.groupBox_NewItem_ExcOpt.BackColor = global::System.Drawing.Color.Transparent;
			this.groupBox_NewItem_ExcOpt.Controls.Add(this.radioButton_NewItem_ExcWings);
			this.groupBox_NewItem_ExcOpt.Controls.Add(this.radioButton_NewItem_ExcArmor);
			this.groupBox_NewItem_ExcOpt.Controls.Add(this.radioButton_NewItem_ExcWeapon);
			this.groupBox_NewItem_ExcOpt.Controls.Add(this.checkBox_NewItem_ExcOpt6);
			this.groupBox_NewItem_ExcOpt.Controls.Add(this.checkBox_NewItem_ExcOpt5);
			this.groupBox_NewItem_ExcOpt.Controls.Add(this.checkBox_NewItem_ExcOpt4);
			this.groupBox_NewItem_ExcOpt.Controls.Add(this.checkBox_NewItem_ExcOpt3);
			this.groupBox_NewItem_ExcOpt.Controls.Add(this.checkBox_NewItem_ExcOpt2);
			this.groupBox_NewItem_ExcOpt.Controls.Add(this.checkBox_NewItem_ExcOpt1);
			this.groupBox_NewItem_ExcOpt.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.groupBox_NewItem_ExcOpt.ForeColor = global::System.Drawing.Color.LawnGreen;
			this.groupBox_NewItem_ExcOpt.Location = new global::System.Drawing.Point(94, 18);
			this.groupBox_NewItem_ExcOpt.Name = "groupBox_NewItem_ExcOpt";
			this.groupBox_NewItem_ExcOpt.Size = new global::System.Drawing.Size(200, 148);
			this.groupBox_NewItem_ExcOpt.TabIndex = 17;
			this.groupBox_NewItem_ExcOpt.TabStop = false;
			this.groupBox_NewItem_ExcOpt.Text = "Excellent Options";
			this.radioButton_NewItem_ExcWings.AutoSize = true;
			this.radioButton_NewItem_ExcWings.Location = new global::System.Drawing.Point(141, 15);
			this.radioButton_NewItem_ExcWings.Name = "radioButton_NewItem_ExcWings";
			this.radioButton_NewItem_ExcWings.Size = new global::System.Drawing.Size(55, 17);
			this.radioButton_NewItem_ExcWings.TabIndex = 13;
			this.radioButton_NewItem_ExcWings.Text = "Wings";
			this.radioButton_NewItem_ExcWings.UseVisualStyleBackColor = true;
			this.radioButton_NewItem_ExcArmor.AutoSize = true;
			this.radioButton_NewItem_ExcArmor.Location = new global::System.Drawing.Point(83, 15);
			this.radioButton_NewItem_ExcArmor.Name = "radioButton_NewItem_ExcArmor";
			this.radioButton_NewItem_ExcArmor.Size = new global::System.Drawing.Size(52, 17);
			this.radioButton_NewItem_ExcArmor.TabIndex = 12;
			this.radioButton_NewItem_ExcArmor.Text = "Armor";
			this.radioButton_NewItem_ExcArmor.UseVisualStyleBackColor = true;
			this.radioButton_NewItem_ExcWeapon.AutoSize = true;
			this.radioButton_NewItem_ExcWeapon.Location = new global::System.Drawing.Point(11, 15);
			this.radioButton_NewItem_ExcWeapon.Name = "radioButton_NewItem_ExcWeapon";
			this.radioButton_NewItem_ExcWeapon.Size = new global::System.Drawing.Size(66, 17);
			this.radioButton_NewItem_ExcWeapon.TabIndex = 11;
			this.radioButton_NewItem_ExcWeapon.Text = "Weapon";
			this.radioButton_NewItem_ExcWeapon.UseVisualStyleBackColor = true;
			this.checkBox_NewItem_ExcOpt6.AutoSize = true;
			this.checkBox_NewItem_ExcOpt6.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.checkBox_NewItem_ExcOpt6.ForeColor = global::System.Drawing.Color.LawnGreen;
			this.checkBox_NewItem_ExcOpt6.Location = new global::System.Drawing.Point(6, 128);
			this.checkBox_NewItem_ExcOpt6.Name = "checkBox_NewItem_ExcOpt6";
			this.checkBox_NewItem_ExcOpt6.Size = new global::System.Drawing.Size(77, 17);
			this.checkBox_NewItem_ExcOpt6.TabIndex = 19;
			this.checkBox_NewItem_ExcOpt6.Text = "checkBox6";
			this.checkBox_NewItem_ExcOpt6.UseVisualStyleBackColor = true;
			this.checkBox_NewItem_ExcOpt5.AutoSize = true;
			this.checkBox_NewItem_ExcOpt5.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.checkBox_NewItem_ExcOpt5.ForeColor = global::System.Drawing.Color.LawnGreen;
			this.checkBox_NewItem_ExcOpt5.Location = new global::System.Drawing.Point(6, 110);
			this.checkBox_NewItem_ExcOpt5.Name = "checkBox_NewItem_ExcOpt5";
			this.checkBox_NewItem_ExcOpt5.Size = new global::System.Drawing.Size(77, 17);
			this.checkBox_NewItem_ExcOpt5.TabIndex = 18;
			this.checkBox_NewItem_ExcOpt5.Text = "checkBox5";
			this.checkBox_NewItem_ExcOpt5.UseVisualStyleBackColor = true;
			this.checkBox_NewItem_ExcOpt4.AutoSize = true;
			this.checkBox_NewItem_ExcOpt4.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.checkBox_NewItem_ExcOpt4.ForeColor = global::System.Drawing.Color.LawnGreen;
			this.checkBox_NewItem_ExcOpt4.Location = new global::System.Drawing.Point(6, 91);
			this.checkBox_NewItem_ExcOpt4.Name = "checkBox_NewItem_ExcOpt4";
			this.checkBox_NewItem_ExcOpt4.Size = new global::System.Drawing.Size(77, 17);
			this.checkBox_NewItem_ExcOpt4.TabIndex = 17;
			this.checkBox_NewItem_ExcOpt4.Text = "checkBox4";
			this.checkBox_NewItem_ExcOpt4.UseVisualStyleBackColor = true;
			this.checkBox_NewItem_ExcOpt3.AutoSize = true;
			this.checkBox_NewItem_ExcOpt3.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.checkBox_NewItem_ExcOpt3.ForeColor = global::System.Drawing.Color.LawnGreen;
			this.checkBox_NewItem_ExcOpt3.Location = new global::System.Drawing.Point(6, 73);
			this.checkBox_NewItem_ExcOpt3.Name = "checkBox_NewItem_ExcOpt3";
			this.checkBox_NewItem_ExcOpt3.Size = new global::System.Drawing.Size(77, 17);
			this.checkBox_NewItem_ExcOpt3.TabIndex = 16;
			this.checkBox_NewItem_ExcOpt3.Text = "checkBox3";
			this.checkBox_NewItem_ExcOpt3.UseVisualStyleBackColor = true;
			this.checkBox_NewItem_ExcOpt2.AutoSize = true;
			this.checkBox_NewItem_ExcOpt2.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.checkBox_NewItem_ExcOpt2.ForeColor = global::System.Drawing.Color.LawnGreen;
			this.checkBox_NewItem_ExcOpt2.Location = new global::System.Drawing.Point(6, 54);
			this.checkBox_NewItem_ExcOpt2.Name = "checkBox_NewItem_ExcOpt2";
			this.checkBox_NewItem_ExcOpt2.Size = new global::System.Drawing.Size(77, 17);
			this.checkBox_NewItem_ExcOpt2.TabIndex = 15;
			this.checkBox_NewItem_ExcOpt2.Text = "checkBox2";
			this.checkBox_NewItem_ExcOpt2.UseVisualStyleBackColor = true;
			this.checkBox_NewItem_ExcOpt1.AutoSize = true;
			this.checkBox_NewItem_ExcOpt1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.checkBox_NewItem_ExcOpt1.ForeColor = global::System.Drawing.Color.LawnGreen;
			this.checkBox_NewItem_ExcOpt1.Location = new global::System.Drawing.Point(6, 36);
			this.checkBox_NewItem_ExcOpt1.Name = "checkBox_NewItem_ExcOpt1";
			this.checkBox_NewItem_ExcOpt1.Size = new global::System.Drawing.Size(77, 17);
			this.checkBox_NewItem_ExcOpt1.TabIndex = 14;
			this.checkBox_NewItem_ExcOpt1.Text = "checkBox1";
			this.checkBox_NewItem_ExcOpt1.UseVisualStyleBackColor = true;
			this.listBox_NewItem_ItemOption.FormattingEnabled = true;
			this.listBox_NewItem_ItemOption.Location = new global::System.Drawing.Point(52, 38);
			this.listBox_NewItem_ItemOption.Name = "listBox_NewItem_ItemOption";
			this.listBox_NewItem_ItemOption.Size = new global::System.Drawing.Size(35, 134);
			this.listBox_NewItem_ItemOption.TabIndex = 9;
			this.checkBox_AddItem_FOItem.AutoSize = true;
			this.checkBox_AddItem_FOItem.BackColor = global::System.Drawing.Color.Transparent;
			this.checkBox_AddItem_FOItem.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.checkBox_AddItem_FOItem.ForeColor = global::System.Drawing.Color.LightSkyBlue;
			this.checkBox_AddItem_FOItem.Location = new global::System.Drawing.Point(58, 184);
			this.checkBox_AddItem_FOItem.Name = "checkBox_AddItem_FOItem";
			this.checkBox_AddItem_FOItem.Size = new global::System.Drawing.Size(127, 17);
			this.checkBox_AddItem_FOItem.TabIndex = 10;
			this.checkBox_AddItem_FOItem.Text = "Exc FO+15+28+Luck";
			this.checkBox_AddItem_FOItem.UseVisualStyleBackColor = false;
			this.checkBox_NewItem_Luck.AutoSize = true;
			this.checkBox_NewItem_Luck.Location = new global::System.Drawing.Point(240, 245);
			this.checkBox_NewItem_Luck.Name = "checkBox_NewItem_Luck";
			this.checkBox_NewItem_Luck.Size = new global::System.Drawing.Size(54, 17);
			this.checkBox_NewItem_Luck.TabIndex = 24;
			this.checkBox_NewItem_Luck.Text = "Luck";
			this.checkBox_NewItem_Luck.UseVisualStyleBackColor = true;
			this.groupBox9.Controls.Add(this.comboBox_Ancient);
			this.groupBox9.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 177);
			this.groupBox9.ForeColor = global::System.Drawing.Color.DarkCyan;
			this.groupBox9.Location = new global::System.Drawing.Point(185, 171);
			this.groupBox9.Name = "groupBox9";
			this.groupBox9.Size = new global::System.Drawing.Size(105, 46);
			this.groupBox9.TabIndex = 14;
			this.groupBox9.TabStop = false;
			this.groupBox9.Text = "Ancient ";
			this.comboBox_Ancient.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_Ancient.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 177);
			this.comboBox_Ancient.ForeColor = global::System.Drawing.SystemColors.ActiveCaptionText;
			this.comboBox_Ancient.FormattingEnabled = true;
			this.comboBox_Ancient.Location = new global::System.Drawing.Point(6, 18);
			this.comboBox_Ancient.Name = "comboBox_Ancient";
			this.comboBox_Ancient.Size = new global::System.Drawing.Size(94, 21);
			this.comboBox_Ancient.TabIndex = 20;
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(6, 18);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(38, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Level";
			this.checkBox_NewItem_Skill.AutoSize = true;
			this.checkBox_NewItem_Skill.Location = new global::System.Drawing.Point(240, 224);
			this.checkBox_NewItem_Skill.Name = "checkBox_NewItem_Skill";
			this.checkBox_NewItem_Skill.Size = new global::System.Drawing.Size(50, 17);
			this.checkBox_NewItem_Skill.TabIndex = 23;
			this.checkBox_NewItem_Skill.Text = "Skill";
			this.checkBox_NewItem_Skill.UseVisualStyleBackColor = true;
			this.groupBox8.BackColor = global::System.Drawing.Color.Transparent;
			this.groupBox8.Controls.Add(this.numericUpDown_NewItem_SocketCount);
			this.groupBox8.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.groupBox8.ForeColor = global::System.Drawing.Color.BlueViolet;
			this.groupBox8.Location = new global::System.Drawing.Point(58, 222);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new global::System.Drawing.Size(95, 38);
			this.groupBox8.TabIndex = 12;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "Empty Sockets";
			this.numericUpDown_NewItem_SocketCount.Location = new global::System.Drawing.Point(25, 16);
			global::System.Windows.Forms.NumericUpDown numericUpDown3 = this.numericUpDown_NewItem_SocketCount;
			int[] array3 = new int[4];
			array3[0] = 5;
			numericUpDown3.Maximum = new decimal(array3);
			this.numericUpDown_NewItem_SocketCount.Name = "numericUpDown_NewItem_SocketCount";
			this.numericUpDown_NewItem_SocketCount.Size = new global::System.Drawing.Size(45, 20);
			this.numericUpDown_NewItem_SocketCount.TabIndex = 21;
			this.label4.AutoSize = true;
			this.label4.Location = new global::System.Drawing.Point(44, 18);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(44, 13);
			this.label4.TabIndex = 3;
			this.label4.Text = "Option";
			this.groupBox6.Controls.Add(this.numericUpDown_NewItem_Durability);
			this.groupBox6.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.groupBox6.ForeColor = global::System.Drawing.Color.DarkKhaki;
			this.groupBox6.Location = new global::System.Drawing.Point(157, 222);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new global::System.Drawing.Size(72, 38);
			this.groupBox6.TabIndex = 10;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Duration";
			this.numericUpDown_NewItem_Durability.Location = new global::System.Drawing.Point(14, 14);
			global::System.Windows.Forms.NumericUpDown numericUpDown4 = this.numericUpDown_NewItem_Durability;
			int[] array4 = new int[4];
			array4[0] = 255;
			numericUpDown4.Maximum = new decimal(array4);
			this.numericUpDown_NewItem_Durability.Name = "numericUpDown_NewItem_Durability";
			this.numericUpDown_NewItem_Durability.Size = new global::System.Drawing.Size(45, 20);
			this.numericUpDown_NewItem_Durability.TabIndex = 22;
			global::System.Windows.Forms.NumericUpDown numericUpDown5 = this.numericUpDown_NewItem_Durability;
			int[] array5 = new int[4];
			array5[0] = 255;
			numericUpDown5.Value = new decimal(array5);
			this.listBox_NewItem_ItemLevel.FormattingEnabled = true;
			this.listBox_NewItem_ItemLevel.Location = new global::System.Drawing.Point(11, 38);
			this.listBox_NewItem_ItemLevel.Name = "listBox_NewItem_ItemLevel";
			this.listBox_NewItem_ItemLevel.Size = new global::System.Drawing.Size(35, 186);
			this.listBox_NewItem_ItemLevel.TabIndex = 8;
			this.button_NewItem_Add.Location = new global::System.Drawing.Point(20, 616);
			this.button_NewItem_Add.Name = "button_NewItem_Add";
			this.button_NewItem_Add.Size = new global::System.Drawing.Size(303, 30);
			this.button_NewItem_Add.TabIndex = 25;
			this.button_NewItem_Add.Text = "Add";
			this.button_NewItem_Add.UseVisualStyleBackColor = true;
			this.pictureBox_NewItem_ItemPreview.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBox_NewItem_ItemPreview.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox_NewItem_ItemPreview.Location = new global::System.Drawing.Point(20, 104);
			this.pictureBox_NewItem_ItemPreview.Name = "pictureBox_NewItem_ItemPreview";
			this.pictureBox_NewItem_ItemPreview.Size = new global::System.Drawing.Size(129, 79);
			this.pictureBox_NewItem_ItemPreview.TabIndex = 3;
			this.pictureBox_NewItem_ItemPreview.TabStop = false;
			this.listBox_NewItem_ItemIndex.FormattingEnabled = true;
			this.listBox_NewItem_ItemIndex.ItemHeight = 12;
			this.listBox_NewItem_ItemIndex.Location = new global::System.Drawing.Point(155, 23);
			this.listBox_NewItem_ItemIndex.Name = "listBox_NewItem_ItemIndex";
			this.listBox_NewItem_ItemIndex.Size = new global::System.Drawing.Size(168, 160);
			this.listBox_NewItem_ItemIndex.TabIndex = 1;
			this.listBox_NewItem_ItemGroup.FormattingEnabled = true;
			this.listBox_NewItem_ItemGroup.ItemHeight = 12;
			this.listBox_NewItem_ItemGroup.Location = new global::System.Drawing.Point(20, 23);
			this.listBox_NewItem_ItemGroup.Name = "listBox_NewItem_ItemGroup";
			this.listBox_NewItem_ItemGroup.Size = new global::System.Drawing.Size(129, 76);
			this.listBox_NewItem_ItemGroup.TabIndex = 0;
			this.panel_MainForm.BackgroundImage = Properties.Resources.panel_MainForm_BackgroundImage;
			this.panel_MainForm.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Stretch;
			this.panel_MainForm.Controls.Add(this.panel_SubCatEnd);
			this.panel_MainForm.Controls.Add(this.panel_CatFirst);
			this.panel_MainForm.Controls.Add(this.textBox_SubCat1);
			this.panel_MainForm.Controls.Add(this.label_MaxPage);
			this.panel_MainForm.Controls.Add(this.panel_ItemsPage1);
			this.panel_MainForm.Controls.Add(this.panel8);
			this.panel_MainForm.Controls.Add(this.label_CurrPage);
			this.panel_MainForm.Controls.Add(this.panel9);
			this.panel_MainForm.Controls.Add(this.panel_NextPage);
			this.panel_MainForm.Controls.Add(this.panel_PrevPage);
			this.panel_MainForm.Controls.Add(this.panel_SubCat1);
			this.panel_MainForm.Location = new global::System.Drawing.Point(0, 25);
			this.panel_MainForm.Name = "panel_MainForm";
			this.panel_MainForm.Size = new global::System.Drawing.Size(694, 666);
			this.panel_MainForm.TabIndex = 0;
			this.panel_SubCatEnd.BackgroundImage = Properties.Resources.panel_SubCatEnd_BackgroundImage;
			this.panel_SubCatEnd.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Zoom;
			this.panel_SubCatEnd.Location = new global::System.Drawing.Point(-5, 36);
			this.panel_SubCatEnd.Name = "panel_SubCatEnd";
			this.panel_SubCatEnd.Size = new global::System.Drawing.Size(54, 73);
			this.panel_SubCatEnd.TabIndex = 2;
			this.panel_CatFirst.BackgroundImage = Properties.Resources.panel_CatFirst_BackgroundImage;
			this.panel_CatFirst.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Stretch;
			this.panel_CatFirst.Controls.Add(this.textBox_Cat1);
			this.panel_CatFirst.Location = new global::System.Drawing.Point(91, 0);
			this.panel_CatFirst.Name = "panel_CatFirst";
			this.panel_CatFirst.Size = new global::System.Drawing.Size(119, 36);
			this.panel_CatFirst.TabIndex = 3;
			this.panel_CatFirst.Visible = false;
			this.textBox_Cat1.BackColor = global::System.Drawing.Color.Black;
			this.textBox_Cat1.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.textBox_Cat1.Font = new global::System.Drawing.Font("Arial Black", 8f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 177);
			this.textBox_Cat1.ForeColor = global::System.Drawing.Color.White;
			this.textBox_Cat1.Location = new global::System.Drawing.Point(12, 6);
			this.textBox_Cat1.Name = "textBox_Cat1";
			this.textBox_Cat1.Size = new global::System.Drawing.Size(91, 16);
			this.textBox_Cat1.TabIndex = 1;
			this.textBox_Cat1.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
			this.textBox_SubCat1.BackColor = global::System.Drawing.Color.Black;
			this.textBox_SubCat1.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.textBox_SubCat1.Font = new global::System.Drawing.Font("Arial Black", 8f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 177);
			this.textBox_SubCat1.ForeColor = global::System.Drawing.Color.White;
			this.textBox_SubCat1.Location = new global::System.Drawing.Point(12, 142);
			this.textBox_SubCat1.Name = "textBox_SubCat1";
			this.textBox_SubCat1.Size = new global::System.Drawing.Size(91, 16);
			this.textBox_SubCat1.TabIndex = 2;
			this.textBox_SubCat1.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
			this.textBox_SubCat1.Visible = false;
			this.label_MaxPage.AutoSize = true;
			this.label_MaxPage.BackColor = global::System.Drawing.Color.Transparent;
			this.label_MaxPage.ForeColor = global::System.Drawing.Color.White;
			this.label_MaxPage.Location = new global::System.Drawing.Point(422, 627);
			this.label_MaxPage.Name = "label_MaxPage";
			this.label_MaxPage.Size = new global::System.Drawing.Size(11, 12);
			this.label_MaxPage.TabIndex = 10;
			this.label_MaxPage.Text = "2";
			this.panel_ItemsPage1.BackgroundImage = Properties.Resources.panel_ItemsPage1_BackgroundImage;
			this.panel_ItemsPage1.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Stretch;
			this.panel_ItemsPage1.Controls.Add(this.panel_Item);
			this.panel_ItemsPage1.Location = new global::System.Drawing.Point(138, 44);
			this.panel_ItemsPage1.Name = "panel_ItemsPage1";
			this.panel_ItemsPage1.Size = new global::System.Drawing.Size(537, 535);
			this.panel_ItemsPage1.TabIndex = 4;
			this.panel_Item.BackColor = global::System.Drawing.Color.Transparent;
			this.panel_Item.Controls.Add(this.label_ItemPrice);
			this.panel_Item.Controls.Add(this.label_ItemName);
			this.panel_Item.Controls.Add(this.pictureBox_ItemImg);
			this.panel_Item.Location = new global::System.Drawing.Point(3, 5);
			this.panel_Item.Name = "panel_Item";
			this.panel_Item.Size = new global::System.Drawing.Size(175, 151);
			this.panel_Item.TabIndex = 0;
			this.panel_Item.Visible = false;
			this.label_ItemPrice.ForeColor = global::System.Drawing.Color.White;
			this.label_ItemPrice.Location = new global::System.Drawing.Point(24, 126);
			this.label_ItemPrice.Name = "label_ItemPrice";
			this.label_ItemPrice.Size = new global::System.Drawing.Size(128, 12);
			this.label_ItemPrice.TabIndex = 2;
			this.label_ItemPrice.Text = "label2";
			this.label_ItemName.ForeColor = global::System.Drawing.Color.White;
			this.label_ItemName.Location = new global::System.Drawing.Point(27, 13);
			this.label_ItemName.Name = "label_ItemName";
			this.label_ItemName.Size = new global::System.Drawing.Size(117, 17);
			this.label_ItemName.TabIndex = 1;
			this.label_ItemName.Text = "label1";
			this.pictureBox_ItemImg.Location = new global::System.Drawing.Point(13, 34);
			this.pictureBox_ItemImg.Name = "pictureBox_ItemImg";
			this.pictureBox_ItemImg.Size = new global::System.Drawing.Size(145, 88);
			this.pictureBox_ItemImg.TabIndex = 0;
			this.pictureBox_ItemImg.TabStop = false;
			this.panel8.BackgroundImage = Properties.Resources.panel8_BackgroundImage;
			this.panel8.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.panel8.Location = new global::System.Drawing.Point(682, 0);
			this.panel8.Name = "panel8";
			this.panel8.Size = new global::System.Drawing.Size(12, 620);
			this.panel8.TabIndex = 0;
			this.label_CurrPage.AutoSize = true;
			this.label_CurrPage.BackColor = global::System.Drawing.Color.Transparent;
			this.label_CurrPage.ForeColor = global::System.Drawing.Color.White;
			this.label_CurrPage.Location = new global::System.Drawing.Point(379, 627);
			this.label_CurrPage.Name = "label_CurrPage";
			this.label_CurrPage.Size = new global::System.Drawing.Size(11, 12);
			this.label_CurrPage.TabIndex = 3;
			this.label_CurrPage.Text = "1";
			this.panel9.BackgroundImage = Properties.Resources.panel9_BackgroundImage;
			this.panel9.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.panel9.Location = new global::System.Drawing.Point(0, 650);
			this.panel9.Name = "panel9";
			this.panel9.Size = new global::System.Drawing.Size(647, 17);
			this.panel9.TabIndex = 9;
			this.panel_NextPage.BackColor = global::System.Drawing.Color.Transparent;
			this.panel_NextPage.Location = new global::System.Drawing.Point(444, 613);
			this.panel_NextPage.Name = "panel_NextPage";
			this.panel_NextPage.Size = new global::System.Drawing.Size(35, 36);
			this.panel_NextPage.TabIndex = 6;
			this.panel_NextPage.Click += new global::System.EventHandler(this.panel_NextPage_Click);
			this.panel_PrevPage.BackColor = global::System.Drawing.Color.Transparent;
			this.panel_PrevPage.Location = new global::System.Drawing.Point(335, 616);
			this.panel_PrevPage.Name = "panel_PrevPage";
			this.panel_PrevPage.Size = new global::System.Drawing.Size(35, 36);
			this.panel_PrevPage.TabIndex = 5;
			this.panel_PrevPage.Click += new global::System.EventHandler(this.panel_PrevPage_Click);
			this.panel_SubCat1.BackgroundImage = Properties.Resources.panel_SubCat1_BackgroundImage;
			this.panel_SubCat1.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Zoom;
			this.panel_SubCat1.Location = new global::System.Drawing.Point(0, 0);
			this.panel_SubCat1.Name = "panel_SubCat1";
			this.panel_SubCat1.Size = new global::System.Drawing.Size(69, 36);
			this.panel_SubCat1.TabIndex = 1;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(694, 691);
			base.Controls.Add(this.panel_ItemAdd);
			base.Controls.Add(this.menuStrip1);
			base.Controls.Add(this.panel_MainForm);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "CashShopEditor";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "CashShop Editor";
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.CashShopEditor_FormClosed);
			base.Load += new global::System.EventHandler(this.CashShopEditor_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.panel_ItemAdd.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_NewItem_Count).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_NewItem_Price).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox_NewItem_ExcOpt.ResumeLayout(false);
			this.groupBox_NewItem_ExcOpt.PerformLayout();
			this.groupBox9.ResumeLayout(false);
			this.groupBox8.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_NewItem_SocketCount).EndInit();
			this.groupBox6.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_NewItem_Durability).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox_NewItem_ItemPreview).EndInit();
			this.panel_MainForm.ResumeLayout(false);
			this.panel_MainForm.PerformLayout();
			this.panel_CatFirst.ResumeLayout(false);
			this.panel_CatFirst.PerformLayout();
			this.panel_ItemsPage1.ResumeLayout(false);
			this.panel_Item.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox_ItemImg).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400009E RID: 158
		private global::System.Windows.Forms.ToolStripMenuItem addNewToolStripMenuItem;

		// Token: 0x0400009F RID: 159
		private global::System.Windows.Forms.ToolStripMenuItem addNewToolStripMenuItem1;

		// Token: 0x040000A0 RID: 160
		private global::System.Windows.Forms.Button button_NewItem_Add;

		// Token: 0x040000A2 RID: 162
		private global::System.Windows.Forms.CheckBox checkBox_AddItem_FOItem;

		// Token: 0x040000A3 RID: 163
		public global::System.Windows.Forms.CheckBox checkBox_NewItem_ExcOpt1;

		// Token: 0x040000A4 RID: 164
		public global::System.Windows.Forms.CheckBox checkBox_NewItem_ExcOpt2;

		// Token: 0x040000A5 RID: 165
		public global::System.Windows.Forms.CheckBox checkBox_NewItem_ExcOpt3;

		// Token: 0x040000A6 RID: 166
		public global::System.Windows.Forms.CheckBox checkBox_NewItem_ExcOpt4;

		// Token: 0x040000A7 RID: 167
		public global::System.Windows.Forms.CheckBox checkBox_NewItem_ExcOpt5;

		// Token: 0x040000A8 RID: 168
		public global::System.Windows.Forms.CheckBox checkBox_NewItem_ExcOpt6;

		// Token: 0x040000A9 RID: 169
		public global::System.Windows.Forms.CheckBox checkBox_NewItem_Luck;

		// Token: 0x040000AA RID: 170
		public global::System.Windows.Forms.CheckBox checkBox_NewItem_Skill;

		// Token: 0x040000AB RID: 171
		private global::System.Windows.Forms.ToolStripMenuItem clientFilesToolStripMenuItem;

		// Token: 0x040000AC RID: 172
		public global::System.Windows.Forms.ComboBox comboBox_Ancient;

		// Token: 0x040000AD RID: 173
		private global::System.Windows.Forms.ComboBox comboBox_NewItem_Coin;

		// Token: 0x040000AE RID: 174
		private global::System.Windows.Forms.ComboBox comboBox_NewItem_CountType;

		// Token: 0x040000AF RID: 175
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040000B1 RID: 177
		private global::System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;

		// Token: 0x040000B2 RID: 178
		private global::System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;

		// Token: 0x040000B4 RID: 180
		private global::System.Windows.Forms.GroupBox groupBox_NewItem_ExcOpt;

		// Token: 0x040000B5 RID: 181
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x040000B6 RID: 182
		private global::System.Windows.Forms.GroupBox groupBox2;

		// Token: 0x040000B7 RID: 183
		private global::System.Windows.Forms.GroupBox groupBox6;

		// Token: 0x040000B8 RID: 184
		private global::System.Windows.Forms.GroupBox groupBox8;

		// Token: 0x040000B9 RID: 185
		private global::System.Windows.Forms.GroupBox groupBox9;

		// Token: 0x040000BB RID: 187
		private global::System.Windows.Forms.ToolStripMenuItem headCategoriesToolStripMenuItem;

		// Token: 0x040000C9 RID: 201
		public global::System.Windows.Forms.Label label_CurrPage;

		// Token: 0x040000CA RID: 202
		private global::System.Windows.Forms.Label label_ItemName;

		// Token: 0x040000CB RID: 203
		private global::System.Windows.Forms.Label label_ItemPrice;

		// Token: 0x040000CC RID: 204
		private global::System.Windows.Forms.Label label_MaxPage;

		// Token: 0x040000CD RID: 205
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040000CE RID: 206
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040000CF RID: 207
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040000D0 RID: 208
		private global::System.Windows.Forms.Label label4;

		// Token: 0x040000D1 RID: 209
		private global::System.Windows.Forms.Label label5;

		// Token: 0x040000D2 RID: 210
		private global::System.Windows.Forms.Label label6;

		// Token: 0x040000D3 RID: 211
		private global::System.Windows.Forms.Label label7;

		// Token: 0x040000D4 RID: 212
		private global::System.Windows.Forms.Label label8;

		// Token: 0x040000D9 RID: 217
		public global::System.Windows.Forms.ListBox listBox_NewItem_ItemGroup;

		// Token: 0x040000DA RID: 218
		public global::System.Windows.Forms.ListBox listBox_NewItem_ItemIndex;

		// Token: 0x040000DB RID: 219
		public global::System.Windows.Forms.ListBox listBox_NewItem_ItemLevel;

		// Token: 0x040000DC RID: 220
		public global::System.Windows.Forms.ListBox listBox_NewItem_ItemOption;

		// Token: 0x040000E1 RID: 225
		private global::System.Windows.Forms.MenuStrip menuStrip1;

		// Token: 0x040000E2 RID: 226
		private global::System.Windows.Forms.NumericUpDown numericUpDown_NewItem_Count;

		// Token: 0x040000E3 RID: 227
		public global::System.Windows.Forms.NumericUpDown numericUpDown_NewItem_Durability;

		// Token: 0x040000E4 RID: 228
		private global::System.Windows.Forms.NumericUpDown numericUpDown_NewItem_Price;

		// Token: 0x040000E5 RID: 229
		public global::System.Windows.Forms.NumericUpDown numericUpDown_NewItem_SocketCount;

		// Token: 0x040000E8 RID: 232
		private global::MU_ToolKit.MyPanel panel_CatFirst;

		// Token: 0x040000E9 RID: 233
		private global::MU_ToolKit.MyPanel panel_Item;

		// Token: 0x040000EA RID: 234
		private global::System.Windows.Forms.Panel panel_ItemAdd;

		// Token: 0x040000EB RID: 235
		private global::MU_ToolKit.MyPanel panel_ItemsPage1;

		// Token: 0x040000EC RID: 236
		private global::MU_ToolKit.MyPanel panel_MainForm;

		// Token: 0x040000ED RID: 237
		private global::MU_ToolKit.MyPanel panel_NextPage;

		// Token: 0x040000EE RID: 238
		private global::MU_ToolKit.MyPanel panel_PrevPage;

		// Token: 0x040000EF RID: 239
		private global::MU_ToolKit.MyPanel panel_SubCat1;

		// Token: 0x040000F0 RID: 240
		private global::MU_ToolKit.MyPanel panel_SubCatEnd;

		// Token: 0x040000F1 RID: 241
		private global::MU_ToolKit.MyPanel panel8;

		// Token: 0x040000F2 RID: 242
		private global::MU_ToolKit.MyPanel panel9;

		// Token: 0x040000F3 RID: 243
		private global::System.Windows.Forms.PictureBox pictureBox_ItemImg;

		// Token: 0x040000F4 RID: 244
		private global::System.Windows.Forms.PictureBox pictureBox_NewItem_ItemPreview;

		// Token: 0x040000F8 RID: 248
		private global::System.Windows.Forms.RadioButton radioButton_NewItem_ExcArmor;

		// Token: 0x040000F9 RID: 249
		private global::System.Windows.Forms.RadioButton radioButton_NewItem_ExcWeapon;

		// Token: 0x040000FA RID: 250
		private global::System.Windows.Forms.RadioButton radioButton_NewItem_ExcWings;

		// Token: 0x040000FC RID: 252
		private global::System.Windows.Forms.RichTextBox richTextBox_NewItem_Info;

		// Token: 0x040000FD RID: 253
		private global::System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;

		// Token: 0x04000107 RID: 263
		private global::System.Windows.Forms.ToolStripMenuItem serverFilesToolStripMenuItem;

		// Token: 0x0400010B RID: 267
		private global::System.Windows.Forms.ToolStripMenuItem subCategoriesToolStripMenuItem;

		// Token: 0x0400010E RID: 270
		private global::System.Windows.Forms.TextBox textBox_Cat1;

		// Token: 0x0400010F RID: 271
		private global::System.Windows.Forms.TextBox textBox_NewItem_Name;

		// Token: 0x04000110 RID: 272
		private global::System.Windows.Forms.TextBox textBox_SubCat1;
	}
}
