namespace FolderViewer
{
    partial class FolderViewerForm
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
            this.ChooseFolderGroupBox = new System.Windows.Forms.GroupBox();
            this.ChooseFolderButton = new System.Windows.Forms.Button();
            this.FolderTextBox = new System.Windows.Forms.TextBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.HorizontalTabPage = new System.Windows.Forms.TabPage();
            this.VisualisingPanel = new System.Windows.Forms.Panel();
            this.VerticalTabPage = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.ChooseFolderGroupBox.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.HorizontalTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChooseFolderGroupBox
            // 
            this.ChooseFolderGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ChooseFolderGroupBox.Controls.Add(this.ChooseFolderButton);
            this.ChooseFolderGroupBox.Controls.Add(this.FolderTextBox);
            this.ChooseFolderGroupBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChooseFolderGroupBox.Location = new System.Drawing.Point(870, 634);
            this.ChooseFolderGroupBox.Name = "ChooseFolderGroupBox";
            this.ChooseFolderGroupBox.Size = new System.Drawing.Size(550, 51);
            this.ChooseFolderGroupBox.TabIndex = 1;
            this.ChooseFolderGroupBox.TabStop = false;
            this.ChooseFolderGroupBox.Text = "Choose a Folder";
            // 
            // ChooseFolderButton
            // 
            this.ChooseFolderButton.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ChooseFolderButton.FlatAppearance.BorderSize = 0;
            this.ChooseFolderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChooseFolderButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChooseFolderButton.ForeColor = System.Drawing.Color.Transparent;
            this.ChooseFolderButton.Location = new System.Drawing.Point(470, 18);
            this.ChooseFolderButton.Name = "ChooseFolderButton";
            this.ChooseFolderButton.Size = new System.Drawing.Size(75, 25);
            this.ChooseFolderButton.TabIndex = 1;
            this.ChooseFolderButton.Text = "Select";
            this.ChooseFolderButton.UseVisualStyleBackColor = false;
            this.ChooseFolderButton.Click += new System.EventHandler(this.SelectButton_Clicked);
            // 
            // FolderTextBox
            // 
            this.FolderTextBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FolderTextBox.Location = new System.Drawing.Point(6, 18);
            this.FolderTextBox.Name = "FolderTextBox";
            this.FolderTextBox.ReadOnly = true;
            this.FolderTextBox.Size = new System.Drawing.Size(458, 25);
            this.FolderTextBox.TabIndex = 0;
            this.FolderTextBox.Text = "Folder Path";
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.HorizontalTabPage);
            this.tabControl.Controls.Add(this.VerticalTabPage);
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.HotTrack = true;
            this.tabControl.Location = new System.Drawing.Point(12, 52);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1408, 564);
            this.tabControl.TabIndex = 3;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.VisualisingTabPage_Select);
            // 
            // HorizontalTabPage
            // 
            this.HorizontalTabPage.AutoScroll = true;
            this.HorizontalTabPage.BackColor = System.Drawing.Color.White;
            this.HorizontalTabPage.Controls.Add(this.VisualisingPanel);
            this.HorizontalTabPage.Location = new System.Drawing.Point(4, 26);
            this.HorizontalTabPage.Name = "HorizontalTabPage";
            this.HorizontalTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.HorizontalTabPage.Size = new System.Drawing.Size(1400, 534);
            this.HorizontalTabPage.TabIndex = 0;
            this.HorizontalTabPage.Text = "Horizontal";
            // 
            // VisualisingPanel
            // 
            this.VisualisingPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.VisualisingPanel.BackColor = System.Drawing.Color.White;
            this.VisualisingPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.VisualisingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VisualisingPanel.Location = new System.Drawing.Point(3, 3);
            this.VisualisingPanel.Name = "VisualisingPanel";
            this.VisualisingPanel.Size = new System.Drawing.Size(1394, 528);
            this.VisualisingPanel.TabIndex = 0;
            this.VisualisingPanel.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.VisualisingPanel_ZoomByButton);
            // 
            // VerticalTabPage
            // 
            this.VerticalTabPage.BackColor = System.Drawing.Color.White;
            this.VerticalTabPage.Location = new System.Drawing.Point(4, 26);
            this.VerticalTabPage.Name = "VerticalTabPage";
            this.VerticalTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.VerticalTabPage.Size = new System.Drawing.Size(1400, 534);
            this.VerticalTabPage.TabIndex = 1;
            this.VerticalTabPage.Text = "Vertical";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 30);
            this.label1.TabIndex = 4;
            this.label1.Text = "Visualize Your Folders!";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FolderViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1432, 697);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.ChooseFolderGroupBox);
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimumSize = new System.Drawing.Size(600, 315);
            this.Name = "FolderViewerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FolderViewer";
            this.ChooseFolderGroupBox.ResumeLayout(false);
            this.ChooseFolderGroupBox.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.HorizontalTabPage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox ChooseFolderGroupBox;
        private System.Windows.Forms.TextBox FolderTextBox;
        private System.Windows.Forms.Button ChooseFolderButton;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage HorizontalTabPage;
        private System.Windows.Forms.TabPage VerticalTabPage;
        private System.Windows.Forms.Panel VisualisingPanel;
        private System.Windows.Forms.Label label1;
    }
}

