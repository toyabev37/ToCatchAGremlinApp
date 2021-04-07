using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ToCatchAGremlin.Models
{
    //we need an obj that will track gremlins info...
    //this is our abstraction of a 'gremlin'
    public class Gremlin
    {
        //key
        [Key]
        public int ID { get; set; }
        
        [Required]
        public string Name { get; set; }

        //will be a foreign key-> just used to relate the gremlin to the officer...
        [ForeignKey(nameof(Officer))]
        public int OfficerID { get; set; }

       //navigation property
        public virtual Officer Officer{ get; set; }

        //need foreignKey for JailCell
        [ForeignKey(nameof(JailCell))]
        public int JailCellID { get; set; }
        public JailCell JailCell { get; set; }

    }
}