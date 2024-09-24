namespace EcommerceAuthToken.Models
{
    public class ProductModel
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int StoreId { get; set; }
        public StoreModel store { get; set; }
        public List<OrederModel> oreders { get; set; }

    }
}
