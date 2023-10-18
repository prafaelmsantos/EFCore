using EFCore.API.Interfaces;
using EFCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public UsersController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var usersList = _repository.GetAll();

            return Ok(usersList);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _repository.GetById(id);
            if (user == null)
                return NotFound("Não encontrado!");

            return Ok(user);
        }

        [HttpPost]
        public IActionResult Add([FromBody] User user)
        {
            _repository.Add(user);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] User user, int id)
        {
            user.Id = id;
            _repository.Update(user);

            return Ok(user);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);

            return Ok();
        }
    }
}
