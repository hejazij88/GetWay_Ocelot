using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using Microsoft.AspNetCore.Http.HttpResults;
using Writer_Api.Model;
using Writer_Api.Repository;

namespace Writer_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WritersController : ControllerBase
    {
        private readonly WriterRepository _writerRepository;

        public WritersController(WriterRepository writerRepository)
        {
            _writerRepository = writerRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_writerRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var writer = _writerRepository.Get(id);

            if (writer is null)
                return NotFound();

            return Ok(writer);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Writer writer)
        {
            var result = _writerRepository.Insert(writer);

            return Created($"/get/{result.Id}", result);
        }

    }
}

