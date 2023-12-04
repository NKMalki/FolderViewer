using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderViewer
{
    public class Folder : IDocument
    {
        private string _folderName;
        private List<IDocument> _documents;

        public Folder(string folderName)
        {
            _folderName = folderName;
            _documents = new List<IDocument>();
        }
        
        public long CalculateSize()
        {
            return _documents.Sum(doc => doc.CalculateSize());
        }

        public string GetFolderName()
        {
            return _folderName;
        }

        public void addDocument(IDocument document)
        {
            _documents.Add(document);
        }

        public List<IDocument> GetChildren()
        {
            return _documents;
        }
    }
}