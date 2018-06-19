using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ansarRyspekov.cSharp.Test.Goods
{
    public class Goods
    {
        public Goods() { }
        public Goods(string productName, string vendorCode, int availlability, int storage, int discount, int price, Marketer.Marketer marketerer)
        {
            this.productName = productName;
            this.vendorCode = vendorCode;
            this.availlability = availlability;
            if(storage >= 0 && storage <= 9)
                this.storage = "Астана";
            else if(storage >= 10 && storage <= 19)
                this.storage = "Алматы";
            else if(storage >= 20 && storage <= 29)
                this.storage = "Караганда";
            this.discount = discount;
            this.price = price;
            this.price_D = price - ((price * discount) / 100);
            this.marketerer = marketerer;
        }
        public string productName { get; set; }//Название продукта, в коде нужен сет, а без гетта никак
        public string vendorCode { get; set; }//Артикул товара, в коде нужен сет, а без гетта никак
        public string storage { get; set; }//Местоположение склада, в коде нужен сет, а без гетта никак
        public int availlability { get; set; }//Наличие я сделал как int, чтобы дальше по коду было легче
        DateTime ariveDate { get; set; }//Дата прибытия
        DateTime supplyDate { get; set; }//Дата поставки
        public int discount { get; set; }//Скидка, в коде нужен сет и гетт
        public int price { get; set; }//Цена, в коде нужен сет и гетт
        public int price_D { get; set; }//Цена с учетом скидки, в коде нужен сет, а без гетта никак
        public Marketer.Marketer marketerer { get; set; }//Хозяин, в коде нужен сет и гетт
        public void print()
        {
            Console.WriteLine("* Продукт: " + productName + " (" + vendorCode + "), местоположение: " + storage);
            Console.Write("* ");
            if(availlability == 0)
                Console.ForegroundColor = ConsoleColor.DarkRed;
            else if(availlability < 5)
                Console.ForegroundColor = ConsoleColor.Red;
            else
                Console.ForegroundColor = ConsoleColor.Green;
            Console.Write((availlability == 0 ? "Товара нет в наличии, " : "Товар есть в наличии (" + availlability + " шт.), "));

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(price + "$");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" (-" + discount + "%) = ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(price_D + "$");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("* Продавец: " + marketerer.fullName + "\n");
        }
    }
}