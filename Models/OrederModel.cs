namespace EcommerceAuthToken.Models
{
    public class OrederModel
    {
        public int Id { get; set; }
        public string OrderStatus { get; set; }
        public int ProdId { get; set; }
        public List<ProductModel> products { get; set; }
    }

}
