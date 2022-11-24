using Dapper;
using Microsoft.Extensions.Configuration;
using pokedex_back.Domain.Models;
using pokedex_back.Domain.Interfaces;

namespace pokedex_back.Infrastructure.Repositories
{
    public class UserRepository : SqlServerRepository, IUserRepository
    {

        public UserRepository(IConfiguration config) : base(config)
        {
        }

        #region 'New User'
        public UserDTO Create(UserRegister newUser, byte[] passwordSalt)
        {
            var user = new UserDTO() {
                DsName = newUser.DsName,
                DsEmail = newUser.DsEmail,
                DsPassword = newUser.DsPassword,
                DsSalt = Convert.ToBase64String(passwordSalt)
            };
            var insert = "INSERT INTO [TRAINER] (DsName, DsEmail, DsPassword, DsSalt) " +
                "OUTPUT INSERTED.IdTrainer " +
                "VALUES (@DsName, @DsEmail, @DsPassword, @DsSalt)"; 
            try
            {
                
                var userId = Database.QuerySingle<int>(insert, user);
                var query = "INSERT INTO [RankMapper] (Trainer, Rank)" +
                    "VALUES (@id, 1)";
                var rank = Database.Execute(query, new { id = userId });
                
                user.IdTrainer = userId;
                user.RankName = "Pokeball";
            }
            catch(Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            return user;
        }
        #endregion

        #region 'Get User'
        public UserDTO getUser(string email)
        {
            var parameters = new { email = email };
            string sql = "SELECT A.*, C.RankName FROM [TRAINER] as A inner join [RANKMAPPER] as B on A.IdTrainer = B.Trainer inner join [Rank] as C on B.Rank = C.Id WHERE DsEmail=@email";

            var user = Database.QuerySingleOrDefault<UserDTO>(sql, parameters);
            return user;
        }
        #endregion

    }
}
