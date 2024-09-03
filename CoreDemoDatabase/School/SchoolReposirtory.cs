
using CoreDemoCore.Infrastructure;
using CoreDemoModels;
using CoreDemoRepositories.School;

namespace CoreDemoRepositories.SchoolRepository
{
    public class SchoolReposirtory : ISchoolRepository
    {
        readonly ApiDbContext db = new();

        public string AddSchool(CoreDemoCore.Domain.Schools school)
        {
            if (school.Id != 0)
            {
                var existingRecord = db.Schools.FirstOrDefault(x => x.Id == school.Id);
                if(existingRecord == null)
                {
                    var result = SchoolMapper.MapToDB(school);
                    db.Schools.Add(result);
                    db.SaveChanges();
                    return ("Record Added Succesfully!");
                }
                else
                {
                    return ("Record with same ID already exists");
                }
            }
            else
            {
                return ("invalid record");
            }
        }

        public string DeleteSchool(int id)
        {
            var recordToDelete = db.Schools.FirstOrDefault(x => x.Id == id);
            if (recordToDelete != null)
            {
                db.Schools.Remove(recordToDelete);
                db.SaveChanges();
                return ("Record Deleted Successfully!");
            }
            else
            {
                return ("Record Not Found");
            }
        }

        public CoreDemoCore.Domain.Schools GetSchoolById(int id)
        {
            var recordToGet = db.Schools.FirstOrDefault(x => x.Id == id);
            if(recordToGet != null)
            {
                var result = SchoolMapper.MapToCore(recordToGet);
                return result;
            }
            else
            {
                return new CoreDemoCore.Domain.Schools();
            }
        }

        public List<CoreDemoCore.Domain.Schools> GetSchools()
        {
            List<CoreDemoCore.Domain.Schools> coreSchools = new();

            foreach (SchoolsDTO school in db.Schools){
                var result = SchoolMapper.MapToCore(school);
                coreSchools.Add(result);
            }
            return coreSchools;
        }

        public string UpdateSchool(CoreDemoCore.Domain.Schools school)
        {
            var recordToUpdate = db.Schools.FirstOrDefault(x => x.Id == school.Id);
            if (recordToUpdate != null)
            {
                recordToUpdate.Name = school.Name;
                recordToUpdate.State = school.State;
                db.SaveChanges();
                return ("Record updated Succesfully!");
            }
            else
            {
                return ("Record Not Found");
            }
        }
    }
}
