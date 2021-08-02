using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace asp_net_ef_codefirst.Context.Managers
{
    public class DatabaseContext:DbContext
    {
        public DbSet<Kisiler> Kisiler { get; set; }
        public DbSet<Categori> Categoris { get; set; }
        public DbSet<Gorev> Gorevs { get; set; }

        public DatabaseContext()
        {

            Database.SetInitializer(new VeritabaniOlusturucu());
        }
    }
    public class VeritabaniOlusturucu:CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            base.Seed(context);   // Nesneyi oluşturduk ve içersine bilgileri aktardık
            Kisiler kisi1 = new Kisiler();

            kisi1.TC = "25589966612";
            kisi1.Sifre = "1234";
            kisi1.Telefon = "0544 419 0546";

            context.Kisiler.Add(kisi1);

            context.SaveChanges();
            List<Kisiler> tumKisiler = context.Kisiler.ToList();

            
           
        }

    }
}