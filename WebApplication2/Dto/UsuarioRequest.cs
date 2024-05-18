using System.ComponentModel.DataAnnotations;
using WebApplication2.Model;

namespace WebApplication2.Dto {
	public class UsuarioRequest {
		[Required]
		public string Nome { get; set; }

		[Required]
		[EmailAddress]
		public string Email { get; set; }

		public string? Senha { get; set; }

		public Usuario toModel() => new() {
			Nome = this.Nome,
			Email = this.Email,
			Senha = this.Senha
		};
	}
}
