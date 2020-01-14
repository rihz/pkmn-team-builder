using AutoMapper;
using PkmnTeamBuilder.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PkmnTeamBuilder.Api.Controllers.News
{
    public interface INewsRepository
    {
        IEnumerable<NewsItemModel> GetNews();
    }

    public class NewsRepository : INewsRepository
    {
        TeamBuilderContext _context;
        IMapper _mapper;

        public NewsRepository(TeamBuilderContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<NewsItemModel> GetNews()
        {
            return _context.News.Select(x => _mapper.Map<NewsItemModel>(x));
        }
    }
}
