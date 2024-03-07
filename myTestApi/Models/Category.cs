namespace myTestApi.Models
{
    public class Category
    {
        /*public Category() { 
        PokemonCategories = new List<PokemonCategory>();
            }
        */
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<PokemonCategory> PokemonCategories { get; set; }
    }
}
