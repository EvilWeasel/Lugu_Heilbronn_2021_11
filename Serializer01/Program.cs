using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

namespace Serializer01
{  
    [XmlRoot("Mitarbeiter")]
    public class Person
    {
        [XmlAttribute("Nr")]
        public int Id { get; set; }
        
        [XmlAttribute]
        public string Vorname { get; set; }

        //[XmlElement("Name")]
        [XmlAttribute]
        public string Nachname { get; set; }

        [XmlIgnore]
        public int Alter { get; set; }

        public static Person CreateMax()
        {
            return new Person() { Id = 42, Vorname = "Max", Nachname = "Mustermann", Alter = 42 };
        }
        public override string ToString()
        {
            return $"{Id}; {Vorname}; {Nachname}; {Alter}";
        }
    }

    class Program
    {
        static void Ser01()
        {
            Person p = Person.CreateMax();
            XmlSerializer serializer = new XmlSerializer(typeof(Person) );
            string xml;
            // String-Streams
            StringWriter stream = new StringWriter();
            serializer.Serialize(stream, p);
            xml = stream.ToString();
            Console.WriteLine(xml);
        }

        static void Ser02()
        {
            Person p = Person.CreateMax();
            XmlSerializer serializer = new XmlSerializer(typeof(Person) );

            // File-Streams
            if (!Directory.Exists(@"c:\temp"))
                Directory.CreateDirectory(@"c:\temp");

            string fn = @"c:\temp\test.xml";
            using (FileStream stream = File.Create(fn))
            {
                serializer.Serialize(stream, p);
            }

            // File.ReadAllText(...)

            using(FileStream fs = File.Open(fn, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using(StreamReader reader = new StreamReader(fs))
                {
                    while(!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        Console.WriteLine("> " + line);
                    }
                }
            }

        }

        static void Deser03()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Person));

            using (FileStream stream = File.OpenRead(@"c:\temp\test.xml"))
            {
                Person p = serializer.Deserialize(stream) as Person;
                Console.WriteLine(p);
            }
        }

        static void Ser04_Schnell_Weiter_Und_Ablenken()
        {
            
            string json = JsonSerializer.Serialize(Person.CreateMax());
            Console.WriteLine(json);

            Person copy = JsonSerializer.Deserialize<Person>(json);
            Console.WriteLine(copy);

            Console.WriteLine(new string('*',60));

            List<Person> pliste = new List<Person>();
            for (int i = 0; i < 50; i++)
            {
                Person x = Person.CreateMax();
                x.Id = i + 1;
                pliste.Add(x);
            }
            json = JsonSerializer.Serialize(pliste);
            Console.WriteLine(json);
        }

        

        static void Main(string[] args)
        {
            Ser04_Schnell_Weiter_Und_Ablenken();  
        }
    }
}
