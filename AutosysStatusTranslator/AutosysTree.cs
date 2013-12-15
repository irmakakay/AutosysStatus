using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutosysStatusTranslator
{
    public class AutosysTree
    {
        private readonly List<TreeNode> _nodes = new List<TreeNode>();

        public TreeNode Root { get; set; }

        public List<TreeNode> Nodes { get { return _nodes; } }

        public AutosysTree()
        {
            Root = new TreeNode 
            { 
                Level = -1, 
                Data = new NodeData { Name = "Root" }
            };
            _nodes.Add(Root);
        }

        public void Add(TreeNode node)
        {
            var last = _nodes[_nodes.Count - 1];
            
            if (last.Level < node.Level)
            {
                last.Children.Add(node);
                node.Parent = last;
            }
            else
            {
                var sibling = _nodes.Last(n => n.Level == node.Level);
                sibling.Parent.Children.Add(node);
                node.Parent = sibling.Parent;
            }

            _nodes.Add(node);
        }
    }
}
