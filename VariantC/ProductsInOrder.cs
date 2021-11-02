using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariantC
{
    class ProductsInOrder
    {
        public Product Item { get; init; }
        public int Amount { get; init; }
        public ProductsInOrder(Product item, int amount)
        {
            Item = item;
            Amount = amount;
        }
        public override string ToString() => $"{Item}, количество: {Amount} шт.";
    }
}
