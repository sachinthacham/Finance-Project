using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Finance_Project.Contracts;
using Finance_Project.Mappers;
using Finance_Project.DTOs.comment;
using Finance_Project.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace Finance_Project.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IStockRepository _stockRepository;

        public CommentController(ICommentRepository commentRepository, IStockRepository stockRepository)
        {
            _commentRepository = commentRepository;
            _stockRepository = stockRepository;
        }

        [HttpGet]
        [Route("getall")]
        [Authorize]
        public async Task<IActionResult> GetAllComments()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var comments = await _commentRepository.getAllComments();
                if(comments == null)
                {
                    return NotFound();
                }

                var commentDto = comments.Select(s => s.ToCommentDto());
                return Ok(commentDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("get/{id:int}")]

        public async Task<IActionResult> getCommentById([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var comment = await _commentRepository.getCommentsById(id);
                if(comment == null)
                {
                    return NotFound();
                }

                return Ok(comment.ToCommentDto());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create/{stockId:int}")]

        public async Task<IActionResult> createComment([FromRoute] int stockId, [FromBody] CreateCommentRequest commentdto)
        {
            try
            {
                var IsStockavailable = await _stockRepository.isStockExcisting(stockId);
                if (!IsStockavailable)
                {
                    return BadRequest("stock is not excisting");
                }

                var commentModel = commentdto.ToCommentModel(stockId);
                await _commentRepository.CreateComment(commentModel);

                return CreatedAtAction(nameof(getCommentById), new { id = commentModel }, commentModel.ToCommentDto());
            }
            catch(Exception ex){ 
                return BadRequest(ex.Message);
            }
           

        }

        [HttpPut]
        [Route("update/{id}")]

        public async Task<IActionResult> UpdateComment([FromRoute] int id, [FromBody] UpdateCommentRequest commentdto)
        {
            try
            {
                var excistingComment = await _commentRepository.getCommentsById(id);
                if(excistingComment == null)
                {
                    return NotFound();
                }

                var commentModel =  commentdto.ToUpdateCommentModel();

                excistingComment.Title = commentModel.Title;
                excistingComment.Content = commentModel.Content;

               
                return Ok(excistingComment.ToCommentDto());

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete/{id:int}")]

        public async Task<IActionResult> deleteComment([FromRoute] int id)
        {
            var deletedComment = await _commentRepository.DeleteComment(id);
            if(deletedComment == null)
            {
                return NotFound();
            }
            return Ok(deletedComment.ToCommentDto());
        }
    }
}
