using FriendBookApp.API.Interfaces;
using FriendBookApp.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendBookApp.API.DAL
{
    public class Repository : IRepository
    {
        public Repository(DataContext dataContext)
        {
            DataContext = dataContext;
        }

        public DataContext DataContext { get; }

        public async Task<List<Value>> GetValues()
        {
            return await DataContext.Value.ToListAsync();
        }

        public async Task<Value> GetValue(int id)
        {
            return await DataContext.Value.FirstOrDefaultAsync(x=>x.Id == id);
        }
    }
}
