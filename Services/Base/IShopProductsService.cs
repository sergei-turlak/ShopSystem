using ShopSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.Services.Base
{
    internal interface IShopProductsService
    {
        Product Read(int id);
        List<Product> ReadAll();
        void Update(int productId, Product updated);
        void Delete(int productId);
        bool Contains(int productId);
    }
}
