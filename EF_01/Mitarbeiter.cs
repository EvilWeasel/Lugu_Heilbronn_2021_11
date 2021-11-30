using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_01
{
    class Abteilung
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Mitarbeiter> Mitarbeiterliste { get; set; }

        public Abteilung()
        {
            Mitarbeiterliste = new List<Mitarbeiter>();
        }




    }

    class Mitarbeiter
    {
        //[Key]
        //public int Mnr { get; set; }
        public int Id { get; set; }
        [Required]
        public string Vorname { get; set; }
        [Required]
        public string Nachname { get; set; }
        public decimal Gehalt { get; set; }

        [Range(typeof(DateTime),"1.1.1900","31.12.2099")]
        public DateTime Geburt { get; set; }

        //public int AbteilungsId { get; set; }
        public virtual Abteilung Abteilung { get; set; }



    }

    class MAContext : DbContext
    {
        private static string strCon = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TestEF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=True";
        public MAContext() : base(strCon)
        {

            //Database.SetInitializer(new CreateDatabaseIfNotExists<MAContext>());
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MAContext>());


        }


        public DbSet<Mitarbeiter> Mitarbeiterliste { get; set; }
        public DbSet<Abteilung> Abteilungsliste { get; set; }


    }
}
