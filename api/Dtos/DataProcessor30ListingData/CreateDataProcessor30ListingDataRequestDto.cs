using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.models;

namespace api.Dtos.DataProcessor30ListingData
{
    public class CreateDataProcessor30ListingDataRequestDto
    {
        
        public string Name { get; set; } = string.Empty;

        public DataController DataController { get; set; } = new DataController();
        public DataProcessor DataProcessor { get; set; } = new DataProcessor();
        public DataProcessorRepresentative DataProcessorRepresentative { get; set; } = new DataProcessorRepresentative();
    }
}