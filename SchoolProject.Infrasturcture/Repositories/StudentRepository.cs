using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrasturcture.Abstracts;
using SchoolProject.Infrasturcture.Data;
using SchoolProject.Infrasturcture.InfrastructureBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrasturcture.Repositories
{
    public class StudentRepository : GenericRepositoryAsync<Student> ,IStudentRepository
    {
        private readonly DbSet<Student> _students;

        public StudentRepository(ApplicationDBContext context):base(context)
        {
            _students = context.Set<Student>();
        }
        public async Task<List<Student>> GetStudentsAsync()
        {
            return await _students.Include(e=>e.Department).ToListAsync();  
        }
    }
}
