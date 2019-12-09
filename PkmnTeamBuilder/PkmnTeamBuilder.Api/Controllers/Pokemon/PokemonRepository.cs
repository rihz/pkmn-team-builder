﻿using AutoMapper;
using PkmnTeamBuilder.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PkmnTeamBuilder.Api.Controllers.Pokemon
{
    public interface IPokemonRepository
    {
        PokemonModel GetPokemon(int id);
        IEnumerable<PokemonSearchResultModel> SearchPokemon(string name);
    }

    public class PokemonRepository : IPokemonRepository
    {
        TeamBuilderContext _context;
        IMapper _mapper;

        public PokemonRepository(TeamBuilderContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public PokemonModel GetPokemon(int id)
        {
            var pkmn = _context.Pokemon.FirstOrDefault(p => p.Id == id);

            return pkmn != default(Entities.Pokemon)
                ? _mapper.Map<PokemonModel>(pkmn)
                : null;
        }

        public IEnumerable<PokemonSearchResultModel> SearchPokemon(string name)
        {
            var results = _context.Pokemon
                .Where(p => p.Name.ToLower().Contains(name.ToLower()));

            return MapSearchResults(results);
        }

        IEnumerable<PokemonModel> Map(IEnumerable<Entities.Pokemon> pkmn)
        {
            return pkmn.Select(x => _mapper.Map<PokemonModel>(x));
        }

        IEnumerable<PokemonSearchResultModel> MapSearchResults(IEnumerable<Entities.Pokemon> pkmn)
        {
            return pkmn.Select(x => new PokemonSearchResultModel
            {
                Id = x.Id,
                Name = x.Name,
                Number = x.Number,
                Icon = x.Icon
            });
        }
    }
}
