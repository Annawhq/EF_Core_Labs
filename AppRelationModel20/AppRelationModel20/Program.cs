using System;
using System.Linq;

namespace AppRelationModel20
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // пересоздаем базу данных
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                Company microsoft = new Company { Name = "Microsoft" };
                Company google = new Company { Name = "Google" };
                db.Companies.AddRange(microsoft, google);
                User tom = new User { Name = "Tom", Age = 36, Company = microsoft };
                User bob = new User { Name = "Bob", Age = 39, Company = google };
                User alice = new User { Name = "Alice", Age = 28, Company = microsoft };
                User kate = new User { Name = "Kate", Age = 25, Company = google };
                db.Users.AddRange(tom, bob, alice, kate);
                db.SaveChanges();
            }
            using (ApplicationContext db = new ApplicationContext())
            {
                // суммарный возраст всех пользователей
                int sum1 = db.Users.Sum(u => u.Age);
                // суммарный возраст тех, кто работает в Microsoft
                int sum2 = db.Users.Where(u => u.Company.Name == "Microsoft")
                .Sum(u => u.Age);
                Console.WriteLine(sum1);
                Console.WriteLine(sum2);
            }
        }
    }
}
