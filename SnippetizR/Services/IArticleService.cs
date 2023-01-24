using YamlDotNet.Serialization;

namespace SnippetizR
{
    public interface IArticleService
    {
        Task<List<Article>> GetArticleList();
        Task<Article>? GetArticle(string slug, bool includeHtml = true);
    }
    public class Article
    {
        [YamlMember(Alias = "title")]
        public string Title { get; set; }
        [YamlMember(Alias = "category")]
        public string Category { get; set; }
        public string Slug { get; set; }
        public string Html { get; set; }
    }
}
