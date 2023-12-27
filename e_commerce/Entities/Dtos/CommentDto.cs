using Entities.Models;

namespace Entities.Dtos
{
    public record CommentDto
    {
        public int CommentId { get; init; }
        public int productId { get; set; }
        public String? UserId {get;set;}
        public Product? product { get; init; }
        public String? Description { get; init; }
    }
}