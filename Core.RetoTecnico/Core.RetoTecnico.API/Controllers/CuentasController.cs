using Core.RetoTecnico.Application.Contracts.Persistence;
using Core.RetoTecnico.Domain.Entities;
using Core.RetoTecnico.Infrastructure.Context;
using Core.RetoTecnico.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Core.RetoTecnico.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentasController : Controller
    {
        private readonly ICuentasRepository _cuentaRepository;

        public CuentasController(ICuentasRepository cuentaRepository)
        {
            _cuentaRepository = cuentaRepository;
        }

        [HttpPost]
        [Route("crear")]
        public async Task<IActionResult> CrearCuenta(Cuentas cuenta)
        {
            if (_cuentaRepository != null)
            {
                await _cuentaRepository.AddCuenta(cuenta);
            }

            return Ok("!Cuenta con numero " + cuenta.Numero + " creada exitosamente!");
        }

        [HttpGet]
        [Route("lista")]
        public async Task<ActionResult<IEnumerable<Cuentas>>> ListaCuentas()
        {
            var cuentas = await _cuentaRepository.GetAllCuentas();
            return Ok(cuentas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Cuentas>>> VerCuenta(int id)
        {
            Cuentas cuenta = await _cuentaRepository.GetCuentaById(id);
            if (cuenta == null)
            {
                return new List<Cuentas>();
            }

            return new List<Cuentas> { cuenta };
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarCuenta(int id, Cuentas cuenta)
        {
            if (id != cuenta.Id)
            {
                return BadRequest();
            }

            try
            {
                await _cuentaRepository.UpdateCuenta(cuenta);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CuentaExists(id))
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
        public async Task<IActionResult> EliminarCuenta(int id)
        {
            var existCuenta = await _cuentaRepository.GetCuentaById(id);
            if (existCuenta == null)
            {
                return NotFound();
            }

            await _cuentaRepository.DeleteCuenta(id);
            return NoContent();
        }

        private bool CuentaExists(int id)
        {
            bool blnCuenta = true;
            var existCuenta = _cuentaRepository.GetCuentaById(id);

            if (existCuenta == null)
            {
                blnCuenta = false;
            }

            return blnCuenta;
        }

    }
}
