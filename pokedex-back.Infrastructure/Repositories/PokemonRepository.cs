using Microsoft.Extensions.Configuration;
using pokedex_back.Domain.Interfaces;
using Dapper;
using pokedex_back.Domain.Models.Dtos;
using pokedex_back.Domain.Models.InputDtos;
using pokedex_back.Domain.Aggregates;
using System.Data;

namespace pokedex_back.Infrastructure.Repositories
{
    public class PokemonRepository : SqlServerRepository, IPokemonRepository
    {
        public PokemonRepository(IConfiguration config) : base(config)
        {
        }

        #region ' Pokedex '
        public void SavePokemon(PokemonInputDto pokemon)
        {
            var insert = "INSERT INTO [dbo].[Pokemons] (PokemonNumber, PokemonName, Type1, Type2, Generation, HasPokemonGroup, PokemonGroupId," +
                "FormGroupId, BaseFormNumber)";
            try
            {

                Database.Execute(insert, pokemon);
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
        }

        public List<PokemonDto> GetAll()
        {
            List<PokemonDto> pokemons = new List<PokemonDto>();
            var query = $"SELECT * FROM [dbo].[Pokemons]" +
                $"ORDER BY COALESCE(BaseFormNumber, PokemonNumber), " +
                $"CASE WHEN BaseFormNumber IS NULL THEN 0 ELSE 1 END, " +
                $"PokemonNumber;";
            try
            {
                pokemons = Database.Query<PokemonDto>(query).ToList();
                
            }
            catch( Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            return pokemons;

        }

        public PokemonDto GetByName(string PokeName)
        {
            PokemonDto pokemon = new PokemonDto();
            DynamicParameters param = new DynamicParameters();

            var query = "Select * from [Pokemons] WHERE [PokemonName] = @name";
            param.Add("name", value: PokeName, direction: ParameterDirection.Input);


            try
            {
                pokemon = Database.QueryFirstOrDefault<PokemonDto>(query, param);
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

        public PokemonDto GetById(string PokeId)
        {
            PokemonDto pokemon = new PokemonDto();
            DynamicParameters param = new DynamicParameters();

            var query = "Select * from [Pokemons] WHERE [PokemonNumber] = @id";
            param.Add("id", value: PokeId, direction: ParameterDirection.Input);

            try
            {
                pokemon = Database.QueryFirstOrDefault<PokemonDto>(query, param);
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

        public List<PokemonDto> GetAndSaveFromAPI(List<PokemonInputDto> pokemons)
        {
            var insert = "INSERT INTO [dbo].[Pokemons] (PokemonNumber, PokemonName, Type1, Type2, Generation, HasPokemonGroup, PokemonGroupId," +
                "FormGroupId, BaseFormNumber) " +
               "VALUES ";
            
            insert += string.Join(',', pokemons.Select(pokemon => $"({pokemon.PokemonNumber},'{pokemon.PokemonName}',{pokemon.Type1},{(pokemon.Type2 is null ? "NULL" : pokemon.Type2)}," +
            $"{pokemon.Generation},{(pokemon.HasPokemonGroup ? 1 : 0)}," +$"{(pokemon.PokemonGroupId is null ? "NULL" : pokemon.PokemonGroupId)}," +
            $"{(pokemon.FormGroupId is null ? "NULL" : pokemon.FormGroupId)},{(pokemon.BaseFormNumber is null ? "NULL" : pokemon.BaseFormNumber)})"));
            
            try
            {

                Database.Execute(insert);
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }


            List<PokemonDto> pokemonsResponse = GetAll();
            return pokemonsResponse;
        }
        #endregion


        #region ' Shiny Hunt '
        public void SaveShinyHunt(ShinyHuntInputDto Hunt)
        {
            var exists = GetShinyHunt(new GetShinyHuntInputDto()
            {
                TrainerId = Hunt.TrainerId,
                PokemonNumber = Hunt.PokemonNumber,
                GameId = Hunt.GameId,
                MethodId = Hunt.MethodId
            });
            if (exists!=null) {
                UpdateShinyHunt(Hunt);
                return;
            }
            var insert = "INSERT INTO [ShinyHunts] (TrainerId, PokemonNumber, PokemonName, EncounterCount, PhaseCount, " +
                        "GameId, HasShinyCharm, MethodId)" +
                        "VALUES (@TrainerId, @PokemonNumber, @PokemonName, @EncounterCount, @PhaseCount, @GameId, @HasShinyCharm, @MethodId)";
            try
            {
                Database.Execute(insert, Hunt);
            }
            catch (Exception e)
            {
                throw new ApplicationException("Error saving Shiny Hunt.", e);
            }
        }

        public void UpdateShinyHunt(ShinyHuntInputDto Hunt)
        {
            DynamicParameters param = new DynamicParameters();
            var update = "UPDATE [ShinyHunt] SET [EncounterCount] = @EncounterCount,  [PhaseCount] = @PhaseCount, " +
                         "[GameId] = @GameId, [MethodId] = @MethodId, [HasShinyCharm] = @HasShinyCharm" +
                         "WHERE [TrainerId] = @TrainerId AND [PokemonNumber] = @PokemonNumber AND [HuntComplete] = 0";
            try
            {
                Database.Execute(update, Hunt);
            }
            catch (Exception e)
            {
                throw new ApplicationException("Error Updating Shiny Hunt.",e);
            }
        }

        public ShinyHuntDto GetShinyHunt(GetShinyHuntInputDto inputDto)
        {
            ShinyHuntDto hunt;
            DynamicParameters param = new DynamicParameters();
            var query = "SELECT * FROM [ShinyHunts] " +
                        "WHERE [TrainerId] = @id " +
                        "AND [HuntComplete] = 0";
            param.Add("id", value: inputDto.TrainerId, direction: ParameterDirection.Input);

            if (inputDto.PokemonNumber is not null)
            {
                query += " AND [PokemonNumber] = @pokeNum";
                param.Add("pokeNum", value: inputDto.PokemonNumber, direction: ParameterDirection.Input);
            }

            if (inputDto.GameId is not null)
            {
                query += " AND [GameId] = @game";
                param.Add("game", inputDto.GameId);
            }

            if (inputDto.MethodId is not null)
            {
                query += " AND [MethodId] = @method";
                param.Add("method", inputDto.MethodId, direction: ParameterDirection.Input);
            }

            try
            {
                hunt = Database.QueryFirstOrDefault<ShinyHuntDto>(query, param);
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            return hunt;
        }

        public List<ShinyHuntDto> GetUserHunts(int UserId)
        {
            List<ShinyHuntDto> userHunts;
            try
            {
                var query = "SELECT * FROM [ShinyHunts] WHERE [TrainerId] = @id";
                userHunts = Database.Query<ShinyHuntDto>(query,  new { id = UserId }).ToList();
            }
            catch (Exception e)
            {
                throw new ApplicationException("Error happened when getting user shiny hunts", e);
            }
            return userHunts;

        }

        #endregion

    }
}
