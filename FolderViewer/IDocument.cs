using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderViewer
{
    public interface IDocument
    {
        bool Equals(IDocument other);
        long CalculateSize();
        void addDocument(IDocument document);
        List<IDocument> GetChildren();
        string GetDocName();
    }
}