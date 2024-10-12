using ASI.Basecode.Data.Interfaces;
using ASI.Basecode.Data.Models;
using Basecode.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Data.Repositories
{
    public class TicketRepository : BaseRepository, ITicketRepository
    {
        //List<Ticket> _ticketList = new();
        private readonly AsiBasecodeDBContext _dbContext;

        public TicketRepository(AsiBasecodeDBContext dBContext, UnitOfWork unitOfWork) : base(unitOfWork)
        {
            _dbContext = dBContext;
        }
        public IEnumerable<Ticket> ViewTickets()
        {
            return _dbContext.Tickets.ToList();
        }

        public int AddTicket(Ticket ticket)
        {
            _dbContext.Tickets.Add(ticket);
            _dbContext.SaveChanges();
            return ticket.TicketId;
        }

        public void DeleteTicket(int ticketId)
        {
            var ticket = _dbContext.Tickets.Find(ticketId);
            if (ticket != null)
            {
                _dbContext.Tickets.Remove(ticket);
                _dbContext.SaveChanges();
            }
        }

        public void UpdateTicket(Ticket ticket)
        {
            var existingTicket = _dbContext.Tickets.FirstOrDefault(t => t.TicketId == ticket.TicketId);

            if (existingTicket != null)
            {
                existingTicket.Subject = ticket.Subject;
                existingTicket.SenderEmail = ticket.SenderEmail;
                existingTicket.Category = ticket.Category;
                existingTicket.Priority = ticket.Priority;
                existingTicket.Status = ticket.Status;
                existingTicket.UpdatedTime = ticket.UpdatedTime;

                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception("Ticket not found");
            }
        }

        public void ViewTickets(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public Ticket GetTicketById(int id)
        {
            //return _dbContext.Tickets.FirstOrDefault(t => t.TicketId == id);
            return _dbContext.Tickets.Find(id);

        }
    }
}
