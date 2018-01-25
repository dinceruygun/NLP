using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LuceneLibrary
{
    public class LuceneManager
    {
        string _rootPath;
        string _schemaPath;

        public LuceneManager()
        {
            _rootPath = Path.Combine(AssemblyDirectory, "data");
            _schemaPath = Path.Combine(_rootPath, "schema");

            init();
        }


        private void init()
        {

        }



        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }


    }




}
