using System;
using System.Collections.Generic;
using System.Linq;

namespace PyroPizza
{
    public enum orderStatus { accepted, inProgress, prepared, inDelivery, done, cancelled }
    [Serializable]
    class Order 
    {
        public int ID { get; }
        public double Cost { get { return GetCost(); } }
        public List<MenuPosition> Content { get; }
        public List<Worker> WorkersInvolved { get; }
        public string Status { get; set; }
        public bool delivery { get; set; }
        public int deliveryCost;
        private int index;
        public int Index { get { return index; } }
        public Order()
        {
            Content = new List<MenuPosition>();
            Status = "Формируется";
            delivery = false;
            ID = DateTime.Now.GetHashCode();
            WorkersInvolved = new List<Worker>();
        }
        public Order(List<MenuPosition> cont)
        {
            Content = cont;
            ID = DateTime.Now.GetHashCode();
            WorkersInvolved = new List<Worker>();
        }
        public void Add(Menu m, int index)
        {
            var select = from p in m.Content
                         where p.Index == index
                         select p;
            if (select.Count() == 0) throw new ArgumentException("Ошибка при добавлении позиции в заказ");

            Content.Add(select.First());
        }
        public void RemoveAt(int index)
        {
            Content.RemoveAt(index);
        }
        private double GetCost()
        {
            double res = 0;
            foreach (var i in Content)
                res += i.Cost;
            if (delivery) res += deliveryCost;
            return res;
        }
        public void AppendWorker(Worker w)
        {
            WorkersInvolved.Add(w);
            w.AppendOrder();
        }
        public void SetIndex(int i)
        {
            index = i;
        }
        public void SetStatus(string st)
        {
            Status = st;
        }
        public override string ToString()
        {
            string str = "";

            str += index + " " + Cost+"p. | ";
            str += Content.First().Name + " | ";
            str += Status + " |";
            if (delivery) str += " Доставка ";

            return str;
        }
    }
}
