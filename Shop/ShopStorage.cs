﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class ShopStorage:ItemStorage<Item>
    {
        public ShopStorage()
        {
            //Default Items in Shop
            //Potion - Category
            Add(new Item
            {
                ProductNumber = "#100-000-001",
                Name = "Health Potion IV",
                Category = Category.Potion,
                Price = 1999.99
            });
            Add(new Item
                {
                    ProductNumber = "#100-000-002",
                    Name = "God Potion I",
                    Category = Category.Potion,
                    Price = 3784.84
                });
            Add(new Item
            {
                ProductNumber = "#100-000-003",
                Name = "Ultimate Badass Potion XVII",
                Category = Category.Potion,
                Price = 9999.99
            });
            //Scrolls
            Add(new Item
            {
                ProductNumber = "#100-000-004",
                Name = "Healing Scroll VI",
                Category = Category.Scroll,
                Price = 2348.49
            });
            Add(new Item
            {
                ProductNumber = "#100-000-005",
                Name = "Teleportation Scroll",
                Category = Category.Scroll,
                Price = 1490
            });
            //Spells
            Add(new Item
            {
                ProductNumber = "#100-000-006",
                Name = "Complete Schoolwork Spell",
                Category = Category.Spell,
                Price = 859.39
            });
            Add(new Item
            {
                ProductNumber = "#100-000-007",
                Name = "Cleaning Spell",
                Category = Category.Spell,
                Price = 149
            });
            Add(new Item
                {
                    ProductNumber="#100-000-008",
                    Name="Holiday Spell III",
                    Category=Category.Spell,
                    Price=39
                });
        }

        public List<Item>GetItems()
        {
            return GetAllItems().ToList();
        }
    }
}
