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
    public class CoursesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CoursesController(AppDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin,Teacher,Student")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseReturnDto>>> GetCourses()
        {
            var courses = await _context.Courses
                .Include(c => c.Teacher)
                .Select(c => new CourseReturnDto
                {
                    Id = c.Id,
                    Title = c.Title,
                    Description = c.Description,
                    TeacherName = c.Teacher.Name
                })
                .ToListAsync();

            return Ok(courses);
        }

        [Authorize(Roles = "Admin,Teacher")]
        [HttpPost]
        public async Task<ActionResult> PostCourse(CourseCreateDto courseDto)
        {
            var course = new Course
            {
                Title = courseDto.Title,
                Description = courseDto.Description,
                TeacherId = courseDto.TeacherId
            };

            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            return Ok(new { message = "تم إضافة الكورس بنجاح", courseId = course.Id });
        }

        [Authorize(Roles = "Admin,Teacher")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null) return NotFound();

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}