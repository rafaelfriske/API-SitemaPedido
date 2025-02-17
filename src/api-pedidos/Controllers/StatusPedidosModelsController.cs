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
    public class StatusPedidosModelsController : ControllerBase
    {
        private readonly MeuContexto _context;

        public StatusPedidosModelsController(MeuContexto context)
        {
            _context = context;
        }

        // GET: api/StatusPedidosModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusPedidosModel>>> GetStatusPedidosModel()
        {
            return await _context.StatusPedidosModel.ToListAsync();
        }

        // GET: api/StatusPedidosModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StatusPedidosModel>> GetStatusPedidosModel(short id)
        {
            var statusPedidosModel = await _context.StatusPedidosModel.FindAsync(id);

            if (statusPedidosModel == null)
            {
                return NotFound();
            }

            return statusPedidosModel;
        }

        // PUT: api/StatusPedidosModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatusPedidosModel(short id, StatusPedidosModel statusPedidosModel)
        {
            if (id != statusPedidosModel.IdStatus)
            {
                return BadRequest();
            }

            _context.Entry(statusPedidosModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusPedidosModelExists(id))
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

        // POST: api/StatusPedidosModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StatusPedidosModel>> PostStatusPedidosModel(StatusPedidosModel statusPedidosModel)
        {
            _context.StatusPedidosModel.Add(statusPedidosModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStatusPedidosModel", new { id = statusPedidosModel.IdStatus }, statusPedidosModel);
        }

        // DELETE: api/StatusPedidosModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatusPedidosModel(short id)
        {
            var statusPedidosModel = await _context.StatusPedidosModel.FindAsync(id);
            if (statusPedidosModel == null)
            {
                return NotFound();
            }

            _context.StatusPedidosModel.Remove(statusPedidosModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StatusPedidosModelExists(short id)
        {
            return _context.StatusPedidosModel.Any(e => e.IdStatus == id);
        }
    }
}
