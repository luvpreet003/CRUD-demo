using CoreDemoModels;

namespace CoreDemoRepositories.School
{
    public class SchoolMapper
    {
        public static SchoolsDTO MapToDB(CoreDemoCore.Domain.Schools coreObj)
        {
            SchoolsDTO dbObj = new()
            {
                Id = coreObj.Id,
                Name = coreObj.Name,
                State = coreObj.State
            };

            return dbObj;
        }

        public static CoreDemoCore.Domain.Schools MapToCore(SchoolsDTO dbObj)
        {
            CoreDemoCore.Domain.Schools coreObj = new()
            {
                Id = dbObj.Id,
                Name = dbObj.Name,
                State = dbObj.State
            };
            return coreObj;
        }
    }
}
