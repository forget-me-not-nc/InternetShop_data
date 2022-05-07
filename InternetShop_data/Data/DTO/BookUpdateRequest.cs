namespace InternetShop_data.Data.DTO
{
    public class BookUpdateRequest
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string PublishingHouse { get; set; }
        public int Count { get; set; }
        public bool IsDeleted { get; set; }
    }
}
