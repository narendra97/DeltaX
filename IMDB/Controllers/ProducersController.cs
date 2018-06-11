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
    public class ProducersController : Controller
    {
        private readonly IProducerRepository _producerRepository;

        public ProducersController(IProducerRepository producerRepository)
        {
            _producerRepository = producerRepository;
        }

        // GET producers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var producer = await _producerRepository.GetAsync(id);

            if (producer == null)
            {
                return NotFound();
            }

            var result = new ProducerModel
            {
                Id = producer.Id,
                Name = producer.Name,
                Sex = producer.Sex,
                DOB = producer.DOB,
                BIO = producer.BIO
            };

            return Ok(result);
        }

        // POST producers
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ProducerModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var producer = new Producer
            {
                Name = model.Name,
                Sex = model.Sex,
                DOB = model.DOB,
                BIO = model.BIO
            };

            await _producerRepository.InsertAsync(producer);

            return Created($"producers/{producer.Id}", producer);
        }

        // PUT producers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]ProducerModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var producer = await _producerRepository.GetAsync(id);

            if (producer == null)
            {
                return NotFound();
            }

            producer.Name = model.Name;
            producer.Sex = model.Sex;
            producer.DOB = model.DOB;
            producer.BIO = model.BIO;

            await _producerRepository.UpdateAsync(producer);

            return Ok(producer);
        }

        // DELETE producers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var producer = await _producerRepository.GetAsync(id);

            if (producer == null)
            {
                return NotFound();
            }

            await _producerRepository.DeleteAsync(producer); 

            return Ok();
        }
    }
}