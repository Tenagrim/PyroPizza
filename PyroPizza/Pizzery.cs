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

        public void BuyRequestedOnStorage(int count)
        {
            wallet.Spend(storage.AppendAllQeue(count));
        }
        public void BuyRequestedOnStorage()
        {
            wallet.Spend(storage.AppendAllQeue());
        }
        public void AcceptOrder(Order ord)
        {
            orderList.Add(ord);
            wallet.Income(ord.Cost);
        }
    }
}
