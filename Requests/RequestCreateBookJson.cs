namespace Gerenciador_de_livraria.Requests;

public class RequestCreateBookJson
{
    public required string Title { get; set; } = string.Empty;
    public required string Author { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Stock { get; set; } = string.Empty;
    public Genres Genre { get; set; }
}
