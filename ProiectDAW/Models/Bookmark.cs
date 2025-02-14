using System.ComponentModel.DataAnnotations;
using static ProiectDAW.Models.ProductBookmarks;

namespace ProiectDAW.Models
{
    public class Bookmark
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Numele colectiei este obligatoriu")]
        public string Name { get; set; }
        public string? UserId { get; set; }
        public virtual ApplicationUser? User { get; set; }
        public virtual ICollection<ProductBookmark>? ProductBookmarks { get; set; }
    }
}
