using Core.RetoTecnico.Application.Contracts.Persistence;
using Core.RetoTecnico.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Core.RetoTecnico.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportesController : Controller
    {
        private readonly IMovimientosRepository _movimientosRepository;

        public ReportesController(IMovimientosRepository movimientosRepository)
        {
            _movimientosRepository = movimientosRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GenerarEstadoCuenta(RequestEstadoCuenta objParametros)
        {
            IEnumerable<EstadoCuenta> result = await _movimientosRepository.ReporteEstadoCuenta(objParametros);
            
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
