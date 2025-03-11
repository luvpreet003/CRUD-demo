
using CoreDemoCore.Infrastructure;
using CoreDemoModels;
using CoreDemoRepositories.School;

namespace CoreDemoRepositories.SchoolRepository
{
    public class SchoolReposirtory : ISchoolRepository
    {
        private readonly ApiDbContext _db;

        public SchoolReposirtory(ApiDbContext db)
        {
            _db = db;
        }
        public string AddSchool(CoreDemoCore.Domain.Schools school)
        {
            var result = SchoolMapper.MapToDB(school);
            _db.Schools.Add(result);
            _db.SaveChanges();
            return ("Record Added Succesfully!");
        }

        public string DeleteSchool(int id)
        {
            var recordToDelete = _db.Schools.FirstOrDefault(x => x.Id == id);
            if (recordToDelete != null)
            {
                _db.Schools.Remove(recordToDelete);
                _db.SaveChanges();
                return ("Record Deleted Successfully!");
            }
            else
            {
                return ("Record Not Found");
            }
        }

        public CoreDemoCore.Domain.Schools GetSchoolById(int id)
        {
            var recordToGet = _db.Schools.FirstOrDefault(x => x.Id == id);
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

            foreach (SchoolsDTO school in _db.Schools){
                var result = SchoolMapper.MapToCore(school);
                coreSchools.Add(result);
            }
            return coreSchools;
        }

        public string UpdateSchool(CoreDemoCore.Domain.Schools school)
        {
            var recordToUpdate = _db.Schools.FirstOrDefault(x => x.Id == school.Id);
            if (recordToUpdate != null)
            {
                recordToUpdate.Name = school.Name;
                recordToUpdate.State = school.State;
                _db.SaveChanges();
                return ("Record updated Succesfully!");
            }
            else
            {
                return ("Record Not Found");
            }
        }
    }
}
