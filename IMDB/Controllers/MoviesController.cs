using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using imdb.Domain;
using imdb.Model;
using imdb.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace imdb.Controllers
{
    [Route("producers")]
    public class MoviesController : Controller
    {
        private readonly IMovieRepository _movieRepository;

        private readonly IProducerRepository _producerRepository;

        private readonly IActorRepository _actorRepository;

        //private readonly IActorMovieRepository _actorMovieRepository;

        //private readonly IProducerMovieRepository _producerMovieRepository;

        public MoviesController(IProducerRepository producerRepository, IMovieRepository movieRepository, IActorRepository actorRepository)
        {
            _movieRepository = movieRepository;
            _actorRepository = actorRepository;
            _producerRepository = producerRepository;
            //_actorMovieRepository = actorMovieRepository;
            //_producerMovieRepository = producerMovieRepository;
        }

        // GET producers/getAllMovies/movies
        [HttpGet("getAllMovies/[controller]")]
        public async Task<IActionResult> GetAllMovies()
        {
            var movies = await _movieRepository.Query().ToListAsync();

            if (movies == null)      //if for particular aticle if we don't have any comment it returns not found
            {
                return NotFound();
            }

            var result = new MovieListModel
            {
                Movies = movies.Select(c => new MovieModel
                {
                    ProducerId = (int)c.ProducerId,            
                    Id = c.Id,
                    Name = c.Name,
                    YearOfReleased = c.YearOfReleased,
                    Plot = c.Plot,
                    ActorId =(int)c.ActorId
                })      
            };

            return Ok(result);
        }


        // GET producers/getProducersById/5/movies
        [HttpGet("getProducersById/{producerId}/[controller]")]
        public async Task<IActionResult> GetProducersById([FromRoute]int producerId)
        {
            var producer = await _producerRepository.GetAsync(producerId);

            if (producer == null)
            {
                return NotFound();
            }

            var movies = await _movieRepository.Query().ToListAsync();

            if (movies.FirstOrDefault(c => c.ProducerId == producerId) == null)      //if for particular aticle if we don't have any comment it returns not found
            {
                return NotFound();
            }

            var result = new MovieListModel
            {
                Movies = movies.Select(c => new MovieModel
                {
                    ProducerId = (int)c.ProducerId,            //article id is used to use where clause to shown the result which is of particular article id
                    Id = c.Id,
                    Name = c.Name,
                    YearOfReleased = c.YearOfReleased,
                    Plot = c.Plot
                }).Where(a => a.ProducerId == producerId)       //use where clause to show the filtered result
            };

            return Ok(result);
        }

        // GET producers/getActorsById/5/movies
        [HttpGet("getActorsById/{actorId}/[controller]")]
        public async Task<IActionResult> GetActorsById([FromRoute]int actorId)
        {
            var actor = await _actorRepository.GetAsync(actorId);

            if (actor == null)
            {
                return NotFound();
            }

            var movies = await _movieRepository.Query().ToListAsync();

            if (movies.FirstOrDefault(c => c.ActorId == actorId) == null)     
            {
                return NotFound();
            }

            var result = new MovieListModel
            {
                Movies = movies.Select(c => new MovieModel
                {
                    ActorId = (int)c.ActorId,            
                    Id = c.Id,
                    Name = c.Name,
                    YearOfReleased = c.YearOfReleased,
                    Plot = c.Plot
                }).Where(a => a.ActorId == actorId)       
            };

            return Ok(result);
        }

        // GET producers/getProducersById/1/movies/5
        [HttpGet("getProducersById/{producerId}/[controller]/{id}")]
        public async Task<IActionResult> GetProducerByMovieId([FromRoute]int producerId, [FromRoute]int id)
        {
            var producer = await _producerRepository.GetAsync(producerId);

            if (producer == null)
            {
                return NotFound();
            }

            var movie = await _movieRepository.Query().FirstOrDefaultAsync(c => c.ProducerId == producerId && c.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            var result = new MovieModel
            {
                Id = movie.Id,
                ProducerId = (int)movie.ProducerId,                 
                Name = movie.Name,
                YearOfReleased = movie.YearOfReleased,
                Plot = movie.Plot
            };

            return Ok(result);
        }

        // GET producers/getActorsById/1/movies/5
        [HttpGet("getActorsById/{actorId}/[controller]/{id}")]
        public async Task<IActionResult> GetActorByMovieId([FromRoute]int actorId, [FromRoute]int id)
        {
            var actor = await _actorRepository.GetAsync(actorId);

            if (actor == null)
            {
                return NotFound();
            }

            var movie = await _movieRepository.Query().FirstOrDefaultAsync(c => c.ActorId == actorId && c.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            var result = new MovieModel
            {
                Id = movie.Id,
                ActorId = (int)movie.ActorId,
                Name = movie.Name,
                YearOfReleased = movie.YearOfReleased,
                Plot = movie.Plot
            };

            return Ok(result);
        }


        // POST producers/5/movies
        [HttpPost("{producerId}/[controller]")]
        public async Task<IActionResult> Post([FromRoute]int producerId, [FromBody]MovieModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var producer = await _producerRepository.GetAsync(producerId);

            if (producer == null)
            {
                return NotFound();
            }

            var movie = new Movie
            {
                ProducerId = producerId,              
                Name = model.Name,
                YearOfReleased = model.YearOfReleased,
                Plot = model.Plot
            };

            await _movieRepository.InsertAsync(movie);

            var result = new MovieModel
            {
                ProducerId = producerId,            
                Id = movie.Id,
                Name = movie.Name,
                YearOfReleased = movie.YearOfReleased,
                Plot = movie.Plot
            };

            return Created($"producers/{producerId}/movies/{movie.Id}", result);
        }

        // POST producers/5/1/movies
        [HttpPost("{producerId}/{actorId}/[controller]")]
        public async Task<IActionResult> Post([FromRoute]int producerId, [FromRoute]int actorId, [FromBody]MovieModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var producer = await _producerRepository.GetAsync(producerId);

            if (producer == null)
            {
                return NotFound();
            }

            var actor = await _actorRepository.GetAsync(actorId);

            if (actor == null)
            {
                return NotFound();
            }

            var movie = new Movie
            {
                ProducerId = producerId,
                Name = model.Name,
                YearOfReleased = model.YearOfReleased,
                Plot = model.Plot,
                ActorId = actorId
            };

            await _movieRepository.InsertAsync(movie);

            var result = new MovieModel
            {
                ProducerId = producerId,
                Id = movie.Id,
                Name = movie.Name,
                YearOfReleased = movie.YearOfReleased,
                Plot = movie.Plot,
                ActorId = actorId
            };

            return Created($"producers/{producerId}/{actorId}/movies/{movie.Id}", result);
        }


    }
}