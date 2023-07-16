using LibraryManagementSystem.Core.Entities;
using LibraryManagementSystem.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Infrastructure.Data
{
    public class BookRepository : IBookRepository
    {
        private BooksDatabaseContext _dbContext = null;
        public BookRepository(BooksDatabaseContext databaseContext )
        {
            _dbContext = databaseContext;
        }

        public void Add(Book entity)
        {
            entity.CreatedDate = DateTime.Now;
            _dbContext.Books.Add( entity );
            _dbContext.SaveChanges();
            
        }

        public void Delete(int id)
        {
            var book = _dbContext.Books.Find(id);
            book.IsDeleted = true;
            Update( id ,book );
        }

        public async Task<Book> GetByIdAsync(int id)
            => await _dbContext.Books.Where(b => b.IsDeleted == false)
            .FirstOrDefaultAsync(b => b.Id ==id);

        public async Task<List<Book>> ListAllAsync(string? searchFilter)
        {
            if (searchFilter != null)
                return await _dbContext.Books.Where(b => b.IsDeleted == false && b.Title.Contains(searchFilter)).ToListAsync();
            return await _dbContext.Books.Where(b => b.IsDeleted == false).ToListAsync();

        }
        public void Update(int id, Book entity)
        {
            var book = _dbContext.Books.Find(id);
            book.Title = entity.Title;
            book.Description = entity.Description;
            book.Author = entity.Author;
            book.Genre = entity.Genre;
            book.Price = entity.Price;
            book.IsDeleted = entity.IsDeleted;
            _dbContext.Books.Update(book);
            _dbContext.SaveChanges();
        }
    }
}
