using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokenizer.Extention
{
    public static class ExtentionClass
    {
        public static IEnumerable<int> AllIndexesOf(this string str, char[] value)
        {
            if (value == null)
                throw new ArgumentException("dize boş geldi", "value");

            for (int index = 0; ; index += 1)
            {

                if (index >= 0)
                {
                    for (int i = 0; i < value.Length; i++)
                    {
                        if (index == -1) index = 0;
                        index = str.IndexOf(value[i], index);

                        if (index > -1) break;
                    }
                }


                if (index == -1)
                    break;
                yield return index;
            }
        }
    }
}
