namespace WFA
{
    partial class Form4
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
            this.textBoxQvestion = new System.Windows.Forms.TextBox();
            this.textBoxAnswer = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxQvestion
            // 
            this.textBoxQvestion.Location = new System.Drawing.Point(12, 12);
            this.textBoxQvestion.Name = "textBoxQvestion";
            this.textBoxQvestion.ReadOnly = true;
            this.textBoxQvestion.Size = new System.Drawing.Size(445, 20);
            this.textBoxQvestion.TabIndex = 0;
            // 
            // textBoxAnswer
            // 
            this.textBoxAnswer.Font = new System.Drawing.Font("MV Boli", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxAnswer.Location = new System.Drawing.Point(12, 38);
            this.textBoxAnswer.Name = "textBoxAnswer";
            this.textBoxAnswer.ReadOnly = true;
            this.textBoxAnswer.Size = new System.Drawing.Size(445, 51);
            this.textBoxAnswer.TabIndex = 1;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 162);
            this.Controls.Add(this.textBoxAnswer);
            this.Controls.Add(this.textBoxQvestion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form4";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxQvestion;
        private System.Windows.Forms.TextBox textBoxAnswer;
    }
}