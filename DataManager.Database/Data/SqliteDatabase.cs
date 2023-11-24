using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Database.Data
{
    public class TableDictionaryItem
    {
        public string WorkPosition { get; set; } = "";

        public string TableName { get; set; } = "";
    }

    public class SqliteDatabase : IDisposable
    {
        private string _dbPath;
        SQLiteConnection connection;

        public SqliteDatabase()
        {
        }

        public bool Init(string dbPath)
        {
            this._dbPath = dbPath;
            string connectionString = $"Data Source={dbPath}";
            connection = new SQLiteConnection(connectionString);
            connection.Open();
            return GetAllTableName().Count > 0;
        }

        public bool InitTableName(JArray objArr)
        {
            TableDictionaryItemList.Clear();
            foreach (JObject objObj in objArr)
            {
                TableDictionaryItem item = new TableDictionaryItem
                {
                    WorkPosition = objObj["WorkPosition"].Value<string>(),
                    TableName = objObj["TableName"].Value<string>()
                };
                TableDictionaryItemList.Add(item);
            }
            return true;
        }

        public void Dispose()
        {
            connection?.Close();
            connection?.Dispose();
        }

        public List<StandardDbEntity> Inquire(string tableName)
        {
            using (SQLiteCommand command = new SQLiteCommand($"SELECT * FROM {tableName}", connection))
            {
                // 执行查询
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    // 创建List以存储查询结果
                    List<StandardDbEntity> resultList = new List<StandardDbEntity>();

                    // 读取数据
                    while (reader.Read())
                    {
                        string dtStr = reader.GetString(1);
                        DateTime dt=DateTime.ParseExact(dtStr, "yyyy-MM-dd_HH:mm:ss", null);
                        StandardDbEntity entity = new StandardDbEntity
                        {
                            id = reader.GetInt32(0),
                            testtime = dt,
                            sampleID = reader.GetString(2),
                            material = reader.GetString(3),
                            ingredient = reader.GetString(4),
                            valid = reader.GetInt32(5)
                        };

                        // 将实体添加到List中
                        resultList.Add(entity);
                    }
                    return resultList;
                }
            }
        }

        public List<string> GetAllTableName()
        {
            List<string> result=new List<string>();
            lock (this)
            {
                DataTable tables = connection.GetSchema("Tables");
                foreach (DataRow row in tables.Rows)
                {
                    string tableName = row["TABLE_NAME"].ToString();
                    result.Add(tableName);
                }
            }
            return result;
        }

        public List<TableDictionaryItem> TableDictionaryItemList { get; } = new List<TableDictionaryItem>();

        private static SqliteDatabase _instance=new SqliteDatabase();
        public static SqliteDatabase GetInstance()
        {
            return _instance;
        }

    }
}
