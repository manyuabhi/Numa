using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Timers;

namespace AsyncExample
{
    internal class Svc
    {
        public static List<string> GetDatabases()
        {
            return new List<string> {"db1", "db2"};
        }

        public static List<string> GetTables(string database)
        {
            return new List<string> {"t1", "t2", "t3"};
        }

        public static List<string> GetColumns(string database, string table)
        {
            return new List<string> {"c1", "c2", "c3"};
        }

        public static void GetDatabasesAsync(Action<List<string>> callback)
        {
            new Timer(200) {AutoReset = false, Enabled = true}.Elapsed +=
                (sender, args) => callback(new List<string> {"db1", "db2"});
        }

        public static void GetTablesAsync(string database, Action<List<string>> callback)
        {
            new Timer(200) {AutoReset = false, Enabled = true}.Elapsed +=
                (sender, args) => callback(new List<string> {"t1", "t2", "t3"});
        }

        public static void GetColumnsAsync(string database, string table, Action<List<string>> callback)
        {
            new Timer(200) {AutoReset = false, Enabled = true}.Elapsed +=
                (sender, args) => callback(new List<string> {"c1", "c2", "c3"});
        }

        public static async Task<List<string>> GetColumnsAsync(string database, string table)
        {
            var tsc = new TaskCompletionSource<List<string>>();
            GetColumnsAsync(database, table, tsc.SetResult);
            await tsc.Task;
            return tsc.Task.Result;
        }

        public static async Task<List<string>> GetTablesAsync(string database)
        {
            var tsc = new TaskCompletionSource<List<string>>();
            GetTablesAsync(database, tsc.SetResult);
            await tsc.Task;
            return tsc.Task.Result;
        }

        public static async Task<List<string>> GetDatabasesAsync()
        {
            var tsc = new TaskCompletionSource<List<string>>();
            GetDatabasesAsync(tsc.SetResult);
            await tsc.Task;
            return tsc.Task.Result;
        }
    }
}