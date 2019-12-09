using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlashCardApi.Models
{
    public class Booklet
    {
        public long BookletId { get; set; }

        [Required]
        public string? Name { get; set; }

        public List<Card> Cards { get; set; }
    }
}
