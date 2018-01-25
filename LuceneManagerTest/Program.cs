using LuceneLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuceneManagerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var manager = new LuceneManager();
            manager.AddSchema("nlp");
        }
    }
}
