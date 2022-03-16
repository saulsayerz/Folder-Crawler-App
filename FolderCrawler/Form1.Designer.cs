namespace FolderCrawler
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.folderButton = new FolderCrawler.Controls.CustomButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.searchButton = new FolderCrawler.Controls.CustomButton();
            this.label3 = new System.Windows.Forms.Label();
            this.optionButton1 = new FolderCrawler.Controls.OptionButton();
            this.optionButton2 = new FolderCrawler.Controls.OptionButton();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.graphPanel = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.customButton1 = new FolderCrawler.Controls.CustomButton();
            this.SuspendLayout();
            // 
            // folderButton
            // 
            this.folderButton.BackColor = System.Drawing.Color.White;
            this.folderButton.BorderColor = System.Drawing.Color.DodgerBlue;
            this.folderButton.BorderRadius = 40;
            this.folderButton.BorderSize = 3;
            this.folderButton.FlatAppearance.BorderSize = 0;
            this.folderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.folderButton.ForeColor = System.Drawing.Color.RoyalBlue;
            this.folderButton.Location = new System.Drawing.Point(12, 31);
            this.folderButton.Name = "folderButton";
            this.folderButton.Size = new System.Drawing.Size(134, 50);
            this.folderButton.TabIndex = 0;
            this.folderButton.Text = "Choose Start Folder";
            this.folderButton.UseVisualStyleBackColor = false;
            this.folderButton.Click += new System.EventHandler(this.folderButton_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(174, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Starting Directory :";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(174, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "None Selected";
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.Color.White;
            this.searchButton.BorderColor = System.Drawing.Color.DodgerBlue;
            this.searchButton.BorderRadius = 40;
            this.searchButton.BorderSize = 3;
            this.searchButton.FlatAppearance.BorderSize = 0;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.ForeColor = System.Drawing.Color.RoyalBlue;
            this.searchButton.Location = new System.Drawing.Point(12, 225);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(134, 50);
            this.searchButton.TabIndex = 3;
            this.searchButton.Text = "Find File";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(186, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Path";
            // 
            // optionButton1
            // 
            this.optionButton1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.optionButton1.AutoSize = true;
            this.optionButton1.CheckedColor = System.Drawing.Color.MediumSlateBlue;
            this.optionButton1.Location = new System.Drawing.Point(24, 143);
            this.optionButton1.MinimumSize = new System.Drawing.Size(0, 21);
            this.optionButton1.Name = "optionButton1";
            this.optionButton1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.optionButton1.Size = new System.Drawing.Size(63, 24);
            this.optionButton1.TabIndex = 5;
            this.optionButton1.TabStop = true;
            this.optionButton1.Text = "BFS";
            this.optionButton1.UnCheckedColor = System.Drawing.Color.DeepSkyBlue;
            this.optionButton1.UseVisualStyleBackColor = true;
            this.optionButton1.CheckedChanged += new System.EventHandler(this.optionButton1_CheckedChanged);
            // 
            // optionButton2
            // 
            this.optionButton2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.optionButton2.AutoSize = true;
            this.optionButton2.CheckedColor = System.Drawing.Color.MediumSlateBlue;
            this.optionButton2.Location = new System.Drawing.Point(24, 180);
            this.optionButton2.MinimumSize = new System.Drawing.Size(0, 21);
            this.optionButton2.Name = "optionButton2";
            this.optionButton2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.optionButton2.Size = new System.Drawing.Size(65, 24);
            this.optionButton2.TabIndex = 6;
            this.optionButton2.TabStop = true;
            this.optionButton2.Text = "DFS";
            this.optionButton2.UnCheckedColor = System.Drawing.Color.DeepSkyBlue;
            this.optionButton2.UseVisualStyleBackColor = true;
            this.optionButton2.CheckedChanged += new System.EventHandler(this.optionButton2_CheckedChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Select Search Mode";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(382, 147);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(283, 27);
            this.textBox1.TabIndex = 9;
            this.textBox1.Text = "Example.jpg";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(382, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "File To Find :";
            // 
            // graphPanel
            // 
            this.graphPanel.Location = new System.Drawing.Point(249, 335);
            this.graphPanel.Name = "graphPanel";
            this.graphPanel.Size = new System.Drawing.Size(715, 392);
            this.graphPanel.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(564, 302);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Search Tree";
            // 
            // customButton1
            // 
            this.customButton1.BackColor = System.Drawing.Color.White;
            this.customButton1.BorderColor = System.Drawing.Color.DodgerBlue;
            this.customButton1.BorderRadius = 40;
            this.customButton1.BorderSize = 3;
            this.customButton1.FlatAppearance.BorderSize = 0;
            this.customButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.customButton1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.customButton1.Location = new System.Drawing.Point(12, 464);
            this.customButton1.Name = "customButton1";
            this.customButton1.Size = new System.Drawing.Size(134, 50);
            this.customButton1.TabIndex = 13;
            this.customButton1.Text = "Test";
            this.customButton1.UseVisualStyleBackColor = false;
            this.customButton1.Click += new System.EventHandler(this.customButton1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1153, 750);
            this.Controls.Add(this.customButton1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.graphPanel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.optionButton2);
            this.Controls.Add(this.optionButton1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.folderButton);
            this.Name = "Form1";
            this.Text = "FolderCrawler";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.CustomButton folderButton;
        private Label label1;
        private Label label2;
        private Controls.CustomButton searchButton;
        private Label label3;
        private Controls.OptionButton optionButton1;
        private Controls.OptionButton optionButton2;
        private Label label4;
        private TextBox textBox1;
        private Label label5;
        private Panel graphPanel;
        private Label label6;
        private Controls.CustomButton customButton1;
    }
}