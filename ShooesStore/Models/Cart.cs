using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShooesStore.Models
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public List<CartLine> Lines { get { return lineCollection; } }

        public void AddItem(Shoes shoes, int quantity)
        {
            CartLine line = lineCollection
                .Where(sh => sh.Shoes.ShoesId == shoes.ShoesId)
                .FirstOrDefault();
            if (line == null)
            {
                lineCollection.Add(new CartLine { Shoes = shoes, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Shoes shoes)
        {
            lineCollection.RemoveAll(l => l.Shoes.ShoesId == shoes.ShoesId);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Shoes.Price * e.Quantity);
        }

        public void Clear()
        {
            lineCollection.Clear();
        }
    }


    public class CartLine
    {
        public Shoes Shoes { get; set; }

        public int Quantity { get; set; }
    }
}