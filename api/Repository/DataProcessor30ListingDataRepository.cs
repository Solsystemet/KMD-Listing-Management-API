using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.DataProcessor30ListingData;
using api.Interfaces;
using api.models;
using Microsoft.EntityFrameworkCore;
namespace api.Repository
{
    public class DataProcessor30ListingDataRepository : IDataProcessor30ListingDataRepository
    {
        private readonly ApplicationDBContext _context;
        public DataProcessor30ListingDataRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<DataProcessor30ListingData>> GetAllSync()
        {
            return await _context.DataProcessor30ListingDatas.ToListAsync();
        }

        public async Task<DataProcessor30ListingData?> GetByIdAsync(int id)
        {
            return await _context.DataProcessor30ListingDatas.FindAsync(id);
        }

        public async Task<DataProcessor30ListingData> CreateAsync(DataProcessor30ListingData DataProcessor30ListingDataModel)
        {
            await _context.DataProcessor30ListingDatas.AddAsync(DataProcessor30ListingDataModel);
            await _context.SaveChangesAsync();
            return DataProcessor30ListingDataModel;
        }

        public async Task<DataProcessor30ListingData?> UpdateAsync(int id, UpdateDataProcessor30ListingDataDto dataProcessor30ListingDataDto)
        {
            var existing30Listing = await _context.DataProcessor30ListingDatas.FindAsync(id);

            if(existing30Listing == null){
                return null;
            }

            _context.Entry(existing30Listing).CurrentValues.SetValues(dataProcessor30ListingDataDto);
            _context.Entry(existing30Listing.DataController).CurrentValues.SetValues(dataProcessor30ListingDataDto.DataController);
            _context.Entry(existing30Listing.DataProcessor).CurrentValues.SetValues(dataProcessor30ListingDataDto.DataProcessor);
            _context.Entry(existing30Listing.DataProcessorRepresentative).CurrentValues.SetValues(dataProcessor30ListingDataDto.DataProcessorRepresentative);
            _context.Entry(existing30Listing.DataCategories).CurrentValues.SetValues(dataProcessor30ListingDataDto.DataCategories);
            _context.Entry(existing30Listing.DataSecurity).CurrentValues.SetValues(dataProcessor30ListingDataDto.DataSecurity);
            _context.Entry(existing30Listing.DataTransfer).CurrentValues.SetValues(dataProcessor30ListingDataDto.DataTransfer);

            await _context.SaveChangesAsync();

            return existing30Listing;

        }

        public async Task<DataProcessor30ListingData?> DeleteAsync(int id)
        {
            var DataProcessor30ListingDataModel = await _context.DataProcessor30ListingDatas.FindAsync(id);
            if(DataProcessor30ListingDataModel == null){
                return null;
            }
            _context.DataProcessor30ListingDatas.Remove(DataProcessor30ListingDataModel);
            await _context.SaveChangesAsync();
            return DataProcessor30ListingDataModel;
        }
    }
}