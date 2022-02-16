using DBNewQuery.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace PartialViewCrudDemo.DataBase
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public virtual DbSet<Especialidad> Especialidad { get; set; }
    }
}
