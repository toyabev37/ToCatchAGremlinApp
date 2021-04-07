using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToCatchAGremlin.Models
{
    public class JailCell
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string CellNumber { get; set; }
        public virtual List<Gremlin> Gremlins { get; set; }
    }
}