namespace App.Migrations
{
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Web.Hosting;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<App.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "App.Models.ApplicationDbContext";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if (!context.People.Any())
            {
                SeedPeople(context);
            }

            if (!context.Cities.Any())
            {
                SeedCities(context);
            }

        }

        private void SeedCities(ApplicationDbContext context)
        {
            string filePath = HostingEnvironment.MapPath("~/Content/capitals.txt");
            var reader = new StreamReader(filePath);
            using (reader)
            {
                var line = reader.ReadLine();
                line = reader.ReadLine();
                while (line != null)
                {
                    var data = line.Split(new[] { ',' }, 2);
                    string country = data[0];
                    string name = data[1];

                    context.Cities.Add(new City()
                    {
                        Name = name,
                        Country = country,

                    });

                    line = reader.ReadLine();
                }
            }

            context.SaveChanges();
        }

        private void SeedPeople(ApplicationDbContext context)
        {
            context.People.Add(new Person
            {
                FullName = "Mark Zuckerberg",
                ImageUrl = "https://31.media.tumblr.com/avatar_0181a7cfa719_128.png",
                Address = "Palo Alto",
                Email = "mark@facebook.com",
                Status = "Married",
                Age = 28

            });

            context.People.Add(new Person
            {
                FullName = "Steve Jobs",
                ImageUrl = "https://38.media.tumblr.com/avatar_204910015583_128.png",
                Address = "Cupertino",
                Email = "steve@apple.com",
                Status = "Dead",
                Age = 55
            });

            context.People.Add(new Person
            {
                FullName = "Bill Gates",
                ImageUrl = "https://38.media.tumblr.com/avatar_65642d38e795_128.png",
                Address = "Redmond",
                Email = "bill@microsoft.com",
                Status = "Rich",
                Age = 52
            });

            context.SaveChanges();
        }
    }
}
