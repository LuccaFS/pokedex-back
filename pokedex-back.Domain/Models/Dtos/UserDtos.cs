using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokedex_back.Domain.Models.Dtos
{
    public class UserDTO
    {
        public int TrainerId { get; set; }
        public string TrainerName { get; set; }
        public string TrainerEmail { get; set; }
        public string TrainerPassword { get; set; }
        public string TrainerSalt { get; set; }
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
