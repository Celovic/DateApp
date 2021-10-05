using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tinder.Data.Entities;
using X.PagedList;

namespace TinderMVC.Models
{
    public class ViewModel
    {
        public User User { get; set; }
        public Matches Match{ get; set; }
        public List<User> Users { get; set; }
        public List<Matches> Matches{ get; set; }
        public List<ViewModel> ViewModels{ get; set; }
        public string LikedPersonName { get; set; }
        public string LikedPersonId { get; set; }
        public string PersonId { get; set; }
    }
}
