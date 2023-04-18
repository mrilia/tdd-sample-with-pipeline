using TicketingSolution.Domain;

namespace TicketingSolution.Core.DataServices
{
    public interface ITicketBookingService
    {
        void Save(TicketBooking ticketBooking);

        IEnumerable<Ticket> GetAvailabeTickets(DateTime Date);

    }
}
