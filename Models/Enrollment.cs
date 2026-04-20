namespace Online_L_Platform2.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public int CourseId { get; set; } // مرجع إلى الكورس اللي الطالب ده مسجل فيه
        public DateTime EnrollmentDate { get; set; } // تاريخ التسجيل في الكورس
        public User Student { get; set; } // العلاقة بين التسجيل والطالب (كل تسجيل مرتبط بطالب واحد) one to one
        public Course Course { get; set; } // العلاقة بين التسجيل والكورس (كل تسجيل مرتبط بكورس واحد) one to one


    }
}
