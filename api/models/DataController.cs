using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace api.models
{
    [Owned]
    public class DataController : DataContactInfo
    {
        public long CVR { get; set; }        
        public  bool IsEqual(DataController dataController){
            if(dataController.CVR != this.CVR){
                return false;
            }
            return base.IsEqual(dataController);            
        }
    }
}