namespace SchoolProject.Core.Features.Students.Queries.Results
{
    public class GetStudentPaginatedListResponse
    {
        public int Id { get; set; }
        public string? StudentName { get; set; }
        public string? Address { get; set; }
        public string? DepartmentName { get; set; }
        public GetStudentPaginatedListResponse(int id, string? studentName, string? address, string? departmentName)
        {
            Id = id;
            StudentName = studentName;
            Address = address;
            DepartmentName = departmentName;
        }
    }
}
