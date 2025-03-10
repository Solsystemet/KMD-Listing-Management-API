using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{

    [Owned]
    public class DataProcessorRepresentative : DataContactInfo
    {
        public string Role { get; set; } = string.Empty;
        public  bool IsEqual(DataProcessorRepresentative dataProcessorRepresentative){
            if(dataProcessorRepresentative.Role != this.Role){
                return false;
            }
            return base.IsEqual(dataProcessorRepresentative);            
        }
    }
}