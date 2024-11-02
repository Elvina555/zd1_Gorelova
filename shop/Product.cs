using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop
{
    class Product
    {
        private double price;
        private string name;
        public Product(string Name, double Price)
        {
            this.name = Name;
            this.price = Price;
        }
        //открываем поле для определения одинакого названия в Shop
        public string Name
        {
            get
            {
                return name;
            }
        }
        //открываем поле для подсчета стоимости в Shop
        public double Price
        {
            get
            {
                return price;
            }
        }
        //метод для вывода информации
        public string GetInfo()
        {
            return $"Наименование: {name}, Цена: {price}";
        }

    }
}
