using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrasturcture.Abstracts;
using SchoolProject.Infrasturcture.Data;
using SchoolProject.Infrasturcture.InfrastructureBases;

namespace SchoolProject.Infrasturcture.Repositories
{
    public class DepartmentRepository : GenericRepositoryAsync<Department>, IDepartmentRepository
    {
        #region Fields
        private DbSet<Department> departments;
        #endregion

        #region constuctors
        public DepartmentRepository(ApplicationDBContext dBContext) : base(dBContext)
        {

            departments = dBContext.Set<Department>();
        }

        public Task<Department> GetDepartmentById(int id)
        {
            throw new NotImplementedException();
        }

        #endregion
        #region
        #endregion
    }
}
