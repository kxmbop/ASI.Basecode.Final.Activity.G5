﻿using ASI.Basecode.Data.Interfaces;
using ASI.Basecode.Data.Models;
using Basecode.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Data.Repositories
{
    public class ResponseRepository : BaseRepository, IResponseRepository
    {
        //List<Response> _responseList = new();
        private readonly AsiBasecodeDBContext _dbContext;

        public ResponseRepository(AsiBasecodeDBContext dBContext, UnitOfWork unitOfWork) : base(unitOfWork)
        {
            _dbContext = dBContext;
        }
        public IEnumerable<Response> ViewResponses() 
        {
            return _dbContext.Responses.ToList();
        }

        public void AddResponse(Response response)
        {
            _dbContext.Responses.Add(response);
            _dbContext.SaveChanges();
        }

        public void DeleteResponse(Response response)
        {
            _dbContext.Remove(response);
            _dbContext.SaveChanges();
        }

        public void UpdateResponse(Response response)
        {
            var existingResponse = _dbContext.Responses.FirstOrDefault(r => r.ResponseId == response.ResponseId);
            if (existingResponse != null)
            {
                existingResponse.TicketId = response.TicketId;
                existingResponse.Description = response.Description;
                existingResponse.Attachment = response.Attachment;
                _dbContext.Responses.Update(existingResponse);
                _dbContext.SaveChanges();
            }
        }

        public void ViewResponses(Response response)
        {
            throw new NotImplementedException();
        }
    }
}