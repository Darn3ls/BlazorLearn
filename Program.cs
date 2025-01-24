using Ratatouille;
using Ratatouille.Components;
using Ratatouille.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Register the pizzas service
builder.Services.AddSingleton<PizzaService>();

// Add the AppState class
builder.Services.AddScoped<PizzaSalesState>();

//Utilizza HttpClient per ottenere il codice JSON per le pizze
builder.Services.AddHttpClient();

//Registra il nuovo oggetto PizzaStoreContext e fornisce il nome file per il database SQLite
builder.Services.AddSqlite<PizzaStoreContext>("Data Source=pizza.db");

// Aggiungi i servizi richiesti per MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();




app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Configura il middleware per il routing
app.UseRouting();

app.UseAntiforgery();

// Configura la route predefinita per i controller dell'applicazione MVC
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");




// Initialize the database
var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PizzaStoreContext>();
    if (db.Database.EnsureCreated())
    {
        SeedData.Initialize(db);
    }
}

app.Run();
