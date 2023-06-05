namespace DepartmentSystemWebAPI.DTO
{
    public class StudentGradeDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string DepartmentName { get; set; }
        public string GraduateName { get; set; }
        public string LessonName { get; set; }
        public int LessonId { get; set; }
        public string Gender { get; set; }
        public int Vize { get; set; }
        public int Final { get; set; }
        public int But { get; set; }
    }
}
