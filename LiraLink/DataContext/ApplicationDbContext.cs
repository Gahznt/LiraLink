using LiraLink.Models;
using Microsoft.EntityFrameworkCore;

namespace LiraLink.DataContext;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<RateiosModel> Rateios { get; set; }
    public DbSet<TipoVinculoModel> TipoVinculo { get; set; }
    public DbSet<ClienteModel> Cliente { get; set; }
    public DbSet<ColaboradoresModel> Colaboradores { get; set; }
    public DbSet<DepartamentoModel> Departamentos { get; set; }
    public DbSet<IndicadoresModel> Indicadores { get; set; }
    public DbSet<TipoIndicadorModel> TipoIndicadores { get; set; }
    public DbSet<ProjetoColaboradores> ProjetoColaboradores { get; set; }
    public DbSet<IndicadoresProjetoModel> ProjetoIndicadores { get; set; }
    public DbSet<ProjetoModel> Projetos { get; set; }
    public DbSet<UsariosModel> Usuarios { get; set; }
    public DbSet<CargoModel> Cargos { get; set; }
}
