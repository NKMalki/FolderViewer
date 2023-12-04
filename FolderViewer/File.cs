using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderViewer
{
    public class File : IDocument
    {
        private string _fileName;
        private long _fileSize;
        private string _fileExtension;
        public File(string fileName, long fileSize, string fileExtension)
        {
            this._fileName = fileName;
            this._fileSize = fileSize;
            this._fileExtension = fileExtension;
        }

        public long CalculateSize()
        {
            return _fileSize;
        }

        public string GetFileName()
        {
            return _fileName;
        }
        
        public List<IDocument> GetChildren()
        {
            throw new Exception("file does not have children");
        }

        public void addDocument(IDocument document)
        {
            throw new Exception("file cannot add a document");
        }
    }
}
