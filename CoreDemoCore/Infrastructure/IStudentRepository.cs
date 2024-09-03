using CoreDemoCore.Domain;

namespace CoreDemoCore.Infrastructure
{
    public interface IStudentRepository
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
