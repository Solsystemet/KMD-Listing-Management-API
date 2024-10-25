using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace api.models
{
    [Owned]
    public class DataProcessor
    {
        public string Name { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty; 

        public long CVR { get; set; }

        public string PhoneNo { get; set;} = string.Empty;

        public string Mail { get; set; } = string.Empty;

        
    }
}