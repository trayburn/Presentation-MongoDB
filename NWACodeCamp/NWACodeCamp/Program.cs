using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Components.DictionaryAdapter;

namespace NWACodeCamp
{
    class Program
    {
        // github.com/samus/mongodb-csharp
        // github.com/atheken/norm

        // github.com/mongo/mongo-csharp-driver
        static void Main(string[] args)
        {
            try
            {
                var dict = new Dictionary<string, object>()
                {
                    {"FirstName","Tim"}, {"LastName","Rayburn"}, {"MiddleName","John"}
                };

                var da = new DictionaryAdapterFactory().GetAdapter<IPerson>(dict);

                Console.WriteLine(da.FirstName);
                Console.WriteLine(da.LastName);

                da.FirstName = "Chris";
                da.Aliases = new List<string>() { "Bob", "Frank", "Henry" };

                Console.WriteLine(dict["FirstName"]);
                Console.WriteLine(dict["Aliases"]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine("Complete");
            Console.ReadLine();
        }
    }

    public interface IPerson
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        [StringList(Separator='|')]
        List<string> Aliases { get; set; }
    }
}
