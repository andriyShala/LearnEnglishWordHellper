namespace WFA
{
    partial class AddIrWord
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 37);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(199, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Enter += new System.EventHandler(this.textBox3_Enter);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox4_KeyDown);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(217, 37);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(199, 20);
            this.textBox2.TabIndex = 1;
            this.textBox2.Enter += new System.EventHandler(this.textBox3_Enter);
            this.textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox4_KeyDown);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(422, 37);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(199, 20);
            this.textBox3.TabIndex = 2;
            this.textBox3.Enter += new System.EventHandler(this.textBox3_Enter);
            this.textBox3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox4_KeyDown);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(12, 11);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(199, 20);
            this.textBox4.TabIndex = 3;
            this.textBox4.Enter += new System.EventHandler(this.textBox4_Enter);
            this.textBox4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox4_KeyDown);
            // 
            // AddIrWord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 83);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddIrWord";
            this.Text = "AddIrWord";
            this.Load += new System.EventHandler(this.AddIrWord_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
    }
}