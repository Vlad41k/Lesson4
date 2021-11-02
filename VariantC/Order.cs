using System;
using System.Collections.Generic;
using System.Text;

namespace VariantC
{
    class Order
    {
        private static int i = 1;
        public List<ProductsInOrder> Products = new();
        public int Number { get; init; } 
        public DateTime Date { get; init; }
        // Конструктор
        public Order (ref List<ProductsInOrder> products, DateTime date)
        {
            Number = i++;
            Products.AddRange(products.ToArray());
            Date = date;
            products.Clear();
        } 

        // Вывод информации о заказе
        public static void ShowOrder(Order order)
        {
            Console.WriteLine($"Номер заказа: {order.Number}");

            Console.WriteLine($"Товары в заказе:");
            foreach (var item in order.Products)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"Дата заказа: {order.Date:d}\n");
        }

        // Вывод номеров заказов, содержащих данный товар
        public static void ShowNumber(List<Order> orders, Product product)
        {
            StringBuilder str = new("Номера заказов, содержащих \"" + product.Title + "\": ");
            foreach (var order in orders)
            {
                foreach (var products in order.Products)
                {
                    if (product.Title == products.Item.Title)
                        str.Append(order.Number + " ");
                }
            }
            Console.WriteLine(str.ToString());
        }

        // Вывод номеров заказов, не содержащих данный товар, и поступивших в заданную дату
        public static void ShowNumber(List<Order> orders, Product product, DateTime date)
        {
            StringBuilder str = new("Номера заказов, не содержащих \"" + product.Title +
                "\", и заказанных " + date.ToString("d") + ": " );
            foreach (var order in orders)
            {
                var check = true;
                foreach (var products in order.Products)
                {
                    if (product.Title == products.Item.Title)
                        check = false;
                }
                if (date != order.Date)
                    check = false;
                if (check == true)
                    str.Append(order.Number + " ");
            }
            Console.WriteLine(str.ToString());
        }  
      
        // Вывод номеров заказов, стоимость которых не превышает заданную,, и содержащих данное количество товаров
        public static void ShowNumber(List<Order> orders, double price, int count)
        {
            StringBuilder str = new("Номера заказов, стоимость которых не превышает " + price +
                "$ и имеет " + count + " различных товаров: ");
            foreach (var order in orders)
            {
                var check = true;
                double totalprice = 0;
                int totalcount = 0;
                foreach (var products in order.Products)
                {
                    totalprice += products.Item.Price;
                    totalcount++;
                }
                if (totalprice > price || totalcount != count) 
                    check = false;
                if (check == true)
                    str.Append(order.Number + " ");
            }
            Console.WriteLine(str.ToString());
        }

        // Удаление заказов, содержащих данный продукт в заданном количестве
        public static void RemoveOrder(List<Order> orders, Product product, int count)
        {

            for (int i = 0; i < orders.Count; i++) // перебирает все заказы
            {
                var check = false;
                for (int j = 0; j < orders[i].Products.Count; j++) // Перебирает все товары в заказе
                {
                    if (orders[i].Products[j].Item.Title == product.Title && orders[i].Products[j].Amount == count)
                        check = true;
                }
                if (check == true) 
                {
                    orders.RemoveAt(i); // Удалить заказ
                    i--;
                }
            }
        }

        //  Формирование нового заказа, состоящего из товаров, заказанных в текущий день.
        public static Order CreateNewOrder(List<Order> orders, DateTime date, ref List<ProductsInOrder> sendproducts)
        {
            foreach (var order in orders)
            {
                if (order.Date == date)
                {
                        sendproducts.AddRange(order.Products);
                }
            }
            Order SendOrder = new(ref sendproducts, new DateTime(2021, 11, 30)); // Создание заказа
            return SendOrder;
        }
    }
}
