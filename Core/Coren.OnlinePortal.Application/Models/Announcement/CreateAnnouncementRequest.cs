using AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace Coren.OnlinePortal.Application.Models.Announcement
{
    [AutoMap(typeof(Domain.Entities.Announcement), ReverseMap = true)]
    public class CreateAnnouncementRequest
    {
        public string Description { get; set; }
        [Required]
        public string Title { get; set; }
        public bool ShowHomePage { get; set; }
        public string Content { get; set; }
    }
}
