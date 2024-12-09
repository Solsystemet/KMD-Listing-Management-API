using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.DataProcessor30ListingData.NullableDataProcessor30ListingData
{
    public class NullableDataProcessor : NullableDataContactInfo
    {
        public string? CVR { get; set; } = null;
    }
}