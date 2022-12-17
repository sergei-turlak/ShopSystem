using ShopSystem.Data;
using ShopSystem.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.Services
{
    internal class ShopProductsServiceAsync : IShopProductsService
    {
        public Product Read(int productId)
        {
            Product product = DBContext.ShopProducts.Find((x => x.Id == productId));
            if (product == null)
                throw new Exception("Товару з таким id не знайдено");
            return product;
        }

        public List<Product> ReadAll()
        {
            return DBContext.ShopProducts;
        }

        public void Update(int productId, Product updated)
        {
            var oldList = ReadAll();
            oldList[oldList.IndexOf(oldList.Find(x => x.Id == productId))] = updated;
            DBContext.ShopProducts = oldList;
        }

        public void Delete(int productId)
        {
            var oldList = ReadAll();
            oldList.Remove(oldList.Find(x => x.Id == productId));
            DBContext.ShopProducts = oldList;
        }

        public bool Contains(int productId)
        {
            return ReadAll().Contains(Read(productId));
        }
    }
}
