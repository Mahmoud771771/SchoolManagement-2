using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Department.Queries.Models;
using SchoolProject.Core.Features.Department.Queries.Results;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Abstracts;
using System.Linq.Expressions;

namespace SchoolProject.Core.Features.Department.Queries.Handles
{
    public class DepartmentQueryHandler : ResponseHandler,
        IRequestHandler<GetDepartmentByIdQuery, Response<GetDepartmentByIdResponse>>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly IDepartmentService _departmentService;
        #region Fields

        #endregion
        #region constructors
        public DepartmentQueryHandler(IStringLocalizer<SharedResources> stringLocalizer
           , IMapper mapper, IDepartmentService departmentService
            , IStudentService studentService
            ) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _mapper = mapper;
            _departmentService = departmentService;
            _studentService = studentService;
        }


        #endregion
        #region handle functions
        #endregion
        public async Task<Response<GetDepartmentByIdResponse>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {

                //service get by id include student subject instrctor
                var response = await _departmentService.GetDepartmentById(request.Id);
                // check is not exist
                if (response == null) return NotFound<GetDepartmentByIdResponse>(_stringLocalizer[SharedResourcesKeys.NotFound]);

                //Pagination 
                Expression<Func<Student, StudentResponse>> expression = e => new StudentResponse(e.Id, e.Localize(e.NameAr, e.NameEn));
                var studentQuerable = _studentService.GetStudentsByDepartmentIDQuerable(request.Id);
                var paginatedList = await studentQuerable.Select(expression).ToPaginateListAsync(request.StudentPageNumber, request.StudentPageSize);

                // mapping
                var result = _mapper.Map<GetDepartmentByIdResponse>(response);
                result.StudentList = paginatedList;

                //return response

                return Success(result);

                //ssad int 
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

    }
}
