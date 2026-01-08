namespace Gerenciador_de_livraria.Repositories;

public class BooksRepository
{
    private const string V = "1";
    public List<Books> SavedBooks = new()
    {
        new Books
        {
            Id = Guid.Parse("d3c8f7a4-5b6e-4f2a-9c1d-123456789abc"),
            Author = "Author 1",
            Title = "Title 1",
            Genre = Genres.horror,
            Stock = 1,
            Price = 10m,
            CreatedAt = DateOnly.FromDateTime(DateTime.Now),
            UpdatedAt = null
        },
        new Books
        {
            Id = Guid.Parse("d3c8f7a4-5b6e-4f2a-9c1d-123456789def"),
            Author = "Author 2",
            Title = "Title 2",
            Genre = Genres.romance,
            Stock = 2,
            Price = 20m,
            CreatedAt = DateOnly.FromDateTime(DateTime.Now),
            UpdatedAt = null
        }
    };
}
