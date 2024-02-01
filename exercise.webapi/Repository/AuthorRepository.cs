﻿using exercise.webapi.Data;
using exercise.webapi.Models;
using Microsoft.EntityFrameworkCore;

namespace exercise.webapi.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        DataContext _db;
        public AuthorRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<Author> GetAuthorById(int id)
        {
            return await _db.Authors.Include(b => b.Books).SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Author>> GetAuthors()
        {
            return await _db.Authors.Include(a => a.Books).ToListAsync();
        }
    }
}
