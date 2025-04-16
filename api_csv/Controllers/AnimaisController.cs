using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_csv.database;
using api_csv.database.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_csv.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimaisController : ControllerBase
    {
        private dbContext _dbContext;

        public AnimaisController(dbContext dBContext)
        {
            _dbContext = dBContext;
        }

        [HttpGet]
        public ActionResult<List<Animal>> GetAll()
        {
            return Ok(_dbContext.Animals);
        }
    }
}
