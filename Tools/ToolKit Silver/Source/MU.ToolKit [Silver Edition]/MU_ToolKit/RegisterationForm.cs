using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace MU_ToolKit
{
	// Token: 0x02000008 RID: 8
	public partial class RegisterationForm : Form
	{
		// Token: 0x06000371 RID: 881 RVA: 0x0000EEFC File Offset: 0x0000D0FC
		public RegisterationForm()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000372 RID: 882 RVA: 0x0000EF0C File Offset: 0x0000D10C
		private void button_Activate_Click(object sender, EventArgs e)
		{
			StringBuilder stringBuilder = new StringBuilder(500)
			{
				Length = 0
			};
			stringBuilder.Append(string.Concat(new string[]
			{
				this.textBox_Name.Text,
				",",
				this.textBox_Org.Text,
				",0,",
				this.textBox_Key.Text
			}));
			if (RegisterationForm.Kernel32.GetEnvironmentVariable("WLRegSmartKeyInstallToRegistry", stringBuilder, 500))
			{
				this.isActivated = true;
				Application.Restart();
			}
		}

		// Token: 0x06000375 RID: 885 RVA: 0x0000F541 File Offset: 0x0000D741
		private void RegisterationForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!this.isActivated)
			{
				Environment.Exit(0);
			}
		}

		// Token: 0x06000376 RID: 886 RVA: 0x0000F554 File Offset: 0x0000D754
		private void RegisterationForm_Load(object sender, EventArgs e)
		{
			StringBuilder stringBuilder = new StringBuilder(100);
			RegisterationForm.Kernel32.GetEnvironmentVariable("WLHardwareGetID", stringBuilder, 100);
			this.textBox_HWID.Text = stringBuilder.ToString();
		}

		// Token: 0x04000086 RID: 134
		private bool isActivated;

		// Token: 0x02000009 RID: 9
		private class Kernel32
		{
			// Token: 0x06000377 RID: 887
			[DllImport("Kernel32.dll", CallingConvention = CallingConvention.StdCall)]
			public static extern bool GetEnvironmentVariable(string lpName, StringBuilder lpBuffer, int nSize);
		}
	}
}
