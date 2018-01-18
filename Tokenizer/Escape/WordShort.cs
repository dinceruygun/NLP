using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tokenizer.Escape
{
    public class WordShort
    {
        public WordShort()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "Tokenizer.Container.ShortList.txt";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string result = reader.ReadToEnd();
            }
        }
    }
}
