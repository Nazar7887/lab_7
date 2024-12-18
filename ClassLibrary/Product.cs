using System;

namespace ClassLibrary
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public Currency Cost { get; set; }
        public int Quantity { get; set; }
        public string Producer { get; set; }
        public double Weight { get; set; }

        public int ExpiryDays { get; set; }
        public int ExpiryMonths { get; set; }
        public int ExpiryYears { get; set; }

        public Product()
        {
            Name = "Unknown";
            Price = 0.0;
            Cost = new Currency();
            Quantity = 0;
            Producer = "Unknown";
            Weight = 0.0;
            ExpiryDays = 0;
            ExpiryMonths = 0;
            ExpiryYears = 0;
        }

        public Product(string name, double price, Currency cost, int quantity, string producer, double weight)
        {
            Name = name;
            Price = price;
            Cost = cost;
            Quantity = quantity;
            Producer = producer;
            Weight = weight;
            ExpiryDays = 0;
            ExpiryMonths = 0;
            ExpiryYears = 0;
        }

        public Product(Product other)
        {
            Name = other.Name;
            Price = other.Price;
            Cost = new Currency(other.Cost);
            Quantity = other.Quantity;
            Producer = other.Producer;
            Weight = other.Weight;
            ExpiryDays = other.ExpiryDays;
            ExpiryMonths = other.ExpiryMonths;
            ExpiryYears = other.ExpiryYears;
        }

        public double GetPriceInUAH()
        {
            return Price * Cost.ExRate;
        }

        public double GetWeightInPounds()
        {
            return Weight * 2.20462; 
        }

        public int GetExpiryInDays()
        {
            return ExpiryDays + (ExpiryMonths * 30) + (ExpiryYears * 365);
        }

        public void SetExpiryDate()
        {
            Console.WriteLine("Виберіть одиницю вимірювання терміну придатності:");
            Console.WriteLine("1. Дні");
            Console.WriteLine("2. Місяці");
            Console.WriteLine("3. Роки");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Введіть термін придатності в днях: ");
                    ExpiryDays = int.Parse(Console.ReadLine());
                    break;
                case 2:
                    Console.Write("Введіть термін придатності в місяцях: ");
                    ExpiryMonths = int.Parse(Console.ReadLine());
                    break;
                case 3:
                    Console.Write("Введіть термін придатності в роках: ");
                    ExpiryYears = int.Parse(Console.ReadLine());
                    break;
                default:
                    Console.WriteLine("Невірний вибір");
                    break;
            }
        }

        public void PrintExpiryDate()
        {
            Console.WriteLine($"Термін придатності: {ExpiryDays} днів, {ExpiryMonths} місяців, {ExpiryYears} років");
        }

        public override string ToString()
        {
            return $"Назва: {Name}, Вартість: {Price} {Cost.Name}, Кількість: {Quantity}, Виробник: {Producer}, Вага: {Weight} кг";
        }
    }

}
