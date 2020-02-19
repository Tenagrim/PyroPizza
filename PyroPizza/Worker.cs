using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PyroPizza
{
    [Serializable]
    class Worker
    {
        private static Random rand = new Random();
        public static string nameList = "Орехов Остап Никитевич|Гордеев Терентий Вениаминович|Ильин Гаянэ Всеволодович|Щукин Андрей Федосеевич|Дмитриев Велорий Арсеньевич|Доронин Нинель Германович|Борисов Сергей Андреевич|Мясников Демьян Кимович|Филатов Гордий Лаврентьевич|Сорокин Корней Антонинович|Фомичёв Тихон Феликсович|Гущин Гордей Рубенович|Кудрявцев Филипп Владимирович|Орлов Прохор Тимурович|Мамонтов Леонтий Петрович|Коновалов Клим Максимович|Никифорова Полианна Вениаминовна|Яковлева Полианна Наумовна|Гордеева Гера Григорьевна|Рожкова Виоланта Онисимовна|Лазарева Жаклин Альбертовна|Копылова Гелана Константиновна|Турова Кира Семеновна|Ермакова Грета Мироновна|Волкова Мальта Георгьевна|Анисимова Томила Аркадьевна|Аксёнова Раиса Созоновна|Владимирова Эльвина Даниловна|Куликова Мила Игоревна|Одинцова Дания Христофоровна|Федотова Юзефа Эльдаровна|Некрасова Амира Пантелеймоновна";
        public static string posList = "курьер,повар,кассир";
        public string Name { get; set; }
        public string Position { get; set; }
        public int OrderCount { get { return orderCount; } }
        private int index;
        private int orderCount;
        public int Index { get { return index; } }
        public Worker()
        {
            Name = RandName();
            Position = RandPos();
            orderCount = 0;
        }
        public Worker(string name, string pos)
        {
            Name = name;
            Position = pos;
            orderCount = 0;
        }
        private string RandName()
        {
            string[] names = nameList.Split('|');
            return names[rand.Next(0,names.Length)];
        }
        private string RandPos()
        {
            string[] names = posList.Split(',');
            return names[rand.Next(0, names.Length)];
        }
        public void SetIndex(int i)
        {
            index = i;
        }
        public void AppendOrder()
        {
            orderCount++;
        }
        public override string ToString()
        {
            return Name + " ("+ index.ToString() + ")" ;
        }
    }
}
