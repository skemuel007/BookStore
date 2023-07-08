using BookStore.Domain.Interfaces;
using BookStore.Domain.Models;
using BookStore.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Repositories;

public class BookRepository : Repository<Book>, IBookRepository
{
    protected BookRepository(BookStoreDbContext dbContext) : base(dbContext)
    {
    }

    public override async Task<List<Book>> GetAll()
    {
        return await _dbContext.Books.AsNoTracking().Include(b => b.Category)
            .OrderBy(b => b.Name)
            .ToListAsync();
    }

    public override async Task<Book> GetById(int id)
    {
        return await _dbContext.Books.AsNoTracking().Include(b => b.Category)
            .Where(b => b.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Book>> GetBooksByCategory(int categoryId)
    {
        return await Search(b => b.CategoryId == categoryId);
    }

    public async Task<IEnumerable<Book>> SearchBookWithCategory(string searchedValue)
    {
        return await _dbContext.Books.AsNoTracking()
            .Include(b => b.Category)
            .Where(b => b.Name.Contains(searchedValue) ||
                        b.Name.Contains(searchedValue)
                        || b.Description.Contains(searchedValue)
                        || b.Category.Name.Contains(searchedValue))
            .ToListAsync();
    }
}