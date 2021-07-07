namespace Backend.Application.DTOs.Modules
{
    public class GetModuleDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageSrc { get; set; }
        public int TotalCourses { get; set; }
        public int TotalHours { get; set; }

        public GetModuleDTO(int id, string name, int totalCourses, int totalHours, string imageSrc)
        {
            Id = id;
            Name = name;
            TotalCourses = totalCourses;
            TotalHours = totalHours;
            ImageSrc = imageSrc;
        }
    }
}
