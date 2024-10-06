using ASI.Basecode.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Data.Interfaces
{
    public interface IResponseRepository
    {
        IEnumerable<Response> ViewResponses();
        void ViewResponses(Response response);
        void AddResponse(Response response);
        void DeleteResponse(Response response);
        void UpdateResponse(Response response);
    }
}
