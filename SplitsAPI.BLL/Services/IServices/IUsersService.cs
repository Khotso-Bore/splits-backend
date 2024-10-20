using SplitsAPI.Domian.Entities;
using SplitsAPI.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitsAPI.BLL.Services.IServices
{
    public interface IUsersService
    {
        Task AddContact(AddContactDTO addContactDTO);
        Task<User> AddUser(AddUserDTO addUserDTO);
        Task<User> GetUser(Guid Id);
        Task<List<User>> GetUserContacts(Guid userId);
        Task<List<User>> GetUsers();
    }
}
