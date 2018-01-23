using NLPEnvironment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morphological
{
    

    public class MorphologicalManager
    {

        public WordCollection WordCompare(Word word)
        {
            if (word == null) return null;
            if (string.IsNullOrEmpty(word.Text)) return null;
            if (word.Text.Length < 3) return null;


            var result = new WordCollection();





            return result;
        }


    }
}
