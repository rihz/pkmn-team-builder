using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PkmnTeamBuilder.Api.Controllers.Nature
{
    public interface INatureService
    {
        IEnumerable<NatureModel> GetNatures();
    }

    public class NatureService : INatureService
    {
        INatureRepository _repo;

        public NatureService(INatureRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<NatureModel> GetNatures()
        {
            return _repo.GetNatures();
        }
    }
}
