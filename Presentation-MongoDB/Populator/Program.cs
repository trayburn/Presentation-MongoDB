using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB;

namespace Populator
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstNames = new[] { "Tim", "Dave", "Craig", "Noah", "Mark", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            var lastNames = new[] { "Rayburn", "O'Hara", "Neuwirt", "Coad", "Mikaelis" };

            using (var mongo = new Mongo())
            {
                mongo.Connect();
                var db = mongo.GetDatabase("StElmo");
                var coll = db.GetCollection("Patients");
                foreach (string firstName in firstNames)
                {
                    foreach (string lastName in lastNames)
                    {
                        coll.Save(new Document()
                            .Add("FirstName", firstName)
                            .Add("LastName", lastName));
                        Console.Write(".");
                    }
                }
            }

            Console.WriteLine("Complete");
            Console.ReadLine();
        }
    }
}
