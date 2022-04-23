using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bookstore_API.Models
{
    public class PlayerModel
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Position { get; set; }
        public string FavPlayer { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public int GamesPlayed { get; set; }
    }
}