using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderViewer
{
    internal class DocumentFactory
    {
        public static IDocument CreateDocument(string path)
        {
            string folderName = new DirectoryInfo(path).Name;
            IDocument folder = new Folder(folderName);
            string[] docs = Directory.GetFileSystemEntries(path);
            IDocument innerDocument;
            foreach (string doc in docs)
            {
                FileInfo docInfo = new FileInfo(doc);
                if (docInfo.Exists)
                {
                    innerDocument = new File(docInfo.Name, docInfo.Length, docInfo.Extension);
                }
                else
                {
                    innerDocument = CreateDocument(docInfo.FullName);
                }
                folder.addDocument(innerDocument);
            }
            return folder;
        }
    }
}
