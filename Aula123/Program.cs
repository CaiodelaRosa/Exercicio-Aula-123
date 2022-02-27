using System;
using Aula123.Entities;
using Aula123.Entities.Enums;
using System.Globalization;

namespace Aula123
{
    class Program
    {
        static void Main(string[] args)
        {
            /// Declaring Client

            Console.WriteLine("Enter cliente data: ");
            Console.Write("Name: ");
            string nameClient = Console.ReadLine();
            Console.Write("Email: ");
            string emailClient = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());
            
            Client cliente = new Client(nameClient, emailClient, birthDate);

            /// Declaring order and order status

            Console.WriteLine("Enter order data:");
            Console.Write("Status (Pending_Payment/Processing/Shipped/Delivered): ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());

            Order order = new Order(status, cliente);
            /// Declaring order items

            Console.Write("How many items to this order? ");
            int quantItems = int.Parse(Console.ReadLine());
            
            for (int i = 1; i <= quantItems; i++)
            {
                Console.WriteLine($"Enter #{i} item data:");
                Console.Write("Product name: ");
                string productName = Console.ReadLine();
                Console.Write("Product price: ");
                double priceProduct = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());
                
                Product product = new Product(productName, priceProduct);
                OrderItem orderItem = new OrderItem(quantity, priceProduct, product);
                order.Items.Add(orderItem);
            }

            Console.WriteLine(order);
        }
    }
}

