using Article_Api.Model;

namespace Article_Api.Repository
{
    public class ArticleRepository
    {
        private readonly static List<Article> _articles = Populate();
        private static List<Article> Populate()
        {
            var result = new List<Article>()
            {
                new Article
                {
                    Id = 1,
                    Title = "First Article",
                    WriterId = 1,
                    LastUpdate = DateTime.Now
                },
                new Article
                {
                    Id = 2,
                    Title = "Second title",
                    WriterId = 2,
                    LastUpdate = DateTime.Now
                },
                new Article
                {
                    Id = 3,
                    Title = "Third title",
                    WriterId = 3,
                    LastUpdate = DateTime.Now
                }
            };
            return result;
        }
        public List<Article> GetAll()
        {
            return _articles;
        }
        public Article? Get(int id)
        {
            return _articles.FirstOrDefault(x => x.Id == id);
        }
        public int Delete(int id)
        {
            var removed = _articles.SingleOrDefault(x => x.Id == id);
            if (removed != null)
                _articles.Remove(removed);
            return removed?.Id ?? 0;
        }
    }
}
