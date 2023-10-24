var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "We have [g]oblins and [o]rks");

app.MapGet("/g", () => "10 goblins steal alive");

app.Run();
