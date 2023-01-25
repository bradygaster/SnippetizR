using Markdig.Extensions.Yaml;
using Markdig.Parsers;
using Markdig.Renderers;
using Markdig;
using YamlDotNet.Serialization;

namespace SnippetizR
{
    public class LocalFileArticleService : IArticleService
    {
        private IWebHostEnvironment _webHostEnvironment;
        private MarkdownPipeline _pipeline;

        public LocalFileArticleService(IWebHostEnvironment webHostEnvironment, MarkdownPipeline pipeline)
        {
            _webHostEnvironment = webHostEnvironment;
            _pipeline = pipeline;
        }

        public async Task<List<Article>> GetArticleList()
        {
            var directoryContents = _webHostEnvironment.WebRootFileProvider.GetDirectoryContents("markdown");
            var result = new List<Article>();
            foreach (var file in directoryContents)
            {
                result.Add(await GetArticle(file.Name.Replace(".md", ""), true));
            }
            return result;
        }

        public Task<Article>? GetArticle(string slug, bool includeHtml = true)
        {
            using (var stream = _webHostEnvironment.WebRootFileProvider.GetFileInfo($"markdown/{slug}.md").CreateReadStream())
            using (var reader = new StreamReader(stream))
            {
                var writer = new StringWriter();
                var renderer = new HtmlRenderer(writer);
                _pipeline.Setup(renderer);

                var document = MarkdownParser.Parse(reader.ReadToEnd(), _pipeline);
                renderer.Render(document);
                writer.Flush();

                var yamlFrontMatter = document.FirstOrDefault(x => x.Parser.GetType().Equals(typeof(YamlFrontMatterParser)));
                if (yamlFrontMatter != null)
                {
                    var yaml = (yamlFrontMatter as YamlFrontMatterBlock)?.Lines.ToString();
                    var deserializer = new Deserializer();
                    var result = deserializer.Deserialize<Article>(new StringReader(yaml));
                    result.Slug = slug;

                    if (includeHtml)
                        result.Html = writer.ToString();
                    return Task.FromResult(result);
                }
            }

            return null;
        }
    }
}
