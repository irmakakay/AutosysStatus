using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutosysStatusTranslator
{
    public class StatusReader
    {
        private readonly string _path;

        public StatusReader(string path)
        {
            _path = path;
        }

        public IEnumerable<string> Lines
        {
            get 
            {
                foreach (var line in File.ReadLines(_path))
                    yield return line;
            }
        }
    }
}
