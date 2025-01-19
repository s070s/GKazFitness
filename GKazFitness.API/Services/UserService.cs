using GKazFitness.API.DatabaseClasses;
using GKazFitness.Models;
using Microsoft.EntityFrameworkCore;

namespace GKazFitness.Services
{
    public class UserService
    {
        private readonly AppDbContext _dbContext;

        /// <summary>
        /// Constructor to inject the database context.
        /// </summary>
        /// <param name="dbContext">The application's database context.</param>
        public UserService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Retrieve all users.
        /// </summary>
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }

        /// <summary>
        /// Retrieve a user by ID.
        /// </summary>
        public async Task<User> GetUserByIdAsync(int id)
        {
                return await _dbContext.Users.FindAsync(id);
        }

        /// <summary>
        /// Create a new user.
        /// </summary>
        public async Task<User> CreateUserAsync(User user)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        /// <summary>
        /// Update an existing user.
        /// </summary>
        public async Task<bool> UpdateUserAsync(User user)
        {
            var existingUser = await _dbContext.Users.FindAsync(user.UserId);
            if (existingUser == null)
            {
                return false;
            }

            // Update properties
            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Email = user.Email;
            existingUser.Email = user.Email;
            existingUser.PhoneNumber = user.PhoneNumber;


            await _dbContext.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Delete a user by ID.
        /// </summary>
        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user == null)
            {
                return false;
            }

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
