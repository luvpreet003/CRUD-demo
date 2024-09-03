using CoreDemoCore.Domain;
using CoreDemoCore.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CoreDemoRepositories.Student
{
    public class StudentRepository : IStudentRepository
    {
        readonly CoreDemoModels.ApiDbContext db = new();

        public string AddStudent(Students student)
        {
            //check for valid Id
            if(student.StudentId == 0)
            {
                return ("Invalid Student Id!");
            }

            //check for a valid school
            var schoolCheck = db.Schools.AsNoTracking().Any(x => x.Id == student.SchoolID);
            if (schoolCheck)
            {
                var studentCheck = db.Students.AsNoTracking().Any(s => s.StudentId == student.StudentId);
                if (studentCheck)
                {
                    return ("Student with same Id already exists");
                }
                else
                {
                    var result = StudentMapper.MapToDb(student);
                    db.Students.Add(result);
                    db.SaveChanges();
                    return ("Student Added Successfully!");
                }              
            }
            else
            {
                return ("Invalid School Id");
            }
        }

        public string DeleteStudent(int id)
        {
            //fetch the student
            var student = db.Students.FirstOrDefault(x => x.StudentId == id);
            if(student != null)
            {
                db.Students.Remove(student);
                db.SaveChanges();
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
            var student = db.Students.FirstOrDefault(x => x.StudentId == id);
            if(student != null)
            {
                var school = db.Schools.AsNoTracking().FirstOrDefault(s => s.Id == student.SchoolID);
                student.School = school;
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
            var schools = db.Schools.AsNoTracking().ToList();
            foreach(CoreDemoModels.StudentsDTO student in db.Students)
            {
                student.School = schools.FirstOrDefault(x => x?.Id == student?.SchoolID);
                students.Add(StudentMapper.MapToCore(student));
            }
            return students;
        }

        public string UpdateStudent(Students student)
        {
            //fetch the student
            var obj = db.Students.FirstOrDefault(s => s.StudentId == student.StudentId);
            if(obj != null)
            {
                //check for valid school
                var schoolCheck = db.Schools.Any(x => x.Id == student.SchoolID);
                if (schoolCheck)
                {
                    obj.SchoolID = student.SchoolID;
                    obj.Address = student.Address;
                    obj.Name = student.Name;
                    obj.StudentId = student.StudentId;
                    db.Students.Update(obj);
                    db.SaveChanges();
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
