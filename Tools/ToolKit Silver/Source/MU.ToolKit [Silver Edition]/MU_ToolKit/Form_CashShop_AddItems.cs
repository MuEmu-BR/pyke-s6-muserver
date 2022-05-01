using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MU_ToolKit.Properties;

namespace MU_ToolKit
{
	// Token: 0x0200002B RID: 43
	public partial class Form_CashShop_AddItems : Form
	{
		// Token: 0x0600060C RID: 1548 RVA: 0x0006ACE0 File Offset: 0x00068EE0
		public Form_CashShop_AddItems()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600060D RID: 1549 RVA: 0x0006AEB4 File Offset: 0x000690B4
		private void button_AddItemToDB_Click(object sender, EventArgs e)
		{
			if (this.checkBox_MultiItem.Checked || this.checkBox_PackageItem.Checked)
			{
				this.textBox_Info.Text = "[ERROR] Only Single Items can be added to Items Database!";
				return;
			}
			this.textBox_Info.Text = "";
			this.frm_Parent.TraceNumber++;
			this.frm_Parent.ProductMaxIndex1++;
			this.frm_Parent.ProductMaxIndex7++;
			List<int> list = new List<int>();
			new List<string>();
			new List<string>();
			Structures.IBSProduct item = new Structures.IBSProduct
			{
				Index1 = this.frm_Parent.ProductMaxIndex1
			};
			int index = item.Index1;
			item.Name = this.textBox_NewItem_Name.Text;
			item.BuyTypeTxt1 = ((this.comboBox_NewItem_CountType.SelectedIndex == 0) ? "Quantity" : ((this.comboBox_NewItem_CountType.SelectedIndex == 1) ? "Duration" : ((this.comboBox_NewItem_CountType.SelectedIndex == 2) ? "Duration" : ((this.comboBox_NewItem_CountType.SelectedIndex == 3) ? "Quantity" : "Duration"))));
			int num = Convert.ToInt32(this.numericUpDown_NewItem_Count.Value);
			TimeSpan timeSpan = default(TimeSpan);
			TimeSpan ts = TimeSpan.FromMinutes((double)num);
			timeSpan.Add(ts);
			string text = "[";
			text += ((ts.TotalDays >= 1.0) ? (Convert.ToInt32(ts.TotalDays).ToString() + " Day(s)") : ((ts.TotalHours >= 1.0) ? (Convert.ToInt32(ts.TotalHours).ToString() + " Hour(s)") : (Convert.ToInt32(ts.TotalMinutes).ToString() + " Minute(s)")));
			if (text.Contains("Day(s)"))
			{
				string str = text + ((ts.Hours >= 1) ? (", " + Convert.ToInt32(ts.Hours).ToString() + " Hour(s)") : "");
				text = str + ((ts.Minutes >= 1) ? (", " + Convert.ToInt32(ts.Minutes).ToString() + " Minute(s)") : "");
			}
			else if (text.Contains("Hour(s)"))
			{
				text += ((ts.Minutes >= 1) ? (", " + Convert.ToInt32(ts.Minutes).ToString() + " Minute(s)") : "");
			}
			text += "]";
			item.TypeCount = num.ToString();
			item.BuyTypeTxt2 = ((this.comboBox_NewItem_CountType.SelectedIndex == 0) ? "EA" : ((this.comboBox_NewItem_CountType.SelectedIndex == 1) ? text : ((this.comboBox_NewItem_CountType.SelectedIndex == 2) ? text : ((this.comboBox_NewItem_CountType.SelectedIndex == 3) ? "NA" : "Days"))));
			item.Price = (int)this.numericUpDown_NewItem_Price.Value;
			item.Index7 = this.frm_Parent.ProductMaxIndex7;
			list.Add(item.Index7);
			item.TraceNumber = this.frm_Parent.TraceNumber;
			item.ItemID = Convert.ToString((int)this.listBox_NewItem_ItemGroup.SelectedValue * 512 + (int)this.listBox_NewItem_ItemIndex.SelectedValue);
			item.Unk1 = 142;
			item.Unk2 = 145;
			item.Unk3 = 1;
			item.Unk4 = 144;
			item.Unk5 = 673;
			item.Unk6 = 518;
			if (this.comboBox_NewItem_CountType.SelectedIndex == 1 || this.comboBox_NewItem_CountType.SelectedIndex == 2 || this.comboBox_NewItem_CountType.SelectedIndex == 4)
			{
				item.Unk7 = "10";
			}
			else
			{
				item.Unk7 = "7";
			}
			item.Unk8 = "138";
			item.Unk9 = "680";
			item.TraceString = this.frm_Parent.GetUniqueString();
			this.frm_Parent.Products.Add(item);
			Structures.IGCCashItemInfo igccashItemInfo = new Structures.IGCCashItemInfo
			{
				iGroup = (int)this.listBox_NewItem_ItemGroup.SelectedValue,
				iIndex = (int)this.listBox_NewItem_ItemIndex.SelectedValue,
				Level = (int)this.listBox_NewItem_ItemLevel.SelectedValue,
				Dur = (int)this.numericUpDown_NewItem_Durability.Value,
				Skill = (this.checkBox_NewItem_Skill.Checked ? 1 : 0),
				Luck = (this.checkBox_NewItem_Luck.Checked ? 1 : 0),
				Option = (int)this.listBox_NewItem_ItemOption.SelectedValue,
				TraceNumber = this.frm_Parent.TraceNumber
			};
			int num2 = 0;
			num2 = (this.checkBox_NewItem_ExcOpt1.Checked ? (num2 + 1) : num2);
			num2 = (this.checkBox_NewItem_ExcOpt2.Checked ? (num2 + 2) : num2);
			num2 = (this.checkBox_NewItem_ExcOpt3.Checked ? (num2 + 4) : num2);
			num2 = (this.checkBox_NewItem_ExcOpt4.Checked ? (num2 + 8) : num2);
			num2 = (this.checkBox_NewItem_ExcOpt5.Checked ? (num2 + 16) : num2);
			num2 = (this.checkBox_NewItem_ExcOpt6.Checked ? (num2 + 32) : num2);
			igccashItemInfo.Exc = num2;
			igccashItemInfo.Ancient = (int)this.comboBox_Ancient.SelectedValue;
			igccashItemInfo.Socket = (int)this.numericUpDown_NewItem_SocketCount.Value;
			igccashItemInfo.Type = this.comboBox_NewItem_CountType.SelectedIndex;
			igccashItemInfo.Period = ((igccashItemInfo.Type == 0 || igccashItemInfo.Type == 3) ? 0 : Convert.ToInt32(this.numericUpDown_NewItem_Count.Value));
			igccashItemInfo.Name = this.textBox_NewItem_Name.Text;
			igccashItemInfo.TraceString = this.frm_Parent.GetUniqueString();
			igccashItemInfo.GID = index;
			igccashItemInfo.ID = list[0];
			this.frm_Parent.ItemsInfo.Add(igccashItemInfo);
			this.comboBox_PackageItem_ItemsDatabase.SelectedItem = igccashItemInfo;
			this.textBox_Info.Text = "[INFO] Item added successfully to Database.";
		}

		// Token: 0x0600060E RID: 1550 RVA: 0x0006B560 File Offset: 0x00069760
		private void button_NewItem_Add_Click(object sender, EventArgs e)
		{
			if (this.listBox_NewItem_ItemIndex.SelectedIndex == -1)
			{
				this.textBox_Info.Text = "[ERROR] Item index not selected!";
				return;
			}
			this.textBox_Info.Text = "";
			this.frm_Parent.TraceNumber++;
			this.frm_Parent.ProductMaxIndex1++;
			this.frm_Parent.MaxItemListGID++;
			this.frm_Parent.PackageMaxIndex++;
			this.frm_Parent.ProductMaxIndex7++;
			int gid = 0;
			List<int> list = new List<int>();
			List<string> list2 = new List<string>();
			List<string> list3 = new List<string>();
            int currPage = this.frm_Parent.currPage;
            if (currPage != this.frm_Parent.ItemPageCount)
			{
				this.frm_Parent.currPage = this.frm_Parent.ItemPageCount;
				this.frm_Parent.label_CurrPage.Text = currPage.ToString();
			}
			if (!this.checkBox_PackageItem.Checked && !this.checkBox_MultiItem.Checked)
			{
				Structures.IBSProduct item = new Structures.IBSProduct
				{
					Index1 = this.frm_Parent.ProductMaxIndex1
				};
				gid = item.Index1;
				item.Name = this.textBox_NewItem_Name.Text;
				item.BuyTypeTxt1 = ((this.comboBox_NewItem_CountType.SelectedIndex == 0) ? "Quantity" : ((this.comboBox_NewItem_CountType.SelectedIndex == 1) ? "Duration" : ((this.comboBox_NewItem_CountType.SelectedIndex == 2) ? "Duration" : ((this.comboBox_NewItem_CountType.SelectedIndex == 3) ? "Quantity" : "Duration"))));
				int num = Convert.ToInt32(this.numericUpDown_NewItem_Count.Value);
				TimeSpan timeSpan = default(TimeSpan);
				TimeSpan ts = TimeSpan.FromMinutes((double)num);
				timeSpan.Add(ts);
				string text = "[";
				text += ((ts.TotalDays >= 1.0) ? (Convert.ToInt32(ts.TotalDays).ToString() + " Day(s)") : ((ts.TotalHours >= 1.0) ? (Convert.ToInt32(ts.TotalHours).ToString() + " Hour(s)") : (Convert.ToInt32(ts.TotalMinutes).ToString() + " Minute(s)")));
				if (text.Contains("Day(s)"))
				{
					string str = text + ((ts.Hours >= 1) ? (", " + Convert.ToInt32(ts.Hours).ToString() + " Hour(s)") : "");
					text = str + ((ts.Minutes >= 1) ? (", " + Convert.ToInt32(ts.Minutes).ToString() + " Minute(s)") : "");
				}
				else if (text.Contains("Hour(s)"))
				{
					text += ((ts.Minutes >= 1) ? (", " + Convert.ToInt32(ts.Minutes).ToString() + " Minute(s)") : "");
				}
				text += "]";
				item.TypeCount = num.ToString();
				item.BuyTypeTxt2 = ((this.comboBox_NewItem_CountType.SelectedIndex == 0) ? "EA" : ((this.comboBox_NewItem_CountType.SelectedIndex == 1) ? text : ((this.comboBox_NewItem_CountType.SelectedIndex == 2) ? text : ((this.comboBox_NewItem_CountType.SelectedIndex == 3) ? "NA" : "Days"))));
				item.Price = (int)this.numericUpDown_NewItem_Price.Value;
				item.Index7 = this.frm_Parent.ProductMaxIndex7;
				list.Add(item.Index7);
				item.TraceNumber = this.frm_Parent.TraceNumber;
				item.ItemID = Convert.ToString((int)this.listBox_NewItem_ItemGroup.SelectedValue * 512 + (int)this.listBox_NewItem_ItemIndex.SelectedValue);
				item.Unk1 = 142;
				item.Unk2 = 145;
				item.Unk3 = 1;
				item.Unk4 = 144;
				item.Unk5 = 673;
				item.Unk6 = 518;
				if (this.comboBox_NewItem_CountType.SelectedIndex == 1 || this.comboBox_NewItem_CountType.SelectedIndex == 2 || this.comboBox_NewItem_CountType.SelectedIndex == 4)
				{
					item.Unk7 = "10";
				}
				else
				{
					item.Unk7 = "7";
				}
				item.Unk8 = "138";
				item.Unk9 = "680";
				item.TraceString = this.frm_Parent.GetUniqueString();
				this.frm_Parent.Products.Add(item);
				this.frm_Parent.ProductMaxIndex7++;
			}
			else if (this.checkBox_MultiItem.Checked && this.checkBox_MultiItem.Enabled)
			{
				for (int i = 1; i < 7; i++)
				{
					CheckBox checkBox = (CheckBox)this.tabControl1.Controls["tabPage_MultiOption_" + i].Controls["checkBox_isMulti_" + i];
					TextBox textBox = (TextBox)this.tabControl1.Controls["tabPage_MultiOption_" + i].Controls["textBox_Name_Multi_" + i];
					NumericUpDown numericUpDown = (NumericUpDown)this.tabControl1.Controls["tabPage_MultiOption_" + i].Controls["numericUpDown_Count_Multi_" + i];
					NumericUpDown numericUpDown2 = (NumericUpDown)this.tabControl1.Controls["tabPage_MultiOption_" + i].Controls["numericUpDown_Price_Multi_" + i];
					if (checkBox.Checked)
					{
						Structures.IBSProduct item2 = new Structures.IBSProduct
						{
							Index1 = this.frm_Parent.ProductMaxIndex1
						};
						gid = item2.Index1;
						item2.Name = textBox.Text;
						item2.BuyTypeTxt1 = ((this.comboBox_NewItem_CountType.SelectedIndex == 0) ? "Quantity" : ((this.comboBox_NewItem_CountType.SelectedIndex == 1) ? "Duration" : ((this.comboBox_NewItem_CountType.SelectedIndex == 2) ? "Duration" : ((this.comboBox_NewItem_CountType.SelectedIndex == 3) ? "Quantity" : "Duration"))));
						int num2 = Convert.ToInt32(numericUpDown.Value);
						TimeSpan timeSpan2 = default(TimeSpan);
						TimeSpan ts2 = TimeSpan.FromMinutes((double)num2);
						timeSpan2.Add(ts2);
						string text2 = "[";
						text2 += ((ts2.TotalDays >= 1.0) ? (Convert.ToInt32(ts2.TotalDays).ToString() + " Day(s)") : ((ts2.TotalHours >= 1.0) ? (Convert.ToInt32(ts2.TotalHours).ToString() + " Hour(s)") : (Convert.ToInt32(ts2.TotalMinutes).ToString() + " Minute(s)")));
						if (text2.Contains("Day(s)"))
						{
							string str2 = text2 + ((ts2.Hours >= 1) ? (", " + Convert.ToInt32(ts2.Hours).ToString() + " Hour(s)") : "");
							text2 = str2 + ((ts2.Minutes >= 1) ? (", " + Convert.ToInt32(ts2.Minutes).ToString() + " Minute(s)") : "");
						}
						else if (text2.Contains("Hour(s)"))
						{
							text2 += ((ts2.Minutes >= 1) ? (", " + Convert.ToInt32(ts2.Minutes).ToString() + " Minute(s)") : "");
						}
						text2 += "]";
						item2.TypeCount = num2.ToString();
						item2.BuyTypeTxt2 = ((this.comboBox_NewItem_CountType.SelectedIndex == 0) ? "EA" : ((this.comboBox_NewItem_CountType.SelectedIndex == 1) ? text2 : ((this.comboBox_NewItem_CountType.SelectedIndex == 2) ? text2 : ((this.comboBox_NewItem_CountType.SelectedIndex == 3) ? "NA" : "Days"))));
						item2.Price = (int)numericUpDown2.Value;
						list3.Add(item2.Price.ToString());
						item2.Index7 = this.frm_Parent.ProductMaxIndex7;
						list.Add(item2.Index7);
						item2.TraceNumber = this.frm_Parent.TraceNumber;
						item2.ItemID = Convert.ToString((int)this.listBox_NewItem_ItemGroup.SelectedValue * 512 + (int)this.listBox_NewItem_ItemIndex.SelectedValue);
						item2.Unk1 = 142;
						item2.Unk2 = 145;
						item2.Unk3 = 1;
						item2.Unk4 = 144;
						item2.Unk5 = 673;
						item2.Unk6 = 518;
						if (this.comboBox_NewItem_CountType.SelectedIndex == 1 || this.comboBox_NewItem_CountType.SelectedIndex == 2 || this.comboBox_NewItem_CountType.SelectedIndex == 4)
						{
							item2.Unk7 = "10";
						}
						else
						{
							item2.Unk7 = "7";
						}
						item2.Unk8 = "138";
						item2.Unk9 = "680";
						item2.TraceString = this.frm_Parent.GetUniqueString();
						this.frm_Parent.Products.Add(item2);
						this.frm_Parent.ProductMaxIndex7++;
					}
				}
			}

            Structures.IBSCategory selectedSubCat = this.frm_Parent.SelectedSubCat;
            Structures.IBSCategory ibsCategory = selectedSubCat;
            Structures.IBSPackage item3 = new Structures.IBSPackage
			{
				CatIndex = (short)ibsCategory.Index,
				Seq = Convert.ToInt16(this.frm_Parent.AddedItems.Count + 1),
				Index = Convert.ToInt16(this.frm_Parent.PackageMaxIndex),
				Name = this.textBox_NewItem_Name.Text,
				Price = (int)this.numericUpDown_NewItem_Price.Value,
				Info = this.richTextBox_NewItem_Info.Text.Replace("\n", "#"),
				Unk3 = Convert.ToInt16((this.comboBox_NewItem_Coin.SelectedIndex == 0) ? 185 : ((this.comboBox_NewItem_Coin.SelectedIndex == 1) ? 184 : 185))
			};
			if (this.checkBox_PackageItem.Checked)
			{
				item3.RewardCount = Convert.ToInt16(this.PackageItems.Count);
			}
			else
			{
				item3.RewardCount = 1;
			}
			item3.CoinTxt1 = this.comboBox_NewItem_Coin.Text;
			item3.CoinTxt2 = this.comboBox_NewItem_Coin.Text;
			if (this.checkBox_PackageItem.Checked)
			{
				using (IEnumerator<Structures.IGCCashItemInfo> enumerator = this.PackageItems.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						Structures.IGCCashItemInfo igccashItemInfo = enumerator.Current;
						object productRewardIndex = item3.ProductRewardIndex1;
						int gid2 = igccashItemInfo.GID;
						item3.ProductRewardIndex1 = productRewardIndex + gid2.ToString() + '|';
					}
					goto IL_C0A;
				}
			}
			item3.ProductRewardIndex1 = gid.ToString() + '|';
			IL_C0A:
			if (this.checkBox_PackageItem.Checked)
			{
				item3.ProductRewardIndexes7 = "";
			}
			else
			{
				if (this.checkBox_MultiItem.Checked)
				{
					using (List<int>.Enumerator enumerator2 = list.GetEnumerator())
					{
						while (enumerator2.MoveNext())
						{
							int num3 = enumerator2.Current;
							item3.ProductRewardIndexes7 = item3.ProductRewardIndexes7 + num3.ToString() + '|';
						}
						goto IL_CA2;
					}
				}
				item3.ProductRewardIndexes7 = list[0].ToString() + '|';
			}
			IL_CA2:
			item3.ItemID = (int)this.listBox_NewItem_ItemGroup.SelectedValue * 512 + (int)this.listBox_NewItem_ItemIndex.SelectedValue;
			if (this.checkBox_MultiItem.Checked)
			{
				item3.CheckBoxCount = Convert.ToInt16(list.Count);
			}
			else
			{
				item3.CheckBoxCount = 1;
			}
			item3.ServerCatIndex = ((this.comboBox_NewItem_Coin.SelectedIndex == 0) ? 508 : ((this.comboBox_NewItem_Coin.SelectedIndex == 1) ? 509 : 0));
			item3.TraceNumber = this.frm_Parent.TraceNumber;
			item3.Unk10 = Convert.ToInt16((this.comboBox_NewItem_Coin.SelectedIndex == 0) ? 2 : ((this.comboBox_NewItem_Coin.SelectedIndex == 1) ? 3 : 5));
			item3.Unk1 = 170;
			item3.Unk2 = 182;
			item3.Unk4 = "0";
			item3.Unk5 = "0";
			item3.Unk6 = 177;
			item3.Unk7 = 181;
			item3.Unk8 = 200;
			item3.Unk9 = 0;
			item3.Unk11 = "0";
			item3.Const669 = 669;
			item3.TraceString = this.frm_Parent.GetUniqueString();
			this.frm_Parent.Packages.Add(item3);
			if (!this.checkBox_PackageItem.Checked && !this.checkBox_MultiItem.Checked)
			{
				Structures.IGCCashItemInfo item4 = new Structures.IGCCashItemInfo
				{
					iGroup = (int)this.listBox_NewItem_ItemGroup.SelectedValue,
					iIndex = (int)this.listBox_NewItem_ItemIndex.SelectedValue,
					Level = (int)this.listBox_NewItem_ItemLevel.SelectedValue,
					Dur = (int)this.numericUpDown_NewItem_Durability.Value,
					Skill = (this.checkBox_NewItem_Skill.Checked ? 1 : 0),
					Luck = (this.checkBox_NewItem_Luck.Checked ? 1 : 0),
					Option = (int)this.listBox_NewItem_ItemOption.SelectedValue,
					TraceNumber = this.frm_Parent.TraceNumber
				};
				int num4 = 0;
				num4 = (this.checkBox_NewItem_ExcOpt1.Checked ? (num4 + 1) : num4);
				num4 = (this.checkBox_NewItem_ExcOpt2.Checked ? (num4 + 2) : num4);
				num4 = (this.checkBox_NewItem_ExcOpt3.Checked ? (num4 + 4) : num4);
				num4 = (this.checkBox_NewItem_ExcOpt4.Checked ? (num4 + 8) : num4);
				num4 = (this.checkBox_NewItem_ExcOpt5.Checked ? (num4 + 16) : num4);
				num4 = (this.checkBox_NewItem_ExcOpt6.Checked ? (num4 + 32) : num4);
				item4.Exc = num4;
				item4.Ancient = (int)this.comboBox_Ancient.SelectedValue;
				item4.Socket = (int)this.numericUpDown_NewItem_SocketCount.Value;
				item4.Type = this.comboBox_NewItem_CountType.SelectedIndex;
				item4.Period = ((item4.Type == 0 || item4.Type == 3) ? 0 : Convert.ToInt32(this.numericUpDown_NewItem_Count.Value));
				item4.Name = this.textBox_NewItem_Name.Text;
				item4.TraceString = this.frm_Parent.GetUniqueString();
				item4.GID = gid;
				item4.ID = list[0];
				this.frm_Parent.ItemsInfo.Add(item4);
			}
			else if (this.checkBox_MultiItem.Checked && this.checkBox_MultiItem.Enabled)
			{
				for (int j = 1; j < 7; j++)
				{
					CheckBox checkBox2 = (CheckBox)this.tabControl1.Controls["tabPage_MultiOption_" + j].Controls["checkBox_isMulti_" + j];
					TextBox textBox2 = (TextBox)this.tabControl1.Controls["tabPage_MultiOption_" + j].Controls["textBox_Name_Multi_" + j];
					NumericUpDown numericUpDown3 = (NumericUpDown)this.tabControl1.Controls["tabPage_MultiOption_" + j].Controls["numericUpDown_Count_Multi_" + j];
					NumericUpDown numericUpDown4 = (NumericUpDown)this.tabControl1.Controls["tabPage_MultiOption_" + j].Controls["numericUpDown_Price_Multi_" + j];
					ListBox listBox = (ListBox)this.tabControl1.Controls["tabPage_MultiOption_" + j].Controls["listBox_Level_Multi_" + j];
					ListBox listBox2 = (ListBox)this.tabControl1.Controls["tabPage_MultiOption_" + j].Controls["listBox_Option_Multi_" + j];
					ComboBox comboBox = (ComboBox)this.tabControl1.Controls["tabPage_MultiOption_" + j].Controls["comboBox_Ancient_Multi_" + j];
					CheckBox checkBox3 = (CheckBox)this.tabControl1.Controls["tabPage_MultiOption_" + j].Controls["groupBox_" + j].Controls["checkBox_ExcOption1_Multi_" + j];
					CheckBox checkBox4 = (CheckBox)this.tabControl1.Controls["tabPage_MultiOption_" + j].Controls["groupBox_" + j].Controls["checkBox_ExcOption2_Multi_" + j];
					CheckBox checkBox5 = (CheckBox)this.tabControl1.Controls["tabPage_MultiOption_" + j].Controls["groupBox_" + j].Controls["checkBox_ExcOption3_Multi_" + j];
					CheckBox checkBox6 = (CheckBox)this.tabControl1.Controls["tabPage_MultiOption_" + j].Controls["groupBox_" + j].Controls["checkBox_ExcOption4_Multi_" + j];
					CheckBox checkBox7 = (CheckBox)this.tabControl1.Controls["tabPage_MultiOption_" + j].Controls["groupBox_" + j].Controls["checkBox_ExcOption5_Multi_" + j];
					CheckBox checkBox8 = (CheckBox)this.tabControl1.Controls["tabPage_MultiOption_" + j].Controls["groupBox_" + j].Controls["checkBox_ExcOption6_Multi_" + j];
					NumericUpDown numericUpDown5 = (NumericUpDown)this.tabControl1.Controls["tabPage_MultiOption_" + j].Controls["numericUpDown_Sockets_Multi_" + j];
					NumericUpDown numericUpDown6 = (NumericUpDown)this.tabControl1.Controls["tabPage_MultiOption_" + j].Controls["numericUpDown_Durability_Multi_" + j];
					CheckBox checkBox9 = (CheckBox)this.tabControl1.Controls["tabPage_MultiOption_" + j].Controls["checkBox_Luck_Multi_" + j];
					CheckBox checkBox10 = (CheckBox)this.tabControl1.Controls["tabPage_MultiOption_" + j].Controls["checkBox_Skill_Multi_" + j];
					if (checkBox2.Checked)
					{
						Structures.IGCCashItemInfo item5 = new Structures.IGCCashItemInfo
						{
							iGroup = (int)this.listBox_NewItem_ItemGroup.SelectedValue,
							iIndex = (int)this.listBox_NewItem_ItemIndex.SelectedValue,
							Level = (int)listBox.SelectedValue,
							Dur = (int)numericUpDown6.Value,
							Skill = (checkBox10.Checked ? 1 : 0),
							Luck = (checkBox9.Checked ? 1 : 0),
							Option = (int)listBox2.SelectedValue,
							TraceNumber = this.frm_Parent.TraceNumber
						};
						int num5 = 0;
						num5 = (checkBox3.Checked ? (num5 + 1) : num5);
						num5 = (checkBox4.Checked ? (num5 + 2) : num5);
						num5 = (checkBox5.Checked ? (num5 + 4) : num5);
						num5 = (checkBox6.Checked ? (num5 + 8) : num5);
						num5 = (checkBox7.Checked ? (num5 + 16) : num5);
						num5 = (checkBox8.Checked ? (num5 + 32) : num5);
						item5.Exc = num5;
						item5.Ancient = (int)comboBox.SelectedValue;
						item5.Socket = (int)numericUpDown5.Value;
						item5.Type = this.comboBox_NewItem_CountType.SelectedIndex;
						item5.Period = ((item5.Type == 0 || item5.Type == 3) ? 0 : Convert.ToInt32(numericUpDown3.Value));
						item5.Name = textBox2.Text;
						list2.Add(item5.Name);
						item5.TraceString = this.frm_Parent.GetUniqueString();
						item5.GID = gid;
						item5.ID = list[j - 1];
						this.frm_Parent.ItemsInfo.Add(item5);
					}
				}
			}
			if (!this.checkBox_PackageItem.Checked && !this.checkBox_MultiItem.Checked)
			{
				Structures.IGCCashItemList item6 = new Structures.IGCCashItemList
				{
					GUID = this.frm_Parent.MaxItemListGID,
					Index = (int)item3.Index,
					SubIndex = item3.ServerCatIndex,
					iOpt = 0,
					pID = 0,
					cType = this.comboBox_NewItem_Coin.SelectedIndex,
					iPrice = (int)this.numericUpDown_NewItem_Price.Value,
					iInfoGD = Convert.ToInt32(item3.ProductRewardIndex1.Replace("|", string.Empty)),
					iInfoID = Convert.ToInt32(item3.ProductRewardIndexes7.Replace("|", string.Empty)),
					iCat = (int)item3.CatIndex,
					iGP = 0,
					iSale = 1,
					iRand = 0,
					Name = this.textBox_NewItem_Name.Text,
					TraceNumber = this.frm_Parent.TraceNumber,
					TraceString = this.frm_Parent.GetUniqueString()
				};
				this.frm_Parent.ItemsList.Add(item6);
			}
			else if (this.checkBox_MultiItem.Checked && this.checkBox_MultiItem.Enabled)
			{
				Structures.IGCCashItemList item7 = new Structures.IGCCashItemList
				{
					Index = (int)item3.Index,
					SubIndex = item3.ServerCatIndex,
					pID = 0,
					cType = this.comboBox_NewItem_Coin.SelectedIndex,
					iInfoGD = Convert.ToInt32(item3.ProductRewardIndex1.Replace("|", string.Empty)),
					iCat = (int)item3.CatIndex,
					iGP = 0,
					iSale = 1,
					iRand = 0,
					TraceNumber = this.frm_Parent.TraceNumber
				};
				string[] array = item3.ProductRewardIndexes7.Split(new char[]
				{
					'|'
				});
				for (int k = 0; k < array.Length - 1; k++)
				{
					item7.Name = list2[k];
					item7.GUID = this.frm_Parent.MaxItemListGID;
					item7.iPrice = Convert.ToInt32(list3[k]);
					item7.iInfoID = Convert.ToInt32(array[k]);
					item7.iOpt = item7.iInfoID;
					item7.TraceString = this.frm_Parent.GetUniqueString();
					this.frm_Parent.ItemsList.Add(item7);
					this.frm_Parent.MaxItemListGID++;
				}
			}
			else if (this.checkBox_PackageItem.Checked)
			{
				this.frm_Parent.MaxPackageID++;
				Structures.IGCCashItemList item8 = new Structures.IGCCashItemList
				{
					GUID = this.frm_Parent.MaxItemListGID,
					Index = (int)item3.Index,
					SubIndex = item3.ServerCatIndex,
					iOpt = 0,
					pID = this.frm_Parent.MaxPackageID,
					cType = this.comboBox_NewItem_Coin.SelectedIndex,
					iPrice = (int)this.numericUpDown_NewItem_Price.Value,
					iInfoGD = 0,
					iInfoID = 0,
					iCat = (int)item3.CatIndex,
					iGP = 0,
					iSale = 1,
					iRand = 0,
					Name = this.textBox_NewItem_Name.Text,
					TraceNumber = this.frm_Parent.TraceNumber,
					TraceString = this.frm_Parent.GetUniqueString()
				};
				this.frm_Parent.ItemsList.Add(item8);
			}
			if (this.checkBox_PackageItem.Checked)
			{
				int num6 = 0;
				foreach (object obj in this.listBox_PackageItem_AddedItems.Items)
				{
					Structures.IGCCashItemInfo igccashItemInfo2 = (Structures.IGCCashItemInfo)obj;
					Structures.IGCCashItemPackages item9 = new Structures.IGCCashItemPackages
					{
						pID = this.frm_Parent.MaxPackageID,
						GUID = num6,
						iSeq = num6,
						iGUID = igccashItemInfo2.GID,
						iID = igccashItemInfo2.ID,
						Name = igccashItemInfo2.Name,
						PackName = this.textBox_NewItem_Name.Text
					};
					this.frm_Parent.IGC_CashItemPackages_Indexes.Add(item9.GUID.ToString() + ',' + item9.iGUID.ToString());
					this.frm_Parent.ItemsPackage.Add(item9);
					num6++;
				}
			}
			this.frm_Parent.ItemsToAdd = this.frm_Parent.GetSubCatItems(ibsCategory.Index);
			this.frm_Parent.LoadItems(currPage);
			this.textBox_Info.Text = "[INFO] Item Added Successfully.";
		}

		// Token: 0x0600060F RID: 1551 RVA: 0x0006D258 File Offset: 0x0006B458
		private void button_PackageItem_AddToList_Click(object sender, EventArgs e)
		{
			this.PackageItems.Add((Structures.IGCCashItemInfo)this.comboBox_PackageItem_ItemsDatabase.SelectedItem);
		}

		// Token: 0x06000610 RID: 1552 RVA: 0x0006D275 File Offset: 0x0006B475
		private void button_PackageItem_RemoveFromList_Click(object sender, EventArgs e)
		{
			if (this.listBox_PackageItem_AddedItems.SelectedIndex != -1)
			{
				this.PackageItems.Remove((Structures.IGCCashItemInfo)this.listBox_PackageItem_AddedItems.SelectedItem);
			}
		}

		// Token: 0x06000611 RID: 1553 RVA: 0x0006D2A4 File Offset: 0x0006B4A4
		private void button_UpdateExistingItem_Click(object sender, EventArgs e)
		{
			if (!this.isItemSelected)
			{
				this.textBox_Info.Text = "[ERROR] No item selected!";
				return;
			}
			this.textBox_Info.Text = "";
			BindingList<Structures.IGCCashItemList> selected_iList = this.frm_Parent.Selected_iList;
			BindingList<Structures.IGCCashItemInfo> selected_iInfo = this.frm_Parent.Selected_iInfo;
			BindingList<Structures.IGCCashItemPackages> selected_iPack = this.frm_Parent.Selected_iPack;
			Structures.IBSPackage selected_iPackage = this.frm_Parent.Selected_iPackage;
			BindingList<Structures.IBSProduct> selected_iProduct = this.frm_Parent.Selected_iProduct;
			if ((selected_iList[0].pID == 0 && this.checkBox_PackageItem.Checked) || (selected_iList[0].pID > 0 && !this.checkBox_PackageItem.Checked) || (selected_iList[0].iOpt == 0 && this.checkBox_MultiItem.Checked) || (selected_iList[0].iOpt > 0 && !this.checkBox_MultiItem.Checked))
			{
				this.textBox_Info.Text = "[ERROR] Cannot convert Non-Package or MultiItem Item to Singel Item Type and vice versa!";
				return;
			}
			int num = 0;
			for (int i = 1; i < 7; i++)
			{
				CheckBox checkBox = (CheckBox)this.tabControl1.Controls["tabPage_MultiOption_" + i].Controls["checkBox_isMulti_" + i];
				num = (checkBox.Checked ? (num + 1) : num);
			}
			if (this.checkBox_MultiItem.Checked && num < 2)
			{
				this.textBox_Info.Text = "[ERROR] Multi item must have at least 2 Options !";
				return;
			}
			if (selected_iList.Count != 1)
			{
				List<int> list = new List<int>();
				List<string> list2 = new List<string>();
				List<string> list3 = new List<string>();
				for (int j = 1; j < 7; j++)
				{
					CheckBox checkBox2 = (CheckBox)this.tabControl1.Controls["tabPage_MultiOption_" + j].Controls["checkBox_isMulti_" + j];
					TextBox textBox = (TextBox)this.tabControl1.Controls["tabPage_MultiOption_" + j].Controls["textBox_Name_Multi_" + j];
					NumericUpDown numericUpDown = (NumericUpDown)this.tabControl1.Controls["tabPage_MultiOption_" + j].Controls["numericUpDown_Count_Multi_" + j];
					NumericUpDown numericUpDown2 = (NumericUpDown)this.tabControl1.Controls["tabPage_MultiOption_" + j].Controls["numericUpDown_Price_Multi_" + j];
					if (checkBox2.Checked)
					{
						if (j <= selected_iProduct.Count)
						{
							Structures.IBSProduct value = selected_iProduct[j - 1];
							value.Name = textBox.Text;
							list.Add(value.Index7);
							value.BuyTypeTxt1 = ((this.comboBox_NewItem_CountType.SelectedIndex == 0) ? "Quantity" : ((this.comboBox_NewItem_CountType.SelectedIndex == 1) ? "Duration" : ((this.comboBox_NewItem_CountType.SelectedIndex == 2) ? "Duration" : ((this.comboBox_NewItem_CountType.SelectedIndex == 3) ? "Quantity" : "Duration"))));
							int num2 = Convert.ToInt32(numericUpDown.Value);
							TimeSpan timeSpan = default(TimeSpan);
							TimeSpan ts = TimeSpan.FromMinutes((double)num2);
							timeSpan.Add(ts);
							string text = "[";
							text += ((ts.TotalDays >= 1.0) ? (Convert.ToInt32(ts.TotalDays).ToString() + " Day(s)") : ((ts.TotalHours >= 1.0) ? (Convert.ToInt32(ts.TotalHours).ToString() + " Hour(s)") : (Convert.ToInt32(ts.TotalMinutes).ToString() + " Minute(s)")));
							if (text.Contains("Day(s)"))
							{
								string str = text + ((ts.Hours >= 1) ? (", " + Convert.ToInt32(ts.Hours).ToString() + " Hour(s)") : "");
								text = str + ((ts.Minutes >= 1) ? (", " + Convert.ToInt32(ts.Minutes).ToString() + " Minute(s)") : "");
							}
							else if (text.Contains("Hour(s)"))
							{
								text += ((ts.Minutes >= 1) ? (", " + Convert.ToInt32(ts.Minutes).ToString() + " Minute(s)") : "");
							}
							text += "]";
							value.TypeCount = num2.ToString();
							value.BuyTypeTxt2 = ((this.comboBox_NewItem_CountType.SelectedIndex == 0) ? "EA" : ((this.comboBox_NewItem_CountType.SelectedIndex == 1) ? text : ((this.comboBox_NewItem_CountType.SelectedIndex == 2) ? text : ((this.comboBox_NewItem_CountType.SelectedIndex == 3) ? "NA" : "Days"))));
							value.Price = (int)numericUpDown2.Value;
							list3.Add(value.Price.ToString());
							this.frm_Parent.Products[this.frm_Parent.Products.IndexOf(selected_iProduct[j - 1])] = value;
							selected_iProduct[j - 1] = value;
						}
						else
						{
							Structures.IBSProduct ibsproduct = selected_iProduct[0];
							this.frm_Parent.ProductMaxIndex7++;
							Structures.IBSProduct item = new Structures.IBSProduct
							{
								Index1 = ibsproduct.Index1,
								Name = textBox.Text,
								BuyTypeTxt1 = ((this.comboBox_NewItem_CountType.SelectedIndex == 0) ? "Quantity" : ((this.comboBox_NewItem_CountType.SelectedIndex == 1) ? "Duration" : ((this.comboBox_NewItem_CountType.SelectedIndex == 2) ? "Duration" : ((this.comboBox_NewItem_CountType.SelectedIndex == 3) ? "Quantity" : "Duration"))))
							};
							int num3 = Convert.ToInt32(numericUpDown.Value);
							TimeSpan timeSpan2 = default(TimeSpan);
							TimeSpan ts2 = TimeSpan.FromMinutes((double)num3);
							timeSpan2.Add(ts2);
							string text2 = "[";
							text2 += ((ts2.TotalDays >= 1.0) ? (Convert.ToInt32(ts2.TotalDays).ToString() + " Day(s)") : ((ts2.TotalHours >= 1.0) ? (Convert.ToInt32(ts2.TotalHours).ToString() + " Hour(s)") : (Convert.ToInt32(ts2.TotalMinutes).ToString() + " Minute(s)")));
							if (text2.Contains("Day(s)"))
							{
								string str2 = text2 + ((ts2.Hours >= 1) ? (", " + Convert.ToInt32(ts2.Hours).ToString() + " Hour(s)") : "");
								text2 = str2 + ((ts2.Minutes >= 1) ? (", " + Convert.ToInt32(ts2.Minutes).ToString() + " Minute(s)") : "");
							}
							else if (text2.Contains("Hour(s)"))
							{
								text2 += ((ts2.Minutes >= 1) ? (", " + Convert.ToInt32(ts2.Minutes).ToString() + " Minute(s)") : "");
							}
							text2 += "]";
							item.TypeCount = num3.ToString();
							item.BuyTypeTxt2 = ((this.comboBox_NewItem_CountType.SelectedIndex == 0) ? "EA" : ((this.comboBox_NewItem_CountType.SelectedIndex == 1) ? text2 : ((this.comboBox_NewItem_CountType.SelectedIndex == 2) ? text2 : ((this.comboBox_NewItem_CountType.SelectedIndex == 3) ? "NA" : "Days"))));
							item.Price = (int)numericUpDown2.Value;
							list3.Add(item.Price.ToString());
							item.Index7 = this.frm_Parent.ProductMaxIndex7;
							list.Add(item.Index7);
							item.TraceNumber = ibsproduct.TraceNumber;
							item.ItemID = ibsproduct.ItemID;
							item.Unk1 = 142;
							item.Unk2 = 145;
							item.Unk3 = 1;
							item.Unk4 = 144;
							item.Unk5 = 673;
							item.Unk6 = 518;
							if (this.comboBox_NewItem_CountType.SelectedIndex == 1 || this.comboBox_NewItem_CountType.SelectedIndex == 2 || this.comboBox_NewItem_CountType.SelectedIndex == 4)
							{
								item.Unk7 = "10";
							}
							else
							{
								item.Unk7 = "7";
							}
							item.Unk8 = "138";
							item.Unk9 = "680";
							item.TraceString = this.frm_Parent.GetUniqueString();
							this.frm_Parent.Products.Add(item);
							selected_iProduct.Add(item);
						}
					}
					else
					{
						try
						{
							this.frm_Parent.Products.Remove(selected_iProduct[j - 1]);
						}
						catch
						{
						}
					}
				}
				Structures.IBSPackage value2 = selected_iPackage;
				value2.Name = this.textBox_NewItem_Name.Text;
				value2.Price = (int)this.numericUpDown_NewItem_Price.Value;
				value2.Info = this.richTextBox_NewItem_Info.Text.Replace("\n", "#");
				value2.Unk3 = Convert.ToInt16((this.comboBox_NewItem_Coin.SelectedIndex == 0) ? 185 : ((this.comboBox_NewItem_Coin.SelectedIndex == 1) ? 184 : 185));
				value2.RewardCount = 1;
				value2.CoinTxt1 = this.comboBox_NewItem_Coin.Text;
				value2.CoinTxt2 = this.comboBox_NewItem_Coin.Text;
				value2.ProductRewardIndexes7 = "";
				foreach (int num4 in list)
				{
					value2.ProductRewardIndexes7 = value2.ProductRewardIndexes7 + num4.ToString() + '|';
				}
				value2.CheckBoxCount = Convert.ToInt16(list.Count);
				value2.Unk10 = Convert.ToInt16((this.comboBox_NewItem_Coin.SelectedIndex == 0) ? 2 : ((this.comboBox_NewItem_Coin.SelectedIndex == 1) ? 3 : 5));
				this.frm_Parent.Packages[this.frm_Parent.Packages.IndexOf(selected_iPackage)] = value2;
				for (int k = 1; k < 7; k++)
				{
					CheckBox checkBox3 = (CheckBox)this.tabControl1.Controls["tabPage_MultiOption_" + k].Controls["checkBox_isMulti_" + k];
					TextBox textBox2 = (TextBox)this.tabControl1.Controls["tabPage_MultiOption_" + k].Controls["textBox_Name_Multi_" + k];
					NumericUpDown numericUpDown3 = (NumericUpDown)this.tabControl1.Controls["tabPage_MultiOption_" + k].Controls["numericUpDown_Count_Multi_" + k];
					NumericUpDown numericUpDown4 = (NumericUpDown)this.tabControl1.Controls["tabPage_MultiOption_" + k].Controls["numericUpDown_Price_Multi_" + k];
					ListBox listBox = (ListBox)this.tabControl1.Controls["tabPage_MultiOption_" + k].Controls["listBox_Level_Multi_" + k];
					ListBox listBox2 = (ListBox)this.tabControl1.Controls["tabPage_MultiOption_" + k].Controls["listBox_Option_Multi_" + k];
					ComboBox comboBox = (ComboBox)this.tabControl1.Controls["tabPage_MultiOption_" + k].Controls["comboBox_Ancient_Multi_" + k];
					CheckBox checkBox4 = (CheckBox)this.tabControl1.Controls["tabPage_MultiOption_" + k].Controls["groupBox_" + k].Controls["checkBox_ExcOption1_Multi_" + k];
					CheckBox checkBox5 = (CheckBox)this.tabControl1.Controls["tabPage_MultiOption_" + k].Controls["groupBox_" + k].Controls["checkBox_ExcOption2_Multi_" + k];
					CheckBox checkBox6 = (CheckBox)this.tabControl1.Controls["tabPage_MultiOption_" + k].Controls["groupBox_" + k].Controls["checkBox_ExcOption3_Multi_" + k];
					CheckBox checkBox7 = (CheckBox)this.tabControl1.Controls["tabPage_MultiOption_" + k].Controls["groupBox_" + k].Controls["checkBox_ExcOption4_Multi_" + k];
					CheckBox checkBox8 = (CheckBox)this.tabControl1.Controls["tabPage_MultiOption_" + k].Controls["groupBox_" + k].Controls["checkBox_ExcOption5_Multi_" + k];
					CheckBox checkBox9 = (CheckBox)this.tabControl1.Controls["tabPage_MultiOption_" + k].Controls["groupBox_" + k].Controls["checkBox_ExcOption6_Multi_" + k];
					NumericUpDown numericUpDown5 = (NumericUpDown)this.tabControl1.Controls["tabPage_MultiOption_" + k].Controls["numericUpDown_Sockets_Multi_" + k];
					NumericUpDown numericUpDown6 = (NumericUpDown)this.tabControl1.Controls["tabPage_MultiOption_" + k].Controls["numericUpDown_Durability_Multi_" + k];
					CheckBox checkBox10 = (CheckBox)this.tabControl1.Controls["tabPage_MultiOption_" + k].Controls["checkBox_Luck_Multi_" + k];
					CheckBox checkBox11 = (CheckBox)this.tabControl1.Controls["tabPage_MultiOption_" + k].Controls["checkBox_Skill_Multi_" + k];
					if (checkBox3.Checked)
					{
						if (k <= selected_iInfo.Count)
						{
							Structures.IGCCashItemInfo value3 = selected_iInfo[k - 1];
							value3.Level = (int)listBox.SelectedValue;
							value3.Dur = (int)numericUpDown6.Value;
							value3.Skill = (checkBox11.Checked ? 1 : 0);
							value3.Luck = (checkBox10.Checked ? 1 : 0);
							value3.Option = (int)listBox2.SelectedValue;
							int num5 = 0;
							num5 = (checkBox4.Checked ? (num5 + 1) : num5);
							num5 = (checkBox5.Checked ? (num5 + 2) : num5);
							num5 = (checkBox6.Checked ? (num5 + 4) : num5);
							num5 = (checkBox7.Checked ? (num5 + 8) : num5);
							num5 = (checkBox8.Checked ? (num5 + 16) : num5);
							num5 = (checkBox9.Checked ? (num5 + 32) : num5);
							value3.Exc = num5;
							value3.Ancient = (int)comboBox.SelectedValue;
							value3.Socket = (int)numericUpDown5.Value;
							value3.Type = this.comboBox_NewItem_CountType.SelectedIndex;
							value3.Period = ((value3.Type == 0 || value3.Type == 3) ? 0 : Convert.ToInt32(numericUpDown3.Value));
							value3.Name = textBox2.Text;
							list2.Add(value3.Name);
							this.frm_Parent.ItemsInfo[this.frm_Parent.ItemsInfo.IndexOf(selected_iInfo[k - 1])] = value3;
						}
						else
						{
							Structures.IGCCashItemInfo igccashItemInfo = selected_iInfo[0];
							Structures.IGCCashItemInfo item2 = new Structures.IGCCashItemInfo
							{
								iGroup = igccashItemInfo.iGroup,
								iIndex = igccashItemInfo.iIndex,
								Level = (int)listBox.SelectedValue,
								Dur = (int)numericUpDown6.Value,
								Skill = (checkBox11.Checked ? 1 : 0),
								Luck = (checkBox10.Checked ? 1 : 0),
								Option = (int)listBox2.SelectedValue,
								TraceNumber = igccashItemInfo.TraceNumber
							};
							int num6 = 0;
							num6 = (checkBox4.Checked ? (num6 + 1) : num6);
							num6 = (checkBox5.Checked ? (num6 + 2) : num6);
							num6 = (checkBox6.Checked ? (num6 + 4) : num6);
							num6 = (checkBox7.Checked ? (num6 + 8) : num6);
							num6 = (checkBox8.Checked ? (num6 + 16) : num6);
							num6 = (checkBox9.Checked ? (num6 + 32) : num6);
							item2.Exc = num6;
							item2.Ancient = (int)comboBox.SelectedValue;
							item2.Socket = (int)numericUpDown5.Value;
							item2.Type = this.comboBox_NewItem_CountType.SelectedIndex;
							item2.Period = ((item2.Type == 0 || item2.Type == 3) ? 0 : Convert.ToInt32(numericUpDown3.Value));
							item2.Name = textBox2.Text;
							list2.Add(item2.Name);
							item2.TraceString = this.frm_Parent.GetUniqueString();
							item2.GID = igccashItemInfo.GID;
							item2.ID = list[k - 1];
							this.frm_Parent.ItemsInfo.Add(item2);
						}
					}
					else
					{
						try
						{
							this.frm_Parent.ItemsInfo.Remove(selected_iInfo[k - 1]);
						}
						catch
						{
						}
					}
				}
				Structures.IGCCashItemList igccashItemList = selected_iList[0];
				foreach (Structures.IGCCashItemList item3 in selected_iList)
				{
					this.frm_Parent.ItemsList.Remove(item3);
				}
				Structures.IGCCashItemList item4 = new Structures.IGCCashItemList
				{
					Index = (int)value2.Index,
					SubIndex = value2.ServerCatIndex,
					pID = 0,
					cType = this.comboBox_NewItem_Coin.SelectedIndex,
					iInfoGD = Convert.ToInt32(value2.ProductRewardIndex1.Replace("|", string.Empty)),
					iCat = (int)value2.CatIndex,
					iGP = 0,
					iSale = 1,
					iRand = 0,
					TraceNumber = value2.TraceNumber
				};
				this.frm_Parent.MaxItemListGID++;
				string[] array = value2.ProductRewardIndexes7.Split(new char[]
				{
					'|'
				});
				for (int l = 0; l < array.Length - 1; l++)
				{
					item4.Name = list2[l];
					item4.GUID = this.frm_Parent.MaxItemListGID;
					item4.iPrice = Convert.ToInt32(list3[l]);
					item4.iInfoID = Convert.ToInt32(array[l]);
					item4.iOpt = item4.iInfoID;
					item4.TraceString = this.frm_Parent.GetUniqueString();
					this.frm_Parent.ItemsList.Add(item4);
					this.frm_Parent.MaxItemListGID++;
				}
			}
			else
			{
				if (selected_iList[0].pID != 0)
				{
                    for (int m = 0; m < this.frm_Parent.Packages.Count; m++)
                    {
                        if (selected_iPackage.TraceString == this.frm_Parent.Packages[m].TraceString)
                        {
                            Structures.IBSPackage value4 = this.frm_Parent.Packages[m];
                            value4.Name = this.textBox_NewItem_Name.Text;
                            value4.Price = (int) this.numericUpDown_NewItem_Price.Value;
                            value4.Info = this.richTextBox_NewItem_Info.Text.Replace("\n", "#");
                            value4.Unk3 = Convert.ToInt16((this.comboBox_NewItem_Coin.SelectedIndex == 0)
                                ? 185
                                : ((this.comboBox_NewItem_Coin.SelectedIndex == 1) ? 184 : 185));
                            if (this.checkBox_PackageItem.Checked)
                            {
                                value4.RewardCount = Convert.ToInt16(this.PackageItems.Count);
                            }
                            else
                            {
                                value4.RewardCount = 1;
                            }

                            value4.CoinTxt1 = this.comboBox_NewItem_Coin.Text;
                            value4.CoinTxt2 = this.comboBox_NewItem_Coin.Text;
                            value4.ProductRewardIndex1 = "";
                            foreach (Structures.IGCCashItemInfo igccashItemInfo2 in this.PackageItems)
                            {
                                object productRewardIndex = value4.ProductRewardIndex1;
                                int num7 = igccashItemInfo2.GID;
                                value4.ProductRewardIndex1 = productRewardIndex + num7.ToString() + '|';
                            }

                            value4.Unk10 = Convert.ToInt16((this.comboBox_NewItem_Coin.SelectedIndex == 0)
                                ? 2
                                : ((this.comboBox_NewItem_Coin.SelectedIndex == 1) ? 3 : 5));
                            this.frm_Parent.Packages[m] = value4;
                            IL_1FE7:
                            for (int n = 0; n < selected_iList.Count; n++)
                            {
                                for (int num8 = 0; num8 < this.frm_Parent.ItemsList.Count; num8++)
                                {
                                    if (selected_iList[n].TraceString == this.frm_Parent.ItemsList[num8].TraceString)
                                    {
                                        Structures.IGCCashItemList value5 = this.frm_Parent.ItemsList[num8];
                                        value5.cType = this.comboBox_NewItem_Coin.SelectedIndex;
                                        value5.iPrice = (int) this.numericUpDown_NewItem_Price.Value;
                                        value5.Name = this.textBox_NewItem_Name.Text;
                                        this.frm_Parent.ItemsList[num8] = value5;
                                        break;
                                    }
                                }
                            }

                            foreach (Structures.IGCCashItemPackages item5 in selected_iPack)
                            {
                                this.frm_Parent.ItemsPackage.Remove(item5);
                                List<string> igc_CashItemPackages_Indexes =
                                    this.frm_Parent.IGC_CashItemPackages_Indexes;
                                int num7 = item5.GUID;
                                object arg = num7.ToString();
                                object arg2 = ',';
                                num7 = item5.iGUID;
                                igc_CashItemPackages_Indexes.Remove(arg + (string) arg2 + num7.ToString());
                            }

                            int num9 = 0;
                            foreach (object obj in this.listBox_PackageItem_AddedItems.Items)
                            {
                                Structures.IGCCashItemInfo igccashItemInfo3 = (Structures.IGCCashItemInfo) obj;
                                Structures.IGCCashItemPackages item6 = new Structures.IGCCashItemPackages
                                {
                                    pID = selected_iList[0].pID,
                                    GUID = num9,
                                    iSeq = num9,
                                    iGUID = igccashItemInfo3.GID,
                                    iID = igccashItemInfo3.ID,
                                    Name = igccashItemInfo3.Name,
                                    PackName = this.textBox_NewItem_Name.Text,
                                    TraceString = igccashItemInfo3.TraceString
                                };
                                this.frm_Parent.IGC_CashItemPackages_Indexes.Add(
                                    item6.GUID.ToString() + ',' + item6.iGUID.ToString());
                                this.frm_Parent.ItemsPackage.Add(item6);
                                num9++;
                            }

                            goto IL_2243;
                        }
                    }
                }
				for (int num10 = 0; num10 < selected_iList.Count; num10++)
				{
					for (int num11 = 0; num11 < this.frm_Parent.ItemsList.Count; num11++)
					{
						if (selected_iList[num10].TraceString == this.frm_Parent.ItemsList[num11].TraceString)
						{
							Structures.IGCCashItemList value6 = this.frm_Parent.ItemsList[num11];
							value6.Name = this.textBox_NewItem_Name.Text;
							value6.iPrice = Convert.ToInt32(this.numericUpDown_NewItem_Price.Value);
							value6.cType = this.comboBox_NewItem_Coin.SelectedIndex;
							this.frm_Parent.ItemsList[num11] = value6;
							if (num10 + 1 == selected_iList.Count)
							{
								break;
							}
						}
					}
				}
				for (int num12 = 0; num12 < selected_iInfo.Count; num12++)
				{
					for (int num13 = 0; num13 < this.frm_Parent.ItemsInfo.Count; num13++)
					{
						if (selected_iInfo[num12].TraceString == this.frm_Parent.ItemsInfo[num13].TraceString)
						{
							Structures.IGCCashItemInfo value7 = this.frm_Parent.ItemsInfo[num13];
							value7.Level = (int)this.listBox_NewItem_ItemLevel.SelectedValue;
							value7.Dur = (int)this.numericUpDown_NewItem_Durability.Value;
							value7.Skill = (this.checkBox_NewItem_Skill.Checked ? 1 : 0);
							value7.Luck = (this.checkBox_NewItem_Luck.Checked ? 1 : 0);
							value7.Option = (int)this.listBox_NewItem_ItemOption.SelectedValue;
							value7.TraceNumber = this.frm_Parent.TraceNumber;
							int num14 = 0;
							num14 = (this.checkBox_NewItem_ExcOpt1.Checked ? (num14 + 1) : num14);
							num14 = (this.checkBox_NewItem_ExcOpt2.Checked ? (num14 + 2) : num14);
							num14 = (this.checkBox_NewItem_ExcOpt3.Checked ? (num14 + 4) : num14);
							num14 = (this.checkBox_NewItem_ExcOpt4.Checked ? (num14 + 8) : num14);
							num14 = (this.checkBox_NewItem_ExcOpt5.Checked ? (num14 + 16) : num14);
							num14 = (this.checkBox_NewItem_ExcOpt6.Checked ? (num14 + 32) : num14);
							value7.Exc = num14;
							value7.Ancient = (int)this.comboBox_Ancient.SelectedValue;
							value7.Socket = (int)this.numericUpDown_NewItem_SocketCount.Value;
							value7.Name = this.textBox_NewItem_Name.Text;
							this.frm_Parent.ItemsInfo[num13] = value7;
							if (num12 + 1 == selected_iInfo.Count)
							{
								break;
							}
						}
					}
				}
				for (int num15 = 0; num15 < this.frm_Parent.Products.Count; num15++)
				{
					if (this.frm_Parent.Products[num15].Index1 == selected_iProduct[0].Index1 && this.frm_Parent.Products[num15].Index7 == selected_iProduct[0].Index7)
					{
						for (int num16 = 0; num16 < selected_iProduct.Count; num16++)
						{
							if (this.frm_Parent.Products[num15].Index1 == selected_iProduct[num16].Index1 && this.frm_Parent.Products[num15].Index7 == selected_iProduct[num16].Index7)
							{
								Structures.IBSProduct value8 = selected_iProduct[num16];
								value8.Name = this.textBox_NewItem_Name.Text;
								value8.BuyTypeTxt1 = ((this.comboBox_NewItem_CountType.SelectedIndex == 0) ? "Quantity" : ((this.comboBox_NewItem_CountType.SelectedIndex == 1) ? "Duration" : ((this.comboBox_NewItem_CountType.SelectedIndex == 2) ? "Duration" : ((this.comboBox_NewItem_CountType.SelectedIndex == 3) ? "Quantity" : "Duration"))));
								int num17 = Convert.ToInt32(this.numericUpDown_NewItem_Count.Value);
								TimeSpan timeSpan3 = default(TimeSpan);
								TimeSpan ts3 = TimeSpan.FromMinutes((double)num17);
								timeSpan3.Add(ts3);
								string text3 = "[";
								text3 += ((ts3.TotalDays >= 1.0) ? (Convert.ToInt32(ts3.TotalDays).ToString() + " Day(s)") : ((ts3.TotalHours >= 1.0) ? (Convert.ToInt32(ts3.TotalHours).ToString() + " Hour(s)") : (Convert.ToInt32(ts3.TotalMinutes).ToString() + " Minute(s)")));
								if (text3.Contains("Day(s)"))
								{
									string str3 = text3 + ((ts3.Hours >= 1) ? (", " + Convert.ToInt32(ts3.Hours).ToString() + " Hour(s)") : "");
									text3 = str3 + ((ts3.Minutes >= 1) ? (", " + Convert.ToInt32(ts3.Minutes).ToString() + " Minute(s)") : "");
								}
								else if (text3.Contains("Hour(s)"))
								{
									text3 += ((ts3.Minutes >= 1) ? (", " + Convert.ToInt32(ts3.Minutes).ToString() + " Minute(s)") : "");
								}
								text3 += "]";
								value8.TypeCount = num17.ToString();
								value8.BuyTypeTxt2 = ((this.comboBox_NewItem_CountType.SelectedIndex == 0) ? "EA" : ((this.comboBox_NewItem_CountType.SelectedIndex == 1) ? text3 : ((this.comboBox_NewItem_CountType.SelectedIndex == 2) ? text3 : ((this.comboBox_NewItem_CountType.SelectedIndex == 3) ? "NA" : "Days"))));
								value8.Price = (int)this.numericUpDown_NewItem_Price.Value;
								this.frm_Parent.Products[this.frm_Parent.Products.IndexOf(selected_iProduct[num16])] = value8;
							}
						}
						break;
					}
				}
				for (int num18 = 0; num18 < this.frm_Parent.Packages.Count; num18++)
				{
					if (selected_iPackage.TraceString == this.frm_Parent.Packages[num18].TraceString)
					{
						Structures.IBSPackage value9 = this.frm_Parent.Packages[num18];
						value9.Name = this.textBox_NewItem_Name.Text;
						value9.Price = (int)this.numericUpDown_NewItem_Price.Value;
						value9.Info = this.richTextBox_NewItem_Info.Text.Replace("\n", "#");
						value9.Unk3 = Convert.ToInt16((this.comboBox_NewItem_Coin.SelectedIndex == 0) ? 185 : ((this.comboBox_NewItem_Coin.SelectedIndex == 1) ? 184 : 185));
						value9.CoinTxt1 = this.comboBox_NewItem_Coin.Text;
						value9.CoinTxt2 = this.comboBox_NewItem_Coin.Text;
						value9.ServerCatIndex = ((this.comboBox_NewItem_Coin.SelectedIndex == 0) ? 508 : ((this.comboBox_NewItem_Coin.SelectedIndex == 1) ? 509 : 0));
						value9.Unk10 = Convert.ToInt16((this.comboBox_NewItem_Coin.SelectedIndex == 0) ? 2 : ((this.comboBox_NewItem_Coin.SelectedIndex == 1) ? 3 : 5));
						this.frm_Parent.Packages[num18] = value9;
						break;
					}
				}
			}
			IL_2243:
			this.frm_Parent.UpdateSelectedItem(this.frm_Parent.LastSelectedPB);
			this.textBox_Info.Text = "[INFO] Selected item Updated successfully.";
		}

		// Token: 0x06000612 RID: 1554 RVA: 0x0006F574 File Offset: 0x0006D774
		private void buttonClearAll_Multi_Click(object sender, EventArgs e)
		{
			for (int i = 1; i <= 6; i++)
			{
				CheckBox checkBox = (CheckBox)this.tabControl1.Controls["tabPage_MultiOption_" + i].Controls["checkBox_isMulti_" + i];
				checkBox.Checked = false;
				((TextBox)this.tabControl1.Controls["tabPage_MultiOption_" + i].Controls["textBox_Name_Multi_" + i]).Clear();
				NumericUpDown numericUpDown = (NumericUpDown)this.tabControl1.Controls["tabPage_MultiOption_" + i].Controls["numericUpDown_Count_Multi_" + i];
				numericUpDown.Value = numericUpDown.Minimum;
				NumericUpDown numericUpDown2 = (NumericUpDown)this.tabControl1.Controls["tabPage_MultiOption_" + i].Controls["numericUpDown_Price_Multi_" + i];
				numericUpDown2.Value = numericUpDown2.Minimum;
				ListBox listBox = (ListBox)this.tabControl1.Controls["tabPage_MultiOption_" + i].Controls["listBox_Level_Multi_" + i];
				listBox.SelectedIndex = 0;
				ListBox listBox2 = (ListBox)this.tabControl1.Controls["tabPage_MultiOption_" + i].Controls["listBox_Option_Multi_" + i];
				listBox2.SelectedIndex = 0;
				ComboBox comboBox = (ComboBox)this.tabControl1.Controls["tabPage_MultiOption_" + i].Controls["comboBox_Ancient_Multi_" + i];
				comboBox.SelectedIndex = 0;
				CheckBox checkBox2 = (CheckBox)this.tabControl1.Controls["tabPage_MultiOption_" + i].Controls["groupBox_" + i].Controls["checkBox_ExcOption1_Multi_" + i];
				checkBox2.Checked = false;
				CheckBox checkBox3 = (CheckBox)this.tabControl1.Controls["tabPage_MultiOption_" + i].Controls["groupBox_" + i].Controls["checkBox_ExcOption2_Multi_" + i];
				checkBox3.Checked = false;
				CheckBox checkBox4 = (CheckBox)this.tabControl1.Controls["tabPage_MultiOption_" + i].Controls["groupBox_" + i].Controls["checkBox_ExcOption3_Multi_" + i];
				checkBox4.Checked = false;
				CheckBox checkBox5 = (CheckBox)this.tabControl1.Controls["tabPage_MultiOption_" + i].Controls["groupBox_" + i].Controls["checkBox_ExcOption4_Multi_" + i];
				checkBox5.Checked = false;
				CheckBox checkBox6 = (CheckBox)this.tabControl1.Controls["tabPage_MultiOption_" + i].Controls["groupBox_" + i].Controls["checkBox_ExcOption5_Multi_" + i];
				checkBox6.Checked = false;
				CheckBox checkBox7 = (CheckBox)this.tabControl1.Controls["tabPage_MultiOption_" + i].Controls["groupBox_" + i].Controls["checkBox_ExcOption6_Multi_" + i];
				checkBox7.Checked = false;
				NumericUpDown numericUpDown3 = (NumericUpDown)this.tabControl1.Controls["tabPage_MultiOption_" + i].Controls["numericUpDown_Sockets_Multi_" + i];
				numericUpDown3.Value = numericUpDown3.Minimum;
				NumericUpDown numericUpDown4 = (NumericUpDown)this.tabControl1.Controls["tabPage_MultiOption_" + i].Controls["numericUpDown_Durability_Multi_" + i];
				numericUpDown4.Value = numericUpDown4.Maximum;
				CheckBox checkBox8 = (CheckBox)this.tabControl1.Controls["tabPage_MultiOption_" + i].Controls["checkBox_Luck_Multi_" + i];
				checkBox8.Checked = false;
				CheckBox checkBox9 = (CheckBox)this.tabControl1.Controls["tabPage_MultiOption_" + i].Controls["checkBox_Skill_Multi_" + i];
				checkBox9.Checked = false;
			}
		}

		// Token: 0x06000613 RID: 1555 RVA: 0x0006FB14 File Offset: 0x0006DD14
		private void checkBox_AddItem_FOItem_CheckedChanged(object sender, EventArgs e)
		{
			if (this.checkBox_AddItem_FOItem.Checked)
			{
				this.checkBox_NewItem_ExcOpt1.Checked = true;
				this.checkBox_NewItem_ExcOpt2.Checked = true;
				this.checkBox_NewItem_ExcOpt3.Checked = true;
				this.checkBox_NewItem_ExcOpt4.Checked = true;
				this.checkBox_NewItem_ExcOpt5.Checked = true;
				this.checkBox_NewItem_ExcOpt6.Checked = true;
				this.listBox_NewItem_ItemLevel.SelectedIndex = 15;
				this.listBox_NewItem_ItemOption.SelectedIndex = 7;
				this.checkBox_NewItem_Luck.Checked = true;
				return;
			}
			this.checkBox_NewItem_ExcOpt1.Checked = false;
			this.checkBox_NewItem_ExcOpt2.Checked = false;
			this.checkBox_NewItem_ExcOpt3.Checked = false;
			this.checkBox_NewItem_ExcOpt4.Checked = false;
			this.checkBox_NewItem_ExcOpt5.Checked = false;
			this.checkBox_NewItem_ExcOpt6.Checked = false;
			this.listBox_NewItem_ItemLevel.SelectedIndex = 0;
			this.listBox_NewItem_ItemOption.SelectedIndex = 0;
			this.checkBox_NewItem_Luck.Checked = false;
		}

		// Token: 0x06000614 RID: 1556 RVA: 0x0006FC08 File Offset: 0x0006DE08
		private void checkBox_MultiItem_CheckedChanged(object sender, EventArgs e)
		{
			this.groupBox_MultiItem.Enabled = this.checkBox_MultiItem.Checked;
			if (this.checkBox_MultiItem.Checked)
			{
				this.checkBox_PackageItem.Checked = false;
			}
		}

		// Token: 0x06000615 RID: 1557 RVA: 0x0006FC3C File Offset: 0x0006DE3C
		private void checkBox_PackageItem_CheckedChanged(object sender, EventArgs e)
		{
			this.groupBox_PackageItem.Enabled = this.checkBox_PackageItem.Checked;
			if (this.checkBox_PackageItem.Checked)
			{
				this.checkBox_MultiItem.Checked = false;
				this.numericUpDown_NewItem_Count.Enabled = false;
				this.numericUpDown_NewItem_Count.Value = 1m;
				this.comboBox_NewItem_CountType.Enabled = false;
				this.groupBox_ItemProperties.Enabled = false;
				this.comboBox_NewItem_CountType.SelectedIndex = 0;
				return;
			}
			this.numericUpDown_NewItem_Count.Enabled = true;
			this.comboBox_NewItem_CountType.Enabled = true;
			this.groupBox_ItemProperties.Enabled = true;
		}

		// Token: 0x06000617 RID: 1559 RVA: 0x0006FCFD File Offset: 0x0006DEFD
		private void Form_CashShop_AddItems_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!this.frm_Parent.isParentClosing && e.CloseReason == CloseReason.UserClosing)
			{
				e.Cancel = true;
			}
		}

		// Token: 0x06000618 RID: 1560 RVA: 0x0006FD1C File Offset: 0x0006DF1C
		private void Form_CashShop_AddItems_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Modifiers == Keys.Control)
			{
				if (e.KeyCode == Keys.S)
				{
					this.button_UpdateExistingItem.PerformClick();
					return;
				}
				if (e.KeyCode == Keys.D)
				{
					this.button_AddItemToDB.PerformClick();
					return;
				}
				if (e.KeyCode == Keys.F)
				{
					this.button_NewItem_Add.PerformClick();
				}
			}
		}

		// Token: 0x06000619 RID: 1561 RVA: 0x0006FD78 File Offset: 0x0006DF78
		private void Form_CashShop_AddItems_Load(object sender, EventArgs e)
		{
			base.TopMost = false;
			this.frm_Parent = (CashShopEditor)Application.OpenForms["CashShopEditor"];
			Form1 form = (Form1)Application.OpenForms[0];
			this.isEx700ItemList = (form.isEx700ItemList ? 1 : 0);
			string[,] array = null;
			if (this.isEx700ItemList == 1)
			{
				this.frm_Parent.strct.ReadItemList("Data\\ItemListSettings_ex700.ini", true, ref this.L_Groups, ref this.L_Swords, ref this.L_Axes, ref this.L_MacesScepters, ref this.L_Spears, ref this.L_BowsCrossBows, ref this.L_Staffs, ref this.L_Shields, ref this.L_Helms, ref this.L_Armors, ref this.L_Pants, ref this.L_Gloves, ref this.L_Boots, ref this.L_WingsSkillsSeedsOthers, ref this.L_Others1, ref this.L_Others2, ref this.L_Scrolls, ref array, ref array);
			}
			else
			{
				this.frm_Parent.strct.ReadItemList("Data\\ItemListSettings.ini", false, ref this.L_Groups, ref this.L_Swords, ref this.L_Axes, ref this.L_MacesScepters, ref this.L_Spears, ref this.L_BowsCrossBows, ref this.L_Staffs, ref this.L_Shields, ref this.L_Helms, ref this.L_Armors, ref this.L_Pants, ref this.L_Gloves, ref this.L_Boots, ref this.L_WingsSkillsSeedsOthers, ref this.L_Others1, ref this.L_Others2, ref this.L_Scrolls, ref array, ref array);
			}
			this.listBox_NewItem_ItemGroup.DisplayMember = "GroupName";
			this.listBox_NewItem_ItemGroup.ValueMember = "Group";
			this.listBox_NewItem_ItemGroup.DataSource = this.L_Groups;
			this.Setc_LevelData(ref this.listBox_NewItem_ItemLevel);
			this.Setc_OptionData(ref this.listBox_NewItem_ItemOption);
			this.comboBox_NewItem_Coin.SelectedIndex = 0;
			this.comboBox_NewItem_CountType.SelectedIndex = 0;
			this.Setc_LevelData(ref this.listBox_Level_Multi_1, ref this.c_LevelDatas_M1);
			this.Setc_LevelData(ref this.listBox_Level_Multi_2, ref this.c_LevelDatas_M2);
			this.Setc_LevelData(ref this.listBox_Level_Multi_3, ref this.c_LevelDatas_M3);
			this.Setc_LevelData(ref this.listBox_Level_Multi_4, ref this.c_LevelDatas_M4);
			this.Setc_LevelData(ref this.listBox_Level_Multi_5, ref this.c_LevelDatas_M5);
			this.Setc_LevelData(ref this.listBox_Level_Multi_6, ref this.c_LevelDatas_M6);
			this.Setc_OptionData(ref this.listBox_Option_Multi_1, ref this.c_OptionDatas_M1);
			this.Setc_OptionData(ref this.listBox_Option_Multi_2, ref this.c_OptionDatas_M2);
			this.Setc_OptionData(ref this.listBox_Option_Multi_3, ref this.c_OptionDatas_M3);
			this.Setc_OptionData(ref this.listBox_Option_Multi_4, ref this.c_OptionDatas_M4);
			this.Setc_OptionData(ref this.listBox_Option_Multi_5, ref this.c_OptionDatas_M5);
			this.Setc_OptionData(ref this.listBox_Option_Multi_6, ref this.c_OptionDatas_M6);
			this.Setc_AncientData(ref this.comboBox_Ancient, ref this.c_AncientDatas);
			this.Setc_AncientData(ref this.comboBox_Ancient_Multi_1, ref this.c_AncientDatas_M1);
			this.Setc_AncientData(ref this.comboBox_Ancient_Multi_2, ref this.c_AncientDatas_M2);
			this.Setc_AncientData(ref this.comboBox_Ancient_Multi_3, ref this.c_AncientDatas_M3);
			this.Setc_AncientData(ref this.comboBox_Ancient_Multi_4, ref this.c_AncientDatas_M4);
			this.Setc_AncientData(ref this.comboBox_Ancient_Multi_5, ref this.c_AncientDatas_M5);
			this.Setc_AncientData(ref this.comboBox_Ancient_Multi_6, ref this.c_AncientDatas_M6);
			this.comboBox_PackageItem_ItemsDatabase.DataSource = this.frm_Parent.ItemsInfo;
			this.comboBox_PackageItem_ItemsDatabase.ValueMember = "Name";
			this.comboBox_PackageItem_ItemsDatabase.DisplayMember = "Name";
			this.listBox_PackageItem_AddedItems.DataSource = this.PackageItems;
			this.listBox_PackageItem_AddedItems.DisplayMember = "Name";
			this.listBox_PackageItem_AddedItems.ValueMember = "Name";
		}

		// Token: 0x0600061B RID: 1563 RVA: 0x0007A40C File Offset: 0x0007860C
		private void listBox_NewItem_ItemGroup_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.PopulateItemIndex(this.listBox_NewItem_ItemIndex, this.listBox_NewItem_ItemGroup);
			if (this.frm_Parent.LastSelectedItemIndex <= this.listBox_NewItem_ItemIndex.Items.Count - 1)
			{
				this.listBox_NewItem_ItemIndex.SelectedIndex = -1;
				this.listBox_NewItem_ItemIndex.SelectedIndex = this.frm_Parent.LastSelectedItemIndex;
			}
			else
			{
				this.listBox_NewItem_ItemIndex.SelectedIndex = -1;
				this.listBox_NewItem_ItemIndex.SelectedIndex = 0;
			}
			if (this.FirstRun)
			{
				this.listBox_NewItem_ItemIndex.SelectedIndex = -1;
				this.listBox_NewItem_ItemIndex.SelectedIndex = 0;
				this.FirstRun = false;
			}
			switch (this.listBox_NewItem_ItemGroup.SelectedIndex)
			{
			case 0:
			case 1:
			case 2:
			case 3:
			case 4:
			case 5:
				this.radioButton_NewItem_ExcWeapon.Checked = true;
				this.radioButton_Weapon_Multi_1.Checked = true;
				this.radioButton_Weapon_Multi_2.Checked = true;
				this.radioButton_Weapon_Multi_3.Checked = true;
				this.radioButton_Weapon_Multi_4.Checked = true;
				this.radioButton_Weapon_Multi_5.Checked = true;
				this.radioButton_Weapon_Multi_6.Checked = true;
				return;
			case 6:
			case 7:
			case 8:
			case 9:
			case 10:
			case 11:
				this.radioButton_NewItem_ExcArmor.Checked = true;
				this.radioButton_Armor_Multi_1.Checked = true;
				this.radioButton_Armor_Multi_2.Checked = true;
				this.radioButton_Armor_Multi_3.Checked = true;
				this.radioButton_Armor_Multi_4.Checked = true;
				this.radioButton_Armor_Multi_5.Checked = true;
				this.radioButton_Armor_Multi_6.Checked = true;
				return;
			case 12:
				this.radioButton_NewItem_ExcWings.Checked = true;
				this.radioButton_Wings_Multi_1.Checked = true;
				this.radioButton_Wings_Multi_2.Checked = true;
				this.radioButton_Wings_Multi_3.Checked = true;
				this.radioButton_Wings_Multi_4.Checked = true;
				this.radioButton_Wings_Multi_5.Checked = true;
				this.radioButton_Wings_Multi_6.Checked = true;
				return;
			default:
				return;
			}
		}

		// Token: 0x0600061C RID: 1564 RVA: 0x0007A5F4 File Offset: 0x000787F4
		private void listBox_NewItem_ItemIndex_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.listBox_NewItem_ItemIndex.SelectedIndex != -1 && !this.DontWork)
			{
				this.frm_Parent.LastSelectedItemIndex = this.listBox_NewItem_ItemIndex.SelectedIndex;
				try
				{
					this.textBox_NewItem_Name.Text = this.listBox_NewItem_ItemIndex.Text.Trim();
					this.pictureBox_NewItem_ItemPreview.BackgroundImage = (Bitmap)Resources.ResourceManager.GetObject("_" + this.listBox_NewItem_ItemGroup.SelectedValue + this.listBox_NewItem_ItemIndex.SelectedValue);
					if (this.pictureBox_NewItem_ItemPreview.BackgroundImage.Size.Width > this.pictureBox_NewItem_ItemPreview.Size.Width || this.pictureBox_NewItem_ItemPreview.BackgroundImage.Size.Height > this.pictureBox_NewItem_ItemPreview.Size.Height)
					{
						this.pictureBox_NewItem_ItemPreview.BackgroundImageLayout = ImageLayout.Zoom;
					}
					else
					{
						this.pictureBox_NewItem_ItemPreview.BackgroundImageLayout = ImageLayout.Center;
					}
				}
				catch
				{
					this.pictureBox_NewItem_ItemPreview.BackgroundImage = (Bitmap)Resources.ResourceManager.GetObject("no_img");
				}
			}
		}

		// Token: 0x0600061D RID: 1565 RVA: 0x0007A730 File Offset: 0x00078930
		public void PopulateItemIndex(ListBox ItemIndex, ListBox ItemGroup)
		{
			this.DontWork = true;
			switch (ItemGroup.SelectedIndex)
			{
			case 0:
				ItemIndex.DisplayMember = "Name";
				ItemIndex.ValueMember = "Index";
				ItemIndex.DataSource = this.L_Swords;
				break;
			case 1:
				ItemIndex.DisplayMember = "Name";
				ItemIndex.ValueMember = "Index";
				ItemIndex.DataSource = this.L_Axes;
				break;
			case 2:
				ItemIndex.DisplayMember = "Name";
				ItemIndex.ValueMember = "Index";
				ItemIndex.DataSource = this.L_MacesScepters;
				break;
			case 3:
				ItemIndex.DisplayMember = "Name";
				ItemIndex.ValueMember = "Index";
				ItemIndex.DataSource = this.L_Spears;
				break;
			case 4:
				ItemIndex.DisplayMember = "Name";
				ItemIndex.ValueMember = "Index";
				ItemIndex.DataSource = this.L_BowsCrossBows;
				break;
			case 5:
				ItemIndex.DisplayMember = "Name";
				ItemIndex.ValueMember = "Index";
				ItemIndex.DataSource = this.L_Staffs;
				break;
			case 6:
				ItemIndex.DisplayMember = "Name";
				ItemIndex.ValueMember = "Index";
				ItemIndex.DataSource = this.L_Shields;
				break;
			case 7:
				ItemIndex.DisplayMember = "Name";
				ItemIndex.ValueMember = "Index";
				ItemIndex.DataSource = this.L_Helms;
				break;
			case 8:
				ItemIndex.DisplayMember = "Name";
				ItemIndex.ValueMember = "Index";
				ItemIndex.DataSource = this.L_Armors;
				break;
			case 9:
				ItemIndex.DisplayMember = "Name";
				ItemIndex.ValueMember = "Index";
				ItemIndex.DataSource = this.L_Pants;
				break;
			case 10:
				ItemIndex.DisplayMember = "Name";
				ItemIndex.ValueMember = "Index";
				ItemIndex.DataSource = this.L_Gloves;
				break;
			case 11:
				ItemIndex.DisplayMember = "Name";
				ItemIndex.ValueMember = "Index";
				ItemIndex.DataSource = this.L_Boots;
				break;
			case 12:
				ItemIndex.DisplayMember = "Name";
				ItemIndex.ValueMember = "Index";
				ItemIndex.DataSource = this.L_WingsSkillsSeedsOthers;
				break;
			case 13:
				ItemIndex.DisplayMember = "Name";
				ItemIndex.ValueMember = "Index";
				ItemIndex.DataSource = this.L_Others1;
				break;
			case 14:
				ItemIndex.DisplayMember = "Name";
				ItemIndex.ValueMember = "Index";
				ItemIndex.DataSource = this.L_Others2;
				break;
			case 15:
				ItemIndex.DisplayMember = "Name";
				ItemIndex.ValueMember = "Index";
				ItemIndex.DataSource = this.L_Scrolls;
				break;
			}
			this.DontWork = false;
		}

		// Token: 0x0600061E RID: 1566 RVA: 0x0007AA00 File Offset: 0x00078C00
		private void radioButton_ExcArmor_CheckedChanged(object sender, EventArgs e)
		{
			this.checkBox_NewItem_ExcOpt1.Text = "Zen Drop +30%";
			this.checkBox_NewItem_ExcOpt2.Text = "Def Success Rate +10%";
			this.checkBox_NewItem_ExcOpt3.Text = "Reflect +5%";
			this.checkBox_NewItem_ExcOpt4.Text = "Damage Decrease +4%";
			this.checkBox_NewItem_ExcOpt5.Text = "Mana +4%";
			this.checkBox_NewItem_ExcOpt6.Text = "HP +4%";
		}

		// Token: 0x0600061F RID: 1567 RVA: 0x0007AA70 File Offset: 0x00078C70
		private void radioButton_ExcWeapon_CheckedChanged(object sender, EventArgs e)
		{
			this.checkBox_NewItem_ExcOpt1.Text = "Mob Kill +mana/8";
			this.checkBox_NewItem_ExcOpt2.Text = "Mob Kill +life/8";
			this.checkBox_NewItem_ExcOpt3.Text = "Attack(Wizardy) Speed +7";
			this.checkBox_NewItem_ExcOpt4.Text = "Damage +2%";
			this.checkBox_NewItem_ExcOpt5.Text = "Damage +level/20";
			this.checkBox_NewItem_ExcOpt6.Text = "Exc Damage Rate +10%";
		}

		// Token: 0x06000620 RID: 1568 RVA: 0x0007AAE0 File Offset: 0x00078CE0
		private void radioButton_ExcWings_CheckedChanged(object sender, EventArgs e)
		{
			this.checkBox_NewItem_ExcOpt1.Text = "Ignor Def +5% / HP +125";
			this.checkBox_NewItem_ExcOpt2.Text = "Return Attack +5% / Mana +125";
			this.checkBox_NewItem_ExcOpt3.Text = "Life Recovery +5% /Ignor Def +3%";
			this.checkBox_NewItem_ExcOpt4.Text = "Mana Recovery +5% / AG +50";
			this.checkBox_NewItem_ExcOpt5.Text = "--- / Attack(Wiz) Speed+5";
			this.checkBox_NewItem_ExcOpt6.Text = "---";
		}

		// Token: 0x06000621 RID: 1569 RVA: 0x0007AB50 File Offset: 0x00078D50
		private void radioButton_Multi_ExcArmor_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton radioButton = (RadioButton)sender;
			string[] array = radioButton.Name.Split(new char[]
			{
				'_'
			});
			CheckBox checkBox = (CheckBox)this.tabControl1.Controls["tabPage_MultiOption_" + array[array.Length - 1]].Controls["groupBox_" + array[array.Length - 1]].Controls["checkBox_ExcOption1_Multi_" + array[array.Length - 1]];
			checkBox.Text = "Zen Drop +30%";
			checkBox = (CheckBox)this.tabControl1.Controls["tabPage_MultiOption_" + array[array.Length - 1]].Controls["groupBox_" + array[array.Length - 1]].Controls["checkBox_ExcOption2_Multi_" + array[array.Length - 1]];
			checkBox.Text = "Def Success Rate +10%";
			checkBox = (CheckBox)this.tabControl1.Controls["tabPage_MultiOption_" + array[array.Length - 1]].Controls["groupBox_" + array[array.Length - 1]].Controls["checkBox_ExcOption3_Multi_" + array[array.Length - 1]];
			checkBox.Text = "Reflect +5%";
			checkBox = (CheckBox)this.tabControl1.Controls["tabPage_MultiOption_" + array[array.Length - 1]].Controls["groupBox_" + array[array.Length - 1]].Controls["checkBox_ExcOption4_Multi_" + array[array.Length - 1]];
			checkBox.Text = "Damage Decrease +4%";
			checkBox = (CheckBox)this.tabControl1.Controls["tabPage_MultiOption_" + array[array.Length - 1]].Controls["groupBox_" + array[array.Length - 1]].Controls["checkBox_ExcOption5_Multi_" + array[array.Length - 1]];
			checkBox.Text = "Mana +4%";
			checkBox = (CheckBox)this.tabControl1.Controls["tabPage_MultiOption_" + array[array.Length - 1]].Controls["groupBox_" + array[array.Length - 1]].Controls["checkBox_ExcOption6_Multi_" + array[array.Length - 1]];
			checkBox.Text = "HP +4%";
		}

		// Token: 0x06000622 RID: 1570 RVA: 0x0007ADF0 File Offset: 0x00078FF0
		private void radioButton_Multi_ExcWeapon_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton radioButton = (RadioButton)sender;
			string[] array = radioButton.Name.Split(new char[]
			{
				'_'
			});
			CheckBox checkBox = (CheckBox)this.tabControl1.Controls["tabPage_MultiOption_" + array[array.Length - 1]].Controls["groupBox_" + array[array.Length - 1]].Controls["checkBox_ExcOption1_Multi_" + array[array.Length - 1]];
			checkBox.Text = "Mob Kill +mana/8";
			checkBox = (CheckBox)this.tabControl1.Controls["tabPage_MultiOption_" + array[array.Length - 1]].Controls["groupBox_" + array[array.Length - 1]].Controls["checkBox_ExcOption2_Multi_" + array[array.Length - 1]];
			checkBox.Text = "Mob Kill +life/8";
			checkBox = (CheckBox)this.tabControl1.Controls["tabPage_MultiOption_" + array[array.Length - 1]].Controls["groupBox_" + array[array.Length - 1]].Controls["checkBox_ExcOption3_Multi_" + array[array.Length - 1]];
			checkBox.Text = "Attack(Wizardy) Speed +7";
			checkBox = (CheckBox)this.tabControl1.Controls["tabPage_MultiOption_" + array[array.Length - 1]].Controls["groupBox_" + array[array.Length - 1]].Controls["checkBox_ExcOption4_Multi_" + array[array.Length - 1]];
			checkBox.Text = "Damage +2%";
			checkBox = (CheckBox)this.tabControl1.Controls["tabPage_MultiOption_" + array[array.Length - 1]].Controls["groupBox_" + array[array.Length - 1]].Controls["checkBox_ExcOption5_Multi_" + array[array.Length - 1]];
			checkBox.Text = "Damage +level/20";
			checkBox = (CheckBox)this.tabControl1.Controls["tabPage_MultiOption_" + array[array.Length - 1]].Controls["groupBox_" + array[array.Length - 1]].Controls["checkBox_ExcOption6_Multi_" + array[array.Length - 1]];
			checkBox.Text = "Exc Damage Rate +10%";
		}

		// Token: 0x06000623 RID: 1571 RVA: 0x0007B090 File Offset: 0x00079290
		private void radioButton_Multi_ExcWings_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton radioButton = (RadioButton)sender;
			string[] array = radioButton.Name.Split(new char[]
			{
				'_'
			});
			CheckBox checkBox = (CheckBox)this.tabControl1.Controls["tabPage_MultiOption_" + array[array.Length - 1]].Controls["groupBox_" + array[array.Length - 1]].Controls["checkBox_ExcOption1_Multi_" + array[array.Length - 1]];
			checkBox.Text = "Ignor Def +5% / HP +125";
			checkBox = (CheckBox)this.tabControl1.Controls["tabPage_MultiOption_" + array[array.Length - 1]].Controls["groupBox_" + array[array.Length - 1]].Controls["checkBox_ExcOption2_Multi_" + array[array.Length - 1]];
			checkBox.Text = "Return Attack +5% / Mana +125";
			checkBox = (CheckBox)this.tabControl1.Controls["tabPage_MultiOption_" + array[array.Length - 1]].Controls["groupBox_" + array[array.Length - 1]].Controls["checkBox_ExcOption3_Multi_" + array[array.Length - 1]];
			checkBox.Text = "Life Recovery +5% /Ignor Def +3%";
			checkBox = (CheckBox)this.tabControl1.Controls["tabPage_MultiOption_" + array[array.Length - 1]].Controls["groupBox_" + array[array.Length - 1]].Controls["checkBox_ExcOption4_Multi_" + array[array.Length - 1]];
			checkBox.Text = "Mana Recovery +5% / AG +50";
			checkBox = (CheckBox)this.tabControl1.Controls["tabPage_MultiOption_" + array[array.Length - 1]].Controls["groupBox_" + array[array.Length - 1]].Controls["checkBox_ExcOption5_Multi_" + array[array.Length - 1]];
			checkBox.Text = "--- / Attack(Wiz) Speed+5";
			checkBox = (CheckBox)this.tabControl1.Controls["tabPage_MultiOption_" + array[array.Length - 1]].Controls["groupBox_" + array[array.Length - 1]].Controls["checkBox_ExcOption6_Multi_" + array[array.Length - 1]];
			checkBox.Text = "---";
		}

		// Token: 0x06000624 RID: 1572 RVA: 0x0007B330 File Offset: 0x00079530
		public void Setc_AncientData(ref ComboBox cb, ref List<Structures.c_AncientData> list)
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
			cb.DataSource = list;
			cb.ValueMember = "ID";
			cb.DisplayMember = "Name";
		}

		// Token: 0x06000625 RID: 1573 RVA: 0x0007B3D0 File Offset: 0x000795D0
		public void Setc_LevelData(ref ListBox lb)
		{
			this.c_LevelDatas.Add(new Structures.c_LevelData(0, "+0"));
			this.c_LevelDatas.Add(new Structures.c_LevelData(1, "+1"));
			this.c_LevelDatas.Add(new Structures.c_LevelData(2, "+2"));
			this.c_LevelDatas.Add(new Structures.c_LevelData(3, "+3"));
			this.c_LevelDatas.Add(new Structures.c_LevelData(4, "+4"));
			this.c_LevelDatas.Add(new Structures.c_LevelData(5, "+5"));
			this.c_LevelDatas.Add(new Structures.c_LevelData(6, "+6"));
			this.c_LevelDatas.Add(new Structures.c_LevelData(7, "+7"));
			this.c_LevelDatas.Add(new Structures.c_LevelData(8, "+8"));
			this.c_LevelDatas.Add(new Structures.c_LevelData(9, "+9"));
			this.c_LevelDatas.Add(new Structures.c_LevelData(10, "+10"));
			this.c_LevelDatas.Add(new Structures.c_LevelData(11, "+11"));
			this.c_LevelDatas.Add(new Structures.c_LevelData(12, "+12"));
			this.c_LevelDatas.Add(new Structures.c_LevelData(13, "+13"));
			this.c_LevelDatas.Add(new Structures.c_LevelData(14, "+14"));
			this.c_LevelDatas.Add(new Structures.c_LevelData(15, "+15"));
			lb.DataSource = this.c_LevelDatas;
			lb.ValueMember = "ID";
			lb.DisplayMember = "Name";
		}

		// Token: 0x06000626 RID: 1574 RVA: 0x0007B56C File Offset: 0x0007976C
		public void Setc_LevelData(ref ListBox lb, ref List<Structures.c_LevelData> c_LevelDatas)
		{
			c_LevelDatas.Add(new Structures.c_LevelData(0, "+0"));
			c_LevelDatas.Add(new Structures.c_LevelData(1, "+1"));
			c_LevelDatas.Add(new Structures.c_LevelData(2, "+2"));
			c_LevelDatas.Add(new Structures.c_LevelData(3, "+3"));
			c_LevelDatas.Add(new Structures.c_LevelData(4, "+4"));
			c_LevelDatas.Add(new Structures.c_LevelData(5, "+5"));
			c_LevelDatas.Add(new Structures.c_LevelData(6, "+6"));
			c_LevelDatas.Add(new Structures.c_LevelData(7, "+7"));
			c_LevelDatas.Add(new Structures.c_LevelData(8, "+8"));
			c_LevelDatas.Add(new Structures.c_LevelData(9, "+9"));
			c_LevelDatas.Add(new Structures.c_LevelData(10, "+10"));
			c_LevelDatas.Add(new Structures.c_LevelData(11, "+11"));
			c_LevelDatas.Add(new Structures.c_LevelData(12, "+12"));
			c_LevelDatas.Add(new Structures.c_LevelData(13, "+13"));
			c_LevelDatas.Add(new Structures.c_LevelData(14, "+14"));
			c_LevelDatas.Add(new Structures.c_LevelData(15, "+15"));
			lb.DataSource = c_LevelDatas;
			lb.ValueMember = "ID";
			lb.DisplayMember = "Name";
		}

		// Token: 0x06000627 RID: 1575 RVA: 0x0007B6C4 File Offset: 0x000798C4
		public void Setc_OptionData(ref ListBox lb)
		{
			Structures.c_OptionData item = new Structures.c_OptionData
			{
				ID = 0,
				Name = "+0"
			};
			this.c_OptionDatas.Add(item);
			item.ID = 1;
			item.Name = "+4";
			this.c_OptionDatas.Add(item);
			item.ID = 2;
			item.Name = "+8";
			this.c_OptionDatas.Add(item);
			item.ID = 3;
			item.Name = "+12";
			this.c_OptionDatas.Add(item);
			item.ID = 4;
			item.Name = "+16";
			this.c_OptionDatas.Add(item);
			item.ID = 5;
			item.Name = "+20";
			this.c_OptionDatas.Add(item);
			item.ID = 6;
			item.Name = "+24";
			this.c_OptionDatas.Add(item);
			item.ID = 7;
			item.Name = "+28";
			this.c_OptionDatas.Add(item);
			lb.DataSource = this.c_OptionDatas;
			lb.DisplayMember = "Name";
			lb.ValueMember = "ID";
		}

		// Token: 0x06000628 RID: 1576 RVA: 0x0007B800 File Offset: 0x00079A00
		public void Setc_OptionData(ref ListBox lb, ref List<Structures.c_OptionData> c_OptionDatas)
		{
			Structures.c_OptionData item = new Structures.c_OptionData
			{
				ID = 0,
				Name = "+0"
			};
			c_OptionDatas.Add(item);
			item.ID = 1;
			item.Name = "+4";
			c_OptionDatas.Add(item);
			item.ID = 2;
			item.Name = "+8";
			c_OptionDatas.Add(item);
			item.ID = 3;
			item.Name = "+12";
			c_OptionDatas.Add(item);
			item.ID = 4;
			item.Name = "+16";
			c_OptionDatas.Add(item);
			item.ID = 5;
			item.Name = "+20";
			c_OptionDatas.Add(item);
			item.ID = 6;
			item.Name = "+24";
			c_OptionDatas.Add(item);
			item.ID = 7;
			item.Name = "+28";
			c_OptionDatas.Add(item);
			lb.DataSource = c_OptionDatas;
			lb.DisplayMember = "Name";
			lb.ValueMember = "ID";
		}

		// Token: 0x06000629 RID: 1577 RVA: 0x0007B918 File Offset: 0x00079B18
		public void UpdateAddedItem()
		{
			BindingList<Structures.IGCCashItemList> selected_iList = this.frm_Parent.Selected_iList;
			BindingList<Structures.IGCCashItemInfo> selected_iInfo = this.frm_Parent.Selected_iInfo;
			BindingList<Structures.IGCCashItemPackages> selected_iPack = this.frm_Parent.Selected_iPack;
			Structures.IBSPackage selected_iPackage = this.frm_Parent.Selected_iPackage;
			BindingList<Structures.IBSProduct> selected_iProduct = this.frm_Parent.Selected_iProduct;
			this.checkBox_PackageItem.Enabled = true;
			this.checkBox_MultiItem.Enabled = true;
			this.groupBox_ItemProperties.Enabled = true;
			this.textBox_NewItem_Name.Text = selected_iPackage.Name;
			this.numericUpDown_NewItem_Price.Value = selected_iList[0].iPrice;
			this.comboBox_NewItem_Coin.SelectedIndex = selected_iList[0].cType;
			this.richTextBox_NewItem_Info.Text = selected_iPackage.Info.Replace("#", "\n");
			if (selected_iInfo.Count > 0)
			{
				this.numericUpDown_NewItem_Count.Value = ((selected_iInfo[0].Period > 0) ? selected_iInfo[0].Period : 1);
				this.comboBox_NewItem_CountType.SelectedIndex = selected_iInfo[0].Type;
				this.listBox_NewItem_ItemLevel.SelectedValue = selected_iInfo[0].Level;
				this.listBox_NewItem_ItemOption.SelectedValue = selected_iInfo[0].Option;
				this.comboBox_Ancient.SelectedIndex = ((selected_iInfo[0].Ancient == 5) ? 1 : ((selected_iInfo[0].Ancient == 10) ? 2 : 0));
				this.checkBox_NewItem_Skill.Checked = Convert.ToBoolean(selected_iInfo[0].Skill);
				this.checkBox_NewItem_Luck.Checked = Convert.ToBoolean(selected_iInfo[0].Luck);
				this.numericUpDown_NewItem_SocketCount.Value = selected_iInfo[0].Socket;
				this.numericUpDown_NewItem_Durability.Value = selected_iInfo[0].Dur;
				this.checkBox_NewItem_ExcOpt1.Checked = Convert.ToBoolean(selected_iInfo[0].Exc & 1);
				this.checkBox_NewItem_ExcOpt2.Checked = Convert.ToBoolean(selected_iInfo[0].Exc >> 1 & 1);
				this.checkBox_NewItem_ExcOpt3.Checked = Convert.ToBoolean(selected_iInfo[0].Exc >> 2 & 1);
				this.checkBox_NewItem_ExcOpt4.Checked = Convert.ToBoolean(selected_iInfo[0].Exc >> 3 & 1);
				this.checkBox_NewItem_ExcOpt5.Checked = Convert.ToBoolean(selected_iInfo[0].Exc >> 4 & 1);
				this.checkBox_NewItem_ExcOpt6.Checked = Convert.ToBoolean(selected_iInfo[0].Exc >> 5 & 1);
			}
			if (selected_iList[0].pID > 0)
			{
				this.PackageItems.Clear();
				this.checkBox_PackageItem.Checked = true;
				using (IEnumerator<Structures.IGCCashItemPackages> enumerator = selected_iPack.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						Structures.IGCCashItemPackages igccashItemPackages = enumerator.Current;
						for (int i = 0; i < this.frm_Parent.ItemsInfo.Count; i++)
						{
							if (this.frm_Parent.ItemsInfo[i].GID == igccashItemPackages.iGUID && this.frm_Parent.ItemsInfo[i].ID == igccashItemPackages.iID)
							{
								this.PackageItems.Add(this.frm_Parent.ItemsInfo[i]);
								break;
							}
						}
					}
					goto IL_39C;
				}
			}
			this.PackageItems.Clear();
			this.checkBox_PackageItem.Checked = false;
			IL_39C:
			if (selected_iPackage.CheckBoxCount > 1)
			{
				this.checkBox_MultiItem.Checked = true;
				for (int j = 1; j <= (int)selected_iPackage.CheckBoxCount; j++)
				{
					if (j >= 7)
					{
						break;
					}
					CheckBox checkBox = (CheckBox)this.tabControl1.Controls["tabPage_MultiOption_" + j].Controls["checkBox_isMulti_" + j];
					TextBox textBox = (TextBox)this.tabControl1.Controls["tabPage_MultiOption_" + j].Controls["textBox_Name_Multi_" + j];
					NumericUpDown numericUpDown = (NumericUpDown)this.tabControl1.Controls["tabPage_MultiOption_" + j].Controls["numericUpDown_Count_Multi_" + j];
					NumericUpDown numericUpDown2 = (NumericUpDown)this.tabControl1.Controls["tabPage_MultiOption_" + j].Controls["numericUpDown_Price_Multi_" + j];
					ListBox listBox = (ListBox)this.tabControl1.Controls["tabPage_MultiOption_" + j].Controls["listBox_Level_Multi_" + j];
					ListBox listBox2 = (ListBox)this.tabControl1.Controls["tabPage_MultiOption_" + j].Controls["listBox_Option_Multi_" + j];
					ComboBox comboBox = (ComboBox)this.tabControl1.Controls["tabPage_MultiOption_" + j].Controls["comboBox_Ancient_Multi_" + j];
					CheckBox checkBox2 = (CheckBox)this.tabControl1.Controls["tabPage_MultiOption_" + j].Controls["groupBox_" + j].Controls["checkBox_ExcOption1_Multi_" + j];
					CheckBox checkBox3 = (CheckBox)this.tabControl1.Controls["tabPage_MultiOption_" + j].Controls["groupBox_" + j].Controls["checkBox_ExcOption2_Multi_" + j];
					CheckBox checkBox4 = (CheckBox)this.tabControl1.Controls["tabPage_MultiOption_" + j].Controls["groupBox_" + j].Controls["checkBox_ExcOption3_Multi_" + j];
					CheckBox checkBox5 = (CheckBox)this.tabControl1.Controls["tabPage_MultiOption_" + j].Controls["groupBox_" + j].Controls["checkBox_ExcOption4_Multi_" + j];
					CheckBox checkBox6 = (CheckBox)this.tabControl1.Controls["tabPage_MultiOption_" + j].Controls["groupBox_" + j].Controls["checkBox_ExcOption5_Multi_" + j];
					CheckBox checkBox7 = (CheckBox)this.tabControl1.Controls["tabPage_MultiOption_" + j].Controls["groupBox_" + j].Controls["checkBox_ExcOption6_Multi_" + j];
					NumericUpDown numericUpDown3 = (NumericUpDown)this.tabControl1.Controls["tabPage_MultiOption_" + j].Controls["numericUpDown_Sockets_Multi_" + j];
					NumericUpDown numericUpDown4 = (NumericUpDown)this.tabControl1.Controls["tabPage_MultiOption_" + j].Controls["numericUpDown_Durability_Multi_" + j];
					CheckBox checkBox8 = (CheckBox)this.tabControl1.Controls["tabPage_MultiOption_" + j].Controls["checkBox_Luck_Multi_" + j];
					CheckBox checkBox9 = (CheckBox)this.tabControl1.Controls["tabPage_MultiOption_" + j].Controls["checkBox_Skill_Multi_" + j];
					checkBox.Checked = true;
					textBox.Text = selected_iInfo[j - 1].Name;
					numericUpDown.Value = ((selected_iInfo[j - 1].Period > 0) ? selected_iInfo[j - 1].Period : 1);
					numericUpDown2.Value = selected_iList[j - 1].iPrice;
					listBox.SelectedValue = selected_iInfo[j - 1].Level;
					listBox2.SelectedValue = selected_iInfo[j - 1].Option;
					comboBox.SelectedValue = selected_iInfo[j - 1].Ancient;
					checkBox2.Checked = Convert.ToBoolean(selected_iInfo[j - 1].Exc & 1);
					checkBox3.Checked = Convert.ToBoolean(selected_iInfo[j - 1].Exc >> 1 & 1);
					checkBox4.Checked = Convert.ToBoolean(selected_iInfo[j - 1].Exc >> 2 & 1);
					checkBox5.Checked = Convert.ToBoolean(selected_iInfo[j - 1].Exc >> 3 & 1);
					checkBox6.Checked = Convert.ToBoolean(selected_iInfo[j - 1].Exc >> 4 & 1);
					checkBox7.Checked = Convert.ToBoolean(selected_iInfo[j - 1].Exc >> 5 & 1);
					numericUpDown3.Value = selected_iInfo[j - 1].Socket;
					numericUpDown4.Value = selected_iInfo[j - 1].Dur;
					checkBox8.Checked = Convert.ToBoolean(selected_iInfo[j - 1].Luck);
					checkBox9.Checked = Convert.ToBoolean(selected_iInfo[j - 1].Skill);
				}
			}
			else
			{
				this.checkBox_MultiItem.Checked = false;
				this.buttonClearAll_Multi.PerformClick();
			}
			int num = selected_iPackage.ItemID / 512;
			int num2 = selected_iPackage.ItemID - num * 512;
			this.listBox_NewItem_ItemGroup.SelectedValue = num;
			this.listBox_NewItem_ItemIndex.SelectedValue = num2;
			this.isItemSelected = true;
		}

		// Token: 0x04000423 RID: 1059
		private List<Structures.c_AncientData> c_AncientDatas = new List<Structures.c_AncientData>();

		// Token: 0x04000424 RID: 1060
		private List<Structures.c_AncientData> c_AncientDatas_M1 = new List<Structures.c_AncientData>();

		// Token: 0x04000425 RID: 1061
		private List<Structures.c_AncientData> c_AncientDatas_M2 = new List<Structures.c_AncientData>();

		// Token: 0x04000426 RID: 1062
		private List<Structures.c_AncientData> c_AncientDatas_M3 = new List<Structures.c_AncientData>();

		// Token: 0x04000427 RID: 1063
		private List<Structures.c_AncientData> c_AncientDatas_M4 = new List<Structures.c_AncientData>();

		// Token: 0x04000428 RID: 1064
		private List<Structures.c_AncientData> c_AncientDatas_M5 = new List<Structures.c_AncientData>();

		// Token: 0x04000429 RID: 1065
		private List<Structures.c_AncientData> c_AncientDatas_M6 = new List<Structures.c_AncientData>();

		// Token: 0x0400042A RID: 1066
		private List<Structures.c_LevelData> c_LevelDatas = new List<Structures.c_LevelData>();

		// Token: 0x0400042B RID: 1067
		private List<Structures.c_LevelData> c_LevelDatas_M1 = new List<Structures.c_LevelData>();

		// Token: 0x0400042C RID: 1068
		private List<Structures.c_LevelData> c_LevelDatas_M2 = new List<Structures.c_LevelData>();

		// Token: 0x0400042D RID: 1069
		private List<Structures.c_LevelData> c_LevelDatas_M3 = new List<Structures.c_LevelData>();

		// Token: 0x0400042E RID: 1070
		private List<Structures.c_LevelData> c_LevelDatas_M4 = new List<Structures.c_LevelData>();

		// Token: 0x0400042F RID: 1071
		private List<Structures.c_LevelData> c_LevelDatas_M5 = new List<Structures.c_LevelData>();

		// Token: 0x04000430 RID: 1072
		private List<Structures.c_LevelData> c_LevelDatas_M6 = new List<Structures.c_LevelData>();

		// Token: 0x04000431 RID: 1073
		private List<Structures.c_OptionData> c_OptionDatas = new List<Structures.c_OptionData>();

		// Token: 0x04000432 RID: 1074
		private List<Structures.c_OptionData> c_OptionDatas_M1 = new List<Structures.c_OptionData>();

		// Token: 0x04000433 RID: 1075
		private List<Structures.c_OptionData> c_OptionDatas_M2 = new List<Structures.c_OptionData>();

		// Token: 0x04000434 RID: 1076
		private List<Structures.c_OptionData> c_OptionDatas_M3 = new List<Structures.c_OptionData>();

		// Token: 0x04000435 RID: 1077
		private List<Structures.c_OptionData> c_OptionDatas_M4 = new List<Structures.c_OptionData>();

		// Token: 0x04000436 RID: 1078
		private List<Structures.c_OptionData> c_OptionDatas_M5 = new List<Structures.c_OptionData>();

		// Token: 0x04000437 RID: 1079
		private List<Structures.c_OptionData> c_OptionDatas_M6 = new List<Structures.c_OptionData>();

		// Token: 0x04000484 RID: 1156
		private bool DontWork;

		// Token: 0x04000485 RID: 1157
		private bool FirstRun = true;

		// Token: 0x04000486 RID: 1158
		private CashShopEditor frm_Parent;

		// Token: 0x04000495 RID: 1173
		private int isEx700ItemList = 1;

		// Token: 0x04000496 RID: 1174
		private bool isItemSelected;

		// Token: 0x04000497 RID: 1175
		private List<Structures.UniItem> L_Armors = new List<Structures.UniItem>();

		// Token: 0x04000498 RID: 1176
		private List<Structures.UniItem> L_Axes = new List<Structures.UniItem>();

		// Token: 0x04000499 RID: 1177
		private List<Structures.UniItem> L_Boots = new List<Structures.UniItem>();

		// Token: 0x0400049A RID: 1178
		private List<Structures.UniItem> L_BowsCrossBows = new List<Structures.UniItem>();

		// Token: 0x0400049B RID: 1179
		private List<Structures.UniItem> L_Gloves = new List<Structures.UniItem>();

		// Token: 0x0400049C RID: 1180
		private List<Structures.c_Groups> L_Groups = new List<Structures.c_Groups>();

		// Token: 0x0400049D RID: 1181
		private List<Structures.UniItem> L_Helms = new List<Structures.UniItem>();

		// Token: 0x0400049E RID: 1182
		private List<Structures.UniItem> L_MacesScepters = new List<Structures.UniItem>();

		// Token: 0x0400049F RID: 1183
		private List<Structures.UniItem> L_Others1 = new List<Structures.UniItem>();

		// Token: 0x040004A0 RID: 1184
		private List<Structures.UniItem> L_Others2 = new List<Structures.UniItem>();

		// Token: 0x040004A1 RID: 1185
		private List<Structures.UniItem> L_Pants = new List<Structures.UniItem>();

		// Token: 0x040004A2 RID: 1186
		private List<Structures.UniItem> L_Scrolls = new List<Structures.UniItem>();

		// Token: 0x040004A3 RID: 1187
		private List<Structures.UniItem> L_Shields = new List<Structures.UniItem>();

		// Token: 0x040004A4 RID: 1188
		private List<Structures.UniItem> L_Spears = new List<Structures.UniItem>();

		// Token: 0x040004A5 RID: 1189
		private List<Structures.UniItem> L_Staffs = new List<Structures.UniItem>();

		// Token: 0x040004A6 RID: 1190
		private List<Structures.UniItem> L_Swords = new List<Structures.UniItem>();

		// Token: 0x040004A7 RID: 1191
		private List<Structures.UniItem> L_WingsSkillsSeedsOthers = new List<Structures.UniItem>();

		// Token: 0x0400050E RID: 1294
		private BindingList<Structures.IGCCashItemInfo> PackageItems = new BindingList<Structures.IGCCashItemInfo>();
	}
}
