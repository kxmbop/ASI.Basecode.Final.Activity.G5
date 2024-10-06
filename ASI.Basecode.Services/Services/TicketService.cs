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

        public void AddTicket(Ticket ticket)
        {
            if (ticket == null)
            {
                throw new ArgumentNullException();
            }
            var newTicket = new Ticket();
            newTicket.TicketId = ticket.TicketId;  
            newTicket.Subject = ticket.Subject; 
            newTicket.SenderEmail = ticket.SenderEmail;
            _ticketRepository.AddTicket(newTicket);
        }

        public void DeleteTicket(Ticket ticket)
        {
            _ticketRepository?.DeleteTicket(ticket);
        }

        public void UpdateTicket(Ticket ticket)
        {
            if (ticket == null)
            {
                throw new AccessViolationException();
            }
            _ticketRepository.UpdateTicket(ticket);
        }

    }
}
