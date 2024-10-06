﻿using ASI.Basecode.Data.Models;
using ASI.Basecode.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Services.Interfaces
{
    public interface ITicketService
    {
        (bool, IEnumerable<Ticket>) GetTicket();
        void AddTicket(Ticket ticket);
        void DeleteTicket(Ticket ticket);
        void UpdateTicket(Ticket ticket);
    }
}