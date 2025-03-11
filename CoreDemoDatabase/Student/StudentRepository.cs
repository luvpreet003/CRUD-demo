using CoreDemoCore.Domain;
using CoreDemoCore.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CoreDemoRepositories.Student
{
    public class StudentRepository : IStudentRepository
    {
        private readonly CoreDemoModels.ApiDbContext _db;

        public StudentRepository(CoreDemoModels.ApiDbContext db)
        {
            _db = db;
        }

        public string AddStudent(Students student)
        {
            //check for a valid school
            var schoolCheck = _db.Schools.AsNoTracking().Any(x => x.Id == student.SchoolID);
            if (schoolCheck)
            {
                var result = StudentMapper.MapToDb(student);
                _db.Students.Add(result);
                _db.SaveChanges();
                return ("Student Added Successfully!");
            }
            else
            {
                return ("Invalid School Id");
            }
        }

        public string DeleteStudent(int id)
        {
            //fetch the student
            var student = _db.Students.FirstOrDefault(x => x.StudentId == id);
            if(student != null)
            {
                _db.Students.Remove(student);
                _db.SaveChanges();
                return ("Student Deleted Successfully!");
            }
            else
            {
                return ("Student not found!");
            }
        }

        public Students GetStudentById(int id)
        {
            //fetch the student
            var student = _db.Students.Include(x => x.School).FirstOrDefault(x => x.StudentId == id);
            if(student != null)
            {
                //var school = _db.Schools.AsNoTracking().FirstOrDefault(s => s.Id == student.SchoolID);
                //student.School = school;
                return StudentMapper.MapToCore(student);
            }
            else
            {
                return new Students();
            }
        }

        public List<Students> GetStudents()
        {
            var students = new List<Students>();
            var dbStudents = _db.Students.Include(x => x.School).ToList();
            foreach (CoreDemoModels.StudentsDTO student in dbStudents)
            {
                //student.School = schools.FirstOrDefault(x => x.Id == student.SchoolID);
                students.Add(StudentMapper.MapToCore(student));
            }
            return students;
        }

        public string UpdateStudent(Students student)
        {
            //fetch the student
            var obj = _db.Students.FirstOrDefault(s => s.StudentId == student.StudentId);
            if(obj != null)
            {
                //check for valid school
                var schoolCheck = _db.Schools.Any(x => x.Id == student.SchoolID);
                if (schoolCheck)
                {
                    obj.SchoolID = student.SchoolID;
                    obj.Address = student.Address;
                    obj.Name = student.Name;
                    obj.StudentId = student.StudentId;
                    _db.Students.Update(obj);
                    _db.SaveChanges();
                    return ("Student update successfully!");
                }
                else
                {
                    return ("Invalid School Id!");
                }
            }
            else
            {
                return ("Student not found!");
            }
        }
    }
}
