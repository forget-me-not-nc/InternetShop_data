namespace InternetShop_data.Data.DTO
{
    public class BookDTO
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string PublishingHouse { get; set; }
        public List<CategoryDTO> Categories { get; set; }
        public List<AuthorDTO> Authors { get; set; }
    }
}
