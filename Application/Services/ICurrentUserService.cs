using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Services
{
    public interface ICurrentUserService
    {
        Task<User> GetCurrentUserAsync();
    }
}