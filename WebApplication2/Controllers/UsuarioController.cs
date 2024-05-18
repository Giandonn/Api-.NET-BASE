using Microsoft.AspNetCore.Mvc;
using WebApplication2.Dto;
using WebApplication2.Model;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication2.Controllers {
	[ApiController]
	[Route("/api/v1.0/usuarios")]
	public class UsuarioController : ControllerBase {
		private readonly DataContext _dataContext;

		public UsuarioController(DataContext dataContext) {
			_dataContext = dataContext;
		}

		[HttpPost]
		public ActionResult<Usuario> Post([FromBody] UsuarioRequest usuarioRequest) {
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var usuario = usuarioRequest.toModel();
			_dataContext.Usuarios.Add(usuario);
			try {
				_dataContext.SaveChanges();
				return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, usuario);
			}
			catch (Exception ex) {
				return StatusCode(500, $"Erro ao salvar alterações: {ex.InnerException.Message}");
			}
		}

		[HttpGet("{id:int}")]
		public ActionResult<Usuario> GetById(int id) {
			var usuario = _dataContext.Usuarios.Find(id);
			if (usuario == null)
				return NotFound();

			return usuario;
		}

		[HttpPut("{id:int}")]
		public ActionResult<Usuario> Put(int id, [FromBody] Usuario usuario) {
			if (id != usuario.Id)
				return BadRequest("ID in URL does not match ID in body.");

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var existingUsuario = _dataContext.Usuarios.Find(id);
			if (existingUsuario == null)
				return NotFound();

			_dataContext.Entry(existingUsuario).CurrentValues.SetValues(usuario);

			try {
				_dataContext.SaveChanges();
				return NoContent();
			}
			catch (Exception ex) {
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpDelete("{id:int}")]
		public ActionResult Delete(int id) {
			var usuario = _dataContext.Usuarios.Find(id);
			if (usuario == null) {
				return NotFound(new { message = "User ID not found." });
			}

			_dataContext.Usuarios.Remove(usuario);
			try {
				_dataContext.SaveChanges();
				return NoContent();
			}
			catch (Exception ex) {
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}
	}
}
