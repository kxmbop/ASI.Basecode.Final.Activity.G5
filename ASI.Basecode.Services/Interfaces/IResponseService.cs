using ASI.Basecode.Data.Models;
using ASI.Basecode.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Services.Interfaces
{
    public interface IResponseService
    {
        (bool, IEnumerable<Response>) GetResponse();
        void AddResponse(Response response);
        void DeleteResponse(Response response); 
        void UpdateResponse(Response response);
        List<Response> GetResponsesByPetId(int petId);

    }
}
