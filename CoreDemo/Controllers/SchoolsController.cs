using CoreDemoModels;
using CoreDemoServices.SchoolServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreDemo.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolsController : ControllerBase
    {
        private readonly ISchoolService _schoolService;
        public SchoolsController(ISchoolService schoolService)
        {
            _schoolService = schoolService;
        }

        // GET: api/<SchoolsController>
        [HttpGet]
        public List<Schools> Get([FromServices] ISchoolService schoolService)
        {
            var result = CoreDemoCore.Domain.Schools.MapCoreToModelList(schoolService.GetSchools());

            return result;
        }

        // GET api/<SchoolsController>/5
        [HttpGet]
        [Route("fetchSchool/{id}")]
        public Schools Get(int id, [FromServices] ISchoolService schoolService)
        {
            var result = CoreDemoCore.Domain.Schools.MapCoreToModel(schoolService.GetSchoolById(id));

            return result;
        }

        // POST api/<SchoolsController>
        [HttpPost]
        public string Post([FromServices] ISchoolService schoolService, [FromBody] Schools school)
        {
            var coreObj = new CoreDemoCore.Domain.Schools(school);
            var result = schoolService.AddSchool(coreObj);
            return result;
        }

        // PUT api/<SchoolsController>/5
        [HttpPut("{id}")]
        public string Put([FromBody] Schools record)
        {
            var coreObj = new CoreDemoCore.Domain.Schools(record);
            var result = _schoolService.UpdateSchool(coreObj);
            return result;
        }

        // DELETE api/<SchoolsController>/5
        [HttpDelete("{id}")]
        public string Delete(int id, [FromServices] ISchoolService schoolService)
        {
            var result = schoolService.DeleteSchool(id);
            return result;
        }
    }
}
