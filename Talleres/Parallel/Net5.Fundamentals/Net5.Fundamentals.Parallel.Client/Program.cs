using Net5.Fundamentals.Parallel.Client.Data.Helper;
using Net5.Fundamentals.Parallel.Client.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Net5.Fundamentals.Parallel.Client
{
    class Program
    {
        static void Main(string[] args)
        {            
            bool exit = false;
            Database database = new Database();

            do
            {
                string opt;
                List<Badge> badges = new List<Badge>();

                Console.Clear();
                Console.WriteLine("Taller - Parallel");
                Console.WriteLine("=================");
                Console.WriteLine(" 1 - Normal Query");
                Console.WriteLine(" 2 - Parallel Query");
                Console.WriteLine("99 - Exit");
                opt = Console.ReadLine();

                switch (opt)
                {
                    case "1":
                        badges = database.ListBadges();
                        Console.WriteLine($"ListBadges, Count : {badges.Count()}");
                        break;
                    case "2":
                        badges = database.ListBadgesParallel();
                        Console.WriteLine($"ListBadges, Count : {badges.Count()}");
                        break;
                    case "99":
                        exit = true;
                        break;
                    default:
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                }
            } while (!exit);
        }
    }
}
