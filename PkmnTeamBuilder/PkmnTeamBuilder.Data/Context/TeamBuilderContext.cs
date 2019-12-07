using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PkmnTeamBuilder.Data.Seed;
using PkmnTeamBuilder.Entities;

namespace PkmnTeamBuilder.Data.Context
{
    public class TeamBuilderContext : IdentityDbContext<AppUser>
    {
        public DbSet<AppUser> Users { get; set; }

        public DbSet<PokemonType> PokemonTypes { get; set; }

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

            var categories = CategorySeed.Seed(builder);
            var types = TypeSeed.Seed(builder);
            MatchupSeed.Seed(builder, types);
            AbilitySeed.Seed(builder);
            ItemSeed.Seed(builder);
            NatureSeed.Seed(builder);
            StatSeed.Seed(builder);
            var moves = MoveSeed.Seed(builder, types, categories);
            PokemonSeed.Seed(builder, types);
        }
    }
}
