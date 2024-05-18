using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Model {
	public class Usuario {
		public Usuario() {
		}

		public Usuario(int Id,string nome, string Email, string Senha) {
			this.Id = Id;
			Nome = nome;
			this.Email = Email;
			this.Senha = Senha;
		}

		[Key]
		public int Id { get; set; }
		public string Nome { get; set; }

		public string Email { get; set; }

		public string? Senha { get; set; }
	}
}
