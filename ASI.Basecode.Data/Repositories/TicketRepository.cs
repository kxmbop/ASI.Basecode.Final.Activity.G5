﻿using ASI.Basecode.Data.Interfaces;
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

        public void AddTicket(Ticket ticket)
        {
            _dbContext.Tickets.Add(ticket);
            _dbContext.SaveChanges();
        }

        public void DeleteTicket(Ticket ticket)
        {
            _dbContext.Remove(ticket);
            _dbContext.SaveChanges();
        }

        public void UpdateTicket(Ticket ticket)
        {
            var existingTicket = _dbContext.Tickets.FirstOrDefault(t => t.TicketId == ticket.TicketId);
            if (existingTicket != null)
            {
                existingTicket.Subject = ticket.Subject;
                existingTicket.SenderEmail = ticket.SenderEmail;
                _dbContext.Tickets.Update(existingTicket);
                _dbContext.SaveChanges();
            }
        }

        public void ViewTickets(Ticket ticket)
        {
            throw new NotImplementedException();
        }
    }
}