using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Currency
    {
        public string Name { get; set; }
        public double ExRate { get; set; }

        public Currency()
        {
            Name = "UAH";
            ExRate = 1.0;
        }

        public Currency(string name, double exRate)
        {
            Name = name;
            ExRate = exRate;
        }

        public Currency(Currency other)
        {
            Name = other.Name;
            ExRate = other.ExRate;
        }

        public override string ToString()
        {
            return $"{Name} (Курс: {ExRate})";
        }
    }

}
