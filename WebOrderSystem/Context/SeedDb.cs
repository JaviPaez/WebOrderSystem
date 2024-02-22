using WebOrderSystem.Models;

namespace WebOrderSystem.Context
{
    public class SeedDb
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (context.Members.Any() || context.Products.Any() || context.Orders.Any())
            {
                Console.WriteLine("Database already has data.");
                return;
            }

            var members = new[]
            {
                new Member { Name = "Juan Acosta" },
                new Member { Name = "Andrea Lorenzo" },
                new Member { Name = "Pablo Guirao" }
            };
            context.Members.AddRange(members);

            var products = new[]
            {
                new Product { Name = "Mesa" },
                new Product { Name = "Silla" },
                new Product { Name = "Cama" }
            };
            context.Products.AddRange(products);
            
            context.SaveChanges();

            var orders = new[]
            {
                new Order { MemberId = 1, ProductId = 1, DateOrder = DateTime.Now },
                new Order { MemberId = 2, ProductId = 2, DateOrder = DateTime.Now },
                new Order { MemberId = 3, ProductId = 3, DateOrder = DateTime.Now }
            };
            context.Orders.AddRange(orders);

            context.SaveChanges();
            Console.WriteLine("Test data inserted successfully.");
        }
    }
}
