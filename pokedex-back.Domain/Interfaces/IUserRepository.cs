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
        User Create(UserDto newUser, byte[] passwordSalt);
        User getUser(string email);

    }
}
