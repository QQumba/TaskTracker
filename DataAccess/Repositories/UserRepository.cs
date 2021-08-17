using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(TaskTrackerDbContext context) : base(context)
        {
        }

        public override async Task<long?> CreateAsync(User user)
        {
            var existingUser = await GetAsync(user.Email);
            if (existingUser is null)
            {
                return await base.CreateAsync(user);
            }

            return null;
        }

        public Task<User> GetAsync(string email)
        {
            return Set.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}