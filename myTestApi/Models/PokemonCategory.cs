namespace myTestApi.Models
{
    public class PokemonCategory
    {
        public int PokemonId { get; set; }
        public int CategoryId { get; set;}
        public Pokemon Pokemons { get; set; }
        public Category Categorys { get; set; }
    }
}
