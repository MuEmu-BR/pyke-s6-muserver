using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MU_ToolKit.Properties;

namespace MU_ToolKit
{
	// Token: 0x02000022 RID: 34
	public partial class ShopEditor : Form
	{
		// Token: 0x06000470 RID: 1136 RVA: 0x0001AC08 File Offset: 0x00018E08
		public ShopEditor()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000471 RID: 1137 RVA: 0x0001AD58 File Offset: 0x00018F58
		private bool AddItemPicture(string toolTip, ref string uniqName, ref Structures.ShopItem sI)
		{
			Structures.UniItem uniItem = (Structures.UniItem)this.listBox_Index.SelectedItem;
			int num = 0;
			int num2 = 0;
			if (!this.GetFirstFreeBox(uniItem.X, uniItem.Y, ref num, ref num2))
			{
				return false;
			}
			Structures.CustomPictureBox customPictureBox = new Structures.CustomPictureBox();
			new Structures.CustomToolTip
			{
				sizeX = 350,
				sizeY = 210
			}.SetToolTip(customPictureBox, toolTip);
			customPictureBox.Size = new Size(uniItem.X * 27, uniItem.Y * 27);
			PictureBox pictureBox = (PictureBox)this.pictureBox_ShopPreview.Controls[string.Concat(new object[]
			{
				"pictureBox_",
				num2,
				"x",
				num
			})];
			customPictureBox.Location = new Point(pictureBox.Location.X, pictureBox.Location.Y);
			customPictureBox.BackColor = Color.Transparent;
			customPictureBox.Parent = this.pictureBox_ShopPreview;
			customPictureBox.Name = string.Concat(new object[]
			{
				"pictureBox_Item_",
				num2,
				"x",
				num,
				"_",
				uniItem.Y,
				"x",
				uniItem.X
			});
			uniqName = string.Concat(new object[]
			{
				"Item_",
				num2,
				"x",
				num,
				"_",
				uniItem.Y,
				"x",
				uniItem.X
			});
			sI.ShopLocX = num;
			sI.ShopLocY = num2;
			try
			{
				customPictureBox.BackgroundImage = (Bitmap)Resources.ResourceManager.GetObject("_" + uniItem.Group + uniItem.Index);
				if (customPictureBox.BackgroundImage.Size.Width > customPictureBox.Size.Width || customPictureBox.BackgroundImage.Size.Height > customPictureBox.Size.Height)
				{
					customPictureBox.BackgroundImageLayout = ImageLayout.Zoom;
				}
				else
				{
					customPictureBox.BackgroundImageLayout = ImageLayout.Center;
				}
			}
			catch
			{
				customPictureBox.BackgroundImage = (Bitmap)Resources.ResourceManager.GetObject("no_img");
			}
			customPictureBox.MouseClick += this.pb_MouseClick;
			customPictureBox.BorderColor = Color.Gold;
			this.LastSelectetItem.BorderColor = Color.Transparent;
			this.LastSelectetItem = customPictureBox;
			this.pictureBox_ShopPreview.Controls.Add(customPictureBox);
			customPictureBox.BringToFront();
			this.pictureBox_ShopPreview.Invalidate();
			this.ChangeOccupid(num, num2, uniItem.X, uniItem.Y, true);
			this.button_Update.Enabled = true;
			return true;
		}

		// Token: 0x06000472 RID: 1138 RVA: 0x0001B090 File Offset: 0x00019290
		private bool AddItemPicture(string toolTip, ref string uniqName, Structures.UniItem uniqItm, ref Structures.ShopItem sI)
		{
			Structures.UniItem uniItem = uniqItm;
			int num = 0;
			int num2 = 0;
			if (!this.GetFirstFreeBox(uniItem.X, uniItem.Y, ref num, ref num2))
			{
				return false;
			}
			Structures.CustomPictureBox customPictureBox = new Structures.CustomPictureBox();
			new Structures.CustomToolTip
			{
				sizeX = 350,
				sizeY = 210
			}.SetToolTip(customPictureBox, toolTip);
			customPictureBox.Size = new Size(uniItem.X * 27, uniItem.Y * 27);
			PictureBox pictureBox = (PictureBox)this.pictureBox_ShopPreview.Controls[string.Concat(new object[]
			{
				"pictureBox_",
				num2,
				"x",
				num
			})];
			customPictureBox.Location = new Point(pictureBox.Location.X, pictureBox.Location.Y);
			customPictureBox.BackColor = Color.Transparent;
			customPictureBox.Parent = this.pictureBox_ShopPreview;
			customPictureBox.Name = string.Concat(new object[]
			{
				"pictureBox_Item_",
				num2,
				"x",
				num,
				"_",
				uniItem.Y,
				"x",
				uniItem.X
			});
			uniqName = string.Concat(new object[]
			{
				"Item_",
				num2,
				"x",
				num,
				"_",
				uniItem.Y,
				"x",
				uniItem.X
			});
			sI.ShopLocX = num;
			sI.ShopLocY = num2;
			try
			{
				customPictureBox.BackgroundImage = (Bitmap)Resources.ResourceManager.GetObject("_" + uniItem.Group + uniItem.Index);
				if (customPictureBox.BackgroundImage.Size.Width > customPictureBox.Size.Width || customPictureBox.BackgroundImage.Size.Height > customPictureBox.Size.Height)
				{
					customPictureBox.BackgroundImageLayout = ImageLayout.Zoom;
				}
				else
				{
					customPictureBox.BackgroundImageLayout = ImageLayout.Center;
				}
			}
			catch
			{
				customPictureBox.BackgroundImage = (Bitmap)Resources.ResourceManager.GetObject("no_img");
			}
			customPictureBox.MouseClick += this.pb_MouseClick;
			customPictureBox.BorderColor = Color.Gold;
			this.LastSelectetItem.BorderColor = Color.Transparent;
			this.LastSelectetItem = customPictureBox;
			this.pictureBox_ShopPreview.Controls.Add(customPictureBox);
			customPictureBox.BringToFront();
			this.pictureBox_ShopPreview.Invalidate();
			this.ChangeOccupid(num, num2, uniItem.X, uniItem.Y, true);
			this.button_Update.Enabled = true;
			return true;
		}

		// Token: 0x06000473 RID: 1139 RVA: 0x0001B3BC File Offset: 0x000195BC
		private void AddPreviewBoxes(int x, int y)
		{
			int num = 19;
			for (int i = 1; i <= y; i++)
			{
				int num2 = 17;
				for (int j = 1; j <= x; j++)
				{
					PictureBox pictureBox = new PictureBox
					{
						Name = string.Concat(new object[]
						{
							"pictureBox_",
							i,
							"x",
							j
						}),
						Location = new Point(num2, num),
						Size = new Size(27, 27),
						BackgroundImage = Resources.Untitled_3
					};
					this.pictureBox_ShopPreview.Controls.Add(pictureBox);
					pictureBox.Invalidate();
					num2 += 26;
				}
				num += 26;
			}
			this.pictureBox_ShopPreview.Visible = true;
			this.pictureBox_ShopPreview.Invalidate();
		}

		// Token: 0x06000474 RID: 1140 RVA: 0x0001B4A0 File Offset: 0x000196A0
		private void button_Add_Click(object sender, EventArgs e)
		{
			string empty = string.Empty;
			Structures.ShopItem shopItem = new Structures.ShopItem
			{
				Group = Convert.ToInt32(this.listBox_Group.SelectedValue),
				Index = Convert.ToInt32(this.listBox_Index.SelectedValue),
				Level = Convert.ToByte(this.listBox_Level.SelectedValue),
				Option = Convert.ToByte(this.listBox_Option.SelectedValue),
				Skill = this.checkBox_Skill.Checked,
				Luck = this.checkBox_Luck.Checked,
				Durablity = Convert.ToByte(this.numericUpDown_Durability.Value),
				Ancient = (this.radioButton_Ancient_Level1.Checked ? Convert.ToByte(5) : (this.radioButton_Ancient_Level2.Checked ? Convert.ToByte(10) : Convert.ToByte(0))),
				Excellent = this.GetExcVal()
			};
			string str = string.Empty + ((shopItem.Excellent > 0) ? "Excellent " : "");
			object obj = str + ((shopItem.Ancient > 0) ? "Ancient " : "") + this.listBox_Index.Text;
			string str2 = string.Concat(new object[]
			{
				obj,
				"+",
				shopItem.Level,
				this.listBox_Option.Text
			});
			string text = str2 + (shopItem.Skill ? "+Skill" : "");
			string str3 = string.Concat(new object[]
			{
				text,
				shopItem.Luck ? "+Luck" : "",
				"\n\nDurability: ",
				shopItem.Durablity
			});
			string text2 = str3 + ((shopItem.Ancient > 0) ? ((shopItem.Ancient == 5) ? "\n\nAncinet: Level 1" : ((shopItem.Ancient == 10) ? "\n\nAncinet: Level 2" : "")) : "");
			if (shopItem.Excellent > 0)
			{
				text2 = string.Concat(new string[]
				{
					text2,
					"\n\nExcellent Options:\n",
					this.checkBox_ExcOpt1.Checked ? (this.checkBox_ExcOpt1.Text + "\n") : "",
					this.checkBox_ExcOpt2.Checked ? (this.checkBox_ExcOpt2.Text + "\n") : "",
					this.checkBox_ExcOpt3.Checked ? (this.checkBox_ExcOpt3.Text + "\n") : "",
					this.checkBox_ExcOpt4.Checked ? (this.checkBox_ExcOpt4.Text + "\n") : "",
					this.checkBox_ExcOpt5.Checked ? (this.checkBox_ExcOpt5.Text + "\n") : "",
					this.checkBox_ExcOpt6.Checked ? this.checkBox_ExcOpt6.Text : ""
				});
			}
			if (this.AddItemPicture(text2, ref empty, ref shopItem))
			{
				shopItem.UniqName = empty;
				this.SelectedSI = shopItem;
				this.ShopItems[shopItem.ShopLocY, shopItem.ShopLocX] = shopItem;
			}
		}

		// Token: 0x06000475 RID: 1141 RVA: 0x0001B838 File Offset: 0x00019A38
		private void button_Update_Click(object sender, EventArgs e)
		{
			Structures.ShopItem shopItem = default(Structures.ShopItem);
			shopItem = this.SelectedSI;
			shopItem.Level = Convert.ToByte(this.listBox_Level.SelectedValue);
			shopItem.Option = Convert.ToByte(this.listBox_Option.SelectedValue);
			shopItem.Skill = this.checkBox_Skill.Checked;
			shopItem.Luck = this.checkBox_Luck.Checked;
			shopItem.Durablity = Convert.ToByte(this.numericUpDown_Durability.Value);
			shopItem.Ancient = (this.radioButton_Ancient_Level1.Checked ? Convert.ToByte(5) : (this.radioButton_Ancient_Level2.Checked ? Convert.ToByte(10) : Convert.ToByte(0)));
			shopItem.Excellent = this.GetExcVal();
			string str = string.Empty + ((shopItem.Excellent > 0) ? "Excellent " : "");
			object obj = str + ((shopItem.Ancient > 0) ? "Ancient " : "") + this.listBox_Index.Text;
			string str2 = string.Concat(new object[]
			{
				obj,
				"+",
				shopItem.Level,
				this.listBox_Option.Text
			});
			string text = str2 + (shopItem.Skill ? "+Skill" : "");
			string str3 = string.Concat(new object[]
			{
				text,
				shopItem.Luck ? "+Luck" : "",
				"\n\nDurability: ",
				shopItem.Durablity
			});
			string text2 = str3 + ((shopItem.Ancient > 0) ? ((shopItem.Ancient == 5) ? "\n\nAncinet: Level 1" : ((shopItem.Ancient == 10) ? "\n\nAncinet: Level 2" : "")) : "");
			if (shopItem.Excellent > 0)
			{
				text2 = string.Concat(new string[]
				{
					text2,
					"\n\nExcellent Options:\n",
					this.checkBox_ExcOpt1.Checked ? (this.checkBox_ExcOpt1.Text + "\n") : "",
					this.checkBox_ExcOpt2.Checked ? (this.checkBox_ExcOpt2.Text + "\n") : "",
					this.checkBox_ExcOpt3.Checked ? (this.checkBox_ExcOpt3.Text + "\n") : "",
					this.checkBox_ExcOpt4.Checked ? (this.checkBox_ExcOpt4.Text + "\n") : "",
					this.checkBox_ExcOpt5.Checked ? (this.checkBox_ExcOpt5.Text + "\n") : "",
					this.checkBox_ExcOpt6.Checked ? this.checkBox_ExcOpt6.Text : ""
				});
			}
			this.LastSelectetItem.Controls.Clear();
			new Structures.CustomToolTip
			{
				sizeX = 350,
				sizeY = 210
			}.SetToolTip(this.LastSelectetItem, text2);
			this.ShopItems[this.SelectedSI.ShopLocY, this.SelectedSI.ShopLocX] = shopItem;
		}

		// Token: 0x06000476 RID: 1142 RVA: 0x0001BBC8 File Offset: 0x00019DC8
		private void ChangeOccupid(int startX, int startY, int LengthX, int LengthY, bool state)
		{
			for (int i = 0; i < LengthY; i++)
			{
				for (int j = 0; j < LengthX; j++)
				{
					this.OccupiedBoxes[i + startY, j + startX] = state;
				}
			}
		}

		// Token: 0x06000477 RID: 1143 RVA: 0x0001BC04 File Offset: 0x00019E04
		private void checkBox_FO_CheckedChanged(object sender, EventArgs e)
		{
			if (this.checkBox_FO.Checked)
			{
				this.checkBox_ExcOpt1.Checked = true;
				this.checkBox_ExcOpt2.Checked = true;
				this.checkBox_ExcOpt3.Checked = true;
				this.checkBox_ExcOpt4.Checked = true;
				this.checkBox_ExcOpt5.Checked = true;
				this.checkBox_ExcOpt6.Checked = true;
				this.listBox_Level.SelectedIndex = 15;
				this.listBox_Option.SelectedValue = 7;
				this.checkBox_Luck.Checked = true;
				this.checkBox_FO.Checked = false;
			}
		}

		// Token: 0x06000478 RID: 1144 RVA: 0x0001BC9C File Offset: 0x00019E9C
		private void ClearShopItemsPreview()
		{
			List<string> list = new List<string>();
			foreach (object obj in this.pictureBox_ShopPreview.Controls)
			{
				Control control = (Control)obj;
				if (control.Name.StartsWith("pictureBox_Item_"))
				{
					list.Add(control.Name);
				}
			}
			foreach (string key in list)
			{
				this.pictureBox_ShopPreview.Controls.RemoveByKey(key);
			}
		}

		// Token: 0x0600047A RID: 1146 RVA: 0x0001BD84 File Offset: 0x00019F84
		private byte GetExcVal()
		{
			int num = 0;
			num = (this.checkBox_ExcOpt1.Checked ? (num + 1) : num);
			num = (this.checkBox_ExcOpt2.Checked ? (num + 2) : num);
			num = (this.checkBox_ExcOpt3.Checked ? (num + 4) : num);
			num = (this.checkBox_ExcOpt4.Checked ? (num + 8) : num);
			num = (this.checkBox_ExcOpt5.Checked ? (num + 16) : num);
			num = (this.checkBox_ExcOpt6.Checked ? (num + 32) : num);
			return Convert.ToByte(num);
		}

		// Token: 0x0600047B RID: 1147 RVA: 0x0001BE14 File Offset: 0x0001A014
		private bool GetFirstFreeBox(int neededX, int neededY, ref int acceptedX, ref int acceptedY)
		{
			for (int i = 1; i <= 15; i++)
			{
				for (int j = 1; j <= 8; j++)
				{
					if (!this.OccupiedBoxes[i, j])
					{
						bool flag = false;
						for (int k = 0; k < neededY; k++)
						{
							for (int l = 0; l < neededX; l++)
							{
								if (!flag)
								{
									if (i + k <= 15 & j + l <= 8)
									{
										if (this.OccupiedBoxes[i + k, j + l])
										{
											flag = true;
										}
									}
									else
									{
										flag = true;
									}
								}
							}
						}
						if (!flag)
						{
							acceptedX = j;
							acceptedY = i;
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x0600047D RID: 1149 RVA: 0x0001D730 File Offset: 0x0001B930
		private void listBox_Group_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.listBox_Group.SelectedIndex != -1)
			{
				this.DontWork = true;
				switch ((int)this.listBox_Group.SelectedValue)
				{
				case 0:
					this.listBox_Index.DisplayMember = "Name";
					this.listBox_Index.ValueMember = "Index";
					this.listBox_Index.DataSource = this.L_Swords;
					break;
				case 1:
					this.listBox_Index.DisplayMember = "Name";
					this.listBox_Index.ValueMember = "Index";
					this.listBox_Index.DataSource = this.L_Axes;
					break;
				case 2:
					this.listBox_Index.DisplayMember = "Name";
					this.listBox_Index.ValueMember = "Index";
					this.listBox_Index.DataSource = this.L_MacesScepters;
					break;
				case 3:
					this.listBox_Index.DisplayMember = "Name";
					this.listBox_Index.ValueMember = "Index";
					this.listBox_Index.DataSource = this.L_Spears;
					break;
				case 4:
					this.listBox_Index.DisplayMember = "Name";
					this.listBox_Index.ValueMember = "Index";
					this.listBox_Index.DataSource = this.L_BowsCrossBows;
					break;
				case 5:
					this.listBox_Index.DisplayMember = "Name";
					this.listBox_Index.ValueMember = "Index";
					this.listBox_Index.DataSource = this.L_Staffs;
					break;
				case 6:
					this.listBox_Index.DisplayMember = "Name";
					this.listBox_Index.ValueMember = "Index";
					this.listBox_Index.DataSource = this.L_Shields;
					break;
				case 7:
					this.listBox_Index.DisplayMember = "Name";
					this.listBox_Index.ValueMember = "Index";
					this.listBox_Index.DataSource = this.L_Helms;
					break;
				case 8:
					this.listBox_Index.DisplayMember = "Name";
					this.listBox_Index.ValueMember = "Index";
					this.listBox_Index.DataSource = this.L_Armors;
					break;
				case 9:
					this.listBox_Index.DisplayMember = "Name";
					this.listBox_Index.ValueMember = "Index";
					this.listBox_Index.DataSource = this.L_Pants;
					break;
				case 10:
					this.listBox_Index.DisplayMember = "Name";
					this.listBox_Index.ValueMember = "Index";
					this.listBox_Index.DataSource = this.L_Gloves;
					break;
				case 11:
					this.listBox_Index.DisplayMember = "Name";
					this.listBox_Index.ValueMember = "Index";
					this.listBox_Index.DataSource = this.L_Boots;
					break;
				case 12:
					this.listBox_Index.DisplayMember = "Name";
					this.listBox_Index.ValueMember = "Index";
					this.listBox_Index.DataSource = this.L_WingsSkillsSeedsOthers;
					break;
				case 13:
					this.listBox_Index.DisplayMember = "Name";
					this.listBox_Index.ValueMember = "Index";
					this.listBox_Index.DataSource = this.L_Others1;
					break;
				case 14:
					this.listBox_Index.DisplayMember = "Name";
					this.listBox_Index.ValueMember = "Index";
					this.listBox_Index.DataSource = this.L_Others2;
					break;
				case 15:
					this.listBox_Index.DisplayMember = "Name";
					this.listBox_Index.ValueMember = "Index";
					this.listBox_Index.DataSource = this.L_Scrolls;
					break;
				}
				this.listBox_Index.SelectedIndex = -1;
				this.DontWork = false;
				if (this.LastSelectedItemIndex <= this.listBox_Index.Items.Count - 1)
				{
					this.listBox_Index.SelectedIndex = this.LastSelectedItemIndex;
				}
			}
		}

		// Token: 0x0600047E RID: 1150 RVA: 0x0001DB44 File Offset: 0x0001BD44
		private void listBox_Index_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.listBox_Index.SelectedIndex != -1 & !this.DontWork)
			{
				this.LastSelectedItemIndex = this.listBox_Index.SelectedIndex;
				try
				{
					this.pictureBox_ItemPreview.BackgroundImage = (Bitmap)Resources.ResourceManager.GetObject("_" + this.listBox_Group.SelectedValue + this.listBox_Index.SelectedValue);
					if (this.pictureBox_ItemPreview.BackgroundImage.Size.Width > this.pictureBox_ItemPreview.Size.Width || this.pictureBox_ItemPreview.BackgroundImage.Size.Height > this.pictureBox_ItemPreview.Size.Height)
					{
						this.pictureBox_ItemPreview.BackgroundImageLayout = ImageLayout.Zoom;
					}
					else
					{
						this.pictureBox_ItemPreview.BackgroundImageLayout = ImageLayout.Center;
					}
				}
				catch
				{
					this.pictureBox_ItemPreview.BackgroundImage = (Bitmap)Resources.ResourceManager.GetObject("no_img");
				}
				Structures.UniItem uniItem = (Structures.UniItem)this.listBox_Index.SelectedItem;
				this.label_Size.Text = uniItem.X + "x" + uniItem.Y;
				this.checkBox_Skill.Checked = (uniItem.Skill != 0 && this.checkBox_Skill.Checked);
				this.listBox_Option.SelectedIndex = ((uniItem.Option == 0) ? 0 : this.listBox_Option.SelectedIndex);
				this.radioButton_Ancient_None.Checked = (uniItem.Ancient == 0 || this.radioButton_Ancient_None.Checked);
				this.numericUpDown_Durability.Value = ((uniItem.Durability == 0) ? 0m : this.numericUpDown_Durability.Value);
				int slot = uniItem.Slot;
				switch (slot)
				{
				case -1:
				case 8:
					break;
				case 0:
				case 9:
					this.radioButton_ExcWeapon.Checked = true;
					return;
				case 1:
				case 2:
				case 3:
				case 4:
				case 5:
				case 6:
				case 10:
					if (uniItem.Group > 5)
					{
						this.radioButton_ExcArmor.Checked = true;
						return;
					}
					this.radioButton_ExcWeapon.Checked = true;
					return;
				case 7:
					this.radioButton_ExcWings.Checked = true;
					return;
				default:
					if (slot != 236)
					{
						return;
					}
					break;
				}
				this.checkBox_ExcOpt1.Checked = false;
				this.checkBox_ExcOpt2.Checked = false;
				this.checkBox_ExcOpt3.Checked = false;
				this.checkBox_ExcOpt4.Checked = false;
				this.checkBox_ExcOpt5.Checked = false;
				this.checkBox_ExcOpt6.Checked = false;
				return;
			}
		}

		// Token: 0x0600047F RID: 1151 RVA: 0x0001DE04 File Offset: 0x0001C004
		private void newToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.ShopItems = new Structures.ShopItem[16, 9];
			this.SelectedSI = default(Structures.ShopItem);
			this.LastSelectetItem = new Structures.CustomPictureBox();
			this.ChangeOccupid(1, 1, 8, 15, false);
			this.ClearShopItemsPreview();
			this.button_Update.Enabled = false;
		}

		// Token: 0x06000480 RID: 1152 RVA: 0x0001DE58 File Offset: 0x0001C058
		private void numericUpDown_Durability_ValueChanged(object sender, EventArgs e)
		{
			if (this.numericUpDown_Durability.Focused)
			{
				this.OldDurValue = (int)this.numericUpDown_Durability.Value;
				return;
			}
			if (this.checkBox_DurLock.Checked)
			{
				this.numericUpDown_Durability.Value = this.OldDurValue;
				return;
			}
			this.OldDurValue = (int)this.numericUpDown_Durability.Value;
		}

		// Token: 0x06000481 RID: 1153 RVA: 0x0001DEC4 File Offset: 0x0001C0C4
		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Filter = "Text files (*.txt)|*.txt",
				Title = "Select a Text Shop file to Load"
			};
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				string[] array = openFileDialog.FileName.Split(new char[]
				{
					'.'
				});
				if (array[array.Length - 1] == "txt")
				{
					array = openFileDialog.FileName.Split(new char[]
					{
						'\\'
					});
					this.label_FileName.Text = array[array.Length - 1];
					this.ShopItems = new Structures.ShopItem[16, 9];
					this.SelectedSI = default(Structures.ShopItem);
					this.LastSelectetItem = new Structures.CustomPictureBox();
					this.ChangeOccupid(1, 1, 8, 15, false);
					this.ClearShopItemsPreview();
					this.ReadShopFile(openFileDialog.FileName);
					return;
				}
				MessageBox.Show("Invalid file selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000482 RID: 1154 RVA: 0x0001DFB0 File Offset: 0x0001C1B0
		private void pb_MouseClick(object sender, MouseEventArgs e)
		{
			Structures.CustomPictureBox customPictureBox = (Structures.CustomPictureBox)sender;
			string[] array = customPictureBox.Name.Split(new char[]
			{
				'_'
			});
			string[] array2 = array[array.Length - 2].Split(new char[]
			{
				'x'
			});
			string[] array3 = array[array.Length - 1].Split(new char[]
			{
				'x'
			});
			int num = (int)Convert.ToInt16(array2[1]);
			int num2 = (int)Convert.ToInt16(array2[0]);
			int num3 = (int)Convert.ToInt16(array3[1]);
			int num4 = (int)Convert.ToInt16(array3[0]);
			string a = string.Concat(new object[]
			{
				"Item_",
				num2,
				"x",
				num,
				"_",
				num4,
				"x",
				num3
			});
			if (e.Button == MouseButtons.Right)
			{
				if (MessageBox.Show("    Are you sure you want to delete this item?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
				{
					Structures.ShopItem[,] shopItems = this.ShopItems;
					int upperBound = shopItems.GetUpperBound(0);
					int upperBound2 = shopItems.GetUpperBound(1);
					for (int i = shopItems.GetLowerBound(0); i <= upperBound; i++)
					{
						for (int j = shopItems.GetLowerBound(1); j <= upperBound2; j++)
						{
							Structures.ShopItem shopItem = shopItems[i, j];
							if (a == shopItem.UniqName)
							{
								this.ShopItems[shopItem.ShopLocY, shopItem.ShopLocX] = default(Structures.ShopItem);
								break;
							}
						}
					}
					this.pictureBox_ShopPreview.Controls.RemoveByKey(string.Concat(new object[]
					{
						"pictureBox_Item_",
						num2,
						"x",
						num,
						"_",
						num4,
						"x",
						num3
					}));
					this.ChangeOccupid(num, num2, num3, num4, false);
					this.button_Update.Enabled = false;
				}
				return;
			}
			if (e.Button != MouseButtons.Left || this.LastSelectetItem == customPictureBox)
			{
				return;
			}
			customPictureBox.BorderColor = Color.Gold;
			this.LastSelectetItem.BorderColor = Color.Transparent;
			this.LastSelectetItem = customPictureBox;
			this.pictureBox_ShopPreview.Invalidate();
			Structures.ShopItem[,] shopItems2 = this.ShopItems;
			int upperBound3 = shopItems2.GetUpperBound(0);
			int upperBound4 = shopItems2.GetUpperBound(1);
			for (int k = shopItems2.GetLowerBound(0); k <= upperBound3; k++)
			{
				for (int l = shopItems2.GetLowerBound(1); l <= upperBound4; l++)
				{
					Structures.ShopItem selectedSI = shopItems2[k, l];
					if (a == selectedSI.UniqName)
					{
						this.SelectedSI = selectedSI;
						break;
					}
				}
			}
			this.listBox_Group.SelectedValue = this.SelectedSI.Group;
			this.listBox_Index.SelectedValue = this.SelectedSI.Index;
			this.listBox_Level.SelectedIndex = (int)this.SelectedSI.Level;
			this.listBox_Option.SelectedIndex = (int)this.SelectedSI.Option;
			this.checkBox_Luck.Checked = this.SelectedSI.Luck;
			this.checkBox_Skill.Checked = this.SelectedSI.Skill;
			this.numericUpDown_Durability.Value = this.SelectedSI.Durablity;
			if (this.SelectedSI.Ancient == 5)
			{
				this.radioButton_Ancient_Level1.Checked = true;
			}
			else if (this.SelectedSI.Ancient == 10)
			{
				this.radioButton_Ancient_Level2.Checked = true;
			}
			else
			{
				this.radioButton_Ancient_None.Checked = true;
			}
			this.checkBox_ExcOpt1.Checked = ((this.SelectedSI.Excellent & 1) == 1);
			this.checkBox_ExcOpt2.Checked = ((this.SelectedSI.Excellent >> 1 & 1) == 1);
			this.checkBox_ExcOpt3.Checked = ((this.SelectedSI.Excellent >> 2 & 1) == 1);
			this.checkBox_ExcOpt4.Checked = ((this.SelectedSI.Excellent >> 3 & 1) == 1);
			this.checkBox_ExcOpt5.Checked = ((this.SelectedSI.Excellent >> 4 & 1) == 1);
			this.checkBox_ExcOpt6.Checked = ((this.SelectedSI.Excellent >> 5 & 1) == 1);
			this.button_Update.Enabled = true;
		}

		// Token: 0x06000483 RID: 1155 RVA: 0x0001E44C File Offset: 0x0001C64C
		private void radioButton_Exc_CheckedChanged(object sender, EventArgs e)
		{
			if (this.radioButton_ExcArmor.Checked)
			{
				this.checkBox_ExcOpt1.Text = "Zen Drop +30%";
				this.checkBox_ExcOpt2.Text = "Def Success Rate +10%";
				this.checkBox_ExcOpt3.Text = "Reflect +5%";
				this.checkBox_ExcOpt4.Text = "Damage Decrease +4%";
				this.checkBox_ExcOpt5.Text = "Mana +4%";
				this.checkBox_ExcOpt6.Text = "HP +4%";
				return;
			}
			if (this.radioButton_ExcWeapon.Checked)
			{
				this.checkBox_ExcOpt1.Text = "Mob Kill +mana/8";
				this.checkBox_ExcOpt2.Text = "Mob Kill +life/8";
				this.checkBox_ExcOpt3.Text = "Attack(Wizardy) Speed +7";
				this.checkBox_ExcOpt4.Text = "Damage +2%";
				this.checkBox_ExcOpt5.Text = "Damage +level/20";
				this.checkBox_ExcOpt6.Text = "Exc Damage Rate +10%";
				return;
			}
			if (this.radioButton_ExcWings.Checked)
			{
				this.checkBox_ExcOpt1.Text = "Ignor Def +5% / HP +125";
				this.checkBox_ExcOpt2.Text = "Return Attack +5% / Mana +125";
				this.checkBox_ExcOpt3.Text = "Life Recovery +5% /Ignor Def +3%";
				this.checkBox_ExcOpt4.Text = "Mana Recovery +5% / AG +50";
				this.checkBox_ExcOpt5.Text = "--- / Attack(Wiz) Speed+5";
				this.checkBox_ExcOpt6.Text = "---";
			}
		}

		// Token: 0x06000484 RID: 1156 RVA: 0x0001E5A4 File Offset: 0x0001C7A4
		private void ReadShopFile(string fName)
		{
			foreach (string text in File.ReadAllLines(fName))
			{
				if (!text.ToLower().Replace("\t", "").Trim().StartsWith("end") & !text.ToUpper().Replace("\t", "").Trim().StartsWith("/") & text.ToUpper().Replace("\t", "").Trim().Length > 0)
				{
					string[] array2 = text.Replace(" ", "\t").Split(new char[]
					{
						'\t'
					});
					List<string> list = new List<string>();
					for (int j = 0; j < array2.Length; j++)
					{
						if (array2[j].Trim().Length != 0)
						{
							list.Add(array2[j]);
						}
					}
					array2 = list.ToArray();
					if (array2.Length < 9)
					{
						MessageBox.Show("\tInvalid line", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						return;
					}
					try
					{
						Structures.ShopItem shopItem = new Structures.ShopItem
						{
							Group = Convert.ToInt32(array2[0]),
							Index = Convert.ToInt32(array2[1]),
							Level = Convert.ToByte(array2[2]),
							Durablity = Convert.ToByte(array2[3]),
							Skill = Convert.ToBoolean(Convert.ToByte(array2[4])),
							Luck = Convert.ToBoolean(Convert.ToByte(array2[5])),
							Option = Convert.ToByte(array2[6]),
							Excellent = Convert.ToByte(array2[7]),
							Ancient = Convert.ToByte(array2[8])
						};
						string empty = string.Empty;
						string str = string.Empty + ((shopItem.Excellent > 0) ? "Excellent " : "");
						object obj = str + ((shopItem.Ancient > 0) ? "Ancient " : "") + this.ItemName[shopItem.Group, shopItem.Index];
						string str2 = string.Concat(new object[]
						{
							obj,
							"+",
							shopItem.Level,
							"+",
							(shopItem.Option == 1) ? "4" : ((shopItem.Option == 2) ? "8" : ((shopItem.Option == 3) ? "12" : ((shopItem.Option == 4) ? "16" : ((shopItem.Option == 5) ? "20" : ((shopItem.Option == 6) ? "24" : ((shopItem.Option == 7) ? "28" : "0"))))))
						});
						string text2 = str2 + (shopItem.Skill ? "+Skill" : "");
						string str3 = string.Concat(new object[]
						{
							text2,
							shopItem.Luck ? "+Luck" : "",
							"\n\nDurability: ",
							shopItem.Durablity
						});
						string text3 = str3 + ((shopItem.Ancient > 0) ? ((shopItem.Ancient == 5) ? "\n\nAncinet: Level 1" : ((shopItem.Ancient == 10) ? "\n\nAncinet: Level 2" : "")) : "");
						if (shopItem.Excellent > 0)
						{
							text3 = text3 + "\n\nExcellent Option: " + shopItem.Excellent;
						}
						Structures.UniItem uniqItm = new Structures.UniItem
						{
							Group = shopItem.Group,
							Index = shopItem.Index
						};
						uniqItm.X = (int)Convert.ToInt16(this.ItemSize[uniqItm.Group, uniqItm.Index].Split(new char[]
						{
							'x'
						})[0]);
						uniqItm.Y = (int)Convert.ToInt16(this.ItemSize[uniqItm.Group, uniqItm.Index].Split(new char[]
						{
							'x'
						})[1]);
						if (this.AddItemPicture(text3, ref empty, uniqItm, ref shopItem))
						{
							shopItem.UniqName = empty;
							this.SelectedSI = shopItem;
							this.ShopItems[shopItem.ShopLocY, shopItem.ShopLocX] = shopItem;
						}
					}
					catch
					{
						MessageBox.Show("\tInvalid line", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						break;
					}
				}
			}
		}

		// Token: 0x06000485 RID: 1157 RVA: 0x0001EA5C File Offset: 0x0001CC5C
		private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog
			{
				Title = "Select a Location to save the Shop file",
				Filter = "Text files (*.txt)|*.txt"
			};
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				string[] array = saveFileDialog.FileName.Split(new char[]
				{
					'\\'
				});
				this.label_FileName.Text = array[array.Length - 1];
				string[] array2 = saveFileDialog.FileName.Split(new char[]
				{
					'\\'
				});
				string arg = array2[array2.Length - 1].Split(new char[]
				{
					'.'
				})[0];
				StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName)
				{
					AutoFlush = true
				};
				streamWriter.WriteLine("/////////////////////////////////////////////////////////////////////////////");
				streamWriter.WriteLine("//Shop file created by MU.ToolKit [Shop Editor]");
				streamWriter.WriteLine("//coded by © TopReal.IT");
				streamWriter.WriteLine("///////////////////////////");
				streamWriter.WriteLine("//Shop: {0}", arg);
				streamWriter.WriteLine("/////////////////////////////////////////////////////////////////////////////");
				streamWriter.WriteLine("//Group\tIndex\tLevel\tDur\tSkill\tLuck\tOpt\tExeOpt\tAncOpt\tInfo");
				streamWriter.WriteLine("/////////////////////////////////////////////////////////////////////////////");
				streamWriter.WriteLine("//");
				for (int i = 1; i < 16; i++)
				{
					for (int j = 1; j < 9; j++)
					{
						if (this.ShopItems[i, j].UniqName != null)
						{
							Structures.ShopItem shopItem = this.ShopItems[i, j];
							string str = string.Empty + ((shopItem.Excellent > 0) ? "Excellent " : "");
							string str2 = str + ((shopItem.Ancient > 0) ? "Ancient " : "");
							streamWriter.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t//{9}", new object[]
							{
								shopItem.Group,
								shopItem.Index,
								shopItem.Level,
								shopItem.Durablity,
								Convert.ToInt16(shopItem.Skill),
								Convert.ToInt16(shopItem.Luck),
								shopItem.Option,
								shopItem.Excellent,
								shopItem.Ancient,
								str2 + this.ItemName[shopItem.Group, shopItem.Index]
							});
						}
					}
				}
				streamWriter.WriteLine("end");
				streamWriter.Close();
			}
		}

		// Token: 0x06000486 RID: 1158 RVA: 0x0001ED0D File Offset: 0x0001CF0D
		private void ShopEditor_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.OpenForms["Form1"].WindowState = FormWindowState.Normal;
		}

		// Token: 0x06000487 RID: 1159 RVA: 0x0001ED24 File Offset: 0x0001CF24
		private void ShopEditor_Load(object sender, EventArgs e)
		{
			Form1 form = (Form1)Application.OpenForms[0];
			this.isEx700ItemList = (form.isEx700ItemList ? 1 : 0);
			this.AddPreviewBoxes(8, 15);
			if (this.isEx700ItemList == 1)
			{
				this.strct.ReadItemList("Data\\ItemListSettings_ex700.ini", true, ref this.L_Groups, ref this.L_Swords, ref this.L_Axes, ref this.L_MacesScepters, ref this.L_Spears, ref this.L_BowsCrossBows, ref this.L_Staffs, ref this.L_Shields, ref this.L_Helms, ref this.L_Armors, ref this.L_Pants, ref this.L_Gloves, ref this.L_Boots, ref this.L_WingsSkillsSeedsOthers, ref this.L_Others1, ref this.L_Others2, ref this.L_Scrolls, ref this.ItemName, ref this.ItemSize);
			}
			else
			{
				this.strct.ReadItemList("Data\\ItemListSettings.ini", false, ref this.L_Groups, ref this.L_Swords, ref this.L_Axes, ref this.L_MacesScepters, ref this.L_Spears, ref this.L_BowsCrossBows, ref this.L_Staffs, ref this.L_Shields, ref this.L_Helms, ref this.L_Armors, ref this.L_Pants, ref this.L_Gloves, ref this.L_Boots, ref this.L_WingsSkillsSeedsOthers, ref this.L_Others1, ref this.L_Others2, ref this.L_Scrolls, ref this.ItemName, ref this.ItemSize);
			}
			this.listBox_Group.DisplayMember = "GroupName";
			this.listBox_Group.ValueMember = "Group";
			this.listBox_Group.DataSource = this.L_Groups;
			this.strct.Setc_LevelData(ref this.c_LevelDatas);
			this.listBox_Level.DataSource = this.c_LevelDatas;
			this.listBox_Level.ValueMember = "ID";
			this.listBox_Level.DisplayMember = "Name";
			this.strct.Setc_OptionData(ref this.c_OptionDatas);
			this.listBox_Option.DataSource = this.c_OptionDatas;
			this.listBox_Option.DisplayMember = "Name";
			this.listBox_Option.ValueMember = "ID";
			this.radioButton_ExcWeapon.Checked = true;
			Application.OpenForms["Form1"].WindowState = FormWindowState.Minimized;
			base.WindowState = FormWindowState.Normal;
			base.TopMost = true;
			base.TopMost = false;
			base.BringToFront();
			base.Focus();
		}

		// Token: 0x040001FD RID: 509
		private List<Structures.c_LevelData> c_LevelDatas = new List<Structures.c_LevelData>();

		// Token: 0x040001FE RID: 510
		private List<Structures.c_OptionData> c_OptionDatas = new List<Structures.c_OptionData>();

		// Token: 0x0400020A RID: 522
		private bool DontWork;

		// Token: 0x04000211 RID: 529
		private int isEx700ItemList;

		// Token: 0x04000212 RID: 530
		private string[,] ItemName = new string[16, 513];

		// Token: 0x04000213 RID: 531
		private string[,] ItemSize = new string[16, 513];

		// Token: 0x04000214 RID: 532
		private List<Structures.UniItem> L_Armors = new List<Structures.UniItem>();

		// Token: 0x04000215 RID: 533
		private List<Structures.UniItem> L_Axes = new List<Structures.UniItem>();

		// Token: 0x04000216 RID: 534
		private List<Structures.UniItem> L_Boots = new List<Structures.UniItem>();

		// Token: 0x04000217 RID: 535
		private List<Structures.UniItem> L_BowsCrossBows = new List<Structures.UniItem>();

		// Token: 0x04000218 RID: 536
		private List<Structures.UniItem> L_Gloves = new List<Structures.UniItem>();

		// Token: 0x04000219 RID: 537
		private List<Structures.c_Groups> L_Groups = new List<Structures.c_Groups>();

		// Token: 0x0400021A RID: 538
		private List<Structures.UniItem> L_Helms = new List<Structures.UniItem>();

		// Token: 0x0400021B RID: 539
		private List<Structures.UniItem> L_MacesScepters = new List<Structures.UniItem>();

		// Token: 0x0400021C RID: 540
		private List<Structures.UniItem> L_Others1 = new List<Structures.UniItem>();

		// Token: 0x0400021D RID: 541
		private List<Structures.UniItem> L_Others2 = new List<Structures.UniItem>();

		// Token: 0x0400021E RID: 542
		private List<Structures.UniItem> L_Pants = new List<Structures.UniItem>();

		// Token: 0x0400021F RID: 543
		private List<Structures.UniItem> L_Scrolls = new List<Structures.UniItem>();

		// Token: 0x04000220 RID: 544
		private List<Structures.UniItem> L_Shields = new List<Structures.UniItem>();

		// Token: 0x04000221 RID: 545
		private List<Structures.UniItem> L_Spears = new List<Structures.UniItem>();

		// Token: 0x04000222 RID: 546
		private List<Structures.UniItem> L_Staffs = new List<Structures.UniItem>();

		// Token: 0x04000223 RID: 547
		private List<Structures.UniItem> L_Swords = new List<Structures.UniItem>();

		// Token: 0x04000224 RID: 548
		private List<Structures.UniItem> L_WingsSkillsSeedsOthers = new List<Structures.UniItem>();

		// Token: 0x04000227 RID: 551
		private int LastSelectedItemIndex;

		// Token: 0x04000228 RID: 552
		private Structures.CustomPictureBox LastSelectetItem = new Structures.CustomPictureBox();

		// Token: 0x04000230 RID: 560
		private bool[,] OccupiedBoxes = new bool[16, 9];

		// Token: 0x04000231 RID: 561
		private int OldDurValue;

		// Token: 0x0400023D RID: 573
		private Structures.ShopItem SelectedSI = default(Structures.ShopItem);

		// Token: 0x0400023E RID: 574
		private Structures.ShopItem[,] ShopItems = new Structures.ShopItem[16, 9];

		// Token: 0x0400023F RID: 575
		private Structures strct = new Structures();
	}
}
