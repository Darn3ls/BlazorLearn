using Microsoft.EntityFrameworkCore;

namespace Ratatouille.Data
{

    // Questa classe rappresenta il contesto del database per l'applicazione
    // "PizzaStoreContext" eredita da DbContext, che è la base per l'interazione con il database
    public class PizzaStoreContext : DbContext
    {

        // Costruttore della classe
        // Riceve un oggetto DbContextOptions che contiene la configurazione per il database
        // Ad esempio: quale database usare, stringa di connessione, ecc.
        public PizzaStoreContext(DbContextOptions options) : base(options)
        {

        }

        // Questa proprietà rappresenta una tabella nel database
        // DbSet<Pizza> indica che ogni elemento del set è un oggetto Pizza
        // Specials sarà usato per accedere ai dati relativi alle "pizze"
        public DbSet<Pizza> Specials { get; set; }
    }
}
