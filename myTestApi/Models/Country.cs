namespace myTestApi.Models
{
    public class Country
    {
        /*public Country() { 
        this.Owner = new List<Owners>();
            }
        */

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Owners> Owner { get; set;}
    }
}
