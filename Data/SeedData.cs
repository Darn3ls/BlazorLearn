﻿namespace Ratatouille.Data
{
    public class SeedData
    {
        public static void Initialize(PizzaStoreContext db)
        {
            var specials = new Pizza[]
            {
                new Pizza()
                {
                    PizzaId = 0,
                    Name = "Basic Cheese Pizza",
                    Description = "It's cheesy and delicious. Why wouldn't you want one?",
                    Price = 9.99m,
                    ImageUrl = "img/pizzas/cheese.jpg",
                },
                new Pizza()
                {
                    PizzaId = 2,
                    Name = "The Baconatorizor",
                    Description = "It has EVERY kind of bacon",
                    Price = 11.99m,
                    ImageUrl = "img/pizzas/bacon.jpg",
                },
                new Pizza()
                {
                    PizzaId = 3,
                    Name = "Classic pepperoni",
                    Description = "It's the pizza you grew up with, but Blazing hot!",
                    Price = 10.50m,
                    ImageUrl = "img/pizzas/pepperoni.jpg",
                },
                new Pizza()
                {
                    PizzaId = 4,
                    Name = "Buffalo chicken",
                    Description = "Spicy chicken, hot sauce and bleu cheese, guaranteed to warm you up",
                    Price = 12.75m,
                    ImageUrl = "img/pizzas/meaty.jpg",
                },
                new Pizza()
                {
                    PizzaId = 5,
                    Name = "Mushroom Lovers",
                    Description = "It has mushrooms. Isn't that obvious?",
                    Price = 11.00m,
                    ImageUrl = "img/pizzas/mushroom.jpg",
                },
                new Pizza()
                {
                    PizzaId = 7,
                    Name = "Veggie Delight",
                    Description = "It's like salad, but on a pizza",
                    Price = 11.50m,
                    ImageUrl = "img/pizzas/salad.jpg",
                },
                new Pizza()
                {
                    PizzaId = 8,
                    Name = "Margherita",
                    Description = "Traditional Italian pizza with tomatoes and basil",
                    Price = 9.99m,
                    ImageUrl = "img/pizzas/margherita.jpg",
                },
            };

            db.Specials.AddRange(specials);
            db.SaveChanges();
        }
    }
}
