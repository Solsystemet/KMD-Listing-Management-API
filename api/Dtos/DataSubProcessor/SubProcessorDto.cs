using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Dtos.DataSubProcessor
{
    public class SubProcessorDto
    {
        public string Name { get; set; } = string.Empty;
        public string CVR { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Treatment { get; set; } = string.Empty;
        public bool DirectSubProcessor { get; set; } = false;
        public string TransferReason { get; set; } = string.Empty;
    }
}