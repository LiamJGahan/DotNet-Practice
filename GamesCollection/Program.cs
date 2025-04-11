using Collection.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// A list containing some games for testing in Swagger, using my Game model
var myGames = new List<Game>
{
    new Game { GameId = 1, Title = "Horizon Zero Dawn", Tags = ["Open world", "Action role-playing game", "Shooter"], Platform = "PS4"},
    new Game { GameId = 2, Title = "Mario Kart 8", Tags = ["Racing", "Arcade"], Platform = "Switch"},
    new Game { GameId = 3, Title = "Kenshi", Tags = ["RPG", "Indie"], Platform = "PC"}
};

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// A reminder to use Swagger on root URL
app.MapGet("/", () => "Use /swagger");

app.MapGet("/games", () =>
{
    return Results.Ok(myGames);
});

// I've avoided LINQ and lambdas here for clarity and personal preference — I'll refactor to use them in later projects
// I'm not using MVC controllers in this project to keep the app lightweight and minimal
app.MapPost("/games", (Game newGame) =>
{
    bool idFound = false;

    foreach (Game game in myGames)
    {
        if (game.GameId == newGame.GameId)
        {
            idFound = true;
            break;
        }
    }

    if (idFound)
    {
        return Results.Problem("ID already exists");
    }

    myGames.Add(newGame);
    return Results.Ok(myGames);
});

app.MapDelete("/games/{id}", (int id) =>
{
    foreach (Game game in myGames)
    {
        if (game.GameId == id)
        {
            myGames.Remove(game);
            return Results.Ok(myGames);
        }
    }
    
    return Results.Problem("ID not found");
});

app.Run();
