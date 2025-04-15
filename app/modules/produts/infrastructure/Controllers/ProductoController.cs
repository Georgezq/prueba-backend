using Microsoft.AspNetCore.Mvc;
using Prueba.Application.UseCases;
using Prueba.Domain.Entities;

namespace Prueba.Infrastructure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductoController : ControllerBase
    {
        private readonly ListarProductos _listarProductos;
        private readonly ELiminarProducto _eLiminarProducto;
        private readonly CrearProducto _crearProducto;
        private readonly ActualizarProducto _actualizarProducto;


        public ProductoController(ListarProductos listarProductos, ELiminarProducto eLiminarProducto, CrearProducto crearProducto, ActualizarProducto actualizarProducto)
        {
            _listarProductos = listarProductos;
            _eLiminarProducto = eLiminarProducto;
            _crearProducto = crearProducto;
            _actualizarProducto = actualizarProducto;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllProductos()
        {
            try
            {
                var productos = await _listarProductos.ExecuteAsync();
                return Ok(productos);        
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error", error = ex.Message });                
            }
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
                await _eLiminarProducto.ExecuteAsync(id);
                return Ok();        
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error", error = ex.Message });                
            }
        }

    }

}