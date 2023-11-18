using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UserBusiness;
using UserDomain;

namespace UserAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        

        private readonly ILogger<UserController> _logger;
        private UBusiness userBusiness = new UBusiness();

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetUser")]

        public User GetUser()
        {
            User user = new User();
            user = userBusiness.getUser();

            return user;
        }

        [HttpGet("GetUsers")]

        public List<User> GetUsers()
        {
            return userBusiness.getUsers();
        }


        [HttpPost("CreateUser")]
        public async Task<ActionResult<User>> PostUser([FromBody] User newUser)
        {
            if (newUser == null)
            {
                return BadRequest("User data is null"); // Manejo de solicitud incorrecta si el usuario es nulo
            }

            try
            {
                Debug.WriteLine("Mensaje de depuración: Información importante aquí.");
                userBusiness.addUser(newUser); // Llamada al método AddUser para agregar el nuevo usuario
                return StatusCode(200, $"all it's ok");

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}"); // Captura de excepciones y devolución de un error interno del servidor con el mensaje de la excepción
            }
        }
        [HttpDelete("DeleteUser")]
        public ActionResult DeleteUser(string username)
        {
            try
            {
                bool userDeleted = userBusiness.deleteUserByUsername(username);

                if (userDeleted)
                {
                    return StatusCode(200, "User deleted successfully");
                }
                else
                {
                    return NotFound($"User with username '{username}' not found");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}