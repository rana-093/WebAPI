using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Dtos;
using WebApplication1.model;
using WebApplication1.Service;

namespace WebApplication1.Controller;

[ApiController]
[Route("api/v1/authors")]
public class AuthorController : ControllerBase
{
    private readonly MyDbContext _context;
    private readonly AuthorService _authorService;

    public AuthorController(MyDbContext context, AuthorService authorService)
    {
        _context = context;
        _authorService = authorService;
    }

    [HttpGet]
    public async Task<IEnumerable<AuthorDTO>> GetAuthor()
    {
        return await _authorService.GetAllAuthors();
    }
    
    [HttpPost]
    public async Task<AuthorDTO> SaveAuthor(AuthorDTO authorDto)
    {
        return await _authorService.SaveAuthor(authorDto);
    }
}