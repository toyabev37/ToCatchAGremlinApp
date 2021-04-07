using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ToCatchAGremlin.Models
{
    public class GremlinDBContext: DbContext
    {
        public GremlinDBContext()
            :base("DefaultConnection")
        {

        }

        public DbSet<Gremlin>Gremlins { get; set; }
        public DbSet<Officer> Officers { get; set; }
        public DbSet<JailCell> JailCells{ get; set; }
    }
}