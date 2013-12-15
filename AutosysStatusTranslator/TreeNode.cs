using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AutosysStatusTranslator
{
    [DataContract]
    public class NodeData
    {
        [DataMember(Order = 2)]
        public string Name { get; set; }
    }

    [DataContract]
    public class TreeNode
    {
        private List<TreeNode> _children;

        public TreeNode Parent { get; set; }

        public int Level { get; set; }

        [DataMember(Order = 0)]
        public NodeData Data { get; set; }

        [DataMember(Order = 1)]
        public List<TreeNode> Children 
        {
            get
            {
                return _children ?? (_children = new List<TreeNode>());
            }
        }
    }
}
