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
    public class ItensPedidoModelsController : ControllerBase
    {
        private readonly MeuContexto _context;

        public ItensPedidoModelsController(MeuContexto context)
        {
            _context = context;
        }

        // GET: api/ItensPedidoModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItensPedidoModel>>> GetItensPedidoModel()
        {
            return await _context.ItensPedidoModel.ToListAsync();
        }

        // GET: api/ItensPedidoModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItensPedidoModel>> GetItensPedidoModel(int id)
        {
            var itensPedidoModel = await _context.ItensPedidoModel.FindAsync(id);

            if (itensPedidoModel == null)
            {
                return NotFound();
            }

            return itensPedidoModel;
        }

        // PUT: api/ItensPedidoModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItensPedidoModel(int id, ItensPedidoModel itensPedidoModel)
        {
            if (id != itensPedidoModel.IdPedido)
            {
                return BadRequest();
            }

            _context.Entry(itensPedidoModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItensPedidoModelExists(id))
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

        // POST: api/ItensPedidoModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ItensPedidoModel>> PostItensPedidoModel(ItensPedidoModel itensPedidoModel)
        {
            _context.ItensPedidoModel.Add(itensPedidoModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItensPedidoModel", new { id = itensPedidoModel.IdPedido }, itensPedidoModel);
        }

        // DELETE: api/ItensPedidoModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItensPedidoModel(int id)
        {
            var itensPedidoModel = await _context.ItensPedidoModel.FindAsync(id);
            if (itensPedidoModel == null)
            {
                return NotFound();
            }

            _context.ItensPedidoModel.Remove(itensPedidoModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItensPedidoModelExists(int id)
        {
            return _context.ItensPedidoModel.Any(e => e.IdPedido == id);
        }
    }
}
