using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.DataProcessor30ListingData;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
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

            if(!string.IsNullOrWhiteSpace(query.DataController)){
                listings = listings.Where(l => l.DataController.Name.Contains(query.DataController));
            }

            if(!string.IsNullOrWhiteSpace(query.DataProcessor)){
                listings = listings.Where(l => l.DataProcessor.Name.Contains(query.DataProcessor));
            }

            if (!string.IsNullOrWhiteSpace(query.DataSubProcessor))
            {
            listings = listings.Where(l => l.DataSubProcessors
            .Any(ds => ds.Name.Contains(query.DataSubProcessor)));
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

            return await _context.DataProcessor30ListingDatas.Include(d=> d.DataSubProcessors).Include(e=> e.DataEdits).FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<DataProcessor30ListingData> CreateAsync(CreateDataProcessor30ListingDataRequestDto dataProcessor30ListingDataDto)
        {
            var dataProcessor30ListingEntity = await _context.DataProcessor30ListingDatas.AddAsync(dataProcessor30ListingDataDto.ToDataProcessor30ListingDataFromCreateDTO());
            var dataProcessor30ListingModel = dataProcessor30ListingEntity.Entity;
            await _context.SaveChangesAsync();
            foreach (var dataSubProcessor in dataProcessor30ListingDataDto.DataSubProcessors) {
                await _context.DataSubProcessors.AddAsync(new DataSubProcessor(dataSubProcessor, dataProcessor30ListingModel));
            }
            await _context.SaveChangesAsync();
            return dataProcessor30ListingModel;
        }

        public async Task<DataProcessor30ListingData?> UpdateAsync(int id, UpdateDataProcessor30ListingDataDto dataProcessor30ListingDataDto)
        {
            var existing30Listing = await _context.DataProcessor30ListingDatas.Include(d => d.DataSubProcessors).FirstOrDefaultAsync(l => l.Id == id);

            if(existing30Listing == null){
                return null;
            }

            List<string>updatedFields = new List<string>();

            if(existing30Listing.Name != dataProcessor30ListingDataDto.Name) updatedFields.Add("Name");
            if(!existing30Listing.DataController.IsEqual(dataProcessor30ListingDataDto.DataController)) updatedFields.Add("Data Controller");
            if(!existing30Listing.DataProcessor.IsEqual(dataProcessor30ListingDataDto.DataProcessor)) updatedFields.Add("Data processor");
            if(!existing30Listing.DataProcessorRepresentative.IsEqual(dataProcessor30ListingDataDto.DataProcessorRepresentative)) updatedFields.Add("Data Processor Representative");
            if(!existing30Listing.DataControllerRepresentative.IsEqual(dataProcessor30ListingDataDto.DataControllerRepresentative)) updatedFields.Add("Data Controller Representative");
            if(!existing30Listing.DataSecurityAdvisor.IsEqual(dataProcessor30ListingDataDto.DataSecurityAdvisor)) updatedFields.Add("Data Security Advisor");
            if(!existing30Listing.DataCategories.IsEqual(dataProcessor30ListingDataDto.DataCategories)) updatedFields.Add("Data categories");
            if(!existing30Listing.DataSecurity.IsEqual(dataProcessor30ListingDataDto.DataSecurity)) updatedFields.Add("Data security");
            if(!existing30Listing.DataTransfer.IsEqual(dataProcessor30ListingDataDto.DataTransfer)) updatedFields.Add("Data Transfer");
            
            bool SubProcessorUpdated = false;
            if(existing30Listing.DataSubProcessors.Count == dataProcessor30ListingDataDto.DataSubProcessors.Count){
                
                for(int i = 0; i<existing30Listing.DataSubProcessors.Count; i++){
                    if(!existing30Listing.DataSubProcessors[i].IsEqualUpdateDto(dataProcessor30ListingDataDto.DataSubProcessors[i])){
                        SubProcessorUpdated = true;
                        break;
                    }
                }
            }else{
                SubProcessorUpdated = true;
            }

            if(SubProcessorUpdated){
                updatedFields.Add("Data Sub-Processor");

                foreach(var SubProcessor in existing30Listing.DataSubProcessors){
                    _context.DataSubProcessors.Remove(SubProcessor);
                }
                foreach(var SubProcessor in dataProcessor30ListingDataDto.DataSubProcessors){
                    await _context.DataSubProcessors.AddAsync(new DataSubProcessor(SubProcessor, existing30Listing));
                }
            }

            _context.Entry(existing30Listing).CurrentValues.SetValues(dataProcessor30ListingDataDto);
            _context.Entry(existing30Listing.DataController).CurrentValues.SetValues(dataProcessor30ListingDataDto.DataController);
            _context.Entry(existing30Listing.DataProcessor).CurrentValues.SetValues(dataProcessor30ListingDataDto.DataProcessor);
            _context.Entry(existing30Listing.DataProcessorRepresentative).CurrentValues.SetValues(dataProcessor30ListingDataDto.DataProcessorRepresentative);
            _context.Entry(existing30Listing.DataControllerRepresentative).CurrentValues.SetValues(dataProcessor30ListingDataDto.DataControllerRepresentative);
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
                .Include(d=> d.DataSubProcessors)
                .Include(e => e.DataEdits)
                .FirstOrDefaultAsync(l => l.Id == id);

            if (dataProcessor30ListingData == null)
            {
                return null;
            }

            foreach(var dataEdit in dataProcessor30ListingData.DataEdits)
            {
                _context.DataEditDatas.Remove(dataEdit);
            }
            foreach(var dataSubProcessor in dataProcessor30ListingData.DataSubProcessors)
            {
                _context.DataSubProcessors.Remove(dataSubProcessor);
            }
            
            _context.DataProcessor30ListingDatas.Remove(dataProcessor30ListingData);

            await _context.SaveChangesAsync();

            return dataProcessor30ListingData;
        }
    }
}