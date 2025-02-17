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
    public class TiposProdutoModelsController : ControllerBase
    {
        private readonly MeuContexto _context;

        public TiposProdutoModelsController(MeuContexto context)
        {
            _context = context;
        }

        // GET: api/TiposProdutoModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TiposProdutoModel>>> GetTiposProdutoModel()
        {
            return await _context.TiposProdutoModel.ToListAsync();
        }

        // GET: api/TiposProdutoModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TiposProdutoModel>> GetTiposProdutoModel(int id)
        {
            var tiposProdutoModel = await _context.TiposProdutoModel.FindAsync(id);

            if (tiposProdutoModel == null)
            {
                return NotFound();
            }

            return tiposProdutoModel;
        }

        // PUT: api/TiposProdutoModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTiposProdutoModel(int id, TiposProdutoModel tiposProdutoModel)
        {
            if (id != tiposProdutoModel.IdTipoProduto)
            {
                return BadRequest();
            }

            _context.Entry(tiposProdutoModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TiposProdutoModelExists(id))
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

        // POST: api/TiposProdutoModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TiposProdutoModel>> PostTiposProdutoModel(TiposProdutoModel tiposProdutoModel)
        {
            _context.TiposProdutoModel.Add(tiposProdutoModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTiposProdutoModel", new { id = tiposProdutoModel.IdTipoProduto }, tiposProdutoModel);
        }

        // DELETE: api/TiposProdutoModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTiposProdutoModel(int id)
        {
            var tiposProdutoModel = await _context.TiposProdutoModel.FindAsync(id);
            if (tiposProdutoModel == null)
            {
                return NotFound();
            }

            _context.TiposProdutoModel.Remove(tiposProdutoModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TiposProdutoModelExists(int id)
        {
            return _context.TiposProdutoModel.Any(e => e.IdTipoProduto == id);
        }
    }
}
