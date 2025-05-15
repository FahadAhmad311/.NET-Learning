using System;
using Newtonsoft.Json;

namespace JsonParsingExample
{
    
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
            string jsonString = @"{ ""Name"": ""Fahad Khattak"", ""Age"": 21 }";

        
            Person person = JsonConvert.DeserializeObject<Person>(jsonString);

            
            Console.WriteLine("Name: " + person.Name);
            Console.WriteLine("Age: " + person.Age);
        }
    }
}
