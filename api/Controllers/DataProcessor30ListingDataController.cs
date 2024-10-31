using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.DataProcessor30ListingData;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{

    [Route ("api/DataProcessor30ListingData")]
    [ApiController]
    public class DataProcessor30ListingDataController : ControllerBase
    {

        private readonly ApplicationDBContext _context;
        public DataProcessor30ListingDataController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll(){
            var dataProcessor30ListingDatas = _context.DataProcessor30ListingDatas.ToList();
            return Ok(dataProcessor30ListingDatas);
        }

        [HttpGet("{id}")]

        public IActionResult GetById([FromRoute] int id){
            var dataProcessor30ListingData = _context.DataProcessor30ListingDatas.Find(id);

            if(dataProcessor30ListingData == null){
                return NotFound();
            }

            return Ok(dataProcessor30ListingData);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateDataProcessor30ListingDataRequestDto dataProcessor30ListingDataDto){
            var dataProcessor30ListingDataModel = dataProcessor30ListingDataDto.ToDataProcessor30ListingDataFromCreateDTO();

            _context.DataProcessor30ListingDatas.Add(dataProcessor30ListingDataModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new {id = dataProcessor30ListingDataModel.Id}, dataProcessor30ListingDataModel);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateDataProcessor30ListingDataDto dataProcessor30ListingDataDto){
            var dataProcessor30ListingDataModel = _context.DataProcessor30ListingDatas.Find(id);

            if(dataProcessor30ListingDataModel == null){
                return NotFound();
            }

            // Update the 30 listing data with the dto values and save
            _context.Entry(dataProcessor30ListingDataModel).CurrentValues.SetValues(dataProcessor30ListingDataDto);
            _context.Entry(dataProcessor30ListingDataModel.DataController).CurrentValues.SetValues(dataProcessor30ListingDataDto.DataController);
            _context.Entry(dataProcessor30ListingDataModel.DataProcessor).CurrentValues.SetValues(dataProcessor30ListingDataDto.DataProcessor);
            _context.Entry(dataProcessor30ListingDataModel.DataProcessorRepresentative).CurrentValues.SetValues(dataProcessor30ListingDataDto.DataProcessorRepresentative);
            _context.Entry(dataProcessor30ListingDataModel.DataCategories).CurrentValues.SetValues(dataProcessor30ListingDataDto.DataCategories);
            _context.Entry(dataProcessor30ListingDataModel.DataSecurity).CurrentValues.SetValues(dataProcessor30ListingDataDto.DataSecurity);
            _context.Entry(dataProcessor30ListingDataModel.DataTransfer).CurrentValues.SetValues(dataProcessor30ListingDataDto.DataTransfer);


            _context.SaveChanges();

            return Ok(dataProcessor30ListingDataModel);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var DataProcessor30ListingModel = _context.DataProcessor30ListingDatas.FirstOrDefault(x => x.Id == id);

            if(DataProcessor30ListingModel == null){
                return NotFound();
            }
            _context.Remove(DataProcessor30ListingModel);

            _context.SaveChanges();

            return NoContent();
        }
    }
}
