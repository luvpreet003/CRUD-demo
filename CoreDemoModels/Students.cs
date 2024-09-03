namespace CoreDemoModels
{
    public class Students
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int SchoolID { get; set; }

        public Schools School { get; set; }
    }
}
