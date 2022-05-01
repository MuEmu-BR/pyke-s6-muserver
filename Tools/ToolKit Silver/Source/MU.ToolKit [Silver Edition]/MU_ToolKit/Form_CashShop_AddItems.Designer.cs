namespace MU_ToolKit
{
	// Token: 0x0200002B RID: 43
	public partial class Form_CashShop_AddItems : global::System.Windows.Forms.Form
	{
		// Token: 0x06000616 RID: 1558 RVA: 0x0006FCDE File Offset: 0x0006DEDE
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600061A RID: 1562 RVA: 0x000700FC File Offset: 0x0006E2FC
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::MU_ToolKit.Form_CashShop_AddItems));
			this.panel_ItemAdd = new global::System.Windows.Forms.Panel();
			this.button_UpdateExistingItem = new global::System.Windows.Forms.Button();
			this.button_AddItemToDB = new global::System.Windows.Forms.Button();
			this.groupBox2 = new global::System.Windows.Forms.GroupBox();
			this.label8 = new global::System.Windows.Forms.Label();
			this.groupBox_PackageItem = new global::System.Windows.Forms.GroupBox();
			this.comboBox_PackageItem_ItemsDatabase = new global::System.Windows.Forms.ComboBox();
			this.button_PackageItem_RemoveFromList = new global::System.Windows.Forms.Button();
			this.button_PackageItem_AddToList = new global::System.Windows.Forms.Button();
			this.label27 = new global::System.Windows.Forms.Label();
			this.listBox_PackageItem_AddedItems = new global::System.Windows.Forms.ListBox();
			this.checkBox_PackageItem = new global::System.Windows.Forms.CheckBox();
			this.checkBox_MultiItem = new global::System.Windows.Forms.CheckBox();
			this.groupBox_MultiItem = new global::System.Windows.Forms.GroupBox();
			this.buttonClearAll_Multi = new global::System.Windows.Forms.Button();
			this.tabControl1 = new global::System.Windows.Forms.TabControl();
			this.tabPage_MultiOption_1 = new global::System.Windows.Forms.TabPage();
			this.numericUpDown_Durability_Multi_1 = new global::System.Windows.Forms.NumericUpDown();
			this.numericUpDown_Sockets_Multi_1 = new global::System.Windows.Forms.NumericUpDown();
			this.label41 = new global::System.Windows.Forms.Label();
			this.comboBox_Ancient_Multi_1 = new global::System.Windows.Forms.ComboBox();
			this.label39 = new global::System.Windows.Forms.Label();
			this.checkBox_Luck_Multi_1 = new global::System.Windows.Forms.CheckBox();
			this.groupBox_1 = new global::System.Windows.Forms.GroupBox();
			this.radioButton_Wings_Multi_1 = new global::System.Windows.Forms.RadioButton();
			this.radioButton_Armor_Multi_1 = new global::System.Windows.Forms.RadioButton();
			this.radioButton_Weapon_Multi_1 = new global::System.Windows.Forms.RadioButton();
			this.checkBox_ExcOption6_Multi_1 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_ExcOption5_Multi_1 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_ExcOption4_Multi_1 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_ExcOption3_Multi_1 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_ExcOption2_Multi_1 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_ExcOption1_Multi_1 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_Skill_Multi_1 = new global::System.Windows.Forms.CheckBox();
			this.listBox_Option_Multi_1 = new global::System.Windows.Forms.ListBox();
			this.textBox_Name_Multi_1 = new global::System.Windows.Forms.TextBox();
			this.label15 = new global::System.Windows.Forms.Label();
			this.label11 = new global::System.Windows.Forms.Label();
			this.label10 = new global::System.Windows.Forms.Label();
			this.label12 = new global::System.Windows.Forms.Label();
			this.numericUpDown_Price_Multi_1 = new global::System.Windows.Forms.NumericUpDown();
			this.listBox_Level_Multi_1 = new global::System.Windows.Forms.ListBox();
			this.label9 = new global::System.Windows.Forms.Label();
			this.checkBox_isMulti_1 = new global::System.Windows.Forms.CheckBox();
			this.numericUpDown_Count_Multi_1 = new global::System.Windows.Forms.NumericUpDown();
			this.label42 = new global::System.Windows.Forms.Label();
			this.tabPage_MultiOption_2 = new global::System.Windows.Forms.TabPage();
			this.numericUpDown_Durability_Multi_2 = new global::System.Windows.Forms.NumericUpDown();
			this.numericUpDown_Sockets_Multi_2 = new global::System.Windows.Forms.NumericUpDown();
			this.comboBox_Ancient_Multi_2 = new global::System.Windows.Forms.ComboBox();
			this.label43 = new global::System.Windows.Forms.Label();
			this.label44 = new global::System.Windows.Forms.Label();
			this.label45 = new global::System.Windows.Forms.Label();
			this.checkBox_Luck_Multi_2 = new global::System.Windows.Forms.CheckBox();
			this.groupBox_2 = new global::System.Windows.Forms.GroupBox();
			this.radioButton_Wings_Multi_2 = new global::System.Windows.Forms.RadioButton();
			this.radioButton_Armor_Multi_2 = new global::System.Windows.Forms.RadioButton();
			this.radioButton_Weapon_Multi_2 = new global::System.Windows.Forms.RadioButton();
			this.checkBox_ExcOption6_Multi_2 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_ExcOption5_Multi_2 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_ExcOption4_Multi_2 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_ExcOption3_Multi_2 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_ExcOption2_Multi_2 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_ExcOption1_Multi_2 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_Skill_Multi_2 = new global::System.Windows.Forms.CheckBox();
			this.listBox_Option_Multi_2 = new global::System.Windows.Forms.ListBox();
			this.textBox_Name_Multi_2 = new global::System.Windows.Forms.TextBox();
			this.label13 = new global::System.Windows.Forms.Label();
			this.label14 = new global::System.Windows.Forms.Label();
			this.label16 = new global::System.Windows.Forms.Label();
			this.label17 = new global::System.Windows.Forms.Label();
			this.numericUpDown_Price_Multi_2 = new global::System.Windows.Forms.NumericUpDown();
			this.listBox_Level_Multi_2 = new global::System.Windows.Forms.ListBox();
			this.label18 = new global::System.Windows.Forms.Label();
			this.checkBox_isMulti_2 = new global::System.Windows.Forms.CheckBox();
			this.numericUpDown_Count_Multi_2 = new global::System.Windows.Forms.NumericUpDown();
			this.tabPage_MultiOption_3 = new global::System.Windows.Forms.TabPage();
			this.label48 = new global::System.Windows.Forms.Label();
			this.numericUpDown_Durability_Multi_3 = new global::System.Windows.Forms.NumericUpDown();
			this.numericUpDown_Sockets_Multi_3 = new global::System.Windows.Forms.NumericUpDown();
			this.comboBox_Ancient_Multi_3 = new global::System.Windows.Forms.ComboBox();
			this.checkBox_Luck_Multi_3 = new global::System.Windows.Forms.CheckBox();
			this.groupBox_3 = new global::System.Windows.Forms.GroupBox();
			this.radioButton_Wings_Multi_3 = new global::System.Windows.Forms.RadioButton();
			this.radioButton_Armor_Multi_3 = new global::System.Windows.Forms.RadioButton();
			this.radioButton_Weapon_Multi_3 = new global::System.Windows.Forms.RadioButton();
			this.checkBox_ExcOption6_Multi_3 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_ExcOption5_Multi_3 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_ExcOption4_Multi_3 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_ExcOption3_Multi_3 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_ExcOption2_Multi_3 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_ExcOption1_Multi_3 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_Skill_Multi_3 = new global::System.Windows.Forms.CheckBox();
			this.listBox_Option_Multi_3 = new global::System.Windows.Forms.ListBox();
			this.textBox_Name_Multi_3 = new global::System.Windows.Forms.TextBox();
			this.label19 = new global::System.Windows.Forms.Label();
			this.label20 = new global::System.Windows.Forms.Label();
			this.label23 = new global::System.Windows.Forms.Label();
			this.numericUpDown_Price_Multi_3 = new global::System.Windows.Forms.NumericUpDown();
			this.listBox_Level_Multi_3 = new global::System.Windows.Forms.ListBox();
			this.label40 = new global::System.Windows.Forms.Label();
			this.checkBox_isMulti_3 = new global::System.Windows.Forms.CheckBox();
			this.numericUpDown_Count_Multi_3 = new global::System.Windows.Forms.NumericUpDown();
			this.label21 = new global::System.Windows.Forms.Label();
			this.label46 = new global::System.Windows.Forms.Label();
			this.label47 = new global::System.Windows.Forms.Label();
			this.tabPage_MultiOption_4 = new global::System.Windows.Forms.TabPage();
			this.label51 = new global::System.Windows.Forms.Label();
			this.numericUpDown_Durability_Multi_4 = new global::System.Windows.Forms.NumericUpDown();
			this.numericUpDown_Sockets_Multi_4 = new global::System.Windows.Forms.NumericUpDown();
			this.comboBox_Ancient_Multi_4 = new global::System.Windows.Forms.ComboBox();
			this.checkBox_Luck_Multi_4 = new global::System.Windows.Forms.CheckBox();
			this.groupBox_4 = new global::System.Windows.Forms.GroupBox();
			this.radioButton_Wings_Multi_4 = new global::System.Windows.Forms.RadioButton();
			this.radioButton_Armor_Multi_4 = new global::System.Windows.Forms.RadioButton();
			this.radioButton_Weapon_Multi_4 = new global::System.Windows.Forms.RadioButton();
			this.checkBox_ExcOption6_Multi_4 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_ExcOption5_Multi_4 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_ExcOption4_Multi_4 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_ExcOption3_Multi_4 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_ExcOption2_Multi_4 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_ExcOption1_Multi_4 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_Skill_Multi_4 = new global::System.Windows.Forms.CheckBox();
			this.listBox_Option_Multi_4 = new global::System.Windows.Forms.ListBox();
			this.textBox_Name_Multi_4 = new global::System.Windows.Forms.TextBox();
			this.label22 = new global::System.Windows.Forms.Label();
			this.label24 = new global::System.Windows.Forms.Label();
			this.label25 = new global::System.Windows.Forms.Label();
			this.label26 = new global::System.Windows.Forms.Label();
			this.numericUpDown_Price_Multi_4 = new global::System.Windows.Forms.NumericUpDown();
			this.listBox_Level_Multi_4 = new global::System.Windows.Forms.ListBox();
			this.label28 = new global::System.Windows.Forms.Label();
			this.checkBox_isMulti_4 = new global::System.Windows.Forms.CheckBox();
			this.numericUpDown_Count_Multi_4 = new global::System.Windows.Forms.NumericUpDown();
			this.label50 = new global::System.Windows.Forms.Label();
			this.label49 = new global::System.Windows.Forms.Label();
			this.tabPage_MultiOption_5 = new global::System.Windows.Forms.TabPage();
			this.numericUpDown_Durability_Multi_5 = new global::System.Windows.Forms.NumericUpDown();
			this.label52 = new global::System.Windows.Forms.Label();
			this.numericUpDown_Sockets_Multi_5 = new global::System.Windows.Forms.NumericUpDown();
			this.comboBox_Ancient_Multi_5 = new global::System.Windows.Forms.ComboBox();
			this.checkBox_Luck_Multi_5 = new global::System.Windows.Forms.CheckBox();
			this.groupBox_5 = new global::System.Windows.Forms.GroupBox();
			this.radioButton_Wings_Multi_5 = new global::System.Windows.Forms.RadioButton();
			this.radioButton_Armor_Multi_5 = new global::System.Windows.Forms.RadioButton();
			this.radioButton_Weapon_Multi_5 = new global::System.Windows.Forms.RadioButton();
			this.checkBox_ExcOption6_Multi_5 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_ExcOption5_Multi_5 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_ExcOption4_Multi_5 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_ExcOption3_Multi_5 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_ExcOption2_Multi_5 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_ExcOption1_Multi_5 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_Skill_Multi_5 = new global::System.Windows.Forms.CheckBox();
			this.listBox_Option_Multi_5 = new global::System.Windows.Forms.ListBox();
			this.textBox_Name_Multi_5 = new global::System.Windows.Forms.TextBox();
			this.label29 = new global::System.Windows.Forms.Label();
			this.label30 = new global::System.Windows.Forms.Label();
			this.label31 = new global::System.Windows.Forms.Label();
			this.label32 = new global::System.Windows.Forms.Label();
			this.numericUpDown_Price_Multi_5 = new global::System.Windows.Forms.NumericUpDown();
			this.listBox_Level_Multi_5 = new global::System.Windows.Forms.ListBox();
			this.label33 = new global::System.Windows.Forms.Label();
			this.checkBox_isMulti_5 = new global::System.Windows.Forms.CheckBox();
			this.numericUpDown_Count_Multi_5 = new global::System.Windows.Forms.NumericUpDown();
			this.label54 = new global::System.Windows.Forms.Label();
			this.label53 = new global::System.Windows.Forms.Label();
			this.tabPage_MultiOption_6 = new global::System.Windows.Forms.TabPage();
			this.numericUpDown_Durability_Multi_6 = new global::System.Windows.Forms.NumericUpDown();
			this.label55 = new global::System.Windows.Forms.Label();
			this.numericUpDown_Sockets_Multi_6 = new global::System.Windows.Forms.NumericUpDown();
			this.comboBox_Ancient_Multi_6 = new global::System.Windows.Forms.ComboBox();
			this.checkBox_Luck_Multi_6 = new global::System.Windows.Forms.CheckBox();
			this.groupBox_6 = new global::System.Windows.Forms.GroupBox();
			this.radioButton_Wings_Multi_6 = new global::System.Windows.Forms.RadioButton();
			this.radioButton_Armor_Multi_6 = new global::System.Windows.Forms.RadioButton();
			this.radioButton_Weapon_Multi_6 = new global::System.Windows.Forms.RadioButton();
			this.checkBox_ExcOption6_Multi_6 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_ExcOption5_Multi_6 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_ExcOption4_Multi_6 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_ExcOption3_Multi_6 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_ExcOption2_Multi_6 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_ExcOption1_Multi_6 = new global::System.Windows.Forms.CheckBox();
			this.checkBox_Skill_Multi_6 = new global::System.Windows.Forms.CheckBox();
			this.listBox_Option_Multi_6 = new global::System.Windows.Forms.ListBox();
			this.textBox_Name_Multi_6 = new global::System.Windows.Forms.TextBox();
			this.label34 = new global::System.Windows.Forms.Label();
			this.label35 = new global::System.Windows.Forms.Label();
			this.label36 = new global::System.Windows.Forms.Label();
			this.label37 = new global::System.Windows.Forms.Label();
			this.numericUpDown_Price_Multi_6 = new global::System.Windows.Forms.NumericUpDown();
			this.listBox_Level_Multi_6 = new global::System.Windows.Forms.ListBox();
			this.label38 = new global::System.Windows.Forms.Label();
			this.checkBox_isMulti_6 = new global::System.Windows.Forms.CheckBox();
			this.numericUpDown_Count_Multi_6 = new global::System.Windows.Forms.NumericUpDown();
			this.label57 = new global::System.Windows.Forms.Label();
			this.label56 = new global::System.Windows.Forms.Label();
			this.comboBox_NewItem_CountType = new global::System.Windows.Forms.ComboBox();
			this.numericUpDown_NewItem_Count = new global::System.Windows.Forms.NumericUpDown();
			this.comboBox_NewItem_Coin = new global::System.Windows.Forms.ComboBox();
			this.numericUpDown_NewItem_Price = new global::System.Windows.Forms.NumericUpDown();
			this.textBox_NewItem_Name = new global::System.Windows.Forms.TextBox();
			this.richTextBox_NewItem_Info = new global::System.Windows.Forms.RichTextBox();
			this.label7 = new global::System.Windows.Forms.Label();
			this.label6 = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.groupBox_ItemProperties = new global::System.Windows.Forms.GroupBox();
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
			this.textBox_Info = new global::System.Windows.Forms.TextBox();
			this.panel_ItemAdd.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox_PackageItem.SuspendLayout();
			this.groupBox_MultiItem.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage_MultiOption_1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Durability_Multi_1).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Sockets_Multi_1).BeginInit();
			this.groupBox_1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Price_Multi_1).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Count_Multi_1).BeginInit();
			this.tabPage_MultiOption_2.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Durability_Multi_2).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Sockets_Multi_2).BeginInit();
			this.groupBox_2.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Price_Multi_2).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Count_Multi_2).BeginInit();
			this.tabPage_MultiOption_3.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Durability_Multi_3).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Sockets_Multi_3).BeginInit();
			this.groupBox_3.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Price_Multi_3).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Count_Multi_3).BeginInit();
			this.tabPage_MultiOption_4.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Durability_Multi_4).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Sockets_Multi_4).BeginInit();
			this.groupBox_4.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Price_Multi_4).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Count_Multi_4).BeginInit();
			this.tabPage_MultiOption_5.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Durability_Multi_5).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Sockets_Multi_5).BeginInit();
			this.groupBox_5.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Price_Multi_5).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Count_Multi_5).BeginInit();
			this.tabPage_MultiOption_6.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Durability_Multi_6).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Sockets_Multi_6).BeginInit();
			this.groupBox_6.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Price_Multi_6).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Count_Multi_6).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_NewItem_Count).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_NewItem_Price).BeginInit();
			this.groupBox_ItemProperties.SuspendLayout();
			this.groupBox_NewItem_ExcOpt.SuspendLayout();
			this.groupBox9.SuspendLayout();
			this.groupBox8.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_NewItem_SocketCount).BeginInit();
			this.groupBox6.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_NewItem_Durability).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox_NewItem_ItemPreview).BeginInit();
			base.SuspendLayout();
			this.panel_ItemAdd.BackgroundImage = Properties.Resources.panel_ItemAdd_BackgroundImage;
			this.panel_ItemAdd.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Stretch;
			this.panel_ItemAdd.Controls.Add(this.button_UpdateExistingItem);
			this.panel_ItemAdd.Controls.Add(this.button_AddItemToDB);
			this.panel_ItemAdd.Controls.Add(this.groupBox2);
			this.panel_ItemAdd.Controls.Add(this.groupBox_ItemProperties);
			this.panel_ItemAdd.Controls.Add(this.button_NewItem_Add);
			this.panel_ItemAdd.Controls.Add(this.pictureBox_NewItem_ItemPreview);
			this.panel_ItemAdd.Controls.Add(this.listBox_NewItem_ItemIndex);
			this.panel_ItemAdd.Controls.Add(this.listBox_NewItem_ItemGroup);
			this.panel_ItemAdd.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.panel_ItemAdd.Location = new global::System.Drawing.Point(0, 0);
			this.panel_ItemAdd.Name = "panel_ItemAdd";
			this.panel_ItemAdd.Size = new global::System.Drawing.Size(911, 478);
			this.panel_ItemAdd.TabIndex = 3;
			this.button_UpdateExistingItem.ForeColor = global::System.Drawing.Color.Black;
			this.button_UpdateExistingItem.Location = new global::System.Drawing.Point(329, 427);
			this.button_UpdateExistingItem.Name = "button_UpdateExistingItem";
			this.button_UpdateExistingItem.Size = new global::System.Drawing.Size(178, 32);
			this.button_UpdateExistingItem.TabIndex = 27;
			this.button_UpdateExistingItem.Text = "[Update] Selected Item\r\nCtrl + S";
			this.button_UpdateExistingItem.UseVisualStyleBackColor = true;
			this.button_UpdateExistingItem.Click += new global::System.EventHandler(this.button_UpdateExistingItem_Click);
			this.button_AddItemToDB.ForeColor = global::System.Drawing.Color.Black;
			this.button_AddItemToDB.Location = new global::System.Drawing.Point(510, 427);
			this.button_AddItemToDB.Name = "button_AddItemToDB";
			this.button_AddItemToDB.Size = new global::System.Drawing.Size(187, 32);
			this.button_AddItemToDB.TabIndex = 26;
			this.button_AddItemToDB.Text = "Add to [Item's Database]\r\nCtrl + D";
			this.button_AddItemToDB.UseVisualStyleBackColor = true;
			this.button_AddItemToDB.Click += new global::System.EventHandler(this.button_AddItemToDB_Click);
			this.groupBox2.BackColor = global::System.Drawing.Color.Transparent;
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.groupBox_PackageItem);
			this.groupBox2.Controls.Add(this.checkBox_PackageItem);
			this.groupBox2.Controls.Add(this.checkBox_MultiItem);
			this.groupBox2.Controls.Add(this.groupBox_MultiItem);
			this.groupBox2.Controls.Add(this.comboBox_NewItem_CountType);
			this.groupBox2.Controls.Add(this.numericUpDown_NewItem_Count);
			this.groupBox2.Controls.Add(this.comboBox_NewItem_Coin);
			this.groupBox2.Controls.Add(this.numericUpDown_NewItem_Price);
			this.groupBox2.Controls.Add(this.textBox_NewItem_Name);
			this.groupBox2.Controls.Add(this.richTextBox_NewItem_Info);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.groupBox2.ForeColor = global::System.Drawing.Color.DarkGoldenrod;
			this.groupBox2.Location = new global::System.Drawing.Point(329, 23);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new global::System.Drawing.Size(559, 399);
			this.groupBox2.TabIndex = 21;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Cash Shop Item Options";
			this.label8.AutoSize = true;
			this.label8.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label8.Location = new global::System.Drawing.Point(12, 50);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(31, 13);
			this.label8.TabIndex = 50;
			this.label8.Text = "Info:";
			this.groupBox_PackageItem.Controls.Add(this.comboBox_PackageItem_ItemsDatabase);
			this.groupBox_PackageItem.Controls.Add(this.button_PackageItem_RemoveFromList);
			this.groupBox_PackageItem.Controls.Add(this.button_PackageItem_AddToList);
			this.groupBox_PackageItem.Controls.Add(this.label27);
			this.groupBox_PackageItem.Controls.Add(this.listBox_PackageItem_AddedItems);
			this.groupBox_PackageItem.Enabled = false;
			this.groupBox_PackageItem.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.groupBox_PackageItem.ForeColor = global::System.Drawing.Color.FromArgb(255, 128, 0);
			this.groupBox_PackageItem.Location = new global::System.Drawing.Point(300, 36);
			this.groupBox_PackageItem.Name = "groupBox_PackageItem";
			this.groupBox_PackageItem.Size = new global::System.Drawing.Size(243, 159);
			this.groupBox_PackageItem.TabIndex = 32;
			this.groupBox_PackageItem.TabStop = false;
			this.groupBox_PackageItem.Text = "Package Item Options";
			this.comboBox_PackageItem_ItemsDatabase.DropDownHeight = 105;
			this.comboBox_PackageItem_ItemsDatabase.DropDownWidth = 255;
			this.comboBox_PackageItem_ItemsDatabase.FormattingEnabled = true;
			this.comboBox_PackageItem_ItemsDatabase.IntegralHeight = false;
			this.comboBox_PackageItem_ItemsDatabase.Location = new global::System.Drawing.Point(58, 18);
			this.comboBox_PackageItem_ItemsDatabase.Name = "comboBox_PackageItem_ItemsDatabase";
			this.comboBox_PackageItem_ItemsDatabase.Size = new global::System.Drawing.Size(115, 21);
			this.comboBox_PackageItem_ItemsDatabase.TabIndex = 0;
			this.button_PackageItem_RemoveFromList.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.button_PackageItem_RemoveFromList.Location = new global::System.Drawing.Point(7, 134);
			this.button_PackageItem_RemoveFromList.Name = "button_PackageItem_RemoveFromList";
			this.button_PackageItem_RemoveFromList.Size = new global::System.Drawing.Size(230, 18);
			this.button_PackageItem_RemoveFromList.TabIndex = 4;
			this.button_PackageItem_RemoveFromList.Text = "Remove";
			this.button_PackageItem_RemoveFromList.UseVisualStyleBackColor = true;
			this.button_PackageItem_RemoveFromList.Click += new global::System.EventHandler(this.button_PackageItem_RemoveFromList_Click);
			this.button_PackageItem_AddToList.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.button_PackageItem_AddToList.Location = new global::System.Drawing.Point(179, 18);
			this.button_PackageItem_AddToList.Name = "button_PackageItem_AddToList";
			this.button_PackageItem_AddToList.Size = new global::System.Drawing.Size(58, 19);
			this.button_PackageItem_AddToList.TabIndex = 3;
			this.button_PackageItem_AddToList.Text = "Add";
			this.button_PackageItem_AddToList.UseVisualStyleBackColor = true;
			this.button_PackageItem_AddToList.Click += new global::System.EventHandler(this.button_PackageItem_AddToList_Click);
			this.label27.AutoSize = true;
			this.label27.ForeColor = global::System.Drawing.Color.White;
			this.label27.Location = new global::System.Drawing.Point(6, 21);
			this.label27.Name = "label27";
			this.label27.Size = new global::System.Drawing.Size(50, 13);
			this.label27.TabIndex = 2;
			this.label27.Text = "Item DB:";
			this.listBox_PackageItem_AddedItems.FormattingEnabled = true;
			this.listBox_PackageItem_AddedItems.HorizontalScrollbar = true;
			this.listBox_PackageItem_AddedItems.Location = new global::System.Drawing.Point(7, 41);
			this.listBox_PackageItem_AddedItems.Name = "listBox_PackageItem_AddedItems";
			this.listBox_PackageItem_AddedItems.Size = new global::System.Drawing.Size(230, 82);
			this.listBox_PackageItem_AddedItems.TabIndex = 1;
			this.checkBox_PackageItem.AutoSize = true;
			this.checkBox_PackageItem.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox_PackageItem.ForeColor = global::System.Drawing.Color.FromArgb(255, 128, 0);
			this.checkBox_PackageItem.Location = new global::System.Drawing.Point(300, 17);
			this.checkBox_PackageItem.Name = "checkBox_PackageItem";
			this.checkBox_PackageItem.Size = new global::System.Drawing.Size(93, 17);
			this.checkBox_PackageItem.TabIndex = 31;
			this.checkBox_PackageItem.Text = "Package Item";
			this.checkBox_PackageItem.UseVisualStyleBackColor = true;
			this.checkBox_PackageItem.CheckedChanged += new global::System.EventHandler(this.checkBox_PackageItem_CheckedChanged);
			this.checkBox_MultiItem.AutoSize = true;
			this.checkBox_MultiItem.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox_MultiItem.ForeColor = global::System.Drawing.Color.PaleGreen;
			this.checkBox_MultiItem.Location = new global::System.Drawing.Point(15, 172);
			this.checkBox_MultiItem.Name = "checkBox_MultiItem";
			this.checkBox_MultiItem.Size = new global::System.Drawing.Size(78, 17);
			this.checkBox_MultiItem.TabIndex = 30;
			this.checkBox_MultiItem.Text = "Multi Item";
			this.checkBox_MultiItem.UseVisualStyleBackColor = true;
			this.checkBox_MultiItem.CheckedChanged += new global::System.EventHandler(this.checkBox_MultiItem_CheckedChanged);
			this.groupBox_MultiItem.Controls.Add(this.buttonClearAll_Multi);
			this.groupBox_MultiItem.Controls.Add(this.tabControl1);
			this.groupBox_MultiItem.Enabled = false;
			this.groupBox_MultiItem.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.groupBox_MultiItem.ForeColor = global::System.Drawing.Color.PaleGreen;
			this.groupBox_MultiItem.Location = new global::System.Drawing.Point(15, 193);
			this.groupBox_MultiItem.Name = "groupBox_MultiItem";
			this.groupBox_MultiItem.Size = new global::System.Drawing.Size(528, 199);
			this.groupBox_MultiItem.TabIndex = 29;
			this.groupBox_MultiItem.TabStop = false;
			this.groupBox_MultiItem.Text = "Multi Item Options";
			this.buttonClearAll_Multi.BackColor = global::System.Drawing.Color.Transparent;
			this.buttonClearAll_Multi.ForeColor = global::System.Drawing.Color.Black;
			this.buttonClearAll_Multi.Location = new global::System.Drawing.Point(413, 13);
			this.buttonClearAll_Multi.Name = "buttonClearAll_Multi";
			this.buttonClearAll_Multi.Size = new global::System.Drawing.Size(110, 19);
			this.buttonClearAll_Multi.TabIndex = 49;
			this.buttonClearAll_Multi.Text = "Clear All Options";
			this.buttonClearAll_Multi.UseVisualStyleBackColor = false;
			this.buttonClearAll_Multi.Click += new global::System.EventHandler(this.buttonClearAll_Multi_Click);
			this.tabControl1.Controls.Add(this.tabPage_MultiOption_1);
			this.tabControl1.Controls.Add(this.tabPage_MultiOption_2);
			this.tabControl1.Controls.Add(this.tabPage_MultiOption_3);
			this.tabControl1.Controls.Add(this.tabPage_MultiOption_4);
			this.tabControl1.Controls.Add(this.tabPage_MultiOption_5);
			this.tabControl1.Controls.Add(this.tabPage_MultiOption_6);
			this.tabControl1.Location = new global::System.Drawing.Point(6, 13);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new global::System.Drawing.Size(516, 181);
			this.tabControl1.TabIndex = 28;
			this.tabPage_MultiOption_1.Controls.Add(this.numericUpDown_Durability_Multi_1);
			this.tabPage_MultiOption_1.Controls.Add(this.numericUpDown_Sockets_Multi_1);
			this.tabPage_MultiOption_1.Controls.Add(this.label41);
			this.tabPage_MultiOption_1.Controls.Add(this.comboBox_Ancient_Multi_1);
			this.tabPage_MultiOption_1.Controls.Add(this.label39);
			this.tabPage_MultiOption_1.Controls.Add(this.checkBox_Luck_Multi_1);
			this.tabPage_MultiOption_1.Controls.Add(this.groupBox_1);
			this.tabPage_MultiOption_1.Controls.Add(this.checkBox_Skill_Multi_1);
			this.tabPage_MultiOption_1.Controls.Add(this.listBox_Option_Multi_1);
			this.tabPage_MultiOption_1.Controls.Add(this.textBox_Name_Multi_1);
			this.tabPage_MultiOption_1.Controls.Add(this.label15);
			this.tabPage_MultiOption_1.Controls.Add(this.label11);
			this.tabPage_MultiOption_1.Controls.Add(this.label10);
			this.tabPage_MultiOption_1.Controls.Add(this.label12);
			this.tabPage_MultiOption_1.Controls.Add(this.numericUpDown_Price_Multi_1);
			this.tabPage_MultiOption_1.Controls.Add(this.listBox_Level_Multi_1);
			this.tabPage_MultiOption_1.Controls.Add(this.label9);
			this.tabPage_MultiOption_1.Controls.Add(this.checkBox_isMulti_1);
			this.tabPage_MultiOption_1.Controls.Add(this.numericUpDown_Count_Multi_1);
			this.tabPage_MultiOption_1.Controls.Add(this.label42);
			this.tabPage_MultiOption_1.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage_MultiOption_1.Name = "tabPage_MultiOption_1";
			this.tabPage_MultiOption_1.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage_MultiOption_1.Size = new global::System.Drawing.Size(508, 155);
			this.tabPage_MultiOption_1.TabIndex = 0;
			this.tabPage_MultiOption_1.Text = "Option 1";
			this.tabPage_MultiOption_1.UseVisualStyleBackColor = true;
			this.numericUpDown_Durability_Multi_1.Location = new global::System.Drawing.Point(160, 130);
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.numericUpDown_Durability_Multi_1;
			int[] array = new int[4];
			array[0] = 255;
			numericUpDown.Maximum = new decimal(array);
			this.numericUpDown_Durability_Multi_1.Name = "numericUpDown_Durability_Multi_1";
			this.numericUpDown_Durability_Multi_1.Size = new global::System.Drawing.Size(45, 22);
			this.numericUpDown_Durability_Multi_1.TabIndex = 22;
			global::System.Windows.Forms.NumericUpDown numericUpDown2 = this.numericUpDown_Durability_Multi_1;
			int[] array2 = new int[4];
			array2[0] = 255;
			numericUpDown2.Value = new decimal(array2);
			this.numericUpDown_Sockets_Multi_1.Location = new global::System.Drawing.Point(50, 129);
			global::System.Windows.Forms.NumericUpDown numericUpDown3 = this.numericUpDown_Sockets_Multi_1;
			int[] array3 = new int[4];
			array3[0] = 5;
			numericUpDown3.Maximum = new decimal(array3);
			this.numericUpDown_Sockets_Multi_1.Name = "numericUpDown_Sockets_Multi_1";
			this.numericUpDown_Sockets_Multi_1.Size = new global::System.Drawing.Size(45, 22);
			this.numericUpDown_Sockets_Multi_1.TabIndex = 21;
			this.label41.AutoSize = true;
			this.label41.ForeColor = global::System.Drawing.Color.Black;
			this.label41.Location = new global::System.Drawing.Point(2, 134);
			this.label41.Name = "label41";
			this.label41.Size = new global::System.Drawing.Size(49, 13);
			this.label41.TabIndex = 47;
			this.label41.Text = "Sockets:";
			this.comboBox_Ancient_Multi_1.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_Ancient_Multi_1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.comboBox_Ancient_Multi_1.ForeColor = global::System.Drawing.SystemColors.ActiveCaptionText;
			this.comboBox_Ancient_Multi_1.FormattingEnabled = true;
			this.comboBox_Ancient_Multi_1.Location = new global::System.Drawing.Point(50, 104);
			this.comboBox_Ancient_Multi_1.Name = "comboBox_Ancient_Multi_1";
			this.comboBox_Ancient_Multi_1.Size = new global::System.Drawing.Size(100, 21);
			this.comboBox_Ancient_Multi_1.TabIndex = 20;
			this.label39.AutoSize = true;
			this.label39.ForeColor = global::System.Drawing.Color.Black;
			this.label39.Location = new global::System.Drawing.Point(1, 107);
			this.label39.Name = "label39";
			this.label39.Size = new global::System.Drawing.Size(49, 13);
			this.label39.TabIndex = 46;
			this.label39.Text = "Ancient:";
			this.checkBox_Luck_Multi_1.AutoSize = true;
			this.checkBox_Luck_Multi_1.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox_Luck_Multi_1.ForeColor = global::System.Drawing.Color.Black;
			this.checkBox_Luck_Multi_1.Location = new global::System.Drawing.Point(156, 56);
			this.checkBox_Luck_Multi_1.Name = "checkBox_Luck_Multi_1";
			this.checkBox_Luck_Multi_1.Size = new global::System.Drawing.Size(49, 17);
			this.checkBox_Luck_Multi_1.TabIndex = 45;
			this.checkBox_Luck_Multi_1.Text = "Luck";
			this.checkBox_Luck_Multi_1.UseVisualStyleBackColor = true;
			this.groupBox_1.BackColor = global::System.Drawing.Color.Transparent;
			this.groupBox_1.Controls.Add(this.radioButton_Wings_Multi_1);
			this.groupBox_1.Controls.Add(this.radioButton_Armor_Multi_1);
			this.groupBox_1.Controls.Add(this.radioButton_Weapon_Multi_1);
			this.groupBox_1.Controls.Add(this.checkBox_ExcOption6_Multi_1);
			this.groupBox_1.Controls.Add(this.checkBox_ExcOption5_Multi_1);
			this.groupBox_1.Controls.Add(this.checkBox_ExcOption4_Multi_1);
			this.groupBox_1.Controls.Add(this.checkBox_ExcOption3_Multi_1);
			this.groupBox_1.Controls.Add(this.checkBox_ExcOption2_Multi_1);
			this.groupBox_1.Controls.Add(this.checkBox_ExcOption1_Multi_1);
			this.groupBox_1.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.groupBox_1.ForeColor = global::System.Drawing.Color.Black;
			this.groupBox_1.Location = new global::System.Drawing.Point(302, 6);
			this.groupBox_1.Name = "groupBox_1";
			this.groupBox_1.Size = new global::System.Drawing.Size(200, 148);
			this.groupBox_1.TabIndex = 41;
			this.groupBox_1.TabStop = false;
			this.groupBox_1.Text = "Excellent Options";
			this.radioButton_Wings_Multi_1.AutoSize = true;
			this.radioButton_Wings_Multi_1.Location = new global::System.Drawing.Point(141, 15);
			this.radioButton_Wings_Multi_1.Name = "radioButton_Wings_Multi_1";
			this.radioButton_Wings_Multi_1.Size = new global::System.Drawing.Size(58, 17);
			this.radioButton_Wings_Multi_1.TabIndex = 13;
			this.radioButton_Wings_Multi_1.Text = "Wings";
			this.radioButton_Wings_Multi_1.UseVisualStyleBackColor = true;
			this.radioButton_Wings_Multi_1.CheckedChanged += new global::System.EventHandler(this.radioButton_Multi_ExcWings_CheckedChanged);
			this.radioButton_Armor_Multi_1.AutoSize = true;
			this.radioButton_Armor_Multi_1.Location = new global::System.Drawing.Point(83, 15);
			this.radioButton_Armor_Multi_1.Name = "radioButton_Armor_Multi_1";
			this.radioButton_Armor_Multi_1.Size = new global::System.Drawing.Size(56, 17);
			this.radioButton_Armor_Multi_1.TabIndex = 12;
			this.radioButton_Armor_Multi_1.Text = "Armor";
			this.radioButton_Armor_Multi_1.UseVisualStyleBackColor = true;
			this.radioButton_Armor_Multi_1.CheckedChanged += new global::System.EventHandler(this.radioButton_Multi_ExcArmor_CheckedChanged);
			this.radioButton_Weapon_Multi_1.AutoSize = true;
			this.radioButton_Weapon_Multi_1.Location = new global::System.Drawing.Point(11, 15);
			this.radioButton_Weapon_Multi_1.Name = "radioButton_Weapon_Multi_1";
			this.radioButton_Weapon_Multi_1.Size = new global::System.Drawing.Size(69, 17);
			this.radioButton_Weapon_Multi_1.TabIndex = 11;
			this.radioButton_Weapon_Multi_1.Text = "Weapon";
			this.radioButton_Weapon_Multi_1.UseVisualStyleBackColor = true;
			this.radioButton_Weapon_Multi_1.CheckedChanged += new global::System.EventHandler(this.radioButton_Multi_ExcWeapon_CheckedChanged);
			this.checkBox_ExcOption6_Multi_1.AutoSize = true;
			this.checkBox_ExcOption6_Multi_1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.checkBox_ExcOption6_Multi_1.ForeColor = global::System.Drawing.Color.Black;
			this.checkBox_ExcOption6_Multi_1.Location = new global::System.Drawing.Point(6, 128);
			this.checkBox_ExcOption6_Multi_1.Name = "checkBox_ExcOption6_Multi_1";
			this.checkBox_ExcOption6_Multi_1.Size = new global::System.Drawing.Size(77, 17);
			this.checkBox_ExcOption6_Multi_1.TabIndex = 19;
			this.checkBox_ExcOption6_Multi_1.Text = "checkBox6";
			this.checkBox_ExcOption6_Multi_1.UseVisualStyleBackColor = true;
			this.checkBox_ExcOption5_Multi_1.AutoSize = true;
			this.checkBox_ExcOption5_Multi_1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.checkBox_ExcOption5_Multi_1.ForeColor = global::System.Drawing.Color.Black;
			this.checkBox_ExcOption5_Multi_1.Location = new global::System.Drawing.Point(6, 110);
			this.checkBox_ExcOption5_Multi_1.Name = "checkBox_ExcOption5_Multi_1";
			this.checkBox_ExcOption5_Multi_1.Size = new global::System.Drawing.Size(77, 17);
			this.checkBox_ExcOption5_Multi_1.TabIndex = 18;
			this.checkBox_ExcOption5_Multi_1.Text = "checkBox5";
			this.checkBox_ExcOption5_Multi_1.UseVisualStyleBackColor = true;
			this.checkBox_ExcOption4_Multi_1.AutoSize = true;
			this.checkBox_ExcOption4_Multi_1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.checkBox_ExcOption4_Multi_1.ForeColor = global::System.Drawing.Color.Black;
			this.checkBox_ExcOption4_Multi_1.Location = new global::System.Drawing.Point(6, 91);
			this.checkBox_ExcOption4_Multi_1.Name = "checkBox_ExcOption4_Multi_1";
			this.checkBox_ExcOption4_Multi_1.Size = new global::System.Drawing.Size(77, 17);
			this.checkBox_ExcOption4_Multi_1.TabIndex = 17;
			this.checkBox_ExcOption4_Multi_1.Text = "checkBox4";
			this.checkBox_ExcOption4_Multi_1.UseVisualStyleBackColor = true;
			this.checkBox_ExcOption3_Multi_1.AutoSize = true;
			this.checkBox_ExcOption3_Multi_1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.checkBox_ExcOption3_Multi_1.ForeColor = global::System.Drawing.Color.Black;
			this.checkBox_ExcOption3_Multi_1.Location = new global::System.Drawing.Point(6, 73);
			this.checkBox_ExcOption3_Multi_1.Name = "checkBox_ExcOption3_Multi_1";
			this.checkBox_ExcOption3_Multi_1.Size = new global::System.Drawing.Size(77, 17);
			this.checkBox_ExcOption3_Multi_1.TabIndex = 16;
			this.checkBox_ExcOption3_Multi_1.Text = "checkBox3";
			this.checkBox_ExcOption3_Multi_1.UseVisualStyleBackColor = true;
			this.checkBox_ExcOption2_Multi_1.AutoSize = true;
			this.checkBox_ExcOption2_Multi_1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.checkBox_ExcOption2_Multi_1.ForeColor = global::System.Drawing.Color.Black;
			this.checkBox_ExcOption2_Multi_1.Location = new global::System.Drawing.Point(6, 54);
			this.checkBox_ExcOption2_Multi_1.Name = "checkBox_ExcOption2_Multi_1";
			this.checkBox_ExcOption2_Multi_1.Size = new global::System.Drawing.Size(77, 17);
			this.checkBox_ExcOption2_Multi_1.TabIndex = 15;
			this.checkBox_ExcOption2_Multi_1.Text = "checkBox2";
			this.checkBox_ExcOption2_Multi_1.UseVisualStyleBackColor = true;
			this.checkBox_ExcOption1_Multi_1.AutoSize = true;
			this.checkBox_ExcOption1_Multi_1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.checkBox_ExcOption1_Multi_1.ForeColor = global::System.Drawing.Color.Black;
			this.checkBox_ExcOption1_Multi_1.Location = new global::System.Drawing.Point(6, 36);
			this.checkBox_ExcOption1_Multi_1.Name = "checkBox_ExcOption1_Multi_1";
			this.checkBox_ExcOption1_Multi_1.Size = new global::System.Drawing.Size(77, 17);
			this.checkBox_ExcOption1_Multi_1.TabIndex = 14;
			this.checkBox_ExcOption1_Multi_1.Text = "checkBox1";
			this.checkBox_ExcOption1_Multi_1.UseVisualStyleBackColor = true;
			this.checkBox_Skill_Multi_1.AutoSize = true;
			this.checkBox_Skill_Multi_1.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox_Skill_Multi_1.ForeColor = global::System.Drawing.Color.Black;
			this.checkBox_Skill_Multi_1.Location = new global::System.Drawing.Point(156, 76);
			this.checkBox_Skill_Multi_1.Name = "checkBox_Skill_Multi_1";
			this.checkBox_Skill_Multi_1.Size = new global::System.Drawing.Size(47, 17);
			this.checkBox_Skill_Multi_1.TabIndex = 44;
			this.checkBox_Skill_Multi_1.Text = "Skill";
			this.checkBox_Skill_Multi_1.UseVisualStyleBackColor = true;
			this.listBox_Option_Multi_1.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.listBox_Option_Multi_1.ForeColor = global::System.Drawing.Color.Black;
			this.listBox_Option_Multi_1.FormattingEnabled = true;
			this.listBox_Option_Multi_1.Location = new global::System.Drawing.Point(261, 30);
			this.listBox_Option_Multi_1.Name = "listBox_Option_Multi_1";
			this.listBox_Option_Multi_1.Size = new global::System.Drawing.Size(35, 121);
			this.listBox_Option_Multi_1.TabIndex = 39;
			this.textBox_Name_Multi_1.ForeColor = global::System.Drawing.Color.Black;
			this.textBox_Name_Multi_1.Location = new global::System.Drawing.Point(50, 30);
			this.textBox_Name_Multi_1.Name = "textBox_Name_Multi_1";
			this.textBox_Name_Multi_1.Size = new global::System.Drawing.Size(151, 22);
			this.textBox_Name_Multi_1.TabIndex = 35;
			this.label15.AutoSize = true;
			this.label15.ForeColor = global::System.Drawing.Color.Black;
			this.label15.Location = new global::System.Drawing.Point(4, 35);
			this.label15.Name = "label15";
			this.label15.Size = new global::System.Drawing.Size(36, 13);
			this.label15.TabIndex = 34;
			this.label15.Text = "Name";
			this.label11.AutoSize = true;
			this.label11.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label11.ForeColor = global::System.Drawing.Color.Black;
			this.label11.Location = new global::System.Drawing.Point(204, 9);
			this.label11.Name = "label11";
			this.label11.Size = new global::System.Drawing.Size(32, 13);
			this.label11.TabIndex = 36;
			this.label11.Text = "Level";
			this.label10.AutoSize = true;
			this.label10.ForeColor = global::System.Drawing.Color.Black;
			this.label10.Location = new global::System.Drawing.Point(4, 81);
			this.label10.Name = "label10";
			this.label10.Size = new global::System.Drawing.Size(31, 13);
			this.label10.TabIndex = 33;
			this.label10.Text = "Price";
			this.label12.AutoSize = true;
			this.label12.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label12.ForeColor = global::System.Drawing.Color.Black;
			this.label12.Location = new global::System.Drawing.Point(258, 9);
			this.label12.Name = "label12";
			this.label12.Size = new global::System.Drawing.Size(44, 13);
			this.label12.TabIndex = 37;
			this.label12.Text = "Option";
			this.numericUpDown_Price_Multi_1.ForeColor = global::System.Drawing.Color.Black;
			this.numericUpDown_Price_Multi_1.Location = new global::System.Drawing.Point(50, 78);
			global::System.Windows.Forms.NumericUpDown numericUpDown4 = this.numericUpDown_Price_Multi_1;
			int[] array4 = new int[4];
			array4[0] = 2000000000;
			numericUpDown4.Maximum = new decimal(array4);
			this.numericUpDown_Price_Multi_1.Name = "numericUpDown_Price_Multi_1";
			this.numericUpDown_Price_Multi_1.Size = new global::System.Drawing.Size(100, 22);
			this.numericUpDown_Price_Multi_1.TabIndex = 32;
			this.listBox_Level_Multi_1.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.listBox_Level_Multi_1.ForeColor = global::System.Drawing.Color.Black;
			this.listBox_Level_Multi_1.FormattingEnabled = true;
			this.listBox_Level_Multi_1.Location = new global::System.Drawing.Point(207, 30);
			this.listBox_Level_Multi_1.Name = "listBox_Level_Multi_1";
			this.listBox_Level_Multi_1.Size = new global::System.Drawing.Size(48, 121);
			this.listBox_Level_Multi_1.TabIndex = 38;
			this.label9.AutoSize = true;
			this.label9.ForeColor = global::System.Drawing.Color.Black;
			this.label9.Location = new global::System.Drawing.Point(4, 57);
			this.label9.Name = "label9";
			this.label9.Size = new global::System.Drawing.Size(39, 13);
			this.label9.TabIndex = 31;
			this.label9.Text = "Count";
			this.checkBox_isMulti_1.AutoSize = true;
			this.checkBox_isMulti_1.ForeColor = global::System.Drawing.Color.Black;
			this.checkBox_isMulti_1.Location = new global::System.Drawing.Point(4, 9);
			this.checkBox_isMulti_1.Name = "checkBox_isMulti_1";
			this.checkBox_isMulti_1.Size = new global::System.Drawing.Size(68, 17);
			this.checkBox_isMulti_1.TabIndex = 29;
			this.checkBox_isMulti_1.Text = "Enabled";
			this.checkBox_isMulti_1.UseVisualStyleBackColor = true;
			this.numericUpDown_Count_Multi_1.ForeColor = global::System.Drawing.Color.Black;
			this.numericUpDown_Count_Multi_1.Location = new global::System.Drawing.Point(50, 54);
			global::System.Windows.Forms.NumericUpDown numericUpDown5 = this.numericUpDown_Count_Multi_1;
			int[] array5 = new int[4];
			array5[0] = 999999;
			numericUpDown5.Maximum = new decimal(array5);
			global::System.Windows.Forms.NumericUpDown numericUpDown6 = this.numericUpDown_Count_Multi_1;
			int[] array6 = new int[4];
			array6[0] = 1;
			numericUpDown6.Minimum = new decimal(array6);
			this.numericUpDown_Count_Multi_1.Name = "numericUpDown_Count_Multi_1";
			this.numericUpDown_Count_Multi_1.Size = new global::System.Drawing.Size(100, 22);
			this.numericUpDown_Count_Multi_1.TabIndex = 30;
			global::System.Windows.Forms.NumericUpDown numericUpDown7 = this.numericUpDown_Count_Multi_1;
			int[] array7 = new int[4];
			array7[0] = 1;
			numericUpDown7.Value = new decimal(array7);
			this.label42.AutoSize = true;
			this.label42.ForeColor = global::System.Drawing.Color.Black;
			this.label42.Location = new global::System.Drawing.Point(102, 133);
			this.label42.Name = "label42";
			this.label42.Size = new global::System.Drawing.Size(60, 13);
			this.label42.TabIndex = 48;
			this.label42.Text = "Durability:";
			this.tabPage_MultiOption_2.Controls.Add(this.numericUpDown_Durability_Multi_2);
			this.tabPage_MultiOption_2.Controls.Add(this.numericUpDown_Sockets_Multi_2);
			this.tabPage_MultiOption_2.Controls.Add(this.comboBox_Ancient_Multi_2);
			this.tabPage_MultiOption_2.Controls.Add(this.label43);
			this.tabPage_MultiOption_2.Controls.Add(this.label44);
			this.tabPage_MultiOption_2.Controls.Add(this.label45);
			this.tabPage_MultiOption_2.Controls.Add(this.checkBox_Luck_Multi_2);
			this.tabPage_MultiOption_2.Controls.Add(this.groupBox_2);
			this.tabPage_MultiOption_2.Controls.Add(this.checkBox_Skill_Multi_2);
			this.tabPage_MultiOption_2.Controls.Add(this.listBox_Option_Multi_2);
			this.tabPage_MultiOption_2.Controls.Add(this.textBox_Name_Multi_2);
			this.tabPage_MultiOption_2.Controls.Add(this.label13);
			this.tabPage_MultiOption_2.Controls.Add(this.label14);
			this.tabPage_MultiOption_2.Controls.Add(this.label16);
			this.tabPage_MultiOption_2.Controls.Add(this.label17);
			this.tabPage_MultiOption_2.Controls.Add(this.numericUpDown_Price_Multi_2);
			this.tabPage_MultiOption_2.Controls.Add(this.listBox_Level_Multi_2);
			this.tabPage_MultiOption_2.Controls.Add(this.label18);
			this.tabPage_MultiOption_2.Controls.Add(this.checkBox_isMulti_2);
			this.tabPage_MultiOption_2.Controls.Add(this.numericUpDown_Count_Multi_2);
			this.tabPage_MultiOption_2.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage_MultiOption_2.Name = "tabPage_MultiOption_2";
			this.tabPage_MultiOption_2.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage_MultiOption_2.Size = new global::System.Drawing.Size(508, 155);
			this.tabPage_MultiOption_2.TabIndex = 1;
			this.tabPage_MultiOption_2.Text = "Option 2";
			this.tabPage_MultiOption_2.UseVisualStyleBackColor = true;
			this.numericUpDown_Durability_Multi_2.Location = new global::System.Drawing.Point(160, 130);
			global::System.Windows.Forms.NumericUpDown numericUpDown8 = this.numericUpDown_Durability_Multi_2;
			int[] array8 = new int[4];
			array8[0] = 255;
			numericUpDown8.Maximum = new decimal(array8);
			this.numericUpDown_Durability_Multi_2.Name = "numericUpDown_Durability_Multi_2";
			this.numericUpDown_Durability_Multi_2.Size = new global::System.Drawing.Size(45, 22);
			this.numericUpDown_Durability_Multi_2.TabIndex = 22;
			global::System.Windows.Forms.NumericUpDown numericUpDown9 = this.numericUpDown_Durability_Multi_2;
			int[] array9 = new int[4];
			array9[0] = 255;
			numericUpDown9.Value = new decimal(array9);
			this.numericUpDown_Sockets_Multi_2.Location = new global::System.Drawing.Point(50, 129);
			global::System.Windows.Forms.NumericUpDown numericUpDown10 = this.numericUpDown_Sockets_Multi_2;
			int[] array10 = new int[4];
			array10[0] = 5;
			numericUpDown10.Maximum = new decimal(array10);
			this.numericUpDown_Sockets_Multi_2.Name = "numericUpDown_Sockets_Multi_2";
			this.numericUpDown_Sockets_Multi_2.Size = new global::System.Drawing.Size(45, 22);
			this.numericUpDown_Sockets_Multi_2.TabIndex = 21;
			this.comboBox_Ancient_Multi_2.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_Ancient_Multi_2.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.comboBox_Ancient_Multi_2.ForeColor = global::System.Drawing.SystemColors.ActiveCaptionText;
			this.comboBox_Ancient_Multi_2.FormattingEnabled = true;
			this.comboBox_Ancient_Multi_2.Location = new global::System.Drawing.Point(50, 104);
			this.comboBox_Ancient_Multi_2.Name = "comboBox_Ancient_Multi_2";
			this.comboBox_Ancient_Multi_2.Size = new global::System.Drawing.Size(100, 21);
			this.comboBox_Ancient_Multi_2.TabIndex = 20;
			this.label43.AutoSize = true;
			this.label43.ForeColor = global::System.Drawing.Color.Black;
			this.label43.Location = new global::System.Drawing.Point(102, 133);
			this.label43.Name = "label43";
			this.label43.Size = new global::System.Drawing.Size(60, 13);
			this.label43.TabIndex = 65;
			this.label43.Text = "Durability:";
			this.label44.AutoSize = true;
			this.label44.ForeColor = global::System.Drawing.Color.Black;
			this.label44.Location = new global::System.Drawing.Point(2, 134);
			this.label44.Name = "label44";
			this.label44.Size = new global::System.Drawing.Size(49, 13);
			this.label44.TabIndex = 64;
			this.label44.Text = "Sockets:";
			this.label45.AutoSize = true;
			this.label45.ForeColor = global::System.Drawing.Color.Black;
			this.label45.Location = new global::System.Drawing.Point(1, 107);
			this.label45.Name = "label45";
			this.label45.Size = new global::System.Drawing.Size(49, 13);
			this.label45.TabIndex = 63;
			this.label45.Text = "Ancient:";
			this.checkBox_Luck_Multi_2.AutoSize = true;
			this.checkBox_Luck_Multi_2.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox_Luck_Multi_2.ForeColor = global::System.Drawing.Color.Black;
			this.checkBox_Luck_Multi_2.Location = new global::System.Drawing.Point(156, 56);
			this.checkBox_Luck_Multi_2.Name = "checkBox_Luck_Multi_2";
			this.checkBox_Luck_Multi_2.Size = new global::System.Drawing.Size(49, 17);
			this.checkBox_Luck_Multi_2.TabIndex = 62;
			this.checkBox_Luck_Multi_2.Text = "Luck";
			this.checkBox_Luck_Multi_2.UseVisualStyleBackColor = true;
			this.groupBox_2.BackColor = global::System.Drawing.Color.Transparent;
			this.groupBox_2.Controls.Add(this.radioButton_Wings_Multi_2);
			this.groupBox_2.Controls.Add(this.radioButton_Armor_Multi_2);
			this.groupBox_2.Controls.Add(this.radioButton_Weapon_Multi_2);
			this.groupBox_2.Controls.Add(this.checkBox_ExcOption6_Multi_2);
			this.groupBox_2.Controls.Add(this.checkBox_ExcOption5_Multi_2);
			this.groupBox_2.Controls.Add(this.checkBox_ExcOption4_Multi_2);
			this.groupBox_2.Controls.Add(this.checkBox_ExcOption3_Multi_2);
			this.groupBox_2.Controls.Add(this.checkBox_ExcOption2_Multi_2);
			this.groupBox_2.Controls.Add(this.checkBox_ExcOption1_Multi_2);
			this.groupBox_2.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.groupBox_2.ForeColor = global::System.Drawing.Color.Black;
			this.groupBox_2.Location = new global::System.Drawing.Point(302, 6);
			this.groupBox_2.Name = "groupBox_2";
			this.groupBox_2.Size = new global::System.Drawing.Size(200, 148);
			this.groupBox_2.TabIndex = 58;
			this.groupBox_2.TabStop = false;
			this.groupBox_2.Text = "Excellent Options";
			this.radioButton_Wings_Multi_2.AutoSize = true;
			this.radioButton_Wings_Multi_2.Location = new global::System.Drawing.Point(141, 15);
			this.radioButton_Wings_Multi_2.Name = "radioButton_Wings_Multi_2";
			this.radioButton_Wings_Multi_2.Size = new global::System.Drawing.Size(58, 17);
			this.radioButton_Wings_Multi_2.TabIndex = 13;
			this.radioButton_Wings_Multi_2.Text = "Wings";
			this.radioButton_Wings_Multi_2.UseVisualStyleBackColor = true;
			this.radioButton_Wings_Multi_2.CheckedChanged += new global::System.EventHandler(this.radioButton_Multi_ExcWings_CheckedChanged);
			this.radioButton_Armor_Multi_2.AutoSize = true;
			this.radioButton_Armor_Multi_2.Location = new global::System.Drawing.Point(83, 15);
			this.radioButton_Armor_Multi_2.Name = "radioButton_Armor_Multi_2";
			this.radioButton_Armor_Multi_2.Size = new global::System.Drawing.Size(56, 17);
			this.radioButton_Armor_Multi_2.TabIndex = 12;
			this.radioButton_Armor_Multi_2.Text = "Armor";
			this.radioButton_Armor_Multi_2.UseVisualStyleBackColor = true;
			this.radioButton_Armor_Multi_2.CheckedChanged += new global::System.EventHandler(this.radioButton_Multi_ExcArmor_CheckedChanged);
			this.radioButton_Weapon_Multi_2.AutoSize = true;
			this.radioButton_Weapon_Multi_2.Location = new global::System.Drawing.Point(11, 15);
			this.radioButton_Weapon_Multi_2.Name = "radioButton_Weapon_Multi_2";
			this.radioButton_Weapon_Multi_2.Size = new global::System.Drawing.Size(69, 17);
			this.radioButton_Weapon_Multi_2.TabIndex = 11;
			this.radioButton_Weapon_Multi_2.Text = "Weapon";
			this.radioButton_Weapon_Multi_2.UseVisualStyleBackColor = true;
			this.radioButton_Weapon_Multi_2.CheckedChanged += new global::System.EventHandler(this.radioButton_Multi_ExcWeapon_CheckedChanged);
			this.checkBox_ExcOption6_Multi_2.AutoSize = true;
			this.checkBox_ExcOption6_Multi_2.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.checkBox_ExcOption6_Multi_2.ForeColor = global::System.Drawing.Color.Black;
			this.checkBox_ExcOption6_Multi_2.Location = new global::System.Drawing.Point(6, 128);
			this.checkBox_ExcOption6_Multi_2.Name = "checkBox_ExcOption6_Multi_2";
			this.checkBox_ExcOption6_Multi_2.Size = new global::System.Drawing.Size(77, 17);
			this.checkBox_ExcOption6_Multi_2.TabIndex = 19;
			this.checkBox_ExcOption6_Multi_2.Text = "checkBox6";
			this.checkBox_ExcOption6_Multi_2.UseVisualStyleBackColor = true;
			this.checkBox_ExcOption5_Multi_2.AutoSize = true;
			this.checkBox_ExcOption5_Multi_2.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.checkBox_ExcOption5_Multi_2.ForeColor = global::System.Drawing.Color.Black;
			this.checkBox_ExcOption5_Multi_2.Location = new global::System.Drawing.Point(6, 110);
			this.checkBox_ExcOption5_Multi_2.Name = "checkBox_ExcOption5_Multi_2";
			this.checkBox_ExcOption5_Multi_2.Size = new global::System.Drawing.Size(77, 17);
			this.checkBox_ExcOption5_Multi_2.TabIndex = 18;
			this.checkBox_ExcOption5_Multi_2.Text = "checkBox5";
			this.checkBox_ExcOption5_Multi_2.UseVisualStyleBackColor = true;
			this.checkBox_ExcOption4_Multi_2.AutoSize = true;
			this.checkBox_ExcOption4_Multi_2.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.checkBox_ExcOption4_Multi_2.ForeColor = global::System.Drawing.Color.Black;
			this.checkBox_ExcOption4_Multi_2.Location = new global::System.Drawing.Point(6, 91);
			this.checkBox_ExcOption4_Multi_2.Name = "checkBox_ExcOption4_Multi_2";
			this.checkBox_ExcOption4_Multi_2.Size = new global::System.Drawing.Size(77, 17);
			this.checkBox_ExcOption4_Multi_2.TabIndex = 17;
			this.checkBox_ExcOption4_Multi_2.Text = "checkBox4";
			this.checkBox_ExcOption4_Multi_2.UseVisualStyleBackColor = true;
			this.checkBox_ExcOption3_Multi_2.AutoSize = true;
			this.checkBox_ExcOption3_Multi_2.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.checkBox_ExcOption3_Multi_2.ForeColor = global::System.Drawing.Color.Black;
			this.checkBox_ExcOption3_Multi_2.Location = new global::System.Drawing.Point(6, 73);
			this.checkBox_ExcOption3_Multi_2.Name = "checkBox_ExcOption3_Multi_2";
			this.checkBox_ExcOption3_Multi_2.Size = new global::System.Drawing.Size(77, 17);
			this.checkBox_ExcOption3_Multi_2.TabIndex = 16;
			this.checkBox_ExcOption3_Multi_2.Text = "checkBox3";
			this.checkBox_ExcOption3_Multi_2.UseVisualStyleBackColor = true;
			this.checkBox_ExcOption2_Multi_2.AutoSize = true;
			this.checkBox_ExcOption2_Multi_2.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.checkBox_ExcOption2_Multi_2.ForeColor = global::System.Drawing.Color.Black;
			this.checkBox_ExcOption2_Multi_2.Location = new global::System.Drawing.Point(6, 54);
			this.checkBox_ExcOption2_Multi_2.Name = "checkBox_ExcOption2_Multi_2";
			this.checkBox_ExcOption2_Multi_2.Size = new global::System.Drawing.Size(77, 17);
			this.checkBox_ExcOption2_Multi_2.TabIndex = 15;
			this.checkBox_ExcOption2_Multi_2.Text = "checkBox2";
			this.checkBox_ExcOption2_Multi_2.UseVisualStyleBackColor = true;
			this.checkBox_ExcOption1_Multi_2.AutoSize = true;
			this.checkBox_ExcOption1_Multi_2.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.checkBox_ExcOption1_Multi_2.ForeColor = global::System.Drawing.Color.Black;
			this.checkBox_ExcOption1_Multi_2.Location = new global::System.Drawing.Point(6, 36);
			this.checkBox_ExcOption1_Multi_2.Name = "checkBox_ExcOption1_Multi_2";
			this.checkBox_ExcOption1_Multi_2.Size = new global::System.Drawing.Size(77, 17);
			this.checkBox_ExcOption1_Multi_2.TabIndex = 14;
			this.checkBox_ExcOption1_Multi_2.Text = "checkBox1";
			this.checkBox_ExcOption1_Multi_2.UseVisualStyleBackColor = true;
			this.checkBox_Skill_Multi_2.AutoSize = true;
			this.checkBox_Skill_Multi_2.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox_Skill_Multi_2.ForeColor = global::System.Drawing.Color.Black;
			this.checkBox_Skill_Multi_2.Location = new global::System.Drawing.Point(156, 76);
			this.checkBox_Skill_Multi_2.Name = "checkBox_Skill_Multi_2";
			this.checkBox_Skill_Multi_2.Size = new global::System.Drawing.Size(47, 17);
			this.checkBox_Skill_Multi_2.TabIndex = 61;
			this.checkBox_Skill_Multi_2.Text = "Skill";
			this.checkBox_Skill_Multi_2.UseVisualStyleBackColor = true;
			this.listBox_Option_Multi_2.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.listBox_Option_Multi_2.ForeColor = global::System.Drawing.Color.Black;
			this.listBox_Option_Multi_2.FormattingEnabled = true;
			this.listBox_Option_Multi_2.Location = new global::System.Drawing.Point(261, 30);
			this.listBox_Option_Multi_2.Name = "listBox_Option_Multi_2";
			this.listBox_Option_Multi_2.Size = new global::System.Drawing.Size(35, 121);
			this.listBox_Option_Multi_2.TabIndex = 56;
			this.textBox_Name_Multi_2.ForeColor = global::System.Drawing.Color.Black;
			this.textBox_Name_Multi_2.Location = new global::System.Drawing.Point(50, 30);
			this.textBox_Name_Multi_2.Name = "textBox_Name_Multi_2";
			this.textBox_Name_Multi_2.Size = new global::System.Drawing.Size(151, 22);
			this.textBox_Name_Multi_2.TabIndex = 52;
			this.label13.AutoSize = true;
			this.label13.ForeColor = global::System.Drawing.Color.Black;
			this.label13.Location = new global::System.Drawing.Point(4, 35);
			this.label13.Name = "label13";
			this.label13.Size = new global::System.Drawing.Size(36, 13);
			this.label13.TabIndex = 51;
			this.label13.Text = "Name";
			this.label14.AutoSize = true;
			this.label14.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label14.ForeColor = global::System.Drawing.Color.Black;
			this.label14.Location = new global::System.Drawing.Point(204, 9);
			this.label14.Name = "label14";
			this.label14.Size = new global::System.Drawing.Size(32, 13);
			this.label14.TabIndex = 53;
			this.label14.Text = "Level";
			this.label16.AutoSize = true;
			this.label16.ForeColor = global::System.Drawing.Color.Black;
			this.label16.Location = new global::System.Drawing.Point(4, 81);
			this.label16.Name = "label16";
			this.label16.Size = new global::System.Drawing.Size(31, 13);
			this.label16.TabIndex = 50;
			this.label16.Text = "Price";
			this.label17.AutoSize = true;
			this.label17.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label17.ForeColor = global::System.Drawing.Color.Black;
			this.label17.Location = new global::System.Drawing.Point(258, 9);
			this.label17.Name = "label17";
			this.label17.Size = new global::System.Drawing.Size(44, 13);
			this.label17.TabIndex = 54;
			this.label17.Text = "Option";
			this.numericUpDown_Price_Multi_2.ForeColor = global::System.Drawing.Color.Black;
			this.numericUpDown_Price_Multi_2.Location = new global::System.Drawing.Point(50, 78);
			global::System.Windows.Forms.NumericUpDown numericUpDown11 = this.numericUpDown_Price_Multi_2;
			int[] array11 = new int[4];
			array11[0] = 2000000000;
			numericUpDown11.Maximum = new decimal(array11);
			this.numericUpDown_Price_Multi_2.Name = "numericUpDown_Price_Multi_2";
			this.numericUpDown_Price_Multi_2.Size = new global::System.Drawing.Size(100, 22);
			this.numericUpDown_Price_Multi_2.TabIndex = 49;
			this.listBox_Level_Multi_2.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.listBox_Level_Multi_2.ForeColor = global::System.Drawing.Color.Black;
			this.listBox_Level_Multi_2.FormattingEnabled = true;
			this.listBox_Level_Multi_2.Location = new global::System.Drawing.Point(207, 30);
			this.listBox_Level_Multi_2.Name = "listBox_Level_Multi_2";
			this.listBox_Level_Multi_2.Size = new global::System.Drawing.Size(48, 121);
			this.listBox_Level_Multi_2.TabIndex = 55;
			this.label18.AutoSize = true;
			this.label18.ForeColor = global::System.Drawing.Color.Black;
			this.label18.Location = new global::System.Drawing.Point(4, 57);
			this.label18.Name = "label18";
			this.label18.Size = new global::System.Drawing.Size(39, 13);
			this.label18.TabIndex = 48;
			this.label18.Text = "Count";
			this.checkBox_isMulti_2.AutoSize = true;
			this.checkBox_isMulti_2.ForeColor = global::System.Drawing.Color.Black;
			this.checkBox_isMulti_2.Location = new global::System.Drawing.Point(4, 9);
			this.checkBox_isMulti_2.Name = "checkBox_isMulti_2";
			this.checkBox_isMulti_2.Size = new global::System.Drawing.Size(68, 17);
			this.checkBox_isMulti_2.TabIndex = 46;
			this.checkBox_isMulti_2.Text = "Enabled";
			this.checkBox_isMulti_2.UseVisualStyleBackColor = true;
			this.numericUpDown_Count_Multi_2.ForeColor = global::System.Drawing.Color.Black;
			this.numericUpDown_Count_Multi_2.Location = new global::System.Drawing.Point(50, 54);
			global::System.Windows.Forms.NumericUpDown numericUpDown12 = this.numericUpDown_Count_Multi_2;
			int[] array12 = new int[4];
			array12[0] = 999999;
			numericUpDown12.Maximum = new decimal(array12);
			global::System.Windows.Forms.NumericUpDown numericUpDown13 = this.numericUpDown_Count_Multi_2;
			int[] array13 = new int[4];
			array13[0] = 1;
			numericUpDown13.Minimum = new decimal(array13);
			this.numericUpDown_Count_Multi_2.Name = "numericUpDown_Count_Multi_2";
			this.numericUpDown_Count_Multi_2.Size = new global::System.Drawing.Size(100, 22);
			this.numericUpDown_Count_Multi_2.TabIndex = 47;
			global::System.Windows.Forms.NumericUpDown numericUpDown14 = this.numericUpDown_Count_Multi_2;
			int[] array14 = new int[4];
			array14[0] = 1;
			numericUpDown14.Value = new decimal(array14);
			this.tabPage_MultiOption_3.Controls.Add(this.label48);
			this.tabPage_MultiOption_3.Controls.Add(this.numericUpDown_Durability_Multi_3);
			this.tabPage_MultiOption_3.Controls.Add(this.numericUpDown_Sockets_Multi_3);
			this.tabPage_MultiOption_3.Controls.Add(this.comboBox_Ancient_Multi_3);
			this.tabPage_MultiOption_3.Controls.Add(this.checkBox_Luck_Multi_3);
			this.tabPage_MultiOption_3.Controls.Add(this.groupBox_3);
			this.tabPage_MultiOption_3.Controls.Add(this.checkBox_Skill_Multi_3);
			this.tabPage_MultiOption_3.Controls.Add(this.listBox_Option_Multi_3);
			this.tabPage_MultiOption_3.Controls.Add(this.textBox_Name_Multi_3);
			this.tabPage_MultiOption_3.Controls.Add(this.label19);
			this.tabPage_MultiOption_3.Controls.Add(this.label20);
			this.tabPage_MultiOption_3.Controls.Add(this.label23);
			this.tabPage_MultiOption_3.Controls.Add(this.numericUpDown_Price_Multi_3);
			this.tabPage_MultiOption_3.Controls.Add(this.listBox_Level_Multi_3);
			this.tabPage_MultiOption_3.Controls.Add(this.label40);
			this.tabPage_MultiOption_3.Controls.Add(this.checkBox_isMulti_3);
			this.tabPage_MultiOption_3.Controls.Add(this.numericUpDown_Count_Multi_3);
			this.tabPage_MultiOption_3.Controls.Add(this.label21);
			this.tabPage_MultiOption_3.Controls.Add(this.label46);
			this.tabPage_MultiOption_3.Controls.Add(this.label47);
			this.tabPage_MultiOption_3.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage_MultiOption_3.Name = "tabPage_MultiOption_3";
			this.tabPage_MultiOption_3.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage_MultiOption_3.Size = new global::System.Drawing.Size(508, 155);
			this.tabPage_MultiOption_3.TabIndex = 2;
			this.tabPage_MultiOption_3.Text = "Option 3";
			this.tabPage_MultiOption_3.UseVisualStyleBackColor = true;
			this.label48.AutoSize = true;
			this.label48.ForeColor = global::System.Drawing.Color.Black;
			this.label48.Location = new global::System.Drawing.Point(1, 107);
			this.label48.Name = "label48";
			this.label48.Size = new global::System.Drawing.Size(49, 13);
			this.label48.TabIndex = 63;
			this.label48.Text = "Ancient:";
			this.numericUpDown_Durability_Multi_3.Location = new global::System.Drawing.Point(160, 130);
			global::System.Windows.Forms.NumericUpDown numericUpDown15 = this.numericUpDown_Durability_Multi_3;
			int[] array15 = new int[4];
			array15[0] = 255;
			numericUpDown15.Maximum = new decimal(array15);
			this.numericUpDown_Durability_Multi_3.Name = "numericUpDown_Durability_Multi_3";
			this.numericUpDown_Durability_Multi_3.Size = new global::System.Drawing.Size(45, 22);
			this.numericUpDown_Durability_Multi_3.TabIndex = 22;
			global::System.Windows.Forms.NumericUpDown numericUpDown16 = this.numericUpDown_Durability_Multi_3;
			int[] array16 = new int[4];
			array16[0] = 255;
			numericUpDown16.Value = new decimal(array16);
			this.numericUpDown_Sockets_Multi_3.Location = new global::System.Drawing.Point(50, 129);
			global::System.Windows.Forms.NumericUpDown numericUpDown17 = this.numericUpDown_Sockets_Multi_3;
			int[] array17 = new int[4];
			array17[0] = 5;
			numericUpDown17.Maximum = new decimal(array17);
			this.numericUpDown_Sockets_Multi_3.Name = "numericUpDown_Sockets_Multi_3";
			this.numericUpDown_Sockets_Multi_3.Size = new global::System.Drawing.Size(45, 22);
			this.numericUpDown_Sockets_Multi_3.TabIndex = 21;
			this.comboBox_Ancient_Multi_3.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_Ancient_Multi_3.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.comboBox_Ancient_Multi_3.ForeColor = global::System.Drawing.SystemColors.ActiveCaptionText;
			this.comboBox_Ancient_Multi_3.FormattingEnabled = true;
			this.comboBox_Ancient_Multi_3.Location = new global::System.Drawing.Point(50, 104);
			this.comboBox_Ancient_Multi_3.Name = "comboBox_Ancient_Multi_3";
			this.comboBox_Ancient_Multi_3.Size = new global::System.Drawing.Size(100, 21);
			this.comboBox_Ancient_Multi_3.TabIndex = 20;
			this.checkBox_Luck_Multi_3.AutoSize = true;
			this.checkBox_Luck_Multi_3.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox_Luck_Multi_3.ForeColor = global::System.Drawing.Color.Black;
			this.checkBox_Luck_Multi_3.Location = new global::System.Drawing.Point(156, 56);
			this.checkBox_Luck_Multi_3.Name = "checkBox_Luck_Multi_3";
			this.checkBox_Luck_Multi_3.Size = new global::System.Drawing.Size(49, 17);
			this.checkBox_Luck_Multi_3.TabIndex = 62;
			this.checkBox_Luck_Multi_3.Text = "Luck";
			this.checkBox_Luck_Multi_3.UseVisualStyleBackColor = true;
			this.groupBox_3.BackColor = global::System.Drawing.Color.Transparent;
			this.groupBox_3.Controls.Add(this.radioButton_Wings_Multi_3);
			this.groupBox_3.Controls.Add(this.radioButton_Armor_Multi_3);
			this.groupBox_3.Controls.Add(this.radioButton_Weapon_Multi_3);
			this.groupBox_3.Controls.Add(this.checkBox_ExcOption6_Multi_3);
			this.groupBox_3.Controls.Add(this.checkBox_ExcOption5_Multi_3);
			this.groupBox_3.Controls.Add(this.checkBox_ExcOption4_Multi_3);
			this.groupBox_3.Controls.Add(this.checkBox_ExcOption3_Multi_3);
			this.groupBox_3.Controls.Add(this.checkBox_ExcOption2_Multi_3);
			this.groupBox_3.Controls.Add(this.checkBox_ExcOption1_Multi_3);
			this.groupBox_3.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.groupBox_3.ForeColor = global::System.Drawing.Color.Black;
			this.groupBox_3.Location = new global::System.Drawing.Point(302, 6);
			this.groupBox_3.Name = "groupBox_3";
			this.groupBox_3.Size = new global::System.Drawing.Size(200, 148);
			this.groupBox_3.TabIndex = 58;
			this.groupBox_3.TabStop = false;
			this.groupBox_3.Text = "Excellent Options";
			this.radioButton_Wings_Multi_3.AutoSize = true;
			this.radioButton_Wings_Multi_3.Location = new global::System.Drawing.Point(141, 15);
			this.radioButton_Wings_Multi_3.Name = "radioButton_Wings_Multi_3";
			this.radioButton_Wings_Multi_3.Size = new global::System.Drawing.Size(58, 17);
			this.radioButton_Wings_Multi_3.TabIndex = 13;
			this.radioButton_Wings_Multi_3.Text = "Wings";
			this.radioButton_Wings_Multi_3.UseVisualStyleBackColor = true;
			this.radioButton_Wings_Multi_3.CheckedChanged += new global::System.EventHandler(this.radioButton_Multi_ExcWings_CheckedChanged);
			this.radioButton_Armor_Multi_3.AutoSize = true;
			this.radioButton_Armor_Multi_3.Location = new global::System.Drawing.Point(83, 15);
			this.radioButton_Armor_Multi_3.Name = "radioButton_Armor_Multi_3";
			this.radioButton_Armor_Multi_3.Size = new global::System.Drawing.Size(56, 17);
			this.radioButton_Armor_Multi_3.TabIndex = 12;
			this.radioButton_Armor_Multi_3.Text = "Armor";
			this.radioButton_Armor_Multi_3.UseVisualStyleBackColor = true;
			this.radioButton_Armor_Multi_3.CheckedChanged += new global::System.EventHandler(this.radioButton_Multi_ExcArmor_CheckedChanged);
			this.radioButton_Weapon_Multi_3.AutoSize = true;
			this.radioButton_Weapon_Multi_3.Location = new global::System.Drawing.Point(11, 15);
			this.radioButton_Weapon_Multi_3.Name = "radioButton_Weapon_Multi_3";
			this.radioButton_Weapon_Multi_3.Size = new global::System.Drawing.Size(69, 17);
			this.radioButton_Weapon_Multi_3.TabIndex = 11;
			this.radioButton_Weapon_Multi_3.Text = "Weapon";
			this.radioButton_Weapon_Multi_3.UseVisualStyleBackColor = true;
			this.radioButton_Weapon_Multi_3.CheckedChanged += new global::System.EventHandler(this.radioButton_Multi_ExcWeapon_CheckedChanged);
			this.checkBox_ExcOption6_Multi_3.AutoSize = true;
			this.checkBox_ExcOption6_Multi_3.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.checkBox_ExcOption6_Multi_3.ForeColor = global::System.Drawing.Color.Black;
			this.checkBox_ExcOption6_Multi_3.Location = new global::System.Drawing.Point(6, 128);
			this.checkBox_ExcOption6_Multi_3.Name = "checkBox_ExcOption6_Multi_3";
			this.checkBox_ExcOption6_Multi_3.Size = new global::System.Drawing.Size(77, 17);
			this.checkBox_ExcOption6_Multi_3.TabIndex = 19;
			this.checkBox_ExcOption6_Multi_3.Text = "checkBox6";
			this.checkBox_ExcOption6_Multi_3.UseVisualStyleBackColor = true;
			this.checkBox_ExcOption5_Multi_3.AutoSize = true;
			this.checkBox_ExcOption5_Multi_3.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.checkBox_ExcOption5_Multi_3.ForeColor = global::System.Drawing.Color.Black;
			this.checkBox_ExcOption5_Multi_3.Location = new global::System.Drawing.Point(6, 110);
			this.checkBox_ExcOption5_Multi_3.Name = "checkBox_ExcOption5_Multi_3";
			this.checkBox_ExcOption5_Multi_3.Size = new global::System.Drawing.Size(77, 17);
			this.checkBox_ExcOption5_Multi_3.TabIndex = 18;
			this.checkBox_ExcOption5_Multi_3.Text = "checkBox5";
			this.checkBox_ExcOption5_Multi_3.UseVisualStyleBackColor = true;
			this.checkBox_ExcOption4_Multi_3.AutoSize = true;
			this.checkBox_ExcOption4_Multi_3.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.checkBox_ExcOption4_Multi_3.ForeColor = global::System.Drawing.Color.Black;
			this.checkBox_ExcOption4_Multi_3.Location = new global::System.Drawing.Point(6, 91);
			this.checkBox_ExcOption4_Multi_3.Name = "checkBox_ExcOption4_Multi_3";
			this.checkBox_ExcOption4_Multi_3.Size = new global::System.Drawing.Size(77, 17);
			this.checkBox_ExcOption4_Multi_3.TabIndex = 17;
			this.checkBox_ExcOption4_Multi_3.Text = "checkBox4";
			this.checkBox_ExcOption4_Multi_3.UseVisualStyleBackColor = true;
			this.checkBox_ExcOption3_Multi_3.AutoSize = true;
			this.checkBox_ExcOption3_Multi_3.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.checkBox_ExcOption3_Multi_3.ForeColor = global::System.Drawing.Color.Black;
			this.checkBox_ExcOption3_Multi_3.Location = new global::System.Drawing.Point(6, 73);
			this.checkBox_ExcOption3_Multi_3.Name = "checkBox_ExcOption3_Multi_3";
			this.checkBox_ExcOption3_Multi_3.Size = new global::System.Drawing.Size(77, 17);
			this.checkBox_ExcOption3_Multi_3.TabIndex = 16;
			this.checkBox_ExcOption3_Multi_3.Text = "checkBox3";
			this.checkBox_ExcOption3_Multi_3.UseVisualStyleBackColor = true;
			this.checkBox_ExcOption2_Multi_3.AutoSize = true;
			this.checkBox_ExcOption2_Multi_3.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.checkBox_ExcOption2_Multi_3.ForeColor = global::System.Drawing.Color.Black;
			this.checkBox_ExcOption2_Multi_3.Location = new global::System.Drawing.Point(6, 54);
			this.checkBox_ExcOption2_Multi_3.Name = "checkBox_ExcOption2_Multi_3";
			this.checkBox_ExcOption2_Multi_3.Size = new global::System.Drawing.Size(77, 17);
			this.checkBox_ExcOption2_Multi_3.TabIndex = 15;
			this.checkBox_ExcOption2_Multi_3.Text = "checkBox2";
			this.checkBox_ExcOption2_Multi_3.UseVisualStyleBackColor = true;
			this.checkBox_ExcOption1_Multi_3.AutoSize = true;
			this.checkBox_ExcOption1_Multi_3.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.checkBox_ExcOption1_Multi_3.ForeColor = global::System.Drawing.Color.Black;
			this.checkBox_ExcOption1_Multi_3.Location = new global::System.Drawing.Point(6, 36);
			this.checkBox_ExcOption1_Multi_3.Name = "checkBox_ExcOption1_Multi_3";
			this.checkBox_ExcOption1_Multi_3.Size = new global::System.Drawing.Size(77, 17);
			this.checkBox_ExcOption1_Multi_3.TabIndex = 14;
			this.checkBox_ExcOption1_Multi_3.Text = "checkBox1";
			this.checkBox_ExcOption1_Multi_3.UseVisualStyleBackColor = true;
			this.checkBox_Skill_Multi_3.AutoSize = true;
			this.checkBox_Skill_Multi_3.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox_Skill_Multi_3.ForeColor = global::System.Drawing.Color.Black;
			this.checkBox_Skill_Multi_3.Location = new global::System.Drawing.Point(156, 76);
			this.checkBox_Skill_Multi_3.Name = "checkBox_Skill_Multi_3";
			this.checkBox_Skill_Multi_3.Size = new global::System.Drawing.Size(47, 17);
			this.checkBox_Skill_Multi_3.TabIndex = 61;
			this.checkBox_Skill_Multi_3.Text = "Skill";
			this.checkBox_Skill_Multi_3.UseVisualStyleBackColor = true;
			this.listBox_Option_Multi_3.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.listBox_Option_Multi_3.ForeColor = global::System.Drawing.Color.Black;
			this.listBox_Option_Multi_3.FormattingEnabled = true;
			this.listBox_Option_Multi_3.Location = new global::System.Drawing.Point(261, 30);
			this.listBox_Option_Multi_3.Name = "listBox_Option_Multi_3";
			this.listBox_Option_Multi_3.Size = new global::System.Drawing.Size(35, 121);
			this.listBox_Option_Multi_3.TabIndex = 56;
			this.textBox_Name_Multi_3.ForeColor = global::System.Drawing.Color.Black;
			this.textBox_Name_Multi_3.Location = new global::System.Drawing.Point(50, 30);
			this.textBox_Name_Multi_3.Name = "textBox_Name_Multi_3";
			this.textBox_Name_Multi_3.Size = new global::System.Drawing.Size(151, 22);
			this.textBox_Name_Multi_3.TabIndex = 52;
			this.label19.AutoSize = true;
			this.label19.ForeColor = global::System.Drawing.Color.Black;
			this.label19.Location = new global::System.Drawing.Point(4, 35);
			this.label19.Name = "label19";
			this.label19.Size = new global::System.Drawing.Size(36, 13);
			this.label19.TabIndex = 51;
			this.label19.Text = "Name";
			this.label20.AutoSize = true;
			this.label20.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label20.ForeColor = global::System.Drawing.Color.Black;
			this.label20.Location = new global::System.Drawing.Point(204, 9);
			this.label20.Name = "label20";
			this.label20.Size = new global::System.Drawing.Size(32, 13);
			this.label20.TabIndex = 53;
			this.label20.Text = "Level";
			this.label23.AutoSize = true;
			this.label23.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label23.ForeColor = global::System.Drawing.Color.Black;
			this.label23.Location = new global::System.Drawing.Point(258, 9);
			this.label23.Name = "label23";
			this.label23.Size = new global::System.Drawing.Size(44, 13);
			this.label23.TabIndex = 54;
			this.label23.Text = "Option";
			this.numericUpDown_Price_Multi_3.ForeColor = global::System.Drawing.Color.Black;
			this.numericUpDown_Price_Multi_3.Location = new global::System.Drawing.Point(50, 78);
			global::System.Windows.Forms.NumericUpDown numericUpDown18 = this.numericUpDown_Price_Multi_3;
			int[] array18 = new int[4];
			array18[0] = 2000000000;
			numericUpDown18.Maximum = new decimal(array18);
			this.numericUpDown_Price_Multi_3.Name = "numericUpDown_Price_Multi_3";
			this.numericUpDown_Price_Multi_3.Size = new global::System.Drawing.Size(100, 22);
			this.numericUpDown_Price_Multi_3.TabIndex = 49;
			this.listBox_Level_Multi_3.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.listBox_Level_Multi_3.ForeColor = global::System.Drawing.Color.Black;
			this.listBox_Level_Multi_3.FormattingEnabled = true;
			this.listBox_Level_Multi_3.Location = new global::System.Drawing.Point(207, 30);
			this.listBox_Level_Multi_3.Name = "listBox_Level_Multi_3";
			this.listBox_Level_Multi_3.Size = new global::System.Drawing.Size(48, 121);
			this.listBox_Level_Multi_3.TabIndex = 55;
			this.label40.AutoSize = true;
			this.label40.ForeColor = global::System.Drawing.Color.Black;
			this.label40.Location = new global::System.Drawing.Point(4, 57);
			this.label40.Name = "label40";
			this.label40.Size = new global::System.Drawing.Size(39, 13);
			this.label40.TabIndex = 48;
			this.label40.Text = "Count";
			this.checkBox_isMulti_3.AutoSize = true;
			this.checkBox_isMulti_3.ForeColor = global::System.Drawing.Color.Black;
			this.checkBox_isMulti_3.Location = new global::System.Drawing.Point(4, 9);
			this.checkBox_isMulti_3.Name = "checkBox_isMulti_3";
			this.checkBox_isMulti_3.Size = new global::System.Drawing.Size(68, 17);
			this.checkBox_isMulti_3.TabIndex = 46;
			this.checkBox_isMulti_3.Text = "Enabled";
			this.checkBox_isMulti_3.UseVisualStyleBackColor = true;
			this.numericUpDown_Count_Multi_3.ForeColor = global::System.Drawing.Color.Black;
			this.numericUpDown_Count_Multi_3.Location = new global::System.Drawing.Point(50, 54);
			global::System.Windows.Forms.NumericUpDown numericUpDown19 = this.numericUpDown_Count_Multi_3;
			int[] array19 = new int[4];
			array19[0] = 999999;
			numericUpDown19.Maximum = new decimal(array19);
			global::System.Windows.Forms.NumericUpDown numericUpDown20 = this.numericUpDown_Count_Multi_3;
			int[] array20 = new int[4];
			array20[0] = 1;
			numericUpDown20.Minimum = new decimal(array20);
			this.numericUpDown_Count_Multi_3.Name = "numericUpDown_Count_Multi_3";
			this.numericUpDown_Count_Multi_3.Size = new global::System.Drawing.Size(100, 22);
			this.numericUpDown_Count_Multi_3.TabIndex = 47;
			global::System.Windows.Forms.NumericUpDown numericUpDown21 = this.numericUpDown_Count_Multi_3;
			int[] array21 = new int[4];
			array21[0] = 1;
			numericUpDown21.Value = new decimal(array21);
			this.label21.AutoSize = true;
			this.label21.ForeColor = global::System.Drawing.Color.Black;
			this.label21.Location = new global::System.Drawing.Point(4, 81);
			this.label21.Name = "label21";
			this.label21.Size = new global::System.Drawing.Size(31, 13);
			this.label21.TabIndex = 33;
			this.label21.Text = "Price";
			this.label46.AutoSize = true;
			this.label46.ForeColor = global::System.Drawing.Color.Black;
			this.label46.Location = new global::System.Drawing.Point(102, 133);
			this.label46.Name = "label46";
			this.label46.Size = new global::System.Drawing.Size(60, 13);
			this.label46.TabIndex = 65;
			this.label46.Text = "Durability:";
			this.label47.AutoSize = true;
			this.label47.ForeColor = global::System.Drawing.Color.Black;
			this.label47.Location = new global::System.Drawing.Point(2, 134);
			this.label47.Name = "label47";
			this.label47.Size = new global::System.Drawing.Size(49, 13);
			this.label47.TabIndex = 64;
			this.label47.Text = "Sockets:";
			this.tabPage_MultiOption_4.Controls.Add(this.label51);
			this.tabPage_MultiOption_4.Controls.Add(this.numericUpDown_Durability_Multi_4);
			this.tabPage_MultiOption_4.Controls.Add(this.numericUpDown_Sockets_Multi_4);
			this.tabPage_MultiOption_4.Controls.Add(this.comboBox_Ancient_Multi_4);
			this.tabPage_MultiOption_4.Controls.Add(this.checkBox_Luck_Multi_4);
			this.tabPage_MultiOption_4.Controls.Add(this.groupBox_4);
			this.tabPage_MultiOption_4.Controls.Add(this.checkBox_Skill_Multi_4);
			this.tabPage_MultiOption_4.Controls.Add(this.listBox_Option_Multi_4);
			this.tabPage_MultiOption_4.Controls.Add(this.textBox_Name_Multi_4);
			this.tabPage_MultiOption_4.Controls.Add(this.label22);
			this.tabPage_MultiOption_4.Controls.Add(this.label24);
			this.tabPage_MultiOption_4.Controls.Add(this.label25);
			this.tabPage_MultiOption_4.Controls.Add(this.label26);
			this.tabPage_MultiOption_4.Controls.Add(this.numericUpDown_Price_Multi_4);
			this.tabPage_MultiOption_4.Controls.Add(this.listBox_Level_Multi_4);
			this.tabPage_MultiOption_4.Controls.Add(this.label28);
			this.tabPage_MultiOption_4.Controls.Add(this.checkBox_isMulti_4);
			this.tabPage_MultiOption_4.Controls.Add(this.numericUpDown_Count_Multi_4);
			this.tabPage_MultiOption_4.Controls.Add(this.label50);
			this.tabPage_MultiOption_4.Controls.Add(this.label49);
			this.tabPage_MultiOption_4.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage_MultiOption_4.Name = "tabPage_MultiOption_4";
			this.tabPage_MultiOption_4.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage_MultiOption_4.Size = new global::System.Drawing.Size(508, 155);
			this.tabPage_MultiOption_4.TabIndex = 3;
			this.tabPage_MultiOption_4.Text = "Option 4";
			this.tabPage_MultiOption_4.UseVisualStyleBackColor = true;
			this.label51.AutoSize = true;
			this.label51.ForeColor = global::System.Drawing.Color.Black;
			this.label51.Location = new global::System.Drawing.Point(1, 107);
			this.label51.Name = "label51";
			this.label51.Size = new global::System.Drawing.Size(49, 13);
			this.label51.TabIndex = 66;
			this.label51.Text = "Ancient:";
			this.numericUpDown_Durability_Multi_4.Location = new global::System.Drawing.Point(160, 130);
			global::System.Windows.Forms.NumericUpDown numericUpDown22 = this.numericUpDown_Durability_Multi_4;
			int[] array22 = new int[4];
			array22[0] = 255;
			numericUpDown22.Maximum = new decimal(array22);
			this.numericUpDown_Durability_Multi_4.Name = "numericUpDown_Durability_Multi_4";
			this.numericUpDown_Durability_Multi_4.Size = new global::System.Drawing.Size(45, 22);
			this.numericUpDown_Durability_Multi_4.TabIndex = 22;
			global::System.Windows.Forms.NumericUpDown numericUpDown23 = this.numericUpDown_Durability_Multi_4;
			int[] array23 = new int[4];
			array23[0] = 255;
			numericUpDown23.Value = new decimal(array23);
			this.numericUpDown_Sockets_Multi_4.Location = new global::System.Drawing.Point(50, 129);
			global::System.Windows.Forms.NumericUpDown numericUpDown24 = this.numericUpDown_Sockets_Multi_4;
			int[] array24 = new int[4];
			array24[0] = 5;
			numericUpDown24.Maximum = new decimal(array24);
			this.numericUpDown_Sockets_Multi_4.Name = "numericUpDown_Sockets_Multi_4";
			this.numericUpDown_Sockets_Multi_4.Size = new global::System.Drawing.Size(45, 22);
			this.numericUpDown_Sockets_Multi_4.TabIndex = 21;
			this.comboBox_Ancient_Multi_4.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_Ancient_Multi_4.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.comboBox_Ancient_Multi_4.ForeColor = global::System.Drawing.SystemColors.ActiveCaptionText;
			this.comboBox_Ancient_Multi_4.FormattingEnabled = true;
			this.comboBox_Ancient_Multi_4.Location = new global::System.Drawing.Point(50, 104);
			this.comboBox_Ancient_Multi_4.Name = "comboBox_Ancient_Multi_4";
			this.comboBox_Ancient_Multi_4.Size = new global::System.Drawing.Size(100, 21);
			this.comboBox_Ancient_Multi_4.TabIndex = 20;
			this.checkBox_Luck_Multi_4.AutoSize = true;
			this.checkBox_Luck_Multi_4.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox_Luck_Multi_4.ForeColor = global::System.Drawing.Color.Black;
			this.checkBox_Luck_Multi_4.Location = new global::System.Drawing.Point(156, 56);
			this.checkBox_Luck_Multi_4.Name = "checkBox_Luck_Multi_4";
			this.checkBox_Luck_Multi_4.Size = new global::System.Drawing.Size(49, 17);
			this.checkBox_Luck_Multi_4.TabIndex = 62;
			this.checkBox_Luck_Multi_4.Text = "Luck";
			this.checkBox_Luck_Multi_4.UseVisualStyleBackColor = true;
			this.groupBox_4.BackColor = global::System.Drawing.Color.Transparent;
			this.groupBox_4.Controls.Add(this.radioButton_Wings_Multi_4);
			this.groupBox_4.Controls.Add(this.radioButton_Armor_Multi_4);
			this.groupBox_4.Controls.Add(this.radioButton_Weapon_Multi_4);
			this.groupBox_4.Controls.Add(this.checkBox_ExcOption6_Multi_4);
			this.groupBox_4.Controls.Add(this.checkBox_ExcOption5_Multi_4);
			this.groupBox_4.Controls.Add(this.checkBox_ExcOption4_Multi_4);
			this.groupBox_4.Controls.Add(this.checkBox_ExcOption3_Multi_4);
			this.groupBox_4.Controls.Add(this.checkBox_ExcOption2_Multi_4);
			this.groupBox_4.Controls.Add(this.checkBox_ExcOption1_Multi_4);
			this.groupBox_4.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.groupBox_4.ForeColor = global::System.Drawing.Color.Black;
			this.groupBox_4.Location = new global::System.Drawing.Point(302, 6);
			this.groupBox_4.Name = "groupBox_4";
			this.groupBox_4.Size = new global::System.Drawing.Size(200, 148);
			this.groupBox_4.TabIndex = 58;
			this.groupBox_4.TabStop = false;
			this.groupBox_4.Text = "Excellent Options";
			this.radioButton_Wings_Multi_4.AutoSize = true;
			this.radioButton_Wings_Multi_4.Location = new global::System.Drawing.Point(141, 15);
			this.radioButton_Wings_Multi_4.Name = "radioButton_Wings_Multi_4";
			this.radioButton_Wings_Multi_4.Size = new global::System.Drawing.Size(58, 17);
			this.radioButton_Wings_Multi_4.TabIndex = 13;
			this.radioButton_Wings_Multi_4.Text = "Wings";
			this.radioButton_Wings_Multi_4.UseVisualStyleBackColor = true;
			this.radioButton_Wings_Multi_4.CheckedChanged += new global::System.EventHandler(this.radioButton_Multi_ExcWings_CheckedChanged);
			this.radioButton_Armor_Multi_4.AutoSize = true;
			this.radioButton_Armor_Multi_4.Location = new global::System.Drawing.Point(83, 15);
			this.radioButton_Armor_Multi_4.Name = "radioButton_Armor_Multi_4";
			this.radioButton_Armor_Multi_4.Size = new global::System.Drawing.Size(56, 17);
			this.radioButton_Armor_Multi_4.TabIndex = 12;
			this.radioButton_Armor_Multi_4.Text = "Armor";
			this.radioButton_Armor_Multi_4.UseVisualStyleBackColor = true;
			this.radioButton_Armor_Multi_4.CheckedChanged += new global::System.EventHandler(this.radioButton_Multi_ExcArmor_CheckedChanged);
			this.radioButton_Weapon_Multi_4.AutoSize = true;
			this.radioButton_Weapon_Multi_4.Location = new global::System.Drawing.Point(11, 15);
			this.radioButton_Weapon_Multi_4.Name = "radioButton_Weapon_Multi_4";
			this.radioButton_Weapon_Multi_4.Size = new global::System.Drawing.Size(69, 17);
			this.radioButton_Weapon_Multi_4.TabIndex = 11;
			this.radioButton_Weapon_Multi_4.Text = "Weapon";
			this.radioButton_Weapon_Multi_4.UseVisualStyleBackColor = true;
			this.radioButton_Weapon_Multi_4.CheckedChanged += new global::System.EventHandler(this.radioButton_Multi_ExcWeapon_CheckedChanged);
			this.checkBox_ExcOption6_Multi_4.AutoSize = true;
			this.checkBox_ExcOption6_Multi_4.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.checkBox_ExcOption6_Multi_4.ForeColor = global::System.Drawing.Color.Black;
			this.checkBox_ExcOption6_Multi_4.Location = new global::System.Drawing.Point(6, 128);
			this.checkBox_ExcOption6_Multi_4.Name = "checkBox_ExcOption6_Multi_4";
			this.checkBox_ExcOption6_Multi_4.Size = new global::System.Drawing.Size(77, 17);
			this.checkBox_ExcOption6_Multi_4.TabIndex = 19;
			this.checkBox_ExcOption6_Multi_4.Text = "checkBox6";
			this.checkBox_ExcOption6_Multi_4.UseVisualStyleBackColor = true;
			this.checkBox_ExcOption5_Multi_4.AutoSize = true;
			this.checkBox_ExcOption5_Multi_4.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.checkBox_ExcOption5_Multi_4.ForeColor = global::System.Drawing.Color.Black;
			this.checkBox_ExcOption5_Multi_4.Location = new global::System.Drawing.Point(6, 110);
			this.checkBox_ExcOption5_Multi_4.Name = "checkBox_ExcOption5_Multi_4";
			this.checkBox_ExcOption5_Multi_4.Size = new global::System.Drawing.Size(77, 17);
			this.checkBox_ExcOption5_Multi_4.TabIndex = 18;
			this.checkBox_ExcOption5_Multi_4.Text = "checkBox5";
			this.checkBox_ExcOption5_Multi_4.UseVisualStyleBackColor = true;
			this.checkBox_ExcOption4_Multi_4.AutoSize = true;
			this.checkBox_ExcOption4_Multi_4.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.checkBox_ExcOption4_Multi_4.ForeColor = global::System.Drawing.Color.Black;
			this.checkBox_ExcOption4_Multi_4.Location = new global::System.Drawing.Point(6, 91);
			this.checkBox_ExcOption4_Multi_4.Name = "checkBox_ExcOption4_Multi_4";
			this.checkBox_ExcOption4_Multi_4.Size = new global::System.Drawing.Size(77, 17);
			this.checkBox_ExcOption4_Multi_4.TabIndex = 17;
			this.checkBox_ExcOption4_Multi_4.Text = "checkBox4";
			this.checkBox_ExcOption4_Multi_4.UseVisualStyleBackColor = true;
			this.checkBox_ExcOption3_Multi_4.AutoSize = true;
			this.checkBox_ExcOption3_Multi_4.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.checkBox_ExcOption3_Multi_4.ForeColor = global::System.Drawing.Color.Black;
			this.checkBox_ExcOption3_Multi_4.Location = new global::System.Drawing.Point(6, 73);
			this.checkBox_ExcOption3_Multi_4.Name = "checkBox_ExcOption3_Multi_4";
			this.checkBox_ExcOption3_Multi_4.Size = new global::System.Drawing.Size(77, 17);
			this.checkBox_ExcOption3_Multi_4.TabIndex = 16;
			this.checkBox_ExcOption3_Multi_4.Text = "checkBox3";
			this.checkBox_ExcOption3_Multi_4.UseVisualStyleBackColor = true;
			this.checkBox_ExcOption2_Multi_4.AutoSize = true;
			this.checkBox_ExcOption2_Multi_4.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.checkBox_ExcOption2_Multi_4.ForeColor = global::System.Drawing.Color.Black;
			this.checkBox_ExcOption2_Multi_4.Location = new global::System.Drawing.Point(6, 54);
			this.checkBox_ExcOption2_Multi_4.Name = "checkBox_ExcOption2_Multi_4";
			this.checkBox_ExcOption2_Multi_4.Size = new global::System.Drawing.Size(77, 17);
			this.checkBox_ExcOption2_Multi_4.TabIndex = 15;
			this.checkBox_ExcOption2_Multi_4.Text = "checkBox2";
			this.checkBox_ExcOption2_Multi_4.UseVisualStyleBackColor = true;
			this.checkBox_ExcOption1_Multi_4.AutoSize = true;
			this.checkBox_ExcOption1_Multi_4.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.checkBox_ExcOption1_Multi_4.ForeColor = global::System.Drawing.Color.Black;
			this.checkBox_ExcOption1_Multi_4.Location = new global::System.Drawing.Point(6, 36);
			this.checkBox_ExcOption1_Multi_4.Name = "checkBox_ExcOption1_Multi_4";
			this.checkBox_ExcOption1_Multi_4.Size = new global::System.Drawing.Size(77, 17);
			this.checkBox_ExcOption1_Multi_4.TabIndex = 14;
			this.checkBox_ExcOption1_Multi_4.Text = "checkBox1";
			this.checkBox_ExcOption1_Multi_4.UseVisualStyleBackColor = true;
			this.checkBox_Skill_Multi_4.AutoSize = true;
			this.checkBox_Skill_Multi_4.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox_Skill_Multi_4.ForeColor = global::System.Drawing.Color.Black;
			this.checkBox_Skill_Multi_4.Location = new global::System.Drawing.Point(156, 76);
			this.checkBox_Skill_Multi_4.Name = "checkBox_Skill_Multi_4";
			this.checkBox_Skill_Multi_4.Size = new global::System.Drawing.Size(47, 17);
			this.checkBox_Skill_Multi_4.TabIndex = 61;
			this.checkBox_Skill_Multi_4.Text = "Skill";
			this.checkBox_Skill_Multi_4.UseVisualStyleBackColor = true;
			this.listBox_Option_Multi_4.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.listBox_Option_Multi_4.ForeColor = global::System.Drawing.Color.Black;
			this.listBox_Option_Multi_4.FormattingEnabled = true;
			this.listBox_Option_Multi_4.Location = new global::System.Drawing.Point(261, 30);
			this.listBox_Option_Multi_4.Name = "listBox_Option_Multi_4";
			this.listBox_Option_Multi_4.Size = new global::System.Drawing.Size(35, 121);
			this.listBox_Option_Multi_4.TabIndex = 56;
			this.textBox_Name_Multi_4.ForeColor = global::System.Drawing.Color.Black;
			this.textBox_Name_Multi_4.Location = new global::System.Drawing.Point(50, 30);
			this.textBox_Name_Multi_4.Name = "textBox_Name_Multi_4";
			this.textBox_Name_Multi_4.Size = new global::System.Drawing.Size(151, 22);
			this.textBox_Name_Multi_4.TabIndex = 52;
			this.label22.AutoSize = true;
			this.label22.ForeColor = global::System.Drawing.Color.Black;
			this.label22.Location = new global::System.Drawing.Point(4, 35);
			this.label22.Name = "label22";
			this.label22.Size = new global::System.Drawing.Size(36, 13);
			this.label22.TabIndex = 51;
			this.label22.Text = "Name";
			this.label24.AutoSize = true;
			this.label24.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label24.ForeColor = global::System.Drawing.Color.Black;
			this.label24.Location = new global::System.Drawing.Point(204, 9);
			this.label24.Name = "label24";
			this.label24.Size = new global::System.Drawing.Size(32, 13);
			this.label24.TabIndex = 53;
			this.label24.Text = "Level";
			this.label25.AutoSize = true;
			this.label25.ForeColor = global::System.Drawing.Color.Black;
			this.label25.Location = new global::System.Drawing.Point(4, 81);
			this.label25.Name = "label25";
			this.label25.Size = new global::System.Drawing.Size(31, 13);
			this.label25.TabIndex = 50;
			this.label25.Text = "Price";
			this.label26.AutoSize = true;
			this.label26.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label26.ForeColor = global::System.Drawing.Color.Black;
			this.label26.Location = new global::System.Drawing.Point(258, 9);
			this.label26.Name = "label26";
			this.label26.Size = new global::System.Drawing.Size(44, 13);
			this.label26.TabIndex = 54;
			this.label26.Text = "Option";
			this.numericUpDown_Price_Multi_4.ForeColor = global::System.Drawing.Color.Black;
			this.numericUpDown_Price_Multi_4.Location = new global::System.Drawing.Point(50, 78);
			global::System.Windows.Forms.NumericUpDown numericUpDown25 = this.numericUpDown_Price_Multi_4;
			int[] array25 = new int[4];
			array25[0] = 2000000000;
			numericUpDown25.Maximum = new decimal(array25);
			this.numericUpDown_Price_Multi_4.Name = "numericUpDown_Price_Multi_4";
			this.numericUpDown_Price_Multi_4.Size = new global::System.Drawing.Size(100, 22);
			this.numericUpDown_Price_Multi_4.TabIndex = 49;
			this.listBox_Level_Multi_4.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.listBox_Level_Multi_4.ForeColor = global::System.Drawing.Color.Black;
			this.listBox_Level_Multi_4.FormattingEnabled = true;
			this.listBox_Level_Multi_4.Location = new global::System.Drawing.Point(207, 30);
			this.listBox_Level_Multi_4.Name = "listBox_Level_Multi_4";
			this.listBox_Level_Multi_4.Size = new global::System.Drawing.Size(48, 121);
			this.listBox_Level_Multi_4.TabIndex = 55;
			this.label28.AutoSize = true;
			this.label28.ForeColor = global::System.Drawing.Color.Black;
			this.label28.Location = new global::System.Drawing.Point(4, 57);
			this.label28.Name = "label28";
			this.label28.Size = new global::System.Drawing.Size(39, 13);
			this.label28.TabIndex = 48;
			this.label28.Text = "Count";
			this.checkBox_isMulti_4.AutoSize = true;
			this.checkBox_isMulti_4.ForeColor = global::System.Drawing.Color.Black;
			this.checkBox_isMulti_4.Location = new global::System.Drawing.Point(4, 9);
			this.checkBox_isMulti_4.Name = "checkBox_isMulti_4";
			this.checkBox_isMulti_4.Size = new global::System.Drawing.Size(68, 17);
			this.checkBox_isMulti_4.TabIndex = 46;
			this.checkBox_isMulti_4.Text = "Enabled";
			this.checkBox_isMulti_4.UseVisualStyleBackColor = true;
			this.numericUpDown_Count_Multi_4.ForeColor = global::System.Drawing.Color.Black;
			this.numericUpDown_Count_Multi_4.Location = new global::System.Drawing.Point(50, 54);
			global::System.Windows.Forms.NumericUpDown numericUpDown26 = this.numericUpDown_Count_Multi_4;
			int[] array26 = new int[4];
			array26[0] = 999999;
			numericUpDown26.Maximum = new decimal(array26);
			global::System.Windows.Forms.NumericUpDown numericUpDown27 = this.numericUpDown_Count_Multi_4;
			int[] array27 = new int[4];
			array27[0] = 1;
			numericUpDown27.Minimum = new decimal(array27);
			this.numericUpDown_Count_Multi_4.Name = "numericUpDown_Count_Multi_4";
			this.numericUpDown_Count_Multi_4.Size = new global::System.Drawing.Size(100, 22);
			this.numericUpDown_Count_Multi_4.TabIndex = 47;
			global::System.Windows.Forms.NumericUpDown numericUpDown28 = this.numericUpDown_Count_Multi_4;
			int[] array28 = new int[4];
			array28[0] = 1;
			numericUpDown28.Value = new decimal(array28);
			this.label50.AutoSize = true;
			this.label50.ForeColor = global::System.Drawing.Color.Black;
			this.label50.Location = new global::System.Drawing.Point(2, 134);
			this.label50.Name = "label50";
			this.label50.Size = new global::System.Drawing.Size(49, 13);
			this.label50.TabIndex = 67;
			this.label50.Text = "Sockets:";
			this.label49.AutoSize = true;
			this.label49.ForeColor = global::System.Drawing.Color.Black;
			this.label49.Location = new global::System.Drawing.Point(102, 133);
			this.label49.Name = "label49";
			this.label49.Size = new global::System.Drawing.Size(60, 13);
			this.label49.TabIndex = 68;
			this.label49.Text = "Durability:";
			this.tabPage_MultiOption_5.Controls.Add(this.numericUpDown_Durability_Multi_5);
			this.tabPage_MultiOption_5.Controls.Add(this.label52);
			this.tabPage_MultiOption_5.Controls.Add(this.numericUpDown_Sockets_Multi_5);
			this.tabPage_MultiOption_5.Controls.Add(this.comboBox_Ancient_Multi_5);
			this.tabPage_MultiOption_5.Controls.Add(this.checkBox_Luck_Multi_5);
			this.tabPage_MultiOption_5.Controls.Add(this.groupBox_5);
			this.tabPage_MultiOption_5.Controls.Add(this.checkBox_Skill_Multi_5);
			this.tabPage_MultiOption_5.Controls.Add(this.listBox_Option_Multi_5);
			this.tabPage_MultiOption_5.Controls.Add(this.textBox_Name_Multi_5);
			this.tabPage_MultiOption_5.Controls.Add(this.label29);
			this.tabPage_MultiOption_5.Controls.Add(this.label30);
			this.tabPage_MultiOption_5.Controls.Add(this.label31);
			this.tabPage_MultiOption_5.Controls.Add(this.label32);
			this.tabPage_MultiOption_5.Controls.Add(this.numericUpDown_Price_Multi_5);
			this.tabPage_MultiOption_5.Controls.Add(this.listBox_Level_Multi_5);
			this.tabPage_MultiOption_5.Controls.Add(this.label33);
			this.tabPage_MultiOption_5.Controls.Add(this.checkBox_isMulti_5);
			this.tabPage_MultiOption_5.Controls.Add(this.numericUpDown_Count_Multi_5);
			this.tabPage_MultiOption_5.Controls.Add(this.label54);
			this.tabPage_MultiOption_5.Controls.Add(this.label53);
			this.tabPage_MultiOption_5.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage_MultiOption_5.Name = "tabPage_MultiOption_5";
			this.tabPage_MultiOption_5.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage_MultiOption_5.Size = new global::System.Drawing.Size(508, 155);
			this.tabPage_MultiOption_5.TabIndex = 4;
			this.tabPage_MultiOption_5.Text = "Option 5";
			this.tabPage_MultiOption_5.UseVisualStyleBackColor = true;
			this.numericUpDown_Durability_Multi_5.Location = new global::System.Drawing.Point(160, 130);
			global::System.Windows.Forms.NumericUpDown numericUpDown29 = this.numericUpDown_Durability_Multi_5;
			int[] array29 = new int[4];
			array29[0] = 255;
			numericUpDown29.Maximum = new decimal(array29);
			this.numericUpDown_Durability_Multi_5.Name = "numericUpDown_Durability_Multi_5";
			this.numericUpDown_Durability_Multi_5.Size = new global::System.Drawing.Size(45, 22);
			this.numericUpDown_Durability_Multi_5.TabIndex = 22;
			global::System.Windows.Forms.NumericUpDown numericUpDown30 = this.numericUpDown_Durability_Multi_5;
			int[] array30 = new int[4];
			array30[0] = 255;
			numericUpDown30.Value = new decimal(array30);
			this.label52.AutoSize = true;
			this.label52.ForeColor = global::System.Drawing.Color.Black;
			this.label52.Location = new global::System.Drawing.Point(102, 133);
			this.label52.Name = "label52";
			this.label52.Size = new global::System.Drawing.Size(60, 13);
			this.label52.TabIndex = 68;
			this.label52.Text = "Durability:";
			this.numericUpDown_Sockets_Multi_5.Location = new global::System.Drawing.Point(50, 129);
			global::System.Windows.Forms.NumericUpDown numericUpDown31 = this.numericUpDown_Sockets_Multi_5;
			int[] array31 = new int[4];
			array31[0] = 5;
			numericUpDown31.Maximum = new decimal(array31);
			this.numericUpDown_Sockets_Multi_5.Name = "numericUpDown_Sockets_Multi_5";
			this.numericUpDown_Sockets_Multi_5.Size = new global::System.Drawing.Size(45, 22);
			this.numericUpDown_Sockets_Multi_5.TabIndex = 21;
			this.comboBox_Ancient_Multi_5.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_Ancient_Multi_5.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.comboBox_Ancient_Multi_5.ForeColor = global::System.Drawing.SystemColors.ActiveCaptionText;
			this.comboBox_Ancient_Multi_5.FormattingEnabled = true;
			this.comboBox_Ancient_Multi_5.Location = new global::System.Drawing.Point(50, 104);
			this.comboBox_Ancient_Multi_5.Name = "comboBox_Ancient_Multi_5";
			this.comboBox_Ancient_Multi_5.Size = new global::System.Drawing.Size(100, 21);
			this.comboBox_Ancient_Multi_5.TabIndex = 20;
			this.checkBox_Luck_Multi_5.AutoSize = true;
			this.checkBox_Luck_Multi_5.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox_Luck_Multi_5.ForeColor = global::System.Drawing.Color.Black;
			this.checkBox_Luck_Multi_5.Location = new global::System.Drawing.Point(156, 56);
			this.checkBox_Luck_Multi_5.Name = "checkBox_Luck_Multi_5";
			this.checkBox_Luck_Multi_5.Size = new global::System.Drawing.Size(49, 17);
			this.checkBox_Luck_Multi_5.TabIndex = 62;
			this.checkBox_Luck_Multi_5.Text = "Luck";
			this.checkBox_Luck_Multi_5.UseVisualStyleBackColor = true;
			this.groupBox_5.BackColor = global::System.Drawing.Color.Transparent;
			this.groupBox_5.Controls.Add(this.radioButton_Wings_Multi_5);
			this.groupBox_5.Controls.Add(this.radioButton_Armor_Multi_5);
			this.groupBox_5.Controls.Add(this.radioButton_Weapon_Multi_5);
			this.groupBox_5.Controls.Add(this.checkBox_ExcOption6_Multi_5);
			this.groupBox_5.Controls.Add(this.checkBox_ExcOption5_Multi_5);
			this.groupBox_5.Controls.Add(this.checkBox_ExcOption4_Multi_5);
			this.groupBox_5.Controls.Add(this.checkBox_ExcOption3_Multi_5);
			this.groupBox_5.Controls.Add(this.checkBox_ExcOption2_Multi_5);
			this.groupBox_5.Controls.Add(this.checkBox_ExcOption1_Multi_5);
			this.groupBox_5.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.groupBox_5.ForeColor = global::System.Drawing.Color.Black;
			this.groupBox_5.Location = new global::System.Drawing.Point(302, 6);
			this.groupBox_5.Name = "groupBox_5";
			this.groupBox_5.Size = new global::System.Drawing.Size(200, 148);
			this.groupBox_5.TabIndex = 58;
			this.groupBox_5.TabStop = false;
			this.groupBox_5.Text = "Excellent Options";
			this.radioButton_Wings_Multi_5.AutoSize = true;
			this.radioButton_Wings_Multi_5.Location = new global::System.Drawing.Point(141, 15);
			this.radioButton_Wings_Multi_5.Name = "radioButton_Wings_Multi_5";
			this.radioButton_Wings_Multi_5.Size = new global::System.Drawing.Size(58, 17);
			this.radioButton_Wings_Multi_5.TabIndex = 13;
			this.radioButton_Wings_Multi_5.Text = "Wings";
			this.radioButton_Wings_Multi_5.UseVisualStyleBackColor = true;
			this.radioButton_Wings_Multi_5.CheckedChanged += new global::System.EventHandler(this.radioButton_Multi_ExcWings_CheckedChanged);
			this.radioButton_Armor_Multi_5.AutoSize = true;
			this.radioButton_Armor_Multi_5.Location = new global::System.Drawing.Point(83, 15);
			this.radioButton_Armor_Multi_5.Name = "radioButton_Armor_Multi_5";
			this.radioButton_Armor_Multi_5.Size = new global::System.Drawing.Size(56, 17);
			this.radioButton_Armor_Multi_5.TabIndex = 12;
			this.radioButton_Armor_Multi_5.Text = "Armor";
			this.radioButton_Armor_Multi_5.UseVisualStyleBackColor = true;
			this.radioButton_Armor_Multi_5.CheckedChanged += new global::System.EventHandler(this.radioButton_Multi_ExcArmor_CheckedChanged);
			this.radioButton_Weapon_Multi_5.AutoSize = true;
			this.radioButton_Weapon_Multi_5.Location = new global::System.Drawing.Point(11, 15);
			this.radioButton_Weapon_Multi_5.Name = "radioButton_Weapon_Multi_5";
			this.radioButton_Weapon_Multi_5.Size = new global::System.Drawing.Size(69, 17);
			this.radioButton_Weapon_Multi_5.TabIndex = 11;
			this.radioButton_Weapon_Multi_5.Text = "Weapon";
			this.radioButton_Weapon_Multi_5.UseVisualStyleBackColor = true;
			this.radioButton_Weapon_Multi_5.CheckedChanged += new global::System.EventHandler(this.radioButton_Multi_ExcWeapon_CheckedChanged);
			this.checkBox_ExcOption6_Multi_5.AutoSize = true;
			this.checkBox_ExcOption6_Multi_5.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.checkBox_ExcOption6_Multi_5.ForeColor = global::System.Drawing.Color.Black;
			this.checkBox_ExcOption6_Multi_5.Location = new global::System.Drawing.Point(6, 128);
			this.checkBox_ExcOption6_Multi_5.Name = "checkBox_ExcOption6_Multi_5";
			this.checkBox_ExcOption6_Multi_5.Size = new global::System.Drawing.Size(77, 17);
			this.checkBox_ExcOption6_Multi_5.TabIndex = 19;
			this.checkBox_ExcOption6_Multi_5.Text = "checkBox6";
			this.checkBox_ExcOption6_Multi_5.UseVisualStyleBackColor = true;
			this.checkBox_ExcOption5_Multi_5.AutoSize = true;
			this.checkBox_ExcOption5_Multi_5.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.checkBox_ExcOption5_Multi_5.ForeColor = global::System.Drawing.Color.Black;
			this.checkBox_ExcOption5_Multi_5.Location = new global::System.Drawing.Point(6, 110);
			this.checkBox_ExcOption5_Multi_5.Name = "checkBox_ExcOption5_Multi_5";
			this.checkBox_ExcOption5_Multi_5.Size = new global::System.Drawing.Size(77, 17);
			this.checkBox_ExcOption5_Multi_5.TabIndex = 18;
			this.checkBox_ExcOption5_Multi_5.Text = "checkBox5";
			this.checkBox_ExcOption5_Multi_5.UseVisualStyleBackColor = true;
			this.checkBox_ExcOption4_Multi_5.AutoSize = true;
			this.checkBox_ExcOption4_Multi_5.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.checkBox_ExcOption4_Multi_5.ForeColor = global::System.Drawing.Color.Black;
			this.checkBox_ExcOption4_Multi_5.Location = new global::System.Drawing.Point(6, 91);
			this.checkBox_ExcOption4_Multi_5.Name = "checkBox_ExcOption4_Multi_5";
			this.checkBox_ExcOption4_Multi_5.Size = new global::System.Drawing.Size(77, 17);
			this.checkBox_ExcOption4_Multi_5.TabIndex = 17;
			this.checkBox_ExcOption4_Multi_5.Text = "checkBox4";
			this.checkBox_ExcOption4_Multi_5.UseVisualStyleBackColor = true;
			this.checkBox_ExcOption3_Multi_5.AutoSize = true;
			this.checkBox_ExcOption3_Multi_5.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.checkBox_ExcOption3_Multi_5.ForeColor = global::System.Drawing.Color.Black;
			this.checkBox_ExcOption3_Multi_5.Location = new global::System.Drawing.Point(6, 73);
			this.checkBox_ExcOption3_Multi_5.Name = "checkBox_ExcOption3_Multi_5";
			this.checkBox_ExcOption3_Multi_5.Size = new global::System.Drawing.Size(77, 17);
			this.checkBox_ExcOption3_Multi_5.TabIndex = 16;
			this.checkBox_ExcOption3_Multi_5.Text = "checkBox3";
			this.checkBox_ExcOption3_Multi_5.UseVisualStyleBackColor = true;
			this.checkBox_ExcOption2_Multi_5.AutoSize = true;
			this.checkBox_ExcOption2_Multi_5.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.checkBox_ExcOption2_Multi_5.ForeColor = global::System.Drawing.Color.Black;
			this.checkBox_ExcOption2_Multi_5.Location = new global::System.Drawing.Point(6, 54);
			this.checkBox_ExcOption2_Multi_5.Name = "checkBox_ExcOption2_Multi_5";
			this.checkBox_ExcOption2_Multi_5.Size = new global::System.Drawing.Size(77, 17);
			this.checkBox_ExcOption2_Multi_5.TabIndex = 15;
			this.checkBox_ExcOption2_Multi_5.Text = "checkBox2";
			this.checkBox_ExcOption2_Multi_5.UseVisualStyleBackColor = true;
			this.checkBox_ExcOption1_Multi_5.AutoSize = true;
			this.checkBox_ExcOption1_Multi_5.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.checkBox_ExcOption1_Multi_5.ForeColor = global::System.Drawing.Color.Black;
			this.checkBox_ExcOption1_Multi_5.Location = new global::System.Drawing.Point(6, 36);
			this.checkBox_ExcOption1_Multi_5.Name = "checkBox_ExcOption1_Multi_5";
			this.checkBox_ExcOption1_Multi_5.Size = new global::System.Drawing.Size(77, 17);
			this.checkBox_ExcOption1_Multi_5.TabIndex = 14;
			this.checkBox_ExcOption1_Multi_5.Text = "checkBox1";
			this.checkBox_ExcOption1_Multi_5.UseVisualStyleBackColor = true;
			this.checkBox_Skill_Multi_5.AutoSize = true;
			this.checkBox_Skill_Multi_5.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox_Skill_Multi_5.ForeColor = global::System.Drawing.Color.Black;
			this.checkBox_Skill_Multi_5.Location = new global::System.Drawing.Point(156, 76);
			this.checkBox_Skill_Multi_5.Name = "checkBox_Skill_Multi_5";
			this.checkBox_Skill_Multi_5.Size = new global::System.Drawing.Size(47, 17);
			this.checkBox_Skill_Multi_5.TabIndex = 61;
			this.checkBox_Skill_Multi_5.Text = "Skill";
			this.checkBox_Skill_Multi_5.UseVisualStyleBackColor = true;
			this.listBox_Option_Multi_5.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.listBox_Option_Multi_5.ForeColor = global::System.Drawing.Color.Black;
			this.listBox_Option_Multi_5.FormattingEnabled = true;
			this.listBox_Option_Multi_5.Location = new global::System.Drawing.Point(261, 30);
			this.listBox_Option_Multi_5.Name = "listBox_Option_Multi_5";
			this.listBox_Option_Multi_5.Size = new global::System.Drawing.Size(35, 121);
			this.listBox_Option_Multi_5.TabIndex = 56;
			this.textBox_Name_Multi_5.ForeColor = global::System.Drawing.Color.Black;
			this.textBox_Name_Multi_5.Location = new global::System.Drawing.Point(50, 30);
			this.textBox_Name_Multi_5.Name = "textBox_Name_Multi_5";
			this.textBox_Name_Multi_5.Size = new global::System.Drawing.Size(151, 22);
			this.textBox_Name_Multi_5.TabIndex = 52;
			this.label29.AutoSize = true;
			this.label29.ForeColor = global::System.Drawing.Color.Black;
			this.label29.Location = new global::System.Drawing.Point(4, 35);
			this.label29.Name = "label29";
			this.label29.Size = new global::System.Drawing.Size(36, 13);
			this.label29.TabIndex = 51;
			this.label29.Text = "Name";
			this.label30.AutoSize = true;
			this.label30.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label30.ForeColor = global::System.Drawing.Color.Black;
			this.label30.Location = new global::System.Drawing.Point(204, 9);
			this.label30.Name = "label30";
			this.label30.Size = new global::System.Drawing.Size(32, 13);
			this.label30.TabIndex = 53;
			this.label30.Text = "Level";
			this.label31.AutoSize = true;
			this.label31.ForeColor = global::System.Drawing.Color.Black;
			this.label31.Location = new global::System.Drawing.Point(4, 81);
			this.label31.Name = "label31";
			this.label31.Size = new global::System.Drawing.Size(31, 13);
			this.label31.TabIndex = 50;
			this.label31.Text = "Price";
			this.label32.AutoSize = true;
			this.label32.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label32.ForeColor = global::System.Drawing.Color.Black;
			this.label32.Location = new global::System.Drawing.Point(258, 9);
			this.label32.Name = "label32";
			this.label32.Size = new global::System.Drawing.Size(44, 13);
			this.label32.TabIndex = 54;
			this.label32.Text = "Option";
			this.numericUpDown_Price_Multi_5.ForeColor = global::System.Drawing.Color.Black;
			this.numericUpDown_Price_Multi_5.Location = new global::System.Drawing.Point(50, 78);
			global::System.Windows.Forms.NumericUpDown numericUpDown32 = this.numericUpDown_Price_Multi_5;
			int[] array32 = new int[4];
			array32[0] = 2000000000;
			numericUpDown32.Maximum = new decimal(array32);
			this.numericUpDown_Price_Multi_5.Name = "numericUpDown_Price_Multi_5";
			this.numericUpDown_Price_Multi_5.Size = new global::System.Drawing.Size(100, 22);
			this.numericUpDown_Price_Multi_5.TabIndex = 49;
			this.listBox_Level_Multi_5.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.listBox_Level_Multi_5.ForeColor = global::System.Drawing.Color.Black;
			this.listBox_Level_Multi_5.FormattingEnabled = true;
			this.listBox_Level_Multi_5.Location = new global::System.Drawing.Point(207, 30);
			this.listBox_Level_Multi_5.Name = "listBox_Level_Multi_5";
			this.listBox_Level_Multi_5.Size = new global::System.Drawing.Size(48, 121);
			this.listBox_Level_Multi_5.TabIndex = 55;
			this.label33.AutoSize = true;
			this.label33.ForeColor = global::System.Drawing.Color.Black;
			this.label33.Location = new global::System.Drawing.Point(4, 57);
			this.label33.Name = "label33";
			this.label33.Size = new global::System.Drawing.Size(39, 13);
			this.label33.TabIndex = 48;
			this.label33.Text = "Count";
			this.checkBox_isMulti_5.AutoSize = true;
			this.checkBox_isMulti_5.ForeColor = global::System.Drawing.Color.Black;
			this.checkBox_isMulti_5.Location = new global::System.Drawing.Point(4, 9);
			this.checkBox_isMulti_5.Name = "checkBox_isMulti_5";
			this.checkBox_isMulti_5.Size = new global::System.Drawing.Size(68, 17);
			this.checkBox_isMulti_5.TabIndex = 46;
			this.checkBox_isMulti_5.Text = "Enabled";
			this.checkBox_isMulti_5.UseVisualStyleBackColor = true;
			this.numericUpDown_Count_Multi_5.ForeColor = global::System.Drawing.Color.Black;
			this.numericUpDown_Count_Multi_5.Location = new global::System.Drawing.Point(50, 54);
			global::System.Windows.Forms.NumericUpDown numericUpDown33 = this.numericUpDown_Count_Multi_5;
			int[] array33 = new int[4];
			array33[0] = 999999;
			numericUpDown33.Maximum = new decimal(array33);
			global::System.Windows.Forms.NumericUpDown numericUpDown34 = this.numericUpDown_Count_Multi_5;
			int[] array34 = new int[4];
			array34[0] = 1;
			numericUpDown34.Minimum = new decimal(array34);
			this.numericUpDown_Count_Multi_5.Name = "numericUpDown_Count_Multi_5";
			this.numericUpDown_Count_Multi_5.Size = new global::System.Drawing.Size(100, 22);
			this.numericUpDown_Count_Multi_5.TabIndex = 47;
			global::System.Windows.Forms.NumericUpDown numericUpDown35 = this.numericUpDown_Count_Multi_5;
			int[] array35 = new int[4];
			array35[0] = 1;
			numericUpDown35.Value = new decimal(array35);
			this.label54.AutoSize = true;
			this.label54.ForeColor = global::System.Drawing.Color.Black;
			this.label54.Location = new global::System.Drawing.Point(1, 107);
			this.label54.Name = "label54";
			this.label54.Size = new global::System.Drawing.Size(49, 13);
			this.label54.TabIndex = 66;
			this.label54.Text = "Ancient:";
			this.label53.AutoSize = true;
			this.label53.ForeColor = global::System.Drawing.Color.Black;
			this.label53.Location = new global::System.Drawing.Point(2, 134);
			this.label53.Name = "label53";
			this.label53.Size = new global::System.Drawing.Size(49, 13);
			this.label53.TabIndex = 67;
			this.label53.Text = "Sockets:";
			this.tabPage_MultiOption_6.Controls.Add(this.numericUpDown_Durability_Multi_6);
			this.tabPage_MultiOption_6.Controls.Add(this.label55);
			this.tabPage_MultiOption_6.Controls.Add(this.numericUpDown_Sockets_Multi_6);
			this.tabPage_MultiOption_6.Controls.Add(this.comboBox_Ancient_Multi_6);
			this.tabPage_MultiOption_6.Controls.Add(this.checkBox_Luck_Multi_6);
			this.tabPage_MultiOption_6.Controls.Add(this.groupBox_6);
			this.tabPage_MultiOption_6.Controls.Add(this.checkBox_Skill_Multi_6);
			this.tabPage_MultiOption_6.Controls.Add(this.listBox_Option_Multi_6);
			this.tabPage_MultiOption_6.Controls.Add(this.textBox_Name_Multi_6);
			this.tabPage_MultiOption_6.Controls.Add(this.label34);
			this.tabPage_MultiOption_6.Controls.Add(this.label35);
			this.tabPage_MultiOption_6.Controls.Add(this.label36);
			this.tabPage_MultiOption_6.Controls.Add(this.label37);
			this.tabPage_MultiOption_6.Controls.Add(this.numericUpDown_Price_Multi_6);
			this.tabPage_MultiOption_6.Controls.Add(this.listBox_Level_Multi_6);
			this.tabPage_MultiOption_6.Controls.Add(this.label38);
			this.tabPage_MultiOption_6.Controls.Add(this.checkBox_isMulti_6);
			this.tabPage_MultiOption_6.Controls.Add(this.numericUpDown_Count_Multi_6);
			this.tabPage_MultiOption_6.Controls.Add(this.label57);
			this.tabPage_MultiOption_6.Controls.Add(this.label56);
			this.tabPage_MultiOption_6.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage_MultiOption_6.Name = "tabPage_MultiOption_6";
			this.tabPage_MultiOption_6.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage_MultiOption_6.Size = new global::System.Drawing.Size(508, 155);
			this.tabPage_MultiOption_6.TabIndex = 5;
			this.tabPage_MultiOption_6.Text = "Option 6";
			this.tabPage_MultiOption_6.UseVisualStyleBackColor = true;
			this.numericUpDown_Durability_Multi_6.Location = new global::System.Drawing.Point(160, 130);
			global::System.Windows.Forms.NumericUpDown numericUpDown36 = this.numericUpDown_Durability_Multi_6;
			int[] array36 = new int[4];
			array36[0] = 255;
			numericUpDown36.Maximum = new decimal(array36);
			this.numericUpDown_Durability_Multi_6.Name = "numericUpDown_Durability_Multi_6";
			this.numericUpDown_Durability_Multi_6.Size = new global::System.Drawing.Size(45, 22);
			this.numericUpDown_Durability_Multi_6.TabIndex = 22;
			global::System.Windows.Forms.NumericUpDown numericUpDown37 = this.numericUpDown_Durability_Multi_6;
			int[] array37 = new int[4];
			array37[0] = 255;
			numericUpDown37.Value = new decimal(array37);
			this.label55.AutoSize = true;
			this.label55.ForeColor = global::System.Drawing.Color.Black;
			this.label55.Location = new global::System.Drawing.Point(102, 133);
			this.label55.Name = "label55";
			this.label55.Size = new global::System.Drawing.Size(60, 13);
			this.label55.TabIndex = 68;
			this.label55.Text = "Durability:";
			this.numericUpDown_Sockets_Multi_6.Location = new global::System.Drawing.Point(50, 129);
			global::System.Windows.Forms.NumericUpDown numericUpDown38 = this.numericUpDown_Sockets_Multi_6;
			int[] array38 = new int[4];
			array38[0] = 5;
			numericUpDown38.Maximum = new decimal(array38);
			this.numericUpDown_Sockets_Multi_6.Name = "numericUpDown_Sockets_Multi_6";
			this.numericUpDown_Sockets_Multi_6.Size = new global::System.Drawing.Size(45, 22);
			this.numericUpDown_Sockets_Multi_6.TabIndex = 21;
			this.comboBox_Ancient_Multi_6.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_Ancient_Multi_6.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.comboBox_Ancient_Multi_6.ForeColor = global::System.Drawing.SystemColors.ActiveCaptionText;
			this.comboBox_Ancient_Multi_6.FormattingEnabled = true;
			this.comboBox_Ancient_Multi_6.Location = new global::System.Drawing.Point(50, 104);
			this.comboBox_Ancient_Multi_6.Name = "comboBox_Ancient_Multi_6";
			this.comboBox_Ancient_Multi_6.Size = new global::System.Drawing.Size(100, 21);
			this.comboBox_Ancient_Multi_6.TabIndex = 20;
			this.checkBox_Luck_Multi_6.AutoSize = true;
			this.checkBox_Luck_Multi_6.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox_Luck_Multi_6.ForeColor = global::System.Drawing.Color.Black;
			this.checkBox_Luck_Multi_6.Location = new global::System.Drawing.Point(156, 56);
			this.checkBox_Luck_Multi_6.Name = "checkBox_Luck_Multi_6";
			this.checkBox_Luck_Multi_6.Size = new global::System.Drawing.Size(49, 17);
			this.checkBox_Luck_Multi_6.TabIndex = 62;
			this.checkBox_Luck_Multi_6.Text = "Luck";
			this.checkBox_Luck_Multi_6.UseVisualStyleBackColor = true;
			this.groupBox_6.BackColor = global::System.Drawing.Color.Transparent;
			this.groupBox_6.Controls.Add(this.radioButton_Wings_Multi_6);
			this.groupBox_6.Controls.Add(this.radioButton_Armor_Multi_6);
			this.groupBox_6.Controls.Add(this.radioButton_Weapon_Multi_6);
			this.groupBox_6.Controls.Add(this.checkBox_ExcOption6_Multi_6);
			this.groupBox_6.Controls.Add(this.checkBox_ExcOption5_Multi_6);
			this.groupBox_6.Controls.Add(this.checkBox_ExcOption4_Multi_6);
			this.groupBox_6.Controls.Add(this.checkBox_ExcOption3_Multi_6);
			this.groupBox_6.Controls.Add(this.checkBox_ExcOption2_Multi_6);
			this.groupBox_6.Controls.Add(this.checkBox_ExcOption1_Multi_6);
			this.groupBox_6.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.groupBox_6.ForeColor = global::System.Drawing.Color.Black;
			this.groupBox_6.Location = new global::System.Drawing.Point(302, 6);
			this.groupBox_6.Name = "groupBox_6";
			this.groupBox_6.Size = new global::System.Drawing.Size(200, 148);
			this.groupBox_6.TabIndex = 58;
			this.groupBox_6.TabStop = false;
			this.groupBox_6.Text = "Excellent Options";
			this.radioButton_Wings_Multi_6.AutoSize = true;
			this.radioButton_Wings_Multi_6.Location = new global::System.Drawing.Point(141, 15);
			this.radioButton_Wings_Multi_6.Name = "radioButton_Wings_Multi_6";
			this.radioButton_Wings_Multi_6.Size = new global::System.Drawing.Size(58, 17);
			this.radioButton_Wings_Multi_6.TabIndex = 13;
			this.radioButton_Wings_Multi_6.Text = "Wings";
			this.radioButton_Wings_Multi_6.UseVisualStyleBackColor = true;
			this.radioButton_Wings_Multi_6.CheckedChanged += new global::System.EventHandler(this.radioButton_Multi_ExcWings_CheckedChanged);
			this.radioButton_Armor_Multi_6.AutoSize = true;
			this.radioButton_Armor_Multi_6.Location = new global::System.Drawing.Point(83, 15);
			this.radioButton_Armor_Multi_6.Name = "radioButton_Armor_Multi_6";
			this.radioButton_Armor_Multi_6.Size = new global::System.Drawing.Size(56, 17);
			this.radioButton_Armor_Multi_6.TabIndex = 12;
			this.radioButton_Armor_Multi_6.Text = "Armor";
			this.radioButton_Armor_Multi_6.UseVisualStyleBackColor = true;
			this.radioButton_Armor_Multi_6.CheckedChanged += new global::System.EventHandler(this.radioButton_Multi_ExcArmor_CheckedChanged);
			this.radioButton_Weapon_Multi_6.AutoSize = true;
			this.radioButton_Weapon_Multi_6.Location = new global::System.Drawing.Point(11, 15);
			this.radioButton_Weapon_Multi_6.Name = "radioButton_Weapon_Multi_6";
			this.radioButton_Weapon_Multi_6.Size = new global::System.Drawing.Size(69, 17);
			this.radioButton_Weapon_Multi_6.TabIndex = 11;
			this.radioButton_Weapon_Multi_6.Text = "Weapon";
			this.radioButton_Weapon_Multi_6.UseVisualStyleBackColor = true;
			this.radioButton_Weapon_Multi_6.CheckedChanged += new global::System.EventHandler(this.radioButton_Multi_ExcWeapon_CheckedChanged);
			this.checkBox_ExcOption6_Multi_6.AutoSize = true;
			this.checkBox_ExcOption6_Multi_6.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.checkBox_ExcOption6_Multi_6.ForeColor = global::System.Drawing.Color.Black;
			this.checkBox_ExcOption6_Multi_6.Location = new global::System.Drawing.Point(6, 128);
			this.checkBox_ExcOption6_Multi_6.Name = "checkBox_ExcOption6_Multi_6";
			this.checkBox_ExcOption6_Multi_6.Size = new global::System.Drawing.Size(77, 17);
			this.checkBox_ExcOption6_Multi_6.TabIndex = 19;
			this.checkBox_ExcOption6_Multi_6.Text = "checkBox6";
			this.checkBox_ExcOption6_Multi_6.UseVisualStyleBackColor = true;
			this.checkBox_ExcOption5_Multi_6.AutoSize = true;
			this.checkBox_ExcOption5_Multi_6.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.checkBox_ExcOption5_Multi_6.ForeColor = global::System.Drawing.Color.Black;
			this.checkBox_ExcOption5_Multi_6.Location = new global::System.Drawing.Point(6, 110);
			this.checkBox_ExcOption5_Multi_6.Name = "checkBox_ExcOption5_Multi_6";
			this.checkBox_ExcOption5_Multi_6.Size = new global::System.Drawing.Size(77, 17);
			this.checkBox_ExcOption5_Multi_6.TabIndex = 18;
			this.checkBox_ExcOption5_Multi_6.Text = "checkBox5";
			this.checkBox_ExcOption5_Multi_6.UseVisualStyleBackColor = true;
			this.checkBox_ExcOption4_Multi_6.AutoSize = true;
			this.checkBox_ExcOption4_Multi_6.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.checkBox_ExcOption4_Multi_6.ForeColor = global::System.Drawing.Color.Black;
			this.checkBox_ExcOption4_Multi_6.Location = new global::System.Drawing.Point(6, 91);
			this.checkBox_ExcOption4_Multi_6.Name = "checkBox_ExcOption4_Multi_6";
			this.checkBox_ExcOption4_Multi_6.Size = new global::System.Drawing.Size(77, 17);
			this.checkBox_ExcOption4_Multi_6.TabIndex = 17;
			this.checkBox_ExcOption4_Multi_6.Text = "checkBox4";
			this.checkBox_ExcOption4_Multi_6.UseVisualStyleBackColor = true;
			this.checkBox_ExcOption3_Multi_6.AutoSize = true;
			this.checkBox_ExcOption3_Multi_6.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.checkBox_ExcOption3_Multi_6.ForeColor = global::System.Drawing.Color.Black;
			this.checkBox_ExcOption3_Multi_6.Location = new global::System.Drawing.Point(6, 73);
			this.checkBox_ExcOption3_Multi_6.Name = "checkBox_ExcOption3_Multi_6";
			this.checkBox_ExcOption3_Multi_6.Size = new global::System.Drawing.Size(77, 17);
			this.checkBox_ExcOption3_Multi_6.TabIndex = 16;
			this.checkBox_ExcOption3_Multi_6.Text = "checkBox3";
			this.checkBox_ExcOption3_Multi_6.UseVisualStyleBackColor = true;
			this.checkBox_ExcOption2_Multi_6.AutoSize = true;
			this.checkBox_ExcOption2_Multi_6.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.checkBox_ExcOption2_Multi_6.ForeColor = global::System.Drawing.Color.Black;
			this.checkBox_ExcOption2_Multi_6.Location = new global::System.Drawing.Point(6, 54);
			this.checkBox_ExcOption2_Multi_6.Name = "checkBox_ExcOption2_Multi_6";
			this.checkBox_ExcOption2_Multi_6.Size = new global::System.Drawing.Size(77, 17);
			this.checkBox_ExcOption2_Multi_6.TabIndex = 15;
			this.checkBox_ExcOption2_Multi_6.Text = "checkBox2";
			this.checkBox_ExcOption2_Multi_6.UseVisualStyleBackColor = true;
			this.checkBox_ExcOption1_Multi_6.AutoSize = true;
			this.checkBox_ExcOption1_Multi_6.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.checkBox_ExcOption1_Multi_6.ForeColor = global::System.Drawing.Color.Black;
			this.checkBox_ExcOption1_Multi_6.Location = new global::System.Drawing.Point(6, 36);
			this.checkBox_ExcOption1_Multi_6.Name = "checkBox_ExcOption1_Multi_6";
			this.checkBox_ExcOption1_Multi_6.Size = new global::System.Drawing.Size(77, 17);
			this.checkBox_ExcOption1_Multi_6.TabIndex = 14;
			this.checkBox_ExcOption1_Multi_6.Text = "checkBox1";
			this.checkBox_ExcOption1_Multi_6.UseVisualStyleBackColor = true;
			this.checkBox_Skill_Multi_6.AutoSize = true;
			this.checkBox_Skill_Multi_6.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox_Skill_Multi_6.ForeColor = global::System.Drawing.Color.Black;
			this.checkBox_Skill_Multi_6.Location = new global::System.Drawing.Point(156, 76);
			this.checkBox_Skill_Multi_6.Name = "checkBox_Skill_Multi_6";
			this.checkBox_Skill_Multi_6.Size = new global::System.Drawing.Size(47, 17);
			this.checkBox_Skill_Multi_6.TabIndex = 61;
			this.checkBox_Skill_Multi_6.Text = "Skill";
			this.checkBox_Skill_Multi_6.UseVisualStyleBackColor = true;
			this.listBox_Option_Multi_6.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.listBox_Option_Multi_6.ForeColor = global::System.Drawing.Color.Black;
			this.listBox_Option_Multi_6.FormattingEnabled = true;
			this.listBox_Option_Multi_6.Location = new global::System.Drawing.Point(261, 30);
			this.listBox_Option_Multi_6.Name = "listBox_Option_Multi_6";
			this.listBox_Option_Multi_6.Size = new global::System.Drawing.Size(35, 121);
			this.listBox_Option_Multi_6.TabIndex = 56;
			this.textBox_Name_Multi_6.ForeColor = global::System.Drawing.Color.Black;
			this.textBox_Name_Multi_6.Location = new global::System.Drawing.Point(50, 30);
			this.textBox_Name_Multi_6.Name = "textBox_Name_Multi_6";
			this.textBox_Name_Multi_6.Size = new global::System.Drawing.Size(151, 22);
			this.textBox_Name_Multi_6.TabIndex = 52;
			this.label34.AutoSize = true;
			this.label34.ForeColor = global::System.Drawing.Color.Black;
			this.label34.Location = new global::System.Drawing.Point(4, 35);
			this.label34.Name = "label34";
			this.label34.Size = new global::System.Drawing.Size(36, 13);
			this.label34.TabIndex = 51;
			this.label34.Text = "Name";
			this.label35.AutoSize = true;
			this.label35.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label35.ForeColor = global::System.Drawing.Color.Black;
			this.label35.Location = new global::System.Drawing.Point(204, 9);
			this.label35.Name = "label35";
			this.label35.Size = new global::System.Drawing.Size(32, 13);
			this.label35.TabIndex = 53;
			this.label35.Text = "Level";
			this.label36.AutoSize = true;
			this.label36.ForeColor = global::System.Drawing.Color.Black;
			this.label36.Location = new global::System.Drawing.Point(4, 81);
			this.label36.Name = "label36";
			this.label36.Size = new global::System.Drawing.Size(31, 13);
			this.label36.TabIndex = 50;
			this.label36.Text = "Price";
			this.label37.AutoSize = true;
			this.label37.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label37.ForeColor = global::System.Drawing.Color.Black;
			this.label37.Location = new global::System.Drawing.Point(258, 9);
			this.label37.Name = "label37";
			this.label37.Size = new global::System.Drawing.Size(44, 13);
			this.label37.TabIndex = 54;
			this.label37.Text = "Option";
			this.numericUpDown_Price_Multi_6.ForeColor = global::System.Drawing.Color.Black;
			this.numericUpDown_Price_Multi_6.Location = new global::System.Drawing.Point(50, 78);
			global::System.Windows.Forms.NumericUpDown numericUpDown39 = this.numericUpDown_Price_Multi_6;
			int[] array39 = new int[4];
			array39[0] = 2000000000;
			numericUpDown39.Maximum = new decimal(array39);
			this.numericUpDown_Price_Multi_6.Name = "numericUpDown_Price_Multi_6";
			this.numericUpDown_Price_Multi_6.Size = new global::System.Drawing.Size(100, 22);
			this.numericUpDown_Price_Multi_6.TabIndex = 49;
			this.listBox_Level_Multi_6.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.listBox_Level_Multi_6.ForeColor = global::System.Drawing.Color.Black;
			this.listBox_Level_Multi_6.FormattingEnabled = true;
			this.listBox_Level_Multi_6.Location = new global::System.Drawing.Point(207, 30);
			this.listBox_Level_Multi_6.Name = "listBox_Level_Multi_6";
			this.listBox_Level_Multi_6.Size = new global::System.Drawing.Size(48, 121);
			this.listBox_Level_Multi_6.TabIndex = 55;
			this.label38.AutoSize = true;
			this.label38.ForeColor = global::System.Drawing.Color.Black;
			this.label38.Location = new global::System.Drawing.Point(4, 57);
			this.label38.Name = "label38";
			this.label38.Size = new global::System.Drawing.Size(39, 13);
			this.label38.TabIndex = 48;
			this.label38.Text = "Count";
			this.checkBox_isMulti_6.AutoSize = true;
			this.checkBox_isMulti_6.ForeColor = global::System.Drawing.Color.Black;
			this.checkBox_isMulti_6.Location = new global::System.Drawing.Point(4, 9);
			this.checkBox_isMulti_6.Name = "checkBox_isMulti_6";
			this.checkBox_isMulti_6.Size = new global::System.Drawing.Size(68, 17);
			this.checkBox_isMulti_6.TabIndex = 46;
			this.checkBox_isMulti_6.Text = "Enabled";
			this.checkBox_isMulti_6.UseVisualStyleBackColor = true;
			this.numericUpDown_Count_Multi_6.ForeColor = global::System.Drawing.Color.Black;
			this.numericUpDown_Count_Multi_6.Location = new global::System.Drawing.Point(50, 54);
			global::System.Windows.Forms.NumericUpDown numericUpDown40 = this.numericUpDown_Count_Multi_6;
			int[] array40 = new int[4];
			array40[0] = 999999;
			numericUpDown40.Maximum = new decimal(array40);
			global::System.Windows.Forms.NumericUpDown numericUpDown41 = this.numericUpDown_Count_Multi_6;
			int[] array41 = new int[4];
			array41[0] = 1;
			numericUpDown41.Minimum = new decimal(array41);
			this.numericUpDown_Count_Multi_6.Name = "numericUpDown_Count_Multi_6";
			this.numericUpDown_Count_Multi_6.Size = new global::System.Drawing.Size(100, 22);
			this.numericUpDown_Count_Multi_6.TabIndex = 47;
			global::System.Windows.Forms.NumericUpDown numericUpDown42 = this.numericUpDown_Count_Multi_6;
			int[] array42 = new int[4];
			array42[0] = 1;
			numericUpDown42.Value = new decimal(array42);
			this.label57.AutoSize = true;
			this.label57.ForeColor = global::System.Drawing.Color.Black;
			this.label57.Location = new global::System.Drawing.Point(1, 107);
			this.label57.Name = "label57";
			this.label57.Size = new global::System.Drawing.Size(49, 13);
			this.label57.TabIndex = 66;
			this.label57.Text = "Ancient:";
			this.label56.AutoSize = true;
			this.label56.ForeColor = global::System.Drawing.Color.Black;
			this.label56.Location = new global::System.Drawing.Point(2, 134);
			this.label56.Name = "label56";
			this.label56.Size = new global::System.Drawing.Size(49, 13);
			this.label56.TabIndex = 67;
			this.label56.Text = "Sockets:";
			this.comboBox_NewItem_CountType.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_NewItem_CountType.DropDownWidth = 255;
			this.comboBox_NewItem_CountType.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.comboBox_NewItem_CountType.FormattingEnabled = true;
			this.comboBox_NewItem_CountType.Items.AddRange(new object[]
			{
				"Normal (Quantity)",
				"Expiration Seal/Scroll (Minutes)",
				"Expiration Pet/Item (Minutes)",
				"Character Card",
				"VIP Card (Days)"
			});
			this.comboBox_NewItem_CountType.Location = new global::System.Drawing.Point(171, 120);
			this.comboBox_NewItem_CountType.Name = "comboBox_NewItem_CountType";
			this.comboBox_NewItem_CountType.Size = new global::System.Drawing.Size(123, 21);
			this.comboBox_NewItem_CountType.TabIndex = 6;
			this.numericUpDown_NewItem_Count.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.numericUpDown_NewItem_Count.Location = new global::System.Drawing.Point(57, 120);
			global::System.Windows.Forms.NumericUpDown numericUpDown43 = this.numericUpDown_NewItem_Count;
			int[] array43 = new int[4];
			array43[0] = 99999;
			numericUpDown43.Maximum = new decimal(array43);
			global::System.Windows.Forms.NumericUpDown numericUpDown44 = this.numericUpDown_NewItem_Count;
			int[] array44 = new int[4];
			array44[0] = 1;
			numericUpDown44.Minimum = new decimal(array44);
			this.numericUpDown_NewItem_Count.Name = "numericUpDown_NewItem_Count";
			this.numericUpDown_NewItem_Count.Size = new global::System.Drawing.Size(73, 22);
			this.numericUpDown_NewItem_Count.TabIndex = 5;
			global::System.Windows.Forms.NumericUpDown numericUpDown45 = this.numericUpDown_NewItem_Count;
			int[] array45 = new int[4];
			array45[0] = 1;
			numericUpDown45.Value = new decimal(array45);
			this.comboBox_NewItem_Coin.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_NewItem_Coin.DropDownWidth = 255;
			this.comboBox_NewItem_Coin.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.comboBox_NewItem_Coin.FormattingEnabled = true;
			this.comboBox_NewItem_Coin.Items.AddRange(new object[]
			{
				"W Coin (C)",
				"W Coin (P)",
				"Goblin Point"
			});
			this.comboBox_NewItem_Coin.Location = new global::System.Drawing.Point(57, 146);
			this.comboBox_NewItem_Coin.Name = "comboBox_NewItem_Coin";
			this.comboBox_NewItem_Coin.Size = new global::System.Drawing.Size(98, 21);
			this.comboBox_NewItem_Coin.TabIndex = 4;
			this.numericUpDown_NewItem_Price.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.numericUpDown_NewItem_Price.Location = new global::System.Drawing.Point(201, 145);
			global::System.Windows.Forms.NumericUpDown numericUpDown46 = this.numericUpDown_NewItem_Price;
			int[] array46 = new int[4];
			array46[0] = 2000000000;
			numericUpDown46.Maximum = new decimal(array46);
			this.numericUpDown_NewItem_Price.Name = "numericUpDown_NewItem_Price";
			this.numericUpDown_NewItem_Price.Size = new global::System.Drawing.Size(93, 22);
			this.numericUpDown_NewItem_Price.TabIndex = 3;
			this.textBox_NewItem_Name.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.textBox_NewItem_Name.Location = new global::System.Drawing.Point(57, 21);
			this.textBox_NewItem_Name.Name = "textBox_NewItem_Name";
			this.textBox_NewItem_Name.Size = new global::System.Drawing.Size(237, 22);
			this.textBox_NewItem_Name.TabIndex = 2;
			this.richTextBox_NewItem_Info.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.richTextBox_NewItem_Info.Location = new global::System.Drawing.Point(57, 47);
			this.richTextBox_NewItem_Info.Name = "richTextBox_NewItem_Info";
			this.richTextBox_NewItem_Info.Size = new global::System.Drawing.Size(237, 68);
			this.richTextBox_NewItem_Info.TabIndex = 7;
			this.richTextBox_NewItem_Info.Text = "";
			this.richTextBox_NewItem_Info.WordWrap = false;
			this.label7.AutoSize = true;
			this.label7.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label7.Location = new global::System.Drawing.Point(12, 148);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(34, 13);
			this.label7.TabIndex = 26;
			this.label7.Text = "Coin:";
			this.label6.AutoSize = true;
			this.label6.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label6.Location = new global::System.Drawing.Point(136, 123);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(33, 13);
			this.label6.TabIndex = 25;
			this.label6.Text = "Type:";
			this.label5.AutoSize = true;
			this.label5.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label5.Location = new global::System.Drawing.Point(12, 24);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(39, 13);
			this.label5.TabIndex = 24;
			this.label5.Text = "Name:";
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.Location = new global::System.Drawing.Point(12, 123);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(42, 13);
			this.label2.TabIndex = 23;
			this.label2.Text = "Count:";
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.Location = new global::System.Drawing.Point(161, 148);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(34, 13);
			this.label1.TabIndex = 22;
			this.label1.Text = "Price:";
			this.groupBox_ItemProperties.BackColor = global::System.Drawing.Color.Transparent;
			this.groupBox_ItemProperties.Controls.Add(this.groupBox_NewItem_ExcOpt);
			this.groupBox_ItemProperties.Controls.Add(this.listBox_NewItem_ItemOption);
			this.groupBox_ItemProperties.Controls.Add(this.checkBox_AddItem_FOItem);
			this.groupBox_ItemProperties.Controls.Add(this.checkBox_NewItem_Luck);
			this.groupBox_ItemProperties.Controls.Add(this.groupBox9);
			this.groupBox_ItemProperties.Controls.Add(this.label3);
			this.groupBox_ItemProperties.Controls.Add(this.checkBox_NewItem_Skill);
			this.groupBox_ItemProperties.Controls.Add(this.groupBox8);
			this.groupBox_ItemProperties.Controls.Add(this.label4);
			this.groupBox_ItemProperties.Controls.Add(this.groupBox6);
			this.groupBox_ItemProperties.Controls.Add(this.listBox_NewItem_ItemLevel);
			this.groupBox_ItemProperties.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.groupBox_ItemProperties.ForeColor = global::System.Drawing.Color.Turquoise;
			this.groupBox_ItemProperties.Location = new global::System.Drawing.Point(20, 188);
			this.groupBox_ItemProperties.Name = "groupBox_ItemProperties";
			this.groupBox_ItemProperties.Size = new global::System.Drawing.Size(303, 271);
			this.groupBox_ItemProperties.TabIndex = 20;
			this.groupBox_ItemProperties.TabStop = false;
			this.groupBox_ItemProperties.Text = "Item Properties (Single item ONLY!)";
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
			this.groupBox_NewItem_ExcOpt.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
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
			this.radioButton_NewItem_ExcWings.Size = new global::System.Drawing.Size(58, 17);
			this.radioButton_NewItem_ExcWings.TabIndex = 13;
			this.radioButton_NewItem_ExcWings.Text = "Wings";
			this.radioButton_NewItem_ExcWings.UseVisualStyleBackColor = true;
			this.radioButton_NewItem_ExcWings.CheckedChanged += new global::System.EventHandler(this.radioButton_ExcWings_CheckedChanged);
			this.radioButton_NewItem_ExcArmor.AutoSize = true;
			this.radioButton_NewItem_ExcArmor.Location = new global::System.Drawing.Point(83, 15);
			this.radioButton_NewItem_ExcArmor.Name = "radioButton_NewItem_ExcArmor";
			this.radioButton_NewItem_ExcArmor.Size = new global::System.Drawing.Size(56, 17);
			this.radioButton_NewItem_ExcArmor.TabIndex = 12;
			this.radioButton_NewItem_ExcArmor.Text = "Armor";
			this.radioButton_NewItem_ExcArmor.UseVisualStyleBackColor = true;
			this.radioButton_NewItem_ExcArmor.CheckedChanged += new global::System.EventHandler(this.radioButton_ExcArmor_CheckedChanged);
			this.radioButton_NewItem_ExcWeapon.AutoSize = true;
			this.radioButton_NewItem_ExcWeapon.Location = new global::System.Drawing.Point(11, 15);
			this.radioButton_NewItem_ExcWeapon.Name = "radioButton_NewItem_ExcWeapon";
			this.radioButton_NewItem_ExcWeapon.Size = new global::System.Drawing.Size(69, 17);
			this.radioButton_NewItem_ExcWeapon.TabIndex = 11;
			this.radioButton_NewItem_ExcWeapon.Text = "Weapon";
			this.radioButton_NewItem_ExcWeapon.UseVisualStyleBackColor = true;
			this.radioButton_NewItem_ExcWeapon.CheckedChanged += new global::System.EventHandler(this.radioButton_ExcWeapon_CheckedChanged);
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
			this.listBox_NewItem_ItemOption.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.listBox_NewItem_ItemOption.FormattingEnabled = true;
			this.listBox_NewItem_ItemOption.Location = new global::System.Drawing.Point(52, 38);
			this.listBox_NewItem_ItemOption.Name = "listBox_NewItem_ItemOption";
			this.listBox_NewItem_ItemOption.Size = new global::System.Drawing.Size(35, 134);
			this.listBox_NewItem_ItemOption.TabIndex = 9;
			this.checkBox_AddItem_FOItem.AutoSize = true;
			this.checkBox_AddItem_FOItem.BackColor = global::System.Drawing.Color.Transparent;
			this.checkBox_AddItem_FOItem.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox_AddItem_FOItem.ForeColor = global::System.Drawing.Color.LightSkyBlue;
			this.checkBox_AddItem_FOItem.Location = new global::System.Drawing.Point(53, 184);
			this.checkBox_AddItem_FOItem.Name = "checkBox_AddItem_FOItem";
			this.checkBox_AddItem_FOItem.Size = new global::System.Drawing.Size(131, 17);
			this.checkBox_AddItem_FOItem.TabIndex = 10;
			this.checkBox_AddItem_FOItem.Text = "Exc FO+15+28+Luck";
			this.checkBox_AddItem_FOItem.UseVisualStyleBackColor = false;
			this.checkBox_AddItem_FOItem.CheckedChanged += new global::System.EventHandler(this.checkBox_AddItem_FOItem_CheckedChanged);
			this.checkBox_NewItem_Luck.AutoSize = true;
			this.checkBox_NewItem_Luck.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox_NewItem_Luck.ForeColor = global::System.Drawing.Color.Turquoise;
			this.checkBox_NewItem_Luck.Location = new global::System.Drawing.Point(240, 245);
			this.checkBox_NewItem_Luck.Name = "checkBox_NewItem_Luck";
			this.checkBox_NewItem_Luck.Size = new global::System.Drawing.Size(49, 17);
			this.checkBox_NewItem_Luck.TabIndex = 24;
			this.checkBox_NewItem_Luck.Text = "Luck";
			this.checkBox_NewItem_Luck.UseVisualStyleBackColor = true;
			this.groupBox9.Controls.Add(this.comboBox_Ancient);
			this.groupBox9.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.groupBox9.ForeColor = global::System.Drawing.Color.SpringGreen;
			this.groupBox9.Location = new global::System.Drawing.Point(185, 171);
			this.groupBox9.Name = "groupBox9";
			this.groupBox9.Size = new global::System.Drawing.Size(105, 46);
			this.groupBox9.TabIndex = 14;
			this.groupBox9.TabStop = false;
			this.groupBox9.Text = "Ancient ";
			this.comboBox_Ancient.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_Ancient.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 177);
			this.comboBox_Ancient.ForeColor = global::System.Drawing.SystemColors.ActiveCaptionText;
			this.comboBox_Ancient.FormattingEnabled = true;
			this.comboBox_Ancient.Location = new global::System.Drawing.Point(6, 18);
			this.comboBox_Ancient.Name = "comboBox_Ancient";
			this.comboBox_Ancient.Size = new global::System.Drawing.Size(94, 21);
			this.comboBox_Ancient.TabIndex = 20;
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::System.Drawing.Color.Turquoise;
			this.label3.Location = new global::System.Drawing.Point(8, 18);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(32, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Level";
			this.checkBox_NewItem_Skill.AutoSize = true;
			this.checkBox_NewItem_Skill.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox_NewItem_Skill.ForeColor = global::System.Drawing.Color.Turquoise;
			this.checkBox_NewItem_Skill.Location = new global::System.Drawing.Point(240, 224);
			this.checkBox_NewItem_Skill.Name = "checkBox_NewItem_Skill";
			this.checkBox_NewItem_Skill.Size = new global::System.Drawing.Size(47, 17);
			this.checkBox_NewItem_Skill.TabIndex = 23;
			this.checkBox_NewItem_Skill.Text = "Skill";
			this.checkBox_NewItem_Skill.UseVisualStyleBackColor = true;
			this.groupBox8.BackColor = global::System.Drawing.Color.Transparent;
			this.groupBox8.Controls.Add(this.numericUpDown_NewItem_SocketCount);
			this.groupBox8.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.groupBox8.ForeColor = global::System.Drawing.Color.BlueViolet;
			this.groupBox8.Location = new global::System.Drawing.Point(58, 222);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new global::System.Drawing.Size(95, 43);
			this.groupBox8.TabIndex = 12;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "Empty Sockets";
			this.numericUpDown_NewItem_SocketCount.Location = new global::System.Drawing.Point(25, 16);
			global::System.Windows.Forms.NumericUpDown numericUpDown47 = this.numericUpDown_NewItem_SocketCount;
			int[] array47 = new int[4];
			array47[0] = 5;
			numericUpDown47.Maximum = new decimal(array47);
			this.numericUpDown_NewItem_SocketCount.Name = "numericUpDown_NewItem_SocketCount";
			this.numericUpDown_NewItem_SocketCount.Size = new global::System.Drawing.Size(45, 22);
			this.numericUpDown_NewItem_SocketCount.TabIndex = 21;
			this.label4.AutoSize = true;
			this.label4.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label4.ForeColor = global::System.Drawing.Color.Turquoise;
			this.label4.Location = new global::System.Drawing.Point(49, 18);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(44, 13);
			this.label4.TabIndex = 3;
			this.label4.Text = "Option";
			this.groupBox6.Controls.Add(this.numericUpDown_NewItem_Durability);
			this.groupBox6.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.groupBox6.ForeColor = global::System.Drawing.Color.DarkKhaki;
			this.groupBox6.Location = new global::System.Drawing.Point(157, 222);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new global::System.Drawing.Size(72, 43);
			this.groupBox6.TabIndex = 10;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Duration";
			this.numericUpDown_NewItem_Durability.Location = new global::System.Drawing.Point(14, 16);
			global::System.Windows.Forms.NumericUpDown numericUpDown48 = this.numericUpDown_NewItem_Durability;
			int[] array48 = new int[4];
			array48[0] = 255;
			numericUpDown48.Maximum = new decimal(array48);
			this.numericUpDown_NewItem_Durability.Name = "numericUpDown_NewItem_Durability";
			this.numericUpDown_NewItem_Durability.Size = new global::System.Drawing.Size(45, 22);
			this.numericUpDown_NewItem_Durability.TabIndex = 22;
			global::System.Windows.Forms.NumericUpDown numericUpDown49 = this.numericUpDown_NewItem_Durability;
			int[] array49 = new int[4];
			array49[0] = 255;
			numericUpDown49.Value = new decimal(array49);
			this.listBox_NewItem_ItemLevel.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.listBox_NewItem_ItemLevel.FormattingEnabled = true;
			this.listBox_NewItem_ItemLevel.Location = new global::System.Drawing.Point(11, 38);
			this.listBox_NewItem_ItemLevel.Name = "listBox_NewItem_ItemLevel";
			this.listBox_NewItem_ItemLevel.Size = new global::System.Drawing.Size(35, 186);
			this.listBox_NewItem_ItemLevel.TabIndex = 8;
			this.button_NewItem_Add.Location = new global::System.Drawing.Point(700, 427);
			this.button_NewItem_Add.Name = "button_NewItem_Add";
			this.button_NewItem_Add.Size = new global::System.Drawing.Size(190, 32);
			this.button_NewItem_Add.TabIndex = 25;
			this.button_NewItem_Add.Text = "Add to [Shop]\r\nCtrl + F";
			this.button_NewItem_Add.UseVisualStyleBackColor = true;
			this.button_NewItem_Add.Click += new global::System.EventHandler(this.button_NewItem_Add_Click);
			this.pictureBox_NewItem_ItemPreview.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBox_NewItem_ItemPreview.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox_NewItem_ItemPreview.Location = new global::System.Drawing.Point(20, 104);
			this.pictureBox_NewItem_ItemPreview.Name = "pictureBox_NewItem_ItemPreview";
			this.pictureBox_NewItem_ItemPreview.Size = new global::System.Drawing.Size(129, 79);
			this.pictureBox_NewItem_ItemPreview.TabIndex = 3;
			this.pictureBox_NewItem_ItemPreview.TabStop = false;
			this.listBox_NewItem_ItemIndex.FormattingEnabled = true;
			this.listBox_NewItem_ItemIndex.Location = new global::System.Drawing.Point(155, 23);
			this.listBox_NewItem_ItemIndex.Name = "listBox_NewItem_ItemIndex";
			this.listBox_NewItem_ItemIndex.Size = new global::System.Drawing.Size(168, 160);
			this.listBox_NewItem_ItemIndex.TabIndex = 1;
			this.listBox_NewItem_ItemIndex.SelectedIndexChanged += new global::System.EventHandler(this.listBox_NewItem_ItemIndex_SelectedIndexChanged);
			this.listBox_NewItem_ItemGroup.FormattingEnabled = true;
			this.listBox_NewItem_ItemGroup.Location = new global::System.Drawing.Point(20, 23);
			this.listBox_NewItem_ItemGroup.Name = "listBox_NewItem_ItemGroup";
			this.listBox_NewItem_ItemGroup.Size = new global::System.Drawing.Size(129, 69);
			this.listBox_NewItem_ItemGroup.TabIndex = 0;
			this.listBox_NewItem_ItemGroup.SelectedIndexChanged += new global::System.EventHandler(this.listBox_NewItem_ItemGroup_SelectedIndexChanged);
			this.textBox_Info.BackColor = global::System.Drawing.Color.DimGray;
			this.textBox_Info.ForeColor = global::System.Drawing.SystemColors.Info;
			this.textBox_Info.Location = new global::System.Drawing.Point(-2, 476);
			this.textBox_Info.Name = "textBox_Info";
			this.textBox_Info.ReadOnly = true;
			this.textBox_Info.Size = new global::System.Drawing.Size(915, 21);
			this.textBox_Info.TabIndex = 4;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(911, 493);
			base.Controls.Add(this.panel_ItemAdd);
			base.Controls.Add(this.textBox_Info);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.KeyPreview = true;
			base.MaximizeBox = false;
			base.Name = "Form_CashShop_AddItems";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Cash Shop Item Adder";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.Form_CashShop_AddItems_FormClosing);
			base.Load += new global::System.EventHandler(this.Form_CashShop_AddItems_Load);
			base.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.Form_CashShop_AddItems_KeyDown);
			this.panel_ItemAdd.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox_PackageItem.ResumeLayout(false);
			this.groupBox_PackageItem.PerformLayout();
			this.groupBox_MultiItem.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage_MultiOption_1.ResumeLayout(false);
			this.tabPage_MultiOption_1.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Durability_Multi_1).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Sockets_Multi_1).EndInit();
			this.groupBox_1.ResumeLayout(false);
			this.groupBox_1.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Price_Multi_1).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Count_Multi_1).EndInit();
			this.tabPage_MultiOption_2.ResumeLayout(false);
			this.tabPage_MultiOption_2.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Durability_Multi_2).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Sockets_Multi_2).EndInit();
			this.groupBox_2.ResumeLayout(false);
			this.groupBox_2.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Price_Multi_2).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Count_Multi_2).EndInit();
			this.tabPage_MultiOption_3.ResumeLayout(false);
			this.tabPage_MultiOption_3.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Durability_Multi_3).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Sockets_Multi_3).EndInit();
			this.groupBox_3.ResumeLayout(false);
			this.groupBox_3.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Price_Multi_3).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Count_Multi_3).EndInit();
			this.tabPage_MultiOption_4.ResumeLayout(false);
			this.tabPage_MultiOption_4.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Durability_Multi_4).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Sockets_Multi_4).EndInit();
			this.groupBox_4.ResumeLayout(false);
			this.groupBox_4.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Price_Multi_4).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Count_Multi_4).EndInit();
			this.tabPage_MultiOption_5.ResumeLayout(false);
			this.tabPage_MultiOption_5.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Durability_Multi_5).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Sockets_Multi_5).EndInit();
			this.groupBox_5.ResumeLayout(false);
			this.groupBox_5.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Price_Multi_5).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Count_Multi_5).EndInit();
			this.tabPage_MultiOption_6.ResumeLayout(false);
			this.tabPage_MultiOption_6.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Durability_Multi_6).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Sockets_Multi_6).EndInit();
			this.groupBox_6.ResumeLayout(false);
			this.groupBox_6.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Price_Multi_6).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_Count_Multi_6).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_NewItem_Count).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_NewItem_Price).EndInit();
			this.groupBox_ItemProperties.ResumeLayout(false);
			this.groupBox_ItemProperties.PerformLayout();
			this.groupBox_NewItem_ExcOpt.ResumeLayout(false);
			this.groupBox_NewItem_ExcOpt.PerformLayout();
			this.groupBox9.ResumeLayout(false);
			this.groupBox8.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_NewItem_SocketCount).EndInit();
			this.groupBox6.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.numericUpDown_NewItem_Durability).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox_NewItem_ItemPreview).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400041D RID: 1053
		public global::System.Windows.Forms.Button button_AddItemToDB;

		// Token: 0x0400041E RID: 1054
		public global::System.Windows.Forms.Button button_NewItem_Add;

		// Token: 0x0400041F RID: 1055
		private global::System.Windows.Forms.Button button_PackageItem_AddToList;

		// Token: 0x04000420 RID: 1056
		private global::System.Windows.Forms.Button button_PackageItem_RemoveFromList;

		// Token: 0x04000421 RID: 1057
		public global::System.Windows.Forms.Button button_UpdateExistingItem;

		// Token: 0x04000422 RID: 1058
		private global::System.Windows.Forms.Button buttonClearAll_Multi;

		// Token: 0x04000438 RID: 1080
		private global::System.Windows.Forms.CheckBox checkBox_AddItem_FOItem;

		// Token: 0x04000439 RID: 1081
		public global::System.Windows.Forms.CheckBox checkBox_ExcOption1_Multi_1;

		// Token: 0x0400043A RID: 1082
		public global::System.Windows.Forms.CheckBox checkBox_ExcOption1_Multi_2;

		// Token: 0x0400043B RID: 1083
		public global::System.Windows.Forms.CheckBox checkBox_ExcOption1_Multi_3;

		// Token: 0x0400043C RID: 1084
		public global::System.Windows.Forms.CheckBox checkBox_ExcOption1_Multi_4;

		// Token: 0x0400043D RID: 1085
		public global::System.Windows.Forms.CheckBox checkBox_ExcOption1_Multi_5;

		// Token: 0x0400043E RID: 1086
		public global::System.Windows.Forms.CheckBox checkBox_ExcOption1_Multi_6;

		// Token: 0x0400043F RID: 1087
		public global::System.Windows.Forms.CheckBox checkBox_ExcOption2_Multi_1;

		// Token: 0x04000440 RID: 1088
		public global::System.Windows.Forms.CheckBox checkBox_ExcOption2_Multi_2;

		// Token: 0x04000441 RID: 1089
		public global::System.Windows.Forms.CheckBox checkBox_ExcOption2_Multi_3;

		// Token: 0x04000442 RID: 1090
		public global::System.Windows.Forms.CheckBox checkBox_ExcOption2_Multi_4;

		// Token: 0x04000443 RID: 1091
		public global::System.Windows.Forms.CheckBox checkBox_ExcOption2_Multi_5;

		// Token: 0x04000444 RID: 1092
		public global::System.Windows.Forms.CheckBox checkBox_ExcOption2_Multi_6;

		// Token: 0x04000445 RID: 1093
		public global::System.Windows.Forms.CheckBox checkBox_ExcOption3_Multi_1;

		// Token: 0x04000446 RID: 1094
		public global::System.Windows.Forms.CheckBox checkBox_ExcOption3_Multi_2;

		// Token: 0x04000447 RID: 1095
		public global::System.Windows.Forms.CheckBox checkBox_ExcOption3_Multi_3;

		// Token: 0x04000448 RID: 1096
		public global::System.Windows.Forms.CheckBox checkBox_ExcOption3_Multi_4;

		// Token: 0x04000449 RID: 1097
		public global::System.Windows.Forms.CheckBox checkBox_ExcOption3_Multi_5;

		// Token: 0x0400044A RID: 1098
		public global::System.Windows.Forms.CheckBox checkBox_ExcOption3_Multi_6;

		// Token: 0x0400044B RID: 1099
		public global::System.Windows.Forms.CheckBox checkBox_ExcOption4_Multi_1;

		// Token: 0x0400044C RID: 1100
		public global::System.Windows.Forms.CheckBox checkBox_ExcOption4_Multi_2;

		// Token: 0x0400044D RID: 1101
		public global::System.Windows.Forms.CheckBox checkBox_ExcOption4_Multi_3;

		// Token: 0x0400044E RID: 1102
		public global::System.Windows.Forms.CheckBox checkBox_ExcOption4_Multi_4;

		// Token: 0x0400044F RID: 1103
		public global::System.Windows.Forms.CheckBox checkBox_ExcOption4_Multi_5;

		// Token: 0x04000450 RID: 1104
		public global::System.Windows.Forms.CheckBox checkBox_ExcOption4_Multi_6;

		// Token: 0x04000451 RID: 1105
		public global::System.Windows.Forms.CheckBox checkBox_ExcOption5_Multi_1;

		// Token: 0x04000452 RID: 1106
		public global::System.Windows.Forms.CheckBox checkBox_ExcOption5_Multi_2;

		// Token: 0x04000453 RID: 1107
		public global::System.Windows.Forms.CheckBox checkBox_ExcOption5_Multi_3;

		// Token: 0x04000454 RID: 1108
		public global::System.Windows.Forms.CheckBox checkBox_ExcOption5_Multi_4;

		// Token: 0x04000455 RID: 1109
		public global::System.Windows.Forms.CheckBox checkBox_ExcOption5_Multi_5;

		// Token: 0x04000456 RID: 1110
		public global::System.Windows.Forms.CheckBox checkBox_ExcOption5_Multi_6;

		// Token: 0x04000457 RID: 1111
		public global::System.Windows.Forms.CheckBox checkBox_ExcOption6_Multi_1;

		// Token: 0x04000458 RID: 1112
		public global::System.Windows.Forms.CheckBox checkBox_ExcOption6_Multi_2;

		// Token: 0x04000459 RID: 1113
		public global::System.Windows.Forms.CheckBox checkBox_ExcOption6_Multi_3;

		// Token: 0x0400045A RID: 1114
		public global::System.Windows.Forms.CheckBox checkBox_ExcOption6_Multi_4;

		// Token: 0x0400045B RID: 1115
		public global::System.Windows.Forms.CheckBox checkBox_ExcOption6_Multi_5;

		// Token: 0x0400045C RID: 1116
		public global::System.Windows.Forms.CheckBox checkBox_ExcOption6_Multi_6;

		// Token: 0x0400045D RID: 1117
		private global::System.Windows.Forms.CheckBox checkBox_isMulti_1;

		// Token: 0x0400045E RID: 1118
		private global::System.Windows.Forms.CheckBox checkBox_isMulti_2;

		// Token: 0x0400045F RID: 1119
		private global::System.Windows.Forms.CheckBox checkBox_isMulti_3;

		// Token: 0x04000460 RID: 1120
		private global::System.Windows.Forms.CheckBox checkBox_isMulti_4;

		// Token: 0x04000461 RID: 1121
		private global::System.Windows.Forms.CheckBox checkBox_isMulti_5;

		// Token: 0x04000462 RID: 1122
		private global::System.Windows.Forms.CheckBox checkBox_isMulti_6;

		// Token: 0x04000463 RID: 1123
		public global::System.Windows.Forms.CheckBox checkBox_Luck_Multi_1;

		// Token: 0x04000464 RID: 1124
		public global::System.Windows.Forms.CheckBox checkBox_Luck_Multi_2;

		// Token: 0x04000465 RID: 1125
		public global::System.Windows.Forms.CheckBox checkBox_Luck_Multi_3;

		// Token: 0x04000466 RID: 1126
		public global::System.Windows.Forms.CheckBox checkBox_Luck_Multi_4;

		// Token: 0x04000467 RID: 1127
		public global::System.Windows.Forms.CheckBox checkBox_Luck_Multi_5;

		// Token: 0x04000468 RID: 1128
		public global::System.Windows.Forms.CheckBox checkBox_Luck_Multi_6;

		// Token: 0x04000469 RID: 1129
		private global::System.Windows.Forms.CheckBox checkBox_MultiItem;

		// Token: 0x0400046A RID: 1130
		public global::System.Windows.Forms.CheckBox checkBox_NewItem_ExcOpt1;

		// Token: 0x0400046B RID: 1131
		public global::System.Windows.Forms.CheckBox checkBox_NewItem_ExcOpt2;

		// Token: 0x0400046C RID: 1132
		public global::System.Windows.Forms.CheckBox checkBox_NewItem_ExcOpt3;

		// Token: 0x0400046D RID: 1133
		public global::System.Windows.Forms.CheckBox checkBox_NewItem_ExcOpt4;

		// Token: 0x0400046E RID: 1134
		public global::System.Windows.Forms.CheckBox checkBox_NewItem_ExcOpt5;

		// Token: 0x0400046F RID: 1135
		public global::System.Windows.Forms.CheckBox checkBox_NewItem_ExcOpt6;

		// Token: 0x04000470 RID: 1136
		public global::System.Windows.Forms.CheckBox checkBox_NewItem_Luck;

		// Token: 0x04000471 RID: 1137
		public global::System.Windows.Forms.CheckBox checkBox_NewItem_Skill;

		// Token: 0x04000472 RID: 1138
		private global::System.Windows.Forms.CheckBox checkBox_PackageItem;

		// Token: 0x04000473 RID: 1139
		public global::System.Windows.Forms.CheckBox checkBox_Skill_Multi_1;

		// Token: 0x04000474 RID: 1140
		public global::System.Windows.Forms.CheckBox checkBox_Skill_Multi_2;

		// Token: 0x04000475 RID: 1141
		public global::System.Windows.Forms.CheckBox checkBox_Skill_Multi_3;

		// Token: 0x04000476 RID: 1142
		public global::System.Windows.Forms.CheckBox checkBox_Skill_Multi_4;

		// Token: 0x04000477 RID: 1143
		public global::System.Windows.Forms.CheckBox checkBox_Skill_Multi_5;

		// Token: 0x04000478 RID: 1144
		public global::System.Windows.Forms.CheckBox checkBox_Skill_Multi_6;

		// Token: 0x04000479 RID: 1145
		public global::System.Windows.Forms.ComboBox comboBox_Ancient;

		// Token: 0x0400047A RID: 1146
		public global::System.Windows.Forms.ComboBox comboBox_Ancient_Multi_1;

		// Token: 0x0400047B RID: 1147
		public global::System.Windows.Forms.ComboBox comboBox_Ancient_Multi_2;

		// Token: 0x0400047C RID: 1148
		public global::System.Windows.Forms.ComboBox comboBox_Ancient_Multi_3;

		// Token: 0x0400047D RID: 1149
		public global::System.Windows.Forms.ComboBox comboBox_Ancient_Multi_4;

		// Token: 0x0400047E RID: 1150
		public global::System.Windows.Forms.ComboBox comboBox_Ancient_Multi_5;

		// Token: 0x0400047F RID: 1151
		public global::System.Windows.Forms.ComboBox comboBox_Ancient_Multi_6;

		// Token: 0x04000480 RID: 1152
		private global::System.Windows.Forms.ComboBox comboBox_NewItem_Coin;

		// Token: 0x04000481 RID: 1153
		private global::System.Windows.Forms.ComboBox comboBox_NewItem_CountType;

		// Token: 0x04000482 RID: 1154
		private global::System.Windows.Forms.ComboBox comboBox_PackageItem_ItemsDatabase;

		// Token: 0x04000483 RID: 1155
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000487 RID: 1159
		private global::System.Windows.Forms.GroupBox groupBox_1;

		// Token: 0x04000488 RID: 1160
		private global::System.Windows.Forms.GroupBox groupBox_2;

		// Token: 0x04000489 RID: 1161
		private global::System.Windows.Forms.GroupBox groupBox_3;

		// Token: 0x0400048A RID: 1162
		private global::System.Windows.Forms.GroupBox groupBox_4;

		// Token: 0x0400048B RID: 1163
		private global::System.Windows.Forms.GroupBox groupBox_5;

		// Token: 0x0400048C RID: 1164
		private global::System.Windows.Forms.GroupBox groupBox_6;

		// Token: 0x0400048D RID: 1165
		private global::System.Windows.Forms.GroupBox groupBox_ItemProperties;

		// Token: 0x0400048E RID: 1166
		private global::System.Windows.Forms.GroupBox groupBox_MultiItem;

		// Token: 0x0400048F RID: 1167
		private global::System.Windows.Forms.GroupBox groupBox_NewItem_ExcOpt;

		// Token: 0x04000490 RID: 1168
		private global::System.Windows.Forms.GroupBox groupBox_PackageItem;

		// Token: 0x04000491 RID: 1169
		private global::System.Windows.Forms.GroupBox groupBox2;

		// Token: 0x04000492 RID: 1170
		private global::System.Windows.Forms.GroupBox groupBox6;

		// Token: 0x04000493 RID: 1171
		private global::System.Windows.Forms.GroupBox groupBox8;

		// Token: 0x04000494 RID: 1172
		private global::System.Windows.Forms.GroupBox groupBox9;

		// Token: 0x040004A8 RID: 1192
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040004A9 RID: 1193
		private global::System.Windows.Forms.Label label10;

		// Token: 0x040004AA RID: 1194
		private global::System.Windows.Forms.Label label11;

		// Token: 0x040004AB RID: 1195
		private global::System.Windows.Forms.Label label12;

		// Token: 0x040004AC RID: 1196
		private global::System.Windows.Forms.Label label13;

		// Token: 0x040004AD RID: 1197
		private global::System.Windows.Forms.Label label14;

		// Token: 0x040004AE RID: 1198
		private global::System.Windows.Forms.Label label15;

		// Token: 0x040004AF RID: 1199
		private global::System.Windows.Forms.Label label16;

		// Token: 0x040004B0 RID: 1200
		private global::System.Windows.Forms.Label label17;

		// Token: 0x040004B1 RID: 1201
		private global::System.Windows.Forms.Label label18;

		// Token: 0x040004B2 RID: 1202
		private global::System.Windows.Forms.Label label19;

		// Token: 0x040004B3 RID: 1203
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040004B4 RID: 1204
		private global::System.Windows.Forms.Label label20;

		// Token: 0x040004B5 RID: 1205
		private global::System.Windows.Forms.Label label21;

		// Token: 0x040004B6 RID: 1206
		private global::System.Windows.Forms.Label label22;

		// Token: 0x040004B7 RID: 1207
		private global::System.Windows.Forms.Label label23;

		// Token: 0x040004B8 RID: 1208
		private global::System.Windows.Forms.Label label24;

		// Token: 0x040004B9 RID: 1209
		private global::System.Windows.Forms.Label label25;

		// Token: 0x040004BA RID: 1210
		private global::System.Windows.Forms.Label label26;

		// Token: 0x040004BB RID: 1211
		private global::System.Windows.Forms.Label label27;

		// Token: 0x040004BC RID: 1212
		private global::System.Windows.Forms.Label label28;

		// Token: 0x040004BD RID: 1213
		private global::System.Windows.Forms.Label label29;

		// Token: 0x040004BE RID: 1214
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040004BF RID: 1215
		private global::System.Windows.Forms.Label label30;

		// Token: 0x040004C0 RID: 1216
		private global::System.Windows.Forms.Label label31;

		// Token: 0x040004C1 RID: 1217
		private global::System.Windows.Forms.Label label32;

		// Token: 0x040004C2 RID: 1218
		private global::System.Windows.Forms.Label label33;

		// Token: 0x040004C3 RID: 1219
		private global::System.Windows.Forms.Label label34;

		// Token: 0x040004C4 RID: 1220
		private global::System.Windows.Forms.Label label35;

		// Token: 0x040004C5 RID: 1221
		private global::System.Windows.Forms.Label label36;

		// Token: 0x040004C6 RID: 1222
		private global::System.Windows.Forms.Label label37;

		// Token: 0x040004C7 RID: 1223
		private global::System.Windows.Forms.Label label38;

		// Token: 0x040004C8 RID: 1224
		private global::System.Windows.Forms.Label label39;

		// Token: 0x040004C9 RID: 1225
		private global::System.Windows.Forms.Label label4;

		// Token: 0x040004CA RID: 1226
		private global::System.Windows.Forms.Label label40;

		// Token: 0x040004CB RID: 1227
		private global::System.Windows.Forms.Label label41;

		// Token: 0x040004CC RID: 1228
		private global::System.Windows.Forms.Label label42;

		// Token: 0x040004CD RID: 1229
		private global::System.Windows.Forms.Label label43;

		// Token: 0x040004CE RID: 1230
		private global::System.Windows.Forms.Label label44;

		// Token: 0x040004CF RID: 1231
		private global::System.Windows.Forms.Label label45;

		// Token: 0x040004D0 RID: 1232
		private global::System.Windows.Forms.Label label46;

		// Token: 0x040004D1 RID: 1233
		private global::System.Windows.Forms.Label label47;

		// Token: 0x040004D2 RID: 1234
		private global::System.Windows.Forms.Label label48;

		// Token: 0x040004D3 RID: 1235
		private global::System.Windows.Forms.Label label49;

		// Token: 0x040004D4 RID: 1236
		private global::System.Windows.Forms.Label label5;

		// Token: 0x040004D5 RID: 1237
		private global::System.Windows.Forms.Label label50;

		// Token: 0x040004D6 RID: 1238
		private global::System.Windows.Forms.Label label51;

		// Token: 0x040004D7 RID: 1239
		private global::System.Windows.Forms.Label label52;

		// Token: 0x040004D8 RID: 1240
		private global::System.Windows.Forms.Label label53;

		// Token: 0x040004D9 RID: 1241
		private global::System.Windows.Forms.Label label54;

		// Token: 0x040004DA RID: 1242
		private global::System.Windows.Forms.Label label55;

		// Token: 0x040004DB RID: 1243
		private global::System.Windows.Forms.Label label56;

		// Token: 0x040004DC RID: 1244
		private global::System.Windows.Forms.Label label57;

		// Token: 0x040004DD RID: 1245
		private global::System.Windows.Forms.Label label6;

		// Token: 0x040004DE RID: 1246
		private global::System.Windows.Forms.Label label7;

		// Token: 0x040004DF RID: 1247
		private global::System.Windows.Forms.Label label8;

		// Token: 0x040004E0 RID: 1248
		private global::System.Windows.Forms.Label label9;

		// Token: 0x040004E1 RID: 1249
		public global::System.Windows.Forms.ListBox listBox_Level_Multi_1;

		// Token: 0x040004E2 RID: 1250
		public global::System.Windows.Forms.ListBox listBox_Level_Multi_2;

		// Token: 0x040004E3 RID: 1251
		public global::System.Windows.Forms.ListBox listBox_Level_Multi_3;

		// Token: 0x040004E4 RID: 1252
		public global::System.Windows.Forms.ListBox listBox_Level_Multi_4;

		// Token: 0x040004E5 RID: 1253
		public global::System.Windows.Forms.ListBox listBox_Level_Multi_5;

		// Token: 0x040004E6 RID: 1254
		public global::System.Windows.Forms.ListBox listBox_Level_Multi_6;

		// Token: 0x040004E7 RID: 1255
		public global::System.Windows.Forms.ListBox listBox_NewItem_ItemGroup;

		// Token: 0x040004E8 RID: 1256
		public global::System.Windows.Forms.ListBox listBox_NewItem_ItemIndex;

		// Token: 0x040004E9 RID: 1257
		public global::System.Windows.Forms.ListBox listBox_NewItem_ItemLevel;

		// Token: 0x040004EA RID: 1258
		public global::System.Windows.Forms.ListBox listBox_NewItem_ItemOption;

		// Token: 0x040004EB RID: 1259
		public global::System.Windows.Forms.ListBox listBox_Option_Multi_1;

		// Token: 0x040004EC RID: 1260
		public global::System.Windows.Forms.ListBox listBox_Option_Multi_2;

		// Token: 0x040004ED RID: 1261
		public global::System.Windows.Forms.ListBox listBox_Option_Multi_3;

		// Token: 0x040004EE RID: 1262
		public global::System.Windows.Forms.ListBox listBox_Option_Multi_4;

		// Token: 0x040004EF RID: 1263
		public global::System.Windows.Forms.ListBox listBox_Option_Multi_5;

		// Token: 0x040004F0 RID: 1264
		public global::System.Windows.Forms.ListBox listBox_Option_Multi_6;

		// Token: 0x040004F1 RID: 1265
		private global::System.Windows.Forms.ListBox listBox_PackageItem_AddedItems;

		// Token: 0x040004F2 RID: 1266
		private global::System.Windows.Forms.NumericUpDown numericUpDown_Count_Multi_1;

		// Token: 0x040004F3 RID: 1267
		private global::System.Windows.Forms.NumericUpDown numericUpDown_Count_Multi_2;

		// Token: 0x040004F4 RID: 1268
		private global::System.Windows.Forms.NumericUpDown numericUpDown_Count_Multi_3;

		// Token: 0x040004F5 RID: 1269
		private global::System.Windows.Forms.NumericUpDown numericUpDown_Count_Multi_4;

		// Token: 0x040004F6 RID: 1270
		private global::System.Windows.Forms.NumericUpDown numericUpDown_Count_Multi_5;

		// Token: 0x040004F7 RID: 1271
		private global::System.Windows.Forms.NumericUpDown numericUpDown_Count_Multi_6;

		// Token: 0x040004F8 RID: 1272
		public global::System.Windows.Forms.NumericUpDown numericUpDown_Durability_Multi_1;

		// Token: 0x040004F9 RID: 1273
		public global::System.Windows.Forms.NumericUpDown numericUpDown_Durability_Multi_2;

		// Token: 0x040004FA RID: 1274
		public global::System.Windows.Forms.NumericUpDown numericUpDown_Durability_Multi_3;

		// Token: 0x040004FB RID: 1275
		public global::System.Windows.Forms.NumericUpDown numericUpDown_Durability_Multi_4;

		// Token: 0x040004FC RID: 1276
		public global::System.Windows.Forms.NumericUpDown numericUpDown_Durability_Multi_5;

		// Token: 0x040004FD RID: 1277
		public global::System.Windows.Forms.NumericUpDown numericUpDown_Durability_Multi_6;

		// Token: 0x040004FE RID: 1278
		private global::System.Windows.Forms.NumericUpDown numericUpDown_NewItem_Count;

		// Token: 0x040004FF RID: 1279
		public global::System.Windows.Forms.NumericUpDown numericUpDown_NewItem_Durability;

		// Token: 0x04000500 RID: 1280
		private global::System.Windows.Forms.NumericUpDown numericUpDown_NewItem_Price;

		// Token: 0x04000501 RID: 1281
		public global::System.Windows.Forms.NumericUpDown numericUpDown_NewItem_SocketCount;

		// Token: 0x04000502 RID: 1282
		private global::System.Windows.Forms.NumericUpDown numericUpDown_Price_Multi_1;

		// Token: 0x04000503 RID: 1283
		private global::System.Windows.Forms.NumericUpDown numericUpDown_Price_Multi_2;

		// Token: 0x04000504 RID: 1284
		private global::System.Windows.Forms.NumericUpDown numericUpDown_Price_Multi_3;

		// Token: 0x04000505 RID: 1285
		private global::System.Windows.Forms.NumericUpDown numericUpDown_Price_Multi_4;

		// Token: 0x04000506 RID: 1286
		private global::System.Windows.Forms.NumericUpDown numericUpDown_Price_Multi_5;

		// Token: 0x04000507 RID: 1287
		private global::System.Windows.Forms.NumericUpDown numericUpDown_Price_Multi_6;

		// Token: 0x04000508 RID: 1288
		public global::System.Windows.Forms.NumericUpDown numericUpDown_Sockets_Multi_1;

		// Token: 0x04000509 RID: 1289
		public global::System.Windows.Forms.NumericUpDown numericUpDown_Sockets_Multi_2;

		// Token: 0x0400050A RID: 1290
		public global::System.Windows.Forms.NumericUpDown numericUpDown_Sockets_Multi_3;

		// Token: 0x0400050B RID: 1291
		public global::System.Windows.Forms.NumericUpDown numericUpDown_Sockets_Multi_4;

		// Token: 0x0400050C RID: 1292
		public global::System.Windows.Forms.NumericUpDown numericUpDown_Sockets_Multi_5;

		// Token: 0x0400050D RID: 1293
		public global::System.Windows.Forms.NumericUpDown numericUpDown_Sockets_Multi_6;

		// Token: 0x0400050F RID: 1295
		private global::System.Windows.Forms.Panel panel_ItemAdd;

		// Token: 0x04000510 RID: 1296
		private global::System.Windows.Forms.PictureBox pictureBox_NewItem_ItemPreview;

		// Token: 0x04000511 RID: 1297
		private global::System.Windows.Forms.RadioButton radioButton_Armor_Multi_1;

		// Token: 0x04000512 RID: 1298
		private global::System.Windows.Forms.RadioButton radioButton_Armor_Multi_2;

		// Token: 0x04000513 RID: 1299
		private global::System.Windows.Forms.RadioButton radioButton_Armor_Multi_3;

		// Token: 0x04000514 RID: 1300
		private global::System.Windows.Forms.RadioButton radioButton_Armor_Multi_4;

		// Token: 0x04000515 RID: 1301
		private global::System.Windows.Forms.RadioButton radioButton_Armor_Multi_5;

		// Token: 0x04000516 RID: 1302
		private global::System.Windows.Forms.RadioButton radioButton_Armor_Multi_6;

		// Token: 0x04000517 RID: 1303
		private global::System.Windows.Forms.RadioButton radioButton_NewItem_ExcArmor;

		// Token: 0x04000518 RID: 1304
		private global::System.Windows.Forms.RadioButton radioButton_NewItem_ExcWeapon;

		// Token: 0x04000519 RID: 1305
		private global::System.Windows.Forms.RadioButton radioButton_NewItem_ExcWings;

		// Token: 0x0400051A RID: 1306
		private global::System.Windows.Forms.RadioButton radioButton_Weapon_Multi_1;

		// Token: 0x0400051B RID: 1307
		private global::System.Windows.Forms.RadioButton radioButton_Weapon_Multi_2;

		// Token: 0x0400051C RID: 1308
		private global::System.Windows.Forms.RadioButton radioButton_Weapon_Multi_3;

		// Token: 0x0400051D RID: 1309
		private global::System.Windows.Forms.RadioButton radioButton_Weapon_Multi_4;

		// Token: 0x0400051E RID: 1310
		private global::System.Windows.Forms.RadioButton radioButton_Weapon_Multi_5;

		// Token: 0x0400051F RID: 1311
		private global::System.Windows.Forms.RadioButton radioButton_Weapon_Multi_6;

		// Token: 0x04000520 RID: 1312
		private global::System.Windows.Forms.RadioButton radioButton_Wings_Multi_1;

		// Token: 0x04000521 RID: 1313
		private global::System.Windows.Forms.RadioButton radioButton_Wings_Multi_2;

		// Token: 0x04000522 RID: 1314
		private global::System.Windows.Forms.RadioButton radioButton_Wings_Multi_3;

		// Token: 0x04000523 RID: 1315
		private global::System.Windows.Forms.RadioButton radioButton_Wings_Multi_4;

		// Token: 0x04000524 RID: 1316
		private global::System.Windows.Forms.RadioButton radioButton_Wings_Multi_5;

		// Token: 0x04000525 RID: 1317
		private global::System.Windows.Forms.RadioButton radioButton_Wings_Multi_6;

		// Token: 0x04000526 RID: 1318
		private global::System.Windows.Forms.RichTextBox richTextBox_NewItem_Info;

		// Token: 0x04000527 RID: 1319
		private global::System.Windows.Forms.TabControl tabControl1;

		// Token: 0x04000528 RID: 1320
		private global::System.Windows.Forms.TabPage tabPage_MultiOption_1;

		// Token: 0x04000529 RID: 1321
		private global::System.Windows.Forms.TabPage tabPage_MultiOption_2;

		// Token: 0x0400052A RID: 1322
		private global::System.Windows.Forms.TabPage tabPage_MultiOption_3;

		// Token: 0x0400052B RID: 1323
		private global::System.Windows.Forms.TabPage tabPage_MultiOption_4;

		// Token: 0x0400052C RID: 1324
		private global::System.Windows.Forms.TabPage tabPage_MultiOption_5;

		// Token: 0x0400052D RID: 1325
		private global::System.Windows.Forms.TabPage tabPage_MultiOption_6;

		// Token: 0x0400052E RID: 1326
		private global::System.Windows.Forms.TextBox textBox_Info;

		// Token: 0x0400052F RID: 1327
		private global::System.Windows.Forms.TextBox textBox_Name_Multi_1;

		// Token: 0x04000530 RID: 1328
		private global::System.Windows.Forms.TextBox textBox_Name_Multi_2;

		// Token: 0x04000531 RID: 1329
		private global::System.Windows.Forms.TextBox textBox_Name_Multi_3;

		// Token: 0x04000532 RID: 1330
		private global::System.Windows.Forms.TextBox textBox_Name_Multi_4;

		// Token: 0x04000533 RID: 1331
		private global::System.Windows.Forms.TextBox textBox_Name_Multi_5;

		// Token: 0x04000534 RID: 1332
		private global::System.Windows.Forms.TextBox textBox_Name_Multi_6;

		// Token: 0x04000535 RID: 1333
		private global::System.Windows.Forms.TextBox textBox_NewItem_Name;
	}
}
