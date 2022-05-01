namespace MU_ToolKit
{
	// Token: 0x02000024 RID: 36
	public partial class MyDialog : global::System.Windows.Forms.Form
	{
		// Token: 0x0600048A RID: 1162 RVA: 0x0001EFAF File Offset: 0x0001D1AF
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600048B RID: 1163 RVA: 0x0001EFD0 File Offset: 0x0001D1D0
		private void InitializeComponent()
		{
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.linkLabel_Download = new global::System.Windows.Forms.LinkLabel();
			this.label_ProductVer = new global::System.Windows.Forms.Label();
			this.label_NewVer = new global::System.Windows.Forms.Label();
			this.pictureBox2 = new global::System.Windows.Forms.PictureBox();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Segoe UI", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.Location = new global::System.Drawing.Point(127, 12);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(119, 17);
			this.label1.TabIndex = 2;
			this.label1.Text = "Your Version............";
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Segoe UI", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.Location = new global::System.Drawing.Point(127, 40);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(121, 17);
			this.label2.TabIndex = 3;
			this.label2.Text = "Required Version....";
			this.linkLabel_Download.AutoSize = true;
			this.linkLabel_Download.Font = new global::System.Drawing.Font("Segoe UI", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.linkLabel_Download.Location = new global::System.Drawing.Point(161, 69);
			this.linkLabel_Download.Name = "linkLabel_Download";
			this.linkLabel_Download.Size = new global::System.Drawing.Size(163, 17);
			this.linkLabel_Download.TabIndex = 4;
			this.linkLabel_Download.TabStop = true;
			this.linkLabel_Download.Text = ">> Click here to Get it! <<";
			this.linkLabel_Download.LinkClicked += new global::System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_Download_LinkClicked);
			this.label_ProductVer.AutoSize = true;
			this.label_ProductVer.Font = new global::System.Drawing.Font("Segoe UI", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label_ProductVer.ForeColor = global::System.Drawing.Color.SteelBlue;
			this.label_ProductVer.Location = new global::System.Drawing.Point(245, 12);
			this.label_ProductVer.Name = "label_ProductVer";
			this.label_ProductVer.Size = new global::System.Drawing.Size(43, 17);
			this.label_ProductVer.TabIndex = 5;
			this.label_ProductVer.Text = "label3";
			this.label_NewVer.AutoSize = true;
			this.label_NewVer.Font = new global::System.Drawing.Font("Segoe UI", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label_NewVer.ForeColor = global::System.Drawing.Color.DarkRed;
			this.label_NewVer.Location = new global::System.Drawing.Point(245, 40);
			this.label_NewVer.Name = "label_NewVer";
			this.label_NewVer.Size = new global::System.Drawing.Size(43, 17);
			this.label_NewVer.TabIndex = 6;
			this.label_NewVer.Text = "label4";
			this.pictureBox2.BackColor = global::System.Drawing.Color.Gainsboro;
			this.pictureBox2.Location = new global::System.Drawing.Point(-1, 100);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new global::System.Drawing.Size(353, 50);
			this.pictureBox2.TabIndex = 1;
			this.pictureBox2.TabStop = false;
			this.pictureBox1.BackgroundImage = Properties.Resources.pictureBox1_BackgroundImage;
			this.pictureBox1.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Zoom;
			this.pictureBox1.Location = new global::System.Drawing.Point(12, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(100, 71);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.WhiteSmoke;
			base.ClientSize = new global::System.Drawing.Size(349, 148);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.label_NewVer);
			base.Controls.Add(this.label_ProductVer);
			base.Controls.Add(this.linkLabel_Download);
			base.Controls.Add(this.pictureBox2);
			base.Controls.Add(this.pictureBox1);
			this.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "MyDialog";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Unsupported Version Detected";
			base.TopMost = true;
			base.Load += new global::System.EventHandler(this.MyDialog_Load);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000240 RID: 576
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000241 RID: 577
		private global::System.Windows.Forms.Label label_NewVer;

		// Token: 0x04000242 RID: 578
		private global::System.Windows.Forms.Label label_ProductVer;

		// Token: 0x04000243 RID: 579
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000244 RID: 580
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000246 RID: 582
		private global::System.Windows.Forms.LinkLabel linkLabel_Download;

		// Token: 0x04000247 RID: 583
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x04000248 RID: 584
		private global::System.Windows.Forms.PictureBox pictureBox2;
	}
}
