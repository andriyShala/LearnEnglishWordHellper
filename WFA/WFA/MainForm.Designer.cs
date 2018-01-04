namespace WFA
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLoadLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fIleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultPerCentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findAndAddNewWordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getTrainingWordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.errorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.errorFix1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findErrorWordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.errorFix2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trainingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trainingBadLearnWordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.trainingFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
            this.ErrorlistView = new System.Windows.Forms.ListView();
            this.Word = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.FilelistBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.WordslistView = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLoadLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 475);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1001, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLoadLabel
            // 
            this.toolStripStatusLoadLabel.Name = "toolStripStatusLoadLabel";
            this.toolStripStatusLoadLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fIleToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.errorToolStripMenuItem,
            this.trainingToolStripMenuItem,
            this.toolStripTextBox1,
            this.toolStripTextBox2});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1001, 27);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // fIleToolStripMenuItem
            // 
            this.fIleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNewFileToolStripMenuItem,
            this.renameFileToolStripMenuItem,
            this.defaultPerCentToolStripMenuItem,
            this.findAndAddNewWordToolStripMenuItem});
            this.fIleToolStripMenuItem.Name = "fIleToolStripMenuItem";
            this.fIleToolStripMenuItem.Size = new System.Drawing.Size(37, 23);
            this.fIleToolStripMenuItem.Text = "FIle";
            // 
            // createNewFileToolStripMenuItem
            // 
            this.createNewFileToolStripMenuItem.Name = "createNewFileToolStripMenuItem";
            this.createNewFileToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.createNewFileToolStripMenuItem.Text = "Create New File";
            this.createNewFileToolStripMenuItem.Click += new System.EventHandler(this.createNewFileToolStripMenuItem_Click);
            // 
            // renameFileToolStripMenuItem
            // 
            this.renameFileToolStripMenuItem.Name = "renameFileToolStripMenuItem";
            this.renameFileToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.renameFileToolStripMenuItem.Text = "Rename File";
            // 
            // defaultPerCentToolStripMenuItem
            // 
            this.defaultPerCentToolStripMenuItem.Name = "defaultPerCentToolStripMenuItem";
            this.defaultPerCentToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.defaultPerCentToolStripMenuItem.Text = "Default PerCent";
            this.defaultPerCentToolStripMenuItem.Click += new System.EventHandler(this.defaultPerCentToolStripMenuItem_Click);
            // 
            // findAndAddNewWordToolStripMenuItem
            // 
            this.findAndAddNewWordToolStripMenuItem.Name = "findAndAddNewWordToolStripMenuItem";
            this.findAndAddNewWordToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.findAndAddNewWordToolStripMenuItem.Text = "Find and Add New word";
            this.findAndAddNewWordToolStripMenuItem.Click += new System.EventHandler(this.findAndAddNewWordToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.getTrainingWordToolStripMenuItem,
            this.sadToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 23);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // getTrainingWordToolStripMenuItem
            // 
            this.getTrainingWordToolStripMenuItem.Name = "getTrainingWordToolStripMenuItem";
            this.getTrainingWordToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.getTrainingWordToolStripMenuItem.Text = "GetTrainingWord";
            this.getTrainingWordToolStripMenuItem.Click += new System.EventHandler(this.getTrainingWordToolStripMenuItem_Click);
            // 
            // sadToolStripMenuItem
            // 
            this.sadToolStripMenuItem.Name = "sadToolStripMenuItem";
            this.sadToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.sadToolStripMenuItem.Text = "sad";
            this.sadToolStripMenuItem.Click += new System.EventHandler(this.sadToolStripMenuItem_Click);
            // 
            // errorToolStripMenuItem
            // 
            this.errorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.errorFix1ToolStripMenuItem,
            this.findErrorWordsToolStripMenuItem,
            this.errorFix2ToolStripMenuItem});
            this.errorToolStripMenuItem.Name = "errorToolStripMenuItem";
            this.errorToolStripMenuItem.Size = new System.Drawing.Size(44, 23);
            this.errorToolStripMenuItem.Text = "Error";
            // 
            // errorFix1ToolStripMenuItem
            // 
            this.errorFix1ToolStripMenuItem.Name = "errorFix1ToolStripMenuItem";
            this.errorFix1ToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.errorFix1ToolStripMenuItem.Text = "ErrorFix1";
            this.errorFix1ToolStripMenuItem.Click += new System.EventHandler(this.errorFix1ToolStripMenuItem_Click);
            // 
            // findErrorWordsToolStripMenuItem
            // 
            this.findErrorWordsToolStripMenuItem.Name = "findErrorWordsToolStripMenuItem";
            this.findErrorWordsToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.findErrorWordsToolStripMenuItem.Text = "Find Error Words";
            this.findErrorWordsToolStripMenuItem.Click += new System.EventHandler(this.findErrorWordsToolStripMenuItem_Click);
            // 
            // errorFix2ToolStripMenuItem
            // 
            this.errorFix2ToolStripMenuItem.Name = "errorFix2ToolStripMenuItem";
            this.errorFix2ToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.errorFix2ToolStripMenuItem.Text = "ErrorFix2";
            this.errorFix2ToolStripMenuItem.Click += new System.EventHandler(this.errorFix2ToolStripMenuItem_Click);
            // 
            // trainingToolStripMenuItem
            // 
            this.trainingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trainingBadLearnWordsToolStripMenuItem,
            this.toolStripSeparator1,
            this.trainingFileToolStripMenuItem});
            this.trainingToolStripMenuItem.Name = "trainingToolStripMenuItem";
            this.trainingToolStripMenuItem.Size = new System.Drawing.Size(63, 23);
            this.trainingToolStripMenuItem.Text = "Training";
            // 
            // trainingBadLearnWordsToolStripMenuItem
            // 
            this.trainingBadLearnWordsToolStripMenuItem.Name = "trainingBadLearnWordsToolStripMenuItem";
            this.trainingBadLearnWordsToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.trainingBadLearnWordsToolStripMenuItem.Text = "Training BadLearn Words";
            this.trainingBadLearnWordsToolStripMenuItem.Click += new System.EventHandler(this.trainingBadLearnWordsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(204, 6);
            // 
            // trainingFileToolStripMenuItem
            // 
            this.trainingFileToolStripMenuItem.Name = "trainingFileToolStripMenuItem";
            this.trainingFileToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.trainingFileToolStripMenuItem.Text = "Training File";
            this.trainingFileToolStripMenuItem.Click += new System.EventHandler(this.trainingFileToolStripMenuItem_Click);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripTextBox1_KeyDown);
            this.toolStripTextBox1.Click += new System.EventHandler(this.toolStripTextBox1_Click);
            this.toolStripTextBox1.TextChanged += new System.EventHandler(this.toolStripTextBox1_TextChanged);
            // 
            // toolStripTextBox2
            // 
            this.toolStripTextBox2.Name = "toolStripTextBox2";
            this.toolStripTextBox2.ReadOnly = true;
            this.toolStripTextBox2.Size = new System.Drawing.Size(100, 23);
            // 
            // ErrorlistView
            // 
            this.ErrorlistView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ErrorlistView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Word});
            this.ErrorlistView.Location = new System.Drawing.Point(725, 44);
            this.ErrorlistView.Name = "ErrorlistView";
            this.ErrorlistView.Size = new System.Drawing.Size(264, 394);
            this.ErrorlistView.TabIndex = 2;
            this.ErrorlistView.UseCompatibleStateImageBehavior = false;
            this.ErrorlistView.View = System.Windows.Forms.View.Details;
            // 
            // Word
            // 
            this.Word.Text = "Word";
            this.Word.Width = 247;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.YellowGreen;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(734, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 22);
            this.label1.TabIndex = 3;
            this.label1.Text = "Error LIst";
            // 
            // FilelistBox
            // 
            this.FilelistBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.FilelistBox.FormattingEnabled = true;
            this.FilelistBox.Location = new System.Drawing.Point(12, 44);
            this.FilelistBox.Name = "FilelistBox";
            this.FilelistBox.ScrollAlwaysVisible = true;
            this.FilelistBox.Size = new System.Drawing.Size(235, 394);
            this.FilelistBox.TabIndex = 4;
            this.FilelistBox.TabStop = false;
            this.FilelistBox.SelectedIndexChanged += new System.EventHandler(this.FilelistBox_SelectedIndexChanged);
            this.FilelistBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FilelistBox_MouseDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.YellowGreen;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(21, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 22);
            this.label2.TabIndex = 5;
            this.label2.Text = "File LIst";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(13, 444);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Let\'s exercise";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // WordslistView
            // 
            this.WordslistView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WordslistView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4});
            this.WordslistView.FullRowSelect = true;
            this.WordslistView.Location = new System.Drawing.Point(253, 44);
            this.WordslistView.Name = "WordslistView";
            this.WordslistView.Size = new System.Drawing.Size(466, 394);
            this.WordslistView.TabIndex = 7;
            this.WordslistView.UseCompatibleStateImageBehavior = false;
            this.WordslistView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Index";
            this.columnHeader3.Width = 40;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Word";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Translete";
            this.columnHeader2.Width = 178;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Try";
            this.columnHeader4.Width = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.YellowGreen;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(263, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 22);
            this.label3.TabIndex = 8;
            this.label3.Text = "Words LIst";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(725, 443);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(264, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Fix";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(450, 444);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(272, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "ShowDetails";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button4.Location = new System.Drawing.Point(253, 443);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(191, 23);
            this.button4.TabIndex = 11;
            this.button4.Text = "AddWord";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button5.Location = new System.Drawing.Point(125, 443);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(122, 23);
            this.button5.TabIndex = 12;
            this.button5.Text = "Let\'s exercise Ua";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(1001, 497);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.WordslistView);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FilelistBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ErrorlistView);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fIleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createNewFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ListView ErrorlistView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox FilelistBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView WordslistView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader Word;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ToolStripMenuItem defaultPerCentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem errorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem errorFix1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findErrorWordsToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLoadLabel;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripMenuItem trainingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trainingBadLearnWordsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem trainingFileToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripMenuItem errorFix2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox2;
        private System.Windows.Forms.ToolStripMenuItem getTrainingWordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findAndAddNewWordToolStripMenuItem;
    }
}