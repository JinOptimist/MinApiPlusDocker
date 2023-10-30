using CoolRpg.Services;
using System.Net.Mime;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IMessageProducer, MessageProducer>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", async (HttpResponse response) =>
{
    response.ContentType = MediaTypeNames.Text.Html;
    await response.WriteAsync("Visit <a href='/tavern'>tavern</a> or <a href='/go'>go</a> to adventure. Or visit the <a href='/swagger/index.html'>page</a> help you.");
});

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

app.MapGet("/go", (IMessageProducer producer) =>
{
    var killGoblinMessage = new
    {
        Action = "Kill",
        Npc = "g",
        Count = 2,
    };
    producer.SendingMessage(killGoblinMessage);

    return "You find and kill 2 goblins";
});

app.Run();
