using System.Threading.Tasks;
using System.Timers;

namespace AsyncExample.Async
{
    internal class Database
    {
        public static async Task<Database> GetDatabaseAsync(string databaseName)
        {
            var tsc = new TaskCompletionSource<Database>();

            new Timer(200) { AutoReset = false, Enabled = true }.Elapsed += (s, a) => tsc.SetResult(new Database());

            await tsc.Task;
            return tsc.Task.Result;
        }
        public async Task<Table> GetTableAsync(string tableName)
        {
            var tsc = new TaskCompletionSource<Table>();

            new Timer(200) { AutoReset = false, Enabled = true }.Elapsed += (s, a) => tsc.SetResult(new Table());

            await tsc.Task;
            return tsc.Task.Result;
        }
    }

    internal class Table
    {
        public async Task<Column> GetColumnAsync(string columnName)
        {
            var tsc = new TaskCompletionSource<Column>();

            new Timer(200) { AutoReset = false, Enabled = true }.Elapsed += (s, a) => tsc.SetResult(new Column());

            await tsc.Task;
            return tsc.Task.Result;
        }
    }

    internal class Column
    {
        public string DisplayName = "value";
    }
}