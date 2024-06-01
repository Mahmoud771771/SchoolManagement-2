using AutoMapper;
using SchoolProject.Core.Features.Department.Queries.Results;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.Departments
{
    public partial class DepartmentProfile : Profile
    {
        public void GetDepartmentByIdMapping()
        {
            CreateMap<Department, GetDepartmentByIdResponse>()
                                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.NameAr, src.NameEn)))
                                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                                .ForMember(dest => dest.ManagerName, opt => opt.MapFrom(src => src.Localize(src.NameAr, src.NameEn)))
                                .ForMember(dest => dest.SubjectList, opt => opt.MapFrom(src => src.DepartmentSubjects))
                                //.ForMember(dest => dest.StudentList, opt => opt.MapFrom(src => src.Students))
                                .ForMember(dest => dest.InstructorList, opt => opt.MapFrom(src => src.Instructors))
                                ;

            CreateMap<DepartmentSubject, SubjectResponse>()
                                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.SubID))
                                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Subjects.Localize(src.Subjects.SubjectNameAr, src.Subjects.SubjectNameEn)));


            //CreateMap<Student, SubjectResponse>()
            //               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            //               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.NameAr, src.NameEn)));

            CreateMap<Instructor, SubjectResponse>()
                           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.InsId))
                           .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.ENameAr, src.ENameEn)));


        }
    }
}
