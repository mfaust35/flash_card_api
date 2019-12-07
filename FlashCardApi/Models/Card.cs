using System;
using System.ComponentModel.DataAnnotations;

namespace FlashCardApi.Models
{
    public class Card
    {
        public long Id { get; set; }

        [Required]
        public int? Rating { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime? NextReview { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime? UpdatedAt { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime? CreatedAt { get; set; }

        [Required]
        public long? BookletId { get; set; }
    }
}
