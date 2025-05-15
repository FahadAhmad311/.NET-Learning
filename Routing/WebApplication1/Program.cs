var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/users/{userid}/posts/{slug}", (int userid, string slug) => {
            return $"User ID: {userid}, Post ID: {slug}";
});

//Parameters Constraint
app.MapGet("/products/{id:int:min(-7)}",(int id) => {
    return $"Product: {id}";
});

//Optional Parameters
app.MapGet("/report/{year?}", (int? year = 2025) => 
{ return $"Year is {year}";
});


//Filepath
app.MapGet("/files/{*filePath}", (string filePath) => {
     return filePath;
});

//Querying
app.MapGet("/search", (string q, int page = 1) => {
        return $"Searching for {q} on page {page}.";
});

app.Run();

