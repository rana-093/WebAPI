using System.ComponentModel.DataAnnotations;
using WebApplication1.model;

namespace WebApplication1.Dtos;

public class AuthorDTO
{
    [Required]
    [MaxLength(50)]
    public String? FirstName { get; set; }
    
    [Required]
    [MaxLength(50)]
    public String? LastName { get; set; }
    
    public String? FullName => $"{FirstName} {LastName}";
    
    public IEnumerable<BookDTO> Books { get; set; }

    public Author ToModel()
    {
        Author author  = new Author();
        author.FirstName = this.FirstName;
        author.LastName = this.LastName;
        return author;
    }
}