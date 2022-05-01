using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace MU_ToolKit
{
	// Token: 0x02000026 RID: 38
	public partial class Form1 : Form
	{
		// Token: 0x060004A1 RID: 1185 RVA: 0x000239B0 File Offset: 0x00021BB0
		public Form1()
		{
			this.InitializeComponent();
		}

		// Token: 0x060004A2 RID: 1186 RVA: 0x00023A30 File Offset: 0x00021C30
		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new Form_About().ShowDialog();
		}

		// Token: 0x060004A3 RID: 1187 RVA: 0x00023A40 File Offset: 0x00021C40
		public void AddColumnsToComboBox(ref ComboBox cb)
		{
			cb.Items.Clear();
			foreach (object obj in this.workingDGV.Columns)
			{
				DataGridViewColumn dataGridViewColumn = (DataGridViewColumn)obj;
				cb.Items.Add(dataGridViewColumn.Name);
			}
		}

		// Token: 0x060004A4 RID: 1188 RVA: 0x00023AB8 File Offset: 0x00021CB8
		private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			Form1.SendArgs sendArgs = new Form1.SendArgs();
			sendArgs = (Form1.SendArgs)e.Argument;
			string fileType;
			switch (fileType = sendArgs.fileType)
			{
			case "ItemToolTip":
				this.ItemToolTipEnc(sendArgs.filePath);
				return;
			case "ItemSetType":
				this.ItemSetTypeEnc(sendArgs.filePath);
				return;
			case "ItemSetOption":
				this.ItemSetOptionEnc(sendArgs.filePath);
				return;
			case "ItemAddOption":
				this.ItemAddOptionEnc(sendArgs.filePath);
				return;
			case "ItemToolTipText":
				this.ItemToolTipTextEnc(sendArgs.filePath);
				return;
			case "JewelOfHarmonySmelt":
				this.JewelOfHarmonySmeltEnc(sendArgs.filePath);
				return;
			case "MoveReq":
				this.MoveReqEnc(sendArgs.filePath);
				return;
			case "NpcName":
				this.NpcNameEnc(sendArgs.filePath);
				return;
			case "NpcNameEx700Plus":
				this.NpcNameEx700PlusEnc(sendArgs.filePath);
				return;
			case "Slide":
				this.SlideEnc(sendArgs.filePath);
				return;
			case "Skill_ExS8E1":
				this.Skill_ExS8E1Enc(sendArgs.filePath);
				return;
			case "Skill_S6E3":
				this.Skill_S6E3Enc(sendArgs.filePath);
				return;
			case "Mix":
				this.MixEnc(sendArgs.filePath);
				return;
			case "ItemEx700":
				this.ItemEx700Enc(sendArgs.filePath);
				return;
			case "Item_S6E3":
				this.Item_S6E3Enc(sendArgs.filePath);
				return;
			case "ItemEx700Plus":
				this.ItemEx700PlusEnc(sendArgs.filePath);
				return;
			case "ItemSeason8Episode1":
				this.ItemSeason8Episode1Enc(sendArgs.filePath);
				return;
			case "ServerListEx700":
				this.ServerListEx700Enc(sendArgs.filePath);
				return;
			case "ServerListS6E3":
				this.ServerListS6E3Enc(sendArgs.filePath);
				return;
			case "Monster":
				this.MonsterEnc(sendArgs.filePath);
				return;
			case "Glow":
				this.GlowEnc(sendArgs.filePath);
				return;
			case "Text":
				this.TEXTEnc(sendArgs.filePath);
				return;
			case "Filter":
				this.FilterEnc(sendArgs.filePath);
				return;
			case "FilterName":
				this.FilterNameEnc(sendArgs.filePath);
				return;
			case "Minimap":
				this.MinimapEnc(sendArgs.filePath);
				return;
			case "Gate":
				this.GateEnc(sendArgs.filePath);
				break;

				return;
			}
		}

		// Token: 0x060004A5 RID: 1189 RVA: 0x00023E1B File Offset: 0x0002201B
		private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			this.toolStripProgressBar_Save.Increment(1);
			this.toolStripProgressBar_Save.Invalidate();
		}

		// Token: 0x060004A6 RID: 1190 RVA: 0x00023E34 File Offset: 0x00022034
		private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this.toolStripProgressBar_Save.Visible = false;
		}

		// Token: 0x060004A7 RID: 1191 RVA: 0x00023E6C File Offset: 0x0002206C
		private byte[] CalcCRC(byte[] Buffer, uint MagicNum, uint SkipStartLength)
		{
			uint num = MagicNum * 512u;
			uint[] array = new uint[]
			{
				uint.MaxValue,
				2147483647u,
				1073741823u,
				536870911u,
				268435455u,
				134217727u,
				67108863u,
				33554431u,
				16777215u
			};
			if (SkipStartLength > 0u)
			{
				byte[] array2 = new byte[(long)Buffer.Length - (long)((ulong)SkipStartLength)];
				Array.Copy(Buffer, (long)((ulong)SkipStartLength), array2, 0L, (long)array2.Length);
				Buffer = array2;
			}
			for (int i = 0; i <= Buffer.Length - 8; i += 4)
			{
				uint tempBuffer = this.GetTempBuffer(Buffer, i, 4);
				if (((long)(i / 4) + (long)((ulong)MagicNum)) % 2L == 1L)
				{
					num += tempBuffer;
				}
				else
				{
					num ^= tempBuffer;
				}
				if (i % 16 == 0)
				{
					num ^= (MagicNum + num >> i / 4 % 8 + 1 & array[i / 4 % 8 + 1]);
				}
			}
			List<byte> list = new List<byte>();
			for (uint num2 = 0u; num2 < 4u; num2 += 1u)
			{
				byte item = this.CalcModulo(num);
				list.Add(item);
				num >>= 8;
			}
			return list.ToArray();
		}

		// Token: 0x060004A8 RID: 1192 RVA: 0x00023F4C File Offset: 0x0002214C
		private byte CalcModulo(uint val)
		{
			uint num = val % 256u;
			if (num < 0u)
			{
				num += 256u;
			}
			return Convert.ToByte(num);
		}

		// Token: 0x060004A9 RID: 1193 RVA: 0x00023F73 File Offset: 0x00022173
		private void computeIGCCRCToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new FormCRC().Show();
		}

		// Token: 0x060004AA RID: 1194 RVA: 0x00023F80 File Offset: 0x00022180
		private void CreateItemTabCategories(string FileType)
		{
			this.tc_Items = new TabControl();
			this.panel1.SizeChanged += this.panel1_SizeChanged;
			this.tc_Items.SelectedIndexChanged += this.tc_Items_SelectedIndexChanged;
			this.tc_Items.Location = new Point(0, 0);
			this.tc_Items.Size = this.panel1.Size;
			this.tc_Items.TabPages.Add(FileType + "_group_0", "Swords");
			this.tc_Items.TabPages.Add(FileType + "_group_1", "Axes");
			this.tc_Items.TabPages.Add(FileType + "_group_2", "Maces/Scapters");
			this.tc_Items.TabPages.Add(FileType + "_group_3", "Spears");
			this.tc_Items.TabPages.Add(FileType + "_group_4", "Bows/Crosswobs");
			this.tc_Items.TabPages.Add(FileType + "_group_5", "Staffs/Sticks");
			this.tc_Items.TabPages.Add(FileType + "_group_6", "Shields");
			this.tc_Items.TabPages.Add(FileType + "_group_7", "Helms");
			this.tc_Items.TabPages.Add(FileType + "_group_8", "Armors");
			this.tc_Items.TabPages.Add(FileType + "_group_9", "Pants");
			this.tc_Items.TabPages.Add(FileType + "_group_10", "Gloves");
			this.tc_Items.TabPages.Add(FileType + "_group_11", "Boots");
			this.tc_Items.TabPages.Add(FileType + "_group_12", "Wings/Other");
			this.tc_Items.TabPages.Add(FileType + "_group_13", "Misc 1");
			this.tc_Items.TabPages.Add(FileType + "_group_14", "Misc 2");
			this.tc_Items.TabPages.Add(FileType + "_group_15", "Scrolls");
			this.panel1.Controls.Add(this.tc_Items);
		}

		// Token: 0x060004AB RID: 1195 RVA: 0x00024204 File Offset: 0x00022404
		private void cSToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new CashShopEditor().Show();
		}

		// Token: 0x060004AC RID: 1196 RVA: 0x00024214 File Offset: 0x00022414
		private void DecBlock(ref byte[] Buffer, int size)
		{
			byte[] array = new byte[]
			{
				252,
				207,
				171
			};
			for (int i = 0; i < size; i++)
			{
				Buffer[i] ^= array[i % 3];
			}
		}

		// Token: 0x060004AD RID: 1197 RVA: 0x00024350 File Offset: 0x00022550
		private void DecIGCBlock(ref byte[] Buffer)
		{
			byte[] array = new byte[]
			{
				13,
				217,
				70,
				112,
				209,
				160,
				74,
				56,
				23,
				212,
				132,
				211,
				184,
				65,
				8,
				97,
				170,
				85,
				87,
				33,
				148,
				46,
				13,
				122,
				144,
				249,
				116,
				241,
				122,
				162,
				97,
				214,
				170,
				19,
				101,
				200,
				220,
				19,
				242,
				171,
				152,
				246,
				121,
				219,
				109,
				59,
				20,
				41,
				73,
				67,
				13,
				49,
				213,
				20,
				98,
				54,
				138,
				125,
				205,
				118,
				198,
				39,
				71,
				246,
				170,
				86,
				246,
				107,
				251,
				250,
				196,
				206,
				189,
				206,
				85,
				149,
				214,
				200,
				35,
				176,
				91,
				193,
				9,
				26,
				157,
				232,
				144,
				189,
				80,
				10,
				124,
				178,
				233,
				171,
				168,
				30,
				191,
				229,
				75,
				142,
				212,
				188,
				24,
				144,
				184,
				123,
				49,
				33,
				123,
				145,
				170,
				107,
				216,
				58,
				55,
				172,
				130,
				124,
				128,
				207,
				63,
				26,
				125,
				228,
				119,
				122,
				104,
				53,
				184,
				167,
				209,
				189,
				148,
				203,
				32,
				5,
				61,
				107,
				164,
				105,
				232,
				242,
				160,
				27,
				126,
				206,
				164,
				163,
				byte.MaxValue,
				15,
				90,
				158,
				81,
				113,
				67,
				189,
				15,
				140,
				53,
				103,
				186,
				182,
				178,
				167,
				27,
				138,
				138,
				155,
				170,
				203,
				225,
				114,
				192,
				110,
				150,
				202,
				82,
				69,
				229,
				34,
				196,
				241,
				90,
				116,
				248,
				67,
				11,
				13,
				185,
				0,
				27,
				66,
				240,
				205,
				209,
				86,
				67,
				25,
				118,
				48,
				35,
				168,
				92,
				35,
				90,
				250,
				248,
				154,
				235,
				160,
				224,
				117,
				17,
				202,
				82,
				40,
				229,
				246,
				249,
				222,
				130,
				153,
				149,
				101,
				10,
				200,
				117,
				251,
				101,
				177,
				101,
				6,
				254,
				6,
				94,
				177,
				8,
				73,
				239,
				15,
				165,
				147,
				126,
				199,
				131,
				198,
				192,
				78,
				99,
				111,
				0,
				44,
				97,
				169,
				229,
				137
			};
			for (int i = 0; i < Buffer.Length; i++)
			{
				Buffer[i] ^= array[i % 256];
			}
		}

		// Token: 0x060004AE RID: 1198 RVA: 0x00024398 File Offset: 0x00022598
		private void dgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
		{
			this.isNewRow = true;
			DataGridView dataGridView = (DataGridView)sender;
			for (int i = 0; i < dataGridView.ColumnCount; i++)
			{
				dataGridView[i, e.RowIndex].Value = 0;
			}
			this.isNewRow = false;
		}

		// Token: 0x060004AF RID: 1199 RVA: 0x000243E4 File Offset: 0x000225E4
		private void dgvPasteEvent_KeyDown(object sender, KeyEventArgs e)
		{
			DataGridView dataGridView = (DataGridView)sender;
			if (e.Control && e.KeyCode == Keys.F)
			{
				this.toolStripButton_Search.PerformClick();
				return;
			}
			if (e.Control && e.KeyCode == Keys.C)
			{
				string text = Convert.ToString(dataGridView.GetClipboardContent().GetText());
				if (text.Length > 0)
				{
					Clipboard.SetText(text);
					e.Handled = true;
					return;
				}
			}
			else if (e.Control && e.KeyCode == Keys.V)
			{
				this.isPasteFromCP = true;
				string[] array = Clipboard.GetText().Replace('\r', ' ').Trim().Split(new char[]
				{
					'\n'
				});
				int num = dataGridView.CurrentCell.RowIndex;
				int num2 = array.Length;
				int num3 = dataGridView.CurrentCell.ColumnIndex;
				int num4 = array[0].Split(new char[]
				{
					'\t'
				}).Length;
				int cellCount = dataGridView.GetCellCount(DataGridViewElementStates.Selected);
				List<int> list = new List<int>();
				List<int> list2 = new List<int>();
				for (int i = 0; i < cellCount; i++)
				{
					int item = dataGridView.SelectedCells[i].RowIndex;
					if (!list.Contains(item))
					{
						list.Add(item);
					}
					item = dataGridView.SelectedCells[i].ColumnIndex;
					if (!list2.Contains(item))
					{
						list2.Add(item);
					}
				}
				if (dataGridView.SelectedRows.Count == 0)
				{
					list.Reverse();
					list2.Reverse();
				}
				int num5 = 0;
				if (dataGridView.Columns[0].ReadOnly & dataGridView.Columns[list2[list2.Count - 1]].Name == "Group")
				{
					List<int> list3;
					(list3 = list2)[0] = list3[0] + 1;
					num5 = 0;
				}
				if (dataGridView.AllowUserToAddRows & dataGridView.Rows.Count - 1 == dataGridView.SelectedCells[0].RowIndex)
				{
					for (int j = 0; j < num2; j++)
					{
						dataGridView.Rows.Add();
					}
				}
				for (int k = 0; k < num2; k++)
				{
					List<string> list4 = array[k].Split(new char[]
					{
						'\t'
					}).ToList<string>();
					if (list4[0] == "")
					{
						list4.Remove(list4[0]);
					}
					string[] array2 = list4.ToArray();
					num4 = array2.Length;
					num3 = dataGridView.CurrentCell.ColumnIndex;
					int l = 0;
					while (l < num4)
					{
						this.PasteValue = array2[l];
						try
						{
							dataGridView[list2[0] + l, list[0] + k].Value = array2[l + num5];
						}
						catch
						{
							goto IL_2C6;
						}
						goto IL_2C0;
						IL_2C6:
						l++;
						continue;
						IL_2C0:
						num3++;
						goto IL_2C6;
					}
					num++;
				}
				this.isPasteFromCP = false;
			}
		}

		// Token: 0x060004B1 RID: 1201 RVA: 0x00024710 File Offset: 0x00022910
		private void DisposeGrid(TabPage tp)
		{
			if (tp.Controls.Count != 0)
			{
				try
				{
					tp.Controls[0].Dispose();
				}
				catch
				{
					this.DisposeGrid(tp);
				}
			}
		}

		// Token: 0x060004B2 RID: 1202 RVA: 0x0002475C File Offset: 0x0002295C
		private void EncBlock(ref byte[] Buffer, int size)
		{
			byte[] array = new byte[]
			{
				252,
				207,
				171
			};
			for (int i = 0; i < size; i++)
			{
				Buffer[i] ^= array[i % 3];
			}
		}

		// Token: 0x060004B3 RID: 1203 RVA: 0x0002479C File Offset: 0x0002299C
		private void EncBlock(ref byte[] Buffer, int size, int offset)
		{
			byte[] array = new byte[]
			{
				252,
				207,
				171
			};
			for (int i = offset; i < size; i++)
			{
				Buffer[i] ^= array[i % 3];
			}
		}

		// Token: 0x060004B4 RID: 1204 RVA: 0x000248D8 File Offset: 0x00022AD8
		private void EncIGCBlock(ref byte[] bArray)
		{
			byte[] array = new byte[]
			{
				13,
				217,
				70,
				112,
				209,
				160,
				74,
				56,
				23,
				212,
				132,
				211,
				184,
				65,
				8,
				97,
				170,
				85,
				87,
				33,
				148,
				46,
				13,
				122,
				144,
				249,
				116,
				241,
				122,
				162,
				97,
				214,
				170,
				19,
				101,
				200,
				220,
				19,
				242,
				171,
				152,
				246,
				121,
				219,
				109,
				59,
				20,
				41,
				73,
				67,
				13,
				49,
				213,
				20,
				98,
				54,
				138,
				125,
				205,
				118,
				198,
				39,
				71,
				246,
				170,
				86,
				246,
				107,
				251,
				250,
				196,
				206,
				189,
				206,
				85,
				149,
				214,
				200,
				35,
				176,
				91,
				193,
				9,
				26,
				157,
				232,
				144,
				189,
				80,
				10,
				124,
				178,
				233,
				171,
				168,
				30,
				191,
				229,
				75,
				142,
				212,
				188,
				24,
				144,
				184,
				123,
				49,
				33,
				123,
				145,
				170,
				107,
				216,
				58,
				55,
				172,
				130,
				124,
				128,
				207,
				63,
				26,
				125,
				228,
				119,
				122,
				104,
				53,
				184,
				167,
				209,
				189,
				148,
				203,
				32,
				5,
				61,
				107,
				164,
				105,
				232,
				242,
				160,
				27,
				126,
				206,
				164,
				163,
				byte.MaxValue,
				15,
				90,
				158,
				81,
				113,
				67,
				189,
				15,
				140,
				53,
				103,
				186,
				182,
				178,
				167,
				27,
				138,
				138,
				155,
				170,
				203,
				225,
				114,
				192,
				110,
				150,
				202,
				82,
				69,
				229,
				34,
				196,
				241,
				90,
				116,
				248,
				67,
				11,
				13,
				185,
				0,
				27,
				66,
				240,
				205,
				209,
				86,
				67,
				25,
				118,
				48,
				35,
				168,
				92,
				35,
				90,
				250,
				248,
				154,
				235,
				160,
				224,
				117,
				17,
				202,
				82,
				40,
				229,
				246,
				249,
				222,
				130,
				153,
				149,
				101,
				10,
				200,
				117,
				251,
				101,
				177,
				101,
				6,
				254,
				6,
				94,
				177,
				8,
				73,
				239,
				15,
				165,
				147,
				126,
				199,
				131,
				198,
				192,
				78,
				99,
				111,
				0,
				44,
				97,
				169,
				229,
				137
			};
			for (int i = 0; i < bArray.Length; i++)
			{
				bArray[i] ^= array[i % 256];
			}
		}

		// Token: 0x060004B5 RID: 1205 RVA: 0x0002491D File Offset: 0x00022B1D
		private void eventBagToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new EventBagEditor().Show();
		}

		// Token: 0x060004B6 RID: 1206 RVA: 0x0002492C File Offset: 0x00022B2C
		private void ex700ItemList_ToolStripMenuItem_ON_Click(object sender, EventArgs e)
		{
			this.isEx700ItemList = true;
			this.ex700ItemList_ToolStripMenuItem_ON.Font = new Font(this.ex700ItemList_ToolStripMenuItem_ON.Font, FontStyle.Bold);
			this.s6e3ItemList_ToolStripMenuItem_ON.Font = new Font(this.s6e3ItemList_ToolStripMenuItem_ON.Font, FontStyle.Regular);
		}

		// Token: 0x060004B7 RID: 1207 RVA: 0x00024978 File Offset: 0x00022B78
		private void Filter_Save()
		{
			Form1.SendArgs sendArgs = new Form1.SendArgs();
			SaveFileDialog saveFileDialog = new SaveFileDialog
			{
				AddExtension = true,
				Title = "Select a location to save the Filter.bmd File",
				Filter = "BMD files (*.bmd)|*.bmd|All files (*.*)|*.*"
			};
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.toolStripProgressBar_Save.Visible = true;
				this.toolStripProgressBar_Save.Value = 0;
				this.toolStripProgressBar_Save.Size = new Size(base.Width - 460, 22);
				this.toolStripProgressBar_Save.Maximum = this.workingDGV.Rows.Count;
				sendArgs.filePath = saveFileDialog.FileName;
				sendArgs.fileType = "Filter";
				this.backgroundWorker.RunWorkerAsync(sendArgs);
			}
		}

		// Token: 0x060004B8 RID: 1208 RVA: 0x00024A30 File Offset: 0x00022C30
		private void Filterbw_DoWork(object sender, DoWorkEventArgs e)
		{
			Form1.SendArgs sendArgs = (Form1.SendArgs)e.Argument;
			this.Filterdgv = this.FilterDec(sendArgs.filePath);
		}

		// Token: 0x060004B9 RID: 1209 RVA: 0x00024A5C File Offset: 0x00022C5C
		private void Filterbw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this.toolStripButton_AddRow.Enabled = false;
			this.toolStripButton_RemoveSelectedRow.Enabled = false;
			this.panel1.Controls.Add(this.Filterdgv);
			this.progressBar_Loading.Visible = false;
			this.Filterdgv.Disposed += this.Filterdgv_Disposed;
			this.Filterdgv.KeyDown += this.dgvPasteEvent_KeyDown;
			this.Filterdgv.CellValueChanged += this.Filterdgv_CellValueChanged;
			this.workingDGV = this.Filterdgv;
			this.workingDGV.RowsAdded += this.dgv_RowsAdded;
		}

		// Token: 0x060004BA RID: 1210 RVA: 0x00024B0C File Offset: 0x00022D0C
		private DataGridView FilterDec(string filePath)
		{
			DataGridView dataGridView = new DataGridView();
			try
			{
				this.initializeFilterGrid(dataGridView);
				FileStream fileStream = new FileStream(filePath, FileMode.Open);
				byte[] array = new byte[fileStream.Length];
				fileStream.Read(array, 0, array.Length);
				fileStream.Close();
				this.endBytes = new byte[4];
				Array.Copy(array, array.Length - 4, this.endBytes, 0, this.endBytes.Length);
				this.sBlockSize = 20;
				this.sSize = (array.Length - 4) / this.sBlockSize;
				for (int i = 0; i < this.sSize; i++)
				{
					byte[] array2 = new byte[this.sBlockSize];
					Array.Copy(array, i * this.sBlockSize, array2, 0, this.sBlockSize);
					this.DecBlock(ref array2, array2.Length);
					dataGridView.Rows.Add();
					dataGridView[0, i].Value = Encoding.GetEncoding("GB2312").GetString(array2).Replace("\0", string.Empty);
				}
			}
			catch (Exception ex)
			{
				dataGridView = new DataGridView();
				MessageBox.Show("The selected file failed to decrypt. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			return dataGridView;
		}

		// Token: 0x060004BB RID: 1211 RVA: 0x00024C44 File Offset: 0x00022E44
		private void Filterdgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			DataGridView dataGridView = (DataGridView)sender;
			if (dataGridView.EditingControl != null)
			{
				if (dataGridView.EditingControl.Text.Length > 20)
				{
					MessageBox.Show("Maximum 20 Chars allowed.", "Eroor", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					dataGridView.EditingControl.Text = dataGridView.EditingControl.Text.Remove(20);
					dataGridView[e.ColumnIndex, e.RowIndex].Value = dataGridView.EditingControl.Text;
				}
			}
			else if (this.isPasteFromCP && this.PasteValue.Length > 20)
			{
				dataGridView[e.ColumnIndex, e.RowIndex].Value = this.PasteValue.Remove(20);
			}
			this.Filterdgv[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.PaleGreen;
		}

		// Token: 0x060004BC RID: 1212 RVA: 0x00024D2C File Offset: 0x00022F2C
		private void Filterdgv_Disposed(object sender, EventArgs e)
		{
			this.toolStripButton_Save.Enabled = false;
			if (Application.OpenForms["Form_Search"] != null)
			{
				Application.OpenForms["Form_Search"].Close();
			}
		}

		// Token: 0x060004BD RID: 1213 RVA: 0x00024D60 File Offset: 0x00022F60
		private void FilterEnc(string filePath)
		{
			List<byte> list = new List<byte>();
			foreach (object obj in ((IEnumerable)this.workingDGV.Rows))
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
				byte[] array = new byte[this.sBlockSize];
				string s = string.Empty;
				if (dataGridViewRow.Cells[0].Value != null)
				{
					s = dataGridViewRow.Cells[0].Value.ToString();
				}
				byte[] bytes = Encoding.GetEncoding("GB2312").GetBytes(s);
				Array.Copy(bytes, 0, array, 0, bytes.Length);
				this.EncBlock(ref array, array.Length);
				for (int i = 0; i < array.Length; i++)
				{
					list.Add(array[i]);
				}
				this.backgroundWorker.ReportProgress(this.workingDGV.Rows.IndexOf(dataGridViewRow));
			}
			for (int j = 0; j < this.endBytes.Length; j++)
			{
				list.Add(this.endBytes[j]);
			}
			this.newFile = new byte[0];
			byte[] sourceArray = this.CalcCRC(list.ToArray(), 15997u, 0u);
			this.newFile = list.ToArray();
			Array.Copy(sourceArray, 0, this.newFile, this.newFile.Length - 4, 4);
			File.WriteAllBytes(filePath, this.newFile);
		}

		// Token: 0x060004BE RID: 1214 RVA: 0x00024EE0 File Offset: 0x000230E0
		private void FilterName_Save()
		{
			Form1.SendArgs sendArgs = new Form1.SendArgs();
			SaveFileDialog saveFileDialog = new SaveFileDialog
			{
				AddExtension = true,
				Title = "Select a location to save the FilterName.bmd File",
				Filter = "BMD files (*.bmd)|*.bmd|All files (*.*)|*.*"
			};
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.toolStripProgressBar_Save.Visible = true;
				this.toolStripProgressBar_Save.Value = 0;
				this.toolStripProgressBar_Save.Size = new Size(base.Width - 460, 22);
				this.toolStripProgressBar_Save.Maximum = this.workingDGV.Rows.Count;
				sendArgs.filePath = saveFileDialog.FileName;
				sendArgs.fileType = "FilterName";
				this.backgroundWorker.RunWorkerAsync(sendArgs);
			}
		}

		// Token: 0x060004BF RID: 1215 RVA: 0x00024F98 File Offset: 0x00023198
		private void FilterNamebw_DoWork(object sender, DoWorkEventArgs e)
		{
			Form1.SendArgs sendArgs = (Form1.SendArgs)e.Argument;
			this.FilterNamedgv = this.FilterNameDec(sendArgs.filePath);
		}

		// Token: 0x060004C0 RID: 1216 RVA: 0x00024FC4 File Offset: 0x000231C4
		private void FilterNamebw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this.toolStripButton_AddRow.Enabled = false;
			this.toolStripButton_RemoveSelectedRow.Enabled = false;
			this.panel1.Controls.Add(this.FilterNamedgv);
			this.progressBar_Loading.Visible = false;
			this.FilterNamedgv.Disposed += this.FilterNamedgv_Disposed;
			this.FilterNamedgv.KeyDown += this.dgvPasteEvent_KeyDown;
			this.FilterNamedgv.CellValueChanged += this.FilterNamedgv_CellValueChanged;
			this.workingDGV = this.FilterNamedgv;
			this.workingDGV.RowsAdded += this.dgv_RowsAdded;
		}

		// Token: 0x060004C1 RID: 1217 RVA: 0x00025074 File Offset: 0x00023274
		private DataGridView FilterNameDec(string filePath)
		{
			DataGridView dataGridView = new DataGridView();
			try
			{
				this.initializeFilterNameGrid(dataGridView);
				FileStream fileStream = new FileStream(filePath, FileMode.Open);
				byte[] array = new byte[fileStream.Length];
				fileStream.Read(array, 0, array.Length);
				fileStream.Close();
				this.endBytes = new byte[4];
				Array.Copy(array, array.Length - 4, this.endBytes, 0, this.endBytes.Length);
				this.sBlockSize = 20;
				this.sSize = (array.Length - 4) / this.sBlockSize;
				for (int i = 0; i < this.sSize; i++)
				{
					byte[] array2 = new byte[this.sBlockSize];
					Array.Copy(array, i * this.sBlockSize, array2, 0, this.sBlockSize);
					this.DecBlock(ref array2, array2.Length);
					dataGridView.Rows.Add();
					dataGridView[0, i].Value = Encoding.GetEncoding("GB2312").GetString(array2).Replace("\0", string.Empty);
				}
			}
			catch (Exception ex)
			{
				dataGridView = new DataGridView();
				MessageBox.Show("The selected file failed to decrypt. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			return dataGridView;
		}

		// Token: 0x060004C2 RID: 1218 RVA: 0x000251AC File Offset: 0x000233AC
		private void FilterNamedgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			DataGridView dataGridView = (DataGridView)sender;
			if (dataGridView.EditingControl != null)
			{
				if (dataGridView.EditingControl.Text.Length > 20)
				{
					MessageBox.Show("Maximum 20 Chars allowed.", "Eroor", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					dataGridView.EditingControl.Text = dataGridView.EditingControl.Text.Remove(20);
					dataGridView[e.ColumnIndex, e.RowIndex].Value = dataGridView.EditingControl.Text;
				}
			}
			else if (this.isPasteFromCP && this.PasteValue.Length > 20)
			{
				dataGridView[e.ColumnIndex, e.RowIndex].Value = this.PasteValue.Remove(20);
			}
			dataGridView[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.PaleGreen;
		}

		// Token: 0x060004C3 RID: 1219 RVA: 0x0002528F File Offset: 0x0002348F
		private void FilterNamedgv_Disposed(object sender, EventArgs e)
		{
			this.toolStripButton_Save.Enabled = false;
			if (Application.OpenForms["Form_Search"] != null)
			{
				Application.OpenForms["Form_Search"].Close();
			}
		}

		// Token: 0x060004C4 RID: 1220 RVA: 0x000252C4 File Offset: 0x000234C4
		private void FilterNameEnc(string filePath)
		{
			List<byte> list = new List<byte>();
			foreach (object obj in ((IEnumerable)this.workingDGV.Rows))
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
				byte[] array = new byte[this.sBlockSize];
				string s = string.Empty;
				if (dataGridViewRow.Cells[0].Value != null)
				{
					s = dataGridViewRow.Cells[0].Value.ToString();
				}
				byte[] bytes = Encoding.GetEncoding("GB2312").GetBytes(s);
				Array.Copy(bytes, 0, array, 0, bytes.Length);
				this.EncBlock(ref array, array.Length);
				for (int i = 0; i < array.Length; i++)
				{
					list.Add(array[i]);
				}
				this.backgroundWorker.ReportProgress(this.workingDGV.Rows.IndexOf(dataGridViewRow));
			}
			for (int j = 0; j < this.endBytes.Length; j++)
			{
				list.Add(this.endBytes[j]);
			}
			this.newFile = new byte[0];
			byte[] sourceArray = this.CalcCRC(list.ToArray(), 11201u, 0u);
			this.newFile = list.ToArray();
			Array.Copy(sourceArray, 0, this.newFile, this.newFile.Length - 4, 4);
			File.WriteAllBytes(filePath, this.newFile);
		}

		// Token: 0x060004C5 RID: 1221 RVA: 0x00025444 File Offset: 0x00023644
		public void FindNextValue(string ColName, string theVal)
		{
			for (int i = this.workingDGV.CurrentRow.Index + 1; i < this.workingDGV.Rows.Count; i++)
			{
				if (this.workingDGV[ColName, i].Value != null && this.workingDGV[ColName, i].Value.ToString().ToUpper().Contains(theVal.ToUpper()))
				{
					this.workingDGV.CurrentCell = this.workingDGV[ColName, i];
					return;
				}
			}
		}

		// Token: 0x060004C6 RID: 1222 RVA: 0x000254D4 File Offset: 0x000236D4
		public void FindPreviousValue(string ColName, string theVal)
		{
			for (int i = this.workingDGV.CurrentRow.Index - 1; i > -1; i--)
			{
				if (this.workingDGV[ColName, i].Value != null && this.workingDGV[ColName, i].Value.ToString().ToUpper().Contains(theVal.ToUpper()))
				{
					this.workingDGV.CurrentCell = this.workingDGV[ColName, i];
					return;
				}
			}
		}

		// Token: 0x060004C7 RID: 1223 RVA: 0x00025554 File Offset: 0x00023754
		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			string path = "Data\\Config.ini";
			if (File.Exists(path))
			{
				File.Delete(path);
			}
			StreamWriter streamWriter = new StreamWriter(path);
			streamWriter.WriteLine("{0}={1}", "isEx700ItemList", this.isEx700ItemList ? "1" : "0");
			streamWriter.Flush();
			streamWriter.Close();
		}

		// Token: 0x060004C8 RID: 1224 RVA: 0x000255AC File Offset: 0x000237AC
		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			if ((e.Control & e.KeyCode == Keys.F) && this.toolStripButton_Search.Enabled)
			{
				this.toolStripButton_Search.PerformClick();
			}
		}

		// Token: 0x060004C9 RID: 1225 RVA: 0x000255DC File Offset: 0x000237DC
		private void Form1_Load(object sender, EventArgs e)
		{
			try
			{
				this.Text = this.Text + " v" + base.ProductVersion;
				string path = "Data\\Config.ini";
				if (File.Exists(path))
				{
					foreach (string text in File.ReadAllLines(path))
					{
						string[] array2 = text.Split(new char[]
						{
							'='
						});
						array2[0] = array2[0].Trim(new char[]
						{
							' '
						});
						array2[1] = array2[1].Trim(new char[]
						{
							' '
						});
						string a;
						if ((a = array2[0]) != null && a == "isEx700ItemList")
						{
							this.isEx700ItemList = Convert.ToBoolean(Convert.ToUInt16(array2[1]));
							if (this.isEx700ItemList)
							{
								this.ex700ItemList_ToolStripMenuItem_ON.PerformClick();
							}
							else
							{
								this.s6e3ItemList_ToolStripMenuItem_ON.PerformClick();
							}
						}
					}
				}
			}
			catch
			{
				Environment.Exit(0);
			}
		}

		// Token: 0x060004CA RID: 1226 RVA: 0x000256EC File Offset: 0x000238EC
		private void Form1_SizeChanged(object sender, EventArgs e)
		{
			this.panel1.Size = new Size(base.Size.Width - 16, base.Size.Height - 111);
		}

		// Token: 0x060004CB RID: 1227 RVA: 0x0002572C File Offset: 0x0002392C
		private void Gate_DAT_Export()
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog
			{
				Title = "Select a location and file Name for the generated GateSettings.dat",
				FileName = "GateSettings.dat",
				Filter = "DAT files (*.dat)|*.dat|All files (*.*)|*.*"
			};
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName)
				{
					AutoFlush = true
				};
				streamWriter.WriteLine("//Generated by MU.ToolKit coded by TopReal.IT");
				streamWriter.WriteLine("//------------------------------------------------------------------------");
				streamWriter.WriteLine("////\tGate\tFlag\tMap\tX1\tY1\tX2\tY2\tTarget\tDir\tMinLevel");
				streamWriter.WriteLine("//------------------------------------------------------------------------");
				streamWriter.WriteLine();
				foreach (object obj in ((IEnumerable)this.workingDGV.Rows))
				{
					DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
					if (dataGridViewRow.Cells[0].Value != null && dataGridViewRow.Cells[0].Value.ToString() != "0")
					{
						streamWriter.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}", new object[]
						{
							dataGridViewRow.Index,
							dataGridViewRow.Cells[0].Value.ToString(),
							dataGridViewRow.Cells[1].Value.ToString(),
							dataGridViewRow.Cells[2].Value.ToString(),
							dataGridViewRow.Cells[3].Value.ToString(),
							dataGridViewRow.Cells[4].Value.ToString(),
							dataGridViewRow.Cells[5].Value.ToString(),
							dataGridViewRow.Cells[6].Value.ToString(),
							dataGridViewRow.Cells[7].Value.ToString(),
							dataGridViewRow.Cells[9].Value.ToString()
						});
					}
				}
				streamWriter.Close();
				if (MessageBox.Show("File generated succesfully.\nOpen?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
				{
					Process.Start(saveFileDialog.FileName);
				}
			}
		}

		// Token: 0x060004CC RID: 1228 RVA: 0x00025990 File Offset: 0x00023B90
		private void Gate_Save()
		{
			Form1.SendArgs sendArgs = new Form1.SendArgs();
			SaveFileDialog saveFileDialog = new SaveFileDialog
			{
				AddExtension = true,
				Title = "Select a location to save the Gate.bmd File",
				Filter = "BMD files (*.bmd)|*.bmd|All files (*.*)|*.*"
			};
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.newFile = new byte[this.sSize * this.sBlockSize];
				this.toolStripProgressBar_Save.Visible = true;
				this.toolStripProgressBar_Save.Value = 0;
				this.toolStripProgressBar_Save.Size = new Size(base.Width - 460, 22);
				this.toolStripProgressBar_Save.Maximum = this.workingDGV.Rows.Count;
				sendArgs.filePath = saveFileDialog.FileName;
				sendArgs.fileType = "Gate";
				this.backgroundWorker.RunWorkerAsync(sendArgs);
			}
		}

		// Token: 0x060004CD RID: 1229 RVA: 0x00025A60 File Offset: 0x00023C60
		private void Gatebw_DoWork(object sender, DoWorkEventArgs e)
		{
			Form1.SendArgs sendArgs = (Form1.SendArgs)e.Argument;
			this.Gatedgv = this.GateDec(sendArgs.filePath);
		}

		// Token: 0x060004CE RID: 1230 RVA: 0x00025A8C File Offset: 0x00023C8C
		private void Gatebw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this.toolStripButton_AddRow.Enabled = true;
			this.toolStripButton_RemoveSelectedRow.Enabled = true;
			this.panel1.Controls.Add(this.Gatedgv);
			this.progressBar_Loading.Visible = false;
			this.Gatedgv.CellValueChanged += this.Gatedgv_CellValueChanged;
			this.Gatedgv.Disposed += this.Gatedgv_Disposed;
			this.Gatedgv.KeyDown += this.dgvPasteEvent_KeyDown;
			this.workingDGV = this.Gatedgv;
			this.workingDGV.RowsAdded += this.dgv_RowsAdded;
		}

		// Token: 0x060004CF RID: 1231 RVA: 0x00025B3C File Offset: 0x00023D3C
		private DataGridView GateDec(string filePath)
		{
			DataGridView dataGridView = new DataGridView();
			this.initializeGateGrid(dataGridView);
			try
			{
				FileStream fileStream = new FileStream(filePath, FileMode.Open);
				this.sBlockSize = 14;
				byte[] array = new byte[fileStream.Length];
				this.sSize = (int)fileStream.Length / this.sBlockSize;
				fileStream.Read(array, 0, array.Length);
				fileStream.Close();
				for (int i = 0; i < this.sSize; i++)
				{
					byte[] array2 = new byte[this.sBlockSize];
					Array.Copy(array, i * this.sBlockSize, array2, 0, this.sBlockSize);
					this.DecBlock(ref array2, array2.Length);
					dataGridView.Rows.Add();
					dataGridView[0, i].Value = array2[0];
					dataGridView[1, i].Value = array2[1];
					dataGridView[2, i].Value = array2[2];
					dataGridView[3, i].Value = array2[3];
					dataGridView[4, i].Value = array2[4];
					dataGridView[5, i].Value = array2[5];
					dataGridView[6, i].Value = BitConverter.ToUInt16(array2, 6);
					dataGridView[7, i].Value = array2[8];
					dataGridView[8, i].Value = array2[9];
					dataGridView[9, i].Value = BitConverter.ToUInt16(array2, 10);
					dataGridView[10, i].Value = BitConverter.ToUInt16(array2, 12);
				}
			}
			catch (Exception ex)
			{
				dataGridView = new DataGridView();
				MessageBox.Show("The selected file failed to decrypt. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			return dataGridView;
		}

		// Token: 0x060004D0 RID: 1232 RVA: 0x00025D38 File Offset: 0x00023F38
		private void Gatedgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			DataGridView dataGridView = (DataGridView)sender;
			dataGridView[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.PaleGreen;
		}

		// Token: 0x060004D1 RID: 1233 RVA: 0x00025D6D File Offset: 0x00023F6D
		private void Gatedgv_Disposed(object sender, EventArgs e)
		{
			if (Application.OpenForms["Form_Search"] != null)
			{
				Application.OpenForms["Form_Search"].Close();
			}
		}

		// Token: 0x060004D2 RID: 1234 RVA: 0x00025D94 File Offset: 0x00023F94
		private void GateEnc(string filePath)
		{
			List<byte> list = new List<byte>();
			foreach (object obj in ((IEnumerable)this.workingDGV.Rows))
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
				if (dataGridViewRow.Cells[0].Value != null)
				{
					byte[] array = new byte[this.sBlockSize];
					Array.Copy(BitConverter.GetBytes((short)Convert.ToByte(dataGridViewRow.Cells[0].Value.ToString())), 0, array, 0, 1);
					Array.Copy(BitConverter.GetBytes((short)Convert.ToByte(dataGridViewRow.Cells[1].Value.ToString())), 0, array, 1, 1);
					Array.Copy(BitConverter.GetBytes((short)Convert.ToByte(dataGridViewRow.Cells[2].Value.ToString())), 0, array, 2, 1);
					Array.Copy(BitConverter.GetBytes((short)Convert.ToByte(dataGridViewRow.Cells[3].Value.ToString())), 0, array, 3, 1);
					Array.Copy(BitConverter.GetBytes((short)Convert.ToByte(dataGridViewRow.Cells[4].Value.ToString())), 0, array, 4, 1);
					Array.Copy(BitConverter.GetBytes((short)Convert.ToByte(dataGridViewRow.Cells[5].Value.ToString())), 0, array, 5, 1);
					Array.Copy(BitConverter.GetBytes(Convert.ToUInt16(dataGridViewRow.Cells[6].Value.ToString())), 0, array, 6, 2);
					Array.Copy(BitConverter.GetBytes((short)Convert.ToByte(dataGridViewRow.Cells[7].Value.ToString())), 0, array, 8, 1);
					Array.Copy(BitConverter.GetBytes((short)Convert.ToByte(dataGridViewRow.Cells[8].Value.ToString())), 0, array, 9, 1);
					Array.Copy(BitConverter.GetBytes(Convert.ToUInt16(dataGridViewRow.Cells[9].Value.ToString())), 0, array, 10, 2);
					Array.Copy(BitConverter.GetBytes(Convert.ToUInt16(dataGridViewRow.Cells[10].Value.ToString())), 0, array, 12, 2);
					this.EncBlock(ref array, this.sBlockSize);
					for (int i = 0; i < array.Length; i++)
					{
						list.Add(array[i]);
					}
					this.backgroundWorker.ReportProgress(dataGridViewRow.Index);
				}
			}
			this.newFile = list.ToArray();
			File.WriteAllBytes(filePath, this.newFile);
		}

		// Token: 0x060004D3 RID: 1235 RVA: 0x00026044 File Offset: 0x00024244
		private uint GetTempBuffer(byte[] Buffer, int StartIndex, int Length)
		{
			uint num = 0u;
			byte[] array = new byte[Length];
			Array.Copy(Buffer, StartIndex, array, 0, Length);
			uint num2 = 0u;
			while ((ulong)num2 < (ulong)((long)Length))
			{
				num += (uint)array[(int)((UIntPtr)num2)] * Convert.ToUInt32(Math.Pow(256.0, num2));
				num2 += 1u;
			}
			return num;
		}

		// Token: 0x060004D4 RID: 1236 RVA: 0x00026094 File Offset: 0x00024294
		private void Glow_Save()
		{
			Form1.SendArgs sendArgs = new Form1.SendArgs();
			SaveFileDialog saveFileDialog = new SaveFileDialog
			{
				AddExtension = true,
				Title = "Select a location to save the Glow.bmd File",
				Filter = "BMD files (*.bmd)|*.bmd|All files (*.*)|*.*"
			};
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.newFile = new byte[this.sSize * this.sBlockSize];
				this.toolStripProgressBar_Save.Visible = true;
				this.toolStripProgressBar_Save.Value = 0;
				this.toolStripProgressBar_Save.Size = new Size(base.Width - 460, 22);
				this.toolStripProgressBar_Save.Maximum = this.Glowdgv.Rows.Count;
				sendArgs.filePath = saveFileDialog.FileName;
				sendArgs.fileType = "Glow";
				this.backgroundWorker.RunWorkerAsync(sendArgs);
			}
		}

		// Token: 0x060004D5 RID: 1237 RVA: 0x00026164 File Offset: 0x00024364
		private void Glowbw_DoWork(object sender, DoWorkEventArgs e)
		{
			Form1.SendArgs sendArgs = (Form1.SendArgs)e.Argument;
			this.Glowdgv = this.GlowDec(sendArgs.filePath);
		}

		// Token: 0x060004D6 RID: 1238 RVA: 0x00026190 File Offset: 0x00024390
		private void Glowbw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this.toolStripButton_AddRow.Enabled = true;
			this.toolStripButton_RemoveSelectedRow.Enabled = true;
			this.panel1.Controls.Add(this.Glowdgv);
			this.progressBar_Loading.Visible = false;
			this.Glowdgv.CellValueChanged += this.Glowdgv_CellValueChanged;
			this.Glowdgv.Disposed += this.Glowdgv_Disposed;
			this.Glowdgv.CellMouseClick += this.Glowdgv_CellMouseClick;
			this.Glowdgv.KeyDown += this.dgvPasteEvent_KeyDown;
			this.workingDGV = this.Glowdgv;
			this.workingDGV.RowsAdded += this.dgv_RowsAdded;
		}

		// Token: 0x060004D7 RID: 1239 RVA: 0x00026258 File Offset: 0x00024458
		private DataGridView GlowDec(string filePath)
		{
			DataGridView dataGridView = new DataGridView();
			try
			{
				this.initializeGlowGrid(dataGridView);
				FileStream fileStream = new FileStream(filePath, FileMode.Open);
				byte[] array = new byte[fileStream.Length];
				fileStream.Read(array, 0, array.Length);
				fileStream.Close();
				this.sBlockSize = 16;
				this.sSize = array.Length / this.sBlockSize;
				this.fStruct = new object[this.sSize, this.sBlockSize];
				byte[] array2 = new byte[this.sBlockSize];
				int num = 0;
				for (int i = 0; i < this.sSize; i++)
				{
					Array.Copy(array, i * this.sBlockSize, array2, 0, this.sBlockSize);
					if (array2[2] != 0)
					{
						dataGridView.Rows.Add();
						int num2 = (int)BitConverter.ToUInt16(array2, 0);
						dataGridView["Item Group", num].Value = num2 / 512;
						dataGridView["Item Index", num].Value = num2 - 512 * (num2 / 512);
						dataGridView["R Color", num].Value = BitConverter.ToSingle(array2, 4) * 255f;
						dataGridView["G Color", num].Value = BitConverter.ToSingle(array2, 8) * 255f;
						dataGridView["B Color", num].Value = BitConverter.ToSingle(array2, 12) * 255f;
						num++;
					}
				}
			}
			catch (Exception ex)
			{
				dataGridView = new DataGridView();
				MessageBox.Show("The selected file failed to decrypt. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			return dataGridView;
		}

		// Token: 0x060004D8 RID: 1240 RVA: 0x00026428 File Offset: 0x00024628
		private void Glowdgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.ColumnIndex == 2 || e.ColumnIndex == 3 || e.ColumnIndex == 4)
			{
				ColorDialog colorDialog = new ColorDialog
				{
					Color = Color.FromArgb(Convert.ToInt32(this.Glowdgv[2, e.RowIndex].Value), Convert.ToInt32(this.Glowdgv[3, e.RowIndex].Value), Convert.ToInt32(this.Glowdgv[4, e.RowIndex].Value))
				};
				if (colorDialog.ShowDialog() == DialogResult.OK)
				{
					this.Glowdgv[2, e.RowIndex].Value = colorDialog.Color.R;
					this.Glowdgv[3, e.RowIndex].Value = colorDialog.Color.G;
					this.Glowdgv[4, e.RowIndex].Value = colorDialog.Color.B;
				}
			}
		}

		// Token: 0x060004D9 RID: 1241 RVA: 0x00026544 File Offset: 0x00024744
		private void Glowdgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (this.Glowdgv.EditingControl != null)
			{
				if (this.Glowdgv.EditingControl.Text == "")
				{
					this.Glowdgv.EditingControl.Text = "0";
				}
			}
			else if (this.PasteValue == "")
			{
				this.PasteValue = "0";
			}
			switch (e.ColumnIndex)
			{
			case 0:
				if (Convert.ToUInt32(this.Glowdgv.EditingControl.Text) > 15u)
				{
					MessageBox.Show("Maximum 15 !", "Error");
					this.Glowdgv.EditingControl.Text = "15";
					this.Glowdgv[e.ColumnIndex, e.RowIndex].Value = 15;
				}
				break;
			case 1:
				if (Convert.ToUInt32(this.Glowdgv.EditingControl.Text) > 512u)
				{
					MessageBox.Show("Maximum 512 !", "Error");
					this.Glowdgv.EditingControl.Text = "512";
					this.Glowdgv[e.ColumnIndex, e.RowIndex].Value = 512;
				}
				break;
			}
			this.Glowdgv[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.PaleGreen;
		}

		// Token: 0x060004DA RID: 1242 RVA: 0x000266BB File Offset: 0x000248BB
		private void Glowdgv_Disposed(object sender, EventArgs e)
		{
			this.toolStripButton_Save.Enabled = false;
			if (Application.OpenForms["Form_Search"] != null)
			{
				Application.OpenForms["Form_Search"].Close();
			}
		}

		// Token: 0x060004DB RID: 1243 RVA: 0x000266F0 File Offset: 0x000248F0
		private void GlowEnc(string filePath)
		{
			byte[] array = new byte[this.sSize * this.sBlockSize];
			foreach (object obj in ((IEnumerable)this.Glowdgv.Rows))
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
				if (dataGridViewRow.Cells[0].Value != null)
				{
					int num = Convert.ToInt32(dataGridViewRow.Cells[0].Value) * 512 + Convert.ToInt32(dataGridViewRow.Cells[1].Value);
					float value = (float)Convert.ToInt32(dataGridViewRow.Cells[2].Value) / 255f;
					float value2 = (float)Convert.ToInt32(dataGridViewRow.Cells[3].Value) / 255f;
					float value3 = (float)Convert.ToInt32(dataGridViewRow.Cells[4].Value) / 255f;
					byte[] bytes = BitConverter.GetBytes(num);
					for (int i = 0; i < bytes.Length - 2; i++)
					{
						array[num * this.sBlockSize + i] = bytes[i];
					}
					array[num * this.sBlockSize + 2] = 1;
					array[num * this.sBlockSize + 3] = 0;
					byte[] bytes2 = BitConverter.GetBytes(value);
					for (int j = 0; j < bytes2.Length; j++)
					{
						array[num * this.sBlockSize + 4 + j] = bytes2[j];
					}
					byte[] bytes3 = BitConverter.GetBytes(value2);
					for (int k = 0; k < bytes3.Length; k++)
					{
						array[num * this.sBlockSize + 8 + k] = bytes3[k];
					}
					byte[] bytes4 = BitConverter.GetBytes(value3);
					for (int l = 0; l < bytes4.Length; l++)
					{
						array[num * this.sBlockSize + 12 + l] = bytes4[l];
					}
					this.backgroundWorker.ReportProgress(1);
				}
			}
			File.WriteAllBytes(filePath, array);
		}

		// Token: 0x060004DC RID: 1244 RVA: 0x00026920 File Offset: 0x00024B20
		private void IAObw_DoWork(object sender, DoWorkEventArgs e)
		{
			Form1.SendArgs sendArgs = (Form1.SendArgs)e.Argument;
			this.ItemAddOptionDec(sendArgs.filePath);
		}

		// Token: 0x060004DD RID: 1245 RVA: 0x00026948 File Offset: 0x00024B48
		private void IAObw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this.toolStripButton_BmdItemAdder.Enabled = true;
			this.isLeaveOpenItemAdder = true;
			this.toolStripButton_AddRow.Enabled = false;
			this.toolStripButton_RemoveSelectedRow.Enabled = false;
			this.progressBar_Loading.Visible = false;
			this.tc_Items.SelectedIndex = -1;
			this.tc_Items.SelectedIndex = 0;
		}

		// Token: 0x060004DE RID: 1246 RVA: 0x000269A4 File Offset: 0x00024BA4
		private void IAOdgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			DataGridView dataGridView = (DataGridView)sender;
			byte b = Convert.ToByte(dataGridView[0, e.RowIndex].Value);
			int rowIndex = e.RowIndex;
			if (e.ColumnIndex == 0)
			{
				dataGridView[e.ColumnIndex, e.RowIndex].Value = b;
				return;
			}
			if (e.ColumnIndex == 1)
			{
				dataGridView[e.ColumnIndex, e.RowIndex].Value = rowIndex;
				return;
			}
			if (dataGridView.EditingControl != null)
			{
				if (dataGridView.EditingControl.Text == "")
				{
					dataGridView.EditingControl.Text = "0";
				}
			}
			else if (this.PasteValue == "")
			{
				this.PasteValue = "0";
			}
			string value = string.Empty;
			if (this.isPasteFromCP)
			{
				value = this.PasteValue;
			}
			else if (dataGridView.EditingControl != null)
			{
				value = dataGridView.EditingControl.Text;
			}
			else
			{
				value = dataGridView[e.ColumnIndex, e.RowIndex].Value.ToString();
			}
			switch (e.ColumnIndex)
			{
			case 2:
				Array.Copy(BitConverter.GetBytes(Convert.ToInt16(value)), 0, this.T_fStruct, ((int)b * 512 + rowIndex) * this.sBlockSize, 2);
				break;
			case 3:
				Array.Copy(BitConverter.GetBytes(Convert.ToInt16(value)), 0, this.T_fStruct, ((int)b * 512 + rowIndex) * this.sBlockSize + 2, 2);
				break;
			case 4:
				Array.Copy(BitConverter.GetBytes(Convert.ToInt16(value)), 0, this.T_fStruct, ((int)b * 512 + rowIndex) * this.sBlockSize + 4, 2);
				break;
			case 5:
				Array.Copy(BitConverter.GetBytes(Convert.ToInt16(value)), 0, this.T_fStruct, ((int)b * 512 + rowIndex) * this.sBlockSize + 6, 2);
				break;
			case 6:
				Array.Copy(BitConverter.GetBytes(Convert.ToInt32(value)), 0, this.T_fStruct, ((int)b * 512 + rowIndex) * this.sBlockSize + 8, 4);
				break;
			case 7:
				Array.Copy(BitConverter.GetBytes(Convert.ToInt32(value)), 0, this.T_fStruct, ((int)b * 512 + rowIndex) * this.sBlockSize + 12, 4);
				break;
			}
			dataGridView[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.PaleGreen;
		}

		// Token: 0x060004DF RID: 1247 RVA: 0x00026C1C File Offset: 0x00024E1C
		private void IAOdgv_Disposed(object sender, EventArgs e)
		{
			if (Application.OpenForms["Form_Search"] != null)
			{
				Application.OpenForms["Form_Search"].Close();
			}
			if (!this.isLeaveOpenItemAdder)
			{
				if (Application.OpenForms["Form_BmdItemAddercs"] != null)
				{
					Application.OpenForms["Form_BmdItemAddercs"].Close();
				}
				this.toolStripButton_BmdItemAdder.Enabled = false;
			}
		}

		// Token: 0x060004E0 RID: 1248 RVA: 0x00026C87 File Offset: 0x00024E87
		private void iGCDropManagerEditorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new Form_DropManager().Show();
		}

		// Token: 0x060004E2 RID: 1250 RVA: 0x00028CC4 File Offset: 0x00026EC4
		private void initializeFilterGrid(DataGridView dgv)
		{
			dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgv.Dock = DockStyle.Fill;
			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToDeleteRows = false;
			dgv.AllowUserToOrderColumns = false;
			dgv.AllowUserToResizeColumns = true;
			dgv.Columns.Add("Text", "Text");
			dgv.Columns["Text"].ValueType = typeof(string);
			dgv.Columns["Text"].ToolTipText = "Unlimited Length";
			dgv.Columns["Text"].Width = 512;
			dgv.Columns["Text"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			foreach (object obj in dgv.Columns)
			{
				DataGridViewColumn dataGridViewColumn = (DataGridViewColumn)obj;
				dataGridViewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
			}
		}

		// Token: 0x060004E3 RID: 1251 RVA: 0x00028DC8 File Offset: 0x00026FC8
		private void initializeFilterNameGrid(DataGridView dgv)
		{
			dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgv.Dock = DockStyle.Fill;
			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToDeleteRows = false;
			dgv.AllowUserToOrderColumns = false;
			dgv.AllowUserToResizeColumns = true;
			dgv.Columns.Add("Text", "Text");
			dgv.Columns["Text"].ValueType = typeof(string);
			dgv.Columns["Text"].ToolTipText = "Maximum 20 Characters";
			dgv.Columns["Text"].Width = 512;
			dgv.Columns["Text"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			foreach (object obj in dgv.Columns)
			{
				DataGridViewColumn dataGridViewColumn = (DataGridViewColumn)obj;
				dataGridViewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
			}
		}

		// Token: 0x060004E4 RID: 1252 RVA: 0x00028ECC File Offset: 0x000270CC
		private void initializeGateGrid(DataGridView dgv)
		{
			dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgv.Dock = DockStyle.Fill;
			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToDeleteRows = false;
			dgv.AllowUserToOrderColumns = false;
			dgv.AllowUserToResizeColumns = true;
			dgv.Columns.Add("Type", "Type");
			dgv.Columns["Type"].ValueType = typeof(byte);
			dgv.Columns["Type"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("Map ID", "Map ID");
			dgv.Columns["Map ID"].ValueType = typeof(byte);
			dgv.Columns["Map ID"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("X 1", "X 1");
			dgv.Columns["X 1"].ValueType = typeof(byte);
			dgv.Columns["X 1"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns["X 1"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			dgv.Columns["X 1"].Width = 50;
			dgv.Columns.Add("Y 1", "Y 1");
			dgv.Columns["Y 1"].ValueType = typeof(byte);
			dgv.Columns["Y 1"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns["Y 1"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			dgv.Columns["Y 1"].Width = 50;
			dgv.Columns.Add("X 2", "X 2");
			dgv.Columns["X 2"].ValueType = typeof(byte);
			dgv.Columns["X 2"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns["X 2"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			dgv.Columns["X 2"].Width = 50;
			dgv.Columns.Add("Y 2", "Y 2");
			dgv.Columns["Y 2"].ValueType = typeof(byte);
			dgv.Columns["Y 2"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns["Y 2"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			dgv.Columns["Y 2"].Width = 50;
			dgv.Columns.Add("Target", "Target");
			dgv.Columns["Target"].ValueType = typeof(ushort);
			dgv.Columns["Target"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns.Add("Direction", "Direction");
			dgv.Columns["Direction"].ValueType = typeof(byte);
			dgv.Columns["Direction"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("Unk_1", "Unk_1");
			dgv.Columns["Unk_1"].ValueType = typeof(byte);
			dgv.Columns["Unk_1"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("Minimum Level", "Minimum Level");
			dgv.Columns["Minimum Level"].ValueType = typeof(ushort);
			dgv.Columns["Minimum Level"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns.Add("Maximum Level", "Maximum Level");
			dgv.Columns["Maximum Level"].ValueType = typeof(ushort);
			dgv.Columns["Maximum Level"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			foreach (object obj in dgv.Columns)
			{
				DataGridViewColumn dataGridViewColumn = (DataGridViewColumn)obj;
				dataGridViewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
			}
		}

		// Token: 0x060004E5 RID: 1253 RVA: 0x000294B4 File Offset: 0x000276B4
		private void initializeGlowGrid(DataGridView dgv)
		{
			dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgv.Dock = DockStyle.Fill;
			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToDeleteRows = false;
			dgv.Columns.Add("Item Group", "Item Group");
			dgv.Columns["Item Group"].ValueType = typeof(uint);
			dgv.Columns["Item Group"].ToolTipText = "0 <= Value(Numbers) <= 15";
			dgv.Columns.Add("Item Index", "Item Index");
			dgv.Columns["Item Index"].ValueType = typeof(uint);
			dgv.Columns["Item Index"].ToolTipText = "0 <= Value(Numbers) <= 512";
			dgv.Columns.Add("R Color", "R Color");
			dgv.Columns["R Color"].ValueType = typeof(byte);
			dgv.Columns["R Color"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("G Color", "G Color");
			dgv.Columns["G Color"].ValueType = typeof(byte);
			dgv.Columns["G Color"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("B Color", "B Color");
			dgv.Columns["B Color"].ValueType = typeof(byte);
			dgv.Columns["B Color"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
		}

		// Token: 0x060004E6 RID: 1254 RVA: 0x000296BC File Offset: 0x000278BC
		public void initializeIAOGrid(DataGridView dgv)
		{
			dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgv.Dock = DockStyle.Fill;
			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToDeleteRows = false;
			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
			dgv.AllowUserToOrderColumns = false;
			dgv.AllowUserToResizeColumns = true;
			dgv.Columns.Add("Group", "Group");
			dgv.Columns["Group"].ReadOnly = true;
			dgv.Columns["Group"].DefaultCellStyle.BackColor = Color.LightGray;
			dgv.Columns.Add("Index", "Index");
			dgv.Columns["Index"].ReadOnly = true;
			dgv.Columns["Index"].DefaultCellStyle.BackColor = Color.LightGray;
			dgv.Columns.Add("v1", "v1");
			dgv.Columns["v1"].ValueType = typeof(short);
			dgv.Columns["v1"].ToolTipText = short.MinValue.ToString() + " <= Value(Numbers) <= " + short.MaxValue.ToString();
			dgv.Columns.Add("v2", "v2");
			dgv.Columns["v2"].ValueType = typeof(short);
			dgv.Columns["v2"].ToolTipText = short.MinValue.ToString() + " <= Value(Numbers) <= " + short.MaxValue.ToString();
			dgv.Columns.Add("v3", "v3");
			dgv.Columns["v3"].ValueType = typeof(short);
			dgv.Columns["v3"].ToolTipText = short.MinValue.ToString() + " <= Value(Numbers) <= " + short.MaxValue.ToString();
			dgv.Columns.Add("v4", "v4");
			dgv.Columns["v4"].ValueType = typeof(short);
			dgv.Columns["v4"].ToolTipText = short.MinValue.ToString() + " <= Value(Numbers) <= " + short.MaxValue.ToString();
			dgv.Columns.Add("v5", "v5");
			dgv.Columns["v5"].ValueType = typeof(int);
			dgv.Columns["v5"].ToolTipText = int.MinValue.ToString() + " <= Value(Numbers) <= " + int.MaxValue.ToString();
			dgv.Columns.Add("v6", "v6");
			dgv.Columns["v6"].ValueType = typeof(int);
			dgv.Columns["v6"].ToolTipText = int.MinValue.ToString() + " <= Value(Numbers) <= " + int.MaxValue.ToString();
		}

		// Token: 0x060004E7 RID: 1255 RVA: 0x00029A2C File Offset: 0x00027C2C
		public void initializeISTGrid(DataGridView dgv)
		{
			dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgv.Dock = DockStyle.Fill;
			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToDeleteRows = false;
			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
			dgv.AllowUserToOrderColumns = false;
			dgv.AllowUserToResizeColumns = true;
			dgv.Columns.Add("Group", "Group");
			dgv.Columns["Group"].ReadOnly = true;
			dgv.Columns["Group"].DefaultCellStyle.BackColor = Color.LightGray;
			dgv.Columns.Add("Index", "Index");
			dgv.Columns["Index"].ReadOnly = true;
			dgv.Columns["Index"].DefaultCellStyle.BackColor = Color.LightGray;
			dgv.Columns.Add("v1", "v1");
			dgv.Columns["v1"].ValueType = typeof(byte);
			dgv.Columns["v1"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("v2", "v2");
			dgv.Columns["v2"].ValueType = typeof(byte);
			dgv.Columns["v2"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("v3", "v3");
			dgv.Columns["v3"].ValueType = typeof(byte);
			dgv.Columns["v3"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("v4", "v4");
			dgv.Columns["v4"].ValueType = typeof(byte);
			dgv.Columns["v4"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
		}

		// Token: 0x060004E8 RID: 1256 RVA: 0x00029CAC File Offset: 0x00027EAC
		public void initializeItem_S6E3Grid(DataGridView dgv)
		{
			dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgv.Dock = DockStyle.Fill;
			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToDeleteRows = false;
			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
			dgv.AllowUserToOrderColumns = false;
			dgv.AllowUserToResizeColumns = true;
			dgv.Columns.Add("Group", "Group");
			dgv.Columns["Group"].ValueType = typeof(ushort);
			dgv.Columns["Group"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns["Group"].ReadOnly = true;
			dgv.Columns["Group"].DefaultCellStyle.BackColor = Color.LightGray;
			dgv.Columns.Add("Index", "Index");
			dgv.Columns["Index"].ValueType = typeof(ushort);
			dgv.Columns["Index"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns["Index"].ReadOnly = true;
			dgv.Columns["Index"].DefaultCellStyle.BackColor = Color.LightGray;
			dgv.Columns.Add("Name", "Name");
			dgv.Columns["Name"].ValueType = typeof(string);
			dgv.Columns["Name"].ToolTipText = "0 <= Value(Chars) <= 30";
			dgv.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			dgv.Columns["Name"].Width = 300;
			dgv.Columns.Add("Two Hands", "Two Hands");
			dgv.Columns["Two Hands"].ValueType = typeof(byte);
			dgv.Columns["Two Hands"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("Level", "Level");
			dgv.Columns["Level"].ValueType = typeof(ushort);
			dgv.Columns["Level"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns.Add("Slot", "Slot");
			dgv.Columns["Slot"].ValueType = typeof(ushort);
			dgv.Columns["Slot"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns.Add("Skill", "Skill");
			dgv.Columns["Skill"].ValueType = typeof(ushort);
			dgv.Columns["Skill"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns.Add("X", "X");
			dgv.Columns["X"].ValueType = typeof(byte);
			dgv.Columns["X"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("Y", "Y");
			dgv.Columns["Y"].ValueType = typeof(byte);
			dgv.Columns["Y"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("Min Dmg", "Min Dmg");
			dgv.Columns["Min Dmg"].ValueType = typeof(byte);
			dgv.Columns["Min Dmg"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("Max Dmg", "Max Dmg");
			dgv.Columns["Max Dmg"].ValueType = typeof(byte);
			dgv.Columns["Max Dmg"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("Def Rate", "Def Rate");
			dgv.Columns["Def Rate"].ValueType = typeof(byte);
			dgv.Columns["Def Rate"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("Defense", "Defense");
			dgv.Columns["Defense"].ValueType = typeof(byte);
			dgv.Columns["Defense"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("Unk_1", "Unk_1");
			dgv.Columns["Unk_1"].ValueType = typeof(byte);
			dgv.Columns["Unk_1"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("AtkSpeed", "AtkSpeed");
			dgv.Columns["AtkSpeed"].ValueType = typeof(byte);
			dgv.Columns["AtkSpeed"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("Unk_2", "Unk_2");
			dgv.Columns["Unk_2"].ValueType = typeof(byte);
			dgv.Columns["Unk_2"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("Durability", "Durability");
			dgv.Columns["Durability"].ValueType = typeof(byte);
			dgv.Columns["Durability"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("MagicDur", "MagicDur");
			dgv.Columns["MagicDur"].ValueType = typeof(byte);
			dgv.Columns["MagicDur"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("MagicPwr", "MagicPwr");
			dgv.Columns["MagicPwr"].ValueType = typeof(byte);
			dgv.Columns["MagicPwr"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("ReqStr", "ReqStr");
			dgv.Columns["ReqStr"].ValueType = typeof(ushort);
			dgv.Columns["ReqStr"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns.Add("ReqDex", "ReqDex");
			dgv.Columns["ReqDex"].ValueType = typeof(ushort);
			dgv.Columns["ReqDex"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns.Add("ReqEne", "ReqEne");
			dgv.Columns["ReqEne"].ValueType = typeof(ushort);
			dgv.Columns["ReqEne"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns.Add("ReqVit", "ReqVit");
			dgv.Columns["ReqVit"].ValueType = typeof(ushort);
			dgv.Columns["ReqVit"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns.Add("ReqLea", "ReqLea");
			dgv.Columns["ReqLea"].ValueType = typeof(ushort);
			dgv.Columns["ReqLea"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns.Add("ReqLvl", "ReqLvl");
			dgv.Columns["ReqLvl"].ValueType = typeof(ushort);
			dgv.Columns["ReqLvl"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns.Add("ItemValue", "ItemValue");
			dgv.Columns["ItemValue"].ValueType = typeof(byte);
			dgv.Columns["ItemValue"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("Unk_4", "Unk_4");
			dgv.Columns["Unk_4"].ValueType = typeof(byte);
			dgv.Columns["Unk_4"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("Zen", "Zen");
			dgv.Columns["Zen"].ValueType = typeof(uint);
			dgv.Columns["Zen"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + uint.MaxValue.ToString();
			dgv.Columns.Add("Type", "Type");
			dgv.Columns["Type"].ValueType = typeof(byte);
			dgv.Columns["Type"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("DW/SM/GM", "DW/SM/GM");
			dgv.Columns["DW/SM/GM"].ValueType = typeof(byte);
			dgv.Columns["DW/SM/GM"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("DK/BK/BM", "DK/BK/BM");
			dgv.Columns["DK/BK/BM"].ValueType = typeof(byte);
			dgv.Columns["DK/BK/BM"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("Elf/ME/HE", "Elf/ME/HE");
			dgv.Columns["Elf/ME/HE"].ValueType = typeof(byte);
			byte maxValue = byte.MaxValue;
			dgv.Columns["Elf/ME/HE"].ToolTipText = maxValue.ToString() + " <= Value(Numbers) <= " + maxValue.ToString();
			dgv.Columns.Add("MG/DM", "MG/DM");
			dgv.Columns["MG/DM"].ValueType = typeof(byte);
			maxValue = byte.MaxValue;
			dgv.Columns["MG/DM"].ToolTipText = maxValue.ToString() + " <= Value(Numbers) <= " + maxValue.ToString();
			dgv.Columns.Add("DL/LE", "DL/LE");
			dgv.Columns["DL/LE"].ValueType = typeof(byte);
			maxValue = byte.MaxValue;
			dgv.Columns["DL/LE"].ToolTipText = maxValue.ToString() + " <= Value(Numbers) <= " + maxValue.ToString();
			dgv.Columns.Add("SUM/BS/DM", "SUM/BS/DM");
			dgv.Columns["SUM/BS/DM"].ValueType = typeof(byte);
			maxValue = byte.MaxValue;
			dgv.Columns["SUM/BS/DM"].ToolTipText = maxValue.ToString() + " <= Value(Numbers) <= " + maxValue.ToString();
			dgv.Columns.Add("RF/FM", "RF/FM");
			dgv.Columns["RF/FM"].ValueType = typeof(byte);
			maxValue = byte.MaxValue;
			dgv.Columns["RF/FM"].ToolTipText = maxValue.ToString() + " <= Value(Numbers) <= " + maxValue.ToString();
			dgv.Columns.Add("Ice Attribute", "Ice Attribute");
			dgv.Columns["Ice Attribute"].ValueType = typeof(byte);
			maxValue = byte.MaxValue;
			dgv.Columns["Ice Attribute"].ToolTipText = maxValue.ToString() + " <= Value(Numbers) <= " + maxValue.ToString();
			dgv.Columns.Add("Poison Attribute", "Poison Attribute");
			dgv.Columns["Poison Attribute"].ValueType = typeof(byte);
			maxValue = byte.MaxValue;
			dgv.Columns["Poison Attribute"].ToolTipText = maxValue.ToString() + " <= Value(Numbers) <= " + maxValue.ToString();
			dgv.Columns.Add("Lightning Attribute", "Lightning Attribute");
			dgv.Columns["Lightning Attribute"].ValueType = typeof(byte);
			maxValue = byte.MaxValue;
			dgv.Columns["Lightning Attribute"].ToolTipText = maxValue.ToString() + " <= Value(Numbers) <= " + maxValue.ToString();
			dgv.Columns.Add("Fire Attribute", "Fire Attribute");
			dgv.Columns["Fire Attribute"].ValueType = typeof(byte);
			maxValue = byte.MaxValue;
			dgv.Columns["Fire Attribute"].ToolTipText = maxValue.ToString() + " <= Value(Numbers) <= " + maxValue.ToString();
			dgv.Columns.Add("Earth Attribute", "Earth Attribute");
			dgv.Columns["Earth Attribute"].ValueType = typeof(byte);
			maxValue = byte.MaxValue;
			dgv.Columns["Earth Attribute"].ToolTipText = maxValue.ToString() + " <= Value(Numbers) <= " + maxValue.ToString();
			dgv.Columns.Add("Wind Attribute", "Wind Attribute");
			dgv.Columns["Wind Attribute"].ValueType = typeof(byte);
			maxValue = byte.MaxValue;
			dgv.Columns["Wind Attribute"].ToolTipText = maxValue.ToString() + " <= Value(Numbers) <= " + maxValue.ToString();
			dgv.Columns.Add("Water Attribute", "Water Attribute");
			dgv.Columns["Water Attribute"].ValueType = typeof(byte);
			maxValue = byte.MaxValue;
			dgv.Columns["Water Attribute"].ToolTipText = maxValue.ToString() + " <= Value(Numbers) <= " + maxValue.ToString();
			dgv.Columns.Add("Unk_6", "Unk_6");
			dgv.Columns["Unk_6"].ValueType = typeof(byte);
			maxValue = byte.MaxValue;
			dgv.Columns["Unk_6"].ToolTipText = maxValue.ToString() + " <= Value(Numbers) <= " + maxValue.ToString();
			foreach (object obj in dgv.Columns)
			{
				DataGridViewColumn dataGridViewColumn = (DataGridViewColumn)obj;
				dataGridViewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
			}
		}

		// Token: 0x060004E9 RID: 1257 RVA: 0x0002B02C File Offset: 0x0002922C
		public void initializeItemEx700Grid(DataGridView dgv)
		{
			dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgv.Dock = DockStyle.Fill;
			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToDeleteRows = false;
			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
			dgv.AllowUserToOrderColumns = false;
			dgv.AllowUserToResizeColumns = true;
			dgv.Columns.Add("Unk_1", "Unk_1");
			dgv.Columns["Unk_1"].ValueType = typeof(ushort);
			dgv.Columns["Unk_1"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns.Add("Unk_2", "Unk_2");
			dgv.Columns["Unk_2"].ValueType = typeof(ushort);
			dgv.Columns["Unk_2"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns.Add("Unk_3", "Unk_3");
			dgv.Columns["Unk_3"].ValueType = typeof(byte);
			dgv.Columns["Unk_3"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("Unk_4", "Unk_4");
			dgv.Columns["Unk_4"].ValueType = typeof(byte);
			dgv.Columns["Unk_4"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("Group", "Group");
			dgv.Columns["Group"].ValueType = typeof(ushort);
			dgv.Columns["Group"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns["Group"].ReadOnly = true;
			dgv.Columns["Group"].DefaultCellStyle.BackColor = Color.LightGray;
			dgv.Columns.Add("Index", "Index");
			dgv.Columns["Index"].ValueType = typeof(ushort);
			dgv.Columns["Index"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns["Index"].ReadOnly = true;
			dgv.Columns["Index"].DefaultCellStyle.BackColor = Color.LightGray;
			dgv.Columns.Add("Model Folder", "Model Folder");
			dgv.Columns["Model Folder"].ValueType = typeof(string);
			dgv.Columns["Model Folder"].ToolTipText = "0 <= Value(Chars) <= 260";
			dgv.Columns["Model Folder"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			dgv.Columns["Model Folder"].Width = 150;
			dgv.Columns.Add("Model Name", "Model Name");
			dgv.Columns["Model Name"].ValueType = typeof(string);
			dgv.Columns["Model Name"].ToolTipText = "0 <= Value(Chars) <= 260";
			dgv.Columns["Model Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			dgv.Columns["Model Name"].Width = 150;
			dgv.Columns.Add("Name", "Name");
			dgv.Columns["Name"].ValueType = typeof(string);
			dgv.Columns["Name"].ToolTipText = "0 <= Value(Chars) <= 30";
			dgv.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			dgv.Columns["Name"].Width = 300;
			dgv.Columns.Add("Type", "Type");
			dgv.Columns["Type"].ValueType = typeof(byte);
			dgv.Columns["Type"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("Two Hands", "Two Hands");
			dgv.Columns["Two Hands"].ValueType = typeof(byte);
			dgv.Columns["Two Hands"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("Level", "Level");
			dgv.Columns["Level"].ValueType = typeof(ushort);
			dgv.Columns["Level"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns.Add("Slot", "Slot");
			dgv.Columns["Slot"].ValueType = typeof(ushort);
			dgv.Columns["Slot"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns.Add("Skill", "Skill");
			dgv.Columns["Skill"].ValueType = typeof(ushort);
			dgv.Columns["Skill"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns.Add("X", "X");
			dgv.Columns["X"].ValueType = typeof(byte);
			dgv.Columns["X"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("Y", "Y");
			dgv.Columns["Y"].ValueType = typeof(byte);
			dgv.Columns["Y"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("Min Dmg", "Min Dmg");
			dgv.Columns["Min Dmg"].ValueType = typeof(byte);
			dgv.Columns["Min Dmg"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("Max Dmg", "Max Dmg");
			dgv.Columns["Max Dmg"].ValueType = typeof(byte);
			dgv.Columns["Max Dmg"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("Def Rate", "Def Rate");
			dgv.Columns["Def Rate"].ValueType = typeof(byte);
			dgv.Columns["Def Rate"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("Defense", "Defense");
			dgv.Columns["Defense"].ValueType = typeof(ushort);
			dgv.Columns["Defense"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns.Add("AtkSpeed", "AtkSpeed");
			dgv.Columns["AtkSpeed"].ValueType = typeof(byte);
			dgv.Columns["AtkSpeed"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("WalkSpeed", "WalkSpeed");
			dgv.Columns["WalkSpeed"].ValueType = typeof(byte);
			dgv.Columns["WalkSpeed"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("Durability", "Durability");
			dgv.Columns["Durability"].ValueType = typeof(byte);
			dgv.Columns["Durability"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("MagicDur", "MagicDur");
			dgv.Columns["MagicDur"].ValueType = typeof(byte);
			dgv.Columns["MagicDur"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("MagicPwr", "MagicPwr");
			dgv.Columns["MagicPwr"].ValueType = typeof(byte);
			dgv.Columns["MagicPwr"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("ReqStr", "ReqStr");
			dgv.Columns["ReqStr"].ValueType = typeof(ushort);
			dgv.Columns["ReqStr"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns.Add("ReqDex", "ReqDex");
			dgv.Columns["ReqDex"].ValueType = typeof(ushort);
			dgv.Columns["ReqDex"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns.Add("ReqEne", "ReqEne");
			dgv.Columns["ReqEne"].ValueType = typeof(ushort);
			dgv.Columns["ReqEne"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns.Add("ReqVit", "ReqVit");
			dgv.Columns["ReqVit"].ValueType = typeof(ushort);
			dgv.Columns["ReqVit"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns.Add("ReqLea", "ReqLea");
			dgv.Columns["ReqLea"].ValueType = typeof(ushort);
			dgv.Columns["ReqLea"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns.Add("ReqLvl", "ReqLvl");
			dgv.Columns["ReqLvl"].ValueType = typeof(ushort);
			dgv.Columns["ReqLvl"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns.Add("ItemValue", "ItemValue");
			dgv.Columns["ItemValue"].ValueType = typeof(ushort);
			dgv.Columns["ItemValue"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns.Add("Zen", "Zen");
			dgv.Columns["Zen"].ValueType = typeof(uint);
			dgv.Columns["Zen"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + uint.MaxValue.ToString();
			dgv.Columns.Add("SetOption", "SetOption");
			dgv.Columns["SetOption"].ValueType = typeof(byte);
			byte maxValue = byte.MaxValue;
			dgv.Columns["SetOption"].ToolTipText = maxValue.ToString() + " <= Value(Numbers) <= " + maxValue.ToString();
			dgv.Columns.Add("DW/SM/GM", "DW/SM/GM");
			dgv.Columns["DW/SM/GM"].ValueType = typeof(byte);
			maxValue = byte.MaxValue;
			dgv.Columns["DW/SM/GM"].ToolTipText = maxValue.ToString() + " <= Value(Numbers) <= " + maxValue.ToString();
			dgv.Columns.Add("DK/BK/BM", "DK/BK/BM");
			dgv.Columns["DK/BK/BM"].ValueType = typeof(byte);
			maxValue = byte.MaxValue;
			dgv.Columns["DK/BK/BM"].ToolTipText = maxValue.ToString() + " <= Value(Numbers) <= " + maxValue.ToString();
			dgv.Columns.Add("Elf/ME/HE", "Elf/ME/HE");
			dgv.Columns["Elf/ME/HE"].ValueType = typeof(byte);
			maxValue = byte.MaxValue;
			dgv.Columns["Elf/ME/HE"].ToolTipText = maxValue.ToString() + " <= Value(Numbers) <= " + maxValue.ToString();
			dgv.Columns.Add("MG/DM", "MG/DM");
			dgv.Columns["MG/DM"].ValueType = typeof(byte);
			maxValue = byte.MaxValue;
			dgv.Columns["MG/DM"].ToolTipText = maxValue.ToString() + " <= Value(Numbers) <= " + maxValue.ToString();
			dgv.Columns.Add("DL/LE", "DL/LE");
			dgv.Columns["DL/LE"].ValueType = typeof(byte);
			maxValue = byte.MaxValue;
			dgv.Columns["DL/LE"].ToolTipText = maxValue.ToString() + " <= Value(Numbers) <= " + maxValue.ToString();
			dgv.Columns.Add("SUM/BS/DM", "SUM/BS/DM");
			dgv.Columns["SUM/BS/DM"].ValueType = typeof(byte);
			maxValue = byte.MaxValue;
			dgv.Columns["SUM/BS/DM"].ToolTipText = maxValue.ToString() + " <= Value(Numbers) <= " + maxValue.ToString();
			dgv.Columns.Add("RF/FM", "RF/FM");
			dgv.Columns["RF/FM"].ValueType = typeof(byte);
			maxValue = byte.MaxValue;
			dgv.Columns["RF/FM"].ToolTipText = maxValue.ToString() + " <= Value(Numbers) <= " + maxValue.ToString();
			dgv.Columns.Add("Ice Attribute", "Ice Attribute");
			dgv.Columns["Ice Attribute"].ValueType = typeof(byte);
			maxValue = byte.MaxValue;
			dgv.Columns["Ice Attribute"].ToolTipText = maxValue.ToString() + " <= Value(Numbers) <= " + maxValue.ToString();
			dgv.Columns.Add("Poison Attribute", "Poison Attribute");
			dgv.Columns["Poison Attribute"].ValueType = typeof(byte);
			maxValue = byte.MaxValue;
			dgv.Columns["Poison Attribute"].ToolTipText = maxValue.ToString() + " <= Value(Numbers) <= " + maxValue.ToString();
			dgv.Columns.Add("Lightning Attribute", "Lightning Attribute");
			dgv.Columns["Lightning Attribute"].ValueType = typeof(byte);
			maxValue = byte.MaxValue;
			dgv.Columns["Lightning Attribute"].ToolTipText = maxValue.ToString() + " <= Value(Numbers) <= " + maxValue.ToString();
			dgv.Columns.Add("Fire Attribute", "Fire Attribute");
			dgv.Columns["Fire Attribute"].ValueType = typeof(byte);
			maxValue = byte.MaxValue;
			dgv.Columns["Fire Attribute"].ToolTipText = maxValue.ToString() + " <= Value(Numbers) <= " + maxValue.ToString();
			dgv.Columns.Add("Earth Attribute", "Earth Attribute");
			dgv.Columns["Earth Attribute"].ValueType = typeof(byte);
			maxValue = byte.MaxValue;
			dgv.Columns["Earth Attribute"].ToolTipText = maxValue.ToString() + " <= Value(Numbers) <= " + maxValue.ToString();
			dgv.Columns.Add("Wind Attribute", "Wind Attribute");
			dgv.Columns["Wind Attribute"].ValueType = typeof(byte);
			maxValue = byte.MaxValue;
			dgv.Columns["Wind Attribute"].ToolTipText = maxValue.ToString() + " <= Value(Numbers) <= " + maxValue.ToString();
			dgv.Columns.Add("Water Attribute", "Water Attribute");
			dgv.Columns["Water Attribute"].ValueType = typeof(byte);
			maxValue = byte.MaxValue;
			dgv.Columns["Water Attribute"].ToolTipText = maxValue.ToString() + " <= Value(Numbers) <= " + maxValue.ToString();
			dgv.Columns.Add("Unk_5", "Unk_5");
			dgv.Columns["Unk_5"].ValueType = typeof(byte);
			maxValue = byte.MaxValue;
			dgv.Columns["Unk_5"].ToolTipText = maxValue.ToString() + " <= Value(Numbers) <= " + maxValue.ToString();
			foreach (object obj in dgv.Columns)
			{
				DataGridViewColumn dataGridViewColumn = (DataGridViewColumn)obj;
				dataGridViewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
			}
		}

		// Token: 0x060004EA RID: 1258 RVA: 0x0002C5E8 File Offset: 0x0002A7E8
		public void initializeItemEx700PlusGrid(DataGridView dgv)
		{
			dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgv.Dock = DockStyle.Fill;
			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToDeleteRows = false;
			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
			dgv.AllowUserToOrderColumns = false;
			dgv.AllowUserToResizeColumns = true;
			dgv.Columns.Add("Unk_1", "Unk_1");
			dgv.Columns["Unk_1"].ValueType = typeof(ushort);
			dgv.Columns["Unk_1"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns.Add("Unk_2", "Unk_2");
			dgv.Columns["Unk_2"].ValueType = typeof(ushort);
			dgv.Columns["Unk_2"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns.Add("Unk_3", "Unk_3");
			dgv.Columns["Unk_3"].ValueType = typeof(byte);
			dgv.Columns["Unk_3"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("Unk_4", "Unk_4");
			dgv.Columns["Unk_4"].ValueType = typeof(byte);
			dgv.Columns["Unk_4"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("Group", "Group");
			dgv.Columns["Group"].ValueType = typeof(ushort);
			dgv.Columns["Group"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns["Group"].ReadOnly = true;
			dgv.Columns["Group"].DefaultCellStyle.BackColor = Color.LightGray;
			dgv.Columns.Add("Index", "Index");
			dgv.Columns["Index"].ValueType = typeof(ushort);
			dgv.Columns["Index"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns["Index"].ReadOnly = true;
			dgv.Columns["Index"].DefaultCellStyle.BackColor = Color.LightGray;
			dgv.Columns.Add("Model Folder", "Model Folder");
			dgv.Columns["Model Folder"].ValueType = typeof(string);
			dgv.Columns["Model Folder"].ToolTipText = "0 <= Value(Chars) <= 260";
			dgv.Columns["Model Folder"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			dgv.Columns["Model Folder"].Width = 150;
			dgv.Columns.Add("Model Name", "Model Name");
			dgv.Columns["Model Name"].ValueType = typeof(string);
			dgv.Columns["Model Name"].ToolTipText = "0 <= Value(Chars) <= 260";
			dgv.Columns["Model Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			dgv.Columns["Model Name"].Width = 150;
			dgv.Columns.Add("Name", "Name");
			dgv.Columns["Name"].ValueType = typeof(string);
			dgv.Columns["Name"].ToolTipText = "0 <= Value(Chars) <= 30";
			dgv.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			dgv.Columns["Name"].Width = 300;
			dgv.Columns.Add("Type", "Type");
			dgv.Columns["Type"].ValueType = typeof(byte);
			dgv.Columns["Type"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("Two Hands", "Two Hands");
			dgv.Columns["Two Hands"].ValueType = typeof(byte);
			dgv.Columns["Two Hands"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("Level", "Level");
			dgv.Columns["Level"].ValueType = typeof(ushort);
			dgv.Columns["Level"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns.Add("Slot", "Slot");
			dgv.Columns["Slot"].ValueType = typeof(ushort);
			dgv.Columns["Slot"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns.Add("Skill", "Skill");
			dgv.Columns["Skill"].ValueType = typeof(ushort);
			dgv.Columns["Skill"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns.Add("X", "X");
			dgv.Columns["X"].ValueType = typeof(byte);
			dgv.Columns["X"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("Y", "Y");
			dgv.Columns["Y"].ValueType = typeof(byte);
			dgv.Columns["Y"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("Min Dmg", "Min Dmg");
			dgv.Columns["Min Dmg"].ValueType = typeof(byte);
			dgv.Columns["Min Dmg"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("Max Dmg", "Max Dmg");
			dgv.Columns["Max Dmg"].ValueType = typeof(byte);
			dgv.Columns["Max Dmg"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("Def Rate", "Def Rate");
			dgv.Columns["Def Rate"].ValueType = typeof(byte);
			dgv.Columns["Def Rate"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("Defense", "Defense");
			dgv.Columns["Defense"].ValueType = typeof(ushort);
			dgv.Columns["Defense"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns.Add("AtkSpeed", "AtkSpeed");
			dgv.Columns["AtkSpeed"].ValueType = typeof(byte);
			dgv.Columns["AtkSpeed"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("WalkSpeed", "WalkSpeed");
			dgv.Columns["WalkSpeed"].ValueType = typeof(byte);
			dgv.Columns["WalkSpeed"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("Durability", "Durability");
			dgv.Columns["Durability"].ValueType = typeof(byte);
			dgv.Columns["Durability"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("MagicDur", "MagicDur");
			dgv.Columns["MagicDur"].ValueType = typeof(byte);
			dgv.Columns["MagicDur"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("MagicPwr", "MagicPwr");
			dgv.Columns["MagicPwr"].ValueType = typeof(byte);
			dgv.Columns["MagicPwr"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("ReqStr", "ReqStr");
			dgv.Columns["ReqStr"].ValueType = typeof(ushort);
			dgv.Columns["ReqStr"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns.Add("ReqDex", "ReqDex");
			dgv.Columns["ReqDex"].ValueType = typeof(ushort);
			dgv.Columns["ReqDex"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns.Add("ReqEne", "ReqEne");
			dgv.Columns["ReqEne"].ValueType = typeof(ushort);
			dgv.Columns["ReqEne"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns.Add("ReqVit", "ReqVit");
			dgv.Columns["ReqVit"].ValueType = typeof(ushort);
			dgv.Columns["ReqVit"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns.Add("ReqLea", "ReqLea");
			dgv.Columns["ReqLea"].ValueType = typeof(ushort);
			dgv.Columns["ReqLea"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns.Add("ReqLvl", "ReqLvl");
			dgv.Columns["ReqLvl"].ValueType = typeof(ushort);
			dgv.Columns["ReqLvl"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns.Add("ItemValue", "ItemValue");
			dgv.Columns["ItemValue"].ValueType = typeof(ushort);
			dgv.Columns["ItemValue"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns.Add("Zen", "Zen");
			dgv.Columns["Zen"].ValueType = typeof(uint);
			dgv.Columns["Zen"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + uint.MaxValue.ToString();
			dgv.Columns.Add("SetOption", "SetOption");
			dgv.Columns["SetOption"].ValueType = typeof(byte);
			byte maxValue = byte.MaxValue;
			dgv.Columns["SetOption"].ToolTipText = maxValue.ToString() + " <= Value(Numbers) <= " + maxValue.ToString();
			dgv.Columns.Add("DW/SM/GM", "DW/SM/GM");
			dgv.Columns["DW/SM/GM"].ValueType = typeof(byte);
			maxValue = byte.MaxValue;
			dgv.Columns["DW/SM/GM"].ToolTipText = maxValue.ToString() + " <= Value(Numbers) <= " + maxValue.ToString();
			dgv.Columns.Add("DK/BK/BM", "DK/BK/BM");
			dgv.Columns["DK/BK/BM"].ValueType = typeof(byte);
			maxValue = byte.MaxValue;
			dgv.Columns["DK/BK/BM"].ToolTipText = maxValue.ToString() + " <= Value(Numbers) <= " + maxValue.ToString();
			dgv.Columns.Add("Elf/ME/HE", "Elf/ME/HE");
			dgv.Columns["Elf/ME/HE"].ValueType = typeof(byte);
			maxValue = byte.MaxValue;
			dgv.Columns["Elf/ME/HE"].ToolTipText = maxValue.ToString() + " <= Value(Numbers) <= " + maxValue.ToString();
			dgv.Columns.Add("MG/DM", "MG/DM");
			dgv.Columns["MG/DM"].ValueType = typeof(byte);
			maxValue = byte.MaxValue;
			dgv.Columns["MG/DM"].ToolTipText = maxValue.ToString() + " <= Value(Numbers) <= " + maxValue.ToString();
			dgv.Columns.Add("DL/LE", "DL/LE");
			dgv.Columns["DL/LE"].ValueType = typeof(byte);
			maxValue = byte.MaxValue;
			dgv.Columns["DL/LE"].ToolTipText = maxValue.ToString() + " <= Value(Numbers) <= " + maxValue.ToString();
			dgv.Columns.Add("SUM/BS/DM", "SUM/BS/DM");
			dgv.Columns["SUM/BS/DM"].ValueType = typeof(byte);
			maxValue = byte.MaxValue;
			dgv.Columns["SUM/BS/DM"].ToolTipText = maxValue.ToString() + " <= Value(Numbers) <= " + maxValue.ToString();
			dgv.Columns.Add("RF/FM", "RF/FM");
			dgv.Columns["RF/FM"].ValueType = typeof(byte);
			maxValue = byte.MaxValue;
			dgv.Columns["RF/FM"].ToolTipText = maxValue.ToString() + " <= Value(Numbers) <= " + maxValue.ToString();
			dgv.Columns.Add("Ice Attribute", "Ice Attribute");
			dgv.Columns["Ice Attribute"].ValueType = typeof(byte);
			maxValue = byte.MaxValue;
			dgv.Columns["Ice Attribute"].ToolTipText = maxValue.ToString() + " <= Value(Numbers) <= " + maxValue.ToString();
			dgv.Columns.Add("Poison Attribute", "Poison Attribute");
			dgv.Columns["Poison Attribute"].ValueType = typeof(byte);
			maxValue = byte.MaxValue;
			dgv.Columns["Poison Attribute"].ToolTipText = maxValue.ToString() + " <= Value(Numbers) <= " + maxValue.ToString();
			dgv.Columns.Add("Lightning Attribute", "Lightning Attribute");
			dgv.Columns["Lightning Attribute"].ValueType = typeof(byte);
			maxValue = byte.MaxValue;
			dgv.Columns["Lightning Attribute"].ToolTipText = maxValue.ToString() + " <= Value(Numbers) <= " + maxValue.ToString();
			dgv.Columns.Add("Fire Attribute", "Fire Attribute");
			dgv.Columns["Fire Attribute"].ValueType = typeof(byte);
			maxValue = byte.MaxValue;
			dgv.Columns["Fire Attribute"].ToolTipText = maxValue.ToString() + " <= Value(Numbers) <= " + maxValue.ToString();
			dgv.Columns.Add("Earth Attribute", "Earth Attribute");
			dgv.Columns["Earth Attribute"].ValueType = typeof(byte);
			maxValue = byte.MaxValue;
			dgv.Columns["Earth Attribute"].ToolTipText = maxValue.ToString() + " <= Value(Numbers) <= " + maxValue.ToString();
			dgv.Columns.Add("Wind Attribute", "Wind Attribute");
			dgv.Columns["Wind Attribute"].ValueType = typeof(byte);
			maxValue = byte.MaxValue;
			dgv.Columns["Wind Attribute"].ToolTipText = maxValue.ToString() + " <= Value(Numbers) <= " + maxValue.ToString();
			dgv.Columns.Add("Water Attribute", "Water Attribute");
			dgv.Columns["Water Attribute"].ValueType = typeof(byte);
			maxValue = byte.MaxValue;
			dgv.Columns["Water Attribute"].ToolTipText = maxValue.ToString() + " <= Value(Numbers) <= " + maxValue.ToString();
			dgv.Columns.Add("Unk_5", "Unk_5");
			dgv.Columns["Unk_5"].ValueType = typeof(byte);
			maxValue = byte.MaxValue;
			dgv.Columns["Unk_5"].ToolTipText = maxValue.ToString() + " <= Value(Numbers) <= " + maxValue.ToString();
			dgv.Columns.Add("Unk_6", "Unk_6");
			dgv.Columns["Unk_6"].ValueType = typeof(byte);
			maxValue = byte.MaxValue;
			dgv.Columns["Unk_6"].ToolTipText = maxValue.ToString() + " <= Value(Numbers) <= " + maxValue.ToString();
			dgv.Columns.Add("Unk_7", "Unk_7");
			dgv.Columns["Unk_7"].ValueType = typeof(byte);
			maxValue = byte.MaxValue;
			dgv.Columns["Unk_7"].ToolTipText = maxValue.ToString() + " <= Value(Numbers) <= " + maxValue.ToString();
			dgv.Columns.Add("Unk_8", "Unk_8");
			dgv.Columns["Unk_8"].ValueType = typeof(byte);
			maxValue = byte.MaxValue;
			dgv.Columns["Unk_8"].ToolTipText = maxValue.ToString() + " <= Value(Numbers) <= " + maxValue.ToString();
			dgv.Columns.Add("Unk_9", "Unk_9");
			dgv.Columns["Unk_9"].ValueType = typeof(byte);
			maxValue = byte.MaxValue;
			dgv.Columns["Unk_9"].ToolTipText = maxValue.ToString() + " <= Value(Numbers) <= " + maxValue.ToString();
			dgv.Columns.Add("Unk_10", "Unk_10");
			dgv.Columns["Unk_10"].ValueType = typeof(byte);
			maxValue = byte.MaxValue;
			dgv.Columns["Unk_10"].ToolTipText = maxValue.ToString() + " <= Value(Numbers) <= " + maxValue.ToString();
			dgv.Columns.Add("Unk_11", "Unk_11");
			dgv.Columns["Unk_11"].ValueType = typeof(byte);
			maxValue = byte.MaxValue;
			dgv.Columns["Unk_11"].ToolTipText = maxValue.ToString() + " <= Value(Numbers) <= " + maxValue.ToString();
			dgv.Columns.Add("Unk_12", "Unk_12");
			dgv.Columns["Unk_12"].ValueType = typeof(byte);
			maxValue = byte.MaxValue;
			dgv.Columns["Unk_12"].ToolTipText = maxValue.ToString() + " <= Value(Numbers) <= " + maxValue.ToString();
			dgv.Columns.Add("Unk_13", "Unk_13");
			dgv.Columns["Unk_13"].ValueType = typeof(byte);
			maxValue = byte.MaxValue;
			dgv.Columns["Unk_13"].ToolTipText = maxValue.ToString() + " <= Value(Numbers) <= " + maxValue.ToString();
			foreach (object obj in dgv.Columns)
			{
				DataGridViewColumn dataGridViewColumn = (DataGridViewColumn)obj;
				dataGridViewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
			}
		}

		// Token: 0x060004EB RID: 1259 RVA: 0x0002DEF4 File Offset: 0x0002C0F4
		public void initializeItemSeason8Episode1Grid(DataGridView dgv)
		{
			dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgv.Dock = DockStyle.Fill;
			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToDeleteRows = false;
			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
			dgv.AllowUserToOrderColumns = false;
			dgv.AllowUserToResizeColumns = true;
			dgv.Columns.Add("Unk_1", "Unk_1");
			dgv.Columns["Unk_1"].ValueType = typeof(ushort);
			dgv.Columns["Unk_1"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns.Add("Unk_2", "Unk_2");
			dgv.Columns["Unk_2"].ValueType = typeof(ushort);
			dgv.Columns["Unk_2"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns.Add("Unk_3", "Unk_3");
			dgv.Columns["Unk_3"].ValueType = typeof(byte);
			dgv.Columns["Unk_3"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("Unk_4", "Unk_4");
			dgv.Columns["Unk_4"].ValueType = typeof(byte);
			dgv.Columns["Unk_4"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("Group", "Group");
			dgv.Columns["Group"].ValueType = typeof(ushort);
			dgv.Columns["Group"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns["Group"].ReadOnly = true;
			dgv.Columns["Group"].DefaultCellStyle.BackColor = Color.LightGray;
			dgv.Columns.Add("Index", "Index");
			dgv.Columns["Index"].ValueType = typeof(ushort);
			dgv.Columns["Index"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns["Index"].ReadOnly = true;
			dgv.Columns["Index"].DefaultCellStyle.BackColor = Color.LightGray;
			dgv.Columns.Add("Model Folder", "Model Folder");
			dgv.Columns["Model Folder"].ValueType = typeof(string);
			dgv.Columns["Model Folder"].ToolTipText = "0 <= Value(Chars) <= 260";
			dgv.Columns["Model Folder"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			dgv.Columns["Model Folder"].Width = 150;
			dgv.Columns.Add("Model Name", "Model Name");
			dgv.Columns["Model Name"].ValueType = typeof(string);
			dgv.Columns["Model Name"].ToolTipText = "0 <= Value(Chars) <= 260";
			dgv.Columns["Model Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			dgv.Columns["Model Name"].Width = 150;
			dgv.Columns.Add("Name", "Name");
			dgv.Columns["Name"].ValueType = typeof(string);
			dgv.Columns["Name"].ToolTipText = "0 <= Value(Chars) <= 30";
			dgv.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			dgv.Columns["Name"].Width = 300;
			dgv.Columns.Add("Type", "Type");
			dgv.Columns["Type"].ValueType = typeof(byte);
			dgv.Columns["Type"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("Two Hands", "Two Hands");
			dgv.Columns["Two Hands"].ValueType = typeof(byte);
			dgv.Columns["Two Hands"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("Level", "Level");
			dgv.Columns["Level"].ValueType = typeof(ushort);
			dgv.Columns["Level"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns.Add("Slot", "Slot");
			dgv.Columns["Slot"].ValueType = typeof(ushort);
			dgv.Columns["Slot"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns.Add("Skill", "Skill");
			dgv.Columns["Skill"].ValueType = typeof(ushort);
			dgv.Columns["Skill"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns.Add("X", "X");
			dgv.Columns["X"].ValueType = typeof(byte);
			dgv.Columns["X"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("Y", "Y");
			dgv.Columns["Y"].ValueType = typeof(byte);
			dgv.Columns["Y"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("Min Dmg", "Min Dmg");
			dgv.Columns["Min Dmg"].ValueType = typeof(byte);
			dgv.Columns["Min Dmg"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("Max Dmg", "Max Dmg");
			dgv.Columns["Max Dmg"].ValueType = typeof(byte);
			dgv.Columns["Max Dmg"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("Def Rate", "Def Rate");
			dgv.Columns["Def Rate"].ValueType = typeof(byte);
			dgv.Columns["Def Rate"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("Defense", "Defense");
			dgv.Columns["Defense"].ValueType = typeof(ushort);
			dgv.Columns["Defense"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns.Add("AtkSpeed", "AtkSpeed");
			dgv.Columns["AtkSpeed"].ValueType = typeof(byte);
			dgv.Columns["AtkSpeed"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("WalkSpeed", "WalkSpeed");
			dgv.Columns["WalkSpeed"].ValueType = typeof(byte);
			dgv.Columns["WalkSpeed"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("Durability", "Durability");
			dgv.Columns["Durability"].ValueType = typeof(byte);
			dgv.Columns["Durability"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("MagicDur", "MagicDur");
			dgv.Columns["MagicDur"].ValueType = typeof(byte);
			dgv.Columns["MagicDur"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("MagicPwr", "MagicPwr");
			dgv.Columns["MagicPwr"].ValueType = typeof(byte);
			dgv.Columns["MagicPwr"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("ReqStr", "ReqStr");
			dgv.Columns["ReqStr"].ValueType = typeof(ushort);
			dgv.Columns["ReqStr"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns.Add("ReqDex", "ReqDex");
			dgv.Columns["ReqDex"].ValueType = typeof(ushort);
			dgv.Columns["ReqDex"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns.Add("ReqEne", "ReqEne");
			dgv.Columns["ReqEne"].ValueType = typeof(ushort);
			dgv.Columns["ReqEne"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns.Add("ReqVit", "ReqVit");
			dgv.Columns["ReqVit"].ValueType = typeof(ushort);
			dgv.Columns["ReqVit"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns.Add("ReqLea", "ReqLea");
			dgv.Columns["ReqLea"].ValueType = typeof(ushort);
			dgv.Columns["ReqLea"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns.Add("ReqLvl", "ReqLvl");
			dgv.Columns["ReqLvl"].ValueType = typeof(ushort);
			dgv.Columns["ReqLvl"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns.Add("ItemValue", "ItemValue");
			dgv.Columns["ItemValue"].ValueType = typeof(ushort);
			dgv.Columns["ItemValue"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns.Add("Zen", "Zen");
			dgv.Columns["Zen"].ValueType = typeof(uint);
			uint maxValue = uint.MaxValue;
			dgv.Columns["Zen"].ToolTipText = maxValue.ToString() + " <= Value(Numbers) <= " + maxValue.ToString();
			dgv.Columns.Add("SetOption", "SetOption");
			dgv.Columns["SetOption"].ValueType = typeof(byte);
			byte maxValue2 = byte.MaxValue;
			dgv.Columns["SetOption"].ToolTipText = maxValue2.ToString() + " <= Value(Numbers) <= " + maxValue2.ToString();
			dgv.Columns.Add("DW/SM/GM", "DW/SM/GM");
			dgv.Columns["DW/SM/GM"].ValueType = typeof(byte);
			maxValue2 = byte.MaxValue;
			dgv.Columns["DW/SM/GM"].ToolTipText = maxValue2.ToString() + " <= Value(Numbers) <= " + maxValue2.ToString();
			dgv.Columns.Add("DK/BK/BM", "DK/BK/BM");
			dgv.Columns["DK/BK/BM"].ValueType = typeof(byte);
			maxValue2 = byte.MaxValue;
			dgv.Columns["DK/BK/BM"].ToolTipText = maxValue2.ToString() + " <= Value(Numbers) <= " + maxValue2.ToString();
			dgv.Columns.Add("Elf/ME/HE", "Elf/ME/HE");
			dgv.Columns["Elf/ME/HE"].ValueType = typeof(byte);
			maxValue2 = byte.MaxValue;
			dgv.Columns["Elf/ME/HE"].ToolTipText = maxValue2.ToString() + " <= Value(Numbers) <= " + maxValue2.ToString();
			dgv.Columns.Add("MG/DM", "MG/DM");
			dgv.Columns["MG/DM"].ValueType = typeof(byte);
			maxValue2 = byte.MaxValue;
			dgv.Columns["MG/DM"].ToolTipText = maxValue2.ToString() + " <= Value(Numbers) <= " + maxValue2.ToString();
			dgv.Columns.Add("DL/LE", "DL/LE");
			dgv.Columns["DL/LE"].ValueType = typeof(byte);
			maxValue2 = byte.MaxValue;
			dgv.Columns["DL/LE"].ToolTipText = maxValue2.ToString() + " <= Value(Numbers) <= " + maxValue2.ToString();
			dgv.Columns.Add("SUM/BS/DM", "SUM/BS/DM");
			dgv.Columns["SUM/BS/DM"].ValueType = typeof(byte);
			maxValue2 = byte.MaxValue;
			dgv.Columns["SUM/BS/DM"].ToolTipText = maxValue2.ToString() + " <= Value(Numbers) <= " + maxValue2.ToString();
			dgv.Columns.Add("RF/FM", "RF/FM");
			dgv.Columns["RF/FM"].ValueType = typeof(byte);
			maxValue2 = byte.MaxValue;
			dgv.Columns["RF/FM"].ToolTipText = maxValue2.ToString() + " <= Value(Numbers) <= " + maxValue2.ToString();
			dgv.Columns.Add("Ice Attribute", "Ice Attribute");
			dgv.Columns["Ice Attribute"].ValueType = typeof(byte);
			maxValue2 = byte.MaxValue;
			dgv.Columns["Ice Attribute"].ToolTipText = maxValue2.ToString() + " <= Value(Numbers) <= " + maxValue2.ToString();
			dgv.Columns.Add("Poison Attribute", "Poison Attribute");
			dgv.Columns["Poison Attribute"].ValueType = typeof(byte);
			maxValue2 = byte.MaxValue;
			dgv.Columns["Poison Attribute"].ToolTipText = maxValue2.ToString() + " <= Value(Numbers) <= " + maxValue2.ToString();
			dgv.Columns.Add("Lightning Attribute", "Lightning Attribute");
			dgv.Columns["Lightning Attribute"].ValueType = typeof(byte);
			maxValue2 = byte.MaxValue;
			dgv.Columns["Lightning Attribute"].ToolTipText = maxValue2.ToString() + " <= Value(Numbers) <= " + maxValue2.ToString();
			dgv.Columns.Add("Fire Attribute", "Fire Attribute");
			dgv.Columns["Fire Attribute"].ValueType = typeof(byte);
			maxValue2 = byte.MaxValue;
			dgv.Columns["Fire Attribute"].ToolTipText = maxValue2.ToString() + " <= Value(Numbers) <= " + maxValue2.ToString();
			dgv.Columns.Add("Earth Attribute", "Earth Attribute");
			dgv.Columns["Earth Attribute"].ValueType = typeof(byte);
			maxValue2 = byte.MaxValue;
			dgv.Columns["Earth Attribute"].ToolTipText = maxValue2.ToString() + " <= Value(Numbers) <= " + maxValue2.ToString();
			dgv.Columns.Add("Wind Attribute", "Wind Attribute");
			dgv.Columns["Wind Attribute"].ValueType = typeof(byte);
			maxValue2 = byte.MaxValue;
			dgv.Columns["Wind Attribute"].ToolTipText = maxValue2.ToString() + " <= Value(Numbers) <= " + maxValue2.ToString();
			dgv.Columns.Add("Water Attribute", "Water Attribute");
			dgv.Columns["Water Attribute"].ValueType = typeof(byte);
			maxValue2 = byte.MaxValue;
			dgv.Columns["Water Attribute"].ToolTipText = maxValue2.ToString() + " <= Value(Numbers) <= " + maxValue2.ToString();
			for (int i = 5; i < 22; i++)
			{
				dgv.Columns.Add("Unk_" + i, "Unk_" + i);
				dgv.Columns["Unk_" + i].ValueType = typeof(byte);
				maxValue2 = byte.MaxValue;
				dgv.Columns["Unk_" + i].ToolTipText = maxValue2.ToString() + " <= Value(Numbers) <= " + maxValue2.ToString();
			}
			foreach (object obj in dgv.Columns)
			{
				DataGridViewColumn dataGridViewColumn = (DataGridViewColumn)obj;
				dataGridViewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
			}
		}

		// Token: 0x060004EC RID: 1260 RVA: 0x0002F4F0 File Offset: 0x0002D6F0
		private void initializeItemSetOptionGrid(DataGridView dgv)
		{
			dgv.Dock = DockStyle.Fill;
			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToDeleteRows = false;
			dgv.AllowUserToOrderColumns = false;
			dgv.AllowUserToResizeColumns = true;
			dgv.Columns.Add("Name", "Name");
			dgv.Columns["Name"].ValueType = typeof(string);
			dgv.Columns["Name"].ToolTipText = 0.ToString() + "0 <= Value(Chars) <= 64" + byte.MaxValue.ToString();
			for (int i = 1; i <= 46; i++)
			{
				dgv.Columns.Add("v" + i, "v" + i);
				dgv.Columns["v" + i].ValueType = typeof(byte);
				dgv.Columns["v" + i].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
				dgv.Columns["v" + i].Width = 30;
			}
			foreach (object obj in dgv.Columns)
			{
				DataGridViewColumn dataGridViewColumn = (DataGridViewColumn)obj;
				dataGridViewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
				if (dataGridViewColumn.Name == "Name")
				{
					dataGridViewColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
					dataGridViewColumn.Width = 300;
				}
			}
		}

		// Token: 0x060004ED RID: 1261 RVA: 0x0002F6D0 File Offset: 0x0002D8D0
		private void initializeItemToolTipTextGrid(DataGridView dgv)
		{
			dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgv.Dock = DockStyle.Fill;
			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToDeleteRows = false;
			dgv.AllowUserToOrderColumns = false;
			dgv.AllowUserToResizeColumns = true;
			dgv.Columns.Add("Code", "Code");
			dgv.Columns["Code"].ValueType = typeof(ushort);
			dgv.Columns["Code"].ToolTipText = 0 + " <= Value <= " + ushort.MaxValue;
			dgv.Columns.Add("Text", "Text");
			dgv.Columns["Text"].ValueType = typeof(string);
			dgv.Columns["Text"].ToolTipText = "Maximum 258 Chars";
			dgv.Columns["Text"].Width = 512;
			dgv.Columns["Text"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			dgv.Columns.Add("Unk", "Unk");
			dgv.Columns["Unk"].ValueType = typeof(ushort);
			dgv.Columns["Unk"].ToolTipText = 0 + " <= Value <= " + ushort.MaxValue;
			foreach (object obj in dgv.Columns)
			{
				DataGridViewColumn dataGridViewColumn = (DataGridViewColumn)obj;
				dataGridViewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
			}
		}

		// Token: 0x060004EE RID: 1262 RVA: 0x0002F89C File Offset: 0x0002DA9C
		public void initializeITTGrid(DataGridView dgv)
		{
			dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgv.Dock = DockStyle.Fill;
			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToDeleteRows = false;
			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
			dgv.AllowUserToOrderColumns = false;
			dgv.AllowUserToResizeColumns = true;
			dgv.Columns.Add("Group", "Group");
			dgv.Columns["Group"].ValueType = typeof(ushort);
			dgv.Columns["Group"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns["Group"].ReadOnly = true;
			dgv.Columns["Group"].DefaultCellStyle.BackColor = Color.LightGray;
			dgv.Columns.Add("Index", "Index");
			dgv.Columns["Index"].ValueType = typeof(ushort);
			dgv.Columns["Index"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns.Add("Name", "Name");
			dgv.Columns["Name"].ValueType = typeof(string);
			dgv.Columns["Name"].ToolTipText = "0 <= Value(Chars) <= 64";
			dgv.Columns.Add("Color", "Color");
			dgv.Columns["Color"].ValueType = typeof(short);
			dgv.Columns["Color"].ToolTipText = short.MinValue.ToString() + " <= Value(Numbers) <= " + short.MaxValue.ToString();
			DataGridViewColumn dataGridViewColumn = dgv.Columns["Color"];
			dataGridViewColumn.ToolTipText += "\n\nIs the color:\n256 = normal\n257 = blue\n258 = red\n259 = gold\n260 = green\n261 = red BG\n262 = archangel\n263 = blue BG\n264 = orange BG\n265 = blue exc\n266 = gray\n267 = light pink\n268 = socket\n269 = orange\n270 = unknown";
			for (int i = 1; i <= 3; i++)
			{
				dgv.Columns.Add("Unk_" + i, "Unk_" + i);
				dgv.Columns["Unk_" + i].ValueType = typeof(short);
				dgv.Columns["Unk_" + i].ToolTipText = short.MinValue.ToString() + " <= Value(Numbers) <= " + short.MaxValue.ToString();
			}
			int num = 4;
			for (int j = 1; j <= 12; j++)
			{
				dgv.Columns.Add("iInfoLine_" + j, "iInfoLine_" + j);
				dgv.Columns["iInfoLine_" + j].ValueType = typeof(short);
				dgv.Columns["iInfoLine_" + j].ToolTipText = short.MinValue.ToString() + " <= Value(Numbers) <= " + short.MaxValue.ToString();
				DataGridViewColumn dataGridViewColumn2 = dgv.Columns["iInfoLine_" + j];
				dataGridViewColumn2.ToolTipText += "\n\nIs the index from ItemToolTipText";
				dgv.Columns.Add("Unk_" + num, "Unk_" + num);
				dgv.Columns["Unk_" + num].ValueType = typeof(short);
				dgv.Columns["Unk_" + num].ToolTipText = short.MinValue.ToString() + " <= Value(Numbers) <= " + short.MaxValue.ToString();
				num++;
			}
			foreach (object obj in dgv.Columns)
			{
				DataGridViewColumn dataGridViewColumn3 = (DataGridViewColumn)obj;
				dataGridViewColumn3.SortMode = DataGridViewColumnSortMode.NotSortable;
				if (dataGridViewColumn3.Name == "Name")
				{
					dataGridViewColumn3.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
					dataGridViewColumn3.Width = 300;
				}
			}
		}

		// Token: 0x060004EF RID: 1263 RVA: 0x0002FD80 File Offset: 0x0002DF80
		public void initializeJOHSGrid(DataGridView dgv)
		{
			dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgv.Dock = DockStyle.Fill;
			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToDeleteRows = false;
			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
			dgv.AllowUserToOrderColumns = false;
			dgv.AllowUserToResizeColumns = true;
			dgv.Columns.Add("Group", "Group");
			dgv.Columns["Group"].ReadOnly = true;
			dgv.Columns["Group"].DefaultCellStyle.BackColor = Color.LightGray;
			dgv.Columns.Add("Index", "Index");
			dgv.Columns["Index"].ReadOnly = true;
			dgv.Columns["Index"].DefaultCellStyle.BackColor = Color.LightGray;
			dgv.Columns.Add("v1", "v1");
			dgv.Columns["v1"].ValueType = typeof(int);
			dgv.Columns["v1"].ToolTipText = int.MinValue.ToString() + " <= Value(Numbers) <= " + int.MaxValue.ToString();
			dgv.Columns.Add("Name", "Name");
			dgv.Columns["Name"].ValueType = typeof(string);
			dgv.Columns["Name"].ToolTipText = "0 <= Value(Chars) <= 59";
			dgv.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			dgv.Columns["Name"].Width = 200;
			dgv.Columns.Add("v2", "v2");
			dgv.Columns["v2"].ValueType = typeof(int);
			dgv.Columns["v2"].ToolTipText = int.MinValue.ToString() + " <= Value(Numbers) <= " + int.MaxValue.ToString();
		}

		// Token: 0x060004F0 RID: 1264 RVA: 0x0002FFB0 File Offset: 0x0002E1B0
		private void initializeMinimapGrid(DataGridView dgv)
		{
			dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgv.Dock = DockStyle.Fill;
			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToDeleteRows = false;
			dgv.AllowUserToOrderColumns = false;
			dgv.AllowUserToResizeColumns = true;
			dgv.Columns.Add("Type", "Type");
			dgv.Columns["Type"].ValueType = typeof(uint);
			dgv.Columns["Type"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + uint.MaxValue.ToString();
			dgv.Columns.Add("X", "X");
			dgv.Columns["X"].ValueType = typeof(uint);
			dgv.Columns["X"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + uint.MaxValue.ToString();
			dgv.Columns["X"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			dgv.Columns["X"].Width = 50;
			dgv.Columns.Add("Y", "Y");
			dgv.Columns["Y"].ValueType = typeof(uint);
			dgv.Columns["Y"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + uint.MaxValue.ToString();
			dgv.Columns["Y"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			dgv.Columns["Y"].Width = 50;
			dgv.Columns.Add("Rotation Angle", "Rotation Angle");
			dgv.Columns["Rotation Angle"].ValueType = typeof(uint);
			dgv.Columns["Rotation Angle"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + uint.MaxValue.ToString();
			dgv.Columns.Add("Name", "Name");
			dgv.Columns["Name"].ValueType = typeof(string);
			dgv.Columns["Name"].ToolTipText = "0 <= Value(Chars) <= 100";
			dgv.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			dgv.Columns["Name"].Width = 300;
			foreach (object obj in dgv.Columns)
			{
				DataGridViewColumn dataGridViewColumn = (DataGridViewColumn)obj;
				dataGridViewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
			}
		}

		// Token: 0x060004F1 RID: 1265 RVA: 0x000302B8 File Offset: 0x0002E4B8
		private void initializeMixGrid(DataGridView dgv)
		{
			dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgv.Dock = DockStyle.Fill;
			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToDeleteRows = false;
			dgv.AllowUserToOrderColumns = false;
			dgv.AllowUserToResizeColumns = true;
			DataGridViewComboBoxColumn dataGridViewComboBoxColumn = new DataGridViewComboBoxColumn
			{
				Name = "MixGroup",
				DisplayIndex = 0
			};
			dataGridViewComboBoxColumn.HeaderText = dataGridViewComboBoxColumn.Name;
			for (int i = 1; i < 15; i++)
			{
				dataGridViewComboBoxColumn.Items.Add(i.ToString());
			}
			dgv.Columns.Add(dataGridViewComboBoxColumn);
			for (int j = 1; j < 15; j++)
			{
				string columnName = j.ToString();
				dgv.Columns.Add(columnName, j.ToString());
				dgv.Columns[j].ValueType = typeof(uint);
				dgv.Columns[j].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + uint.MaxValue.ToString();
			}
			dgv.Columns.Add("15", "15");
			dgv.Columns[15].ValueType = typeof(uint);
			dgv.Columns[15].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + uint.MaxValue.ToString();
			for (int k = 16; k < 18; k++)
			{
				string columnName2 = k.ToString();
				dgv.Columns.Add(columnName2, k.ToString());
				dgv.Columns[k].ValueType = typeof(uint);
				dgv.Columns[k].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + uint.MaxValue.ToString();
			}
			int num = 18;
			for (int l = 0; l < 32; l++)
			{
				string columnName3 = num.ToString();
				dgv.Columns.Add(columnName3, num.ToString());
				dgv.Columns[num].ValueType = typeof(uint);
				dgv.Columns[num].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + uint.MaxValue.ToString();
				num++;
				string columnName4 = num.ToString();
				dgv.Columns.Add(columnName4, num.ToString());
				dgv.Columns[num].ValueType = typeof(float);
				dgv.Columns[num].ToolTipText = float.MinValue.ToString() + " <= Value(Numbers) <= " + float.MaxValue.ToString();
				num++;
			}
			dgv.Columns.Add("82", "82");
			dgv.Columns[82].ValueType = typeof(uint);
			dgv.Columns[82].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + uint.MaxValue.ToString();
			for (int m = 83; m < 91; m++)
			{
				string columnName5 = m.ToString();
				dgv.Columns.Add(columnName5, m.ToString());
				dgv.Columns[m].ValueType = typeof(byte);
				dgv.Columns[m].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			}
			int num2 = 91;
			for (int n = 0; n < 8; n++)
			{
				for (int num3 = 0; num3 < 2; num3++)
				{
					string columnName6 = num2.ToString();
					dgv.Columns.Add(columnName6, num2.ToString());
					dgv.Columns[num2].ValueType = typeof(short);
					dgv.Columns[num2].ToolTipText = short.MinValue.ToString() + " <= Value(Numbers) <= " + short.MaxValue.ToString();
					num2++;
				}
				for (int num4 = 0; num4 < 9; num4++)
				{
					string columnName7 = num2.ToString();
					dgv.Columns.Add(columnName7, num2.ToString());
					dgv.Columns[num2].ValueType = typeof(uint);
					dgv.Columns[num2].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + uint.MaxValue.ToString();
					num2++;
				}
			}
			string columnName8 = num2.ToString();
			dgv.Columns.Add(columnName8, num2.ToString());
			dgv.Columns[num2].ValueType = typeof(uint);
			dgv.Columns[num2].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + uint.MaxValue.ToString();
			int num5 = 1;
			dgv.Columns[num5].Name = "MixID";
			dgv.Columns[num5].HeaderText = dgv.Columns[num5].Name;
			num5++;
			dgv.Columns[num5].Name = "HeadCode";
			dgv.Columns[num5].HeaderText = dgv.Columns[num5].Name;
			num5++;
			dgv.Columns[num5].Name = "MixInfo1";
			dgv.Columns[num5].HeaderText = dgv.Columns[num5].Name;
			num5++;
			dgv.Columns[num5].Name = "MixInfo2";
			dgv.Columns[num5].HeaderText = dgv.Columns[num5].Name;
			num5++;
			dgv.Columns[num5].Name = "MixInfo3";
			dgv.Columns[num5].HeaderText = dgv.Columns[num5].Name;
			num5++;
			dgv.Columns[num5].Name = "BadMixInfo1";
			dgv.Columns[num5].HeaderText = dgv.Columns[num5].Name;
			num5++;
			dgv.Columns[num5].Name = "BadMixInfo2";
			dgv.Columns[num5].HeaderText = dgv.Columns[num5].Name;
			num5++;
			dgv.Columns[num5].Name = "BadMixInfo3";
			dgv.Columns[num5].HeaderText = dgv.Columns[num5].Name;
			num5++;
			dgv.Columns[num5].Name = "GoodMixInfo1";
			dgv.Columns[num5].HeaderText = dgv.Columns[num5].Name;
			num5++;
			dgv.Columns[num5].Name = "GoodMixInfo2";
			dgv.Columns[num5].HeaderText = dgv.Columns[num5].Name;
			num5++;
			dgv.Columns[num5].Name = "GoodMixInfo3";
			dgv.Columns[num5].HeaderText = dgv.Columns[num5].Name;
			num5++;
			dgv.Columns[num5].Name = "Height";
			dgv.Columns[num5].HeaderText = dgv.Columns[num5].Name;
			num5++;
			dgv.Columns[num5].Name = "Width";
			dgv.Columns[num5].HeaderText = dgv.Columns[num5].Name;
			num5++;
			dgv.Columns[num5].Name = "MinLvl";
			dgv.Columns[num5].HeaderText = dgv.Columns[num5].Name;
			num5++;
			dgv.Columns[num5].Name = "MoneyRule";
			dgv.Columns[num5].HeaderText = dgv.Columns[num5].Name;
			num5++;
			dgv.Columns[num5].Name = "ReqMoney";
			dgv.Columns[num5].HeaderText = dgv.Columns[num5].Name;
			num5++;
			dgv.Columns[num5].Name = "RulesUsed";
			dgv.Columns[num5].HeaderText = dgv.Columns[num5].Name;
			num5++;
			for (int num6 = 0; num6 < 32; num6++)
			{
				dgv.Columns[num5].Name = "RuleID";
				dgv.Columns[num5].HeaderText = dgv.Columns[num5].Name;
				num5++;
				dgv.Columns[num5].Name = "Div";
				dgv.Columns[num5].HeaderText = dgv.Columns[num5].Name;
				num5++;
			}
			dgv.Columns[num5].Name = "MaxSuccessRate";
			dgv.Columns[num5].HeaderText = dgv.Columns[num5].Name;
			num5++;
			dgv.Columns[num5].Name = "Uk1";
			dgv.Columns[num5].HeaderText = dgv.Columns[num5].Name;
			num5++;
			dgv.Columns[num5].Name = "TalismanOfLuck";
			dgv.Columns[num5].HeaderText = dgv.Columns[num5].Name;
			num5++;
			dgv.Columns[num5].Name = "Uk2";
			dgv.Columns[num5].HeaderText = dgv.Columns[num5].Name;
			num5++;
			dgv.Columns[num5].Name = "Uk3";
			dgv.Columns[num5].HeaderText = dgv.Columns[num5].Name;
			num5++;
			dgv.Columns[num5].Name = "Uk4";
			dgv.Columns[num5].HeaderText = dgv.Columns[num5].Name;
			num5++;
			dgv.Columns[num5].Name = "Uk5";
			dgv.Columns[num5].HeaderText = dgv.Columns[num5].Name;
			num5++;
			dgv.Columns[num5].Name = "Uk6";
			dgv.Columns[num5].HeaderText = dgv.Columns[num5].Name;
			num5++;
			dgv.Columns[num5].Name = "Uk7";
			dgv.Columns[num5].HeaderText = dgv.Columns[num5].Name;
			num5++;
			for (int num7 = 0; num7 < 8; num7++)
			{
				dgv.Columns[num5].Name = "StartId";
				dgv.Columns[num5].HeaderText = dgv.Columns[num5].Name;
				num5++;
				dgv.Columns[num5].Name = "EndId";
				dgv.Columns[num5].HeaderText = dgv.Columns[num5].Name;
				num5++;
				dgv.Columns[num5].Name = "MinLvl";
				dgv.Columns[num5].HeaderText = dgv.Columns[num5].Name;
				num5++;
				dgv.Columns[num5].Name = "MaxLvl";
				dgv.Columns[num5].HeaderText = dgv.Columns[num5].Name;
				num5++;
				dgv.Columns[num5].Name = "MinOpt";
				dgv.Columns[num5].HeaderText = dgv.Columns[num5].Name;
				num5++;
				dgv.Columns[num5].Name = "MaxOpt";
				dgv.Columns[num5].HeaderText = dgv.Columns[num5].Name;
				num5++;
				dgv.Columns[num5].Name = "MinDurability";
				dgv.Columns[num5].HeaderText = dgv.Columns[num5].Name;
				num5++;
				dgv.Columns[num5].Name = "MaxDurabiltiy";
				dgv.Columns[num5].HeaderText = dgv.Columns[num5].Name;
				num5++;
				dgv.Columns[num5].Name = "MinCnt";
				dgv.Columns[num5].HeaderText = dgv.Columns[num5].Name;
				num5++;
				dgv.Columns[num5].Name = "MaxCnt";
				dgv.Columns[num5].HeaderText = dgv.Columns[num5].Name;
				num5++;
				dgv.Columns[num5].Name = "ItemType";
				dgv.Columns[num5].HeaderText = dgv.Columns[num5].Name;
				num5++;
			}
			dgv.Columns[num5].Name = "MixItemUsed";
			dgv.Columns[num5].HeaderText = dgv.Columns[num5].Name;
			num5++;
			foreach (object obj in dgv.Columns)
			{
				DataGridViewColumn dataGridViewColumn = (DataGridViewColumn)obj;
				dataGridViewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
			}
		}

		// Token: 0x060004F2 RID: 1266 RVA: 0x000312BC File Offset: 0x0002F4BC
		private void initializeMonsterGrid(DataGridView dgv)
		{
			dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgv.Dock = DockStyle.Fill;
			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToDeleteRows = false;
			dgv.Columns.Add("Model ID (1)", "Model ID (1)");
			dgv.Columns["Model ID (1)"].ValueType = typeof(uint);
			dgv.Columns["Model ID (1)"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + uint.MaxValue.ToString();
			dgv.Columns.Add("Model Path", "Model Path");
			dgv.Columns["Model Path"].ValueType = typeof(string);
			dgv.Columns["Model Path"].ToolTipText = "0 <= Value(Cahrs) <= 64";
			dgv.Columns.Add("Model Name", "Model Name");
			dgv.Columns["Model Name"].ValueType = typeof(string);
			dgv.Columns["Model Name"].ToolTipText = "0 <= Value(Cahrs) <= 32";
			dgv.Columns.Add("Monster ID", "Monster ID");
			dgv.Columns["Monster ID"].ValueType = typeof(uint);
			dgv.Columns["Monster ID"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + uint.MaxValue.ToString();
			dgv.Columns.Add("Monster Name", "Monster Name");
			dgv.Columns["Monster Name"].ValueType = typeof(string);
			dgv.Columns["Monster Name"].ToolTipText = "0 <= Value(Cahrs) <= 32";
			dgv.Columns.Add("Model ID (2)", "Model ID (2)");
			dgv.Columns["Model ID (2)"].ValueType = typeof(ushort);
			dgv.Columns["Model ID (2)"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns.Add("NPC?", "NPC?");
			dgv.Columns["NPC?"].ValueType = typeof(byte);
			dgv.Columns["NPC?"].ToolTipText = "0 or 1";
			dgv.Columns.Add("Scale", "Scale");
			dgv.Columns["Scale"].ValueType = typeof(float);
			dgv.Columns["Scale"].ToolTipText = float.MinValue.ToString() + " <= Value(Numbers) <= " + float.MaxValue.ToString();
			dgv.Columns.Add("Glow Power", "Glow Power");
			dgv.Columns["Glow Power"].ValueType = typeof(float);
			dgv.Columns["Glow Power"].ToolTipText = "0 <= Value(Numbers) <= 1";
			dgv.Columns.Add("R Color", "R Color");
			dgv.Columns["R Color"].ValueType = typeof(byte);
			dgv.Columns["R Color"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("G Color", "G Color");
			dgv.Columns["G Color"].ValueType = typeof(byte);
			dgv.Columns["G Color"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			dgv.Columns.Add("B Color", "B Color");
			dgv.Columns["B Color"].ValueType = typeof(byte);
			dgv.Columns["B Color"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
		}

		// Token: 0x060004F3 RID: 1267 RVA: 0x0003175C File Offset: 0x0002F95C
		private void initializeMRGrid(DataGridView dgv)
		{
			dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgv.Dock = DockStyle.Fill;
			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToDeleteRows = false;
			dgv.Columns.Add("Index", "Index");
			dgv.Columns["Index"].ValueType = typeof(uint);
			dgv.Columns["Index"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + uint.MaxValue.ToString();
			dgv.Columns.Add("Client Name", "Client Name");
			dgv.Columns["Client Name"].ValueType = typeof(string);
			dgv.Columns["Client Name"].ToolTipText = "0 <= Value(Chars) <= 32";
			dgv.Columns.Add("Server Name", "Server Name");
			dgv.Columns["Server Name"].ValueType = typeof(string);
			dgv.Columns["Server Name"].ToolTipText = "0 <= Value(Chars) <= 32";
			dgv.Columns.Add("Min Level", "Min Level");
			dgv.Columns["Min Level"].ValueType = typeof(uint);
			dgv.Columns["Min Level"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + uint.MaxValue.ToString();
			dgv.Columns.Add("Max Level", "Max Level");
			dgv.Columns["Max Level"].ValueType = typeof(uint);
			dgv.Columns["Max Level"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + uint.MaxValue.ToString();
			dgv.Columns.Add("Required Zen", "Required Zen");
			dgv.Columns["Required Zen"].ValueType = typeof(uint);
			dgv.Columns["Required Zen"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + uint.MaxValue.ToString();
			dgv.Columns.Add("Gate Number", "Gate Number");
			dgv.Columns["Gate Number"].ValueType = typeof(uint);
			dgv.Columns["Gate Number"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + uint.MaxValue.ToString();
		}

		// Token: 0x060004F4 RID: 1268 RVA: 0x00031A28 File Offset: 0x0002FC28
		private void initializeNPCNGrid(DataGridView dgv)
		{
			dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			dgv.Dock = DockStyle.Fill;
			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToDeleteRows = false;
			dgv.Columns.Add("ID", "ID");
			dgv.Columns["ID"].ValueType = typeof(int);
			dgv.Columns["ID"].ToolTipText = int.MinValue.ToString() + " <= Value(Numbers) <= " + int.MaxValue.ToString();
			dgv.Columns["ID"].Width = 50;
			dgv.Columns.Add("Unk_1", "Unk_1");
			dgv.Columns["Unk_1"].ValueType = typeof(uint);
			dgv.Columns["Unk_1"].ToolTipText = int.MinValue.ToString() + " <= Value(Numbers) <= " + int.MaxValue.ToString();
			dgv.Columns["Unk_1"].Width = 50;
			dgv.Columns.Add("Name", "Name");
			dgv.Columns["Name"].ValueType = typeof(string);
			dgv.Columns["Name"].ToolTipText = "0 <= Value(Chars) <= 256";
			dgv.Columns["Name"].Width = 512;
		}

		// Token: 0x060004F5 RID: 1269 RVA: 0x00031BC4 File Offset: 0x0002FDC4
		private void initializeNPCNPlusGrid(DataGridView dgv)
		{
			dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			dgv.Dock = DockStyle.Fill;
			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToDeleteRows = false;
			dgv.Columns.Add("ID", "ID");
			dgv.Columns["ID"].ValueType = typeof(ushort);
			dgv.Columns["ID"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns["ID"].Width = 50;
			dgv.Columns.Add("Unk_1", "Unk_1");
			dgv.Columns["Unk_1"].ValueType = typeof(ushort);
			dgv.Columns["Unk_1"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			dgv.Columns["Unk_1"].Width = 50;
			dgv.Columns.Add("Name", "Name");
			dgv.Columns["Name"].ValueType = typeof(string);
			dgv.Columns["Name"].ToolTipText = "0 <= Value(Chars) <= 256";
			dgv.Columns["Name"].Width = 512;
		}

		// Token: 0x060004F6 RID: 1270 RVA: 0x00031D58 File Offset: 0x0002FF58
		private void initializeServerListEx700Grid(DataGridView dgv)
		{
			dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgv.Dock = DockStyle.Fill;
			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToDeleteRows = false;
			dgv.AllowUserToOrderColumns = false;
			dgv.AllowUserToResizeColumns = true;
			dgv.Columns.Add("Code", "Code");
			dgv.Columns["Code"].ValueType = typeof(uint);
			dgv.Columns["Code"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + uint.MaxValue.ToString();
			dgv.Columns.Add("Name", "Name");
			dgv.Columns["Name"].ValueType = typeof(string);
			dgv.Columns["Name"].ToolTipText = "0 <= Value(Chars) <= 32";
			dgv.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			dgv.Columns["Name"].Width = 300;
			dgv.Columns.Add("Pos.", "Pos.");
			dgv.Columns["Pos."].ValueType = typeof(byte);
			dgv.Columns["Pos."].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString() + "\nThe server position (Sequence [1 = First, 2 = Second, etc..]).";
			for (int i = 1; i < 21; i++)
			{
				dgv.Columns.Add("Server_" + i, "Server_" + i);
				dgv.Columns["Server_" + i].ValueType = typeof(byte);
				dgv.Columns["Server_" + i].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString() + "\n[0 = Normal PVP, 1 = Normal Non-PVP, 2 = Gold PVP, 3 = Gold Non-PVP]";
			}
			for (int j = 2; j < 6; j++)
			{
				dgv.Columns.Add("Unk_" + j, "Unk_" + j);
				dgv.Columns["Unk_" + j].ValueType = typeof(byte);
				dgv.Columns["Unk_" + j].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			}
			foreach (object obj in dgv.Columns)
			{
				DataGridViewColumn dataGridViewColumn = (DataGridViewColumn)obj;
				dataGridViewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
			}
		}

		// Token: 0x060004F7 RID: 1271 RVA: 0x0003209C File Offset: 0x0003029C
		private void initializeServerListS6E3Grid(DataGridView dgv)
		{
			dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgv.Dock = DockStyle.Fill;
			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToDeleteRows = false;
			dgv.AllowUserToOrderColumns = false;
			dgv.AllowUserToResizeColumns = true;
			dgv.Columns.Add("Code", "Code");
			dgv.Columns["Code"].ValueType = typeof(uint);
			dgv.Columns["Code"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + uint.MaxValue.ToString();
			dgv.Columns.Add("Name", "Name");
			dgv.Columns["Name"].ValueType = typeof(string);
			dgv.Columns["Name"].ToolTipText = "0 <= Value(Chars) <= 32";
			dgv.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			dgv.Columns["Name"].Width = 300;
			dgv.Columns.Add("Pos.", "Pos.");
			dgv.Columns["Pos."].ValueType = typeof(byte);
			dgv.Columns["Pos."].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString() + "\nThe server position (Sequence [1 = First, 2 = Second, etc..]).";
			for (int i = 1; i < 16; i++)
			{
				dgv.Columns.Add("Server_" + i, "Server_" + i);
				dgv.Columns["Server_" + i].ValueType = typeof(byte);
				dgv.Columns["Server_" + i].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
				dgv.Columns["Server_" + i].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString() + "\n[0 = Normal PVP, 1 = Normal Non-PVP, 2 = Gold PVP, 3 = Gold Non-PVP]";
			}
			for (int j = 2; j < 6; j++)
			{
				dgv.Columns.Add("Unk_" + j, "Unk_" + j);
				dgv.Columns["Unk_" + j].ValueType = typeof(byte);
				dgv.Columns["Unk_" + j].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			}
			foreach (object obj in dgv.Columns)
			{
				DataGridViewColumn dataGridViewColumn = (DataGridViewColumn)obj;
				dataGridViewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
			}
		}

		// Token: 0x060004F8 RID: 1272 RVA: 0x00032420 File Offset: 0x00030620
		private void initializeSkill_ExS8E1Grid(DataGridView dgv)
		{
			dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgv.Dock = DockStyle.Fill;
			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToDeleteRows = false;
			dgv.AllowUserToOrderColumns = false;
			dgv.AllowUserToResizeColumns = true;
			dgv.Columns.Add("Name", "Name");
			dgv.Columns[0].ValueType = typeof(string);
			dgv.Columns[0].ToolTipText = "Maximum 32 Chars";
			dgv.Columns[0].Width = 128;
			dgv.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			for (int i = 1; i < 5; i++)
			{
				string columnName = i.ToString();
				dgv.Columns.Add(columnName, i.ToString());
				dgv.Columns[i].ValueType = typeof(ushort);
				dgv.Columns[i].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			}
			for (int j = 5; j < 8; j++)
			{
				string columnName2 = j.ToString();
				dgv.Columns.Add(columnName2, j.ToString());
				dgv.Columns[j].ValueType = typeof(uint);
				dgv.Columns[j].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + uint.MaxValue.ToString();
			}
			dgv.Columns.Add("8", "8");
			dgv.Columns[8].ValueType = typeof(ushort);
			dgv.Columns[8].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			for (int k = 9; k < 51; k++)
			{
				string columnName3 = k.ToString();
				dgv.Columns.Add(columnName3, k.ToString());
				dgv.Columns[k].ValueType = typeof(byte);
				dgv.Columns[k].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			}
			int num = 1;
			dgv.Columns[num].Name = "SkillLevel";
			dgv.Columns[num].HeaderText = dgv.Columns[num].Name;
			num++;
			dgv.Columns[num].Name = "Damage";
			dgv.Columns[num].HeaderText = dgv.Columns[num].Name;
			num++;
			dgv.Columns[num].Name = "Mana";
			dgv.Columns[num].HeaderText = dgv.Columns[num].Name;
			num++;
			dgv.Columns[num].Name = "Agility";
			dgv.Columns[num].HeaderText = dgv.Columns[num].Name;
			num++;
			dgv.Columns[num].Name = "Distance";
			dgv.Columns[num].HeaderText = dgv.Columns[num].Name;
			num++;
			dgv.Columns[num].Name = "TimeDelay";
			dgv.Columns[num].HeaderText = dgv.Columns[num].Name;
			num++;
			dgv.Columns[num].Name = "Req.Energy";
			dgv.Columns[num].HeaderText = dgv.Columns[num].Name;
			num++;
			dgv.Columns[num].Name = "Req.Level";
			dgv.Columns[num].HeaderText = dgv.Columns[num].Name;
			num++;
			dgv.Columns[num].Name = "Property";
			dgv.Columns[num].HeaderText = dgv.Columns[num].Name;
			num++;
			dgv.Columns[num].Name = "UseType";
			dgv.Columns[num].HeaderText = dgv.Columns[num].Name;
			num++;
			dgv.Columns[num].Name = "Brand";
			dgv.Columns[num].HeaderText = dgv.Columns[num].Name;
			num++;
			dgv.Columns[num].Name = "KillCount";
			dgv.Columns[num].HeaderText = dgv.Columns[num].Name;
			num++;
			dgv.Columns[num].Name = "Req.Status[0]";
			dgv.Columns[num].HeaderText = dgv.Columns[num].Name;
			num++;
			dgv.Columns[num].Name = "Req.Status[1]";
			dgv.Columns[num].HeaderText = dgv.Columns[num].Name;
			num++;
			dgv.Columns[num].Name = "Req.Status[2]";
			dgv.Columns[num].HeaderText = dgv.Columns[num].Name;
			num++;
			dgv.Columns[num].Name = "Req.Status[3]";
			dgv.Columns[num].HeaderText = dgv.Columns[num].Name;
			num++;
			dgv.Columns[num].Name = "Req.Status[4]";
			dgv.Columns[num].HeaderText = dgv.Columns[num].Name;
			num++;
			dgv.Columns[num].Name = "Req.Status[5]";
			dgv.Columns[num].HeaderText = dgv.Columns[num].Name;
			num++;
			dgv.Columns[num].Name = "DW";
			dgv.Columns[num].HeaderText = dgv.Columns[num].Name;
			num++;
			dgv.Columns[num].Name = "BK";
			dgv.Columns[num].HeaderText = dgv.Columns[num].Name;
			num++;
			dgv.Columns[num].Name = "ELF";
			dgv.Columns[num].HeaderText = dgv.Columns[num].Name;
			num++;
			dgv.Columns[num].Name = "MG";
			dgv.Columns[num].HeaderText = dgv.Columns[num].Name;
			num++;
			dgv.Columns[num].Name = "DL";
			dgv.Columns[num].HeaderText = dgv.Columns[num].Name;
			num++;
			dgv.Columns[num].Name = "SUM";
			dgv.Columns[num].HeaderText = dgv.Columns[num].Name;
			num++;
			dgv.Columns[num].Name = "RF";
			dgv.Columns[num].HeaderText = dgv.Columns[num].Name;
			num++;
			dgv.Columns[num].Name = "IconIndex";
			dgv.Columns[num].HeaderText = dgv.Columns[num].Name;
			num++;
			dgv.Columns[num].Name = "SkillType";
			dgv.Columns[num].HeaderText = dgv.Columns[num].Name;
			num++;
			for (int l = num; l < 51; l++)
			{
				dgv.Columns[num].Name = "Unk_" + l;
				dgv.Columns[num].HeaderText = dgv.Columns[num].Name;
				num++;
			}
			foreach (object obj in dgv.Columns)
			{
				DataGridViewColumn dataGridViewColumn = (DataGridViewColumn)obj;
				dataGridViewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
			}
		}

		// Token: 0x060004F9 RID: 1273 RVA: 0x00032E24 File Offset: 0x00031024
		private void initializeSkill_S6E3Grid(DataGridView dgv)
		{
			dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgv.Dock = DockStyle.Fill;
			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToDeleteRows = false;
			dgv.AllowUserToOrderColumns = false;
			dgv.AllowUserToResizeColumns = true;
			dgv.Columns.Add("Name", "Name");
			dgv.Columns[0].ValueType = typeof(string);
			dgv.Columns[0].ToolTipText = "Maximum 32 Chars";
			dgv.Columns[0].Width = 128;
			dgv.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			for (int i = 1; i < 5; i++)
			{
				string columnName = i.ToString();
				dgv.Columns.Add(columnName, i.ToString());
				dgv.Columns[i].ValueType = typeof(ushort);
				dgv.Columns[i].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			}
			for (int j = 5; j < 8; j++)
			{
				string columnName2 = j.ToString();
				dgv.Columns.Add(columnName2, j.ToString());
				dgv.Columns[j].ValueType = typeof(uint);
				dgv.Columns[j].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + uint.MaxValue.ToString();
			}
			dgv.Columns.Add("8", "8");
			dgv.Columns[8].ValueType = typeof(ushort);
			dgv.Columns[8].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + ushort.MaxValue.ToString();
			for (int k = 9; k < 43; k++)
			{
				string columnName3 = k.ToString();
				dgv.Columns.Add(columnName3, k.ToString());
				dgv.Columns[k].ValueType = typeof(byte);
				dgv.Columns[k].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + byte.MaxValue.ToString();
			}
			int num = 1;
			dgv.Columns[num].Name = "SkillLevel";
			dgv.Columns[num].HeaderText = dgv.Columns[num].Name;
			num++;
			dgv.Columns[num].Name = "Damage";
			dgv.Columns[num].HeaderText = dgv.Columns[num].Name;
			num++;
			dgv.Columns[num].Name = "Mana";
			dgv.Columns[num].HeaderText = dgv.Columns[num].Name;
			num++;
			dgv.Columns[num].Name = "Agility";
			dgv.Columns[num].HeaderText = dgv.Columns[num].Name;
			num++;
			dgv.Columns[num].Name = "Distance";
			dgv.Columns[num].HeaderText = dgv.Columns[num].Name;
			num++;
			dgv.Columns[num].Name = "TimeDelay";
			dgv.Columns[num].HeaderText = dgv.Columns[num].Name;
			num++;
			dgv.Columns[num].Name = "Req.Energy";
			dgv.Columns[num].HeaderText = dgv.Columns[num].Name;
			num++;
			dgv.Columns[num].Name = "Req.Level";
			dgv.Columns[num].HeaderText = dgv.Columns[num].Name;
			num++;
			dgv.Columns[num].Name = "Property";
			dgv.Columns[num].HeaderText = dgv.Columns[num].Name;
			num++;
			dgv.Columns[num].Name = "UseType";
			dgv.Columns[num].HeaderText = dgv.Columns[num].Name;
			num++;
			dgv.Columns[num].Name = "Brand";
			dgv.Columns[num].HeaderText = dgv.Columns[num].Name;
			num++;
			dgv.Columns[num].Name = "KillCount";
			dgv.Columns[num].HeaderText = dgv.Columns[num].Name;
			num++;
			dgv.Columns[num].Name = "Req.Status[0]";
			dgv.Columns[num].HeaderText = dgv.Columns[num].Name;
			num++;
			dgv.Columns[num].Name = "Req.Status[1]";
			dgv.Columns[num].HeaderText = dgv.Columns[num].Name;
			num++;
			dgv.Columns[num].Name = "Req.Status[2]";
			dgv.Columns[num].HeaderText = dgv.Columns[num].Name;
			num++;
			dgv.Columns[num].Name = "Req.Status[3]";
			dgv.Columns[num].HeaderText = dgv.Columns[num].Name;
			num++;
			dgv.Columns[num].Name = "Req.Status[4]";
			dgv.Columns[num].HeaderText = dgv.Columns[num].Name;
			num++;
			dgv.Columns[num].Name = "Req.Status[5]";
			dgv.Columns[num].HeaderText = dgv.Columns[num].Name;
			num++;
			dgv.Columns[num].Name = "DW";
			dgv.Columns[num].HeaderText = dgv.Columns[num].Name;
			num++;
			dgv.Columns[num].Name = "BK";
			dgv.Columns[num].HeaderText = dgv.Columns[num].Name;
			num++;
			dgv.Columns[num].Name = "ELF";
			dgv.Columns[num].HeaderText = dgv.Columns[num].Name;
			num++;
			dgv.Columns[num].Name = "MG";
			dgv.Columns[num].HeaderText = dgv.Columns[num].Name;
			num++;
			dgv.Columns[num].Name = "DL";
			dgv.Columns[num].HeaderText = dgv.Columns[num].Name;
			num++;
			dgv.Columns[num].Name = "SUM";
			dgv.Columns[num].HeaderText = dgv.Columns[num].Name;
			num++;
			dgv.Columns[num].Name = "RF";
			dgv.Columns[num].HeaderText = dgv.Columns[num].Name;
			num++;
			dgv.Columns[num].Name = "IconIndex";
			dgv.Columns[num].HeaderText = dgv.Columns[num].Name;
			num++;
			dgv.Columns[num].Name = "SkillType";
			dgv.Columns[num].HeaderText = dgv.Columns[num].Name;
			num++;
			for (int l = num; l < 43; l++)
			{
				dgv.Columns[num].Name = "Unk_" + l;
				dgv.Columns[num].HeaderText = dgv.Columns[num].Name;
				num++;
			}
			foreach (object obj in dgv.Columns)
			{
				DataGridViewColumn dataGridViewColumn = (DataGridViewColumn)obj;
				dataGridViewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
			}
		}

		// Token: 0x060004FA RID: 1274 RVA: 0x00033828 File Offset: 0x00031A28
		private void initializeSlideGrid(DataGridView dgv)
		{
			dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgv.Dock = DockStyle.Fill;
			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToDeleteRows = false;
			dgv.AllowUserToOrderColumns = false;
			dgv.AllowUserToResizeColumns = true;
			dgv.Columns.Add("Unk_1", "Unk_1");
			dgv.Columns["Unk_1"].ValueType = typeof(uint);
			dgv.Columns["Unk_1"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + uint.MaxValue.ToString();
			dgv.Columns.Add("Unk_2", "Unk_2");
			dgv.Columns["Unk_2"].ValueType = typeof(uint);
			dgv.Columns["Unk_2"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + uint.MaxValue.ToString();
			for (int i = 1; i <= 32; i++)
			{
				dgv.Columns.Add("Slide_" + i, "Slide_" + i);
				dgv.Columns["Slide_" + i].ValueType = typeof(string);
				dgv.Columns["Slide_" + i].ToolTipText = "Maximum 256 Chars";
				dgv.Columns["Slide_" + i].Width = 512;
				dgv.Columns["Slide_" + i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			}
			foreach (object obj in dgv.Columns)
			{
				DataGridViewColumn dataGridViewColumn = (DataGridViewColumn)obj;
				dataGridViewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
			}
		}

		// Token: 0x060004FB RID: 1275 RVA: 0x00033A54 File Offset: 0x00031C54
		private void initializeTEXTGrid(DataGridView dgv)
		{
			dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgv.Dock = DockStyle.Fill;
			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToDeleteRows = false;
			dgv.RowsAdded += this.TEXTdgv_RowsAdded;
			dgv.AllowUserToOrderColumns = false;
			dgv.AllowUserToResizeColumns = true;
			dgv.Columns.Add("Pointer", "Pointer");
			dgv.Columns["Pointer"].ValueType = typeof(uint);
			dgv.Columns["Pointer"].ToolTipText = 0.ToString() + " <= Value(Numbers) <= " + uint.MaxValue.ToString();
			dgv.Columns.Add("c_Count", "c_Count");
			dgv.Columns["c_Count"].ValueType = typeof(uint);
			dgv.Columns["c_Count"].ReadOnly = true;
			dgv.Columns["c_Count"].DefaultCellStyle.BackColor = Color.DarkGray;
			dgv.Columns.Add("Text", "Text");
			dgv.Columns["Text"].ValueType = typeof(string);
			dgv.Columns["Text"].ToolTipText = "Unlimited Length";
			dgv.Columns["Text"].Width = 1024;
			dgv.Columns["Text"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			foreach (object obj in dgv.Columns)
			{
				DataGridViewColumn dataGridViewColumn = (DataGridViewColumn)obj;
				dataGridViewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
			}
		}

		// Token: 0x060004FC RID: 1276 RVA: 0x00033C3C File Offset: 0x00031E3C
		private void InitIAOGridAndAddItems(int theGroup, TabPage tp)
		{
			DataGridView dataGridView = new DataGridView
			{
				Size = tp.Size
			};
			this.initializeIAOGrid(dataGridView);
			tp.Controls.Add(dataGridView);
			int num = 0;
			for (int i = 512 * theGroup; i < 512 * theGroup + 512; i++)
			{
				byte[] array = new byte[this.sBlockSize];
				Array.Copy(this.T_fStruct, i * this.sBlockSize, array, 0, array.Length);
				dataGridView.Rows.Add();
				dataGridView[0, num].Value = theGroup;
				dataGridView[1, num].Value = num;
				dataGridView[2, num].Value = BitConverter.ToInt16(array, 0);
				dataGridView[3, num].Value = BitConverter.ToInt16(array, 2);
				dataGridView[4, num].Value = BitConverter.ToInt16(array, 4);
				dataGridView[5, num].Value = BitConverter.ToInt16(array, 6);
				dataGridView[6, num].Value = BitConverter.ToInt32(array, 8);
				dataGridView[7, num].Value = BitConverter.ToInt32(array, 12);
				num++;
			}
			this.workingDGV = dataGridView;
			dataGridView.CellValueChanged += this.IAOdgv_CellValueChanged;
			dataGridView.KeyDown += this.dgvPasteEvent_KeyDown;
			dataGridView.Disposed += this.IAOdgv_Disposed;
		}

		// Token: 0x060004FD RID: 1277 RVA: 0x00033DC8 File Offset: 0x00031FC8
		private void InitISTGridAndAddItems(int theGroup, TabPage tp)
		{
			DataGridView dataGridView = new DataGridView
			{
				Size = tp.Size
			};
			this.initializeISTGrid(dataGridView);
			tp.Controls.Add(dataGridView);
			int num = 0;
			for (int i = 512 * theGroup; i < 512 * theGroup + 512; i++)
			{
				byte[] array = new byte[this.sBlockSize];
				Array.Copy(this.T_fStruct, i * this.sBlockSize, array, 0, array.Length);
				dataGridView.Rows.Add();
				dataGridView[0, num].Value = theGroup;
				dataGridView[1, num].Value = num;
				dataGridView[2, num].Value = array[0];
				dataGridView[3, num].Value = array[1];
				dataGridView[4, num].Value = array[2];
				dataGridView[5, num].Value = array[3];
				num++;
			}
			this.workingDGV = dataGridView;
			dataGridView.CellValueChanged += this.ISTdgv_CellValueChanged;
			dataGridView.KeyDown += this.dgvPasteEvent_KeyDown;
			dataGridView.Disposed += this.ISTdgv_Disposed;
		}

		// Token: 0x060004FE RID: 1278 RVA: 0x00033F10 File Offset: 0x00032110
		private void InitItem_S6E3GridAndAddItems(int theGroup, TabPage tp)
		{
			DataGridView dataGridView = new DataGridView
			{
				Size = tp.Size
			};
			this.initializeItem_S6E3Grid(dataGridView);
			tp.Controls.Add(dataGridView);
			int num = 0;
			for (int i = 512 * theGroup; i < 512 * theGroup + 512; i++)
			{
				bool flag = true;
				byte[] array = new byte[this.sBlockSize];
				for (int j = 0; j < this.sBlockSize; j++)
				{
					if (this.fStruct[i, j] == null)
					{
						flag = true;
						break;
					}
					array[j] = Convert.ToByte(this.fStruct[i, j]);
					flag = false;
				}
				if (!flag)
				{
					byte[] array2 = new byte[30];
					byte[] array3 = new byte[1];
					byte[] array4 = new byte[2];
					byte[] array5 = new byte[2];
					byte[] array6 = new byte[2];
					byte[] array7 = new byte[1];
					byte[] array8 = new byte[1];
					byte[] array9 = new byte[1];
					byte[] array10 = new byte[1];
					byte[] array11 = new byte[1];
					byte[] array12 = new byte[2];
					byte[] array13 = new byte[1];
					byte[] array14 = new byte[1];
					byte[] array15 = new byte[1];
					byte[] array16 = new byte[1];
					byte[] array17 = new byte[2];
					byte[] array18 = new byte[2];
					byte[] array19 = new byte[2];
					byte[] array20 = new byte[2];
					byte[] array21 = new byte[2];
					byte[] array22 = new byte[2];
					byte[] array23 = new byte[1];
					byte[] array24 = new byte[1];
					byte[] array25 = new byte[4];
					byte[] array26 = new byte[1];
					byte[] array27 = new byte[1];
					byte[] array28 = new byte[1];
					byte[] array29 = new byte[1];
					byte[] array30 = new byte[1];
					byte[] array31 = new byte[1];
					byte[] array32 = new byte[1];
					byte[] array33 = new byte[1];
					byte[] array34 = new byte[1];
					byte[] array35 = new byte[1];
					byte[] array36 = new byte[1];
					byte[] array37 = new byte[1];
					byte[] array38 = new byte[1];
					byte[] array39 = new byte[1];
					byte[] array40 = new byte[1];
					byte[] array41 = new byte[1];
					byte[] array42 = new byte[1];
					byte[] array43 = new byte[1];
					Array.Copy(array, 0, array2, 0, array2.Length);
					Array.Copy(array, 30, array3, 0, array3.Length);
					Array.Copy(array, 32, array4, 0, array4.Length);
					Array.Copy(array, 34, array5, 0, array5.Length);
					Array.Copy(array, 36, array6, 0, array6.Length);
					Array.Copy(array, 38, array7, 0, array7.Length);
					Array.Copy(array, 39, array8, 0, array8.Length);
					Array.Copy(array, 40, array9, 0, array9.Length);
					Array.Copy(array, 41, array10, 0, array10.Length);
					Array.Copy(array, 42, array11, 0, array11.Length);
					Array.Copy(array, 43, array12, 0, array12.Length);
					Array.Copy(array, 44, array23, 0, array23.Length);
					Array.Copy(array, 45, array13, 0, array13.Length);
					Array.Copy(array, 46, array24, 0, array24.Length);
					Array.Copy(array, 47, array14, 0, array14.Length);
					Array.Copy(array, 48, array15, 0, array15.Length);
					Array.Copy(array, 49, array16, 0, array16.Length);
					Array.Copy(array, 50, array17, 0, array17.Length);
					Array.Copy(array, 52, array18, 0, array18.Length);
					Array.Copy(array, 54, array19, 0, array19.Length);
					Array.Copy(array, 56, array20, 0, array20.Length);
					Array.Copy(array, 58, array21, 0, array21.Length);
					Array.Copy(array, 60, array22, 0, array22.Length);
					Array.Copy(array, 62, array42, 0, array42.Length);
					Array.Copy(array, 63, array43, 0, array43.Length);
					Array.Copy(array, 64, array25, 0, array25.Length);
					Array.Copy(array, 68, array27, 0, array27.Length);
					Array.Copy(array, 69, array28, 0, array28.Length);
					Array.Copy(array, 70, array29, 0, array29.Length);
					Array.Copy(array, 71, array30, 0, array30.Length);
					Array.Copy(array, 72, array31, 0, array31.Length);
					Array.Copy(array, 73, array32, 0, array32.Length);
					Array.Copy(array, 74, array33, 0, array33.Length);
					Array.Copy(array, 75, array34, 0, array34.Length);
					Array.Copy(array, 76, array35, 0, array35.Length);
					Array.Copy(array, 77, array36, 0, array36.Length);
					Array.Copy(array, 78, array37, 0, array37.Length);
					Array.Copy(array, 79, array38, 0, array38.Length);
					Array.Copy(array, 80, array39, 0, array39.Length);
					Array.Copy(array, 81, array40, 0, array40.Length);
					Array.Copy(array, 82, array41, 0, array41.Length);
					Array.Copy(array, 83, array26, 0, array26.Length);
					dataGridView.Rows.Add();
					dataGridView[0, num].Value = theGroup;
					dataGridView[1, num].Value = num;
					dataGridView[2, num].Value = Encoding.GetEncoding("GB2312").GetString(array2).Replace("\0", "").Replace("?", "");
					dataGridView[3, num].Value = array3[0];
					dataGridView[4, num].Value = BitConverter.ToUInt16(array4, 0);
					dataGridView[5, num].Value = BitConverter.ToUInt16(array5, 0);
					dataGridView[6, num].Value = BitConverter.ToUInt16(array6, 0);
					dataGridView[7, num].Value = array7[0];
					dataGridView[8, num].Value = array8[0];
					dataGridView[9, num].Value = array9[0];
					dataGridView[10, num].Value = array10[0];
					dataGridView[11, num].Value = array11[0];
					dataGridView[12, num].Value = BitConverter.ToUInt16(array12, 0);
					dataGridView[13, num].Value = array23[0];
					dataGridView[14, num].Value = array13[0];
					dataGridView[15, num].Value = array24[0];
					dataGridView[16, num].Value = array14[0];
					dataGridView[17, num].Value = array15[0];
					dataGridView[18, num].Value = array16[0];
					dataGridView[19, num].Value = BitConverter.ToUInt16(array17, 0);
					dataGridView[20, num].Value = BitConverter.ToUInt16(array18, 0);
					dataGridView[21, num].Value = BitConverter.ToUInt16(array19, 0);
					dataGridView[22, num].Value = BitConverter.ToUInt16(array20, 0);
					dataGridView[23, num].Value = BitConverter.ToUInt16(array21, 0);
					dataGridView[24, num].Value = BitConverter.ToUInt16(array22, 0);
					dataGridView[25, num].Value = array42[0];
					dataGridView[26, num].Value = array43[0];
					dataGridView[27, num].Value = BitConverter.ToUInt32(array25, 0);
					dataGridView[28, num].Value = array27[0];
					dataGridView[29, num].Value = array28[0];
					dataGridView[30, num].Value = array29[0];
					dataGridView[31, num].Value = array30[0];
					dataGridView[32, num].Value = array31[0];
					dataGridView[33, num].Value = array32[0];
					dataGridView[34, num].Value = array33[0];
					dataGridView[35, num].Value = array34[0];
					dataGridView[36, num].Value = array35[0];
					dataGridView[37, num].Value = array36[0];
					dataGridView[38, num].Value = array37[0];
					dataGridView[39, num].Value = array38[0];
					dataGridView[40, num].Value = array39[0];
					dataGridView[41, num].Value = array40[0];
					dataGridView[42, num].Value = array41[0];
					dataGridView[43, num].Value = array26[0];
				}
				else if (flag)
				{
					dataGridView.Rows.Add();
					dataGridView["Group", num].Value = theGroup;
					dataGridView["Index", num].Value = num;
					for (int k = 0; k < dataGridView.Columns.Count; k++)
					{
						if (k != 0 & k != 1)
						{
							dataGridView.Rows[num].Cells[k].Value = "0";
						}
					}
				}
				num++;
			}
			this.workingDGV = dataGridView;
			dataGridView.CellValueChanged += this.Item_S6E3dgv_CellValueChanged;
			dataGridView.KeyDown += this.dgvPasteEvent_KeyDown;
			dataGridView.Disposed += this.Item_S6E3dgv_Disposed;
		}

		// Token: 0x060004FF RID: 1279 RVA: 0x000348D0 File Offset: 0x00032AD0
		private void InitItemEx700GridAndAddItems(int theGroup, TabPage tp)
		{
			DataGridView dataGridView = new DataGridView
			{
				Size = tp.Size
			};
			this.initializeItemEx700Grid(dataGridView);
			tp.Controls.Add(dataGridView);
			int num = 0;
			for (int i = 512 * theGroup; i < 512 * theGroup + 512; i++)
			{
				bool flag = true;
				byte[] array = new byte[this.sBlockSize];
				for (int j = 0; j < this.sBlockSize; j++)
				{
					if (this.fStruct[i, j] == null)
					{
						flag = true;
						break;
					}
					array[j] = Convert.ToByte(this.fStruct[i, j]);
					flag = false;
				}
				if (!flag)
				{
					byte[] array2 = new byte[1];
					byte[] array3 = new byte[1];
					byte[] array4 = new byte[1];
					byte[] array5 = new byte[1];
					byte[] array6 = new byte[2];
					byte[] array7 = new byte[2];
					byte[] array8 = new byte[260];
					byte[] array9 = new byte[260];
					byte[] array10 = new byte[30];
					byte[] array11 = new byte[1];
					byte[] array12 = new byte[1];
					byte[] array13 = new byte[2];
					byte[] array14 = new byte[2];
					byte[] array15 = new byte[2];
					byte[] array16 = new byte[1];
					byte[] array17 = new byte[1];
					byte[] array18 = new byte[1];
					byte[] array19 = new byte[1];
					byte[] array20 = new byte[1];
					byte[] array21 = new byte[2];
					byte[] array22 = new byte[1];
					byte[] array23 = new byte[1];
					byte[] array24 = new byte[1];
					byte[] array25 = new byte[1];
					byte[] array26 = new byte[1];
					byte[] array27 = new byte[2];
					byte[] array28 = new byte[2];
					byte[] array29 = new byte[2];
					byte[] array30 = new byte[2];
					byte[] array31 = new byte[2];
					byte[] array32 = new byte[2];
					byte[] array33 = new byte[2];
					byte[] array34 = new byte[4];
					byte[] array35 = new byte[1];
					byte[] array36 = new byte[1];
					byte[] array37 = new byte[1];
					byte[] array38 = new byte[1];
					byte[] array39 = new byte[1];
					byte[] array40 = new byte[1];
					byte[] array41 = new byte[1];
					byte[] array42 = new byte[1];
					byte[] array43 = new byte[1];
					byte[] array44 = new byte[1];
					byte[] array45 = new byte[1];
					byte[] array46 = new byte[1];
					byte[] array47 = new byte[1];
					byte[] array48 = new byte[1];
					byte[] array49 = new byte[1];
					byte[] array50 = new byte[1];
					int num2 = 520;
					int num3 = 6;
					Array.Copy(array, 0, array2, 0, array2.Length);
					Array.Copy(array, 1, array3, 0, array3.Length);
					Array.Copy(array, 2, array4, 0, array4.Length);
					Array.Copy(array, 3, array5, 0, array5.Length);
					Array.Copy(array, 4, array6, 0, array6.Length);
					Array.Copy(array, 6, array7, 0, array7.Length);
					Array.Copy(array, 2 + num3, array8, 0, array8.Length);
					Array.Copy(array, 262 + num3, array9, 0, array9.Length);
					Array.Copy(array, 522 + num3, array10, 0, array10.Length);
					Array.Copy(array, 32 + num3 + num2, array11, 0, array11.Length);
					Array.Copy(array, 33 + num3 + num2, array12, 0, array12.Length);
					Array.Copy(array, 34 + num3 + num2, array13, 0, array13.Length);
					Array.Copy(array, 36 + num3 + num2, array14, 0, array14.Length);
					Array.Copy(array, 38 + num3 + num2, array15, 0, array15.Length);
					Array.Copy(array, 40 + num3 + num2, array16, 0, array16.Length);
					Array.Copy(array, 41 + num3 + num2, array17, 0, array17.Length);
					Array.Copy(array, 42 + num3 + num2, array18, 0, array18.Length);
					Array.Copy(array, 43 + num3 + num2, array19, 0, array19.Length);
					Array.Copy(array, 44 + num3 + num2, array20, 0, array20.Length);
					Array.Copy(array, 45 + num3 + num2, array21, 0, array21.Length);
					Array.Copy(array, 47 + num3 + num2, array22, 0, array22.Length);
					Array.Copy(array, 48 + num3 + num2, array23, 0, array23.Length);
					Array.Copy(array, 49 + num3 + num2, array24, 0, array24.Length);
					Array.Copy(array, 50 + num3 + num2, array25, 0, array25.Length);
					Array.Copy(array, 51 + num3 + num2, array26, 0, array26.Length);
					Array.Copy(array, 52 + num3 + num2, array27, 0, array27.Length);
					Array.Copy(array, 54 + num3 + num2, array28, 0, array28.Length);
					Array.Copy(array, 56 + num3 + num2, array29, 0, array29.Length);
					Array.Copy(array, 58 + num3 + num2, array30, 0, array30.Length);
					Array.Copy(array, 60 + num3 + num2, array31, 0, array31.Length);
					Array.Copy(array, 62 + num3 + num2, array32, 0, array32.Length);
					Array.Copy(array, 64 + num3 + num2, array33, 0, array33.Length);
					Array.Copy(array, 66 + num3 + num2, array34, 0, array34.Length);
					Array.Copy(array, 70 + num3 + num2, array35, 0, array35.Length);
					Array.Copy(array, 71 + num3 + num2, array36, 0, array36.Length);
					Array.Copy(array, 72 + num3 + num2, array37, 0, array37.Length);
					Array.Copy(array, 73 + num3 + num2, array38, 0, array38.Length);
					Array.Copy(array, 74 + num3 + num2, array39, 0, array39.Length);
					Array.Copy(array, 75 + num3 + num2, array40, 0, array40.Length);
					Array.Copy(array, 76 + num3 + num2, array41, 0, array41.Length);
					Array.Copy(array, 77 + num3 + num2, array42, 0, array42.Length);
					Array.Copy(array, 78 + num3 + num2, array43, 0, array43.Length);
					Array.Copy(array, 79 + num3 + num2, array44, 0, array44.Length);
					Array.Copy(array, 80 + num3 + num2, array45, 0, array45.Length);
					Array.Copy(array, 81 + num3 + num2, array46, 0, array46.Length);
					Array.Copy(array, 82 + num3 + num2, array47, 0, array47.Length);
					Array.Copy(array, 83 + num3 + num2, array48, 0, array48.Length);
					Array.Copy(array, 84 + num3 + num2, array49, 0, array49.Length);
					Array.Copy(array, 85 + num3 + num2, array50, 0, array50.Length);
					dataGridView.Rows.Add();
					dataGridView[0, num].Value = array2[0];
					dataGridView[1, num].Value = array3[0];
					dataGridView[2, num].Value = array4[0];
					dataGridView[3, num].Value = array5[0];
					dataGridView[4, num].Value = BitConverter.ToUInt16(array6, 0);
					dataGridView[5, num].Value = BitConverter.ToUInt16(array7, 0);
					dataGridView[6, num].Value = Encoding.GetEncoding("GB2312").GetString(array8).Replace("\0", "");
					dataGridView[7, num].Value = Encoding.GetEncoding("GB2312").GetString(array9).Replace("\0", "");
					dataGridView[8, num].Value = Encoding.GetEncoding("GB2312").GetString(array10).Replace("\0", "");
					dataGridView[9, num].Value = array11[0];
					dataGridView[10, num].Value = array12[0];
					dataGridView[11, num].Value = BitConverter.ToUInt16(array13, 0);
					dataGridView[12, num].Value = BitConverter.ToUInt16(array14, 0);
					dataGridView[13, num].Value = BitConverter.ToUInt16(array15, 0);
					dataGridView[14, num].Value = array16[0];
					dataGridView[15, num].Value = array17[0];
					dataGridView[16, num].Value = array18[0];
					dataGridView[17, num].Value = array19[0];
					dataGridView[18, num].Value = array20[0];
					dataGridView[19, num].Value = BitConverter.ToUInt16(array21, 0);
					dataGridView[20, num].Value = array22[0];
					dataGridView[21, num].Value = array23[0];
					dataGridView[22, num].Value = array24[0];
					dataGridView[23, num].Value = array25[0];
					dataGridView[24, num].Value = array26[0];
					dataGridView[25, num].Value = BitConverter.ToUInt16(array27, 0);
					dataGridView[26, num].Value = BitConverter.ToUInt16(array28, 0);
					dataGridView[27, num].Value = BitConverter.ToUInt16(array29, 0);
					dataGridView[28, num].Value = BitConverter.ToUInt16(array30, 0);
					dataGridView[29, num].Value = BitConverter.ToUInt16(array31, 0);
					dataGridView[30, num].Value = BitConverter.ToUInt16(array32, 0);
					dataGridView[31, num].Value = BitConverter.ToUInt16(array33, 0);
					dataGridView[32, num].Value = BitConverter.ToUInt32(array34, 0);
					dataGridView[33, num].Value = array35[0];
					dataGridView[34, num].Value = array36[0];
					dataGridView[35, num].Value = array37[0];
					dataGridView[36, num].Value = array38[0];
					dataGridView[37, num].Value = array39[0];
					dataGridView[38, num].Value = array40[0];
					dataGridView[39, num].Value = array41[0];
					dataGridView[40, num].Value = array42[0];
					dataGridView[41, num].Value = array43[0];
					dataGridView[42, num].Value = array44[0];
					dataGridView[43, num].Value = array45[0];
					dataGridView[44, num].Value = array46[0];
					dataGridView[45, num].Value = array47[0];
					dataGridView[46, num].Value = array48[0];
					dataGridView[47, num].Value = array49[0];
					dataGridView[48, num].Value = array50[0];
				}
				else if (flag)
				{
					dataGridView.Rows.Add();
					dataGridView["Group", num].Value = theGroup;
					dataGridView["Index", num].Value = num;
					for (int k = 0; k < dataGridView.Columns.Count; k++)
					{
						if (k != 4 & k != 5)
						{
							dataGridView.Rows[num].Cells[k].Value = "0";
						}
					}
				}
				num++;
			}
			this.workingDGV = dataGridView;
			dataGridView.CellValueChanged += this.ItemEx700dgv_CellValueChanged;
			dataGridView.KeyDown += this.dgvPasteEvent_KeyDown;
			dataGridView.Disposed += this.ItemEx700dgv_Disposed;
		}

		// Token: 0x06000500 RID: 1280 RVA: 0x000354E4 File Offset: 0x000336E4
		private void InitItemEx700PlusGridAndAddItems(int theGroup, TabPage tp)
		{
			DataGridView dataGridView = new DataGridView
			{
				Size = tp.Size
			};
			this.initializeItemEx700PlusGrid(dataGridView);
			tp.Controls.Add(dataGridView);
			int num = 0;
			for (int i = 512 * theGroup; i < 512 * theGroup + 512; i++)
			{
				bool flag = true;
				byte[] array = new byte[this.sBlockSize];
				for (int j = 0; j < this.sBlockSize; j++)
				{
					if (this.fStruct[i, j] == null)
					{
						flag = true;
						break;
					}
					array[j] = Convert.ToByte(this.fStruct[i, j]);
					flag = false;
				}
				if (!flag)
				{
					byte[] array2 = new byte[1];
					byte[] array3 = new byte[1];
					byte[] array4 = new byte[1];
					byte[] array5 = new byte[1];
					byte[] array6 = new byte[2];
					byte[] array7 = new byte[2];
					byte[] array8 = new byte[260];
					byte[] array9 = new byte[260];
					byte[] array10 = new byte[30];
					byte[] array11 = new byte[1];
					byte[] array12 = new byte[1];
					byte[] array13 = new byte[2];
					byte[] array14 = new byte[2];
					byte[] array15 = new byte[2];
					byte[] array16 = new byte[1];
					byte[] array17 = new byte[1];
					byte[] array18 = new byte[1];
					byte[] array19 = new byte[1];
					byte[] array20 = new byte[1];
					byte[] array21 = new byte[2];
					byte[] array22 = new byte[1];
					byte[] array23 = new byte[1];
					byte[] array24 = new byte[1];
					byte[] array25 = new byte[1];
					byte[] array26 = new byte[1];
					byte[] array27 = new byte[2];
					byte[] array28 = new byte[2];
					byte[] array29 = new byte[2];
					byte[] array30 = new byte[2];
					byte[] array31 = new byte[2];
					byte[] array32 = new byte[2];
					byte[] array33 = new byte[2];
					byte[] array34 = new byte[4];
					byte[] array35 = new byte[1];
					byte[] array36 = new byte[1];
					byte[] array37 = new byte[1];
					byte[] array38 = new byte[1];
					byte[] array39 = new byte[1];
					byte[] array40 = new byte[1];
					byte[] array41 = new byte[1];
					byte[] array42 = new byte[1];
					byte[] array43 = new byte[1];
					byte[] array44 = new byte[1];
					byte[] array45 = new byte[1];
					byte[] array46 = new byte[1];
					byte[] array47 = new byte[1];
					byte[] array48 = new byte[1];
					byte[] array49 = new byte[1];
					byte[] array50 = new byte[1];
					byte[] array51 = new byte[1];
					byte[] array52 = new byte[1];
					byte[] array53 = new byte[1];
					byte[] array54 = new byte[1];
					byte[] array55 = new byte[1];
					byte[] array56 = new byte[1];
					byte[] array57 = new byte[1];
					byte[] array58 = new byte[1];
					int num2 = 520;
					int num3 = 6;
					Array.Copy(array, 0, array2, 0, array2.Length);
					Array.Copy(array, 1, array3, 0, array3.Length);
					Array.Copy(array, 2, array4, 0, array4.Length);
					Array.Copy(array, 3, array5, 0, array5.Length);
					Array.Copy(array, 4, array6, 0, array6.Length);
					Array.Copy(array, 6, array7, 0, array7.Length);
					Array.Copy(array, 2 + num3, array8, 0, array8.Length);
					Array.Copy(array, 262 + num3, array9, 0, array9.Length);
					Array.Copy(array, 522 + num3, array10, 0, array10.Length);
					Array.Copy(array, 32 + num3 + num2, array11, 0, array11.Length);
					Array.Copy(array, 33 + num3 + num2, array12, 0, array12.Length);
					Array.Copy(array, 34 + num3 + num2, array13, 0, array13.Length);
					Array.Copy(array, 36 + num3 + num2, array14, 0, array14.Length);
					Array.Copy(array, 38 + num3 + num2, array15, 0, array15.Length);
					Array.Copy(array, 40 + num3 + num2, array16, 0, array16.Length);
					Array.Copy(array, 41 + num3 + num2, array17, 0, array17.Length);
					Array.Copy(array, 42 + num3 + num2, array18, 0, array18.Length);
					Array.Copy(array, 43 + num3 + num2, array19, 0, array19.Length);
					Array.Copy(array, 44 + num3 + num2, array20, 0, array20.Length);
					Array.Copy(array, 45 + num3 + num2, array21, 0, array21.Length);
					Array.Copy(array, 47 + num3 + num2, array22, 0, array22.Length);
					Array.Copy(array, 48 + num3 + num2, array23, 0, array23.Length);
					Array.Copy(array, 49 + num3 + num2, array24, 0, array24.Length);
					Array.Copy(array, 50 + num3 + num2, array25, 0, array25.Length);
					Array.Copy(array, 51 + num3 + num2, array26, 0, array26.Length);
					Array.Copy(array, 52 + num3 + num2, array27, 0, array27.Length);
					Array.Copy(array, 54 + num3 + num2, array28, 0, array28.Length);
					Array.Copy(array, 56 + num3 + num2, array29, 0, array29.Length);
					Array.Copy(array, 58 + num3 + num2, array30, 0, array30.Length);
					Array.Copy(array, 60 + num3 + num2, array31, 0, array31.Length);
					Array.Copy(array, 62 + num3 + num2, array32, 0, array32.Length);
					Array.Copy(array, 64 + num3 + num2, array33, 0, array33.Length);
					Array.Copy(array, 66 + num3 + num2, array34, 0, array34.Length);
					Array.Copy(array, 70 + num3 + num2, array35, 0, array35.Length);
					Array.Copy(array, 71 + num3 + num2, array36, 0, array36.Length);
					Array.Copy(array, 72 + num3 + num2, array37, 0, array37.Length);
					Array.Copy(array, 73 + num3 + num2, array38, 0, array38.Length);
					Array.Copy(array, 74 + num3 + num2, array39, 0, array39.Length);
					Array.Copy(array, 75 + num3 + num2, array40, 0, array40.Length);
					Array.Copy(array, 76 + num3 + num2, array41, 0, array41.Length);
					Array.Copy(array, 77 + num3 + num2, array42, 0, array42.Length);
					Array.Copy(array, 78 + num3 + num2, array43, 0, array43.Length);
					Array.Copy(array, 79 + num3 + num2, array44, 0, array44.Length);
					Array.Copy(array, 80 + num3 + num2, array45, 0, array45.Length);
					Array.Copy(array, 81 + num3 + num2, array46, 0, array46.Length);
					Array.Copy(array, 82 + num3 + num2, array47, 0, array47.Length);
					Array.Copy(array, 83 + num3 + num2, array48, 0, array48.Length);
					Array.Copy(array, 84 + num3 + num2, array49, 0, array49.Length);
					Array.Copy(array, 85 + num3 + num2, array50, 0, array50.Length);
					Array.Copy(array, 86 + num3 + num2, array51, 0, array51.Length);
					Array.Copy(array, 87 + num3 + num2, array52, 0, array52.Length);
					Array.Copy(array, 88 + num3 + num2, array53, 0, array53.Length);
					Array.Copy(array, 89 + num3 + num2, array54, 0, array54.Length);
					Array.Copy(array, 90 + num3 + num2, array55, 0, array55.Length);
					Array.Copy(array, 91 + num3 + num2, array56, 0, array56.Length);
					Array.Copy(array, 92 + num3 + num2, array57, 0, array57.Length);
					Array.Copy(array, 93 + num3 + num2, array58, 0, array58.Length);
					dataGridView.Rows.Add();
					dataGridView[0, num].Value = array2[0];
					dataGridView[1, num].Value = array3[0];
					dataGridView[2, num].Value = array4[0];
					dataGridView[3, num].Value = array5[0];
					dataGridView[4, num].Value = BitConverter.ToUInt16(array6, 0);
					dataGridView[5, num].Value = BitConverter.ToUInt16(array7, 0);
					dataGridView[6, num].Value = Encoding.GetEncoding("GB2312").GetString(array8).Replace("\0", "");
					dataGridView[7, num].Value = Encoding.GetEncoding("GB2312").GetString(array9).Replace("\0", "");
					dataGridView[8, num].Value = Encoding.GetEncoding("GB2312").GetString(array10).Replace("\0", "");
					dataGridView[9, num].Value = array11[0];
					dataGridView[10, num].Value = array12[0];
					dataGridView[11, num].Value = BitConverter.ToUInt16(array13, 0);
					dataGridView[12, num].Value = BitConverter.ToUInt16(array14, 0);
					dataGridView[13, num].Value = BitConverter.ToUInt16(array15, 0);
					dataGridView[14, num].Value = array16[0];
					dataGridView[15, num].Value = array17[0];
					dataGridView[16, num].Value = array18[0];
					dataGridView[17, num].Value = array19[0];
					dataGridView[18, num].Value = array20[0];
					dataGridView[19, num].Value = BitConverter.ToUInt16(array21, 0);
					dataGridView[20, num].Value = array22[0];
					dataGridView[21, num].Value = array23[0];
					dataGridView[22, num].Value = array24[0];
					dataGridView[23, num].Value = array25[0];
					dataGridView[24, num].Value = array26[0];
					dataGridView[25, num].Value = BitConverter.ToUInt16(array27, 0);
					dataGridView[26, num].Value = BitConverter.ToUInt16(array28, 0);
					dataGridView[27, num].Value = BitConverter.ToUInt16(array29, 0);
					dataGridView[28, num].Value = BitConverter.ToUInt16(array30, 0);
					dataGridView[29, num].Value = BitConverter.ToUInt16(array31, 0);
					dataGridView[30, num].Value = BitConverter.ToUInt16(array32, 0);
					dataGridView[31, num].Value = BitConverter.ToUInt16(array33, 0);
					dataGridView[32, num].Value = BitConverter.ToUInt32(array34, 0);
					dataGridView[33, num].Value = array35[0];
					dataGridView[34, num].Value = array36[0];
					dataGridView[35, num].Value = array37[0];
					dataGridView[36, num].Value = array38[0];
					dataGridView[37, num].Value = array39[0];
					dataGridView[38, num].Value = array40[0];
					dataGridView[39, num].Value = array41[0];
					dataGridView[40, num].Value = array42[0];
					dataGridView[41, num].Value = array43[0];
					dataGridView[42, num].Value = array44[0];
					dataGridView[43, num].Value = array45[0];
					dataGridView[44, num].Value = array46[0];
					dataGridView[45, num].Value = array47[0];
					dataGridView[46, num].Value = array48[0];
					dataGridView[47, num].Value = array49[0];
					dataGridView[48, num].Value = array50[0];
					dataGridView[49, num].Value = array51[0];
					dataGridView[50, num].Value = array52[0];
					dataGridView[51, num].Value = array53[0];
					dataGridView[52, num].Value = array54[0];
					dataGridView[53, num].Value = array55[0];
					dataGridView[54, num].Value = array56[0];
					dataGridView[55, num].Value = array57[0];
					dataGridView[56, num].Value = array58[0];
				}
				else if (flag)
				{
					dataGridView.Rows.Add();
					dataGridView["Group", num].Value = theGroup;
					dataGridView["Index", num].Value = num;
					for (int k = 0; k < dataGridView.Columns.Count; k++)
					{
						if (k != 4 & k != 5)
						{
							dataGridView.Rows[num].Cells[k].Value = "0";
						}
					}
				}
				num++;
			}
			this.workingDGV = dataGridView;
			dataGridView.CellValueChanged += this.ItemEx700Plusdgv_CellValueChanged;
			dataGridView.KeyDown += this.dgvPasteEvent_KeyDown;
			dataGridView.Disposed += this.ItemEx700Plusdgv_Disposed;
		}

		// Token: 0x06000501 RID: 1281 RVA: 0x000362A0 File Offset: 0x000344A0
		private void InitItemSeason8Episode1GridAndAddItems(int theGroup, TabPage tp)
		{
			DataGridView dataGridView = new DataGridView
			{
				Size = tp.Size
			};
			this.initializeItemSeason8Episode1Grid(dataGridView);
			tp.Controls.Add(dataGridView);
			int num = 0;
			for (int i = 512 * theGroup; i < 512 * theGroup + 512; i++)
			{
				bool flag = true;
				byte[] array = new byte[this.sBlockSize];
				for (int j = 0; j < this.sBlockSize; j++)
				{
					if (this.fStruct[i, j] == null)
					{
						flag = true;
						break;
					}
					array[j] = Convert.ToByte(this.fStruct[i, j]);
					flag = false;
				}
				if (!flag)
				{
					byte[] array2 = new byte[1];
					byte[] array3 = new byte[1];
					byte[] array4 = new byte[1];
					byte[] array5 = new byte[1];
					byte[] array6 = new byte[2];
					byte[] array7 = new byte[2];
					byte[] array8 = new byte[260];
					byte[] array9 = new byte[260];
					byte[] array10 = new byte[30];
					byte[] array11 = new byte[1];
					byte[] array12 = new byte[1];
					byte[] array13 = new byte[2];
					byte[] array14 = new byte[2];
					byte[] array15 = new byte[2];
					byte[] array16 = new byte[1];
					byte[] array17 = new byte[1];
					byte[] array18 = new byte[1];
					byte[] array19 = new byte[1];
					byte[] array20 = new byte[1];
					byte[] array21 = new byte[2];
					byte[] array22 = new byte[1];
					byte[] array23 = new byte[1];
					byte[] array24 = new byte[1];
					byte[] array25 = new byte[1];
					byte[] array26 = new byte[1];
					byte[] array27 = new byte[2];
					byte[] array28 = new byte[2];
					byte[] array29 = new byte[2];
					byte[] array30 = new byte[2];
					byte[] array31 = new byte[2];
					byte[] array32 = new byte[2];
					byte[] array33 = new byte[2];
					byte[] array34 = new byte[4];
					byte[] array35 = new byte[1];
					byte[] array36 = new byte[1];
					byte[] array37 = new byte[1];
					byte[] array38 = new byte[1];
					byte[] array39 = new byte[1];
					byte[] array40 = new byte[1];
					byte[] array41 = new byte[1];
					byte[] array42 = new byte[1];
					byte[] array43 = new byte[1];
					byte[] array44 = new byte[1];
					byte[] array45 = new byte[1];
					byte[] array46 = new byte[1];
					byte[] array47 = new byte[1];
					byte[] array48 = new byte[1];
					byte[] array49 = new byte[1];
					byte[] array50 = new byte[1];
					byte[] array51 = new byte[1];
					byte[] array52 = new byte[1];
					byte[] array53 = new byte[1];
					byte[] array54 = new byte[1];
					byte[] array55 = new byte[1];
					byte[] array56 = new byte[1];
					byte[] array57 = new byte[1];
					byte[] array58 = new byte[1];
					int num2 = 520;
					int num3 = 6;
					Array.Copy(array, 0, array2, 0, array2.Length);
					Array.Copy(array, 1, array3, 0, array3.Length);
					Array.Copy(array, 2, array4, 0, array4.Length);
					Array.Copy(array, 3, array5, 0, array5.Length);
					Array.Copy(array, 4, array6, 0, array6.Length);
					Array.Copy(array, 6, array7, 0, array7.Length);
					Array.Copy(array, 2 + num3, array8, 0, array8.Length);
					Array.Copy(array, 262 + num3, array9, 0, array9.Length);
					Array.Copy(array, 522 + num3, array10, 0, array10.Length);
					Array.Copy(array, 32 + num3 + num2, array11, 0, array11.Length);
					Array.Copy(array, 33 + num3 + num2, array12, 0, array12.Length);
					Array.Copy(array, 34 + num3 + num2, array13, 0, array13.Length);
					Array.Copy(array, 36 + num3 + num2, array14, 0, array14.Length);
					Array.Copy(array, 38 + num3 + num2, array15, 0, array15.Length);
					Array.Copy(array, 40 + num3 + num2, array16, 0, array16.Length);
					Array.Copy(array, 41 + num3 + num2, array17, 0, array17.Length);
					Array.Copy(array, 42 + num3 + num2, array18, 0, array18.Length);
					Array.Copy(array, 43 + num3 + num2, array19, 0, array19.Length);
					Array.Copy(array, 44 + num3 + num2, array20, 0, array20.Length);
					Array.Copy(array, 45 + num3 + num2, array21, 0, array21.Length);
					Array.Copy(array, 47 + num3 + num2, array22, 0, array22.Length);
					Array.Copy(array, 48 + num3 + num2, array23, 0, array23.Length);
					Array.Copy(array, 49 + num3 + num2, array24, 0, array24.Length);
					Array.Copy(array, 50 + num3 + num2, array25, 0, array25.Length);
					Array.Copy(array, 51 + num3 + num2, array26, 0, array26.Length);
					Array.Copy(array, 52 + num3 + num2, array27, 0, array27.Length);
					Array.Copy(array, 54 + num3 + num2, array28, 0, array28.Length);
					Array.Copy(array, 56 + num3 + num2, array29, 0, array29.Length);
					Array.Copy(array, 58 + num3 + num2, array30, 0, array30.Length);
					Array.Copy(array, 60 + num3 + num2, array31, 0, array31.Length);
					Array.Copy(array, 62 + num3 + num2, array32, 0, array32.Length);
					Array.Copy(array, 64 + num3 + num2, array33, 0, array33.Length);
					Array.Copy(array, 66 + num3 + num2, array34, 0, array34.Length);
					Array.Copy(array, 70 + num3 + num2, array35, 0, array35.Length);
					Array.Copy(array, 71 + num3 + num2, array36, 0, array36.Length);
					Array.Copy(array, 72 + num3 + num2, array37, 0, array37.Length);
					Array.Copy(array, 73 + num3 + num2, array38, 0, array38.Length);
					Array.Copy(array, 74 + num3 + num2, array39, 0, array39.Length);
					Array.Copy(array, 75 + num3 + num2, array40, 0, array40.Length);
					Array.Copy(array, 76 + num3 + num2, array41, 0, array41.Length);
					Array.Copy(array, 77 + num3 + num2, array42, 0, array42.Length);
					Array.Copy(array, 78 + num3 + num2, array43, 0, array43.Length);
					Array.Copy(array, 79 + num3 + num2, array44, 0, array44.Length);
					Array.Copy(array, 80 + num3 + num2, array45, 0, array45.Length);
					Array.Copy(array, 81 + num3 + num2, array46, 0, array46.Length);
					Array.Copy(array, 82 + num3 + num2, array47, 0, array47.Length);
					Array.Copy(array, 83 + num3 + num2, array48, 0, array48.Length);
					Array.Copy(array, 84 + num3 + num2, array49, 0, array49.Length);
					Array.Copy(array, 85 + num3 + num2, array50, 0, array50.Length);
					Array.Copy(array, 86 + num3 + num2, array51, 0, array51.Length);
					Array.Copy(array, 87 + num3 + num2, array52, 0, array52.Length);
					Array.Copy(array, 88 + num3 + num2, array53, 0, array53.Length);
					Array.Copy(array, 89 + num3 + num2, array54, 0, array54.Length);
					Array.Copy(array, 90 + num3 + num2, array55, 0, array55.Length);
					Array.Copy(array, 91 + num3 + num2, array56, 0, array56.Length);
					Array.Copy(array, 92 + num3 + num2, array57, 0, array57.Length);
					Array.Copy(array, 93 + num3 + num2, array58, 0, array58.Length);
					dataGridView.Rows.Add();
					dataGridView[0, num].Value = array2[0];
					dataGridView[1, num].Value = array3[0];
					dataGridView[2, num].Value = array4[0];
					dataGridView[3, num].Value = array5[0];
					dataGridView[4, num].Value = BitConverter.ToUInt16(array6, 0);
					dataGridView[5, num].Value = BitConverter.ToUInt16(array7, 0);
					dataGridView[6, num].Value = Encoding.GetEncoding("GB2312").GetString(array8).Replace("\0", "");
					dataGridView[7, num].Value = Encoding.GetEncoding("GB2312").GetString(array9).Replace("\0", "");
					dataGridView[8, num].Value = Encoding.GetEncoding("GB2312").GetString(array10).Replace("\0", "");
					dataGridView[9, num].Value = array11[0];
					dataGridView[10, num].Value = array12[0];
					dataGridView[11, num].Value = BitConverter.ToUInt16(array13, 0);
					dataGridView[12, num].Value = BitConverter.ToUInt16(array14, 0);
					dataGridView[13, num].Value = BitConverter.ToUInt16(array15, 0);
					dataGridView[14, num].Value = array16[0];
					dataGridView[15, num].Value = array17[0];
					dataGridView[16, num].Value = array18[0];
					dataGridView[17, num].Value = array19[0];
					dataGridView[18, num].Value = array20[0];
					dataGridView[19, num].Value = BitConverter.ToUInt16(array21, 0);
					dataGridView[20, num].Value = array22[0];
					dataGridView[21, num].Value = array23[0];
					dataGridView[22, num].Value = array24[0];
					dataGridView[23, num].Value = array25[0];
					dataGridView[24, num].Value = array26[0];
					dataGridView[25, num].Value = BitConverter.ToUInt16(array27, 0);
					dataGridView[26, num].Value = BitConverter.ToUInt16(array28, 0);
					dataGridView[27, num].Value = BitConverter.ToUInt16(array29, 0);
					dataGridView[28, num].Value = BitConverter.ToUInt16(array30, 0);
					dataGridView[29, num].Value = BitConverter.ToUInt16(array31, 0);
					dataGridView[30, num].Value = BitConverter.ToUInt16(array32, 0);
					dataGridView[31, num].Value = BitConverter.ToUInt16(array33, 0);
					dataGridView[32, num].Value = BitConverter.ToUInt32(array34, 0);
					dataGridView[33, num].Value = array35[0];
					dataGridView[34, num].Value = array36[0];
					dataGridView[35, num].Value = array37[0];
					dataGridView[36, num].Value = array38[0];
					dataGridView[37, num].Value = array39[0];
					dataGridView[38, num].Value = array40[0];
					dataGridView[39, num].Value = array41[0];
					dataGridView[40, num].Value = array42[0];
					dataGridView[41, num].Value = array43[0];
					dataGridView[42, num].Value = array44[0];
					dataGridView[43, num].Value = array45[0];
					dataGridView[44, num].Value = array46[0];
					dataGridView[45, num].Value = array47[0];
					dataGridView[46, num].Value = array48[0];
					dataGridView[47, num].Value = array49[0];
					dataGridView[48, num].Value = array50[0];
					dataGridView[49, num].Value = array51[0];
					dataGridView[50, num].Value = array52[0];
					dataGridView[51, num].Value = array53[0];
					dataGridView[52, num].Value = array54[0];
					dataGridView[53, num].Value = array55[0];
					dataGridView[54, num].Value = array56[0];
					dataGridView[55, num].Value = array57[0];
					dataGridView[56, num].Value = array58[0];
					dataGridView[57, num].Value = array[620];
					dataGridView[58, num].Value = array[621];
					dataGridView[59, num].Value = array[622];
					dataGridView[60, num].Value = array[623];
					dataGridView[61, num].Value = array[624];
					dataGridView[62, num].Value = array[625];
					dataGridView[63, num].Value = array[626];
					dataGridView[64, num].Value = array[627];
				}
				else if (flag)
				{
					dataGridView.Rows.Add();
					dataGridView["Group", num].Value = theGroup;
					dataGridView["Index", num].Value = num;
					for (int k = 0; k < dataGridView.Columns.Count; k++)
					{
						if (k != 4 & k != 5)
						{
							dataGridView.Rows[num].Cells[k].Value = "0";
						}
					}
				}
				num++;
			}
			this.workingDGV = dataGridView;
			dataGridView.CellValueChanged += this.ItemSeason8Episode1dgv_CellValueChanged;
			dataGridView.KeyDown += this.dgvPasteEvent_KeyDown;
			dataGridView.Disposed += this.ItemSeason8Episode1dgv_Disposed;
		}

		// Token: 0x06000502 RID: 1282 RVA: 0x00037134 File Offset: 0x00035334
		private void InitITTGridAndAddItems(int theGroup, TabPage tp)
		{
			DataGridView dataGridView = new DataGridView
			{
				Size = tp.Size
			};
			this.initializeITTGrid(dataGridView);
			tp.Controls.Add(dataGridView);
			int num = 0;
			for (int i = 512 * theGroup; i < 512 * theGroup + 512; i++)
			{
				bool flag = false;
				byte[] array = new byte[this.sBlockSize];
				for (int j = 0; j < this.sBlockSize; j++)
				{
					array[j] = this.T_fStruct[i * this.sBlockSize + j];
				}
				if (!flag)
				{
					byte[] array2 = new byte[64];
					Array.Copy(array, 4, array2, 0, 64);
					dataGridView.Rows.Add();
					if (BitConverter.ToUInt16(array, 0) != 0)
					{
						theGroup = (int)BitConverter.ToUInt16(array, 0);
					}
					dataGridView["Group", num].Value = theGroup;
					dataGridView["Index", num].Value = BitConverter.ToUInt16(array, 2);
					dataGridView["Name", num].Value = Encoding.GetEncoding("GB2312").GetString(array2).Replace('\0', ' ').Trim();
					dataGridView["Color", num].Value = BitConverter.ToInt16(array, 68);
					dataGridView["Unk_1", num].Value = BitConverter.ToInt16(array, 70);
					dataGridView["Unk_2", num].Value = BitConverter.ToInt16(array, 72);
					dataGridView["Unk_3", num].Value = BitConverter.ToInt16(array, 74);
					dataGridView["iInfoLine_1", num].Value = BitConverter.ToInt16(array, 76);
					dataGridView["Unk_4", num].Value = BitConverter.ToInt16(array, 78);
					dataGridView["iInfoLine_2", num].Value = BitConverter.ToInt16(array, 80);
					dataGridView["Unk_5", num].Value = BitConverter.ToInt16(array, 82);
					dataGridView["iInfoLine_3", num].Value = BitConverter.ToInt16(array, 84);
					dataGridView["Unk_6", num].Value = BitConverter.ToInt16(array, 86);
					dataGridView["iInfoLine_4", num].Value = BitConverter.ToInt16(array, 88);
					dataGridView["Unk_7", num].Value = BitConverter.ToInt16(array, 90);
					dataGridView["iInfoLine_5", num].Value = BitConverter.ToInt16(array, 92);
					dataGridView["Unk_8", num].Value = BitConverter.ToInt16(array, 94);
					dataGridView["iInfoLine_6", num].Value = BitConverter.ToInt16(array, 96);
					dataGridView["Unk_9", num].Value = BitConverter.ToInt16(array, 98);
					dataGridView["iInfoLine_7", num].Value = BitConverter.ToInt16(array, 100);
					dataGridView["Unk_10", num].Value = BitConverter.ToInt16(array, 102);
					dataGridView["iInfoLine_8", num].Value = BitConverter.ToInt16(array, 104);
					dataGridView["Unk_11", num].Value = BitConverter.ToInt16(array, 106);
					dataGridView["iInfoLine_9", num].Value = BitConverter.ToInt16(array, 108);
					dataGridView["Unk_12", num].Value = BitConverter.ToInt16(array, 110);
					dataGridView["iInfoLine_10", num].Value = BitConverter.ToInt16(array, 112);
					dataGridView["Unk_13", num].Value = BitConverter.ToInt16(array, 114);
					dataGridView["iInfoLine_11", num].Value = BitConverter.ToInt16(array, 116);
					dataGridView["Unk_14", num].Value = BitConverter.ToInt16(array, 118);
					dataGridView["iInfoLine_12", num].Value = BitConverter.ToInt16(array, 120);
					dataGridView["Unk_15", num].Value = BitConverter.ToInt16(array, 122);
				}
				else if (flag)
				{
					dataGridView.Rows.Add();
					dataGridView["Group", num].Value = theGroup;
					for (int k = 1; k < dataGridView.Columns.Count; k++)
					{
						dataGridView.Rows[num].Cells[k].Value = "0";
					}
				}
				num++;
			}
			this.workingDGV = dataGridView;
			dataGridView.CellValueChanged += this.ITTdgv_CellValueChanged;
			dataGridView.KeyDown += this.dgvPasteEvent_KeyDown;
			dataGridView.Disposed += this.ITTdgv_Disposed;
		}

		// Token: 0x06000503 RID: 1283 RVA: 0x00037678 File Offset: 0x00035878
		private void InitJOHSGridAndAddItems(int theGroup, TabPage tp)
		{
			DataGridView dataGridView = new DataGridView
			{
				Size = tp.Size
			};
			this.initializeJOHSGrid(dataGridView);
			tp.Controls.Add(dataGridView);
			int num = 0;
			for (int i = 512 * theGroup; i < 512 * theGroup + 512; i++)
			{
				byte[] array = new byte[this.sBlockSize];
				Array.Copy(this.T_fStruct, i * this.sBlockSize, array, 0, array.Length);
				dataGridView.Rows.Add();
				dataGridView[0, num].Value = theGroup;
				dataGridView[1, num].Value = num;
				dataGridView[2, num].Value = BitConverter.ToInt32(array, 0);
				dataGridView[3, num].Value = Encoding.GetEncoding("GB2312").GetString(array, 4, 60).Trim(new char[]
				{
					'?'
				}).Trim(new char[1]);
				dataGridView[4, num].Value = BitConverter.ToInt32(array, 64);
				num++;
			}
			this.workingDGV = dataGridView;
			dataGridView.CellValueChanged += this.JOHSdgv_CellValueChanged;
			dataGridView.KeyDown += this.dgvPasteEvent_KeyDown;
			dataGridView.Disposed += this.JOHSdgv_Disposed;
		}

		// Token: 0x06000504 RID: 1284 RVA: 0x000377E0 File Offset: 0x000359E0
		private void ISTbw_DoWork(object sender, DoWorkEventArgs e)
		{
			Form1.SendArgs sendArgs = (Form1.SendArgs)e.Argument;
			this.ItemSetTypeDec(sendArgs.filePath);
		}

		// Token: 0x06000505 RID: 1285 RVA: 0x00037808 File Offset: 0x00035A08
		private void ISTbw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this.toolStripButton_BmdItemAdder.Enabled = true;
			this.isLeaveOpenItemAdder = true;
			this.toolStripButton_AddRow.Enabled = false;
			this.toolStripButton_RemoveSelectedRow.Enabled = false;
			this.progressBar_Loading.Visible = false;
			this.tc_Items.SelectedIndex = -1;
			this.tc_Items.SelectedIndex = 0;
		}

		// Token: 0x06000506 RID: 1286 RVA: 0x00037864 File Offset: 0x00035A64
		private void ISTdgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			DataGridView dataGridView = (DataGridView)sender;
			byte b = Convert.ToByte(dataGridView[0, e.RowIndex].Value);
			int rowIndex = e.RowIndex;
			if (e.ColumnIndex == 0)
			{
				dataGridView[e.ColumnIndex, e.RowIndex].Value = b;
				return;
			}
			if (e.ColumnIndex == 1)
			{
				dataGridView[e.ColumnIndex, e.RowIndex].Value = rowIndex;
				return;
			}
			if (dataGridView.EditingControl != null)
			{
				if (dataGridView.EditingControl.Text == "")
				{
					dataGridView.EditingControl.Text = "0";
				}
			}
			else if (this.PasteValue == "")
			{
				this.PasteValue = "0";
			}
			string value = string.Empty;
			if (this.isPasteFromCP)
			{
				value = this.PasteValue;
			}
			else if (dataGridView.EditingControl != null)
			{
				value = dataGridView.EditingControl.Text;
			}
			else
			{
				value = dataGridView[e.ColumnIndex, e.RowIndex].Value.ToString();
			}
			switch (e.ColumnIndex)
			{
			case 2:
				this.T_fStruct[((int)b * 512 + rowIndex) * this.sBlockSize] = Convert.ToByte(value);
				break;
			case 3:
				this.T_fStruct[((int)b * 512 + rowIndex) * this.sBlockSize + 1] = Convert.ToByte(value);
				break;
			case 4:
				this.T_fStruct[((int)b * 512 + rowIndex) * this.sBlockSize + 2] = Convert.ToByte(value);
				break;
			case 5:
				this.T_fStruct[((int)b * 512 + rowIndex) * this.sBlockSize + 3] = Convert.ToByte(value);
				break;
			}
			dataGridView[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.PaleGreen;
		}

		// Token: 0x06000507 RID: 1287 RVA: 0x00037A44 File Offset: 0x00035C44
		private void ISTdgv_Disposed(object sender, EventArgs e)
		{
			if (Application.OpenForms["Form_Search"] != null)
			{
				Application.OpenForms["Form_Search"].Close();
			}
			if (!this.isLeaveOpenItemAdder)
			{
				if (Application.OpenForms["Form_BmdItemAddercs"] != null)
				{
					Application.OpenForms["Form_BmdItemAddercs"].Close();
				}
				this.toolStripButton_BmdItemAdder.Enabled = false;
			}
		}

		// Token: 0x06000508 RID: 1288 RVA: 0x00037AB0 File Offset: 0x00035CB0
		private void Item_S6E3_INI_Export()
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog
			{
				Title = "Select a location and file Name for the generated ItemListSettings.ini",
				FileName = "ItemListSettings.ini",
				Filter = "INI files (*.ini)|*.ini|All files (*.*)|*.*"
			};
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName)
				{
					AutoFlush = true
				};
				streamWriter.WriteLine("//Generated by MU.ToolKit coded by TopReal.IT");
				List<string> list = new List<string>();
				List<string> list2 = new List<string>();
				List<string> list3 = new List<string>();
				List<string> list4 = new List<string>();
				List<string> list5 = new List<string>();
				List<string> list6 = new List<string>();
				List<string> list7 = new List<string>();
				List<string> list8 = new List<string>();
				List<string> list9 = new List<string>();
				List<string> list10 = new List<string>();
				List<string> list11 = new List<string>();
				List<string> list12 = new List<string>();
				List<string> list13 = new List<string>();
				List<string> list14 = new List<string>();
				List<string> list15 = new List<string>();
				List<string> list16 = new List<string>();
				for (int i = 0; i < 16; i++)
				{
					this.tc_Items.SelectedIndex = i;
					string item = string.Empty;
					int num = 0;
					foreach (object obj in ((IEnumerable)this.workingDGV.Rows))
					{
						DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
						bool flag = false;
						if (num == this.workingDGV.Rows.Count - 1)
						{
							break;
						}
						foreach (object obj2 in dataGridViewRow.Cells)
						{
							DataGridViewCell dataGridViewCell = (DataGridViewCell)obj2;
							if (dataGridViewCell.Value.ToString() == "" & dataGridViewCell.ValueType != typeof(string))
							{
								dataGridViewCell.Value = "0";
							}
							if (dataGridViewCell.Value.ToString() != "0" & dataGridViewCell.ColumnIndex != 0 & dataGridViewCell.ColumnIndex != 1 & dataGridViewCell.Value.ToString() != "")
							{
								flag = true;
								break;
							}
						}
						if (flag)
						{
							switch (Convert.ToInt32(dataGridViewRow.Cells["Group"].Value))
							{
							case 0:
								item = string.Concat(new string[]
								{
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["Level"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Min Dmg"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Max Dmg"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["AtkSpeed"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Durability"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["MagicDur"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["MagicPwr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLvl"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqStr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqDex"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqEne"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqVit"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLea"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Type"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[29].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[30].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[31].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[32].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[33].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[34].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[35].Value.ToString()
								});
								list.Add(item);
								break;
							case 1:
								item = string.Concat(new string[]
								{
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["Level"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Min Dmg"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Max Dmg"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["AtkSpeed"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Durability"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["MagicDur"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["MagicPwr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLvl"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqStr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqDex"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqEne"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqVit"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLea"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Type"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[29].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[30].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[31].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[32].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[33].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[34].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[35].Value.ToString()
								});
								list2.Add(item);
								break;
							case 2:
								item = string.Concat(new string[]
								{
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["Level"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Min Dmg"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Max Dmg"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["AtkSpeed"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Durability"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["MagicDur"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["MagicPwr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLvl"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqStr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqDex"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqEne"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqVit"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLea"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Type"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[29].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[30].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[31].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[32].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[33].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[34].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[35].Value.ToString()
								});
								list3.Add(item);
								break;
							case 3:
								item = string.Concat(new string[]
								{
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["Level"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Min Dmg"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Max Dmg"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["AtkSpeed"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Durability"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["MagicDur"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["MagicPwr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLvl"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqStr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqDex"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqEne"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqVit"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLea"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Type"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[29].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[30].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[31].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[32].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[33].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[34].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[35].Value.ToString()
								});
								list4.Add(item);
								break;
							case 4:
								item = string.Concat(new string[]
								{
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["Level"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Min Dmg"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Max Dmg"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["AtkSpeed"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Durability"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["MagicDur"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["MagicPwr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLvl"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqStr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqDex"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqEne"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqVit"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLea"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Type"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[29].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[30].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[31].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[32].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[33].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[34].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[35].Value.ToString()
								});
								list5.Add(item);
								break;
							case 5:
								item = string.Concat(new string[]
								{
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["Level"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Min Dmg"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Max Dmg"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["AtkSpeed"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Durability"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["MagicDur"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["MagicPwr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLvl"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqStr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqDex"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqEne"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqVit"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLea"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Type"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[29].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[30].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[31].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[32].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[33].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[34].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[35].Value.ToString()
								});
								list6.Add(item);
								break;
							case 6:
								item = string.Concat(new string[]
								{
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["Level"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Defense"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Def Rate"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Durability"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLvl"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqStr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqDex"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqEne"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqVit"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLea"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Type"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[29].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[30].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[31].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[32].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[33].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[34].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[35].Value.ToString()
								});
								list7.Add(item);
								break;
							case 7:
								item = string.Concat(new string[]
								{
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["Level"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Defense"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Def Rate"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Durability"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLvl"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqStr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqDex"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqEne"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqVit"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLea"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Type"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[29].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[30].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[31].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[32].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[33].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[34].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[35].Value.ToString()
								});
								list8.Add(item);
								break;
							case 8:
								item = string.Concat(new string[]
								{
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["Level"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Defense"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Def Rate"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Durability"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLvl"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqStr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqDex"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqEne"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqVit"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLea"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Type"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[29].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[30].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[31].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[32].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[33].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[34].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[35].Value.ToString()
								});
								list9.Add(item);
								break;
							case 9:
								item = string.Concat(new string[]
								{
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["Level"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Defense"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Def Rate"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Durability"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLvl"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqStr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqDex"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqEne"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqVit"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLea"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Type"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[29].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[30].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[31].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[32].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[33].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[34].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[35].Value.ToString()
								});
								list10.Add(item);
								break;
							case 10:
								item = string.Concat(new string[]
								{
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["Level"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Defense"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Def Rate"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Durability"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLvl"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqStr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqDex"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqEne"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqVit"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLea"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Type"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[29].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[30].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[31].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[32].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[33].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[34].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[35].Value.ToString()
								});
								list11.Add(item);
								break;
							case 11:
								item = string.Concat(new string[]
								{
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["Level"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Defense"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Def Rate"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Durability"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLvl"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqStr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqDex"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqEne"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqVit"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLea"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Type"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[29].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[30].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[31].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[32].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[33].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[34].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[35].Value.ToString()
								});
								list12.Add(item);
								break;
							case 12:
								item = string.Concat(new string[]
								{
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["Level"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Defense"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Durability"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLvl"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqEne"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqStr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqDex"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLea"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Zen"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[29].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[30].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[31].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[32].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[33].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[34].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[35].Value.ToString()
								});
								list13.Add(item);
								break;
							case 13:
								item = string.Concat(new string[]
								{
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["Level"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Durability"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Ice Attribute"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Poison Attribute"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Lightning Attribute"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Fire Attribute"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Earth Attribute"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Wind Attribute"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Water Attribute"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Type"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[29].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[30].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[31].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[32].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[33].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[34].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[35].Value.ToString()
								});
								list14.Add(item);
								break;
							case 14:
								item = string.Concat(new string[]
								{
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["ItemValue"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Level"].Value.ToString()
								});
								list15.Add(item);
								break;
							case 15:
								item = string.Concat(new string[]
								{
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["Level"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLvl"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqEne"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Zen"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[29].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[30].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[31].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[32].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[33].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[34].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[35].Value.ToString()
								});
								list16.Add(item);
								break;
							}
							num++;
						}
					}
				}
				streamWriter.WriteLine("//Index\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tlevel\tDmgMin\tDmgMax\tASpeed\tDur\tMagDur\tMagPW\tReqLvl\tReqStr\tReqDex\tReqEne\tReqVit\tReqCmd\tSetA\tC0\tC1\tC2\tC3\tC4\tC5\tC6");
				streamWriter.WriteLine("0");
				foreach (string value in list)
				{
					streamWriter.WriteLine(value);
				}
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				streamWriter.WriteLine("//Index\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tlevel\tDmgMin\tDmgMax\tASpeed\tDur\tMagDur\tMagPW\tReqLvl\tReqStr\tReqDex\tReqEne\tReqVit\tReqCmd\tSetA\tC0\tC1\tC2\tC3\tC4\tC5\tC6");
				streamWriter.WriteLine("1");
				foreach (string value2 in list2)
				{
					streamWriter.WriteLine(value2);
				}
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				streamWriter.WriteLine("//Index\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tlevel\tDmgMin\tDmgMax\tASpeed\tDur\tMagDur\tMagPW\tReqLvl\tReqStr\tReqDex\tReqEne\tReqVit\tReqCmd\tSetA\tC0\tC1\tC2\tC3\tC4\tC5\tC6");
				streamWriter.WriteLine("2");
				foreach (string value3 in list3)
				{
					streamWriter.WriteLine(value3);
				}
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				streamWriter.WriteLine("//Index\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tlevel\tDmgMin\tDmgMax\tASpeed\tDur\tMagDur\tMagPW\tReqLvl\tReqStr\tReqDex\tReqEne\tReqVit\tReqCmd\tSetA\tC0\tC1\tC2\tC3\tC4\tC5\tC6");
				streamWriter.WriteLine("3");
				foreach (string value4 in list4)
				{
					streamWriter.WriteLine(value4);
				}
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				streamWriter.WriteLine("//Index\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tlevel\tDmgMin\tDmgMax\tASpeed\tDur\tMagDur\tMagPW\tReqLvl\tReqStr\tReqDex\tReqEne\tReqVit\tReqCmd\tSetA\tC0\tC1\tC2\tC3\tC4\tC5\tC6");
				streamWriter.WriteLine("4");
				foreach (string value5 in list5)
				{
					streamWriter.WriteLine(value5);
				}
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				streamWriter.WriteLine("//Index\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tlevel\tDmgMin\tDmgMax\tASpeed\tDur\tMagDur\tMagPW\tReqLvl\tReqStr\tReqDex\tReqEne\tReqVit\tReqCmd\tSetA\tC0\tC1\tC2\tC3\tC4\tC5\tC6");
				streamWriter.WriteLine("5");
				foreach (string value6 in list6)
				{
					streamWriter.WriteLine(value6);
				}
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				streamWriter.WriteLine("//Index\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tlevel\tDef\tDefRate\tDur\tReqLvl\tReqStr\tReqDex\tReqEne\tReqVit\tReqCmd\tSetA\tC0\tC1\tC2\tC3\tC4\tC5\tC6");
				streamWriter.WriteLine("6");
				foreach (string value7 in list7)
				{
					streamWriter.WriteLine(value7);
				}
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				streamWriter.WriteLine("//Index\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tlevel\tDef\tMagDef\tDur\tReqLvl\tReqStr\tReqDex\tReqEne\tReqVit\tReqCmd\tSetA\tC0\tC1\tC2\tC3\tC4\tC5\tC6");
				streamWriter.WriteLine("7");
				foreach (string value8 in list8)
				{
					streamWriter.WriteLine(value8);
				}
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				streamWriter.WriteLine("//Index\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tlevel\tDef\tMagDef\tDur\tReqLvl\tReqStr\tReqDex\tReqEne\tReqVit\tReqCmd\tSetA\tC0\tC1\tC2\tC3\tC4\tC5\tC6");
				streamWriter.WriteLine("8");
				foreach (string value9 in list9)
				{
					streamWriter.WriteLine(value9);
				}
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				streamWriter.WriteLine("//Index\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tlevel\tDef\tMagDef\tDur\tReqLvl\tReqStr\tReqDex\tReqEne\tReqVit\tReqCmd\tSetA\tC0\tC1\tC2\tC3\tC4\tC5\tC6");
				streamWriter.WriteLine("9");
				foreach (string value10 in list10)
				{
					streamWriter.WriteLine(value10);
				}
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				streamWriter.WriteLine("//Index\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tlevel\tDef\tASpeed\tDur\tReqLvl\tReqStr\tReqDex\tReqEne\tReqVit\tReqCmd\tSetA\tC0\tC1\tC2\tC3\tC4\tC5\tC6");
				streamWriter.WriteLine("10");
				foreach (string value11 in list11)
				{
					streamWriter.WriteLine(value11);
				}
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				streamWriter.WriteLine("//Index\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tlevel\tDef\tWSpeed\tDur\tReqLvl\tReqStr\tReqDex\tReqEne\tReqVit\tReqCmd\tSetA\tC0\tC1\tC2\tC3\tC4\tC5\tC6");
				streamWriter.WriteLine("11");
				foreach (string value12 in list12)
				{
					streamWriter.WriteLine(value12);
				}
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				streamWriter.WriteLine("//Index\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tlevel\tDef\tDur\tReqLvl\tReqEne\tReqStr\tReqDex\tReqCmd\tMoney\tC0\tC1\tC2\tC3\tC4\tC5\tC6");
				streamWriter.WriteLine("12");
				foreach (string value13 in list13)
				{
					streamWriter.WriteLine(value13);
				}
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				streamWriter.WriteLine("//Index\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tlevel\tDur\tRes1\tRes2\tRes3\tRes4\tRes5\tRes6\tRes7\tSetA\tC0\tC1\tC2\tC3\tC4\tC5\tC6");
				streamWriter.WriteLine("13");
				foreach (string value14 in list14)
				{
					streamWriter.WriteLine(value14);
				}
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				streamWriter.WriteLine("//Index\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tValue\tLevel");
				streamWriter.WriteLine("14");
				foreach (string value15 in list15)
				{
					streamWriter.WriteLine(value15);
				}
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				streamWriter.WriteLine("//Index\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tlevel\tReqLvl\tReqEne\tMoney\tC0\tC1\tC2\tC3\tC4\tC5\tC6");
				streamWriter.WriteLine("15");
				foreach (string value16 in list16)
				{
					streamWriter.WriteLine(value16);
				}
				streamWriter.WriteLine("end");
				streamWriter.Close();
				if (MessageBox.Show("File generated succesfully.\nOpen?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
				{
					Process.Start(saveFileDialog.FileName);
				}
			}
		}

		// Token: 0x06000509 RID: 1289 RVA: 0x0003C230 File Offset: 0x0003A430
		private void Item_S6E3_Save()
		{
			Form1.SendArgs sendArgs = new Form1.SendArgs();
			SaveFileDialog saveFileDialog = new SaveFileDialog
			{
				AddExtension = true,
				Title = "Select a location to save the Season 6 Episode 3 Item.bmd File",
				Filter = "BMD files (*.bmd)|*.bmd|All files (*.*)|*.*"
			};
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.toolStripProgressBar_Save.Visible = true;
				this.toolStripProgressBar_Save.Value = 0;
				this.toolStripProgressBar_Save.Size = new Size(base.Width - 460, 22);
				this.toolStripProgressBar_Save.Maximum = this.sSize;
				sendArgs.filePath = saveFileDialog.FileName;
				sendArgs.fileType = "Item_S6E3";
				this.backgroundWorker.RunWorkerAsync(sendArgs);
			}
		}

		// Token: 0x0600050A RID: 1290 RVA: 0x0003C2DC File Offset: 0x0003A4DC
		private void Item_S6E3bw_DoWork(object sender, DoWorkEventArgs e)
		{
			Form1.SendArgs sendArgs = (Form1.SendArgs)e.Argument;
			this.Item_S6E3Dec(sendArgs.filePath);
		}

		// Token: 0x0600050B RID: 1291 RVA: 0x0003C304 File Offset: 0x0003A504
		private void Item_S6E3bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this.toolStripButton_AddRow.Enabled = false;
			this.toolStripButton_RemoveSelectedRow.Enabled = false;
			this.toolStripButton_BmdItemAdder.Enabled = true;
			this.isLeaveOpenItemAdder = true;
			this.progressBar_Loading.Visible = false;
			this.tc_Items.SelectedIndex = -1;
			this.tc_Items.SelectedIndex = 0;
		}

		// Token: 0x0600050C RID: 1292 RVA: 0x0003C360 File Offset: 0x0003A560
		private DataGridView Item_S6E3Dec(string filePath)
		{
			DataGridView result = new DataGridView();
			try
			{
				StreamReader streamReader = new StreamReader(filePath);
				streamReader.ReadToEnd();
				string encodingName = streamReader.CurrentEncoding.EncodingName;
				streamReader.Close();
				this.sBlockSize = 84;
				FileStream fileStream = new FileStream(filePath, FileMode.Open);
				byte[] array = new byte[fileStream.Length];
				fileStream.Read(array, 0, array.Length);
				fileStream.Close();
				this.DecBlock(ref array, array.Length);
				Array.Resize<byte>(ref this.endBytes, 4);
				Array.Copy(array, array.Length - 4, this.endBytes, 0, 4);
				this.sSize = (array.Length - 4) / this.sBlockSize;
				this.fStruct = new object[this.sSize, this.sBlockSize];
				byte[] array2 = new byte[this.sBlockSize];
				for (int i = 0; i < this.sSize; i++)
				{
					array2 = new byte[this.sBlockSize];
					Array.Copy(array, i * this.sBlockSize, array2, 0, array2.Length);
					for (int j = 0; j < this.sBlockSize; j++)
					{
						try
						{
							this.fStruct[i, j] = array2[j];
						}
						catch
						{
						}
					}
				}
			}
			catch (Exception ex)
			{
				result = new DataGridView();
				MessageBox.Show("The selected file failed to decrypt. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			return result;
		}

		// Token: 0x0600050D RID: 1293 RVA: 0x0003C4F0 File Offset: 0x0003A6F0
		private void Item_S6E3dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			DataGridView dataGridView = (DataGridView)sender;
			int num = (int)Convert.ToInt16(dataGridView[0, e.RowIndex].Value);
			int rowIndex = e.RowIndex;
			if (e.ColumnIndex != 0 && e.ColumnIndex != 1)
			{
				if (dataGridView.EditingControl != null)
				{
					if (dataGridView.EditingControl.Text == "")
					{
						dataGridView.EditingControl.Text = "0";
					}
				}
				else if (this.PasteValue == "")
				{
					this.PasteValue = "0";
				}
				byte[] array = new byte[1];
				byte[] array2 = new byte[4];
				byte[] array3 = new byte[2];
				byte[] array4 = new byte[30];
				string text = string.Empty;
				if (this.isPasteFromCP)
				{
					text = this.PasteValue;
				}
				else if (dataGridView.EditingControl != null)
				{
					text = dataGridView.EditingControl.Text;
				}
				else
				{
					text = dataGridView[e.ColumnIndex, e.RowIndex].Value.ToString();
				}
				switch (e.ColumnIndex)
				{
				case 2:
					this.StrToByteArray(ref array4, text);
					for (int i = 0; i < array4.Length; i++)
					{
						this.fStruct[num * 512 + rowIndex, i] = array4[i];
					}
					break;
				case 3:
					array3 = BitConverter.GetBytes(Convert.ToUInt16(text));
					for (int j = 0; j < array3.Length; j++)
					{
						this.fStruct[num * 512 + rowIndex, 30 + j] = array3[j];
					}
					break;
				case 4:
					array3 = BitConverter.GetBytes(Convert.ToUInt16(text));
					for (int k = 0; k < array3.Length; k++)
					{
						this.fStruct[num * 512 + rowIndex, 32 + k] = array3[k];
					}
					break;
				case 5:
					array3 = BitConverter.GetBytes(Convert.ToUInt16(text));
					for (int l = 0; l < array3.Length; l++)
					{
						this.fStruct[num * 512 + rowIndex, 34 + l] = array3[l];
					}
					break;
				case 6:
					array3 = BitConverter.GetBytes(Convert.ToUInt16(text));
					for (int m = 0; m < array3.Length; m++)
					{
						this.fStruct[num * 512 + rowIndex, 36 + m] = array3[m];
					}
					break;
				case 7:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 38] = array[0];
					break;
				case 8:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 39] = array[0];
					break;
				case 9:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 40] = array[0];
					break;
				case 10:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 41] = array[0];
					break;
				case 11:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 42] = array[0];
					break;
				case 12:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 43] = array[0];
					break;
				case 13:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 44] = array[0];
					break;
				case 14:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 45] = array[0];
					break;
				case 15:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 46] = array[0];
					break;
				case 16:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 47] = array[0];
					break;
				case 17:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 48] = array[0];
					break;
				case 18:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 49] = array[0];
					break;
				case 19:
					array3 = BitConverter.GetBytes(Convert.ToUInt16(text));
					for (int n = 0; n < array3.Length; n++)
					{
						this.fStruct[num * 512 + rowIndex, 50 + n] = array3[n];
					}
					break;
				case 20:
					array3 = BitConverter.GetBytes(Convert.ToUInt16(text));
					for (int num2 = 0; num2 < array3.Length; num2++)
					{
						this.fStruct[num * 512 + rowIndex, 52 + num2] = array3[num2];
					}
					break;
				case 21:
					array3 = BitConverter.GetBytes(Convert.ToUInt16(text));
					for (int num3 = 0; num3 < array3.Length; num3++)
					{
						this.fStruct[num * 512 + rowIndex, 54 + num3] = array3[num3];
					}
					break;
				case 22:
					array3 = BitConverter.GetBytes(Convert.ToUInt16(text));
					for (int num4 = 0; num4 < array3.Length; num4++)
					{
						this.fStruct[num * 512 + rowIndex, 56 + num4] = array3[num4];
					}
					break;
				case 23:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 58] = array[0];
					break;
				case 24:
					array3 = BitConverter.GetBytes(Convert.ToUInt16(text));
					for (int num5 = 0; num5 < array3.Length; num5++)
					{
						this.fStruct[num * 512 + rowIndex, 60 + num5] = array3[num5];
					}
					break;
				case 25:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 62] = array[0];
					break;
				case 26:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 63] = array[0];
					break;
				case 27:
					array2 = BitConverter.GetBytes(Convert.ToUInt32(text));
					for (int num6 = 0; num6 < array2.Length; num6++)
					{
						this.fStruct[num * 512 + rowIndex, 64 + num6] = array2[num6];
					}
					break;
				case 28:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 68] = array[0];
					break;
				case 29:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 69] = array[0];
					break;
				case 30:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 70] = array[0];
					break;
				case 31:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 71] = array[0];
					break;
				case 32:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 72] = array[0];
					break;
				case 33:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 73] = array[0];
					break;
				case 34:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 74] = array[0];
					break;
				case 35:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 75] = array[0];
					break;
				case 36:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 76] = array[0];
					break;
				case 37:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 77] = array[0];
					break;
				case 38:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 78] = array[0];
					break;
				case 39:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 79] = array[0];
					break;
				case 40:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 80] = array[0];
					break;
				case 41:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 81] = array[0];
					break;
				case 42:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 82] = array[0];
					break;
				case 43:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 83] = array[0];
					break;
				}
				dataGridView[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.PaleGreen;
				return;
			}
			if (e.ColumnIndex == 0)
			{
				dataGridView[e.ColumnIndex, e.RowIndex].Value = num;
				return;
			}
			dataGridView[e.ColumnIndex, e.RowIndex].Value = rowIndex;
		}

		// Token: 0x0600050E RID: 1294 RVA: 0x0003CFF4 File Offset: 0x0003B1F4
		private void Item_S6E3dgv_Disposed(object sender, EventArgs e)
		{
			if (Application.OpenForms["Form_Search"] != null)
			{
				Application.OpenForms["Form_Search"].Close();
			}
			if (!this.isLeaveOpenItemAdder)
			{
				if (Application.OpenForms["Form_BmdItemAddercs"] != null)
				{
					Application.OpenForms["Form_BmdItemAddercs"].Close();
				}
				this.toolStripButton_BmdItemAdder.Enabled = false;
			}
		}

		// Token: 0x0600050F RID: 1295 RVA: 0x0003D060 File Offset: 0x0003B260
		private void Item_S6E3Enc(string filePath)
		{
			List<byte> list = new List<byte>();
			for (int i = 0; i < this.sSize; i++)
			{
				byte[] array = new byte[this.sBlockSize];
				for (int j = 0; j < this.sBlockSize; j++)
				{
					array[j] = Convert.ToByte(this.fStruct[i, j]);
				}
				this.EncBlock(ref array, array.Length);
				for (int k = 0; k < this.sBlockSize; k++)
				{
					list.Add(array[k]);
				}
				this.backgroundWorker.ReportProgress(i);
			}
			this.newFile = new byte[list.Count + this.endBytes.Length];
			byte[] array2 = list.ToArray<byte>();
			Array.Copy(array2, 0, this.newFile, 0, array2.Length);
			Array.Copy(this.endBytes, 0, this.newFile, this.newFile.Length - 4, this.endBytes.Length);
			Array.Copy(this.CalcCRC(this.newFile, 58097u, 0u), 0, this.newFile, this.newFile.Length - 4, 4);
			File.WriteAllBytes(filePath, this.newFile);
		}

		// Token: 0x06000510 RID: 1296 RVA: 0x0003D17C File Offset: 0x0003B37C
		private void ItemAddOption_Save()
		{
			Form1.SendArgs sendArgs = new Form1.SendArgs();
			SaveFileDialog saveFileDialog = new SaveFileDialog
			{
				AddExtension = true,
				Title = "Select a location to save the ItemAddOption.bmd File",
				Filter = "BMD files (*.bmd)|*.bmd|All files (*.*)|*.*"
			};
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.newFile = new byte[this.sSize * this.sBlockSize];
				this.toolStripProgressBar_Save.Visible = true;
				this.toolStripProgressBar_Save.Value = 0;
				this.toolStripProgressBar_Save.Size = new Size(base.Width - 460, 22);
				this.toolStripProgressBar_Save.Maximum = this.sSize * this.sBlockSize;
				base.Invalidate();
				sendArgs.filePath = saveFileDialog.FileName;
				sendArgs.fileType = "ItemAddOption";
				this.backgroundWorker.RunWorkerAsync(sendArgs);
			}
		}

		// Token: 0x06000511 RID: 1297 RVA: 0x0003D250 File Offset: 0x0003B450
		private DataGridView ItemAddOptionDec(string filePath)
		{
			DataGridView result = new DataGridView();
			try
			{
				FileStream fileStream = new FileStream(filePath, FileMode.Open);
				byte[] array = new byte[fileStream.Length];
				this.sBlockSize = 16;
				this.sSize = array.Length / this.sBlockSize;
				this.T_fStruct = new byte[this.sSize * this.sBlockSize];
				fileStream.Read(array, 0, array.Length);
				fileStream.Close();
				this.DecBlock(ref array, array.Length);
				byte[] array2 = new byte[this.sBlockSize];
				int num = 0;
				int num2 = 0;
				for (int i = 0; i < this.sSize; i++)
				{
					Array.Copy(array, i * this.sBlockSize, array2, 0, this.sBlockSize);
					bool flag = false;
					for (int j = 0; j < array2.Length; j++)
					{
						if (array2[j] != 0)
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						for (int k = 0; k < this.sBlockSize; k++)
						{
							this.T_fStruct[(512 * num2 + num) * this.sBlockSize + k] = array2[k];
						}
					}
					num++;
					if (num > 511)
					{
						num = 0;
						num2++;
					}
				}
			}
			catch (Exception ex)
			{
				result = new DataGridView();
				MessageBox.Show("The selected file failed to decrypt. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			return result;
		}

		// Token: 0x06000512 RID: 1298 RVA: 0x0003D3C4 File Offset: 0x0003B5C4
		private void ItemAddOptionEnc(string filePath)
		{
			this.newFile = this.T_fStruct;
			this.EncBlock(ref this.newFile, this.newFile.Length);
			File.WriteAllBytes(filePath, this.newFile);
		}

		// Token: 0x06000513 RID: 1299 RVA: 0x0003D3F4 File Offset: 0x0003B5F4
		private void ItemEx700_INI_Export()
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog
			{
				Title = "Select a location and file Name for the generated ItemListSettings.ini",
				FileName = "ItemListSettings.ini",
				Filter = "INI files (*.ini)|*.ini|All files (*.*)|*.*"
			};
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName)
				{
					AutoFlush = true
				};
				streamWriter.WriteLine("//Generated by MU.ToolKit coded by TopReal.IT");
				List<string> list = new List<string>();
				List<string> list2 = new List<string>();
				List<string> list3 = new List<string>();
				List<string> list4 = new List<string>();
				List<string> list5 = new List<string>();
				List<string> list6 = new List<string>();
				List<string> list7 = new List<string>();
				List<string> list8 = new List<string>();
				List<string> list9 = new List<string>();
				List<string> list10 = new List<string>();
				List<string> list11 = new List<string>();
				List<string> list12 = new List<string>();
				List<string> list13 = new List<string>();
				List<string> list14 = new List<string>();
				List<string> list15 = new List<string>();
				List<string> list16 = new List<string>();
				for (int i = 0; i < 16; i++)
				{
					this.tc_Items.SelectedIndex = i;
					string item = string.Empty;
					int num = 0;
					foreach (object obj in ((IEnumerable)this.workingDGV.Rows))
					{
						DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
						bool flag = false;
						if (num == this.workingDGV.Rows.Count - 1)
						{
							break;
						}
						foreach (object obj2 in dataGridViewRow.Cells)
						{
							DataGridViewCell dataGridViewCell = (DataGridViewCell)obj2;
							if (dataGridViewCell.Value.ToString() == "" & dataGridViewCell.ValueType != typeof(string))
							{
								dataGridViewCell.Value = "0";
							}
							if (dataGridViewCell.Value.ToString() != "0" & dataGridViewCell.ColumnIndex != 4 & dataGridViewCell.ColumnIndex != 5)
							{
								flag = true;
							}
						}
						if (flag)
						{
							switch (Convert.ToInt32(dataGridViewRow.Cells["Group"].Value))
							{
							case 0:
								item = string.Concat(new string[]
								{
									"\"",
									dataGridViewRow.Cells["Model Folder"].Value.ToString(),
									"\"\t\"",
									dataGridViewRow.Cells["Model Name"].Value.ToString(),
									"\"\t\t",
									dataGridViewRow.Cells["Type"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["Level"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Min Dmg"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Max Dmg"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["AtkSpeed"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Durability"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["MagicDur"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["MagicPwr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLvl"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqStr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqDex"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqEne"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqVit"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLea"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["SetOption"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[34].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[35].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[36].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[37].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[38].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[39].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[40].Value.ToString()
								});
								list.Add(item);
								break;
							case 1:
								item = string.Concat(new string[]
								{
									"\"",
									dataGridViewRow.Cells["Model Folder"].Value.ToString(),
									"\"\t\"",
									dataGridViewRow.Cells["Model Name"].Value.ToString(),
									"\"\t\t",
									dataGridViewRow.Cells["Type"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["Level"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Min Dmg"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Max Dmg"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["AtkSpeed"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Durability"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["MagicDur"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["MagicPwr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLvl"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqStr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqDex"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqEne"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqVit"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLea"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["SetOption"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[34].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[35].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[36].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[37].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[38].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[39].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[40].Value.ToString()
								});
								list2.Add(item);
								break;
							case 2:
								item = string.Concat(new string[]
								{
									"\"",
									dataGridViewRow.Cells["Model Folder"].Value.ToString(),
									"\"\t\"",
									dataGridViewRow.Cells["Model Name"].Value.ToString(),
									"\"\t\t",
									dataGridViewRow.Cells["Type"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["Level"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Min Dmg"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Max Dmg"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["AtkSpeed"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Durability"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["MagicDur"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["MagicPwr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLvl"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqStr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqDex"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqEne"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqVit"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLea"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["SetOption"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[34].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[35].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[36].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[37].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[38].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[39].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[40].Value.ToString()
								});
								list3.Add(item);
								break;
							case 3:
								item = string.Concat(new string[]
								{
									"\"",
									dataGridViewRow.Cells["Model Folder"].Value.ToString(),
									"\"\t\"",
									dataGridViewRow.Cells["Model Name"].Value.ToString(),
									"\"\t\t",
									dataGridViewRow.Cells["Type"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["Level"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Min Dmg"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Max Dmg"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["AtkSpeed"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Durability"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["MagicDur"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["MagicPwr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLvl"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqStr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqDex"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqEne"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqVit"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLea"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["SetOption"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[34].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[35].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[36].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[37].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[38].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[39].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[40].Value.ToString()
								});
								list4.Add(item);
								break;
							case 4:
								item = string.Concat(new string[]
								{
									"\"",
									dataGridViewRow.Cells["Model Folder"].Value.ToString(),
									"\"\t\"",
									dataGridViewRow.Cells["Model Name"].Value.ToString(),
									"\"\t\t",
									dataGridViewRow.Cells["Type"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["Level"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Min Dmg"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Max Dmg"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["AtkSpeed"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Durability"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["MagicDur"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["MagicPwr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLvl"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqStr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqDex"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqEne"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqVit"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLea"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["SetOption"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[34].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[35].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[36].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[37].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[38].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[39].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[40].Value.ToString()
								});
								list5.Add(item);
								break;
							case 5:
								item = string.Concat(new string[]
								{
									"\"",
									dataGridViewRow.Cells["Model Folder"].Value.ToString(),
									"\"\t\"",
									dataGridViewRow.Cells["Model Name"].Value.ToString(),
									"\"\t\t",
									dataGridViewRow.Cells["Type"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["Level"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Min Dmg"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Max Dmg"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["AtkSpeed"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Durability"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["MagicDur"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["MagicPwr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLvl"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqStr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqDex"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqEne"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqVit"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLea"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["SetOption"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[34].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[35].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[36].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[37].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[38].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[39].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[40].Value.ToString()
								});
								list6.Add(item);
								break;
							case 6:
								item = string.Concat(new string[]
								{
									"\"",
									dataGridViewRow.Cells["Model Folder"].Value.ToString(),
									"\"\t\"",
									dataGridViewRow.Cells["Model Name"].Value.ToString(),
									"\"\t\t",
									dataGridViewRow.Cells["Type"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["Level"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Defense"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Def Rate"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Durability"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLvl"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqStr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqDex"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqEne"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqVit"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLea"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["SetOption"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[34].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[35].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[36].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[37].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[38].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[39].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[40].Value.ToString()
								});
								list7.Add(item);
								break;
							case 7:
								item = string.Concat(new string[]
								{
									"\"",
									dataGridViewRow.Cells["Model Folder"].Value.ToString(),
									"\"\t\"",
									dataGridViewRow.Cells["Model Name"].Value.ToString(),
									"\"\t\t",
									dataGridViewRow.Cells["Type"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["Level"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Defense"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["MagicDur"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Durability"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLvl"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqStr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqDex"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqEne"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqVit"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLea"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["SetOption"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[34].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[35].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[36].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[37].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[38].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[39].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[40].Value.ToString()
								});
								list8.Add(item);
								break;
							case 8:
								item = string.Concat(new string[]
								{
									"\"",
									dataGridViewRow.Cells["Model Folder"].Value.ToString(),
									"\"\t\"",
									dataGridViewRow.Cells["Model Name"].Value.ToString(),
									"\"\t\t",
									dataGridViewRow.Cells["Type"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["Level"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Defense"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["MagicDur"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Durability"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLvl"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqStr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqDex"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqEne"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqVit"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLea"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["SetOption"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[34].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[35].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[36].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[37].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[38].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[39].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[40].Value.ToString()
								});
								list9.Add(item);
								break;
							case 9:
								item = string.Concat(new string[]
								{
									"\"",
									dataGridViewRow.Cells["Model Folder"].Value.ToString(),
									"\"\t\"",
									dataGridViewRow.Cells["Model Name"].Value.ToString(),
									"\"\t\t",
									dataGridViewRow.Cells["Type"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["Level"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Defense"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["MagicDur"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Durability"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLvl"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqStr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqDex"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqEne"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqVit"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLea"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["SetOption"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[34].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[35].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[36].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[37].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[38].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[39].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[40].Value.ToString()
								});
								list10.Add(item);
								break;
							case 10:
								item = string.Concat(new string[]
								{
									"\"",
									dataGridViewRow.Cells["Model Folder"].Value.ToString(),
									"\"\t\"",
									dataGridViewRow.Cells["Model Name"].Value.ToString(),
									"\"\t\t",
									dataGridViewRow.Cells["Type"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["Level"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Defense"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["AtkSpeed"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Durability"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLvl"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqStr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqDex"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqEne"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqVit"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLea"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["SetOption"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[34].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[35].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[36].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[37].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[38].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[39].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[40].Value.ToString()
								});
								list11.Add(item);
								break;
							case 11:
								item = string.Concat(new string[]
								{
									"\"",
									dataGridViewRow.Cells["Model Folder"].Value.ToString(),
									"\"\t\"",
									dataGridViewRow.Cells["Model Name"].Value.ToString(),
									"\"\t\t",
									dataGridViewRow.Cells["Type"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["Level"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Defense"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["WalkSpeed"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Durability"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLvl"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqStr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqDex"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqEne"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqVit"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLea"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["SetOption"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[34].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[35].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[36].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[37].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[38].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[39].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[40].Value.ToString()
								});
								list12.Add(item);
								break;
							case 12:
								item = string.Concat(new string[]
								{
									"\"",
									dataGridViewRow.Cells["Model Folder"].Value.ToString(),
									"\"\t\"",
									dataGridViewRow.Cells["Model Name"].Value.ToString(),
									"\"\t\t",
									dataGridViewRow.Cells["Type"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["Level"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Defense"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Durability"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLvl"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqStr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqDex"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqEne"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqVit"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLea"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Zen"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[34].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[35].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[36].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[37].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[38].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[39].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[40].Value.ToString()
								});
								list13.Add(item);
								break;
							case 13:
								item = string.Concat(new string[]
								{
									"\"",
									dataGridViewRow.Cells["Model Folder"].Value.ToString(),
									"\"\t\"",
									dataGridViewRow.Cells["Model Name"].Value.ToString(),
									"\"\t\t",
									dataGridViewRow.Cells["Type"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["Level"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Durability"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Ice Attribute"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Poison Attribute"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Lightning Attribute"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Fire Attribute"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Earth Attribute"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Wind Attribute"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Water Attribute"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["SetOption"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[34].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[35].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[36].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[37].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[38].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[39].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[40].Value.ToString()
								});
								list14.Add(item);
								break;
							case 14:
								item = string.Concat(new string[]
								{
									"\"",
									dataGridViewRow.Cells["Model Folder"].Value.ToString(),
									"\"\t\"",
									dataGridViewRow.Cells["Model Name"].Value.ToString(),
									"\"\t\t",
									dataGridViewRow.Cells["Type"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["ItemValue"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Level"].Value.ToString()
								});
								list15.Add(item);
								break;
							case 15:
								item = string.Concat(new string[]
								{
									"\"",
									dataGridViewRow.Cells["Model Folder"].Value.ToString(),
									"\"\t\"",
									dataGridViewRow.Cells["Model Name"].Value.ToString(),
									"\"\t\t",
									dataGridViewRow.Cells["Type"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["Level"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLvl"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqEne"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Zen"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[34].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[35].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[36].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[37].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[38].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[39].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[40].Value.ToString()
								});
								list16.Add(item);
								break;
							}
							num++;
						}
					}
				}
				streamWriter.WriteLine("//Texture\tModel\t\t\tType\tIndex\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tlevel\tDmgMin\tDmgMax\tASpeed\tDur\tMagDur\tMagPW\tReqLvl\tReqStr\tReqDex\tReqEne\tReqVit\tReqCmd\tSetA\tC0\tC1\tC2\tC3\tC4\tC5\tC6");
				streamWriter.WriteLine("0");
				foreach (string value in list)
				{
					streamWriter.WriteLine(value);
				}
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				streamWriter.WriteLine("//Texture\tModel\t\t\tType\tIndex\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tlevel\tDmgMin\tDmgMax\tASpeed\tDur\tMagDur\tMagPW\tReqLvl\tReqStr\tReqDex\tReqEne\tReqVit\tReqCmd\tSetA\tC0\tC1\tC2\tC3\tC4\tC5\tC6");
				streamWriter.WriteLine("1");
				foreach (string value2 in list2)
				{
					streamWriter.WriteLine(value2);
				}
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				streamWriter.WriteLine("//Texture\tModel\t\t\tType\tIndex\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tlevel\tDmgMin\tDmgMax\tASpeed\tDur\tMagDur\tMagPW\tReqLvl\tReqStr\tReqDex\tReqEne\tReqVit\tReqCmd\tSetA\tC0\tC1\tC2\tC3\tC4\tC5\tC6");
				streamWriter.WriteLine("2");
				foreach (string value3 in list3)
				{
					streamWriter.WriteLine(value3);
				}
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				streamWriter.WriteLine("//Texture\tModel\t\t\tType\tIndex\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tlevel\tDmgMin\tDmgMax\tASpeed\tDur\tMagDur\tMagPW\tReqLvl\tReqStr\tReqDex\tReqEne\tReqVit\tReqCmd\tSetA\tC0\tC1\tC2\tC3\tC4\tC5\tC6");
				streamWriter.WriteLine("3");
				foreach (string value4 in list4)
				{
					streamWriter.WriteLine(value4);
				}
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				streamWriter.WriteLine("//Texture\tModel\t\t\tType\tIndex\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tlevel\tDmgMin\tDmgMax\tASpeed\tDur\tMagDur\tMagPW\tReqLvl\tReqStr\tReqDex\tReqEne\tReqVit\tReqCmd\tSetA\tC0\tC1\tC2\tC3\tC4\tC5\tC6");
				streamWriter.WriteLine("4");
				foreach (string value5 in list5)
				{
					streamWriter.WriteLine(value5);
				}
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				streamWriter.WriteLine("//Texture\tModel\t\t\tType\tIndex\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tlevel\tDmgMin\tDmgMax\tASpeed\tDur\tMagDur\tMagPW\tReqLvl\tReqStr\tReqDex\tReqEne\tReqVit\tReqCmd\tSetA\tC0\tC1\tC2\tC3\tC4\tC5\tC6");
				streamWriter.WriteLine("5");
				foreach (string value6 in list6)
				{
					streamWriter.WriteLine(value6);
				}
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				streamWriter.WriteLine("//Texture\tModel\t\t\tType\tIndex\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tlevel\tDef\tDefRate\tDur\tReqLvl\tReqStr\tReqDex\tReqEne\tReqVit\tReqCmd\tSetA\tC0\tC1\tC2\tC3\tC4\tC5\tC6");
				streamWriter.WriteLine("6");
				foreach (string value7 in list7)
				{
					streamWriter.WriteLine(value7);
				}
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				streamWriter.WriteLine("//Texture\tModel\t\t\tType\tIndex\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tlevel\tDef\tMagDef\tDur\tReqLvl\tReqStr\tReqDex\tReqEne\tReqVit\tReqCmd\tSetA\tC0\tC1\tC2\tC3\tC4\tC5\tC6");
				streamWriter.WriteLine("7");
				foreach (string value8 in list8)
				{
					streamWriter.WriteLine(value8);
				}
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				streamWriter.WriteLine("//Texture\tModel\t\t\tType\tIndex\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tlevel\tDef\tMagDef\tDur\tReqLvl\tReqStr\tReqDex\tReqEne\tReqVit\tReqCmd\tSetA\tC0\tC1\tC2\tC3\tC4\tC5\tC6");
				streamWriter.WriteLine("8");
				foreach (string value9 in list9)
				{
					streamWriter.WriteLine(value9);
				}
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				streamWriter.WriteLine("//Texture\tModel\t\t\tType\tIndex\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tlevel\tDef\tMagDef\tDur\tReqLvl\tReqStr\tReqDex\tReqEne\tReqVit\tReqCmd\tSetA\tC0\tC1\tC2\tC3\tC4\tC5\tC6");
				streamWriter.WriteLine("9");
				foreach (string value10 in list10)
				{
					streamWriter.WriteLine(value10);
				}
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				streamWriter.WriteLine("//Texture\tModel\t\t\tType\tIndex\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tlevel\tDef\tASpeed\tDur\tReqLvl\tReqStr\tReqDex\tReqEne\tReqVit\tReqCmd\tSetA\tC0\tC1\tC2\tC3\tC4\tC5\tC6");
				streamWriter.WriteLine("10");
				foreach (string value11 in list11)
				{
					streamWriter.WriteLine(value11);
				}
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				streamWriter.WriteLine("//Texture\tModel\t\t\tType\tIndex\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tlevel\tDef\tWSpeed\tDur\tReqLvl\tReqStr\tReqDex\tReqEne\tReqVit\tReqCmd\tSetA\tC0\tC1\tC2\tC3\tC4\tC5\tC6");
				streamWriter.WriteLine("11");
				foreach (string value12 in list12)
				{
					streamWriter.WriteLine(value12);
				}
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				streamWriter.WriteLine("//Texture\tModel\t\t\tType\tIndex\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tlevel\tDef\tDur\tReqLvl\tReqEne\tReqStr\tReqDex\tReqCmd\tMoney\tC0\tC1\tC2\tC3\tC4\tC5\tC6");
				streamWriter.WriteLine("12");
				foreach (string value13 in list13)
				{
					streamWriter.WriteLine(value13);
				}
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				streamWriter.WriteLine("//Texture\tModel\t\t\tType\tIndex\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tlevel\tDur\tRes1\tRes2\tRes3\tRes4\tRes5\tRes6\tRes7\tSetA\tC0\tC1\tC2\tC3\tC4\tC5\tC6");
				streamWriter.WriteLine("13");
				foreach (string value14 in list14)
				{
					streamWriter.WriteLine(value14);
				}
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				streamWriter.WriteLine("//Texture\tModel\t\t\tType\tIndex\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tValue\tLevel");
				streamWriter.WriteLine("14");
				foreach (string value15 in list15)
				{
					streamWriter.WriteLine(value15);
				}
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				streamWriter.WriteLine("//Texture\tModel\t\t\tType\tIndex\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tlevel\tReqLvl\tReqEne\tMoney\tC0\tC1\tC2\tC3\tC4\tC5\tC6");
				streamWriter.WriteLine("15");
				foreach (string value16 in list16)
				{
					streamWriter.WriteLine(value16);
				}
				streamWriter.WriteLine("end");
				streamWriter.Close();
				if (MessageBox.Show("File generated succesfully.\nOpen?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
				{
					Process.Start(saveFileDialog.FileName);
				}
			}
		}

		// Token: 0x06000514 RID: 1300 RVA: 0x00042408 File Offset: 0x00040608
		private void ItemEx700_Save()
		{
			Form1.SendArgs sendArgs = new Form1.SendArgs();
			SaveFileDialog saveFileDialog = new SaveFileDialog
			{
				AddExtension = true,
				Title = "Select a location to save the ItemEx700.bmd File",
				Filter = "BMD files (*.bmd)|*.bmd|All files (*.*)|*.*"
			};
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.toolStripProgressBar_Save.Visible = true;
				this.toolStripProgressBar_Save.Value = 0;
				this.toolStripProgressBar_Save.Size = new Size(base.Width - 460, 22);
				this.toolStripProgressBar_Save.Maximum = 8192;
				sendArgs.filePath = saveFileDialog.FileName;
				sendArgs.fileType = "ItemEx700";
				this.backgroundWorker.RunWorkerAsync(sendArgs);
			}
		}

		// Token: 0x06000515 RID: 1301 RVA: 0x000424B4 File Offset: 0x000406B4
		private void ItemEx700bw_DoWork(object sender, DoWorkEventArgs e)
		{
			Form1.SendArgs sendArgs = (Form1.SendArgs)e.Argument;
			this.ItemEx700Dec(sendArgs.filePath);
		}

		// Token: 0x06000516 RID: 1302 RVA: 0x000424DC File Offset: 0x000406DC
		private void ItemEx700bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this.toolStripButton_AddRow.Enabled = false;
			this.toolStripButton_RemoveSelectedRow.Enabled = false;
			this.toolStripButton_BmdItemAdder.Enabled = true;
			this.isLeaveOpenItemAdder = true;
			this.progressBar_Loading.Visible = false;
			this.tc_Items.SelectedIndex = -1;
			this.tc_Items.SelectedIndex = 0;
		}

		// Token: 0x06000517 RID: 1303 RVA: 0x00042538 File Offset: 0x00040738
		private DataGridView ItemEx700Dec(string filePath)
		{
			DataGridView result = new DataGridView();
			try
			{
				FileStream fileStream = new FileStream(filePath, FileMode.Open);
				byte[] array = new byte[fileStream.Length];
				long length = fileStream.Length;
				fileStream.Read(array, 0, array.Length);
				fileStream.Close();
				Array.Resize<byte>(ref this.startBytes, 4);
				Array.Copy(array, 0, this.startBytes, 0, 4);
				this.sSize = BitConverter.ToInt32(this.startBytes, 0);
				Array.Resize<byte>(ref this.endBytes, 4);
				this.fStruct = new object[8192, this.sBlockSize];
				Array.Copy(array, array.Length - 4, this.endBytes, 0, 4);
				byte[] array2 = new byte[this.sBlockSize];
				for (int i = 0; i < this.sSize; i++)
				{
					array2 = new byte[this.sBlockSize];
					try
					{
						Array.Copy(array, i * this.sBlockSize + 4, array2, 0, array2.Length);
					}
					catch
					{
					}
					this.DecBlock(ref array2, array2.Length);
					for (int j = 0; j < this.sBlockSize; j++)
					{
						try
						{
							this.fStruct[(int)(BitConverter.ToUInt16(array2, 4) * 512 + BitConverter.ToUInt16(array2, 6)), j] = array2[j];
						}
						catch
						{
						}
					}
				}
			}
			catch (Exception ex)
			{
				result = new DataGridView();
				MessageBox.Show("The selected file failed to decrypt. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			return result;
		}

		// Token: 0x06000518 RID: 1304 RVA: 0x000426F0 File Offset: 0x000408F0
		private void ItemEx700dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			DataGridView dataGridView = (DataGridView)sender;
			int num = (int)Convert.ToInt16(dataGridView[4, e.RowIndex].Value);
			int rowIndex = e.RowIndex;
			if (e.ColumnIndex != 5 && e.ColumnIndex != 4)
			{
				if (dataGridView.EditingControl != null)
				{
					if (dataGridView.EditingControl.Text == "")
					{
						dataGridView.EditingControl.Text = "0";
					}
				}
				else if (this.PasteValue == "")
				{
					this.PasteValue = "0";
				}
				byte[] array = new byte[1];
				byte[] array2 = new byte[4];
				byte[] array3 = new byte[2];
				byte[] array4 = new byte[30];
				byte[] array5 = new byte[30];
				string text = string.Empty;
				if (this.isPasteFromCP)
				{
					text = this.PasteValue;
				}
				else if (dataGridView.EditingControl != null)
				{
					text = dataGridView.EditingControl.Text;
				}
				else
				{
					text = dataGridView[e.ColumnIndex, e.RowIndex].Value.ToString();
				}
				if (this.fStruct[num * 512 + rowIndex, 0] == null)
				{
					array3 = BitConverter.GetBytes(Convert.ToUInt16(num));
					for (int i = 0; i < array3.Length; i++)
					{
						this.fStruct[num * 512 + rowIndex, 4 + i] = array3[i];
					}
					array3 = BitConverter.GetBytes(Convert.ToUInt16(dataGridView[5, e.RowIndex].Value));
					for (int j = 0; j < array3.Length; j++)
					{
						this.fStruct[num * 512 + rowIndex, 6 + j] = array3[j];
					}
					for (int k = 0; k < this.sBlockSize; k++)
					{
						if (k != 4 & k != 5 & k != 6 & k != 7)
						{
							this.fStruct[num * 512 + rowIndex, k] = 0;
						}
					}
				}
				int num2 = 520;
				int num3 = 8;
				switch (e.ColumnIndex)
				{
				case 0:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 0] = array[0];
					break;
				case 1:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 1] = array[0];
					break;
				case 2:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 2] = array[0];
					break;
				case 3:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 3] = array[0];
					break;
				case 6:
					this.StrToByteArray(ref array5, text);
					for (int l = 0; l < array5.Length; l++)
					{
						this.fStruct[num * 512 + rowIndex, l + num3] = array5[l];
					}
					break;
				case 7:
					this.StrToByteArray(ref array5, text);
					for (int m = 0; m < array5.Length; m++)
					{
						this.fStruct[num * 512 + rowIndex, 260 + m + num3] = array5[m];
					}
					break;
				case 8:
					if (text == "0")
					{
						text = "";
					}
					this.StrToByteArray(ref array4, text);
					for (int n = 0; n < array4.Length; n++)
					{
						this.fStruct[num * 512 + rowIndex, 520 + n + num3] = array4[n];
					}
					break;
				case 9:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 30 + num2 + num3] = array[0];
					break;
				case 10:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 31 + num2 + num3] = array[0];
					break;
				case 11:
					array3 = BitConverter.GetBytes(Convert.ToUInt16(text));
					for (int num4 = 0; num4 < array3.Length; num4++)
					{
						this.fStruct[num * 512 + rowIndex, 32 + num2 + num3 + num4] = array3[num4];
					}
					break;
				case 12:
					array3 = BitConverter.GetBytes(Convert.ToUInt16(text));
					for (int num5 = 0; num5 < array3.Length; num5++)
					{
						this.fStruct[num * 512 + rowIndex, 34 + num2 + num3 + num5] = array3[num5];
					}
					break;
				case 13:
					array3 = BitConverter.GetBytes(Convert.ToUInt16(text));
					for (int num6 = 0; num6 < array3.Length; num6++)
					{
						this.fStruct[num * 512 + rowIndex, 36 + num2 + num3 + num6] = array3[num6];
					}
					break;
				case 14:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 38 + num2 + num3] = array[0];
					break;
				case 15:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 39 + num2 + num3] = array[0];
					break;
				case 16:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 40 + num2 + num3] = array[0];
					break;
				case 17:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 41 + num2 + num3] = array[0];
					break;
				case 18:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 42 + num2 + num3] = array[0];
					break;
				case 19:
					array3 = BitConverter.GetBytes(Convert.ToUInt16(text));
					for (int num7 = 0; num7 < array3.Length; num7++)
					{
						this.fStruct[num * 512 + rowIndex, 43 + num2 + num3 + num7] = array3[num7];
					}
					break;
				case 20:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 45 + num2 + num3] = array[0];
					break;
				case 21:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 46 + num2 + num3] = array[0];
					break;
				case 22:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 47 + num2 + num3] = array[0];
					break;
				case 23:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 48 + num2 + num3] = array[0];
					break;
				case 24:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 49 + num2 + num3] = array[0];
					break;
				case 25:
					array3 = BitConverter.GetBytes(Convert.ToUInt16(text));
					for (int num8 = 0; num8 < array3.Length; num8++)
					{
						this.fStruct[num * 512 + rowIndex, 50 + num2 + num3 + num8] = array3[num8];
					}
					break;
				case 26:
					array3 = BitConverter.GetBytes(Convert.ToUInt16(text));
					for (int num9 = 0; num9 < array3.Length; num9++)
					{
						this.fStruct[num * 512 + rowIndex, 52 + num2 + num3 + num9] = array3[num9];
					}
					break;
				case 27:
					array3 = BitConverter.GetBytes(Convert.ToUInt16(text));
					for (int num10 = 0; num10 < array3.Length; num10++)
					{
						this.fStruct[num * 512 + rowIndex, 54 + num2 + num3 + num10] = array3[num10];
					}
					break;
				case 28:
					array3 = BitConverter.GetBytes(Convert.ToUInt16(text));
					for (int num11 = 0; num11 < array3.Length; num11++)
					{
						this.fStruct[num * 512 + rowIndex, 56 + num2 + num3 + num11] = array3[num11];
					}
					break;
				case 29:
					array3 = BitConverter.GetBytes(Convert.ToUInt16(text));
					for (int num12 = 0; num12 < array3.Length; num12++)
					{
						this.fStruct[num * 512 + rowIndex, 58 + num2 + num3 + num12] = array3[num12];
					}
					break;
				case 30:
					array3 = BitConverter.GetBytes(Convert.ToUInt16(text));
					for (int num13 = 0; num13 < array3.Length; num13++)
					{
						this.fStruct[num * 512 + rowIndex, 60 + num2 + num3 + num13] = array3[num13];
					}
					break;
				case 31:
					array3 = BitConverter.GetBytes(Convert.ToUInt16(text));
					for (int num14 = 0; num14 < array3.Length; num14++)
					{
						this.fStruct[num * 512 + rowIndex, 62 + num2 + num3 + num14] = array3[num14];
					}
					break;
				case 32:
					array2 = BitConverter.GetBytes(Convert.ToUInt32(text));
					for (int num15 = 0; num15 < array2.Length; num15++)
					{
						this.fStruct[num * 512 + rowIndex, 64 + num2 + num3 + num15] = array2[num15];
					}
					break;
				case 33:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 68 + num2 + num3] = array[0];
					break;
				case 34:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 69 + num2 + num3] = array[0];
					break;
				case 35:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 70 + num2 + num3] = array[0];
					break;
				case 36:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 71 + num2 + num3] = array[0];
					break;
				case 37:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 72 + num2 + num3] = array[0];
					break;
				case 38:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 73 + num2 + num3] = array[0];
					break;
				case 39:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 74 + num2 + num3] = array[0];
					break;
				case 40:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 75 + num2 + num3] = array[0];
					break;
				case 41:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 76 + num2 + num3] = array[0];
					break;
				case 42:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 77 + num2 + num3] = array[0];
					break;
				case 43:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 78 + num2 + num3] = array[0];
					break;
				case 44:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 79 + num2 + num3] = array[0];
					break;
				case 45:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 80 + num2 + num3] = array[0];
					break;
				case 46:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 81 + num2 + num3] = array[0];
					break;
				case 47:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 82 + num2 + num3] = array[0];
					break;
				case 48:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 83 + num2 + num3] = array[0];
					break;
				}
				dataGridView[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.PaleGreen;
				bool flag = true;
				foreach (object obj in dataGridView.Columns)
				{
					DataGridViewColumn dataGridViewColumn = (DataGridViewColumn)obj;
					if (dataGridView[dataGridViewColumn.Index, e.RowIndex].Value != null)
					{
						if (dataGridView[dataGridViewColumn.Index, e.RowIndex].Value.ToString() != "0")
						{
							flag = false;
						}
					}
					else if (dataGridView.EditingControl.Text != "0")
					{
						flag = false;
					}
				}
				if (flag)
				{
					for (int num16 = 0; num16 < this.sBlockSize; num16++)
					{
						this.fStruct[num * 512 + rowIndex, num16] = null;
					}
				}
				return;
			}
			if (e.ColumnIndex == 4)
			{
				dataGridView[e.ColumnIndex, e.RowIndex].Value = num;
				return;
			}
			dataGridView[e.ColumnIndex, e.RowIndex].Value = rowIndex;
		}

		// Token: 0x06000519 RID: 1305 RVA: 0x00043668 File Offset: 0x00041868
		private void ItemEx700dgv_Disposed(object sender, EventArgs e)
		{
			if (Application.OpenForms["Form_Search"] != null)
			{
				Application.OpenForms["Form_Search"].Close();
			}
			if (!this.isLeaveOpenItemAdder)
			{
				if (Application.OpenForms["Form_BmdItemAddercs"] != null)
				{
					Application.OpenForms["Form_BmdItemAddercs"].Close();
				}
				this.toolStripButton_BmdItemAdder.Enabled = false;
			}
		}

		// Token: 0x0600051A RID: 1306 RVA: 0x000436D4 File Offset: 0x000418D4
		private void ItemEx700Enc(string filePath)
		{
			List<byte> list = new List<byte>();
			for (int i = 0; i < 8192; i++)
			{
				bool flag = false;
				for (int j = 528; j < 558; j++)
				{
					if (Convert.ToByte(this.fStruct[i, j]) != 0)
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					for (int k = 0; k < this.sBlockSize; k++)
					{
						list.Add(Convert.ToByte(this.fStruct[i, k]));
					}
				}
				this.backgroundWorker.ReportProgress(i);
			}
			this.newFile = new byte[4 + list.Count + this.endBytes.Length];
			this.startBytes = BitConverter.GetBytes(list.Count / this.sBlockSize);
			Array.Copy(this.startBytes, 0, this.newFile, 0, 4);
			byte[] array = list.ToArray<byte>();
			this.EncBlock(ref array, array.Length);
			Array.Copy(array, 0, this.newFile, 4, array.Length);
			Array.Copy(this.endBytes, 0, this.newFile, this.newFile.Length - 4, this.endBytes.Length);
			this.CalcCRC(this.newFile, 58097u, 0u);
			File.WriteAllBytes(filePath, this.newFile);
		}

		// Token: 0x0600051B RID: 1307 RVA: 0x00043814 File Offset: 0x00041A14
		private void ItemEx700Plus_INI_Export()
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog
			{
				Title = "Select a location and file Name for the generated ItemListSettings.ini",
				FileName = "ItemListSettings.ini",
				Filter = "INI files (*.ini)|*.ini|All files (*.*)|*.*"
			};
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName)
				{
					AutoFlush = true
				};
				streamWriter.WriteLine("//Generated by MU.ToolKit coded by TopReal.IT");
				List<string> list = new List<string>();
				List<string> list2 = new List<string>();
				List<string> list3 = new List<string>();
				List<string> list4 = new List<string>();
				List<string> list5 = new List<string>();
				List<string> list6 = new List<string>();
				List<string> list7 = new List<string>();
				List<string> list8 = new List<string>();
				List<string> list9 = new List<string>();
				List<string> list10 = new List<string>();
				List<string> list11 = new List<string>();
				List<string> list12 = new List<string>();
				List<string> list13 = new List<string>();
				List<string> list14 = new List<string>();
				List<string> list15 = new List<string>();
				List<string> list16 = new List<string>();
				for (int i = 0; i < 16; i++)
				{
					this.tc_Items.SelectedIndex = i;
					string item = string.Empty;
					int num = 0;
					foreach (object obj in ((IEnumerable)this.workingDGV.Rows))
					{
						DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
						bool flag = false;
						if (num == this.workingDGV.Rows.Count - 1)
						{
							break;
						}
						foreach (object obj2 in dataGridViewRow.Cells)
						{
							DataGridViewCell dataGridViewCell = (DataGridViewCell)obj2;
							if (dataGridViewCell.Value.ToString() == "" & dataGridViewCell.ValueType != typeof(string))
							{
								dataGridViewCell.Value = "0";
							}
							if (dataGridViewCell.Value.ToString() != "0" & dataGridViewCell.ColumnIndex != 4 & dataGridViewCell.ColumnIndex != 5)
							{
								flag = true;
							}
						}
						if (flag)
						{
							switch (Convert.ToInt32(dataGridViewRow.Cells["Group"].Value))
							{
							case 0:
								item = string.Concat(new string[]
								{
									"\"",
									dataGridViewRow.Cells["Model Folder"].Value.ToString(),
									"\"\t\"",
									dataGridViewRow.Cells["Model Name"].Value.ToString(),
									"\"\t\t",
									dataGridViewRow.Cells["Type"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["Level"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Min Dmg"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Max Dmg"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["AtkSpeed"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Durability"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["MagicDur"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["MagicPwr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLvl"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqStr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqDex"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqEne"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqVit"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLea"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["SetOption"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[34].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[35].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[36].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[37].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[38].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[39].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[40].Value.ToString()
								});
								list.Add(item);
								break;
							case 1:
								item = string.Concat(new string[]
								{
									"\"",
									dataGridViewRow.Cells["Model Folder"].Value.ToString(),
									"\"\t\"",
									dataGridViewRow.Cells["Model Name"].Value.ToString(),
									"\"\t\t",
									dataGridViewRow.Cells["Type"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["Level"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Min Dmg"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Max Dmg"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["AtkSpeed"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Durability"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["MagicDur"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["MagicPwr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLvl"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqStr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqDex"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqEne"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqVit"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLea"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["SetOption"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[34].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[35].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[36].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[37].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[38].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[39].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[40].Value.ToString()
								});
								list2.Add(item);
								break;
							case 2:
								item = string.Concat(new string[]
								{
									"\"",
									dataGridViewRow.Cells["Model Folder"].Value.ToString(),
									"\"\t\"",
									dataGridViewRow.Cells["Model Name"].Value.ToString(),
									"\"\t\t",
									dataGridViewRow.Cells["Type"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["Level"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Min Dmg"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Max Dmg"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["AtkSpeed"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Durability"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["MagicDur"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["MagicPwr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLvl"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqStr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqDex"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqEne"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqVit"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLea"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["SetOption"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[34].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[35].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[36].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[37].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[38].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[39].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[40].Value.ToString()
								});
								list3.Add(item);
								break;
							case 3:
								item = string.Concat(new string[]
								{
									"\"",
									dataGridViewRow.Cells["Model Folder"].Value.ToString(),
									"\"\t\"",
									dataGridViewRow.Cells["Model Name"].Value.ToString(),
									"\"\t\t",
									dataGridViewRow.Cells["Type"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["Level"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Min Dmg"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Max Dmg"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["AtkSpeed"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Durability"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["MagicDur"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["MagicPwr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLvl"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqStr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqDex"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqEne"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqVit"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLea"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["SetOption"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[34].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[35].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[36].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[37].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[38].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[39].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[40].Value.ToString()
								});
								list4.Add(item);
								break;
							case 4:
								item = string.Concat(new string[]
								{
									"\"",
									dataGridViewRow.Cells["Model Folder"].Value.ToString(),
									"\"\t\"",
									dataGridViewRow.Cells["Model Name"].Value.ToString(),
									"\"\t\t",
									dataGridViewRow.Cells["Type"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["Level"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Min Dmg"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Max Dmg"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["AtkSpeed"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Durability"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["MagicDur"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["MagicPwr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLvl"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqStr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqDex"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqEne"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqVit"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLea"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["SetOption"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[34].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[35].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[36].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[37].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[38].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[39].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[40].Value.ToString()
								});
								list5.Add(item);
								break;
							case 5:
								item = string.Concat(new string[]
								{
									"\"",
									dataGridViewRow.Cells["Model Folder"].Value.ToString(),
									"\"\t\"",
									dataGridViewRow.Cells["Model Name"].Value.ToString(),
									"\"\t\t",
									dataGridViewRow.Cells["Type"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["Level"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Min Dmg"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Max Dmg"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["AtkSpeed"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Durability"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["MagicDur"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["MagicPwr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLvl"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqStr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqDex"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqEne"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqVit"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLea"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["SetOption"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[34].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[35].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[36].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[37].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[38].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[39].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[40].Value.ToString()
								});
								list6.Add(item);
								break;
							case 6:
								item = string.Concat(new string[]
								{
									"\"",
									dataGridViewRow.Cells["Model Folder"].Value.ToString(),
									"\"\t\"",
									dataGridViewRow.Cells["Model Name"].Value.ToString(),
									"\"\t\t",
									dataGridViewRow.Cells["Type"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["Level"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Defense"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Def Rate"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Durability"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLvl"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqStr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqDex"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqEne"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqVit"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLea"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["SetOption"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[34].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[35].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[36].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[37].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[38].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[39].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[40].Value.ToString()
								});
								list7.Add(item);
								break;
							case 7:
								item = string.Concat(new string[]
								{
									"\"",
									dataGridViewRow.Cells["Model Folder"].Value.ToString(),
									"\"\t\"",
									dataGridViewRow.Cells["Model Name"].Value.ToString(),
									"\"\t\t",
									dataGridViewRow.Cells["Type"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["Level"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Defense"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["MagicDur"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Durability"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLvl"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqStr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqDex"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqEne"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqVit"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLea"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["SetOption"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[34].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[35].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[36].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[37].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[38].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[39].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[40].Value.ToString()
								});
								list8.Add(item);
								break;
							case 8:
								item = string.Concat(new string[]
								{
									"\"",
									dataGridViewRow.Cells["Model Folder"].Value.ToString(),
									"\"\t\"",
									dataGridViewRow.Cells["Model Name"].Value.ToString(),
									"\"\t\t",
									dataGridViewRow.Cells["Type"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["Level"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Defense"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["MagicDur"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Durability"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLvl"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqStr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqDex"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqEne"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqVit"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLea"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["SetOption"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[34].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[35].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[36].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[37].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[38].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[39].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[40].Value.ToString()
								});
								list9.Add(item);
								break;
							case 9:
								item = string.Concat(new string[]
								{
									"\"",
									dataGridViewRow.Cells["Model Folder"].Value.ToString(),
									"\"\t\"",
									dataGridViewRow.Cells["Model Name"].Value.ToString(),
									"\"\t\t",
									dataGridViewRow.Cells["Type"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["Level"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Defense"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["MagicDur"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Durability"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLvl"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqStr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqDex"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqEne"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqVit"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLea"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["SetOption"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[34].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[35].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[36].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[37].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[38].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[39].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[40].Value.ToString()
								});
								list10.Add(item);
								break;
							case 10:
								item = string.Concat(new string[]
								{
									"\"",
									dataGridViewRow.Cells["Model Folder"].Value.ToString(),
									"\"\t\"",
									dataGridViewRow.Cells["Model Name"].Value.ToString(),
									"\"\t\t",
									dataGridViewRow.Cells["Type"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["Level"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Defense"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["AtkSpeed"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Durability"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLvl"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqStr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqDex"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqEne"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqVit"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLea"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["SetOption"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[34].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[35].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[36].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[37].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[38].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[39].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[40].Value.ToString()
								});
								list11.Add(item);
								break;
							case 11:
								item = string.Concat(new string[]
								{
									"\"",
									dataGridViewRow.Cells["Model Folder"].Value.ToString(),
									"\"\t\"",
									dataGridViewRow.Cells["Model Name"].Value.ToString(),
									"\"\t\t",
									dataGridViewRow.Cells["Type"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["Level"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Defense"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["WalkSpeed"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Durability"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLvl"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqStr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqDex"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqEne"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqVit"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLea"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["SetOption"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[34].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[35].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[36].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[37].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[38].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[39].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[40].Value.ToString()
								});
								list12.Add(item);
								break;
							case 12:
								item = string.Concat(new string[]
								{
									"\"",
									dataGridViewRow.Cells["Model Folder"].Value.ToString(),
									"\"\t\"",
									dataGridViewRow.Cells["Model Name"].Value.ToString(),
									"\"\t\t",
									dataGridViewRow.Cells["Type"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["Level"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Defense"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Durability"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLvl"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqStr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqDex"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqEne"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqVit"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLea"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Zen"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[34].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[35].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[36].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[37].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[38].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[39].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[40].Value.ToString()
								});
								list13.Add(item);
								break;
							case 13:
								item = string.Concat(new string[]
								{
									"\"",
									dataGridViewRow.Cells["Model Folder"].Value.ToString(),
									"\"\t\"",
									dataGridViewRow.Cells["Model Name"].Value.ToString(),
									"\"\t\t",
									dataGridViewRow.Cells["Type"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["Level"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Durability"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Ice Attribute"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Poison Attribute"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Lightning Attribute"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Fire Attribute"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Earth Attribute"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Wind Attribute"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Water Attribute"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["SetOption"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[34].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[35].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[36].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[37].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[38].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[39].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[40].Value.ToString()
								});
								list14.Add(item);
								break;
							case 14:
								item = string.Concat(new string[]
								{
									"\"",
									dataGridViewRow.Cells["Model Folder"].Value.ToString(),
									"\"\t\"",
									dataGridViewRow.Cells["Model Name"].Value.ToString(),
									"\"\t\t",
									dataGridViewRow.Cells["Type"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["ItemValue"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Level"].Value.ToString()
								});
								list15.Add(item);
								break;
							case 15:
								item = string.Concat(new string[]
								{
									"\"",
									dataGridViewRow.Cells["Model Folder"].Value.ToString(),
									"\"\t\"",
									dataGridViewRow.Cells["Model Name"].Value.ToString(),
									"\"\t\t",
									dataGridViewRow.Cells["Type"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["Level"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLvl"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqEne"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Zen"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[34].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[35].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[36].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[37].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[38].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[39].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[40].Value.ToString()
								});
								list16.Add(item);
								break;
							}
							num++;
						}
					}
				}
				streamWriter.WriteLine("//Texture\tModel\t\t\tType\tIndex\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tlevel\tDmgMin\tDmgMax\tASpeed\tDur\tMagDur\tMagPW\tReqLvl\tReqStr\tReqDex\tReqEne\tReqVit\tReqCmd\tSetA\tC0\tC1\tC2\tC3\tC4\tC5\tC6");
				streamWriter.WriteLine("0");
				foreach (string value in list)
				{
					streamWriter.WriteLine(value);
				}
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				streamWriter.WriteLine("//Texture\tModel\t\t\tType\tIndex\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tlevel\tDmgMin\tDmgMax\tASpeed\tDur\tMagDur\tMagPW\tReqLvl\tReqStr\tReqDex\tReqEne\tReqVit\tReqCmd\tSetA\tC0\tC1\tC2\tC3\tC4\tC5\tC6");
				streamWriter.WriteLine("1");
				foreach (string value2 in list2)
				{
					streamWriter.WriteLine(value2);
				}
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				streamWriter.WriteLine("//Texture\tModel\t\t\tType\tIndex\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tlevel\tDmgMin\tDmgMax\tASpeed\tDur\tMagDur\tMagPW\tReqLvl\tReqStr\tReqDex\tReqEne\tReqVit\tReqCmd\tSetA\tC0\tC1\tC2\tC3\tC4\tC5\tC6");
				streamWriter.WriteLine("2");
				foreach (string value3 in list3)
				{
					streamWriter.WriteLine(value3);
				}
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				streamWriter.WriteLine("//Texture\tModel\t\t\tType\tIndex\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tlevel\tDmgMin\tDmgMax\tASpeed\tDur\tMagDur\tMagPW\tReqLvl\tReqStr\tReqDex\tReqEne\tReqVit\tReqCmd\tSetA\tC0\tC1\tC2\tC3\tC4\tC5\tC6");
				streamWriter.WriteLine("3");
				foreach (string value4 in list4)
				{
					streamWriter.WriteLine(value4);
				}
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				streamWriter.WriteLine("//Texture\tModel\t\t\tType\tIndex\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tlevel\tDmgMin\tDmgMax\tASpeed\tDur\tMagDur\tMagPW\tReqLvl\tReqStr\tReqDex\tReqEne\tReqVit\tReqCmd\tSetA\tC0\tC1\tC2\tC3\tC4\tC5\tC6");
				streamWriter.WriteLine("4");
				foreach (string value5 in list5)
				{
					streamWriter.WriteLine(value5);
				}
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				streamWriter.WriteLine("//Texture\tModel\t\t\tType\tIndex\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tlevel\tDmgMin\tDmgMax\tASpeed\tDur\tMagDur\tMagPW\tReqLvl\tReqStr\tReqDex\tReqEne\tReqVit\tReqCmd\tSetA\tC0\tC1\tC2\tC3\tC4\tC5\tC6");
				streamWriter.WriteLine("5");
				foreach (string value6 in list6)
				{
					streamWriter.WriteLine(value6);
				}
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				streamWriter.WriteLine("//Texture\tModel\t\t\tType\tIndex\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tlevel\tDef\tDefRate\tDur\tReqLvl\tReqStr\tReqDex\tReqEne\tReqVit\tReqCmd\tSetA\tC0\tC1\tC2\tC3\tC4\tC5\tC6");
				streamWriter.WriteLine("6");
				foreach (string value7 in list7)
				{
					streamWriter.WriteLine(value7);
				}
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				streamWriter.WriteLine("//Texture\tModel\t\t\tType\tIndex\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tlevel\tDef\tMagDef\tDur\tReqLvl\tReqStr\tReqDex\tReqEne\tReqVit\tReqCmd\tSetA\tC0\tC1\tC2\tC3\tC4\tC5\tC6");
				streamWriter.WriteLine("7");
				foreach (string value8 in list8)
				{
					streamWriter.WriteLine(value8);
				}
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				streamWriter.WriteLine("//Texture\tModel\t\t\tType\tIndex\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tlevel\tDef\tMagDef\tDur\tReqLvl\tReqStr\tReqDex\tReqEne\tReqVit\tReqCmd\tSetA\tC0\tC1\tC2\tC3\tC4\tC5\tC6");
				streamWriter.WriteLine("8");
				foreach (string value9 in list9)
				{
					streamWriter.WriteLine(value9);
				}
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				streamWriter.WriteLine("//Texture\tModel\t\t\tType\tIndex\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tlevel\tDef\tMagDef\tDur\tReqLvl\tReqStr\tReqDex\tReqEne\tReqVit\tReqCmd\tSetA\tC0\tC1\tC2\tC3\tC4\tC5\tC6");
				streamWriter.WriteLine("9");
				foreach (string value10 in list10)
				{
					streamWriter.WriteLine(value10);
				}
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				streamWriter.WriteLine("//Texture\tModel\t\t\tType\tIndex\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tlevel\tDef\tASpeed\tDur\tReqLvl\tReqStr\tReqDex\tReqEne\tReqVit\tReqCmd\tSetA\tC0\tC1\tC2\tC3\tC4\tC5\tC6");
				streamWriter.WriteLine("10");
				foreach (string value11 in list11)
				{
					streamWriter.WriteLine(value11);
				}
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				streamWriter.WriteLine("//Texture\tModel\t\t\tType\tIndex\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tlevel\tDef\tWSpeed\tDur\tReqLvl\tReqStr\tReqDex\tReqEne\tReqVit\tReqCmd\tSetA\tC0\tC1\tC2\tC3\tC4\tC5\tC6");
				streamWriter.WriteLine("11");
				foreach (string value12 in list12)
				{
					streamWriter.WriteLine(value12);
				}
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				streamWriter.WriteLine("//Texture\tModel\t\t\tType\tIndex\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tlevel\tDef\tDur\tReqLvl\tReqEne\tReqStr\tReqDex\tReqCmd\tMoney\tC0\tC1\tC2\tC3\tC4\tC5\tC6");
				streamWriter.WriteLine("12");
				foreach (string value13 in list13)
				{
					streamWriter.WriteLine(value13);
				}
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				streamWriter.WriteLine("//Texture\tModel\t\t\tType\tIndex\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tlevel\tDur\tRes1\tRes2\tRes3\tRes4\tRes5\tRes6\tRes7\tSetA\tC0\tC1\tC2\tC3\tC4\tC5\tC6");
				streamWriter.WriteLine("13");
				foreach (string value14 in list14)
				{
					streamWriter.WriteLine(value14);
				}
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				streamWriter.WriteLine("//Texture\tModel\t\t\tType\tIndex\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tValue\tLevel");
				streamWriter.WriteLine("14");
				foreach (string value15 in list15)
				{
					streamWriter.WriteLine(value15);
				}
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				streamWriter.WriteLine("//Texture\tModel\t\t\tType\tIndex\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tlevel\tReqLvl\tReqEne\tMoney\tC0\tC1\tC2\tC3\tC4\tC5\tC6");
				streamWriter.WriteLine("15");
				foreach (string value16 in list16)
				{
					streamWriter.WriteLine(value16);
				}
				streamWriter.WriteLine("end");
				streamWriter.Close();
				if (MessageBox.Show("File generated succesfully.\nOpen?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
				{
					Process.Start(saveFileDialog.FileName);
				}
			}
		}

		// Token: 0x0600051C RID: 1308 RVA: 0x00048828 File Offset: 0x00046A28
		private void ItemEx700Plus_Save()
		{
			Form1.SendArgs sendArgs = new Form1.SendArgs();
			SaveFileDialog saveFileDialog = new SaveFileDialog
			{
				AddExtension = true,
				Title = "Select a location to save the Ex700Plus Item.bmd File",
				Filter = "BMD files (*.bmd)|*.bmd|All files (*.*)|*.*"
			};
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.toolStripProgressBar_Save.Visible = true;
				this.toolStripProgressBar_Save.Value = 0;
				this.toolStripProgressBar_Save.Size = new Size(base.Width - 460, 22);
				this.toolStripProgressBar_Save.Maximum = 8192;
				sendArgs.filePath = saveFileDialog.FileName;
				sendArgs.fileType = "ItemEx700Plus";
				this.backgroundWorker.RunWorkerAsync(sendArgs);
			}
		}

		// Token: 0x0600051D RID: 1309 RVA: 0x000488D4 File Offset: 0x00046AD4
		private void ItemEx700Plusbw_DoWork(object sender, DoWorkEventArgs e)
		{
			Form1.SendArgs sendArgs = (Form1.SendArgs)e.Argument;
			this.ItemEx700PlusDec(sendArgs.filePath);
		}

		// Token: 0x0600051E RID: 1310 RVA: 0x000488FC File Offset: 0x00046AFC
		private void ItemEx700Plusbw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this.toolStripButton_BmdItemAdder.Enabled = true;
			this.isLeaveOpenItemAdder = true;
			this.toolStripButton_AddRow.Enabled = false;
			this.toolStripButton_RemoveSelectedRow.Enabled = false;
			this.toolStripButton_Save.Enabled = true;
			this.progressBar_Loading.Visible = false;
			this.tc_Items.SelectedIndex = -1;
			this.tc_Items.SelectedIndex = 0;
		}

		// Token: 0x0600051F RID: 1311 RVA: 0x00048964 File Offset: 0x00046B64
		private DataGridView ItemEx700PlusDec(string filePath)
		{
			DataGridView result = new DataGridView();
			try
			{
				FileStream fileStream = new FileStream(filePath, FileMode.Open);
				byte[] array = new byte[fileStream.Length];
				long length = fileStream.Length;
				fileStream.Read(array, 0, array.Length);
				fileStream.Close();
				Array.Resize<byte>(ref this.startBytes, 4);
				Array.Copy(array, 0, this.startBytes, 0, 4);
				this.sSize = BitConverter.ToInt32(this.startBytes, 0);
				Array.Resize<byte>(ref this.endBytes, 4);
				this.fStruct = new object[8192, this.sBlockSize];
				Array.Copy(array, array.Length - 4, this.endBytes, 0, 4);
				byte[] array2 = new byte[this.sBlockSize];
				for (int i = 0; i < this.sSize; i++)
				{
					array2 = new byte[this.sBlockSize];
					Array.Copy(array, i * this.sBlockSize + 4, array2, 0, array2.Length);
					this.DecBlock(ref array2, array2.Length);
					for (int j = 0; j < this.sBlockSize; j++)
					{
						try
						{
							this.fStruct[(int)(BitConverter.ToUInt16(array2, 4) * 512 + BitConverter.ToUInt16(array2, 6)), j] = array2[j];
						}
						catch
						{
						}
					}
				}
			}
			catch (Exception ex)
			{
				result = new DataGridView();
				MessageBox.Show("The selected file failed to decrypt. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			return result;
		}

		// Token: 0x06000520 RID: 1312 RVA: 0x00048B00 File Offset: 0x00046D00
		private void ItemEx700Plusdgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			DataGridView dataGridView = (DataGridView)sender;
			int num = (int)Convert.ToInt16(dataGridView[4, e.RowIndex].Value);
			int rowIndex = e.RowIndex;
			if (e.ColumnIndex != 5 && e.ColumnIndex != 4)
			{
				if (dataGridView.EditingControl != null)
				{
					if (dataGridView.EditingControl.Text == "")
					{
						dataGridView.EditingControl.Text = "0";
					}
				}
				else if (this.PasteValue == "")
				{
					this.PasteValue = "0";
				}
				byte[] array = new byte[1];
				byte[] array2 = new byte[4];
				byte[] array3 = new byte[2];
				byte[] array4 = new byte[30];
				byte[] array5 = new byte[30];
				string text = string.Empty;
				if (this.isPasteFromCP)
				{
					text = this.PasteValue;
				}
				else if (dataGridView.EditingControl != null)
				{
					text = dataGridView.EditingControl.Text;
				}
				else
				{
					text = dataGridView[e.ColumnIndex, e.RowIndex].Value.ToString();
				}
				if (this.fStruct[num * 512 + rowIndex, 0] == null)
				{
					array3 = BitConverter.GetBytes(Convert.ToUInt16(num));
					for (int i = 0; i < array3.Length; i++)
					{
						this.fStruct[num * 512 + rowIndex, 4 + i] = array3[i];
					}
					array3 = BitConverter.GetBytes(Convert.ToUInt16(dataGridView[5, e.RowIndex].Value));
					for (int j = 0; j < array3.Length; j++)
					{
						this.fStruct[num * 512 + rowIndex, 6 + j] = array3[j];
					}
					for (int k = 0; k < this.sBlockSize; k++)
					{
						if (k != 4 & k != 5 & k != 6 & k != 7)
						{
							this.fStruct[num * 512 + rowIndex, k] = 0;
						}
					}
				}
				int num2 = 520;
				int num3 = 8;
				switch (e.ColumnIndex)
				{
				case 0:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 0] = array[0];
					break;
				case 1:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 1] = array[0];
					break;
				case 2:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 2] = array[0];
					break;
				case 3:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 3] = array[0];
					break;
				case 6:
					this.StrToByteArray(ref array5, text);
					for (int l = 0; l < array5.Length; l++)
					{
						this.fStruct[num * 512 + rowIndex, l + num3] = array5[l];
					}
					break;
				case 7:
					this.StrToByteArray(ref array5, text);
					for (int m = 0; m < array5.Length; m++)
					{
						this.fStruct[num * 512 + rowIndex, 260 + m + num3] = array5[m];
					}
					break;
				case 8:
					this.StrToByteArray(ref array4, text);
					for (int n = 0; n < array4.Length; n++)
					{
						this.fStruct[num * 512 + rowIndex, 520 + n + num3] = array4[n];
					}
					break;
				case 9:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 30 + num2 + num3] = array[0];
					break;
				case 10:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 31 + num2 + num3] = array[0];
					break;
				case 11:
					array3 = BitConverter.GetBytes(Convert.ToUInt16(text));
					for (int num4 = 0; num4 < array3.Length; num4++)
					{
						this.fStruct[num * 512 + rowIndex, 32 + num2 + num3 + num4] = array3[num4];
					}
					break;
				case 12:
					array3 = BitConverter.GetBytes(Convert.ToUInt16(text));
					for (int num5 = 0; num5 < array3.Length; num5++)
					{
						this.fStruct[num * 512 + rowIndex, 34 + num2 + num3 + num5] = array3[num5];
					}
					break;
				case 13:
					array3 = BitConverter.GetBytes(Convert.ToUInt16(text));
					for (int num6 = 0; num6 < array3.Length; num6++)
					{
						this.fStruct[num * 512 + rowIndex, 36 + num2 + num3 + num6] = array3[num6];
					}
					break;
				case 14:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 38 + num2 + num3] = array[0];
					break;
				case 15:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 39 + num2 + num3] = array[0];
					break;
				case 16:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 40 + num2 + num3] = array[0];
					break;
				case 17:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 41 + num2 + num3] = array[0];
					break;
				case 18:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 42 + num2 + num3] = array[0];
					break;
				case 19:
					array3 = BitConverter.GetBytes(Convert.ToUInt16(text));
					for (int num7 = 0; num7 < array3.Length; num7++)
					{
						this.fStruct[num * 512 + rowIndex, 43 + num2 + num3 + num7] = array3[num7];
					}
					break;
				case 20:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 45 + num2 + num3] = array[0];
					break;
				case 21:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 46 + num2 + num3] = array[0];
					break;
				case 22:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 47 + num2 + num3] = array[0];
					break;
				case 23:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 48 + num2 + num3] = array[0];
					break;
				case 24:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 49 + num2 + num3] = array[0];
					break;
				case 25:
					array3 = BitConverter.GetBytes(Convert.ToUInt16(text));
					for (int num8 = 0; num8 < array3.Length; num8++)
					{
						this.fStruct[num * 512 + rowIndex, 50 + num2 + num3 + num8] = array3[num8];
					}
					break;
				case 26:
					array3 = BitConverter.GetBytes(Convert.ToUInt16(text));
					for (int num9 = 0; num9 < array3.Length; num9++)
					{
						this.fStruct[num * 512 + rowIndex, 52 + num2 + num3 + num9] = array3[num9];
					}
					break;
				case 27:
					array3 = BitConverter.GetBytes(Convert.ToUInt16(text));
					for (int num10 = 0; num10 < array3.Length; num10++)
					{
						this.fStruct[num * 512 + rowIndex, 54 + num2 + num3 + num10] = array3[num10];
					}
					break;
				case 28:
					array3 = BitConverter.GetBytes(Convert.ToUInt16(text));
					for (int num11 = 0; num11 < array3.Length; num11++)
					{
						this.fStruct[num * 512 + rowIndex, 56 + num2 + num3 + num11] = array3[num11];
					}
					break;
				case 29:
					array3 = BitConverter.GetBytes(Convert.ToUInt16(text));
					for (int num12 = 0; num12 < array3.Length; num12++)
					{
						this.fStruct[num * 512 + rowIndex, 58 + num2 + num3 + num12] = array3[num12];
					}
					break;
				case 30:
					array3 = BitConverter.GetBytes(Convert.ToUInt16(text));
					for (int num13 = 0; num13 < array3.Length; num13++)
					{
						this.fStruct[num * 512 + rowIndex, 60 + num2 + num3 + num13] = array3[num13];
					}
					break;
				case 31:
					array3 = BitConverter.GetBytes(Convert.ToUInt16(text));
					for (int num14 = 0; num14 < array3.Length; num14++)
					{
						this.fStruct[num * 512 + rowIndex, 62 + num2 + num3 + num14] = array3[num14];
					}
					break;
				case 32:
					array2 = BitConverter.GetBytes(Convert.ToUInt32(text));
					for (int num15 = 0; num15 < array2.Length; num15++)
					{
						this.fStruct[num * 512 + rowIndex, 64 + num2 + num3 + num15] = array2[num15];
					}
					break;
				case 33:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 68 + num2 + num3] = array[0];
					break;
				case 34:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 69 + num2 + num3] = array[0];
					break;
				case 35:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 70 + num2 + num3] = array[0];
					break;
				case 36:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 71 + num2 + num3] = array[0];
					break;
				case 37:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 72 + num2 + num3] = array[0];
					break;
				case 38:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 73 + num2 + num3] = array[0];
					break;
				case 39:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 74 + num2 + num3] = array[0];
					break;
				case 40:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 75 + num2 + num3] = array[0];
					break;
				case 41:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 76 + num2 + num3] = array[0];
					break;
				case 42:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 77 + num2 + num3] = array[0];
					break;
				case 43:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 78 + num2 + num3] = array[0];
					break;
				case 44:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 79 + num2 + num3] = array[0];
					break;
				case 45:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 80 + num2 + num3] = array[0];
					break;
				case 46:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 81 + num2 + num3] = array[0];
					break;
				case 47:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 82 + num2 + num3] = array[0];
					break;
				case 48:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 83 + num2 + num3] = array[0];
					break;
				case 49:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 84 + num2 + num3] = array[0];
					break;
				case 50:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 85 + num2 + num3] = array[0];
					break;
				case 51:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 86 + num2 + num3] = array[0];
					break;
				case 52:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 87 + num2 + num3] = array[0];
					break;
				case 53:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 88 + num2 + num3] = array[0];
					break;
				case 54:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 89 + num2 + num3] = array[0];
					break;
				case 55:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 90 + num2 + num3] = array[0];
					break;
				case 56:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 91 + num2 + num3] = array[0];
					break;
				}
				dataGridView[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.PaleGreen;
				bool flag = true;
				foreach (object obj in dataGridView.Columns)
				{
					DataGridViewColumn dataGridViewColumn = (DataGridViewColumn)obj;
					if (dataGridView[dataGridViewColumn.Index, e.RowIndex].Value != null)
					{
						if (dataGridView[dataGridViewColumn.Index, e.RowIndex].Value.ToString() != "0")
						{
							flag = false;
						}
					}
					else if (dataGridView.EditingControl.Text != "0")
					{
						flag = false;
					}
				}
				if (flag)
				{
					for (int num16 = 0; num16 < this.sBlockSize; num16++)
					{
						this.fStruct[num * 512 + rowIndex, num16] = null;
					}
				}
				return;
			}
			if (e.ColumnIndex == 4)
			{
				dataGridView[e.ColumnIndex, e.RowIndex].Value = num;
				return;
			}
			dataGridView[e.ColumnIndex, e.RowIndex].Value = rowIndex;
		}

		// Token: 0x06000521 RID: 1313 RVA: 0x00049C34 File Offset: 0x00047E34
		private void ItemEx700Plusdgv_Disposed(object sender, EventArgs e)
		{
			if (Application.OpenForms["Form_Search"] != null)
			{
				Application.OpenForms["Form_Search"].Close();
			}
			if (!this.isLeaveOpenItemAdder)
			{
				if (Application.OpenForms["Form_BmdItemAddercs"] != null)
				{
					Application.OpenForms["Form_BmdItemAddercs"].Close();
				}
				this.toolStripButton_BmdItemAdder.Enabled = false;
			}
		}

		// Token: 0x06000522 RID: 1314 RVA: 0x00049CA0 File Offset: 0x00047EA0
		private void ItemEx700PlusEnc(string filePath)
		{
			List<byte> list = new List<byte>();
			for (int i = 0; i < 8192; i++)
			{
				bool flag = false;
				for (int j = 528; j < 558; j++)
				{
					if (Convert.ToByte(this.fStruct[i, j]) != 0)
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					byte[] array = new byte[this.sBlockSize];
					for (int k = 0; k < this.sBlockSize; k++)
					{
						array[k] = Convert.ToByte(this.fStruct[i, k]);
					}
					this.EncBlock(ref array, array.Length);
					for (int l = 0; l < this.sBlockSize; l++)
					{
						list.Add(array[l]);
					}
				}
				this.backgroundWorker.ReportProgress(i);
			}
			this.newFile = new byte[4 + list.Count + this.endBytes.Length];
			this.startBytes = BitConverter.GetBytes(list.Count / this.sBlockSize);
			Array.Copy(this.startBytes, 0, this.newFile, 0, 4);
			byte[] array2 = list.ToArray<byte>();
			Array.Copy(array2, 0, this.newFile, 4, array2.Length);
			Array.Copy(this.endBytes, 0, this.newFile, this.newFile.Length - 4, this.endBytes.Length);
			this.CalcCRC(this.newFile, 58097u, 0u);
			File.WriteAllBytes(filePath, this.newFile);
		}

		// Token: 0x06000523 RID: 1315 RVA: 0x00049E14 File Offset: 0x00048014
		private void ItemSeason8Episode1_INI_Export()
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog
			{
				Title = "Select a location and file Name for the generated ItemListSettings.ini",
				FileName = "ItemListSettings.ini",
				Filter = "INI files (*.ini)|*.ini|All files (*.*)|*.*"
			};
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName)
				{
					AutoFlush = true
				};
				streamWriter.WriteLine("//Generated by MU.ToolKit coded by TopReal.IT");
				List<string> list = new List<string>();
				List<string> list2 = new List<string>();
				List<string> list3 = new List<string>();
				List<string> list4 = new List<string>();
				List<string> list5 = new List<string>();
				List<string> list6 = new List<string>();
				List<string> list7 = new List<string>();
				List<string> list8 = new List<string>();
				List<string> list9 = new List<string>();
				List<string> list10 = new List<string>();
				List<string> list11 = new List<string>();
				List<string> list12 = new List<string>();
				List<string> list13 = new List<string>();
				List<string> list14 = new List<string>();
				List<string> list15 = new List<string>();
				List<string> list16 = new List<string>();
				for (int i = 0; i < 16; i++)
				{
					this.tc_Items.SelectedIndex = i;
					string item = string.Empty;
					int num = 0;
					foreach (object obj in ((IEnumerable)this.workingDGV.Rows))
					{
						DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
						bool flag = false;
						if (num == this.workingDGV.Rows.Count - 1)
						{
							break;
						}
						foreach (object obj2 in dataGridViewRow.Cells)
						{
							DataGridViewCell dataGridViewCell = (DataGridViewCell)obj2;
							if (dataGridViewCell.Value.ToString() == "" & dataGridViewCell.ValueType != typeof(string))
							{
								dataGridViewCell.Value = "0";
							}
							if (dataGridViewCell.Value.ToString() != "0" & dataGridViewCell.ColumnIndex != 4 & dataGridViewCell.ColumnIndex != 5)
							{
								flag = true;
							}
						}
						if (flag)
						{
							switch (Convert.ToInt32(dataGridViewRow.Cells["Group"].Value))
							{
							case 0:
								item = string.Concat(new string[]
								{
									"\"",
									dataGridViewRow.Cells["Model Folder"].Value.ToString(),
									"\"\t\"",
									dataGridViewRow.Cells["Model Name"].Value.ToString(),
									"\"\t\t",
									dataGridViewRow.Cells["Type"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["Level"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Min Dmg"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Max Dmg"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["AtkSpeed"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Durability"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["MagicDur"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["MagicPwr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLvl"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqStr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqDex"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqEne"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqVit"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLea"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["SetOption"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[34].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[35].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[36].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[37].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[38].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[39].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[40].Value.ToString()
								});
								list.Add(item);
								break;
							case 1:
								item = string.Concat(new string[]
								{
									"\"",
									dataGridViewRow.Cells["Model Folder"].Value.ToString(),
									"\"\t\"",
									dataGridViewRow.Cells["Model Name"].Value.ToString(),
									"\"\t\t",
									dataGridViewRow.Cells["Type"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["Level"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Min Dmg"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Max Dmg"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["AtkSpeed"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Durability"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["MagicDur"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["MagicPwr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLvl"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqStr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqDex"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqEne"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqVit"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLea"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["SetOption"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[34].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[35].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[36].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[37].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[38].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[39].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[40].Value.ToString()
								});
								list2.Add(item);
								break;
							case 2:
								item = string.Concat(new string[]
								{
									"\"",
									dataGridViewRow.Cells["Model Folder"].Value.ToString(),
									"\"\t\"",
									dataGridViewRow.Cells["Model Name"].Value.ToString(),
									"\"\t\t",
									dataGridViewRow.Cells["Type"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["Level"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Min Dmg"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Max Dmg"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["AtkSpeed"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Durability"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["MagicDur"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["MagicPwr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLvl"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqStr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqDex"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqEne"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqVit"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLea"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["SetOption"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[34].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[35].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[36].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[37].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[38].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[39].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[40].Value.ToString()
								});
								list3.Add(item);
								break;
							case 3:
								item = string.Concat(new string[]
								{
									"\"",
									dataGridViewRow.Cells["Model Folder"].Value.ToString(),
									"\"\t\"",
									dataGridViewRow.Cells["Model Name"].Value.ToString(),
									"\"\t\t",
									dataGridViewRow.Cells["Type"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["Level"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Min Dmg"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Max Dmg"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["AtkSpeed"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Durability"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["MagicDur"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["MagicPwr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLvl"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqStr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqDex"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqEne"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqVit"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLea"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["SetOption"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[34].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[35].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[36].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[37].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[38].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[39].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[40].Value.ToString()
								});
								list4.Add(item);
								break;
							case 4:
								item = string.Concat(new string[]
								{
									"\"",
									dataGridViewRow.Cells["Model Folder"].Value.ToString(),
									"\"\t\"",
									dataGridViewRow.Cells["Model Name"].Value.ToString(),
									"\"\t\t",
									dataGridViewRow.Cells["Type"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["Level"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Min Dmg"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Max Dmg"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["AtkSpeed"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Durability"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["MagicDur"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["MagicPwr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLvl"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqStr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqDex"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqEne"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqVit"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLea"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["SetOption"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[34].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[35].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[36].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[37].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[38].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[39].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[40].Value.ToString()
								});
								list5.Add(item);
								break;
							case 5:
								item = string.Concat(new string[]
								{
									"\"",
									dataGridViewRow.Cells["Model Folder"].Value.ToString(),
									"\"\t\"",
									dataGridViewRow.Cells["Model Name"].Value.ToString(),
									"\"\t\t",
									dataGridViewRow.Cells["Type"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["Level"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Min Dmg"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Max Dmg"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["AtkSpeed"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Durability"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["MagicDur"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["MagicPwr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLvl"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqStr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqDex"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqEne"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqVit"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLea"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["SetOption"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[34].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[35].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[36].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[37].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[38].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[39].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[40].Value.ToString()
								});
								list6.Add(item);
								break;
							case 6:
								item = string.Concat(new string[]
								{
									"\"",
									dataGridViewRow.Cells["Model Folder"].Value.ToString(),
									"\"\t\"",
									dataGridViewRow.Cells["Model Name"].Value.ToString(),
									"\"\t\t",
									dataGridViewRow.Cells["Type"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["Level"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Defense"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Def Rate"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Durability"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLvl"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqStr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqDex"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqEne"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqVit"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLea"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["SetOption"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[34].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[35].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[36].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[37].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[38].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[39].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[40].Value.ToString()
								});
								list7.Add(item);
								break;
							case 7:
								item = string.Concat(new string[]
								{
									"\"",
									dataGridViewRow.Cells["Model Folder"].Value.ToString(),
									"\"\t\"",
									dataGridViewRow.Cells["Model Name"].Value.ToString(),
									"\"\t\t",
									dataGridViewRow.Cells["Type"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["Level"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Defense"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["MagicDur"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Durability"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLvl"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqStr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqDex"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqEne"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqVit"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLea"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["SetOption"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[34].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[35].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[36].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[37].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[38].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[39].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[40].Value.ToString()
								});
								list8.Add(item);
								break;
							case 8:
								item = string.Concat(new string[]
								{
									"\"",
									dataGridViewRow.Cells["Model Folder"].Value.ToString(),
									"\"\t\"",
									dataGridViewRow.Cells["Model Name"].Value.ToString(),
									"\"\t\t",
									dataGridViewRow.Cells["Type"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["Level"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Defense"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["MagicDur"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Durability"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLvl"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqStr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqDex"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqEne"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqVit"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLea"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["SetOption"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[34].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[35].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[36].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[37].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[38].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[39].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[40].Value.ToString()
								});
								list9.Add(item);
								break;
							case 9:
								item = string.Concat(new string[]
								{
									"\"",
									dataGridViewRow.Cells["Model Folder"].Value.ToString(),
									"\"\t\"",
									dataGridViewRow.Cells["Model Name"].Value.ToString(),
									"\"\t\t",
									dataGridViewRow.Cells["Type"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["Level"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Defense"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["MagicDur"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Durability"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLvl"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqStr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqDex"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqEne"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqVit"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLea"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["SetOption"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[34].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[35].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[36].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[37].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[38].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[39].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[40].Value.ToString()
								});
								list10.Add(item);
								break;
							case 10:
								item = string.Concat(new string[]
								{
									"\"",
									dataGridViewRow.Cells["Model Folder"].Value.ToString(),
									"\"\t\"",
									dataGridViewRow.Cells["Model Name"].Value.ToString(),
									"\"\t\t",
									dataGridViewRow.Cells["Type"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["Level"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Defense"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["AtkSpeed"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Durability"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLvl"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqStr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqDex"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqEne"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqVit"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLea"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["SetOption"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[34].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[35].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[36].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[37].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[38].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[39].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[40].Value.ToString()
								});
								list11.Add(item);
								break;
							case 11:
								item = string.Concat(new string[]
								{
									"\"",
									dataGridViewRow.Cells["Model Folder"].Value.ToString(),
									"\"\t\"",
									dataGridViewRow.Cells["Model Name"].Value.ToString(),
									"\"\t\t",
									dataGridViewRow.Cells["Type"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["Level"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Defense"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["WalkSpeed"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Durability"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLvl"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqStr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqDex"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqEne"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqVit"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLea"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["SetOption"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[34].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[35].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[36].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[37].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[38].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[39].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[40].Value.ToString()
								});
								list12.Add(item);
								break;
							case 12:
								item = string.Concat(new string[]
								{
									"\"",
									dataGridViewRow.Cells["Model Folder"].Value.ToString(),
									"\"\t\"",
									dataGridViewRow.Cells["Model Name"].Value.ToString(),
									"\"\t\t",
									dataGridViewRow.Cells["Type"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["Level"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Defense"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Durability"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLvl"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqStr"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqDex"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqEne"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqVit"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLea"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Zen"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[34].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[35].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[36].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[37].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[38].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[39].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[40].Value.ToString()
								});
								list13.Add(item);
								break;
							case 13:
								item = string.Concat(new string[]
								{
									"\"",
									dataGridViewRow.Cells["Model Folder"].Value.ToString(),
									"\"\t\"",
									dataGridViewRow.Cells["Model Name"].Value.ToString(),
									"\"\t\t",
									dataGridViewRow.Cells["Type"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["Level"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Durability"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Ice Attribute"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Poison Attribute"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Lightning Attribute"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Fire Attribute"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Earth Attribute"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Wind Attribute"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Water Attribute"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["SetOption"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[34].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[35].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[36].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[37].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[38].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[39].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[40].Value.ToString()
								});
								list14.Add(item);
								break;
							case 14:
								item = string.Concat(new string[]
								{
									"\"",
									dataGridViewRow.Cells["Model Folder"].Value.ToString(),
									"\"\t\"",
									dataGridViewRow.Cells["Model Name"].Value.ToString(),
									"\"\t\t",
									dataGridViewRow.Cells["Type"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["ItemValue"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Level"].Value.ToString()
								});
								list15.Add(item);
								break;
							case 15:
								item = string.Concat(new string[]
								{
									"\"",
									dataGridViewRow.Cells["Model Folder"].Value.ToString(),
									"\"\t\"",
									dataGridViewRow.Cells["Model Name"].Value.ToString(),
									"\"\t\t",
									dataGridViewRow.Cells["Type"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Index"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Slot"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Skill"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["X"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Y"].Value.ToString(),
									"\t1\t1\t1\t\"",
									dataGridViewRow.Cells["Name"].Value.ToString(),
									"\"\t\t\t\t",
									dataGridViewRow.Cells["Level"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqLvl"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["ReqEne"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells["Zen"].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[34].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[35].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[36].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[37].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[38].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[39].Value.ToString(),
									"\t",
									dataGridViewRow.Cells[40].Value.ToString()
								});
								list16.Add(item);
								break;
							}
							num++;
						}
					}
				}
				streamWriter.WriteLine("//Texture\tModel\t\t\tType\tIndex\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tlevel\tDmgMin\tDmgMax\tASpeed\tDur\tMagDur\tMagPW\tReqLvl\tReqStr\tReqDex\tReqEne\tReqVit\tReqCmd\tSetA\tC0\tC1\tC2\tC3\tC4\tC5\tC6");
				streamWriter.WriteLine("0");
				foreach (string value in list)
				{
					streamWriter.WriteLine(value);
				}
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				streamWriter.WriteLine("//Texture\tModel\t\t\tType\tIndex\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tlevel\tDmgMin\tDmgMax\tASpeed\tDur\tMagDur\tMagPW\tReqLvl\tReqStr\tReqDex\tReqEne\tReqVit\tReqCmd\tSetA\tC0\tC1\tC2\tC3\tC4\tC5\tC6");
				streamWriter.WriteLine("1");
				foreach (string value2 in list2)
				{
					streamWriter.WriteLine(value2);
				}
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				streamWriter.WriteLine("//Texture\tModel\t\t\tType\tIndex\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tlevel\tDmgMin\tDmgMax\tASpeed\tDur\tMagDur\tMagPW\tReqLvl\tReqStr\tReqDex\tReqEne\tReqVit\tReqCmd\tSetA\tC0\tC1\tC2\tC3\tC4\tC5\tC6");
				streamWriter.WriteLine("2");
				foreach (string value3 in list3)
				{
					streamWriter.WriteLine(value3);
				}
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				streamWriter.WriteLine("//Texture\tModel\t\t\tType\tIndex\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tlevel\tDmgMin\tDmgMax\tASpeed\tDur\tMagDur\tMagPW\tReqLvl\tReqStr\tReqDex\tReqEne\tReqVit\tReqCmd\tSetA\tC0\tC1\tC2\tC3\tC4\tC5\tC6");
				streamWriter.WriteLine("3");
				foreach (string value4 in list4)
				{
					streamWriter.WriteLine(value4);
				}
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				streamWriter.WriteLine("//Texture\tModel\t\t\tType\tIndex\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tlevel\tDmgMin\tDmgMax\tASpeed\tDur\tMagDur\tMagPW\tReqLvl\tReqStr\tReqDex\tReqEne\tReqVit\tReqCmd\tSetA\tC0\tC1\tC2\tC3\tC4\tC5\tC6");
				streamWriter.WriteLine("4");
				foreach (string value5 in list5)
				{
					streamWriter.WriteLine(value5);
				}
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				streamWriter.WriteLine("//Texture\tModel\t\t\tType\tIndex\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tlevel\tDmgMin\tDmgMax\tASpeed\tDur\tMagDur\tMagPW\tReqLvl\tReqStr\tReqDex\tReqEne\tReqVit\tReqCmd\tSetA\tC0\tC1\tC2\tC3\tC4\tC5\tC6");
				streamWriter.WriteLine("5");
				foreach (string value6 in list6)
				{
					streamWriter.WriteLine(value6);
				}
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				streamWriter.WriteLine("//Texture\tModel\t\t\tType\tIndex\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tlevel\tDef\tDefRate\tDur\tReqLvl\tReqStr\tReqDex\tReqEne\tReqVit\tReqCmd\tSetA\tC0\tC1\tC2\tC3\tC4\tC5\tC6");
				streamWriter.WriteLine("6");
				foreach (string value7 in list7)
				{
					streamWriter.WriteLine(value7);
				}
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				streamWriter.WriteLine("//Texture\tModel\t\t\tType\tIndex\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tlevel\tDef\tMagDef\tDur\tReqLvl\tReqStr\tReqDex\tReqEne\tReqVit\tReqCmd\tSetA\tC0\tC1\tC2\tC3\tC4\tC5\tC6");
				streamWriter.WriteLine("7");
				foreach (string value8 in list8)
				{
					streamWriter.WriteLine(value8);
				}
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				streamWriter.WriteLine("//Texture\tModel\t\t\tType\tIndex\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tlevel\tDef\tMagDef\tDur\tReqLvl\tReqStr\tReqDex\tReqEne\tReqVit\tReqCmd\tSetA\tC0\tC1\tC2\tC3\tC4\tC5\tC6");
				streamWriter.WriteLine("8");
				foreach (string value9 in list9)
				{
					streamWriter.WriteLine(value9);
				}
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				streamWriter.WriteLine("//Texture\tModel\t\t\tType\tIndex\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tlevel\tDef\tMagDef\tDur\tReqLvl\tReqStr\tReqDex\tReqEne\tReqVit\tReqCmd\tSetA\tC0\tC1\tC2\tC3\tC4\tC5\tC6");
				streamWriter.WriteLine("9");
				foreach (string value10 in list10)
				{
					streamWriter.WriteLine(value10);
				}
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				streamWriter.WriteLine("//Texture\tModel\t\t\tType\tIndex\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tlevel\tDef\tASpeed\tDur\tReqLvl\tReqStr\tReqDex\tReqEne\tReqVit\tReqCmd\tSetA\tC0\tC1\tC2\tC3\tC4\tC5\tC6");
				streamWriter.WriteLine("10");
				foreach (string value11 in list11)
				{
					streamWriter.WriteLine(value11);
				}
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				streamWriter.WriteLine("//Texture\tModel\t\t\tType\tIndex\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tlevel\tDef\tWSpeed\tDur\tReqLvl\tReqStr\tReqDex\tReqEne\tReqVit\tReqCmd\tSetA\tC0\tC1\tC2\tC3\tC4\tC5\tC6");
				streamWriter.WriteLine("11");
				foreach (string value12 in list12)
				{
					streamWriter.WriteLine(value12);
				}
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				streamWriter.WriteLine("//Texture\tModel\t\t\tType\tIndex\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tlevel\tDef\tDur\tReqLvl\tReqEne\tReqStr\tReqDex\tReqCmd\tMoney\tC0\tC1\tC2\tC3\tC4\tC5\tC6");
				streamWriter.WriteLine("12");
				foreach (string value13 in list13)
				{
					streamWriter.WriteLine(value13);
				}
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				streamWriter.WriteLine("//Texture\tModel\t\t\tType\tIndex\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tlevel\tDur\tRes1\tRes2\tRes3\tRes4\tRes5\tRes6\tRes7\tSetA\tC0\tC1\tC2\tC3\tC4\tC5\tC6");
				streamWriter.WriteLine("13");
				foreach (string value14 in list14)
				{
					streamWriter.WriteLine(value14);
				}
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				streamWriter.WriteLine("//Texture\tModel\t\t\tType\tIndex\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tValue\tLevel");
				streamWriter.WriteLine("14");
				foreach (string value15 in list15)
				{
					streamWriter.WriteLine(value15);
				}
				streamWriter.WriteLine("end");
				streamWriter.WriteLine();
				streamWriter.WriteLine("//Texture\tModel\t\t\tType\tIndex\tSlot\tSkill\tX\tY\tSerial\tOption\tDrop\tName\t\t\t\tlevel\tReqLvl\tReqEne\tMoney\tC0\tC1\tC2\tC3\tC4\tC5\tC6");
				streamWriter.WriteLine("15");
				foreach (string value16 in list16)
				{
					streamWriter.WriteLine(value16);
				}
				streamWriter.WriteLine("end");
				streamWriter.Close();
				if (MessageBox.Show("File generated succesfully.\nOpen?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
				{
					Process.Start(saveFileDialog.FileName);
				}
			}
		}

		// Token: 0x06000524 RID: 1316 RVA: 0x0004EE28 File Offset: 0x0004D028
		private void ItemSeason8Episode1_Save()
		{
			Form1.SendArgs sendArgs = new Form1.SendArgs();
			SaveFileDialog saveFileDialog = new SaveFileDialog
			{
				AddExtension = true,
				Title = "Select a location to save the Season 8 Episode 1 Item.bmd File",
				Filter = "BMD files (*.bmd)|*.bmd|All files (*.*)|*.*"
			};
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.toolStripProgressBar_Save.Visible = true;
				this.toolStripProgressBar_Save.Value = 0;
				this.toolStripProgressBar_Save.Size = new Size(base.Width - 460, 22);
				this.toolStripProgressBar_Save.Maximum = 8192;
				sendArgs.filePath = saveFileDialog.FileName;
				sendArgs.fileType = "ItemSeason8Episode1";
				this.backgroundWorker.RunWorkerAsync(sendArgs);
			}
		}

		// Token: 0x06000525 RID: 1317 RVA: 0x0004EED4 File Offset: 0x0004D0D4
		private void ItemSeason8Episode1bw_DoWork(object sender, DoWorkEventArgs e)
		{
			Form1.SendArgs sendArgs = (Form1.SendArgs)e.Argument;
			this.ItemSeason8Episode1Dec(sendArgs.filePath);
		}

		// Token: 0x06000526 RID: 1318 RVA: 0x0004EEFC File Offset: 0x0004D0FC
		private void ItemSeason8Episode1bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this.toolStripButton_BmdItemAdder.Enabled = true;
			this.isLeaveOpenItemAdder = true;
			this.toolStripButton_AddRow.Enabled = false;
			this.toolStripButton_RemoveSelectedRow.Enabled = false;
			this.toolStripButton_Save.Enabled = true;
			this.progressBar_Loading.Visible = false;
			this.tc_Items.SelectedIndex = -1;
			this.tc_Items.SelectedIndex = 0;
		}

		// Token: 0x06000527 RID: 1319 RVA: 0x0004EF64 File Offset: 0x0004D164
		private DataGridView ItemSeason8Episode1Dec(string filePath)
		{
			DataGridView result = new DataGridView();
			try
			{
				FileStream fileStream = new FileStream(filePath, FileMode.Open);
				byte[] array = new byte[fileStream.Length];
				long length = fileStream.Length;
				fileStream.Read(array, 0, array.Length);
				fileStream.Close();
				Array.Resize<byte>(ref this.startBytes, 4);
				Array.Copy(array, 0, this.startBytes, 0, 4);
				this.sSize = BitConverter.ToInt32(this.startBytes, 0);
				Array.Resize<byte>(ref this.endBytes, 4);
				this.sBlockSize = (array.Length - 8) / this.sSize;
				this.fStruct = new object[8192, this.sBlockSize];
				Array.Copy(array, array.Length - 4, this.endBytes, 0, 4);
				byte[] array2 = new byte[this.sBlockSize];
				for (int i = 0; i < this.sSize; i++)
				{
					array2 = new byte[this.sBlockSize];
					Array.Copy(array, i * this.sBlockSize + 4, array2, 0, array2.Length);
					this.DecBlock(ref array2, array2.Length);
					for (int j = 0; j < this.sBlockSize; j++)
					{
						try
						{
							this.fStruct[(int)(BitConverter.ToUInt16(array2, 4) * 512 + BitConverter.ToUInt16(array2, 6)), j] = array2[j];
						}
						catch
						{
						}
					}
				}
			}
			catch (Exception ex)
			{
				result = new DataGridView();
				MessageBox.Show("The selected file failed to decrypt. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			return result;
		}

		// Token: 0x06000528 RID: 1320 RVA: 0x0004F110 File Offset: 0x0004D310
		private void ItemSeason8Episode1dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			DataGridView dataGridView = (DataGridView)sender;
			int num = (int)Convert.ToInt16(dataGridView[4, e.RowIndex].Value);
			int rowIndex = e.RowIndex;
			if (e.ColumnIndex != 5 && e.ColumnIndex != 4)
			{
				if (dataGridView.EditingControl != null)
				{
					if (dataGridView.EditingControl.Text == "")
					{
						dataGridView.EditingControl.Text = "0";
					}
				}
				else if (this.PasteValue == "")
				{
					this.PasteValue = "0";
				}
				byte[] array = new byte[1];
				byte[] array2 = new byte[4];
				byte[] array3 = new byte[2];
				byte[] array4 = new byte[30];
				byte[] array5 = new byte[30];
				string text = string.Empty;
				if (this.isPasteFromCP)
				{
					text = this.PasteValue;
				}
				else if (dataGridView.EditingControl != null)
				{
					text = dataGridView.EditingControl.Text;
				}
				else
				{
					text = dataGridView[e.ColumnIndex, e.RowIndex].Value.ToString();
				}
				if (this.fStruct[num * 512 + rowIndex, 0] == null)
				{
					array3 = BitConverter.GetBytes(Convert.ToUInt16(num));
					for (int i = 0; i < array3.Length; i++)
					{
						this.fStruct[num * 512 + rowIndex, 4 + i] = array3[i];
					}
					array3 = BitConverter.GetBytes(Convert.ToUInt16(dataGridView[5, e.RowIndex].Value));
					for (int j = 0; j < array3.Length; j++)
					{
						this.fStruct[num * 512 + rowIndex, 6 + j] = array3[j];
					}
					for (int k = 0; k < this.sBlockSize; k++)
					{
						if (k != 4 & k != 5 & k != 6 & k != 7)
						{
							this.fStruct[num * 512 + rowIndex, k] = 0;
						}
					}
				}
				int num2 = 520;
				int num3 = 8;
				switch (e.ColumnIndex)
				{
				case 0:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 0] = array[0];
					break;
				case 1:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 1] = array[0];
					break;
				case 2:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 2] = array[0];
					break;
				case 3:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 3] = array[0];
					break;
				case 6:
					this.StrToByteArray(ref array5, text);
					for (int l = 0; l < array5.Length; l++)
					{
						this.fStruct[num * 512 + rowIndex, l + num3] = array5[l];
					}
					break;
				case 7:
					this.StrToByteArray(ref array5, text);
					for (int m = 0; m < array5.Length; m++)
					{
						this.fStruct[num * 512 + rowIndex, 260 + m + num3] = array5[m];
					}
					break;
				case 8:
					this.StrToByteArray(ref array4, text);
					for (int n = 0; n < array4.Length; n++)
					{
						this.fStruct[num * 512 + rowIndex, 520 + n + num3] = array4[n];
					}
					break;
				case 9:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 30 + num2 + num3] = array[0];
					break;
				case 10:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 31 + num2 + num3] = array[0];
					break;
				case 11:
					array3 = BitConverter.GetBytes(Convert.ToUInt16(text));
					for (int num4 = 0; num4 < array3.Length; num4++)
					{
						this.fStruct[num * 512 + rowIndex, 32 + num2 + num3 + num4] = array3[num4];
					}
					break;
				case 12:
					array3 = BitConverter.GetBytes(Convert.ToUInt16(text));
					for (int num5 = 0; num5 < array3.Length; num5++)
					{
						this.fStruct[num * 512 + rowIndex, 34 + num2 + num3 + num5] = array3[num5];
					}
					break;
				case 13:
					array3 = BitConverter.GetBytes(Convert.ToUInt16(text));
					for (int num6 = 0; num6 < array3.Length; num6++)
					{
						this.fStruct[num * 512 + rowIndex, 36 + num2 + num3 + num6] = array3[num6];
					}
					break;
				case 14:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 38 + num2 + num3] = array[0];
					break;
				case 15:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 39 + num2 + num3] = array[0];
					break;
				case 16:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 40 + num2 + num3] = array[0];
					break;
				case 17:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 41 + num2 + num3] = array[0];
					break;
				case 18:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 42 + num2 + num3] = array[0];
					break;
				case 19:
					array3 = BitConverter.GetBytes(Convert.ToUInt16(text));
					for (int num7 = 0; num7 < array3.Length; num7++)
					{
						this.fStruct[num * 512 + rowIndex, 43 + num2 + num3 + num7] = array3[num7];
					}
					break;
				case 20:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 45 + num2 + num3] = array[0];
					break;
				case 21:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 46 + num2 + num3] = array[0];
					break;
				case 22:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 47 + num2 + num3] = array[0];
					break;
				case 23:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 48 + num2 + num3] = array[0];
					break;
				case 24:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 49 + num2 + num3] = array[0];
					break;
				case 25:
					array3 = BitConverter.GetBytes(Convert.ToUInt16(text));
					for (int num8 = 0; num8 < array3.Length; num8++)
					{
						this.fStruct[num * 512 + rowIndex, 50 + num2 + num3 + num8] = array3[num8];
					}
					break;
				case 26:
					array3 = BitConverter.GetBytes(Convert.ToUInt16(text));
					for (int num9 = 0; num9 < array3.Length; num9++)
					{
						this.fStruct[num * 512 + rowIndex, 52 + num2 + num3 + num9] = array3[num9];
					}
					break;
				case 27:
					array3 = BitConverter.GetBytes(Convert.ToUInt16(text));
					for (int num10 = 0; num10 < array3.Length; num10++)
					{
						this.fStruct[num * 512 + rowIndex, 54 + num2 + num3 + num10] = array3[num10];
					}
					break;
				case 28:
					array3 = BitConverter.GetBytes(Convert.ToUInt16(text));
					for (int num11 = 0; num11 < array3.Length; num11++)
					{
						this.fStruct[num * 512 + rowIndex, 56 + num2 + num3 + num11] = array3[num11];
					}
					break;
				case 29:
					array3 = BitConverter.GetBytes(Convert.ToUInt16(text));
					for (int num12 = 0; num12 < array3.Length; num12++)
					{
						this.fStruct[num * 512 + rowIndex, 58 + num2 + num3 + num12] = array3[num12];
					}
					break;
				case 30:
					array3 = BitConverter.GetBytes(Convert.ToUInt16(text));
					for (int num13 = 0; num13 < array3.Length; num13++)
					{
						this.fStruct[num * 512 + rowIndex, 60 + num2 + num3 + num13] = array3[num13];
					}
					break;
				case 31:
					array3 = BitConverter.GetBytes(Convert.ToUInt16(text));
					for (int num14 = 0; num14 < array3.Length; num14++)
					{
						this.fStruct[num * 512 + rowIndex, 62 + num2 + num3 + num14] = array3[num14];
					}
					break;
				case 32:
					array2 = BitConverter.GetBytes(Convert.ToUInt32(text));
					for (int num15 = 0; num15 < array2.Length; num15++)
					{
						this.fStruct[num * 512 + rowIndex, 64 + num2 + num3 + num15] = array2[num15];
					}
					break;
				case 33:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 68 + num2 + num3] = array[0];
					break;
				case 34:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 69 + num2 + num3] = array[0];
					break;
				case 35:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 70 + num2 + num3] = array[0];
					break;
				case 36:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 71 + num2 + num3] = array[0];
					break;
				case 37:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 72 + num2 + num3] = array[0];
					break;
				case 38:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 73 + num2 + num3] = array[0];
					break;
				case 39:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 74 + num2 + num3] = array[0];
					break;
				case 40:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 75 + num2 + num3] = array[0];
					break;
				case 41:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 76 + num2 + num3] = array[0];
					break;
				case 42:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 77 + num2 + num3] = array[0];
					break;
				case 43:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 78 + num2 + num3] = array[0];
					break;
				case 44:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 79 + num2 + num3] = array[0];
					break;
				case 45:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 80 + num2 + num3] = array[0];
					break;
				case 46:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 81 + num2 + num3] = array[0];
					break;
				case 47:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 82 + num2 + num3] = array[0];
					break;
				case 48:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 83 + num2 + num3] = array[0];
					break;
				case 49:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 84 + num2 + num3] = array[0];
					break;
				case 50:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 85 + num2 + num3] = array[0];
					break;
				case 51:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 86 + num2 + num3] = array[0];
					break;
				case 52:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 87 + num2 + num3] = array[0];
					break;
				case 53:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 88 + num2 + num3] = array[0];
					break;
				case 54:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 89 + num2 + num3] = array[0];
					break;
				case 55:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 90 + num2 + num3] = array[0];
					break;
				case 56:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 91 + num2 + num3] = array[0];
					break;
				case 57:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 620] = array[0];
					break;
				case 58:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 621] = array[0];
					break;
				case 59:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 622] = array[0];
					break;
				case 60:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 623] = array[0];
					break;
				case 61:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 624] = array[0];
					break;
				case 62:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 625] = array[0];
					break;
				case 63:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 626] = array[0];
					break;
				case 64:
					array = BitConverter.GetBytes(Convert.ToUInt16(text));
					this.fStruct[num * 512 + rowIndex, 627] = array[0];
					break;
				}
				dataGridView[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.PaleGreen;
				bool flag = true;
				foreach (object obj in dataGridView.Columns)
				{
					DataGridViewColumn dataGridViewColumn = (DataGridViewColumn)obj;
					if (dataGridView[dataGridViewColumn.Index, e.RowIndex].Value != null)
					{
						if (dataGridView[dataGridViewColumn.Index, e.RowIndex].Value.ToString() != "0")
						{
							flag = false;
						}
					}
					else if (dataGridView.EditingControl.Text != "0")
					{
						flag = false;
					}
				}
				if (flag)
				{
					for (int num16 = 0; num16 < this.sBlockSize; num16++)
					{
						this.fStruct[num * 512 + rowIndex, num16] = null;
					}
				}
				return;
			}
			if (e.ColumnIndex == 4)
			{
				dataGridView[e.ColumnIndex, e.RowIndex].Value = num;
				return;
			}
			dataGridView[e.ColumnIndex, e.RowIndex].Value = rowIndex;
		}

		// Token: 0x06000529 RID: 1321 RVA: 0x000503FC File Offset: 0x0004E5FC
		private void ItemSeason8Episode1dgv_Disposed(object sender, EventArgs e)
		{
			if (Application.OpenForms["Form_Search"] != null)
			{
				Application.OpenForms["Form_Search"].Close();
			}
			if (!this.isLeaveOpenItemAdder)
			{
				if (Application.OpenForms["Form_BmdItemAddercs"] != null)
				{
					Application.OpenForms["Form_BmdItemAddercs"].Close();
				}
				this.toolStripButton_BmdItemAdder.Enabled = false;
			}
		}

		// Token: 0x0600052A RID: 1322 RVA: 0x00050468 File Offset: 0x0004E668
		private void ItemSeason8Episode1Enc(string filePath)
		{
			List<byte> list = new List<byte>();
			for (int i = 0; i < 8192; i++)
			{
				bool flag = false;
				for (int j = 528; j < 558; j++)
				{
					if (Convert.ToByte(this.fStruct[i, j]) != 0)
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					byte[] array = new byte[this.sBlockSize];
					for (int k = 0; k < this.sBlockSize; k++)
					{
						array[k] = Convert.ToByte(this.fStruct[i, k]);
					}
					this.EncBlock(ref array, array.Length);
					for (int l = 0; l < this.sBlockSize; l++)
					{
						list.Add(array[l]);
					}
				}
				this.backgroundWorker.ReportProgress(i);
			}
			this.newFile = new byte[4 + list.Count + this.endBytes.Length];
			this.startBytes = BitConverter.GetBytes(list.Count / this.sBlockSize);
			Array.Copy(this.startBytes, 0, this.newFile, 0, 4);
			byte[] array2 = list.ToArray<byte>();
			Array.Copy(array2, 0, this.newFile, 4, array2.Length);
			Array.Copy(this.endBytes, 0, this.newFile, this.newFile.Length - 4, this.endBytes.Length);
			Array.Copy(this.CalcCRC(this.newFile, 58097u, 0u), 0, this.newFile, this.newFile.Length - 4, 4);
			File.WriteAllBytes(filePath, this.newFile);
		}

		// Token: 0x0600052B RID: 1323 RVA: 0x000505F0 File Offset: 0x0004E7F0
		private void ItemSetOption_Save()
		{
			Form1.SendArgs sendArgs = new Form1.SendArgs();
			SaveFileDialog saveFileDialog = new SaveFileDialog
			{
				AddExtension = true,
				Title = "Select a location to save the ItemSetOption.bmd File",
				Filter = "BMD files (*.bmd)|*.bmd|All files (*.*)|*.*"
			};
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.newFile = new byte[this.sSize * this.sBlockSize + 4];
				this.toolStripProgressBar_Save.Visible = true;
				this.toolStripProgressBar_Save.Value = 0;
				this.toolStripProgressBar_Save.Size = new Size(base.Width - 460, 22);
				this.toolStripProgressBar_Save.Maximum = this.workingDGV.Rows.Count;
				sendArgs.filePath = saveFileDialog.FileName;
				sendArgs.fileType = "ItemSetOption";
				this.backgroundWorker.RunWorkerAsync(sendArgs);
			}
		}

		// Token: 0x0600052C RID: 1324 RVA: 0x000506C4 File Offset: 0x0004E8C4
		private void ItemSetOptionbw_DoWork(object sender, DoWorkEventArgs e)
		{
			Form1.SendArgs sendArgs = (Form1.SendArgs)e.Argument;
			this.ItemSetOptiondgv = this.ItemSetOptionDec(sendArgs.filePath);
		}

		// Token: 0x0600052D RID: 1325 RVA: 0x000506F0 File Offset: 0x0004E8F0
		private void ItemSetOptionbw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this.toolStripButton_AddRow.Enabled = false;
			this.toolStripButton_RemoveSelectedRow.Enabled = false;
			this.panel1.Controls.Add(this.ItemSetOptiondgv);
			this.progressBar_Loading.Visible = false;
			this.ItemSetOptiondgv.CellValueChanged += this.ItemSetOptiondgv_CellValueChanged;
			this.ItemSetOptiondgv.Disposed += this.ItemSetOptiondgv_Disposed;
			this.ItemSetOptiondgv.KeyDown += this.dgvPasteEvent_KeyDown;
			this.workingDGV = this.ItemSetOptiondgv;
			this.workingDGV.RowsAdded += this.dgv_RowsAdded;
		}

		// Token: 0x0600052E RID: 1326 RVA: 0x000507A0 File Offset: 0x0004E9A0
		private DataGridView ItemSetOptionDec(string filePath)
		{
			DataGridView dataGridView = new DataGridView();
			this.initializeItemSetOptionGrid(dataGridView);
			try
			{
				FileStream fileStream = new FileStream(filePath, FileMode.Open);
				this.sBlockSize = 110;
				byte[] array = new byte[fileStream.Length];
				this.sSize = ((int)fileStream.Length - 4) / this.sBlockSize;
				fileStream.Read(array, 0, array.Length);
				fileStream.Close();
				for (int i = 0; i < this.sSize; i++)
				{
					byte[] array2 = new byte[this.sBlockSize];
					Array.Copy(array, i * this.sBlockSize, array2, 0, this.sBlockSize);
					this.DecBlock(ref array2, array2.Length);
					dataGridView.Rows.Add();
					dataGridView[0, i].Value = Encoding.GetEncoding("GB2312").GetString(array2, 0, 64).Trim(new char[1]).Replace("?", "");
					for (int j = 1; j < 47; j++)
					{
						dataGridView[j, i].Value = array2[j + 63];
					}
				}
			}
			catch (Exception ex)
			{
				dataGridView = new DataGridView();
				MessageBox.Show("The selected file failed to decrypt. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			return dataGridView;
		}

		// Token: 0x0600052F RID: 1327 RVA: 0x00050904 File Offset: 0x0004EB04
		private void ItemSetOptiondgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			DataGridView dataGridView = (DataGridView)sender;
			dataGridView[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.PaleGreen;
		}

		// Token: 0x06000530 RID: 1328 RVA: 0x00050939 File Offset: 0x0004EB39
		private void ItemSetOptiondgv_Disposed(object sender, EventArgs e)
		{
			if (Application.OpenForms["Form_Search"] != null)
			{
				Application.OpenForms["Form_Search"].Close();
			}
		}

		// Token: 0x06000531 RID: 1329 RVA: 0x00050960 File Offset: 0x0004EB60
		private void ItemSetOptionEnc(string filePath)
		{
			int num = 0;
			List<byte> list = new List<byte>();
			foreach (object obj in ((IEnumerable)this.workingDGV.Rows))
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
				bool flag = true;
				for (int i = 1; i < 47; i++)
				{
					if (dataGridViewRow.Cells[i].Value == null)
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					byte[] array = new byte[this.sBlockSize];
					byte[] bytes = Encoding.GetEncoding("GB2312").GetBytes(dataGridViewRow.Cells[0].Value.ToString());
					Array.Resize<byte>(ref bytes, 64);
					Array.Copy(bytes, 0, array, 0, 64);
					for (int j = 0; j < 46; j++)
					{
						Array.Copy(BitConverter.GetBytes((short)Convert.ToByte(dataGridViewRow.Cells[j + 1].Value.ToString())), 0, array, j + 64, 1);
					}
					this.EncBlock(ref array, this.sBlockSize);
					for (int k = 0; k < array.Length; k++)
					{
						list.Add(array[k]);
					}
					this.backgroundWorker.ReportProgress(dataGridViewRow.Index);
					num += this.sBlockSize;
				}
			}
			byte[] array2 = list.ToArray();
			this.newFile = new byte[array2.Length + 4];
			Array.Copy(array2, this.newFile, array2.Length);
			Array.Copy(this.CalcCRC(this.newFile, 41713u, 0u), 0, this.newFile, this.newFile.Length - 4, 4);
			File.WriteAllBytes(filePath, this.newFile);
		}

		// Token: 0x06000532 RID: 1330 RVA: 0x00050B3C File Offset: 0x0004ED3C
		private void ItemSetType_Save()
		{
			Form1.SendArgs sendArgs = new Form1.SendArgs();
			SaveFileDialog saveFileDialog = new SaveFileDialog
			{
				AddExtension = true,
				Title = "Select a location to save the ItemSetType.bmd File",
				Filter = "BMD files (*.bmd)|*.bmd|All files (*.*)|*.*"
			};
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.newFile = new byte[this.sSize * this.sBlockSize + 4];
				this.toolStripProgressBar_Save.Visible = true;
				this.toolStripProgressBar_Save.Value = 0;
				this.toolStripProgressBar_Save.Size = new Size(base.Width - 460, 22);
				this.toolStripProgressBar_Save.Maximum = this.sSize * this.sBlockSize;
				base.Invalidate();
				sendArgs.filePath = saveFileDialog.FileName;
				sendArgs.fileType = "ItemSetType";
				this.backgroundWorker.RunWorkerAsync(sendArgs);
			}
		}

		// Token: 0x06000533 RID: 1331 RVA: 0x00050C14 File Offset: 0x0004EE14
		private DataGridView ItemSetTypeDec(string filePath)
		{
			DataGridView result = new DataGridView();
			try
			{
				FileStream fileStream = new FileStream(filePath, FileMode.Open);
				byte[] array = new byte[fileStream.Length];
				this.sBlockSize = 4;
				this.sSize = (array.Length - 4) / this.sBlockSize;
				this.T_fStruct = new byte[this.sSize * this.sBlockSize];
				fileStream.Read(array, 0, array.Length);
				fileStream.Close();
				Array.Copy(array, array.Length - 4, this.endBytes, 0, 4);
				byte[] array2 = new byte[this.sBlockSize];
				int num = 0;
				int num2 = 0;
				for (int i = 0; i < this.sSize; i++)
				{
					Array.Copy(array, i * this.sBlockSize, array2, 0, this.sBlockSize);
					this.DecBlock(ref array2, this.sBlockSize);
					bool flag = false;
					for (int j = 0; j < array2.Length; j++)
					{
						if (array2[j] != 0)
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						for (int k = 0; k < this.sBlockSize; k++)
						{
							this.T_fStruct[(512 * num2 + num) * this.sBlockSize + k] = array2[k];
						}
					}
					num++;
					if (num > 511)
					{
						num = 0;
						num2++;
					}
				}
			}
			catch (Exception ex)
			{
				result = new DataGridView();
				MessageBox.Show("The selected file failed to decrypt. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			return result;
		}

		// Token: 0x06000534 RID: 1332 RVA: 0x00050DA0 File Offset: 0x0004EFA0
		private void ItemSetTypeEnc(string filePath)
		{
			byte[] array = new byte[this.sBlockSize];
			for (int i = 0; i < this.sSize; i++)
			{
				Array.Copy(this.T_fStruct, i * this.sBlockSize, array, 0, this.sBlockSize);
				this.EncBlock(ref array, this.sBlockSize);
				Array.Copy(array, 0, this.newFile, i * this.sBlockSize, array.Length);
			}
			Array.Copy(this.endBytes, 0, this.newFile, this.newFile.Length - 4, 4);
			Array.Copy(this.CalcCRC(this.newFile.ToArray<byte>(), 58865u, 0u), 0, this.newFile, this.newFile.Length - 4, 4);
			File.WriteAllBytes(filePath, this.newFile);
		}

		// Token: 0x06000535 RID: 1333 RVA: 0x00050E64 File Offset: 0x0004F064
		private void ItemToolTip_Save()
		{
			Form1.SendArgs sendArgs = new Form1.SendArgs();
			SaveFileDialog saveFileDialog = new SaveFileDialog
			{
				AddExtension = true,
				Title = "Select a location to save the ItemToolTip.bmd File",
				Filter = "BMD files (*.bmd)|*.bmd|All files (*.*)|*.*"
			};
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.newFile = new byte[this.sSize * this.sBlockSize + 4];
				this.toolStripProgressBar_Save.Visible = true;
				this.toolStripProgressBar_Save.Value = 0;
				this.toolStripProgressBar_Save.Size = new Size(base.Width - 460, 22);
				this.toolStripProgressBar_Save.Maximum = this.sSize * this.sBlockSize;
				base.Invalidate();
				sendArgs.filePath = saveFileDialog.FileName;
				sendArgs.fileType = "ItemToolTip";
				this.backgroundWorker.RunWorkerAsync(sendArgs);
			}
		}

		// Token: 0x06000536 RID: 1334 RVA: 0x00050F3C File Offset: 0x0004F13C
		private DataGridView ItemToolTipDec(string filePath)
		{
			DataGridView result = new DataGridView();
			try
			{
				FileStream fileStream = new FileStream(filePath, FileMode.Open);
				byte[] array = new byte[fileStream.Length];
				this.T_fStruct = new byte[this.sSize * this.sBlockSize];
				fileStream.Read(array, 0, array.Length);
				fileStream.Close();
				Array.Copy(array, array.Length - 4, this.endBytes, 0, 4);
				byte[] array2 = new byte[this.sBlockSize];
				int num = 0;
				for (int i = 0; i < this.sSize; i++)
				{
					Array.Copy(array, i * this.sBlockSize, array2, 0, this.sBlockSize);
					this.DecBlock(ref array2, this.sBlockSize);
					bool flag = false;
					for (int j = 4; j < 69; j++)
					{
						if (array2[j] != 0)
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						int num2 = Convert.ToInt32(BitConverter.ToUInt16(array2, 2));
						if (num != (int)array2[0])
						{
							num2 = 0;
						}
						for (int k = 0; k < this.sBlockSize; k++)
						{
							this.T_fStruct[(512 * (int)array2[0] + num2) * this.sBlockSize + k] = array2[k];
						}
						num = (int)array2[0];
					}
				}
			}
			catch (Exception ex)
			{
				result = new DataGridView();
				MessageBox.Show("The selected file failed to decrypt. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			return result;
		}

		// Token: 0x06000537 RID: 1335 RVA: 0x000510B4 File Offset: 0x0004F2B4
		private void ItemToolTipEnc(string filePath)
		{
			byte[] array = new byte[this.sBlockSize];
			int num = 0;
			for (int i = 0; i < this.sSize; i++)
			{
				Array.Copy(this.T_fStruct, i * this.sBlockSize, array, 0, this.sBlockSize);
				this.EncBlock(ref array, this.sBlockSize);
				Array.Copy(array, 0, this.newFile, i * this.sBlockSize, array.Length);
				num++;
				if (num > 511)
				{
					num = 0;
				}
			}
			Array.Copy(this.endBytes, 0, this.newFile, this.newFile.Length - 4, 4);
			Array.Copy(this.CalcCRC(this.newFile.ToArray<byte>(), 58097u, 0u), 0, this.newFile, this.newFile.Length - 4, 4);
			File.WriteAllBytes(filePath, this.newFile);
		}

		// Token: 0x06000538 RID: 1336 RVA: 0x00051188 File Offset: 0x0004F388
		private void ItemToolTipText_Save()
		{
			Form1.SendArgs sendArgs = new Form1.SendArgs();
			SaveFileDialog saveFileDialog = new SaveFileDialog
			{
				AddExtension = true,
				Title = "Select a location to save the ItemToolTipText.bmd File",
				Filter = "BMD files (*.bmd)|*.bmd|All files (*.*)|*.*"
			};
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.toolStripProgressBar_Save.Visible = true;
				this.toolStripProgressBar_Save.Value = 0;
				this.toolStripProgressBar_Save.Size = new Size(base.Width - 460, 22);
				this.toolStripProgressBar_Save.Maximum = this.workingDGV.Rows.Count;
				sendArgs.filePath = saveFileDialog.FileName;
				sendArgs.fileType = "ItemToolTipText";
				this.backgroundWorker.RunWorkerAsync(sendArgs);
			}
		}

		// Token: 0x06000539 RID: 1337 RVA: 0x00051240 File Offset: 0x0004F440
		private void ItemToolTipTextbw_DoWork(object sender, DoWorkEventArgs e)
		{
			Form1.SendArgs sendArgs = (Form1.SendArgs)e.Argument;
			this.ItemToolTipTextdgv = this.ItemToolTipTextDec(sendArgs.filePath);
		}

		// Token: 0x0600053A RID: 1338 RVA: 0x0005126C File Offset: 0x0004F46C
		private void ItemToolTipTextbw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this.toolStripButton_AddRow.Enabled = false;
			this.toolStripButton_RemoveSelectedRow.Enabled = false;
			this.panel1.Controls.Add(this.ItemToolTipTextdgv);
			this.progressBar_Loading.Visible = false;
			this.ItemToolTipTextdgv.Disposed += this.ItemToolTipTextdgv_Disposed;
			this.ItemToolTipTextdgv.KeyDown += this.dgvPasteEvent_KeyDown;
			this.ItemToolTipTextdgv.CellValueChanged += this.ItemToolTipTextdgv_CellValueChanged;
			this.workingDGV = this.ItemToolTipTextdgv;
			this.workingDGV.RowsAdded += this.dgv_RowsAdded;
		}

		// Token: 0x0600053B RID: 1339 RVA: 0x0005131C File Offset: 0x0004F51C
		private DataGridView ItemToolTipTextDec(string filePath)
		{
			DataGridView dataGridView = new DataGridView();
			try
			{
				this.initializeItemToolTipTextGrid(dataGridView);
				FileStream fileStream = new FileStream(filePath, FileMode.Open);
				byte[] array = new byte[fileStream.Length];
				fileStream.Read(array, 0, array.Length);
				fileStream.Close();
				this.endBytes = new byte[4];
				Array.Copy(array, array.Length - 4, this.endBytes, 0, this.endBytes.Length);
				this.sBlockSize = 260;
				this.sSize = (array.Length - 4) / this.sBlockSize;
				for (int i = 0; i < this.sSize; i++)
				{
					byte[] array2 = new byte[this.sBlockSize];
					Array.Copy(array, i * this.sBlockSize, array2, 0, this.sBlockSize);
					this.DecBlock(ref array2, array2.Length);
					byte[] array3 = new byte[256];
					Array.Copy(array2, 2, array3, 0, array3.Length);
					string arg = string.Empty;
					foreach (byte value in array3)
					{
						arg += Convert.ToChar(value);
					}
					dataGridView.Rows.Add();
					dataGridView[0, i].Value = BitConverter.ToUInt16(array2, 0);
					dataGridView[1, i].Value = Encoding.GetEncoding("GB2312").GetString(array3).Replace("\0", string.Empty);
					dataGridView[2, i].Value = BitConverter.ToUInt16(array2, 258);
				}
			}
			catch (Exception ex)
			{
				dataGridView = new DataGridView();
				MessageBox.Show("The selected file failed to decrypt. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			return dataGridView;
		}

		// Token: 0x0600053C RID: 1340 RVA: 0x000514F8 File Offset: 0x0004F6F8
		private void ItemToolTipTextdgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			DataGridView dataGridView = (DataGridView)sender;
			if (dataGridView.EditingControl != null)
			{
				if (dataGridView.EditingControl.Text.Length > 258)
				{
					MessageBox.Show("Maximum 20 Chars allowed.", "Eroor", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					dataGridView.EditingControl.Text = dataGridView.EditingControl.Text.Remove(258);
					dataGridView[e.ColumnIndex, e.RowIndex].Value = dataGridView.EditingControl.Text;
				}
			}
			else if (this.isPasteFromCP)
			{
				if (this.PasteValue.Length > 20)
				{
					dataGridView[e.ColumnIndex, e.RowIndex].Value = this.PasteValue.Remove(258);
				}
			}
			else if (dataGridView.CurrentCell.Value.ToString().Length > 20)
			{
				dataGridView[e.ColumnIndex, e.RowIndex].Value = dataGridView.CurrentCell.Value.ToString().Remove(258);
			}
			this.ItemToolTipTextdgv[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.PaleGreen;
		}

		// Token: 0x0600053D RID: 1341 RVA: 0x00051638 File Offset: 0x0004F838
		private void ItemToolTipTextdgv_Disposed(object sender, EventArgs e)
		{
			this.toolStripButton_Save.Enabled = false;
			if (Application.OpenForms["Form_Search"] != null)
			{
				Application.OpenForms["Form_Search"].Close();
			}
		}

		// Token: 0x0600053E RID: 1342 RVA: 0x0005166C File Offset: 0x0004F86C
		private void ItemToolTipTextEnc(string filePath)
		{
			List<byte> list = new List<byte>();
			foreach (object obj in ((IEnumerable)this.workingDGV.Rows))
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
				byte[] array = new byte[this.sBlockSize];
				ushort value = 0;
				string s = string.Empty;
				ushort value2 = 0;
				if (dataGridViewRow.Cells[0].Value != null)
				{
					value = Convert.ToUInt16(dataGridViewRow.Cells[0].Value.ToString());
				}
				if (dataGridViewRow.Cells[1].Value != null)
				{
					s = dataGridViewRow.Cells[1].Value.ToString();
				}
				if (dataGridViewRow.Cells[2].Value != null)
				{
					value2 = Convert.ToUInt16(dataGridViewRow.Cells[2].Value.ToString());
				}
				Array.Copy(BitConverter.GetBytes(value), 0, array, 0, 2);
				byte[] bytes = Encoding.GetEncoding("GB2312").GetBytes(s);
				Array.Copy(bytes, 0, array, 2, bytes.Length);
				Array.Copy(BitConverter.GetBytes(value2), 0, array, 258, 2);
				this.EncBlock(ref array, array.Length);
				for (int i = 0; i < array.Length; i++)
				{
					list.Add(array[i]);
				}
				this.backgroundWorker.ReportProgress(this.workingDGV.Rows.IndexOf(dataGridViewRow));
			}
			for (int j = 0; j < this.endBytes.Length; j++)
			{
				list.Add(this.endBytes[j]);
			}
			this.newFile = new byte[0];
			this.CalcCRC(list.ToArray(), 15997u, 0u);
			this.newFile = list.ToArray();
			File.WriteAllBytes(filePath, this.newFile);
		}

		// Token: 0x0600053F RID: 1343 RVA: 0x00051868 File Offset: 0x0004FA68
		private void itemToolTipTextToolStripMenuItem_Load_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Title = "Select the ItemToolTipText.bmd File",
				Filter = "BMD files (*.bmd)|*.bmd|All files (*.*)|*.*"
			};
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				if (!this.toolStrip_RowOptions.Enabled)
				{
					this.toolStrip_RowOptions.Enabled = true;
				}
				this.isLeaveOpenItemAdder = false;
				this.panel1_DisposeUnusedControls();
				this.s_LoadedFile = "ItemToolTipText";
				this.ItemToolTipTextdgv = new DataGridView();
				this.toolStripButton_Save.Enabled = true;
				this.progressBar_Loading.Location = new Point(this.panel1.Location.X + this.panel1.Size.Width / 2 - this.progressBar_Loading.Size.Width / 2, this.panel1.Location.Y + this.panel1.Size.Height / 2 - this.progressBar_Loading.Size.Height / 2);
				this.progressBar_Loading.Visible = true;
				Form1.SendArgs argument = new Form1.SendArgs
				{
					filePath = openFileDialog.FileName
				};
				BackgroundWorker backgroundWorker = new BackgroundWorker();
				backgroundWorker.RunWorkerCompleted += this.ItemToolTipTextbw_RunWorkerCompleted;
				backgroundWorker.DoWork += this.ItemToolTipTextbw_DoWork;
				backgroundWorker.RunWorkerAsync(argument);
				openFileDialog.FileName.Split(new char[]
				{
					'\\'
				});
				this.toolStripLabel_FileName1.Text = "ItemToolTipText.bmd File";
				this.toolStripLabel_FileName2.Text = "[" + openFileDialog.FileName + "]";
			}
		}

		// Token: 0x06000540 RID: 1344 RVA: 0x00051A1C File Offset: 0x0004FC1C
		private void ITTbw_DoWork(object sender, DoWorkEventArgs e)
		{
			Form1.SendArgs sendArgs = (Form1.SendArgs)e.Argument;
			this.ItemToolTipDec(sendArgs.filePath);
		}

		// Token: 0x06000541 RID: 1345 RVA: 0x00051A44 File Offset: 0x0004FC44
		private void ITTbw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this.toolStripButton_BmdItemAdder.Enabled = true;
			this.isLeaveOpenItemAdder = true;
			this.toolStripButton_AddRow.Enabled = false;
			this.toolStripButton_RemoveSelectedRow.Enabled = false;
			this.progressBar_Loading.Visible = false;
			this.tc_Items.SelectedIndex = -1;
			this.tc_Items.SelectedIndex = 0;
		}

		// Token: 0x06000542 RID: 1346 RVA: 0x00051AA0 File Offset: 0x0004FCA0
		private void ITTdgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			DataGridView dataGridView = (DataGridView)sender;
			byte b = Convert.ToByte(dataGridView[0, e.RowIndex].Value);
			int rowIndex = e.RowIndex;
			if (e.ColumnIndex == 0)
			{
				dataGridView[e.ColumnIndex, e.RowIndex].Value = b;
				return;
			}
			if (dataGridView.EditingControl != null)
			{
				if (dataGridView.EditingControl.Text == "")
				{
					dataGridView.EditingControl.Text = "0";
				}
			}
			else if (this.PasteValue == "")
			{
				this.PasteValue = "0";
			}
			byte[] array = new byte[64];
			byte[] array2 = new byte[2];
			string text = string.Empty;
			if (this.isPasteFromCP)
			{
				text = this.PasteValue;
			}
			else if (dataGridView.EditingControl != null)
			{
				text = dataGridView.EditingControl.Text;
			}
			else
			{
				text = dataGridView[e.ColumnIndex, e.RowIndex].Value.ToString();
			}
			if (e.ColumnIndex == 1 && Convert.ToInt16(text) > 511)
			{
				text = "511";
				dataGridView.EditingControl.Text = text;
				dataGridView[e.ColumnIndex, e.RowIndex].Value = text;
			}
			this.T_fStruct[((int)b * 512 + rowIndex) * this.sBlockSize] = b;
			switch (e.ColumnIndex)
			{
			case 1:
				array2 = BitConverter.GetBytes(Convert.ToInt16(text));
				for (int i = 0; i < array2.Length; i++)
				{
					this.T_fStruct[((int)b * 512 + rowIndex) * this.sBlockSize + 2 + i] = array2[i];
				}
				break;
			case 2:
				this.StrToByteArray(ref array, text);
				for (int j = 0; j < array.Length; j++)
				{
					this.T_fStruct[((int)b * 512 + rowIndex) * this.sBlockSize + 4 + j] = array[j];
				}
				break;
			case 3:
				array2 = BitConverter.GetBytes(Convert.ToInt16(text));
				for (int k = 0; k < array2.Length; k++)
				{
					this.T_fStruct[((int)b * 512 + rowIndex) * this.sBlockSize + 68 + k] = array2[k];
				}
				break;
			case 4:
				array2 = BitConverter.GetBytes(Convert.ToInt16(text));
				for (int l = 0; l < array2.Length; l++)
				{
					this.T_fStruct[((int)b * 512 + rowIndex) * this.sBlockSize + 70 + l] = array2[l];
				}
				break;
			case 5:
				array2 = BitConverter.GetBytes(Convert.ToInt16(text));
				for (int m = 0; m < array2.Length; m++)
				{
					this.T_fStruct[((int)b * 512 + rowIndex) * this.sBlockSize + 72 + m] = array2[m];
				}
				break;
			case 6:
				array2 = BitConverter.GetBytes(Convert.ToInt16(text));
				for (int n = 0; n < array2.Length; n++)
				{
					this.T_fStruct[((int)b * 512 + rowIndex) * this.sBlockSize + 74 + n] = array2[n];
				}
				break;
			case 7:
				array2 = BitConverter.GetBytes(Convert.ToInt16(text));
				for (int num = 0; num < array2.Length; num++)
				{
					this.T_fStruct[((int)b * 512 + rowIndex) * this.sBlockSize + 76 + num] = array2[num];
				}
				break;
			case 8:
				array2 = BitConverter.GetBytes(Convert.ToInt16(text));
				for (int num2 = 0; num2 < array2.Length; num2++)
				{
					this.T_fStruct[((int)b * 512 + rowIndex) * this.sBlockSize + 78 + num2] = array2[num2];
				}
				break;
			case 9:
				array2 = BitConverter.GetBytes(Convert.ToInt16(text));
				for (int num3 = 0; num3 < array2.Length; num3++)
				{
					this.T_fStruct[((int)b * 512 + rowIndex) * this.sBlockSize + 80 + num3] = array2[num3];
				}
				break;
			case 10:
				array2 = BitConverter.GetBytes(Convert.ToInt16(text));
				for (int num4 = 0; num4 < array2.Length; num4++)
				{
					this.T_fStruct[((int)b * 512 + rowIndex) * this.sBlockSize + 82 + num4] = array2[num4];
				}
				break;
			case 11:
				array2 = BitConverter.GetBytes(Convert.ToInt16(text));
				for (int num5 = 0; num5 < array2.Length; num5++)
				{
					this.T_fStruct[((int)b * 512 + rowIndex) * this.sBlockSize + 84 + num5] = array2[num5];
				}
				break;
			case 12:
				array2 = BitConverter.GetBytes(Convert.ToInt16(text));
				for (int num6 = 0; num6 < array2.Length; num6++)
				{
					this.T_fStruct[((int)b * 512 + rowIndex) * this.sBlockSize + 86 + num6] = array2[num6];
				}
				break;
			case 13:
				array2 = BitConverter.GetBytes(Convert.ToInt16(text));
				for (int num7 = 0; num7 < array2.Length; num7++)
				{
					this.T_fStruct[((int)b * 512 + rowIndex) * this.sBlockSize + 88 + num7] = array2[num7];
				}
				break;
			case 14:
				array2 = BitConverter.GetBytes(Convert.ToInt16(text));
				for (int num8 = 0; num8 < array2.Length; num8++)
				{
					this.T_fStruct[((int)b * 512 + rowIndex) * this.sBlockSize + 90 + num8] = array2[num8];
				}
				break;
			case 15:
				array2 = BitConverter.GetBytes(Convert.ToInt16(text));
				for (int num9 = 0; num9 < array2.Length; num9++)
				{
					this.T_fStruct[((int)b * 512 + rowIndex) * this.sBlockSize + 92 + num9] = array2[num9];
				}
				break;
			case 16:
				array2 = BitConverter.GetBytes(Convert.ToInt16(text));
				for (int num10 = 0; num10 < array2.Length; num10++)
				{
					this.T_fStruct[((int)b * 512 + rowIndex) * this.sBlockSize + 94 + num10] = array2[num10];
				}
				break;
			case 17:
				array2 = BitConverter.GetBytes(Convert.ToInt16(text));
				for (int num11 = 0; num11 < array2.Length; num11++)
				{
					this.T_fStruct[((int)b * 512 + rowIndex) * this.sBlockSize + 96 + num11] = array2[num11];
				}
				break;
			case 18:
				array2 = BitConverter.GetBytes(Convert.ToInt16(text));
				for (int num12 = 0; num12 < array2.Length; num12++)
				{
					this.T_fStruct[((int)b * 512 + rowIndex) * this.sBlockSize + 98 + num12] = array2[num12];
				}
				break;
			case 19:
				array2 = BitConverter.GetBytes(Convert.ToInt16(text));
				for (int num13 = 0; num13 < array2.Length; num13++)
				{
					this.T_fStruct[((int)b * 512 + rowIndex) * this.sBlockSize + 100 + num13] = array2[num13];
				}
				break;
			case 20:
				array2 = BitConverter.GetBytes(Convert.ToInt16(text));
				for (int num14 = 0; num14 < array2.Length; num14++)
				{
					this.T_fStruct[((int)b * 512 + rowIndex) * this.sBlockSize + 102 + num14] = array2[num14];
				}
				break;
			case 21:
				array2 = BitConverter.GetBytes(Convert.ToInt16(text));
				for (int num15 = 0; num15 < array2.Length; num15++)
				{
					this.T_fStruct[((int)b * 512 + rowIndex) * this.sBlockSize + 104 + num15] = array2[num15];
				}
				break;
			case 22:
				array2 = BitConverter.GetBytes(Convert.ToInt16(text));
				for (int num16 = 0; num16 < array2.Length; num16++)
				{
					this.T_fStruct[((int)b * 512 + rowIndex) * this.sBlockSize + 106 + num16] = array2[num16];
				}
				break;
			case 23:
				array2 = BitConverter.GetBytes(Convert.ToInt16(text));
				for (int num17 = 0; num17 < array2.Length; num17++)
				{
					this.T_fStruct[((int)b * 512 + rowIndex) * this.sBlockSize + 108 + num17] = array2[num17];
				}
				break;
			case 24:
				array2 = BitConverter.GetBytes(Convert.ToInt16(text));
				for (int num18 = 0; num18 < array2.Length; num18++)
				{
					this.T_fStruct[((int)b * 512 + rowIndex) * this.sBlockSize + 110 + num18] = array2[num18];
				}
				break;
			case 25:
				array2 = BitConverter.GetBytes(Convert.ToInt16(text));
				for (int num19 = 0; num19 < array2.Length; num19++)
				{
					this.T_fStruct[((int)b * 512 + rowIndex) * this.sBlockSize + 112 + num19] = array2[num19];
				}
				break;
			case 26:
				array2 = BitConverter.GetBytes(Convert.ToInt16(text));
				for (int num20 = 0; num20 < array2.Length; num20++)
				{
					this.T_fStruct[((int)b * 512 + rowIndex) * this.sBlockSize + 114 + num20] = array2[num20];
				}
				break;
			case 27:
				array2 = BitConverter.GetBytes(Convert.ToInt16(text));
				for (int num21 = 0; num21 < array2.Length; num21++)
				{
					this.T_fStruct[((int)b * 512 + rowIndex) * this.sBlockSize + 116 + num21] = array2[num21];
				}
				break;
			case 28:
				array2 = BitConverter.GetBytes(Convert.ToInt16(text));
				for (int num22 = 0; num22 < array2.Length; num22++)
				{
					this.T_fStruct[((int)b * 512 + rowIndex) * this.sBlockSize + 118 + num22] = array2[num22];
				}
				break;
			case 29:
				array2 = BitConverter.GetBytes(Convert.ToInt16(text));
				for (int num23 = 0; num23 < array2.Length; num23++)
				{
					this.T_fStruct[((int)b * 512 + rowIndex) * this.sBlockSize + 120 + num23] = array2[num23];
				}
				break;
			case 30:
				array2 = BitConverter.GetBytes(Convert.ToInt16(text));
				for (int num24 = 0; num24 < array2.Length; num24++)
				{
					this.T_fStruct[((int)b * 512 + rowIndex) * this.sBlockSize + 122 + num24] = array2[num24];
				}
				break;
			}
			dataGridView[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.PaleGreen;
			bool flag = true;
			foreach (object obj in dataGridView.Columns)
			{
				DataGridViewColumn dataGridViewColumn = (DataGridViewColumn)obj;
				if (dataGridView[dataGridViewColumn.Index, e.RowIndex].Value != null)
				{
					if (dataGridView[dataGridViewColumn.Index, e.RowIndex].Value.ToString() != "0" || dataGridView[dataGridViewColumn.Index, e.RowIndex].Value.ToString() != "")
					{
						flag = false;
					}
				}
				else if (dataGridView.EditingControl.Text != "0" || dataGridView[dataGridViewColumn.Index, e.RowIndex].Value.ToString() != "")
				{
					flag = false;
				}
			}
			if (flag)
			{
				for (int num25 = 0; num25 < this.sBlockSize; num25++)
				{
					this.T_fStruct[(int)b * 512 * this.sBlockSize + num25] = 0;
				}
			}
		}

		// Token: 0x06000543 RID: 1347 RVA: 0x0005264C File Offset: 0x0005084C
		private void ITTdgv_Disposed(object sender, EventArgs e)
		{
			if (Application.OpenForms["Form_Search"] != null)
			{
				Application.OpenForms["Form_Search"].Close();
			}
			if (!this.isLeaveOpenItemAdder)
			{
				if (Application.OpenForms["Form_BmdItemAddercs"] != null)
				{
					Application.OpenForms["Form_BmdItemAddercs"].Close();
				}
				this.toolStripButton_BmdItemAdder.Enabled = false;
			}
		}

		// Token: 0x06000544 RID: 1348 RVA: 0x000526B8 File Offset: 0x000508B8
		private void JewelOfHarmonySmelt_Save()
		{
			Form1.SendArgs sendArgs = new Form1.SendArgs();
			SaveFileDialog saveFileDialog = new SaveFileDialog
			{
				AddExtension = true,
				Title = "Select a location to save the JewelOfHarmonySmelt.bmd File",
				Filter = "BMD files (*.bmd)|*.bmd|All files (*.*)|*.*"
			};
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.newFile = new byte[this.sSize * this.sBlockSize];
				this.toolStripProgressBar_Save.Visible = true;
				this.toolStripProgressBar_Save.Value = 0;
				this.toolStripProgressBar_Save.Size = new Size(base.Width - 460, 22);
				this.toolStripProgressBar_Save.Maximum = this.sSize * this.sBlockSize;
				base.Invalidate();
				sendArgs.filePath = saveFileDialog.FileName;
				sendArgs.fileType = "JewelOfHarmonySmelt";
				this.backgroundWorker.RunWorkerAsync(sendArgs);
			}
		}

		// Token: 0x06000545 RID: 1349 RVA: 0x0005278C File Offset: 0x0005098C
		private DataGridView JewelOfHarmonySmeltDec(string filePath)
		{
			DataGridView result = new DataGridView();
			try
			{
				FileStream fileStream = new FileStream(filePath, FileMode.Open);
				byte[] array = new byte[fileStream.Length];
				this.sBlockSize = 68;
				this.sSize = array.Length / this.sBlockSize;
				this.T_fStruct = new byte[this.sSize * this.sBlockSize];
				fileStream.Read(array, 0, array.Length);
				fileStream.Close();
				this.DecBlock(ref array, array.Length);
				byte[] array2 = new byte[this.sBlockSize];
				int num = 0;
				int num2 = 0;
				for (int i = 0; i < this.sSize; i++)
				{
					Array.Copy(array, i * this.sBlockSize, array2, 0, this.sBlockSize);
					bool flag = false;
					for (int j = 0; j < array2.Length; j++)
					{
						if (array2[j] != 0)
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						for (int k = 0; k < this.sBlockSize; k++)
						{
							this.T_fStruct[(512 * num2 + num) * this.sBlockSize + k] = array2[k];
						}
					}
					num++;
					if (num > 511)
					{
						num = 0;
						num2++;
					}
				}
			}
			catch (Exception ex)
			{
				result = new DataGridView();
				MessageBox.Show("The selected file failed to decrypt. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			return result;
		}

		// Token: 0x06000546 RID: 1350 RVA: 0x00052900 File Offset: 0x00050B00
		private void JewelOfHarmonySmeltEnc(string filePath)
		{
			this.newFile = this.T_fStruct;
			this.EncBlock(ref this.newFile, this.newFile.Length);
			File.WriteAllBytes(filePath, this.newFile);
		}

		// Token: 0x06000547 RID: 1351 RVA: 0x00052930 File Offset: 0x00050B30
		private void JOHSbw_DoWork(object sender, DoWorkEventArgs e)
		{
			Form1.SendArgs sendArgs = (Form1.SendArgs)e.Argument;
			this.JewelOfHarmonySmeltDec(sendArgs.filePath);
		}

		// Token: 0x06000548 RID: 1352 RVA: 0x00052958 File Offset: 0x00050B58
		private void JOHSbw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this.toolStripButton_BmdItemAdder.Enabled = true;
			this.isLeaveOpenItemAdder = true;
			this.toolStripButton_AddRow.Enabled = false;
			this.toolStripButton_RemoveSelectedRow.Enabled = false;
			this.progressBar_Loading.Visible = false;
			this.tc_Items.SelectedIndex = -1;
			this.tc_Items.SelectedIndex = 0;
		}

		// Token: 0x06000549 RID: 1353 RVA: 0x000529B4 File Offset: 0x00050BB4
		private void JOHSdgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			DataGridView dataGridView = (DataGridView)sender;
			byte b = Convert.ToByte(dataGridView[0, e.RowIndex].Value);
			int rowIndex = e.RowIndex;
			if (e.ColumnIndex == 0)
			{
				dataGridView[e.ColumnIndex, e.RowIndex].Value = b;
				return;
			}
			if (e.ColumnIndex == 1)
			{
				dataGridView[e.ColumnIndex, e.RowIndex].Value = rowIndex;
				return;
			}
			if (dataGridView.EditingControl != null)
			{
				if (dataGridView.EditingControl.Text == "")
				{
					dataGridView.EditingControl.Text = "0";
				}
			}
			else if (this.PasteValue == "")
			{
				this.PasteValue = "0";
			}
			byte[] array = new byte[60];
			string text = string.Empty;
			if (this.isPasteFromCP)
			{
				text = this.PasteValue;
			}
			else if (dataGridView.EditingControl != null)
			{
				text = dataGridView.EditingControl.Text;
			}
			else
			{
				text = dataGridView[e.ColumnIndex, e.RowIndex].Value.ToString();
			}
			switch (e.ColumnIndex)
			{
			case 2:
				Array.Copy(BitConverter.GetBytes(Convert.ToInt32(text)), 0, this.T_fStruct, ((int)b * 512 + rowIndex) * this.sBlockSize, 4);
				break;
			case 3:
				text += "\0";
				for (int i = 4; i < 64; i++)
				{
					this.T_fStruct[((int)b * 512 + rowIndex) * this.sBlockSize + i] = byte.MaxValue;
				}
				array = Encoding.GetEncoding("GB2312").GetBytes(text);
				if (array.Length > 60)
				{
					Array.Resize<byte>(ref array, 60);
				}
				Array.Copy(array, 0, this.T_fStruct, ((int)b * 512 + rowIndex) * this.sBlockSize + 4, array.Length);
				break;
			case 4:
				Array.Copy(BitConverter.GetBytes(Convert.ToInt32(text)), 0, this.T_fStruct, ((int)b * 512 + rowIndex) * this.sBlockSize + 64, 4);
				break;
			}
			dataGridView[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.PaleGreen;
		}

		// Token: 0x0600054A RID: 1354 RVA: 0x00052BFC File Offset: 0x00050DFC
		private void JOHSdgv_Disposed(object sender, EventArgs e)
		{
			if (Application.OpenForms["Form_Search"] != null)
			{
				Application.OpenForms["Form_Search"].Close();
			}
			if (!this.isLeaveOpenItemAdder)
			{
				if (Application.OpenForms["Form_BmdItemAddercs"] != null)
				{
					Application.OpenForms["Form_BmdItemAddercs"].Close();
				}
				this.toolStripButton_BmdItemAdder.Enabled = false;
			}
		}

		// Token: 0x0600054B RID: 1355 RVA: 0x00052C68 File Offset: 0x00050E68
		private void loadToolStripMenuItem_FilterBMD_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Title = "Select the Filter.bmd File",
				Filter = "BMD files (*.bmd)|*.bmd|All files (*.*)|*.*"
			};
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				if (!this.toolStrip_RowOptions.Enabled)
				{
					this.toolStrip_RowOptions.Enabled = true;
				}
				this.isLeaveOpenItemAdder = false;
				this.panel1_DisposeUnusedControls();
				this.s_LoadedFile = "Filter";
				this.Filterdgv = new DataGridView();
				this.toolStripButton_Save.Enabled = true;
				this.progressBar_Loading.Location = new Point(this.panel1.Location.X + this.panel1.Size.Width / 2 - this.progressBar_Loading.Size.Width / 2, this.panel1.Location.Y + this.panel1.Size.Height / 2 - this.progressBar_Loading.Size.Height / 2);
				this.progressBar_Loading.Visible = true;
				Form1.SendArgs argument = new Form1.SendArgs
				{
					filePath = openFileDialog.FileName
				};
				BackgroundWorker backgroundWorker = new BackgroundWorker();
				backgroundWorker.RunWorkerCompleted += this.Filterbw_RunWorkerCompleted;
				backgroundWorker.DoWork += this.Filterbw_DoWork;
				backgroundWorker.RunWorkerAsync(argument);
				openFileDialog.FileName.Split(new char[]
				{
					'\\'
				});
				this.toolStripLabel_FileName1.Text = "Filter.bmd File";
				this.toolStripLabel_FileName2.Text = "[" + openFileDialog.FileName + "]";
			}
		}

		// Token: 0x0600054C RID: 1356 RVA: 0x00052E1C File Offset: 0x0005101C
		private void loadToolStripMenuItem_FilterNameBMD_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Title = "Select the FilterName.bmd File",
				Filter = "BMD files (*.bmd)|*.bmd|All files (*.*)|*.*"
			};
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				if (!this.toolStrip_RowOptions.Enabled)
				{
					this.toolStrip_RowOptions.Enabled = true;
				}
				this.isLeaveOpenItemAdder = false;
				this.panel1_DisposeUnusedControls();
				this.s_LoadedFile = "FilterName";
				this.FilterNamedgv = new DataGridView();
				this.toolStripButton_Save.Enabled = true;
				this.progressBar_Loading.Location = new Point(this.panel1.Location.X + this.panel1.Size.Width / 2 - this.progressBar_Loading.Size.Width / 2, this.panel1.Location.Y + this.panel1.Size.Height / 2 - this.progressBar_Loading.Size.Height / 2);
				this.progressBar_Loading.Visible = true;
				Form1.SendArgs argument = new Form1.SendArgs
				{
					filePath = openFileDialog.FileName
				};
				BackgroundWorker backgroundWorker = new BackgroundWorker();
				backgroundWorker.RunWorkerCompleted += this.FilterNamebw_RunWorkerCompleted;
				backgroundWorker.DoWork += this.FilterNamebw_DoWork;
				backgroundWorker.RunWorkerAsync(argument);
				openFileDialog.FileName.Split(new char[]
				{
					'\\'
				});
				this.toolStripLabel_FileName1.Text = "FilterName.bmd File";
				this.toolStripLabel_FileName2.Text = "[" + openFileDialog.FileName + "]";
			}
		}

		// Token: 0x0600054D RID: 1357 RVA: 0x00052FD0 File Offset: 0x000511D0
		private void loadToolStripMenuItem_Gate_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Title = "Select the Gate.bmd File",
				Filter = "BMD files (*.bmd)|*.bmd|All files (*.*)|*.*"
			};
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				if (!this.toolStrip_RowOptions.Enabled)
				{
					this.toolStrip_RowOptions.Enabled = true;
				}
				this.isLeaveOpenItemAdder = false;
				this.panel1_DisposeUnusedControls();
				this.s_LoadedFile = "Gate";
				this.toolStripButton_Save.Enabled = true;
				this.progressBar_Loading.Location = new Point(this.panel1.Location.X + this.panel1.Size.Width / 2 - this.progressBar_Loading.Size.Width / 2, this.panel1.Location.Y + this.panel1.Size.Height / 2 - this.progressBar_Loading.Size.Height / 2);
				this.progressBar_Loading.Visible = true;
				Form1.SendArgs argument = new Form1.SendArgs
				{
					filePath = openFileDialog.FileName
				};
				BackgroundWorker backgroundWorker = new BackgroundWorker();
				backgroundWorker.RunWorkerCompleted += this.Gatebw_RunWorkerCompleted;
				backgroundWorker.DoWork += this.Gatebw_DoWork;
				backgroundWorker.RunWorkerAsync(argument);
				openFileDialog.FileName.Split(new char[]
				{
					'\\'
				});
				this.toolStripLabel_FileName1.Text = "Gate.bmd File";
				this.toolStripLabel_FileName2.Text = "[" + openFileDialog.FileName + "]";
			}
		}

		// Token: 0x0600054E RID: 1358 RVA: 0x0005317C File Offset: 0x0005137C
		private void loadToolStripMenuItem_Glow_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Title = "Select the Glow.bmd File",
				Filter = "BMD files (*.bmd)|*.bmd|All files (*.*)|*.*"
			};
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				if (!this.toolStrip_RowOptions.Enabled)
				{
					this.toolStrip_RowOptions.Enabled = true;
				}
				this.isLeaveOpenItemAdder = false;
				this.panel1_DisposeUnusedControls();
				this.s_LoadedFile = "Glow";
				this.Glowdgv = new DataGridView();
				this.toolStripButton_Save.Enabled = true;
				this.progressBar_Loading.Location = new Point(this.panel1.Location.X + this.panel1.Size.Width / 2 - this.progressBar_Loading.Size.Width / 2, this.panel1.Location.Y + this.panel1.Size.Height / 2 - this.progressBar_Loading.Size.Height / 2);
				this.progressBar_Loading.Visible = true;
				Form1.SendArgs argument = new Form1.SendArgs
				{
					filePath = openFileDialog.FileName
				};
				BackgroundWorker backgroundWorker = new BackgroundWorker();
				backgroundWorker.RunWorkerCompleted += this.Glowbw_RunWorkerCompleted;
				backgroundWorker.DoWork += this.Glowbw_DoWork;
				backgroundWorker.RunWorkerAsync(argument);
				openFileDialog.FileName.Split(new char[]
				{
					'\\'
				});
				this.toolStripLabel_FileName1.Text = "Glow.bmd File";
				this.toolStripLabel_FileName2.Text = "[" + openFileDialog.FileName + "]";
			}
		}

		// Token: 0x0600054F RID: 1359 RVA: 0x00053330 File Offset: 0x00051530
		private void loadToolStripMenuItem_IAO_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Title = "Select the ItemAddOption.bmd File",
				Filter = "BMD files (*.bmd)|*.bmd|All files (*.*)|*.*"
			};
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.isLeaveOpenItemAdder = false;
				this.panel1_DisposeUnusedControls();
				this.s_LoadedFile = "ItemAddOption";
				this.CreateItemTabCategories("IAO");
				if (!this.toolStrip_RowOptions.Enabled)
				{
					this.toolStrip_RowOptions.Enabled = true;
				}
				this.toolStripButton_Save.Enabled = true;
				this.progressBar_Loading.Location = new Point(this.panel1.Location.X + this.panel1.Size.Width / 2 - this.progressBar_Loading.Size.Width / 2, this.panel1.Location.Y + this.panel1.Size.Height / 2 - this.progressBar_Loading.Size.Height / 2);
				this.progressBar_Loading.Visible = true;
				Form1.SendArgs argument = new Form1.SendArgs
				{
					filePath = openFileDialog.FileName
				};
				BackgroundWorker backgroundWorker = new BackgroundWorker();
				backgroundWorker.DoWork += this.IAObw_DoWork;
				backgroundWorker.RunWorkerCompleted += this.IAObw_RunWorkerCompleted;
				backgroundWorker.RunWorkerAsync(argument);
				openFileDialog.FileName.Split(new char[]
				{
					'\\'
				});
				this.toolStripLabel_FileName1.Text = "ItemAddOption.bmd File";
				this.toolStripLabel_FileName2.Text = "[" + openFileDialog.FileName + "]";
			}
		}

		// Token: 0x06000550 RID: 1360 RVA: 0x000534E4 File Offset: 0x000516E4
		private void loadToolStripMenuItem_ISO_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Title = "Select the ItemSetOption.bmd File",
				Filter = "BMD files (*.bmd)|*.bmd|All files (*.*)|*.*"
			};
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				if (!this.toolStrip_RowOptions.Enabled)
				{
					this.toolStrip_RowOptions.Enabled = true;
				}
				this.isLeaveOpenItemAdder = false;
				this.panel1_DisposeUnusedControls();
				this.s_LoadedFile = "ItemSetOption";
				this.toolStripButton_Save.Enabled = true;
				this.progressBar_Loading.Location = new Point(this.panel1.Location.X + this.panel1.Size.Width / 2 - this.progressBar_Loading.Size.Width / 2, this.panel1.Location.Y + this.panel1.Size.Height / 2 - this.progressBar_Loading.Size.Height / 2);
				this.progressBar_Loading.Visible = true;
				Form1.SendArgs argument = new Form1.SendArgs
				{
					filePath = openFileDialog.FileName
				};
				BackgroundWorker backgroundWorker = new BackgroundWorker();
				backgroundWorker.RunWorkerCompleted += this.ItemSetOptionbw_RunWorkerCompleted;
				backgroundWorker.DoWork += this.ItemSetOptionbw_DoWork;
				backgroundWorker.RunWorkerAsync(argument);
				openFileDialog.FileName.Split(new char[]
				{
					'\\'
				});
				this.toolStripLabel_FileName1.Text = "ItemSetOption.bmd File";
				this.toolStripLabel_FileName2.Text = "[" + openFileDialog.FileName + "]";
			}
		}

		// Token: 0x06000551 RID: 1361 RVA: 0x00053690 File Offset: 0x00051890
		private void loadToolStripMenuItem_IST_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Title = "Select the ItemSetType.bmd File",
				Filter = "BMD files (*.bmd)|*.bmd|All files (*.*)|*.*"
			};
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.isLeaveOpenItemAdder = false;
				this.panel1_DisposeUnusedControls();
				this.s_LoadedFile = "ItemSetType";
				this.CreateItemTabCategories("IST");
				if (!this.toolStrip_RowOptions.Enabled)
				{
					this.toolStrip_RowOptions.Enabled = true;
				}
				this.toolStripButton_Save.Enabled = true;
				this.progressBar_Loading.Location = new Point(this.panel1.Location.X + this.panel1.Size.Width / 2 - this.progressBar_Loading.Size.Width / 2, this.panel1.Location.Y + this.panel1.Size.Height / 2 - this.progressBar_Loading.Size.Height / 2);
				this.progressBar_Loading.Visible = true;
				Form1.SendArgs argument = new Form1.SendArgs
				{
					filePath = openFileDialog.FileName
				};
				BackgroundWorker backgroundWorker = new BackgroundWorker();
				backgroundWorker.DoWork += this.ISTbw_DoWork;
				backgroundWorker.RunWorkerCompleted += this.ISTbw_RunWorkerCompleted;
				backgroundWorker.RunWorkerAsync(argument);
				openFileDialog.FileName.Split(new char[]
				{
					'\\'
				});
				this.toolStripLabel_FileName1.Text = "ItemSetType.bmd File";
				this.toolStripLabel_FileName2.Text = "[" + openFileDialog.FileName + "]";
			}
		}

		// Token: 0x06000552 RID: 1362 RVA: 0x00053844 File Offset: 0x00051A44
		private void loadToolStripMenuItem_Item_S6E3_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Title = "Select the Season 6 Episode 3 Item.bmd File",
				Filter = "BMD files (*.bmd)|*.bmd|All files (*.*)|*.*"
			};
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				string[] array = openFileDialog.FileName.Split(new char[]
				{
					'\\'
				});
				if (array[array.Length - 1].ToLower().EndsWith(".bmd"))
				{
					if (!this.toolStrip_RowOptions.Enabled)
					{
						this.toolStrip_RowOptions.Enabled = true;
					}
					this.sBlockSize = 84;
					this.isLeaveOpenItemAdder = false;
					this.panel1_DisposeUnusedControls();
					this.s_LoadedFile = "Item_S6E3";
					this.CreateItemTabCategories("ItemS6E3");
					this.progressBar_Loading.Location = new Point(this.panel1.Location.X + this.panel1.Size.Width / 2 - this.progressBar_Loading.Size.Width / 2, this.panel1.Location.Y + this.panel1.Size.Height / 2 - this.progressBar_Loading.Size.Height / 2);
					this.progressBar_Loading.Visible = true;
					Form1.SendArgs argument = new Form1.SendArgs
					{
						filePath = openFileDialog.FileName
					};
					BackgroundWorker backgroundWorker = new BackgroundWorker();
					backgroundWorker.RunWorkerCompleted += this.Item_S6E3bw_RunWorkerCompleted;
					backgroundWorker.DoWork += this.Item_S6E3bw_DoWork;
					backgroundWorker.RunWorkerAsync(argument);
				}
				else if (array[array.Length - 1].ToLower().EndsWith(".ini"))
				{
					return;
				}
				this.toolStripLabel_FileName1.Text = "Season 6 Episode 3 Item.bmd File";
				this.toolStripLabel_FileName2.Text = "[" + openFileDialog.FileName + "]";
			}
		}

		// Token: 0x06000553 RID: 1363 RVA: 0x00053A30 File Offset: 0x00051C30
		private void loadToolStripMenuItem_ItemEx700_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Title = "Select the ItemEx700.bmd File",
				Filter = "BMD files (*.bmd)|*.bmd|All files (*.*)|*.*"
			};
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				string[] array = openFileDialog.FileName.Split(new char[]
				{
					'\\'
				});
				if (array[array.Length - 1].ToLower().EndsWith(".bmd"))
				{
					if (!this.toolStrip_RowOptions.Enabled)
					{
						this.toolStrip_RowOptions.Enabled = true;
					}
					this.sBlockSize = 612;
					this.isLeaveOpenItemAdder = false;
					this.panel1_DisposeUnusedControls();
					this.s_LoadedFile = "Item_Ex700";
					this.CreateItemTabCategories("ItemEx700");
					this.progressBar_Loading.Location = new Point(this.panel1.Location.X + this.panel1.Size.Width / 2 - this.progressBar_Loading.Size.Width / 2, this.panel1.Location.Y + this.panel1.Size.Height / 2 - this.progressBar_Loading.Size.Height / 2);
					this.progressBar_Loading.Visible = true;
					Form1.SendArgs argument = new Form1.SendArgs
					{
						filePath = openFileDialog.FileName
					};
					BackgroundWorker backgroundWorker = new BackgroundWorker();
					backgroundWorker.RunWorkerCompleted += this.ItemEx700bw_RunWorkerCompleted;
					backgroundWorker.DoWork += this.ItemEx700bw_DoWork;
					backgroundWorker.RunWorkerAsync(argument);
				}
				else if (array[array.Length - 1].ToLower().EndsWith(".ini"))
				{
					return;
				}
				this.toolStripLabel_FileName1.Text = "Ex700 Item.bmd File";
				this.toolStripLabel_FileName2.Text = "[" + openFileDialog.FileName + "]";
			}
		}

		// Token: 0x06000554 RID: 1364 RVA: 0x00053C1C File Offset: 0x00051E1C
		private void loadToolStripMenuItem_ItemEx700Plus_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Title = "Select the Ex700Plus Item.bmd File",
				Filter = "BMD files (*.bmd)|*.bmd|All files (*.*)|*.*"
			};
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				string[] array = openFileDialog.FileName.Split(new char[]
				{
					'\\'
				});
				if (array[array.Length - 1].ToLower().EndsWith(".bmd"))
				{
					if (!this.toolStrip_RowOptions.Enabled)
					{
						this.toolStrip_RowOptions.Enabled = true;
					}
					this.sBlockSize = 620;
					this.isLeaveOpenItemAdder = false;
					this.panel1_DisposeUnusedControls();
					this.s_LoadedFile = "Item_Ex700Plus";
					this.CreateItemTabCategories("ItemEx700Plus");
					this.progressBar_Loading.Location = new Point(this.panel1.Location.X + this.panel1.Size.Width / 2 - this.progressBar_Loading.Size.Width / 2, this.panel1.Location.Y + this.panel1.Size.Height / 2 - this.progressBar_Loading.Size.Height / 2);
					this.progressBar_Loading.Visible = true;
					Form1.SendArgs argument = new Form1.SendArgs
					{
						filePath = openFileDialog.FileName
					};
					BackgroundWorker backgroundWorker = new BackgroundWorker();
					backgroundWorker.RunWorkerCompleted += this.ItemEx700Plusbw_RunWorkerCompleted;
					backgroundWorker.DoWork += this.ItemEx700Plusbw_DoWork;
					backgroundWorker.RunWorkerAsync(argument);
				}
				else if (array[array.Length - 1].ToLower().EndsWith(".ini"))
				{
					return;
				}
				this.toolStripLabel_FileName1.Text = "Ex700Plus Item.bmd File";
				this.toolStripLabel_FileName2.Text = "[" + openFileDialog.FileName + "]";
			}
		}

		// Token: 0x06000555 RID: 1365 RVA: 0x00053E08 File Offset: 0x00052008
		private void loadToolStripMenuItem_ItemSeason8Episode1_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Title = "Select the Season 8 Episode 1 Item.bmd File",
				Filter = "BMD files (*.bmd)|*.bmd|All files (*.*)|*.*"
			};
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				string[] array = openFileDialog.FileName.Split(new char[]
				{
					'\\'
				});
				if (array[array.Length - 1].ToLower().EndsWith(".bmd"))
				{
					if (!this.toolStrip_RowOptions.Enabled)
					{
						this.toolStrip_RowOptions.Enabled = true;
					}
					this.sBlockSize = 628;
					this.isLeaveOpenItemAdder = false;
					this.panel1_DisposeUnusedControls();
					this.s_LoadedFile = "Item_Season8Episode1";
					this.CreateItemTabCategories("ItemSeason8Episode1");
					this.progressBar_Loading.Location = new Point(this.panel1.Location.X + this.panel1.Size.Width / 2 - this.progressBar_Loading.Size.Width / 2, this.panel1.Location.Y + this.panel1.Size.Height / 2 - this.progressBar_Loading.Size.Height / 2);
					this.progressBar_Loading.Visible = true;
					Form1.SendArgs argument = new Form1.SendArgs
					{
						filePath = openFileDialog.FileName
					};
					BackgroundWorker backgroundWorker = new BackgroundWorker();
					backgroundWorker.RunWorkerCompleted += this.ItemSeason8Episode1bw_RunWorkerCompleted;
					backgroundWorker.DoWork += this.ItemSeason8Episode1bw_DoWork;
					backgroundWorker.RunWorkerAsync(argument);
				}
				else if (array[array.Length - 1].ToLower().EndsWith(".ini"))
				{
					return;
				}
				this.toolStripLabel_FileName1.Text = "Season 8 Episode 1 Item.bmd File";
				this.toolStripLabel_FileName2.Text = "[" + openFileDialog.FileName + "]";
			}
		}

		// Token: 0x06000556 RID: 1366 RVA: 0x00053FF4 File Offset: 0x000521F4
		private void loadToolStripMenuItem_ITT_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Title = "Select the ItemToolTip.bmd File",
				Filter = "BMD files (*.bmd)|*.bmd|All files (*.*)|*.*"
			};
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.isLeaveOpenItemAdder = false;
				this.panel1_DisposeUnusedControls();
				this.s_LoadedFile = "ItemToolTip";
				this.CreateItemTabCategories("ITT");
				if (!this.toolStrip_RowOptions.Enabled)
				{
					this.toolStrip_RowOptions.Enabled = true;
				}
				this.sSize = 8192;
				this.sBlockSize = 124;
				this.toolStripButton_Save.Enabled = true;
				this.progressBar_Loading.Location = new Point(this.panel1.Location.X + this.panel1.Size.Width / 2 - this.progressBar_Loading.Size.Width / 2, this.panel1.Location.Y + this.panel1.Size.Height / 2 - this.progressBar_Loading.Size.Height / 2);
				this.progressBar_Loading.Visible = true;
				Form1.SendArgs argument = new Form1.SendArgs
				{
					filePath = openFileDialog.FileName
				};
				BackgroundWorker backgroundWorker = new BackgroundWorker();
				backgroundWorker.DoWork += this.ITTbw_DoWork;
				backgroundWorker.RunWorkerCompleted += this.ITTbw_RunWorkerCompleted;
				backgroundWorker.RunWorkerAsync(argument);
				openFileDialog.FileName.Split(new char[]
				{
					'\\'
				});
				this.toolStripLabel_FileName1.Text = "ItemToolTip.bmd File";
				this.toolStripLabel_FileName2.Text = "[" + openFileDialog.FileName + "]";
			}
		}

		// Token: 0x06000557 RID: 1367 RVA: 0x000541BC File Offset: 0x000523BC
		private void loadToolStripMenuItem_JOHS_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Title = "Select the JewelOfHarmonySmelt.bmd File",
				Filter = "BMD files (*.bmd)|*.bmd|All files (*.*)|*.*"
			};
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.isLeaveOpenItemAdder = false;
				this.panel1_DisposeUnusedControls();
				this.s_LoadedFile = "JewelOfHarmonySmelt";
				this.CreateItemTabCategories("JOHS");
				if (!this.toolStrip_RowOptions.Enabled)
				{
					this.toolStrip_RowOptions.Enabled = true;
				}
				this.toolStripButton_Save.Enabled = true;
				this.progressBar_Loading.Location = new Point(this.panel1.Location.X + this.panel1.Size.Width / 2 - this.progressBar_Loading.Size.Width / 2, this.panel1.Location.Y + this.panel1.Size.Height / 2 - this.progressBar_Loading.Size.Height / 2);
				this.progressBar_Loading.Visible = true;
				Form1.SendArgs argument = new Form1.SendArgs
				{
					filePath = openFileDialog.FileName
				};
				BackgroundWorker backgroundWorker = new BackgroundWorker();
				backgroundWorker.DoWork += this.JOHSbw_DoWork;
				backgroundWorker.RunWorkerCompleted += this.JOHSbw_RunWorkerCompleted;
				backgroundWorker.RunWorkerAsync(argument);
				openFileDialog.FileName.Split(new char[]
				{
					'\\'
				});
				this.toolStripLabel_FileName1.Text = "JewelOfHarmonySmelt.bmd File";
				this.toolStripLabel_FileName2.Text = "[" + openFileDialog.FileName + "]";
			}
		}

		// Token: 0x06000558 RID: 1368 RVA: 0x00054370 File Offset: 0x00052570
		private void loadToolStripMenuItem_Minimap_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Title = "Select the Minimap_WorldX.bmd File",
				Filter = "BMD files (*.bmd)|*.bmd|All files (*.*)|*.*"
			};
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				if (!this.toolStrip_RowOptions.Enabled)
				{
					this.toolStrip_RowOptions.Enabled = true;
				}
				this.isLeaveOpenItemAdder = false;
				this.panel1_DisposeUnusedControls();
				this.s_LoadedFile = "Minimap";
				this.Minimapdgv = new DataGridView();
				this.toolStripButton_Save.Enabled = true;
				this.progressBar_Loading.Location = new Point(this.panel1.Location.X + this.panel1.Size.Width / 2 - this.progressBar_Loading.Size.Width / 2, this.panel1.Location.Y + this.panel1.Size.Height / 2 - this.progressBar_Loading.Size.Height / 2);
				this.progressBar_Loading.Visible = true;
				Form1.SendArgs argument = new Form1.SendArgs
				{
					filePath = openFileDialog.FileName
				};
				BackgroundWorker backgroundWorker = new BackgroundWorker();
				backgroundWorker.RunWorkerCompleted += this.Minimapbw_RunWorkerCompleted;
				backgroundWorker.DoWork += this.Minimapbw_DoWork;
				backgroundWorker.RunWorkerAsync(argument);
				openFileDialog.FileName.Split(new char[]
				{
					'\\'
				});
				this.toolStripLabel_FileName1.Text = "Minimap_WorldX.bmd File";
				this.toolStripLabel_FileName2.Text = "[" + openFileDialog.FileName + "]";
			}
		}

		// Token: 0x06000559 RID: 1369 RVA: 0x00054524 File Offset: 0x00052724
		private void loadToolStripMenuItem_MixBMD_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Title = "Select the Mix.bmd File",
				Filter = "BMD files (*.bmd)|*.bmd|All files (*.*)|*.*"
			};
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				if (!this.toolStrip_RowOptions.Enabled)
				{
					this.toolStrip_RowOptions.Enabled = true;
				}
				this.isLeaveOpenItemAdder = false;
				this.panel1_DisposeUnusedControls();
				this.s_LoadedFile = "Mix";
				this.Mixdgv = new DataGridView();
				this.toolStripButton_Save.Enabled = true;
				this.toolStripButton_BmdItemAdder.Enabled = false;
				this.progressBar_Loading.Location = new Point(this.panel1.Location.X + this.panel1.Size.Width / 2 - this.progressBar_Loading.Size.Width / 2, this.panel1.Location.Y + this.panel1.Size.Height / 2 - this.progressBar_Loading.Size.Height / 2);
				this.progressBar_Loading.Visible = true;
				Form1.SendArgs argument = new Form1.SendArgs
				{
					filePath = openFileDialog.FileName
				};
				BackgroundWorker backgroundWorker = new BackgroundWorker();
				backgroundWorker.RunWorkerCompleted += this.Mixbw_RunWorkerCompleted;
				backgroundWorker.DoWork += this.Mixbw_DoWork;
				backgroundWorker.RunWorkerAsync(argument);
				openFileDialog.FileName.Split(new char[]
				{
					'\\'
				});
				this.toolStripLabel_FileName1.Text = "Mix.bmd File";
				this.toolStripLabel_FileName2.Text = "[" + openFileDialog.FileName + "]";
			}
		}

		// Token: 0x0600055A RID: 1370 RVA: 0x000546E4 File Offset: 0x000528E4
		private void loadToolStripMenuItem_Monster_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Title = "Select the Monster.bmd File",
				Filter = "BMD files (*.bmd)|*.bmd|All files (*.*)|*.*"
			};
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				if (!this.toolStrip_RowOptions.Enabled)
				{
					this.toolStrip_RowOptions.Enabled = true;
				}
				this.isLeaveOpenItemAdder = false;
				this.panel1_DisposeUnusedControls();
				this.s_LoadedFile = "Monster";
				this.Monsterdgv = new DataGridView();
				this.toolStripButton_Save.Enabled = true;
				this.progressBar_Loading.Location = new Point(this.panel1.Location.X + this.panel1.Size.Width / 2 - this.progressBar_Loading.Size.Width / 2, this.panel1.Location.Y + this.panel1.Size.Height / 2 - this.progressBar_Loading.Size.Height / 2);
				this.progressBar_Loading.Visible = true;
				Form1.SendArgs argument = new Form1.SendArgs
				{
					filePath = openFileDialog.FileName
				};
				BackgroundWorker backgroundWorker = new BackgroundWorker();
				backgroundWorker.RunWorkerCompleted += this.Monsterbw_RunWorkerCompleted;
				backgroundWorker.DoWork += this.Monsterbw_DoWork;
				backgroundWorker.RunWorkerAsync(argument);
				openFileDialog.FileName.Split(new char[]
				{
					'\\'
				});
				this.toolStripLabel_FileName1.Text = "Monster.bmd File";
				this.toolStripLabel_FileName2.Text = "[" + openFileDialog.FileName + "]";
			}
		}

		// Token: 0x0600055B RID: 1371 RVA: 0x00054898 File Offset: 0x00052A98
		private void loadToolStripMenuItem_MR_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Title = "Select the MoveReq File",
				Filter = "BMD files (*.bmd)|*.bmd|DAT files (*.dat)|*.dat|All files (*.*)|*.*"
			};
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				string[] array = openFileDialog.FileName.Split(new char[]
				{
					'\\'
				});
				if (array[array.Length - 1].ToLower().EndsWith(".bmd"))
				{
					if (!this.toolStrip_RowOptions.Enabled)
					{
						this.toolStrip_RowOptions.Enabled = true;
					}
					this.sBlockSize = 84;
					this.isLeaveOpenItemAdder = false;
					this.panel1_DisposeUnusedControls();
					this.s_LoadedFile = "MoveReq";
					this.MRdgv = new DataGridView();
					this.progressBar_Loading.Location = new Point(this.panel1.Location.X + this.panel1.Size.Width / 2 - this.progressBar_Loading.Size.Width / 2, this.panel1.Location.Y + this.panel1.Size.Height / 2 - this.progressBar_Loading.Size.Height / 2);
					this.progressBar_Loading.Visible = true;
					Form1.SendArgs argument = new Form1.SendArgs
					{
						filePath = openFileDialog.FileName
					};
					BackgroundWorker backgroundWorker = new BackgroundWorker();
					backgroundWorker.RunWorkerCompleted += this.MRbw_RunWorkerCompleted;
					backgroundWorker.DoWork += this.MRbw_DoWork;
					backgroundWorker.RunWorkerAsync(argument);
					this.toolStripLabel_FileName1.Text = "MoveReq.bmd File";
					this.toolStripLabel_FileName2.Text = "[" + openFileDialog.FileName + "]";
					return;
				}
				if (array[array.Length - 1].ToLower().EndsWith(".dat"))
				{
					if (!this.toolStrip_RowOptions.Enabled)
					{
						this.toolStrip_RowOptions.Enabled = true;
					}
					this.sBlockSize = 84;
					this.isLeaveOpenItemAdder = false;
					this.panel1_DisposeUnusedControls();
					this.MRdgv = new DataGridView();
					this.progressBar_Loading.Location = new Point(this.panel1.Location.X + this.panel1.Size.Width / 2 - this.progressBar_Loading.Size.Width / 2, this.panel1.Location.Y + this.panel1.Size.Height / 2 - this.progressBar_Loading.Size.Height / 2);
					this.progressBar_Loading.Visible = true;
					this.initializeMRGrid(this.MRdgv);
					this.MRdgv.CellValueChanged += this.MRdgv_CellValueChanged;
					this.ReadINIFile(openFileDialog.FileName, this.MRdgv, 84);
					this.panel1.Controls.Add(this.MRdgv);
					this.progressBar_Loading.Visible = false;
					this.MRdgv.Disposed += this.MRdgv_Disposed;
					this.MRdgv.KeyDown += this.dgvPasteEvent_KeyDown;
					this.workingDGV = this.MRdgv;
					this.workingDGV.RowsAdded += this.dgv_RowsAdded;
					this.toolStripLabel_FileName1.Text = "MoveReq.dat File";
					this.toolStripLabel_FileName2.Text = "[" + openFileDialog.FileName + "]";
				}
			}
		}

		// Token: 0x0600055C RID: 1372 RVA: 0x00054C38 File Offset: 0x00052E38
		private void loadToolStripMenuItem_NpcName700_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Title = "Select the NpcName.bmd File",
				Filter = "BMD files (*.bmd)|*.bmd|All files (*.*)|*.*"
			};
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				if (!this.toolStrip_RowOptions.Enabled)
				{
					this.toolStrip_RowOptions.Enabled = true;
				}
				this.sBlockSize = 264;
				this.isLeaveOpenItemAdder = false;
				this.panel1_DisposeUnusedControls();
				this.s_LoadedFile = "NpcName";
				this.NPCNdgv = new DataGridView();
				this.toolStripButton_Save.Enabled = true;
				this.progressBar_Loading.Location = new Point(this.panel1.Location.X + this.panel1.Size.Width / 2 - this.progressBar_Loading.Size.Width / 2, this.panel1.Location.Y + this.panel1.Size.Height / 2 - this.progressBar_Loading.Size.Height / 2);
				this.progressBar_Loading.Visible = true;
				Form1.SendArgs argument = new Form1.SendArgs
				{
					filePath = openFileDialog.FileName
				};
				BackgroundWorker backgroundWorker = new BackgroundWorker();
				backgroundWorker.RunWorkerCompleted += this.NPCNbw_RunWorkerCompleted;
				backgroundWorker.DoWork += this.NPCNbw_DoWork;
				backgroundWorker.RunWorkerAsync(argument);
				openFileDialog.FileName.Split(new char[]
				{
					'\\'
				});
				this.toolStripLabel_FileName1.Text = "Ex700 NpcName.bmd File";
				this.toolStripLabel_FileName2.Text = "[" + openFileDialog.FileName + "]";
			}
		}

		// Token: 0x0600055D RID: 1373 RVA: 0x00054DF8 File Offset: 0x00052FF8
		private void loadToolStripMenuItem_NpcNameEx700Plus_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Title = "Select the NpcName.bmd File",
				Filter = "BMD files (*.bmd)|*.bmd|All files (*.*)|*.*"
			};
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				if (!this.toolStrip_RowOptions.Enabled)
				{
					this.toolStrip_RowOptions.Enabled = true;
				}
				this.sBlockSize = 260;
				this.isLeaveOpenItemAdder = false;
				this.panel1_DisposeUnusedControls();
				this.s_LoadedFile = "NpcName_Ex700Plus";
				this.NPCNPlusdgv = new DataGridView();
				this.toolStripButton_Save.Enabled = true;
				this.progressBar_Loading.Location = new Point(this.panel1.Location.X + this.panel1.Size.Width / 2 - this.progressBar_Loading.Size.Width / 2, this.panel1.Location.Y + this.panel1.Size.Height / 2 - this.progressBar_Loading.Size.Height / 2);
				this.progressBar_Loading.Visible = true;
				Form1.SendArgs argument = new Form1.SendArgs
				{
					filePath = openFileDialog.FileName
				};
				BackgroundWorker backgroundWorker = new BackgroundWorker();
				backgroundWorker.RunWorkerCompleted += this.NPCNPlusbw_RunWorkerCompleted;
				backgroundWorker.DoWork += this.NPCNPlusbw_DoWork;
				backgroundWorker.RunWorkerAsync(argument);
				openFileDialog.FileName.Split(new char[]
				{
					'\\'
				});
				this.toolStripLabel_FileName1.Text = "Ex700Plus NpcName.bmd File";
				this.toolStripLabel_FileName2.Text = "[" + openFileDialog.FileName + "]";
			}
		}

		// Token: 0x0600055E RID: 1374 RVA: 0x00054FB8 File Offset: 0x000531B8
		private void loadToolStripMenuItem_SererListEx700_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Title = "Select the ServerList.bmd File",
				Filter = "BMD files (*.bmd)|*.bmd|All files (*.*)|*.*"
			};
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				if (!this.toolStrip_RowOptions.Enabled)
				{
					this.toolStrip_RowOptions.Enabled = true;
				}
				this.sBlockSize = 60;
				this.isLeaveOpenItemAdder = false;
				this.panel1_DisposeUnusedControls();
				this.s_LoadedFile = "ServerList_Ex700";
				this.ServerListEx700dgv = new DataGridView();
				this.toolStripButton_Save.Enabled = true;
				this.progressBar_Loading.Location = new Point(this.panel1.Location.X + this.panel1.Size.Width / 2 - this.progressBar_Loading.Size.Width / 2, this.panel1.Location.Y + this.panel1.Size.Height / 2 - this.progressBar_Loading.Size.Height / 2);
				this.progressBar_Loading.Visible = true;
				Form1.SendArgs argument = new Form1.SendArgs
				{
					filePath = openFileDialog.FileName
				};
				BackgroundWorker backgroundWorker = new BackgroundWorker();
				backgroundWorker.RunWorkerCompleted += this.ServerListEx700bw_RunWorkerCompleted;
				backgroundWorker.DoWork += this.ServerListEx700bw_DoWork;
				backgroundWorker.RunWorkerAsync(argument);
				openFileDialog.FileName.Split(new char[]
				{
					'\\'
				});
				this.toolStripLabel_FileName1.Text = "Ex700 / Plus ServerList.bmd File";
				this.toolStripLabel_FileName2.Text = "[" + openFileDialog.FileName + "]";
			}
		}

		// Token: 0x0600055F RID: 1375 RVA: 0x00055174 File Offset: 0x00053374
		private void loadToolStripMenuItem_SererListS6E3_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Title = "Select the ServerList.bmd File",
				Filter = "BMD files (*.bmd)|*.bmd|All files (*.*)|*.*"
			};
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				if (!this.toolStrip_RowOptions.Enabled)
				{
					this.toolStrip_RowOptions.Enabled = true;
				}
				this.sBlockSize = 55;
				this.isLeaveOpenItemAdder = false;
				this.panel1_DisposeUnusedControls();
				this.s_LoadedFile = "ServerList_S6E3";
				this.ServerListS6E3dgv = new DataGridView();
				this.toolStripButton_Save.Enabled = true;
				this.progressBar_Loading.Location = new Point(this.panel1.Location.X + this.panel1.Size.Width / 2 - this.progressBar_Loading.Size.Width / 2, this.panel1.Location.Y + this.panel1.Size.Height / 2 - this.progressBar_Loading.Size.Height / 2);
				this.progressBar_Loading.Visible = true;
				Form1.SendArgs argument = new Form1.SendArgs
				{
					filePath = openFileDialog.FileName
				};
				BackgroundWorker backgroundWorker = new BackgroundWorker();
				backgroundWorker.RunWorkerCompleted += this.ServerListS6E3bw_RunWorkerCompleted;
				backgroundWorker.DoWork += this.ServerListS6E3bw_DoWork;
				backgroundWorker.RunWorkerAsync(argument);
				openFileDialog.FileName.Split(new char[]
				{
					'\\'
				});
				this.toolStripLabel_FileName1.Text = "S6E3 ServerList.bmd File";
				this.toolStripLabel_FileName2.Text = "[" + openFileDialog.FileName + "]";
			}
		}

		// Token: 0x06000560 RID: 1376 RVA: 0x00055330 File Offset: 0x00053530
		private void loadToolStripMenuItem_Skill_ExS8E1BMD_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Title = "Select the Skill.bmd File",
				Filter = "BMD files (*.bmd)|*.bmd|All files (*.*)|*.*"
			};
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				if (!this.toolStrip_RowOptions.Enabled)
				{
					this.toolStrip_RowOptions.Enabled = true;
				}
				this.isLeaveOpenItemAdder = false;
				this.panel1_DisposeUnusedControls();
				this.s_LoadedFile = "Skill_ExS8E1";
				this.Skill_ExS8E1dgv = new DataGridView();
				this.toolStripButton_Save.Enabled = true;
				this.progressBar_Loading.Location = new Point(this.panel1.Location.X + this.panel1.Size.Width / 2 - this.progressBar_Loading.Size.Width / 2, this.panel1.Location.Y + this.panel1.Size.Height / 2 - this.progressBar_Loading.Size.Height / 2);
				this.progressBar_Loading.Visible = true;
				Form1.SendArgs argument = new Form1.SendArgs
				{
					filePath = openFileDialog.FileName
				};
				BackgroundWorker backgroundWorker = new BackgroundWorker();
				backgroundWorker.RunWorkerCompleted += this.Skill_ExS8E1bw_RunWorkerCompleted;
				backgroundWorker.DoWork += this.Skill_ExS8E1bw_DoWork;
				backgroundWorker.RunWorkerAsync(argument);
				openFileDialog.FileName.Split(new char[]
				{
					'\\'
				});
				this.toolStripLabel_FileName1.Text = "Ex700/2 / Season 8 Episode 1 Skill.bmd File";
				this.toolStripLabel_FileName2.Text = "[" + openFileDialog.FileName + "]";
			}
		}

		// Token: 0x06000561 RID: 1377 RVA: 0x000554E4 File Offset: 0x000536E4
		private void loadToolStripMenuItem_Skill_S6E3BMD_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Title = "Select the Skill.bmd File",
				Filter = "BMD files (*.bmd)|*.bmd|All files (*.*)|*.*"
			};
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				if (!this.toolStrip_RowOptions.Enabled)
				{
					this.toolStrip_RowOptions.Enabled = true;
				}
				this.isLeaveOpenItemAdder = false;
				this.panel1_DisposeUnusedControls();
				this.s_LoadedFile = "Skill_S6E3";
				this.Skill_S6E3dgv = new DataGridView();
				this.toolStripButton_Save.Enabled = true;
				this.progressBar_Loading.Location = new Point(this.panel1.Location.X + this.panel1.Size.Width / 2 - this.progressBar_Loading.Size.Width / 2, this.panel1.Location.Y + this.panel1.Size.Height / 2 - this.progressBar_Loading.Size.Height / 2);
				this.progressBar_Loading.Visible = true;
				Form1.SendArgs argument = new Form1.SendArgs
				{
					filePath = openFileDialog.FileName
				};
				BackgroundWorker backgroundWorker = new BackgroundWorker();
				backgroundWorker.RunWorkerCompleted += this.Skill_S6E3bw_RunWorkerCompleted;
				backgroundWorker.DoWork += this.Skill_S6E3bw_DoWork;
				backgroundWorker.RunWorkerAsync(argument);
				openFileDialog.FileName.Split(new char[]
				{
					'\\'
				});
				this.toolStripLabel_FileName1.Text = "Season 6 Episode 3 Skill.bmd File";
				this.toolStripLabel_FileName2.Text = "[" + openFileDialog.FileName + "]";
			}
		}

		// Token: 0x06000562 RID: 1378 RVA: 0x00055698 File Offset: 0x00053898
		private void loadToolStripMenuItem_SlideBMD_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Title = "Select the Slide.bmd File",
				Filter = "BMD files (*.bmd)|*.bmd|All files (*.*)|*.*"
			};
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				if (!this.toolStrip_RowOptions.Enabled)
				{
					this.toolStrip_RowOptions.Enabled = true;
				}
				this.isLeaveOpenItemAdder = false;
				this.panel1_DisposeUnusedControls();
				this.s_LoadedFile = "Slide";
				this.Slidedgv = new DataGridView();
				this.toolStripButton_Save.Enabled = true;
				this.progressBar_Loading.Location = new Point(this.panel1.Location.X + this.panel1.Size.Width / 2 - this.progressBar_Loading.Size.Width / 2, this.panel1.Location.Y + this.panel1.Size.Height / 2 - this.progressBar_Loading.Size.Height / 2);
				this.progressBar_Loading.Visible = true;
				Form1.SendArgs argument = new Form1.SendArgs
				{
					filePath = openFileDialog.FileName
				};
				BackgroundWorker backgroundWorker = new BackgroundWorker();
				backgroundWorker.RunWorkerCompleted += this.Slidebw_RunWorkerCompleted;
				backgroundWorker.DoWork += this.Slidebw_DoWork;
				backgroundWorker.RunWorkerAsync(argument);
				openFileDialog.FileName.Split(new char[]
				{
					'\\'
				});
				this.toolStripLabel_FileName1.Text = "Slide.bmd File";
				this.toolStripLabel_FileName2.Text = "[" + openFileDialog.FileName + "]";
			}
		}

		// Token: 0x06000563 RID: 1379 RVA: 0x0005584C File Offset: 0x00053A4C
		private void loadToolStripMenuItem_TextBMD_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Title = "Select the Text.bmd File",
				Filter = "BMD files (*.bmd)|*.bmd|All files (*.*)|*.*"
			};
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				if (!this.toolStrip_RowOptions.Enabled)
				{
					this.toolStrip_RowOptions.Enabled = true;
				}
				this.isLeaveOpenItemAdder = false;
				this.panel1_DisposeUnusedControls();
				this.s_LoadedFile = "Text";
				this.TEXTdgv = new DataGridView();
				this.toolStripButton_Save.Enabled = true;
				this.progressBar_Loading.Location = new Point(this.panel1.Location.X + this.panel1.Size.Width / 2 - this.progressBar_Loading.Size.Width / 2, this.panel1.Location.Y + this.panel1.Size.Height / 2 - this.progressBar_Loading.Size.Height / 2);
				this.progressBar_Loading.Visible = true;
				Form1.SendArgs argument = new Form1.SendArgs
				{
					filePath = openFileDialog.FileName
				};
				BackgroundWorker backgroundWorker = new BackgroundWorker();
				backgroundWorker.RunWorkerCompleted += this.TEXTbw_RunWorkerCompleted;
				backgroundWorker.DoWork += this.TEXTbw_DoWork;
				backgroundWorker.RunWorkerAsync(argument);
				openFileDialog.FileName.Split(new char[]
				{
					'\\'
				});
				this.toolStripLabel_FileName1.Text = "Text.bmd File";
				this.toolStripLabel_FileName2.Text = "[" + openFileDialog.FileName + "]";
			}
		}

		// Token: 0x06000564 RID: 1380 RVA: 0x00055A00 File Offset: 0x00053C00
		private void Minimap_Save()
		{
			Form1.SendArgs sendArgs = new Form1.SendArgs();
			SaveFileDialog saveFileDialog = new SaveFileDialog
			{
				AddExtension = true,
				Title = "Select a location to save the Minimap_WorldX.bmd File",
				Filter = "BMD files (*.bmd)|*.bmd|All files (*.*)|*.*"
			};
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.newFile = new byte[this.sSize * this.sBlockSize];
				this.toolStripProgressBar_Save.Visible = true;
				this.toolStripProgressBar_Save.Value = 0;
				this.toolStripProgressBar_Save.Size = new Size(base.Width - 460, 22);
				this.toolStripProgressBar_Save.Maximum = this.workingDGV.Rows.Count;
				sendArgs.filePath = saveFileDialog.FileName;
				sendArgs.fileType = "Minimap";
				this.backgroundWorker.RunWorkerAsync(sendArgs);
			}
		}

		// Token: 0x06000565 RID: 1381 RVA: 0x00055AD0 File Offset: 0x00053CD0
		private void Minimapbw_DoWork(object sender, DoWorkEventArgs e)
		{
			Form1.SendArgs sendArgs = (Form1.SendArgs)e.Argument;
			this.Minimapdgv = this.MinimapDec(sendArgs.filePath);
		}

		// Token: 0x06000566 RID: 1382 RVA: 0x00055AFC File Offset: 0x00053CFC
		private void Minimapbw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this.toolStripButton_AddRow.Enabled = false;
			this.toolStripButton_RemoveSelectedRow.Enabled = false;
			this.panel1.Controls.Add(this.Minimapdgv);
			this.progressBar_Loading.Visible = false;
			this.Minimapdgv.CellValueChanged += this.Minimapdgv_CellValueChanged;
			this.Minimapdgv.Disposed += this.Minimapdgv_Disposed;
			this.Minimapdgv.KeyDown += this.dgvPasteEvent_KeyDown;
			this.workingDGV = this.Minimapdgv;
			this.workingDGV.RowsAdded += this.dgv_RowsAdded;
		}

		// Token: 0x06000567 RID: 1383 RVA: 0x00055BAC File Offset: 0x00053DAC
		private DataGridView MinimapDec(string filePath)
		{
			DataGridView dataGridView = new DataGridView();
			this.initializeMinimapGrid(dataGridView);
			try
			{
				FileStream fileStream = new FileStream(filePath, FileMode.Open);
				this.sBlockSize = 116;
				byte[] array = new byte[fileStream.Length];
				this.sSize = ((int)fileStream.Length - 4) / this.sBlockSize;
				fileStream.Read(array, 0, array.Length);
				fileStream.Close();
				this.endBytes = new byte[49];
				Array.Copy(array, array.Length - 49, this.endBytes, 0, 49);
				for (int i = 0; i < this.sSize; i++)
				{
					byte[] array2 = new byte[this.sBlockSize];
					Array.Copy(array, i * this.sBlockSize, array2, 0, this.sBlockSize);
					this.DecBlock(ref array2, array2.Length);
					dataGridView.Rows.Add();
					dataGridView[0, i].Value = BitConverter.ToUInt32(array2, 0);
					dataGridView[1, i].Value = BitConverter.ToUInt32(array2, 4);
					dataGridView[2, i].Value = BitConverter.ToUInt32(array2, 8);
					dataGridView[3, i].Value = BitConverter.ToUInt32(array2, 12);
					char[] array3 = new char[2];
					array3[0] = ' ';
					dataGridView[4, i].Value = Encoding.GetEncoding("GB2312").GetString(array2, 16, 100).Trim(array3);
				}
			}
			catch (Exception ex)
			{
				dataGridView = new DataGridView();
				MessageBox.Show("The selected file failed to decrypt. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			return dataGridView;
		}

		// Token: 0x06000568 RID: 1384 RVA: 0x00055D68 File Offset: 0x00053F68
		private void Minimapdgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			this.Minimapdgv[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.PaleGreen;
		}

		// Token: 0x06000569 RID: 1385 RVA: 0x00055D90 File Offset: 0x00053F90
		private void Minimapdgv_Disposed(object sender, EventArgs e)
		{
			if (Application.OpenForms["Form_Search"] != null)
			{
				Application.OpenForms["Form_Search"].Close();
			}
		}

		// Token: 0x0600056A RID: 1386 RVA: 0x00055DB8 File Offset: 0x00053FB8
		private void MinimapEnc(string filePath)
		{
			List<byte> list = new List<byte>();
			List<byte> list2 = new List<byte>();
			foreach (object obj in ((IEnumerable)this.workingDGV.Rows))
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
				if (dataGridViewRow.Cells[0].Value != null)
				{
					byte[] array = new byte[this.sBlockSize];
					Array.Copy(BitConverter.GetBytes(Convert.ToUInt32(dataGridViewRow.Cells[0].Value.ToString())), 0, array, 0, 4);
					Array.Copy(BitConverter.GetBytes(Convert.ToUInt32(dataGridViewRow.Cells[1].Value.ToString())), 0, array, 4, 4);
					Array.Copy(BitConverter.GetBytes(Convert.ToUInt32(dataGridViewRow.Cells[2].Value.ToString())), 0, array, 8, 4);
					Array.Copy(BitConverter.GetBytes(Convert.ToUInt32(dataGridViewRow.Cells[3].Value.ToString())), 0, array, 12, 4);
					byte[] bytes = Encoding.GetEncoding("GB2312").GetBytes(dataGridViewRow.Cells[4].Value.ToString());
					Array.Copy(bytes, 0, array, 16, bytes.Length);
					for (int i = 0; i < array.Length; i++)
					{
						list2.Add(array[i]);
					}
					this.EncBlock(ref array, this.sBlockSize);
					for (int j = 0; j < array.Length; j++)
					{
						list.Add(array[j]);
					}
					this.backgroundWorker.ReportProgress(dataGridViewRow.Index);
				}
			}
			for (int k = 0; k < this.endBytes.Length; k++)
			{
				list.Add(this.endBytes[k]);
			}
			byte[] sourceArray = this.CalcCRC(list.ToArray(), 11201u, 0u);
			this.newFile = list.ToArray();
			Array.Copy(sourceArray, 0, this.newFile, this.newFile.Length - 4, 4);
			File.WriteAllBytes(filePath, this.newFile);
		}

		// Token: 0x0600056B RID: 1387 RVA: 0x00055FF4 File Offset: 0x000541F4
		private void Mix_Save()
		{
			Form1.SendArgs sendArgs = new Form1.SendArgs();
			SaveFileDialog saveFileDialog = new SaveFileDialog
			{
				AddExtension = true,
				Title = "Select a location to save the Mix.bmd File",
				Filter = "BMD files (*.bmd)|*.bmd|All files (*.*)|*.*"
			};
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.toolStripProgressBar_Save.Visible = true;
				this.toolStripProgressBar_Save.Value = 0;
				this.toolStripProgressBar_Save.Size = new Size(base.Width - 460, 22);
				this.toolStripProgressBar_Save.Maximum = this.workingDGV.Rows.Count - 1;
				sendArgs.filePath = saveFileDialog.FileName;
				sendArgs.fileType = "Mix";
				this.backgroundWorker.RunWorkerAsync(sendArgs);
			}
		}

		// Token: 0x0600056C RID: 1388 RVA: 0x000560AC File Offset: 0x000542AC
		private void Mixbw_DoWork(object sender, DoWorkEventArgs e)
		{
			Form1.SendArgs sendArgs = (Form1.SendArgs)e.Argument;
			this.Mixdgv = this.MixDec(sendArgs.filePath);
		}

		// Token: 0x0600056D RID: 1389 RVA: 0x000560D8 File Offset: 0x000542D8
		private void Mixbw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this.toolStripButton_AddRow.Enabled = true;
			this.toolStripButton_RemoveSelectedRow.Enabled = true;
			this.panel1.Controls.Add(this.Mixdgv);
			this.progressBar_Loading.Visible = false;
			this.Mixdgv.CellValueChanged += this.Mixdgv_CellValueChanged;
			this.Mixdgv.Disposed += this.Mixdgv_Disposed;
			this.Mixdgv.KeyDown += this.dgvPasteEvent_KeyDown;
			this.workingDGV = this.Mixdgv;
			this.workingDGV.RowsAdded += this.dgv_RowsAdded;
		}

		// Token: 0x0600056E RID: 1390 RVA: 0x00056188 File Offset: 0x00054388
		private DataGridView MixDec(string filePath)
		{
			DataGridView dataGridView = new DataGridView();
			try
			{
				this.initializeMixGrid(dataGridView);
				FileStream fileStream = new FileStream(filePath, FileMode.Open);
				byte[] array = new byte[fileStream.Length];
				fileStream.Read(array, 0, array.Length);
				fileStream.Close();
				this.startBytes = new byte[56];
				Array.Copy(array, 0, this.startBytes, 0, this.startBytes.Length);
				this.DecBlock(ref this.startBytes, this.startBytes.Length);
				int num = BitConverter.ToInt32(this.startBytes, 0);
				int num2 = BitConverter.ToInt32(this.startBytes, 4);
				int num3 = BitConverter.ToInt32(this.startBytes, 8);
				int num4 = BitConverter.ToInt32(this.startBytes, 12);
				int num5 = BitConverter.ToInt32(this.startBytes, 16);
				int num6 = BitConverter.ToInt32(this.startBytes, 20);
				int num7 = BitConverter.ToInt32(this.startBytes, 24);
				int num8 = BitConverter.ToInt32(this.startBytes, 28);
				int num9 = BitConverter.ToInt32(this.startBytes, 32);
				int num10 = BitConverter.ToInt32(this.startBytes, 36);
				int num11 = BitConverter.ToInt32(this.startBytes, 40);
				int num12 = BitConverter.ToInt32(this.startBytes, 44);
				int num13 = BitConverter.ToInt32(this.startBytes, 48);
				int num14 = BitConverter.ToInt32(this.startBytes, 52);
				this.sBlockSize = 660;
				this.sSize = (array.Length - 56) / this.sBlockSize;
				for (int i = 0; i < this.sSize; i++)
				{
					byte[] array2 = new byte[this.sBlockSize];
					Array.Copy(array, 56 + i * this.sBlockSize, array2, 0, array2.Length);
					this.DecBlock(ref array2, array2.Length);
					dataGridView.Rows.Add();
					if (i < num)
					{
						((DataGridViewComboBoxCell)dataGridView[0, i]).Value = "1";
					}
					else if (i - num < num2)
					{
						((DataGridViewComboBoxCell)dataGridView[0, i]).Value = "2";
					}
					else if (i - num - num2 < num3)
					{
						((DataGridViewComboBoxCell)dataGridView[0, i]).Value = "3";
					}
					else if (i - num - num2 - num3 < num4)
					{
						((DataGridViewComboBoxCell)dataGridView[0, i]).Value = "4";
					}
					else if (i - num - num2 - num3 - num4 < num5)
					{
						((DataGridViewComboBoxCell)dataGridView[0, i]).Value = "5";
					}
					else if (i - num - num2 - num3 - num4 - num5 < num6)
					{
						((DataGridViewComboBoxCell)dataGridView[0, i]).Value = "6";
					}
					else if (i - num - num2 - num3 - num4 - num5 - num6 < num7)
					{
						((DataGridViewComboBoxCell)dataGridView[0, i]).Value = "7";
					}
					else if (i - num - num2 - num3 - num4 - num5 - num6 - num7 < num8)
					{
						((DataGridViewComboBoxCell)dataGridView[0, i]).Value = "8";
					}
					else if (i - num - num2 - num3 - num4 - num5 - num6 - num7 - num8 < num9)
					{
						((DataGridViewComboBoxCell)dataGridView[0, i]).Value = "9";
					}
					else if (i - num - num2 - num3 - num4 - num5 - num6 - num7 - num8 - num9 < num10)
					{
						((DataGridViewComboBoxCell)dataGridView[0, i]).Value = "10";
					}
					else if (i - num - num2 - num3 - num4 - num5 - num6 - num7 - num8 - num9 - num10 < num11)
					{
						((DataGridViewComboBoxCell)dataGridView[0, i]).Value = "11";
					}
					else if (i - num - num2 - num3 - num4 - num5 - num6 - num7 - num8 - num9 - num10 - num11 < num12)
					{
						((DataGridViewComboBoxCell)dataGridView[0, i]).Value = "12";
					}
					else if (i - num - num2 - num3 - num4 - num5 - num6 - num7 - num8 - num9 - num10 - num11 - num12 < num13)
					{
						((DataGridViewComboBoxCell)dataGridView[0, i]).Value = "13";
					}
					else if (i - num - num2 - num3 - num4 - num5 - num6 - num7 - num8 - num9 - num10 - num11 - num12 - num13 < num14)
					{
						((DataGridViewComboBoxCell)dataGridView[0, i]).Value = "14";
					}
					int num15 = 0;
					for (int j = 1; j < 15; j++)
					{
						dataGridView[j, i].Value = BitConverter.ToUInt32(array2, num15);
						num15 += 4;
					}
					dataGridView[15, i].Value = BitConverter.ToUInt32(array2, num15);
					num15 += 4;
					for (int k = 16; k < 18; k++)
					{
						dataGridView[k, i].Value = BitConverter.ToUInt32(array2, num15);
						num15 += 4;
					}
					int num16 = 18;
					for (int l = 0; l < 32; l++)
					{
						dataGridView[num16, i].Value = BitConverter.ToUInt32(array2, num15);
						num15 += 4;
						num16++;
						dataGridView[num16, i].Value = BitConverter.ToUInt32(array2, num15);
						num15 += 4;
						num16++;
					}
					dataGridView[82, i].Value = BitConverter.ToUInt32(array2, num15);
					num15 += 4;
					for (int m = 83; m < 91; m++)
					{
						dataGridView[m, i].Value = array2[num15];
						num15++;
					}
					int num17 = 91;
					for (int n = 0; n < 8; n++)
					{
						for (int num18 = 0; num18 < 2; num18++)
						{
							dataGridView[num17, i].Value = BitConverter.ToUInt16(array2, num15);
							num15 += 2;
							num17++;
						}
						for (int num19 = 0; num19 < 9; num19++)
						{
							dataGridView[num17, i].Value = BitConverter.ToUInt32(array2, num15);
							num15 += 4;
							num17++;
						}
					}
					dataGridView[num17, i].Value = BitConverter.ToUInt32(array2, num15);
					num15 += 4;
				}
			}
			catch (Exception ex)
			{
				dataGridView = new DataGridView();
				MessageBox.Show("The selected file failed to decrypt. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			return dataGridView;
		}

		// Token: 0x0600056F RID: 1391 RVA: 0x00056868 File Offset: 0x00054A68
		private void Mixdgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (this.isNewRow && e.ColumnIndex == 0)
			{
				((DataGridViewComboBoxCell)this.Mixdgv[e.ColumnIndex, e.RowIndex]).Value = "1";
			}
			this.Mixdgv[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.PaleGreen;
		}

		// Token: 0x06000570 RID: 1392 RVA: 0x000568D1 File Offset: 0x00054AD1
		private void Mixdgv_Disposed(object sender, EventArgs e)
		{
			this.toolStripButton_Save.Enabled = false;
			if (Application.OpenForms["Form_Search"] != null)
			{
				Application.OpenForms["Form_Search"].Close();
			}
		}

		// Token: 0x06000571 RID: 1393 RVA: 0x00056904 File Offset: 0x00054B04
		private void MixEnc(string filePath)
		{
			List<byte> list = new List<byte>();
			List<byte> list2 = new List<byte>();
			List<byte> list3 = new List<byte>();
			List<byte> list4 = new List<byte>();
			List<byte> list5 = new List<byte>();
			List<byte> list6 = new List<byte>();
			List<byte> list7 = new List<byte>();
			List<byte> list8 = new List<byte>();
			List<byte> list9 = new List<byte>();
			List<byte> list10 = new List<byte>();
			List<byte> list11 = new List<byte>();
			List<byte> list12 = new List<byte>();
			List<byte> list13 = new List<byte>();
			List<byte> list14 = new List<byte>();
			List<byte> list15 = new List<byte>();
			byte[] array = new byte[0];
			foreach (object obj in ((IEnumerable)this.workingDGV.Rows))
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
				list = new List<byte>();
				for (int i = 1; i < 83; i++)
				{
					array = BitConverter.GetBytes(Convert.ToUInt32(dataGridViewRow.Cells[i].Value));
					for (int j = 0; j < array.Length; j++)
					{
						list.Add(array[j]);
					}
				}
				for (int k = 83; k < 91; k++)
				{
					array = BitConverter.GetBytes((short)Convert.ToByte(dataGridViewRow.Cells[k].Value));
					list.Add(array[0]);
				}
				int num = 91;
				for (int l = 0; l < 8; l++)
				{
					for (int m = 0; m < 2; m++)
					{
						array = BitConverter.GetBytes(Convert.ToUInt16(dataGridViewRow.Cells[num].Value));
						for (int n = 0; n < array.Length; n++)
						{
							list.Add(array[n]);
						}
						num++;
					}
					for (int num2 = 0; num2 < 9; num2++)
					{
						array = BitConverter.GetBytes(Convert.ToUInt32(dataGridViewRow.Cells[num].Value));
						for (int num3 = 0; num3 < array.Length; num3++)
						{
							list.Add(array[num3]);
						}
						num++;
					}
				}
				array = BitConverter.GetBytes(Convert.ToUInt32(dataGridViewRow.Cells[num].Value));
				for (int num4 = 0; num4 < array.Length; num4++)
				{
					list.Add(array[num4]);
				}
				if (((DataGridViewComboBoxCell)dataGridViewRow.Cells[0]).Value.ToString() == "1")
				{
					list2.AddRange(list);
				}
				else if (((DataGridViewComboBoxCell)dataGridViewRow.Cells[0]).Value.ToString() == "2")
				{
					list3.AddRange(list);
				}
				else if (((DataGridViewComboBoxCell)dataGridViewRow.Cells[0]).Value.ToString() == "3")
				{
					list4.AddRange(list);
				}
				else if (((DataGridViewComboBoxCell)dataGridViewRow.Cells[0]).Value.ToString() == "4")
				{
					list5.AddRange(list);
				}
				else if (((DataGridViewComboBoxCell)dataGridViewRow.Cells[0]).Value.ToString() == "5")
				{
					list6.AddRange(list);
				}
				else if (((DataGridViewComboBoxCell)dataGridViewRow.Cells[0]).Value.ToString() == "6")
				{
					list7.AddRange(list);
				}
				else if (((DataGridViewComboBoxCell)dataGridViewRow.Cells[0]).Value.ToString() == "7")
				{
					list8.AddRange(list);
				}
				else if (((DataGridViewComboBoxCell)dataGridViewRow.Cells[0]).Value.ToString() == "8")
				{
					list9.AddRange(list);
				}
				else if (((DataGridViewComboBoxCell)dataGridViewRow.Cells[0]).Value.ToString() == "9")
				{
					list10.AddRange(list);
				}
				else if (((DataGridViewComboBoxCell)dataGridViewRow.Cells[0]).Value.ToString() == "10")
				{
					list11.AddRange(list);
				}
				else if (((DataGridViewComboBoxCell)dataGridViewRow.Cells[0]).Value.ToString() == "11")
				{
					list12.AddRange(list);
				}
				else if (((DataGridViewComboBoxCell)dataGridViewRow.Cells[0]).Value.ToString() == "12")
				{
					list13.AddRange(list);
				}
				else if (((DataGridViewComboBoxCell)dataGridViewRow.Cells[0]).Value.ToString() == "13")
				{
					list14.AddRange(list);
				}
				else if (((DataGridViewComboBoxCell)dataGridViewRow.Cells[0]).Value.ToString() == "14")
				{
					list15.AddRange(list);
				}
				this.backgroundWorker.ReportProgress(this.workingDGV.Rows.IndexOf(dataGridViewRow));
			}
			byte[] array2 = new byte[56];
			Array.Copy(BitConverter.GetBytes(list2.Count / 660), 0, array2, 0, 4);
			Array.Copy(BitConverter.GetBytes(list3.Count / 660), 0, array2, 4, 4);
			Array.Copy(BitConverter.GetBytes(list4.Count / 660), 0, array2, 8, 4);
			Array.Copy(BitConverter.GetBytes(list5.Count / 660), 0, array2, 12, 4);
			Array.Copy(BitConverter.GetBytes(list6.Count / 660), 0, array2, 16, 4);
			Array.Copy(BitConverter.GetBytes(list7.Count / 660), 0, array2, 20, 4);
			Array.Copy(BitConverter.GetBytes(list8.Count / 660), 0, array2, 24, 4);
			Array.Copy(BitConverter.GetBytes(list9.Count / 660), 0, array2, 28, 4);
			Array.Copy(BitConverter.GetBytes(list10.Count / 660), 0, array2, 32, 4);
			Array.Copy(BitConverter.GetBytes(list11.Count / 660), 0, array2, 36, 4);
			Array.Copy(BitConverter.GetBytes(list12.Count / 660), 0, array2, 40, 4);
			Array.Copy(BitConverter.GetBytes(list13.Count / 660), 0, array2, 44, 4);
			Array.Copy(BitConverter.GetBytes(list14.Count / 660), 0, array2, 48, 4);
			Array.Copy(BitConverter.GetBytes(list15.Count / 660), 0, array2, 52, 4);
			this.EncBlock(ref array2, array2.Length);
			List<byte> list16 = new List<byte>();
			list16.AddRange(list2);
			list16.AddRange(list3);
			list16.AddRange(list4);
			list16.AddRange(list5);
			list16.AddRange(list6);
			list16.AddRange(list7);
			list16.AddRange(list8);
			list16.AddRange(list9);
			list16.AddRange(list10);
			list16.AddRange(list11);
			list16.AddRange(list12);
			list16.AddRange(list13);
			list16.AddRange(list14);
			list16.AddRange(list15);
			byte[] array3 = list16.ToArray();
			this.EncBlock(ref array3, array3.Length);
			this.newFile = new byte[array2.Length + array3.Length];
			Array.Copy(array2, 0, this.newFile, 0, array2.Length);
			Array.Copy(array3, 0, this.newFile, 56, array3.Length);
			File.WriteAllBytes(filePath, this.newFile);
		}

		// Token: 0x06000572 RID: 1394 RVA: 0x000570E8 File Offset: 0x000552E8
		private void Monster_Save()
		{
			Form1.SendArgs sendArgs = new Form1.SendArgs();
			SaveFileDialog saveFileDialog = new SaveFileDialog
			{
				AddExtension = true,
				Title = "Select a location to save the Monster.bmd File",
				Filter = "BMD files (*.bmd)|*.bmd|All files (*.*)|*.*"
			};
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.newFile = new byte[this.sSize * this.sBlockSize];
				this.toolStripProgressBar_Save.Visible = true;
				this.toolStripProgressBar_Save.Value = 0;
				this.toolStripProgressBar_Save.Size = new Size(base.Width - 460, 22);
				this.toolStripProgressBar_Save.Maximum = this.workingDGV.Rows.Count;
				sendArgs.filePath = saveFileDialog.FileName;
				sendArgs.fileType = "Monster";
				this.backgroundWorker.RunWorkerAsync(sendArgs);
			}
		}

		// Token: 0x06000573 RID: 1395 RVA: 0x000571B8 File Offset: 0x000553B8
		private void Monsterbw_DoWork(object sender, DoWorkEventArgs e)
		{
			Form1.SendArgs sendArgs = (Form1.SendArgs)e.Argument;
			this.Monsterdgv = this.MonsterDec(sendArgs.filePath);
		}

		// Token: 0x06000574 RID: 1396 RVA: 0x000571E4 File Offset: 0x000553E4
		private void Monsterbw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this.toolStripButton_AddRow.Enabled = true;
			this.toolStripButton_RemoveSelectedRow.Enabled = true;
			this.panel1.Controls.Add(this.Monsterdgv);
			this.progressBar_Loading.Visible = false;
			this.Monsterdgv.CellValueChanged += this.Monsterdgv_CellValueChanged;
			this.Monsterdgv.Disposed += this.Monsterdgv_Disposed;
			this.Monsterdgv.CellMouseClick += this.Monsterdgv_CellMouseClick;
			this.Monsterdgv.KeyDown += this.dgvPasteEvent_KeyDown;
			this.workingDGV = this.Monsterdgv;
			this.workingDGV.RowsAdded += this.dgv_RowsAdded;
			this.isIGCCustomBMD = true;
		}

		// Token: 0x06000575 RID: 1397 RVA: 0x000572B4 File Offset: 0x000554B4
		private DataGridView MonsterDec(string filePath)
		{
			DataGridView dataGridView = new DataGridView();
			try
			{
				this.initializeMonsterGrid(dataGridView);
				FileStream fileStream = new FileStream(filePath, FileMode.Open);
				byte[] array = new byte[fileStream.Length];
				fileStream.Read(array, 0, array.Length);
				fileStream.Close();
				this.DecIGCBlock(ref array);
				this.Model_sSize = BitConverter.ToInt32(array, 8);
				this.Monster_sSize = BitConverter.ToInt32(array, 12);
				byte[] array2 = new byte[this.Model_sBlockSize * this.Model_sSize];
				byte[] array3 = new byte[this.Monster_sBlockSize * this.Monster_sSize];
				Array.Copy(array, 16, array2, 0, array2.Length);
				Array.Copy(array, 16 + array2.Length, array3, 0, array3.Length);
				byte[] array4 = new byte[this.Model_sBlockSize];
				for (int i = 0; i < this.Model_sSize; i++)
				{
					Array.Copy(array2, i * this.Model_sBlockSize, array4, 0, this.Model_sBlockSize);
					dataGridView.Rows.Add();
					dataGridView["Model ID (1)", i].Value = BitConverter.ToUInt32(array4, 0);
					dataGridView["Model Path", i].Value = Encoding.GetEncoding("GB2312").GetString(array4, 4, 64).Replace("\0", "");
					dataGridView["Model Name", i].Value = Encoding.GetEncoding("GB2312").GetString(array4, 68, 32).Replace("\0", "");
				}
				array4 = new byte[this.Monster_sBlockSize];
				for (int j = 0; j < this.Monster_sSize; j++)
				{
					Array.Copy(array3, j * this.Monster_sBlockSize, array4, 0, this.Monster_sBlockSize);
					dataGridView["Monster ID", j].Value = BitConverter.ToUInt32(array4, 0);
					dataGridView["Monster Name", j].Value = Encoding.GetEncoding("GB2312").GetString(array4, 4, 32).Replace("\0", "");
					dataGridView["Model ID (2)", j].Value = BitConverter.ToUInt16(array4, 36);
					dataGridView["NPC?", j].Value = Convert.ToByte(array4[38]);
					dataGridView["Scale", j].Value = BitConverter.ToSingle(array4, 39);
					dataGridView["Glow Power", j].Value = BitConverter.ToSingle(array4, 43);
					float num = BitConverter.ToSingle(array4, 47);
					float num2 = BitConverter.ToSingle(array4, 51);
					float num3 = BitConverter.ToSingle(array4, 55);
					dataGridView["R Color", j].Value = Convert.ToByte(num * 255f);
					dataGridView["G Color", j].Value = Convert.ToByte(num2 * 255f);
					dataGridView["B Color", j].Value = Convert.ToByte(num3 * 255f);
				}
			}
			catch (Exception ex)
			{
				dataGridView = new DataGridView();
				MessageBox.Show("The selected file failed to decrypt. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			return dataGridView;
		}

		// Token: 0x06000576 RID: 1398 RVA: 0x00057624 File Offset: 0x00055824
		private void Monsterdgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.ColumnIndex == 11 || e.ColumnIndex == 10 || e.ColumnIndex == 9)
			{
				ColorDialog colorDialog = new ColorDialog
				{
					Color = Color.FromArgb(Convert.ToInt32(this.Monsterdgv[9, e.RowIndex].Value), Convert.ToInt32(this.Monsterdgv[10, e.RowIndex].Value), Convert.ToInt32(this.Monsterdgv[11, e.RowIndex].Value))
				};
				if (colorDialog.ShowDialog() == DialogResult.OK)
				{
					this.Monsterdgv[9, e.RowIndex].Value = colorDialog.Color.R;
					this.Monsterdgv[10, e.RowIndex].Value = colorDialog.Color.G;
					this.Monsterdgv[11, e.RowIndex].Value = colorDialog.Color.B;
				}
			}
		}

		// Token: 0x06000577 RID: 1399 RVA: 0x0005774A File Offset: 0x0005594A
		private void Monsterdgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			this.Monsterdgv[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.PaleGreen;
		}

		// Token: 0x06000578 RID: 1400 RVA: 0x00057772 File Offset: 0x00055972
		private void Monsterdgv_Disposed(object sender, EventArgs e)
		{
			this.toolStripButton_Save.Enabled = false;
			this.isIGCCustomBMD = false;
			if (Application.OpenForms["Form_Search"] != null)
			{
				Application.OpenForms["Form_Search"].Close();
			}
		}

		// Token: 0x06000579 RID: 1401 RVA: 0x000577AC File Offset: 0x000559AC
		private void MonsterEnc(string filePath)
		{
			List<byte> list = new List<byte>();
			for (int i = 0; i < 4; i++)
			{
				list.Add(byte.MaxValue);
			}
			list.Add(1);
			for (int j = 0; j < 3; j++)
			{
				list.Add(0);
			}
			byte[] bytes = BitConverter.GetBytes(this.Monsterdgv.RowCount);
			for (int k = 0; k < 2; k++)
			{
				foreach (byte item in bytes)
				{
					list.Add(item);
				}
			}
			int num = 0;
			List<byte> list2 = new List<byte>();
			List<byte> list3 = new List<byte>();
			foreach (object obj in ((IEnumerable)this.workingDGV.Rows))
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
				num++;
				if (dataGridViewRow.Cells[0].Value != null)
				{
					byte[] array2 = new byte[4];
					byte[] array3 = new byte[64];
					byte[] array4 = new byte[32];
					byte[] array5 = new byte[2];
					byte[] array6 = new byte[0];
					byte[] array7 = new byte[this.Model_sBlockSize];
					array2 = BitConverter.GetBytes(Convert.ToUInt32(dataGridViewRow.Cells[0].Value.ToString()));
					Array.Copy(array2, 0, array7, 0, array2.Length);
					array6 = Encoding.GetEncoding("GB2312").GetBytes(dataGridViewRow.Cells[1].Value.ToString());
					Array.Copy(array6, 0, array3, 0, array6.Length);
					Array.Copy(array3, 0, array7, 4, array3.Length);
					array6 = Encoding.GetEncoding("GB2312").GetBytes(dataGridViewRow.Cells[2].Value.ToString());
					Array.Copy(array6, 0, array4, 0, array6.Length);
					Array.Copy(array4, 0, array7, 68, array4.Length);
					for (int m = 0; m < array7.Length; m++)
					{
						list2.Add(array7[m]);
					}
					array7 = new byte[this.Monster_sBlockSize];
					array2 = BitConverter.GetBytes(Convert.ToUInt32(dataGridViewRow.Cells[3].Value.ToString()));
					Array.Copy(array2, 0, array7, 0, array2.Length);
					array6 = Encoding.GetEncoding("GB2312").GetBytes(dataGridViewRow.Cells[4].Value.ToString());
					Array.Copy(array6, 0, array4, 0, array6.Length);
					Array.Copy(array4, 0, array7, 4, array4.Length);
					array5 = BitConverter.GetBytes(Convert.ToUInt16(dataGridViewRow.Cells[5].Value.ToString()));
					Array.Copy(array5, 0, array7, 36, array5.Length);
					array7[38] = Convert.ToByte(dataGridViewRow.Cells[6].Value.ToString());
					array2 = BitConverter.GetBytes(Convert.ToSingle(dataGridViewRow.Cells[7].Value.ToString()));
					Array.Copy(array2, 0, array7, 39, array2.Length);
					array2 = BitConverter.GetBytes(Convert.ToSingle(dataGridViewRow.Cells[8].Value.ToString()));
					Array.Copy(array2, 0, array7, 43, array2.Length);
					float value = (float)Convert.ToInt16(dataGridViewRow.Cells[9].Value.ToString()) / 255f;
					array2 = BitConverter.GetBytes(value);
					Array.Copy(array2, 0, array7, 47, array2.Length);
					float value2 = (float)Convert.ToInt16(dataGridViewRow.Cells[10].Value.ToString()) / 255f;
					array2 = BitConverter.GetBytes(value2);
					Array.Copy(array2, 0, array7, 51, array2.Length);
					float value3 = (float)Convert.ToInt16(dataGridViewRow.Cells[11].Value.ToString()) / 255f;
					array2 = BitConverter.GetBytes(value3);
					Array.Copy(array2, 0, array7, 55, array2.Length);
					for (int n = 0; n < array7.Length; n++)
					{
						list3.Add(array7[n]);
					}
					this.backgroundWorker.ReportProgress(num);
				}
			}
			byte[] array8 = new byte[list.Count + list2.Count + list3.Count];
			list.CopyTo(0, array8, 0, list.Count);
			list2.CopyTo(0, array8, list.Count, list2.Count);
			list3.CopyTo(0, array8, list.Count + list2.Count, list3.Count);
			this.EncIGCBlock(ref array8);
			File.WriteAllBytes(filePath, array8);
		}

		// Token: 0x0600057A RID: 1402 RVA: 0x00057C78 File Offset: 0x00055E78
		private void monsterSetBaseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new MSBEditor().Show();
		}

		// Token: 0x0600057B RID: 1403 RVA: 0x00057C84 File Offset: 0x00055E84
		private void MoveReq_DAT_Export()
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog
			{
				Title = "Select a location and file Name for the generated MoveReq.dat",
				FileName = "MoveReq.dat",
				Filter = "DAT files (*.dat)|*.dat|All files (*.*)|*.*"
			};
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName)
				{
					AutoFlush = true
				};
				streamWriter.WriteLine("//Generated by MU.ToolKit coded by TopReal.IT");
				streamWriter.WriteLine("//------------------------------------------------------------------------");
				streamWriter.WriteLine("//\tIndex\tMoveName(Server)\tMoveName(Client)\tMinLvl\tMaxLvl\tZen\tGateNumber");
				streamWriter.WriteLine("//------------------------------------------------------------------------");
				streamWriter.WriteLine();
				foreach (object obj in ((IEnumerable)this.workingDGV.Rows))
				{
					DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
					if (dataGridViewRow.Cells[0].Value != null && dataGridViewRow.Cells[0].Value.ToString() != "0")
					{
						streamWriter.WriteLine("\t{0}\t\"{2}\"\t\t\"{1}\"\t\t{3}\t{4}\t{5}\t{6}", new object[]
						{
							dataGridViewRow.Cells[0].Value.ToString(),
							dataGridViewRow.Cells[1].Value.ToString(),
							dataGridViewRow.Cells[2].Value.ToString(),
							dataGridViewRow.Cells[3].Value.ToString(),
							dataGridViewRow.Cells[4].Value.ToString(),
							dataGridViewRow.Cells[5].Value.ToString(),
							dataGridViewRow.Cells[6].Value.ToString()
						});
					}
				}
				streamWriter.Close();
				if (MessageBox.Show("File generated succesfully.\nOpen?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
				{
					Process.Start(saveFileDialog.FileName);
				}
			}
		}

		// Token: 0x0600057C RID: 1404 RVA: 0x00057EA4 File Offset: 0x000560A4
		private void MoveReq_Save()
		{
			Form1.SendArgs sendArgs = new Form1.SendArgs();
			SaveFileDialog saveFileDialog = new SaveFileDialog
			{
				AddExtension = true,
				Title = "Select a location to save the MoveReq.bmd File",
				Filter = "BMD files (*.bmd)|*.bmd|All files (*.*)|*.*"
			};
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.newFile = new byte[this.sSize * this.sBlockSize + 4];
				this.toolStripProgressBar_Save.Visible = true;
				this.toolStripProgressBar_Save.Value = 0;
				this.toolStripProgressBar_Save.Size = new Size(base.Width - 460, 22);
				this.toolStripProgressBar_Save.Maximum = this.workingDGV.Rows.Count;
				sendArgs.filePath = saveFileDialog.FileName;
				sendArgs.fileType = "MoveReq";
				this.backgroundWorker.RunWorkerAsync(sendArgs);
			}
		}

		// Token: 0x0600057D RID: 1405 RVA: 0x00057F78 File Offset: 0x00056178
		private DataGridView MoveReqDec(string filePath)
		{
			DataGridView dataGridView = new DataGridView();
			this.initializeMRGrid(dataGridView);
			try
			{
				FileStream fileStream = new FileStream(filePath, FileMode.Open);
				byte[] array = new byte[fileStream.Length];
				fileStream.Read(array, 0, array.Length);
				fileStream.Close();
				this.sSize = (array.Length - 4) / this.sBlockSize;
				this.fStruct = new object[this.sSize, this.sBlockSize];
				byte[] array2 = new byte[this.sBlockSize];
				for (int i = 0; i < this.sSize; i++)
				{
					try
					{
						Array.Copy(array, i * this.sBlockSize + 4, array2, 0, this.sBlockSize);
					}
					catch
					{
						return dataGridView;
					}
					this.DecBlock(ref array2, this.sBlockSize);
					for (int j = 0; j < this.sBlockSize; j++)
					{
						this.fStruct[i, j] = array2[j];
					}
					byte[] array3 = new byte[4];
					byte[] array4 = new byte[32];
					byte[] array5 = new byte[32];
					byte[] array6 = new byte[4];
					byte[] array7 = new byte[4];
					byte[] array8 = new byte[4];
					byte[] array9 = new byte[4];
					Array.Copy(array2, 0, array3, 0, array3.Length);
					Array.Copy(array2, 4, array4, 0, array4.Length);
					Array.Copy(array2, 36, array5, 0, array5.Length);
					Array.Copy(array2, 68, array6, 0, array6.Length);
					Array.Copy(array2, 72, array7, 0, array7.Length);
					Array.Copy(array2, 76, array8, 0, array8.Length);
					Array.Copy(array2, 80, array9, 0, array9.Length);
					dataGridView.Rows.Add();
					dataGridView["Index", i].Value = BitConverter.ToUInt32(array3, 0);
					dataGridView["Client Name", i].Value = Encoding.GetEncoding("GB2312").GetString(array4).Replace("\0", "");
					dataGridView["Server Name", i].Value = Encoding.GetEncoding("GB2312").GetString(array5).Replace("\0", "");
					dataGridView["Min Level", i].Value = BitConverter.ToUInt32(array6, 0);
					dataGridView["Max Level", i].Value = BitConverter.ToUInt32(array7, 0);
					dataGridView["Required Zen", i].Value = BitConverter.ToUInt32(array8, 0);
					dataGridView["Gate Number", i].Value = BitConverter.ToUInt32(array9, 0);
				}
			}
			catch (Exception ex)
			{
				dataGridView = new DataGridView();
				MessageBox.Show("The selected file failed to decrypt. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			return dataGridView;
		}

		// Token: 0x0600057E RID: 1406 RVA: 0x00058278 File Offset: 0x00056478
		private void MoveReqEnc(string filePath)
		{
			List<byte> list = new List<byte>();
			foreach (object obj in ((IEnumerable)this.workingDGV.Rows))
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
				if (dataGridViewRow.Cells[0].Value != null)
				{
					byte[] array = new byte[this.sBlockSize];
					byte[] array2 = new byte[0];
					Array.Copy(BitConverter.GetBytes(Convert.ToUInt32(dataGridViewRow.Cells[0].Value.ToString())), 0, array, 0, 4);
					array2 = Encoding.GetEncoding("GB2312").GetBytes(dataGridViewRow.Cells[1].Value.ToString());
					Array.Copy(array2, 0, array, 4, array2.Length);
					array2 = Encoding.GetEncoding("GB2312").GetBytes(dataGridViewRow.Cells[2].Value.ToString());
					Array.Copy(array2, 0, array, 36, array2.Length);
					Array.Copy(BitConverter.GetBytes(Convert.ToUInt32(dataGridViewRow.Cells[3].Value.ToString())), 0, array, 68, 4);
					Array.Copy(BitConverter.GetBytes(Convert.ToUInt32(dataGridViewRow.Cells[4].Value.ToString())), 0, array, 72, 4);
					Array.Copy(BitConverter.GetBytes(Convert.ToUInt32(dataGridViewRow.Cells[5].Value.ToString())), 0, array, 76, 4);
					Array.Copy(BitConverter.GetBytes(Convert.ToUInt32(dataGridViewRow.Cells[6].Value.ToString())), 0, array, 80, 4);
					this.EncBlock(ref array, this.sBlockSize);
					for (int i = 0; i < array.Length; i++)
					{
						list.Add(array[i]);
					}
					this.backgroundWorker.ReportProgress(dataGridViewRow.Index);
				}
			}
			byte[] array3 = list.ToArray();
			int num = 0;
			foreach (object obj2 in ((IEnumerable)this.MRdgv.Rows))
			{
				DataGridViewRow dataGridViewRow2 = (DataGridViewRow)obj2;
				if (dataGridViewRow2.Cells[0].Value.ToString() != "0" & dataGridViewRow2.Cells[0].Value.ToString() != "")
				{
					num++;
				}
			}
			this.startBytes = BitConverter.GetBytes(Convert.ToUInt32(num));
			this.newFile = new byte[4 + array3.Length];
			Array.Copy(this.startBytes, 0, this.newFile, 0, 4);
			Array.Copy(array3, 0, this.newFile, 4, array3.Length);
			File.WriteAllBytes(filePath, this.newFile);
		}

		// Token: 0x0600057F RID: 1407 RVA: 0x00058590 File Offset: 0x00056790
		private void MRbw_DoWork(object sender, DoWorkEventArgs e)
		{
			Form1.SendArgs sendArgs = (Form1.SendArgs)e.Argument;
			this.MRdgv = this.MoveReqDec(sendArgs.filePath);
		}

		// Token: 0x06000580 RID: 1408 RVA: 0x000585BC File Offset: 0x000567BC
		private void MRbw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this.toolStripButton_AddRow.Enabled = true;
			this.toolStripButton_RemoveSelectedRow.Enabled = true;
			this.panel1.Controls.Add(this.MRdgv);
			this.progressBar_Loading.Visible = false;
			this.MRdgv.CellValueChanged += this.MRdgv_CellValueChanged;
			this.MRdgv.Disposed += this.MRdgv_Disposed;
			this.MRdgv.KeyDown += this.dgvPasteEvent_KeyDown;
			this.workingDGV = this.MRdgv;
			this.workingDGV.RowsAdded += this.dgv_RowsAdded;
		}

		// Token: 0x06000581 RID: 1409 RVA: 0x0005866B File Offset: 0x0005686B
		private void MRdgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			this.MRdgv[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.PaleGreen;
		}

		// Token: 0x06000582 RID: 1410 RVA: 0x00058693 File Offset: 0x00056893
		private void MRdgv_Disposed(object sender, EventArgs e)
		{
			if (Application.OpenForms["Form_Search"] != null)
			{
				Application.OpenForms["Form_Search"].Close();
			}
		}

		// Token: 0x06000583 RID: 1411 RVA: 0x000586BC File Offset: 0x000568BC
		private void NpcName_Save()
		{
			Form1.SendArgs sendArgs = new Form1.SendArgs();
			SaveFileDialog saveFileDialog = new SaveFileDialog
			{
				AddExtension = true,
				Title = "Select a location to save the NpcName.bmd File",
				Filter = "BMD files (*.bmd)|*.bmd|All files (*.*)|*.*"
			};
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.newFile = new byte[this.sSize * this.sBlockSize];
				this.toolStripProgressBar_Save.Visible = true;
				this.toolStripProgressBar_Save.Value = 0;
				this.toolStripProgressBar_Save.Size = new Size(base.Width - 460, 22);
				this.toolStripProgressBar_Save.Maximum = this.workingDGV.Rows.Count - 1;
				sendArgs.filePath = saveFileDialog.FileName;
				sendArgs.fileType = "NpcName";
				this.backgroundWorker.RunWorkerAsync(sendArgs);
			}
		}

		// Token: 0x06000584 RID: 1412 RVA: 0x00058790 File Offset: 0x00056990
		private DataGridView NpcNameDec(string filePath)
		{
			DataGridView dataGridView = new DataGridView();
			try
			{
				this.initializeNPCNGrid(dataGridView);
				FileStream fileStream = new FileStream(filePath, FileMode.Open);
				byte[] array = new byte[fileStream.Length];
				fileStream.Read(array, 0, array.Length);
				fileStream.Close();
				this.DecBlock(ref array, array.Length);
				this.sSize = array.Length / this.sBlockSize;
				byte[] array2 = new byte[this.sBlockSize];
				for (int i = 0; i < this.sSize; i++)
				{
					try
					{
						Array.Copy(array, i * this.sBlockSize, array2, 0, this.sBlockSize);
					}
					catch
					{
						return dataGridView;
					}
					byte[] array3 = new byte[256];
					Array.Copy(array2, 8, array3, 0, array3.Length);
					dataGridView.Rows.Add();
					dataGridView[0, i].Value = BitConverter.ToUInt32(array2, 0);
					dataGridView[1, i].Value = BitConverter.ToUInt32(array2, 4);
					dataGridView[2, i].Value = Encoding.GetEncoding("GB2312").GetString(array3).Replace("\0", "");
				}
			}
			catch (Exception ex)
			{
				dataGridView = new DataGridView();
				MessageBox.Show("The selected file failed to decrypt. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			return dataGridView;
		}

		// Token: 0x06000585 RID: 1413 RVA: 0x00058920 File Offset: 0x00056B20
		private void NpcNameEnc(string filePath)
		{
			List<byte> list = new List<byte>();
			foreach (object obj in ((IEnumerable)this.workingDGV.Rows))
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
				if (dataGridViewRow.Cells[0].Value != null)
				{
					byte[] array = new byte[this.sBlockSize];
					Array.Copy(BitConverter.GetBytes(Convert.ToUInt32(dataGridViewRow.Cells[0].Value.ToString())), 0, array, 0, 4);
					Array.Copy(BitConverter.GetBytes(Convert.ToUInt32(dataGridViewRow.Cells[1].Value.ToString())), 0, array, 4, 4);
					byte[] bytes = Encoding.GetEncoding("GB2312").GetBytes(dataGridViewRow.Cells[2].Value.ToString());
					Array.Copy(bytes, 0, array, 8, bytes.Length);
					this.EncBlock(ref array, this.sBlockSize);
					for (int i = 0; i < array.Length; i++)
					{
						list.Add(array[i]);
					}
					this.backgroundWorker.ReportProgress(dataGridViewRow.Index);
				}
			}
			this.newFile = list.ToArray();
			File.WriteAllBytes(filePath, this.newFile);
		}

		// Token: 0x06000586 RID: 1414 RVA: 0x00058A90 File Offset: 0x00056C90
		private void NpcNameEx700Plus_Save()
		{
			Form1.SendArgs sendArgs = new Form1.SendArgs();
			SaveFileDialog saveFileDialog = new SaveFileDialog
			{
				AddExtension = true,
				Title = "Select a location to save the NpcName.bmd File",
				Filter = "BMD files (*.bmd)|*.bmd|All files (*.*)|*.*"
			};
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.newFile = new byte[this.sSize * this.sBlockSize];
				this.toolStripProgressBar_Save.Visible = true;
				this.toolStripProgressBar_Save.Value = 0;
				this.toolStripProgressBar_Save.Size = new Size(base.Width - 460, 22);
				this.toolStripProgressBar_Save.Maximum = this.workingDGV.Rows.Count - 1;
				sendArgs.filePath = saveFileDialog.FileName;
				sendArgs.fileType = "NpcNameEx700Plus";
				this.backgroundWorker.RunWorkerAsync(sendArgs);
			}
		}

		// Token: 0x06000587 RID: 1415 RVA: 0x00058B64 File Offset: 0x00056D64
		private DataGridView NpcNameEx700PlusDec(string filePath)
		{
			DataGridView dataGridView = new DataGridView();
			try
			{
				this.initializeNPCNPlusGrid(dataGridView);
				FileStream fileStream = new FileStream(filePath, FileMode.Open);
				byte[] array = new byte[fileStream.Length];
				fileStream.Read(array, 0, array.Length);
				fileStream.Close();
				this.sSize = array.Length / this.sBlockSize;
				byte[] array2 = new byte[this.sBlockSize];
				for (int i = 0; i < this.sSize; i++)
				{
					try
					{
						Array.Copy(array, i * this.sBlockSize, array2, 0, this.sBlockSize);
						this.DecBlock(ref array2, array2.Length);
					}
					catch
					{
						return dataGridView;
					}
					byte[] array3 = new byte[256];
					Array.Copy(array2, 4, array3, 0, array3.Length);
					dataGridView.Rows.Add();
					dataGridView[0, i].Value = BitConverter.ToUInt16(array2, 0);
					dataGridView[1, i].Value = BitConverter.ToUInt16(array2, 2);
					dataGridView[2, i].Value = Encoding.GetEncoding("GB2312").GetString(array3).Replace("\0", "");
				}
			}
			catch (Exception ex)
			{
				dataGridView = new DataGridView();
				MessageBox.Show("The selected file failed to decrypt. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			return dataGridView;
		}

		// Token: 0x06000588 RID: 1416 RVA: 0x00058CF4 File Offset: 0x00056EF4
		private void NpcNameEx700PlusEnc(string filePath)
		{
			List<byte> list = new List<byte>();
			foreach (object obj in ((IEnumerable)this.workingDGV.Rows))
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
				if (dataGridViewRow.Cells[0].Value != null)
				{
					byte[] array = new byte[this.sBlockSize];
					Array.Copy(BitConverter.GetBytes(Convert.ToUInt16(dataGridViewRow.Cells[0].Value.ToString())), 0, array, 0, 2);
					Array.Copy(BitConverter.GetBytes(Convert.ToUInt16(dataGridViewRow.Cells[1].Value.ToString())), 0, array, 2, 2);
					byte[] bytes = Encoding.GetEncoding("GB2312").GetBytes(dataGridViewRow.Cells[2].Value.ToString());
					Array.Copy(bytes, 0, array, 4, bytes.Length);
					this.EncBlock(ref array, this.sBlockSize);
					for (int i = 0; i < array.Length; i++)
					{
						list.Add(array[i]);
					}
					this.backgroundWorker.ReportProgress(dataGridViewRow.Index);
				}
			}
			this.newFile = list.ToArray();
			File.WriteAllBytes(filePath, this.newFile);
		}

		// Token: 0x06000589 RID: 1417 RVA: 0x00058E64 File Offset: 0x00057064
		private void NPCNbw_DoWork(object sender, DoWorkEventArgs e)
		{
			Form1.SendArgs sendArgs = (Form1.SendArgs)e.Argument;
			this.NPCNdgv = this.NpcNameDec(sendArgs.filePath);
		}

		// Token: 0x0600058A RID: 1418 RVA: 0x00058E90 File Offset: 0x00057090
		private void NPCNbw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this.toolStripButton_AddRow.Enabled = true;
			this.toolStripButton_RemoveSelectedRow.Enabled = true;
			this.panel1.Controls.Add(this.NPCNdgv);
			this.progressBar_Loading.Visible = false;
			this.NPCNdgv.CellValueChanged += this.NPCNdgv_CellValueChanged;
			this.NPCNdgv.Disposed += this.NPCNdgv_Disposed;
			this.NPCNdgv.KeyDown += this.dgvPasteEvent_KeyDown;
			this.workingDGV = this.NPCNdgv;
			this.workingDGV.RowsAdded += this.dgv_RowsAdded;
		}

		// Token: 0x0600058B RID: 1419 RVA: 0x00058F3F File Offset: 0x0005713F
		private void NPCNdgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			this.NPCNdgv[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.PaleGreen;
		}

		// Token: 0x0600058C RID: 1420 RVA: 0x00058F67 File Offset: 0x00057167
		private void NPCNdgv_Disposed(object sender, EventArgs e)
		{
			this.toolStripButton_Save.Enabled = false;
			if (Application.OpenForms["Form_Search"] != null)
			{
				Application.OpenForms["Form_Search"].Close();
			}
		}

		// Token: 0x0600058D RID: 1421 RVA: 0x00058F9C File Offset: 0x0005719C
		private void NPCNPlusbw_DoWork(object sender, DoWorkEventArgs e)
		{
			Form1.SendArgs sendArgs = (Form1.SendArgs)e.Argument;
			this.NPCNPlusdgv = this.NpcNameEx700PlusDec(sendArgs.filePath);
		}

		// Token: 0x0600058E RID: 1422 RVA: 0x00058FC8 File Offset: 0x000571C8
		private void NPCNPlusbw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this.toolStripButton_AddRow.Enabled = true;
			this.toolStripButton_RemoveSelectedRow.Enabled = true;
			this.panel1.Controls.Add(this.NPCNPlusdgv);
			this.progressBar_Loading.Visible = false;
			this.NPCNPlusdgv.CellValueChanged += this.NPCNPlusdgv_CellValueChanged;
			this.NPCNPlusdgv.Disposed += this.NPCNPlusdgv_Disposed;
			this.NPCNPlusdgv.KeyDown += this.dgvPasteEvent_KeyDown;
			this.workingDGV = this.NPCNPlusdgv;
			this.workingDGV.RowsAdded += this.dgv_RowsAdded;
		}

		// Token: 0x0600058F RID: 1423 RVA: 0x00059077 File Offset: 0x00057277
		private void NPCNPlusdgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			this.NPCNPlusdgv[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.PaleGreen;
		}

		// Token: 0x06000590 RID: 1424 RVA: 0x0005909F File Offset: 0x0005729F
		private void NPCNPlusdgv_Disposed(object sender, EventArgs e)
		{
			this.toolStripButton_Save.Enabled = false;
			if (Application.OpenForms["Form_Search"] != null)
			{
				Application.OpenForms["Form_Search"].Close();
			}
		}

		// Token: 0x06000591 RID: 1425 RVA: 0x000590D4 File Offset: 0x000572D4
		private void panel1_DisposeUnusedControls()
		{
			if (this.panel1.Controls.Count != 1)
			{
				try
				{
					this.panel1.Controls[1].Dispose();
				}
				catch
				{
					this.panel1_DisposeUnusedControls();
				}
			}
		}

		// Token: 0x06000592 RID: 1426 RVA: 0x00059128 File Offset: 0x00057328
		private void panel1_SizeChanged(object sender, EventArgs e)
		{
			if (this.tc_Items != null)
			{
				this.tc_Items.Size = this.panel1.Size;
			}
		}

		// Token: 0x06000593 RID: 1427 RVA: 0x00059148 File Offset: 0x00057348
		private void ReadINIFile(string fLocation, DataGridView dgv, int BlockSize)
		{
			this.fStruct = new object[0, this.sBlockSize];
			string[] array = File.ReadAllLines(fLocation);
			int num = 0;
			foreach (string text in array)
			{
				if (text.Length != 0 && !text.StartsWith("end") && !text.StartsWith("//"))
				{
					List<int> list = new List<int>();
					int num2 = 0;
					foreach (char c in text)
					{
						if (c == '"')
						{
							list.Add(num2);
						}
						num2++;
					}
					string source = text.Replace(' ', '$');
					char[] array3 = text.ToArray<char>();
					char[] sourceArray = source.ToArray<char>();
					for (int k = 0; k <= list.Count / 2; k += 2)
					{
						Array.Copy(sourceArray, list[k], array3, list[k], list[k + 1] - list[k]);
					}
					string text3 = new string(array3);
					string[] array4 = text3.Replace(' ', '\t').Split(new char[]
					{
						'\t'
					});
					List<string> list2 = new List<string>();
					foreach (string text4 in array4)
					{
						string text5 = text4;
						if (!text5.Contains('"'))
						{
							text5 = text5.Trim(new char[]
							{
								' '
							});
						}
						else
						{
							text5 = text5.Trim(new char[]
							{
								'"'
							}).Replace('$', ' ');
						}
						if (text5.Length > 0)
						{
							list2.Add(text5);
						}
					}
					if (list2.Count != 0)
					{
						array4 = list2.ToArray();
						dgv.Rows.Add();
						dgv[0, num].Value = array4[0];
						dgv[1, num].Value = array4[1];
						dgv[2, num].Value = array4[2];
						dgv[3, num].Value = array4[3];
						dgv[4, num].Value = array4[4];
						dgv[5, num].Value = array4[5];
						dgv[6, num].Value = array4[6];
						num++;
					}
				}
			}
		}

		// Token: 0x06000594 RID: 1428 RVA: 0x000593AC File Offset: 0x000575AC
		private void ReadINIFileAsGroups(string fLocation, DataGridView dgv, int BlockSize)
		{
			string[] array = File.ReadAllLines(fLocation);
			this.fStruct = new object[8192, BlockSize];
			int num = 0;
			int num2 = 0;
			foreach (string text in array)
			{
				if (!text.StartsWith("end") && !text.StartsWith("//"))
				{
					string[] array3 = text.Split(new char[]
					{
						'\t'
					});
					List<string> list = new List<string>();
					foreach (string text2 in array3)
					{
						string text3 = text2;
						if (!text3.Contains('"'))
						{
							text3 = text3.Trim(new char[]
							{
								' '
							});
						}
						else
						{
							text3 = text3.Trim(new char[]
							{
								'"'
							});
						}
						if (text3 != "")
						{
							list.Add(text3);
						}
					}
					if (list.Count != 0)
					{
						array3 = list.ToArray();
						if (array3.Length == 1)
						{
							num2 = (int)Convert.ToInt16(array3[0]);
						}
						dgv.Rows.Add();
						int num3 = Convert.ToInt32(array3[3]);
						int num4 = num2 * 512 + num3;
						byte[] array5 = new byte[BlockSize];
						byte[] array6 = new byte[1];
						byte[] array7 = new byte[1];
						byte[] array8 = new byte[1];
						byte[] array9 = new byte[1];
						byte[] bytes = BitConverter.GetBytes(Convert.ToUInt16(num2));
						byte[] bytes2 = BitConverter.GetBytes(Convert.ToUInt16(num3));
						byte[] bytes3 = Encoding.GetEncoding("GB2312").GetBytes(array3[0].Trim(new char[]
						{
							'"'
						}));
						byte[] bytes4 = Encoding.GetEncoding("GB2312").GetBytes(array3[1].Trim(new char[]
						{
							'"'
						}));
						byte[] array10 = new byte[30];
						byte[] array11 = new byte[1];
						byte[] array12 = new byte[1];
						byte[] array13 = new byte[2];
						byte[] array14 = new byte[2];
						byte[] array15 = new byte[2];
						byte[] array16 = new byte[1];
						byte[] array17 = new byte[1];
						byte[] array18 = new byte[1];
						byte[] array19 = new byte[1];
						byte[] array20 = new byte[1];
						byte[] array21 = new byte[2];
						byte[] array22 = new byte[1];
						byte[] array23 = new byte[1];
						byte[] array24 = new byte[1];
						byte[] array25 = new byte[1];
						byte[] array26 = new byte[1];
						byte[] array27 = new byte[2];
						byte[] array28 = new byte[2];
						byte[] array29 = new byte[2];
						byte[] array30 = new byte[2];
						byte[] array31 = new byte[2];
						byte[] array32 = new byte[2];
						byte[] array33 = new byte[2];
						byte[] array34 = new byte[4];
						byte[] array35 = new byte[1];
						byte[] array36 = new byte[1];
						byte[] array37 = new byte[1];
						byte[] array38 = new byte[1];
						byte[] array39 = new byte[1];
						byte[] array40 = new byte[1];
						byte[] array41 = new byte[1];
						byte[] array42 = new byte[1];
						byte[] array43 = new byte[1];
						byte[] array44 = new byte[1];
						byte[] array45 = new byte[1];
						byte[] array46 = new byte[1];
						byte[] array47 = new byte[1];
						byte[] array48 = new byte[1];
						byte[] array49 = new byte[1];
						byte[] array50 = new byte[1];
						int num5 = 520;
						int num6 = 6;
						Array.Copy(array6, 0, array5, 0, array6.Length);
						Array.Copy(array7, 0, array5, 1, array7.Length);
						Array.Copy(array8, 0, array5, 2, array8.Length);
						Array.Copy(array9, 0, array5, 3, array9.Length);
						Array.Copy(bytes, 0, array5, 4, bytes.Length);
						Array.Copy(bytes2, 0, array5, 6, bytes2.Length);
						Array.Copy(bytes3, 0, array5, 2 + num6, bytes3.Length);
						Array.Copy(bytes4, 0, array5, 262 + num6, bytes4.Length);
						Array.Copy(array10, 0, array5, 522 + num6, array10.Length);
						Array.Copy(array11, 0, array5, 32 + num6 + num5, array11.Length);
						Array.Copy(array12, 0, array5, 33 + num6 + num5, array12.Length);
						Array.Copy(array13, 0, array5, 34 + num6 + num5, array13.Length);
						Array.Copy(array14, 0, array5, 36 + num6 + num5, array14.Length);
						Array.Copy(array15, 0, array5, 38 + num6 + num5, array15.Length);
						Array.Copy(array16, 0, array5, 40 + num6 + num5, array16.Length);
						Array.Copy(array17, 0, array5, 41 + num6 + num5, array17.Length);
						Array.Copy(array18, 0, array5, 42 + num6 + num5, array18.Length);
						Array.Copy(array19, 0, array5, 43 + num6 + num5, array19.Length);
						Array.Copy(array20, 0, array5, 44 + num6 + num5, array20.Length);
						Array.Copy(array21, 0, array5, 45 + num6 + num5, array21.Length);
						Array.Copy(array22, 0, array5, 47 + num6 + num5, array22.Length);
						Array.Copy(array23, 0, array5, 48 + num6 + num5, array23.Length);
						Array.Copy(array24, 0, array5, 49 + num6 + num5, array24.Length);
						Array.Copy(array25, 0, array5, 50 + num6 + num5, array25.Length);
						Array.Copy(array26, 0, array5, 51 + num6 + num5, array26.Length);
						Array.Copy(array27, 0, array5, 52 + num6 + num5, array27.Length);
						Array.Copy(array28, 0, array5, 54 + num6 + num5, array28.Length);
						Array.Copy(array29, 0, array5, 56 + num6 + num5, array29.Length);
						Array.Copy(array30, 0, array5, 58 + num6 + num5, array30.Length);
						Array.Copy(array31, 0, array5, 60 + num6 + num5, array31.Length);
						Array.Copy(array32, 0, array5, 62 + num6 + num5, array32.Length);
						Array.Copy(array33, 0, array5, 64 + num6 + num5, array33.Length);
						Array.Copy(array34, 0, array5, 66 + num6 + num5, array34.Length);
						Array.Copy(array35, 0, array5, 70 + num6 + num5, array35.Length);
						Array.Copy(array36, 0, array5, 71 + num6 + num5, array36.Length);
						Array.Copy(array37, 0, array5, 72 + num6 + num5, array37.Length);
						Array.Copy(array38, 0, array5, 73 + num6 + num5, array38.Length);
						Array.Copy(array39, 0, array5, 74 + num6 + num5, array39.Length);
						Array.Copy(array40, 0, array5, 75 + num6 + num5, array40.Length);
						Array.Copy(array41, 0, array5, 76 + num6 + num5, array41.Length);
						Array.Copy(array42, 0, array5, 77 + num6 + num5, array42.Length);
						Array.Copy(array43, 0, array5, 78 + num6 + num5, array43.Length);
						Array.Copy(array44, 0, array5, 79 + num6 + num5, array44.Length);
						Array.Copy(array45, 0, array5, 80 + num6 + num5, array45.Length);
						Array.Copy(array46, 0, array5, 81 + num6 + num5, array46.Length);
						Array.Copy(array47, 0, array5, 82 + num6 + num5, array47.Length);
						Array.Copy(array48, 0, array5, 83 + num6 + num5, array48.Length);
						Array.Copy(array49, 0, array5, 84 + num6 + num5, array49.Length);
						Array.Copy(array50, 0, array5, 85 + num6 + num5, array50.Length);
						for (int k = 0; k < this.sBlockSize; k++)
						{
							this.fStruct[num4, k] = array5[k];
						}
						num++;
					}
				}
			}
			this.sSize = num;
			object[,] array51 = new object[this.sSize, BlockSize];
			Array.Copy(this.fStruct, array51, array51.Length);
			this.fStruct = array51;
		}

		// Token: 0x06000595 RID: 1429 RVA: 0x00059B4C File Offset: 0x00057D4C
		private void RegTimer_Tick(object sender, EventArgs e)
		{
			((Timer)sender).Stop();
			try
			{
				this.UpdateCheck();
				StringBuilder lpBuffer = new StringBuilder(100);
				MessageBox.Show(Form1.Kernel32.GetEnvironmentVariable("WLRegFirstRun", lpBuffer, 100).ToString());
			}
			catch
			{
				Environment.Exit(0);
			}
			((Timer)sender).Start();
		}

		// Token: 0x06000596 RID: 1430 RVA: 0x00059BB4 File Offset: 0x00057DB4
		private void s6e3ItemList_ToolStripMenuItem_ON_Click(object sender, EventArgs e)
		{
			this.isEx700ItemList = false;
			this.ex700ItemList_ToolStripMenuItem_ON.Font = new Font(this.ex700ItemList_ToolStripMenuItem_ON.Font, FontStyle.Regular);
			this.s6e3ItemList_ToolStripMenuItem_ON.Font = new Font(this.s6e3ItemList_ToolStripMenuItem_ON.Font, FontStyle.Bold);
		}

		// Token: 0x06000597 RID: 1431 RVA: 0x00059C00 File Offset: 0x00057E00
		private void ServerListEx700_Save()
		{
			Form1.SendArgs sendArgs = new Form1.SendArgs();
			SaveFileDialog saveFileDialog = new SaveFileDialog
			{
				AddExtension = true,
				Title = "Select a location to save the ServerList.bmd File",
				Filter = "BMD files (*.bmd)|*.bmd|All files (*.*)|*.*"
			};
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.newFile = new byte[this.sSize * this.sBlockSize];
				this.toolStripProgressBar_Save.Visible = true;
				this.toolStripProgressBar_Save.Value = 0;
				this.toolStripProgressBar_Save.Size = new Size(base.Width - 460, 22);
				this.toolStripProgressBar_Save.Maximum = this.workingDGV.Rows.Count;
				sendArgs.filePath = saveFileDialog.FileName;
				sendArgs.fileType = "ServerListEx700";
				this.backgroundWorker.RunWorkerAsync(sendArgs);
			}
		}

		// Token: 0x06000598 RID: 1432 RVA: 0x00059CD0 File Offset: 0x00057ED0
		private void ServerListEx700bw_DoWork(object sender, DoWorkEventArgs e)
		{
			Form1.SendArgs sendArgs = (Form1.SendArgs)e.Argument;
			this.ServerListEx700dgv = this.ServerListEx700Dec(sendArgs.filePath);
		}

		// Token: 0x06000599 RID: 1433 RVA: 0x00059CFC File Offset: 0x00057EFC
		private void ServerListEx700bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this.toolStripButton_AddRow.Enabled = true;
			this.toolStripButton_RemoveSelectedRow.Enabled = true;
			this.panel1.Controls.Add(this.ServerListEx700dgv);
			this.progressBar_Loading.Visible = false;
			this.ServerListEx700dgv.CellValueChanged += this.ServerListEx700dgv_CellValueChanged;
			this.ServerListEx700dgv.Disposed += this.ServerListEx700dgv_Disposed;
			this.ServerListEx700dgv.KeyDown += this.dgvPasteEvent_KeyDown;
			this.workingDGV = this.ServerListEx700dgv;
			this.workingDGV.RowsAdded += this.dgv_RowsAdded;
		}

		// Token: 0x0600059A RID: 1434 RVA: 0x00059DAC File Offset: 0x00057FAC
		private DataGridView ServerListEx700Dec(string filePath)
		{
			DataGridView dataGridView = new DataGridView();
			this.initializeServerListEx700Grid(dataGridView);
			try
			{
				FileStream fileStream = new FileStream(filePath, FileMode.Open);
				byte[] array = new byte[fileStream.Length];
				this.sSize = (int)fileStream.Length / this.sBlockSize;
				this.fStruct = new object[this.sSize, this.sBlockSize];
				fileStream.Read(array, 0, array.Length);
				fileStream.Close();
				byte[] array2 = new byte[this.sBlockSize];
				for (int i = 0; i < this.sSize; i++)
				{
					Array.Copy(array, i * this.sBlockSize, array2, 0, this.sBlockSize);
					this.DecBlock(ref array2, array2.Length);
					byte[] array3 = new byte[2];
					byte[] array4 = new byte[32];
					byte[] array5 = new byte[1];
					byte[] array6 = new byte[1];
					byte[] array7 = new byte[1];
					byte[] array8 = new byte[1];
					byte[] array9 = new byte[1];
					byte[] array10 = new byte[1];
					byte[] array11 = new byte[1];
					byte[] array12 = new byte[1];
					byte[] array13 = new byte[1];
					byte[] array14 = new byte[1];
					byte[] array15 = new byte[1];
					byte[] array16 = new byte[1];
					byte[] array17 = new byte[1];
					byte[] array18 = new byte[1];
					byte[] array19 = new byte[1];
					byte[] array20 = new byte[1];
					byte[] array21 = new byte[1];
					byte[] array22 = new byte[1];
					byte[] array23 = new byte[1];
					byte[] array24 = new byte[1];
					byte[] array25 = new byte[1];
					byte[] array26 = new byte[1];
					byte[] array27 = new byte[1];
					byte[] array28 = new byte[1];
					byte[] array29 = new byte[1];
					Array.Copy(array2, 0, array3, 0, array3.Length);
					Array.Copy(array2, 2, array4, 0, array4.Length);
					Array.Copy(array2, 35, array5, 0, array5.Length);
					Array.Copy(array2, 36, array6, 0, array6.Length);
					Array.Copy(array2, 37, array7, 0, array7.Length);
					Array.Copy(array2, 38, array8, 0, array8.Length);
					Array.Copy(array2, 39, array9, 0, array9.Length);
					Array.Copy(array2, 40, array10, 0, array10.Length);
					Array.Copy(array2, 41, array11, 0, array11.Length);
					Array.Copy(array2, 42, array12, 0, array12.Length);
					Array.Copy(array2, 43, array13, 0, array13.Length);
					Array.Copy(array2, 44, array14, 0, array14.Length);
					Array.Copy(array2, 45, array15, 0, array15.Length);
					Array.Copy(array2, 46, array16, 0, array16.Length);
					Array.Copy(array2, 47, array17, 0, array17.Length);
					Array.Copy(array2, 48, array18, 0, array18.Length);
					Array.Copy(array2, 49, array19, 0, array19.Length);
					Array.Copy(array2, 50, array20, 0, array20.Length);
					Array.Copy(array2, 51, array21, 0, array21.Length);
					Array.Copy(array2, 52, array22, 0, array22.Length);
					Array.Copy(array2, 53, array23, 0, array23.Length);
					Array.Copy(array2, 54, array24, 0, array24.Length);
					Array.Copy(array2, 55, array25, 0, array25.Length);
					Array.Copy(array2, 56, array26, 0, array26.Length);
					Array.Copy(array2, 57, array27, 0, array27.Length);
					Array.Copy(array2, 58, array28, 0, array28.Length);
					Array.Copy(array2, 59, array29, 0, array29.Length);
					dataGridView.Rows.Add();
					dataGridView["Code", i].Value = BitConverter.ToUInt16(array3, 0);
					dataGridView["Name", i].Value = Encoding.GetEncoding("GB2312").GetString(array4).Replace('\0', ' ').Trim();
					dataGridView[2, i].Value = array5[0];
					dataGridView[3, i].Value = array6[0];
					dataGridView[4, i].Value = array7[0];
					dataGridView[5, i].Value = array8[0];
					dataGridView[6, i].Value = array9[0];
					dataGridView[7, i].Value = array10[0];
					dataGridView[8, i].Value = array11[0];
					dataGridView[9, i].Value = array12[0];
					dataGridView[10, i].Value = array13[0];
					dataGridView[11, i].Value = array14[0];
					dataGridView[12, i].Value = array15[0];
					dataGridView[13, i].Value = array16[0];
					dataGridView[14, i].Value = array17[0];
					dataGridView[15, i].Value = array18[0];
					dataGridView[16, i].Value = array19[0];
					dataGridView[17, i].Value = array20[0];
					dataGridView[18, i].Value = array21[0];
					dataGridView[19, i].Value = array22[0];
					dataGridView[20, i].Value = array23[0];
					dataGridView[21, i].Value = array24[0];
					dataGridView[22, i].Value = array25[0];
					dataGridView[23, i].Value = array26[0];
					dataGridView[24, i].Value = array27[0];
					dataGridView[25, i].Value = array28[0];
					dataGridView[26, i].Value = array29[0];
				}
			}
			catch (Exception ex)
			{
				dataGridView = new DataGridView();
				MessageBox.Show("The selected file failed to decrypt. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			return dataGridView;
		}

		// Token: 0x0600059B RID: 1435 RVA: 0x0005A3C4 File Offset: 0x000585C4
		private void ServerListEx700dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			this.ServerListEx700dgv[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.PaleGreen;
		}

		// Token: 0x0600059C RID: 1436 RVA: 0x0005A3EC File Offset: 0x000585EC
		private void ServerListEx700dgv_Disposed(object sender, EventArgs e)
		{
			if (Application.OpenForms["Form_Search"] != null)
			{
				Application.OpenForms["Form_Search"].Close();
			}
		}

		// Token: 0x0600059D RID: 1437 RVA: 0x0005A414 File Offset: 0x00058614
		private void ServerListEx700Enc(string filePath)
		{
			List<byte> list = new List<byte>();
			foreach (object obj in ((IEnumerable)this.workingDGV.Rows))
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
				if (dataGridViewRow.Cells[0].Value != null)
				{
					byte[] array = new byte[this.sBlockSize];
					Array.Copy(BitConverter.GetBytes(Convert.ToUInt16(dataGridViewRow.Cells[0].Value.ToString())), 0, array, 0, 2);
					byte[] bytes = Encoding.GetEncoding("GB2312").GetBytes(dataGridViewRow.Cells[1].Value.ToString());
					Array.Copy(bytes, 0, array, 2, bytes.Length);
					Array.Copy(BitConverter.GetBytes((short)Convert.ToByte(dataGridViewRow.Cells[2].Value.ToString())), 0, array, 35, 1);
					Array.Copy(BitConverter.GetBytes((short)Convert.ToByte(dataGridViewRow.Cells[3].Value.ToString())), 0, array, 36, 1);
					Array.Copy(BitConverter.GetBytes((short)Convert.ToByte(dataGridViewRow.Cells[4].Value.ToString())), 0, array, 37, 1);
					Array.Copy(BitConverter.GetBytes((short)Convert.ToByte(dataGridViewRow.Cells[5].Value.ToString())), 0, array, 38, 1);
					Array.Copy(BitConverter.GetBytes((short)Convert.ToByte(dataGridViewRow.Cells[6].Value.ToString())), 0, array, 39, 1);
					Array.Copy(BitConverter.GetBytes((short)Convert.ToByte(dataGridViewRow.Cells[7].Value.ToString())), 0, array, 40, 1);
					Array.Copy(BitConverter.GetBytes((short)Convert.ToByte(dataGridViewRow.Cells[8].Value.ToString())), 0, array, 41, 1);
					Array.Copy(BitConverter.GetBytes((short)Convert.ToByte(dataGridViewRow.Cells[9].Value.ToString())), 0, array, 42, 1);
					Array.Copy(BitConverter.GetBytes((short)Convert.ToByte(dataGridViewRow.Cells[10].Value.ToString())), 0, array, 43, 1);
					Array.Copy(BitConverter.GetBytes((short)Convert.ToByte(dataGridViewRow.Cells[11].Value.ToString())), 0, array, 44, 1);
					Array.Copy(BitConverter.GetBytes((short)Convert.ToByte(dataGridViewRow.Cells[12].Value.ToString())), 0, array, 45, 1);
					Array.Copy(BitConverter.GetBytes((short)Convert.ToByte(dataGridViewRow.Cells[13].Value.ToString())), 0, array, 46, 1);
					Array.Copy(BitConverter.GetBytes((short)Convert.ToByte(dataGridViewRow.Cells[14].Value.ToString())), 0, array, 47, 1);
					Array.Copy(BitConverter.GetBytes((short)Convert.ToByte(dataGridViewRow.Cells[15].Value.ToString())), 0, array, 48, 1);
					Array.Copy(BitConverter.GetBytes((short)Convert.ToByte(dataGridViewRow.Cells[16].Value.ToString())), 0, array, 49, 1);
					Array.Copy(BitConverter.GetBytes((short)Convert.ToByte(dataGridViewRow.Cells[17].Value.ToString())), 0, array, 50, 1);
					Array.Copy(BitConverter.GetBytes((short)Convert.ToByte(dataGridViewRow.Cells[18].Value.ToString())), 0, array, 51, 1);
					Array.Copy(BitConverter.GetBytes((short)Convert.ToByte(dataGridViewRow.Cells[19].Value.ToString())), 0, array, 52, 1);
					Array.Copy(BitConverter.GetBytes((short)Convert.ToByte(dataGridViewRow.Cells[20].Value.ToString())), 0, array, 53, 1);
					Array.Copy(BitConverter.GetBytes((short)Convert.ToByte(dataGridViewRow.Cells[21].Value.ToString())), 0, array, 54, 1);
					Array.Copy(BitConverter.GetBytes((short)Convert.ToByte(dataGridViewRow.Cells[22].Value.ToString())), 0, array, 55, 1);
					Array.Copy(BitConverter.GetBytes((short)Convert.ToByte(dataGridViewRow.Cells[23].Value.ToString())), 0, array, 56, 1);
					Array.Copy(BitConverter.GetBytes((short)Convert.ToByte(dataGridViewRow.Cells[24].Value.ToString())), 0, array, 57, 1);
					Array.Copy(BitConverter.GetBytes((short)Convert.ToByte(dataGridViewRow.Cells[25].Value.ToString())), 0, array, 58, 1);
					Array.Copy(BitConverter.GetBytes((short)Convert.ToByte(dataGridViewRow.Cells[26].Value.ToString())), 0, array, 59, 1);
					this.EncBlock(ref array, this.sBlockSize);
					for (int i = 0; i < array.Length; i++)
					{
						list.Add(array[i]);
					}
					this.backgroundWorker.ReportProgress(dataGridViewRow.Index);
				}
			}
			this.newFile = list.ToArray();
			File.WriteAllBytes(filePath, this.newFile);
		}

		// Token: 0x0600059E RID: 1438 RVA: 0x0005A988 File Offset: 0x00058B88
		private void ServerListS6E3_Save()
		{
			Form1.SendArgs sendArgs = new Form1.SendArgs();
			SaveFileDialog saveFileDialog = new SaveFileDialog
			{
				AddExtension = true,
				Title = "Select a location to save the ServerList.bmd File",
				Filter = "BMD files (*.bmd)|*.bmd|All files (*.*)|*.*"
			};
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.newFile = new byte[this.sSize * this.sBlockSize];
				this.toolStripProgressBar_Save.Visible = true;
				this.toolStripProgressBar_Save.Value = 0;
				this.toolStripProgressBar_Save.Size = new Size(base.Width - 460, 22);
				this.toolStripProgressBar_Save.Maximum = this.workingDGV.Rows.Count;
				sendArgs.filePath = saveFileDialog.FileName;
				sendArgs.fileType = "ServerListS6E3";
				this.backgroundWorker.RunWorkerAsync(sendArgs);
			}
		}

		// Token: 0x0600059F RID: 1439 RVA: 0x0005AA58 File Offset: 0x00058C58
		private void ServerListS6E3bw_DoWork(object sender, DoWorkEventArgs e)
		{
			Form1.SendArgs sendArgs = (Form1.SendArgs)e.Argument;
			this.ServerListS6E3dgv = this.ServerListS6E3Dec(sendArgs.filePath);
		}

		// Token: 0x060005A0 RID: 1440 RVA: 0x0005AA84 File Offset: 0x00058C84
		private void ServerListS6E3bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this.toolStripButton_AddRow.Enabled = true;
			this.toolStripButton_RemoveSelectedRow.Enabled = true;
			this.panel1.Controls.Add(this.ServerListS6E3dgv);
			this.progressBar_Loading.Visible = false;
			this.ServerListS6E3dgv.CellValueChanged += this.ServerListS6E3dgv_CellValueChanged;
			this.ServerListS6E3dgv.Disposed += this.ServerListS6E3dgv_Disposed;
			this.ServerListS6E3dgv.KeyDown += this.dgvPasteEvent_KeyDown;
			this.workingDGV = this.ServerListS6E3dgv;
			this.workingDGV.RowsAdded += this.dgv_RowsAdded;
		}

		// Token: 0x060005A1 RID: 1441 RVA: 0x0005AB34 File Offset: 0x00058D34
		private DataGridView ServerListS6E3Dec(string filePath)
		{
			DataGridView dataGridView = new DataGridView();
			this.initializeServerListS6E3Grid(dataGridView);
			try
			{
				FileStream fileStream = new FileStream(filePath, FileMode.Open);
				byte[] array = new byte[fileStream.Length];
				this.sBlockSize = 55;
				this.sSize = (int)fileStream.Length / this.sBlockSize;
				fileStream.Read(array, 0, array.Length);
				fileStream.Close();
				byte[] array2 = new byte[this.sBlockSize];
				for (int i = 0; i < this.sSize; i++)
				{
					Array.Copy(array, i * this.sBlockSize, array2, 0, this.sBlockSize);
					this.DecBlock(ref array2, array2.Length);
					byte[] array3 = new byte[2];
					byte[] array4 = new byte[32];
					byte[] array5 = new byte[1];
					byte[] array6 = new byte[1];
					byte[] array7 = new byte[1];
					byte[] array8 = new byte[1];
					byte[] array9 = new byte[1];
					byte[] array10 = new byte[1];
					byte[] array11 = new byte[1];
					byte[] array12 = new byte[1];
					byte[] array13 = new byte[1];
					byte[] array14 = new byte[1];
					byte[] array15 = new byte[1];
					byte[] array16 = new byte[1];
					byte[] array17 = new byte[1];
					byte[] array18 = new byte[1];
					byte[] array19 = new byte[1];
					byte[] array20 = new byte[1];
					byte[] array21 = new byte[1];
					byte[] array22 = new byte[1];
					byte[] array23 = new byte[1];
					byte[] array24 = new byte[1];
					Array.Copy(array2, 0, array3, 0, array3.Length);
					Array.Copy(array2, 2, array4, 0, array4.Length);
					Array.Copy(array2, 35, array5, 0, array5.Length);
					Array.Copy(array2, 36, array6, 0, array6.Length);
					Array.Copy(array2, 37, array7, 0, array7.Length);
					Array.Copy(array2, 38, array8, 0, array8.Length);
					Array.Copy(array2, 39, array9, 0, array9.Length);
					Array.Copy(array2, 40, array10, 0, array10.Length);
					Array.Copy(array2, 41, array11, 0, array11.Length);
					Array.Copy(array2, 42, array12, 0, array12.Length);
					Array.Copy(array2, 43, array13, 0, array13.Length);
					Array.Copy(array2, 44, array14, 0, array14.Length);
					Array.Copy(array2, 45, array15, 0, array15.Length);
					Array.Copy(array2, 46, array16, 0, array16.Length);
					Array.Copy(array2, 47, array17, 0, array17.Length);
					Array.Copy(array2, 48, array18, 0, array18.Length);
					Array.Copy(array2, 49, array19, 0, array19.Length);
					Array.Copy(array2, 50, array20, 0, array20.Length);
					Array.Copy(array2, 51, array21, 0, array21.Length);
					Array.Copy(array2, 52, array22, 0, array22.Length);
					Array.Copy(array2, 53, array23, 0, array23.Length);
					Array.Copy(array2, 54, array24, 0, array24.Length);
					dataGridView.Rows.Add();
					dataGridView["Code", i].Value = BitConverter.ToUInt16(array3, 0);
					dataGridView["Name", i].Value = Encoding.GetEncoding("GB2312").GetString(array4).Replace('\0', ' ').Trim();
					dataGridView[2, i].Value = array5[0];
					dataGridView[3, i].Value = array6[0];
					dataGridView[4, i].Value = array7[0];
					dataGridView[5, i].Value = array8[0];
					dataGridView[6, i].Value = array9[0];
					dataGridView[7, i].Value = array10[0];
					dataGridView[8, i].Value = array11[0];
					dataGridView[9, i].Value = array12[0];
					dataGridView[10, i].Value = array13[0];
					dataGridView[11, i].Value = array14[0];
					dataGridView[12, i].Value = array15[0];
					dataGridView[13, i].Value = array16[0];
					dataGridView[14, i].Value = array17[0];
					dataGridView[15, i].Value = array18[0];
					dataGridView[16, i].Value = array19[0];
					dataGridView[17, i].Value = array20[0];
					dataGridView[18, i].Value = array21[0];
					dataGridView[19, i].Value = array22[0];
					dataGridView[20, i].Value = array23[0];
					dataGridView[21, i].Value = array24[0];
				}
			}
			catch (Exception ex)
			{
				dataGridView = new DataGridView();
				MessageBox.Show("The selected file failed to decrypt. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			return dataGridView;
		}

		// Token: 0x060005A2 RID: 1442 RVA: 0x0005B050 File Offset: 0x00059250
		private void ServerListS6E3dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			this.ServerListS6E3dgv[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.PaleGreen;
		}

		// Token: 0x060005A3 RID: 1443 RVA: 0x0005B078 File Offset: 0x00059278
		private void ServerListS6E3dgv_Disposed(object sender, EventArgs e)
		{
			if (Application.OpenForms["Form_Search"] != null)
			{
				Application.OpenForms["Form_Search"].Close();
			}
		}

		// Token: 0x060005A4 RID: 1444 RVA: 0x0005B0A0 File Offset: 0x000592A0
		private void ServerListS6E3Enc(string filePath)
		{
			List<byte> list = new List<byte>();
			foreach (object obj in ((IEnumerable)this.workingDGV.Rows))
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
				if (dataGridViewRow.Cells[0].Value != null)
				{
					byte[] array = new byte[this.sBlockSize];
					Array.Copy(BitConverter.GetBytes(Convert.ToUInt16(dataGridViewRow.Cells[0].Value.ToString())), 0, array, 0, 2);
					byte[] bytes = Encoding.GetEncoding("GB2312").GetBytes(dataGridViewRow.Cells[1].Value.ToString());
					Array.Copy(bytes, 0, array, 2, bytes.Length);
					Array.Copy(BitConverter.GetBytes((short)Convert.ToByte(dataGridViewRow.Cells[2].Value.ToString())), 0, array, 35, 1);
					Array.Copy(BitConverter.GetBytes((short)Convert.ToByte(dataGridViewRow.Cells[3].Value.ToString())), 0, array, 36, 1);
					Array.Copy(BitConverter.GetBytes((short)Convert.ToByte(dataGridViewRow.Cells[4].Value.ToString())), 0, array, 37, 1);
					Array.Copy(BitConverter.GetBytes((short)Convert.ToByte(dataGridViewRow.Cells[5].Value.ToString())), 0, array, 38, 1);
					Array.Copy(BitConverter.GetBytes((short)Convert.ToByte(dataGridViewRow.Cells[6].Value.ToString())), 0, array, 39, 1);
					Array.Copy(BitConverter.GetBytes((short)Convert.ToByte(dataGridViewRow.Cells[7].Value.ToString())), 0, array, 40, 1);
					Array.Copy(BitConverter.GetBytes((short)Convert.ToByte(dataGridViewRow.Cells[8].Value.ToString())), 0, array, 41, 1);
					Array.Copy(BitConverter.GetBytes((short)Convert.ToByte(dataGridViewRow.Cells[9].Value.ToString())), 0, array, 42, 1);
					Array.Copy(BitConverter.GetBytes((short)Convert.ToByte(dataGridViewRow.Cells[10].Value.ToString())), 0, array, 43, 1);
					Array.Copy(BitConverter.GetBytes((short)Convert.ToByte(dataGridViewRow.Cells[11].Value.ToString())), 0, array, 44, 1);
					Array.Copy(BitConverter.GetBytes((short)Convert.ToByte(dataGridViewRow.Cells[12].Value.ToString())), 0, array, 45, 1);
					Array.Copy(BitConverter.GetBytes((short)Convert.ToByte(dataGridViewRow.Cells[13].Value.ToString())), 0, array, 46, 1);
					Array.Copy(BitConverter.GetBytes((short)Convert.ToByte(dataGridViewRow.Cells[14].Value.ToString())), 0, array, 47, 1);
					Array.Copy(BitConverter.GetBytes((short)Convert.ToByte(dataGridViewRow.Cells[15].Value.ToString())), 0, array, 48, 1);
					Array.Copy(BitConverter.GetBytes((short)Convert.ToByte(dataGridViewRow.Cells[16].Value.ToString())), 0, array, 49, 1);
					Array.Copy(BitConverter.GetBytes((short)Convert.ToByte(dataGridViewRow.Cells[17].Value.ToString())), 0, array, 50, 1);
					Array.Copy(BitConverter.GetBytes((short)Convert.ToByte(dataGridViewRow.Cells[18].Value.ToString())), 0, array, 51, 1);
					Array.Copy(BitConverter.GetBytes((short)Convert.ToByte(dataGridViewRow.Cells[19].Value.ToString())), 0, array, 52, 1);
					Array.Copy(BitConverter.GetBytes((short)Convert.ToByte(dataGridViewRow.Cells[20].Value.ToString())), 0, array, 53, 1);
					Array.Copy(BitConverter.GetBytes((short)Convert.ToByte(dataGridViewRow.Cells[21].Value.ToString())), 0, array, 54, 1);
					this.EncBlock(ref array, this.sBlockSize);
					for (int i = 0; i < array.Length; i++)
					{
						list.Add(array[i]);
					}
					this.backgroundWorker.ReportProgress(dataGridViewRow.Index);
				}
			}
			this.newFile = list.ToArray();
			File.WriteAllBytes(filePath, this.newFile);
		}

		// Token: 0x060005A5 RID: 1445 RVA: 0x0005B53C File Offset: 0x0005973C
		private void shopToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new ShopEditor().Show();
		}

		// Token: 0x060005A6 RID: 1446 RVA: 0x0005B548 File Offset: 0x00059748
		private void Skill_ExS8E1_Save()
		{
			Form1.SendArgs sendArgs = new Form1.SendArgs();
			SaveFileDialog saveFileDialog = new SaveFileDialog
			{
				AddExtension = true,
				Title = "Select a location to save the Skill.bmd File",
				Filter = "BMD files (*.bmd)|*.bmd|All files (*.*)|*.*"
			};
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.toolStripProgressBar_Save.Visible = true;
				this.toolStripProgressBar_Save.Value = 0;
				this.toolStripProgressBar_Save.Size = new Size(base.Width - 460, 22);
				this.toolStripProgressBar_Save.Maximum = this.workingDGV.Rows.Count - 1;
				sendArgs.filePath = saveFileDialog.FileName;
				sendArgs.fileType = "Skill_ExS8E1";
				this.backgroundWorker.RunWorkerAsync(sendArgs);
			}
		}

		// Token: 0x060005A7 RID: 1447 RVA: 0x0005B600 File Offset: 0x00059800
		private void Skill_ExS8E1bw_DoWork(object sender, DoWorkEventArgs e)
		{
			Form1.SendArgs sendArgs = (Form1.SendArgs)e.Argument;
			this.Skill_ExS8E1dgv = this.Skill_ExS8E1Dec(sendArgs.filePath);
		}

		// Token: 0x060005A8 RID: 1448 RVA: 0x0005B62C File Offset: 0x0005982C
		private void Skill_ExS8E1bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this.toolStripButton_AddRow.Enabled = false;
			this.toolStripButton_RemoveSelectedRow.Enabled = false;
			this.panel1.Controls.Add(this.Skill_ExS8E1dgv);
			this.progressBar_Loading.Visible = false;
			this.Skill_ExS8E1dgv.CellValueChanged += this.Skill_ExS8E1dgv_CellValueChanged;
			this.Skill_ExS8E1dgv.Disposed += this.Skill_ExS8E1dgv_Disposed;
			this.Skill_ExS8E1dgv.KeyDown += this.dgvPasteEvent_KeyDown;
			this.workingDGV = this.Skill_ExS8E1dgv;
		}

		// Token: 0x060005A9 RID: 1449 RVA: 0x0005B6C4 File Offset: 0x000598C4
		private DataGridView Skill_ExS8E1Dec(string filePath)
		{
			DataGridView dataGridView = new DataGridView();
			try
			{
				this.initializeSkill_ExS8E1Grid(dataGridView);
				FileStream fileStream = new FileStream(filePath, FileMode.Open);
				byte[] array = new byte[fileStream.Length];
				fileStream.Read(array, 0, array.Length);
				fileStream.Close();
				this.DecBlock(ref array, array.Length);
				this.sBlockSize = 96;
				this.sSize = (array.Length - 4) / this.sBlockSize;
				for (int i = 0; i < this.sSize; i++)
				{
					byte[] array2 = new byte[this.sBlockSize];
					Array.Copy(array, i * this.sBlockSize, array2, 0, array2.Length);
					dataGridView.Rows.Add();
					dataGridView[0, i].Value = Encoding.GetEncoding("GB2312").GetString(array2, 0, 32).Replace("\0", string.Empty);
					int num = 32;
					for (int j = 1; j < 5; j++)
					{
						dataGridView[j, i].Value = BitConverter.ToUInt16(array2, num);
						num += 2;
					}
					for (int k = 5; k < 8; k++)
					{
						dataGridView[k, i].Value = BitConverter.ToUInt32(array2, num);
						num += 4;
					}
					dataGridView[8, i].Value = BitConverter.ToUInt16(array2, num);
					num += 2;
					for (int l = 9; l < 51; l++)
					{
						dataGridView[l, i].Value = array2[num];
						num++;
					}
				}
			}
			catch (Exception ex)
			{
				dataGridView = new DataGridView();
				MessageBox.Show("The selected file failed to decrypt. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			return dataGridView;
		}

		// Token: 0x060005AA RID: 1450 RVA: 0x0005B8A0 File Offset: 0x00059AA0
		private void Skill_ExS8E1dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			this.Skill_ExS8E1dgv[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.PaleGreen;
		}

		// Token: 0x060005AB RID: 1451 RVA: 0x0005B8C8 File Offset: 0x00059AC8
		private void Skill_ExS8E1dgv_Disposed(object sender, EventArgs e)
		{
			this.toolStripButton_Save.Enabled = false;
			if (Application.OpenForms["Form_Search"] != null)
			{
				Application.OpenForms["Form_Search"].Close();
			}
		}

		// Token: 0x060005AC RID: 1452 RVA: 0x0005B8FC File Offset: 0x00059AFC
		private void Skill_ExS8E1Enc(string filePath)
		{
			List<byte> list = new List<byte>();
			byte[] array = new byte[0];
			foreach (object obj in ((IEnumerable)this.workingDGV.Rows))
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
				array = new byte[32];
				byte[] bytes = Encoding.GetEncoding("GB2312").GetBytes(dataGridViewRow.Cells[0].Value.ToString());
				Array.Resize<byte>(ref bytes, 32);
				Array.Copy(bytes, 0, array, 0, bytes.Length);
				for (int i = 0; i < array.Length; i++)
				{
					list.Add(array[i]);
				}
				for (int j = 1; j < 5; j++)
				{
					array = BitConverter.GetBytes(Convert.ToUInt16(dataGridViewRow.Cells[j].Value));
					for (int k = 0; k < array.Length; k++)
					{
						list.Add(array[k]);
					}
				}
				for (int l = 5; l < 8; l++)
				{
					array = BitConverter.GetBytes(Convert.ToUInt32(dataGridViewRow.Cells[l].Value));
					for (int m = 0; m < array.Length; m++)
					{
						list.Add(array[m]);
					}
				}
				array = BitConverter.GetBytes(Convert.ToUInt16(dataGridViewRow.Cells[8].Value));
				for (int n = 0; n < array.Length; n++)
				{
					list.Add(array[n]);
				}
				for (int num = 9; num < 51; num++)
				{
					array = BitConverter.GetBytes((short)Convert.ToByte(dataGridViewRow.Cells[num].Value));
					list.Add(array[0]);
				}
				this.backgroundWorker.ReportProgress(this.workingDGV.Rows.IndexOf(dataGridViewRow));
			}
			byte[] array2 = list.ToArray();
			this.EncBlock(ref array2, array2.Length);
			this.newFile = new byte[array2.Length + 4];
			Array.Copy(array2, 0, this.newFile, 0, array2.Length);
			byte[] array3 = this.CalcCRC(this.newFile, 23064u, 0u);
			Array.Copy(array3, 0, this.newFile, this.newFile.Length - 4, array3.Length);
			File.WriteAllBytes(filePath, this.newFile);
		}

		// Token: 0x060005AD RID: 1453 RVA: 0x0005BB6C File Offset: 0x00059D6C
		private void Skill_S6E3_Save()
		{
			Form1.SendArgs sendArgs = new Form1.SendArgs();
			SaveFileDialog saveFileDialog = new SaveFileDialog
			{
				AddExtension = true,
				Title = "Select a location to save the Skill.bmd File",
				Filter = "BMD files (*.bmd)|*.bmd|All files (*.*)|*.*"
			};
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.toolStripProgressBar_Save.Visible = true;
				this.toolStripProgressBar_Save.Value = 0;
				this.toolStripProgressBar_Save.Size = new Size(base.Width - 460, 22);
				this.toolStripProgressBar_Save.Maximum = this.workingDGV.Rows.Count - 1;
				sendArgs.filePath = saveFileDialog.FileName;
				sendArgs.fileType = "Skill_S6E3";
				this.backgroundWorker.RunWorkerAsync(sendArgs);
			}
		}

		// Token: 0x060005AE RID: 1454 RVA: 0x0005BC24 File Offset: 0x00059E24
		private void Skill_S6E3bw_DoWork(object sender, DoWorkEventArgs e)
		{
			Form1.SendArgs sendArgs = (Form1.SendArgs)e.Argument;
			this.Skill_S6E3dgv = this.Skill_S6E3Dec(sendArgs.filePath);
		}

		// Token: 0x060005AF RID: 1455 RVA: 0x0005BC50 File Offset: 0x00059E50
		private void Skill_S6E3bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this.toolStripButton_AddRow.Enabled = false;
			this.toolStripButton_RemoveSelectedRow.Enabled = false;
			this.panel1.Controls.Add(this.Skill_S6E3dgv);
			this.progressBar_Loading.Visible = false;
			this.Skill_S6E3dgv.CellValueChanged += this.Skill_S6E3dgv_CellValueChanged;
			this.Skill_S6E3dgv.Disposed += this.Skill_S6E3dgv_Disposed;
			this.Skill_S6E3dgv.KeyDown += this.dgvPasteEvent_KeyDown;
			this.workingDGV = this.Skill_S6E3dgv;
		}

		// Token: 0x060005B0 RID: 1456 RVA: 0x0005BCE8 File Offset: 0x00059EE8
		private DataGridView Skill_S6E3Dec(string filePath)
		{
			DataGridView dataGridView = new DataGridView();
			try
			{
				this.initializeSkill_S6E3Grid(dataGridView);
				FileStream fileStream = new FileStream(filePath, FileMode.Open);
				byte[] array = new byte[fileStream.Length];
				fileStream.Read(array, 0, array.Length);
				fileStream.Close();
				this.sBlockSize = 88;
				this.sSize = (array.Length - 4) / this.sBlockSize;
				for (int i = 0; i < this.sSize; i++)
				{
					byte[] array2 = new byte[this.sBlockSize];
					Array.Copy(array, i * this.sBlockSize, array2, 0, array2.Length);
					this.DecBlock(ref array2, array2.Length);
					dataGridView.Rows.Add();
					dataGridView[0, i].Value = Encoding.GetEncoding("GB2312").GetString(array2, 0, 32).Replace("\0", string.Empty);
					int num = 32;
					for (int j = 1; j < 5; j++)
					{
						dataGridView[j, i].Value = BitConverter.ToUInt16(array2, num);
						num += 2;
					}
					for (int k = 5; k < 8; k++)
					{
						dataGridView[k, i].Value = BitConverter.ToUInt32(array2, num);
						num += 4;
					}
					dataGridView[8, i].Value = BitConverter.ToUInt16(array2, num);
					num += 2;
					for (int l = 9; l < 43; l++)
					{
						dataGridView[l, i].Value = array2[num];
						num++;
					}
				}
			}
			catch (Exception ex)
			{
				dataGridView = new DataGridView();
				MessageBox.Show("The selected file failed to decrypt. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			return dataGridView;
		}

		// Token: 0x060005B1 RID: 1457 RVA: 0x0005BEC8 File Offset: 0x0005A0C8
		private void Skill_S6E3dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			this.Skill_S6E3dgv[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.PaleGreen;
		}

		// Token: 0x060005B2 RID: 1458 RVA: 0x0005BEF0 File Offset: 0x0005A0F0
		private void Skill_S6E3dgv_Disposed(object sender, EventArgs e)
		{
			this.toolStripButton_Save.Enabled = false;
			if (Application.OpenForms["Form_Search"] != null)
			{
				Application.OpenForms["Form_Search"].Close();
			}
		}

		// Token: 0x060005B3 RID: 1459 RVA: 0x0005BF24 File Offset: 0x0005A124
		private void Skill_S6E3Enc(string filePath)
		{
			List<byte> list = new List<byte>();
			List<byte> list2 = new List<byte>();
			byte[] array = new byte[0];
			foreach (object obj in ((IEnumerable)this.workingDGV.Rows))
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
				array = new byte[32];
				byte[] bytes = Encoding.GetEncoding("GB2312").GetBytes(dataGridViewRow.Cells[0].Value.ToString());
				Array.Resize<byte>(ref bytes, 32);
				Array.Copy(bytes, 0, array, 0, bytes.Length);
				for (int i = 0; i < array.Length; i++)
				{
					list2.Add(array[i]);
				}
				for (int j = 1; j < 5; j++)
				{
					array = BitConverter.GetBytes(Convert.ToUInt16(dataGridViewRow.Cells[j].Value));
					for (int k = 0; k < array.Length; k++)
					{
						list2.Add(array[k]);
					}
				}
				for (int l = 5; l < 8; l++)
				{
					array = BitConverter.GetBytes(Convert.ToUInt32(dataGridViewRow.Cells[l].Value));
					for (int m = 0; m < array.Length; m++)
					{
						list2.Add(array[m]);
					}
				}
				array = BitConverter.GetBytes(Convert.ToUInt16(dataGridViewRow.Cells[8].Value));
				for (int n = 0; n < array.Length; n++)
				{
					list2.Add(array[n]);
				}
				for (int num = 9; num < 43; num++)
				{
					array = BitConverter.GetBytes((short)Convert.ToByte(dataGridViewRow.Cells[num].Value));
					list2.Add(array[0]);
				}
				array = list2.ToArray();
				this.EncBlock(ref array, array.Length);
				for (int num2 = 0; num2 < array.Length; num2++)
				{
					list.Add(array[num2]);
				}
				this.backgroundWorker.ReportProgress(this.workingDGV.Rows.IndexOf(dataGridViewRow));
			}
			byte[] array2 = list.ToArray();
			this.EncBlock(ref array2, array2.Length);
			this.newFile = new byte[array2.Length + 4];
			Array.Copy(array2, 0, this.newFile, 0, array2.Length);
			byte[] array3 = this.CalcCRC(this.newFile, 23064u, 0u);
			Array.Copy(array3, 0, this.newFile, this.newFile.Length - 4, array3.Length);
			File.WriteAllBytes(filePath, this.newFile);
		}

		// Token: 0x060005B4 RID: 1460 RVA: 0x0005C1CC File Offset: 0x0005A3CC
		private void Slide_Save()
		{
			Form1.SendArgs sendArgs = new Form1.SendArgs();
			SaveFileDialog saveFileDialog = new SaveFileDialog
			{
				AddExtension = true,
				Title = "Select a location to save the Slide.bmd File",
				Filter = "BMD files (*.bmd)|*.bmd|All files (*.*)|*.*"
			};
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.toolStripProgressBar_Save.Visible = true;
				this.toolStripProgressBar_Save.Value = 0;
				this.toolStripProgressBar_Save.Size = new Size(base.Width - 460, 22);
				this.toolStripProgressBar_Save.Maximum = this.workingDGV.Rows.Count - 1;
				sendArgs.filePath = saveFileDialog.FileName;
				sendArgs.fileType = "Slide";
				this.backgroundWorker.RunWorkerAsync(sendArgs);
			}
		}

		// Token: 0x060005B5 RID: 1461 RVA: 0x0005C284 File Offset: 0x0005A484
		private void Slidebw_DoWork(object sender, DoWorkEventArgs e)
		{
			Form1.SendArgs sendArgs = (Form1.SendArgs)e.Argument;
			this.Slidedgv = this.SlideDec(sendArgs.filePath);
		}

		// Token: 0x060005B6 RID: 1462 RVA: 0x0005C2B0 File Offset: 0x0005A4B0
		private void Slidebw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this.toolStripButton_AddRow.Enabled = true;
			this.toolStripButton_RemoveSelectedRow.Enabled = true;
			this.panel1.Controls.Add(this.Slidedgv);
			this.progressBar_Loading.Visible = false;
			this.Slidedgv.CellValueChanged += this.Slidedgv_CellValueChanged;
			this.Slidedgv.Disposed += this.Slidedgv_Disposed;
			this.Slidedgv.KeyDown += this.dgvPasteEvent_KeyDown;
			this.workingDGV = this.Slidedgv;
			this.workingDGV.RowsAdded += this.dgv_RowsAdded;
		}

		// Token: 0x060005B7 RID: 1463 RVA: 0x0005C360 File Offset: 0x0005A560
		private DataGridView SlideDec(string filePath)
		{
			DataGridView dataGridView = new DataGridView();
			try
			{
				this.initializeSlideGrid(dataGridView);
				FileStream fileStream = new FileStream(filePath, FileMode.Open);
				byte[] array = new byte[fileStream.Length];
				fileStream.Read(array, 0, array.Length);
				fileStream.Close();
				this.DecBlock(ref array, array.Length);
				this.startBytes = new byte[8];
				Array.Copy(array, 0, this.startBytes, 0, this.startBytes.Length);
				this.sBlockSize = 8200;
				this.sSize = (array.Length - 8) / this.sBlockSize;
				for (int i = 0; i < this.sSize; i++)
				{
					byte[] array2 = new byte[this.sBlockSize];
					Array.Copy(array, 8 + i * this.sBlockSize, array2, 0, array2.Length);
					dataGridView.Rows.Add();
					dataGridView[0, i].Value = BitConverter.ToUInt32(array2, 0);
					dataGridView[1, i].Value = BitConverter.ToUInt32(array2, 4);
					for (int j = 0; j < 32; j++)
					{
						byte[] array3 = new byte[256];
						Array.Copy(array2, 8 + j * 256, array3, 0, array3.Length);
						dataGridView[j + 2, i].Value = Encoding.GetEncoding("GB2312").GetString(array3).Replace("\0", string.Empty);
					}
				}
			}
			catch (Exception ex)
			{
				dataGridView = new DataGridView();
				MessageBox.Show("The selected file failed to decrypt. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			return dataGridView;
		}

		// Token: 0x060005B8 RID: 1464 RVA: 0x0005C514 File Offset: 0x0005A714
		private void Slidedgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			DataGridView dataGridView = (DataGridView)sender;
			string text = string.Empty;
			if (dataGridView.EditingControl != null)
			{
				text = dataGridView.EditingControl.Text;
			}
			else
			{
				text = this.PasteValue;
			}
			if (e.ColumnIndex != 0 & e.ColumnIndex != 1)
			{
				if (text.Length > 256)
				{
					dataGridView.EditingControl.Text = text.Remove(256);
					dataGridView[e.ColumnIndex, e.RowIndex].Value = text.Remove(256);
				}
			}
			else
			{
				try
				{
					if (Convert.ToUInt32(text) > 4294967295u || Convert.ToUInt32(text) < 0u)
					{
						dataGridView.EditingControl.Text = "0";
						dataGridView[e.ColumnIndex, e.RowIndex].Value = "0";
					}
				}
				catch
				{
					dataGridView.EditingControl.Text = string.Empty;
					dataGridView[e.ColumnIndex, e.RowIndex].Value = string.Empty;
				}
			}
			this.Slidedgv[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.PaleGreen;
		}

		// Token: 0x060005B9 RID: 1465 RVA: 0x0005C658 File Offset: 0x0005A858
		private void Slidedgv_Disposed(object sender, EventArgs e)
		{
			this.toolStripButton_Save.Enabled = false;
			if (Application.OpenForms["Form_Search"] != null)
			{
				Application.OpenForms["Form_Search"].Close();
			}
		}

		// Token: 0x060005BA RID: 1466 RVA: 0x0005C68C File Offset: 0x0005A88C
		private void SlideEnc(string filePath)
		{
			List<byte> list = new List<byte>();
			for (int i = 0; i < this.startBytes.Length; i++)
			{
				list.Add(this.startBytes[i]);
			}
			foreach (object obj in ((IEnumerable)this.workingDGV.Rows))
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
				List<byte> list2 = new List<byte>();
				byte[] array = new byte[0];
				array = BitConverter.GetBytes(Convert.ToUInt32(dataGridViewRow.Cells[0].Value));
				for (int j = 0; j < array.Length; j++)
				{
					list2.Add(array[j]);
				}
				array = BitConverter.GetBytes(Convert.ToUInt32(dataGridViewRow.Cells[1].Value));
				for (int k = 0; k < array.Length; k++)
				{
					list2.Add(array[k]);
				}
				for (int l = 0; l < 32; l++)
				{
					string s = string.Empty;
					byte[] array2 = new byte[256];
					if (dataGridViewRow.Cells[l + 2].Value != null)
					{
						s = dataGridViewRow.Cells[l + 2].Value.ToString();
					}
					array = Encoding.GetEncoding("GB2312").GetBytes(s);
					Array.Copy(array, 0, array2, 0, array.Length);
					for (int m = 0; m < array2.Length; m++)
					{
						list2.Add(array2[m]);
					}
				}
				array = list2.ToArray();
				for (int n = 0; n < array.Length; n++)
				{
					list.Add(array[n]);
				}
				this.backgroundWorker.ReportProgress(this.workingDGV.Rows.IndexOf(dataGridViewRow));
			}
			this.newFile = new byte[0];
			this.newFile = list.ToArray();
			this.EncBlock(ref this.newFile, this.newFile.Length);
			File.WriteAllBytes(filePath, this.newFile);
		}

		// Token: 0x060005BB RID: 1467 RVA: 0x0005C8BC File Offset: 0x0005AABC
		public void StrToByteArray(ref byte[] OrigByt, string str)
		{
			byte[] array = new byte[str.Length];
			array = new UTF8Encoding().GetBytes(str);
			Array.Copy(array, 0, OrigByt, 0, array.Length);
		}

		// Token: 0x060005BC RID: 1468 RVA: 0x0005C8F0 File Offset: 0x0005AAF0
		private void tc_Items_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.LastSelectedItemGroup != null)
			{
				this.DisposeGrid(this.LastSelectedItemGroup);
			}
			TabControl tabControl = (TabControl)sender;
			if (tabControl.SelectedIndex != -1)
			{
				TabPage selectedTab = tabControl.SelectedTab;
				string key;
				switch (key = selectedTab.Name.Split(new char[]
				{
					'_'
				})[0])
				{
				case "ITT":
					this.InitITTGridAndAddItems((int)Convert.ToInt16(selectedTab.Name.Split(new char[]
					{
						'_'
					})[2]), selectedTab);
					break;
				case "IST":
					this.InitISTGridAndAddItems((int)Convert.ToInt16(selectedTab.Name.Split(new char[]
					{
						'_'
					})[2]), selectedTab);
					break;
				case "IAO":
					this.InitIAOGridAndAddItems((int)Convert.ToInt16(selectedTab.Name.Split(new char[]
					{
						'_'
					})[2]), selectedTab);
					break;
				case "JOHS":
					this.InitJOHSGridAndAddItems((int)Convert.ToInt16(selectedTab.Name.Split(new char[]
					{
						'_'
					})[2]), selectedTab);
					break;
				case "ItemEx700":
					this.InitItemEx700GridAndAddItems((int)Convert.ToInt16(selectedTab.Name.Split(new char[]
					{
						'_'
					})[2]), selectedTab);
					break;
				case "ItemEx700Plus":
					this.InitItemEx700PlusGridAndAddItems((int)Convert.ToInt16(selectedTab.Name.Split(new char[]
					{
						'_'
					})[2]), selectedTab);
					break;
				case "ItemSeason8Episode1":
					this.InitItemSeason8Episode1GridAndAddItems((int)Convert.ToInt16(selectedTab.Name.Split(new char[]
					{
						'_'
					})[2]), selectedTab);
					break;
				case "ItemS6E3":
					this.InitItem_S6E3GridAndAddItems((int)Convert.ToInt16(selectedTab.Name.Split(new char[]
					{
						'_'
					})[2]), selectedTab);
					break;
				}
				this.LastSelectedItemGroup = selectedTab;
				if (Application.OpenForms["Form_BmdItemAddercs"] != null)
				{
					Form_BmdItemAddercs form_BmdItemAddercs = (Form_BmdItemAddercs)Application.OpenForms["Form_BmdItemAddercs"];
					form_BmdItemAddercs.isWorkingMainForm = true;
					form_BmdItemAddercs.comboBox_ToGroup.SelectedIndex = (int)Convert.ToInt16(selectedTab.Name.Split(new char[]
					{
						'_'
					})[2]);
					form_BmdItemAddercs.isWorkingMainForm = false;
				}
			}
		}

		// Token: 0x060005BD RID: 1469 RVA: 0x0005CBD0 File Offset: 0x0005ADD0
		private void Text_Save()
		{
			Form1.SendArgs sendArgs = new Form1.SendArgs();
			SaveFileDialog saveFileDialog = new SaveFileDialog
			{
				AddExtension = true,
				Title = "Select a location to save the Text.bmd File",
				Filter = "BMD files (*.bmd)|*.bmd|All files (*.*)|*.*"
			};
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.toolStripProgressBar_Save.Visible = true;
				this.toolStripProgressBar_Save.Value = 0;
				this.toolStripProgressBar_Save.Size = new Size(base.Width - 460, 22);
				this.toolStripProgressBar_Save.Maximum = this.workingDGV.Rows.Count;
				sendArgs.filePath = saveFileDialog.FileName;
				sendArgs.fileType = "Text";
				this.backgroundWorker.RunWorkerAsync(sendArgs);
			}
		}

		// Token: 0x060005BE RID: 1470 RVA: 0x0005CC88 File Offset: 0x0005AE88
		private void TEXTbw_DoWork(object sender, DoWorkEventArgs e)
		{
			Form1.SendArgs sendArgs = (Form1.SendArgs)e.Argument;
			this.TEXTdgv = this.TEXTDec(sendArgs.filePath);
		}

		// Token: 0x060005BF RID: 1471 RVA: 0x0005CCB4 File Offset: 0x0005AEB4
		private void TEXTbw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this.toolStripButton_AddRow.Enabled = true;
			this.toolStripButton_RemoveSelectedRow.Enabled = true;
			this.panel1.Controls.Add(this.TEXTdgv);
			this.progressBar_Loading.Visible = false;
			this.TEXTdgv.CellValueChanged += this.TEXTdgv_CellValueChanged;
			this.TEXTdgv.Disposed += this.TEXTdgv_Disposed;
			this.TEXTdgv.KeyDown += this.dgvPasteEvent_KeyDown;
			this.workingDGV = this.TEXTdgv;
		}

		// Token: 0x060005C0 RID: 1472 RVA: 0x0005CD4C File Offset: 0x0005AF4C
		private DataGridView TEXTDec(string filePath)
		{
			DataGridView dataGridView = new DataGridView();
			try
			{
				this.initializeTEXTGrid(dataGridView);
				FileStream fileStream = new FileStream(filePath, FileMode.Open);
				byte[] array = new byte[fileStream.Length];
				fileStream.Read(array, 0, array.Length);
				fileStream.Close();
				this.startBytes = new byte[2];
				Array.Copy(array, 0, this.startBytes, 0, this.startBytes.Length);
				uint num = BitConverter.ToUInt32(array, 2);
				int num2 = 6;
				int num3 = 0;
				while ((long)num3 < (long)((ulong)num))
				{
					byte[] array2 = new byte[BitConverter.ToUInt32(array, num2 + 4)];
					Array.Copy(array, num2 + 8, array2, 0, array2.Length);
					this.DecBlock(ref array2, array2.Length);
					dataGridView.Rows.Add();
					dataGridView[0, num3].Value = BitConverter.ToUInt32(array, num2);
					dataGridView[1, num3].Value = BitConverter.ToUInt32(array, num2 + 4);
					dataGridView[2, num3].Value = Encoding.GetEncoding("GB2312").GetString(array2).Replace("\0", "");
					num2 = num2 + array2.Length + 8;
					num3++;
				}
			}
			catch (Exception ex)
			{
				dataGridView = new DataGridView();
				MessageBox.Show("The selected file failed to decrypt. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			return dataGridView;
		}

		// Token: 0x060005C1 RID: 1473 RVA: 0x0005CEC8 File Offset: 0x0005B0C8
		private void TEXTdgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			string text = string.Empty;
			if (this.TEXTdgv[e.ColumnIndex, e.RowIndex].Value != null)
			{
				text = this.TEXTdgv[e.ColumnIndex, e.RowIndex].Value.ToString();
			}
			if (text.Length == 0)
			{
				text = " ";
			}
			if (e.ColumnIndex == 2)
			{
				this.TEXTdgv[1, e.RowIndex].Value = text.Length;
			}
			this.TEXTdgv[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.PaleGreen;
		}

		// Token: 0x060005C2 RID: 1474 RVA: 0x0005CF7A File Offset: 0x0005B17A
		private void TEXTdgv_Disposed(object sender, EventArgs e)
		{
			this.toolStripButton_Save.Enabled = false;
			if (Application.OpenForms["Form_Search"] != null)
			{
				Application.OpenForms["Form_Search"].Close();
			}
		}

		// Token: 0x060005C3 RID: 1475 RVA: 0x0005CFB0 File Offset: 0x0005B1B0
		private void TEXTdgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
		{
			if (!this.progressBar_Loading.Visible)
			{
				DataGridView dataGridView = (DataGridView)sender;
				dataGridView[0, e.RowIndex].Value = Convert.ToUInt32(dataGridView[0, e.RowIndex - 1].Value) + 1u;
				dataGridView[1, e.RowIndex].Value = 1;
				dataGridView[2, e.RowIndex].Value = " ";
			}
		}

		// Token: 0x060005C4 RID: 1476 RVA: 0x0005D034 File Offset: 0x0005B234
		private void TEXTEnc(string filePath)
		{
			List<byte> list = new List<byte>();
			for (int i = 0; i < this.startBytes.Length; i++)
			{
				list.Add(this.startBytes[i]);
			}
			byte[] bytes = BitConverter.GetBytes(Convert.ToUInt32(this.workingDGV.Rows.Count));
			for (int j = 0; j < bytes.Length; j++)
			{
				list.Add(bytes[j]);
			}
			foreach (object obj in ((IEnumerable)this.workingDGV.Rows))
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
				byte[] array = new byte[0];
				array = BitConverter.GetBytes(Convert.ToUInt32(dataGridViewRow.Cells[0].Value));
				for (int k = 0; k < array.Length; k++)
				{
					list.Add(array[k]);
				}
				array = BitConverter.GetBytes(Convert.ToUInt32(dataGridViewRow.Cells[1].Value));
				for (int l = 0; l < array.Length; l++)
				{
					list.Add(array[l]);
				}
				array = Encoding.GetEncoding("GB2312").GetBytes(dataGridViewRow.Cells[2].Value.ToString());
				this.EncBlock(ref array, array.Length);
				for (int m = 0; m < array.Length; m++)
				{
					list.Add(array[m]);
				}
				this.backgroundWorker.ReportProgress(this.workingDGV.Rows.IndexOf(dataGridViewRow));
			}
			this.newFile = new byte[0];
			this.newFile = list.ToArray();
			File.WriteAllBytes(filePath, this.newFile);
		}

		// Token: 0x060005C5 RID: 1477 RVA: 0x0005D214 File Offset: 0x0005B414
		private void toolStripButton_AddRow_Click(object sender, EventArgs e)
		{
			if (this.s_LoadedFile != "Item_Ex700" && this.s_LoadedFile != "Item_Ex700Plus" && this.s_LoadedFile != "ItemToolTip" && this.workingDGV != null)
			{
				this.workingDGV.Rows.Add();
			}
		}

		// Token: 0x060005C6 RID: 1478 RVA: 0x0005D270 File Offset: 0x0005B470
		private void toolStripButton_BmdItemAdder_Click(object sender, EventArgs e)
		{
			if (Application.OpenForms["Form_BmdItemAddercs"] == null)
			{
				string key;
				switch (key = this.s_LoadedFile)
				{
				case "Item_S6E3":
				{
					Form form = new Form_BmdItemAddercs(0);
					form.Show(this);
					return;
				}
				case "Item_Ex700":
				{
					Form form = new Form_BmdItemAddercs(1);
					form.Show(this);
					return;
				}
				case "Item_Ex700Plus":
				{
					Form form = new Form_BmdItemAddercs(2);
					form.Show(this);
					return;
				}
				case "Item_Season8Episode1":
				{
					Form form = new Form_BmdItemAddercs(3);
					form.Show(this);
					return;
				}
				case "ItemToolTip":
				{
					Form form = new Form_BmdItemAddercs(4);
					form.Show(this);
					return;
				}
				case "ItemSetType":
				{
					Form form = new Form_BmdItemAddercs(5);
					form.Show(this);
					return;
				}
				case "ItemAddOption":
				{
					Form form = new Form_BmdItemAddercs(6);
					form.Show(this);
					return;
				}
				case "JewelOfHarmonySmelt":
					new Form_BmdItemAddercs(7).Show(this);
					return;

					return;
				}
			}
			else
			{
				Application.OpenForms["Form_BmdItemAddercs"].Focus();
			}
		}

		// Token: 0x060005C7 RID: 1479 RVA: 0x0005D3DC File Offset: 0x0005B5DC
		private void toolStripButton_Export_Click(object sender, EventArgs e)
		{
			string text = this.s_LoadedFile;
			if (text != null)
			{
				if (text == "MoveReq")
				{
					this.MoveReq_DAT_Export();
					return;
				}
				if (!(text == "Item_Ex700"))
				{
					if (text == "Item_Ex700Plus")
					{
						this.ItemEx700Plus_INI_Export();
						return;
					}
					if (text == "Item_Season8Episode1")
					{
						this.ItemSeason8Episode1_INI_Export();
						return;
					}
					if (!(text == "Item_S6E3"))
					{
						if (text == "Gate")
						{
							this.Gate_DAT_Export();
						}
						return;
					}
					this.Item_S6E3_INI_Export();
					return;
				}
				else
				{
					this.ItemEx700_INI_Export();
				}
			}
		}

		// Token: 0x060005C8 RID: 1480 RVA: 0x0005D46C File Offset: 0x0005B66C
		private void toolStripButton_Open_Click(object sender, EventArgs e)
		{
			string key;
			switch (key = this.s_LoadedFile)
			{
			case "ItemToolTip":
				this.toolStripMenuItem_ItemToolTipBMD.PerformClick();
				return;
			case "ItemAddOption":
				this.itemAddOptionbmdToolStripMenuItem.PerformClick();
				return;
			case "ItemSetType":
				this.itemSetTypebmdToolStripMenuItem.PerformClick();
				return;
			case "ItemSetOption":
				this.itemSetOptionbmdToolStripMenuItem.PerformClick();
				return;
			case "ItemToolTipText":
				this.itemToolTipTextToolStripMenuItem_Load.PerformClick();
				return;
			case "JewelOfHarmonySmelt":
				this.jewelOfHarmonySmeltbmdToolStripMenuItem.PerformClick();
				return;
			case "MoveReq":
				this.moveReqbmdEx700ToolStripMenuItem_Load.PerformClick();
				return;
			case "NpcName":
				this.ex700ToolStripMenuItem_NpcNameEx700BMD.PerformClick();
				return;
			case "NpcName_Ex700Plus":
				this.ex700ToolStripMenuItem_NpcNameEx700PlusBMD.PerformClick();
				return;
			case "Item_Ex700":
				this.ItemEx700ToolStripMenuItem_Load.PerformClick();
				return;
			case "Item_S6E3":
				this.ToolStripMenuItem_ItemS6E3_Load.PerformClick();
				return;
			case "Item_Ex700Plus":
				this.ItemEx700PlusToolStripMenuItem_Load.PerformClick();
				return;
			case "Item_Season8Episode1":
				this.season8Episode1ToolStripMenuItem.PerformClick();
				return;
			case "ServerList_Ex700":
				this.ex700ToolStripMenuItem_ServerListBMD.PerformClick();
				return;
			case "ServerList_S6E3":
				this.ToolStripMenuItem_ServerList_S6E3.PerformClick();
				return;
			case "Monster":
				this.monsterbmdToolStripMenuItem_Load.PerformClick();
				return;
			case "Glow":
				this.glowbmdToolStripMenuItem_Load.PerformClick();
				return;
			case "Text":
				this.textbmdToolStripMenuItem_Load.PerformClick();
				return;
			case "Slide":
				this.slidebmdToolStripMenuItem_Load.PerformClick();
				return;
			case "Skill_ExS8E1":
				this.skillbmdToolStripMenuItem_ExS8E1_Load.PerformClick();
				return;
			case "Skill_S6E3":
				this.skillbmdToolStripMenuItem_S6E3_Load.PerformClick();
				return;
			case "Mix":
				this.mixToolStripMenuItem_Load.PerformClick();
				return;
			case "Filter":
				this.filterbmdToolStripMenuItem_Load.PerformClick();
				return;
			case "FilterName":
				this.filterNamebmdToolStripMenuItem_Load.PerformClick();
				return;
			case "Minimap":
				this.minimapWorldXbmdToolStripMenuItem_Load.PerformClick();
				return;
			case "Gate":
				this.gatebmdToolStripMenuItem_Load.PerformClick();
				break;

				return;
			}
		}

		// Token: 0x060005C9 RID: 1481 RVA: 0x0005D7A4 File Offset: 0x0005B9A4
		private void toolStripButton_RemoveSelectedRow_Click(object sender, EventArgs e)
		{
			if (this.s_LoadedFile != "Item_Ex700" && this.s_LoadedFile != "Item_Ex700Plus" && this.s_LoadedFile != "ItemToolTip" && this.workingDGV.CurrentRow != null)
			{
				this.workingDGV.Rows.RemoveAt(this.workingDGV.Rows.IndexOf(this.workingDGV.CurrentRow));
			}
		}

		// Token: 0x060005CA RID: 1482 RVA: 0x0005D820 File Offset: 0x0005BA20
		private void toolStripButton_Save_Click(object sender, EventArgs e)
		{
			string key;
			switch (key = this.s_LoadedFile)
			{
			case "ItemToolTip":
				this.ItemToolTip_Save();
				return;
			case "ItemSetType":
				this.ItemSetType_Save();
				return;
			case "ItemSetOption":
				this.ItemSetOption_Save();
				return;
			case "ItemAddOption":
				this.ItemAddOption_Save();
				return;
			case "ItemToolTipText":
				this.ItemToolTipText_Save();
				return;
			case "JewelOfHarmonySmelt":
				this.JewelOfHarmonySmelt_Save();
				return;
			case "MoveReq":
				this.MoveReq_Save();
				return;
			case "NpcName":
				this.NpcName_Save();
				return;
			case "NpcName_Ex700Plus":
				this.NpcNameEx700Plus_Save();
				return;
			case "Item_Ex700":
				this.ItemEx700_Save();
				return;
			case "Item_S6E3":
				this.Item_S6E3_Save();
				return;
			case "Item_Ex700Plus":
				this.ItemEx700Plus_Save();
				return;
			case "Item_Season8Episode1":
				this.ItemSeason8Episode1_Save();
				return;
			case "ServerList_Ex700":
				this.ServerListEx700_Save();
				return;
			case "ServerList_S6E3":
				this.ServerListS6E3_Save();
				return;
			case "Monster":
				this.Monster_Save();
				return;
			case "Glow":
				this.Glow_Save();
				return;
			case "Text":
				this.Text_Save();
				return;
			case "Slide":
				this.Slide_Save();
				return;
			case "Skill_ExS8E1":
				this.Skill_ExS8E1_Save();
				return;
			case "Skill_S6E3":
				this.Skill_S6E3_Save();
				return;
			case "Mix":
				this.Mix_Save();
				return;
			case "Filter":
				this.Filter_Save();
				return;
			case "FilterName":
				this.FilterName_Save();
				return;
			case "Minimap":
				this.Minimap_Save();
				return;
			case "Gate":
				this.Gate_Save();
				break;

				return;
			}
		}

		// Token: 0x060005CB RID: 1483 RVA: 0x0005DAD8 File Offset: 0x0005BCD8
		private void toolStripButton_SaveTXT_Click(object sender, EventArgs e)
		{
			if (this.workingDGV != null)
			{
				SaveFileDialog saveFileDialog = new SaveFileDialog
				{
					DefaultExt = ".txt",
					AddExtension = true,
					Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"
				};
				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName)
					{
						AutoFlush = true
					};
					streamWriter.WriteLine("******** File Generated by MU.ToolKit [Silver Edition] coded by TopReal.IT ********");
					string text = string.Empty;
					foreach (object obj in this.workingDGV.Columns)
					{
						DataGridViewColumn dataGridViewColumn = (DataGridViewColumn)obj;
						text = text + "\t" + dataGridViewColumn.Name;
					}
					streamWriter.WriteLine(text);
					foreach (object obj2 in ((IEnumerable)this.workingDGV.Rows))
					{
						DataGridViewRow dataGridViewRow = (DataGridViewRow)obj2;
						string text2 = string.Empty;
						for (int i = 0; i < dataGridViewRow.Cells.Count; i++)
						{
							text2 = text2 + "\t" + dataGridViewRow.Cells[i].Value;
						}
						streamWriter.WriteLine(text2);
					}
					streamWriter.Close();
				}
			}
		}

		// Token: 0x060005CC RID: 1484 RVA: 0x0005DC58 File Offset: 0x0005BE58
		private void toolStripButton_Search_Click(object sender, EventArgs e)
		{
			if (Application.OpenForms["Form_Search"] == null)
			{
				new Form_Search().Show(this);
				return;
			}
			Application.OpenForms["Form_Search"].Focus();
		}

		// Token: 0x060005CD RID: 1485 RVA: 0x0005DC8C File Offset: 0x0005BE8C
		private void UpdateCheck()
		{
			WebClient webClient = new WebClient();
			try
			{
				string[] array = Encoding.ASCII.GetString(webClient.DownloadData(this.UpdatePath)).Replace("\r", "").Split(new char[]
				{
					'\n'
				});
				if (array[0].Trim(new char[]
				{
					'"'
				}) != base.ProductVersion && array[1].Trim(new char[]
				{
					'"'
				}) != base.ProductVersion)
				{
					new MyDialog("v" + array[0].Trim(new char[]
					{
						'"'
					}), array[2]).ShowDialog();
					Environment.Exit(0);
				}
			}
			catch
			{
				MessageBox.Show("Failed to check for latest version.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				Environment.Exit(0);
			}
		}

		// Token: 0x060005CE RID: 1486 RVA: 0x0005DD84 File Offset: 0x0005BF84
		private void xMLNewToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new EventBagEditor_XML().Show();
		}

		// Token: 0x040002C0 RID: 704
		private byte[] endBytes = new byte[4];

		// Token: 0x040002C7 RID: 711
		private DataGridView Filterdgv;

		// Token: 0x040002C9 RID: 713
		private DataGridView FilterNamedgv;

		// Token: 0x040002CA RID: 714
		private object[,] fStruct;

		// Token: 0x040002CC RID: 716
		private DataGridView Gatedgv;

		// Token: 0x040002CE RID: 718
		private DataGridView Glowdgv;

		// Token: 0x040002D1 RID: 721
		public bool isEx700ItemList = true;

		// Token: 0x040002D2 RID: 722
		public bool isIGCCustomBMD;

		// Token: 0x040002D3 RID: 723
		private bool isLeaveOpenItemAdder;

		// Token: 0x040002D4 RID: 724
		private bool isNewRow;

		// Token: 0x040002D5 RID: 725
		private bool isPasteFromCP;

		// Token: 0x040002DB RID: 731
		private DataGridView ItemSetOptiondgv;

		// Token: 0x040002DD RID: 733
		private DataGridView ItemToolTipTextdgv;

		// Token: 0x040002E1 RID: 737
		private TabPage LastSelectedItemGroup;

		// Token: 0x040002E3 RID: 739
		private DataGridView Minimapdgv;

		// Token: 0x040002E5 RID: 741
		private DataGridView Mixdgv;

		// Token: 0x040002E7 RID: 743
		private int Model_sBlockSize = 100;

		// Token: 0x040002E8 RID: 744
		private int Model_sSize;

		// Token: 0x040002E9 RID: 745
		private int Monster_sBlockSize = 59;

		// Token: 0x040002EA RID: 746
		private int Monster_sSize;

		// Token: 0x040002EC RID: 748
		private DataGridView Monsterdgv;

		// Token: 0x040002EF RID: 751
		private DataGridView MRdgv;

		// Token: 0x040002F0 RID: 752
		private byte[] newFile = new byte[0];

		// Token: 0x040002F2 RID: 754
		private DataGridView NPCNdgv;

		// Token: 0x040002F3 RID: 755
		private DataGridView NPCNPlusdgv;

		// Token: 0x040002F5 RID: 757
		private string PasteValue = string.Empty;

		// Token: 0x040002F7 RID: 759
		private string s_LoadedFile = "";

		// Token: 0x040002FA RID: 762
		private int sBlockSize;

		// Token: 0x040002FD RID: 765
		private DataGridView ServerListEx700dgv;

		// Token: 0x040002FE RID: 766
		private DataGridView ServerListS6E3dgv;

		// Token: 0x04000301 RID: 769
		private DataGridView Skill_ExS8E1dgv;

		// Token: 0x04000302 RID: 770
		private DataGridView Skill_S6E3dgv;

		// Token: 0x04000307 RID: 775
		private DataGridView Slidedgv;

		// Token: 0x04000308 RID: 776
		public int sSize;

		// Token: 0x04000309 RID: 777
		private byte[] startBytes = new byte[4];

		// Token: 0x0400030B RID: 779
		private byte[] T_fStruct;

		// Token: 0x0400030C RID: 780
		public TabControl tc_Items = new TabControl();

		// Token: 0x0400030E RID: 782
		private DataGridView TEXTdgv;

		// Token: 0x04000329 RID: 809
		private string UpdatePath = "https://dl.dropbox.com/u/108778685/ToolKitUpdate.txt";

		// Token: 0x0400032A RID: 810
		public DataGridView workingDGV;

		// Token: 0x02000027 RID: 39
		public class Kernel32
		{
			// Token: 0x060005CF RID: 1487
			[DllImport("Kernel32.dll", CallingConvention = CallingConvention.StdCall)]
			public static extern bool GetEnvironmentVariable(string lpName, StringBuilder lpBuffer, int nSize);
		}

		// Token: 0x02000028 RID: 40
		internal class SendArgs
		{
			// Token: 0x170003B0 RID: 944
			// (get) Token: 0x060005D1 RID: 1489 RVA: 0x0005DD98 File Offset: 0x0005BF98
			// (set) Token: 0x060005D2 RID: 1490 RVA: 0x0005DDA0 File Offset: 0x0005BFA0
			internal string filePath { get; set; }

			// Token: 0x170003B1 RID: 945
			// (get) Token: 0x060005D3 RID: 1491 RVA: 0x0005DDA9 File Offset: 0x0005BFA9
			// (set) Token: 0x060005D4 RID: 1492 RVA: 0x0005DDB1 File Offset: 0x0005BFB1
			internal string fileType { get; set; }
		}
	}
}
