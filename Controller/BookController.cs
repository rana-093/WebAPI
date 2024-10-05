using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dtos;
using WebApplication1.Service;

namespace WebApplication1.Controller;

[ApiController]
[Route("api/v1/books")]
public class BookController: ControllerBase
{
    private readonly BookService _bookService;

    public BookController(BookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<IEnumerable<BookDTO>> GetBooks()
    {
        return await _bookService.GetBooks();
    }

    [HttpPost]
    public async Task<BookDTO> CreateBook(BookDTO book)
    {
        return await _bookService.AddBook(book);
    }
}