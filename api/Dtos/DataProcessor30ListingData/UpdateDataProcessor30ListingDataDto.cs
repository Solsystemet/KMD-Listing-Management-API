using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Dtos.DataProcessor30ListingData
{
    public class UpdateDataProcessor30ListingDataDto
    {
        [Required]
        [MinLength(3,ErrorMessage = "The listing name must be at least 3 characters")]
        [MaxLength(100,ErrorMessage = "The listing name must be less that 100 characters")]
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