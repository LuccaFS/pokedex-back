using pokedex_back.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokedex_back.Domain.Interfaces
{
    public interface IUserRepository
    {
        UserDTO Create(UserRegister newUser, byte[] passwordSalt);
        UserDTO getUser(string email);

    }
}
