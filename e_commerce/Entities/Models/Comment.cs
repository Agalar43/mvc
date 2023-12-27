namespace Entities.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public String? UserId { get; set; }
        public int productId { get; set; }
        public Product? product { get; set; }
        public String? Description { get; set; }
    }
}