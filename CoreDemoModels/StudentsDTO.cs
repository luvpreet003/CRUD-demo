using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreDemoModels
{
    public class StudentsDTO
    {
        [Key]
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int SchoolID { get; set; }

        [ForeignKey("SchoolID")]
        public virtual SchoolsDTO School { get; set; }
    }
}
