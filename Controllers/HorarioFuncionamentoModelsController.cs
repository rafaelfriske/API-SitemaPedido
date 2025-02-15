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
    public class HorarioFuncionamentoModelsController : ControllerBase
    {
        private readonly MeuContexto _context;

        public HorarioFuncionamentoModelsController(MeuContexto context)
        {
            _context = context;
        }

        // GET: api/HorarioFuncionamentoModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HorarioFuncionamentoModel>>> GetHorarioFuncionamentoModel()
        {
            return await _context.HorarioFuncionamentoModel.ToListAsync();
        }

        // GET: api/HorarioFuncionamentoModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HorarioFuncionamentoModel>> GetHorarioFuncionamentoModel(int id)
        {
            var horarioFuncionamentoModel = await _context.HorarioFuncionamentoModel.FindAsync(id);

            if (horarioFuncionamentoModel == null)
            {
                return NotFound();
            }

            return horarioFuncionamentoModel;
        }

        // PUT: api/HorarioFuncionamentoModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHorarioFuncionamentoModel(int id, HorarioFuncionamentoModel horarioFuncionamentoModel)
        {
            if (id != horarioFuncionamentoModel.idHorarioFuncionamento)
            {
                return BadRequest();
            }

            _context.Entry(horarioFuncionamentoModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HorarioFuncionamentoModelExists(id))
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

        // POST: api/HorarioFuncionamentoModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HorarioFuncionamentoModel>> PostHorarioFuncionamentoModel(HorarioFuncionamentoModel horarioFuncionamentoModel)
        {
            _context.HorarioFuncionamentoModel.Add(horarioFuncionamentoModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHorarioFuncionamentoModel", new { id = horarioFuncionamentoModel.idHorarioFuncionamento }, horarioFuncionamentoModel);
        }

        // DELETE: api/HorarioFuncionamentoModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHorarioFuncionamentoModel(int id)
        {
            var horarioFuncionamentoModel = await _context.HorarioFuncionamentoModel.FindAsync(id);
            if (horarioFuncionamentoModel == null)
            {
                return NotFound();
            }

            _context.HorarioFuncionamentoModel.Remove(horarioFuncionamentoModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HorarioFuncionamentoModelExists(int id)
        {
            return _context.HorarioFuncionamentoModel.Any(e => e.idHorarioFuncionamento == id);
        }
    }
}
