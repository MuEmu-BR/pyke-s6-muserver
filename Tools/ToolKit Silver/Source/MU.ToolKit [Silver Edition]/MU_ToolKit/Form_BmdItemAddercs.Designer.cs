namespace MU_ToolKit
{
	// Token: 0x0200000A RID: 10
	public partial class Form_BmdItemAddercs : global::System.Windows.Forms.Form
	{
		// Token: 0x0600037D RID: 893 RVA: 0x0000F6DE File Offset: 0x0000D8DE
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600037F RID: 895 RVA: 0x0000F8E0 File Offset: 0x0000DAE0
		private void InitializeComponent()
		{
			this.dataGridView_NewItem = new global::System.Windows.Forms.DataGridView();
			this.label1 = new global::System.Windows.Forms.Label();
			this.comboBox_ToGroup = new global::System.Windows.Forms.ComboBox();
			this.button_InsertItem = new global::System.Windows.Forms.Button();
			this.panel1 = new global::System.Windows.Forms.Panel();
			((global::System.ComponentModel.ISupportInitialize)this.dataGridView_NewItem).BeginInit();
			this.panel1.SuspendLayout();
			base.SuspendLayout();
			this.dataGridView_NewItem.AllowUserToAddRows = false;
			this.dataGridView_NewItem.AllowUserToDeleteRows = false;
			this.dataGridView_NewItem.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView_NewItem.Location = new global::System.Drawing.Point(13, 16);
			this.dataGridView_NewItem.Name = "dataGridView_NewItem";
			this.dataGridView_NewItem.Size = new global::System.Drawing.Size(198, 37);
			this.dataGridView_NewItem.TabIndex = 0;
			this.dataGridView_NewItem.RowsAdded += new global::System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView_NewItem_RowsAdded);
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(6, 111);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(47, 12);
			this.label1.TabIndex = 1;
			this.label1.Text = "Add to:";
			this.comboBox_ToGroup.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_ToGroup.FormattingEnabled = true;
			this.comboBox_ToGroup.Items.AddRange(new object[]
			{
				"Swords",
				"Axes",
				"Maces/Scapters",
				"Spears",
				"Bows/Crosswobs",
				"Staffs/Sticks",
				"Shields",
				"Helms",
				"Armors",
				"Pants",
				"Gloves",
				"Boots",
				"Wings/Other",
				"Misc 1",
				"Misc 2",
				"Scrolls"
			});
			this.comboBox_ToGroup.Location = new global::System.Drawing.Point(53, 107);
			this.comboBox_ToGroup.Name = "comboBox_ToGroup";
			this.comboBox_ToGroup.Size = new global::System.Drawing.Size(158, 20);
			this.comboBox_ToGroup.TabIndex = 2;
			this.comboBox_ToGroup.SelectedIndexChanged += new global::System.EventHandler(this.comboBox_ToGroup_SelectedIndexChanged);
			this.button_InsertItem.Location = new global::System.Drawing.Point(217, 95);
			this.button_InsertItem.Name = "button_InsertItem";
			this.button_InsertItem.Size = new global::System.Drawing.Size(563, 41);
			this.button_InsertItem.TabIndex = 3;
			this.button_InsertItem.Text = "Insert Item";
			this.button_InsertItem.UseVisualStyleBackColor = true;
			this.button_InsertItem.Click += new global::System.EventHandler(this.button_InsertItem_Click);
			this.panel1.Controls.Add(this.dataGridView_NewItem);
			this.panel1.Location = new global::System.Drawing.Point(4, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(776, 86);
			this.panel1.TabIndex = 4;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(785, 139);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.button_InsertItem);
			base.Controls.Add(this.comboBox_ToGroup);
			base.Controls.Add(this.label1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "Form_BmdItemAddercs";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Item Adder";
			base.TopMost = true;
			base.Load += new global::System.EventHandler(this.Form_BmdItemAddercs_Load);
			((global::System.ComponentModel.ISupportInitialize)this.dataGridView_NewItem).EndInit();
			this.panel1.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000091 RID: 145
		private global::System.Windows.Forms.Button button_InsertItem;

		// Token: 0x04000092 RID: 146
		public global::System.Windows.Forms.ComboBox comboBox_ToGroup;

		// Token: 0x04000093 RID: 147
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000094 RID: 148
		private global::System.Windows.Forms.DataGridView dataGridView_NewItem;

		// Token: 0x04000099 RID: 153
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400009A RID: 154
		private global::System.Windows.Forms.Panel panel1;
	}
}
