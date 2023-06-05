using DepartmentSystemWebAPI.DTO;
using DepartmentSystemWebAPI.Entities;
using DepartmentSystemWebAPI.GenericDTO;
using DepartmentSystemWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DepartmentSystemWebAPI.Services
{
    public class LecturerCourseServices : ILecturerCourseServices
    {
        private readonly DBContext _context;

        public LecturerCourseServices(DBContext dBContext)
        {
            _context = dBContext;
        }

        public async Task<IEnumerable<LecturerCourse>> GetAllData()
        {
            return await _context.lecturer_courses.ToListAsync();
        }

        public async Task<ApiResponse<IEnumerable<CourseDTO>>> GetCourseByLecturerId(int id)
        {
            var query =

               (from l in _context.lecturers
                join c in _context.lecturer_courses on l.id equals c.lecturer_id
                join g in _context.courses on c.course_id equals g.id
                select new { l, c, g });


            //query = query.Where(x => x.l.is_deleted == false);



            query = query.Where(x => x.l.id == id);

            try
            {
                var listDto = from x in query
                              select new CourseDTO
                              {
                                  id = x.c.course_id,
                                  name = x.g.name,
                              };
                ApiResponse<IEnumerable<CourseDTO>> apiResponse = new ApiResponse<IEnumerable<CourseDTO>>();
                apiResponse.Data = listDto;
                apiResponse.Status = true;
                apiResponse.Message = "Listed Succesfully";
                return apiResponse;
            }
            catch (Exception e)
            {

                throw;
            }

            return new ApiResponse<IEnumerable<CourseDTO>>();
        }
    }
}
