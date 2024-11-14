using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public class DataProcessor30ListingData
    {
        //Generic Data
       public int Id { get; set; }
    
        public string Name { get; set; } = string.Empty;

        public DateTime CreationTime {get; set; } = DateTime.Now;
        public DateTime UpdateTime {get; set; } = DateTime.Now;

        // (1) Contact
        public DataController DataController { get; set; } = new DataController();
        public DataProcessor DataProcessor { get; set; } = new DataProcessor();
        public DataProcessorRepresentative DataProcessorRepresentative { get; set; } = new DataProcessorRepresentative();
        public DataSecurityAdvisor DataSecurityAdvisor { get; set; } = new DataSecurityAdvisor();

        public List<DataSubProcessor> DataSubProcessors { get; set; } = new List<DataSubProcessor>();

        // (2) Categories of data
        public DataCategories DataCategories { get; set; } = new DataCategories();

        // (3) International / 3rd Country Transfer
        public DataTransfer DataTransfer { get; set; } = new DataTransfer();

        // (4) Security
        public DataSecurity DataSecurity {get; set; } = new DataSecurity();


        public List<DataEdit> DataEdits { get; set; } = new List<DataEdit>();
        
    }
}