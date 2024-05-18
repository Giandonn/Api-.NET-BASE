using Microsoft.EntityFrameworkCore;
using WebApplication2.Model;

public class DataContext : DbContext {

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

		optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=UsuariosDB;ConnectRetryCount=0");

		//optionsBuilder.UseSqlServer
		//   ("Password=root;Persist Security Info=True;User ID=root;Initial Catalog=UsuariosDB;Data Source=server");

	}



	public DbSet<Usuario> Usuarios { get; set; }


}