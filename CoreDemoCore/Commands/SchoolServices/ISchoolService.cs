
using CoreDemoCore.Domain;

namespace CoreDemoServices.SchoolServices
{
    public interface ISchoolService
    {
        // GET
        public List<Schools> GetSchools();
        public Schools GetSchoolById(int id);

        //POST
        public string AddSchool(Schools school);

        //PUT
        public string UpdateSchool(Schools school);

        //DELETE
        public string DeleteSchool(int id);

    }
}
