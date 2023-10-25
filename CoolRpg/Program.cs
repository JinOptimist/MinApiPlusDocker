using System.Net.Mime;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Hello adventure. Please visit a /tavern  ");

app.MapGet("/help", async (HttpResponse response) =>
{
    response.ContentType = MediaTypeNames.Text.Html;
    await response.WriteAsync("The <a href='/swagger/index.html'>page</a> help you.");
});

app.MapGet("/tavern", async() =>
{
    //response.WriteAsync("No one help you!")
    var client = new HttpClient();
    var response = await client.GetAsync("http://npc/g");
    var responseContent = await response.Content.ReadAsStringAsync();
    return $"No one help you! {responseContent}";
});

app.Run();
