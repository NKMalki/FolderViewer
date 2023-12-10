using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FolderViewer
{
    public partial class FolderViewerForm : Form
    {
        private DocumentNode _docTree;
        private int nodeHeight;
        private int nodeWidth;
        private float fontSize;
        private const int NODE_MARGIN_X = 50;
        private const int NODE_MARGIN_Y = 20;
        private float zoom = 1.0f;
        private bool isNewDrawing = false;
        private PointF zoomingPoint;

        public FolderViewerForm()
        {
            InitializeComponent();
            nodeHeight = VisualisingPanel.Height / 12;
            nodeWidth = VisualisingPanel.Width / 10;
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
                    return;
                }
                FolderTextBox.Text = path_of_folder;
                _docTree = this.TraverseStructure(path_of_folder);
                this.VisualisingTabPage_Select(null, null);

                VisualisingPanel.Select();
                DoubleBuffered = true;
             }
        }

        public DocumentNode TraverseStructure(string path)
        {
            return DocumentNode.CreateStructure(path);
        }

        public void VisualisingTabPage_Select(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == HorizontalTabPage)
            {
                HorizontalTabPage.Controls.Add(this.VisualisingPanel);
                this.CalculateNodesPositionsHorizontally();
                VisualisingPanel.Paint += this.HorizontalVisualising_Paint;

                var treeWidth = _docTree.Width + 1;
                var treeHeight = _docTree.Height + 1;

                HorizontalTabPage.AutoScrollMinSize = new Size(
                    Convert.ToInt32((treeWidth * nodeWidth) + ((treeWidth + 1) * NODE_MARGIN_X)),
                    ((int)treeHeight * nodeHeight) + (((int)treeHeight + 1) * NODE_MARGIN_Y));
            } 
            else if (tabControl.SelectedTab == VerticalTabPage)
            {
                VerticalTabPage.Controls.Add(this.VisualisingPanel);
                this.CalculateNodesPositionsVertically();
                VisualisingPanel.Paint += this.VerticalVisualising_Paint;
                

                var treeWidth = _docTree.Width + 1;
                var treeHeight = _docTree.Height + 1;

                VerticalTabPage.AutoScrollMinSize = new Size(
                    Convert.ToInt32((treeWidth * nodeWidth) + ((treeWidth + 1) * NODE_MARGIN_X)),
                    ((int)treeHeight * nodeHeight) + (((int)treeHeight + 1) * NODE_MARGIN_Y));
            }
            isNewDrawing = true;
            zoom = 1.0f;
            VisualisingPanel.MouseWheel += VisualisingPanel_ZoomByWheel;
            VisualisingPanel.Invalidate();
        }

        private void VerticalVisualising_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (!isNewDrawing)
            {
                g.TranslateTransform(zoomingPoint.X, zoomingPoint.Y);
                g.ScaleTransform(zoom, zoom);
                g.TranslateTransform(-zoomingPoint.X, -zoomingPoint.Y);
            }
            g.Clear(BackColor);
            string largestNameSize = this.DetermineLargestName(g, _docTree);
            fontSize = this.DetermineFontSize(g, largestNameSize);
            this.DrawNodeVertically(_docTree, g);
        }

        private void HorizontalVisualising_Paint(object sender, PaintEventArgs e) 
        {
            Graphics g = e.Graphics;
            if (!isNewDrawing)
            {   
                g.TranslateTransform(zoomingPoint.X, zoomingPoint.Y);
                g.ScaleTransform(zoom, zoom);
                g.TranslateTransform(-zoomingPoint.X, -zoomingPoint.Y);
            }
            g.Clear(BackColor);
            string largestNameSize = this.DetermineLargestName(g, _docTree);
            fontSize = this.DetermineFontSize(g, largestNameSize);
            DrawNodeHorizontally(_docTree, g);
        }

        // VERTICAL VISUALISING METHODS
        public void CalculateNodesPositionsVertically()
        {
            this.InitializeNodesVertically(_docTree, 0);

            this.CalculateYPositions(_docTree);

            this.CalculateFinalPostion(_docTree);
        }

        private void InitializeNodesVertically(DocumentNode node, int depth)
        {
            node.X = depth;
            node.Y = -1;
            foreach (DocumentNode child in node.GetChildren())
                InitializeNodesVertically(child, depth + 1);
        }

        private void CalculateYPositions(DocumentNode node)
        {
            CalculateYPositions(node, 0);
        }

        private int CalculateYPositions(DocumentNode node, int v)
        {
            node.Y = v;
            foreach (DocumentNode child in node.GetChildren()) 
            {
                v++;
                v = CalculateYPositions(child, v);
            }
            return v;
        }
        
        private void CalculateFinalPostion(DocumentNode node)
        {
            foreach(DocumentNode child in node.GetChildren())
            {
                CalculateFinalPostion(child);
            }
            if (node.GetChildren().Count == 0)
            {
                node.Width = node.X;
                node.Height = node.Y;
            }
            else
            {
                node.Width = node.GetChildren().OrderByDescending(p => p.Width).First().Width;
                node.Height = node.GetChildren().OrderByDescending(p => p.Height).First().Height;
            }
        
        }

        public void DrawNodeVertically(DocumentNode node, Graphics g)
        {
        // rectangle where node will be positioned
        Rectangle nodeRect = new Rectangle(
                     (int)(NODE_MARGIN_X + (node.X * (nodeWidth + NODE_MARGIN_X))),
                        (int)(NODE_MARGIN_Y + (node.Y * (nodeHeight + NODE_MARGIN_Y)))
                        , nodeWidth, nodeHeight);

            // draw box
            g.DrawRectangle(new Pen(Brushes.Gray, 2), nodeRect);
            if (node.GetDocument() is Folder)
                g.FillRectangle(Brushes.LightGray, nodeRect);
            else
                g.FillRectangle(Brushes.LightSkyBlue, nodeRect);

            // draw content
            this.DrawStringInsideRectangle(node, nodeRect, g);

            // draw the line to the furthest child
            if (!node.IsLeaf()) 
            {
                Point parentPoint = new Point(nodeRect.X + (nodeRect.Width / 2),
                                                  nodeRect.Y + nodeRect.Height);

                int furthestChildX = parentPoint.X;
                int furthestChildY = (int) node.GetRightMostChild().Y * (nodeHeight + NODE_MARGIN_Y) + nodeHeight;
                Point furthestChildPoint = new Point(furthestChildX,
                                                                furthestChildY);

                g.DrawLine(Pens.Gray, parentPoint, furthestChildPoint);
            }

            // draw line back to the parents line
            if (!(node.GetParent() == null))
            {
                int lineYposition = nodeRect.Y + (nodeRect.Height / 2);
                Point parentLinePoint = new Point((int)node.GetParent().X * (nodeWidth + NODE_MARGIN_X) + NODE_MARGIN_X + nodeWidth / 2, 
                                                            lineYposition + 2);
                Point childPoint = new Point(nodeRect.X - 1,
                                                        lineYposition + 2);

                g.DrawLine(Pens.Gray, parentLinePoint, childPoint);
            }

            foreach (DocumentNode child in node.GetChildren())
            {
                this.DrawNodeVertically(child, g);
            }
        }
        
        // HORIZONTAL DRAWING METHODS
        public void CalculateNodesPositionsHorizontally()
        {
            // Init X, Y and Mod values
            InitializeNodesHorizontally(_docTree, 0);

            // Assign initial X and Mod values for nodes
            CalculateInitialX(_docTree);

            // For nodes with negative Mod
            CheckAllChildrenOnScreen(_docTree);

            // add Mod values to nodes
            CalculateFinalPostion(_docTree, 0);
        }

        private void InitializeNodesHorizontally(DocumentNode node, int depth)
        {
            node.X = -1;
            node.Y = depth;
            node.Mod = 0;

            foreach (DocumentNode child in node.GetChildren())
                InitializeNodesHorizontally(child, depth + 1);
        }

        private void CalculateInitialX(DocumentNode node)
        {
            // Do a post-order traversal of the tree to reach the left most node
            foreach (DocumentNode childNode in node.GetChildren())
                CalculateInitialX(childNode);

            // Assign the left most node to 0, else to the X value of the previous node + 1
            if (node.IsLeaf())
            {
                if (node.IsLeftMost())
                    node.X = 0;
                else
                    node.X = node.GetPreviousSibling().X + 1;
            } 
            else if (node.GetChildren().Count == 1)
            {
                if (node.IsLeftMost())
                {
                    node.X = node.GetChildren()[0].X;
                }
                else
                {
                    node.X = node.GetPreviousSibling().X + 1;
                    node.Mod = node.X - node.GetChildren()[0].X;
                }
            } 
            else
            {
                var leftChildNode = node.GetLeftMostChild();
                var rightChildNode = node.GetRightMostChild();
                float midWay = (rightChildNode.X + leftChildNode.X) / 2;
                if (node.IsLeftMost())
                {
                    node.X = node.GetChildren()[0].X;

                }
                else
                {
                    node.X = node.GetPreviousSibling().X + 1;
                    
                }
                node.Mod = node.X - midWay;
            }
            
            if (node.GetChildren().Count > 0 && !node.IsLeftMost())
                this.CheckForConflicts(node);
        }

        private void CheckForConflicts(DocumentNode node)
        {
            var minDistance = 1;
            var shiftValue = 0F;

            var nodeContour = new Dictionary<int, float>();
            GetLeftContour(node, 0, ref nodeContour);

            var sibling = node.GetLeftMostSibling();
            while (sibling != null && sibling != node)
            {
                var siblingContour = new Dictionary<int, float>();
                GetRightContour(sibling, 0, ref siblingContour);

                for (int level = (int) node.Y + 1; level <= Math.Min(siblingContour.Keys.Max(), nodeContour.Keys.Max()); level++)
                {
                    var distance = nodeContour[level] - siblingContour[level];
                    if (distance + shiftValue < minDistance)
                    {
                        shiftValue = minDistance - distance;
                    }
                }

                if (shiftValue > 0)
                {
                    node.X += shiftValue;
                    node.Mod += shiftValue;

                    CenterNodesBetween(node, sibling);

                    shiftValue = 0;
                }

                sibling = sibling.GetNextSibling();
            }
        }

        private void GetLeftContour(DocumentNode node, float modSum, ref Dictionary<int, float> values)
        {
            if (!values.ContainsKey((int)node.Y))
                values.Add((int)node.Y, node.X + modSum);
            else
                values[(int)node.Y] = Math.Min(values[(int)node.Y], node.X + modSum);

            modSum += node.Mod;
            foreach (var child in node.GetChildren())
            {
                GetLeftContour(child, modSum, ref values);
            }
        }

        private void GetRightContour(DocumentNode node, float modSum, ref Dictionary<int, float> values)
        {
            if (!values.ContainsKey((int)node.Y))
                values.Add((int)node.Y, node.X + modSum);
            else
                values[(int)node.Y] = Math.Max(values[(int)node.Y], node.X + modSum);

            modSum += node.Mod;
            foreach (var child in node.GetChildren())
            {
                GetRightContour(child, modSum, ref values);
            }
        }

        private void CenterNodesBetween(DocumentNode leftNode, DocumentNode rightNode)
        {
            var leftIndex = leftNode.GetParent().GetChildren().IndexOf(rightNode);
            var rightIndex = leftNode.GetParent().GetChildren().IndexOf(leftNode);

            var numNodesBetween = (rightIndex - leftIndex) - 1;

            if (numNodesBetween > 0)
            {
                var distanceBetweenNodes = (leftNode.X - rightNode.X) / (numNodesBetween + 1);

                int count = 1;
                for (int i = leftIndex + 1; i < rightIndex; i++)
                {
                    var middleNode = leftNode.GetParent().GetChildren()[i];

                    var desiredX = rightNode.X + (distanceBetweenNodes * count);
                    var offset = desiredX - middleNode.X;
                    middleNode.X += offset;
                    middleNode.Mod += offset;

                    count++;
                }

                CheckForConflicts(leftNode);
            }
        }

        private void CheckAllChildrenOnScreen(DocumentNode rootNode)
        {
            var nodeContour = new Dictionary<int, float>();
            GetLeftContour(rootNode, 0, ref nodeContour);

            float shiftAmount = 0;
            foreach (var y in nodeContour.Keys)
            {
                if (nodeContour[y] + shiftAmount < 0)
                    shiftAmount = (nodeContour[y] * -1);
            }

            if (shiftAmount > 0)
            {
                rootNode.X += shiftAmount;
                rootNode.Mod += shiftAmount;
            }
        }

        private void CalculateFinalPostion(DocumentNode node, float modSum)
        {
            node.X += modSum;
            modSum += node.Mod;

            foreach (var child in node.GetChildren())
                CalculateFinalPostion(child, modSum);

            if (node.GetChildren().Count == 0)
            {
                node.Width = node.X;
                node.Height = node.Y;
            }
            else
            {
                node.Width = node.GetChildren().OrderByDescending(p => p.Width).First().Width;
                node.Height = node.GetChildren().OrderByDescending(p => p.Height).First().Height;
            }
        }

        public void DrawNodeHorizontally(DocumentNode node, Graphics g)
        {
            // rectangle where node will be positioned
            var nodeRect = new Rectangle(
                (int)(NODE_MARGIN_X + (node.X * (nodeWidth + NODE_MARGIN_X))),
                (int)(NODE_MARGIN_Y + (node.Y * (nodeHeight + NODE_MARGIN_Y)))
                , nodeWidth, nodeHeight);

            // draw box
            g.DrawRectangle(new Pen(Brushes.Gray, 2), nodeRect);
            if (node.GetDocument() is Folder)
                g.FillRectangle(Brushes.LightGray, nodeRect);
            else
                g.FillRectangle(Brushes.LightSkyBlue, nodeRect);
            // draw content
            this.DrawStringInsideRectangle(node, nodeRect, g);

            // No line above the root node
            if (node.GetParent() == null) { }
            // draw line to parent
            else if (node.GetChildren() != null)
            {
                var nodeTopMiddle = new Point(nodeRect.X + (nodeRect.Width / 2), nodeRect.Y);
                g.DrawLine(Pens.Gray, nodeTopMiddle, new Point(nodeTopMiddle.X, nodeTopMiddle.Y - (NODE_MARGIN_Y / 2)));
            }

            // draw line to children
            if (node.GetChildren().Count > 0)
            {
                var nodeBottomMiddle = new Point(nodeRect.X + (nodeRect.Width / 2), nodeRect.Y + nodeRect.Height);
                g.DrawLine(Pens.Gray, nodeBottomMiddle, new Point(nodeBottomMiddle.X, nodeBottomMiddle.Y + (NODE_MARGIN_Y / 2)));


                // draw line over children
                if (node.GetChildren().Count > 1)
                {
                    var childrenLineStart = new Point(
                        Convert.ToInt32(NODE_MARGIN_X + (node.GetRightMostChild().X * (nodeWidth + NODE_MARGIN_X)) + (nodeWidth / 2)),
                        nodeBottomMiddle.Y + (NODE_MARGIN_Y / 2));
                    var childrenLineEnd = new Point(
                        Convert.ToInt32(NODE_MARGIN_X + (node.GetLeftMostChild().X * (nodeWidth + NODE_MARGIN_X)) + (nodeWidth / 2)),
                        nodeBottomMiddle.Y + (NODE_MARGIN_Y / 2));

                    g.DrawLine(Pens.Gray, childrenLineStart, childrenLineEnd);
                }
            }


            foreach (var item in node.GetChildren())
            {
                DrawNodeHorizontally(item, g);
            }
        }


        // FITTING STRINGS INTO RECTANGLES
        public void DrawStringInsideRectangle(DocumentNode doc, Rectangle rec, Graphics graphics)
        {
            Font font = new Font("Light Segoe UI", fontSize);
            SizeF textSize = graphics.MeasureString(doc.GetName(), font);
            StringFormat sf = new StringFormat
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Center
            };

            graphics.DrawString(doc.GetName(), font, Brushes.Black,
                rec, sf);
            string docSize = this.FormatSize(doc.GetDocument().CalculateSize());
            sf = new StringFormat
            {
                LineAlignment = StringAlignment.Far,
                Alignment = StringAlignment.Far
            };
            graphics.DrawString(docSize, new Font("Segoe UI", 7), Brushes.DarkGray,
                rec, sf);
        }
        
        public string FormatSize(Int64 bytes)
        {
            string[] suffixes =
            { "Bytes", "KB", "MB", "GB", "TB", "PB" };
            int counter = 0;
            decimal number = (decimal)bytes;
            if (number <= 1024)
            {
                return number + " Bytes";
            }
            while (Math.Round(number / 1024) >= 1)
            {
                number = number / 1024;
                counter++;
            }
            return string.Format("{0:n1}{1}", number, suffixes[counter]);
        }

        public float DetermineFontSize(Graphics g, string largestNameSize)
        {
            float f = 30;
            Font largestAllowedFont = new Font("Segoe UI", f);
            SizeF textSize = g.MeasureString(largestNameSize, largestAllowedFont);

            while (textSize.Width > nodeWidth || textSize.Height > nodeHeight)
            {
                f -= 0.5f;
                largestAllowedFont = new Font("Arial", f);
                textSize = g.MeasureString(largestNameSize, largestAllowedFont);
            }
            return f;
        }

        public string DetermineLargestName(Graphics g, DocumentNode node)
        {
            string largestName = node.GetName();
            int length = largestName.Length;
            int childTextLength;
            foreach (DocumentNode child in node.GetChildren())
            {

                string childText = DetermineLargestName(g, child);
                childTextLength = childText.Length;
                if (childTextLength > length)
                    largestName = childText;

            }
            return largestName;
        }

        // ZOOMING METHODS
        private void VisualisingPanel_ZoomByButton(object sender, PreviewKeyDownEventArgs e)
        {
           
            if (e.KeyCode == Keys.Up)
            {
                if (!(zoom > 2.0f))
                    zoom += 0.1f;
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (!(zoom < 0.5f))
                    zoom -= 0.1f;
            }
            zoomingPoint = new PointF(VisualisingPanel.Width / 2, VisualisingPanel.Height / 2);
            isNewDrawing = false;
            VisualisingPanel.Invalidate();
        }

        private void VisualisingPanel_ZoomByWheel(object sender, MouseEventArgs e)
        {
            if (ModifierKeys != Keys.Control)
            {
                return;
            }
            if (e.Delta > 0)
            {
                if (!(zoom > 2.0f))
                    zoom += 0.1f;
            } 
            else if (e.Delta < 0)
            {
                if (!(zoom < 0.5f))
                    zoom -= 0.1f;
            }
            zoomingPoint = new PointF(MousePosition.X, MousePosition.Y);
            isNewDrawing = false;
            VisualisingPanel.Invalidate();
        }
    }
}