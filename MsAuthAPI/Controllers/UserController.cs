using Microsoft.AspNetCore.Mvc;
using Aplication.DTOs;
using Aplication.Interfaces;

namespace MsAuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController: ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(
            IUserService userService)
        {
            _userService = userService;
        }


        //[HttpPost]
        //public async Task<ActionResult> Post([FromBody] UserDTO user)
        //{
        //    if (user == null)
        //        return BadRequest("Dados inválidos");

        //    await _userService.GetAll .Add(materialDTO);

        //    return new CreatedAtRouteResult("GetMaterial", new { id = materialDTO.IdMaterial }, materialDTO);
        //}     

        [HttpGet("UsersList", Name = "MaterialById")]
        public async Task<ActionResult<UserDTO>> GetUsersList()
        {
            var usersData = await _userService.GetAll();

            if (usersData  == null)
                return NotFound("user data not found");
            
            return Ok(usersData);
        }

    }
}
