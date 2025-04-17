using Microsoft.AspNetCore.Mvc;
using Prueba.Application.UseCases;
using Prueba.Domain.Entities;
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
            var result = await _listarProductosPaginados.EjecutarAsync(filtro);
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateProducto(Producto producto)
        {
                if (producto == null)
                    return BadRequest("Datos invalidos");

                var createProducto = await _crearProducto.ExecuteAsync(producto);
                return CreatedAtAction(nameof(CreateProducto), new { id = createProducto.Id }, createProducto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] Producto producto){
            if(id != producto.Id)
                return BadRequest("Las id no coinciden");

            var productoUpdated = await _actualizarProducto.ExecuteAsync(producto);
            return Ok(productoUpdated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductos(int id)
        {
            try
            {
                await _eliminarProducto.ExecuteAsync(id);
                return Ok();        
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error", error = ex.Message });                
            }
        }

    }

}