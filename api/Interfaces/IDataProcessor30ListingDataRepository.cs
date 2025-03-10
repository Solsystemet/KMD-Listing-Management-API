using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.DataProcessor30ListingData;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface IDataProcessor30ListingDataRepository
    {
        Task<List<DataProcessor30ListingData>> GetAllAsync(QueryObject query);
        Task<DataProcessor30ListingData?> GetByIdAsync(int id);
        Task<DataProcessor30ListingData> CreateAsync(CreateDataProcessor30ListingDataRequestDto dataProcessor30ListingDataDto);

        Task <DataProcessor30ListingData?> UpdateAsync(int id, UpdateDataProcessor30ListingDataDto dataProcessor30ListingDataDto);

        Task <DataProcessor30ListingData?> DeleteAsync(int id);

    }
}