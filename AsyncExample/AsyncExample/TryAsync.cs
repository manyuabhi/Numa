using System;
using AsyncExample.Async;

namespace AsyncExample
{
    internal class TryAsync
    {
        public static async void Do()
        {
            var db = await Database.GetDatabaseAsync("db1");
            var table = await db.GetTableAsync("contact");
            var column = await table.GetColumnAsync("address");
            Console.WriteLine(column.DisplayName);
        }
    }
}