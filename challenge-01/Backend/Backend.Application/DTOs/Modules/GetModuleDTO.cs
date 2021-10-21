namespace Backend.Application.DTOs.Modules
{
    public class GetModuleDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TotalCourses { get; set; }

        public GetModuleDTO(int id, string name, int totalCourses)
        {
            Id = id;
            Name = name;
            TotalCourses = totalCourses;
        }
    }
}
