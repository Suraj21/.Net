using FriendBookApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendBookApp.API.Interfaces
{
    public interface IRepository
    {
        Task<List<Value>> GetValues();

        Task<Value> GetValue(int id);
    }
}
