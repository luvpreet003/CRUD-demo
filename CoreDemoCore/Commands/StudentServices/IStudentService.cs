using CoreDemoCore.Domain;

namespace CoreDemoCore.Commands.StudentServices
{
    public interface IStudentService
    {
        // GET
        public List<Students> GetStudents();
        public Students GetStudentById(int id);

        //POST
        public string AddStudent(Students student);

        //PUT
        public string UpdateStudent(Students student);

        //DELETE
        public string DeleteStudent(int id);

    }
}
