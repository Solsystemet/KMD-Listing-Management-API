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
