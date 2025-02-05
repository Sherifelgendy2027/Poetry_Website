using Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Poetry_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : APIBaseController
    {
        public CategoryController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
