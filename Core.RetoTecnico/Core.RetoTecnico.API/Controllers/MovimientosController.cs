using Core.RetoTecnico.Application.Contracts.Persistence;
using Core.RetoTecnico.Domain.Entities;
using Core.RetoTecnico.Infrastructure.Context;
using Core.RetoTecnico.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace Core.RetoTecnico.API.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientosController : Controller
    {
        private readonly IMovimientosRepository _movimientoRepository;

        public MovimientosController(IMovimientosRepository movimientoRepository)
        {
            _movimientoRepository = movimientoRepository;
        }

        [HttpPost]
        [Route("crear")]
        public async Task<IActionResult> CrearMovimiento(Movimientos movimiento)
        {
            if (movimiento.Valor == (decimal)0 || movimiento.Saldo == (decimal)0)
            {
                return Ok("Saldo no Disponible");
            }

            if (_movimientoRepository != null)
            {
                try
                {
                    await _movimientoRepository.AddMovimiento(movimiento);
                }
                catch (ArgumentException ex)
                {
                    return BadRequest(ex.Message);
                }
                
            }

            return Ok("!Movimiento por valor de $USD " + movimiento.Valor + " creado exitosamente!");
        }

        [HttpGet]
        [Route("lista")]
        public async Task<ActionResult<IEnumerable<Movimientos>>> ListaMovimientos()
        {
            var movimientos = await _movimientoRepository.GetAllMovimientos();
            return Ok(movimientos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Movimientos>>> VerMovimiento(int id)
        {
            Movimientos movimiento = await _movimientoRepository.GetMovimientoById(id);
            if (movimiento == null)
            {
                return new List<Movimientos>();
            }

            return new List<Movimientos> { movimiento };
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarMovimiento(int id, Movimientos movimiento)
        {
            if (id != movimiento.Id)
            {
                return BadRequest();
            }

            try
            {
                await _movimientoRepository.UpdateMovimiento(movimiento);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovimientoExists(id))
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
        public async Task<IActionResult> EliminarMovimiento(int id)
        {
            var existMovimiento = await _movimientoRepository.GetMovimientoById(id);
            if (existMovimiento == null)
            {
                return NotFound();
            }

            await _movimientoRepository.DeleteMovimiento(id);
            return NoContent();
        }
        private bool MovimientoExists(int id)
        {
            bool blnMovimiento = true;
            var existMovimiento = _movimientoRepository.GetMovimientoById(id);

            if (existMovimiento == null)
            {
                blnMovimiento = false;
            }

            return blnMovimiento;
        }
    }
}
