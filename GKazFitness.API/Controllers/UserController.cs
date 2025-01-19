using GKazFitness.Models;
using Microsoft.AspNetCore.Mvc;
using GKazFitness.Services;

namespace YourAppNamespace.Controllers
{
    [ApiController]
    [Route("GKazFitness/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        /// <summary>
        /// Constructor to inject the UserService dependency.
        /// </summary>
        /// <param name="userService">Service handling user-related operations.</param>
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Get a list of all users.
        /// </summary>
        /// <returns>List of users.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        /// <summary>
        /// Get a user by their ID.
        /// </summary>
        /// <param name="id">ID of the user.</param>
        /// <returns>The user if found, otherwise NotFound.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        /// <summary>
        /// Create a new user.
        /// </summary>
        /// <param name="user">User object to create.</param>
        /// <returns>The created user.</returns>
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdUser = await _userService.CreateUserAsync(user);
            return CreatedAtAction(nameof(GetUserById), new { id = createdUser.UserId }, createdUser);
        }

        /// <summary>
        /// Update an existing user.
        /// </summary>
        /// <param name="id">ID of the user to update.</param>
        /// <param name="user">Updated user data.</param>
        /// <returns>NoContent if successful, otherwise appropriate error.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
        {
            if (id != user.UserId || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _userService.UpdateUserAsync(user);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        /// <summary>
        /// Delete a user by their ID.
        /// </summary>
        /// <param name="id">ID of the user to delete.</param>
        /// <returns>NoContent if successful, otherwise NotFound.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userService.DeleteUserAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
