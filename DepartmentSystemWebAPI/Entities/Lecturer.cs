namespace DepartmentSystemWebAPI.Entities
{
    public class Lecturer
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? surname { get; set; }
        public string? email { get; set; }
        public Boolean is_deleted { get; set; }
    }
}
