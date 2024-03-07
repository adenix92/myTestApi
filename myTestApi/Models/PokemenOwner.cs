namespace myTestApi.Models
{
    public class PokemenOwner
    {
        //public PokemenOwner() { }
        public int PokemonId { get; set; }
        public int OwnerId { get; set; }
        public Pokemon Pokemon { get; set; }
        public  Owners Owners { get; set; }
    }
}
