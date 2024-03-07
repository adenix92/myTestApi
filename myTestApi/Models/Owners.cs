namespace myTestApi.Models
{
    public class Owners
    {
        //public Owners() { }
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Gym { get; set; } 
        public Country Countrys { get; set; }
        public ICollection<PokemenOwner> PokemenOwners { get; set; }
    }
}
