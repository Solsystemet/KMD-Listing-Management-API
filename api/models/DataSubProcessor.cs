using api.Dtos.DataSubProcessor;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    
    public class DataSubProcessor : DataContactInfo
    {
        public DataSubProcessor (){

        }
        public DataSubProcessor(SubProcessorDto subProcessorDto, DataProcessor30ListingData dataProcessor30ListingData)
        {
            this.CVR = subProcessorDto.CVR;
            
            this.Name = subProcessorDto.Name;

            this.Address = subProcessorDto.Name;

            this.PhoneNo = subProcessorDto.Name;

            this.Mail = subProcessorDto.Mail;

            this.Treatment = subProcessorDto.Treatment;

            this.DirectSubProcessor = subProcessorDto.DirectSubProcessor;

            this.TransferReason = subProcessorDto.TransferReason;

            this.DataProcessor30ListingDataId = dataProcessor30ListingData.Id;
        }
        public int Id { get; set; } // Primary Key
        public string CVR { get; set; } = string.Empty;
        public string Treatment { get; set; } = string.Empty;
        public bool DirectSubProcessor { get; set; } = false;
        public string TransferReason { get; set; } = string.Empty;

        public int? DataProcessor30ListingDataId { get; set; }

        public  bool IsEqualUpdateDto(SubProcessorDto dataSubProcessor){
            if(dataSubProcessor.CVR != this.CVR){
                return false;
            }
             if(dataSubProcessor.Treatment != this.Treatment){
                return false;
            }
            if(dataSubProcessor.DirectSubProcessor != this.DirectSubProcessor){
                return false;
            }
            if(dataSubProcessor.TransferReason != this.TransferReason){
                return false;
            }
            return base.IsEqual(dataSubProcessor);            
        }  

        public DataProcessor30ListingData? DataProcessor30ListingData { get; set; }
    }

}
