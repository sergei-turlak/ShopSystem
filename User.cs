using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem
{
    internal class User
    {
        public int Id { get; }
        public string Name { get; }
        public int Balance { get; private set; }

        private ProductsCart ProductCart;

        public User(UserDTO dto)
        {
            Id = new Random(Guid.NewGuid().GetHashCode()).Next(0, 1_000_000);
            Name = dto.Name;
            Balance = dto.Balance;
            ProductCart = new ProductsCart();
        }

        public void ReplenishBalance(int value)
        {
            Balance += value;
        }

        public void AddProductToCart(int productId, int copiesNumber)
        {
            if (!Contain(productId)) throw new Exception("Товару з таким індексом немає");
            ProductCart.Add((productId, copiesNumber));
        }

        public void BuyProductsInCart()
        {
            if (ProductCart.Count == 0) throw new Exception("Кошик товарів порожній!");
            if (ProductCart.TotalPrice > Balance) throw new Exception("На рахунку бракує балансу здійснити купівлю товарів з кошику!");

            foreach(var element in ProductCart)
            {
                Product product = GetProduct(element.productId);
                if (element.copies > product.Copies) throw new Exception("У нас немає такої кількості копій цього товару!");
                product.Copies -= element.copies;
                Balance -= product.Price * element.copies;
                Update(product);
            }

            History.AddOrder(this, ProductCart);
            ProductCart.Clear();
        }
    }

    internal class UserDTO
    {
        public string Name { get; set; }
        public int Balance { get; set; }
    }
}
