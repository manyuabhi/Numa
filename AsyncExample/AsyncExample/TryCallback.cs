using System;
using AsyncExample.Callback;

namespace AsyncExample
{
    internal class TryCallback
    {
        public static void Do1()
        {
            Database.GetDatabaseCallback("db1", delegate(Database db)
            {
                db.GetTableCallback("contact", delegate(Table table)
                {
                    table.GetColumnCallback("address", delegate(Column column)
                    {
                        Console.WriteLine(column.DisplayName);
                    });
                });
            });
        }

        public static void Do2()
        {
            Database.GetDatabaseCallback("db1", db =>            
                db.GetTableCallback("contact", table =>                
                    table.GetColumnCallback("address", column =>                    
                        Console.WriteLine(column.DisplayName)
                    )
                )
            );
        }
    }
}