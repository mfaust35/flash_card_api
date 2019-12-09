using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlashCardApi.Models;

namespace FlashCardApi.Models
{
    public class FlashContext : DbContext
    {
        public FlashContext(DbContextOptions<FlashContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Card>()
                        .HasOne(c => c.Booklet)
                        .WithMany(b => b.Cards)
                        .HasForeignKey(c => c.BookletId)
                        .IsRequired(true)
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("ForeignKey_Card_Booklet");
        }

        public DbSet<Card> Cards { get; set; }

        public DbSet<Booklet> Booklets { get; set; }
    }
}
