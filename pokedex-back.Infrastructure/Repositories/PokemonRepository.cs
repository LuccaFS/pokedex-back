using Microsoft.Extensions.Configuration;
using pokedex_back.Domain.Interfaces;
using pokedex_back.Domain.Models;
using Dapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace pokedex_back.Infrastructure.Repositories
{
    public class PokemonRepository : SqlServerRepository, IPokemonRepository
    {
        public PokemonRepository(IConfiguration config) : base(config)
        {
        }

        #region ' Pokedex '
        public void SavePokemon(PokemonDTO pokemon)
        {
            var insert = "INSERT INTO [POKEMON] (IdPokemon, DsName, Type1, Type2, Image, Generation, isStarter, isPseudo, isLegendary)" +
               "VALUES (@IdPokemon, @DsName, @Type1, @Type2, @Image, @Generation, @isStarter, @isPseudo, @isLegendary)";
            try
            {

                Database.Execute(insert, pokemon);
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
        }

        public List<Pokemon> GetAll()
        {
            List<Pokemon> pokemons = new List<Pokemon>();
            var query = "Select A.IdPokemon, A.DsName, B.TypeName as 'Type1', C.TypeName as 'Type2', A.Image, A.Generation, A.isStarter, a.isPseudo, A.isLegendary " +
                "from [POKEMON] as A inner join [TYPE] as B on A.Type1 = B.IdType LEFT OUTER JOIN [TYPE] as C on A.Type2 = C.IdType";
            try
            {
                pokemons = Database.Query<Pokemon>(query).ToList();
                
            }
            catch( Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            return pokemons;

        }

        public Pokemon GetByName(string PokeName)
        {
            Pokemon pokemon = new Pokemon();
            var select = new { name = PokeName };
            var query = "Select A.IdPokemon, A.DsName, B.TypeName as 'Type1', C.TypeName as 'Type2', A.Image, A.Generation, A.isStarter, a.isPseudo, A.isLegendary " +
                "from [POKEMON] as A inner join [TYPE] as B on A.Type1 = B.IdType LEFT OUTER JOIN [TYPE] as C on A.Type2 = C.IdType WHERE A.DsName = @name";
            try
            {
                pokemon = Database.QueryFirstOrDefault<Pokemon>(query, select);
                if (pokemon == null)
                {
                    throw new ApplicationException("Pokemon not found.");
                }

            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            return pokemon;

        }

        public Pokemon GetById(string PokeId)
        {
            Pokemon pokemon = new Pokemon();
            var select = new { id = PokeId };
            var query = "Select A.IdPokemon, A.DsName, B.TypeName as 'Type1', C.TypeName as 'Type2', A.Image, A.Generation, A.isStarter, a.isPseudo, A.isLegendary " +
                "from [POKEMON] as A inner join [TYPE] as B on A.Type1 = B.IdType LEFT OUTER JOIN [TYPE] as C on A.Type2 = C.IdType WHERE A.IdPokemon = @id";
            try
            {
                pokemon = Database.QueryFirstOrDefault<Pokemon>(query, select);
                if (pokemon == null)
                {
                    throw new ApplicationException("Pokemon not found.");
                }

            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            return pokemon;

        }
        #endregion


        #region ' Shiny Hunt '
        public void SaveShinyHunt(ShinyHunt Hunt)
        {
            var exists = this.GetShinyHunt(Hunt.IdTrainer, Hunt.PokeName);
            if (exists!=null) {
                this.UpdateShinyHunt(Hunt);
                return;
            }
            var insert = "INSERT INTO [ShinyHunt] (IdTrainer, PokeName, Counter)" +
              "VALUES (@IdTrainer, @PokeName, @Counter)";
            try
            {

                Database.Execute(insert, Hunt);
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
        }

        public void UpdateShinyHunt(ShinyHunt Hunt)
        {
            var update = "UPDATE [ShinyHunt] SET Counter = @Counter " +
              "WHERE IdTrainer = @IdTrainer AND PokeName = @PokeName";
            try
            {
                Database.Execute(update, Hunt);
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
        }

        public ShinyHunt GetShinyHunt(int UserId, string Name)
        {
            ShinyHunt hunt;
            try
            {
                var query = "SELECT * FROM [ShinyHunt] WHERE IdTrainer = @id AND PokeName = @name";
                hunt = Database.QueryFirstOrDefault<ShinyHunt>(query, new { id = UserId, name = Name });
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            return hunt;
        }

        public List<ShinyHunt> GetUserHunts(int UserId)
        {
            List<ShinyHunt> userHunts;
            try
            {
                var query = "SELECT * FROM [ShinyHunt] WHERE IdTrainer = @id";
                userHunts = Database.Query<ShinyHunt>(query,  new { id = UserId }).ToList();
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            return userHunts;

        }

        #endregion

    }
}
