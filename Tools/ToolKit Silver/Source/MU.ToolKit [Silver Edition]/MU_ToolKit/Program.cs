using System;
using System.Windows.Forms;

namespace MU_ToolKit
{
	// Token: 0x02000023 RID: 35
	internal static class Program
	{
		// Token: 0x06000488 RID: 1160 RVA: 0x0001EF6C File Offset: 0x0001D16C
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}
	}
}
