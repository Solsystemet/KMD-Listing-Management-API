using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route ("api/file-scraper")]
    [ApiController]
    public class FileScraperController : ControllerBase
    {
        
        [HttpPost]
        public IActionResult ScrapeFile(IFormFile file)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (Path.GetExtension(file.FileName) != ".pdf")
            {
                return BadRequest("File must be a PDF");
            }

            
            return Ok();
        }
    }
}