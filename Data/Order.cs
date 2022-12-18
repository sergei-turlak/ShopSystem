using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.Data
{
    internal class Order
    {
        public int Id { get; }
        public int UserId { get; }
        public ProductsCart Products { get; }
        public int TotalPrice { get; }
        public DateTime Date { get; }

        public Order(OrderDTO dto)
        {
            Id = new Random(Guid.NewGuid().GetHashCode()).Next(0, 1_000_000);
            TotalPrice = dto.Products.TotalPrice;
            Date = DateTime.Now;
            UserId = dto.UserId;

            Products = new ProductsCart();
            foreach(var item in dto.Products)
                Products.Add(item);
        }
    }

    internal class OrderDTO
    {
        public int UserId { get; set; }
        public ProductsCart Products { get; set; }
    }
}
