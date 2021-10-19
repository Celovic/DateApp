using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tinder.Data.Entities
{
    public class User : IdentityUser, IEntity
    {
        [Required]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public IEnumerable<Matches> Matches { get; set; }
    }
}
