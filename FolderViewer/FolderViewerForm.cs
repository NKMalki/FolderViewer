using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderViewer
{
    public partial class FolderViewerForm : Form
    {
        public FolderViewerForm()
        {
            InitializeComponent();
            
        }

        private void SelectButton_Clicked(object sender, EventArgs e)
        {
            string path_of_folder;
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                path_of_folder = fbd.SelectedPath;
           
                if (!(result == DialogResult.OK && !string.IsNullOrWhiteSpace(path_of_folder)))
                {
                    MessageBox.Show("Something went wrong!");             
                }
            }

            FolderTextBox.Text = path_of_folder;
            IDocument folder = this.TraverseStructure(path_of_folder);
            
        }
        public IDocument TraverseStructure(string path)
        {
            return DocumentFactory.CreateDocument(path);
        }
        public void VisualizeStructure()
        {
            throw new NotImplementedException();
        }
    }
}