using Microsoft.EntityFrameworkCore;
using myTestApi.Models;

namespace myTestApi.Datas
{
    public class DataDbContexts:DbContext
    {
        public DataDbContexts(DbContextOptions<DataDbContexts> Options):base(Options) { 
        


        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Owners> Owners { get; set; }
        public DbSet<PokemenOwner> PokemenOwner { get; set; }
        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<PokemonCategory> PokemonCategories { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // link two id together.
            modelBuilder.Entity<PokemonCategory>()
                .HasKey(k => new { k.PokemonId, k.CategoryId });

            modelBuilder.Entity<PokemonCategory>()
                .HasOne(p => p.Pokemons)
                .WithMany(pc => pc.PokemonCategory)
                .HasForeignKey(c => c.PokemonId);
            modelBuilder.Entity<PokemonCategory>()
                .HasOne(p => p.Categorys)
                .WithMany(pc => pc.PokemonCategories)
                .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<PokemenOwner>()
                .HasKey(k => new { k.OwnerId, k.PokemonId });
            modelBuilder.Entity<PokemenOwner>()
                .HasOne(p => p.Pokemon)
                .WithMany(pc=>pc.PokemenOwner)
                .HasForeignKey(c=>c.PokemonId);
            modelBuilder.Entity<PokemenOwner>()
                .HasOne(p => p.Owners)
                .WithMany(pc=>pc.PokemenOwners)
                .HasForeignKey(c=> c.OwnerId);
            



          // base.OnModelCreating(modelBuilder);
        }


    }
}
