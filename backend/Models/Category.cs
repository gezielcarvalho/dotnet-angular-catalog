using Backend.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Backend.Models
{
    [Table("Category")]
    public class Category : ISerializable, IComparable<Category>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<Product> Products { get; set; } = null!;

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public Category() { }
        public Category(string name)
        {
            Name = name;
        }
        public Category(int id, string name, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            Name = name;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public int CompareTo(Category? other)
        {
            if (other == null)
            {
                return 1;
            }
            return Id.CompareTo(other.Id);
        }

        public override bool Equals(object? obj)
        {
            return obj switch
            {
                Category => ((Category)obj).Id == Id,
                _ => false,
            };
        }

        public override int GetHashCode()
        {
            int prime = 31;
            int result = 1;
            result = (int)(prime * result + Id);
            return result;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {

            info.AddValue("id", Id);
            info.AddValue("name", Name);
            info.AddValue("createdAt", CreatedAt);
            info.AddValue("updatedAt", UpdatedAt);
        }
    }


}
