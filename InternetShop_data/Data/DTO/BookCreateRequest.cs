namespace InternetShop_data.Data.DTO
{
    public class BookCreateRequest
    {
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string PublishingHouse { get; set; }
        public int Count { get; set; }
        public List<int> Categories { get; set; }
        public List<int> Authors { get; set; }
        public bool IsDeleted { get; set; }
    }
}
