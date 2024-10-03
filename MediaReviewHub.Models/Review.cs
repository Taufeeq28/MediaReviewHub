using System.ComponentModel.DataAnnotations;

namespace MediaReviewHub.Models
{
    public class Review
    {
        [Key]
        public int ReviewID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string ReviewText { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateReviewed { get; set; }
    }
}
