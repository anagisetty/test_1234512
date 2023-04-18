using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test_1234512.Models;
using test_1234512.Services;

namespace test_1234512.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        private readonly IConfigurationService _configurationService;

        public ConfigurationController(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        // GET: api/Configuration
        [HttpGet]
        public IEnumerable<Configuration> Get()
        {
            return _configurationService.GetConfigurations();
        }

        // GET: api/Configuration/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Configuration> Get(int id)
        {
            Configuration configuration = _configurationService.GetConfigurationById(id);

            if (configuration == null)
            {
                return NotFound();
            }

            return Ok(configuration);
        }

        // POST: api/Configuration
        [HttpPost]
        public ActionResult Post([FromBody] Configuration configuration)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _configurationService.AddConfiguration(configuration);

            return CreatedAtAction("Get", new { id = configuration.Id }, configuration);
        }

        // PUT: api/Configuration/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Configuration configuration)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != configuration.Id)
            {
                return BadRequest();
            }

            _configurationService.UpdateConfiguration(id, configuration);

            return NoContent();
        }

        // DELETE: api/Configuration/5
        [HttpDelete("{id}")]
        public ActionResult<Configuration> Delete(int id)
        {
            Configuration configuration = _configurationService.GetConfigurationById(id);

            if(configuration == null)
            {
                return NotFound();
            }

            _configurationService.DeleteConfiguration(configuration);

            return configuration;
        }
    }
}