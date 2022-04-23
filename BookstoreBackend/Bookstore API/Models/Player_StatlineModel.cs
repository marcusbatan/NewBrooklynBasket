using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bookstore_API.Models
{
    public class Player_StatlineModel
    {
        [Key]
        public int Id { get; set; }
        public PlayerModel PlayerModel { get; set; }
        public StatlineModel StatlineModel { get; set; }
        public string RegisterDate { get; set; }
    }
}