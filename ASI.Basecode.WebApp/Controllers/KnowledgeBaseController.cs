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
    public class KnowledgeBaseController : ControllerBase<KnowledgeBaseController>
    {
        private readonly IKnowledgeBaseService _knowledgebaseService;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="configuration"></param>
        /// <param name="localizer"></param>
        /// <param name="mapper"></param>
        public KnowledgeBaseController(IKnowledgeBaseService knowledgebaseService,
                                IHttpContextAccessor httpContextAccessor,
                                ILoggerFactory loggerFactory,
                                IConfiguration configuration,
                                IMapper mapper = null) : base(httpContextAccessor, loggerFactory, configuration, mapper)
        {
            _knowledgebaseService = knowledgebaseService;
        }

        [HttpGet]
        public IActionResult NewKnowledgeBase()
        {
            return View(new KnowledgeBaseViewModel());
        }

        [HttpPost]
        public IActionResult NewKnowledgeBase(KnowledgeBaseViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var newKnowledgeBase = new KnowledgeBase
                    {
                        Title = model.Title,
                        Creator = model.Creator,
                        Content = model.Content,
                        CreatedTime = DateTime.Now,
                        UpdatedTime = DateTime.Now
                    };

                    var knowledgebaseId = _knowledgebaseService.AddKnowledgeBase(newKnowledgeBase);

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An error occurred while creating the knowledge base. Please try again.");
                }
            }

            return View(model);
        }
        public IActionResult ViewKnowledgeBase(int id)
        {
            var knowledgebase = _knowledgebaseService.GetKnowledgeBaseById(id);

            if (knowledgebase == null)
            {
                return NotFound();
            }

            var model = new KnowledgeBaseViewModel
            {
                KnowledgeBaseId = knowledgebase.KnowledgeBaseId,
                Title = knowledgebase.Title,
                Creator = knowledgebase.Creator,
                Content = knowledgebase.Content,
                CreatedTime = knowledgebase.CreatedTime,
                UpdatedTime = knowledgebase.UpdatedTime,
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult UpdateKnowledgeBase(int id)
        {
            var knowledgebase = _knowledgebaseService.GetKnowledgeBaseById(id);

            if (knowledgebase == null)
            {
                return NotFound();
            }

            var updateKnowledgeBase = new KnowledgeBase
            {
                KnowledgeBaseId = id,
                Title = knowledgebase.Title,
                Creator = knowledgebase.Creator,
                Content = knowledgebase.Content,
                CreatedTime = knowledgebase.CreatedTime,
                UpdatedTime = knowledgebase.UpdatedTime,
            };

            return View(updateKnowledgeBase);
        }

        [HttpPost]
        public IActionResult UpdateKnowledgeBase(KnowledgeBase knowledgebase)
        {

            _knowledgebaseService.UpdateKnowledgeBase(knowledgebase);

            return RedirectToAction("Index", "KnowledgeBase");
        }

        [HttpPost]

        public IActionResult DeleteKnowledgeBase(int knowledgebaseId)
        {
            _knowledgebaseService.DeleteKnowledgeBase(knowledgebaseId);

            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            var (success, knowledgebases) = _knowledgebaseService.GetKnowledgeBase();

            if (success && knowledgebases != null)
            {
                var knowledgebaseViewModels = knowledgebases.Select(k => new KnowledgeBaseViewModel
                {
                    KnowledgeBaseId = k.KnowledgeBaseId,
                    Title = k.Title,
                    Creator = k.Creator,
                    Content = k.Content,
                    CreatedTime = k.CreatedTime,
                    UpdatedTime = k.UpdatedTime,

                }).ToList();

                return View(knowledgebaseViewModels);
            }
            else
            {
                return View(new List<KnowledgeBaseViewModel>());
            }
        }

    }
}
