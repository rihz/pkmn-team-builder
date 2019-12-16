using AutoMapper;
using PkmnTeamBuilder.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PkmnTeamBuilder.Api.Controllers.Item
{
    public interface IItemService
    {
        IEnumerable<ItemModel> GetItems();
    }

    public class ItemService : IItemService
    {
        IItemRepository _repo;

        public ItemService(IItemRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<ItemModel> GetItems()
        {
            return _repo.GetItems();
        }
    }
}
