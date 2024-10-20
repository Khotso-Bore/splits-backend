using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using SplitsAPI.BLL.Services.IServices;
using SplitsAPI.Domian.Data;
using SplitsAPI.Domian.Entities;
using SplitsAPI.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace SplitsAPI.BLL.Services
{
    public class UsersService : IUsersService
    {
        private SplitsDbContext _splitsDbContxt;

        public UsersService(SplitsDbContext splitsDbContxt)
        {
            _splitsDbContxt = splitsDbContxt;
        }

        public async Task<User> GetUser(Guid Id)
        {
            return await _splitsDbContxt.Users.FirstOrDefaultAsync(x => x.Id.Equals(Id));
        }

        public async Task<List<User>> GetUsers()
        {
            return await _splitsDbContxt.Users.ToListAsync();
        }

        public async Task<List<User>> GetUserContacts(Guid userId)
        {
            var contacts = await  _splitsDbContxt.Contatcs
                .Where(x => x.UserId.Equals(userId))
                .Include(x => x.UserContact)
                .Select(x => x.UserContact) 
                .ToListAsync();

            return contacts;
        }

        public  async Task<User> AddUser(AddUserDTO addUserDTO)
        {
            var newUser = new User
            {
                UserName = addUserDTO.UserName,
                Number = addUserDTO.Number,
                Id = Guid.NewGuid(),
            };
            await _splitsDbContxt.Users.AddAsync(newUser);
            await _splitsDbContxt.SaveChangesAsync();

            return newUser;
        }

        public async Task AddContact(AddContactDTO addContactDTO)
        {

            var user = await _splitsDbContxt.Users.FirstOrDefaultAsync(x => x.Number.Equals(addContactDTO.AddUser.Number));

            if (user == null)
            {
                user = new User
                {
                    UserName = addContactDTO.AddUser.UserName,
                    Number = addContactDTO.AddUser.Number,
                    Id = Guid.NewGuid(),
                };

                await _splitsDbContxt.Users.AddAsync(user);
            }

            var contact = new Contact
            {
                UserId = addContactDTO.UserId,
                ContactId = user.Id,
            };

            await _splitsDbContxt.Contatcs.AddAsync(contact);
        }
    }
}
