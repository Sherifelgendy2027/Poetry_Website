using Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Poetry_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : APIBaseController
    {
        public AuthorController(IUnitOfWork unitOfWork):base(unitOfWork)
        {
            
        }
    }
}
