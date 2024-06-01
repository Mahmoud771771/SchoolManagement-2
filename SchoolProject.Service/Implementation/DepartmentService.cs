using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrasturcture.Abstracts;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Service.Implementation
{
    public class DepartmentService : IDepartmentService
    {
        #region fields
        private readonly IDepartmentRepository _departmentRepository;
        #endregion
        #region constructors
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        #endregion
        #region handle functions
        public async Task<Department> GetDepartmentById(int id)
        {
            var department = await _departmentRepository.GetTableNoTracking()
                  .Where(e => e.Id.Equals(id))
                  .Include(e => e.DepartmentSubjects).ThenInclude(x => x.Subjects)
                  // .Include(e => e.Students)
                  .Include(e => e.Instructors).FirstOrDefaultAsync();
            return department;
        }

        public async Task<bool> IsDepartmentExist(int id)
        {
            return await _departmentRepository.GetTableAsTracking().AnyAsync(e => e.Id.Equals(id));
        }

        #endregion
    }
}
