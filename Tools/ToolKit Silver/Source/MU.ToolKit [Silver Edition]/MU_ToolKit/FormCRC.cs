using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MU_ToolKit
{
	// Token: 0x02000004 RID: 4
	public partial class FormCRC : Form
	{
		// Token: 0x06000007 RID: 7 RVA: 0x000026B4 File Offset: 0x000008B4
		public FormCRC()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000026C4 File Offset: 0x000008C4
		private void button_BrowseFile_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				byte[] data = File.ReadAllBytes(openFileDialog.FileName);
				this.textBox_CRC.Text = "0x" + this.ComputeCRC(data).ToString("X");
			}
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002718 File Offset: 0x00000918
		private long ComputeCRC(byte[] data)
		{
			long num = 0L;
			foreach (byte b in data)
			{
				byte b2 = b;
				num ^= (long)((long)b2 << 8);
				for (int j = 0; j < 8; j++)
				{
					if ((num & 32768L) == 32768L)
					{
						num = (num << 1 ^ 270611557L);
					}
					else
					{
						num <<= 1;
					}
				}
			}
			return num & unchecked((long)(unchecked((ulong)-1)));
		}
	}
}
