namespace A_8
{
    partial class FormAdminViewErros
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxFrom = new System.Windows.Forms.TextBox();
            this.listViewTitle = new System.Windows.Forms.ListView();
            this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button_ClearList = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(431, 47);
            this.textBoxDescription.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ReadOnly = true;
            this.textBoxDescription.Size = new System.Drawing.Size(583, 282);
            this.textBoxDescription.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(427, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "From:";
            // 
            // textBoxFrom
            // 
            this.textBoxFrom.Location = new System.Drawing.Point(479, 15);
            this.textBoxFrom.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxFrom.Name = "textBoxFrom";
            this.textBoxFrom.ReadOnly = true;
            this.textBoxFrom.Size = new System.Drawing.Size(535, 22);
            this.textBoxFrom.TabIndex = 4;
            // 
            // listViewTitle
            // 
            this.listViewTitle.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Title});
            this.listViewTitle.FullRowSelect = true;
            this.listViewTitle.GridLines = true;
            this.listViewTitle.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewTitle.Location = new System.Drawing.Point(16, 15);
            this.listViewTitle.Margin = new System.Windows.Forms.Padding(4);
            this.listViewTitle.MultiSelect = false;
            this.listViewTitle.Name = "listViewTitle";
            this.listViewTitle.Size = new System.Drawing.Size(392, 314);
            this.listViewTitle.TabIndex = 5;
            this.listViewTitle.UseCompatibleStateImageBehavior = false;
            this.listViewTitle.View = System.Windows.Forms.View.Details;
            this.listViewTitle.SelectedIndexChanged += new System.EventHandler(this.listViewTitle_SelectedIndexChanged_1);
            this.listViewTitle.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewTitle_MouseClick);
            // 
            // Title
            // 
            this.Title.Text = "Title";
            this.Title.Width = 291;
            // 
            // button_ClearList
            // 
            this.button_ClearList.Location = new System.Drawing.Point(430, 346);
            this.button_ClearList.Name = "button_ClearList";
            this.button_ClearList.Size = new System.Drawing.Size(163, 54);
            this.button_ClearList.TabIndex = 6;
            this.button_ClearList.Text = "Delete all messages";
            this.button_ClearList.UseVisualStyleBackColor = true;
            this.button_ClearList.Click += new System.EventHandler(this.button_ClearList_Click);
            // 
            // FormAdminViewErros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 427);
            this.Controls.Add(this.button_ClearList);
            this.Controls.Add(this.listViewTitle);
            this.Controls.Add(this.textBoxFrom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxDescription);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormAdminViewErros";
            this.Text = "FormAdminViewErros";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAdminViewErros_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxFrom;
        private System.Windows.Forms.ListView listViewTitle;
        private System.Windows.Forms.ColumnHeader Title;
        private System.Windows.Forms.Button button_ClearList;
    }
}