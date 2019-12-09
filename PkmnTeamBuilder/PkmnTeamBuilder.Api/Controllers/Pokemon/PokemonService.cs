using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PkmnTeamBuilder.Api.Controllers.Pokemon
{
    public interface IPokemonService
    {
        PokemonModel GetPokemon(int id);
        IEnumerable<PokemonSearchResultModel> SearchPokemon(string name);
    }

    public class PokemonService : IPokemonService
    {
        IPokemonRepository _repo;

        public PokemonService(IPokemonRepository repo)
        {
            _repo = repo;
        }

        public PokemonModel GetPokemon(int id)
        {
            return _repo.GetPokemon(id);
        }

        public IEnumerable<PokemonSearchResultModel> SearchPokemon(string name)
        {
            return _repo.SearchPokemon(name);
        }
    }
}
