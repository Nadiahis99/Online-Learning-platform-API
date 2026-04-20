namespace Online_L_Platform2.Models
{
    public class Result
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int ExamId { get; set; }
        public double Score { get; set; } 
        public User Student { get; set; } // النتيجة مرتبطة بطالب واحد وامتحان واحدone to one
        public Exam Exam { get; set; } // النتيجة مرتبطة بطالب واحد وامتحان واحدone to one 


    }
}
