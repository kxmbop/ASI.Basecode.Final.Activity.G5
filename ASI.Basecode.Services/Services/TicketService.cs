using ASI.Basecode.Data.Interfaces;
using ASI.Basecode.Data.Models;
using ASI.Basecode.Services.Interfaces;
using ASI.Basecode.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Services.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public (bool, IEnumerable<Ticket>) GetTicket()
        { 
            var tickets = _ticketRepository.ViewTickets();
            if (tickets != null)
            {
                return (true, tickets);
            }
            else
            {
                return (false, null);
            }

        }

        public int AddTicket(Ticket ticket) 
        {
            if (ticket == null)
            {
                throw new ArgumentNullException(nameof(ticket));
            }

            var newTicket = new Ticket
            {
                Subject = ticket.Subject,
                SenderEmail = ticket.SenderEmail,
                CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            };

            return _ticketRepository.AddTicket(newTicket);
        }

        public void DeleteTicket(int ticketId)
        {
            _ticketRepository.DeleteTicket(ticketId);
        }

        public void UpdateTicket(Ticket ticket)
        {
            if (ticket == null)
            {
                throw new AccessViolationException();
            }
            _ticketRepository.UpdateTicket(ticket);
        }

        public Ticket GetTicketById(int id)
        {
            return _ticketRepository.GetTicketById(id); 
        }

    }
}
