using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PkmnTeamBuilder.Api.Controllers.News
{
    public interface INewsService
    {
        IEnumerable<NewsItemModel> GetNews();
    }

    public class NewsService : INewsService
    {
        INewsRepository _repo;

        public NewsService(INewsRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<NewsItemModel> GetNews()
        {
            return _repo.GetNews();
        }
    }
}
