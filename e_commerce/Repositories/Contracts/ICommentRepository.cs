using Entities.Models;

namespace Repositories.Contracts
{
    public interface ICommentRepository : IRepositoriesBase<Comment>
    {
        IQueryable<Comment> getProductComment(int id);
        
    }
}