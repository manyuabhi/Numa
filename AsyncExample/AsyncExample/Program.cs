using System;

namespace AsyncExample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Method1();
            Console.ReadKey();
            Method2();
            Console.ReadKey();
            Method3();
            Console.ReadKey();
        }

        private static void Method1()
        {
            foreach (string database in Svc.GetDatabases())
            {
                foreach (string table in Svc.GetTables(database))
                {
                    foreach (string column in Svc.GetColumns(database, table))
                    {
                        Console.WriteLine("Database: {0}, Table: {1}, Column: {2}", database, table, column);
                    }
                }
            }
        }

        private static void Method2()
        {
            Svc.GetDatabasesAsync(databases =>
            {
                foreach (string database in databases)
                {
                    Svc.GetTablesAsync(database, tables =>
                    {
                        foreach (string table in tables)
                        {
                            Svc.GetColumnsAsync(database, table, columns =>
                            {
                                foreach (string column in columns)
                                {
                                    Console.WriteLine("Database: {0}, Table: {1}, Column: {2}", database, table, column);
                                }
                            });
                        }
                    });
                }
            });
        }

        private static async void Method3()
        {
            foreach (string database in await Svc.GetDatabasesAsync())
            {
                foreach (string table in await Svc.GetTablesAsync(database))
                {
                    foreach (string column in await Svc.GetColumnsAsync(database, table))
                    {
                        Console.WriteLine("Database: {0}, Table: {1}, Column: {2}", database, table, column);
                    }
                }
            }
        }
    }
}