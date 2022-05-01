using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MU_ToolKit
{
	// Token: 0x02000003 RID: 3
	public partial class Form_Search : Form
	{
		// Token: 0x06000002 RID: 2 RVA: 0x000020E4 File Offset: 0x000002E4
		public Form_Search()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002108 File Offset: 0x00000308
		private void button_Find_Click(object sender, EventArgs e)
		{
			if (this.radioButton_FindDown.Checked)
			{
				this.f_main.FindNextValue(this.comboBox_SearchIn.Text, this.textBox_SearchFor.Text);
				return;
			}
			this.f_main.FindPreviousValue(this.comboBox_SearchIn.Text, this.textBox_SearchFor.Text);
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002184 File Offset: 0x00000384
		private void Form_Search_Load(object sender, EventArgs e)
		{
			this.f_main.AddColumnsToComboBox(ref this.comboBox_SearchIn);
			if (this.comboBox_SearchIn.Items.Count > 0)
			{
				this.comboBox_SearchIn.SelectedIndex = 0;
			}
		}

		// Token: 0x04000004 RID: 4
		private Form1 f_main = (Form1)Application.OpenForms[0];
	}
}
