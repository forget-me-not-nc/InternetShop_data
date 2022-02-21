using System.ComponentModel.DataAnnotations.Schema;

namespace InternetShop_data.Data.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string PublishingHouse { get; set; }
        public int Count { get; set; }
    }
}
