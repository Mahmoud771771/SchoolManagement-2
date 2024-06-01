using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Data.Helpers;
using SchoolProject.Infrasturcture.Abstracts;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Service.Implementation
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }


        public async Task<Student> GetStudentByIdAsync(int id)
        {
            //var student = _studentRepository.GetByIdAsync(id)

            var student = _studentRepository.GetTableNoTracking()
                                           .Where(e => e.Id.Equals(id)).FirstOrDefault();
            return student;

        }

        public async Task<List<Student>> GetStudentsListAsync()
        {
            return await _studentRepository.GetStudentsAsync();
        }
        public async Task<string> AddAsync(Student student)
        {
            //check if the name is exist or not


            // Adding Student
            await _studentRepository.AddAsync(student);
            return "Success";
        }

        public async Task<bool> IsNameExist(string name)
        {
            var student = _studentRepository.GetTableNoTracking().Where(e => e.NameAr.Equals(name)).FirstOrDefault();

            if (student == null) return false;
            return true;
        }

        public async Task<bool> IsNameExistExcludeSelf(string name, int id)
        {
            var student = _studentRepository.GetTableNoTracking().Where(e => e.NameAr.Equals(name) && !e.Id.Equals(id)).FirstOrDefault();

            if (student == null) return false;
            return true;
        }

        public async Task<string> EditAsync(Student student)
        {
            await _studentRepository.UpdateAsync(student);
            return "Success";
        }

        public async Task<string> DeleteAsync(Student student)
        {
            var trans = _studentRepository.BeginTransaction();
            try
            {
                await _studentRepository.DeleteAsync(student);
                await trans.CommitAsync();
                return "Success";

            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                return "Falied";


            }
        }

        public async Task<Student> GetStudentByIdWithIncludeAsync(int id)
        {
            var student = _studentRepository.GetTableNoTracking()
                                                .Include(e => e.Department)
                                                .Where(e => e.Id.Equals(id)).FirstOrDefault();
            return student;
        }

        public IQueryable<Student> GetStudentsQuerable()
        {
            return _studentRepository.GetTableNoTracking().Include(e => e.Department).AsQueryable();
        }

        public IQueryable<Student> FilterStudentPaginatedQuerable(StudentOrderingEnum orderingEnum, string search)
        {
            var querable = _studentRepository.GetTableNoTracking().Include(e => e.Department).AsQueryable();
            if (search != null)
            {
                querable = querable.Where(e => e.NameAr.Contains(search) || e.Address.Contains(search));

            }
            switch (orderingEnum)
            {
                case StudentOrderingEnum.Id:
                    querable = querable.OrderBy(e => e.Id);
                    break;
                case StudentOrderingEnum.StudentName:
                    querable = querable.OrderBy(e => e.NameAr);
                    break;
                case StudentOrderingEnum.Address:
                    querable = querable.OrderBy(e => e.Address);
                    break;
                case StudentOrderingEnum.DepartmentName:
                    querable = querable.OrderBy(e => e.Department.NameAr);
                    break;
                default:
                    querable = querable.OrderBy(e => e.Id);
                    break;

            }
            return querable;
        }

        public IQueryable<Student> GetStudentsByDepartmentIDQuerable(int DID)
        {
            return _studentRepository.GetTableNoTracking().Where(e => e.DepartmentId.Equals(DID)).AsQueryable();

        }
    }
}
