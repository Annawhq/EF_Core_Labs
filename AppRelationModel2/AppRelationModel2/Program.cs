using System;
using System.Linq;

namespace AppRelationModel2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // создаем два объекта Company
                Company comp1 = new Company { Name = "РИНХ" };
                Company comp2 = new Company { Name = "ЮФУ" };
                db.Companies.AddRange(comp1, comp2);

                // создаем два объекта User
                User user1 = new User { Name = "Tom", Company = comp1 };
                User user2 = new User { Name = "Alice", Company = comp2 };
                // добавляем их в БД
                db.Users.AddRange(user1, user2);

                db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены");
                // получаем объекты из бд и выводим на консоль
                var comp = db.Companies.ToList();
                Console.WriteLine("Список компаний:");
                foreach (Company u in comp)
                {
                    Console.WriteLine($"{u.Id}.{u.Name}");
                }
                // получаем объекты из бд и выводим на консоль
                var users = db.Users.ToList();
                Console.WriteLine("Список сотрудников:");
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Name} работает в компании: {u.Company.Name}");
                }
            }
            Console.Read();
        }
    }
}
