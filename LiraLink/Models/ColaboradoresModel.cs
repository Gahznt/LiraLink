using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiraLink.Models;

public class ColaboradoresModel
{
    [Key]
    public int id { get; set; }
    public int departamento_id { get; set; }
    [ForeignKey("departamento_id")]
    public DepartamentoModel Departamento { get; set; }
    public DateOnly data_admissao { get; set; }
    public int tipo_vinculo_id { get; set; }
    [ForeignKey("tipo_vinculo_id")]
    public TipoVinculoModel TipoVinculo { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime created_at { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime updated_at { get; set; }
}