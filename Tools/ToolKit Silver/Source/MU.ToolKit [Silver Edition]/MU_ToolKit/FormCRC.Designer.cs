namespace MU_ToolKit
{
	// Token: 0x02000004 RID: 4
	public partial class FormCRC : global::System.Windows.Forms.Form
	{
		// Token: 0x0600000A RID: 10 RVA: 0x0000277E File Offset: 0x0000097E
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000027A0 File Offset: 0x000009A0
		private void InitializeComponent()
		{
			this.button_BrowseFile = new global::System.Windows.Forms.Button();
			this.label1 = new global::System.Windows.Forms.Label();
			this.textBox_CRC = new global::System.Windows.Forms.TextBox();
			base.SuspendLayout();
			this.button_BrowseFile.Location = new global::System.Drawing.Point(12, 11);
			this.button_BrowseFile.Name = "button_BrowseFile";
			this.button_BrowseFile.Size = new global::System.Drawing.Size(241, 30);
			this.button_BrowseFile.TabIndex = 0;
			this.button_BrowseFile.Text = "Browse a File";
			this.button_BrowseFile.UseVisualStyleBackColor = true;
			this.button_BrowseFile.Click += new global::System.EventHandler(this.button_BrowseFile_Click);
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(12, 50);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(65, 12);
			this.label1.TabIndex = 1;
			this.label1.Text = "CRC Value:";
			this.textBox_CRC.Location = new global::System.Drawing.Point(80, 47);
			this.textBox_CRC.Name = "textBox_CRC";
			this.textBox_CRC.ReadOnly = true;
			this.textBox_CRC.Size = new global::System.Drawing.Size(173, 21);
			this.textBox_CRC.TabIndex = 1;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(265, 77);
			base.Controls.Add(this.textBox_CRC);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.button_BrowseFile);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.MaximizeBox = false;
			base.Name = "FormCRC";
			base.ShowIcon = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MU CRC Calculator";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400000B RID: 11
		private global::System.Windows.Forms.Button button_BrowseFile;

		// Token: 0x0400000C RID: 12
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400000D RID: 13
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400000E RID: 14
		private global::System.Windows.Forms.TextBox textBox_CRC;
	}
}
