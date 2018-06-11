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
    [Route("[controller]")]
    public class ActorsController : Controller
    {
        private readonly IActorRepository _actorRepository;
        //private readonly IActorMovieRepository _actorMovieRepository;

        public ActorsController(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }

        // GET actors/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var actor = await _actorRepository.GetAsync(id);

            //var actorMovie = await _actorMovieRepository.GetAsync(;

            if (actor == null)
            {
                return NotFound();
            }

            var result = new ActorModel
            {
                Id = actor.Id,
                Name = actor.Name,
                Sex = actor.Sex,
                DOB = actor.DOB,
                BIO = actor.BIO
            };

            return Ok(result);
        }

        // POST actors
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ActorModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var actor = new Actor
            {
                Name = model.Name,
                Sex = model.Sex,
                DOB = model.DOB,
                BIO = model.BIO
            };

            await _actorRepository.InsertAsync(actor);

            return Created($"actors/{actor.Id}", actor);
        }

        // PUT actors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]ActorModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var actor = await _actorRepository.GetAsync(id);

            if (actor == null)
            {
                return NotFound();
            }

            actor.Name = model.Name;
            actor.Sex = model.Sex;
            actor.DOB = model.DOB;
            actor.BIO = model.BIO;

            await _actorRepository.UpdateAsync(actor);

            return Ok(actor);
        }

        // DELETE actors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var actor = await _actorRepository.GetAsync(id);

            if (actor == null)
            {
                return NotFound();
            }

            await _actorRepository.DeleteAsync(actor);

            return Ok();
        }
    }
}