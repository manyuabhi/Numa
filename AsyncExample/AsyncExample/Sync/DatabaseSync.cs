namespace AsyncExample.Sync
{
    internal class Database
    {
        public static Database GetDatabase(string databaseName)
        {
            return new Database();
        }

        public Table GetTable(string tableName)
        {
            return new Table();
        }
    }

    internal class Table
    {
        public Column GetColumn(string columnName)
        {
            return new Column();
        }
    }

    internal class Column
    {
        public string DisplayName = "value";
    }
}