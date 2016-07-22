using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Music.Models
{
    public class Car
    {
        [Key]
        public int RecordId { get; set; }
        public string CarId { get; set; }
        public int AlbumId { get; set; }
        public int Count { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual Album Album { get; set; }
    }
}