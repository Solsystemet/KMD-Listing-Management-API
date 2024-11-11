using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    [Owned]
    public class DataTransfer
    {
        public string TransferInformation { get; set; } = string.Empty;

    }
}