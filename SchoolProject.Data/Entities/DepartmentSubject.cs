using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public class DepartmentSubject
    {
        // [Key]
        //public int DeptSubID { get; set; }
        [Key]
        public int DID { get; set; }
        [Key]
        public int SubID { get; set; }

        [ForeignKey("DID")]
        [InverseProperty(nameof(Department.DepartmentSubjects))]

        public virtual Department? Department { get; set; }

        [ForeignKey("SubID")]
        [InverseProperty(nameof(Subjects.DepartmetsSubjects))]
        public virtual Subjects? Subjects { get; set; }
    }
}