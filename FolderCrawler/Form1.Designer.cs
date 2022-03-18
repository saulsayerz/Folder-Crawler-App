using System.Windows.Forms;

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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.graphPanel = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.toggleButton1 = new FolderCrawler.Controls.ToggleButton();
            this.DFS_optButton = new FolderCrawler.Controls.OptionButton();
            this.BFS_optButton = new FolderCrawler.Controls.OptionButton();
            this.searchButton = new FolderCrawler.Controls.CustomButton();
            this.folderButton = new FolderCrawler.Controls.CustomButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(215, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Starting Directory :";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(215, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "None Selected";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(180, 228);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Path";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Select Search Mode";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(381, 118);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(283, 22);
            this.textBox1.TabIndex = 9;
            this.textBox1.Text = "Example.jpg";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(381, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "File To Find :";
            // 
            // graphPanel
            // 
            this.graphPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.graphPanel.Location = new System.Drawing.Point(593, 307);
            this.graphPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.graphPanel.Name = "graphPanel";
            this.graphPanel.Size = new System.Drawing.Size(630, 336);
            this.graphPanel.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(879, 274);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Search Tree";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(381, 175);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 16);
            this.label7.TabIndex = 17;
            this.label7.Text = "Find All Occurence";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(27, 307);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(541, 335);
            this.flowLayoutPanel1.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(251, 274);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 16);
            this.label8.TabIndex = 19;
            this.label8.Text = "Found Links";
            // 
            // toggleButton1
            // 
            this.toggleButton1.AutoSize = true;
            this.toggleButton1.Location = new System.Drawing.Point(543, 170);
            this.toggleButton1.Margin = new System.Windows.Forms.Padding(4);
            this.toggleButton1.MinimumSize = new System.Drawing.Size(60, 27);
            this.toggleButton1.Name = "toggleButton1";
            this.toggleButton1.OffBackColor = System.Drawing.Color.Gray;
            this.toggleButton1.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.toggleButton1.OnBackColor = System.Drawing.Color.DodgerBlue;
            this.toggleButton1.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.toggleButton1.Size = new System.Drawing.Size(111, 27);
            this.toggleButton1.SolidStyle = true;
            this.toggleButton1.TabIndex = 16;
            this.toggleButton1.Text = "toggleButton1";
            this.toggleButton1.UseVisualStyleBackColor = true;
            // 
            // DFS_optButton
            // 
            this.DFS_optButton.AutoSize = true;
            this.DFS_optButton.CheckedColor = System.Drawing.Color.MediumSlateBlue;
            this.DFS_optButton.Location = new System.Drawing.Point(16, 166);
            this.DFS_optButton.Margin = new System.Windows.Forms.Padding(4);
            this.DFS_optButton.MinimumSize = new System.Drawing.Size(93, 25);
            this.DFS_optButton.Name = "DFS_optButton";
            this.DFS_optButton.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.DFS_optButton.Size = new System.Drawing.Size(93, 25);
            this.DFS_optButton.TabIndex = 15;
            this.DFS_optButton.Text = "DFS";
            this.DFS_optButton.UnCheckedColor = System.Drawing.Color.DodgerBlue;
            this.DFS_optButton.UseVisualStyleBackColor = true;
            // 
            // BFS_optButton
            // 
            this.BFS_optButton.AutoSize = true;
            this.BFS_optButton.Checked = true;
            this.BFS_optButton.CheckedColor = System.Drawing.Color.SlateBlue;
            this.BFS_optButton.Location = new System.Drawing.Point(16, 128);
            this.BFS_optButton.Margin = new System.Windows.Forms.Padding(4);
            this.BFS_optButton.MinimumSize = new System.Drawing.Size(93, 25);
            this.BFS_optButton.Name = "BFS_optButton";
            this.BFS_optButton.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.BFS_optButton.Size = new System.Drawing.Size(93, 25);
            this.BFS_optButton.TabIndex = 14;
            this.BFS_optButton.TabStop = true;
            this.BFS_optButton.Text = "BFS";
            this.BFS_optButton.UnCheckedColor = System.Drawing.Color.DodgerBlue;
            this.BFS_optButton.UseVisualStyleBackColor = true;
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.Color.White;
            this.searchButton.BorderColor = System.Drawing.Color.DodgerBlue;
            this.searchButton.BorderRadius = 30;
            this.searchButton.BorderSize = 2;
            this.searchButton.FlatAppearance.BorderSize = 0;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.ForeColor = System.Drawing.Color.RoyalBlue;
            this.searchButton.Location = new System.Drawing.Point(12, 212);
            this.searchButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(151, 47);
            this.searchButton.TabIndex = 3;
            this.searchButton.Text = "Find File";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // folderButton
            // 
            this.folderButton.BackColor = System.Drawing.Color.White;
            this.folderButton.BorderColor = System.Drawing.Color.DodgerBlue;
            this.folderButton.BorderRadius = 30;
            this.folderButton.BorderSize = 2;
            this.folderButton.FlatAppearance.BorderSize = 0;
            this.folderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.folderButton.ForeColor = System.Drawing.Color.RoyalBlue;
            this.folderButton.Location = new System.Drawing.Point(12, 20);
            this.folderButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.folderButton.Name = "folderButton";
            this.folderButton.Size = new System.Drawing.Size(151, 47);
            this.folderButton.TabIndex = 0;
            this.folderButton.Text = "Choose Start Folder";
            this.folderButton.UseVisualStyleBackColor = false;
            this.folderButton.Click += new System.EventHandler(this.folderButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1339, 654);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.toggleButton1);
            this.Controls.Add(this.DFS_optButton);
            this.Controls.Add(this.BFS_optButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.graphPanel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.folderButton);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
        private Label label4;
        private TextBox textBox1;
        private Label label5;
        private Panel graphPanel;
        private Label label6;
        private Controls.OptionButton BFS_optButton;
        private Controls.OptionButton DFS_optButton;
        private Controls.ToggleButton toggleButton1;
        private Label label7;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label8;
    }
}