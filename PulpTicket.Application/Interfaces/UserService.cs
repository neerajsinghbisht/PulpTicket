using PulpTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PulpTicket.Application.DTOs;

namespace PulpTicket.Application.Interfaces
{
    public interface IUserServices
    {
        Task<IEnumerable<UserDtos>> GetAllUsersAsync();
        Task<UserDtos> CreateUserAsync(UserDtos userDto);
        Task<UserDtos> GetUserByIdAsync(Guid userId);
        Task UpdateUserAsync(UserDtos userDto);
        Task DeleteUserAsync(Guid userId);
        
       
}
}
