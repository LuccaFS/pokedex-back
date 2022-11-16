using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokedex_back.Domain.Models
{
    public class User
    {
        public int IdUser { get; set; }
        public string DsName { get; set; }
        public string DsEmail { get; set; }
        public string DsPassword { get; set; }
        public string DsSalt { get; set; }
        public string RankName { get; set; }

    }

    public class UserDto
    {
        public string DsName { get; set; }
        public string DsEmail { get; set; }
        public string DsPassword { get; set; }
    }
}
