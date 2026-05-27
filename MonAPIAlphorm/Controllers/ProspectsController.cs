using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MonAPIAlphorm.BDD;
using MonAPIAlphorm.DTOs;
using MonAPIAlphorm.Entities;
using MonAPIAlphorm.Services.Prospect;
using MonAPIAlphorm.Utils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MonAPIAlphorm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProspectsController : ControllerBase
    {
        private readonly IProspectService _prospectService;

        public ProspectsController(IProspectService prospectService)
        {
            _prospectService = prospectService;
        }

        // GET: api/<ProspectsController>
        [HttpGet]
        public IEnumerable<ProspectDTO> Get()
        {
            var maListe = _prospectService.GetProspects();

            return maListe.Select(p => p.ToDTO());
        }

        // GET api/<ProspectsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProspectsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProspectDTO dto)
        {
            var isOk = await _prospectService.CreateProspect(dto.ToEntity());

            if (isOk)
            {
                return Created();
            }
            else
            {
                return StatusCode(500, "Une erreur est survenue lors de la création");
            }
        }

        // PUT api/<ProspectsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProspectsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
