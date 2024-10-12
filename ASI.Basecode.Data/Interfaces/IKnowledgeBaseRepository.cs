using ASI.Basecode.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Data.Interfaces
{
    public interface IKnowledgeBaseRepository

    {
        IEnumerable<KnowledgeBase> ViewKnowledgeBases();
        void ViewKnowledgeBases(KnowledgeBase knowledgebase);
        int AddKnowledgeBase(KnowledgeBase knowledgebase);
        void DeleteKnowledgeBase(int knowledgebase);
        void UpdateKnowledgeBase(KnowledgeBase knowledgebase);
        KnowledgeBase GetKnowledgeBaseById(int id);

    }
}
