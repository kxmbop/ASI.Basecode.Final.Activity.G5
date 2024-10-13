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
        private readonly ITicketRepository _ticketRepository;

        public ResponseService(ResponseRepository responseRepository, ITicketRepository ticketRepository)
        {
            _responseRepository = responseRepository;
            _ticketRepository = ticketRepository;
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
                throw new ArgumentNullException(nameof(response), "Response cannot be null");
            }

            var newResponse = new Response();
            newResponse.ResponseId = response.ResponseId;
<<<<<<< HEAD
            //newResponse.ResponseId = System.Guid.NewGuid().ToString();
            newResponse.PetId = response.PetId;
=======
            newResponse.TicketId = response.TicketId;
            newResponse.Sender = response.Sender;
>>>>>>> 89387afed3219f92ab731ac777255bde340d1795
            newResponse.Description = response.Description;
            newResponse.Attachment = response.Attachment;
            newResponse.CreatedTime = DateTime.Now;

            _responseRepository.AddResponse(newResponse);

            var ticket = _ticketRepository.GetTicketById(response.TicketId);
            if (ticket == null)
            {
                throw new Exception($"Ticket with ID {response.TicketId} not found.");
            }
            else
            {
                ticket.UpdatedTime = DateTime.Now;
                _ticketRepository.UpdateTicket(ticket);
            }
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
