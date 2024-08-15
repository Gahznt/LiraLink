using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiraLink.Models;

public class ProjetoDepartamentosModel
{
    [Key]
    public int id { get; set; }
    public int projeto_id { get; set; }
    [ForeignKey("projeto_id")]
    public required ProjetoModel projeto { get; set; }
    public int departamento_id { get; set; }
    [ForeignKey("departamento_id")]
    public required DepartamentoModel departamento { get; set; }
    public float distribuicao_valor_participacao { get; set; }
    public float distribuicao_valor_premio { get; set; }
}
