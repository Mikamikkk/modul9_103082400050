using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace modul9_103082400050.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private static List<Movie> _movies = new List<Movie>
        {
            new Movie {
                Title = "The Shawshank Redemption",
                Director = "Frank Darabont",
                Stars = new List<string>{"Tim Robbins", "Morgan Freeman", "Bob Gunton"},
                Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency."
            },
            new Movie {
                Title = "The Godfather",
                Director = "Francis Ford Coppola",
                Stars = new List<string>{"Marlon Brando", "Al Pacino", "James Caan"},
                Description = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son."
            },
            new Movie {
                Title = "The Dark Knight",
                Director = "Christopher Nolan",
                Stars = new List<string>{"Christian Bale", "Heath Ledger", "Aaron Eckhart"},
                Description = "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice."
            }
        };

        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return _movies;
        }

        [HttpGet("{id}")]
        public ActionResult<Movie> Get(int id)
        {
            if (id < 0 || id >= _movies.Count)
            {
                return NotFound(new { message = "Film tidak ditemukan pada index tersebut." });
            }
            return _movies[id];
        }

        [HttpPost]
        public IActionResult Post([FromBody] Movie value)
        {
            if (value == null)
            {
                return BadRequest();
            }
            _movies.Add(value);
            return Ok(new { message = "Film berhasil ditambahkan!" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= _movies.Count)
            {
                return NotFound(new { message = "Gagal menghapus, index tidak valid." });
            }
            _movies.RemoveAt(id);
            return Ok(new { message = "Film berhasil dihapus!" });
        }
    }
}