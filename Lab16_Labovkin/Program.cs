using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.IO;

namespace Lab16_Labovkin
{
    class Program
    {
        static void Main(string[] args)
        {
            const int n = 5;
            //создаем массив из 5 товаров
            Product[] products = new Product[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Введите код товара:");
                //сохраняем пользовательский ввод в переменную
                int productcode = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите название товара");
                string productname = Console.ReadLine();
                Console.WriteLine("Введите цену товара");
                //сохраняем пользовательский ввод в переменную
                double productprice = Convert.ToDouble(Console.ReadLine());
                //создаем экземпляр класса и инициализируем его
                products[i] = new Product() { ProductCode = productcode, ProductName = productname, ProductPrice = productprice };
            }
            //созадем экземпляр для записи русских букв
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                //поле определяющее кодировку
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                //устанавливаем дополнительные пробелы
                WriteIndented = true
            };
            //превращаем массив в строку
            string jsonString = JsonSerializer.Serialize(products, options);
            //записываем строку в файл
            using (StreamWriter sw = new StreamWriter("../../../Products.json")) /*поднимаемся на 3 уровня*/
            {
                sw.WriteLine(jsonString);
            }
        }
    }

}
