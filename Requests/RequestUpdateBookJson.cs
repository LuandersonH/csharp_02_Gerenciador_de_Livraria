namespace Gerenciador_de_livraria.Requests;

public class RequestUpdateBookJson
{
    public decimal Price { get; set; }
    public int Stock { get; set; } = string.Empty;

}
