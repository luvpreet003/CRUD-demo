namespace CoreDemoCore.Domain
{
    public class Students
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int SchoolID { get; set; }

        public Schools SchoolData { get; set; }

        public Students(CoreDemoModels.Students students)
        {
            StudentId = students.StudentId;
            Name = students.Name;
            Address = students.Address;
            SchoolID = students.SchoolID;
        }

        public static CoreDemoModels.Students MapToCore(Students students)
        {
            return new CoreDemoModels.Students()
            {
                StudentId = students.StudentId,
                Name = students.Name,
                Address = students.Address,
                SchoolID = students.SchoolID,
                School = new CoreDemoModels.Schools()
                {
                    Id = students.SchoolData.Id,
                    Name = students.SchoolData.Name,
                    State = students.SchoolData.State
                }              
            };
        }

        public static List<CoreDemoModels.Students> MapToCoreList(List<Students> students)
        {
            List<CoreDemoModels.Students> studentsList = new();

            foreach(Students student in students)
            {
                studentsList.Add(MapToCore(student));
            }

            return studentsList;
        }

        public Students()
        {

        }
    }
}
