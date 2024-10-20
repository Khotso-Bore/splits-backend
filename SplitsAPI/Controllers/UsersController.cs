using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SplitsAPI.BLL.Services.IServices;
using SplitsAPI.Domian.Entities;
using SplitsAPI.Infrastructure.DTOs;

namespace SplitsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _userService;

        public UsersController(IUsersService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _userService.GetUsers());
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(Guid id)
        {
            return Ok(await _userService.GetUser(id));
        }

        [HttpGet("Contacts/{id}")]
        public async Task<IActionResult> Contacts(Guid id)
        {
            return Ok(await _userService.GetUserContacts(id));

        }

        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserDTO addUserDTO)
        {
            return Ok(await _userService.AddUser(addUserDTO));
        }

        [HttpPost("AddContact")]
        public async Task<IActionResult> AddContact(AddContactDTO addContactDTO)
        {
            await _userService.AddContact(addContactDTO);
            return Ok();
        }

        
        
    }
}
