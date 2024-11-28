using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.DataProcessor30ListingData.NullableDataProcessor30ListingData
{
    public class NullableDataContactInfo
    {
        public string? Name { get; set; } = null;

        public string? Address { get; set; } = null; 

        public string? PhoneNo { get; set;} = null;

        public string? Mail { get; set; } = null;
    }
}