namespace WFA
{
    partial class Form2
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.I = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Word = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Transcription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Translete = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.URL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBoxWord = new System.Windows.Forms.TextBox();
            this.textBoxTranscription = new System.Windows.Forms.TextBox();
            this.textBoxTranslate = new System.Windows.Forms.TextBox();
            this.textBoxColumn = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.I,
            this.Word,
            this.Transcription,
            this.Translete,
            this.columnHeader1,
            this.URL});
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.LabelEdit = true;
            this.listView1.Location = new System.Drawing.Point(0, 50);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1187, 418);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView1_KeyDown);
            // 
            // I
            // 
            this.I.Text = "I";
            this.I.Width = 46;
            // 
            // Word
            // 
            this.Word.Text = "Word";
            this.Word.Width = 300;
            // 
            // Transcription
            // 
            this.Transcription.Text = "Transcription";
            this.Transcription.Width = 288;
            // 
            // Translete
            // 
            this.Translete.Text = "Translete";
            this.Translete.Width = 333;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Percent";
            this.columnHeader1.Width = 131;
            // 
            // URL
            // 
            this.URL.Text = "URL";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(64, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(297, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(648, 11);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(372, 20);
            this.textBox2.TabIndex = 3;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.textBox2.Enter += new System.EventHandler(this.textBox2_Enter);
            this.textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
            // 
            // textBoxWord
            // 
            this.textBoxWord.Location = new System.Drawing.Point(55, 474);
            this.textBoxWord.Name = "textBoxWord";
            this.textBoxWord.Size = new System.Drawing.Size(289, 20);
            this.textBoxWord.TabIndex = 4;
            this.textBoxWord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxWord_KeyDown);
            // 
            // textBoxTranscription
            // 
            this.textBoxTranscription.Location = new System.Drawing.Point(351, 473);
            this.textBoxTranscription.Name = "textBoxTranscription";
            this.textBoxTranscription.Size = new System.Drawing.Size(284, 20);
            this.textBoxTranscription.TabIndex = 5;
            this.textBoxTranscription.TextChanged += new System.EventHandler(this.textBoxTranscription_TextChanged);
            this.textBoxTranscription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxWord_KeyDown);
            // 
            // textBoxTranslate
            // 
            this.textBoxTranslate.Location = new System.Drawing.Point(648, 475);
            this.textBoxTranslate.Name = "textBoxTranslate";
            this.textBoxTranslate.Size = new System.Drawing.Size(319, 20);
            this.textBoxTranslate.TabIndex = 6;
            this.textBoxTranslate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxWord_KeyDown);
            // 
            // textBoxColumn
            // 
            this.textBoxColumn.Location = new System.Drawing.Point(974, 474);
            this.textBoxColumn.Name = "textBoxColumn";
            this.textBoxColumn.Size = new System.Drawing.Size(58, 20);
            this.textBoxColumn.TabIndex = 7;
            this.textBoxColumn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxWord_KeyDown);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(1039, 473);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(148, 20);
            this.textBox3.TabIndex = 8;
            this.textBox3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxWord_KeyDown);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(2, 473);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(49, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "delete";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1187, 506);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBoxColumn);
            this.Controls.Add(this.textBoxTranslate);
            this.Controls.Add(this.textBoxTranscription);
            this.Controls.Add(this.textBoxWord);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listView1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Form2";
            this.Text = "Wi";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ColumnHeader Word;
        private System.Windows.Forms.ColumnHeader Transcription;
        private System.Windows.Forms.ColumnHeader Translete;
        private System.Windows.Forms.ColumnHeader I;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        public System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.TextBox textBoxWord;
        private System.Windows.Forms.TextBox textBoxTranscription;
        private System.Windows.Forms.TextBox textBoxTranslate;
        private System.Windows.Forms.TextBox textBoxColumn;
        public System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader URL;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button1;
    }
}