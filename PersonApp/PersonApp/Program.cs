using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PersonApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var p = new Person()
            {
                Age = 17,
                Name = "Luke",
            };
            p.AgeChanging += PersonAgeChanging;
            p.AgeChanging += PersonAgeChanging;
            p.AgeChanging -= PersonAgeChanging;
            p.Age = 2;
            p.Age++;
            Console.WriteLine(p.Age);
            Console.WriteLine(p.Name);
            var serializer = new XmlSerializer(typeof(Person));
            var stream = new FileStream("person.txt", FileMode.Create);
            serializer.Serialize(stream, p);
            stream.Close();
            Process.Start(new ProcessStartInfo
            {
                FileName = "person.txt",
                UseShellExecute = true,
            });

            var list = new List<int>() { 1, 2, 3 };
            list = list.FindAll(n => n % 2 == 1);

            foreach (int n in list)
            {
                Console.WriteLine($"Value: {n}");
            }

            var lista = new List<int>();
            lista.Add(1);
            lista.Add(2);
            lista.Add(3);
            for (int n = 0; n < lista.Count; n++)
            {
                int i = lista[n]; // Nem kell cast-olni
                Console.WriteLine($"Value: {i}");
            }
        }

        private static void PersonAgeChanging(int oldAge, int newAge)
        {
            Console.WriteLine(oldAge + " => " + newAge);
        }
    }
}
