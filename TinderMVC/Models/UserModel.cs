using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Tinder.Data.Entities;

namespace TinderMVC.Models
{
    public class UserModel
    {
        public string UserId { get; set; }
        public int MatchesId { get; set; }
        public string UserName { get; set; }
        public string Description { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
