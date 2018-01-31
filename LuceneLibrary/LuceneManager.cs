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
        string _indexPath;
        string _dataPath;
        string _schemaDocName = "schema";
        string _indexDocName = "index";
        string _dataDocName = "data";



        LuceneDocumentCollection _luceneDocumentCollection;
        LuceneSchemaCollection _luceneSchemaCollection;
        Dictionary<string, Dictionary<string, string>> _indexCollection;


        public LuceneManager()
        {
            _rootPath = Path.Combine(AssemblyDirectory, "data");
            _schemaPath = Path.Combine(_rootPath, _schemaDocName);
            _indexPath = Path.Combine(_rootPath, _indexDocName);
            _dataPath = Path.Combine(_rootPath, _dataDocName);

            init();
        }

        public DataTable Query(string schemaName, string indexName, string find)
        {
            if (string.IsNullOrEmpty(schemaName)) throw new NullReferenceException("Şema adı boş geçilemez");
            if (!ExistSchema(schemaName)) throw new NullReferenceException("Şema bulunamadı");


            if (string.IsNullOrEmpty(indexName)) throw new NullReferenceException("Index adı boş geçilemez");
            if (!_indexCollection[schemaName].ContainsKey(indexName)) throw new NullReferenceException("Index bulunamadı");




            var docIndex = new LuceneDocument(Path.Combine(_dataPath, _indexCollection[schemaName][indexName]));

            var result = docIndex.Query(find);

            docIndex.Dispose();



            return result;
        }

        private void init()
        {
            CheckDirectory(_rootPath);
            CheckDirectory(_schemaPath);


            _luceneDocumentCollection = new LuceneDocumentCollection();
            _luceneSchemaCollection = new LuceneSchemaCollection();
            _indexCollection = new Dictionary<string, Dictionary<string, string>>();



            var docSchema = new LuceneDocument(_schemaPath);
            

            _luceneDocumentCollection.Add(_schemaDocName, docSchema);


            LoadSchema();
        }

        public DataTable GetAllDocument(string schemaName, string indexName)
        {
            if (string.IsNullOrEmpty(schemaName)) throw new NullReferenceException("Şema adı boş geçilemez");
            if (!ExistSchema(schemaName)) throw new NullReferenceException("Şema bulunamadı");


            if (string.IsNullOrEmpty(indexName)) throw new NullReferenceException("Index adı boş geçilemez");
            if (!_indexCollection[schemaName].ContainsKey(indexName)) throw new NullReferenceException("Index bulunamadı");


            var docIndex = new LuceneDocument(Path.Combine(_dataPath, _indexCollection[schemaName][indexName]));

            var result = docIndex.GetAllDocuments();

            docIndex.Dispose();


            return result;
        }

        public void Index(string schemaName, DataTable table)
        {
            if(string.IsNullOrEmpty(schemaName)) throw new NullReferenceException("Şema adı boş geçilemez");
            if (!ExistSchema(schemaName)) throw new NullReferenceException("Şema bulunamadı");



            var docIndex = new LuceneDocument(Path.Combine(_indexPath, _luceneSchemaCollection[schemaName].Id));

            var indexControl = false;
            if (!_indexCollection.ContainsKey(schemaName)) indexControl = false;
            else if (!_indexCollection[schemaName].ContainsKey(table.TableName)) indexControl = false;



            if (!indexControl)
            {
                var t = new DataTable(_schemaDocName.Trim());
                t.Columns.Add("name");
                t.Columns.Add("id");

                var row = t.NewRow();
                row["name"] = table.TableName;
                row["id"] = Guid.NewGuid();

                t.Rows.Add(row);

                docIndex.AddToIndex(t);

                docIndex.Dispose();

                LoadSchema();
            }





            docIndex = new LuceneDocument(Path.Combine(_dataPath, _indexCollection[schemaName][table.TableName]));

            docIndex.AddToIndex(table);

            docIndex.Dispose();

            docIndex = null;
        }


        private void LoadSchema()
        {
            _luceneSchemaCollection = new LuceneSchemaCollection();

            var doc = _luceneDocumentCollection[_schemaDocName];

            var table = doc.GetAllDocuments();
            if (table == null) return;


            foreach (DataRow row in table.Rows)
            {
                _luceneSchemaCollection.Add(new LuceneSchema(row["name"].ToString(), row["id"].ToString()));
            }



            foreach (var schema in _luceneSchemaCollection)
            {
                LoadIndexes(schema);
            }
        }



        private void LoadIndexes(LuceneSchema schema)
        {
            var docIndex = new LuceneDocument(Path.Combine(_indexPath, schema.Id));


            _indexCollection.Remove(schema.Name);

            var table = docIndex.GetAllDocuments();

            if (table == null) return;

            var indexList = new Dictionary<string, string>();

            foreach (DataRow row in table.Rows)
            {
                indexList.Add(row["name"].ToString(), row["id"].ToString());
            }

            _indexCollection.Add(schema.Name, indexList);


            docIndex.Dispose();
        }




        public bool ExistSchema(string schemaName)
        {
            if (string.IsNullOrEmpty(schemaName)) return false;

            if (_luceneSchemaCollection[schemaName] == null) return false;

            return true;
        }


        public bool AddSchema(string schemaName)
        {
            if (_luceneSchemaCollection[schemaName] != null) throw new DuplicateWaitObjectException();


            var doc = _luceneDocumentCollection[_schemaDocName.Trim()];

            var t = new DataTable(_schemaDocName.Trim());
            t.Columns.Add("name");
            t.Columns.Add("id");

            var row = t.NewRow();
            row["name"] = schemaName;
            row["id"] = Guid.NewGuid();

            t.Rows.Add(row);

            doc.AddToIndex(t);


            LoadSchema();


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
