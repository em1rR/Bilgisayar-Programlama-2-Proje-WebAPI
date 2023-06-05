using DepartmentSystemWebAPI.DTO;
using DepartmentSystemWebAPI.Entities;
using DepartmentSystemWebAPI.Filters;
using DepartmentSystemWebAPI.GenericDTO;
using DepartmentSystemWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DepartmentSystemWebAPI.Services
{
    public class StudentCourseGradeServices : IStudentCourseGradeServices
    {
        private readonly DBContext _context;
        public StudentCourseGradeServices(DBContext context)
        {
            _context = context;
        }
        public Task<string> DeleteStudentCourseGrade(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<StudentCourseGrade>> GetAllData()
        {
            throw new NotImplementedException();
        }

        public Task<StudentCourseGrade> GetStudentCourseGradeById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<StudentCourseGrade> PostStudentCourseGrade(StudentCourseGrade studentCourseGrade)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<IEnumerable<StudentGradeDTO>>> GetStudentsCourseGradeBySearch(StudentFilter studentFilter)
        {
            var query =

              (from s in _context.students
               join d in _context.departments on s.department_id equals d.id
               join g in _context.graduates on s.graduate_id equals g.id
               join c in _context.student_course_grades on s.id equals c.student_id
               join l in _context.courses on c.course_id equals l.id
               select new { s, d, g, c, l });

            query = query.Where(x => x.s.is_deleted == false);

            if (studentFilter.LessonId != 0)
            {
                query = query.Where(x => x.c.course_id == studentFilter.LessonId);
            }
            if (studentFilter.Id != 0)
            {
                query = query.Where(x => x.s.id == studentFilter.Id);
            }
            if (studentFilter.Name != "q")
            {
                query = query.Where(x => x.s.name.Contains(studentFilter.Name));
            }
            if (studentFilter.GraduateId != 0)
            {
                query = query.Where(x => x.s.graduate_id == studentFilter.GraduateId);
            }
            if (studentFilter.DepartmentId != 0)
            {
                query = query.Where(x => x.s.department_id == studentFilter.DepartmentId);
            }
            if (studentFilter.Gender != 0)
            {
                query = query.Where(x => x.s.gender == studentFilter.Gender);
            }
            try
            {
                var listDto = from x in query
                              select new StudentGradeDTO
                              {
                                  Id = x.s.id,
                                  Name = x.s.name,
                                  DepartmentName = x.d.name,
                                  GraduateName = x.g.name,
                                  LessonName = x.l.name,
                                  Gender = ((Enums.Gender)x.s.gender).ToString(),
                                  Vize = x.c.vize,
                                  Final = x.c.final,
                                  But = x.c.but,
                              };
                ApiResponse<IEnumerable<StudentGradeDTO>> apiResponse = new ApiResponse<IEnumerable<StudentGradeDTO>>();
                apiResponse.Data = listDto;
                apiResponse.Status = true;
                apiResponse.Message = "Listed Succesfully";
                return apiResponse;
            }
            catch (Exception)
            {

                throw;
            }


            return new ApiResponse<IEnumerable<StudentGradeDTO>>();
        }

        public async Task<ApiResponse<EditStudentCourseGradeDTO>> PutStudentCourseGrade(int id, EditStudentCourseGradeDTO editStudentDTO)
        {
            ApiResponse<EditStudentCourseGradeDTO> response = new ApiResponse<EditStudentCourseGradeDTO>();

            StudentCourseGrade oldobj = _context.student_course_grades.Where(x => x.student_id == id && x.course_id == editStudentDTO.LessonId).SingleOrDefault();
            if (oldobj != null)
            {
                //oldobj.id = editStudentDTO.Id;
                oldobj.vize = editStudentDTO.Vize;
                oldobj.final = editStudentDTO.Final;
                oldobj.but = editStudentDTO.But;
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    response.Status = false;
                    response.Message = "Something went wrong while saving";
                    response.Data = null;
                }

                response.Status = true;
                response.Message = "Edited Succesfully";
                response.Data = null;

            }
            else
            {
                response.Status = false;
                response.Message = "Not found";
                response.Data = null;
            }

            return response;
        }

    }
}
