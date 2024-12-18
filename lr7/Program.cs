using System;
using System.Collections.Generic;
using ClassLibrary;

namespace lr7
{
    class Program
    {
        public static List<Product> CreateProductList(int n)
        {
            List<Product> products = new List<Product>();
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nВведіть дані для товару #{i + 1}:");

                Console.Write("Назва товару: ");
                string name = Console.ReadLine();

                Console.Write("Ціна: ");
                double price = double.Parse(Console.ReadLine());

                Console.Write("Валюта (назва): ");
                string currencyName = Console.ReadLine();

                Console.Write("Курс валюти: ");
                double exRate = double.Parse(Console.ReadLine());

                Console.Write("Кількість: ");
                int quantity = int.Parse(Console.ReadLine());

                Console.Write("Виробник: ");
                string producer = Console.ReadLine();

                Console.Write("Вага (кг): ");
                double weight = double.Parse(Console.ReadLine());

                Currency cost = new Currency(currencyName, exRate);
                Product product = new Product(name, price, cost, quantity, producer, weight);

                product.SetExpiryDate(); 

                products.Add(product);
            }

            return products;
        }

        public static void PrintProduct(Product product)
        {
            Console.WriteLine("\nДеталі товару:");
            Console.WriteLine(product.ToString());
            Console.WriteLine($"Ціна в гривнях: {product.GetPriceInUAH():F2} UAH");
            Console.WriteLine($"Вага в фунтах: {product.GetWeightInPounds():F2} lbs");
            product.PrintExpiryDate(); 
        }

        public static void PrintAllProducts(List<Product> products)
        {
            Console.WriteLine("\nВсі товари на складі:");
            foreach (var product in products)
            {
                PrintProduct(product);
            }
        }

        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
            int choice = 0;

            while (choice != 5)
            {
                Console.WriteLine("\nМеню:");
                Console.WriteLine("1. Ввести дані про товари");
                Console.WriteLine("2. Вивести інформацію про один товар");
                Console.WriteLine("3. Вивести всі товари");
                Console.WriteLine("4. Пошук за найменуванням товару");
                Console.WriteLine("5. Вихід");

                Console.Write("Виберіть опцію: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Скільки товарів ви хочете додати? ");
                        int n = int.Parse(Console.ReadLine());
                        products = CreateProductList(n);
                        break;

                    case 2:
                        Console.Write("Введіть номер товару для перегляду (1 - {0}): ", products.Count);
                        int productIndex = int.Parse(Console.ReadLine()) - 1;
                        if (productIndex >= 0 && productIndex < products.Count)
                        {
                            PrintProduct(products[productIndex]);
                        }
                        else
                        {
                            Console.WriteLine("Невірний індекс товару.");
                        }
                        break;

                    case 3:
                        PrintAllProducts(products);
                        break;

                    case 4:
                        Console.Write("Введіть найменування товару для пошуку: ");
                        string searchName = Console.ReadLine();
                        var foundProducts = products.FindAll(p => p.Name.Contains(searchName, StringComparison.OrdinalIgnoreCase));
                        if (foundProducts.Count > 0)
                        {
                            foreach (var product in foundProducts)
                            {
                                PrintProduct(product);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Товари не знайдені.");
                        }
                        break;

                    case 5:
                        Console.WriteLine("Вихід з програми...");
                        break;

                    default:
                        Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                        break;
                }
            }
        }
    }
}
