using CoreDemoCore.Domain;
using CoreDemoCore.Infrastructure;

namespace CoreDemoCore.Commands.StudentServices
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public string AddStudent(Students student)
        {
            return _studentRepository.AddStudent(student);
        }

        public string DeleteStudent(int id)
        {
            return _studentRepository.DeleteStudent(id);
        }

        public Students GetStudentById(int id)
        {
            return _studentRepository.GetStudentById(id);
        }

        public List<Students> GetStudents()
        {
            return _studentRepository.GetStudents();
        }

        public string UpdateStudent(Students student)
        {
            return _studentRepository.UpdateStudent(student);
        }
    }
}
