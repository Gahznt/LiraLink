using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiraLink.Models;

public class ProjetoModel
{
    [Key]
    public int id { get; set; }
    public required string nome { get; set; }
    public int cliente_id { get; set; }
    [ForeignKey("cliente_id")]
    public ClienteModel cliente { get; set; }
    public float porcentagem_aplicavel_valor_remunerado { get; set; }
    public float porcentagem_aplicavel_participacao { get; set; }
    public float porcentagem_aplicavel_premio { get; set; }
    public float porcentagem_desempenho_deficiente { get; set; }
    public float porcentagem_processo_disciplinar { get; set; }
    public float porcentagem_ficha_advertencia { get; set; }
    public float valor_obra { get; set; }
    public float numero_fatura { get; set; }
    public int criado_por { get; set; }
    [ForeignKey("criado_por")]
    public string? status { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime created_at { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime updated_at { get; set; }
}
