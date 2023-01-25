using Markdig;
using Markdig.SyntaxHighlighting;
using SnippetizR;
using System.Text.RegularExpressions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSingleton<IArticleService, LocalFileArticleService>();
builder.Services.AddSingleton((_)
    => new MarkdownPipelineBuilder()
        .UseYamlFrontMatter()
        .UseAdvancedExtensions()
        .UseSyntaxHighlighting()
            .Build());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();

app.MapGet("/articles", async (IArticleService articleService) =>
{
    var result = await articleService.GetArticleList();
    return Results.Ok(result);
});

app.MapGet("/articles/{article}", async (string article, 
    IArticleService articleService) =>
{
    var result = await articleService.GetArticle(article);
    return Results.Content(result.Html, "text/html");
});

app.MapGet("/articles/{article}/copy", async (string article,
    IArticleService articleService) =>
{
    var result = await articleService.GetArticle(article);
    var code = Regex.Replace(result.Html, "<[^>]*>", "");
    code = Regex.Replace(code, "&quot;", "\"");
    code = Regex.Replace(code, "&gt;", ">");
    code = Regex.Replace(code, "&lt;", "<");
    return Results.Content(code, "text/plain");
});

app.Run();
