namespace BulletinBoardApi.Models
{
    public class Ad
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public string? ContactName { get; set; }
        public string? Phone { get; set; }
        public string? ImageBase64 { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
