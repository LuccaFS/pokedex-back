using pokedex_back.Domain.Models.Dtos;

namespace pokedex_back.Domain.Interfaces
{
    public interface IUserRepository
    {
        UserDTO Create(UserRegister newUser, byte[] passwordSalt);
        UserDTO getUser(string email);

    }
}
