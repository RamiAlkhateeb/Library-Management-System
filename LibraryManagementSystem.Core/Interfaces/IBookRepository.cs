using LibraryManagementSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Core.Interfaces
{
    public interface IBookRepository
    {
        Task<List<Book>> ListAllAsync(string? searchFilter);
        Task<Book> GetByIdAsync(int id);
        void Add(Book entity);
        void Update(int id ,Book entity);
        void Delete(int id);
    }
}
