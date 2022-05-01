using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MU_ToolKit.Properties;

namespace MU_ToolKit
{
	// Token: 0x02000005 RID: 5
	public partial class EventBagEditor_XML : Form
	{
		// Token: 0x0600000C RID: 12 RVA: 0x000029A4 File Offset: 0x00000BA4
		public EventBagEditor_XML()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002B88 File Offset: 0x00000D88
		private void button_AddItem_Click(object sender, EventArgs e)
		{
			if (this.BagItemList.Count < 150)
			{
				Structures.EventBagItem item = new Structures.EventBagItem
				{
					Group = (int)this.listBox_Add_Group.SelectedValue,
					Index = (int)this.listBox_Add_Index.SelectedValue,
					Luck = this.checkBox_Add_Luck.Checked,
					MaxLevel = (int)this.numericUpDown_Add_MaxLevel.Value,
					MinLevel = (int)this.numericUpDown_Add_MinLevel.Value,
					new_MaxOption = (int)this.comboBox_Add_MaxOption.SelectedValue,
					Skill = this.checkBox_Add_Skill.Checked,
					Excellent = this.checkBox_Add_Exc.Checked,
					Ancient = this.checkBox_Add_Anc.Checked,
					Socket = this.checkBox_Add_Sock.Checked
				};
				item.Name = this.ItemName[item.Group, item.Index];
				this.BagItemList.Add(item);
				if (!this.button_Item_Remove.Enabled)
				{
					this.button_Item_Remove.Enabled = true;
					this.button_Item_Update.Enabled = true;
				}
				this.label_ItemCount.Text = ((int)(Convert.ToInt16(this.label_ItemCount.Text) + 1)).ToString();
				this.listBox_AddedItems.SelectedIndex = -1;
				this.listBox_AddedItems.SelectedIndex = this.listBox_AddedItems.Items.Count - 1;
			}
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002D20 File Offset: 0x00000F20
		private void button_Item_Remove_Click(object sender, EventArgs e)
		{
			Structures.EventBagItem item = (Structures.EventBagItem)this.listBox_AddedItems.SelectedItem;
			this.BagItemList.Remove(item);
			this.label_ItemCount.Text = ((int)(Convert.ToInt16(this.label_ItemCount.Text) - 1)).ToString();
			if (Convert.ToInt16(this.label_ItemCount.Text) == 0)
			{
				this.button_Item_Remove.Enabled = false;
				this.button_Item_Update.Enabled = false;
			}
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002D9C File Offset: 0x00000F9C
		private void button_Item_Update_Click(object sender, EventArgs e)
		{
			this.DontWork = true;
			Structures.EventBagItem eventBagItem = (Structures.EventBagItem)this.listBox_AddedItems.SelectedItem;
			Structures.EventBagItem value = eventBagItem;
			value.Excellent = this.checkBox_Added_Exc.Checked;
			value.Luck = this.checkBox_Added_Luck.Checked;
			value.MaxLevel = (int)this.numericUpDown_Added_MaxLevel.Value;
			value.MinLevel = (int)this.numericUpDown_Added_MinLevel.Value;
			value.new_MaxOption = (int)this.comboBox_Added_MaxOption.SelectedValue;
			value.Skill = this.checkBox_Added_Skill.Checked;
			value.Ancient = this.checkBox_Added_Anc.Checked;
			value.Socket = this.checkBox_Added_Sock.Checked;
			this.BagItemList[this.BagItemList.IndexOf(eventBagItem)] = value;
			this.DontWork = false;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002EA0 File Offset: 0x000010A0
		private void EventBagEditor_XML_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.OpenForms["Form1"].WindowState = FormWindowState.Normal;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002EB8 File Offset: 0x000010B8
		private void EventBagEditor_XML_Load(object sender, EventArgs e)
		{
			Form1 form = (Form1)Application.OpenForms[0];
			this.isEx700ItemList = (form.isEx700ItemList ? 1 : 0);
			string[,] array = null;
			if (this.isEx700ItemList == 1)
			{
				this.strct.ReadItemList("Data\\ItemListSettings_ex700.ini", true, ref this.L_Groups, ref this.L_Swords, ref this.L_Axes, ref this.L_MacesScepters, ref this.L_Spears, ref this.L_BowsCrossBows, ref this.L_Staffs, ref this.L_Shields, ref this.L_Helms, ref this.L_Armors, ref this.L_Pants, ref this.L_Gloves, ref this.L_Boots, ref this.L_WingsSkillsSeedsOthers, ref this.L_Others1, ref this.L_Others2, ref this.L_Scrolls, ref this.ItemName, ref array);
			}
			else
			{
				this.strct.ReadItemList("Data\\ItemListSettings.ini", false, ref this.L_Groups, ref this.L_Swords, ref this.L_Axes, ref this.L_MacesScepters, ref this.L_Spears, ref this.L_BowsCrossBows, ref this.L_Staffs, ref this.L_Shields, ref this.L_Helms, ref this.L_Armors, ref this.L_Pants, ref this.L_Gloves, ref this.L_Boots, ref this.L_WingsSkillsSeedsOthers, ref this.L_Others1, ref this.L_Others2, ref this.L_Scrolls, ref this.ItemName, ref array);
			}
			this.C_Swords = new List<Structures.UniItem>(this.L_Swords);
			this.C_Axes = new List<Structures.UniItem>(this.L_Axes);
			this.C_MacesScepters = new List<Structures.UniItem>(this.L_MacesScepters);
			this.C_Spears = new List<Structures.UniItem>(this.L_Spears);
			this.C_BowsCrossBows = new List<Structures.UniItem>(this.L_BowsCrossBows);
			this.C_Staffs = new List<Structures.UniItem>(this.L_Staffs);
			this.C_Shields = new List<Structures.UniItem>(this.L_Shields);
			this.C_Helms = new List<Structures.UniItem>(this.L_Helms);
			this.C_Armors = new List<Structures.UniItem>(this.L_Armors);
			this.C_Pants = new List<Structures.UniItem>(this.L_Pants);
			this.C_Gloves = new List<Structures.UniItem>(this.L_Gloves);
			this.C_Boots = new List<Structures.UniItem>(this.L_Boots);
			this.C_WingsSkillsSeedsOthers = new List<Structures.UniItem>(this.L_WingsSkillsSeedsOthers);
			this.C_Others1 = new List<Structures.UniItem>(this.L_Others1);
			this.C_Others2 = new List<Structures.UniItem>(this.L_Others2);
			this.C_Scrolls = new List<Structures.UniItem>(this.L_Scrolls);
			this.C_Groups = new List<Structures.c_Groups>(this.L_Groups);
			this.listBox_Add_Group.DisplayMember = "GroupName";
			this.listBox_Add_Group.ValueMember = "Group";
			this.listBox_Add_Group.DataSource = this.L_Groups;
			this.listBox_AddedItems.DataSource = this.BagItemList;
			this.listBox_AddedItems.DisplayMember = "Name";
			this.strct.Setc_OptionData(ref this.c_OptionDatas_Add);
			this.c_OptionDatas_Added = new List<Structures.c_OptionData>(this.c_OptionDatas_Add);
			this.c_OptionDatas_Default = new List<Structures.c_OptionData>(this.c_OptionDatas_Add);
			this.comboBox_Add_MaxOption.DataSource = this.c_OptionDatas_Add;
			this.comboBox_Add_MaxOption.DisplayMember = "Name";
			this.comboBox_Add_MaxOption.ValueMember = "ID";
			this.comboBox_Added_MaxOption.DataSource = this.c_OptionDatas_Added;
			this.comboBox_Added_MaxOption.DisplayMember = "Name";
			this.comboBox_Added_MaxOption.ValueMember = "ID";
			this.comboBox_DefMaxOption.DataSource = this.c_OptionDatas_Default;
			this.comboBox_DefMaxOption.DisplayMember = "Name";
			this.comboBox_DefMaxOption.ValueMember = "ID";
			Application.OpenForms["Form1"].WindowState = FormWindowState.Minimized;
			base.WindowState = FormWindowState.Normal;
			base.TopMost = true;
			base.TopMost = false;
			base.BringToFront();
			base.Focus();
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00005A00 File Offset: 0x00003C00
		private void listBox_Add_Group_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.listBox_Add_Group.SelectedIndex != -1)
			{
				this.DontWork = true;
				switch ((int)this.listBox_Add_Group.SelectedValue)
				{
				case 0:
					this.listBox_Add_Index.DisplayMember = "Name";
					this.listBox_Add_Index.ValueMember = "Index";
					this.listBox_Add_Index.DataSource = this.L_Swords;
					break;
				case 1:
					this.listBox_Add_Index.DisplayMember = "Name";
					this.listBox_Add_Index.ValueMember = "Index";
					this.listBox_Add_Index.DataSource = this.L_Axes;
					break;
				case 2:
					this.listBox_Add_Index.DisplayMember = "Name";
					this.listBox_Add_Index.ValueMember = "Index";
					this.listBox_Add_Index.DataSource = this.L_MacesScepters;
					break;
				case 3:
					this.listBox_Add_Index.DisplayMember = "Name";
					this.listBox_Add_Index.ValueMember = "Index";
					this.listBox_Add_Index.DataSource = this.L_Spears;
					break;
				case 4:
					this.listBox_Add_Index.DisplayMember = "Name";
					this.listBox_Add_Index.ValueMember = "Index";
					this.listBox_Add_Index.DataSource = this.L_BowsCrossBows;
					break;
				case 5:
					this.listBox_Add_Index.DisplayMember = "Name";
					this.listBox_Add_Index.ValueMember = "Index";
					this.listBox_Add_Index.DataSource = this.L_Staffs;
					break;
				case 6:
					this.listBox_Add_Index.DisplayMember = "Name";
					this.listBox_Add_Index.ValueMember = "Index";
					this.listBox_Add_Index.DataSource = this.L_Shields;
					break;
				case 7:
					this.listBox_Add_Index.DisplayMember = "Name";
					this.listBox_Add_Index.ValueMember = "Index";
					this.listBox_Add_Index.DataSource = this.L_Helms;
					break;
				case 8:
					this.listBox_Add_Index.DisplayMember = "Name";
					this.listBox_Add_Index.ValueMember = "Index";
					this.listBox_Add_Index.DataSource = this.L_Armors;
					break;
				case 9:
					this.listBox_Add_Index.DisplayMember = "Name";
					this.listBox_Add_Index.ValueMember = "Index";
					this.listBox_Add_Index.DataSource = this.L_Pants;
					break;
				case 10:
					this.listBox_Add_Index.DisplayMember = "Name";
					this.listBox_Add_Index.ValueMember = "Index";
					this.listBox_Add_Index.DataSource = this.L_Gloves;
					break;
				case 11:
					this.listBox_Add_Index.DisplayMember = "Name";
					this.listBox_Add_Index.ValueMember = "Index";
					this.listBox_Add_Index.DataSource = this.L_Boots;
					break;
				case 12:
					this.listBox_Add_Index.DisplayMember = "Name";
					this.listBox_Add_Index.ValueMember = "Index";
					this.listBox_Add_Index.DataSource = this.L_WingsSkillsSeedsOthers;
					break;
				case 13:
					this.listBox_Add_Index.DisplayMember = "Name";
					this.listBox_Add_Index.ValueMember = "Index";
					this.listBox_Add_Index.DataSource = this.L_Others1;
					break;
				case 14:
					this.listBox_Add_Index.DisplayMember = "Name";
					this.listBox_Add_Index.ValueMember = "Index";
					this.listBox_Add_Index.DataSource = this.L_Others2;
					break;
				case 15:
					this.listBox_Add_Index.DisplayMember = "Name";
					this.listBox_Add_Index.ValueMember = "Index";
					this.listBox_Add_Index.DataSource = this.L_Scrolls;
					break;
				}
				this.listBox_Add_Index.SelectedIndex = -1;
				this.DontWork = false;
				if (this.LastSelectedItemIndex <= this.listBox_Add_Index.Items.Count)
				{
					this.listBox_Add_Index.SelectedIndex = this.LastSelectedItemIndex;
				}
			}
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00005E14 File Offset: 0x00004014
		private void listBox_Add_Index_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.listBox_Add_Index.SelectedIndex != -1 & !this.DontWork)
			{
				this.LastSelectedItemIndex = this.listBox_Add_Index.SelectedIndex;
				try
				{
					this.pictureBox_Add_ItemPreview.BackgroundImage = (Bitmap)Resources.ResourceManager.GetObject("_" + this.listBox_Add_Group.SelectedValue + this.listBox_Add_Index.SelectedValue);
					if (this.pictureBox_Add_ItemPreview.BackgroundImage.Size.Width > this.pictureBox_Add_ItemPreview.Size.Width || this.pictureBox_Add_ItemPreview.BackgroundImage.Size.Height > this.pictureBox_Add_ItemPreview.Size.Height)
					{
						this.pictureBox_Add_ItemPreview.BackgroundImageLayout = ImageLayout.Zoom;
					}
					else
					{
						this.pictureBox_Add_ItemPreview.BackgroundImageLayout = ImageLayout.Center;
					}
				}
				catch
				{
					this.pictureBox_Add_ItemPreview.BackgroundImage = (Bitmap)Resources.ResourceManager.GetObject("no_img");
				}
			}
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00005F34 File Offset: 0x00004134
		private void listBox_AddedItems_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.listBox_AddedItems.SelectedIndex != -1 & !this.DontWork)
			{
				Structures.EventBagItem eventBagItem = (Structures.EventBagItem)this.listBox_AddedItems.SelectedItem;
				this.numericUpDown_Added_MaxLevel.Value = eventBagItem.MaxLevel;
				this.numericUpDown_Added_MinLevel.Value = eventBagItem.MinLevel;
				this.checkBox_Added_Exc.Checked = eventBagItem.Excellent;
				this.checkBox_Added_Luck.Checked = eventBagItem.Luck;
				this.comboBox_Added_MaxOption.SelectedValue = eventBagItem.new_MaxOption;
				this.checkBox_Added_Skill.Checked = eventBagItem.Skill;
				this.checkBox_Added_Anc.Checked = eventBagItem.Ancient;
				this.checkBox_Added_Sock.Checked = eventBagItem.Socket;
				try
				{
					this.pictureBox_Added_ItemPreview.BackgroundImage = (Bitmap)Resources.ResourceManager.GetObject("_" + eventBagItem.Group + eventBagItem.Index);
					if (this.pictureBox_Added_ItemPreview.BackgroundImage.Size.Width > this.pictureBox_Added_ItemPreview.Size.Width || this.pictureBox_Added_ItemPreview.BackgroundImage.Size.Height > this.pictureBox_Added_ItemPreview.Size.Height)
					{
						this.pictureBox_Added_ItemPreview.BackgroundImageLayout = ImageLayout.Zoom;
					}
					else
					{
						this.pictureBox_Added_ItemPreview.BackgroundImageLayout = ImageLayout.Center;
					}
				}
				catch
				{
					this.pictureBox_Added_ItemPreview.BackgroundImage = (Bitmap)Resources.ResourceManager.GetObject("no_img");
				}
			}
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000060F8 File Offset: 0x000042F8
		private void newToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.button_Item_Update.Enabled = false;
			this.button_Item_Remove.Enabled = false;
			this.BagDrop = default(Structures.EventBagDrop);
			this.BagItemList.Clear();
			this.numericUpDown_DropRate.Value = 0m;
			this.numericUpDown_ExcDropRate.Value = 0m;
			this.numericUpDown_AncDropRate.Value = 0m;
			this.numericUpDown_SocketDropRate.Value = 0m;
			this.numericUpDown_BagZen.Value = 0m;
			this.numericUpDown_Add_MinLevel.Value = 0m;
			this.numericUpDown_Add_MaxLevel.Value = 15m;
			this.numericUpDown_Added_MinLevel.Value = 0m;
			this.numericUpDown_Added_MaxLevel.Value = 15m;
			this.comboBox_Added_MaxOption.SelectedIndex = 0;
			this.checkBox_Add_Skill.Checked = false;
			this.checkBox_Add_Luck.Checked = false;
			this.checkBox_Add_Anc.Checked = false;
			this.checkBox_Add_Sock.Checked = false;
			this.comboBox_Add_MaxOption.SelectedIndex = 0;
			this.checkBox_Add_Exc.Checked = false;
			this.checkBox_Added_Skill.Checked = false;
			this.checkBox_Added_Luck.Checked = false;
			this.checkBox_Added_Anc.Checked = false;
			this.checkBox_Added_Sock.Checked = false;
			this.checkBox_Added_Exc.Checked = false;
			this.numericUpDown_DefMinLvl.Value = 0m;
			this.numericUpDown_DefMaxLvl.Value = 15m;
			this.comboBox_DefMaxOption.SelectedIndex = 0;
			this.checkBox_DefSkill.Checked = false;
			this.checkBox_DefLuck.Checked = false;
			this.checkBox_DefExc.Checked = false;
			this.checkBox_DefAnc.Checked = false;
			this.checkBox_DefSocket.Checked = false;
			this.label_ItemCount.Text = "0";
			this.textBox_EventName.Text = "";
		}

		// Token: 0x06000018 RID: 24 RVA: 0x000062EC File Offset: 0x000044EC
		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Title = "Select the EventBag (xml) file to load",
				Filter = "XML files (*.xml)|*.xml"
			};
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				string[] array = openFileDialog.FileName.Split(new char[]
				{
					'\\'
				});
				this.label_FileName.Text = array[array.Length - 1];
				this.BagDrop = default(Structures.EventBagDrop);
				this.BagItemList.Clear();
				this.label_ItemCount.Text = "0";
				this.strct.ReadXMLEventBagFile(openFileDialog.FileName, ref this.BagDrop, ref this.BagItemList, this.ItemName);
				if (this.listBox_AddedItems.Items.Count > 0)
				{
					this.listBox_AddedItems.SelectedIndex = -1;
					this.listBox_AddedItems.SelectedIndex = 0;
					this.button_Item_Update.Enabled = true;
					this.button_Item_Remove.Enabled = true;
					this.label_ItemCount.Text = this.listBox_AddedItems.Items.Count.ToString();
				}
				this.textBox_EventName.Text = this.BagDrop.Name;
				this.numericUpDown_BagZen.Value = this.BagDrop.Zen;
				this.numericUpDown_DropRate.Value = (decimal)this.BagDrop.ItemDropRate;
				this.numericUpDown_ExcDropRate.Value = (decimal)this.BagDrop.ExcDropRate;
				this.numericUpDown_AncDropRate.Value = (decimal)this.BagDrop.AncDropRate;
				this.numericUpDown_SocketDropRate.Value = (decimal)this.BagDrop.SocketDropRate;
				this.numericUpDown_DefMinLvl.Value = this.BagDrop.Default_minlv;
				this.numericUpDown_DefMaxLvl.Value = this.BagDrop.Default_maxlv;
				this.comboBox_DefMaxOption.SelectedValue = this.BagDrop.Default_addopt;
				this.checkBox_DefSkill.Checked = this.BagDrop.Default_skill;
				this.checkBox_DefAnc.Checked = this.BagDrop.Default_anc;
				this.checkBox_DefLuck.Checked = this.BagDrop.Default_luck;
				this.checkBox_DefExc.Checked = this.BagDrop.Default_exc;
				this.checkBox_DefSocket.Checked = this.BagDrop.Default_sock;
			}
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00006560 File Offset: 0x00004760
		private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog
			{
				Title = "Select a location to save the EventBag",
				Filter = "XML files (*.xml)|*.xml"
			};
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				string[] array = saveFileDialog.FileName.Split(new char[]
				{
					'\\'
				});
				this.label_FileName.Text = array[array.Length - 1];
				StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);
				streamWriter.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
				streamWriter.WriteLine("\t<ItemBag>");
				streamWriter.WriteLine("\t\t<Bag>");
				streamWriter.WriteLine("\t\t\t<!-- ItemRate [0..100];  ExcRate [0..100]; AncientRate [0..100]; SocketRate [0..100]; -->");
				streamWriter.WriteLine(string.Concat(new object[]
				{
					"\t\t\t<BagConfig Name=\"",
					this.textBox_EventName.Text,
					"\" ZenDrop=\"",
					this.numericUpDown_BagZen.Value,
					"\" ItemRate=\"",
					this.numericUpDown_DropRate.Value,
					"\" ExcRate=\"",
					this.numericUpDown_ExcDropRate.Value,
					"\" AncientRate=\"",
					this.numericUpDown_AncDropRate.Value,
					"\" SocketRate=\"",
					this.numericUpDown_SocketDropRate.Value,
					"\"/>"
				}));
				streamWriter.WriteLine("\t\t</Bag>");
				streamWriter.WriteLine("\t\t<Default>");
				streamWriter.WriteLine("\t\t\t<!-- addopt [0..7];  exc [0/1]; anc [0/1]; sock [0/1]; -->");
				streamWriter.WriteLine(string.Concat(new object[]
				{
					"\t\t\t<DefaultConfig cat=\"0\" id=\"0\" minlv=\"",
					this.numericUpDown_DefMinLvl.Value,
					"\" maxlv=\"",
					this.numericUpDown_DefMaxLvl.Value,
					"\" skill=\"",
					this.checkBox_DefSkill.Checked ? "1" : "0",
					"\" luck=\"",
					this.checkBox_DefLuck.Checked ? "1" : "0",
					"\" addopt=\"",
					this.comboBox_DefMaxOption.SelectedValue,
					"\" exc=\"",
					this.checkBox_DefExc.Checked ? "1" : "0",
					"\" anc=\"",
					this.checkBox_DefAnc.Checked ? "1" : "0",
					"\" sock=\"",
					this.checkBox_DefSocket.Checked ? "1" : "0",
					"\"/>"
				}));
				streamWriter.WriteLine("\t\t</Default>");
				streamWriter.WriteLine("\t\t<Items>");
				streamWriter.WriteLine("\t\t\t<!-- addopt [0..7];  exc [0/1]; anc [0/1]; sock [0/1]; -->");
				foreach (Structures.EventBagItem eventBagItem in this.BagItemList)
				{
					streamWriter.WriteLine(string.Concat(new object[]
					{
						"\t\t\t<Item cat=\"",
						eventBagItem.Group,
						"\" id=\"",
						eventBagItem.Index,
						"\" minlv=\"",
						eventBagItem.MinLevel,
						"\" maxlv=\"",
						eventBagItem.MaxLevel,
						"\" skill=\"",
						eventBagItem.Skill ? "1" : "0",
						"\" luck=\"",
						eventBagItem.Luck ? "1" : "0",
						"\" addopt=\"",
						eventBagItem.new_MaxOption,
						"\" exc=\"",
						eventBagItem.Excellent ? "1" : "0",
						"\" anc=\"",
						eventBagItem.Ancient ? "1" : "0",
						"\" sock=\"",
						eventBagItem.Socket ? "1" : "0",
						"\"/>"
					}));
				}
				streamWriter.WriteLine("\t\t</Items>");
				streamWriter.WriteLine("\t</ItemBag>");
				streamWriter.Flush();
				streamWriter.Close();
			}
		}

		// Token: 0x0400000F RID: 15
		private Structures.EventBagDrop BagDrop = default(Structures.EventBagDrop);

		// Token: 0x04000010 RID: 16
		private BindingList<Structures.EventBagItem> BagItemList = new BindingList<Structures.EventBagItem>();

		// Token: 0x04000014 RID: 20
		private List<Structures.UniItem> C_Armors = new List<Structures.UniItem>();

		// Token: 0x04000015 RID: 21
		private List<Structures.UniItem> C_Axes = new List<Structures.UniItem>();

		// Token: 0x04000016 RID: 22
		private List<Structures.UniItem> C_Boots = new List<Structures.UniItem>();

		// Token: 0x04000017 RID: 23
		private List<Structures.UniItem> C_BowsCrossBows = new List<Structures.UniItem>();

		// Token: 0x04000018 RID: 24
		private List<Structures.UniItem> C_Gloves = new List<Structures.UniItem>();

		// Token: 0x04000019 RID: 25
		private List<Structures.c_Groups> C_Groups = new List<Structures.c_Groups>();

		// Token: 0x0400001A RID: 26
		private List<Structures.UniItem> C_Helms = new List<Structures.UniItem>();

		// Token: 0x0400001B RID: 27
		private List<Structures.UniItem> C_MacesScepters = new List<Structures.UniItem>();

		// Token: 0x0400001C RID: 28
		private List<Structures.c_OptionData> c_OptionDatas_Add = new List<Structures.c_OptionData>();

		// Token: 0x0400001D RID: 29
		private List<Structures.c_OptionData> c_OptionDatas_Added = new List<Structures.c_OptionData>();

		// Token: 0x0400001E RID: 30
		private List<Structures.c_OptionData> c_OptionDatas_Default = new List<Structures.c_OptionData>();

		// Token: 0x0400001F RID: 31
		private List<Structures.UniItem> C_Others1 = new List<Structures.UniItem>();

		// Token: 0x04000020 RID: 32
		private List<Structures.UniItem> C_Others2 = new List<Structures.UniItem>();

		// Token: 0x04000021 RID: 33
		private List<Structures.UniItem> C_Pants = new List<Structures.UniItem>();

		// Token: 0x04000022 RID: 34
		private List<Structures.UniItem> C_Scrolls = new List<Structures.UniItem>();

		// Token: 0x04000023 RID: 35
		private List<Structures.UniItem> C_Shields = new List<Structures.UniItem>();

		// Token: 0x04000024 RID: 36
		private List<Structures.UniItem> C_Spears = new List<Structures.UniItem>();

		// Token: 0x04000025 RID: 37
		private List<Structures.UniItem> C_Staffs = new List<Structures.UniItem>();

		// Token: 0x04000026 RID: 38
		private List<Structures.UniItem> C_Swords = new List<Structures.UniItem>();

		// Token: 0x04000027 RID: 39
		private List<Structures.UniItem> C_WingsSkillsSeedsOthers = new List<Structures.UniItem>();

		// Token: 0x0400003B RID: 59
		private bool DontWork;

		// Token: 0x04000041 RID: 65
		private int isEx700ItemList;

		// Token: 0x04000042 RID: 66
		private string[,] ItemName = new string[16, 513];

		// Token: 0x04000043 RID: 67
		private List<Structures.UniItem> L_Armors = new List<Structures.UniItem>();

		// Token: 0x04000044 RID: 68
		private List<Structures.UniItem> L_Axes = new List<Structures.UniItem>();

		// Token: 0x04000045 RID: 69
		private List<Structures.UniItem> L_Boots = new List<Structures.UniItem>();

		// Token: 0x04000046 RID: 70
		private List<Structures.UniItem> L_BowsCrossBows = new List<Structures.UniItem>();

		// Token: 0x04000047 RID: 71
		private List<Structures.UniItem> L_Gloves = new List<Structures.UniItem>();

		// Token: 0x04000048 RID: 72
		private List<Structures.c_Groups> L_Groups = new List<Structures.c_Groups>();

		// Token: 0x04000049 RID: 73
		private List<Structures.UniItem> L_Helms = new List<Structures.UniItem>();

		// Token: 0x0400004A RID: 74
		private List<Structures.UniItem> L_MacesScepters = new List<Structures.UniItem>();

		// Token: 0x0400004B RID: 75
		private List<Structures.UniItem> L_Others1 = new List<Structures.UniItem>();

		// Token: 0x0400004C RID: 76
		private List<Structures.UniItem> L_Others2 = new List<Structures.UniItem>();

		// Token: 0x0400004D RID: 77
		private List<Structures.UniItem> L_Pants = new List<Structures.UniItem>();

		// Token: 0x0400004E RID: 78
		private List<Structures.UniItem> L_Scrolls = new List<Structures.UniItem>();

		// Token: 0x0400004F RID: 79
		private List<Structures.UniItem> L_Shields = new List<Structures.UniItem>();

		// Token: 0x04000050 RID: 80
		private List<Structures.UniItem> L_Spears = new List<Structures.UniItem>();

		// Token: 0x04000051 RID: 81
		private List<Structures.UniItem> L_Staffs = new List<Structures.UniItem>();

		// Token: 0x04000052 RID: 82
		private List<Structures.UniItem> L_Swords = new List<Structures.UniItem>();

		// Token: 0x04000053 RID: 83
		private List<Structures.UniItem> L_WingsSkillsSeedsOthers = new List<Structures.UniItem>();

		// Token: 0x0400006A RID: 106
		private int LastSelectedItemIndex;

		// Token: 0x0400007F RID: 127
		private Structures strct = new Structures();
	}
}
