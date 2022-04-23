using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bookstore_API.Models
{
    public class StatlineModel
    {
        [Key]
        public int Id { get; set; }
        public int Points { get; set; }
        public int Rebounds { get; set; }
        public int Assists { get; set; }
        public int Steals { get; set; }
        public int Blocks { get; set; }
        public int FGA { get; set; }
        public int FGM { get; set; }
        public int ThreePTA { get; set; }
        public int ThreePTM { get; set; }
        public int FTA { get; set; }
        public int FTM { get; set; }
        public string RegLineDate { get; set; }

    }
}