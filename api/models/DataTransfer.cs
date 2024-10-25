using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.models
{
    [Owned]
    public class DataTransfer
    {
        public string TransferInformation { get; set; } = string.Empty;

    }
}