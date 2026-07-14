using Dapper;
using Microsoft.Extensions.Configuration;
using pokedex_back.Domain.Aggregates;
using pokedex_back.Domain.Interfaces;
using pokedex_back.Domain.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace pokedex_back.Infrastructure.Repositories
{
    public class CommonRepository : SqlServerRepository, ICommonRepository
    {
        public CommonRepository(IConfiguration config) : base(config)
        {
        }

        public List<DropdownDto> GetRanksDropdown(string? name = null)
        {
            List<DropdownDto> response = new List<DropdownDto>();
            DynamicParameters param = new DynamicParameters();

            string sql = $"SELECT [RankId] as Id, [RankName] as Name " +
                         $"FROM [dbo].[Ranks] ";

            if (name != null)
            {
                sql += "WHERE [RankName] LIKE @name";
                param.Add("name", value: '%' + name + '%', direction: ParameterDirection.Input);
            }

            try
            {
                response = Database.Query<DropdownDto>(sql, param).ToList();

            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            return response;
        }

        public List<DropdownDto> GetTypesDropdown(string? name = null)
        {
            List<DropdownDto> response = new List<DropdownDto>();
            DynamicParameters param = new DynamicParameters();

            string sql = $"SELECT [TypeId] as Id, [TypeName] as Name " +
                         $"FROM [dbo].[Types] ";
            if(name != null)
            {
                sql += "WHERE [TypeName] LIKE @name";
                param.Add("name", value: '%' + name + '%', direction: ParameterDirection.Input);
            }

            try
            {
                response = Database.Query<DropdownDto>(sql, param).ToList();

            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            return response;
        }

        public List<DropdownDto> GetFormGroupsDropdown(string? name = null)
        {
            List<DropdownDto> response = new List<DropdownDto>();
            DynamicParameters param = new DynamicParameters();

            string sql = $"SELECT [FormGroupId] as Id, [FormGroupName] as Name " +
                         $"FROM [dbo].[FormGroups] ";
            if (name != null)
            {
                sql += "WHERE [FormGroupName] LIKE @name";
                param.Add("name", value: '%' + name + '%', direction: ParameterDirection.Input);
            }

            try
            {
                response = Database.Query<DropdownDto>(sql, param).ToList();

            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            return response;
        }

        public List<DropdownDto> GetPokemonGroupsDropdown(string? name = null)
        {
            List<DropdownDto> response = new List<DropdownDto>();
            DynamicParameters param = new DynamicParameters();

            string sql = $"SELECT [GroupId] as Id, [GroupName] as Name " +
                         $"FROM [dbo].[PokemonGroups] ";
            if (name != null)
            {
                sql += "WHERE [GroupName] LIKE @name";
                param.Add("name", value: '%' + name + '%', direction: ParameterDirection.Input);
            }

            try
            {
                response = Database.Query<DropdownDto>(sql, param).ToList();

            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            return response;
        }

        public List<DropdownDto> GetGamesDropdown(string? name = null)
        {
            List<DropdownDto> response = new List<DropdownDto>();
            DynamicParameters param = new DynamicParameters();

            string sql = $"SELECT [GameId] as Id, [GameNames] as Name " +
                         $"FROM [dbo].[Games] ";
            if (name != null)
            {
                sql += "WHERE [GameNames] LIKE @name";
                param.Add("name", value: '%' + name + '%', direction: ParameterDirection.Input);
            }

            try
            {
                response = Database.Query<DropdownDto>(sql, param).ToList();

            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            return response;
        }

        public List<DropdownDto> GetShinyMethodsDropdown(string? name = null)
        {
            List<DropdownDto> response = new List<DropdownDto>();
            DynamicParameters param = new DynamicParameters();

            string sql = $"SELECT [ShinyMethodId] as Id, [ShinyMethodName] as Name " +
                         $"FROM [dbo].[ShinyMethods] ";
            if (name != null)
            {
                sql += "WHERE [ShinyMethodName] LIKE @name";
                param.Add("name", value: '%' + name + '%', direction: ParameterDirection.Input);
            }

            try
            {
                response = Database.Query<DropdownDto>(sql, param).ToList();

            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            return response;
        }

        public List<GamesDto> GetGamesDetails(int? gameId)
        {
            List<GamesDto> response = new List<GamesDto>();
            DynamicParameters param = new DynamicParameters();

            var sql = new StringBuilder($"SELECT [GameId], [GameNames], [ReleaseGeneration], [IsRemake], [OriginalGeneration] " +
                                        $"FROM [dbo].[Games] ");

            if(gameId != null)
            {
                sql.Append("WHERE [GameId] = @gameId");
                param.Add("gameId", value: gameId, direction: ParameterDirection.Input);
            }
            try
            {
                response = Database.Query<GamesDto>(sql.ToString(), param).ToList();

            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            return response;

        }

        public List<ShinyMethodsDto> GetShinyMethodsDetails(int? shinyMethodId)
        {
            List<ShinyMethodsDto> response = new List<ShinyMethodsDto>();
            DynamicParameters param = new DynamicParameters();

            var sql = new StringBuilder($"SELECT [ShinyMethodId], [ShinyMethodName], [ShinyMethodDescription], [ShinyMethodFirstGen], [IsGameExclusive], [GameId] " +
                                        $"FROM [dbo].[ShinyMethods] ");

            if (shinyMethodId != null)
            {
                sql.Append("WHERE [ShinyMethodId] = @shinyMethodId");
                param.Add("shinyMethodId", value: shinyMethodId, direction: ParameterDirection.Input);
            }
            try
            {
                response = Database.Query<ShinyMethodsDto>(sql.ToString(), param).ToList();

            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            return response;
        }
    }
}
