using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.DataSubProcessor
{
    public class CreateDataSubProcessorRequestDto
    {
        public string CVR { get; set; } = String.Empty;
        public string Treatment { get; set; } = String.Empty;
        public bool directSubProcessor { get; set; } = false;
        public string transferReason { get; set; } = String.Empty;
        
    }
}