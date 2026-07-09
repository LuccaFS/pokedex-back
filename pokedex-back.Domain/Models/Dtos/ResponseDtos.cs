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
}
