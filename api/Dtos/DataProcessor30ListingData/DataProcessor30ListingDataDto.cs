using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.models;

namespace api.Dtos.DataProcessor30ListingData
{
    public class DataProcessor30ListingDataDto
    {
        public int Id {get; set;}
        public string Name { get; set; } = string.Empty;

        public DateTime CreationTime {get; set; } = DateTime.Now;

        public DataController DataController { get; set; } = new DataController();
        public DataProcessor DataProcessor { get; set; } = new DataProcessor();
        public DataProcessorRepresentative DataProcessorRepresentative { get; set; } = new DataProcessorRepresentative();
    }
}