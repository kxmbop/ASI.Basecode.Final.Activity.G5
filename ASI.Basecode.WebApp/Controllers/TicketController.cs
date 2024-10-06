using ASI.Basecode.Services.Interfaces;
using ASI.Basecode.Services.ServiceModels;
using ASI.Basecode.WebApp.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace ASI.Basecode.WebApp.Controllers
{
    public class TicketController : ControllerBase<TicketController>
    {
        private readonly ITicketService _ticketService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="configuration"></param>
        /// <param name="localizer"></param>
        /// <param name="mapper"></param>
        public TicketController(ITicketService ticketService,
                                IHttpContextAccessor httpContextAccessor,
                                ILoggerFactory loggerFactory,
                                IConfiguration configuration,
                                IMapper mapper = null) : base(httpContextAccessor, loggerFactory, configuration, mapper)
        {
            _ticketService = ticketService;
        }
        [HttpGet]

        public IActionResult Index()
        {
            var (success, tickets) = _ticketService.GetTicket();

            if (success && tickets != null)
            {
                // Map IEnumerable<Ticket> to List<TicketViewModel>
                var ticketViewModels = tickets.Select(t => new TicketViewModel
                {
                    TicketId = t.TicketId,
                    Subject = t.Subject,
                    SenderEmail = t.SenderEmail,
                    CreatedTime = t.CreatedTime,
                    UpdatedTime = t.UpdatedTime
                }).ToList();

                return View(ticketViewModels);  // Pass the mapped list to the view
            }
            else
            {
                return View(new List<TicketViewModel>());  // Pass an empty list if no tickets found or unsuccessful
            }
        }

    }
}
