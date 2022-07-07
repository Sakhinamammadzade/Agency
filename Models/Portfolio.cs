namespace Agency.Models
{
    public class Portfolio:Base
    {
        public string Title { get; set; }
        public string PhotoUrl { get; set; }
        public string Description { get; set; }
        public string Client { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
