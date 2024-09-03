using System.ComponentModel.DataAnnotations;

namespace CoreDemoModels
{
    public class SchoolsDTO
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
    }
}
