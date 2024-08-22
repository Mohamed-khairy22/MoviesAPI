namespace MoviesAPI.DTO
{
    public class CreateGenre
    {
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
