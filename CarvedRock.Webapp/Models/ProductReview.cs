namespace CarvedRock.Webapp.Models
{
    public class ProductReview
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        
        public string Title { get; set; }
        public string Review { get; set; }
    }
}