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
            this.FolderVisualisingPanel = new System.Windows.Forms.Panel();
            this.ChooseFolderGroupBox = new System.Windows.Forms.GroupBox();
            this.ChooseFolderButton = new System.Windows.Forms.Button();
            this.FolderTextBox = new System.Windows.Forms.TextBox();
            this.folderPictureBox = new System.Windows.Forms.PictureBox();
            this.FolderVisualisingPanel.SuspendLayout();
            this.ChooseFolderGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.folderPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // FolderVisualisingPanel
            // 
            this.FolderVisualisingPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FolderVisualisingPanel.BackColor = System.Drawing.Color.White;
            this.FolderVisualisingPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FolderVisualisingPanel.Controls.Add(this.folderPictureBox);
            this.FolderVisualisingPanel.Location = new System.Drawing.Point(12, 40);
            this.FolderVisualisingPanel.Name = "FolderVisualisingPanel";
            this.FolderVisualisingPanel.Size = new System.Drawing.Size(1080, 520);
            this.FolderVisualisingPanel.TabIndex = 0;
            // 
            // ChooseFolderGroupBox
            // 
            this.ChooseFolderGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ChooseFolderGroupBox.Controls.Add(this.ChooseFolderButton);
            this.ChooseFolderGroupBox.Controls.Add(this.FolderTextBox);
            this.ChooseFolderGroupBox.Location = new System.Drawing.Point(542, 581);
            this.ChooseFolderGroupBox.Name = "ChooseFolderGroupBox";
            this.ChooseFolderGroupBox.Size = new System.Drawing.Size(550, 44);
            this.ChooseFolderGroupBox.TabIndex = 1;
            this.ChooseFolderGroupBox.TabStop = false;
            this.ChooseFolderGroupBox.Text = "Choose a Folder";
            // 
            // ChooseFolderButton
            // 
            this.ChooseFolderButton.Location = new System.Drawing.Point(470, 15);
            this.ChooseFolderButton.Name = "ChooseFolderButton";
            this.ChooseFolderButton.Size = new System.Drawing.Size(75, 23);
            this.ChooseFolderButton.TabIndex = 1;
            this.ChooseFolderButton.Text = "Select";
            this.ChooseFolderButton.UseVisualStyleBackColor = true;
            this.ChooseFolderButton.Click += new System.EventHandler(this.SelectButton_Clicked);
            // 
            // FolderTextBox
            // 
            this.FolderTextBox.Location = new System.Drawing.Point(6, 15);
            this.FolderTextBox.Name = "FolderTextBox";
            this.FolderTextBox.ReadOnly = true;
            this.FolderTextBox.Size = new System.Drawing.Size(429, 20);
            this.FolderTextBox.TabIndex = 0;
            this.FolderTextBox.Text = "Folder Path";
            // 
            // folderPictureBox
            // 
            this.folderPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.folderPictureBox.Location = new System.Drawing.Point(-1, -1);
            this.folderPictureBox.Name = "folderPictureBox";
            this.folderPictureBox.Size = new System.Drawing.Size(1080, 520);
            this.folderPictureBox.TabIndex = 0;
            this.folderPictureBox.TabStop = false;
            // 
            // FolderViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1104, 651);
            this.Controls.Add(this.ChooseFolderGroupBox);
            this.Controls.Add(this.FolderVisualisingPanel);
            this.MaximumSize = new System.Drawing.Size(1600, 840);
            this.MinimumSize = new System.Drawing.Size(600, 315);
            this.Name = "FolderViewerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Folder Viewer";
            this.FolderVisualisingPanel.ResumeLayout(false);
            this.ChooseFolderGroupBox.ResumeLayout(false);
            this.ChooseFolderGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.folderPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel FolderVisualisingPanel;
        private System.Windows.Forms.GroupBox ChooseFolderGroupBox;
        private System.Windows.Forms.TextBox FolderTextBox;
        private System.Windows.Forms.Button ChooseFolderButton;
        private System.Windows.Forms.PictureBox folderPictureBox;
    }
}

