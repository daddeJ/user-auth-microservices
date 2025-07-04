using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserService.Application.Dtos;
using UserService.Application.Intefaces;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        public readonly IUserAppService _userAppService;
        public UsersController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
        {
            var users = await _userAppService.GetAllAsync();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetById(Guid id)
        {
            var user = await _userAppService.GetByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserDto dto)
        {
            var created = await _userAppService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateUserDto dto)
        {
            var updated = await _userAppService.UpdateAsync(id, dto);
            if (Update == null) return NotFound();
            return Ok(updated);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _userAppService.DeleteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
        [HttpGet("{by-email}")]
        public async Task<ActionResult<UserDto>> GetByEmail([FromQuery] string email)
        {
            var user = await _userAppService.GetByEmailAsync(email);
            if (user == null) return NotFound();
            return Ok(user);
        }
    }
}