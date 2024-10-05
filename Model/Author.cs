using System.ComponentModel.DataAnnotations;
using WebApplication1.Dtos;

namespace WebApplication1.model;

public class Author
{
  public int Id { get; set; }
  
  [MaxLength(50)]
  public String FirstName { get; set; } = null!;
  
  public String LastName { get; set; }
  public ICollection<Book> Books { get; set; }

  public AuthorDTO ToDto()
  {
    AuthorDTO authorDto = new AuthorDTO();
    authorDto.FirstName = this.FirstName;
    authorDto.LastName = this.LastName;
    return authorDto;
  }
}