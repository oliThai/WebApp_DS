using Microsoft.EntityFrameworkCore;
using WebApp_DS.Entidades;

namespace WebApp_DS
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> opt): base(opt) 
        {
        }

        public DbSet<Produtos> PRODUTOS { get; set; }
        public DbSet<Categoria> CATEGORIAS{ get; set; }
        public DbSet<PermissaoEntidade> PERMISSAO{ get; set; }

    }
}
