using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace XamarinNaoDa
{
    public class Database
    {
        private readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Postagem>().Wait();
        }

        public Task<List<Postagem>> GetPostAsync()
        {
            return _database.Table<Postagem>().ToListAsync();
        }

        public Task<int> SavePostAsync(Postagem postagem)
        {
            return _database.InsertAsync(postagem);
        }
    }
}
