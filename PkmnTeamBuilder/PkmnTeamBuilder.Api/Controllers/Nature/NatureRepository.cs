using AutoMapper;
using PkmnTeamBuilder.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PkmnTeamBuilder.Api.Controllers.Nature
{
    public interface INatureRepository
    {
        IEnumerable<NatureModel> GetNatures();
    }

    public class NatureRepository : INatureRepository
    {
        TeamBuilderContext _context;
        IMapper _mapper;

        public NatureRepository(TeamBuilderContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<NatureModel> GetNatures()
        {
            return Map(_context.PokemonNature);
        }

        IEnumerable<NatureModel> Map(IEnumerable<Entities.PokemonNature> natures)
        {
            return natures.Select(x => _mapper.Map<NatureModel>(x));
        }
    }
}
