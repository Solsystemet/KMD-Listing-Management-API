using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{

    [Owned]
    public class DataControllerRepresentative : DataContactInfo
    {
        public string Role { get; set; } = string.Empty;
        public  bool IsEqual(DataControllerRepresentative dataControllerRepresentative){
            if(dataControllerRepresentative.Role != this.Role){
                return false;
            }
            return base.IsEqual(dataControllerRepresentative);            
        }
    }
}