using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MU_ToolKit
{
	// Token: 0x0200000A RID: 10
	public partial class Form_BmdItemAddercs : Form
	{
		// Token: 0x06000379 RID: 889 RVA: 0x0000F590 File Offset: 0x0000D790
		public Form_BmdItemAddercs(int BmdType)
		{
			this.InitializeComponent();
			this.BMDType = BmdType;
		}

		// Token: 0x0600037A RID: 890 RVA: 0x0000F5A8 File Offset: 0x0000D7A8
		private void button_InsertItem_Click(object sender, EventArgs e)
		{
			DataGridView workingDGV = ((Form1)base.Owner).workingDGV;
			int num = Convert.ToInt32(this.dataGridView_NewItem[this.iIndexLocation, 0].Value);
			if (num <= 511)
			{
				for (int i = 0; i < workingDGV.Columns.Count; i++)
				{
					workingDGV[i, num].Value = this.dataGridView_NewItem[i, 0].Value;
				}
				workingDGV.CurrentCell = workingDGV[this.iIndexLocation, num];
			}
		}

		// Token: 0x0600037B RID: 891 RVA: 0x0000F634 File Offset: 0x0000D834
		private void comboBox_ToGroup_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.isFinishedInit)
			{
				if (!this.isWorkingMainForm)
				{
					((Form1)base.Owner).tc_Items.SelectedIndex = this.comboBox_ToGroup.SelectedIndex;
				}
				this.dataGridView_NewItem[this.iIndexLocation - 1, 0].Value = this.comboBox_ToGroup.SelectedIndex;
			}
		}

		// Token: 0x0600037C RID: 892 RVA: 0x0000F69C File Offset: 0x0000D89C
		private void dataGridView_NewItem_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
		{
			DataGridView dataGridView = (DataGridView)sender;
			for (int i = 0; i < dataGridView.Columns.Count; i++)
			{
				dataGridView[i, e.RowIndex].Value = 0;
			}
		}

		// Token: 0x0600037E RID: 894 RVA: 0x0000F700 File Offset: 0x0000D900
		private void Form_BmdItemAddercs_Load(object sender, EventArgs e)
		{
			this.frmOwner = (Form1)base.Owner;
			switch (this.BMDType)
			{
			case 0:
				this.frmOwner.initializeItem_S6E3Grid(this.dataGridView_NewItem);
				this.iIndexLocation = 1;
				break;
			case 1:
				this.frmOwner.initializeItemEx700Grid(this.dataGridView_NewItem);
				this.iIndexLocation = 5;
				break;
			case 2:
				this.frmOwner.initializeItemEx700PlusGrid(this.dataGridView_NewItem);
				this.iIndexLocation = 5;
				break;
			case 3:
				this.frmOwner.initializeItemSeason8Episode1Grid(this.dataGridView_NewItem);
				this.iIndexLocation = 5;
				break;
			case 4:
				this.frmOwner.initializeITTGrid(this.dataGridView_NewItem);
				this.iIndexLocation = 1;
				break;
			case 5:
				this.frmOwner.initializeISTGrid(this.dataGridView_NewItem);
				this.iIndexLocation = 1;
				break;
			case 6:
				this.frmOwner.initializeIAOGrid(this.dataGridView_NewItem);
				this.iIndexLocation = 1;
				break;
			case 7:
				this.frmOwner.initializeJOHSGrid(this.dataGridView_NewItem);
				this.iIndexLocation = 1;
				break;
			}
			this.dataGridView_NewItem.Rows.Add();
			this.comboBox_ToGroup.SelectedIndex = 0;
			this.isFinishedInit = true;
			this.dataGridView_NewItem.Columns[this.iIndexLocation].ReadOnly = false;
			this.dataGridView_NewItem.Columns[this.iIndexLocation].DefaultCellStyle.BackColor = Color.White;
			this.dataGridView_NewItem.Columns[this.iIndexLocation - 1].ReadOnly = true;
			this.dataGridView_NewItem.Columns[this.iIndexLocation - 1].DefaultCellStyle.BackColor = Color.LightGray;
			this.dataGridView_NewItem.Dock = DockStyle.Fill;
		}

		// Token: 0x04000090 RID: 144
		private int BMDType;

		// Token: 0x04000095 RID: 149
		private Form1 frmOwner;

		// Token: 0x04000096 RID: 150
		private int iIndexLocation;

		// Token: 0x04000097 RID: 151
		private bool isFinishedInit;

		// Token: 0x04000098 RID: 152
		public bool isWorkingMainForm;
	}
}
