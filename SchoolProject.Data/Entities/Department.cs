using SchoolProject.Data.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public class Department : GeneralLocalizableEntity
    {
        public Department()
        {
            Students = new HashSet<Student>();
            DepartmentSubjects = new HashSet<DepartmentSubject>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(250)]
        public string? NameAr { get; set; }
        [StringLength(250)]
        public string? NameEn { get; set; }
        public int? InsManager { get; set; }
        [InverseProperty(nameof(Student.Department))]
        public virtual ICollection<Student> Students { get; set; }

        [InverseProperty(nameof(DepartmentSubject.Department))]
        public virtual ICollection<DepartmentSubject> DepartmentSubjects { get; set; }

        [InverseProperty(nameof(Instructor.Department))]
        public virtual ICollection<Instructor> Instructors { get; set; }

        [ForeignKey(nameof(InsManager))]
        [InverseProperty(nameof(Instructor.DepartmentManager))]
        public virtual Instructor? Instructor { get; set; }

    }
}