namespace Online_L_Platform2.Models
{
    public class Exam
    {
        public int id { get; set; }
        public string Tilte { get; set; }
        public int CourseId { get; set; } // مرجع إلى الكورس اللي الامتحان ده بيتبع له

        public Course Course { get; set; } // العلاقة بين الامتحان والكورس (كل امتحان بيتبع لكورس واحد) one to one
        public ICollection<Result> Results { get; set; } // الامتحان الواحد يقدر يشارك فيه كذا طالب
    }
}
