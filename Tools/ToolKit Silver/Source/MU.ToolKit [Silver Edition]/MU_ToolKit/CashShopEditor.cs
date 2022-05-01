using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MU_ToolKit.Properties;

namespace MU_ToolKit
{
	// Token: 0x0200000B RID: 11
	public partial class CashShopEditor : Form
	{
		// Token: 0x06000380 RID: 896 RVA: 0x0000FD04 File Offset: 0x0000DF04
		public CashShopEditor()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000381 RID: 897 RVA: 0x0000FE60 File Offset: 0x0000E060
		private void AddHeadCat(Structures.IBSCategory cat)
		{
			if (this.CatCount < 6)
			{
				Panel panel = new MyPanel();
				TextBox textBox = new TextBox
				{
					Location = new Point(this.textBox_Cat1.Location.X - 5, this.textBox_Cat1.Location.Y),
					BackColor = this.textBox_Cat1.BackColor,
					BorderStyle = this.textBox_Cat1.BorderStyle,
					ForeColor = this.textBox_Cat1.ForeColor,
					Font = this.textBox_Cat1.Font,
					TextAlign = this.textBox_Cat1.TextAlign,
					Name = string.Concat(new object[]
					{
						"txtb_Cat_",
						cat.Seq,
						"_",
						cat.Index
					}),
					Text = cat.Name
				};
				textBox.MouseClick += this.nwTbHeadCat_MouseClick;
				textBox.MouseDoubleClick += this.nwTbHeadCat_MouseDoubleClick;
				textBox.KeyDown += this.nwTbHeadCat_KeyDown;
				textBox.LostFocus += this.nwTb_LostFocus;
				textBox.ReadOnly = true;
				if (this.isFirstHeadCat == 0)
				{
					textBox.ForeColor = Color.Gold;
					this.LastClickedCatTB = textBox;
					this.isFirstHeadCat = 1;
				}
				panel.Name = string.Concat(new object[]
				{
					"pnl_Cat_",
					cat.Seq,
					"_",
					cat.Index
				});
				panel.BackgroundImageLayout = ImageLayout.Stretch;
				panel.BackgroundImage = new Bitmap(Resources.pnl_NewCat);
				panel.Location = new Point(this.panel_CatFirst.Size.Width * (int)this.CatCount + 40, 0);
				panel.Size = new Size(this.panel_CatFirst.Size.Width, this.panel_CatFirst.Size.Height);
				this.panel_MainForm.Controls.Add(panel);
				this.AddedCatName.Add(string.Concat(new object[]
				{
					"pnl_Cat_",
					cat.Seq,
					"_",
					cat.Index
				}));
				this.CatCount += 1;
				panel.Controls.Add(textBox);
				panel.BringToFront();
			}
		}

		// Token: 0x06000382 RID: 898 RVA: 0x00010110 File Offset: 0x0000E310
		private void AddItem(Structures.IBSPackage pack)
		{
			if (this.AddedItems.Count < 10)
			{
				pack.TraceNumber = this.TraceNumber;
				int num = pack.ItemID / 512;
				int num2 = pack.ItemID - 512 * num;
				Panel panel = new Panel
				{
					BackColor = Color.Transparent
				};
				string firstNull = this.GetFirstNull(this.ItemsStrct, 3, 3);
				int num3 = Convert.ToInt32(firstNull.Split(new char[]
				{
					'x'
				})[0]);
				int num4 = Convert.ToInt32(firstNull.Split(new char[]
				{
					'x'
				})[1]);
				panel.Name = string.Concat(new object[]
				{
					"pnl_Itm_",
					num4,
					"x",
					num3
				});
				if (this.AddedItems.Count < 3)
				{
					panel.Location = new Point(num4 * this.panel_Item.Size.Width + 5, num3 * this.panel_Item.Size.Height + 1);
				}
				else if (this.AddedItems.Count < 6)
				{
					panel.Location = new Point(num4 * this.panel_Item.Size.Width - 3, num3 * this.panel_Item.Size.Height + 45);
				}
				else
				{
					panel.Location = new Point(num4 * this.panel_Item.Size.Width + 10, num3 * this.panel_Item.Size.Height + 85);
				}
				panel.Size = this.panel_Item.Size;
				Label value = new Label
				{
					Location = this.label_ItemName.Location,
					Size = this.label_ItemName.Size,
					TextAlign = ContentAlignment.MiddleCenter,
					ForeColor = this.label_ItemName.ForeColor,
					Text = pack.Name,
					AutoSize = false
				};
				Label value2 = new Label
				{
					Location = this.label_ItemPrice.Location,
					Size = this.label_ItemPrice.Size,
					TextAlign = ContentAlignment.MiddleCenter,
					ForeColor = this.label_ItemPrice.ForeColor,
					Text = pack.Price + " " + pack.CoinTxt1
				};
				Structures.CustomPictureBox customPictureBox = new Structures.CustomPictureBox
				{
					Location = this.pictureBox_ItemImg.Location,
					Size = this.pictureBox_ItemImg.Size,
					BackgroundImageLayout = ImageLayout.Center,
					Name = string.Concat(new object[]
					{
						panel.Name,
						"_",
						pack.CatIndex,
						"@",
						pack.Seq,
						"@",
						pack.Index
					})
				};
				customPictureBox.MouseClick += this.itmPic_MouseClick;
				customPictureBox.BorderColor = Color.Transparent;
				try
				{
					customPictureBox.BackgroundImage = (Bitmap)Resources.ResourceManager.GetObject("_" + num.ToString() + num2.ToString());
					if (customPictureBox.BackgroundImage.Size.Width > customPictureBox.Size.Width || customPictureBox.BackgroundImage.Size.Height > customPictureBox.Size.Height)
					{
						customPictureBox.BackgroundImageLayout = ImageLayout.Zoom;
					}
				}
				catch
				{
					customPictureBox.BackgroundImage = (Bitmap)Resources.ResourceManager.GetObject("no_img");
				}
				panel.Controls.Add(value);
				panel.Controls.Add(customPictureBox);
				panel.Controls.Add(value2);
				this.panel_ItemsPage1.Controls.Add(panel);
				this.ItemsStrct[num3, num4] = 1;
				this.AddedItems.Add(string.Concat(new object[]
				{
					panel.Name,
					"_",
					pack.CatIndex,
					"@",
					pack.Seq,
					"@",
					pack.Index
				}));
				this.TraceNumber++;
			}
		}

		// Token: 0x06000383 RID: 899 RVA: 0x000105F8 File Offset: 0x0000E7F8
		private void AddSubCat(Structures.IBSCategory cat)
		{
			if (this.SubCatCount < 12)
			{
				Panel panel = new MyPanel();
				TextBox textBox = new TextBox
				{
					Location = new Point(30, 17),
					BackColor = this.textBox_SubCat1.BackColor,
					BorderStyle = this.textBox_SubCat1.BorderStyle,
					ForeColor = this.textBox_SubCat1.ForeColor,
					Font = this.textBox_SubCat1.Font,
					TextAlign = this.textBox_SubCat1.TextAlign,
					Name = string.Concat(new object[]
					{
						"txtb_SubCat_",
						cat.Seq,
						"_",
						cat.Index
					}),
					Text = cat.Name
				};
				textBox.MouseClick += this.nwTbSubCat_MouseClick;
				textBox.MouseDoubleClick += this.nwTbSubCat_MouseDoubleClick;
				textBox.KeyDown += this.nwTbSubCat_KeyDown;
				textBox.ReadOnly = true;
				textBox.LostFocus += this.nwTb_LostFocus;
				if (this.isFirstSubCat == 0)
				{
					textBox.ForeColor = Color.Gold;
					this.LastClickedSubCatTB = textBox;
					this.isFirstSubCat = 1;
				}
				panel.Name = string.Concat(new object[]
				{
					"pnl_SubCat_",
					cat.Seq,
					"_",
					cat.Index
				});
				panel.BackgroundImageLayout = ImageLayout.Stretch;
				panel.BackgroundImage = new Bitmap(Resources.pnl_NewSubCat2);
				panel.Location = new Point(0, (Resources.pnl_NewSubCat2.Size.Height - 30) * (int)this.SubCatCount + this.panel_SubCat1.Size.Height - 10);
				panel.Size = new Size(Resources.pnl_NewSubCat2.Size.Width - 30, Resources.pnl_NewSubCat2.Size.Height - 30);
				this.AddedSubCatName.Add(string.Concat(new object[]
				{
					"pnl_SubCat_",
					cat.Seq,
					"_",
					cat.Index
				}));
				this.SubCatCount += 1;
				this.panel_SubCatEnd.Location = new Point(0, (Resources.pnl_NewSubCat2.Size.Height - 31) * (int)this.SubCatCount + this.panel_SubCat1.Size.Height);
				panel.BringToFront();
				this.panel_MainForm.Controls.Add(panel);
				panel.Controls.Add(textBox);
			}
		}

		// Token: 0x06000384 RID: 900 RVA: 0x000108DC File Offset: 0x0000EADC
		private void addToolStripMenuItem_Cat_Click(object sender, EventArgs e)
		{
			if (this.CatCount < 6)
			{
				if (base.HasChildren)
				{
					Form_CashShop_AddItems form_CashShop_AddItems = (Form_CashShop_AddItems)Application.OpenForms["Form_CashShop_AddItems"];
					if (form_CashShop_AddItems != null)
					{
						form_CashShop_AddItems.button_AddItemToDB.Enabled = false;
						form_CashShop_AddItems.button_NewItem_Add.Enabled = false;
						form_CashShop_AddItems.button_UpdateExistingItem.Enabled = false;
					}
				}
				this.MaxHeadCatIndex++;
				Structures.IBSCategory ibscategory = new Structures.IBSCategory
				{
					Index = this.MaxHeadCatIndex,
					Name = "HeadCat_" + (int)(this.CatCount + 1),
					Unk1 = 200,
					Unk2 = 201,
					Seq = Convert.ToInt16((int)(this.CatCount + 1)),
					IsHeadCat = true
				};
				ibscategory.HeadCatIndex = ibscategory.Index;
				this.HeadCategories.Add(ibscategory);
				this.AddHeadCat(ibscategory);
			}
		}

		// Token: 0x06000385 RID: 901 RVA: 0x000109D4 File Offset: 0x0000EBD4
		private void addToolStripMenuItem_SubCat_Click(object sender, EventArgs e)
		{
			if (this.CatCount > 0 & this.SelectedHeadCat.Unk1 != 0)
			{
				this.MaxCategoryIndex++;
				Structures.IBSCategory ibscategory = new Structures.IBSCategory
				{
					Index = this.MaxCategoryIndex,
					Name = "SubCat_" + (int)(this.SubCatCount + 1),
					Unk1 = 200,
					Unk2 = 201,
					HeadCatIndex = this.SelectedHeadCat.Index,
					Seq = Convert.ToInt16((int)(this.SubCatCount + 1)),
					IsHeadCat = false
				};
				this.SubCategories.Add(ibscategory);
				this.AddSubCat(ibscategory);
				if (this.AddedSubCatName.Count == 1)
				{
					this.SelectedSubCat = ibscategory;
					if (!this.button_NewItem_Add.Enabled)
					{
						this.button_NewItem_Add.Enabled = true;
					}
				}
			}
		}

		// Token: 0x06000386 RID: 902 RVA: 0x00010ACB File Offset: 0x0000ECCB
		private void CashShopEditor_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.OpenForms["Form1"].WindowState = FormWindowState.Normal;
			this.isParentClosing = true;
			Application.OpenForms["Form_CashShop_AddItems"].Close();
		}

		// Token: 0x06000387 RID: 903 RVA: 0x00010B00 File Offset: 0x0000ED00
		private void CashShopEditor_Load(object sender, EventArgs e)
		{
			Form1 form = (Form1)Application.OpenForms[0];
			this.isEx700ItemList = (form.isEx700ItemList ? 1 : 0);
			this.DoubleBuffered = true;
			this.ReadCSFiles();
			this.LoadHeadCategories();
			if (this.CatCount > 0)
			{
				this.LoadSubCategories(this.HeadCategories[0].HeadCatIndex);
				this.ItemsToAdd = this.GetSubCatItems(this.SubCategories[0].Index);
				this.LoadItems(1);
				this.SelectedSubCat = this.SubCategories[0];
				this.SelectedHeadCat = this.HeadCategories[0];
			}
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
			Application.OpenForms["Form1"].WindowState = FormWindowState.Minimized;
			base.WindowState = FormWindowState.Normal;
			base.TopMost = true;
			base.TopMost = false;
			base.BringToFront();
			base.Focus();
			this.form_ItemsAdd = new Form_CashShop_AddItems();
			this.form_ItemsAdd.Show();
		}

		// Token: 0x06000388 RID: 904 RVA: 0x00010C04 File Offset: 0x0000EE04
		private void clientToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string text = "Saved Data\\CashShop Editor\\Client Files\\" + DateTime.Now.ToLocalTime().ToString().Replace('/', '.').Replace(':', '-').Replace(" ", " [") + "]";
			Directory.CreateDirectory(text);
			if (this.GenerateClientFiles(text) && MessageBox.Show("Files saved successfully in\n\"" + text + "\"\n\nOpen containing folder?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
			{
				Process.Start(text);
			}
		}

		// Token: 0x0600038A RID: 906 RVA: 0x00010CB4 File Offset: 0x0000EEB4
		private bool GenerateClientFiles(string FolderName)
		{
			StreamWriter streamWriter = new StreamWriter(FolderName + "\\IBSCategory.txt");
			bool result;
			try
			{
				streamWriter.AutoFlush = true;
				foreach (Structures.IBSCategory ibscategory in this.HeadCategories)
				{
					object empty = string.Empty;
					object obj = string.Concat(new object[]
					{
						empty,
						ibscategory.Index,
						"@",
						ibscategory.Name,
						"@",
						ibscategory.Unk1,
						"@"
					});
					string arg = string.Concat(new object[]
					{
						obj,
						ibscategory.Unk2,
						"@",
						ibscategory.HeadCatIndex,
						"@",
						ibscategory.Seq,
						"@"
					});
					string value = arg + Convert.ToInt16(ibscategory.IsHeadCat);
					streamWriter.WriteLine(value);
				}
				foreach (Structures.IBSCategory ibscategory2 in this.SubCategories)
				{
					object empty2 = string.Empty;
					object obj2 = string.Concat(new object[]
					{
						empty2,
						ibscategory2.Index,
						"@",
						ibscategory2.Name,
						"@",
						ibscategory2.Unk1,
						"@"
					});
					string arg2 = string.Concat(new object[]
					{
						obj2,
						ibscategory2.Unk2,
						"@",
						ibscategory2.HeadCatIndex,
						"@",
						ibscategory2.Seq,
						"@"
					});
					string value2 = arg2 + Convert.ToInt16(ibscategory2.IsHeadCat);
					streamWriter.WriteLine(value2);
				}
				streamWriter.Close();
				streamWriter = new StreamWriter(FolderName + "\\IBSPackage.txt");
				foreach (Structures.IBSPackage ibspackage in this.Packages)
				{
					object empty3 = string.Empty;
					object obj3 = string.Concat(new object[]
					{
						empty3,
						ibspackage.CatIndex,
						"@",
						ibspackage.Seq,
						"@",
						ibspackage.Index,
						"@",
						ibspackage.Name,
						"@"
					});
					object obj4 = string.Concat(new object[]
					{
						obj3,
						ibspackage.Unk1,
						"@",
						ibspackage.Price,
						"@",
						ibspackage.Info,
						"@",
						ibspackage.Empty,
						"@"
					});
					object obj5 = string.Concat(new object[]
					{
						obj4,
						ibspackage.Unk2,
						"@",
						ibspackage.Unk3,
						"@",
						ibspackage.Unk4,
						"@",
						ibspackage.Unk5,
						"@"
					});
					object obj6 = string.Concat(new object[]
					{
						obj5,
						ibspackage.Unk6,
						"@",
						ibspackage.RewardCount,
						"@",
						ibspackage.CoinTxt1,
						"@"
					});
					object obj7 = string.Concat(new object[]
					{
						obj6,
						ibspackage.CoinTxt2,
						"@",
						ibspackage.Unk7,
						"@",
						ibspackage.Unk8,
						"@",
						ibspackage.Unk9,
						"@"
					});
					object obj8 = string.Concat(new object[]
					{
						obj7,
						ibspackage.ProductRewardIndex1,
						"@",
						ibspackage.ItemID,
						"@",
						ibspackage.Unk10,
						"@"
					});
					string arg3 = string.Concat(new object[]
					{
						obj8,
						ibspackage.CheckBoxCount,
						"@",
						ibspackage.ProductRewardIndexes7,
						"@",
						ibspackage.Unk11,
						"@",
						ibspackage.ServerCatIndex,
						"@"
					});
					string value3 = arg3 + ibspackage.Const669;
					streamWriter.WriteLine(value3);
				}
				streamWriter.Close();
				streamWriter = new StreamWriter(FolderName + "\\IBSProduct.txt");
				foreach (Structures.IBSProduct ibsproduct in this.Products)
				{
					object empty4 = string.Empty;
					object obj9 = string.Concat(new object[]
					{
						empty4,
						ibsproduct.Index1,
						"@",
						ibsproduct.Name,
						"@",
						ibsproduct.BuyTypeTxt1,
						"@"
					});
					object obj10 = string.Concat(new object[]
					{
						obj9,
						ibsproduct.TypeCount,
						"@",
						ibsproduct.BuyTypeTxt2,
						"@",
						ibsproduct.Price,
						"@",
						ibsproduct.Index7,
						"@"
					});
					object obj11 = string.Concat(new object[]
					{
						obj10,
						ibsproduct.Unk1,
						"@",
						ibsproduct.Unk2,
						"@",
						ibsproduct.Unk3,
						"@"
					});
					string text = string.Concat(new object[]
					{
						obj11,
						ibsproduct.Unk4,
						"@",
						ibsproduct.Unk5,
						"@",
						ibsproduct.Unk6,
						"@"
					});
					string str = string.Concat(new string[]
					{
						text,
						ibsproduct.ItemID,
						"@",
						ibsproduct.Unk7,
						"@",
						ibsproduct.Unk8,
						"@"
					});
					string value4 = str + ibsproduct.Unk9;
					streamWriter.WriteLine(value4);
				}
				streamWriter.Close();
				result = true;
			}
			catch
			{
				streamWriter.Close();
				result = false;
			}
			return result;
		}

		// Token: 0x0600038B RID: 907 RVA: 0x00011564 File Offset: 0x0000F764
		private bool GenerateServerFiles(string FolderName)
		{
			StreamWriter streamWriter = new StreamWriter(FolderName + "\\IGCCashItemInfo.dat");
			bool result;
			try
			{
				streamWriter.AutoFlush = true;
				streamWriter.WriteLine("1");
				foreach (Structures.IGCCashItemInfo igccashItemInfo in this.ItemsInfo)
				{
					object empty = string.Empty;
					object obj = string.Concat(new object[]
					{
						empty,
						igccashItemInfo.GID,
						"\t",
						igccashItemInfo.ID,
						"\t",
						igccashItemInfo.iGroup,
						"\t",
						igccashItemInfo.iIndex,
						"\t"
					});
					object obj2 = string.Concat(new object[]
					{
						obj,
						igccashItemInfo.Level,
						"\t",
						igccashItemInfo.Dur,
						"\t",
						igccashItemInfo.Skill,
						"\t",
						igccashItemInfo.Luck,
						"\t"
					});
					object obj3 = string.Concat(new object[]
					{
						obj2,
						igccashItemInfo.Option,
						"\t",
						igccashItemInfo.Exc,
						"\t",
						igccashItemInfo.Ancient,
						"\t",
						igccashItemInfo.Socket,
						"\t"
					});
					string value = string.Concat(new object[]
					{
						obj3,
						igccashItemInfo.Type,
						"\t",
						igccashItemInfo.Period,
						"\t//",
						igccashItemInfo.Name
					});
					streamWriter.WriteLine(value);
				}
				streamWriter.WriteLine("end");
				streamWriter.Close();
				streamWriter = new StreamWriter(FolderName + "\\IGCCashItemList.dat");
				streamWriter.WriteLine("1");
				foreach (Structures.IGCCashItemList igccashItemList in this.ItemsList)
				{
					object empty2 = string.Empty;
					object obj4 = string.Concat(new object[]
					{
						empty2,
						igccashItemList.GUID,
						"\t",
						igccashItemList.Index,
						"\t",
						igccashItemList.SubIndex,
						"\t",
						igccashItemList.iOpt,
						"\t"
					});
					object obj5 = string.Concat(new object[]
					{
						obj4,
						igccashItemList.pID,
						"\t",
						igccashItemList.cType,
						"\t",
						igccashItemList.iPrice,
						"\t",
						igccashItemList.iInfoGD,
						"\t"
					});
					object obj6 = string.Concat(new object[]
					{
						obj5,
						igccashItemList.iInfoID,
						"\t",
						igccashItemList.iCat,
						"\t",
						igccashItemList.iGP,
						"\t",
						igccashItemList.iSale,
						"\t"
					});
					string value2 = string.Concat(new object[]
					{
						obj6,
						igccashItemList.iRand,
						"\t//",
						igccashItemList.Name
					});
					streamWriter.WriteLine(value2);
				}
				streamWriter.WriteLine("end");
				streamWriter.Close();
				streamWriter = new StreamWriter(FolderName + "\\IGCCashItemPackages.dat");
				streamWriter.WriteLine("1");
				foreach (Structures.IGCCashItemPackages igccashItemPackages in this.ItemsPackage)
				{
					object empty3 = string.Empty;
					string value3 = string.Concat(new object[]
					{
						empty3,
						"\t",
						igccashItemPackages.GUID,
						"\t",
						igccashItemPackages.pID,
						"\t",
						igccashItemPackages.iSeq,
						"\t",
						igccashItemPackages.iGUID,
						"\t",
						igccashItemPackages.iID,
						"\t//",
						igccashItemPackages.Name
					});
					streamWriter.WriteLine(value3);
				}
				streamWriter.WriteLine("end");
				streamWriter.Close();
				result = true;
			}
			catch
			{
				streamWriter.Close();
				result = false;
			}
			return result;
		}

		// Token: 0x0600038C RID: 908 RVA: 0x00011B64 File Offset: 0x0000FD64
		private string GetFirstNull(object[,] theStrct, short sizeA, short sizeB)
		{
			for (int i = 0; i < (int)sizeA; i++)
			{
				for (int j = 0; j < (int)sizeB; j++)
				{
					if (theStrct[i, j] == null)
					{
						return i + "x" + j;
					}
				}
			}
			return null;
		}

		// Token: 0x0600038D RID: 909 RVA: 0x00011BAC File Offset: 0x0000FDAC
		public List<Structures.IBSPackage> GetSubCatItems(int SubCat)
		{
			List<Structures.IBSPackage> list = new List<Structures.IBSPackage>();
			foreach (Structures.IBSPackage item in this.Packages)
			{
				if ((int)item.CatIndex == SubCat)
				{
					list.Add(item);
				}
			}
			this.ItemPageCount = list.Count / 9 + 1;
			this.label_MaxPage.Text = this.ItemPageCount.ToString();
			return list;
		}

		// Token: 0x0600038E RID: 910 RVA: 0x00011C38 File Offset: 0x0000FE38
		public string GetUniqueString()
		{
			List<byte> list = new List<byte>();
			for (int i = 0; i < 36; i++)
			{
				list.Add((byte)this.rand.Next(0, 255));
			}
			return Convert.ToBase64String(list.ToArray());
		}

		// Token: 0x06000390 RID: 912 RVA: 0x00014640 File Offset: 0x00012840
		private void itmPic_MouseClick(object sender, MouseEventArgs e)
		{
			Structures.CustomPictureBox customPictureBox = (Structures.CustomPictureBox)sender;
			string[] array = customPictureBox.Name.Split(new char[]
			{
				'_'
			});
			if (e.Button == MouseButtons.Right)
			{
				if (MessageBox.Show("Are you sure you want to delete this item?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
				{
					return;
				}
				this.panel_ItemsPage1.Controls.RemoveByKey(string.Concat(new string[]
				{
					array[0],
					"_",
					array[1],
					"_",
					array[2]
				}));
				using (List<string>.Enumerator enumerator = this.AddedItems.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						string text = enumerator.Current;
						if (text == customPictureBox.Name)
						{
							this.AddedItems.Remove(text);
							this.RemoveItemPack(array[3]);
							this.ItemsToAdd = this.GetSubCatItems(this.SelectedSubCat.Index);
							this.LoadItems(this.currPage);
							break;
						}
					}
					return;
				}
			}
			if (e.Button == MouseButtons.Left)
			{
				foreach (string text2 in this.AddedItems)
				{
					if (text2 == customPictureBox.Name)
					{
						string[] array2 = text2.Split(new char[]
						{
							'_'
						})[3].Split(new char[]
						{
							'@'
						});
						string b = string.Empty;
						string b2 = array2[0];
						string text3 = array2[1];
						b = array2[2];
						this.Selected_iInfo = new BindingList<Structures.IGCCashItemInfo>();
						this.Selected_iPack = new BindingList<Structures.IGCCashItemPackages>();
						this.Selected_iList = new BindingList<Structures.IGCCashItemList>();
						this.Selected_iPackage = default(Structures.IBSPackage);
						this.Selected_iProduct = new BindingList<Structures.IBSProduct>();
						bool flag = false;
						foreach (Structures.IGCCashItemList item in this.ItemsList)
						{
							int index = item.Index;
							bool flag2 = index.ToString() == b;
							int iCat = item.iCat;
							if (flag2 & iCat.ToString() == b2)
							{
								this.Selected_iList.Add(item);
								flag = true;
							}
						}
						if (flag)
						{
							if (this.Selected_iList[0].pID > 0)
							{
								foreach (Structures.IGCCashItemPackages item2 in this.ItemsPackage)
								{
									if (item2.pID == this.Selected_iList[0].pID)
									{
										this.Selected_iPack.Add(item2);
									}
								}
							}
							foreach (Structures.IGCCashItemInfo item3 in this.ItemsInfo)
							{
								if (item3.GID == this.Selected_iList[0].iInfoGD)
								{
									this.Selected_iInfo.Add(item3);
								}
							}
							foreach (Structures.IBSProduct item4 in this.Products)
							{
								if (this.Selected_iList[0].iInfoGD == item4.Index1)
								{
									this.Selected_iProduct.Add(item4);
								}
							}
							foreach (Structures.IBSPackage selected_iPackage in this.Packages)
							{
								if ((int)selected_iPackage.Index == this.Selected_iList[0].Index)
								{
									this.Selected_iPackage = selected_iPackage;
									break;
								}
							}
							((Form_CashShop_AddItems)Application.OpenForms["Form_CashShop_AddItems"]).UpdateAddedItem();
							if (this.LastSelectedPB != null)
							{
								this.LastSelectedPB.BorderColor = Color.Transparent;
								this.LastSelectedPB.BorderStyle = BorderStyle.None;
							}
							customPictureBox.BorderStyle = BorderStyle.FixedSingle;
							customPictureBox.BorderColor = Color.Gold;
							this.LastSelectedPB = customPictureBox;
							break;
						}
						break;
					}
				}
			}
		}

		// Token: 0x06000391 RID: 913 RVA: 0x00014B1C File Offset: 0x00012D1C
		private void LoadHeadCategories()
		{
			foreach (Structures.IBSCategory cat in this.HeadCategories)
			{
				this.AddHeadCat(cat);
			}
		}

		// Token: 0x06000392 RID: 914 RVA: 0x00014B70 File Offset: 0x00012D70
		public void LoadItems(int Page)
		{
			for (int i = (Page - 1) * 9; i < (Page - 1) * 9 + 1; i++)
			{
				try
				{
					this.RemoveAddedItems();
					this.ItemsStrct = new object[3, 3];
					this.AddedItems = new List<string>();
					this.AddItem(this.ItemsToAdd[i]);
					this.AddItem(this.ItemsToAdd[i + 1]);
					this.AddItem(this.ItemsToAdd[i + 2]);
					this.AddItem(this.ItemsToAdd[i + 3]);
					this.AddItem(this.ItemsToAdd[i + 4]);
					this.AddItem(this.ItemsToAdd[i + 5]);
					this.AddItem(this.ItemsToAdd[i + 6]);
					this.AddItem(this.ItemsToAdd[i + 7]);
					this.AddItem(this.ItemsToAdd[i + 8]);
				}
				catch
				{
				}
			}
		}

		// Token: 0x06000393 RID: 915 RVA: 0x00014C80 File Offset: 0x00012E80
		private void LoadSubCategories(int HeadCatIndex)
		{
			this.isFirstSubCat = 0;
			this.RemoveAddedSubs();
			this.AddedSubCatName = new List<string>();
			this.AddedItems = new List<string>();
			this.LastClickedSubCatTB = null;
			this.SubCatCount = 0;
			foreach (Structures.IBSCategory cat in this.SubCategories)
			{
				if (cat.HeadCatIndex == HeadCatIndex)
				{
					this.AddSubCat(cat);
				}
			}
		}

		// Token: 0x06000394 RID: 916 RVA: 0x00014D10 File Offset: 0x00012F10
		private void nwTb_LostFocus(object sender, EventArgs e)
		{
			((TextBox)sender).ReadOnly = true;
		}

		// Token: 0x06000395 RID: 917 RVA: 0x00014D20 File Offset: 0x00012F20
		private void nwTbHeadCat_KeyDown(object sender, KeyEventArgs e)
		{
			TextBox textBox = (TextBox)sender;
			this.t1.Show("Press Enter to save new Category Name", textBox, 5000);
			if (e.KeyCode == Keys.Return)
			{
				int num = this.HeadCategories.IndexOf(this.SelectedHeadCat);
				Structures.IBSCategory ibscategory = this.HeadCategories[0];
				if (num != -1)
				{
					ibscategory = this.HeadCategories[num];
				}
				ibscategory.Name = textBox.Text;
				this.HeadCategories[num] = ibscategory;
				this.SelectedHeadCat = ibscategory;
				this.t1.Hide(textBox);
			}
		}

		// Token: 0x06000396 RID: 918 RVA: 0x00014DB4 File Offset: 0x00012FB4
		private void nwTbHeadCat_MouseClick(object sender, MouseEventArgs e)
		{
			TextBox textBox = (TextBox)sender;
			textBox.ReadOnly = false;
			string[] array = textBox.Name.Split(new char[]
			{
				'_'
			});
			short num = Convert.ToInt16(array[2]);
			short num2 = Convert.ToInt16(array[3]);
			foreach (Structures.IBSCategory ibscategory in this.HeadCategories)
			{
				if (num == ibscategory.Seq && (int)num2 == ibscategory.Index)
				{
					this.LoadSubCategories(this.HeadCategories[this.HeadCategories.IndexOf(ibscategory)].HeadCatIndex);
					this.ItemsToAdd = new List<Structures.IBSPackage>();
					foreach (Structures.IBSCategory selectedSubCat in this.SubCategories)
					{
						if (ibscategory.HeadCatIndex == selectedSubCat.HeadCatIndex & selectedSubCat.Seq == 1)
						{
							this.ItemsToAdd = this.GetSubCatItems(selectedSubCat.Index);
							this.currPage = 1;
							this.LoadItems(1);
							this.label_CurrPage.Text = "1";
							this.SelectedSubCat = selectedSubCat;
							break;
						}
					}
					if (this.AddedSubCatName.Count == 0)
					{
						this.RemoveAddedItems();
						this.currPage = 1;
						this.label_CurrPage.Text = "1";
						this.label_MaxPage.Text = "1";
						this.ItemPageCount = 1;
						this.button_NewItem_Add.Enabled = false;
						this.panel_SubCatEnd.Location = new Point(0, Resources.pnl_NewSubCat2.Size.Height);
						if (base.HasChildren)
						{
							Form_CashShop_AddItems form_CashShop_AddItems = (Form_CashShop_AddItems)Application.OpenForms["Form_CashShop_AddItems"];
							if (form_CashShop_AddItems != null)
							{
								form_CashShop_AddItems.button_AddItemToDB.Enabled = false;
								form_CashShop_AddItems.button_NewItem_Add.Enabled = false;
								form_CashShop_AddItems.button_UpdateExistingItem.Enabled = false;
							}
						}
					}
					else
					{
						this.button_NewItem_Add.Enabled = true;
						if (base.HasChildren)
						{
							Form_CashShop_AddItems form_CashShop_AddItems2 = (Form_CashShop_AddItems)Application.OpenForms["Form_CashShop_AddItems"];
							if (form_CashShop_AddItems2 != null)
							{
								form_CashShop_AddItems2.button_AddItemToDB.Enabled = true;
								form_CashShop_AddItems2.button_NewItem_Add.Enabled = true;
								form_CashShop_AddItems2.button_UpdateExistingItem.Enabled = true;
							}
						}
					}
					this.SelectedHeadCat = ibscategory;
					break;
				}
			}
			textBox.ForeColor = Color.Gold;
			if (this.LastClickedCatTB != null & this.LastClickedCatTB.Name != textBox.Name)
			{
				this.LastClickedCatTB.ForeColor = Color.White;
			}
			this.LastClickedCatTB = textBox;
		}

		// Token: 0x06000397 RID: 919 RVA: 0x000150A4 File Offset: 0x000132A4
		private void nwTbHeadCat_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to delete this Category?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				if (base.HasChildren)
				{
					Form_CashShop_AddItems form_CashShop_AddItems = (Form_CashShop_AddItems)Application.OpenForms["Form_CashShop_AddItems"];
					if (form_CashShop_AddItems != null)
					{
						form_CashShop_AddItems.button_AddItemToDB.Enabled = false;
						form_CashShop_AddItems.button_NewItem_Add.Enabled = false;
						form_CashShop_AddItems.button_UpdateExistingItem.Enabled = false;
					}
				}
				TextBox textBox = (TextBox)sender;
				string[] array = textBox.Name.Split(new char[]
				{
					'_'
				});
				short num = Convert.ToInt16(array[2]);
				short num2 = Convert.ToInt16(array[3]);
				List<Structures.IBSPackage> list = new List<Structures.IBSPackage>();
				new List<string>();
				List<Structures.IBSCategory> list2 = new List<Structures.IBSCategory>();
				foreach (Structures.IBSCategory item in this.HeadCategories)
				{
					if (num == item.Seq & (int)num2 == item.Index)
					{
						foreach (Structures.IBSCategory item2 in this.SubCategories)
						{
							if (item2.HeadCatIndex == item.Index)
							{
								List<Structures.IGCCashItemList> list3 = new List<Structures.IGCCashItemList>();
								foreach (Structures.IBSPackage item3 in this.Packages)
								{
									if (item2.Index == (int)item3.CatIndex)
									{
										list.Add(item3);
										foreach (Structures.IGCCashItemList item4 in this.ItemsList)
										{
											if (item4.iCat == item2.Index && item4.Index == (int)item3.Index)
											{
												list3.Add(item4);
												if (item4.TraceString != null && item4.pID > 0)
												{
													List<Structures.IGCCashItemPackages> list4 = new List<Structures.IGCCashItemPackages>();
													foreach (Structures.IGCCashItemPackages item5 in this.ItemsPackage)
													{
														if (item5.pID == item4.pID)
														{
															list4.Add(item5);
														}
													}
													for (int i = 0; i < list4.Count; i++)
													{
														this.ItemsPackage.Remove(list4[i]);
													}
												}
											}
										}
									}
								}
								for (int j = 0; j < list3.Count; j++)
								{
									this.ItemsList.Remove(list3[j]);
								}
								for (int k = 0; k < list.Count; k++)
								{
									this.Packages.Remove(list[k]);
								}
								list2.Add(item2);
							}
						}
						for (int l = 0; l < list2.Count; l++)
						{
							this.SubCategories.Remove(list2[l]);
						}
						this.panel_MainForm.Controls.RemoveByKey(string.Concat(new object[]
						{
							"pnl_Cat_",
							item.Seq,
							"_",
							item.Index
						}));
						this.AddedCatName.Remove(string.Concat(new object[]
						{
							"pnl_Cat_",
							item.Seq,
							"_",
							item.Index
						}));
						this.CatCount -= 1;
						this.RemoveAddedItems();
						this.currPage = 1;
						this.ItemPageCount = 1;
						this.label_CurrPage.Text = "1";
						this.label_MaxPage.Text = "1";
						if (this.LastClickedCatTB != null)
						{
							this.LastClickedCatTB.ForeColor = Color.White;
						}
						this.RemoveAddedSubs();
						this.AddedSubCatName = new List<string>();
						this.AddedItems = new List<string>();
						this.LastClickedSubCatTB = null;
						this.SelectedSubCat = default(Structures.IBSCategory);
						this.SelectedHeadCat = default(Structures.IBSCategory);
						this.SubCatCount = 0;
						this.panel_SubCatEnd.Location = new Point(0, this.panel_SubCat1.Location.Y + this.panel_SubCat1.Size.Height);
						this.RemoveAddedHeadCat();
						this.HeadCategories.Remove(item);
						break;
					}
				}
				for (int m = 0; m < this.HeadCategories.Count; m++)
				{
					Structures.IBSCategory value = this.HeadCategories[m];
					value.Seq = (short)(m + 1);
					this.HeadCategories[m] = value;
				}
				this.LoadHeadCategories();
				this.button_NewItem_Add.Enabled = false;
			}
		}

		// Token: 0x06000398 RID: 920 RVA: 0x00015628 File Offset: 0x00013828
		private void nwTbSubCat_KeyDown(object sender, KeyEventArgs e)
		{
			TextBox textBox = (TextBox)sender;
			this.t2.Show("Press Enter to save new Category Name", textBox, 5000);
			if (e.KeyCode == Keys.Return)
			{
				int index = this.SubCategories.IndexOf(this.SelectedSubCat);
				Structures.IBSCategory ibscategory = this.SubCategories[index];
				ibscategory.Name = textBox.Text;
				this.SubCategories[index] = ibscategory;
				this.SelectedSubCat = ibscategory;
				this.t2.Hide(textBox);
			}
		}

		// Token: 0x06000399 RID: 921 RVA: 0x000156A8 File Offset: 0x000138A8
		private void nwTbSubCat_MouseClick(object sender, MouseEventArgs e)
		{
			if (base.HasChildren)
			{
				Form_CashShop_AddItems form_CashShop_AddItems = (Form_CashShop_AddItems)Application.OpenForms["Form_CashShop_AddItems"];
				if (form_CashShop_AddItems != null)
				{
					form_CashShop_AddItems.button_AddItemToDB.Enabled = true;
					form_CashShop_AddItems.button_NewItem_Add.Enabled = true;
					form_CashShop_AddItems.button_UpdateExistingItem.Enabled = true;
				}
			}
			TextBox textBox = (TextBox)sender;
			textBox.ReadOnly = false;
			string[] array = textBox.Name.Split(new char[]
			{
				'_'
			});
			short num = Convert.ToInt16(array[2]);
			short num2 = Convert.ToInt16(array[3]);
			this.ItemsToAdd = new List<Structures.IBSPackage>();
			foreach (Structures.IBSCategory selectedSubCat in this.SubCategories)
			{
				if (num == selectedSubCat.Seq & (int)num2 == selectedSubCat.Index)
				{
					this.ItemsToAdd = this.GetSubCatItems(selectedSubCat.Index);
					this.currPage = 1;
					this.LoadItems(1);
					this.label_CurrPage.Text = "1";
					this.SelectedSubCat = selectedSubCat;
					break;
				}
			}
			textBox.ForeColor = Color.Gold;
			if (this.LastClickedSubCatTB != null & this.LastClickedSubCatTB.Name != textBox.Name)
			{
				this.LastClickedSubCatTB.ForeColor = Color.White;
			}
			this.LastClickedSubCatTB = textBox;
		}

		// Token: 0x0600039A RID: 922 RVA: 0x0001581C File Offset: 0x00013A1C
		private void nwTbSubCat_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to delete this Category?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				if (base.HasChildren)
				{
					Form_CashShop_AddItems form_CashShop_AddItems = (Form_CashShop_AddItems)Application.OpenForms["Form_CashShop_AddItems"];
					if (form_CashShop_AddItems != null)
					{
						form_CashShop_AddItems.button_AddItemToDB.Enabled = false;
						form_CashShop_AddItems.button_NewItem_Add.Enabled = false;
						form_CashShop_AddItems.button_UpdateExistingItem.Enabled = false;
					}
				}
				TextBox textBox = (TextBox)sender;
				string[] array = textBox.Name.Split(new char[]
				{
					'_'
				});
				short num = Convert.ToInt16(array[2]);
				short num2 = Convert.ToInt16(array[3]);
				List<Structures.IBSPackage> list = new List<Structures.IBSPackage>();
				new List<string>();
				foreach (Structures.IBSCategory item in this.SubCategories)
				{
					if (num == item.Seq & (int)num2 == item.Index)
					{
						List<Structures.IGCCashItemList> list2 = new List<Structures.IGCCashItemList>();
						foreach (Structures.IBSPackage item2 in this.Packages)
						{
							if (item.Index == (int)item2.CatIndex)
							{
								list.Add(item2);
								foreach (Structures.IGCCashItemList item3 in this.ItemsList)
								{
									if (item3.iCat == item.Index && item3.Index == (int)item2.Index)
									{
										list2.Add(item3);
										if (item3.TraceString != null && item3.pID > 0)
										{
											List<Structures.IGCCashItemPackages> list3 = new List<Structures.IGCCashItemPackages>();
											foreach (Structures.IGCCashItemPackages item4 in this.ItemsPackage)
											{
												if (item4.pID == item3.pID)
												{
													list3.Add(item4);
												}
											}
											for (int i = 0; i < list3.Count; i++)
											{
												this.ItemsPackage.Remove(list3[i]);
											}
										}
									}
								}
							}
						}
						for (int j = 0; j < list2.Count; j++)
						{
							this.ItemsList.Remove(list2[j]);
						}
						for (int k = 0; k < list.Count; k++)
						{
							this.Packages.Remove(list[k]);
						}
						this.panel_MainForm.Controls.RemoveByKey(string.Concat(new object[]
						{
							"pnl_SubCat_",
							item.Seq,
							"_",
							item.Index
						}));
						this.AddedSubCatName.Remove(string.Concat(new object[]
						{
							"pnl_SubCat_",
							item.Seq,
							"_",
							item.Index
						}));
						this.SubCatCount -= 1;
						this.RemoveAddedItems();
						this.currPage = 1;
						this.ItemPageCount = 1;
						this.label_CurrPage.Text = "1";
						this.label_MaxPage.Text = "1";
						if (this.LastClickedSubCatTB != null)
						{
							this.LastClickedSubCatTB.ForeColor = Color.White;
						}
						this.SelectedSubCat = default(Structures.IBSCategory);
						this.panel_SubCatEnd.Location = new Point(0, this.panel_SubCatEnd.Location.Y - Resources.pnl_NewSubCat2.Size.Height);
						this.SubCategories.Remove(item);
						this.RemoveAddedSubs();
						this.LoadSubCategories(this.SelectedHeadCat.Index);
						break;
					}
				}
				this.button_NewItem_Add.Enabled = false;
			}
		}

		// Token: 0x0600039B RID: 923 RVA: 0x00015C94 File Offset: 0x00013E94
		private void panel_NextPage_Click(object sender, EventArgs e)
		{
			if (this.currPage + 1 <= this.ItemPageCount)
			{
				this.currPage++;
				this.label_CurrPage.Text = this.currPage.ToString();
				this.LoadItems(this.currPage);
			}
		}

		// Token: 0x0600039C RID: 924 RVA: 0x00015CE1 File Offset: 0x00013EE1
		private void panel_PrevPage_Click(object sender, EventArgs e)
		{
			if (this.currPage - 1 != 0)
			{
				this.currPage--;
				this.label_CurrPage.Text = this.currPage.ToString();
				this.LoadItems(this.currPage);
			}
		}

		// Token: 0x0600039D RID: 925 RVA: 0x00015D20 File Offset: 0x00013F20
		private void ReadCSFiles()
		{
			foreach (string text in File.ReadAllLines("Data\\IGCCashItemList.dat"))
			{
				if (!text.StartsWith("//") && text.Trim().Length != 0)
				{
					string[] array2 = text.Split(new char[]
					{
						'/'
					});
					string text2 = text;
					if (array2.Length > 2)
					{
						string str = array2[2].Replace(" ", "$").Replace("\t", "$");
						text2 = array2[0] + "//" + str;
					}
					string[] array3 = text2.Replace(" ", "\t").Split(new char[]
					{
						'\t'
					});
					List<string> list = new List<string>();
					foreach (string text3 in array3)
					{
						if (text3.Length > 0)
						{
							list.Add(text3);
						}
					}
					array3 = list.ToArray();
					if (array3.Length >= 13)
					{
						Structures.IGCCashItemList item = new Structures.IGCCashItemList
						{
							GUID = Convert.ToInt32(array3[0]),
							Index = Convert.ToInt32(array3[1]),
							SubIndex = Convert.ToInt32(array3[2]),
							iOpt = Convert.ToInt32(array3[3]),
							pID = Convert.ToInt32(array3[4]),
							cType = Convert.ToInt32(array3[5]),
							iPrice = Convert.ToInt32(array3[6]),
							iInfoGD = Convert.ToInt32(array3[7]),
							iInfoID = Convert.ToInt32(array3[8]),
							iCat = Convert.ToInt32(array3[9]),
							iGP = Convert.ToInt32(array3[10]),
							iSale = Convert.ToInt32(array3[11]),
							iRand = Convert.ToInt32(array3[12]),
							TraceString = this.GetUniqueString()
						};
						if (array3.Length > 13)
						{
							item.Name = array3[13].Trim(new char[]
							{
								'/'
							}).Replace("$", " ");
						}
						if (item.GUID > this.MaxItemListGID)
						{
							this.MaxItemListGID = item.GUID;
						}
						this.IGC_CashItemList_Indexes.Add(item.Index.ToString());
						this.ItemsList.Add(item);
					}
				}
			}
			foreach (string text4 in File.ReadAllLines("Data\\IGCCashItemInfo.dat"))
			{
				if (!text4.StartsWith("//") && text4.Trim().Length != 0)
				{
					string[] array6 = text4.Split(new char[]
					{
						'/'
					});
					string text5 = text4;
					if (array6.Length > 2)
					{
						string str2 = array6[2].Replace(" ", "$").Replace("\t", "$");
						text5 = array6[0] + "//" + str2;
					}
					string[] array7 = text5.Replace(" ", "\t").Split(new char[]
					{
						'\t'
					});
					List<string> list2 = new List<string>();
					foreach (string text6 in array7)
					{
						if (text6.Length > 0)
						{
							list2.Add(text6);
						}
					}
					array7 = list2.ToArray();
					if (array7.Length >= 14)
					{
						Structures.IGCCashItemInfo item2 = new Structures.IGCCashItemInfo
						{
							GID = Convert.ToInt32(array7[0]),
							ID = Convert.ToInt32(array7[1]),
							iGroup = Convert.ToInt32(array7[2]),
							iIndex = Convert.ToInt32(array7[3]),
							Level = Convert.ToInt32(array7[4]),
							Dur = Convert.ToInt32(array7[5]),
							Skill = Convert.ToInt32(array7[6]),
							Luck = Convert.ToInt32(array7[7]),
							Option = Convert.ToInt32(array7[8]),
							Exc = Convert.ToInt32(array7[9]),
							Ancient = Convert.ToInt32(array7[10]),
							Socket = Convert.ToInt32(array7[11]),
							Type = Convert.ToInt32(array7[12]),
							Period = Convert.ToInt32(array7[13]),
							TraceString = this.GetUniqueString()
						};
						if (array7.Length > 14)
						{
							item2.Name = array7[14].Trim(new char[]
							{
								'/'
							}).Replace("$", " ");
						}
						this.IGC_CashItemInfo_Indexes.Add(item2.GID.ToString() + ',' + item2.ID.ToString());
						this.ItemsInfo.Add(item2);
					}
				}
			}
			foreach (string text7 in File.ReadAllLines("Data\\IGCCashItemPackages.dat"))
			{
				if (!text7.StartsWith("//") && text7.Trim().Length != 0)
				{
					string[] array10 = text7.Split(new char[]
					{
						'/'
					});
					string text8 = text7;
					if (array10.Length > 2)
					{
						string str3 = array10[2].Replace(" ", "$").Replace("\t", "$");
						text8 = array10[0] + "//" + str3;
					}
					string[] array11 = text8.Replace(" ", "\t").Split(new char[]
					{
						'\t'
					});
					List<string> list3 = new List<string>();
					foreach (string text9 in array11)
					{
						if (text9.Length > 0)
						{
							list3.Add(text9);
						}
					}
					array11 = list3.ToArray();
					if (array11.Length >= 5 && !array11[0].StartsWith("//"))
					{
						Structures.IGCCashItemPackages item3 = new Structures.IGCCashItemPackages
						{
							GUID = Convert.ToInt32(array11[0]),
							pID = Convert.ToInt32(array11[1]),
							iSeq = Convert.ToInt32(array11[2]),
							iGUID = Convert.ToInt32(array11[3]),
							iID = Convert.ToInt32(array11[4]),
							TraceString = this.GetUniqueString()
						};
						if (array11.Length > 5)
						{
							item3.Name = array11[5].Trim(new char[]
							{
								'/'
							}).Replace("$", " ");
						}
						this.IGC_CashItemPackages_Indexes.Add(item3.GUID.ToString() + ',' + item3.iGUID.ToString());
						if (item3.pID > this.MaxPackageID)
						{
							this.MaxPackageID = item3.pID + 1;
						}
						this.ItemsPackage.Add(item3);
					}
				}
			}
			foreach (string text10 in File.ReadAllLines("Data\\IBSCategory.txt"))
			{
				string[] array13 = text10.Split(new char[]
				{
					'@'
				});
				Structures.IBSCategory item4 = new Structures.IBSCategory
				{
					Index = (int)Convert.ToInt16(array13[0]),
					Name = array13[1],
					Unk1 = Convert.ToInt16(array13[2]),
					Unk2 = Convert.ToInt16(array13[3]),
					HeadCatIndex = (int)Convert.ToInt16(array13[4]),
					Seq = Convert.ToInt16(array13[5]),
					IsHeadCat = Convert.ToBoolean(Convert.ToInt16(array13[6])),
					TraceString = this.GetUniqueString()
				};
				if (item4.IsHeadCat)
				{
					this.HeadCategories.Add(item4);
				}
				else
				{
					this.SubCategories.Add(item4);
				}
				if (item4.Index > this.MaxCategoryIndex)
				{
					this.MaxCategoryIndex = item4.Index;
				}
				if (item4.Index > this.MaxHeadCatIndex & item4.IsHeadCat)
				{
					this.MaxHeadCatIndex = item4.Index;
				}
			}
			foreach (string text11 in File.ReadAllLines("Data\\IBSPackage.txt"))
			{
				string[] array14 = text11.Split(new char[]
				{
					'@'
				});
				Structures.IBSPackage item5 = new Structures.IBSPackage
				{
					CatIndex = Convert.ToInt16(array14[0]),
					Seq = Convert.ToInt16(array14[1]),
					Index = Convert.ToInt16(array14[2])
				};
				if (this.IGC_CashItemList_Indexes.Contains(item5.Index.ToString()))
				{
					item5.Name = array14[3];
					item5.Unk1 = Convert.ToInt16(array14[4]);
					item5.Price = Convert.ToInt32(array14[5]);
					item5.Info = array14[6];
					item5.Empty = array14[7];
					item5.Unk2 = Convert.ToInt16(array14[8]);
					item5.Unk3 = Convert.ToInt16(array14[9]);
					item5.Unk4 = array14[10];
					item5.Unk5 = array14[11];
					item5.Unk6 = Convert.ToInt16(array14[12]);
					item5.RewardCount = Convert.ToInt16(array14[13]);
					item5.CoinTxt1 = array14[14];
					item5.CoinTxt2 = array14[15];
					item5.Unk7 = Convert.ToInt16(array14[16]);
					item5.Unk8 = Convert.ToInt16(array14[17]);
					item5.Unk9 = Convert.ToInt16(array14[18]);
					item5.ProductRewardIndex1 = array14[19];
					item5.ItemID = Convert.ToInt32(array14[20]);
					item5.Unk10 = Convert.ToInt16(array14[21]);
					item5.CheckBoxCount = Convert.ToInt16(array14[22]);
					item5.ProductRewardIndexes7 = array14[23];
					item5.Unk11 = array14[24];
					item5.ServerCatIndex = Convert.ToInt32(array14[25]);
					item5.Const669 = Convert.ToInt32(array14[26]);
					item5.TraceString = this.GetUniqueString();
					this.Packages.Add(item5);
					if ((int)item5.Index > this.PackageMaxIndex)
					{
						this.PackageMaxIndex = (int)item5.Index;
					}
				}
			}
			List<string> list4 = new List<string>();
			foreach (string text12 in File.ReadAllLines("Data\\IBSProduct.txt"))
			{
				string[] array15 = text12.Split(new char[]
				{
					'@'
				});
				Structures.IBSProduct item6 = new Structures.IBSProduct
				{
					Index1 = Convert.ToInt32(array15[0]),
					Name = array15[1],
					BuyTypeTxt1 = array15[2],
					TypeCount = array15[3],
					BuyTypeTxt2 = array15[4],
					Price = Convert.ToInt32(array15[5]),
					Index7 = Convert.ToInt32(array15[6]),
					Unk1 = Convert.ToInt16(array15[7]),
					Unk2 = Convert.ToInt16(array15[8]),
					Unk3 = Convert.ToInt16(array15[9]),
					Unk4 = Convert.ToInt16(array15[10]),
					Unk5 = Convert.ToInt16(array15[11]),
					Unk6 = Convert.ToInt16(array15[12]),
					ItemID = array15[13],
					Unk7 = array15[14],
					Unk8 = array15[15],
					Unk9 = array15[16],
					TraceString = this.GetUniqueString()
				};
				if (this.IGC_CashItemInfo_Indexes.Contains(item6.Index1.ToString() + ',' + item6.Index7.ToString()) && !list4.Contains(item6.Index1 + "$" + item6.Index7))
				{
					list4.Add(item6.Index1 + "$" + item6.Index7);
					this.Products.Add(item6);
					if (item6.Index7 > this.ProductMaxIndex7)
					{
						this.ProductMaxIndex7 = item6.Index7;
					}
					if (item6.Index1 > this.ProductMaxIndex1)
					{
						this.ProductMaxIndex1 = item6.Index1;
					}
				}
			}
		}

		// Token: 0x0600039E RID: 926 RVA: 0x000169E0 File Offset: 0x00014BE0
		private void RemoveAddedHeadCat()
		{
			List<string> list = new List<string>();
			foreach (object obj in this.panel_MainForm.Controls)
			{
				Control control = (Control)obj;
				if (control.Name.Contains("pnl_Cat_"))
				{
					list.Add(control.Name);
				}
			}
			foreach (string key in list)
			{
				this.panel_MainForm.Controls.RemoveByKey(key);
			}
			this.CatCount = 0;
		}

		// Token: 0x0600039F RID: 927 RVA: 0x00016AB0 File Offset: 0x00014CB0
		public void RemoveAddedItems()
		{
			List<string> list = new List<string>();
			foreach (object obj in this.panel_ItemsPage1.Controls)
			{
				Control control = (Control)obj;
				if (control.Name != "panel_Item")
				{
					list.Add(control.Name);
				}
			}
			foreach (string key in list)
			{
				this.panel_ItemsPage1.Controls.RemoveByKey(key);
			}
		}

		// Token: 0x060003A0 RID: 928 RVA: 0x00016B78 File Offset: 0x00014D78
		private void RemoveAddedSubs()
		{
			List<string> list = new List<string>();
			foreach (object obj in this.panel_MainForm.Controls)
			{
				Control control = (Control)obj;
				if (control.Name.Contains("pnl_SubCat") || control.Name.Contains("txtb_Cat_"))
				{
					list.Add(control.Name);
				}
			}
			foreach (string key in list)
			{
				this.panel_MainForm.Controls.RemoveByKey(key);
			}
			this.SubCatCount = 0;
		}

		// Token: 0x060003A1 RID: 929 RVA: 0x00016C58 File Offset: 0x00014E58
		private void RemoveItemPack(string ValueToSearch)
		{
			string[] array = ValueToSearch.Split(new char[]
			{
				'@'
			});
			short num = Convert.ToInt16(array[0]);
			short num2 = Convert.ToInt16(array[1]);
			short num3 = Convert.ToInt16(array[2]);
			List<Structures.IBSPackage> list = new List<Structures.IBSPackage>();
			List<Structures.IGCCashItemList> list2 = new List<Structures.IGCCashItemList>();
			foreach (Structures.IBSPackage item in this.Packages)
			{
				if (num == item.CatIndex && num2 == item.Seq && item.Index == num3)
				{
					list.Add(item);
					using (IEnumerator<Structures.IGCCashItemList> enumerator2 = this.ItemsList.GetEnumerator())
					{
						while (enumerator2.MoveNext())
						{
							Structures.IGCCashItemList item2 = enumerator2.Current;
							if (item2.iCat == (int)num && item2.Index == (int)item.Index)
							{
								list2.Add(item2);
								if (item2.TraceString != null && item2.pID > 0)
								{
									List<Structures.IGCCashItemPackages> list3 = new List<Structures.IGCCashItemPackages>();
									foreach (Structures.IGCCashItemPackages item3 in this.ItemsPackage)
									{
										if (item3.pID == item2.pID)
										{
											list3.Add(item3);
										}
									}
									for (int i = 0; i < list3.Count; i++)
									{
										this.ItemsPackage.Remove(list3[i]);
									}
								}
							}
						}
						break;
					}
				}
			}
			for (int j = 0; j < list2.Count; j++)
			{
				this.ItemsList.Remove(list2[j]);
			}
			for (int k = 0; k < list.Count; k++)
			{
				this.Packages.Remove(list[k]);
			}
		}

		// Token: 0x060003A2 RID: 930 RVA: 0x00016E9C File Offset: 0x0001509C
		private void serverToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string text = "Saved Data\\CashShop Editor\\Server Files\\" + DateTime.Now.ToLocalTime().ToString().Replace('/', '.').Replace(':', '-').Replace(" ", " [") + "]";
			Directory.CreateDirectory(text);
			if (this.GenerateServerFiles(text) && MessageBox.Show("Files saved successfully in\n\"" + text + "\"\n\nOpen containing folder?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
			{
				Process.Start(text);
			}
		}

		// Token: 0x060003A3 RID: 931 RVA: 0x00016F2C File Offset: 0x0001512C
		public void UpdateSelectedItem(Structures.CustomPictureBox pnl)
		{
			foreach (string text in this.AddedItems)
			{
				if (text == pnl.Name)
				{
					string[] array = text.Split(new char[]
					{
						'_'
					})[3].Split(new char[]
					{
						'@'
					});
					string b = string.Empty;
					string b2 = array[0];
					string text2 = array[1];
					b = array[2];
					this.Selected_iInfo = new BindingList<Structures.IGCCashItemInfo>();
					this.Selected_iPack = new BindingList<Structures.IGCCashItemPackages>();
					this.Selected_iList = new BindingList<Structures.IGCCashItemList>();
					this.Selected_iPackage = default(Structures.IBSPackage);
					this.Selected_iProduct = new BindingList<Structures.IBSProduct>();
					bool flag = false;
					foreach (Structures.IGCCashItemList item in this.ItemsList)
					{
						int index = item.Index;
						bool flag2 = index.ToString() == b;
						int iCat = item.iCat;
						if (flag2 & iCat.ToString() == b2)
						{
							this.Selected_iList.Add(item);
							flag = true;
						}
					}
					if (flag)
					{
						if (this.Selected_iList[0].pID > 0)
						{
							foreach (Structures.IGCCashItemPackages item2 in this.ItemsPackage)
							{
								if (item2.pID == this.Selected_iList[0].pID)
								{
									this.Selected_iPack.Add(item2);
								}
							}
						}
						foreach (Structures.IGCCashItemInfo item3 in this.ItemsInfo)
						{
							if (item3.GID == this.Selected_iList[0].iInfoGD)
							{
								this.Selected_iInfo.Add(item3);
							}
						}
						foreach (Structures.IBSProduct item4 in this.Products)
						{
							if (this.Selected_iList[0].iInfoGD == item4.Index1)
							{
								this.Selected_iProduct.Add(item4);
							}
						}
						foreach (Structures.IBSPackage selected_iPackage in this.Packages)
						{
							if ((int)selected_iPackage.Index == this.Selected_iList[0].Index)
							{
								this.Selected_iPackage = selected_iPackage;
								break;
							}
						}
						((Form_CashShop_AddItems)Application.OpenForms["Form_CashShop_AddItems"]).UpdateAddedItem();
						if (this.LastSelectedPB != null)
						{
							this.LastSelectedPB.BorderColor = Color.Transparent;
							this.LastSelectedPB.BorderStyle = BorderStyle.None;
						}
						pnl.BorderStyle = BorderStyle.FixedSingle;
						pnl.BorderColor = Color.Gold;
						this.LastSelectedPB = pnl;
						break;
					}
					break;
				}
			}
		}

		// Token: 0x0400009B RID: 155
		public List<string> AddedCatName = new List<string>();

		// Token: 0x0400009C RID: 156
		public List<string> AddedItems = new List<string>();

		// Token: 0x0400009D RID: 157
		public List<string> AddedSubCatName = new List<string>();

		// Token: 0x040000A1 RID: 161
		public short CatCount;

		// Token: 0x040000B0 RID: 176
		public int currPage = 1;

		// Token: 0x040000B3 RID: 179
		public Form form_ItemsAdd;

		// Token: 0x040000BA RID: 186
		public List<Structures.IBSCategory> HeadCategories = new List<Structures.IBSCategory>();

		// Token: 0x040000BC RID: 188
		public List<string> IGC_CashItemInfo_Indexes = new List<string>();

		// Token: 0x040000BD RID: 189
		public List<string> IGC_CashItemList_Indexes = new List<string>();

		// Token: 0x040000BE RID: 190
		public List<string> IGC_CashItemPackages_Indexes = new List<string>();

		// Token: 0x040000BF RID: 191
		public int isEx700ItemList = 1;

		// Token: 0x040000C0 RID: 192
		public int isFirstHeadCat;

		// Token: 0x040000C1 RID: 193
		public int isFirstSubCat;

		// Token: 0x040000C2 RID: 194
		public bool isParentClosing;

		// Token: 0x040000C3 RID: 195
		public int ItemPageCount;

		// Token: 0x040000C4 RID: 196
		public BindingList<Structures.IGCCashItemInfo> ItemsInfo = new BindingList<Structures.IGCCashItemInfo>();

		// Token: 0x040000C5 RID: 197
		public BindingList<Structures.IGCCashItemList> ItemsList = new BindingList<Structures.IGCCashItemList>();

		// Token: 0x040000C6 RID: 198
		public BindingList<Structures.IGCCashItemPackages> ItemsPackage = new BindingList<Structures.IGCCashItemPackages>();

		// Token: 0x040000C7 RID: 199
		public object[,] ItemsStrct = new object[3, 3];

		// Token: 0x040000C8 RID: 200
		public List<Structures.IBSPackage> ItemsToAdd = new List<Structures.IBSPackage>();

		// Token: 0x040000D5 RID: 213
		public TextBox LastClickedCatTB;

		// Token: 0x040000D6 RID: 214
		public TextBox LastClickedSubCatTB;

		// Token: 0x040000D7 RID: 215
		public int LastSelectedItemIndex;

		// Token: 0x040000D8 RID: 216
		public Structures.CustomPictureBox LastSelectedPB;

		// Token: 0x040000DD RID: 221
		public int MaxCategoryIndex = 10;

		// Token: 0x040000DE RID: 222
		public int MaxHeadCatIndex;

		// Token: 0x040000DF RID: 223
		public int MaxItemListGID;

		// Token: 0x040000E0 RID: 224
		public int MaxPackageID;

		// Token: 0x040000E6 RID: 230
		public int PackageMaxIndex;

		// Token: 0x040000E7 RID: 231
		public List<Structures.IBSPackage> Packages = new List<Structures.IBSPackage>();

		// Token: 0x040000F5 RID: 245
		public int ProductMaxIndex1;

		// Token: 0x040000F6 RID: 246
		public int ProductMaxIndex7;

		// Token: 0x040000F7 RID: 247
		public BindingList<Structures.IBSProduct> Products = new BindingList<Structures.IBSProduct>();

		// Token: 0x040000FB RID: 251
		private Random rand = new Random();

		// Token: 0x040000FE RID: 254
		public BindingList<Structures.IGCCashItemInfo> Selected_iInfo = new BindingList<Structures.IGCCashItemInfo>();

		// Token: 0x040000FF RID: 255
		public BindingList<Structures.IGCCashItemList> Selected_iList = new BindingList<Structures.IGCCashItemList>();

		// Token: 0x04000100 RID: 256
		public BindingList<Structures.IGCCashItemPackages> Selected_iPack = new BindingList<Structures.IGCCashItemPackages>();

		// Token: 0x04000101 RID: 257
		public Structures.IBSPackage Selected_iPackage;

		// Token: 0x04000102 RID: 258
		public BindingList<Structures.IBSProduct> Selected_iProduct = new BindingList<Structures.IBSProduct>();

		// Token: 0x04000103 RID: 259
		public Structures.IBSCategory SelectedHeadCat = default(Structures.IBSCategory);

		// Token: 0x04000104 RID: 260
		private TextBox selectedHeadTB = new TextBox();

		// Token: 0x04000105 RID: 261
		public Structures.IBSCategory SelectedSubCat = default(Structures.IBSCategory);

		// Token: 0x04000106 RID: 262
		private TextBox selectedSubTB = new TextBox();

		// Token: 0x04000108 RID: 264
		public Structures strct = new Structures();

		// Token: 0x04000109 RID: 265
		public short SubCatCount;

		// Token: 0x0400010A RID: 266
		public List<Structures.IBSCategory> SubCategories = new List<Structures.IBSCategory>();

		// Token: 0x0400010C RID: 268
		private ToolTip t1 = new ToolTip();

		// Token: 0x0400010D RID: 269
		private ToolTip t2 = new ToolTip();

		// Token: 0x04000111 RID: 273
		public int TraceNumber;
	}
}
