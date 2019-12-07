using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlashCardApi.Models
{
    public class FlashContext : DbContext
    {
        public FlashContext(DbContextOptions<FlashContext> options)
            : base(options)
        {
        }

        public DbSet<Card> FlashCards { get; set; }
    }
}
