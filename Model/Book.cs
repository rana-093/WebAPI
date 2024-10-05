using WebApplication1.Dtos;

namespace WebApplication1.model;

public class Book
{
    public int BookId { get; set; }
    public string Title { get; set; }
    public int AuthorId { get; set; }
    public Author Author { get; set; } = null!;

    public BookDTO ToDto()
    {
        BookDTO dto = new BookDTO();
        dto.Author = Author != null ? Author.ToDto() : null;
        dto.Title = Title;
        dto.AuthorId = AuthorId;
        return dto;
    }
}