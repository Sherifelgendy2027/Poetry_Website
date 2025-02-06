using Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Poetry_Api.DTO;

namespace Poetry_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : APIBaseController
    {
        public AuthorController(IUnitOfWork unitOfWork):base(unitOfWork)
        {
            
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAuthors()
        {
            var authors = await _unitOfWork.Authors.GetAllAsync();
            List<GetAuthorsDTO> authorsData = authors.Select(a => new GetAuthorsDTO()
            {
                AuthorId = a.AuthorId,
                Name = a.Name,
                Bio = a.Bio,
                BirthDate = a.BirthDate,
                DeathDate = a.DeathDate
            }).ToList();
            return Ok(authorsData);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorById(int id)
        {
            var author = await _unitOfWork.Authors.GetByIdAsync(id);
            if (author == null)
            {
                return NotFound("Author not found");
            }
            var authorData = new GetAuthorsDTO()
            {
                AuthorId = author.AuthorId,
                Name = author.Name,
                Bio = author.Bio,
                BirthDate = author.BirthDate,
                DeathDate = author.DeathDate
            };
            return Ok(authorData);
        }

        [HttpPost]
        public async Task<IActionResult> AddAuthor(AddAuthorDTO addAuthorDTO)
        {
            if (ModelState.IsValid)
            {
                Author author = new Author()
                {
                    Name = addAuthorDTO.Name,
                    Bio = addAuthorDTO.Bio,
                    BirthDate = addAuthorDTO.BirthDate,
                    DeathDate = addAuthorDTO.DeathDate
                };
                await _unitOfWork.Authors.AddAsync(author);
                _unitOfWork.Save();
                return Ok("Author added successfully");
            }
            return BadRequest(ModelState.Values.Select(x => x.Errors));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var author = await _unitOfWork.Authors.GetByIdAsync(id);
            if (author == null)
                return NotFound("Author not found");
            _unitOfWork.Authors.Delete(author);
            _unitOfWork.Save();
            return Ok("Author deleted successfully");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(int id, UpdateAuthorDTO updateAuthorDTO)
        {
            if (ModelState.IsValid)
            {
                var author = await _unitOfWork.Authors.GetByIdAsync(id);
                if (author != null)
                {
                    author.Name = updateAuthorDTO.Name;
                    author.Bio = updateAuthorDTO.Bio;
                    author.BirthDate = updateAuthorDTO.BirthDate;
                    author.DeathDate = updateAuthorDTO.DeathDate;
                    _unitOfWork.Authors.Update(author);
                    _unitOfWork.Save();
                    return Ok("Author updated successfully");
                }
                return NotFound("Author not found");
            }
            return BadRequest(ModelState.Values.Select(x => x.Errors));
        }
    }
}
