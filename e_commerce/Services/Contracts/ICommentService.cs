using Entities.Dtos;
using Entities.Models;

namespace Services.Contracts
{
    public interface ICommentService
    {
        IQueryable<Comment> getProductComment(int id);
        void AddComment(CommentDtoForCreation commentDto);
        
    }
}