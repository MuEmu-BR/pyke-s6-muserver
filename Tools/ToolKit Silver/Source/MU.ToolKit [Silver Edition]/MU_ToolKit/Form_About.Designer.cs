using MU_ToolKit.Properties;

namespace MU_ToolKit
{
	// Token: 0x0200002C RID: 44
	public partial class Form_About : global::System.Windows.Forms.Form
	{
		// Token: 0x0600062B RID: 1579 RVA: 0x0007C476 File Offset: 0x0007A676
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600062D RID: 1581 RVA: 0x0007C54C File Offset: 0x0007A74C
		private void InitializeComponent()
		{
			this.label1 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.textBox_cHWID = new global::System.Windows.Forms.TextBox();
			this.textBox_cCompany = new global::System.Windows.Forms.TextBox();
			this.textBox_cName = new global::System.Windows.Forms.TextBox();
			this.label6 = new global::System.Windows.Forms.Label();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.groupBox1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.BackColor = global::System.Drawing.Color.Transparent;
			this.label1.Font = new global::System.Drawing.Font("Segoe UI", 15f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.Black;
			this.label1.Location = new global::System.Drawing.Point(61, 17);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(243, 28);
			this.label1.TabIndex = 0;
			this.label1.Text = "MU.ToolKit [Silver Edition]";
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(10, 71);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(35, 12);
			this.label3.TabIndex = 2;
			this.label3.Text = "HWID:";
			this.label4.AutoSize = true;
			this.label4.Location = new global::System.Drawing.Point(10, 23);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(35, 12);
			this.label4.TabIndex = 3;
			this.label4.Text = "Name:";
			this.label5.AutoSize = true;
			this.label5.Location = new global::System.Drawing.Point(10, 47);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(53, 12);
			this.label5.TabIndex = 4;
			this.label5.Text = "Company:";
			this.groupBox1.Controls.Add(this.textBox_cHWID);
			this.groupBox1.Controls.Add(this.textBox_cCompany);
			this.groupBox1.Controls.Add(this.textBox_cName);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Location = new global::System.Drawing.Point(12, 55);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(333, 101);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "This copy is Licensed to:";
			this.textBox_cHWID.Location = new global::System.Drawing.Point(70, 68);
			this.textBox_cHWID.Name = "textBox_cHWID";
			this.textBox_cHWID.ReadOnly = true;
			this.textBox_cHWID.Size = new global::System.Drawing.Size(254, 21);
			this.textBox_cHWID.TabIndex = 8;
			this.textBox_cHWID.Text = "XXXX-XXXX-XXXX-XXXX-XXXX-XXXX-XXXX-XXXX";
			this.textBox_cCompany.Location = new global::System.Drawing.Point(70, 44);
			this.textBox_cCompany.Name = "textBox_cCompany";
			this.textBox_cCompany.ReadOnly = true;
			this.textBox_cCompany.Size = new global::System.Drawing.Size(254, 21);
			this.textBox_cCompany.TabIndex = 7;
			this.textBox_cCompany.Text = "XXXX-XXXX-XXXX-XXXX-XXXX-XXXX-XXXX-XXXX";
			this.textBox_cName.Location = new global::System.Drawing.Point(70, 20);
			this.textBox_cName.Name = "textBox_cName";
			this.textBox_cName.ReadOnly = true;
			this.textBox_cName.Size = new global::System.Drawing.Size(254, 21);
			this.textBox_cName.TabIndex = 6;
			this.textBox_cName.Text = "XXXX-XXXX-XXXX-XXXX-XXXX-XXXX-XXXX-XXXX";
			this.label6.AutoSize = true;
			this.label6.Font = new global::System.Drawing.Font("Segoe UI", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label6.Location = new global::System.Drawing.Point(18, 170);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(326, 19);
			this.label6.TabIndex = 7;
			this.label6.Text = "MU.ToolKit is coded and developed by © TopReal.IT\r\n";
			this.pictureBox1.BackgroundImage = Resources.pictureBox1_BackgroundImage;
			this.pictureBox1.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Stretch;
			this.pictureBox1.Location = new global::System.Drawing.Point(118, 199);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(113, 57);
			this.pictureBox1.TabIndex = 8;
			this.pictureBox1.TabStop = false;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.SystemColors.Control;
			base.ClientSize = new global::System.Drawing.Size(359, 272);
			base.Controls.Add(this.pictureBox1);
			base.Controls.Add(this.label6);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.label1);
			this.ForeColor = global::System.Drawing.Color.Black;
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "Form_About";
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "About";
			base.Load += new global::System.EventHandler(this.Form_About_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000536 RID: 1334
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000537 RID: 1335
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x04000538 RID: 1336
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000539 RID: 1337
		private global::System.Windows.Forms.Label label3;

		// Token: 0x0400053A RID: 1338
		private global::System.Windows.Forms.Label label4;

		// Token: 0x0400053B RID: 1339
		private global::System.Windows.Forms.Label label5;

		// Token: 0x0400053C RID: 1340
		private global::System.Windows.Forms.Label label6;

		// Token: 0x0400053D RID: 1341
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x0400053E RID: 1342
		private global::System.Windows.Forms.TextBox textBox_cCompany;

		// Token: 0x0400053F RID: 1343
		private global::System.Windows.Forms.TextBox textBox_cHWID;

		// Token: 0x04000540 RID: 1344
		private global::System.Windows.Forms.TextBox textBox_cName;
	}
}
