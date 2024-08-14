using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiraLink.Models;

public class IndicadoresModel
{
    [Key]
    public int id { get; set; }
    public int tipo_indicador_id { get; set; }
    [ForeignKey("tipo_indicador_id")]
    public required TipoIndicadorModel TipoIndicador { get; set; }
    public required string nome { get; set; }
}
