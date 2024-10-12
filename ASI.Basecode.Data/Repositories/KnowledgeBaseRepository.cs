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
    public class KnowledgeBaseRepository : BaseRepository, IKnowledgeBaseRepository
    {
        private readonly AsiBasecodeDBContext _dbContext;

        public KnowledgeBaseRepository(AsiBasecodeDBContext dBContext, UnitOfWork unitOfWork) : base(unitOfWork)
        {
            _dbContext = dBContext;
        }
        public IEnumerable<KnowledgeBase> ViewKnowledgeBases()
        {
            return _dbContext.KnowledgeBases.ToList();
        }

        public int AddKnowledgeBase(KnowledgeBase knowledgebase)
        {
            _dbContext.KnowledgeBases.Add(knowledgebase);
            _dbContext.SaveChanges();
            return knowledgebase.KnowledgeBaseId;
        }

        public void DeleteKnowledgeBase(int knowledgebaseId)
        {
            var knowledgebase = _dbContext.KnowledgeBases.Find(knowledgebaseId);
            if (knowledgebase != null)
            {
                _dbContext.KnowledgeBases.Remove(knowledgebase);
                _dbContext.SaveChanges();
            }
        }

        public void UpdateKnowledgeBase(KnowledgeBase knowledgebase)
        {
            var existingKnowledgeBase = _dbContext.KnowledgeBases.FirstOrDefault(k => k.KnowledgeBaseId == knowledgebase.KnowledgeBaseId);
            if (existingKnowledgeBase != null)
            {
                existingKnowledgeBase.Title = knowledgebase.Title;
                existingKnowledgeBase.Creator = knowledgebase.Creator;
                existingKnowledgeBase.Content = knowledgebase.Content;
                _dbContext.KnowledgeBases.Update(existingKnowledgeBase);
                _dbContext.SaveChanges();
            }
        }

        public void ViewKnowledgeBases(KnowledgeBase knowledgebase)
        {
            throw new NotImplementedException();
        }

        public KnowledgeBase GetKnowledgeBaseById(int id)
        {
            return _dbContext.KnowledgeBases.Find(id);
        }
    }
}
