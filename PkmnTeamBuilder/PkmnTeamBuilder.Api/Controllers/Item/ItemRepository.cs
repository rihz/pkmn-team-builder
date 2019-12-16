using AutoMapper;
using PkmnTeamBuilder.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PkmnTeamBuilder.Api.Controllers.Item
{
    public interface IItemRepository
    {
        IEnumerable<ItemModel> GetItems();
    }

    public class ItemRepository : IItemRepository
    {
        TeamBuilderContext _context;
        IMapper _mapper;

        public ItemRepository(TeamBuilderContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<ItemModel> GetItems()
        {
            return Map(_context.PokemonItem);
        }

        IEnumerable<ItemModel> Map(IEnumerable<Entities.PokemonItem> items)
        {
            return items.Select(x => _mapper.Map<ItemModel>(x));
        }
    }
}
