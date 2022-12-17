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
            UserId = dto.UserId;
            Products = dto.Products;
            TotalPrice = dto.Products.TotalPrice;
            Date = DateTime.Now;
        }
    }

    internal class OrderDTO
    {
        public int UserId { get; set; }
        public ProductsCart Products { get; set; }
    }
}
