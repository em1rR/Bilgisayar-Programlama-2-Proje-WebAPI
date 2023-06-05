using DepartmentSystemWebAPI.DTO;
using DepartmentSystemWebAPI.Entities;
using DepartmentSystemWebAPI.Filters;
using DepartmentSystemWebAPI.GenericDTO;
using Microsoft.AspNetCore.Mvc;

namespace DepartmentSystemWebAPI.Services
{
    public interface IStudentCourseGradeServices
    {
        Task<IEnumerable<StudentCourseGrade>> GetAllData();
        Task<StudentCourseGrade> GetStudentCourseGradeById(int id);
        Task<StudentCourseGrade> PostStudentCourseGrade(StudentCourseGrade studentCourseGrade);
        Task<String> DeleteStudentCourseGrade(int id);
        Task<ApiResponse<IEnumerable<StudentGradeDTO>>> GetStudentsCourseGradeBySearch(StudentFilter studentFilter);
        Task<ApiResponse<EditStudentCourseGradeDTO>> PutStudentCourseGrade(int id, EditStudentCourseGradeDTO editStudentDTO);
    }
}
