using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.DataProcessor30ListingData;
using api.Helpers;
using api.Interfaces;
using api.Models;
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

        public async Task<List<DataProcessor30ListingData>> GetAllAsync(QueryObject query)
        {
            var listings =  _context.DataProcessor30ListingDatas.AsQueryable();

            if(!string.IsNullOrWhiteSpace(query.Name)){
                listings = listings.Where(l => l.Name.Contains(query.Name));
            }

            if(!string.IsNullOrWhiteSpace(query.SortBy)){

               
                if(query.SortBy.Equals("Name", StringComparison.OrdinalIgnoreCase)){
                    listings = query.IsDescending ? listings.OrderByDescending(l => l.Name) : listings.OrderBy(l => l.Name);
                }
                else if(query.SortBy.Equals("Creation Time", StringComparison.OrdinalIgnoreCase)){
                listings = query.IsDescending ? listings.OrderByDescending(l => l.CreationTime) : listings.OrderBy(l => l.CreationTime);
                }
                else if(query.SortBy.Equals("Update Time", StringComparison.OrdinalIgnoreCase)){
                listings = query.IsDescending ? listings.OrderByDescending(l => l.UpdateTime) : listings.OrderBy(l => l.UpdateTime);
                }
            }

            var skipNumber = (query.PageNumber - 1)* query.PageSize;


            return await listings.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<DataProcessor30ListingData?> GetByIdAsync(int id)
        {

            return await _context.DataProcessor30ListingDatas.Include(E=> E.DataEdits).Include(S =>S.DataSubProcessors).FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<DataProcessor30ListingData> CreateAsync(DataProcessor30ListingData DataProcessor30ListingDataModel)
        {
            var Data30Listing = await _context.DataProcessor30ListingDatas.AddAsync(DataProcessor30ListingDataModel);



            await _context.SaveChangesAsync();

            return DataProcessor30ListingDataModel;
        }

        public async Task<DataProcessor30ListingData?> UpdateAsync(int id, UpdateDataProcessor30ListingDataDto dataProcessor30ListingDataDto)
        {
            var existing30Listing = await _context.DataProcessor30ListingDatas.FindAsync(id);

            if(existing30Listing == null){
                return null;
            }

            List<string>updatedFields = new List<string>();

            if(existing30Listing.Name != dataProcessor30ListingDataDto.Name) updatedFields.Add("Name");
            if(!existing30Listing.DataController.IsEqual(dataProcessor30ListingDataDto.DataController)) updatedFields.Add("Data Controller");
            if(!existing30Listing.DataProcessor.IsEqual(dataProcessor30ListingDataDto.DataProcessor)) updatedFields.Add("Data processor");
            if(!existing30Listing.DataProcessorRepresentative.IsEqual(dataProcessor30ListingDataDto.DataProcessorRepresentative)) updatedFields.Add("Data Processor Representative");
            if(!existing30Listing.DataSecurityAdvisor.IsEqual(dataProcessor30ListingDataDto.DataSecurityAdvisor)) updatedFields.Add("Data Security Advisor");
            if(!existing30Listing.DataCategories.IsEqual(dataProcessor30ListingDataDto.DataCategories)) updatedFields.Add("Data categories");
            if(!existing30Listing.DataSecurity.IsEqual(dataProcessor30ListingDataDto.DataSecurity)) updatedFields.Add("Data security");
            if(!existing30Listing.DataTransfer.IsEqual(dataProcessor30ListingDataDto.DataTransfer)) updatedFields.Add("Data Transfer");

            _context.Entry(existing30Listing).CurrentValues.SetValues(dataProcessor30ListingDataDto);
            _context.Entry(existing30Listing.DataController).CurrentValues.SetValues(dataProcessor30ListingDataDto.DataController);
            _context.Entry(existing30Listing.DataProcessor).CurrentValues.SetValues(dataProcessor30ListingDataDto.DataProcessor);
            _context.Entry(existing30Listing.DataProcessorRepresentative).CurrentValues.SetValues(dataProcessor30ListingDataDto.DataProcessorRepresentative);
            _context.Entry(existing30Listing.DataSecurityAdvisor).CurrentValues.SetValues(dataProcessor30ListingDataDto.DataSecurityAdvisor);
            _context.Entry(existing30Listing.DataCategories).CurrentValues.SetValues(dataProcessor30ListingDataDto.DataCategories);
            _context.Entry(existing30Listing.DataSecurity).CurrentValues.SetValues(dataProcessor30ListingDataDto.DataSecurity);
            _context.Entry(existing30Listing.DataTransfer).CurrentValues.SetValues(dataProcessor30ListingDataDto.DataTransfer);
            existing30Listing.UpdateTime = DateTime.Now;

            await _context.DataEditDatas.AddAsync(new DataEdit("Listing Updated", String.Join(',', updatedFields), existing30Listing.Id));
            

            updatedFields.Clear();
            await _context.SaveChangesAsync();

            return existing30Listing;

        }

       public async Task<DataProcessor30ListingData?> DeleteAsync(int id)
         {
            var dataProcessor30ListingData = await _context.DataProcessor30ListingDatas
                .Include(e => e.DataEdits)
                .FirstOrDefaultAsync(l => l.Id == id);

            if (dataProcessor30ListingData != null)
            {
                foreach(var dataEdit in dataProcessor30ListingData.DataEdits)
                {
                    _context.DataEditDatas.Remove(dataEdit);
                }
            }


            
            _context.DataProcessor30ListingDatas.Remove(dataProcessor30ListingData);

            // Save changes
            await _context.SaveChangesAsync();

            return dataProcessor30ListingData;
            }


        
    }
}