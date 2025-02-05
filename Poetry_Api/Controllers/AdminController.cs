using Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            return Ok(admins);
        }
    }
}
