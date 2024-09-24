namespace EcommerceAuthToken.Models
{
    public class StoreModel
    {
        public int Id { get; set; }
        public string StoreName { get; set; }
        public List<ProductModel> products { get; set; }
    }
}
