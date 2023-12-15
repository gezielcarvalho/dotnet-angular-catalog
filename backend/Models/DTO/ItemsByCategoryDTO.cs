namespace Backend.Models.DTO
{
    public class ItemsByCategoryDTO
    {
        public List<Category> CategoryAscending { get; set; }
        public List<Category> CategoryDescending { get; set; }
        public long CategoryId { get; set; }
    }
}

