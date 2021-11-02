using System;
using System.Collections.Generic;


namespace VariantC
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ProductsInOrder> SendProducts = new(); // Создание списка товаров в заказе 
            List<Order> Orders = new(); // Создание списка всех заказов


            Product mouse = new("Мышь проводная", "изготовленна в Германии", 8); // Создание товара
            Product keyboard = new("Клавиатура проводная", "изготовленна в Украине", 5); // Создание товара
            Product gamepad = new("Джойстик проводной", "изготовленна в Китае", 2); // Создание товара
            SendProducts.Add(new ProductsInOrder(mouse, 4)); // Добавление товара в список товаров
            SendProducts.Add(new ProductsInOrder(keyboard, 1)); // Добавление товара в список товаров
            SendProducts.Add(new ProductsInOrder(gamepad, 2)); // Добавление товара в список товаров


            Order SendOrder = new(ref SendProducts, new DateTime(2021, 10, 24)); // Создание заказа
            Orders.Add(SendOrder); // Добавление заказа в список заказов


            Product table = new("Стол для компьютера", "из дуба", 25); // Создание товара
            Product chair = new("Стул для компьютера", "из тополя", 15); // Создание товара
            SendProducts.Add(new ProductsInOrder(table, 1)); // Добавление товара в список товаров
            SendProducts.Add(new ProductsInOrder(chair, 1)); // Добавление товара в список товаров
            SendProducts.Add(new ProductsInOrder(keyboard, 1)); // Добавление товара в список товаров
                

            SendOrder = new(ref SendProducts, new DateTime(2021, 10, 24)); // Создание заказа
            Orders.Add(SendOrder); // Добавление заказа в список заказов


            Product monitor = new("монитор", "частота 144 герц", 35); // Создание товара
            SendProducts.Add(new ProductsInOrder(monitor, 1)); // Добавление товара в список товаров
            SendProducts.Add(new ProductsInOrder(gamepad, 3)); // Добавление товара в список товаров


            SendOrder = new(ref SendProducts, new DateTime(2021, 10, 26)); // Создание заказа
            Orders.Add(SendOrder); // Добавление заказа в список заказов


            SendOrder = Order.CreateNewOrder(Orders, new DateTime(2021, 10, 24), ref SendProducts);
            Orders.Add(SendOrder); // Добавление заказа в список заказов


            Order.RemoveOrder(Orders, monitor, 1); // Удаление заказа, содержащего 4 ттовара типа mouse
            foreach (var item in Orders)
            {
                Order.ShowOrder(item);
            }
            Order.ShowNumber(Orders, 100, 3); // Вывод номеров заказов, сумма которых не превышает 100, и содержащих 
        }
    }
}
