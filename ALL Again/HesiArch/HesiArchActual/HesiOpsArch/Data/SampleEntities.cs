using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Data
{
    public partial class SampleEntities : DbContext
    {
        public SampleEntities()
            : base("name=SampleEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<Exam> Exams { get; set; }
        public virtual DbSet<Student> Students { get; set; }
    }
}
