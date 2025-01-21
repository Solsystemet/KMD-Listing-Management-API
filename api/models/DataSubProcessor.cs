using api.Dtos.DataSubProcessor;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    
    public class DataSubProcessor
    {
        public DataSubProcessor (){

        }
        public DataSubProcessor(SubProcessorDto subProcessorDto, DataProcessor30ListingData dataProcessor30ListingData)
        {
            this.CVR = subProcessorDto.CVR;
            
            this.Name = subProcessorDto.Name;

            this.Address = subProcessorDto.Address;

            this.Treatment = subProcessorDto.Treatment;

            this.DirectSubProcessor = subProcessorDto.DirectSubProcessor;

            this.TransferReason = subProcessorDto.TransferReason;

            this.ParentCompany = subProcessorDto.ParentCompany;

            this.DataProcessor30ListingDataId = dataProcessor30ListingData.Id;
        }
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string CVR { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Treatment { get; set; } = string.Empty;
        public bool DirectSubProcessor { get; set; } = false;
        public string TransferReason { get; set; } = string.Empty;
        public string ParentCompany  { get; set; } = string.Empty;

        public int? DataProcessor30ListingDataId { get; set; }
        public  bool IsEqualUpdateDto(SubProcessorDto dataSubProcessor){

            if(dataSubProcessor.Name != this.Name){
                return false;
            }
            if(dataSubProcessor.CVR != this.CVR){
                return false;
            }
            if(dataSubProcessor.Address != this.Address){
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
            if(dataSubProcessor.ParentCompany != this.ParentCompany){
                return false;
            }
            return true;
        }  

        public DataProcessor30ListingData? DataProcessor30ListingData { get; set; }
    }

}
