using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace MU_ToolKit
{
	// Token: 0x0200002C RID: 44
	public partial class Form_About : Form
	{
		// Token: 0x0600062A RID: 1578 RVA: 0x0007C468 File Offset: 0x0007A668
		public Form_About()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600062C RID: 1580 RVA: 0x0007C498 File Offset: 0x0007A698
		private void Form_About_Load(object sender, EventArgs e)
		{
			StringBuilder stringBuilder = new StringBuilder(100);
			StringBuilder stringBuilder2 = new StringBuilder(500);
			if (Form_About.Kernel32.GetEnvironmentVariable("WLHardwareGetID", stringBuilder, 100))
			{
				this.textBox_cHWID.Text = stringBuilder.ToString();
			}
			if (Form_About.Kernel32.GetEnvironmentVariable("WLRegGetLicenseInfo", stringBuilder2, 500))
			{
				string[] array = stringBuilder2.ToString().Split(new char[]
				{
					','
				});
				this.textBox_cName.Text = array[0].TrimStart(new char[]
				{
					' '
				});
				this.textBox_cCompany.Text = array[1].TrimStart(new char[]
				{
					' '
				});
			}
		}

		// Token: 0x0200002D RID: 45
		private class Kernel32
		{
			// Token: 0x0600062E RID: 1582
			[DllImport("Kernel32.dll", CallingConvention = CallingConvention.StdCall)]
			public static extern bool GetEnvironmentVariable(string lpName, StringBuilder lpBuffer, int nSize);
		}
	}
}
