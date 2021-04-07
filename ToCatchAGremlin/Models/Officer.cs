using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToCatchAGremlin.Models
{
    //one officer can have many Gremlins....
    public class Officer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Gremlin> ApprehenedGremlins { get; set; } = new List<Gremlin>();


    }
}