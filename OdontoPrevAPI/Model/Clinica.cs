using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace OdontoPrevAPI.Model
{
    [Table("Api_Clinicas")]
    public class Clinica
    {

        private string _cnpj;
        
        [Key]
        // public int id { get; set; }
        public int id_clinica { get; set; }
        [Column("CNPJ")]
        [Display(Name = "CNPJ da clinica: ")]
        [Required(ErrorMessage = "CPF ou CNPJ Obrigatório", AllowEmptyStrings = false)]
        public string cnpj 
        {
            get => _cnpj;
            set
            {
                if (!Regex.IsMatch(value, @"^\d{14}$"))
                    throw new ArgumentException("CNPJ incorreto.");
         _cnpj = value;
            }
        }
    }
}
