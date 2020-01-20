using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PkmnTeamBuilder.Api.Controllers.Team
{
    public interface ITeamService
    {
        TeamModel GetTeam(string code);
        TeamModel AddTeam(TeamModel model);
        TeamModel UpdateTeam(TeamModel model);
        TeamSearchResultModel GetAllTeams(int skip, int take, int filterType, string search, int sort);
        TeamSearchResultModel GetMyTeams(string userId);
        void DeleteTeam(int id);
        void LinkTeam(string code, string userId);

        LikeModel UpdateLike(int teamId, string userId);
    }

    public class TeamService : ITeamService
    {
        ITeamRepository _repo;

        public TeamService(ITeamRepository repo)
        {
            _repo = repo;
        }

        public TeamModel GetTeam(string code)
        {
            return _repo.GetTeam(code);
        }

        public TeamModel AddTeam(TeamModel model)
        {
            return _repo.AddTeam(model);
        }

        public TeamModel UpdateTeam(TeamModel model)
        {
            return _repo.UpdateTeam(model);
        }

        public TeamSearchResultModel GetAllTeams(int skip, int take, int filterType, string search, int sort)
        {
            return _repo.GetAllTeams(skip, take, filterType, search, sort);
        }

        public TeamSearchResultModel GetMyTeams(string userId)
        {
            return _repo.GetMyTeams(userId);
        }

        public void DeleteTeam(int id)
        {
            _repo.DeleteTeam(id);
        }

        public void LinkTeam(string code, string userId)
        {
            _repo.LinkTeam(code, userId);
        }

        public LikeModel UpdateLike(int teamId, string userId)
        {
            return _repo.UpdateLike(teamId, userId);
        }
    }
}
