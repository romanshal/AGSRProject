using AGSRProject.Common.Interfaces.Services;
using AGSRProject.Common.Models.BLL;
using AGSRProject.Common.Models.Dto;
using AGSRProject.Common.Models.Entities;
using AGSRProject.Common.Models.Responses;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AGSRProject.Controllers
{
    [Route("agsrproject/v1/patient")]
    [Produces("application/json")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _service;
        private readonly IMapper _mapper;

        public PatientController(IPatientService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet, Route("getpatient")]
        [ProducesResponseType(typeof(Response), 200)]
        [ProducesResponseType(typeof(Response), 400)]
        [ProducesResponseType(typeof(Response), 500)]
        public async Task<IActionResult> GetPatientAsync(string id)
        {
            var patient = await _service.GetAsync(id);
            var result = new ResponseResult<PatientBLL>(_mapper.Map<PatientBLL>(patient), "Ok", false);

            return Ok(result);
        }

        [HttpGet, Route("getallpatients")]
        [ProducesResponseType(typeof(Response), 200)]
        [ProducesResponseType(typeof(Response), 400)]
        [ProducesResponseType(typeof(Response), 500)]
        public async Task<IActionResult> GetAllPatientsAsync()
        {
            var patients = await _service.GetAllAsync();
            var result = new ResponseResult<IEnumerable<PatientBLL>>(_mapper.Map<IEnumerable<PatientBLL>>(patients), "Ok", false);

            return Ok(result);
        }

        [HttpPost, Route("addpatient")]
        [ProducesResponseType(typeof(Response), 200)]
        [ProducesResponseType(typeof(Response), 400)]
        [ProducesResponseType(typeof(Response), 500)]
        public async Task<IActionResult> AddPatientAsync(PatientBLL patient)
        {
            var patientId = await _service.AddAsync(_mapper.Map<PatientDto>(patient));
            var result = new Response(patientId,  false);

            return Ok(result);
        }

        [HttpPost, Route("updatepatient")]
        [ProducesResponseType(typeof(Response), 200)]
        [ProducesResponseType(typeof(Response), 400)]
        [ProducesResponseType(typeof(Response), 500)]
        public async Task<IActionResult> UpdatePatientAsync(PatientBLL patient)
        {
            var patientId = await _service.UpdateAsync(_mapper.Map<PatientDto>(patient));
            var result = new Response(patientId, false);

            return Ok(result);
        }

        [HttpDelete, Route("deletepatient")]
        [ProducesResponseType(typeof(Response), 200)]
        [ProducesResponseType(typeof(Response), 400)]
        [ProducesResponseType(typeof(Response), 500)]
        public async Task<IActionResult> DeletePatientAsync(string id)
        {
            var patientId = await _service.DeleteAsync(id);
            var result = new Response(patientId, false);

            return Ok(result);
        }

        [HttpGet, Route("getpatientsbybirthdate")]
        [ProducesResponseType(typeof(Response), 200)]
        [ProducesResponseType(typeof(Response), 400)]
        [ProducesResponseType(typeof(Response), 500)]
        public async Task<IActionResult> GetPatiensByBirthDayAsync(string birthdate)
        {
            var patients = await _service.GetPatientsByBirthDayAsync(birthdate);
            var result = new ResponseResult<IEnumerable<PatientBLL>>(_mapper.Map<IEnumerable<PatientBLL>>(patients), "Ok", false);

            return Ok(result);
        }
    }
}
