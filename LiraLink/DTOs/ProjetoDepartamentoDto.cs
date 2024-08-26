using System.ComponentModel.DataAnnotations;

namespace LiraLink.DTOs;

public class ProjetoDepartamentoDto
{
    [Required(ErrorMessage = "The field projeto_id is required")]
    public int projeto_id { get; set; }

    [Required(ErrorMessage = "The field departamento_id is required")]
    public int departamento_id { get; set; }

    [Required(ErrorMessage = "The field distribuicao_valor_participacao is required")]
    public float distribuicao_valor_participacao { get; set; }

    [Required(ErrorMessage = "The field distribuicao_valor_premio is required")]
    public float distribuicao_valor_premio { get; set; }
}
