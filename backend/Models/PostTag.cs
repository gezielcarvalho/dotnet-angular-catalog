using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Backend.Models
{
    public class PostTag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Post")]
        public int PostId { get; set; }

        public Post? Post { get; set; }

        [ForeignKey("Tag")]
        public int TagId { get; set; }

        public Tag? Tag { get; set; }
    }
}
