namespace A_8
{
    partial class FormAdmin_AddClassroom
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
            this.textBox_ClassName = new System.Windows.Forms.TextBox();
            this.label_className = new System.Windows.Forms.Label();
            this.textBox_Capacity = new System.Windows.Forms.TextBox();
            this.label_Capacity = new System.Windows.Forms.Label();
            this.label_Headline = new System.Windows.Forms.Label();
            this.button_AddClass = new System.Windows.Forms.Button();
            this.button_Back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_ClassName
            // 
            this.textBox_ClassName.Location = new System.Drawing.Point(82, 48);
            this.textBox_ClassName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_ClassName.Name = "textBox_ClassName";
            this.textBox_ClassName.Size = new System.Drawing.Size(96, 20);
            this.textBox_ClassName.TabIndex = 0;
            this.textBox_ClassName.TextChanged += new System.EventHandler(this.textBox_ClassName_TextChanged);
            this.textBox_ClassName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_ClassName_KeyPress);
            // 
            // label_className
            // 
            this.label_className.AutoSize = true;
            this.label_className.Location = new System.Drawing.Point(16, 50);
            this.label_className.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_className.Name = "label_className";
            this.label_className.Size = new System.Drawing.Size(60, 13);
            this.label_className.TabIndex = 1;
            this.label_className.Text = "class name";
            // 
            // textBox_Capacity
            // 
            this.textBox_Capacity.Enabled = false;
            this.textBox_Capacity.Location = new System.Drawing.Point(82, 75);
            this.textBox_Capacity.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_Capacity.Name = "textBox_Capacity";
            this.textBox_Capacity.Size = new System.Drawing.Size(96, 20);
            this.textBox_Capacity.TabIndex = 2;
            this.textBox_Capacity.TextChanged += new System.EventHandler(this.textBox_Capacity_TextChanged);
            this.textBox_Capacity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Capacity_KeyPress);
            // 
            // label_Capacity
            // 
            this.label_Capacity.AutoSize = true;
            this.label_Capacity.Location = new System.Drawing.Point(30, 77);
            this.label_Capacity.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Capacity.Name = "label_Capacity";
            this.label_Capacity.Size = new System.Drawing.Size(47, 13);
            this.label_Capacity.TabIndex = 3;
            this.label_Capacity.Text = "capacity";
            // 
            // label_Headline
            // 
            this.label_Headline.AutoSize = true;
            this.label_Headline.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label_Headline.Location = new System.Drawing.Point(57, 15);
            this.label_Headline.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Headline.Name = "label_Headline";
            this.label_Headline.Size = new System.Drawing.Size(81, 20);
            this.label_Headline.TabIndex = 4;
            this.label_Headline.Text = "Add Class";
            // 
            // button_AddClass
            // 
            this.button_AddClass.Enabled = false;
            this.button_AddClass.Location = new System.Drawing.Point(61, 112);
            this.button_AddClass.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_AddClass.Name = "button_AddClass";
            this.button_AddClass.Size = new System.Drawing.Size(77, 30);
            this.button_AddClass.TabIndex = 5;
            this.button_AddClass.Text = "Add Class";
            this.button_AddClass.UseVisualStyleBackColor = true;
            this.button_AddClass.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_Back
            // 
            this.button_Back.BackgroundImage = global::A_8.Properties.Resources.back_key_assistant_menu_in_Galaxy_S4_Android_Kitkat;
            this.button_Back.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Back.Location = new System.Drawing.Point(153, 10);
            this.button_Back.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_Back.Name = "button_Back";
            this.button_Back.Size = new System.Drawing.Size(34, 32);
            this.button_Back.TabIndex = 6;
            this.button_Back.UseVisualStyleBackColor = true;
            this.button_Back.Click += new System.EventHandler(this.button_Back_Click);
            // 
            // FormAdmin_AddClassroom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(205, 160);
            this.Controls.Add(this.button_Back);
            this.Controls.Add(this.button_AddClass);
            this.Controls.Add(this.label_Headline);
            this.Controls.Add(this.label_Capacity);
            this.Controls.Add(this.textBox_Capacity);
            this.Controls.Add(this.label_className);
            this.Controls.Add(this.textBox_ClassName);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormAdmin_AddClassroom";
            this.Text = "AddClassroom";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAdminAddClassroom_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_ClassName;
        private System.Windows.Forms.Label label_className;
        private System.Windows.Forms.TextBox textBox_Capacity;
        private System.Windows.Forms.Label label_Capacity;
        private System.Windows.Forms.Label label_Headline;
        private System.Windows.Forms.Button button_AddClass;
        private System.Windows.Forms.Button button_Back;
    }
}