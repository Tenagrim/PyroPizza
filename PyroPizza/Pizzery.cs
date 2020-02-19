using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PyroPizza
{
    [Serializable]
    class Pizzery
    {
        public Staff staff;
        public Storage storage;
        public Menu menu;
        public Journal journal;
        public OrderList orderList;
        public Wallet wallet;
        public Pizzery()
        {
            staff = new Staff();
            storage = new Storage();
            menu = new Menu();
            journal = new Journal();
            orderList = new OrderList();
            wallet = new Wallet();
        }
        public List<Ingredient> GetKnownIngredients()
        {
            List<Ingredient> res = new List<Ingredient>();

            foreach (var i in storage.Content)
            {
                Ingredient ai = i as Ingredient;
                if (ai != null)
                    res.Add(ai);
            }
            return res;
        }
        public void SetSalary(int ind, int sal)
        {
            wallet.SetSalary(ind, sal);
        }
        public void DismissWorker(int ind)
        {
            staff.DismissWorker(ind);
        }
        public void BuyAllStorage(int count) 
        {
            wallet.Spend(storage.AppendAll(count));
        }
        public void PayToWorkers()
        {
            if (staff.Count == 0) throw new ArgumentException("Некому платить");

            double cost = 0;
            foreach (var i in staff.Workers)
            {
                if (i.Position == "кассир")
                    cost += wallet.GetSalary(0);
                else if(i.Position == "повар")
                    cost += wallet.GetSalary(1);
                else if (i.Position == "курьер")
                    cost += wallet.GetSalary(2);
            }
            wallet.Spend(cost);
        }
        public void BuyRequestedOnStorage(int count)
        {
            wallet.Spend(storage.AppendAllQeue(count));
        }
        public void BuyRequestedOnStorage()
        {
            wallet.Spend(storage.AppendAllQeue());
        }
        public void BuyProductOnStorage(int cnt)
        {
            wallet.Spend(storage.AppendAllContent(cnt));
        }
        public void BuyProductOnStorage(Product p, int cnt)
        {
            wallet.Spend(storage.AppendPosition(p, cnt));
        }
        public void AddWorker()
        {
            staff.Add(new Worker());
        }
        public void AddWorker(Worker w)
        {
            staff.Add(w);
        }
        public void AcceptOrder(Order ord)
        {
            orderList.Add(ord);
            wallet.Income(ord.Cost);
        }
    }
}
