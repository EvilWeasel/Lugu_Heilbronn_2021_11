using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Reflections01
{
    // Attribute für XSerializer
    class XIgnoreAttribute : Attribute
    {

    }

    class XRenameAttribute : Attribute
    {
        public string Name { get; set; }
        public XRenameAttribute(string name) : base()
        {
            Name = name;
        }
    }


    // XmlSerializer
    // JsonSerializer

    //Generische Klasse
    class XSerializer
    {
        public static string Serialize<T>(T obj)
        {
            string xml = "";
            Type t = typeof(T);
            XRenameAttribute classrename = t.GetCustomAttribute<XRenameAttribute>();
            string strClassName;
            if (classrename == null)
            {
                strClassName = t.Name;
            }
            else
            {
                strClassName = classrename.Name; // aus Attribute
            }

            xml += $"<{strClassName}>\n";
            foreach (PropertyInfo pi in t.GetRuntimeProperties())
            {
                XRenameAttribute pi_rename = pi.GetCustomAttribute<XRenameAttribute>();
                XIgnoreAttribute pi_ignore = pi.GetCustomAttribute<XIgnoreAttribute>();
                if (pi_ignore == null)
                {
                    if (pi_rename == null)
                        xml += $"\t<{pi.Name}>{pi.GetValue(obj)}</{pi.Name}>\n";
                    else
                        xml += $"\t<{pi_rename.Name}>{pi.GetValue(obj)}</{pi_rename.Name}>\n";
                }
            }
            xml += $"</{strClassName}>\n";
            return xml;
        }

        public static T Deserialize<T>(string xml) where T : new()
        {
            T obj = new T();
            Type t = typeof(T);
            XElement xobj = XElement.Parse(xml);
            XRenameAttribute new_classname = t.GetCustomAttribute<XRenameAttribute>();
            if (
                (new_classname == null && xobj.Name == t.Name) ||           // ohne Attribut
                (new_classname != null && xobj.Name == new_classname.Name)  // mit Attribut
                )
            {
                foreach (PropertyInfo pi in t.GetRuntimeProperties())
                {
                    XRenameAttribute pi_rename = pi.GetCustomAttribute<XRenameAttribute>();
                    XIgnoreAttribute pi_ignore = pi.GetCustomAttribute<XIgnoreAttribute>();
                    if (pi_ignore == null)
                    {
                        string name = pi_rename != null ? pi_rename.Name : pi.Name;
                        if (xobj.Element(name) != null)
                        {
                            // Property in xml gefunden!!!
                            object val = Convert.ChangeType(xobj.Element(name).Value, pi.PropertyType);
                            // ? DATENTYP ?
                            pi.SetValue(obj, val);
                        }
                    }
                }
            }
            return obj;
        }

        public static T DeserializeOhneAttribute<T>(string xml) where T : new()
        {
            T obj = new T();
            Type t = typeof(T);
            XElement xobj = XElement.Parse(xml);
            if (xobj.Name == t.Name)
            {
                foreach (PropertyInfo pi in t.GetRuntimeProperties())
                {
                    if (xobj.Element(pi.Name) != null)
                    {
                        // Property in xml gefunden!!!
                        object val = Convert.ChangeType(xobj.Element(pi.Name).Value, pi.PropertyType);
                        // ? DATENTYP ?
                        pi.SetValue(obj, val);
                    }
                }
            }
            return obj;
        }
    }
}
