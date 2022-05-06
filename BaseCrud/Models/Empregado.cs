using System.ComponentModel.DataAnnotations;

namespace BaseCrud.Models
{
    public class Empregado
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nome do Empregado")]
        public string Nome { get; set; }
        public string Designacao { get; set; }
        [DataType(DataType.MultilineText)]
        public string Endereco { get; set; }
        public DateTime? EmpregadoEm { get; set; }
    }
}
