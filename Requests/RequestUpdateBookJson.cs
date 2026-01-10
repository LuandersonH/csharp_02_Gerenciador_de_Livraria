using System.ComponentModel.DataAnnotations;

namespace Gerenciador_de_livraria.Requests;

public class RequestUpdateBookJson
{
    [Range(0, double.MaxValue)]
    public decimal Price { get; set; }

    [Range(0, int.MaxValue)]
    public int Stock { get; set; }

}
