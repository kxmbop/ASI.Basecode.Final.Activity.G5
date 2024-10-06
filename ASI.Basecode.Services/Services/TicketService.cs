using ASI.Basecode.Data.Interfaces;
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

        public List<TicketViewModel> GetTickets()
        {

            var data = _ticketRepository.GetTicket().Select(s => new TicketViewModel
            {
                TicketId = s.TicketId,
                Subject = s.Subject,
                CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now,

            }).ToList();
            return data;
        }
    }
}
