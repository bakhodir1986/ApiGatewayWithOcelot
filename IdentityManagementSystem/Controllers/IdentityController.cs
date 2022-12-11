using IdentityManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace IdentityManagementSystem.Controllers
{
    [ApiController]
    [Route("api/identity")]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityRepository repository;

        public IdentityController(IIdentityRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost("user")]
        [Consumes("application/json")]
        public IActionResult PostUser([FromBody] User user)
        {
            if (user == null) return BadRequest();
            repository.AddUser(user);
            return Ok();
        }

        [HttpGet("user")]
        [Consumes("application/json")]
        public IActionResult GetUsers()
        {
            return Ok(repository.GetUsers());
        }

        [HttpPost("role")]
        [Consumes("application/json")]
        public IActionResult PostRole([FromBody] Roles roles)
        {
            if (roles == null) return BadRequest();
            repository.AddRole(roles);
            return Ok();
        }

        [HttpGet("role")]
        [Consumes("application/json")]
        public IActionResult GetRoles()
        {
            return Ok(repository.GetRoles());
        }

        [HttpPost("userrole")]
        [Consumes("application/json")]
        public IActionResult PostUserRole([FromBody] UserRoles roles)
        {
            if (roles == null) return BadRequest();
            repository.AddUserRole(roles);
            return Ok();
        }

        [HttpGet("userrole")]
        [Consumes("application/json")]
        public IActionResult GetUserRoles()
        {
            return Ok(repository.GetUserRoles());
        }

        [HttpPost("rolepermit")]
        [Consumes("application/json")]
        public IActionResult PostRolePermision([FromBody] RolePermissions roles)
        {
            if (roles == null) return BadRequest();
            repository.AddRolePermissions(roles);
            return Ok();
        }

        [HttpGet("rolepermit")]
        [Consumes("application/json")]
        public IActionResult GetRolePermits()
        {
            return Ok(repository.GetRolePermissions());
        }
    }
}
