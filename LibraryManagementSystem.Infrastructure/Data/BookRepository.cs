using LibraryManagementSystem.Core.Entities;
using LibraryManagementSystem.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LibraryManagementSystem.Infrastructure.Data
{
    public class BookRepository : IBookRepository
    {
        private BooksDatabaseContext _dbContext = null;
        public BookRepository(BooksDatabaseContext databaseContext)
        {
            _dbContext = databaseContext;
        }

        public void Add(Book entity)
        {
            if (entity.GetType().GetProperties()
                .Where(pi => pi.PropertyType == typeof(string))
                .Select(pi => (string)pi.GetValue(entity))
                .All(value => !string.IsNullOrEmpty(value))
               )
            {

                _dbContext.Products.Add(entity);
                _dbContext.SaveChanges();
            }

        }

        public void Delete(int id)
        {
            var book = _dbContext.Products.Find(id);
            if (book != null)
            {
                book.IsActive = false;
                Update(id, book);
            }
        }

        public async Task<Book> GetByIdAsync(int id)
            => await _dbContext.Products.Where(b => b.IsActive == true)
            .FirstOrDefaultAsync(b => b.Id == id);

        public async Task<List<Book>> ListAllAsync(string? searchFilter)
        {
            if (searchFilter != null)
                return await _dbContext.Products.Where(b => b.IsActive == true && b.Title.ToLower().Contains(searchFilter.ToLower())).ToListAsync();
            return await _dbContext.Products.Where(b => b.IsActive == true).ToListAsync();

        }
        public void Update(int id, Book entity)
        {
            var book = _dbContext.Products.Find(id);
            if (book != null)
            {
                book.Title = entity.Title;
                book.Description = entity.Description;
                book.Brand = entity.Brand;
                book.Category = entity.Category;
                book.Price = entity.Price;
                book.IsActive = entity.IsActive;
                _dbContext.Products.Update(book);
                _dbContext.SaveChanges();
            }
        }
    }
}
