using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Dtos.DataProcessor30ListingData
{
    public class DataProcessor30ListingDataDto
    {
        public int Id {get; set;}
        public string Name { get; set; } = string.Empty;
        public DateTime CreationTime {get; set; }
        public string DataProcessorName { get; set; } = string.Empty;

        

    }
}