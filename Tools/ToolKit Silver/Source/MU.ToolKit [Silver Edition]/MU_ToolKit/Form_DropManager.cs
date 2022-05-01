using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MU_ToolKit.Properties;

namespace MU_ToolKit
{
	// Token: 0x0200002A RID: 42
	public partial class Form_DropManager : Form
	{
		// Token: 0x060005F2 RID: 1522 RVA: 0x00065434 File Offset: 0x00063634
		public Form_DropManager()
		{
			this.InitializeComponent();
		}

		// Token: 0x060005F3 RID: 1523 RVA: 0x00065593 File Offset: 0x00063793
		private void button_Existing_RemoveSelected_Click(object sender, EventArgs e)
		{
			if (this.listBox_DropItems.SelectedIndex != -1)
			{
				this.Items.Remove((Structures.IGCDropManagerFile)this.listBox_DropItems.SelectedItem);
			}
		}

		// Token: 0x060005F4 RID: 1524 RVA: 0x000655C0 File Offset: 0x000637C0
		private void button_Existing_UpdateSelected_Click(object sender, EventArgs e)
		{
			if (this.listBox_DropItems.SelectedIndex != -1)
			{
				Structures.IGCDropManagerFile value = default(Structures.IGCDropManagerFile);
				value = (Structures.IGCDropManagerFile)this.listBox_DropItems.SelectedItem;
				value.Ancient = this.comboBox_Existing_Ancient.SelectedValue.ToString();
				value.DropRate = Convert.ToUInt32(this.numericUpDown_Existing_DropRate.Value * 100m).ToString();
				value.Durability = this.numericUpDown_Existing_Durability.Value.ToString();
				value.Exc = (this.checkBox_Existing_RandomExc.Checked ? "-1" : this.GetExcVal(this.checkBox_Existing_ExcOpt1, this.checkBox_Existing_ExcOpt2, this.checkBox_Existing_ExcOpt3, this.checkBox_Existing_ExcOpt4, this.checkBox_Existing_ExcOpt5, this.checkBox_Existing_ExcOpt6));
				value.Luck = Convert.ToInt16(this.checkBox_Existing_Luck.Checked).ToString();
				value.MapID = this.comboBox_Existing_Map.SelectedValue.ToString();
				value.MaxLvl = this.numericUpDown_Existing_ItemMaxLv.Value.ToString();
				value.MaxMobLvl = this.numericUpDown_Existing_MobMaxLv.Value.ToString();
				value.MinLvl = this.numericUpDown_Existing_ItemMinLv.Value.ToString();
				value.MinMobLvl = this.numericUpDown_Existing_MobMinLv.Value.ToString();
				value.MobID = this.comboBox_Existing_Mob.SelectedValue.ToString();
				value.Opt = this.comboBox_Existing_Opt.SelectedValue.ToString();
				value.Skill = Convert.ToInt16(this.checkBox_Existing_Skill.Checked).ToString();
				this.Items[this.Items.IndexOf((Structures.IGCDropManagerFile)this.listBox_DropItems.SelectedItem)] = value;
			}
		}

		// Token: 0x060005F5 RID: 1525 RVA: 0x000657B0 File Offset: 0x000639B0
		private void button_New_Add_Click(object sender, EventArgs e)
		{
			if (this.listBox_New_iGroup.SelectedIndex != -1 && this.listBox_New_iIndex.SelectedIndex != -1)
			{
				Structures.IGCDropManagerFile item = new Structures.IGCDropManagerFile
				{
					Ancient = this.comboBox_New_Ancient.SelectedValue.ToString(),
					DropRate = Convert.ToUInt32(this.numericUpDown_New_DropRate.Value * 100m).ToString(),
					Durability = this.numericUpDown_New_Durability.Value.ToString(),
					Exc = (this.checkBox_New_RandomExc.Checked ? "-1" : this.GetExcVal(this.checkBox_New_ExcOpt1, this.checkBox_New_ExcOpt2, this.checkBox_New_ExcOpt3, this.checkBox_New_ExcOpt4, this.checkBox_New_ExcOpt5, this.checkBox_New_ExcOpt6)),
					Luck = Convert.ToInt16(this.checkBox_New_Luck.Checked).ToString(),
					MapID = this.comboBox_New_Map.SelectedValue.ToString(),
					MaxLvl = this.numericUpDown_New_ItemMaxLv.Value.ToString(),
					MaxMobLvl = this.numericUpDown_New_MobMaxLv.Value.ToString(),
					MinLvl = this.numericUpDown_New_ItemMinLv.Value.ToString(),
					MinMobLvl = this.numericUpDown_New_MobMinLv.Value.ToString(),
					MobID = this.comboBox_New_Mob.SelectedValue.ToString(),
					Opt = this.comboBox_New_Opt.SelectedValue.ToString(),
					Skill = Convert.ToInt16(this.checkBox_New_Skill.Checked).ToString(),
					iGroup = this.listBox_New_iGroup.SelectedValue.ToString(),
					iIndex = this.listBox_New_iIndex.SelectedValue.ToString()
				};
				short num = Convert.ToInt16(item.iGroup);
				item.Name = this.GetItemName[(int)num, (int)Convert.ToInt16(item.iIndex)];
				this.Items.Add(item);
				this.listBox_DropItems.SelectedIndex = this.Items.Count - 1;
			}
		}

		// Token: 0x060005F6 RID: 1526 RVA: 0x000659FC File Offset: 0x00063BFC
		private void comboBox_VerifyValidItem(object sender, EventArgs e)
		{
			ComboBox comboBox = (ComboBox)sender;
			if (comboBox.SelectedItem == null)
			{
				comboBox.SelectedIndex = 0;
			}
		}

		// Token: 0x060005F8 RID: 1528 RVA: 0x00065A3E File Offset: 0x00063C3E
		private void Form_DropManager_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.OpenForms["Form1"].WindowState = FormWindowState.Normal;
		}

		// Token: 0x060005F9 RID: 1529 RVA: 0x00065A58 File Offset: 0x00063C58
		private void Form_DropManager_Load(object sender, EventArgs e)
		{
			Form1 form = (Form1)Application.OpenForms[0];
			int num = form.isEx700ItemList ? 1 : 0;
			string[,] array = null;
			if (num == 1)
			{
				this.strc.ReadItemList("Data\\ItemListSettings_ex700.ini", true, ref this.L_Groups, ref this.L_Swords, ref this.L_Axes, ref this.L_MacesScepters, ref this.L_Spears, ref this.L_BowsCrossBows, ref this.L_Staffs, ref this.L_Shields, ref this.L_Helms, ref this.L_Armors, ref this.L_Pants, ref this.L_Gloves, ref this.L_Boots, ref this.L_WingsSkillsSeedsOthers, ref this.L_Others1, ref this.L_Others2, ref this.L_Scrolls, ref this.GetItemName, ref array);
			}
			else
			{
				this.strc.ReadItemList("Data\\ItemListSettings.ini", false, ref this.L_Groups, ref this.L_Swords, ref this.L_Axes, ref this.L_MacesScepters, ref this.L_Spears, ref this.L_BowsCrossBows, ref this.L_Staffs, ref this.L_Shields, ref this.L_Helms, ref this.L_Armors, ref this.L_Pants, ref this.L_Gloves, ref this.L_Boots, ref this.L_WingsSkillsSeedsOthers, ref this.L_Others1, ref this.L_Others2, ref this.L_Scrolls, ref this.GetItemName, ref array);
			}
			this.strc.Setc_OptionData(ref this.c_OptionDatas_Existing);
			this.c_OptionDatas_New = new List<Structures.c_OptionData>(this.c_OptionDatas_Existing);
			this.comboBox_Existing_Opt.DataSource = this.c_OptionDatas_Existing;
			this.comboBox_Existing_Opt.DisplayMember = "Name";
			this.comboBox_Existing_Opt.ValueMember = "ID";
			this.comboBox_New_Opt.DataSource = this.c_OptionDatas_New;
			this.comboBox_New_Opt.DisplayMember = "Name";
			this.comboBox_New_Opt.ValueMember = "ID";
			this.Setc_AncientData(ref this.c_AncientDatas_Existing);
			this.c_AncientDatas_New = new BindingList<Structures.c_AncientData>(this.c_AncientDatas_Existing);
			this.comboBox_New_Ancient.DataSource = this.c_AncientDatas_New;
			this.comboBox_New_Ancient.ValueMember = "ID";
			this.comboBox_New_Ancient.DisplayMember = "Name";
			this.comboBox_Existing_Ancient.DataSource = this.c_AncientDatas_Existing;
			this.comboBox_Existing_Ancient.ValueMember = "ID";
			this.comboBox_Existing_Ancient.DisplayMember = "Name";
			this.listBox_DropItems.DataSource = this.Items;
			this.listBox_DropItems.DisplayMember = "Name";
			this.listBox_DropItems.ValueMember = "Name";
			Structures.Map item = new Structures.Map
			{
				MapCode = -1,
				MapName = "[All Maps]"
			};
			this.mMapList_Existing.Add(item);
			this.mMapList_New.Add(item);
			this.strc.initMapList(ref this.comboBox_Existing_Map, ref this.mMapList_Existing);
			this.strc.initMapList(ref this.comboBox_New_Map, ref this.mMapList_New);
			Structures.Monster item2 = new Structures.Monster
			{
				ID = -1,
				Name = "[All Mobs]"
			};
			this.Monster_Existing.Add(item2);
			this.Monster_New.Add(item2);
			this.ReadMonsterFile("Data\\MSB\\Monster.txt");
			this.comboBox_Existing_Ancient.SelectedIndex = 0;
			this.comboBox_Existing_Opt.SelectedIndex = 0;
			this.radioButton_Existing_ExcWeapon.Checked = true;
			this.comboBox_New_Ancient.SelectedIndex = 0;
			this.comboBox_New_Opt.SelectedIndex = 0;
			this.radioButton_New_ExcWeapon.Checked = true;
			this.listBox_New_iGroup.DisplayMember = "GroupName";
			this.listBox_New_iGroup.ValueMember = "Group";
			this.listBox_New_iGroup.DataSource = this.L_Groups;
			Application.OpenForms["Form1"].WindowState = FormWindowState.Minimized;
			base.WindowState = FormWindowState.Normal;
			base.TopMost = true;
			base.TopMost = false;
			base.BringToFront();
			base.Focus();
		}

		// Token: 0x060005FA RID: 1530 RVA: 0x00065E1C File Offset: 0x0006401C
		private string GetExcVal(CheckBox cb1, CheckBox cb2, CheckBox cb3, CheckBox cb4, CheckBox cb5, CheckBox cb6)
		{
			int num = 0;
			num = (cb1.Checked ? (num + 1) : num);
			num = (cb2.Checked ? (num + 2) : num);
			num = (cb3.Checked ? (num + 4) : num);
			num = (cb4.Checked ? (num + 8) : num);
			num = (cb5.Checked ? (num + 16) : num);
			return (cb6.Checked ? (num + 32) : num).ToString();
		}

		// Token: 0x060005FB RID: 1531 RVA: 0x00065E94 File Offset: 0x00064094
		private string[] GetTrimmedSplitString(string line)
		{
			if (line.Contains('"'))
			{
				string[] array = line.Split(new char[]
				{
					'"'
				});
				string text = array[0];
				string text2 = array[1];
				string text3 = array[2];
				line = string.Concat(new string[]
				{
					text,
					"\"",
					text2.Replace(" ", "$"),
					"\"",
					text3
				});
			}
			string[] array2 = line.Replace(" ", "\t").Split(new char[]
			{
				'\t'
			});
			List<string> list = new List<string>();
			for (int i = 0; i < array2.Length; i++)
			{
				if (array2[i].Length != 0)
				{
					list.Add(array2[i]);
				}
			}
			if (list.Count == 0)
			{
				return null;
			}
			string[] array3 = new string[list.Count];
			for (int j = 0; j < list.Count; j++)
			{
				array3[j] = list[j];
			}
			return array3;
		}

		// Token: 0x060005FD RID: 1533 RVA: 0x00069AEC File Offset: 0x00067CEC
		private void listBox_DropItems_SelectedIndexChanged(object sender, EventArgs e)
		{
			ListBox listBox = (ListBox)sender;
			if (listBox.SelectedIndex != -1)
			{
				Structures.IGCDropManagerFile igcdropManagerFile = (Structures.IGCDropManagerFile)listBox.SelectedItem;
				this.numericUpDown_Existing_ItemMinLv.Value = Convert.ToUInt16(igcdropManagerFile.MinLvl);
				this.numericUpDown_Existing_ItemMaxLv.Value = Convert.ToUInt16(igcdropManagerFile.MaxLvl);
				this.comboBox_Existing_Opt.SelectedValue = Convert.ToInt32(igcdropManagerFile.Opt);
				this.comboBox_Existing_Ancient.SelectedValue = Convert.ToInt32(igcdropManagerFile.Ancient);
				this.numericUpDown_Existing_Durability.Value = Convert.ToUInt16(igcdropManagerFile.Durability);
				this.checkBox_Existing_Skill.Checked = (igcdropManagerFile.Skill == "1");
				this.checkBox_Existing_Luck.Checked = (igcdropManagerFile.Luck == "1");
				this.checkBox_Existing_RandomExc.Checked = (igcdropManagerFile.Exc == "-1");
				if (!this.checkBox_Existing_RandomExc.Checked)
				{
					this.checkBox_Existing_ExcOpt1.Checked = ((Convert.ToUInt16(igcdropManagerFile.Exc) & 1) == 1);
					this.checkBox_Existing_ExcOpt2.Checked = ((Convert.ToUInt16(igcdropManagerFile.Exc) >> 1 & 1) == 1);
					this.checkBox_Existing_ExcOpt3.Checked = ((Convert.ToUInt16(igcdropManagerFile.Exc) >> 2 & 1) == 1);
					this.checkBox_Existing_ExcOpt4.Checked = ((Convert.ToUInt16(igcdropManagerFile.Exc) >> 3 & 1) == 1);
					this.checkBox_Existing_ExcOpt5.Checked = ((Convert.ToUInt16(igcdropManagerFile.Exc) >> 4 & 1) == 1);
					this.checkBox_Existing_ExcOpt6.Checked = ((Convert.ToUInt16(igcdropManagerFile.Exc) >> 5 & 1) == 1);
				}
				else
				{
					this.checkBox_Existing_ExcOpt1.Checked = false;
					this.checkBox_Existing_ExcOpt2.Checked = false;
					this.checkBox_Existing_ExcOpt3.Checked = false;
					this.checkBox_Existing_ExcOpt4.Checked = false;
					this.checkBox_Existing_ExcOpt5.Checked = false;
					this.checkBox_Existing_ExcOpt6.Checked = false;
				}
				this.comboBox_Existing_Map.SelectedValue = Convert.ToInt32(igcdropManagerFile.MapID);
				this.comboBox_Existing_Mob.SelectedValue = Convert.ToInt32(igcdropManagerFile.MobID);
				this.numericUpDown_Existing_MobMinLv.Value = Convert.ToUInt16(igcdropManagerFile.MinMobLvl);
				this.numericUpDown_Existing_MobMaxLv.Value = Convert.ToUInt16(igcdropManagerFile.MaxMobLvl);
				this.numericUpDown_Existing_DropRate.Value = Convert.ToDecimal(igcdropManagerFile.DropRate) / 100m;
			}
		}

		// Token: 0x060005FE RID: 1534 RVA: 0x00069D98 File Offset: 0x00067F98
		private void listBox_New_iGroup_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.listBox_New_iGroup.SelectedIndex != -1)
			{
				this.DontWork = true;
				switch ((int)this.listBox_New_iGroup.SelectedValue)
				{
				case 0:
					this.listBox_New_iIndex.DisplayMember = "Name";
					this.listBox_New_iIndex.ValueMember = "Index";
					this.listBox_New_iIndex.DataSource = this.L_Swords;
					break;
				case 1:
					this.listBox_New_iIndex.DisplayMember = "Name";
					this.listBox_New_iIndex.ValueMember = "Index";
					this.listBox_New_iIndex.DataSource = this.L_Axes;
					break;
				case 2:
					this.listBox_New_iIndex.DisplayMember = "Name";
					this.listBox_New_iIndex.ValueMember = "Index";
					this.listBox_New_iIndex.DataSource = this.L_MacesScepters;
					break;
				case 3:
					this.listBox_New_iIndex.DisplayMember = "Name";
					this.listBox_New_iIndex.ValueMember = "Index";
					this.listBox_New_iIndex.DataSource = this.L_Spears;
					break;
				case 4:
					this.listBox_New_iIndex.DisplayMember = "Name";
					this.listBox_New_iIndex.ValueMember = "Index";
					this.listBox_New_iIndex.DataSource = this.L_BowsCrossBows;
					break;
				case 5:
					this.listBox_New_iIndex.DisplayMember = "Name";
					this.listBox_New_iIndex.ValueMember = "Index";
					this.listBox_New_iIndex.DataSource = this.L_Staffs;
					break;
				case 6:
					this.listBox_New_iIndex.DisplayMember = "Name";
					this.listBox_New_iIndex.ValueMember = "Index";
					this.listBox_New_iIndex.DataSource = this.L_Shields;
					break;
				case 7:
					this.listBox_New_iIndex.DisplayMember = "Name";
					this.listBox_New_iIndex.ValueMember = "Index";
					this.listBox_New_iIndex.DataSource = this.L_Helms;
					break;
				case 8:
					this.listBox_New_iIndex.DisplayMember = "Name";
					this.listBox_New_iIndex.ValueMember = "Index";
					this.listBox_New_iIndex.DataSource = this.L_Armors;
					break;
				case 9:
					this.listBox_New_iIndex.DisplayMember = "Name";
					this.listBox_New_iIndex.ValueMember = "Index";
					this.listBox_New_iIndex.DataSource = this.L_Pants;
					break;
				case 10:
					this.listBox_New_iIndex.DisplayMember = "Name";
					this.listBox_New_iIndex.ValueMember = "Index";
					this.listBox_New_iIndex.DataSource = this.L_Gloves;
					break;
				case 11:
					this.listBox_New_iIndex.DisplayMember = "Name";
					this.listBox_New_iIndex.ValueMember = "Index";
					this.listBox_New_iIndex.DataSource = this.L_Boots;
					break;
				case 12:
					this.listBox_New_iIndex.DisplayMember = "Name";
					this.listBox_New_iIndex.ValueMember = "Index";
					this.listBox_New_iIndex.DataSource = this.L_WingsSkillsSeedsOthers;
					break;
				case 13:
					this.listBox_New_iIndex.DisplayMember = "Name";
					this.listBox_New_iIndex.ValueMember = "Index";
					this.listBox_New_iIndex.DataSource = this.L_Others1;
					break;
				case 14:
					this.listBox_New_iIndex.DisplayMember = "Name";
					this.listBox_New_iIndex.ValueMember = "Index";
					this.listBox_New_iIndex.DataSource = this.L_Others2;
					break;
				case 15:
					this.listBox_New_iIndex.DisplayMember = "Name";
					this.listBox_New_iIndex.ValueMember = "Index";
					this.listBox_New_iIndex.DataSource = this.L_Scrolls;
					break;
				}
				this.listBox_New_iIndex.SelectedIndex = -1;
				this.DontWork = false;
				if (this.LastSelectedItemIndex <= this.listBox_New_iIndex.Items.Count - 1)
				{
					this.listBox_New_iIndex.SelectedIndex = this.LastSelectedItemIndex;
					return;
				}
				this.listBox_New_iIndex.SelectedIndex = 0;
			}
		}

		// Token: 0x060005FF RID: 1535 RVA: 0x0006A1BC File Offset: 0x000683BC
		private void listBox_New_iIndex_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.listBox_New_iIndex.SelectedIndex != -1 & !this.DontWork)
			{
				this.LastSelectedItemIndex = this.listBox_New_iIndex.SelectedIndex;
				try
				{
					this.pictureBox_New_iPicture.BackgroundImage = (Bitmap)Resources.ResourceManager.GetObject("_" + this.listBox_New_iGroup.SelectedValue + this.listBox_New_iIndex.SelectedValue);
					if (this.pictureBox_New_iPicture.BackgroundImage.Size.Width > this.pictureBox_New_iPicture.Size.Width || this.pictureBox_New_iPicture.BackgroundImage.Size.Height > this.pictureBox_New_iPicture.Size.Height)
					{
						this.pictureBox_New_iPicture.BackgroundImageLayout = ImageLayout.Zoom;
					}
					else
					{
						this.pictureBox_New_iPicture.BackgroundImageLayout = ImageLayout.Center;
					}
				}
				catch
				{
					this.pictureBox_New_iPicture.BackgroundImage = (Bitmap)Resources.ResourceManager.GetObject("no_img");
				}
			}
		}

		// Token: 0x06000600 RID: 1536 RVA: 0x0006A2DC File Offset: 0x000684DC
		private void newToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Items = new BindingList<Structures.IGCDropManagerFile>();
		}

		// Token: 0x06000601 RID: 1537 RVA: 0x0006A2EC File Offset: 0x000684EC
		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				foreach (string text in File.ReadAllLines(openFileDialog.FileName))
				{
					if (text.Trim(new char[]
					{
						' ',
						'\t'
					}).Length > 2 && !text.Trim(new char[]
					{
						' ',
						'\t'
					}).StartsWith("end") && !text.Trim(new char[]
					{
						' ',
						'\t'
					}).StartsWith("//"))
					{
						string[] array2 = this.strc.FixLine(text);
						if (array2.Length >= 15)
						{
							Structures.IGCDropManagerFile item = new Structures.IGCDropManagerFile
							{
								iGroup = array2[0],
								iIndex = array2[1],
								MinLvl = array2[2],
								MaxLvl = array2[3],
								Skill = array2[4],
								Luck = array2[5],
								Opt = array2[6],
								Exc = array2[7],
								Ancient = array2[8],
								MapID = array2[9],
								MobID = array2[10],
								MinMobLvl = array2[11],
								MaxMobLvl = array2[12],
								Durability = array2[13],
								DropRate = array2[14]
							};
							ushort num = Convert.ToUInt16(item.iGroup);
							item.Name = this.GetItemName[(int)num, (int)Convert.ToUInt16(item.iIndex)];
							this.Items.Add(item);
						}
					}
				}
				if (this.Items.Count >= 1)
				{
					this.listBox_DropItems.SelectedIndex = -1;
					this.listBox_DropItems.SelectedIndex = 0;
				}
			}
		}

		// Token: 0x06000602 RID: 1538 RVA: 0x0006A4D4 File Offset: 0x000686D4
		private void radioButton_Existing_ExcArmor_CheckedChanged(object sender, EventArgs e)
		{
			this.checkBox_Existing_ExcOpt1.Text = "Zen Drop +30%";
			this.checkBox_Existing_ExcOpt2.Text = "Def Success Rate +10%";
			this.checkBox_Existing_ExcOpt3.Text = "Reflect +5%";
			this.checkBox_Existing_ExcOpt4.Text = "Damage Decrease +4%";
			this.checkBox_Existing_ExcOpt5.Text = "Mana +4%";
			this.checkBox_Existing_ExcOpt6.Text = "HP +4%";
		}

		// Token: 0x06000603 RID: 1539 RVA: 0x0006A544 File Offset: 0x00068744
		private void radioButton_Existing_ExcWeapon_CheckedChanged(object sender, EventArgs e)
		{
			this.checkBox_Existing_ExcOpt1.Text = "Mob Kill +mana/8";
			this.checkBox_Existing_ExcOpt2.Text = "Mob Kill +life/8";
			this.checkBox_Existing_ExcOpt3.Text = "Attack(Wizardy) Speed +7";
			this.checkBox_Existing_ExcOpt4.Text = "Damage +2%";
			this.checkBox_Existing_ExcOpt5.Text = "Damage +level/20";
			this.checkBox_Existing_ExcOpt6.Text = "Exc Damage Rate +10%";
		}

		// Token: 0x06000604 RID: 1540 RVA: 0x0006A5B4 File Offset: 0x000687B4
		private void radioButton_Existing_ExcWings_CheckedChanged(object sender, EventArgs e)
		{
			this.checkBox_Existing_ExcOpt1.Text = "Ignor Def +5% / HP +125";
			this.checkBox_Existing_ExcOpt2.Text = "Return Attack +5% / Mana +125";
			this.checkBox_Existing_ExcOpt3.Text = "Life Recovery +5% /Ignor Def +3%";
			this.checkBox_Existing_ExcOpt4.Text = "Mana Recovery +5% / AG +50";
			this.checkBox_Existing_ExcOpt5.Text = "--- / Attack(Wiz) Speed+5";
			this.checkBox_Existing_ExcOpt6.Text = "---";
		}

		// Token: 0x06000605 RID: 1541 RVA: 0x0006A624 File Offset: 0x00068824
		private void radioButton_New_ExcArmor_CheckedChanged(object sender, EventArgs e)
		{
			this.checkBox_New_ExcOpt1.Text = "Zen Drop +30%";
			this.checkBox_New_ExcOpt2.Text = "Def Success Rate +10%";
			this.checkBox_New_ExcOpt3.Text = "Reflect +5%";
			this.checkBox_New_ExcOpt4.Text = "Damage Decrease +4%";
			this.checkBox_New_ExcOpt5.Text = "Mana +4%";
			this.checkBox_New_ExcOpt6.Text = "HP +4%";
		}

		// Token: 0x06000606 RID: 1542 RVA: 0x0006A694 File Offset: 0x00068894
		private void radioButton_New_ExcWeapon_CheckedChanged(object sender, EventArgs e)
		{
			this.checkBox_New_ExcOpt1.Text = "Mob Kill +mana/8";
			this.checkBox_New_ExcOpt2.Text = "Mob Kill +life/8";
			this.checkBox_New_ExcOpt3.Text = "Attack(Wizardy) Speed +7";
			this.checkBox_New_ExcOpt4.Text = "Damage +2%";
			this.checkBox_New_ExcOpt5.Text = "Damage +level/20";
			this.checkBox_New_ExcOpt6.Text = "Exc Damage Rate +10%";
		}

		// Token: 0x06000607 RID: 1543 RVA: 0x0006A704 File Offset: 0x00068904
		private void radioButton_New_ExcWings_CheckedChanged(object sender, EventArgs e)
		{
			this.checkBox_New_ExcOpt1.Text = "Ignor Def +5% / HP +125";
			this.checkBox_New_ExcOpt2.Text = "Return Attack +5% / Mana +125";
			this.checkBox_New_ExcOpt3.Text = "Life Recovery +5% /Ignor Def +3%";
			this.checkBox_New_ExcOpt4.Text = "Mana Recovery +5% / AG +50";
			this.checkBox_New_ExcOpt5.Text = "--- / Attack(Wiz) Speed+5";
			this.checkBox_New_ExcOpt6.Text = "---";
		}

		// Token: 0x06000608 RID: 1544 RVA: 0x0006A774 File Offset: 0x00068974
		private void ReadMonsterFile(string fName)
		{
			foreach (string text in File.ReadAllLines(fName))
			{
				if (!text.StartsWith("//") & !text.StartsWith("end"))
				{
					string line = text.Split(new char[]
					{
						'/'
					})[0];
					string[] trimmedSplitString = this.GetTrimmedSplitString(line);
					if (trimmedSplitString != null)
					{
						if (trimmedSplitString.Length != 28 && trimmedSplitString.Length != 32)
						{
							MessageBox.Show("Bad length.\nLine: " + text, "Monster.txt Read Error");
							return;
						}
						Structures.Monster item = new Structures.Monster
						{
							ID = Convert.ToInt32(trimmedSplitString[0]),
							Rate = Convert.ToInt32(trimmedSplitString[1]),
							Name = trimmedSplitString[2].Replace("\"", "").Replace("$", " "),
							Level = Convert.ToInt32(trimmedSplitString[3]),
							HP = Convert.ToInt32(trimmedSplitString[4]),
							MP = Convert.ToInt32(trimmedSplitString[5]),
							MinDmg = Convert.ToInt32(trimmedSplitString[6]),
							MaxDmg = Convert.ToInt32(trimmedSplitString[7]),
							Def = Convert.ToInt32(trimmedSplitString[8]),
							MagDef = Convert.ToInt32(trimmedSplitString[9]),
							AtkPower = Convert.ToInt32(trimmedSplitString[10]),
							AtkSucRate = Convert.ToInt32(trimmedSplitString[11]),
							Move = Convert.ToInt32(trimmedSplitString[12]),
							AType = Convert.ToInt32(trimmedSplitString[13]),
							ARange = Convert.ToInt32(trimmedSplitString[14]),
							VRange = Convert.ToInt32(trimmedSplitString[15]),
							MovSP = Convert.ToInt32(trimmedSplitString[16]),
							ASpeed = Convert.ToInt32(trimmedSplitString[17]),
							RegTime = Convert.ToInt32(trimmedSplitString[18]),
							Attrib = Convert.ToInt32(trimmedSplitString[19]),
							ItemR = Convert.ToInt32(trimmedSplitString[20]),
							MoneyR = Convert.ToInt32(trimmedSplitString[21]),
							MaxIS = Convert.ToInt32(trimmedSplitString[22]),
							RWind = Convert.ToInt32(trimmedSplitString[23]),
							RPois = Convert.ToInt32(trimmedSplitString[24]),
							RIce = Convert.ToInt32(trimmedSplitString[25]),
							RWtr = Convert.ToInt32(trimmedSplitString[26]),
							RFire = Convert.ToInt32(trimmedSplitString[27])
						};
						if (trimmedSplitString.Length == 32)
						{
							item.Element = Convert.ToInt32(trimmedSplitString[28]);
							item.MinElem = Convert.ToInt32(trimmedSplitString[29]);
							item.MaxElem = Convert.ToInt32(trimmedSplitString[30]);
							item.ElemDef = Convert.ToInt32(trimmedSplitString[31]);
						}
						this.Monster_Existing.Add(item);
						this.Monster_New.Add(item);
					}
				}
			}
			this.comboBox_Existing_Mob.ValueMember = "ID";
			this.comboBox_Existing_Mob.DisplayMember = "Name";
			this.comboBox_Existing_Mob.DataSource = this.Monster_Existing;
			this.comboBox_New_Mob.ValueMember = "ID";
			this.comboBox_New_Mob.DisplayMember = "Name";
			this.comboBox_New_Mob.DataSource = this.Monster_New;
		}

		// Token: 0x06000609 RID: 1545 RVA: 0x0006AAB8 File Offset: 0x00068CB8
		private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog
			{
				Filter = "DAT files (*.dat)|*.dat"
			};
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.SaveFile(saveFileDialog.FileName);
			}
		}

		// Token: 0x0600060A RID: 1546 RVA: 0x0006AAF0 File Offset: 0x00068CF0
		private void SaveFile(string fileName)
		{
			StreamWriter streamWriter = new StreamWriter(fileName);
			streamWriter.WriteLine("/////////////////////////////////////////////////////////////////////////////");
			streamWriter.WriteLine("//MU DropManager file generated by MU.ToolKit");
			streamWriter.WriteLine("//Coded by © TopReal.IT");
			streamWriter.WriteLine("/////////////////////////////////////////////////////////////////////////////");
			streamWriter.WriteLine("//\tiGroup\tiIndex\tiMinLv\tiMaxLv\tiSkill\tiLuck\tiOpt\tiExc\tiAncient\tMapID\tMobID\tMobMinLv\tMobMaxLv\tiDur\tiDropRate");
			streamWriter.WriteLine("///////////////////////////");
			streamWriter.WriteLine("0");
			foreach (Structures.IGCDropManagerFile igcdropManagerFile in this.Items)
			{
				streamWriter.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}\t{10}\t{11}\t\t{12}\t\t{13}\t{14}\t//{15}", new object[]
				{
					igcdropManagerFile.iGroup,
					igcdropManagerFile.iIndex,
					igcdropManagerFile.MinLvl,
					igcdropManagerFile.MaxLvl,
					igcdropManagerFile.Skill,
					igcdropManagerFile.Luck,
					igcdropManagerFile.Opt,
					igcdropManagerFile.Exc,
					igcdropManagerFile.Ancient,
					igcdropManagerFile.MapID,
					igcdropManagerFile.MobID,
					igcdropManagerFile.MinMobLvl,
					igcdropManagerFile.MaxMobLvl,
					igcdropManagerFile.Durability,
					igcdropManagerFile.DropRate,
					igcdropManagerFile.Name
				});
			}
			streamWriter.WriteLine("end");
			streamWriter.Flush();
			streamWriter.Close();
		}

		// Token: 0x0600060B RID: 1547 RVA: 0x0006AC64 File Offset: 0x00068E64
		public void Setc_AncientData(ref BindingList<Structures.c_AncientData> list)
		{
			Structures.c_AncientData item = new Structures.c_AncientData
			{
				ID = 0,
				Name = "None"
			};
			list.Add(item);
			Structures.c_AncientData item2 = new Structures.c_AncientData
			{
				ID = 5,
				Name = "Level 1"
			};
			list.Add(item2);
			Structures.c_AncientData item3 = new Structures.c_AncientData
			{
				ID = 10,
				Name = "Level 2"
			};
			list.Add(item3);
		}

		// Token: 0x040003AA RID: 938
		private BindingList<Structures.c_AncientData> c_AncientDatas_Existing = new BindingList<Structures.c_AncientData>();

		// Token: 0x040003AB RID: 939
		private BindingList<Structures.c_AncientData> c_AncientDatas_New = new BindingList<Structures.c_AncientData>();

		// Token: 0x040003AC RID: 940
		private List<Structures.c_OptionData> c_OptionDatas_Existing = new List<Structures.c_OptionData>();

		// Token: 0x040003AD RID: 941
		private List<Structures.c_OptionData> c_OptionDatas_New = new List<Structures.c_OptionData>();

		// Token: 0x040003C9 RID: 969
		private bool DontWork;

		// Token: 0x040003CB RID: 971
		private string[,] GetItemName = new string[16, 512];

		// Token: 0x040003D4 RID: 980
		private BindingList<Structures.IGCDropManagerFile> Items = new BindingList<Structures.IGCDropManagerFile>();

		// Token: 0x040003D5 RID: 981
		private List<Structures.UniItem> L_Armors = new List<Structures.UniItem>();

		// Token: 0x040003D6 RID: 982
		private List<Structures.UniItem> L_Axes = new List<Structures.UniItem>();

		// Token: 0x040003D7 RID: 983
		private List<Structures.UniItem> L_Boots = new List<Structures.UniItem>();

		// Token: 0x040003D8 RID: 984
		private List<Structures.UniItem> L_BowsCrossBows = new List<Structures.UniItem>();

		// Token: 0x040003D9 RID: 985
		private List<Structures.UniItem> L_Gloves = new List<Structures.UniItem>();

		// Token: 0x040003DA RID: 986
		private List<Structures.c_Groups> L_Groups = new List<Structures.c_Groups>();

		// Token: 0x040003DB RID: 987
		private List<Structures.UniItem> L_Helms = new List<Structures.UniItem>();

		// Token: 0x040003DC RID: 988
		private List<Structures.UniItem> L_MacesScepters = new List<Structures.UniItem>();

		// Token: 0x040003DD RID: 989
		private List<Structures.UniItem> L_Others1 = new List<Structures.UniItem>();

		// Token: 0x040003DE RID: 990
		private List<Structures.UniItem> L_Others2 = new List<Structures.UniItem>();

		// Token: 0x040003DF RID: 991
		private List<Structures.UniItem> L_Pants = new List<Structures.UniItem>();

		// Token: 0x040003E0 RID: 992
		private List<Structures.UniItem> L_Scrolls = new List<Structures.UniItem>();

		// Token: 0x040003E1 RID: 993
		private List<Structures.UniItem> L_Shields = new List<Structures.UniItem>();

		// Token: 0x040003E2 RID: 994
		private List<Structures.UniItem> L_Spears = new List<Structures.UniItem>();

		// Token: 0x040003E3 RID: 995
		private List<Structures.UniItem> L_Staffs = new List<Structures.UniItem>();

		// Token: 0x040003E4 RID: 996
		private List<Structures.UniItem> L_Swords = new List<Structures.UniItem>();

		// Token: 0x040003E5 RID: 997
		private List<Structures.UniItem> L_WingsSkillsSeedsOthers = new List<Structures.UniItem>();

		// Token: 0x040003FC RID: 1020
		private int LastSelectedItemIndex;

		// Token: 0x04000401 RID: 1025
		private List<Structures.Map> mMapList_Existing = new List<Structures.Map>();

		// Token: 0x04000402 RID: 1026
		private List<Structures.Map> mMapList_New = new List<Structures.Map>();

		// Token: 0x04000403 RID: 1027
		private BindingList<Structures.Monster> Monster_Existing = new BindingList<Structures.Monster>();

		// Token: 0x04000404 RID: 1028
		private BindingList<Structures.Monster> Monster_New = new BindingList<Structures.Monster>();

		// Token: 0x04000405 RID: 1029
		private Dictionary<int, string> MonsterDic = new Dictionary<int, string>();

		// Token: 0x0400041C RID: 1052
		private Structures strc = new Structures();
	}
}
