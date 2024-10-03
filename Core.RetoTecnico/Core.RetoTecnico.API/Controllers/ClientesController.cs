using Core.RetoTecnico.Application.Contracts.Persistence;
using Core.RetoTecnico.Domain.Entities;
using Core.RetoTecnico.Infrastructure.Context;
using Core.RetoTecnico.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Core.RetoTecnico.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : Controller
    {
        private readonly IClientesRepository _clienteRepository;

        public ClientesController(IClientesRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpPost]
        [Route("crear")]
        public async Task<IActionResult> CrearCliente(Clientes cliente)
        {
            if (_clienteRepository != null) 
            {
                await _clienteRepository.AddCliente(cliente);
            }

            return Ok("!Cliente con identificacion " + cliente.Identificacion + " creado exitosamente!");

        }

        [HttpGet]
        [Route("lista")]
        public async Task<ActionResult<IEnumerable<Clientes>>> ListaClientes()
        {
            var clientes = await _clienteRepository.GetAllClientes();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Clientes>>> VerCliente(int id)
        {
            Clientes cliente = await _clienteRepository.GetClienteById(id);
            if (cliente == null)
            {
                return new List<Clientes>();
            }

            return new List<Clientes> { cliente };
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarCliente(int id, Clientes cliente)
        {
            if (id != cliente.Id)
            {
                return BadRequest();
            }

            try
            {
                await _clienteRepository.UpdateCliente(cliente);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
                
            }
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarCliente(int id)
        {
            var existsCliente = await _clienteRepository.GetClienteById(id);
            if (existsCliente == null) 
            {
                return NotFound();
            }

            await _clienteRepository.DeleteCliente(id);
            return NoContent();
        }

        private bool ClienteExists(int id)
        {
            bool blnCliente = true;
            var existCliente = _clienteRepository.GetClienteById(id);

            if (existCliente == null)
            {
                blnCliente = false;
            }

            return blnCliente;
        }

    }
}
