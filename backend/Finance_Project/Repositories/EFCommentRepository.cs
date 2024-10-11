using Finance_Project.Contracts;
using Finance_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Finance_Project.Repositories
{
    public class EFCommentRepository:ICommentRepository
    {
        private readonly EFDbContext _dbContext;

        public EFCommentRepository(EFDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Comment>> getAllComments()
        {
            return await _dbContext.Comments.ToListAsync();
        }

        public async Task<Comment?> getCommentsById(int id)
        {
            return await _dbContext.Comments.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Comment> CreateComment(Comment commentModel)
        {
            await _dbContext.Comments.AddAsync(commentModel);
            await _dbContext.SaveChangesAsync();
            return commentModel;
        }

        public async Task<Comment?> DeleteComment(int id)
        {
            var commentTobeDeleted = await _dbContext.Comments.FirstOrDefaultAsync(x => x.Id == id);
            if(commentTobeDeleted != null)
            {
                _dbContext.Comments.Remove(commentTobeDeleted);
                await _dbContext.SaveChangesAsync();
                return commentTobeDeleted;
            }

            return null;
        }

        public async Task<Comment?> UpdateComment(int id)
        {
            return await _dbContext.Comments.FirstOrDefaultAsync(x =>x.Id == id);
        }
        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

    }
}
