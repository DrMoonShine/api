using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
namespace Friends_web_api_v1.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<UserEvent> UserEvents { get; set; } = null!;//коллекция объектов, которая сопоставляется с определенной таблицей в БД
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Response> Responses { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
      
       
    }
}
