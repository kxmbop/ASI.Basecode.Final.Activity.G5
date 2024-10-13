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
    public class KnowledgeBaseService : IKnowledgeBaseService
    {
        private readonly IKnowledgeBaseRepository _knowledgebaseRepository;

        public KnowledgeBaseService(IKnowledgeBaseRepository knowledgebaseRepository)
        {
            _knowledgebaseRepository = knowledgebaseRepository;
        }

        public (bool, IEnumerable<KnowledgeBase>) GetKnowledgeBase()
        {
            var knowledgebases = _knowledgebaseRepository.ViewKnowledgeBases();
            if (knowledgebases != null)
            {
                return (true, knowledgebases);
            }
            else
            {
                return (false, null);
            }

        }

        public int AddKnowledgeBase(KnowledgeBase knowledgebase)
        {
            if (knowledgebase == null)
            {
                throw new ArgumentNullException(nameof(knowledgebase));
            }

            var newKnowledgeBase = new KnowledgeBase
            {
                Title = knowledgebase.Title,
                Creator = knowledgebase.Creator,
                Content = knowledgebase.Content,
                CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            };

            return _knowledgebaseRepository.AddKnowledgeBase(newKnowledgeBase);
        }

        public void DeleteKnowledgeBase(int knowledgebaseId)
        {
            _knowledgebaseRepository.DeleteKnowledgeBase(knowledgebaseId);
        }

        public void UpdateKnowledgeBase(KnowledgeBase knowledgebase)
        {
            if (knowledgebase == null)
            {
                throw new AccessViolationException();
            }
            _knowledgebaseRepository.UpdateKnowledgeBase(knowledgebase);
        }

        public KnowledgeBase GetKnowledgeBaseById(int id)
        {
            return _knowledgebaseRepository.GetKnowledgeBaseById(id);
        }

    }
}
