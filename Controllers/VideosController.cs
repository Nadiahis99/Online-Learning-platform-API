using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_L_Platform2.Data;
using Online_L_Platform2.DTOs;
using Online_L_Platform2.Models;

namespace Online_L_Platform2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] 
    public class VideosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VideosController(AppDbContext context)
        {
            _context = context;
        }

        // Endpoint: GET /api/Videos/course/{courseId}
        // Role: Student, Teacher, Admin
        [HttpGet("course/{courseId}")]
        public async Task<ActionResult<IEnumerable<VideoReturnDto>>> GetVideosByCourse(int courseId)
        {
            var videos = await _context.Videos
                .Where(v => v.CourseId == courseId)
                .Select(v => new VideoReturnDto
                {
                    Id = v.id,
                    Title = v.title,
                    Url = v.VideoUrl,
                    CourseId = v.CourseId
                })
                .ToListAsync();

            return Ok(videos);
        }

        // Endpoint: POST /api/Videos
        // Role: Admin, Teacher
        [HttpPost]
        [Authorize(Roles = "Admin,Teacher")]
        public async Task<ActionResult> PostVideo(VideoCreateDto model)
        {
            var video = new Video
            {
                title = model.Title,
                VideoUrl = model.Url,
                CourseId = model.CourseId
            };

            _context.Videos.Add(video);
            await _context.SaveChangesAsync();

            return Ok(new { message = "تمت إضافة الفيديو بنجاح!" });
        }

        // Endpoint: PUT /api/Videos/{id}
        // Role: Admin, Teacher
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Teacher")]
        public async Task<IActionResult> PutVideo(int id, VideoCreateDto model)
        {
            var video = await _context.Videos.FindAsync(id);
            if (video == null) return NotFound();

            video.title = model.Title;
            video.VideoUrl = model.Url;
            video.CourseId = model.CourseId;

            _context.Entry(video).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Endpoint: DELETE /api/Videos/{id}
        // Role: Admin, Teacher
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Teacher")]
        public async Task<IActionResult> DeleteVideo(int id)
        {
            var video = await _context.Videos.FindAsync(id);
            if (video == null) return NotFound();

            _context.Videos.Remove(video);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}