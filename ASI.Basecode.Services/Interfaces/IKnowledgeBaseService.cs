using ASI.Basecode.Data.Models;
using ASI.Basecode.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Services.Interfaces
{
    public interface IKnowledgeBaseService
    {
        (bool, IEnumerable<KnowledgeBase>) GetKnowledgeBase();
        int AddKnowledgeBase(KnowledgeBase knowledgebase);
        void DeleteKnowledgeBase(int knowledgebase);
        void UpdateKnowledgeBase(KnowledgeBase knowledgebase);
        KnowledgeBase GetKnowledgeBaseById(int id);
    }
}
