using DepartmentSystemWebAPI.DTO;
using DepartmentSystemWebAPI.Entities;
using DepartmentSystemWebAPI.GenericDTO;
using Microsoft.AspNetCore.Mvc;

namespace DepartmentSystemWebAPI.Services
{
    public interface ILecturerCourseServices
    {
        Task<IEnumerable<LecturerCourse>> GetAllData();
        Task<ApiResponse<IEnumerable<CourseDTO>>> GetCourseByLecturerId(int id);
    }
}
