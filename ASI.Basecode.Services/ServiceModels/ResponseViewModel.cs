﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Services.ServiceModels
{
    public class ResponseViewModel
    {
        public int ResponseId { get; set; }
        public int PetId { get; set; }
        public string PetBreed { get; set; }
        public string PetName { get; set; }
        public string Description { get; set; }
        public byte[] Attachment { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
    }
}
