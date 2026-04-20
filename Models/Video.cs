namespace Online_L_Platform2.Models
{
    public class Video
    {
        public int id { get; set; }
        public string title { get; set; }
        public string VideoUrl { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; } 
    }
}
