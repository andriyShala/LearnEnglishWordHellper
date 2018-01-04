namespace WFA
{
    partial class Wordscoach
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
            this.AnswerTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.QuestionTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TransactionTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.PromptTextBox = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelAmount = new System.Windows.Forms.ToolStripStatusLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AnswerTextBox
            // 
            this.AnswerTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AnswerTextBox.Location = new System.Drawing.Point(59, 85);
            this.AnswerTextBox.Name = "AnswerTextBox";
            this.AnswerTextBox.Size = new System.Drawing.Size(595, 31);
            this.AnswerTextBox.TabIndex = 2;
            this.AnswerTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AnswerTextBox_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Answer";
            // 
            // QuestionTextBox
            // 
            this.QuestionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.QuestionTextBox.Location = new System.Drawing.Point(59, 12);
            this.QuestionTextBox.Name = "QuestionTextBox";
            this.QuestionTextBox.ReadOnly = true;
            this.QuestionTextBox.Size = new System.Drawing.Size(258, 31);
            this.QuestionTextBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Question";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(323, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Transaction";
            // 
            // TransactionTextBox
            // 
            this.TransactionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TransactionTextBox.Location = new System.Drawing.Point(392, 12);
            this.TransactionTextBox.Name = "TransactionTextBox";
            this.TransactionTextBox.ReadOnly = true;
            this.TransactionTextBox.Size = new System.Drawing.Size(262, 31);
            this.TransactionTextBox.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Prompt";
            // 
            // PromptTextBox
            // 
            this.PromptTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PromptTextBox.Location = new System.Drawing.Point(59, 49);
            this.PromptTextBox.Name = "PromptTextBox";
            this.PromptTextBox.ReadOnly = true;
            this.PromptTextBox.Size = new System.Drawing.Size(506, 31);
            this.PromptTextBox.TabIndex = 9;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabelAmount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 123);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(666, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(580, 16);
            this.toolStripProgressBar1.Step = 1;
            this.toolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(24, 17);
            this.toolStripStatusLabel1.Text = "0/0";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(12, 17);
            this.toolStripStatusLabel2.Text = "/";
            // 
            // toolStripStatusLabelAmount
            // 
            this.toolStripStatusLabelAmount.Name = "toolStripStatusLabelAmount";
            this.toolStripStatusLabelAmount.Size = new System.Drawing.Size(13, 17);
            this.toolStripStatusLabelAmount.Text = "0";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(571, 49);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 30);
            this.button1.TabIndex = 11;
            this.button1.Text = "Play";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Wordscoach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 145);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.PromptTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TransactionTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.QuestionTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AnswerTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Wordscoach";
            this.Text = "Wordscoach";
            this.Load += new System.EventHandler(this.Wordscoach_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox AnswerTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox QuestionTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TransactionTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox PromptTextBox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelAmount;
    }
}