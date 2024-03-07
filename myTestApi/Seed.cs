using Microsoft.EntityFrameworkCore;
using myTestApi.Datas;
using myTestApi.Models;

namespace myTestApi
{
    public class Seed
    {
       // private readonly static DataDbContexts dataDbContexts;
       /* public Seed(DataDbContexts Contexts)
        {
            dataDbContexts = Contexts;
        }
       */
        public static void SeedDataContext(IServiceProvider serviceProvider)
        {
            try
            {
                using (var dc = new DataDbContexts(serviceProvider.GetRequiredService<DbContextOptions<DataDbContexts>>()))
                {
                    
                    if (!dc.PokemenOwner.Any())
                    {
                        var pokemonOwners = new List<PokemenOwner>()
                {
                    new PokemenOwner()
                    {
                        Pokemon = new Pokemon()
                        {
                            Name = "Pikachu",
                            BirthDate = new DateTime(1903,1,1),
                            PokemonCategory = new List<PokemonCategory>()
                            {
                                new PokemonCategory { Categorys = new Category() { Name = "Electric"}}
                            },
                            Review = new List<Review>()
                            {
                                new Review { Title="Pikachu",Text = "Pickahu is the best pokemon, because it is electric",
                                Reviewers = new Reviewer(){ FirstName = "Teddy", LastName = "Smith" } },
                                new Review { Title="Pikachu", Text = "Pickachu is the best a killing rocks",
                                Reviewers = new Reviewer(){ FirstName = "Taylor", LastName = "Jones" } },
                                new Review { Title="Pikachu",Text = "Pickchu, pickachu, pikachu",
                                Reviewers = new Reviewer(){ FirstName = "Jessica", LastName = "McGregor" } },
                            }
                        },
                        Owners = new Owners()
                        {
                            Name = "Jack",

                            Gym = "Brocks Gym",
                            Countrys = new Country()
                            {
                                Name = "Kanto"
                            }
                        }
                    },
                    new PokemenOwner()
                    {
                        Pokemon = new Pokemon()
                        {
                            Name = "Squirtle",
                            BirthDate = new DateTime(1903,1,1),
                            PokemonCategory = new List<PokemonCategory>()
                            {
                                new PokemonCategory { Categorys = new Category() { Name = "Water"}}
                            },
                            Review = new List<Review>()
                            {
                                new Review { Title= "Squirtle", Text = "squirtle is the best pokemon, because it is electric",
                                Reviewers = new Reviewer(){ FirstName = "Teddy", LastName = "Smith" } },
                                new Review { Title= "Squirtle",Text = "Squirtle is the best a killing rocks",
                                Reviewers = new Reviewer(){ FirstName = "Taylor", LastName = "Jones" } },
                                new Review { Title= "Squirtle", Text = "squirtle, squirtle, squirtle",
                                Reviewers = new Reviewer(){ FirstName = "Jessica", LastName = "McGregor" } },
                            }
                        },
                        Owners = new Owners()
                        {
                            Name = "Harry",
                            //LastName = "Potter",
                            Gym = "Mistys Gym",
                            Countrys = new Country()
                            {
                                Name = "Saffron City"
                            }
                        }
                    }

                };
                        dc.PokemenOwner.AddRange(pokemonOwners);
                        dc.SaveChanges();
                    }


                }







                //
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message.ToString());
            }
            
        }
    }
}
