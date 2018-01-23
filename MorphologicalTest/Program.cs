using Morphological;
using NLPEnvironment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorphologicalTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var manager = new MorphologicalManager();
            var word = new Word("cmhurbaşkanım");



            var result = manager.WordCompare(word);
        }

    }
}
