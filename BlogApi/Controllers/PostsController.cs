using BlogApi.Data;
using BlogApi.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly BlogContext _context;

        public PostsController(BlogContext context)
        {
            _context = context;
        }

        // GET POSTS
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
        {
            return await _context.Posts.ToListAsync();
        }

        // CREATE POST
        [HttpPost]
        public async Task<ActionResult<Post>> CreatePost(Post post)
        {
            if (
                Request.Headers["role"] != "Professor" &&
                Request.Headers["role"] != "Admin"
            )
            {
                return Unauthorized(
                    "Apenas professores e administradores podem criar posts"
                );
            }

            post.Author = Request.Headers["author"];

            _context.Posts.Add(post);

            await _context.SaveChangesAsync();

            return Ok(post);
        }

        // UPDATE POST
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePost(
            int id,
            Post updatedPost
        )
        {
            if (
                Request.Headers["role"] != "Professor" &&
                Request.Headers["role"] != "Admin"
            )
            {
                return Unauthorized(
                    "Apenas professores e administradores podem editar posts"
                );
            }

            var post =
                await _context.Posts.FindAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            post.Title = updatedPost.Title;
            post.Content = updatedPost.Content;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE POST
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePost(
            int id
        )
        {
            if (
                Request.Headers["role"] != "Professor" &&
                Request.Headers["role"] != "Admin"
            )
            {
                return Unauthorized(
                    "Apenas professores e administradores podem excluir posts"
                );
            }

            var post =
                await _context.Posts.FindAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            _context.Posts.Remove(post);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}