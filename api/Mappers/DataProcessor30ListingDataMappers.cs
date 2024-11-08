using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.DataProcessor30ListingData;
using api.models;

namespace api.Mappers
{
    public static class DataProcessor30ListingDataMappers
    {
        public static DataProcessor30ListingDataDto ToDto( this DataProcessor30ListingData dataProcessor30ListingData)
        {
            return new  DataProcessor30ListingDataDto{
                Id = dataProcessor30ListingData.Id,
                Name = dataProcessor30ListingData.Name,
                CreationTime = dataProcessor30ListingData.CreationTime,
                DataProcessorName = dataProcessor30ListingData.DataProcessor.Name,
                DataTransfer = dataProcessor30ListingData.DataTransfer.TransferInformation,

            };
        }

        public static DataProcessor30ListingData ToDataProcessor30ListingDataFromCreateDTO(this CreateDataProcessor30ListingDataRequestDto dataProcessor30ListingDataDto){
            return new DataProcessor30ListingData
            {
                 Name = dataProcessor30ListingDataDto.Name,
                 DataController = dataProcessor30ListingDataDto.DataController,
                 DataProcessor = dataProcessor30ListingDataDto.DataProcessor,
                 DataProcessorRepresentative = dataProcessor30ListingDataDto.DataProcessorRepresentative,
                 DataSecurityAdvisor = dataProcessor30ListingDataDto.DataSecurityAdvisor,
                 DataCategories = dataProcessor30ListingDataDto.DataCategories,
                DataSecurity = dataProcessor30ListingDataDto.DataSecurity,
                DataTransfer = dataProcessor30ListingDataDto.DataTransfer
            };
        }
    }
}