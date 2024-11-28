using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Dtos.DataProcessor30ListingData.NullableDataProcessor30ListingData
{
    public class NullableDataProcessor30ListingData
    {
        public string? Name { get; set; } = null;

        public NullableDataController DataController { get; set; } = new NullableDataController();
        public NullableDataProcessor DataProcessor { get; set; } = new NullableDataProcessor();
        
        public NullableDataControllerRepresentative DataControllerRepresentative { get; set; } = new NullableDataControllerRepresentative();
        public NullableDataProcessorRepresentative DataProcessorRepresentative { get; set; } = new NullableDataProcessorRepresentative();

        public NullableDataSecurityAdvisor DataSecurityAdvisor { get; set; } = new NullableDataSecurityAdvisor();

        public NullableDataCategories DataCategories { get; set; } = new NullableDataCategories();

        public NullableDataSecurity DataSecurity { get; set; } =  new NullableDataSecurity();

        public NullableDataTransfer DataTransfer { get; set; } = new NullableDataTransfer();

        public List<NullableSubProcessor> DataSubProcessors { get; set; } = new List<NullableSubProcessor>();
    }
}