using TicketingSolution.Core.DataServices;
using TicketingSolution.Domain;

namespace TicketingSolution.Persistence.Repositories
{
    public class TicketBookingService : ITicketBookingService
    {
        private readonly TicketingSolutionDbContext _context;

        public TicketBookingService(TicketingSolutionDbContext context)
        {
            this._context = context;
        }

        public IEnumerable<Ticket> GetAvailabeTickets(DateTime Date)
        {
            return _context.Tickets
                .Where(q => !q.TicketBooking.Any(x => x.Date == Date))
                .ToList();
        }

        public void Save(TicketBooking ticketBooking)
        {
            _context.Add(ticketBooking);
            _context.SaveChanges();
        }
    }
}
