using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrasturcture.Abstracts;
using SchoolProject.Infrasturcture.Data;
using SchoolProject.Infrasturcture.InfrastructureBases;

namespace SchoolProject.Infrasturcture.Repositories
{
    public class SubjectRepository : GenericRepositoryAsync<Subjects>, ISubjectRepository
    {
        #region Fields
        private DbSet<Subjects> departments;
        #endregion

        #region constuctors
        public SubjectRepository(ApplicationDBContext dBContext) : base(dBContext)
        {

            departments = dBContext.Set<Subjects>();
        }

        #endregion
        #region
        #endregion
    }
}
