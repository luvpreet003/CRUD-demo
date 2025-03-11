using CoreDemoCore.Commands.StudentServices;
using CoreDemoModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreDemoAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: api/<StudentsController>
        [HttpGet]
        [Authorize(Policy = "AdminOrUser")]
        public List<Students> GetStudents([FromServices] IStudentService studentService)
        {
            var studentData = studentService.GetStudents();
            return CoreDemoCore.Domain.Students.MapToCoreList(studentData);
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,User")] //another way of authorizing
        public Students GetStudentById(int id, [FromServices] IStudentService studentService)
        {
            var result = studentService.GetStudentById(id);
            return CoreDemoCore.Domain.Students.MapToCore(result);
        }

        // POST api/<StudentsController>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public string PostStudent([FromBody] Students student, [FromServices] IStudentService studentService)
        {
            var coreObj = new CoreDemoCore.Domain.Students(student);
            var result = studentService.AddStudent(coreObj);
            return result;
        }

        // PUT api/<StudentsController>/5
        [HttpPut]
        [Authorize(Policy ="AdminOnly")]
        public string PutStudent([FromBody] Students student, [FromServices] IStudentService studentService)
        {
            var coreObj = new CoreDemoCore.Domain.Students(student);
            var result = studentService.UpdateStudent(coreObj);
            return result;
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = "AdminOnly")]
        public string DeleteStudent(int id, [FromServices] IStudentService studentService)
        {
            var result = studentService.DeleteStudent(id);
            return result;
        }
    }
}
