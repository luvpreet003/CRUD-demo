using CoreDemoCore.Domain;

namespace CoreDemoRepositories.Student
{
    public class StudentMapper
    {
        public static Students MapToCore(CoreDemoModels.StudentsDTO dbObj)
        {
            Students students = new Students()
            {
                SchoolID = dbObj.SchoolID,
                StudentId = dbObj.StudentId,
                Name = dbObj.Name,
                Address = dbObj.Address,
                SchoolData = new Schools()
                {
                    Id = dbObj.School.Id,
                    State = dbObj.School.State,
                    Name = dbObj.School.Name
                }
            };

            return students;
        }

        public static CoreDemoModels.StudentsDTO MapToDb(Students students)
        {
            return new CoreDemoModels.StudentsDTO()
            {
                StudentId = students.StudentId,
                SchoolID = students.SchoolID,
                Name = students.Name,
                Address = students.Address
            };
        }
    }
}
