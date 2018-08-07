namespace A_8
{
    partial class FormStudent_ViewChanges
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
            this.label2 = new System.Windows.Forms.Label();
            this.listViewTitle = new System.Windows.Forms.ListView();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.label_description = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 13);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Titles";
            // 
            // listViewTitle
            // 
            this.listViewTitle.Location = new System.Drawing.Point(32, 36);
            this.listViewTitle.Margin = new System.Windows.Forms.Padding(4);
            this.listViewTitle.Name = "listViewTitle";
            this.listViewTitle.Size = new System.Drawing.Size(232, 244);
            this.listViewTitle.TabIndex = 10;
            this.listViewTitle.UseCompatibleStateImageBehavior = false;
            this.listViewTitle.View = System.Windows.Forms.View.List;
            this.listViewTitle.SelectedIndexChanged += new System.EventHandler(this.listViewTitle_SelectedIndexChanged);
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(272, 36);
            this.textBoxDescription.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ReadOnly = true;
            this.textBoxDescription.Size = new System.Drawing.Size(465, 244);
            this.textBoxDescription.TabIndex = 7;
            this.textBoxDescription.TextChanged += new System.EventHandler(this.textBoxDescription_TextChanged);
            // 
            // label_description
            // 
            this.label_description.AutoSize = true;
            this.label_description.Location = new System.Drawing.Point(272, 13);
            this.label_description.Name = "label_description";
            this.label_description.Size = new System.Drawing.Size(79, 17);
            this.label_description.TabIndex = 12;
            this.label_description.Text = "Description";
            // 
            // FormStudent_ViewChanges
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 313);
            this.Controls.Add(this.label_description);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listViewTitle);
            this.Controls.Add(this.textBoxDescription);
            this.Name = "FormStudent_ViewChanges";
            this.Text = "FormStudent_ViewChanges";
            this.Load += new System.EventHandler(this.FormStudent_ViewChanges_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listViewTitle;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label label_description;
    }
}