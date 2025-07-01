using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideoGameApi.Data;

namespace VideoGameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameController : ControllerBase
    {
        private readonly VideoGameDBContext _context;

        public VideoGameController(VideoGameDBContext context)
        {
            _context = context;
        }

        //[Authorize]
        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<List<VideoGame>>> GetVideoGame()
        {
            var videoGames = await _context.VideoGames.ToListAsync();
            return Ok(videoGames);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<VideoGame>> GetVideoGameById(int id)
        {
            var videoGame = await _context.VideoGames.FindAsync(id);
            if (videoGame == null)
            {
                return NotFound();
            }
            return Ok(videoGame);
        }

        [HttpPost]
        public async Task<IActionResult> AddVideoGame(VideoGame newGame)
        {
            if(newGame is null)
                return BadRequest();

            await _context.VideoGames.AddAsync(newGame);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVideoGameById), new { id = newGame.Id }, newGame);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateVideoGame(int id, VideoGame updvideoGame)
        {
            var videoGame = await _context.VideoGames.FindAsync(id);
            if (videoGame is null)
                return NotFound();

            if (updvideoGame is null)
                return BadRequest();

            videoGame.Title = updvideoGame.Title;
            videoGame.Platform = updvideoGame.Platform;
            videoGame.Developer = updvideoGame.Developer;
            videoGame.Publisher = updvideoGame.Publisher;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteVideoGame(int id)
        {
            var game = _context.VideoGames.FirstOrDefault(v => v.Id == id);
            if (game is null)
                return NotFound();

            _context.VideoGames.Remove(game);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
