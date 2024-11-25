using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.DataProcessor30ListingData;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{

    [Route ("api/data-processor-30-listing-data")]
    [ApiController]
    public class DataProcessor30ListingDataController : ControllerBase
    {
        private readonly IDataProcessor30ListingDataRepository _dataProcessor30ListingDataRepo;
        public DataProcessor30ListingDataController(IDataProcessor30ListingDataRepository dataProcessor30ListingDataRepo)
        {
            _dataProcessor30ListingDataRepo = dataProcessor30ListingDataRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            
            var dataProcessor30ListingDatas = await _dataProcessor30ListingDataRepo.GetAllAsync(query);
            var dataProcessor30ListingDataDtos = dataProcessor30ListingDatas.Select(l => l.ToDto());
            
            return Ok(dataProcessor30ListingDataDtos);
        }
        [HttpGet("{id:int}")]

        public async Task<IActionResult> GetById([FromRoute] int id){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var dataProcessor30ListingData = await _dataProcessor30ListingDataRepo.GetByIdAsync(id);

            if(dataProcessor30ListingData == null){
                return NotFound();
            }

            return Ok(dataProcessor30ListingData);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDataProcessor30ListingDataRequestDto dataProcessor30ListingDataDto){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var dataProcessor30ListingDataModel = dataProcessor30ListingDataDto.ToDataProcessor30ListingDataFromCreateDTO();
            await _dataProcessor30ListingDataRepo.CreateAsync(dataProcessor30ListingDataModel);
            return CreatedAtAction(nameof(GetById), new {id = dataProcessor30ListingDataModel.Id}, dataProcessor30ListingDataModel);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateDataProcessor30ListingDataDto dataProcessor30ListingDataDto){
             if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var dataProcessor30ListingDataModel = await _dataProcessor30ListingDataRepo.UpdateAsync(id, dataProcessor30ListingDataDto);

            if(dataProcessor30ListingDataModel == null){
                return NotFound();
            }


            return Ok(dataProcessor30ListingDataModel);
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var DataProcessor30ListingModel = await _dataProcessor30ListingDataRepo.DeleteAsync(id);

            if(DataProcessor30ListingModel == null){
                return NotFound();
            }
            
            return NoContent();
        }
    }
}
