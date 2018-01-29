using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuceneLibrary
{
    public class LuceneSchema
    {
        string _name;
        string _id;

        public string Id
        {
            get
            {
                return _id;
            }

            internal set
            {
                _id = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }

            internal set
            {
                _name = value;
            }
        }


        public LuceneSchema()
        {

        }


        public LuceneSchema(string name, string id) : this()
        {

            _name = name;
            _id = id;
        }
    }
}
