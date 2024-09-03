namespace CoreDemoCore.Domain
{
    public class Schools
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string State { get; set; }

        public Schools(CoreDemoModels.Schools modelObj)
        {
            Id = modelObj.Id;
            Name = modelObj.Name;
            State = modelObj.State;
        }

        public static CoreDemoModels.Schools MapCoreToModel (Schools coreObj)
        {
            CoreDemoModels.Schools modelObj = new()
            {
                Id = coreObj.Id,
                Name = coreObj.Name,
                State = coreObj.State
            };

            return modelObj;
        }

        public static List<CoreDemoModels.Schools> MapCoreToModelList(List<Schools> coreObj)
        {
            List<CoreDemoModels.Schools> modelObj = new();
            foreach (Schools school in coreObj)
            {
                modelObj.Add(MapCoreToModel(school));
            }
            return modelObj;
        }

        public Schools()
        {
        }
    }
}
