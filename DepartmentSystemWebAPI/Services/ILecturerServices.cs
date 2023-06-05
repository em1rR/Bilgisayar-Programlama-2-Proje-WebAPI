using DepartmentSystemWebAPI.DTO;
using DepartmentSystemWebAPI.Entities;
using DepartmentSystemWebAPI.GenericDTO;
using Microsoft.AspNetCore.Mvc;

namespace DepartmentSystemWebAPI.Services
{
    public interface ILecturerServices
    {
        Task<IEnumerable<Lecturer>> GetAllData();
        Task<Lecturer> GetLecturerById(int id);
        Task<ApiResponse<LecturerDTO>> GetLecturerByEmail(string email);
        Task<Lecturer> PostLecturer(Lecturer lecturer);
        Task<String> PutLecturer(int id, Lecturer lecturer);
        Task<String> DeleteLecturer(int id);
    }
}
