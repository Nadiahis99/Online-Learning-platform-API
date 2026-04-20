namespace Online_L_Platform2.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        // foreign key للمدرس
        public int? TeacherId { get; set; }
        public User Teacher { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
