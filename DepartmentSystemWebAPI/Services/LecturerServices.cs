using DepartmentSystemWebAPI.DTO;
using DepartmentSystemWebAPI.Entities;
using DepartmentSystemWebAPI.GenericDTO;
using DepartmentSystemWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DepartmentSystemWebAPI.Services
{
    public class LecturerServices : ILecturerServices
    {
        private readonly DBContext _context;
        public LecturerServices(DBContext dBContext)
        {
            _context = dBContext;
        }
        //GET
        public async Task<IEnumerable<Lecturer>> GetAllData()
        {
            //return await _context.lecturers.ToListAsync();
            return await _context.lecturers.Where(x => x.is_deleted == false).ToListAsync();
        }
        //GET by Id
        public async Task<Lecturer>GetLecturerById(int id)
        {
            //var lecturer = await _context.lecturers.FindAsync(id);
            var lecturer = await _context.lecturers.Where(x => x.is_deleted == false && x.id == id).FirstOrDefaultAsync();

            if (lecturer == null)
            {
                return new Lecturer();

            }

            return lecturer;
        }

        //GET by Email
        public async Task<ApiResponse<LecturerDTO>> GetLecturerByEmail(string email)
        {
            //var lecturer = await _context.lecturers.FindAsync(id);
            var lecturer = await _context.lecturers.Where(x => x.is_deleted == false && x.email == email).FirstOrDefaultAsync();

            ApiResponse<LecturerDTO> apiResponse = new ApiResponse<LecturerDTO>();

            if (lecturer == null)
            {
                apiResponse.Data = null;
                apiResponse.Status = true;
                apiResponse.Message = "Can't found";
                return apiResponse;
            }

            LecturerDTO dto = new LecturerDTO();
            dto.Id = lecturer.id;
            dto.Name = lecturer.name;
            dto.Surname = lecturer.surname;
            dto.Email = lecturer.email;

            apiResponse.Data = dto;
            apiResponse.Status = true;
            apiResponse.Message = "Listed Succesfully";
            return apiResponse;
        }

        //POST
        public async Task<Lecturer>PostLecturer(Lecturer lecturer)
        {
            _context.lecturers.Add(lecturer);
            await _context.SaveChangesAsync();
            //return CreatedAtAction("GetStudent", new { id = student.id }, student);
            return lecturer;
        }


        //PUT
        public async Task<String> PutLecturer(int id, Lecturer lecturer)
        {
            if (id != lecturer.id)
            {
                return ("bad request");
            }

            _context.Entry(lecturer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LecturerExists(id))
                {
                    return "Not Found";
                }
                else
                {
                    throw;
                }
            }

            return "No Content";
        }

        //DELETE
        public async Task<String> DeleteLecturer(int id)
        {
            var lecturer = await _context.lecturers.FindAsync(id);
            if (lecturer == null)
            {
                return "Not Found";
            }

            //_context.Entry(lecturer).Property(is_deleted) = EntityState.Modified;
            lecturer.is_deleted = true;
            _context.Attach(lecturer).Property(x => x.is_deleted).IsModified = true;
            await _context.SaveChangesAsync();

            return "Deleted succesfully";
        }

        private Lecturer NotFoundResult()
        {
            throw new NotImplementedException();
        }
        private Lecturer OkObjectResult(Lecturer lecturer)
        {
            throw new NotImplementedException();
        }
        private bool LecturerExists(int id)
        {
            return _context.lecturers.Any(e => e.id == id);
        }
    }
}
