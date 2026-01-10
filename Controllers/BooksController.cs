using Gerenciador_de_livraria.Repositories;
using Gerenciador_de_livraria.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Runtime.Intrinsics.X86;

namespace Gerenciador_de_livraria.Controllers;

[Route("api/[controller]")]
[ApiController]

public class BooksController : ControllerBase
{
    //POST em '/api/books' para Criar um novo livro.
    [HttpPost]
    [ProducesResponseType(typeof(Books), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(Books), StatusCodes.Status409Conflict)]
    public IActionResult createBook([FromBody] RequestCreateBookJson req)
    {
        var booksList = new BooksRepository();

        var bookTitle = booksList.SavedBooks
                .Find(bk => bk.Title == req.Title.ToLower());
        
        var bookAuthor = booksList.SavedBooks
                .Find(bk => bk.Author == req.Author.ToLower());

        if (bookTitle != null) return Conflict("Já existe um livro com esse nome cadastrado!");
        if (bookAuthor != null) return Conflict("Já existe um autor com esse nome cadastrado!");

        var newBook = new Books
        {
            Id = Guid.NewGuid(),
            Title = req.Title,
            Author = req.Author,
            Price = req.Price,
            Stock = req.Stock,
            Genre = req.Genre,
            CreatedAt = DateOnly.FromDateTime(DateTime.Now)
        };

        booksList.SavedBooks.Add(newBook);

        return Created();
    }

    //GET em '/api/books' para Listar todos os livros (com filtros opcionais).
    [HttpGet]
    // typeof(IEnumerable<Books>) indica resposta com uma lista de livros.
    [ProducesResponseType(typeof(IEnumerable<Books>), StatusCodes.Status200OK)] 

    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult getAllBooks([FromQuery] string? reqTitle)
    {
        var booksList = new BooksRepository();

        if (!string.IsNullOrWhiteSpace(reqTitle))
        {
            var book = booksList.SavedBooks
                .Where(bk => bk.Title.Equals(reqTitle, StringComparison.OrdinalIgnoreCase))
                .ToList();

            return book.Any() ? Ok(book) : NotFound("Nenhum livro com esse título foi encontrado!");
        }

        return Ok(booksList.SavedBooks);
    }

    //GET em '/api/books/{id}' para Buscar um livro pelo ID.
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Books), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public IActionResult getBookById([FromRoute] string id)
    {
        var booksList = new BooksRepository();

        if (!Guid.TryParse(id, out var guid))
        {
            return BadRequest("ID inválida.");
        }

        var book = booksList.SavedBooks.FirstOrDefault(bk => bk.Id == guid);

        if (book == null)
        {
            return NotFound("Nenhum livro com esse ID foi encontrado!");
        }
                
        return Ok(book);
    }

    //PUT em '/api/books/{id}' para Atualizar informações de um livro.
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public IActionResult UpdateBookById([FromRoute] string id, [FromBody] RequestUpdateBookJson request)
    {
        if (!Guid.TryParse(id, out var idReq))
            return BadRequest("ID inválido.");

        var bookList = new BooksRepository();
        var book = bookList.SavedBooks.Find(bk => bk.Id == idReq);

        if (book == null)
            return NotFound("Nenhum livro com esse ID foi encontrado!");

        if (request.Price < 0 || request.Stock < 0)
            return BadRequest("Preço e estoque devem ser maiores ou iguais a 0.");

        book.Stock = request.Stock;
        book.Price = request.Price;
        book.UpdatedAt = DateOnly.FromDateTime(DateTime.Now);

        return NoContent();
    }


    //DELETE em '/api/books/{id}' para Excluir um livro da livraria.
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public IActionResult Delete([FromRoute] string id)
    {
        if (!Guid.TryParse(id, out var idReq))
            return BadRequest("ID inválido.");

        var bookList = new BooksRepository();
        var book = bookList.SavedBooks.Find(bk => bk.Id == idReq);

        if (book == null)
            return NotFound("Nenhum livro com esse ID foi encontrado!");

        bookList.SavedBooks.Remove(book);

        return NoContent();
    }

}
