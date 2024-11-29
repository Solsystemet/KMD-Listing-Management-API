using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.DataProcessor30ListingData.NullableDataProcessor30ListingData
{
    public class NullableDataControllerRepresentative : NullableDataContactInfo
    {
        public string? Role { get; set; } = null;
    }
}