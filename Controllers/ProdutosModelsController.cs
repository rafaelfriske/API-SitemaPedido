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
    public class ProdutosModelsController : ControllerBase
    {
        private readonly MeuContexto _context;

        public ProdutosModelsController(MeuContexto context)
        {
            _context = context;
        }

        // GET: api/ProdutosModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutosModel>>> GetProdutosModel()
        {
            return await _context.ProdutosModel.ToListAsync();
        }

        // GET: api/ProdutosModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutosModel>> GetProdutosModel(int id)
        {
            var produtosModel = await _context.ProdutosModel.FindAsync(id);

            if (produtosModel == null)
            {
                return NotFound();
            }

            return produtosModel;
        }

        // PUT: api/ProdutosModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProdutosModel(int id, ProdutosModel produtosModel)
        {
            if (id != produtosModel.idProduto)
            {
                return BadRequest();
            }

            _context.Entry(produtosModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutosModelExists(id))
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

        // POST: api/ProdutosModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProdutosModel>> PostProdutosModel(ProdutosModel produtosModel)
        {
            _context.ProdutosModel.Add(produtosModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProdutosModel", new { id = produtosModel.idProduto }, produtosModel);
        }

        // DELETE: api/ProdutosModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProdutosModel(int id)
        {
            var produtosModel = await _context.ProdutosModel.FindAsync(id);
            if (produtosModel == null)
            {
                return NotFound();
            }

            _context.ProdutosModel.Remove(produtosModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProdutosModelExists(int id)
        {
            return _context.ProdutosModel.Any(e => e.idProduto == id);
        }
    }
}
