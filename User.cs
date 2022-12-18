using ShopSystem.Data;
using ShopSystem.Services;
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
        public ProductsCart ProductsCart { get; private set; }

        public User(UserDTO dto)
        {
            Id = new Random(Guid.NewGuid().GetHashCode()).Next(0, 1_000_000);
            Name = dto.Name;
            Balance = dto.Balance;
            ProductsCart = new ProductsCart();
        }

        public void ReplenishBalance(int value)
        {
            if (value <= 0) throw new Exception("Не можливо поповнити рахунок на таку суму");
            Balance += value;
        }

        public void AddProductToCart(int productId, int copiesNumber)
        {
            ShopProductsService service = new ShopProductsService();
            if (copiesNumber <= 0 || copiesNumber > service.Read(productId).Copies) throw new Exception("Немає такої кількості товару");
            if (!service.Contains(productId)) throw new Exception("Товару з таким індексом немає");

            foreach (var element in ProductsCart)
                if (element.productId == productId)
                {
                    ProductsCart[ProductsCart.IndexOf(element)] = (productId, element.copies + copiesNumber);
                    return;
                }

            ProductsCart.Add((productId, copiesNumber));
        }

        public void BuyProductsInCart()
        {
            if (ProductsCart.Count == 0) throw new Exception("Кошик товарів порожній!");
            if (ProductsCart.TotalPrice > Balance) throw new Exception("На рахунку бракує балансу здійснити купівлю товарів з кошику!");

            ShopProductsService service = new ShopProductsService();
            foreach (var element in ProductsCart)
            {
                Product product = service.Read(element.productId);
                if (element.copies > product.Copies)
                {
                    ProductsCart.Remove(element);
                    throw new Exception("У нас немає такої кількості копій цього товару!");
                }
            }

            foreach(var element in ProductsCart)
            {
                Product product = service.Read(element.productId);
                product.Copies -= element.copies;
                Balance -= product.Price * element.copies;
                service.Update(element.productId, product);
            }

            Order newOrder = new Order(new OrderDTO { UserId = Id, Products = ProductsCart });
            OrdersHistoryService service2 = new OrdersHistoryService();
            service2.Create(newOrder);

            ProductsCart.Clear();
        }
    }

    internal class UserDTO
    {
        public string Name { get; set; }
        public int Balance { get; set; }
    }
}
