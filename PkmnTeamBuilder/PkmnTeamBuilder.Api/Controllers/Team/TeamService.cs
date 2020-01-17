﻿using System;
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
        IEnumerable<TeamModel> GetTeams(string userId);
        void DeleteTeam(int id);
        void LinkTeam(string code, string userId);
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

        public IEnumerable<TeamModel> GetTeams(string userId)
        {
            return _repo.GetTeams(userId);
        }

        public void DeleteTeam(int id)
        {
            _repo.DeleteTeam(id);
        }

        public void LinkTeam(string code, string userId)
        {
            _repo.LinkTeam(code, userId);
        }
    }
}
