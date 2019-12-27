using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PkmnTeamBuilder.Api.Controllers.Team
{
    public interface ITeamService
    {
        TeamModel AddTeam(TeamModel model);
        IEnumerable<TeamModel> GetTeams(string userId);
    }

    public class TeamService : ITeamService
    {
        ITeamRepository _repo;

        public TeamService(ITeamRepository repo)
        {
            _repo = repo;
        }

        public TeamModel AddTeam(TeamModel model)
        {
            return _repo.AddTeam(model);
        }

        public IEnumerable<TeamModel> GetTeams(string userId)
        {
            return _repo.GetTeams(userId);
        }
    }
}
