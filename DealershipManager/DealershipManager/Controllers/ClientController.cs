using DealershipManager.Dtos;
using DealershipManager.Models;
using DealershipManager.Services;
using Microsoft.AspNetCore.Mvc;

namespace DealershipManager.Controllers
{
     [ApiController]
     public class ClientController : ControllerBase
     {
          private readonly IClientService _clientService;

          public ClientController(IClientService clientService)
          {
               _clientService = clientService;
          }

          //Add Client: POST /clients

          [HttpPost]
          [Route("clients")]

          public IActionResult Add(AddClientDto client)
          {
               _clientService.Add(client);

               return Ok();
          }

          //Get all clients: GET /clients

          [HttpGet]
          [Route("clients")]

          public IActionResult GetAll()
          {
               var result = _clientService.GetAll();

               return Ok(result);
          }
     }
}
