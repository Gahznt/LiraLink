using LiraLink.Models;
using Microsoft.EntityFrameworkCore;

namespace LiraLink.DataContext;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<ApportionmentsModel> Apportionments { get; set; }
    public DbSet<BondTypesModel> BondTypes { get; set; }
    public DbSet<ClientsModel> Clients { get; set; }
    public DbSet<CollaboratorsModel> Collaborators { get; set; }
    public DbSet<DepartmentsModel> Departments { get; set; }
    public DbSet<IndicatorsModel> Indicators { get; set; }
    public DbSet<IndicatorTypesModel> IndicatorTypes { get; set; }
    public DbSet<ProjectCollaborators> ProjectCollaborators { get; set; }
    public DbSet<ProjectIndicatorsModel> ProjectIndicators { get; set; }
    public DbSet<ProjectsModel> Projects { get; set; }
    public DbSet<UsersModel> Users { get; set; }
}
