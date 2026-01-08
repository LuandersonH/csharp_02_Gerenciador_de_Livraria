namespace Gerenciador_de_livraria.Repositories;

public class BooksRepository
{
    public List<Books> SavedBooks = new()
    {
        new Books
        {
            Id = Guid.NewGuid(),
            Author = "Author 1",
            Title = "Title 1",
            Genre = Genres.horror,
            Stock = 1,
            Price = 10m,
            CreatedAt = DateOnly.FromDateTime(DateTime.Now)
        },
        new Books
        {
            Id = Guid.NewGuid(),
            Author = "Author 2",
            Title = "Title 2",
            Genre = Genres.romance,
            Stock = 2,
            Price = 20m,
            CreatedAt = DateOnly.FromDateTime(DateTime.Now)
        }
    };
}
