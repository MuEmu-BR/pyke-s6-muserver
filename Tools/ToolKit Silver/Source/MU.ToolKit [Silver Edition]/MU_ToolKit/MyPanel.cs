using System;
using System.Windows.Forms;

namespace MU_ToolKit
{
	// Token: 0x02000002 RID: 2
	public class MyPanel : Panel
	{
		// Token: 0x06000001 RID: 1 RVA: 0x000020D0 File Offset: 0x000002D0
		public MyPanel()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}
	}
}
