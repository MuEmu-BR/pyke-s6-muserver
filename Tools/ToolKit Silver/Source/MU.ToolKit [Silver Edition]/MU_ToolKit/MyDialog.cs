using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using MU_ToolKit.Properties;

namespace MU_ToolKit
{
	// Token: 0x02000024 RID: 36
	public partial class MyDialog : Form
	{
		// Token: 0x06000489 RID: 1161 RVA: 0x0001EF83 File Offset: 0x0001D183
		public MyDialog(string NewVersion, string Location)
		{
			this.InitializeComponent();
			this.label_NewVer.Text = NewVersion;
			this.Link = Location;
		}

		// Token: 0x0600048C RID: 1164 RVA: 0x0001F51B File Offset: 0x0001D71B
		private void linkLabel_Download_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(this.Link);
			base.Close();
		}

		// Token: 0x0600048D RID: 1165 RVA: 0x0001F52F File Offset: 0x0001D72F
		private void MyDialog_Load(object sender, EventArgs e)
		{
			new SoundPlayer(Resources.notify).Play();
			this.label_ProductVer.Text = "v" + base.ProductVersion;
		}

		// Token: 0x04000245 RID: 581
		private string Link = string.Empty;
	}
}
