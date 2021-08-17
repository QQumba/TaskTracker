using System.Threading.Tasks;
using Application.Services;
using Domain.Entities;

namespace TaskTracker.Web.JwtUtils
{
    public class CurrentUserService : ICurrentUserService
    {
        public Task<User> GetCurrentUserAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}