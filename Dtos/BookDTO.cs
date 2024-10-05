using WebApplication1.model;

namespace WebApplication1.Dtos;

public class BookDTO
{
    public String Title { get; set; }
    public AuthorDTO? Author { get; set; }
    public int AuthorId { get; set; }

    public Book ToModel()
    {
        Book book = new Book();
        book.Title = Title;
        book.AuthorId = AuthorId;
        book.Author = Author?.ToModel();
        return book;
    }
}