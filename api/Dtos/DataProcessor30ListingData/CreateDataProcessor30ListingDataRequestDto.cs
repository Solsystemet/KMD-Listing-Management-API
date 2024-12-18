using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.DataSubProcessor;
using api.Models;

namespace api.Dtos.DataProcessor30ListingData
{
    public class CreateDataProcessor30ListingDataRequestDto
    {
        public string Name { get; set; } = string.Empty;

        public string Solution { get; set; } = string.Empty;
        public DataController DataController { get; set; } = new DataController();
        public DataProcessor DataProcessor { get; set; } = new DataProcessor();
        
        public DataControllerRepresentative DataControllerRepresentative { get; set; } = new DataControllerRepresentative();
        public DataProcessorRepresentative DataProcessorRepresentative { get; set; } = new DataProcessorRepresentative();

        public DataCategories DataCategories { get; set; } = new DataCategories();
        public DataSecurity DataSecurity { get; set; } =  new DataSecurity();

        public List<SubProcessorDto> DataSubProcessors { get; set; } = new List<SubProcessorDto>();
    }
}