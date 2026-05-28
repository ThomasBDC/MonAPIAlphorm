using FluentValidation;
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

        private readonly IValidator<CreateProspectDTO> _createProspectValidator;

        public ProspectsController(IProspectService prospectService, IValidator<CreateProspectDTO> createProspectValidator)
        {
            _prospectService = prospectService;
            _createProspectValidator  = createProspectValidator;
        }

        // GET: api/<ProspectsController>
        [HttpGet]
        public async Task<IEnumerable<ProspectDTO>> Get(int page = 1, int pageSize = 10)
        {
            var maListe = await _prospectService.GetProspects(page, pageSize);

            return maListe.Select(p => p.ToDTO());
        }

        // GET: api/<ProspectsController>/search?q=<marecherche>
        [HttpGet("search")]
        public async Task<IEnumerable<ProspectDTO>> Get(string q)
        {
            var maListe = await _prospectService.SearchProspects(q);

            return maListe.Select(p => p.ToDTO());
        }

        // GET api/<ProspectsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProspectDTO>> Get(int id)
        {
            var prospect = await _prospectService.GetProspect(id);
            if (prospect == null)
            {
                return NotFound();
            }
            else
            {
                var prospectDto = prospect.ToDTO();
                return prospectDto;
            }
        }

        // POST api/<ProspectsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProspectDTO dto)
        {
            var validationResult = await _createProspectValidator.ValidateAsync(dto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

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
        public async Task<IActionResult> Put(int id, EditProspectDTO prospectDTO)
        {
            if(id != prospectDTO.Id)
            {
                return BadRequest();
            }

            var isOk = await _prospectService.EditProspect(prospectDTO.ToEntity());

            if (isOk)
            {
                return NoContent();
            }
            else
            {
                return StatusCode(500, "Une erreur est survenue lors de la modification");
            }
        }

        // DELETE api/<ProspectsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var isOk = await _prospectService.DeleteProspect(id);
            if (isOk)
            {
                return NoContent();
            }
            else
            {
                return StatusCode(500, "Une erreur est survenue lors de la suppression");
            }
        }
    }
}
