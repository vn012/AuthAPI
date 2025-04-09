using Microsoft.AspNetCore.Mvc;
using Aplication.DTOs;
using Aplication.Interfaces;
using Infra.Contexto;
using System.Net;

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
        #region POST
        //[HttpPost("CadastrarUsuario", Name = "CadastrarUsuario")]
        //public async Task<ActionResult<string>> CadastrarUsuario()
        //{
        //    var res = await _userService.
        //}

        #endregion
        #region GET
        [HttpGet("UsersList", Name = "UserList")]
        public async Task<ActionResult<UserDTO>> GetUsersList()
        {
            var usersData = await _userService.GetAll();

            if (usersData == null)
                return NotFound("user data not found");

            return Ok(usersData);
        }

        [HttpGet("teste", Name = "teste")]
        public async Task<ActionResult<string>> teste()
        {
            try
            {
                string serverIp = null;
                try
                {
                    var host = Dns.GetHostEntry(Dns.GetHostName());
                    serverIp = host.AddressList
                        .FirstOrDefault(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)?
                        .ToString();
                }
                catch (Exception ex)
                {
                    //_logger.LogError(ex, "Erro ao obter o IP do servidor.");
                }

                return Ok(serverIp);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro interno no servidor.");
            }
        }
        #endregion




    }
}
