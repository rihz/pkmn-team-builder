using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PkmnTeamBuilder.Data.Context;
using PkmnTeamBuilder.Entities;
using PkmnTeamBuilder.Entities.Team;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PkmnTeamBuilder.Api.Controllers.Team
{
    public interface ITeamRepository
    {
        TeamModel GetTeam(string code);
        TeamSearchResultModel GetAllTeams(int skip, int take, int filterType, string search, int sort);
        TeamSearchResultModel GetMyTeams(string userId);
        TeamModel AddTeam(TeamModel model);
        TeamModel UpdateTeam(TeamModel model);
        IEnumerable<TeamMember> AddTeamMembers(IEnumerable<TeamMemberModel> members);
        //void UpdateTeamMembers(IEnumerable<TeamMemberModel> members);
        void DeleteTeam(int id);

        void LinkTeam(string code, string userId);

        LikeModel UpdateLike(int teamId, string userId);
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

            string code = "";

            do
            {
                code = GenerateCode(6);
            }
            while (_context.Team.FirstOrDefault(x => x.Code == code) != default(Entities.Team.Team));

            team.Code = code;

            _context.Add(team);

            _context.SaveChanges();

            foreach (var member in members)
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

        public TeamModel UpdateTeam(TeamModel model)
        {
            var team = _mapper.Map<Entities.Team.Team>(model);

            DeleteTeamMembers(model.Id);

            var members = AddTeamMembers(model.Members);

            _context.Update(team);

            _context.SaveChanges();

            foreach (var member in members)
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

            foreach (var map in mapped)
            {
                if (map.Id <= 0)
                {
                    _context.TeamMember.Add(map);
                }

                added.Add(map);
            }

            _context.SaveChanges();

            return added;
        }

        public TeamModel GetTeam(string code)
        {
            var team = _context.Team
                            .Include(x => x.Likes)
                            .FirstOrDefault(x => x.Code == code);

            var mappedTeam = _mapper.Map<TeamModel>(team);

            var members = _context.TeamMembers.Where(x => x.TeamId == mappedTeam.Id);
            var list = new List<TeamMemberModel>();

            foreach (var member in members)
            {
                list.Add(
                    _mapper.Map<TeamMemberModel>(
                        _context.TeamMember
                             .Include(x => x.Pokemon)
                                 .ThenInclude(y => y.Abilities)
                                    .ThenInclude(z => z.Ability)
                             .Include(x => x.Pokemon)
                                 .ThenInclude(y => y.Moveset)
                                    .ThenInclude(z => z.Move)
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
                            .First(z => z.Id == member.TeamMemberId)
                    )
                );
            }

            mappedTeam.Members = list;

            return mappedTeam;
        }

        public TeamSearchResultModel GetAllTeams(int skip, int take, int filterType, string search, int sort)
        {
            var result = FilterTeams(skip, take, filterType, search, sort);

            foreach (var team in result.Teams)
            {
                var members = _context.TeamMembers.Where(y => y.TeamId == team.Id);

                team.Members = GetTeamMembers(members);
            }

            return result;
        }

        public TeamSearchResultModel GetMyTeams(string userId)
        {
            var teams = _context.Team
                            .Include(x => x.Likes)
                            .Where(x => x.UserId == userId);

            var mappedTeams = teams.Select(x => _mapper.Map<TeamModel>(x)).ToList();

            foreach (var team in mappedTeams)
            {
                var members = _context.TeamMembers.Where(y => y.TeamId == team.Id);

                team.Members = GetTeamMembers(members);
            }

            return new TeamSearchResultModel
            {
                Teams = mappedTeams,
                Total = teams.Count()
            };
        }

        public void DeleteTeam(int id)
        {
            _context.TeamMembers.RemoveRange(
                _context.TeamMembers.Where(x => x.TeamId == id)
            );

            _context.Team.Remove(
                _context.Team.First(x => x.Id == id)
            );

            _context.SaveChanges();
        }

        public void LinkTeam(string code, string userId)
        {
            var team = _context.Team.First(x => x.Code == code);
            team.UserId = userId;

            var members = _context.TeamMembers.Where(x => x.TeamId == team.Id);

            foreach (var member in members)
            {
                var m = _context.TeamMember.First(x => x.Id == member.TeamMemberId);
                m.UserId = userId;
            }

            _context.SaveChanges();
        }
        TeamSearchResultModel FilterTeams(int skip, int take, int filterType, string search, int sort)
        {
            IQueryable<Entities.Team.Team> teams;
            var result = new TeamSearchResultModel();

            if (search != null)
            {
                switch (filterType)
                {
                    case 1:
                        teams = _context.Team
                            .Include(x => x.User)
                            .Include(x => x.Likes)
                            .Include(x => x.Members)
                                .ThenInclude(x => x.TeamMember)
                                    .ThenInclude(x => x.Ability)
                            .Where(x => x.Members.Any(y => y.TeamMember.Ability.Name.ToLower().Contains(search.ToLower())));
                        break;
                    case 2:
                        teams = _context.Team
                            .Include(x => x.User)
                            .Include(x => x.Likes)
                            .Include(x => x.Members)
                                .ThenInclude(x => x.TeamMember)
                                    .ThenInclude(x => x.Item)
                            .Where(x => x.Members.Any(y => y.TeamMember.Item.Name.ToLower().Contains(search.ToLower())));
                        break;
                    case 3:
                        teams = _context.Team
                            .Include(x => x.User)
                            .Include(x => x.Likes)
                            .Include(x => x.Members)
                                .ThenInclude(x => x.TeamMember)
                                    .ThenInclude(x => x.Move1)
                            .Include(x => x.Members)
                                .ThenInclude(x => x.TeamMember)
                                    .ThenInclude(x => x.Move2)
                            .Include(x => x.Members)
                                .ThenInclude(x => x.TeamMember)
                                    .ThenInclude(x => x.Move3)
                            .Include(x => x.Members)
                                .ThenInclude(x => x.TeamMember)
                                    .ThenInclude(x => x.Move4)
                            .Where(x =>
                                x.Members.Any(y => y.TeamMember.Move1.Name.ToLower().Contains(search.ToLower()))
                                || x.Members.Any(y => y.TeamMember.Move2.Name.ToLower().Contains(search.ToLower()))
                                || x.Members.Any(y => y.TeamMember.Move3.Name.ToLower().Contains(search.ToLower()))
                                || x.Members.Any(y => y.TeamMember.Move4.Name.ToLower().Contains(search.ToLower()))
                            );
                        break;
                    case 4:
                        teams = _context.Team
                            .Include(x => x.User)
                            .Include(x => x.Likes)
                            .Include(x => x.Members)
                                .ThenInclude(x => x.TeamMember)
                                    .ThenInclude(x => x.Nature)
                            .Where(x => x.Members.Any(y => y.TeamMember.Nature.Name.ToLower().Contains(search.ToLower())));
                        break;
                    case 5:
                        teams = _context.Team
                            .Include(x => x.User)
                            .Include(x => x.Likes)
                            .Include(x => x.Members)
                                .ThenInclude(x => x.TeamMember)
                                    .ThenInclude(x => x.Pokemon)
                            .Where(x =>
                                x.Members.Any(y => y.TeamMember.Nickname.ToLower().Contains(search.ToLower()))
                                || x.Members.Any(y => y.TeamMember.Pokemon.Name.ToLower().Contains(search.ToLower()))
                            );
                        break;
                    case 6:
                        teams = _context.Team
                            .Include(x => x.User)
                            .Include(x => x.Likes)
                            .Where(x => x.Name.ToLower().Contains(search.ToLower()));
                        break;
                    case 7:
                        teams = _context.Team
                            .Include(x => x.User)
                            .Include(x => x.Likes)
                            .Where(x => x.User.UserName == search);
                        break;
                    default:
                        teams = _context.Team
                            .Include(x => x.User)
                            .Include(x => x.Likes);
                        break;
                }
            }
            else
            {
                teams = _context.Team
                    .Include(x => x.User)
                    .Include(x => x.Likes);
            }

            teams = SortTeams(teams, sort);

            result.Teams = teams
                .Skip(skip)
                .Take(take)
                .Select(x => _mapper.Map<TeamModel>(x)).ToList();
            result.Total = teams.Count();

            return result;
        }

        public LikeModel UpdateLike(int teamId, string userId)
        {
            var existing = _context.TeamLikes.FirstOrDefault(x => x.TeamId == teamId && x.UserId == userId);

            if (existing == default(TeamLike))
            {
                _context.TeamLikes.Add(new TeamLike
                {
                    TeamId = teamId,
                    UserId = userId
                });
            }
            else
            {
                _context.TeamLikes.Remove(existing);
            }

            _context.SaveChanges();

            var likes = _context.TeamLikes.Where(x => x.TeamId == teamId);

            return new LikeModel
            {
                Likes = likes.Count(),
                LikedBy = likes.Select(x => x.UserId).ToArray()
            };
        }

        string GenerateCode(int size)
        {
            const string pool = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            var random = new Random();

            var code = new char[size];

            for (int i = 0; i < size; i++)
            {
                code[i] = pool[random.Next(pool.Length)];
            }

            return new string(code);
        }

        void DeleteTeamMembers(int teamId)
        {
            _context.TeamMembers.RemoveRange(
                _context.TeamMembers.Where(x => x.TeamId == teamId)
            );

            _context.SaveChanges();
        }

        IQueryable<Entities.Team.Team> SortTeams(IQueryable<Entities.Team.Team> teams, int sort)
        {
            switch(sort)
            {
                default:
                case 1:
                    return teams.OrderBy(x => x.Name);
                case 2:
                    return teams.OrderByDescending(x => x.Likes.Count);
            }
        }

        IEnumerable<TeamMemberModel> GetTeamMembers(IEnumerable<TeamMembers> memberRefs)
        {
            var list = new List<TeamMemberModel>();

            foreach (var member in memberRefs)
            {
                list.Add(
                    _mapper.Map<TeamMemberModel>(
                        _context.TeamMember
                            .Include(x => x.Pokemon)
                                .ThenInclude(y => y.Abilities)
                            .Include(x => x.Pokemon)
                                .ThenInclude(y => y.Moveset)
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
                            .First(z => z.Id == member.TeamMemberId)
                    )
                );
            }

            return list;
        }
    }
}
