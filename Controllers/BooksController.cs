using Gerenciador_de_livraria.Repositories;
using Gerenciador_de_livraria.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
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
            CreatedAt = DateOnly.FromDateTime(DateTime.Now)
        };

        return Created();
    }

    //GET em '/api/books' para Listar todos os livros (com filtros opcionais).
    [HttpGet]
    [ProducesResponseType(typeof(Books), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult getAllBooks([FromBody] string? req)
    {

        var booksList = new BooksRepository();

        if (!string.IsNullOrWhiteSpace(req))
         {
            switch (req.ToLower()) 
            {
                case "author 1":
                    var book1 = booksList.SavedBooks.Where(bk => bk.Author.Equals("author 1", StringComparison.OrdinalIgnoreCase)).ToList();
                    return Ok(book1);
                    
                case "author 2":
                    var book2 = booksList.SavedBooks.Where(bk => bk.Author.Equals("author 2", StringComparison.OrdinalIgnoreCase)).ToList();
                    return Ok(book2);
                
                default:
                    return NotFound();
            }
        }

        var books = booksList.SavedBooks;
        return Ok(books);
    }

    [Route("{id}")]
    [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    //GET em '/api/books/{id}' para Buscar um livro pelo ID.

    //PUT em '/api/books/{id}' para Atualizar informações de um livro.

    //DELETE em '/api/books/{id}' para Excluir um livro da livraria.
}
