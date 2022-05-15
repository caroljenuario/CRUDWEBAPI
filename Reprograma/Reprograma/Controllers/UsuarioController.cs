using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reprograma.Data;

namespace Reprograma.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly Contexto _context;
        public UsuarioController (Contexto context) {
            _context = context; 
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> ListarTodosOsUsuarios()
        {
            return Ok(await _context.Usuarios.ToListAsync());
        }
   

        [HttpGet("{email, nome}")]
        public async Task<ActionResult<List<Usuario>>> Listar(string nome, string email)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(e => e.Nome == nome && e.Email == email);
            if (usuario == null)
                return BadRequest("Não encontrado");
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<List<Usuario>>> Adicionar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return Ok(usuario);
        }

        [HttpPut]
        public async Task<ActionResult<List<Usuario>>> Atualizar(Usuario request)
        {
            var usuario = await _context.Usuarios.FindAsync(request.Id);
            if (usuario == null)
                return BadRequest("Não encontrado");
            usuario.Nome = request.Nome;
            usuario.Email = request.Email;
            await _context.SaveChangesAsync();
            return Ok(usuario);
        }

        [HttpDelete("{email}")]
        public async Task<ActionResult<List<Usuario>>> Deletar(string email)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(e => e.Email == email);
            if (usuario == null)
                return BadRequest("Não encontrado");
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return Ok(usuario);
        }

    }
}
