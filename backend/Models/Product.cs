using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [ForeignKey("Category")]
        public long CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? ImgUrl { get; set; } = null!;
        public double Price { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Product() { }
        public Product(string name, string description, string imgUrl, double price)
        {
            Name = name;
            Description = description;
            ImgUrl = imgUrl;
            Price = price;
        }

        public Product(long categoryId, string name, string description, string imgUrl, double price)
        {
            CategoryId = categoryId;
            Name = name;
            Description = description;
            ImgUrl = imgUrl;
            Price = price;
        }

        public Product(long id, long categoryId, string name, string description, string imgUrl, double price, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            CategoryId = categoryId;
            Name = name;
            Description = description;
            ImgUrl = imgUrl;
            Price = price;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
