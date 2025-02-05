using Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Poetry_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VerseController : APIBaseController
    {
        public VerseController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
