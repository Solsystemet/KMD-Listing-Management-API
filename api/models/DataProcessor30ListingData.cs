using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace api.models
{
    public class DataProcessor30ListingData
    {
       public int Id { get; set; }
    
        public string Name { get; set; } = string.Empty;

        public DateTime CreationTime {get; set; } = DateTime.Now;

       public DataController DataController { get; set; } = new DataController();
        public DataProcessor DataProcessor { get; set; } = new DataProcessor();
        public DataProcessorRepresentative DataProcessorRepresentative { get; set; } = new DataProcessorRepresentative();
    }
}