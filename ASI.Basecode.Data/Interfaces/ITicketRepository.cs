using ASI.Basecode.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Data.Interfaces
{
    public interface ITicketRepository
    {
        IEnumerable<Ticket> ViewTickets();
        void ViewTickets(Ticket ticket);
        int AddTicket(Ticket ticket);
        void DeleteTicket(int ticket);
        void UpdateTicket(Ticket ticket);
        Ticket GetTicketById(int id);

    }
}
