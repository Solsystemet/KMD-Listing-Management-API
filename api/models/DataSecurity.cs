using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    [Owned]
    public class DataSecurity
    {
        public string SecurityMeasures { get; set; } = string.Empty;

        public bool IsEqual(DataSecurity dataSecurity){
            return dataSecurity.SecurityMeasures == this.SecurityMeasures;
        }
    }
}