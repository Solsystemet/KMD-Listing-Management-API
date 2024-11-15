using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    [Owned]
    public class DataSubProcessor : DataContactInfo
    {   
        public int Id { get; set; }
        public string CVR { get; set; } = String.Empty;
        public string Treatment { get; set; } = String.Empty;
        public bool directSubProcessor { get; set; } = false;
        public string transferReason { get; set; } = String.Empty;
        public int? DataProcessor30ListingDataId { get; set; }

        public DataProcessor30ListingData? DataProcessor30ListingData { get; set; }

        public  bool IsEqual(DataSubProcessor dataSubProcessor){
            if(dataSubProcessor.CVR != this.CVR){
                return false;
            } 
            if(dataSubProcessor.Treatment != this.Treatment){
                return false;
            }
            if(dataSubProcessor.directSubProcessor != this.directSubProcessor){
                return false;
            }
            if(dataSubProcessor.transferReason != this.transferReason){
                return false;
            }
            
            return base.IsEqual(dataSubProcessor);            
        }
    }
}
