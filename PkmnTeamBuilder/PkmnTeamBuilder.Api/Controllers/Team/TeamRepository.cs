using AutoMapper;
using PkmnTeamBuilder.Data.Context;
using PkmnTeamBuilder.Entities;
using PkmnTeamBuilder.Entities.Team;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PkmnTeamBuilder.Api.Controllers.Team
{
    public interface ITeamRepository
    {
        TeamModel GetTeam(string code);
        IEnumerable<TeamModel> GetTeams(int userId);
        TeamModel AddTeam(TeamModel model);
        IEnumerable<TeamMember> AddTeamMembers(IEnumerable<TeamMemberModel> members);
    }

    public class TeamRepository : ITeamRepository
    {
        TeamBuilderContext _context;
        IMapper _mapper;

        public TeamRepository(TeamBuilderContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public TeamModel AddTeam(TeamModel model)
        {
            var team = _mapper.Map<Entities.Team.Team>(model);

            var members = AddTeamMembers(model.Members);

            _context.Add(team);

            _context.SaveChanges();

            foreach(var member in members)
            {
                _context.TeamMembers.Add(new TeamMembers
                {
                    TeamId = team.Id,
                    TeamMemberId = member.Id
                });
            }

            _context.SaveChanges();

            return _mapper.Map<TeamModel>(team);
        }

        public IEnumerable<TeamMember> AddTeamMembers(IEnumerable<TeamMemberModel> members)
        {
            var added = new List<TeamMember>();
            var mapped = members.Select(y => _mapper.Map<TeamMember>(y));

            foreach(var map in mapped)
            {
                _context.TeamMember.Add(map);

                added.Add(map);
            }

            _context.SaveChanges();

            return added;
        }

        public TeamModel GetTeam(string code)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TeamModel> GetTeams(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
