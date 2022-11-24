using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokedex_back.Domain.Models
{
    public class UserDTO
    {
        public int IdTrainer { get; set; }
        public string DsName { get; set; }
        public string DsEmail { get; set; }
        public string DsPassword { get; set; }
        public string DsSalt { get; set; }
        public string RankName { get; set; }

    }

    public class UserRegister
    {
        public string DsName { get; set; }
        public string DsEmail { get; set; }
        public string DsPassword { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string DsName { get; set; }
        public string DsRank { get; set; }
    }
}
