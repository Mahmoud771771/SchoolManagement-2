using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrasturcture.Abstracts;
using SchoolProject.Infrasturcture.Data;
using SchoolProject.Infrasturcture.InfrastructureBases;

namespace SchoolProject.Infrasturcture.Repositories
{
    public class InstructorsRepository : GenericRepositoryAsync<Instructor>, IInstructorsRepository
    {
        #region Fields
        private DbSet<Instructor> departments;
        #endregion

        #region constuctors
        public InstructorsRepository(ApplicationDBContext dBContext) : base(dBContext)
        {

            departments = dBContext.Set<Instructor>();
        }

        #endregion
        #region
        #endregion
    }

}
