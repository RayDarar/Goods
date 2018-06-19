using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ansarRyspekov.cSharp.Test.Marketer
{
    public class Marketer
    {
        public Marketer()
        {
            fullName = "";
            wrongAccess = 0;
            login = "";
            password = "";
            WhichIsAvaliable = 0;
            WhichIsUnavaliable = 0;
        }
        public string fullName { get; set; }//Имя продавца, в коде нужен сет и гетт
        public DateTime lastEnter { get; set; }//Последний вход
        public int wrongAccess { get; set; }//Кол-во ошибок пользователя
        public string login { get; set; }//Логин, в коде нужен сет, а без гетта никак
        public string password { get; set; }//Пароль, в коде нужен сет, а без гетта никак
        public int WhichIsAvaliable { get; set; }//Счет товаров в наличии, в коде нужен сет, а без гетта никак
        public int WhichIsUnavaliable { get; set; }//Счет товаров не в наличии, в коде нужен сет, а без гетта никак
        public string printTime() { return lastEnter.ToLongDateString() + " | " + lastEnter.ToLongTimeString(); }
    }
}
