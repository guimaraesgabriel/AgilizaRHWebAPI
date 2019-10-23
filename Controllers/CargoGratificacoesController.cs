using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgilizaRH.Context;
using AgilizaRH.Models;
using AgilizaRH.Helper;

namespace AgilizaRH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoGratificacoesController : ControllerBase
    {
        private readonly AgilizaRHContext _context;
        Tools tool = new Tools();

        public CargoGratificacoesController(AgilizaRHContext context)
        {
            _context = context;
        }

        // GET: api/CargoGratificacoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CargoGratificacoes>>> GetCargoGratificacoes()
        {
            return await _context.CargoGratificacoes.ToListAsync();
        }

        // GET: api/CargoGratificacoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CargoGratificacoes>> GetCargoGratificacoes(int id)
        {
            var cargoGratificacoes = await _context.CargoGratificacoes.FindAsync(id);

            if (cargoGratificacoes == null)
            {
                return NotFound();
            }

            return cargoGratificacoes;
        }

        // PUT: api/CargoGratificacoes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCargoGratificacoes(int id, CargoGratificacoes cargoGratificacoes, int usuarioId)
        {
            if (id != cargoGratificacoes.Id)
            {
                return BadRequest();
            }

            _context.Entry(cargoGratificacoes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                tool.MontaLog(
                    2,
                    "Gratificação Id: " + cargoGratificacoes.Gratificacoes.Id
                    + " do Tipo: " + cargoGratificacoes.Gratificacoes.Tipo
                    + " do Cargo Id: " + cargoGratificacoes.Cargos.Id
                    + " Cargo: " + cargoGratificacoes.Cargos.Nome
                    + " editado com sucesso.",
                    usuarioId,
                    "EDITAR"
                );
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CargoGratificacoesExists(id))
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

        // POST: api/CargoGratificacoes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<CargoGratificacoes>> PostCargoGratificacoes(CargoGratificacoes cargoGratificacoes, int usuarioId)
        {
            _context.CargoGratificacoes.Add(cargoGratificacoes);
            await _context.SaveChangesAsync();

            tool.MontaLog(
                   2,
                   "Gratificação Id: " + cargoGratificacoes.Gratificacoes.Id
                   + " do Tipo: " + cargoGratificacoes.Gratificacoes.Tipo
                   + " do Cargo Id: " + cargoGratificacoes.Cargos.Id
                   + " Cargo: " + cargoGratificacoes.Cargos.Nome
                   + " adicionado com sucesso.",
                   usuarioId,
                   "ADICIONAR"
               );

            //return CreatedAtAction("GetCargoGratificacoes", new { id = cargoGratificacoes.Id }, cargoGratificacoes);
            return CreatedAtAction(nameof(GetCargoGratificacoes), new { id = cargoGratificacoes.Id }, cargoGratificacoes);
        }

        // DELETE: api/CargoGratificacoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CargoGratificacoes>> DeleteCargoGratificacoes(int id, int usuarioId)
        {
            var cargoGratificacoes = await _context.CargoGratificacoes.FindAsync(id);
            if (cargoGratificacoes == null)
            {
                return NotFound();
            }

            //_context.CargoGratificacoes.Remove(cargoGratificacoes);
            cargoGratificacoes.Ativo = !cargoGratificacoes.Ativo;
            await _context.SaveChangesAsync();

            if (cargoGratificacoes.Ativo)
            {
                tool.MontaLog(
                    2, 
                    "Gratificação Id: " + cargoGratificacoes.Gratificacoes.Id
                    + " do Tipo: " + cargoGratificacoes.Gratificacoes.Tipo 
                    + " do Cargo Id: " + cargoGratificacoes.Cargos.Id 
                    + " Cargo: " + cargoGratificacoes.Cargos.Nome 
                    + " ativado com sucesso.", 
                    usuarioId, 
                    "ATIVAR/DESATIVAR"
                );
            }
            else{
                tool.MontaLog(
                   2,
                   "Gratificação Id: " + cargoGratificacoes.Gratificacoes.Id
                   + " do Tipo: " + cargoGratificacoes.Gratificacoes.Tipo
                   + " do Cargo Id: " + cargoGratificacoes.Cargos.Id
                   + " Cargo: " + cargoGratificacoes.Cargos.Nome
                   + " desativado com sucesso.",
                   usuarioId,
                   "ATIVAR/DESATIVAR"
               );
            }

            return cargoGratificacoes;
        }

        private bool CargoGratificacoesExists(int id)
        {
            return _context.CargoGratificacoes.Any(e => e.Id == id);
        }
    }
}
