using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_asmontech.Models;

namespace api_asmontech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoModelsController : ControllerBase
    {
        private readonly MeuContexto _context;

        public PedidoModelsController(MeuContexto context)
        {
            _context = context;
        }

        // GET: api/PedidoModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedidoModel>>> GetPedidoModel()
        {;
            var pedidoModel = await _context.PedidoModel
                .Include(p => p.Itens).ToListAsync();
            return pedidoModel;
        }

        // GET: api/PedidoModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PedidoModel>> GetPedidoModel(int id)
        {
            // Usa o método Include para carregar os itens do pedido
            var pedidoModel = await _context.PedidoModel
                .Include(p => p.Itens) // Inclui os itens do pedido
                .FirstOrDefaultAsync(p => p.IdCliente == id);

            if (pedidoModel == null)
            {
                return NotFound();
            }

            return pedidoModel;
        }

        // PUT: api/PedidoModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedidoModel(int id, PedidoModel pedidoModel)
        {
            if (id != pedidoModel.IdPedido)
            {
                return BadRequest();
            }

            _context.Entry(pedidoModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoModelExists(id))
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

        // POST: api/PedidoModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PedidoModel>> PostPedidoModel(PedidoModel pedidoModel)
        {
            // Adiciona o pedido ao contexto
            _context.PedidoModel.Add(pedidoModel);

            // Itera sobre os itens do pedido e adiciona cada item ao contexto
            foreach (var item in pedidoModel.Itens)
            {
                _context.ItensPedidoModel.Add(item);
            }

            // Salva as alterações no banco de dados
            await _context.SaveChangesAsync();

            // Retorna o pedido criado
            return CreatedAtAction("GetPedidoModel", new { id = pedidoModel.IdPedido }, pedidoModel);
        }

        // DELETE: api/PedidoModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedidoModel(int id)
        {
            var pedidoModel = await _context.PedidoModel.FindAsync(id);
            if (pedidoModel == null)
            {
                return NotFound();
            }

            _context.PedidoModel.Remove(pedidoModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PedidoModelExists(int id)
        {
            return _context.PedidoModel.Any(e => e.IdPedido == id);
        }
    }
}
