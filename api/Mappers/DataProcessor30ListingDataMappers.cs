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
                DataController = dataProcessor30ListingData.DataController,
                DataProcessorRepresentative = dataProcessor30ListingData.DataProcessorRepresentative
            };
        }

        public static DataProcessor30ListingData ToDataProcessor30ListingDataFromCreateDTO(this CreateDataProcessor30ListingDataRequestDto dataProcessor30ListingDataDto){
            return new DataProcessor30ListingData
            {
                 Name = dataProcessor30ListingDataDto.Name,
                 DataController = dataProcessor30ListingDataDto.DataController,
                 DataProcessor = dataProcessor30ListingDataDto.DataProcessor,
                 DataProcessorRepresentative = dataProcessor30ListingDataDto.DataProcessorRepresentative
            };
        }
    }
}