using AutoMapper;
using SchoolProject.Core.Features.Students.Queries.Results;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.StudentMapping
{
    public partial class StudentProfile : Profile
    {
        public void GetStudentListMapping()
        {
            CreateMap<Student, GetStudentListResponse>()
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Localize(src.NameAr, src.NameEn)))
                .ForMember(dest => dest.StudentName, opt => opt.MapFrom(src => src.Localize(src.NameAr, src.NameEn)));

        }
    }
}
