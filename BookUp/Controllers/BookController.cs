using BookUp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookUp.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private static List<Book> books = new List<Book>();

    [HttpPost("Create")]
    public IActionResult AddBooks(Book newBook)
    {
        if (newBook == null){ return Problem("Book is null"); }
        
        bool idFound = false;

        foreach(Book book in books)
        {
            if (book.Id == newBook.Id)
            {
                idFound = true;
            }
        }

        if (idFound)
        {
            return Problem("Id already exists");
        }

        books.Add(newBook);
        return Ok("New book was added to list");
    }

    [HttpGet("Read")]
    public IActionResult GetBooks()
    {
        return Ok(books);
    }
}
