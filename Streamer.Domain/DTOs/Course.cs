namespace Streamer.Domain.DTOs
{
    public class Course
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public static implicit operator Course(Entities.Course entity)
        {
            return new Course
            {
                Id = entity.Id.ToString(),
                Name = entity.Name,
            };
        }
    }
}
