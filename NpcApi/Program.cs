using NpcApi.repository;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "We have [g]oblins and [o]rks. You can try to kill goblins /kill/g");

app.MapGet("/g", () => $"{NpcRepository.GoblinsCount} goblins steal alive");

app.MapGet("/kill/g", () => $"You kill one goblin. {NpcRepository.GoblinsCount--} goblins steal alive");

app.Run();
