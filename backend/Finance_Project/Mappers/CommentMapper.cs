using Finance_Project.DTOs.comment;
using Finance_Project.Models;

namespace Finance_Project.Mappers
{
    public static class CommentMapper
    {
        public static CommentDto ToCommentDto(this Comment commentModel)
        {
            return new CommentDto
            {
                Id = commentModel.Id,
                Title = commentModel.Title,
                Content = commentModel.Content,
                CreatedOn = commentModel.CreatedOn,
                StockId = commentModel.StockId,
            };
        }

        public static Comment ToCommentModel(this CreateCommentRequest commentDto, int stockId)
        {
            return new Comment
            {
                
                Title = commentDto.Title,
                Content = commentDto.Content,
                StockId = stockId,
            };
        }

        public static Comment ToUpdateCommentModel(this UpdateCommentRequest commentDto)
        {
            return new Comment
            {

                Title = commentDto.Title,
                Content = commentDto.Content,
                
            };
        }


    }
}
