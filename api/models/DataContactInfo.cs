using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public abstract class DataContactInfo
    {
        public string Name { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty; 

        public string PhoneNo { get; set;} = string.Empty;

        public string Mail { get; set; } = string.Empty;

        public bool IsEqual(DataContactInfo dataContactInfo){
            if(dataContactInfo.Name != this.Name){
                return false;
            }
            if(dataContactInfo.Address != this.Address){
                return false;
            }
            if(dataContactInfo.PhoneNo != this.PhoneNo){
                return false;
            }
            if(dataContactInfo.Mail != this.Mail){
                return false;
            }
            return true;
        }
    }
}