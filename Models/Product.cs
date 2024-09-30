namespace EcommerceAuthToken.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int StoreId { get; set; }
        public Store store { get; set; }
        public List<Oreder> oreders { get; set; }

    }
}
