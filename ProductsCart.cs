using ShopSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem
{
    internal class ProductsCart : List<(int productId, int copies)>
    {
        public int TotalPrice
        {
            get
            {
                return this.Sum(x => new ShopProductsService().Read(x.productId).Price * x.copies);
            }
        }
    }
}
