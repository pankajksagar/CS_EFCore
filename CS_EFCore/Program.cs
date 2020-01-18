using System;
using System.Linq;

namespace CS_EFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            try
            {
                ManageDatabase();
                using (var ctx = new Models.PersonDBContext())
                {
                    var person = new Models.Person()
                    {
                        //PersonID = 1,
                        PersonName = "Pankaj",
                        Gender = "M",
                        Age = 36
                    };

                    ctx.Persons.Add(person);
                    ctx.SaveChanges();

                    Console.WriteLine("Added Person");

                    foreach (var p in ctx.Persons.ToList())
                    {
                        Console.WriteLine($"{p.PersonID} {p.PersonName} {p.Gender} {p.Age}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }

        /// <summary>
        /// This method will make sure that if database is already available then delete it.
        /// </summary>
        static void ManageDatabase()
        {
            using (var ctx = new Models.PersonDBContext())
            {
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();
            }
        }
    }
}
