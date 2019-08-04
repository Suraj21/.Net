using FriendBookApp.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace FriendBookApp.API.DAL
{
    public class DataContext:DbContext
    {
        public DbSet<Value> Value { get; set; }
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
        }
    }
}
