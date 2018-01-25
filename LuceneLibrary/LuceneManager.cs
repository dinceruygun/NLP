using System;
using System.Collections.Generic;
using System.Data;
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
        string _schemaDocName = "schema";


        LuceneDocumentCollection _luceneDocumentCollection;

        public LuceneManager()
        {
            _rootPath = Path.Combine(AssemblyDirectory, "data");
            _schemaPath = Path.Combine(_rootPath, "schema");

            init();
        }


        private void init()
        {
            CheckDirectory(_rootPath);
            CheckDirectory(_schemaPath);

            _luceneDocumentCollection = new LuceneDocumentCollection();


            var doc = new LuceneDocument(_schemaPath);

            _luceneDocumentCollection.Add(_schemaDocName, doc);


            LoadSchema();
        }


        private void LoadSchema()
        {
            var doc = _luceneDocumentCollection[_schemaDocName];

            var table = doc.GetAllDocuments();
            if (table == null) return;


            foreach (var item in table.Rows)
            {

            }

        }

        
        public bool AddSchema(string schemaName)
        {
            var doc = _luceneDocumentCollection[_schemaDocName];

            var t = new DataTable(_schemaDocName);
            t.Columns.Add("name");
            t.Columns.Add("id");

            var row = t.NewRow();
            row["name"] = schemaName;
            row["id"] = Guid.NewGuid();

            t.Rows.Add(row);

            doc.AddToIndex(t);

            return true;
        }



        private bool CheckDirectory(string path)
        {
            try
            {
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
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
