using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokedex_back.Domain.Models.Dtos
{
    public class ResponseDto
    {
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
    }

    public class DropdownDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class GamesDto
    {
        public int GameId { get; set; }
        public string GameNames { get; set; } = null!;
        public int ReleaseGeneration { get; set; }
        public bool IsRemake { get; set; }
        public int? OriginalGeneration { get; set; }
    }

    public class ShinyMethodsDto
    {
        public int ShinyMethodId { get; set; }
        public string ShinyMethodName { get; set; }
        public string? ShinyMethodDescription { get; set; }
        public int ShinyMethodFirstGen { get; set; }
        public bool IsGameExclusive { get; set; }
        public int? GameId { get; set; }
    }
}
