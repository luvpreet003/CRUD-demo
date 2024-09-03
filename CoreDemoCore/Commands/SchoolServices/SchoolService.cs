using CoreDemoCore.Domain;
using CoreDemoCore.Infrastructure;

namespace CoreDemoServices.SchoolServices
{
    public class SchoolService : ISchoolService
    {
        private readonly ISchoolRepository _schoolRepository;

        public SchoolService(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }

        public string AddSchool(Schools school)
        {
            var result = _schoolRepository.AddSchool(school);
            return result;
        }

        public string DeleteSchool(int id)
        {
            var result = _schoolRepository.DeleteSchool(id);
            return result;
        }

        public Schools GetSchoolById(int id)
        {
            var result = _schoolRepository.GetSchoolById(id);
            return result;
        }

        public List<Schools> GetSchools()
        {
            var result = _schoolRepository.GetSchools();
            return result;
        }

        public string UpdateSchool(Schools school)
        {
            var result = _schoolRepository.UpdateSchool(school);
            return result;
        }
    }
}
