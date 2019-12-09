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
                    .WithMany(y => y.Pokemon)
                    .HasForeignKey(y => y.Type1Id)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Type1_Pokemon");

                x.HasOne(y => y.Type2)
                    .WithMany(y => y.Pokemon)
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

            var categories = CategorySeed.Seed(builder);
            var types = TypeSeed.Seed(builder);
            var moveTypes = MoveTypeSeed.Seed(builder);
            MatchupSeed.Seed(builder, types);
            AbilitySeed.Seed(builder);
            ItemSeed.Seed(builder);
            NatureSeed.Seed(builder);
            StatSeed.Seed(builder);
            var moves = MoveSeed.Seed(builder, types, categories);
            PokemonSeed.Seed(builder, types, moveTypes, moves);
        }
    }
}
