using ASI.Basecode.Data.Models;
using ASI.Basecode.Services.Interfaces;
using ASI.Basecode.Services.ServiceModels;
using ASI.Basecode.Services.Services;
using ASI.Basecode.WebApp.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ASI.Basecode.WebApp.Controllers
{
    public class TicketController : ControllerBase<TicketController>
    {
        private readonly ITicketService _ticketService;
        private readonly IResponseService _responseService;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="configuration"></param>
        /// <param name="localizer"></param>
        /// <param name="mapper"></param>
        public TicketController(ITicketService ticketService,
                                IResponseService responseService,
                                IHttpContextAccessor httpContextAccessor,
                                ILoggerFactory loggerFactory,
                                IConfiguration configuration,
                                IMapper mapper = null) : base(httpContextAccessor, loggerFactory, configuration, mapper)
        {
            _responseService = responseService;
            _ticketService = ticketService;
        }

        [HttpGet]
        public IActionResult NewTicket()
        {
            return View(new TicketViewModel());
        }

        [HttpPost]
        public IActionResult NewTicket(TicketViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var newTicket = new Ticket
                    {
                        Subject = model.Subject,
                        SenderEmail = model.SenderEmail,
                        CreatedTime = DateTime.Now,
                        UpdatedTime = DateTime.Now
                    };

                    var ticketId = _ticketService.AddTicket(newTicket);

                    var newResponse = new Response
                    {
                        TicketId = ticketId,
                        Description = model.Description,
                        CreatedTime = DateTime.Now
                    };

                    _responseService.AddResponse(newResponse);

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An error occurred while creating the ticket and response. Please try again.");
                }
            }

            return View(model);
        }
        public IActionResult ViewTicket(int id)
        {
            var ticket = _ticketService.GetTicketById(id); 

            if (ticket == null)
            {
                return NotFound(); 
            }

            var responses = _responseService.GetResponsesByTicketId(id);

            var model = new TicketViewModel
            {
                TicketId = ticket.TicketId,
                Subject = ticket.Subject,
                SenderEmail = ticket.SenderEmail,
                CreatedTime = ticket.CreatedTime,
                UpdatedTime = ticket.UpdatedTime,
                Responses = responses.Select(r => new ResponseViewModel
                {
                    ResponseId = r.ResponseId,
                    TicketId = r.TicketId,
                    Description = r.Description,
                    CreatedTime = r.CreatedTime
                }).ToList()
            };

            return View(model);
        }
        public IActionResult AddResponse(int ticketId, string description)
        {
            if (ModelState.IsValid)
            {
                var newResponse = new Response
                {
                    TicketId = ticketId,
                    Description = description,
                    CreatedTime = DateTime.Now
                };

                _responseService.AddResponse(newResponse);

                return RedirectToAction("ViewTicket", new { id = ticketId }); 
            }

            return RedirectToAction("ViewTicket", new { id = ticketId });
        }
        public IActionResult DeleteTicket(int ticketId)
        {
            _ticketService.DeleteTicket(ticketId);

            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            var (success, tickets) = _ticketService.GetTicket();

            if (success && tickets != null)
            {
                var ticketViewModels = tickets.Select(t => new TicketViewModel
                {
                    TicketId = t.TicketId,
                    Subject = t.Subject,
                    SenderEmail = t.SenderEmail,
                    CreatedTime = t.CreatedTime,
                    UpdatedTime = t.UpdatedTime
                }).ToList();

                return View(ticketViewModels);  
            }
            else
            {
                return View(new List<TicketViewModel>()); 
            }
        }

    }
}
