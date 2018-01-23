using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NLPEnvironment.Escape
{
    public class WordShort
    {
        public Dictionary<string, string> ShortList;

        public WordShort()
        {
            ShortList = new Dictionary<string, string>();
            LoadShortList();
        }


        public void LoadShortList()
        {
            var containerReader = new Container.ContainerReader();

            var text = containerReader.Read(Container.ContainerName.SHORTLIST);

            ShortList = new Dictionary<string, string>();


            foreach (var item in text.Split(Environment.NewLine.ToCharArray()))
            {
                if (item.IndexOf(",") > 1 && !string.IsNullOrEmpty(item))
                {
                    var splitData = item.Split(',');

                    var shortName = splitData[0].Trim().ToLower();
                    shortName = shortName[shortName.Length - 1] == '.' ? shortName.Substring(0, shortName.Length - 2) : shortName;

                    if (!ShortList.ContainsKey(shortName))
                    {
                        ShortList.Add(shortName, splitData[1]);
                    }
                }
            }

        }

    }
}
