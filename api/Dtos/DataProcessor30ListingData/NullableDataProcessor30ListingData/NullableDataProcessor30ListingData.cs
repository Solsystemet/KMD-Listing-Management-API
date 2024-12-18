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
        public string? Solution { get; set; } = null;

        public NullableDataController DataController { get; set; } = new NullableDataController();
        public NullableDataProcessor DataProcessor { get; set; } = new NullableDataProcessor();
        
        public NullableDataControllerRepresentative DataControllerRepresentative { get; set; } = new NullableDataControllerRepresentative();
        public NullableDataProcessorRepresentative DataProcessorRepresentative { get; set; } = new NullableDataProcessorRepresentative();

        public NullableDataCategories DataCategories { get; set; } = new NullableDataCategories();
        public NullableDataSecurity DataSecurity { get; set; } =  new NullableDataSecurity();

        public List<NullableSubProcessor> DataSubProcessors { get; set; } = new List<NullableSubProcessor>();
    }
}