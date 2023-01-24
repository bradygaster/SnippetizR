using Markdig;
using Markdig.SyntaxHighlighting;
using SnippetizR;

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

app.MapGet("/articles", async (MarkdownPipeline pipeline,
    IArticleService articleService) =>
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

app.Run();
