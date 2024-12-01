using GestaoProduto.Data.Mappings;
using GestaoProduto.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


namespace GestaoProduto.Data.Contexto
{
    public class AppDBContext : DbContext
    {
        public DbSet<Produto> Produto { get; set; }
        public AppDBContext
            (DbContextOptions<AppDBContext> options) : base(options)
        {

        }
    }
}
