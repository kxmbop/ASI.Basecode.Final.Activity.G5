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

        public List<ResponseViewModel> GetResponse()
        {

            var data = _responseRepository.GetResponse().Select(s => new ResponseViewModel
            {
                ResponseId = s.ResponseId,
                Email = s.Email,
                Description = s.Description,
                Attachment = s.Attachment,
                CreatedTime = s.CreatedTime,
                UpdatedTime = s.UpdatedTime,

            }).ToList();
            return data;
        }

    }
}
