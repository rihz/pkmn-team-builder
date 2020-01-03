using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PkmnTeamBuilder.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace PkmnTeamBuilder.Api.Controllers.Members
{
    public interface ITeamMemberRepository
    {
        IEnumerable<TeamMemberModel> GetForUser(string userId);
        TeamMemberModel GetMember(int id);
    }

    public class TeamMemberRepository : ITeamMemberRepository
    {
        TeamBuilderContext _context;
        IMapper _mapper;

        public TeamMemberRepository(TeamBuilderContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<TeamMemberModel> GetForUser(string userId)
        {
            return _context.TeamMember
                .Where(x => x.UserId == userId)
                .Include(x => x.Pokemon)
                    .ThenInclude(y => y.Type1)
                .Include(x => x.Pokemon)
                    .ThenInclude(y => y.Type2)
                .Include(x => x.Ability)
                .Include(x => x.Nature)
                .Include(x => x.Item)
                .Include(x => x.Move1)
                    .ThenInclude(y => y.Category)
                .Include(x => x.Move2)
                    .ThenInclude(y => y.Category)
                .Include(x => x.Move3)
                    .ThenInclude(y => y.Category)
                .Include(x => x.Move4)
                    .ThenInclude(y => y.Category)
                .Include(x => x.Move1)
                    .ThenInclude(y => y.Type)
                .Include(x => x.Move2)
                    .ThenInclude(y => y.Type)
                .Include(x => x.Move3)
                    .ThenInclude(y => y.Type)
                .Include(x => x.Move4)
                    .ThenInclude(y => y.Type)
                .Select(x => _mapper.Map<TeamMemberModel>(x));
        }

        public TeamMemberModel GetMember(int id)
        {
            return _mapper.Map<TeamMemberModel>(
                _context.TeamMember
                    .Where(x => x.Id == id)
                    .Include(x => x.Pokemon)
                    .Include(x => x.Ability)
                    .Include(x => x.Nature)
                    .Include(x => x.Item)
                    .Include(x => x.Move1)
                        .ThenInclude(y => y.Category)
                    .Include(x => x.Move2)
                        .ThenInclude(y => y.Category)
                    .Include(x => x.Move3)
                        .ThenInclude(y => y.Category)
                    .Include(x => x.Move4)
                        .ThenInclude(y => y.Category)
                    .Include(x => x.Move1)
                        .ThenInclude(y => y.Type)
                    .Include(x => x.Move2)
                        .ThenInclude(y => y.Type)
                    .Include(x => x.Move3)
                        .ThenInclude(y => y.Type)
                    .Include(x => x.Move4)
                        .ThenInclude(y => y.Type)
                    .First()
               );
        }
    }
}
