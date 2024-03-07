namespace myTestApi.Models
{
    public class Review
    {
        /*
        public Review() {
        Reviewers = new Reviewer();
        Pokemons = new Pokemon();

            }
        */
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Text { get; set; }  = string.Empty;
        public  Reviewer Reviewers { get; set; }
        public Pokemon Pokemons { get; set; }
        
    }
}
