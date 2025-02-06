namespace Poetry_Api.DTO
{
    public class AddAuthorDTO
    {
        public string Name { get; set; }
        public string Bio { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }
    }
}
