using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Infrasturcture.Abstracts;
using SchoolProject.Infrasturcture.InfrastructureBases;
using SchoolProject.Infrasturcture.Repositories;

namespace SchoolProject.Infrasturcture
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IInstructorsRepository, InstructorsRepository>();
            services.AddTransient<ISubjectRepository, SubjectRepository>();
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            return services;
        }

    }
}
