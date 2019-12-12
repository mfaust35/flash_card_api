using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FlashCardApi.Models
{
    public class Booklet
    {
        [Required]
        public long BookletId { get; set; }

        [Required]
        public string Name { get; set; }

        public List<Card> Cards { get; set; }
    }
}
