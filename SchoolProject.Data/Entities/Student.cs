using SchoolProject.Data.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public class Student : GeneralLocalizableEntity
    {
        public Student()
        {
            StudentSubjects = new HashSet<StudentSubject>();
        }
        [Key]
        public int Id { get; set; }

        [StringLength(250)]

        public string? NameAr { get; set; }
        [StringLength(250)]
        public string? NameEn { get; set; }
        [StringLength(250)]
        public string? Address { get; set; }
        [StringLength(250)]
        public string? Phone { get; set; }
        public int? DepartmentId { get; set; }
        [ForeignKey(nameof(DepartmentId))]
        [InverseProperty(nameof(Department.Students))]
        public virtual Department Department { get; set; }
        [InverseProperty(nameof(StudentSubject.Student))]
        public virtual ICollection<StudentSubject> StudentSubjects { get; set; }
    }
}
