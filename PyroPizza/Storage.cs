using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PyroPizza
{
    [Serializable]
    class Storage
    {
        public List<Product> Content { get; }
        public List<Product> ProductQuery { get { return productQuery; } }
        private List<Product> productQuery;
        public Storage()
        {
            Content = new List<Product>();
            productQuery = new List<Product>();
        }
        public void Request(List<Product> list)
        {
            foreach (var i in list)
            {
                if (!ProductQuery.Contains(i))
                    productQuery.Add(i);
                else
                {
                    Product ai = productQuery.Find(p => p.Name == i.Name);
                    ai.SetCount( ai.CountOnStorage+ i.CountOnStorage);
                }
            }
        }
        public void PrepareOrd(Order o)
        {
            if (GetMissingProgucts(o).Count != 0) throw new ArgumentException("Недостаточно продуктов на складе");

            List<Product> ls = GetProducts(o);

            foreach (var i in ls)
            {
                Product tmp = Content.Find(p => p.Name == i.Name);
                tmp.Spend(1);
            }
        }
        public void Add(Product product)
        {
            Product ai = Content.Find(t => t == product);
            if (ai == null)
            {
                Content.Add(product);
            }
            else
            {
                ai.Append(product.CountOnStorage);
            }
        }
        private void AppQ(Product p, List<Product> ls)
        {
            Product tmp = ls.Find(pp => p.Name == pp.Name);
            if (tmp == null)
            {
                p.SetCount(1);
                ls.Add(p);
            }
            else tmp.Append(1);
        }

        public List<Product> GetProducts(Order ord)
        {
            List<Product> res = new List<Product>();
            foreach (var pos in ord.Content)
            {
                if (pos is Pizza)
                {
                    Pizza pp = pos as Pizza;
                    foreach (var i in pp.Ingredients)
                    {
                        AppQ((Product)i, res);
                    }
                }
                else if (pos is OtherFood)
                {
                    OtherFood po = pos as OtherFood;
                    foreach (var i in po.Ingredients)
                    {
                        AppQ((Product)i, res);
                    }
                }
                else
                {
                    Drink d = pos as Drink;
                    AppQ((Product)d.productInStorage, res);
                }
            }
            return res;
        }
        public List<Product> GetMissingProgucts(Order ord)
        {
            List<Product> res = new List<Product>();
            List<Product> tmp = GetProducts(ord);
            foreach (var i in tmp)
            {
                Product p = Content.Find(pp => pp.Name == i.Name);
                if (p == null)
                {
                    res.Add(i);
                }
                else
                {
                    if (i.CountOnStorage > p.CountOnStorage)
                    {
                        i.SetCount(i.CountOnStorage - p.CountOnStorage);
                        res.Add(i);
                    }
                }
            }
            return res;
        }
        public void Append(Product prod, int co)
        {
            Product tmp = Content.Find(p => p.Name == prod.Name);
            if (tmp == null)
            {
                int t = prod.CountOnStorage;
                prod.SetCount(co);
                Ingredient tpi = prod as Ingredient;
                if (tpi != null)
                    Content.Add((Ingredient)tpi.Clone());
                else
                    Content.Add((Product)prod.Clone());
                prod.SetCount(t - co);

            }
            else
            {
                tmp.Append(co);
                prod.SetCount(prod.CountOnStorage - co);
            }

        }

        public void SpendByOrder(Order ord)
        {
            List<Product> check = GetMissingProgucts(ord);
            if (check.Count != 0)
            {
                string str = "";
                foreach (var i in check)
                    str += i.Name + ", ";
                throw new ArgumentException("Недостаточно следующих продуктов на складе: " + str);
            }

            List<Product> allProds = GetProducts(ord);
            List<Product> allProdsT = GetStorageTickets(allProds);
            for (int i = 0; i < allProdsT.Count; i++ )
            {
                allProdsT[i].Spend(allProds[i].CountOnStorage);
            }
        }

        private List<Product> GetStorageTickets(List<Product> ls)
        {
            List<Product> res = new List<Product>();
            foreach (var i in ls)
            {
                Product ai = Content.Find(p => p.Name == i.Name);
                if (ai == null) { throw new ArgumentException("Не хватает товара на складе "+i.Name); }
                res.Add(ai);
            }
            return res;
        }
        public double AppendAllQeue(int count)
        {
            double cost = 0;
            foreach (var i in ProductQuery)
            {
                    cost += i.Cost * count;
                    Append(i, count);
            }
            ClearQueue();
            return cost;
        }
        public double AppendAllQeue()
        {
            double cost = 0;
            foreach (var i in ProductQuery)
            {
                cost += i.Cost * i.CountOnStorage;
                Append(i, i.CountOnStorage);
            }
            ClearQueue();
            return cost;
        }
        private void ClearQueue()
        {
            List<Product> res = new List<Product>();
            foreach (var i in ProductQuery)
            {
                if (i.CountOnStorage > 0)
                    res.Add(i);
            }
            productQuery = res;
        }
    }
}
