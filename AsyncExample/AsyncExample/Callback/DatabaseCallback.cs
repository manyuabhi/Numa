using System;
using System.Timers;

namespace AsyncExample.Callback
{
    internal class Database
    {
        public static void GetDatabaseCallback(string databaseName, Action<Database> callback)
        {
            new Timer(200) { AutoReset = false, Enabled = true }.Elapsed += (s, a) => callback(new Database());
        }
        public void GetTableCallback(string tableName, Action<Table> callback)
        {
            new Timer(200) { AutoReset = false, Enabled = true }.Elapsed += (s, a) => callback(new Table());
        }
    }

    internal class Table
    {
        public void GetColumnCallback(string columnName, Action<Column> callback)
        {
            new Timer(200) { AutoReset = false, Enabled = true }.Elapsed += (s, a) => callback(new Column());
        }
    }

    internal class Column
    {
        public string DisplayName = "value";
    }
}

