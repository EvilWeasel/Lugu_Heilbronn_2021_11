#define Test

using System;
using System.Diagnostics;
using System.Reflection;

namespace Reflections01
{

    class Program
    {
#if DEBUG
        static void Test01()
        {
            // Meta-Datentyp
            Type t = typeof(Person);

            // dummy, alter, ...
            foreach (FieldInfo fi in t.GetRuntimeFields())
            {
                Console.WriteLine($"{fi.Name}, {fi.FieldType.Name}");
            }

            foreach (PropertyInfo pi in t.GetRuntimeProperties())
            {
                Console.WriteLine($"{pi.Name}, {pi.PropertyType.Name}");
            }

            foreach (MethodInfo mi in t.GetRuntimeMethods())
            {
                Console.WriteLine($"{mi.Name}, {mi.ReturnType.Name}");
                // mi.GetParameters
            }
        }
#endif
        [Conditional("DEBUG")]
        static void Test02()
        {
            Person p1 = new Person() { Id = 1, Vorname = "Max", Nachname = "Mustermann" };
            Person p2 = p1.Clone();
            p2.Nachname = "Musterfrau";
            Console.WriteLine(p1);
            Console.WriteLine(p2);

            Console.WriteLine("SERIALIZE p1");
            string xml = XSerializer.Serialize(p1);
            Console.WriteLine(xml);

            Console.WriteLine(XSerializer.Serialize(DateTime.Now));
            // Debug.WriteLine(p1);
            // Trace.WriteLine(p1);
        }

        static void Test03()
        {
            // <Person Id="1" Vorname="Arni" ... />
            string xml = @"<Mitarbeiter>
<Nr>4</Nr>
<Vorname>Arnold</Vorname>
<Name>Schwarzenegger</Name>
<Alter>73</Alter>
</Mitarbeiter>";
            Person p = XSerializer.Deserialize<Person>(xml);
            
            Console.WriteLine(p);
        }


        static void Main(string[] args)
        {
            Console.WriteLine("START");
            Test03();
        }

        // Marshalling
        // Zugriff auf Windows
        // user32.dll

    }
}
