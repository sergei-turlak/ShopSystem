using ShopSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.Data
{
    internal class Product
    {
        public int Id { get; }
        public string Name { get; }
        public int Price { get; }
        public string Description { get; }
        public int Copies { get; set; }
        public Product(ProductDTO dto)
        {
            Id = new Random(Guid.NewGuid().GetHashCode()).Next(0, 1_000_000);
            Name = dto.Name;
            Price = dto.Price;
            Description = dto.Description;
            Copies = dto.Copies;
        }
    }

    internal class ProductDTO
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int Copies { get; set; }
    }
}
