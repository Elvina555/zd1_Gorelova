using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shop
{
    class Shop
    {
        private Dictionary<Product, int> products;
        private double profit;

        //конструктор
        public Shop()
        {
            products = new Dictionary<Product, int>();
            profit = 0;
        }
        //метод для добавления нового продукта с указанным количеством
        public void AddProduct(Product product, int count)
        {
            products.Add(product, count);
        }
        //метод для сохранения списка товаров
        public void CreateProduct(string name, double price, int count)
        {
            if (FindByName(name) != null)
            {
                MessageBox.Show($"Продукт '{name}' уже существует!");
                return;
            }
            products.Add(new Product(name, price), count);
        }

        //метод для того,чтобы сообщать пользователям о их покупках 
        public void WriteAllProducts()
        {
            MessageBox.Show("Вы купили: ");
            foreach (var product in products)
            {
                MessageBox.Show(product.Key.GetInfo() + "; Количество: " + product.Value);
            }
        }
        //метод для доступа ко всей коллекции товаров
        public List<Product> GetAllProducts()
        {

            List<Product> list = new List<Product>();


            foreach (var product in products)
            {
                list.Add(product.Key);
            }


            return list;
        }
        //метод для нахождения товара по имени который уже существует
        public Product FindByName(string name)
        {
            foreach (var product in products.Keys)
            {
                if (product.Name == name)
                {
                    return product;
                }
            }
            return null;
        }
        //метод, который проверяет наличие товара и выводит информацию о прибыли магазина
        public void Sell(string produc, int product)
        {
            Product toSell = FindByName(produc);

            if (toSell != null)
            {

                if (products[toSell] <= 0)
                {
                    MessageBox.Show("Нет в наличии");
                }
                else if (products[toSell] < product)
                {
                    MessageBox.Show("Товара на складе больше нет!");
                }
                else
                {
                    products[toSell] -= product;
                    profit += toSell.Price * product;
                    MessageBox.Show($"Продано: {toSell.Name}. Осталось: {products[toSell]}");
                    MessageBox.Show($"Прибыль: {profit}");


                    if (products[toSell] <= 0)
                    {
                        MessageBox.Show("Нет в наличии");
                    }
                }
            }
            else
            {
                MessageBox.Show("Товар не найден");
            }
           
        }
        //метод, который поставляет товар на склад
        public void PopolnProduct(string name, int count)
        {
            Product product = FindByName(name);

            if (product != null)
            {
                products[product] += count;
                MessageBox.Show($"Продукт '{name}' был доставлен на склад. Текущее количество: {products[product]}");
            }
            else
            {
                MessageBox.Show("Товар не найден");
            }
        }
    }
}
