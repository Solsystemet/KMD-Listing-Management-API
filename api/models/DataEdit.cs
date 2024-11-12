using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class DataEdit
    {

        public DataEdit(){
             
        }
    

        public DataEdit(string EditType, string FieldsEdited, int DataProcessor30ListingDataId)
        {
            this.EditType = EditType;
            this.FieldsEdited = FieldsEdited;
            this.DataProcessor30ListingDataId = DataProcessor30ListingDataId;
            this.EditTime = DateTime.Now;
        }
        public int Id { get; set; }

        public string EditType { get; set; } = string.Empty;

        public string Comment { get; set; } = string.Empty;

        public string FieldsEdited { get; set; } = string.Empty;

        public DateTime EditTime {get; set;} = DateTime.Now;
    

        public int? DataProcessor30ListingDataId { get; set; }

        public DataProcessor30ListingData? DataProcessor30ListingData { get; set; }
    }
}