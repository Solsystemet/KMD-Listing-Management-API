using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public class DataProcessor30ListingData
    {
        public int Id { get; set; }
    
        public string Name { get; set; } = string.Empty;
        
        public string Solution { get; set; } = string.Empty;

        public byte Archived { get; set; } = 0;


        public DateTime CreationTime {get; set; } = DateTime.Now;
        public DateTime UpdateTime {get; set; } = DateTime.Now;

        
        public DataController DataController { get; set; } = new DataController();
        public DataProcessor DataProcessor { get; set; } = new DataProcessor();
        public DataProcessorRepresentative DataProcessorRepresentative { get; set; } = new DataProcessorRepresentative();
        public DataControllerRepresentative DataControllerRepresentative { get; set; } = new DataControllerRepresentative();
        public DataSecurityAdvisor DataSecurityAdvisor { get; set; } = new DataSecurityAdvisor();

        public DataCategories DataCategories { get; set; } = new DataCategories();
        public DataTransfer DataTransfer { get; set; } = new DataTransfer();
        public DataSecurity DataSecurity {get; set; } = new DataSecurity();

        public List<DataEdit> DataEdits { get; set; } = new List<DataEdit>();
        public List<DataSubProcessor> DataSubProcessors { get; set; } = new List<DataSubProcessor>();
        
    }
}