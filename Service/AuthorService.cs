using Microsoft.EntityFrameworkCore;
using WebApplication1.Dtos;
using WebApplication1.model;

namespace WebApplication1.Service;

public class AuthorService
{
    private readonly MyDbContext _context;

    public AuthorService(MyDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<AuthorDTO>> GetAllAuthors()
    {
        var authors =  await _context
            .Authors
            .Include(a => a.Books)
            .ToListAsync();
        
        return authors.Select(a => new AuthorDTO
        {
            FirstName = a.FirstName,
            LastName = a.LastName,
            Books = a.Books.Select(b => new BookDTO
            {
                Title = b.Title,
            })
            
        });
    }

    public async Task<AuthorDTO> SaveAuthor(AuthorDTO authorDto)
    {
        Author author = authorDto.ToModel();
        await _context.Authors.AddAsync(author);
        await _context.SaveChangesAsync();
        return author.ToDto();
    }
}