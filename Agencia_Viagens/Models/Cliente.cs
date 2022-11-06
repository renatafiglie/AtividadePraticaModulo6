using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Agencia_Viagens.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        public int ClienteId { get; set; }

        [Display(Name = "Nome")]
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }


        [Display(Name = "Data de Nascimento")]
        [Required]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Origem")]
        [Required]
        public string Origem { get; set; }


        [Display(Name = "Destino")]
        [Required]
        public string Destino { get; set; }

        [Display(Name = "Data Ida")]
        [Required]
        public DateTime DataIda { get; set; }

        [Display(Name = "Data Volta")]
        [Required]
        public DateTime DataVolta { get; set; }


    }
   
}
