using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PkmnTeamBuilder.Api.Controllers.Members
{
    public interface ITeamMemberService
    {
        IEnumerable<TeamMemberModel> GetForUser(string userId);
    }

    public class TeamMemberService : ITeamMemberService
    {
        ITeamMemberRepository _repo;

        public TeamMemberService(ITeamMemberRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<TeamMemberModel> GetForUser(string userId)
        {
            return _repo.GetForUser(userId);
        }
    }
}
