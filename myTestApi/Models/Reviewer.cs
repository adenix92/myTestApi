namespace myTestApi.Models
{
    public class Reviewer
    {
        /*
        public Reviewer() { 
        
            Reviews = new List<Review>();

            }
        */

        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public ICollection<Review> Reviews { get; set;}
    }
}
