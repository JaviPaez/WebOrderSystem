using Microsoft.AspNetCore.Mvc;
using WebOrderSystem.Services;

namespace WebOrderSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _postService;

        public CommentsController(ICommentService postService)
        {
            _postService = postService;
        }

        [HttpGet("TopPostIdsWithMostComments")]
        public IActionResult GetTopPostIdsWithMostComments()
        {
            var topPostIds = _postService.GetTopPostIdsWithMostComments();
            return Ok(topPostIds);
        }

        [HttpGet("TopPostWithMostComments")]
        public IActionResult GetTopPostsWithMostComments()
        {
            var comments = _postService.GetComments();
            return Ok(comments);
        }
    }
}
