using Entities.Models;
using Repositories.Contracts;

namespace Repositories
{
    public class CommentRepository : RepositoryBase<Comment>, ICommentRepository
    {
        public CommentRepository(RepositoryContext context) : base(context)
        {
        }

        public IQueryable<Comment> getProductComment(int id)
        {
            return _context.Comments.Where(c =>c.productId == id);
        }

       
    }
}