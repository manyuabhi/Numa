using System;
using System.Collections.Generic;
using AsyncExample.Yield;

namespace AsyncExample
{
    internal class TryYield
    {
        public static void Do()
        {
            YieldFrame.Perform(Actual);
        }

        private static IEnumerable<Param> Actual(Param p)
        {
            yield return Database.GetDatabaseYield(p, "db1");
            var db = (Database)p.Value;

            yield return db.GetTableYield(p, "contact");
            var table = (Table)p.Value;

            yield return Table.GetColumnYield(p, "address");
            var column = (Column)p.Value;

            Console.WriteLine(column.DisplayName);
        }
    }
}