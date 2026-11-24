using BookManager.Communication.Requests;
using BookManager.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseCreateBookJson), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public IActionResult CreateBook([FromBody] RequestCreateBookJson book)
    {
        var NewBook = new Book()
        {
            Title = book.Title,
            Author = book.Author,
            Genre = book.Genre,
            Price = book.Price,
            Stock = book.Stock
        };

        if (!NewBook.isValidBook())
        {
            return BadRequest();
        }

        var response = new ResponseCreateBookJson
        {
            Id = NewBook.Id,
            Title = NewBook.Title,
            Author = NewBook.Author,
            Genre = NewBook.Genre,
            Price = NewBook.Price,
            Stock = NewBook.Stock
        };

        return Created(string.Empty, response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult GetAllBooks()
    {
        var books = new List<Book>
        {
            new Book { Id = 1, Title = "Book 1", Author = "Author 1", Genre = BookGenres.Fiction, Price = 10.99, Stock = 10, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new Book { Id = 2, Title = "Book 2", Author = "Author 2", Genre = BookGenres.NonFiction, Price = 15.99, Stock = 5, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
        };

        return Ok(books);
    }


    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult GetBookById([FromRoute] int id)
    {
        var response = new Book
        {
            Id = id,
            Title = $"Book {id}",
            Author = $"Author {id}",
            Genre = BookGenres.Fiction,
            Price = 10.99 + id,
            Stock = 10 + id
        };

        return Ok(response);
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult UpdateBook([FromRoute] int id, [FromBody] RequestCreateBookJson book)
    {
        var response = new Book
        {
            Id = id,
            Title = book.Title,
            Author = book.Author,
            Genre = book.Genre,
            Price = book.Price,
            Stock = book.Stock,
            UpdatedAt = DateTime.UtcNow,
        };

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult DeleteBook([FromRoute] int id)
    {
        return NoContent();
    }
}
