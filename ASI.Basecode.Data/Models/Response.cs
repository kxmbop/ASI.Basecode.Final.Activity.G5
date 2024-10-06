using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Data.Models
{
    public class Response
    {
        public int ResponseId { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public byte[] Attachment { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
    }
}
