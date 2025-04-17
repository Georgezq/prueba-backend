using Microsoft.AspNetCore.Mvc;
using Prueba.Application.UseCases;
using Prueba.Domain.Entities;
using Prueba.Shared;

namespace Prueba.Infraestructure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class BodegaController(ListarBodegas listarBodegas, EliminarBodega eliminarBodega, CrearBodega crearBodega, ActualizarBodega actualizarBodega, ListarBodegasPaginacion listarBodegasPaginacion) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllBodega()
        {
            try
            {
                var bodega = await listarBodegas.ExecuteAsync();
                return Ok(bodega);        
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error", error = ex.Message });                
            }
        }

        [HttpGet("pagination")]
        public async Task<ActionResult<PageList<Bodega>>> GetBodega([FromQuery] BodegaFilter filtro)
        {
            var result = await listarBodegasPaginacion.EjecutarAsync(filtro);
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateBodega(Bodega bodega)
        {
                if (bodega== null)
                    return BadRequest("Datos invalidos");

                var createBodega = await crearBodega.ExecuteAsync(bodega);
                return CreatedAtAction(nameof(createBodega), new { id = createBodega.Id }, createBodega);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBodega(int id, [FromBody] Bodega bodega)
        {
            try
            {
            if (id != bodega.Id)
                return BadRequest("Las id no coinciden");

            var bodegaUpdated = await actualizarBodega.ExecuteAsync(bodega);
            return Ok(bodegaUpdated);
            }
            catch (Exception ex)
            {
            return StatusCode(500, new { message = "Error", error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBodega(int id)
        {
            try
            {
                await eliminarBodega.ExecuteAsync(id);
                return Ok();        
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error", error = ex.Message });                
            }
        }


    }
}
