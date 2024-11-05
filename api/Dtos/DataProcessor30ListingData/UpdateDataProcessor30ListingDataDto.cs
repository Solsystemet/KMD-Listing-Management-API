using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.models;

namespace api.Dtos.DataProcessor30ListingData
{
    public class UpdateDataProcessor30ListingDataDto
    {
        public string Name { get; set; } = string.Empty;

        public DataController DataController { get; set; } = new DataController();
        public DataProcessor DataProcessor { get; set; } = new DataProcessor();
        public DataProcessorRepresentative DataProcessorRepresentative { get; set; } = new DataProcessorRepresentative();
        public DataSecurityAdvisor DataSecurityAdvisor { get; set; } = new DataSecurityAdvisor();

        public DataCategories DataCategories { get; set; } = new DataCategories();

        public DataSecurity DataSecurity { get; set; } =  new DataSecurity();

        public DataTransfer DataTransfer { get; set; } = new DataTransfer();
    }
}