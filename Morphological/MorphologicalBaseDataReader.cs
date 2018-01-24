using NLPEnvironment.Container;
using NLPEnvironment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morphological
{
    public class MorphologicalBaseDataReader
    {
        public WordCollection Read()
        {
            var result = new WordCollection();
            var containerReader = new ContainerReader();

            var text = containerReader.Read(ContainerName.MORPHOLOGICAL);


            var splitText = text.Split(Environment.NewLine.ToCharArray()).Where(t => !string.IsNullOrEmpty(t)).Where(t => (t.Trim()[0] != '#'));


            foreach (var row in splitText)
            {
                var cols = row.Split('\t');


                var newWord = new Word()
                {
                    Text = cols[0],
                    Root = new Word(cols[1]),
                    Morphologic = cols[2].Split('+').Select(m => new MorphologicItem(m)).ToList()
                };


                result.Add(newWord);
            }




            return result;
        }
    }
}
