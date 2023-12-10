using System;
using System.Collections.Generic;
using System.Drawing;

namespace FolderViewer
{
    public class DocumentNode
    {
        public float X {  get; set; }
        public float Y { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public float Mod {  get; set; }

        private IDocument _document;
        private DocumentNode _parent;
        private List<DocumentNode> _children;
        public DocumentNode(IDocument document, DocumentNode parent)
        {
            _document = document;
            _parent = parent;
            _children = new List<DocumentNode>();
        }

        public DocumentNode GetParent()
        {
            return _parent;
        }

        public List<DocumentNode> GetChildren() 
        {
            return _children; 
        }

        public void AddChild(DocumentNode child)
        {
            _children.Add(child);
        }

        public bool IsLeaf()
        {
            return _children.Count == 0;
            
        }

        public bool IsLeftMost()
        {
            if (this._parent == null)
                return true;

            return this._parent._children[0].GetDocument().Equals(this.GetDocument());
        }

        
        public bool IsRightMost()
        {
            if (this._parent == null)
                return true;
            return this._parent._children[this._parent._children.Count - 1].GetDocument().Equals(this.GetDocument());
        }

        public DocumentNode GetPreviousSibling()
        {
            if (this._parent == null || this.IsLeftMost())
                return null;

            return this._parent._children[this._parent._children.IndexOf(this) - 1];
        }

        public DocumentNode GetNextSibling()
        {
            if (this._parent == null || this.IsRightMost())
                return null;

            return this._parent._children[this._parent._children.IndexOf(this) + 1];
        }

        public DocumentNode GetLeftMostSibling()
        {
            if (this._parent == null)
                return null;

            if (this.IsLeftMost())
                return this;

            return this._parent._children[0];
        }

        public DocumentNode GetLeftMostChild()
        {
            if (this._children.Count == 0)
                return null;

            return this._children[0];
        }

        public DocumentNode GetRightMostChild()
        {
            if (this._children.Count == 0)
                return null;

            return this._children[_children.Count - 1];
        }

        public IDocument GetDocument()
        {
            return _document;
        }

        public string GetName()
        {
            return _document.GetDocName();
        }

        public static DocumentNode CreateStructure(string path)
        {
            IDocument rootDoc = DocumentFactory.CreateDocument(path);
            DocumentNode rootNode = new DocumentNode(rootDoc, null);
            return DocumentNode.CreateStructure(rootNode);
        }

        private static DocumentNode CreateStructure(DocumentNode node)
        {
            if (node.GetDocument().GetChildren() == null)
            {
                return node;
            }
            foreach(IDocument childDoc in node.GetDocument().GetChildren())
            {
                DocumentNode childNode = new DocumentNode(childDoc, node);
                node.AddChild(childNode);
                DocumentNode.CreateStructure(childNode);
            }
            return node;
        }
    }
}
