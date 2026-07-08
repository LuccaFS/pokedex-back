using pokedex_back.Domain.Models.Dtos;
using pokedex_back.Domain.Models.InputDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokedex_back.Domain.Interfaces
{
    public interface IUserService
    {
        public void Create(UserRegister user);
        public bool Login(LoginInputDto login, out string msgErr, out string token);
        public User getUser();
    }
}
