using Gerenciador_de_livraria.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

namespace Gerenciador_de_livraria.Controllers;

[Route("api/[controller]")]
[ApiController]

public class BooksController : ControllerBase
{
    //POST em '/api/books' para Criar um novo livro.
    [HttpPost]
    [ProducesResponseType(typeof(Books), StatusCodes.Status201Created)]

    public IActionResult createBook([FromBody] RequestCreateBookJson req)
    {
        var newBook = new
        {
            Title = req.Title,
            Author = req.Author,
            Price = req.Price,
            Stock = req.Stock,
            Genre = req.Genre,
            CreatedAt = DateOnly.FromDateTime(DateTime.Now),
            UpdatedAt = DateOnly.FromDateTime(DateTime.Now)
        };
        return CreatedResult(newBook);
    }

    //GET em '/api/books' para Listar todos os livros (com filtros opcionais).
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    //GET em '/api/books/{id}' para Buscar um livro pelo ID.

    //PUT em '/api/books/{id}' para Atualizar informações de um livro.

    //DELETE em '/api/books/{id}' para Excluir um livro da livraria.
}
