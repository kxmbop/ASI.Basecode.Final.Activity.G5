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
using NuGet.Protocol.Plugins;
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
        [HttpGet]
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
                Category = ticket.Category,
                Priority = ticket.Priority,
                Status = ticket.Status,
                CreatedTime = ticket.CreatedTime,
                UpdatedTime = ticket.UpdatedTime,
                Responses = responses.Select(r => new ResponseViewModel
                {
                    ResponseId = r.ResponseId,
                    TicketId = r.TicketId,
                    Sender = r.Sender,
                    Description = r.Description,
                    CreatedTime = r.CreatedTime
                }).ToList()
            };

            return View(model);
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
                        Category = model.Category,
                        Priority = model.Priority,
                        Status = model.Status,
                        CreatedTime = DateTime.Now,
                        UpdatedTime = DateTime.Now
                    };

                    var ticketId = _ticketService.AddTicket(newTicket);

                    var newResponse = new Response
                    {
                        TicketId = ticketId,
                        Sender = model.SenderEmail,
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
        [HttpPost]
        public IActionResult AddResponse(int ticketId, string sender, string description)
        {
            if (ticketId <= 0 || string.IsNullOrWhiteSpace(description))
            {
                TempData["ErrorMessage"] = "Invalid ticket ID or response description.";
                return RedirectToAction("ViewTicket", new { id = ticketId });
            }

            var newResponse = new Response
            {
                TicketId = ticketId,
                Sender = sender,
                Description = description,
                CreatedTime = DateTime.Now
            };

            try
            {
                _responseService.AddResponse(newResponse);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "There was an error adding the response.";
                return RedirectToAction("ViewTicket", new { id = ticketId });
            }

            return RedirectToAction("ViewTicket", new { id = ticketId });
        }

        public IActionResult DeleteTicket(int ticketId)
        {
            _ticketService.DeleteTicket(ticketId);

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult UpdateTicket(TicketViewModel model, string Status)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var ticket = _ticketService.GetTicketById(model.TicketId);

                    if (ticket != null)
                    {
                        ticket.Category = model.Category;
                        ticket.Priority = model.Priority;
                        ticket.Status = Status; 
                        ticket.UpdatedTime = DateTime.Now;

                        _ticketService.UpdateTicket(ticket);

                        var response = new Response
                        {
                            TicketId = model.TicketId,
                            Description = model.Description,
                            Sender = model.Sender,
                            CreatedTime = DateTime.Now
                        };

                        _responseService.AddResponse(response);

                        return RedirectToAction("ViewTicket", new { id = model.TicketId });
                    }
                    else
                    {
                        ModelState.AddModelError("", "Ticket not found.");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An error occurred while updating the ticket.");
                }
            }

            return View(model);
        }
        [HttpGet]
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
                    Category = t.Category,
                    Priority = t.Priority,
                    Status  = t.Status,
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
