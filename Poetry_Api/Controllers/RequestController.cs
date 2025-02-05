using Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Poetry_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : APIBaseController
    {
        public RequestController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
