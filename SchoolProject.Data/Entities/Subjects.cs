using SchoolProject.Data.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public class Subjects : GeneralLocalizableEntity
    {
        public Subjects()
        {
            StudentsSubjects = new HashSet<StudentSubject>();
            DepartmetsSubjects = new HashSet<DepartmentSubject>();
            Ins_Subjects = new HashSet<Ins_Subject>();
        }
        [Key]
        public int SubID { get; set; }
        [StringLength(500)]
        public string? SubjectNameAr { get; set; }
        public string? SubjectNameEn { get; set; }
        public int? Period1 { get; set; }
        [InverseProperty(nameof(StudentSubject.Subject))]
        public virtual ICollection<StudentSubject> StudentsSubjects { get; set; }
        [InverseProperty(nameof(DepartmentSubject.Subjects))]

        public virtual ICollection<DepartmentSubject> DepartmetsSubjects { get; set; }
        [InverseProperty(nameof(Ins_Subject.Subjects))]

        public virtual ICollection<Ins_Subject> Ins_Subjects { get; set; }


    }
}
