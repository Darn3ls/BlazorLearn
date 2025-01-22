using Ratatouille.Components.Pages;

namespace Ratatouille.Data
{
    public class PizzaService
    {

        private readonly HashSet<int> existingIds = new HashSet<int>();
        private List<Pizza> pizzas = new();

        public Task<Pizza[]> GetPizzasAsync()
        {
            // Nuove pizze da aggiungere
            var nuovePizze = new List<Pizza>
            {
                new Pizza {PizzaId = 0, Name = "Margherita", Description = "Pomodoro e mozzarella", Vegetarian = true, Vegan = false, Price = 8.0M},
                new Pizza {PizzaId = 1, Name = "Diavola", Description = "Pomodoro, mozzarella e salame piccante", Vegetarian = false, Vegan = false, Price = 9.5M},
                new Pizza {PizzaId = 2, Name = "Quattro Formaggi", Description = "Mozzarella, gorgonzola, fontina e parmigiano", Vegetarian = true, Vegan = false, Price = 10.0M},
                new Pizza {PizzaId = 3, Name = "Vegetariana", Description = "Pomodoro, mozzarella e verdure grigliate", Vegetarian = true, Vegan = false, Price = 8.5M},
                new Pizza {PizzaId = 4, Name = "Marinara", Description = "Pomodoro, aglio, origano e olio d'oliva", Vegetarian = true, Vegan = true, Price = 7.5M},
                new Pizza {PizzaId = 5, Name = "Capricciosa", Description = "Pomodoro, mozzarella, prosciutto cotto, funghi, olive e carciofi", Vegetarian = false, Vegan = false, Price = 10.0M},
                new Pizza {PizzaId = 6, Name = "Tonno e Cipolla", Description = "Pomodoro, mozzarella, tonno e cipolla rossa", Vegetarian = false, Vegan = false, Price = 9.0M},
                new Pizza {PizzaId = 7, Name = "Funghi", Description = "Pomodoro, mozzarella e funghi freschi", Vegetarian = true, Vegan = false, Price = 8.0M}
            };

            // Filtra le pizze da aggiungere e aggiungile
            foreach (var pizza in nuovePizze)
            {
                if (existingIds.Add(pizza.PizzaId)) // Aggiunge solo se l'ID non esiste
                {
                    pizzas.Add(pizza);
                }
            }

            return Task.FromResult(pizzas.ToArray());
        }
    }
}
