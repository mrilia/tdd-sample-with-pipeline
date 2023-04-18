using Microsoft.EntityFrameworkCore;
using TicketingSolution.Domain;

namespace TicketingSolution.Persistence
{
    public class TicketingSolutionDbContext : DbContext
    {
      

        public TicketingSolutionDbContext(DbContextOptions<TicketingSolutionDbContext> options) : 
            base(options)
        {

        }



        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketBooking> TicketBookings { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ticket>().HasData(
                new Ticket { Id = 1, Name = "To Shiraz" },
                new Ticket { Id = 2, Name = "To Esfahan" },
                new Ticket { Id = 3, Name = "To Mashhad" }
            );
        }


    }
}
