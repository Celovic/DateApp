using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tinder.Data.Entities
{
    public class Matches:IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MatchesId { get; set; }
        public string PersonId { get; set; }
        public string LikedPerson { get; set; }
        public bool Status { get; set; }
        [ForeignKey("PersonId")]
        public User User { get; set; }
    }
}
