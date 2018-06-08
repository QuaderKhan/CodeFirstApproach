using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Somee.Models;

namespace Somee.Data
{
    public class UserDBContext : DbContext
    {
        public UserDBContext() : base("LocalDataBase")
        {
            
        }
        public DbSet<User> Users { get; set; }
        
    }
}