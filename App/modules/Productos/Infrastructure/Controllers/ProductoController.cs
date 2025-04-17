using Microsoft.AspNetCore.Mvc;
using Prueba.Application.UseCases;
using Prueba.Domain.DTO;
using Prueba.Domain.Entities;
using Prueba.Domain.Exceptions;
using Prueba.Shared;

namespace Prueba.Infraestructure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductoController : ControllerBase
    {
        private readonly ListarProductos _listarProductos;
        private readonly EliminarProducto _eliminarProducto;
        private readonly CrearProducto _crearProducto;
        private readonly ActualizarProducto _actualizarProducto;
        private readonly ListarProductosPaginados _listarProductosPaginados;


        public ProductoController(ListarProductos listarProductos, EliminarProducto eliminarProducto, CrearProducto crearProducto, ActualizarProducto actualizarProducto, ListarProductosPaginados listarProductosPaginados)
        {
            _listarProductos = listarProductos;
            _eliminarProducto = eliminarProducto;
            _crearProducto = crearProducto;
            _actualizarProducto = actualizarProducto;
            _listarProductosPaginados = listarProductosPaginados;
        }
        

        [HttpGet]
        public async Task<ActionResult<PageList<Producto>>> GetProductos([FromQuery] ProductoFilter filtro)
        {
            try
            {
                var result = await _listarProductosPaginados.EjecutarAsync(filtro);
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { message = "Error interno", error = ex.Message });
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateProducto(Producto producto)
        {
            try
            {
                if (producto == null)
                    return BadRequest("Datos invalidos");

                var createProducto = await _crearProducto.ExecuteAsync(producto);
                return CreatedAtAction(nameof(CreateProducto), new { id = createProducto.Id }, createProducto);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch(Exception ex){
                return StatusCode(500, new { message = "Error interno", error = ex.Message });
            }  
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProducto(int id, [FromBody] ActualizarProductoDTO producto){
            try
            {
                if(id != producto.Id)
                return BadRequest("Las id no coinciden");

                var productoUpdated = await _actualizarProducto.ExecuteAsync(producto);
                return Ok(productoUpdated);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch(NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { message = "Error interno", error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductos(int id)
        {
            try
            {
                await _eliminarProducto.ExecuteAsync(id);
                return Ok();        
            }
            catch(NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error", error = ex.Message });                
            }
        }

    }

}