﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.Data
{
    internal static class DBContext
    {
        public static List<Product> ShopProducts { get; set; }
        public static List<Order> OrdersHistory { get; set; }
        public static User User { get; set; }

        static DBContext()
        {
            ShopProducts = new List<Product>();
            ShopProducts.AddRange(new Product[]
            {
                new Product(new ProductDTO { Name = "<3 Bayraktar TB2", Price = 17, Description = "турецький ударний оперативно-тактичний середньовисотний безпілотний літальний апарат (БПЛА)", Copies = 5}),
                new Product(new ProductDTO { Name = "<3 CAESAR", Price = 9, Description = "французька 155-мм самохідна артилерійська установка, призначена для знищення живої сили, артилерійських батарей, дзотів", Copies = 8}),
                new Product(new ProductDTO { Name = "<3 NASAMS", Price = 8, Description = "норвезький зенітний ракетний комплекс середньої дальності", Copies = 4}),
                new Product(new ProductDTO { Name = "<3 M1 «Абрамс»", Price = 23, Description = "M1 «Абрамс» є добре озброєною, броньованою, мобільною бойовою машиною, розрахованою на ведення бойових дій у різних умовах сучасних війн та збройних конфліктів", Copies = 2}),
            });
            OrdersHistory = new List<Order>();
            User = null;
        }
    }
}
