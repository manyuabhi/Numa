using System;
using AsyncExample.Sync;

namespace AsyncExample
{
    internal class TrySync
    {
        public static void Do()
        {
            var db = Database.GetDatabase("db1");
            var table = db.GetTable("contact");
            var column = table.GetColumn("address");
            Console.WriteLine(column.DisplayName);
        }
    }
}