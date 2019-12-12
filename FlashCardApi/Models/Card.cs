using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FlashCardApi.Models
{
    public class Card
    {
        [Required]
        public long CardId { get; set; }

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
        public long BookletId { get; set; }

        [JsonIgnore]
        public Booklet Booklet { get; set; }
    }
}
