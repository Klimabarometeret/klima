using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TransformSsbBlobToSQL.Models;

namespace TransformSsbBlobToSQL.Data
{
    class SsbContext : DbContext
    {
        public SsbContext(DbContextOptions options) : base(options)
        {
        }

        private DbSet<Ssb07849> ssbKjøringer { get; set; }
    }
}
