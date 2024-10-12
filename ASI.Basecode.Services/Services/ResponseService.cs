using ASI.Basecode.Data.Interfaces;
using ASI.Basecode.Data.Models;
using ASI.Basecode.Data.Repositories;
using ASI.Basecode.Services.Interfaces;
using ASI.Basecode.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Services.Services
{
    public class ResponseService : IResponseService
    {
        private readonly IResponseRepository _responseRepository;

        public ResponseService(ResponseRepository responseRepository)
        {
            _responseRepository = responseRepository;
        }

        public (bool, IEnumerable<Response>) GetResponse()
        {
            var responses =  _responseRepository.ViewResponses();
            if (responses != null)
            { 
                return (true, responses);
            }
            else
            {
                return (false, null);
            }

        }

        public void AddResponse(Response response)
        {
            if (response == null)
            {
                throw new ArgumentException();
            }
            var newResponse = new Response();
            newResponse.ResponseId = response.ResponseId;
            //newResponse.ResponseId = System.Guid.NewGuid().ToString();
            newResponse.PetId = response.PetId;
            newResponse.Description = response.Description;
            newResponse.Attachment = response.Attachment;
            _responseRepository.AddResponse(newResponse);
        }

        public void DeleteResponse(Response response)
        { 
            _responseRepository.DeleteResponse(response);
        }

        public void UpdateResponse(Response response)
        {
            if (response == null)
            { 
                throw new ArgumentException();
            }
            _responseRepository.UpdateResponse(response);
        }

        public List<Response> GetResponsesByTicketId(int ticketId)
        {
            return _responseRepository.GetResponsesByPetId(ticketId);
        }

        public IEnumerable<object> GetResponsesByPetId(int id)
        {
            throw new NotImplementedException();
        }

        List<Response> IResponseService.GetResponsesByPetId(int petId)
        {
            throw new NotImplementedException();
        }
    }
}
