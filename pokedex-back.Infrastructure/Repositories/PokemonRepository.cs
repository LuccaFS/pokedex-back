using Microsoft.Extensions.Configuration;
using pokedex_back.Domain.Interfaces;
using pokedex_back.Domain.Models;
using Dapper;

namespace pokedex_back.Infrastructure.Repositories
{
    public class PokemonRepository : SqlServerRepository, IPokemonRepository
    {
        public PokemonRepository(IConfiguration config) : base(config)
        {
        }

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
    }
}
