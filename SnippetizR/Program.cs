using Markdig;
using Markdig.Extensions.Yaml;
using Markdig.Parsers;
using Markdig.Renderers;
using Markdig.SyntaxHighlighting;
using YamlDotNet.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSingleton<MarkdownPipeline>((_)
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

app.MapGet("/articles/{article}", async (string article,
    MarkdownPipeline pipeline,
    IWebHostEnvironment webHostEnvironment) =>
{
    using (var stream = webHostEnvironment.WebRootFileProvider.GetFileInfo($"markdown/{article}.md").CreateReadStream())
    using (var reader = new StreamReader(stream))
    {
        var writer = new StringWriter();
        var renderer = new HtmlRenderer(writer);
        pipeline.Setup(renderer);

        var document = MarkdownParser.Parse(reader.ReadToEnd(), pipeline);
        renderer.Render(document);
        writer.Flush();

        var yamlFrontMatter = document.FirstOrDefault(x => x.Parser.GetType().Equals(typeof(YamlFrontMatterParser)));
        if (yamlFrontMatter != null)
        {
            var yaml = (yamlFrontMatter as YamlFrontMatterBlock)?.Lines.ToString();
            var deserializer = new Deserializer();
            var result = deserializer.Deserialize<Article>(new StringReader(yaml));
        }

        return Results.Content(writer.ToString(), "text/html");
    }
});

app.Run();

public class Article
{
    [YamlMember(Alias = "title")]
    public string Title { get; set; }
    
    [YamlMember(Alias = "category")]
    public string Category { get; set; }
}