using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Simple_API_Assessment.Data.Repository;
using Simple_API_Assessment.Models;

namespace Simple_API_Assessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantRepository _repository;
        public ApplicantController(IApplicantRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("GetAllApplicants")]
        public async Task<ActionResult<List<Applicant>>> GetAllApplicants()
        {
           var applicants = await _repository.GetApplicants();
            return Ok(applicants);
        }

        [HttpGet("GetSingleApplicant/{Id}")]
        public async Task<ActionResult<Applicant>> GetAllApplicants(int Id)
        {
            var applicant = await _repository.GetSingleApplicant(Id);
            if (applicant == null)
            {
                return StatusCode(404, "Applicant not found");
            }
            return Ok(applicant);
        }

        [HttpPut("UpdateApplicant/{Id}")]
        public async Task<ActionResult<Applicant>> EditApplicant(Applicant applicant, int Id)
        {
            if(Id != applicant.Id)
            {
                return BadRequest("Parameter ID and model id did not match");
            }
            var applicant1 = await _repository.EditApplicant(applicant, Id);
            return Ok(applicant1);
        }

        [HttpPost("CreateApplicant")]
        public async Task<ActionResult<Applicant>> CreateApplicant(Applicant applicant)
        {
            await _repository.AddApplicant(applicant);
            return Ok(applicant);
        }

        [HttpDelete("RemoveApplicant/{Id}")]
        public async Task<ActionResult<string>> RemoveApplicant(int Id)
        {
            var message = await _repository.DeleteApplicant(Id);
            if(message == "not found")
            {
                return BadRequest("trying to delete an applicant that doesnt exist.");
            }
            
            return Ok(message);
        }
    }
}
