using Finance_Project.Models;

namespace Finance_Project.Contracts
{
    public interface ICommentRepository
    {
        Task<List<Comment>> getAllComments();
        Task<Comment?> getCommentsById(int id);
        Task<Comment> CreateComment(Comment commentModel);
        Task<Comment?> DeleteComment(int id);
        Task<Comment?> UpdateComment(int id);
        Task SaveChangesAsync();
    }
}
