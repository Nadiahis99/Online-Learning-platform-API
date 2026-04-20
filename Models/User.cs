namespace Online_L_Platform2.Models
{
    public enum UserRole
    {
        Admin = 1,
        Teacher = 2,
        Student = 3
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public UserRole Role { get; set; }

        public bool IsApproved { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<Result> Results { get; set; }
        public ICollection<Course> CreatedCourses { get; set; }
        public ICollection<Video> CreatedVideos { get; set; }
        public ICollection<Exam> CreatedExams { get; set; }
    }
}