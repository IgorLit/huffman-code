using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace huffman_code_implementation
{
   
    class Program
    {
        static void Main(string[] args)
        {
            HuffmanCode huffman = new HuffmanCode();
            Console.WriteLine(huffman.Encode("hello"));
            Console.WriteLine(huffman.Decode(huffman.Encode("hello")));
        }
    }
}
