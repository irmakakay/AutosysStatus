using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutosysStatusTranslator
{
    class Program
    {
        private static StatusReader _reader;

        static void Main(string[] args)
        {
            _reader = new StatusReader(
                @"B:\\code.base\\CSharp\\AutosysStatusTranslator\\autosys.txt");

            var tree = new AutosysTree();

            Parse(tree);

            var json = TreeSerializer.SerializeToXml<TreeNode>(tree.Root);

            Console.ReadKey();
        }

        public static void Parse(AutosysTree tree)
        {
            foreach (var line in _reader.Lines)
            {
                var index = line.IndexOf("c_", StringComparison.InvariantCulture);

                if (index < 0) continue;

                var content = new NodeData 
                {
                    Name = line.Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries).First()
                };

                tree.Add(new TreeNode { Data = content, Level = index });

                Console.WriteLine(index);
            }
        }
    }
}
