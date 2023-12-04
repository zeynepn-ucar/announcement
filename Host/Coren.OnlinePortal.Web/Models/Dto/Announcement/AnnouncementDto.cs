namespace Coren.OnlinePortal.Web.Models.Dto.Announcement
{
    public class AnnouncementDto
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public bool ShowHomePage { get; set; }
        public string Content { get; set; }
    }
}
