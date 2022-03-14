using System;
using System.Linq;

namespace ModelsApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // создаем два объекта Company
                Product product1 = new Product { Name = "Product1", Price = 200 };
                Product product2 = new Product { Name = "Product2", Price = 100 };
                // добавляем их в БД
                db.Products.Add(product1);
                db.Products.Add(product2);
                db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены");
                // получаем объекты из бд и выводим на консоль
                var users = db.Products.ToList();
                Console.WriteLine("Список объектов:");
                foreach (Product u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Price}");
                }
            }
            Console.Read();
        }
    }
}
