using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Students.Commands.Handlers
{
    public class StudentCommandHandler : ResponseHandler,
                                      IRequestHandler<AddStudentCommand, Response<string>>,
                                      IRequestHandler<EditStudentCommand, Response<string>>,
                                      IRequestHandler<DeleteStudentCommand, Response<string>>
    {
        #region Field
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        #endregion

        #region Constructor
        public StudentCommandHandler(IStudentService studentService, IMapper mapper, IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)

        {
            _studentService = studentService;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
        }
        #endregion

        #region Handle Function
        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            //mapping between request and student
            try
            {
                var studentMapper = _mapper.Map<Student>(request);
                // adding
                var result = await _studentService.AddAsync(studentMapper);
                // check Condition
                if (result == "Exist") return UnprocessableEntity<string>("Name is Exist");
                //return response
                else if (result == "Success") return Created("Added SuccessFully");

                else return BadRequest<string>();
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            //Check if the id is exist or not
            var student = await _studentService.GetStudentByIdAsync(request.Id);
            //return not found
            if (student == null) return NotFound<string>("student is not found");
            //mapping between request and student

            var studentMapper = _mapper.Map(request, student);

            var result = await _studentService.EditAsync(studentMapper);
            //return response
            if (result == "Success") return Created($"Edit SuccessFully{studentMapper.Id}");

            else
                return BadRequest<string>();

        }

        public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            //Check if the id is exist or not
            var student = await _studentService.GetStudentByIdAsync(request.Id);
            //return not found
            if (student == null) return NotFound<string>("student is not found");
            //cal service that make delete
            var result = await _studentService.DeleteAsync(student);
            //return response
            if (result == "Success") return Deleted<string>($"Deleted SuccessFully{request.Id}");

            else
                return BadRequest<string>();


        }
        #endregion
    }
}
