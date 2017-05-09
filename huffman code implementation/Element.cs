using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace huffman_code_implementation
{
    public class Element
    {
        public int count;
        public string symbs;
        public Element(int cnt, string smb)
        {
            this.count = cnt;
            this.symbs = smb;
        }
    }
}
