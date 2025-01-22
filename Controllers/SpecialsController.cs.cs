using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ratatouille.Data;

namespace Ratatouille.Controllers
{
    // Specifica il percorso del controller e abilita il comportamento API
    // - [Route("specials")]: Imposta l'endpoint come "/specials"
    // - [ApiController]: Fornisce funzionalità aggiuntive per un controller API (es. validazione automatica)
    [Route("specials")]
    [ApiController]
    public class SpecialsController : Controller
    {
        // Campo privato per accedere al contesto del database
        private readonly PizzaStoreContext _db;

        // Costruttore del controller
        // Il contesto viene iniettato tramite Dependency Injection (DI)
        public SpecialsController(PizzaStoreContext db)
        {
            _db = db;
        }

        // Metodo HTTP GET per recuperare le pizze speciali
        // - [HttpGet]: Indica che questo metodo risponde alle richieste GET
        // - Ritorna una lista di pizze ordinate per prezzo decrescente
        [HttpGet]
        public async Task<ActionResult<List<Pizza>>> GetSpecials()
        {
            // Ottiene tutte le pizze speciali dal database
            // - ToListAsync(): Esegue la query in modo asincrono e restituisce la lista
            // - OrderByDescending(s => s.Price): Ordina le pizze per prezzo in ordine decrescente
            return (await _db.Specials.ToListAsync()).OrderByDescending(s => s.Price).ToList();
        }
    }
}