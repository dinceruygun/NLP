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


            var splitText = text.Split(Environment.NewLine.ToCharArray()).Where(t => (t.Trim()[0] != '#'));


            foreach (var item in splitText)
            {

            }




            return result;
        }
    }
}
