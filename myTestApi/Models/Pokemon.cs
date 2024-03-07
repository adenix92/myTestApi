namespace myTestApi.Models
{
    public class Pokemon
    {
        //public Pokemon() { }
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; } 
        public ICollection<Review> Review { get; set; }
        public ICollection<PokemenOwner> PokemenOwner { get; set; }
        public ICollection<PokemonCategory> PokemonCategory { get; set; }
    }
}
