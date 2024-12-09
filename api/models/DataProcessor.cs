using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    [Owned]
    public class DataProcessor : DataContactInfo
    {
        public string CVR { get; set; } = string.Empty;    

         public  bool IsEqual(DataProcessor dataProcessor){
            if(dataProcessor.CVR != this.CVR){
                return false;
            }
            return base.IsEqual(dataProcessor);            
        }  
    }
}