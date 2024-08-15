using LiraLink.Filters;
using System.ComponentModel.DataAnnotations;

namespace LiraLink.DTOs;

public class ProjetoDto
{
    [Required(ErrorMessage = "Nome é obrigatório")]
    public string nome { get; set; }

    [Required(ErrorMessage = "cliente_id é obrigatório")]
    public int cliente_id { get; set; }

    [Required(ErrorMessage = "porcentagem_aplicavel_valor_remunerado é obrigatório")]
    [NonZeroFloat(ErrorMessage = "porcentagem_aplicavel_valor_remunerado deve ser diferente de zero")]
    public float porcentagem_aplicavel_valor_remunerado { get; set; }

    [Required(ErrorMessage = "porcentagem_aplicavel_participacao é obrigatório")]
    [NonZeroFloat(ErrorMessage = "porcentagem_aplicavel_participacao deve ser diferente de zero")]
    public float porcentagem_aplicavel_participacao { get; set; }

    [Required(ErrorMessage = "porcentagem_aplicavel_premio é obrigatório")]
    [NonZeroFloat(ErrorMessage = "porcentagem_aplicavel_premio deve ser diferente de zero")]
    public float porcentagem_aplicavel_premio { get; set; }

    [Required(ErrorMessage = "porcentagem_desempenho_deficiente é obrigatório")]
    [NonZeroFloat(ErrorMessage = "porcentagem_desempenho_deficiente deve ser diferente de zero")]
    public float porcentagem_desempenho_deficiente { get; set; }

    [Required(ErrorMessage = "porcentagem_processo_disciplinar é obrigatório")]
    [NonZeroFloat(ErrorMessage = "porcentagem_processo_disciplinar deve ser diferente de zero")]
    public float porcentagem_processo_disciplinar { get; set; }

    [Required(ErrorMessage = "porcentagem_ficha_advertencia é obrigatório")]
    [NonZeroFloat(ErrorMessage = "porcentagem_ficha_advertencia deve ser diferente de zero")]
    public float porcentagem_ficha_advertencia { get; set; }

    [Required(ErrorMessage = "valor_obra é obrigatório")]
    [NonZeroFloat(ErrorMessage = "valor_obra deve ser diferente de zero")]
    public float valor_obra { get; set; }

    [Required(ErrorMessage = "numero_fatura é obrigatório")]
    [NonZeroFloat(ErrorMessage = "numero_fatura deve ser diferente de zero")]
    public float numero_fatura { get; set; }
}