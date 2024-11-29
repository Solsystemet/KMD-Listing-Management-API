using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.DataProcessor30ListingData.NullableDataProcessor30ListingData
{
    public class NullableSubProcessor
    {
        public string? Name { get; set; } = null;
        public string? CVR { get; set; } = null;
        public string? Address { get; set; } = null;
        public string? Treatment { get; set; } = null;
        public bool? DirectSubProcessor { get; set; } = null;
        public string? TransferReason { get; set; } = null;
    }
}