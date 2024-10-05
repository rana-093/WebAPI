using Microsoft.EntityFrameworkCore;
using WebApplication1.Dtos;
using WebApplication1.model;

namespace WebApplication1.Service;

public class BookService
{
    private readonly MyDbContext _context;

    public BookService(MyDbContext context)
    {
        _context = context;
    }
    
    public async Task<BookDTO> AddBook(BookDTO bookDto)
    {
        Book book = bookDto.ToModel();
        await _context.Books.AddAsync(book);
        await _context.SaveChangesAsync();
        return book.ToDto();
    }

    public async Task<IEnumerable<BookDTO>> GetBooks()
    {
        var books =  await _context
            .Books
            .Include(b => b.Author)
            .ToListAsync();
        return books.Select(b => b.ToDto());
    }
}

