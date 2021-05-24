using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SicWEB.Models;

namespace SicWEB.Data {
  public class ApplicationDbContext : IdentityDbContext {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) {
    }
    public DbSet<SicWEB.Models.FielDepositario> FielDepositario { get; set; }
    public DbSet<SicWEB.Models.CitacaoCarta> CitacaoCarta { get; set; }
    public DbSet<SicWEB.Models.ExpedicaoNovoMandado> ExpedicaoNovoMandado { get; set; }
    public DbSet<SicWEB.Models.Malote> Malote { get; set; }
    public DbSet<SicWEB.Models.InformarEndereco> InformarEndereco { get; set; }
    public DbSet<SicWEB.Models.InformarOrgao> InformarOrgao { get; set; }
    public DbSet<SicWEB.Models.ConversaoExecucao> ConversaoExecucao { get; set; }
    public DbSet<SicWEB.Models.JuntadaTermoCessao> JuntadaTermoCessao { get; set; }
    public DbSet<SicWEB.Models.ConversaoExecucaoItau> ConversaoExecucaoItau { get; set; }
    public DbSet<SicWEB.Models.CitacaoEdital> CitacaoEdital { get; set; }
    public DbSet<SicWEB.Models.ExpedicaoMandadoCitacao> ExpedicaoMandadoCitacao { get; set; }
  }
}
