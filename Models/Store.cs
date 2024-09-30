namespace EcommerceAuthToken.Models
{
    public class Store
    {
        public int Id { get; set; }
        public string StoreName { get; set; }
        public List<Product> products { get; set; }
    }
}
