using System;
using System.Collections.Generic;

namespace AsyncExample.Yield
{
    class Database
    {
        public static Param GetDatabaseYield(Param p, string dbName)
        {
            p.Value = new Database();
            return p;
        }

        public Param GetTableYield(Param p, string table)
        {
            p.Value = new Table();
            return p;
        }
    }

    class Table
    {
        public static Param GetColumnYield(Param p, string column)
        {
            p.Value = new Column();
            return p;
        }
    }

    internal class Column
    {
        public string DisplayName = "value";
    }


    internal class YieldFrame
    {
        public static void Perform(Func<Param, IEnumerable<Param>> site)
        {
            foreach (var param in site(new Param { Value = null }))
            {
            }
        }
    }

    class Param
    {
        public object Value;
    }
}
