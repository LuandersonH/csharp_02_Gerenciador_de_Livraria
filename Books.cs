using Microsoft.AspNetCore.Http.HttpResults;

namespace Gerenciador_de_livraria;

public enum Genres
{
    horror,
    fantasy,
    science,
    romance
}

public class Books
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Stock { get; set; } = string.Empty;
    public Genres Genre { get; set; }
    public DateOnly CreatedAt { get; set; }
    public DateOnly UpdatedAt { get; set; }
}
