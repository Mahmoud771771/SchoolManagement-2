using SchoolProject.Data.Entities;
using SchoolProject.Infrasturcture.InfrastructureBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrasturcture.Abstracts
{
    public interface IStudentRepository: IGenericRepositoryAsync<Student>
    {
        Task<List<Student>> GetStudentsAsync();
    }
}
