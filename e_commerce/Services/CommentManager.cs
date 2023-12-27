using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class CommentManager : ICommentService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        public CommentManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public void AddComment(CommentDtoForCreation commentDto)
        {
            Comment comment = _mapper.Map<Comment>(commentDto);
            _manager.Comment.Create(comment);
            _manager.Save();
        }

        public IQueryable<Comment> getProductComment(int id)
        {
            return _manager.Comment.getProductComment(id);
        }

       
    }
}