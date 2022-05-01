using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MU_ToolKit.Properties;

namespace MU_ToolKit
{
	// Token: 0x02000025 RID: 37
	public partial class EventBagEditor : Form
	{
		// Token: 0x0600048E RID: 1166 RVA: 0x0001F55C File Offset: 0x0001D75C
		public EventBagEditor()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600048F RID: 1167 RVA: 0x0001F73C File Offset: 0x0001D93C
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
					Option = this.checkBox_Add_Option.Checked,
					Skill = this.checkBox_Add_Skill.Checked,
					Excellent = this.checkBox_Add_Exc.Checked
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

		// Token: 0x06000490 RID: 1168 RVA: 0x0001F8AC File Offset: 0x0001DAAC
		private void button_AddMap_Click(object sender, EventArgs e)
		{
			Structures.EventBagMap item = default(Structures.EventBagMap);
			Structures.Map map = (Structures.Map)this.listBox_MapSelection.SelectedItem;
			item.Drop = this.checkBox_Map_Drop.Checked;
			item.ID = map.MapCode;
			item.MobMaxLvl = (int)this.numericUpDown_Map_MaxMobLvl.Value;
			item.MobMinLvl = (int)this.numericUpDown_Map_MinMobLvl.Value;
			item.Name = map.MapName;
			foreach (object obj in this.listBox_SelectedMaps.Items)
			{
				if (((Structures.EventBagMap)obj).ID == item.ID)
				{
					return;
				}
			}
			this.BagMapList.Add(item);
			this.listBox_SelectedMaps.SelectedIndex = -1;
			this.listBox_SelectedMaps.SelectedIndex = this.listBox_SelectedMaps.Items.Count - 1;
			if (!this.button_Map_Update.Enabled)
			{
				this.button_Map_Update.Enabled = true;
			}
			if (!this.button_RemoveMap.Enabled)
			{
				this.button_RemoveMap.Enabled = true;
			}
		}

		// Token: 0x06000491 RID: 1169 RVA: 0x0001F9F8 File Offset: 0x0001DBF8
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

		// Token: 0x06000492 RID: 1170 RVA: 0x0001FA74 File Offset: 0x0001DC74
		private void button_Item_Update_Click(object sender, EventArgs e)
		{
			this.DontWork = true;
			Structures.EventBagItem eventBagItem = (Structures.EventBagItem)this.listBox_AddedItems.SelectedItem;
			Structures.EventBagItem value = eventBagItem;
			value.Excellent = this.checkBox_Added_Exc.Checked;
			value.Luck = this.checkBox_Added_Luck.Checked;
			value.MaxLevel = (int)this.numericUpDown_Added_MaxLevel.Value;
			value.MinLevel = (int)this.numericUpDown_Added_MinLevel.Value;
			value.Option = this.checkBox_Added_Option.Checked;
			value.Skill = this.checkBox_Added_Skill.Checked;
			this.BagItemList[this.BagItemList.IndexOf(eventBagItem)] = value;
			this.DontWork = false;
		}

		// Token: 0x06000493 RID: 1171 RVA: 0x0001FB30 File Offset: 0x0001DD30
		private void button_Map_Update_Click(object sender, EventArgs e)
		{
			this.DontWork = true;
			Structures.EventBagMap eventBagMap = (Structures.EventBagMap)this.listBox_SelectedMaps.SelectedItem;
			Structures.EventBagMap value = eventBagMap;
			value.Drop = this.checkBox_Map_Drop.Checked;
			value.MobMaxLvl = (int)this.numericUpDown_Map_MaxMobLvl.Value;
			value.MobMinLvl = (int)this.numericUpDown_Map_MinMobLvl.Value;
			this.BagMapList[this.BagMapList.IndexOf(eventBagMap)] = value;
			this.DontWork = false;
		}

		// Token: 0x06000494 RID: 1172 RVA: 0x0001FBB8 File Offset: 0x0001DDB8
		private void button_RemoveMap_Click(object sender, EventArgs e)
		{
			if (this.listBox_SelectedMaps.SelectedIndex != -1)
			{
				Structures.EventBagMap item = (Structures.EventBagMap)this.listBox_SelectedMaps.SelectedItem;
				this.BagMapList.Remove(item);
				if (this.listBox_SelectedMaps.Items.Count < 1)
				{
					this.button_Map_Update.Enabled = false;
				}
			}
		}

		// Token: 0x06000495 RID: 1173 RVA: 0x0001FC10 File Offset: 0x0001DE10
		private void comboBox_Bag_ItemGroup_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.comboBox_Bag_ItemGroup.SelectedIndex != -1)
			{
				switch ((int)this.comboBox_Bag_ItemGroup.SelectedValue)
				{
				case 0:
					this.comboBox_Bag_ItemIndex.DisplayMember = "Name";
					this.comboBox_Bag_ItemIndex.ValueMember = "Index";
					this.comboBox_Bag_ItemIndex.DataSource = this.C_Swords;
					return;
				case 1:
					this.comboBox_Bag_ItemIndex.DisplayMember = "Name";
					this.comboBox_Bag_ItemIndex.ValueMember = "Index";
					this.comboBox_Bag_ItemIndex.DataSource = this.C_Axes;
					return;
				case 2:
					this.comboBox_Bag_ItemIndex.DisplayMember = "Name";
					this.comboBox_Bag_ItemIndex.ValueMember = "Index";
					this.comboBox_Bag_ItemIndex.DataSource = this.C_MacesScepters;
					return;
				case 3:
					this.comboBox_Bag_ItemIndex.DisplayMember = "Name";
					this.comboBox_Bag_ItemIndex.ValueMember = "Index";
					this.comboBox_Bag_ItemIndex.DataSource = this.C_Spears;
					return;
				case 4:
					this.comboBox_Bag_ItemIndex.DisplayMember = "Name";
					this.comboBox_Bag_ItemIndex.ValueMember = "Index";
					this.comboBox_Bag_ItemIndex.DataSource = this.C_BowsCrossBows;
					return;
				case 5:
					this.comboBox_Bag_ItemIndex.DisplayMember = "Name";
					this.comboBox_Bag_ItemIndex.ValueMember = "Index";
					this.comboBox_Bag_ItemIndex.DataSource = this.C_Staffs;
					return;
				case 6:
					this.comboBox_Bag_ItemIndex.DisplayMember = "Name";
					this.comboBox_Bag_ItemIndex.ValueMember = "Index";
					this.comboBox_Bag_ItemIndex.DataSource = this.C_Shields;
					return;
				case 7:
					this.comboBox_Bag_ItemIndex.DisplayMember = "Name";
					this.comboBox_Bag_ItemIndex.ValueMember = "Index";
					this.comboBox_Bag_ItemIndex.DataSource = this.C_Helms;
					return;
				case 8:
					this.comboBox_Bag_ItemIndex.DisplayMember = "Name";
					this.comboBox_Bag_ItemIndex.ValueMember = "Index";
					this.comboBox_Bag_ItemIndex.DataSource = this.C_Armors;
					return;
				case 9:
					this.comboBox_Bag_ItemIndex.DisplayMember = "Name";
					this.comboBox_Bag_ItemIndex.ValueMember = "Index";
					this.comboBox_Bag_ItemIndex.DataSource = this.C_Pants;
					return;
				case 10:
					this.comboBox_Bag_ItemIndex.DisplayMember = "Name";
					this.comboBox_Bag_ItemIndex.ValueMember = "Index";
					this.comboBox_Bag_ItemIndex.DataSource = this.C_Gloves;
					return;
				case 11:
					this.comboBox_Bag_ItemIndex.DisplayMember = "Name";
					this.comboBox_Bag_ItemIndex.ValueMember = "Index";
					this.comboBox_Bag_ItemIndex.DataSource = this.C_Boots;
					return;
				case 12:
					this.comboBox_Bag_ItemIndex.DisplayMember = "Name";
					this.comboBox_Bag_ItemIndex.ValueMember = "Index";
					this.comboBox_Bag_ItemIndex.DataSource = this.C_WingsSkillsSeedsOthers;
					return;
				case 13:
					this.comboBox_Bag_ItemIndex.DisplayMember = "Name";
					this.comboBox_Bag_ItemIndex.ValueMember = "Index";
					this.comboBox_Bag_ItemIndex.DataSource = this.C_Others1;
					return;
				case 14:
					this.comboBox_Bag_ItemIndex.DisplayMember = "Name";
					this.comboBox_Bag_ItemIndex.ValueMember = "Index";
					this.comboBox_Bag_ItemIndex.DataSource = this.C_Others2;
					return;
				case 15:
					this.comboBox_Bag_ItemIndex.DisplayMember = "Name";
					this.comboBox_Bag_ItemIndex.ValueMember = "Index";
					this.comboBox_Bag_ItemIndex.DataSource = this.C_Scrolls;
					break;
				default:
					return;
				}
			}
		}

		// Token: 0x06000497 RID: 1175 RVA: 0x0001FFC4 File Offset: 0x0001E1C4
		private void EventBagEditor_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.OpenForms["Form1"].WindowState = FormWindowState.Normal;
		}

		// Token: 0x06000498 RID: 1176 RVA: 0x0001FFDC File Offset: 0x0001E1DC
		private void EventBagEditor_Load(object sender, EventArgs e)
		{
			Form1 form = (Form1)Application.OpenForms[0];
			this.isEx700ItemList = (form.isEx700ItemList ? 1 : 0);
			this.strct.initMapListBox(ref this.listBox_MapSelection, ref this.MapName);
			this.listBox_SelectedMaps.DataSource = this.BagMapList;
			this.listBox_SelectedMaps.ValueMember = "ID";
			this.listBox_SelectedMaps.DisplayMember = "Name";
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
			this.comboBox_Bag_ItemGroup.DisplayMember = "GroupName";
			this.comboBox_Bag_ItemGroup.ValueMember = "Group";
			this.comboBox_Bag_ItemGroup.DataSource = this.C_Groups;
			this.listBox_AddedItems.DataSource = this.BagItemList;
			this.listBox_AddedItems.DisplayMember = "Name";
			Application.OpenForms["Form1"].WindowState = FormWindowState.Minimized;
			base.WindowState = FormWindowState.Normal;
			base.TopMost = true;
			base.TopMost = false;
			base.BringToFront();
			base.Focus();
		}

		// Token: 0x0600049A RID: 1178 RVA: 0x00022A20 File Offset: 0x00020C20
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

		// Token: 0x0600049B RID: 1179 RVA: 0x00022E34 File Offset: 0x00021034
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

		// Token: 0x0600049C RID: 1180 RVA: 0x00022F54 File Offset: 0x00021154
		private void listBox_AddedItems_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.listBox_AddedItems.SelectedIndex != -1 & !this.DontWork)
			{
				Structures.EventBagItem eventBagItem = (Structures.EventBagItem)this.listBox_AddedItems.SelectedItem;
				this.numericUpDown_Added_MaxLevel.Value = eventBagItem.MaxLevel;
				this.numericUpDown_Added_MinLevel.Value = eventBagItem.MinLevel;
				this.checkBox_Added_Exc.Checked = eventBagItem.Excellent;
				this.checkBox_Added_Luck.Checked = eventBagItem.Luck;
				this.checkBox_Added_Option.Checked = eventBagItem.Option;
				this.checkBox_Added_Skill.Checked = eventBagItem.Skill;
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

		// Token: 0x0600049D RID: 1181 RVA: 0x000230F0 File Offset: 0x000212F0
		private void listBox_SelectedMaps_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.listBox_SelectedMaps.SelectedIndex != -1 & !this.DontWork)
			{
				Structures.EventBagMap eventBagMap = (Structures.EventBagMap)this.listBox_SelectedMaps.SelectedItem;
				this.numericUpDown_Map_MaxMobLvl.Value = eventBagMap.MobMaxLvl;
				this.numericUpDown_Map_MinMobLvl.Value = eventBagMap.MobMinLvl;
				this.checkBox_Map_Drop.Checked = eventBagMap.Drop;
			}
		}

		// Token: 0x0600049E RID: 1182 RVA: 0x0002316C File Offset: 0x0002136C
		private void newToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.button_Item_Update.Enabled = false;
			this.button_Item_Remove.Enabled = false;
			this.button_Map_Update.Enabled = false;
			this.button_RemoveMap.Enabled = false;
			this.BagMapList.Clear();
			this.BagDrop = default(Structures.EventBagDrop);
			this.BagItemList.Clear();
			this.numericUpDown_Map_MinMobLvl.Value = 0m;
			this.numericUpDown_Map_MaxMobLvl.Value = 0m;
			this.numericUpDown_DropRate.Value = 0m;
			this.numericUpDown_ExcDropRate.Value = 0m;
			this.numericUpDown_BagDropRate.Value = 0m;
			this.numericUpDown_BagZen.Value = 0m;
			this.numericUpDown_Add_MinLevel.Value = 0m;
			this.numericUpDown_Add_MaxLevel.Value = 0m;
			this.numericUpDown_Added_MinLevel.Value = 0m;
			this.numericUpDown_Added_MaxLevel.Value = 0m;
			this.checkBox_Map_Drop.Checked = false;
			this.checkBox_Add_Skill.Checked = false;
			this.checkBox_Add_Luck.Checked = false;
			this.checkBox_Add_Option.Checked = false;
			this.checkBox_Add_Exc.Checked = false;
			this.checkBox_Added_Skill.Checked = false;
			this.checkBox_Added_Luck.Checked = false;
			this.checkBox_Added_Option.Checked = false;
			this.checkBox_Added_Exc.Checked = false;
			this.label_ItemCount.Text = "0";
			this.textBox_EventName.Text = "";
		}

		// Token: 0x0600049F RID: 1183 RVA: 0x00023304 File Offset: 0x00021504
		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Title = "Select the EventBag (txt) file to load",
				Filter = "TXT files (*.txt)|*.txt"
			};
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				string[] array = openFileDialog.FileName.Split(new char[]
				{
					'\\'
				});
				this.label_FileName.Text = array[array.Length - 1];
				this.BagMapList.Clear();
				this.BagDrop = default(Structures.EventBagDrop);
				this.BagItemList.Clear();
				this.label_ItemCount.Text = "0";
				this.strct.ReadEventBagFile(openFileDialog.FileName, ref this.BagMapList, ref this.BagDrop, ref this.BagItemList, this.ItemName, this.MapName);
				if (this.listBox_SelectedMaps.Items.Count > 0)
				{
					this.listBox_SelectedMaps.SelectedIndex = -1;
					this.listBox_SelectedMaps.SelectedIndex = 0;
					this.button_Map_Update.Enabled = true;
					this.button_RemoveMap.Enabled = true;
				}
				if (this.listBox_AddedItems.Items.Count > 0)
				{
					this.listBox_AddedItems.SelectedIndex = -1;
					this.listBox_AddedItems.SelectedIndex = 0;
					this.button_Item_Update.Enabled = true;
					this.button_Item_Remove.Enabled = true;
				}
				double num = this.BagDrop.BagDropRate / 1000.0;
				this.textBox_EventName.Text = this.BagDrop.Name;
				this.numericUpDown_BagZen.Value = this.BagDrop.Zen;
				this.numericUpDown_DropRate.Value = (decimal)this.BagDrop.ItemDropRate;
				this.numericUpDown_ExcDropRate.Value = (decimal)this.BagDrop.ExcDropRate / 1000m * 100m;
				this.numericUpDown_BagLevel.Value = this.BagDrop.BagLevel;
				this.numericUpDown_BagDropRate.Value = (decimal)(this.BagDrop.BagDropRate / 1000.0 * 100.0);
				this.comboBox_Bag_ItemGroup.SelectedValue = this.BagDrop.BagGroup;
				this.comboBox_Bag_ItemIndex.SelectedValue = this.BagDrop.BagIndex;
			}
		}

		// Token: 0x060004A0 RID: 1184 RVA: 0x00023568 File Offset: 0x00021768
		private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog
			{
				Title = "Select a location to save the EventBag",
				Filter = "TXT files (*.txt)|*.txt"
			};
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				string[] array = saveFileDialog.FileName.Split(new char[]
				{
					'\\'
				});
				this.label_FileName.Text = array[array.Length - 1];
				StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);
				streamWriter.WriteLine("//Created by MU.ToolKit coded by TopReal.IT");
				streamWriter.WriteLine();
				streamWriter.WriteLine("0");
				streamWriter.WriteLine("//\tMapID\tDrop\tMinMobLvl\tMaxMobLvl\tName");
				foreach (Structures.EventBagMap eventBagMap in this.BagMapList)
				{
					streamWriter.WriteLine("\t{0}\t{1}\t{2}\t\t{3}\t\t//{4}", new object[]
					{
						eventBagMap.ID,
						Convert.ToInt16(eventBagMap.Drop),
						eventBagMap.MobMinLvl,
						eventBagMap.MobMaxLvl,
						eventBagMap.Name
					});
				}
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				this.BagDrop.Name = this.textBox_EventName.Text;
				this.BagDrop.Zen = (int)this.numericUpDown_BagZen.Value;
				this.BagDrop.ItemDropRate = (double)Convert.ToInt32(this.numericUpDown_DropRate.Value);
				this.BagDrop.ExcDropRate = (double)Convert.ToInt32(this.numericUpDown_ExcDropRate.Value * 100m);
				this.BagDrop.BagGroup = (int)this.comboBox_Bag_ItemGroup.SelectedValue;
				this.BagDrop.BagIndex = (int)this.comboBox_Bag_ItemIndex.SelectedValue;
				this.BagDrop.BagLevel = (int)this.numericUpDown_BagLevel.Value;
				this.BagDrop.BagDropRate = (double)Convert.ToInt32(this.numericUpDown_BagDropRate.Value * 100m);
				streamWriter.WriteLine("1");
				streamWriter.WriteLine("//\tEventName\tZen\t\tEventItemGroup\tEventItemIndex\tEventItemLevel\tEventItemDR\tItemDR\tExItemDR");
				streamWriter.WriteLine("\t{0}\t{1}\t\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}", new object[]
				{
					"\"" + this.BagDrop.Name + "\"",
					this.BagDrop.Zen,
					this.BagDrop.BagGroup,
					this.BagDrop.BagIndex,
					this.BagDrop.BagLevel,
					this.BagDrop.BagDropRate,
					this.BagDrop.ItemDropRate,
					this.BagDrop.ExcDropRate
				});
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				streamWriter.WriteLine("2");
				streamWriter.WriteLine("//\tGroup\tIndex\tMinLvl\tMaxLvl\tSkill\tLuck\tOpt\tExc\tName");
				foreach (Structures.EventBagItem eventBagItem in this.BagItemList)
				{
					streamWriter.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t//{8}", new object[]
					{
						eventBagItem.Group,
						eventBagItem.Index,
						eventBagItem.MinLevel,
						eventBagItem.MaxLevel,
						Convert.ToInt16(eventBagItem.Skill),
						Convert.ToInt16(eventBagItem.Luck),
						Convert.ToInt16(eventBagItem.Option),
						Convert.ToInt16(eventBagItem.Excellent),
						eventBagItem.Name
					});
				}
				streamWriter.WriteLine("end");
				streamWriter.Flush();
				streamWriter.Close();
			}
		}

		// Token: 0x04000249 RID: 585
		private Structures.EventBagDrop BagDrop = default(Structures.EventBagDrop);

		// Token: 0x0400024A RID: 586
		private BindingList<Structures.EventBagItem> BagItemList = new BindingList<Structures.EventBagItem>();

		// Token: 0x0400024B RID: 587
		private BindingList<Structures.EventBagMap> BagMapList = new BindingList<Structures.EventBagMap>();

		// Token: 0x04000252 RID: 594
		private List<Structures.UniItem> C_Armors = new List<Structures.UniItem>();

		// Token: 0x04000253 RID: 595
		private List<Structures.UniItem> C_Axes = new List<Structures.UniItem>();

		// Token: 0x04000254 RID: 596
		private List<Structures.UniItem> C_Boots = new List<Structures.UniItem>();

		// Token: 0x04000255 RID: 597
		private List<Structures.UniItem> C_BowsCrossBows = new List<Structures.UniItem>();

		// Token: 0x04000256 RID: 598
		private List<Structures.UniItem> C_Gloves = new List<Structures.UniItem>();

		// Token: 0x04000257 RID: 599
		private List<Structures.c_Groups> C_Groups = new List<Structures.c_Groups>();

		// Token: 0x04000258 RID: 600
		private List<Structures.UniItem> C_Helms = new List<Structures.UniItem>();

		// Token: 0x04000259 RID: 601
		private List<Structures.UniItem> C_MacesScepters = new List<Structures.UniItem>();

		// Token: 0x0400025A RID: 602
		private List<Structures.UniItem> C_Others1 = new List<Structures.UniItem>();

		// Token: 0x0400025B RID: 603
		private List<Structures.UniItem> C_Others2 = new List<Structures.UniItem>();

		// Token: 0x0400025C RID: 604
		private List<Structures.UniItem> C_Pants = new List<Structures.UniItem>();

		// Token: 0x0400025D RID: 605
		private List<Structures.UniItem> C_Scrolls = new List<Structures.UniItem>();

		// Token: 0x0400025E RID: 606
		private List<Structures.UniItem> C_Shields = new List<Structures.UniItem>();

		// Token: 0x0400025F RID: 607
		private List<Structures.UniItem> C_Spears = new List<Structures.UniItem>();

		// Token: 0x04000260 RID: 608
		private List<Structures.UniItem> C_Staffs = new List<Structures.UniItem>();

		// Token: 0x04000261 RID: 609
		private List<Structures.UniItem> C_Swords = new List<Structures.UniItem>();

		// Token: 0x04000262 RID: 610
		private List<Structures.UniItem> C_WingsSkillsSeedsOthers = new List<Structures.UniItem>();

		// Token: 0x04000270 RID: 624
		private bool DontWork;

		// Token: 0x04000279 RID: 633
		private int isEx700ItemList;

		// Token: 0x0400027A RID: 634
		private string[,] ItemName = new string[16, 513];

		// Token: 0x0400027B RID: 635
		private List<Structures.UniItem> L_Armors = new List<Structures.UniItem>();

		// Token: 0x0400027C RID: 636
		private List<Structures.UniItem> L_Axes = new List<Structures.UniItem>();

		// Token: 0x0400027D RID: 637
		private List<Structures.UniItem> L_Boots = new List<Structures.UniItem>();

		// Token: 0x0400027E RID: 638
		private List<Structures.UniItem> L_BowsCrossBows = new List<Structures.UniItem>();

		// Token: 0x0400027F RID: 639
		private List<Structures.UniItem> L_Gloves = new List<Structures.UniItem>();

		// Token: 0x04000280 RID: 640
		private List<Structures.c_Groups> L_Groups = new List<Structures.c_Groups>();

		// Token: 0x04000281 RID: 641
		private List<Structures.UniItem> L_Helms = new List<Structures.UniItem>();

		// Token: 0x04000282 RID: 642
		private List<Structures.UniItem> L_MacesScepters = new List<Structures.UniItem>();

		// Token: 0x04000283 RID: 643
		private List<Structures.UniItem> L_Others1 = new List<Structures.UniItem>();

		// Token: 0x04000284 RID: 644
		private List<Structures.UniItem> L_Others2 = new List<Structures.UniItem>();

		// Token: 0x04000285 RID: 645
		private List<Structures.UniItem> L_Pants = new List<Structures.UniItem>();

		// Token: 0x04000286 RID: 646
		private List<Structures.UniItem> L_Scrolls = new List<Structures.UniItem>();

		// Token: 0x04000287 RID: 647
		private List<Structures.UniItem> L_Shields = new List<Structures.UniItem>();

		// Token: 0x04000288 RID: 648
		private List<Structures.UniItem> L_Spears = new List<Structures.UniItem>();

		// Token: 0x04000289 RID: 649
		private List<Structures.UniItem> L_Staffs = new List<Structures.UniItem>();

		// Token: 0x0400028A RID: 650
		private List<Structures.UniItem> L_Swords = new List<Structures.UniItem>();

		// Token: 0x0400028B RID: 651
		private List<Structures.UniItem> L_WingsSkillsSeedsOthers = new List<Structures.UniItem>();

		// Token: 0x0400029F RID: 671
		private int LastSelectedItemIndex;

		// Token: 0x040002A5 RID: 677
		private string[] MapName = new string[255];

		// Token: 0x040002B7 RID: 695
		private Structures strct = new Structures();
	}
}
