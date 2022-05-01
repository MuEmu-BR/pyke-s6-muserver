using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MU_ToolKit.Properties;

namespace MU_ToolKit
{
	// Token: 0x02000029 RID: 41
	public partial class MSBEditor : Form
	{
		// Token: 0x060005D6 RID: 1494 RVA: 0x0005DDC4 File Offset: 0x0005BFC4
		public MSBEditor()
		{
			this.InitializeComponent();
		}

		// Token: 0x060005D7 RID: 1495 RVA: 0x0005DE44 File Offset: 0x0005C044
		private void AddMobToMap(Structures.MSB mMSB)
		{
			Structures.CustomPictureBox customPictureBox = new Structures.CustomPictureBox();
			Structures.CustomToolTip customToolTip = new Structures.CustomToolTip();
			customPictureBox.Location = new Point(mMSB.Y * 3, mMSB.X * 3);
			int num = mMSB.Y - mMSB.EndY;
			int num2 = mMSB.X - mMSB.EndX;
			if (num < 0)
			{
				num *= -1;
			}
			if (num2 < 0)
			{
				num2 *= -1;
			}
			switch (mMSB.Type)
			{
			case 0:
				customPictureBox.BackColor = Color.Yellow;
				customPictureBox.Size = new Size(3, 3);
				break;
			case 1:
				customPictureBox.Size = new Size(num * 3, num2 * 3);
				customPictureBox.BorderColor = Color.ForestGreen;
				customPictureBox.BackColor = Color.Transparent;
				break;
			case 2:
				customPictureBox.BackColor = Color.Red;
				customPictureBox.Size = new Size(3, 3);
				break;
			case 3:
				customPictureBox.Size = new Size(num * 3, num2 * 3);
				customPictureBox.BorderColor = Color.Maroon;
				customPictureBox.BackColor = Color.Transparent;
				break;
			case 4:
				customPictureBox.BackColor = Color.Cyan;
				customPictureBox.Size = new Size(3, 3);
				break;
			}
			customPictureBox.Parent = this.pictureBox_Map;
			customPictureBox.Name = mMSB.UniKey;
			customToolTip.SetToolTip(customPictureBox, mMSB.ToolTipInfo);
			this.pictureBox_Map.Controls.Add(customPictureBox);
			if (mMSB.Type == 3 || mMSB.Type == 1)
			{
				customPictureBox.SendToBack();
			}
			else
			{
				customPictureBox.BringToFront();
			}
			customPictureBox.MouseClick += this.p_MouseClick;
		}

		// Token: 0x060005D8 RID: 1496 RVA: 0x0005DFE0 File Offset: 0x0005C1E0
		private void button_RemoveMobOnMap_Click(object sender, EventArgs e)
		{
			Structures.MSB item = (Structures.MSB)this.listBox_MobsOnMap.SelectedItem;
			this.MobsOnMap.Remove(item);
			this.MonsterSetBase.Remove(item);
			this.pictureBox_Map.Controls.RemoveByKey(item.UniKey);
		}

		// Token: 0x060005D9 RID: 1497 RVA: 0x0005E030 File Offset: 0x0005C230
		private void button_UpdateMonster_Click(object sender, EventArgs e)
		{
			Structures.Monster monster = (Structures.Monster)this.listBox_Mob.SelectedItem;
			Structures.Monster value = default(Structures.Monster);
			value = monster;
			value.Name = this.textBox_MobName.Text;
			value.ID = (int)this.numericUpDown_ID.Value;
			value.Rate = (int)this.numericUpDown_Rate.Value;
			value.Level = (int)this.numericUpDown_Level.Value;
			value.HP = (int)this.numericUpDown_HP.Value;
			value.MP = (int)this.numericUpDown_MP.Value;
			value.MinDmg = (int)this.numericUpDown_MinDmg.Value;
			value.MaxDmg = (int)this.numericUpDown_MaxDmg.Value;
			value.Def = (int)this.numericUpDown_Def.Value;
			value.MagDef = (int)this.numericUpDown_MagicDef.Value;
			value.AtkPower = (int)this.numericUpDown_Attack.Value;
			value.AtkSucRate = (int)this.numericUpDown_Success.Value;
			value.Move = (int)this.numericUpDown_Move.Value;
			value.AType = (int)this.numericUpDown_AType.Value;
			value.ARange = (int)this.numericUpDown_ARange.Value;
			value.VRange = (int)this.numericUpDown_VRange.Value;
			value.MovSP = (int)this.numericUpDown_MoveSP.Value;
			value.ASpeed = (int)this.numericUpDown_ASpeed.Value;
			value.RegTime = (int)this.numericUpDown_RegTime.Value;
			value.ItemR = (int)this.numericUpDown_ItemR.Value;
			value.MoneyR = (int)this.numericUpDown_MoneyR.Value;
			value.MaxIS = (int)this.numericUpDown_MaxIS.Value;
			value.Attrib = (int)this.numericUpDown_Attrib.Value;
			value.RWind = (int)this.numericUpDown_RWind.Value;
			value.RPois = (int)this.numericUpDown_RPois.Value;
			value.RIce = (int)this.numericUpDown_RIce.Value;
			value.RWtr = (int)this.numericUpDown_RWtr.Value;
			value.RFire = (int)this.numericUpDown_RFire.Value;
			value.Element = (int)this.numericUpDown_Element.Value;
			value.MinElem = (int)this.numericUpDown_MinElem.Value;
			value.MaxElem = (int)this.numericUpDown_MaxElem.Value;
			value.ElemDef = (int)this.numericUpDown_ElemDef.Value;
			this.Monster[this.Monster.IndexOf(monster)] = value;
			this.MonsterDic[monster.ID] = value.Name;
		}

		// Token: 0x060005DA RID: 1498 RVA: 0x0005E364 File Offset: 0x0005C564
		private void checkBox_HideMobs_CheckedChanged(object sender, EventArgs e)
		{
			if (this.checkBox_HideMobs.Checked)
            {
                IEnumerator enumerator = this.pictureBox_Map.Controls.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    object obj = enumerator.Current;
                    Control control = (Control)obj;
                    control.Visible = false;
                }
                return;
            }
			foreach (object obj2 in this.pictureBox_Map.Controls)
			{
				Control control2 = (Control)obj2;
				control2.Visible = true;
			}
		}

		// Token: 0x060005DC RID: 1500 RVA: 0x0005E444 File Offset: 0x0005C644
		private void DisposedUnusedControls()
		{
			foreach (object obj in this.pictureBox_Map.Controls)
			{
				Control control = (Control)obj;
				control.Visible = false;
				control.Hide();
			}
		}

		// Token: 0x060005DD RID: 1501 RVA: 0x0005E4A8 File Offset: 0x0005C6A8
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

		// Token: 0x060005DE RID: 1502 RVA: 0x0005E5BC File Offset: 0x0005C7BC
		private string GetUniqueKey()
		{
			return this.rnd.Next(99999).ToString() + this.rnd.Next(99999).ToString() + this.rnd.Next(99999).ToString() + this.rnd.Next(99999).ToString();
		}

		// Token: 0x060005E0 RID: 1504 RVA: 0x00062C8C File Offset: 0x00060E8C
		private void listBox_Map_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!this.isWorking & this.listBox_Map.SelectedIndex != -1)
			{
				this.DisposedUnusedControls();
				this.LastPicBox = null;
				this.isWorking = true;
				this.pictureBox_Map.Controls.Clear();
				Structures.Map map = (Structures.Map)this.listBox_Map.SelectedItem;
				this.pictureBox_Map.BackgroundImage = (Bitmap)Resources.ResourceManager.GetObject(map.MapName.Replace(' ', '_').Replace('-', '_'));
				this.MobsOnMap = new BindingList<Structures.MSB>();
				foreach (Structures.MSB msb in this.MonsterSetBase)
				{
					if (msb.MapID == (int)this.listBox_Map.SelectedValue)
					{
						this.MobsOnMap.Add(msb);
						this.AddMobToMap(msb);
					}
				}
				this.listBox_MobsOnMap.DataBindings.Clear();
				this.listBox_MobsOnMap.DataSource = null;
				this.listBox_MobsOnMap.DisplayMember = "MobName";
				this.listBox_MobsOnMap.ValueMember = "MobID";
				this.listBox_MobsOnMap.DataSource = this.MobsOnMap;
				this.isWorking = false;
				if (this.listBox_MobsOnMap.Items.Count > 0)
				{
					this.listBox_MobsOnMap.SelectedIndex = -1;
					this.listBox_MobsOnMap.SelectedIndex = 0;
				}
				this.checkBox_HideMobs.Checked = false;
			}
		}

		// Token: 0x060005E1 RID: 1505 RVA: 0x00062E24 File Offset: 0x00061024
		private void listBox_Mob_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.listBox_Mob.SelectedItem != null)
			{
				Structures.Monster monster = (Structures.Monster)this.listBox_Mob.SelectedItem;
				this.textBox_MobName.Text = monster.Name;
				this.numericUpDown_ID.Value = monster.ID;
				this.numericUpDown_Rate.Value = monster.Rate;
				this.numericUpDown_Level.Value = monster.Level;
				this.numericUpDown_HP.Value = monster.HP;
				this.numericUpDown_MP.Value = monster.MP;
				this.numericUpDown_MinDmg.Value = monster.MinDmg;
				this.numericUpDown_MaxDmg.Value = monster.MaxDmg;
				this.numericUpDown_Def.Value = monster.Def;
				this.numericUpDown_MagicDef.Value = monster.MagDef;
				this.numericUpDown_Attack.Value = monster.AtkPower;
				this.numericUpDown_Success.Value = monster.AtkSucRate;
				this.numericUpDown_Move.Value = monster.Move;
				this.numericUpDown_AType.Value = monster.AType;
				this.numericUpDown_ARange.Value = monster.ARange;
				this.numericUpDown_VRange.Value = monster.VRange;
				this.numericUpDown_MoveSP.Value = monster.MovSP;
				this.numericUpDown_ASpeed.Value = monster.ASpeed;
				this.numericUpDown_RegTime.Value = monster.RegTime;
				this.numericUpDown_ItemR.Value = monster.ItemR;
				this.numericUpDown_MoneyR.Value = monster.MoneyR;
				this.numericUpDown_MaxIS.Value = monster.MaxIS;
				this.numericUpDown_Attrib.Value = monster.Attrib;
				this.numericUpDown_RWind.Value = monster.RWind;
				this.numericUpDown_RPois.Value = monster.RPois;
				this.numericUpDown_RIce.Value = monster.RIce;
				this.numericUpDown_RWtr.Value = monster.RWtr;
				this.numericUpDown_RFire.Value = monster.RFire;
				this.numericUpDown_Element.Value = monster.Element;
				this.numericUpDown_MaxElem.Value = monster.MaxElem;
				this.numericUpDown_MinElem.Value = monster.MinElem;
				this.numericUpDown_ElemDef.Value = monster.ElemDef;
			}
		}

		// Token: 0x060005E2 RID: 1506 RVA: 0x00063130 File Offset: 0x00061330
		private void listBox_MobsOnMap_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!this.isWorking & this.listBox_MobsOnMap.SelectedIndex != -1)
			{
				if (this.LastPicBox != null)
				{
					if (this.LastPicBox.BackColor != Color.Transparent)
					{
						this.LastPicBox.Size = new Size(3, 3);
						this.LastPicBox.BorderColor = Color.Transparent;
						this.LastPicBox.BackColor = this.LastBackColor;
					}
					else
					{
						this.LastPicBox.BorderColor = this.LastBorderColor;
					}
					if (this.LastPicBox.MSBType == 3 || this.LastPicBox.MSBType == 1)
					{
						this.LastPicBox.SendToBack();
					}
				}
				Structures.MSB msb = (Structures.MSB)this.listBox_MobsOnMap.SelectedItem;
				Structures.CustomPictureBox customPictureBox = (Structures.CustomPictureBox)this.pictureBox_Map.Controls[this.pictureBox_Map.Controls.IndexOfKey(msb.UniKey)];
				this.listBox_Mob.SelectedValue = msb.MobID;
				this.LastBackColor = customPictureBox.BackColor;
				this.LastBorderColor = customPictureBox.BorderColor;
				if (customPictureBox.BorderColor != Color.Transparent)
				{
					customPictureBox.BorderColor = Color.GhostWhite;
				}
				else
				{
					customPictureBox.BackColor = Color.GhostWhite;
					customPictureBox.Size = new Size(9, 9);
				}
				customPictureBox.BringToFront();
				this.LastPicBox = customPictureBox;
				this.LastPicBox.MSBType = msb.Type;
				this.pictureBox_Map.Invalidate();
			}
		}

		// Token: 0x060005E3 RID: 1507 RVA: 0x000632BC File Offset: 0x000614BC
		private void monsterSetBasetxtToolStripMenuItem_Save_Click(object sender, EventArgs e)
		{
			string text = "Saved Data\\MonsterSetBase Editor\\MonsterSetBase\\" + DateTime.Now.ToLocalTime().ToString().Replace('/', '.').Replace(':', '-').Replace(" ", " [") + "]";
			Directory.CreateDirectory(text);
			string text2 = text + "\\MonsterSetBase.txt";
			if (this.SaveMonsterSetBaseFile(text2) && MessageBox.Show("File saved successfully in\n\"" + text2 + "\"\n\nOpen containing folder?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
			{
				Process.Start(text);
			}
		}

		// Token: 0x060005E4 RID: 1508 RVA: 0x00063358 File Offset: 0x00061558
		private void monstertxtToolStripMenuItem_Save_Click(object sender, EventArgs e)
		{
			string text = "Saved Data\\MonsterSetBase Editor\\Monster\\" + DateTime.Now.ToLocalTime().ToString().Replace('/', '.').Replace(':', '-').Replace(" ", " [") + "]";
			Directory.CreateDirectory(text);
			string text2 = text + "\\Monster.txt";
			if (this.SaveMonsterFile(text2) && MessageBox.Show("File saved successfully in\n\"" + text2 + "\"\n\nOpen containing folder?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
			{
				Process.Start(text);
			}
		}

		// Token: 0x060005E5 RID: 1509 RVA: 0x000633F4 File Offset: 0x000615F4
		private void MSBEditor_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.OpenForms["Form1"].WindowState = FormWindowState.Normal;
		}

		// Token: 0x060005E6 RID: 1510 RVA: 0x0006340C File Offset: 0x0006160C
		private void MSBEditor_Load(object sender, EventArgs e)
		{
			if (Screen.PrimaryScreen.Bounds.Size.Height < base.Size.Height || Screen.PrimaryScreen.Bounds.Size.Width < base.Size.Width)
			{
				base.Size = new Size(Screen.PrimaryScreen.Bounds.Size.Width, Screen.PrimaryScreen.Bounds.Size.Height);
				base.Location = new Point(0, 0);
			}
			this.g = this.pictureBox_Map.CreateGraphics();
			this.isWorking = true;
			this.strct.initMapListBox(ref this.listBox_Map);
			this.isWorking = false;
			this.ReadMonsterFile("Data\\MSB\\Monster.txt");
			this.ReadMSBFile("Data\\MSB\\MonsterSetBase.txt");
			if (this.listBox_Map.Items.Count > 0)
			{
				this.listBox_Map.SelectedIndex = -1;
				this.listBox_Map.SelectedIndex = 0;
			}
			if (this.listBox_MobsOnMap.Items.Count > 0)
			{
				this.listBox_MobsOnMap.SelectedIndex = -1;
				this.listBox_MobsOnMap.SelectedIndex = 0;
			}
			Application.OpenForms["Form1"].WindowState = FormWindowState.Minimized;
			base.WindowState = FormWindowState.Normal;
			base.TopMost = true;
			base.TopMost = false;
			base.BringToFront();
			base.Focus();
			base.Focus();
		}

		// Token: 0x060005E7 RID: 1511 RVA: 0x0006359C File Offset: 0x0006179C
		private void p_MouseClick(object sender, MouseEventArgs e)
		{
			PictureBox pictureBox = (PictureBox)sender;
			if (e.Button == MouseButtons.Left)
			{
				foreach (Structures.MSB msb in this.MobsOnMap)
				{
					if (msb.UniKey == pictureBox.Name)
					{
						this.listBox_MobsOnMap.SelectedItem = msb;
						break;
					}
				}
			}
		}

		// Token: 0x060005E8 RID: 1512 RVA: 0x00063620 File Offset: 0x00061820
		private void pictureBox_Map_MouseClick(object sender, MouseEventArgs e)
		{
			if (this.SelectedMSBType != 1 && this.SelectedMSBType != 3)
			{
				Structures.Monster monster = (Structures.Monster)this.listBox_Mob.SelectedItem;
				Structures.MSB msb = new Structures.MSB
				{
					Dis = (int)this.numericUpDown_Distance.Value,
					MapID = (int)this.listBox_Map.SelectedValue,
					MobID = monster.ID,
					MobName = monster.Name,
					Type = this.SelectedMSBType,
					UniKey = this.GetUniqueKey(),
					Y = e.Location.X / 3,
					X = e.Location.Y / 3
				};
				msb.FileDesc = "//" + msb.MobName;
				msb.ToolTipInfo = string.Concat(new object[]
				{
					"\bName:\t\t",
					msb.MobName,
					"\nID:\t\t",
					msb.MobID,
					"\nSpot Type:\t"
				});
				msb.ToolTipInfo += ((msb.Type == 0) ? "(0) NPC" : ((msb.Type == 1) ? "(1) Multiple" : ((msb.Type == 2) ? "(2) Standard" : ((msb.Type == 3) ? "(3) Multiple" : ((msb.Type == 4) ? "(4) Event" : "NULL")))));
				msb.ToolTipInfo = msb.ToolTipInfo + "\nSpawn Radius:\t" + msb.Dis;
				switch (this.SelectedMSBType)
				{
				case 0:
				case 2:
					msb.Dir = this.SelectedDir;
					msb.ToolTipInfo = msb.ToolTipInfo + "\nDirection:\t" + msb.Dir;
					break;
				case 4:
					msb.Total = (int)this.numericUpDown_Total.Value;
					msb.ToolTipInfo = msb.ToolTipInfo + "\nTotal Mobs:\t" + msb.Total;
					break;
				}
				msb.ToolTipInfo = msb.ToolTipInfo + "\nX:\t" + msb.X;
				msb.ToolTipInfo = msb.ToolTipInfo + "\tY:\t" + msb.Y;
				this.MonsterSetBase.Add(msb);
				this.AddMobToMap(msb);
				this.MobsOnMap.Add(msb);
			}
		}

		// Token: 0x060005E9 RID: 1513 RVA: 0x000638E0 File Offset: 0x00061AE0
		private void pictureBox_Map_MouseDown(object sender, MouseEventArgs e)
		{
			if (this.SelectedMSBType == 1 || this.SelectedMSBType == 3)
			{
				this.mouseDrag = 1;
				this.StartY = e.Location.X / 3;
				this.StartX = e.Location.Y / 3;
				this.PanelPreview = new Structures.CustomPictureBox();
				this.PanelPreview.Size = new Size(0, 0);
				this.PanelPreview.Location = e.Location;
				this.PanelPreview.BackColor = Color.Transparent;
				this.PanelPreview.BorderColor = Color.GhostWhite;
				this.pictureBox_Map.Controls.Add(this.PanelPreview);
			}
		}

		// Token: 0x060005EA RID: 1514 RVA: 0x0006399C File Offset: 0x00061B9C
		private void pictureBox_Map_MouseMove(object sender, MouseEventArgs e)
		{
			if (((this.SelectedMSBType == 1 || this.SelectedMSBType == 3) & this.mouseDrag == 1) && (this.PanelPreview.Location.X < e.Location.X & this.PanelPreview.Location.Y < e.Location.Y))
			{
				this.PanelPreview.Size = new Size(e.Location.X - this.PanelPreview.Location.X, e.Location.Y - this.PanelPreview.Location.Y);
				this.pictureBox_Map.Invalidate();
			}
		}

		// Token: 0x060005EB RID: 1515 RVA: 0x00063A7C File Offset: 0x00061C7C
		private void pictureBox_Map_MouseUp(object sender, MouseEventArgs e)
		{
			this.mouseDrag = 0;
			if (this.SelectedMSBType == 1 || this.SelectedMSBType == 3)
			{
				this.pictureBox_Map.Controls.Remove(this.PanelPreview);
				this.PanelPreview = new Structures.CustomPictureBox();
				Structures.Monster monster = (Structures.Monster)this.listBox_Mob.SelectedItem;
				Structures.MSB msb = new Structures.MSB
				{
					Dis = (int)this.numericUpDown_Distance.Value,
					MapID = (int)this.listBox_Map.SelectedValue,
					MobID = monster.ID,
					MobName = monster.Name,
					Type = this.SelectedMSBType,
					UniKey = this.GetUniqueKey(),
					EndY = e.Location.X / 3,
					EndX = e.Location.Y / 3,
					X = this.StartX,
					Y = this.StartY,
					Dir = this.SelectedDir,
					Total = (int)this.numericUpDown_Total.Value
				};
				msb.FileDesc = "//" + msb.MobName;
				msb.ToolTipInfo = string.Concat(new object[]
				{
					"\bName:\t\t",
					msb.MobName,
					"\nID:\t\t",
					msb.MobID,
					"\nDirection:\t",
					msb.Dir,
					"\nSpot Type:\t"
				});
				msb.ToolTipInfo += ((msb.Type == 0) ? "(0) NPC" : ((msb.Type == 1) ? "(1) Multiple" : ((msb.Type == 2) ? "(2) Standard" : ((msb.Type == 3) ? "(3) Multiple" : ((msb.Type == 4) ? "(4) Event" : "NULL")))));
				msb.ToolTipInfo = msb.ToolTipInfo + "\nSpawn Radius:\t" + msb.Dis;
				msb.ToolTipInfo = msb.ToolTipInfo + "\nTotal Mobs:\t" + msb.Total;
				msb.ToolTipInfo = msb.ToolTipInfo + "\nStart X:\t" + msb.X;
				msb.ToolTipInfo = msb.ToolTipInfo + "\tStart Y:\t" + msb.Y;
				msb.ToolTipInfo = msb.ToolTipInfo + "\nEnd X:\t" + msb.EndX;
				msb.ToolTipInfo = msb.ToolTipInfo + "\tEnd Y:\t" + msb.EndY;
				this.MonsterSetBase.Add(msb);
				this.AddMobToMap(msb);
				this.MobsOnMap.Add(msb);
			}
		}

		// Token: 0x060005EC RID: 1516 RVA: 0x00063D8C File Offset: 0x00061F8C
		private void radioButton_Dir_Negtive1_CheckedChanged(object sender, EventArgs e)
		{
			if (this.radioButton_Dir_1.Checked)
			{
				this.label_Dir.Text = "1";
				this.SelectedDir = 1;
				return;
			}
			if (this.radioButton_Dir_2.Checked)
			{
				this.label_Dir.Text = "2";
				this.SelectedDir = 2;
				return;
			}
			if (this.radioButton_Dir_3.Checked)
			{
				this.label_Dir.Text = "3";
				this.SelectedDir = 3;
				return;
			}
			if (this.radioButton_Dir_4.Checked)
			{
				this.label_Dir.Text = "4";
				this.SelectedDir = 4;
				return;
			}
			if (this.radioButton_Dir_5.Checked)
			{
				this.label_Dir.Text = "5";
				this.SelectedDir = 5;
				return;
			}
			if (this.radioButton_Dir_6.Checked)
			{
				this.label_Dir.Text = "6";
				this.SelectedDir = 6;
				return;
			}
			if (this.radioButton_Dir_7.Checked)
			{
				this.label_Dir.Text = "7";
				this.SelectedDir = 7;
				return;
			}
			if (this.radioButton_Dir_8.Checked)
			{
				this.label_Dir.Text = "8";
				this.SelectedDir = 8;
				return;
			}
			if (this.radioButton_Dir_Negtive1.Checked)
			{
				this.label_Dir.Text = "-1";
				this.SelectedDir = -1;
			}
		}

		// Token: 0x060005ED RID: 1517 RVA: 0x00063EE8 File Offset: 0x000620E8
		private void radioButton_Type_1_CheckedChanged(object sender, EventArgs e)
		{
			if (this.radioButton_Type_0.Checked)
			{
				this.SelectedMSBType = 0;
				return;
			}
			if (this.radioButton_Type_1.Checked)
			{
				this.SelectedMSBType = 1;
				return;
			}
			if (this.radioButton_Type_2.Checked)
			{
				this.SelectedMSBType = 2;
				return;
			}
			if (this.radioButton_Type_3.Checked)
			{
				this.SelectedMSBType = 3;
				return;
			}
			if (this.radioButton_Type_4.Checked)
			{
				this.SelectedMSBType = 4;
			}
		}

		// Token: 0x060005EE RID: 1518 RVA: 0x00063F60 File Offset: 0x00062160
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
						this.MonsterDic.Add(item.ID, item.Name);
						this.Monster.Add(item);
					}
				}
			}
			this.listBox_Mob.DataBindings.Clear();
			this.listBox_Mob.DataSource = null;
			this.listBox_Mob.ValueMember = "ID";
			this.listBox_Mob.DisplayMember = "Name";
			this.listBox_Mob.DataSource = this.Monster;
		}

		// Token: 0x060005EF RID: 1519 RVA: 0x0006429C File Offset: 0x0006249C
		private void ReadMSBFile(string fName)
		{
			try
			{
				string[] array = File.ReadAllLines(fName);
				int num = 0;
				foreach (string text in array)
				{
					if (!text.StartsWith("end") & !text.StartsWith("//") & text.Length != 0)
					{
						string[] array3 = text.Split(new char[]
						{
							'/'
						});
						string text2 = array3[0].Replace(" ", "\t");
						if (text2.Length == 1 || text2.Replace("\t", string.Empty).Length == 1)
						{
							num = Convert.ToInt32(text2);
						}
						else
						{
							string fileDesc = string.Empty;
							if (array3.Contains("//"))
							{
								fileDesc = array3[2];
							}
							string[] trimmedSplitString = this.GetTrimmedSplitString(text2);
							if (trimmedSplitString != null)
							{
								Structures.MSB item = default(Structures.MSB);
								switch (num)
								{
								case 0:
								case 2:
									item.Type = 0;
									item.MobID = Convert.ToInt32(trimmedSplitString[0]);
									item.MapID = Convert.ToInt32(trimmedSplitString[1]);
									item.Dis = Convert.ToInt32(trimmedSplitString[2]);
									item.X = Convert.ToInt32(trimmedSplitString[3]);
									item.Y = Convert.ToInt32(trimmedSplitString[4]);
									item.Dir = Convert.ToInt32(trimmedSplitString[5]);
									break;
								case 1:
								case 3:
									item.Type = 1;
									item.MobID = Convert.ToInt32(trimmedSplitString[0]);
									item.MapID = Convert.ToInt32(trimmedSplitString[1]);
									item.Dis = Convert.ToInt32(trimmedSplitString[2]);
									item.X = Convert.ToInt32(trimmedSplitString[3]);
									item.Y = Convert.ToInt32(trimmedSplitString[4]);
									item.EndX = Convert.ToInt32(trimmedSplitString[5]);
									item.EndY = Convert.ToInt32(trimmedSplitString[6]);
									item.Dir = Convert.ToInt32(trimmedSplitString[7]);
									item.Total = Convert.ToInt32(trimmedSplitString[8]);
									break;
								case 4:
									item.Type = 0;
									item.MobID = Convert.ToInt32(trimmedSplitString[0]);
									item.MapID = Convert.ToInt32(trimmedSplitString[1]);
									item.Dis = Convert.ToInt32(trimmedSplitString[2]);
									item.X = Convert.ToInt32(trimmedSplitString[3]);
									item.Y = Convert.ToInt32(trimmedSplitString[4]);
									item.Total = Convert.ToInt32(trimmedSplitString[5]);
									break;
								}
								item.FileDesc = fileDesc;
								if (this.MonsterDic.ContainsKey(item.MobID))
								{
									item.MobName = this.MonsterDic[item.MobID];
								}
								item.UniKey = this.GetUniqueKey();
								item.ToolTipInfo = string.Concat(new object[]
								{
									"\bName:\t\t",
									item.MobName,
									"\nID:\t\t",
									item.MobID,
									"\nDirection:\t",
									item.Dir,
									"\nSpot Type:\t"
								});
								item.ToolTipInfo += ((item.Type == 0) ? "(0) NPC" : ((item.Type == 1) ? "(1) Multiple" : ((item.Type == 2) ? "(2) Standard" : ((item.Type == 3) ? "(3) Multiple" : ((item.Type == 4) ? "(4) Event" : "NULL")))));
								item.ToolTipInfo = item.ToolTipInfo + "\nSpawn Radius:\t" + item.Dis;
								item.ToolTipInfo = item.ToolTipInfo + "\nTotal Mobs:\t" + item.Total;
								item.ToolTipInfo = item.ToolTipInfo + "\nStart X:\t" + item.X;
								item.ToolTipInfo = item.ToolTipInfo + "\tStart Y:\t" + item.Y;
								item.ToolTipInfo = item.ToolTipInfo + "\nEnd X:\t" + item.EndX;
								item.ToolTipInfo = item.ToolTipInfo + "\tEnd Y:\t" + item.EndY;
								this.MonsterSetBase.Add(item);
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.StackTrace.Split(new char[]
				{
					':'
				})[2], "MonsterSetBase.txt Read Error");
			}
		}

		// Token: 0x060005F0 RID: 1520 RVA: 0x00064768 File Offset: 0x00062968
		private bool SaveMonsterFile(string fName)
		{
			StreamWriter streamWriter = new StreamWriter(fName);
			bool result;
			try
			{
				streamWriter.AutoFlush = true;
				streamWriter.WriteLine("//Generated by MU.ToolKit coded by TopReal.IT");
				streamWriter.WriteLine("// ==========================================================================================================================================================================================================================================");
				streamWriter.WriteLine("//No.\tRate\tName\t\t\tLVL\tHP\tMP\tMinDmg\tMaxDmg\tDef\tMagDef\tAttack \tSuccess\tMove\tA.Type\tA.Range\tV.Range\tMovSP\tA.Speed\tRegTime\tAttrib\tItemR\tMoneyR\tMaxIS\tRWind\tRPois\tRIce\tRWtr\tRFire\tEl\tElMin\tElMax\tElDef");
				streamWriter.WriteLine("// ==========================================================================================================================================================================================================================================");
				int num = 1;
				foreach (Structures.Monster monster in this.Monster)
				{
					int num2 = 0;
					Math.DivRem(num, 20, out num2);
					if (num2 == 0)
					{
						streamWriter.WriteLine("// ==========================================================================================================================================================================================================================================");
						streamWriter.WriteLine("//No.\tRate\tName\t\t\tLVL\tHP\tMP\tMinDmg\tMaxDmg\tDef\tMagDef\tAttack \tSuccess\tMove\tA.Type\tA.Range\tV.Range\tMovSP\tA.Speed\tRegTime\tAttrib\tItemR\tMoneyR\tMaxIS\tRWind\tRPois\tRIce\tRWtr\tRFire\tEl\tElMin\tElMax\tElDef");
						streamWriter.WriteLine("// ==========================================================================================================================================================================================================================================");
					}
					streamWriter.WriteLine("{0}\t{1}\t{2}\t\t\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}\t{10}\t{11}\t{12}\t{13}\t{14}\t{15}\t{16}\t{17}\t{18}\t{19}\t{20}\t{21}\t{22}\t{23}\t{24}\t{25}\t{26}\t{27}\t{28}\t{29}\t{30}\t{31}", new object[]
					{
						monster.ID.ToString(),
						monster.Rate.ToString(),
						"\"" + monster.Name + "\"".ToString(),
						monster.Level.ToString(),
						monster.HP.ToString(),
						monster.MP.ToString(),
						monster.MinDmg.ToString(),
						monster.MaxDmg.ToString(),
						monster.Def.ToString(),
						monster.MagDef.ToString(),
						monster.AtkPower.ToString(),
						monster.AtkSucRate.ToString(),
						monster.Move.ToString(),
						monster.AType.ToString(),
						monster.ARange.ToString(),
						monster.VRange.ToString(),
						monster.MovSP.ToString(),
						monster.ASpeed.ToString(),
						monster.RegTime.ToString(),
						monster.Attrib.ToString(),
						monster.ItemR.ToString(),
						monster.MoneyR.ToString(),
						monster.MaxIS.ToString(),
						monster.RWind.ToString(),
						monster.RPois.ToString(),
						monster.RIce.ToString(),
						monster.RWtr.ToString(),
						monster.RFire,
						monster.Element.ToString(),
						monster.MinElem.ToString(),
						monster.MaxElem.ToString(),
						monster.ElemDef.ToString()
					});
					num++;
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

		// Token: 0x060005F1 RID: 1521 RVA: 0x00064B28 File Offset: 0x00062D28
		private bool SaveMonsterSetBaseFile(string fName)
		{
			StreamWriter streamWriter = new StreamWriter(fName);
			bool result;
			try
			{
				streamWriter.AutoFlush = true;
				streamWriter.WriteLine("//Generated by MU.ToolKit coded by TopReal.IT");
				this.MonsterSetBase.Sort();
				int mapID = this.MonsterSetBase[0].MapID;
				streamWriter.WriteLine();
				streamWriter.WriteLine("// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
				streamWriter.WriteLine("// =========== MapID: {0}", mapID);
				streamWriter.WriteLine("// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
				streamWriter.WriteLine();
				streamWriter.WriteLine("0");
				streamWriter.WriteLine("// ==========================================================================================================================================================================================================================================");
				streamWriter.WriteLine("//Mob\tMap\tDis\tX\tY\tDir\tName");
				streamWriter.WriteLine("// ==========================================================================================================================================================================================================================================");
				int num = 0;
				foreach (Structures.MSB msb in this.MonsterSetBase)
				{
					if (msb.MapID != mapID)
					{
						streamWriter.WriteLine();
						streamWriter.WriteLine("// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
						streamWriter.WriteLine("// =========== MapID: {0}", msb.MapID);
						streamWriter.WriteLine("// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
						streamWriter.WriteLine();
					}
					if (msb.Type == num)
					{
						switch (msb.Type)
						{
						case 0:
							streamWriter.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t//{6}", new object[]
							{
								msb.MobID,
								msb.MapID,
								msb.Dis,
								msb.X,
								msb.Y,
								msb.Dir,
								msb.MobName
							});
							break;
						case 1:
							streamWriter.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t//{9}", new object[]
							{
								msb.MobID,
								msb.MapID,
								msb.Dis,
								msb.X,
								msb.Y,
								msb.EndX,
								msb.EndY,
								msb.Dir,
								msb.Total,
								msb.MobName
							});
							break;
						case 2:
							streamWriter.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t//{6}", new object[]
							{
								msb.MobID,
								msb.MapID,
								msb.Dis,
								msb.X,
								msb.Y,
								msb.Dir,
								msb.MobName
							});
							break;
						case 3:
							streamWriter.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t//{9}", new object[]
							{
								msb.MobID,
								msb.MapID,
								msb.Dis,
								msb.X,
								msb.Y,
								msb.EndX,
								msb.EndY,
								msb.Dir,
								msb.Total,
								msb.MobName
							});
							break;
						case 4:
							streamWriter.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t//{6}", new object[]
							{
								msb.MobID,
								msb.MapID,
								msb.Dis,
								msb.X,
								msb.Y,
								msb.Total,
								msb.MobName
							});
							break;
						}
					}
					else
					{
						switch (msb.Type)
						{
						case 0:
							streamWriter.WriteLine("end");
							streamWriter.WriteLine();
							streamWriter.WriteLine("0");
							streamWriter.WriteLine("// ==========================================================================================================================================================================================================================================");
							streamWriter.WriteLine("//Mob\tMap\tDis\tX\tY\tDir\tName");
							streamWriter.WriteLine("// ==========================================================================================================================================================================================================================================");
							streamWriter.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t//{6}", new object[]
							{
								msb.MobID,
								msb.MapID,
								msb.Dis,
								msb.X,
								msb.Y,
								msb.Dir,
								msb.MobName
							});
							break;
						case 1:
							streamWriter.WriteLine("end");
							streamWriter.WriteLine();
							streamWriter.WriteLine("1");
							streamWriter.WriteLine("// ==========================================================================================================================================================================================================================================");
							streamWriter.WriteLine("//Mob\tMap\tDis\tsX\tsY\teX\teY\tDir\tTotal\tName");
							streamWriter.WriteLine("// ==========================================================================================================================================================================================================================================");
							streamWriter.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t//{9}", new object[]
							{
								msb.MobID,
								msb.MapID,
								msb.Dis,
								msb.X,
								msb.Y,
								msb.EndX,
								msb.EndY,
								msb.Dir,
								msb.Total,
								msb.MobName
							});
							break;
						case 2:
							streamWriter.WriteLine("end");
							streamWriter.WriteLine();
							streamWriter.WriteLine("2");
							streamWriter.WriteLine("// ==========================================================================================================================================================================================================================================");
							streamWriter.WriteLine("//Mob\tMap\tDis\tX\tY\tDir\tName");
							streamWriter.WriteLine("// ==========================================================================================================================================================================================================================================");
							streamWriter.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t//{6}", new object[]
							{
								msb.MobID,
								msb.MapID,
								msb.Dis,
								msb.X,
								msb.Y,
								msb.Dir,
								msb.MobName
							});
							break;
						case 3:
							streamWriter.WriteLine("end");
							streamWriter.WriteLine();
							streamWriter.WriteLine("3");
							streamWriter.WriteLine("// ==========================================================================================================================================================================================================================================");
							streamWriter.WriteLine("//Mob\tMap\tDis\tsX\tsY\teX\teY\tDir\tTotal\tName");
							streamWriter.WriteLine("// ==========================================================================================================================================================================================================================================");
							streamWriter.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t//{9}", new object[]
							{
								msb.MobID,
								msb.MapID,
								msb.Dis,
								msb.X,
								msb.Y,
								msb.EndX,
								msb.EndY,
								msb.Dir,
								msb.Total,
								msb.MobName
							});
							break;
						case 4:
							streamWriter.WriteLine("end");
							streamWriter.WriteLine();
							streamWriter.WriteLine("4");
							streamWriter.WriteLine("// ==========================================================================================================================================================================================================================================");
							streamWriter.WriteLine("//Mob\tMap\tDis\tX\tY\tTotal\tName");
							streamWriter.WriteLine("// ==========================================================================================================================================================================================================================================");
							streamWriter.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t//{6}", new object[]
							{
								msb.MobID,
								msb.MapID,
								msb.Dis,
								msb.X,
								msb.Y,
								msb.Total,
								msb.MobName
							});
							break;
						}
					}
					num = msb.Type;
					mapID = msb.MapID;
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

		// Token: 0x04000333 RID: 819
		private Graphics g;

		// Token: 0x0400033A RID: 826
		private bool isWorking;

		// Token: 0x0400035E RID: 862
		private Color LastBackColor = Color.Beige;

		// Token: 0x0400035F RID: 863
		private Color LastBorderColor = Color.Beige;

		// Token: 0x04000360 RID: 864
		private Structures.CustomPictureBox LastPicBox;

		// Token: 0x04000366 RID: 870
		private BindingList<Structures.MSB> MobsOnMap = new BindingList<Structures.MSB>();

		// Token: 0x04000367 RID: 871
		private BindingList<Structures.Monster> Monster = new BindingList<Structures.Monster>();

		// Token: 0x04000368 RID: 872
		private Dictionary<int, string> MonsterDic = new Dictionary<int, string>();

		// Token: 0x04000369 RID: 873
		private List<Structures.MSB> MonsterSetBase = new List<Structures.MSB>();

		// Token: 0x0400036C RID: 876
		private int mouseDrag;

		// Token: 0x0400038E RID: 910
		private Structures.CustomPictureBox PanelPreview;

		// Token: 0x0400039F RID: 927
		private Random rnd = new Random();

		// Token: 0x040003A1 RID: 929
		private int SelectedDir = 1;

		// Token: 0x040003A2 RID: 930
		private int SelectedMSBType = 2;

		// Token: 0x040003A3 RID: 931
		private int StartX;

		// Token: 0x040003A4 RID: 932
		private int StartY;

		// Token: 0x040003A5 RID: 933
		private Structures strct = new Structures();
	}
}
