var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpLogging((o) => {});
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.Use(async (context, next) =>
{
    Console.WriteLine("Logic before 1");
    await next.Invoke();
    Console.WriteLine("Logic after 1");
});
app.Use(async (context, next) =>
{
    Console.WriteLine("Logic before 2");
    await next.Invoke();
    Console.WriteLine("Logic after 2");
});
app.Use(async (context, next) =>
{
    Console.WriteLine("Logic before 3");
    await next.Invoke();
    Console.WriteLine("Logic after 3");
});
app.UseHttpLogging();

app.MapGet("/about", () => "Myself Fahad,Undergraduate final year software engineering student.");

app.Run();
