using Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Poetry_Api.DTO;

namespace Poetry_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : APIBaseController
    {
        public AdminController(IUnitOfWork unitOfWork) : base(unitOfWork) 
        {
            
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAdmins()
        {
            var admins =await _unitOfWork.Admins.GetAllAsync();
            List<GetAdminsDTO> showShortData = admins.Select(x => new GetAdminsDTO()
            {
                Email = x.Email,
                Username = x.Username,
            }).ToList();
            return Ok(admins);
        }
        [HttpGet]
        public async Task<IActionResult> GetAdminById(int id)
        {
            var admin = await _unitOfWork.Admins.GetByIdAsync(id);
            if (admin == null)
            {
                return BadRequest("Invalid id");
            }
            var shownAdmin = new GetAdminsDTO() { Email = admin.Email, Username = admin.Username };
            return Ok(shownAdmin);
        }
        [HttpPost]
        public async Task<IActionResult> AddAdmin(AddAdminDTO addAdminDTO)
        {
            if (ModelState.IsValid)
            {
                Admin admin = new Admin()
                {
                    Email = addAdminDTO.Email,
                    Username = addAdminDTO.Username,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(addAdminDTO.Password)
                };
                await _unitOfWork.Admins.AddAsync(admin);
                _unitOfWork.Save();
                return Ok("Add admin success");
            }
            return BadRequest(ModelState.Values.Select(x => x.Errors));
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAdmin(string username)
        {
            var admin = _unitOfWork.Admins.GetAll().FirstOrDefault(x => x.Username == username);
            if (admin is null)
                return NotFound("inValid Username");
            _unitOfWork.Admins.Delete(admin);
            _unitOfWork.Save();
            return Ok("delete admin success");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAdmin(UpdateAdminDTO updateAdminDTO)
        {
            if (ModelState.IsValid)
            {
                var admin = _unitOfWork.Admins.GetAll().FirstOrDefault(x => x.Username == updateAdminDTO.OldUsername);
                if (admin is not null)
                {
                    if (!BCrypt.Net.BCrypt.Verify(updateAdminDTO.OldPassword, admin.PasswordHash))
                        return BadRequest("the old Password incorrect");
                    admin.Username = updateAdminDTO.NewUsername;
                    admin.PasswordHash = BCrypt.Net.BCrypt.HashPassword(updateAdminDTO.Password);
                    _unitOfWork.Admins.Update(admin);
                    _unitOfWork.Save();
                    return Ok("update admin success");
                }
                return BadRequest("Invalid Username");
            }
            return BadRequest(ModelState.Values.Select(x => x.Errors));
        }
        
        //[HttpPost("Login")]
        //public async Task<IActionResult> LoginAndTokenAsync(LoginDTO loginDto)
        //{
        //    Admin admin = await _unitOfWork.Admins.FindAsync(u => u.SSN == loginDto.SSN);
        //    if (admin == null)
        //        return BadRequest("Username or Password is incorrect");
        //    bool isPasswordValid = BCrypt.Net.BCrypt.Verify(loginDto.Password, admin.Password);

        //    if (!isPasswordValid)
        //        return BadRequest("Username or Password is incorrect");
        //    return Ok(new
        //    {
        //        token = jwt.GenerateJSONWebToken(admin),
        //        expiration = DateTime.UtcNow.AddHours(8)
        //    });
        //}
    }
}
