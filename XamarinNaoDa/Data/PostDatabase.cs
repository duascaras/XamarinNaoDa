using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinNaoDa.Models;

namespace XamarinNaoDa.Data
{
    public class PostDatabase
    {
        private readonly SQLiteAsyncConnection _database;

        public PostDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Postagem>().Wait();
        }

        public Task<List<Postagem>> GetPostAsync()
        {
            return _database.Table<Postagem>().ToListAsync();
        }

        public Task<Postagem> GetPostAsync(int id)
        {
            // Get a specific post.
            return _database.Table<Postagem>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SavePostAsync(Postagem postagem)
        {
            return _database.InsertAsync(postagem);
        }

        public Task<int> DeletePostAsync(Postagem postagem)
        {
            return _database.DeleteAsync(postagem);
        }
    }
}