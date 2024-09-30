namespace EcommerceAuthToken.Models
{
    public class Oreder
    {
        public int Id { get; set; }
        public string OrderStatus { get; set; }
        public int ProdId { get; set; }
        public List<Product> products { get; set; }
    }

}
