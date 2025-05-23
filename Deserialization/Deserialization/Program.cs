using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Http.Json;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapPost("/auto", (Person personForClient) =>
{
    return TypedResults.Ok(personForClient);
});

app.MapPost("json", async (HttpContext context) =>
{
    var person = context.Request.ReadFromJsonAsync<Person>();
    return TypedResults.Json(person);
});

app.MapPost("custom", async (HttpContext context) =>
{
    var options = new JsonSerializerOptions
    {
        UnmappedMemberHandling = JsonUnmappedMemberHandling.Disallow
    };
    var person = await context.Request.ReadFromJsonAsync<Person>();
    return TypedResults.Ok(person);
});

app.MapPost("xml", async (HttpContext context) =>
{
    var reader = new StreamReader(context.Request.Body);
    var body = await reader.ReadToEndAsync();

    var xmlSerializer = new XmlSerializer(typeof(Person));
    var stringReader = new StringReader(body);

    var person = xmlSerializer.Deserialize(stringReader);
    return TypedResults.Ok(person);
});
app.Run();

public class Person
{
    required public string UserName { get; set; }
    public int? UserAge { get; set; }
}