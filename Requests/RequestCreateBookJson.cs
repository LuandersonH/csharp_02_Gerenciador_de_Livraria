using System.ComponentModel.DataAnnotations;

namespace Gerenciador_de_livraria.Requests;

public class RequestCreateBookJson
{
    [StringLength(120, MinimumLength = 2)]
    public required string Title { get; set; } = string.Empty;
    
    [StringLength(120, MinimumLength = 2)]
    public required string Author { get; set; } = string.Empty;

    [Range(0, double.MaxValue)]
    public decimal Price { get; set; }

    [Range(0, int.MaxValue)]
    public int Stock { get; set; }

    [EnumDataType(typeof(Genres))]
    public Genres Genre { get; set; }
}
