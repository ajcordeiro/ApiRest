using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebTest.Entities;
using WebTest.Models;
using WebTest.Persistence;

namespace WebTest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IAPIDbContext _context;
        private readonly IMapper _mapper;

        public ClientController(IAPIDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("All")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllClient()
        {
            var getAllClient = _context.Clients.ToList();

            if (getAllClient is null)
                return NotFound();

            var viewModel = _mapper.Map<List<Client>>(getAllClient);

            return Ok(viewModel);
        }

        [HttpGet("Ativos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetClientActive()
        {
            var getClient = _context.Clients.Where(d => d.IsActive).ToList();

            var viewModel = _mapper.Map<List<Client>>(getClient);

            return Ok(viewModel);
        }

        [HttpGet("Not Active")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetClientNotActive()
        {
            var getClient = _context.Clients.Where(d => !d.IsActive).ToList();

            var viewModel = _mapper.Map<List<Client>>(getClient);

            return Ok(viewModel);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetClient(Guid id)
        {
            var client = _context.Clients.SingleOrDefault(d => d.ClientID == id);

            if (client is null)
                return NotFound();

            var clientModel = _mapper.Map<ClientViewModel>(client);

            return Ok(client);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult PutClient(Guid id, ClientInputModel client)
        {
            var devEvent = _context.Clients.SingleOrDefault(d => d.ClientID == id);

            if (devEvent == null)
                return NotFound();

            devEvent.Update(client.Name, client.Address, client.Age, client.DocumentNumber, client.IsActive);

            _context.Clients.Update(devEvent);
            _context.SaveChanges();

            return Ok(devEvent);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult PostClient(ClientInputModel clientInput)
        {
            var client = _mapper.Map<Client>(clientInput);

            if (client is null)
                return NotFound();

            client.ClientID = Guid.NewGuid();

            _context.Clients.Add(client);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetClientActive), new { id = client.ClientID }, clientInput);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteClient(Guid id)
        {
            var client = _context.Clients.SingleOrDefault(d => d.ClientID == id);

            if (client is null)
                return NotFound();

            client.Delete();

            _context.SaveChanges();

            return Ok(client);
        }

    }
}
