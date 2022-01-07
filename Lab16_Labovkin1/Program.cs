using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;


namespace Lab16_Labovkin1
{
    class Program
    {
        static void Main(string[] args)
        {
            //объявляем пустую строку
            string jsonString = String.Empty;
            //открываем файл для чтения
            using(StreamReader sr= new StreamReader("../../../Products.json"))
            {
                //считываем весь файл 
                jsonString= sr.ReadToEnd();
            }
            //превращаем строку в массив
            Product[] products = JsonSerializer.Deserialize<Product[]>(jsonString);
            //создаем условие, где у первого товара максимальная стоимость
            Product maxProduct = products[0];
            //перебираем товары для нахождения наибольшей стоимости
            foreach (Product pr in products)
            {
                if (pr.ProductPrice > maxProduct.ProductPrice)
                {
                    maxProduct = pr;
                }
            }
            //выводим всю информацию о товаре
            Console.WriteLine($"{maxProduct.ProductCode} {maxProduct.ProductName} {maxProduct.ProductPrice}");
            Console.ReadKey();
        }
    }
}
