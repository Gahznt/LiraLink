using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiraLink.Models;

public class ProjetoColaboradores
{
    [Key]
    public int id { get; set; }
    public int colaborador_id { get; set; }
    [ForeignKey("colaborador_id")]
    public required ColaboradoresModel Colaboradores{ get; set; }
    public int projeto_id { get; set; }
    [ForeignKey("projeto_id")]
    public required ProjetoModel Projeto { get; set; }
    public required string estado_participacao { get; set; }
    public int performance { get; set; }
    public int quantidade_processos_disciplinar { get; set; }
    public int quantidade_ficha_advertencia { get; set; }
}
