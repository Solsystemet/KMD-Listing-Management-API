using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.DataProcessor30ListingData;
using api.Dtos.DataSubProcessor;
using api.Models;

namespace api.Mappers
{
    public static class DataProcessor30ListingDataMappers
    {
        public static DataProcessor30ListingDataSummeryDto ToDto( this DataProcessor30ListingData dataProcessor30ListingData)
        {
            return new  DataProcessor30ListingDataSummeryDto{
                Id = dataProcessor30ListingData.Id,
                Name = dataProcessor30ListingData.Name,
                CreationTime = dataProcessor30ListingData.CreationTime,
                DataProcessorName = dataProcessor30ListingData.DataProcessor.Name,

            };
        }

        public static DataProcessor30ListingData ToDataProcessor30ListingDataFromCreateDTO(this CreateDataProcessor30ListingDataRequestDto dataProcessor30ListingDataDto){
            return new DataProcessor30ListingData
            {
                Name = dataProcessor30ListingDataDto.Name,
                Solution = dataProcessor30ListingDataDto.Solution,
                DataController = dataProcessor30ListingDataDto.DataController,
                DataProcessor = dataProcessor30ListingDataDto.DataProcessor,
                DataControllerRepresentative = dataProcessor30ListingDataDto.DataControllerRepresentative,
                DataProcessorRepresentative = dataProcessor30ListingDataDto.DataProcessorRepresentative,
                DataCategories = dataProcessor30ListingDataDto.DataCategories,
                DataSecurity = dataProcessor30ListingDataDto.DataSecurity,
            };
        }
    }
}