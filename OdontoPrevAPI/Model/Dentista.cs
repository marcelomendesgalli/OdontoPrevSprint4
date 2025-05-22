using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

namespace OdontoPrevAPI.Model
{
    [Table("Api_Dentistas")]
    public class Dentista
    {
        private string _cpf;
        private string _numero_cro;
        private string _telefone;
        private string _email;
        
        [Key]
        // public int id { get; set; }
        public int id_dentista { get; set; }
        [Column("cpf_cnpj")]

        [Display(Name = "CPF do dentista: ")]
        [Required(ErrorMessage = "CPF Obrigatório", AllowEmptyStrings = false)]
        public string cpf
         {
            get => _cpf;
            set
            {
                if (!Regex.IsMatch(value, @"^\d{11}|\d{14}$"))
                    throw new ArgumentException("CPF/CNPJ inválido.");
         _cpf = value;
            }
         }
        
        [Display(Name = "Numero_cro do dentista: ")]
        [Required(ErrorMessage = "Numero CRO Obrigatório", AllowEmptyStrings = false)]
        public string numero_cro
        {
            get => _numero_cro;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Número CRO inválido.");
         _numero_cro = value;
            }
         }

        [Column("nome")]
        [Display(Name = "Nome do dentista: ")]
        [Required(ErrorMessage = "Nome Obrigatório", AllowEmptyStrings = false)]
        public string nome { get; set; }

        [Column("telefone ")]

        [Display(Name = "Telefone do dentista: ")]
        [Required(ErrorMessage = "Telefone Obrigatório", AllowEmptyStrings = false)]
        public string telefone 
        {
            get => _telefone;
            set
            {
                if (!Regex.IsMatch(value, @"^(9|1)\d{10}$"))
                    throw new ArgumentException("Telefone inválido.");
         _telefone = value;
            }
        }
        
        [Column("email  ")]
        [Display(Name = "Email do dentista: ")]
        [Required(ErrorMessage = "Email Obrigatório", AllowEmptyStrings = false)]
        public string email 
         {
            get => _email;
            set
            {
                if (!value.Contains("@"))
                    throw new ArgumentException("E-mail inválido.");
         _email = value;
            }
         }
        
    }
}
