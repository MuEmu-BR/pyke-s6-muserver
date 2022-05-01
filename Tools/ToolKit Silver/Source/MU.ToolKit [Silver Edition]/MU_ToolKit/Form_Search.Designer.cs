namespace MU_ToolKit
{
	// Token: 0x02000003 RID: 3
	public partial class Form_Search : global::System.Windows.Forms.Form
	{
		// Token: 0x06000004 RID: 4 RVA: 0x00002165 File Offset: 0x00000365
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000021B8 File Offset: 0x000003B8
		private void InitializeComponent()
		{
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.comboBox_SearchIn = new global::System.Windows.Forms.ComboBox();
			this.textBox_SearchFor = new global::System.Windows.Forms.TextBox();
			this.button_Find = new global::System.Windows.Forms.Button();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.radioButton_FindDown = new global::System.Windows.Forms.RadioButton();
			this.radioButton_FindUp = new global::System.Windows.Forms.RadioButton();
			this.groupBox1.SuspendLayout();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(8, 10);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(65, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "Find what:";
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(8, 34);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(65, 12);
			this.label2.TabIndex = 1;
			this.label2.Text = "In Column:";
			this.comboBox_SearchIn.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_SearchIn.FormattingEnabled = true;
			this.comboBox_SearchIn.Location = new global::System.Drawing.Point(70, 31);
			this.comboBox_SearchIn.Name = "comboBox_SearchIn";
			this.comboBox_SearchIn.Size = new global::System.Drawing.Size(179, 20);
			this.comboBox_SearchIn.TabIndex = 1;
			this.textBox_SearchFor.Location = new global::System.Drawing.Point(70, 7);
			this.textBox_SearchFor.Name = "textBox_SearchFor";
			this.textBox_SearchFor.Size = new global::System.Drawing.Size(179, 21);
			this.textBox_SearchFor.TabIndex = 0;
			this.button_Find.Location = new global::System.Drawing.Point(363, 10);
			this.button_Find.Name = "button_Find";
			this.button_Find.Size = new global::System.Drawing.Size(102, 43);
			this.button_Find.TabIndex = 4;
			this.button_Find.Text = "Find Next";
			this.button_Find.UseVisualStyleBackColor = true;
			this.button_Find.Click += new global::System.EventHandler(this.button_Find_Click);
			this.groupBox1.Controls.Add(this.radioButton_FindDown);
			this.groupBox1.Controls.Add(this.radioButton_FindUp);
			this.groupBox1.Location = new global::System.Drawing.Point(255, 7);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(102, 46);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Direction";
			this.radioButton_FindDown.AutoSize = true;
			this.radioButton_FindDown.Checked = true;
			this.radioButton_FindDown.Location = new global::System.Drawing.Point(47, 19);
			this.radioButton_FindDown.Name = "radioButton_FindDown";
			this.radioButton_FindDown.Size = new global::System.Drawing.Size(47, 16);
			this.radioButton_FindDown.TabIndex = 3;
			this.radioButton_FindDown.TabStop = true;
			this.radioButton_FindDown.Text = "Down";
			this.radioButton_FindDown.UseVisualStyleBackColor = true;
			this.radioButton_FindUp.AutoSize = true;
			this.radioButton_FindUp.Location = new global::System.Drawing.Point(8, 19);
			this.radioButton_FindUp.Name = "radioButton_FindUp";
			this.radioButton_FindUp.Size = new global::System.Drawing.Size(35, 16);
			this.radioButton_FindUp.TabIndex = 2;
			this.radioButton_FindUp.TabStop = true;
			this.radioButton_FindUp.Text = "Up";
			this.radioButton_FindUp.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(477, 64);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.button_Find);
			base.Controls.Add(this.textBox_SearchFor);
			base.Controls.Add(this.comboBox_SearchIn);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "Form_Search";
			base.Opacity = 0.8;
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Find";
			base.TopMost = true;
			base.Load += new global::System.EventHandler(this.Form_Search_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000001 RID: 1
		private global::System.Windows.Forms.Button button_Find;

		// Token: 0x04000002 RID: 2
		private global::System.Windows.Forms.ComboBox comboBox_SearchIn;

		// Token: 0x04000003 RID: 3
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000005 RID: 5
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x04000006 RID: 6
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000007 RID: 7
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000008 RID: 8
		private global::System.Windows.Forms.RadioButton radioButton_FindDown;

		// Token: 0x04000009 RID: 9
		private global::System.Windows.Forms.RadioButton radioButton_FindUp;

		// Token: 0x0400000A RID: 10
		private global::System.Windows.Forms.TextBox textBox_SearchFor;
	}
}
