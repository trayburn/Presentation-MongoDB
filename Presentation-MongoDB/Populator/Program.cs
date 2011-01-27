using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB;
using Castle.Components.DictionaryAdapter;
using MongoDB.Linq;

namespace Populator
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstNames = new[] { "Tim", "Dave", "Craig", "Noah", "Mark", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            var lastNames = new[] { "Rayburn", "O'Hara", "Neuwirt", "Coad", "Mikaelis" };

            var daf = new DictionaryAdapterFactory();
            var da = daf.GetAdapter<IPatient>(new Document()
                .Add("FirstName", "Tim")
                .Add("LastName", "Rayburn")
                .Add("Address", new Document().Add("Line1","Dallas,TX")));

            using (var mongo = new Mongo())
            {
                var db = mongo.GetDatabase("StElmo");
                var coll = db.GetCollection<Patient>().Linq().Select(p => p.FirstName == "Tim").ToList();
                var query = from p in db.GetCollection<Patient>().Linq()
                            where p.FirstName == "Tim"
                            select p;
            }

            Console.WriteLine(da.FirstName);
            Console.WriteLine(da.Address.Line1);

            Console.WriteLine("Complete");
            Console.ReadLine();
        }
    }

    public interface IPatient
    {
        string FirstName { get; set; }
        string LastName { get; set; }

        [Component]
        IAddress Address { get; set; }
    }

    public class Patient
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

    } 
    public interface IAddress
    {
        string Line1 { get; set; }
    }
}
