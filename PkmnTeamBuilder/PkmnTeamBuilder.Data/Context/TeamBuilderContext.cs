using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PkmnTeamBuilder.Data.Seed;
using PkmnTeamBuilder.Entities;
using PkmnTeamBuilder.Entities.Team;

namespace PkmnTeamBuilder.Data.Context
{
    public class TeamBuilderContext : IdentityDbContext<AppUser>
    {
        public DbSet<AppUser> Users { get; set; }
        public DbSet<PokemonType> PokemonTypes { get; set; }
        public DbSet<Pokemon> Pokemon { get; set; }
        public DbSet<PokemonAbility> PokemonAbility { get; set; }
        public DbSet<PokemonAbilityset> PokemonAbilityset { get; set; }
        public DbSet<PokemonItem> PokemonItem { get; set; }
        public DbSet<PokemonMatchup> PokemonMatchup { get; set; }
        public DbSet<PokemonMove> PokemonMove { get; set; }
        public DbSet<PokemonMoveCategory> PokemonMoveCategory { get; set; }
        public DbSet<PokemonMoveset> PokemonMoveset { get; set; }
        public DbSet<PokemonMoveType> PokemonMoveType { get; set; }
        public DbSet<PokemonNature> PokemonNature { get; set; }
        public DbSet<PokemonStat> PokemonStat { get; set; }
        public DbSet<TeamMember> TeamMember { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<TeamLike> TeamLikes { get; set; }
        public DbSet<TeamMembers> TeamMembers { get; set; }
        public DbSet<NewsItem> News { get; set; }

        public TeamBuilderContext(DbContextOptions options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<PokemonType>(x =>
            {
                x.HasKey(y => y.Id);
                x.Property(y => y.Id).ValueGeneratedOnAdd();
            });

            builder.Entity<PokemonMatchup>(x =>
            {
                x.HasOne(y => y.AttackingType)
                    .WithMany(y => y.Attacking)
                    .HasForeignKey(y => y.AttackingTypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_PokemonType_PokemonMatchup_Attacking");

                x.HasOne(y => y.DefendingType)
                    .WithMany(y => y.Defending)
                    .HasForeignKey(y => y.DefendingTypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_PokemonType_PokemonMatchup_Defending");

                x.HasKey(y => y.Id);
                x.Property(y => y.Id).ValueGeneratedOnAdd();
            });

            builder.Entity<PokemonMoveType>(x =>
            {
                x.HasKey(y => y.Id);
                x.Property(y => y.Id).ValueGeneratedOnAdd();
            });

            builder.Entity<PokemonAbility>(x =>
            {
                x.HasKey(y => y.Id);
                x.Property(y => y.Id).ValueGeneratedOnAdd();
            });

            builder.Entity<PokemonItem>(x =>
            {
                x.HasKey(y => y.Id);
                x.Property(y => y.Id).ValueGeneratedOnAdd();
            });

            builder.Entity<PokemonNature>(x =>
            {
                x.HasKey(y => y.Id);
                x.Property(y => y.Id).ValueGeneratedOnAdd();
            });

            builder.Entity<PokemonStat>(x =>
            {
                x.HasKey(y => y.Id);
                x.Property(y => y.Id).ValueGeneratedOnAdd();
            });

            builder.Entity<Pokemon>(x =>
            {
                x.HasKey(y => y.Id);
                x.Property(y => y.Id).ValueGeneratedOnAdd();

                x.HasOne(y => y.Type1)
                    .WithMany(y => y.PokemonType1)
                    .HasForeignKey(y => y.Type1Id)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Type1_Pokemon");

                x.HasOne(y => y.Type2)
                    .WithMany(y => y.PokemonType2)
                    .HasForeignKey(y => y.Type2Id)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Type2_Pokemon");
            });

            builder.Entity<PokemonMoveset>(x =>
            {
                x.HasKey(y => y.Id);
                x.Property(y => y.Id).ValueGeneratedOnAdd();

                x.HasOne(y => y.Move)
                    .WithMany(y => y.Moveset)
                    .HasForeignKey(y => y.MoveId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Move_Moveset");

                x.HasOne(y => y.MoveType)
                    .WithMany(y => y.Moveset)
                    .HasForeignKey(y => y.MoveTypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_MoveType_Moveset");

                x.HasOne(y => y.Pokemon)
                    .WithMany(y => y.Moveset)
                    .HasForeignKey(y => y.PokemonId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Pokemon_Moveset");
            });

            builder.Entity<PokemonAbilityset>(x =>
            {
                x.HasKey(y => y.Id);
                x.Property(y => y.Id).ValueGeneratedOnAdd();

                x.HasOne(y => y.Ability)
                    .WithMany(y => y.Abilityset)
                    .HasForeignKey(y => y.AbilityId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Ability_Abilityset");

                x.HasOne(y => y.Pokemon)
                    .WithMany(y => y.Abilities)
                    .HasForeignKey(y => y.PokemonId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Pokemon_Abilityset");
            });

            builder.Entity<TeamMember>(x =>
            {
                x.HasKey(y => y.Id);
                x.Property(y => y.Id).ValueGeneratedOnAdd();

                x.HasOne(y => y.Pokemon)
                    .WithMany(y => y.TeamMembers)
                    .HasForeignKey(y => y.PokemonId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_TeamMember_Pokemon");

                x.HasOne(y => y.Ability)
                    .WithMany(y => y.TeamMembers)
                    .HasForeignKey(y => y.AbilityId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_TeamMember_PokemonAbility");

                x.HasOne(y => y.Nature)
                    .WithMany(y => y.TeamMembers)
                    .HasForeignKey(y => y.NatureId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_TeamMember_Nature");

                x.HasOne(y => y.Item)
                    .WithMany(y => y.TeamMembers)
                    .HasForeignKey(y => y.ItemId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_TeamMember_Item");

                x.HasOne(y => y.Move1)
                    .WithMany(y => y.TeamMembers1)
                    .HasForeignKey(y => y.Move1Id)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_TeamMember_Move1");

                x.HasOne(y => y.Move2)
                    .WithMany(y => y.TeamMembers2)
                    .HasForeignKey(y => y.Move2Id)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_TeamMember_Move2");

                x.HasOne(y => y.Move3)
                    .WithMany(y => y.TeamMembers3)
                    .HasForeignKey(y => y.Move3Id)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_TeamMember_Move3");

                x.HasOne(y => y.Move4)
                    .WithMany(y => y.TeamMembers4)
                    .HasForeignKey(y => y.Move4Id)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_TeamMember_Move4");

                x.HasOne(y => y.User)
                    .WithMany(y => y.TeamMembers)
                    .HasForeignKey(y => y.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_TeamMember_User");
            });

            builder.Entity<Team>(x =>
            {
                x.HasKey(a => a.Id);
                x.Property(a => a.Id).ValueGeneratedOnAdd();

                x.HasOne(y => y.User)
                    .WithMany(y => y.Teams)
                    .HasForeignKey(y => y.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Team_User");
            });

            builder.Entity<TeamLike>(x =>
            {
                x.HasKey(a => a.Id);
                x.Property(a => a.Id).ValueGeneratedOnAdd();

                x.HasOne(a => a.Team)
                    .WithMany(a => a.Likes)
                    .HasForeignKey(a => a.TeamId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_TeamLikes_Team");

                x.HasOne(a => a.User)
                    .WithMany(a => a.TeamLikes)
                    .HasForeignKey(a => a.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_User_TeamMember");
            });

            builder.Entity<TeamMembers>(x =>
            {
                x.HasKey(a => a.Id);
                x.Property(a => a.Id).ValueGeneratedOnAdd();

                x.HasOne(a => a.Team)
                    .WithMany(a => a.Members)
                    .HasForeignKey(a => a.TeamId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_TeamMembers_Team");

                x.HasOne(a => a.TeamMember)
                    .WithMany(a => a.Members)
                    .HasForeignKey(a => a.TeamMemberId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_TeamMembers_TeamMember");
            });

            builder.Entity<NewsItem>(x =>
            {
                x.HasKey(a => a.Id);
                x.Property(a => a.Id).ValueGeneratedOnAdd();
            });

            var categories = CategorySeed.Seed(builder);
            var types = TypeSeed.Seed(builder);
            var moveTypes = MoveTypeSeed.Seed(builder);
            MatchupSeed.Seed(builder, types);
            var abilities = AbilitySeed.Seed(builder);
            ItemSeed.Seed(builder);
            NatureSeed.Seed(builder);
            StatSeed.Seed(builder);
            var moves = MoveSeed.Seed(builder, types, categories);
            PokemonSeed.Seed(builder, types, moveTypes, moves, abilities);
        }
    }
}
