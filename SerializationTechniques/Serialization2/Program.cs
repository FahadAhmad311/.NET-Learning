using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

public class Project
{
    public class Person
    {
        public string UserName { get; set; }
        public int UserAge { get; set; }
    }
    static void Main()
    {
        Person samplePerson = new Person { UserName = "Fahad Ahmad", UserAge = 22 };
        using (FileStream fs = new FileStream("person.dat", FileMode.Create))
        {
            BinaryWriter writer = new BinaryWriter(fs);
            writer.Write(samplePerson.UserName);
            writer.Write(samplePerson.UserAge);
        }
        Console.WriteLine("Binary serealization complete.");

        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
        using (StreamWriter writer = new StreamWriter("person.xml"))
        {
            xmlSerializer.Serialize(writer, samplePerson);
        }

        string jsonString = JsonSerializer.Serialize(samplePerson);
        File.WriteAllText("person.json", jsonString);
        Console.WriteLine("Json serialization complete.");
    }
}