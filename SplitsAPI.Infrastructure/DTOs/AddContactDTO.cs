using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitsAPI.Infrastructure.DTOs
{
    public class AddContactDTO
    {
        public AddUserDTO AddUser { get; set; }

        public Guid UserId { get; set; }
    }
}
