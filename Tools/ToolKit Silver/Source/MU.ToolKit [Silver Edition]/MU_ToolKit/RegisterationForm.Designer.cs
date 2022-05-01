namespace MU_ToolKit
{
	// Token: 0x02000008 RID: 8
	public partial class RegisterationForm : global::System.Windows.Forms.Form
	{
		// Token: 0x06000373 RID: 883 RVA: 0x0000EF99 File Offset: 0x0000D199
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000374 RID: 884 RVA: 0x0000EFB8 File Offset: 0x0000D1B8
		private void InitializeComponent()
		{
			this.label1 = new global::System.Windows.Forms.Label();
			this.textBox_HWID = new global::System.Windows.Forms.TextBox();
			this.textBox_Key = new global::System.Windows.Forms.TextBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.button_Activate = new global::System.Windows.Forms.Button();
			this.label3 = new global::System.Windows.Forms.Label();
			this.textBox_Name = new global::System.Windows.Forms.TextBox();
			this.label4 = new global::System.Windows.Forms.Label();
			this.textBox_Org = new global::System.Windows.Forms.TextBox();
			this.label5 = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(12, 65);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(77, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "Hardware ID:";
			this.textBox_HWID.Location = new global::System.Drawing.Point(111, 62);
			this.textBox_HWID.Name = "textBox_HWID";
			this.textBox_HWID.ReadOnly = true;
			this.textBox_HWID.Size = new global::System.Drawing.Size(254, 21);
			this.textBox_HWID.TabIndex = 0;
			this.textBox_HWID.Text = "XXXX-XXXX-XXXX-XXXX-XXXX-XXXX-XXXX-XXXX";
			this.textBox_Key.Location = new global::System.Drawing.Point(112, 134);
			this.textBox_Key.Name = "textBox_Key";
			this.textBox_Key.Size = new global::System.Drawing.Size(254, 21);
			this.textBox_Key.TabIndex = 3;
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(13, 137);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(113, 12);
			this.label2.TabIndex = 3;
			this.label2.Text = "Registeration Key:";
			this.button_Activate.Location = new global::System.Drawing.Point(15, 161);
			this.button_Activate.Name = "button_Activate";
			this.button_Activate.Size = new global::System.Drawing.Size(350, 31);
			this.button_Activate.TabIndex = 4;
			this.button_Activate.Text = "Activate";
			this.button_Activate.UseVisualStyleBackColor = true;
			this.button_Activate.Click += new global::System.EventHandler(this.button_Activate_Click);
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(13, 89);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(35, 12);
			this.label3.TabIndex = 6;
			this.label3.Text = "Name:";
			this.textBox_Name.Location = new global::System.Drawing.Point(112, 86);
			this.textBox_Name.Name = "textBox_Name";
			this.textBox_Name.Size = new global::System.Drawing.Size(254, 21);
			this.textBox_Name.TabIndex = 1;
			this.label4.AutoSize = true;
			this.label4.Location = new global::System.Drawing.Point(13, 113);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(59, 12);
			this.label4.TabIndex = 8;
			this.label4.Text = "Company: ";
			this.textBox_Org.Location = new global::System.Drawing.Point(112, 110);
			this.textBox_Org.Name = "textBox_Org";
			this.textBox_Org.Size = new global::System.Drawing.Size(254, 21);
			this.textBox_Org.TabIndex = 2;
			this.label5.AutoSize = true;
			this.label5.Font = new global::System.Drawing.Font("Segoe UI", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label5.Location = new global::System.Drawing.Point(33, 23);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(302, 21);
			this.label5.TabIndex = 9;
			this.label5.Text = "* Please enter your info and press Activate";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(378, 203);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.textBox_Org);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.textBox_Name);
			base.Controls.Add(this.button_Activate);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.textBox_Key);
			base.Controls.Add(this.textBox_HWID);
			base.Controls.Add(this.label1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "RegisterationForm";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MU.ToolKit Product Activation";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.RegisterationForm_FormClosing);
			base.Load += new global::System.EventHandler(this.RegisterationForm_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000084 RID: 132
		private global::System.Windows.Forms.Button button_Activate;

		// Token: 0x04000085 RID: 133
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000087 RID: 135
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000088 RID: 136
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000089 RID: 137
		private global::System.Windows.Forms.Label label3;

		// Token: 0x0400008A RID: 138
		private global::System.Windows.Forms.Label label4;

		// Token: 0x0400008B RID: 139
		private global::System.Windows.Forms.Label label5;

		// Token: 0x0400008C RID: 140
		private global::System.Windows.Forms.TextBox textBox_HWID;

		// Token: 0x0400008D RID: 141
		private global::System.Windows.Forms.TextBox textBox_Key;

		// Token: 0x0400008E RID: 142
		private global::System.Windows.Forms.TextBox textBox_Name;

		// Token: 0x0400008F RID: 143
		private global::System.Windows.Forms.TextBox textBox_Org;
	}
}
