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
        IEnumerable<TeamModel> GetTeams(string userId);
        TeamModel AddTeam(TeamModel model);
        TeamModel UpdateTeam(TeamModel model);
        IEnumerable<TeamMember> AddTeamMembers(IEnumerable<TeamMemberModel> members);
        void UpdateTeamMembers(IEnumerable<TeamMemberModel> members);
        void DeleteTeam(int id);
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

            UpdateTeamMembers(model.Members);

            _context.Update(team);

            _context.SaveChanges();

            return _mapper.Map<TeamModel>(team);
        }

        public void UpdateTeamMembers(IEnumerable<TeamMemberModel> members)
        {
            var mapped = members.Select(y => _mapper.Map<TeamMember>(y));

            foreach(var map in mapped)
            {
                _context.TeamMember.Update(map);
            }

            _context.SaveChanges();
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
            var team = _context.Team.FirstOrDefault(x => x.Code == code);

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

        public IEnumerable<TeamModel> GetTeams(string userId)
        {
            var teams = _context.Team.Where(x => x.UserId == userId);

            var mappedTeams = teams.Select(x => _mapper.Map<TeamModel>(x)).ToList();

            foreach (var team in mappedTeams)
            {
                var members = _context.TeamMembers.Where(y => y.TeamId == team.Id);
                var list = new List<TeamMemberModel>();

                foreach (var member in members)
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

                team.Members = list;
            }

            return mappedTeams;
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
    }
}
