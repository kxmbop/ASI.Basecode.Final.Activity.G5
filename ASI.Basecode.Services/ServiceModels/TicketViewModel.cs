using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Services.ServiceModels
{
    public class TicketViewModel
    {
        public int TicketId { get; set; }
        public string Subject { get; set; }
        public string SenderEmail { get; set; }
        public string Description { get; set; }
        public string Category {  get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }

        public List<ResponseViewModel> Responses { get; set; }
        public string Sender { get; set; }
    }
}
