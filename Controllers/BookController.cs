using LivrariaOnline.Communication.Requests;
using LivrariaOnline.Entities;
using LivrariaOnline.Enums;
using Microsoft.AspNetCore.Mvc;

namespace LivrariaOnline.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : Controller
{
    private readonly List<Book> _books = new List<Book>
    {
        new Book { Title = "1984", Author = "George Orwell", Genre = Genre.Romance, Price = 10.50m, QuantityInStock = 5 },
        new Book { Title = "The Lord of the Rings", Author = "J.R.R Tolkien", Genre = Genre.Fiction, Price = 19.99m, QuantityInStock = 20 },
        new Book { Title = "The Hobbit", Author = "J.R.R Tolkien", Genre = Genre.Fiction, Price = 20.98m, QuantityInStock = 10},
    };
    
    [HttpGet]
    [ProducesResponseType(typeof(List<Book>), StatusCodes.Status201Created)]
    public IActionResult GetAll()
    {
        return Ok(_books);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult Create([FromBody] RequestCreateBookJson book)
    {
        _books.Add(new Book
        {
            Title = book.Title,
            Author = book.Author,
            Genre = book.Genre,
            Price = book.Price,
            QuantityInStock = book.QuantityInStock
        });
        
        return Created(string.Empty, book);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Update([FromRoute] int id, [FromBody] RequestUpdateBookJson book)
    {
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Delete([FromRoute] int id)
    {
        var book = _books.Find(b => b.Id == id);

        if (book is not null)
        {
            _books.Remove(book);
        }
        
        return NoContent();
    }
}