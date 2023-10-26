using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApiCliente.Controllers
{
    [Route("api/client")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        //private ILoggerManager _loggerManager;
        private IRepositoryWrapper _repositoryWrapper;
        private IMapper _mapper;

        public ClientController(
            //ILoggerManager loggerManager,
            IRepositoryWrapper repositoryWrapper,
            IMapper mapper)
        {
            //_loggerManager = loggerManager;
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllClients()
        {
            try
            {
                var client = _repositoryWrapper.Client.GetAllClients();
               // _loggerManager.LogInfo($"Returned all client from database.");

                var clientResult = _mapper.Map<IEnumerable<ClientDto>>(client);
                return Ok(clientResult);
            }
            catch (Exception ex)
            {
               // _loggerManager.LogError($"Something went wrong inside GetAllClient action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "ClientById")]
        public IActionResult GetClientById(Guid id)
        {
            try
            {
                var client = _repositoryWrapper.Client.GetClientById(id);

                if (client is null)
                {
                  //  _loggerManager.LogError($"Owner with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                  //  _loggerManager.LogInfo($"Returned owner with id: {id}");
                    var clientResult = _mapper.Map<ClientDto>(client);
                    return Ok(clientResult);
                }
            }
            catch (Exception ex)
            {
               // _loggerManager.LogError($"Something went wrong inside GetOwnerById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/account")]
        public IActionResult GetClientWhitDetails(Guid id)
        {
            try
            {
                var client = _repositoryWrapper.Client.GetClientWhitDetails(id);

                if (client is null)
                {
                   // _loggerManager.LogError($"Owner with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                   // _loggerManager.LogInfo($"Returned owner with details for id: {id}");

                    var clientResult = _mapper.Map<ClientDto>(client);
                    return Ok(clientResult);
                }
            }
            catch (Exception ex)
            {
               // _loggerManager.LogError($"Something went wrong inside GetOwnerWithDetails action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateClient([FromBody] ClientForCreationDto client)
        {
            try
            {
                if (client is null)
                {
                  //  _loggerManager.LogError("Owner object sent from client is null.");
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                  //  _loggerManager.LogError("Invalid owner object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var clientEntity = _mapper.Map<Client>(client);
                _repositoryWrapper.Client.CreateClient(clientEntity);
                _repositoryWrapper.Save();

                var createdClient = _mapper.Map<ClientDto>(clientEntity);
                return CreatedAtRoute("ClientById", new { id = createdClient.ClientId }, createdClient);
            }
            catch (Exception ex)
            {
               // _loggerManager.LogError($"Something went wrong inside CreateOwner action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateClient(Guid id, [FromBody]ClientForUpdateDto client)
        {
            try
            {
                if (client is null)
                {
                  //  _loggerManager.LogError("Client object sent from client is null.");
                    return BadRequest("Client object is null");
                }
                if (!ModelState.IsValid)
                {
                  //  _loggerManager.LogError("Invalid client object sent by client.");
                    return BadRequest("Invalid model object");
                }

                var clientEntity = _repositoryWrapper.Client.GetClientById(id);
                if(clientEntity is null)
                {
                  //  _loggerManager.LogError($"Client with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(client, clientEntity);
                _repositoryWrapper.Client.UpdateClient(clientEntity);
                _repositoryWrapper.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
              //  _loggerManager.LogError($"Something went wrong inside UpdateClient action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteClient(Guid id)
        {
            try
            {
                var client = _repositoryWrapper.Client.GetClientById(id);
                if (client is null)
                {
                 //   _loggerManager.LogError($"Client with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                if (_repositoryWrapper.Account.AccountsByClient(id).Any())
                {
                   // _loggerManager.LogError($"Cannot delete owner with id: {id}. It has related accounts. Delete those accounts first");
                    return BadRequest("Cannot delete owner. It has related accounts. Delete those accounts first");
                }

                _repositoryWrapper.Client.DeleteClient(client);
                _repositoryWrapper.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
               // _loggerManager.LogError($"Something went wrong inside DeleteOwner action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
