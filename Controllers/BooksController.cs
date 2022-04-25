using API_APP.Models;
using API_APP.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace api_app.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookRepository _bookRepository;

    public BooksController(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    [HttpGet]
    public async Task<IEnumerable<Book>> GetBooks()
    {
        return await _bookRepository.GetBooks();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Book>> GetBook(int id)
    {
        return await _bookRepository.GetBook(id);
    }

    [HttpPost]
    public async Task<ActionResult<Book>> CreateBook([FromBody] Book book)
    {
        var newBook = await _bookRepository.CreateBook(book);
        return CreatedAtAction(nameof(GetBook), new {id = newBook.Id}, newBook);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateBook(int id, [FromBody] Book book)
    {
        if (id != book.Id)
        {
            return BadRequest();
        }

        await _bookRepository.UpdateBook(book);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteBook(int id)
    {
        var bookToDelete = await _bookRepository.GetBook(id);
        if (bookToDelete == null)
        {
            return NotFound();
        }

        await _bookRepository.DeleteBook(id);
        return NoContent();
    }
}
