var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var blogs = new List<Blog>
{
    new Blog {Title = "My first blog", Body = "This is my first post."},
    new Blog {Title = "My second blog", Body = "This is my second post."}
};

app.MapGet("/", () => "This is root");
app.MapGet("/blogs", () =>
{
    return blogs;
});

//for getting single post
app.MapGet("/blogs/{id}", (int id) =>
{
    if (id < 0 || id >= 2)
    {
        return Results.NotFound();

    }
    else
    {
        return Results.Ok(blogs[id]);
    }
});

//for creating new blog
app.MapPost("/blogs", (Blog blog) =>
{
    blogs.Add(blog);
    return Results.Created($"/blogs/{blogs.Count - 1}", blog);
});

//for Deleting blog
app.MapDelete("/blogs/{id}", (int id) =>
{
    if (id < 0 || id >= 2)
    {
        return Results.NotFound();

    }
    else
    {
        blogs.RemoveAt(id);
        return Results.NoContent();
    }
});

// for updating blog
app.MapPut("/blogs/{id}", (int id, Blog blog) =>
{
    if (id < 0 || id >= 2)
    {
        return Results.NotFound();

    }
    else
    {
        blogs[id] = blog;
        return Results.Ok(blog);
    }
});


app.Run();

public class Blog {
    public required string Title { get; set; }
    public required string Body { get; set; }
}