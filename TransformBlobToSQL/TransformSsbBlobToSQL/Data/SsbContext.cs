using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TransformSsbBlobToSQL.Models;

namespace TransformSsbBlobToSQL.Data
{
    public class SsbContext : DbContext
    {
        public SsbContext(DbContextOptions<SsbContext> options) : base(options)
        {
        }

        private DbSet<Ssb07849> Ssb07849s { get; set; }
    }
}