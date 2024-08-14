using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiraLink.Models;

public class IndicadoresProjetoModel
{
    [Key]
    public int id { get; set; }
    public int indicador_id { get; set; }
    [ForeignKey("indicador_id")]
    public required IndicadoresModel Indicadores { get; set; }
    public int projeto_id { get; set; }
    [ForeignKey("projeto_id")]
    public required ProjetoModel Projeto { get; set; }
    public float percentual {  get; set; }
}
