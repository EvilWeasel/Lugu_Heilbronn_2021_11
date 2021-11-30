using Lugu.Helper.DataGenerator;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Reflection;
using System.Linq;

// Active Data Objects ADO
// DAO
// Ado.Net
// SqlConnection, OleDBConnection, MySqlConnection, ...



namespace ADO01
{
    class Program
    {
        static SqlConnection connection;
        // Get (HTTP)
        static void TestENUMERATOR()
        {
            List<string> x = new List<string>() { "Mo", "Di", "Mi" };
            IEnumerator<string> en = x.GetEnumerator();
            while (en.MoveNext())
            {
                Console.WriteLine(en.Current);
            }
        }

        // Get Personen Methode : return List<Personen>

        static List<Person> GetPersonen()
        {
            string sql = "select id, vorname, nachname, geschlecht, geburt, gehalt from tblperson";
            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Person> plist = new List<Person>();
            while (reader.Read())
            {
                Person person = new Person();
                person.Id = reader.GetInt32(0);
                person.Vorname = reader.GetString(1);
                person.Nachname = reader.GetString(2);
                person.Geschlecht = (Geschlecht)reader.GetInt32(3);
                person.Geburtsdatum = reader.GetDateTime(4);
                person.Gehalt = (double)reader.GetDecimal(5);
                //person.Gehalt = (double)reader.GetDouble(5);
                plist.Add(person);
            }
            reader.Close();
            return plist;
        }
        static List<Person> GetPersonenNotGenericButKindOfGeneric()
        {
            string sql = "select id, vorname, nachname, geschlecht, geburt, gehalt from tblperson";
            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Person> plist = new List<Person>();
            Type pType = typeof(Person);
            while (reader.Read())
            {
                Person person = new Person();
                foreach (PropertyInfo pi in pType.GetRuntimeProperties())
                {
                    int pos = reader.GetOrdinal(pi.Name.ToLower());
                    if (pi.PropertyType.IsEnum)
                    {
                        //pi.SetValue(person, Enum.ToObject(pi.PropertyType, reader[pos]));
                        pi.SetValue(person, reader[pos]);
                    }
                    else
                    {
                        pi.SetValue(person, Convert.ChangeType(reader[pos], pi.PropertyType));
                    }

                }
                plist.Add(person);
                //for (int i = 0; i < reader.FieldCount; i++)
                //{
                //    PropertyInfo pi = pType.GetRuntimeProperty(reader.GetName(i));
                //}

            }
            reader.Close();
            return plist;
        }

        static List<Person> GetPersonenReflection()
        {
            List<Person> pListe = new List<Person>();
            Type pType = typeof(Person);

            string sql = "select id, vorname, nachname, geschlecht, geburt as geburtsdatum, gehalt from [tblPerson]";
            SqlCommand cmd = new SqlCommand(sql, connection);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Person p = new Person();

                foreach (PropertyInfo pi in pType.GetRuntimeProperties())
                {
                    int pos = reader.GetOrdinal(pi.Name.ToLower());

                    if (pos >= 0)
                    {
                        pi.SetValue(p, reader[pos]);
                    }
                }

                pListe.Add(p);
            }
            reader.Close();

            return pListe;
        }

        static void PrintPersonList(List<Person> plist)
        {
            foreach (Person p in plist)
            {
                Console.WriteLine(p.ToString());
            }
        }

        static void Lesen()
        {
            void WriteTrenner(int n, int size)
            {
                for (int i = 0; i < n; i++)
                {
                    Console.Write("+-" + new string('-', size) + "-");
                }
                Console.WriteLine("-+");
            }



            string sql = "select id, vorname, nachname, geschlecht, geburt, gehalt from tblperson";
            SqlCommand cmd = new SqlCommand(sql, connection);



            SqlDataReader reader = cmd.ExecuteReader();



            // Überschrift der Tabelle
            WriteTrenner(reader.FieldCount, 12);
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.Write($"| {reader.GetName(i),12} ");
            }
            Console.WriteLine(" |");
            Console.ForegroundColor = ConsoleColor.White;



            WriteTrenner(reader.FieldCount, 12);
            while (reader.Read())
            {
                int id1 = (int)reader[0];
                int id2 = (int)reader["id"];
                int id3 = reader.GetInt32(0);
                string vn1 = reader[1] as string;
                string vn2 = reader["vorname"] as string;
                string vn3 = reader.GetString(1);
                string nn1 = reader.GetFieldValue<string>(2);



                for (int i = 0; i < reader.FieldCount; i++)
                {
                    if (reader.GetFieldType(i) == typeof(DateTime))
                    {
                        Console.Write($"| {((DateTime)reader[i]),12: yyyy-MM-dd} ");
                    }
                    else if (reader.GetName(i).ToLower() == "geschlecht")
                    {
                        Console.Write($"| {(Geschlecht)reader[i],12} ");
                    }
                    else if (reader.GetName(i).ToLower() == "gehalt")
                    {
                        Console.Write($"| {reader[i],12:0,000.00}€ ");
                    }
                    else
                    {
                        Console.Write($"| {reader[i],12} ");
                    }
                }
                Console.WriteLine(" |");
                WriteTrenner(reader.FieldCount, 12);
            }
            reader.Close();
        }



        // Put
        static void Update(int id, Person p)
        {
            string sql = @"update [tblperson]
                set vorname=@vorname, nachname=@nachname, geschlecht=@geschlecht,
                geburt=@geburt, gehalt=@gehalt
                where id=@id";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@vorname", p.Vorname);
            cmd.Parameters.AddWithValue("@nachname", p.Nachname);
            cmd.Parameters.AddWithValue("@geschlecht", p.Geschlecht);
            cmd.Parameters.AddWithValue("@geburt", p.Geburtsdatum);
            cmd.Parameters.AddWithValue("@gehalt", p.Gehalt);
            cmd.Parameters.Add(new SqlParameter("@id", id));
            cmd.ExecuteNonQuery();
            // korrekt?
            // sql = sql.Replace("@vorname", p.Vorname.ToSql());
            // $"values ( '{p.Vorname.ToSQL()}'
        }



        // Post
        static void Insert(Person p)
        {
            string sql = @"insert into [tblperson]
                (vorname,nachname,geschlecht,geburt,gehalt)
                values (@vorname,@nachname,@geschlecht,@geburt,@gehalt)";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@vorname", p.Vorname);
            cmd.Parameters.AddWithValue("@nachname", p.Nachname);
            cmd.Parameters.AddWithValue("@geschlecht", p.Geschlecht);
            cmd.Parameters.AddWithValue("@geburt", p.Geburtsdatum);
            cmd.Parameters.AddWithValue("@gehalt", p.Gehalt);



            cmd.ExecuteNonQuery();



            // LastId



            // korrekt?
            // sql = sql.Replace("@vorname", p.Vorname.ToSql());
            // $"values ( '{p.Vorname.ToSQL()}'
        }



        static void CreateTable()
        {
            string sql = @"
                drop table [tblPerson];

                create table [tblPerson](
                [Id] int primary key identity(1,1),
                [Vorname] nvarchar(30),
                [Nachname] nvarchar(30),
                [Geburt] Date,
                [Gehalt] decimal,
                [Geschlecht] int)";
            string connectionstring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TestDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            /*
            SELECT
            object_id
            FROM sys.tables
            WHERE name = 'tblPerson';
            */
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                Console.WriteLine("CONNECTED");
                SqlCommand testCommand = new SqlCommand("SELECT object_id FROM sys.tables WHERE name = 'tblPerson'", connection);
                int? id = (int?)testCommand.ExecuteScalar();
                Console.WriteLine(id);
                // if (!id.HasValue)
                {
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.ExecuteNonQuery(); // Für Änderungsabfragen
                }
                // object result = command.ExecuteScalar(); // Gibt einen Wert zurück
                // SqlDataReader reader = command.ExecuteReader(); // Liefert einen Iterator,
                // der über ein komplette Tabelle laufen kann



            } // connection.Close();
        }



        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            string strCon = ConfigurationManager.ConnectionStrings["testdb"].ConnectionString;
            connection = new SqlConnection(strCon);
            // PersonenGenerator.Instance.Generate(25);
            try
            {
                // CreateTable();
                connection.Open();
                //foreach (Person p in PersonenGenerator.Instance.GetPersonen())
                //{
                // Insert(p);
                //}


                PrintPersonList(GetPersonen());
                //PrintPersonList(GetPersonenNotGenericButKindOfGeneric());
                //PrintPersonList(GetPersonenReflection());


                //Lesen();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection?.Close();
            }
        }
    }
}