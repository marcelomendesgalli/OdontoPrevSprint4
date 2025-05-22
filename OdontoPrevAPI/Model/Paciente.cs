using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace OdontoPrevAPI.Model
{
    [Table("Api_Pacientes")]
    public class Paciente
    {
        private string _cpf_cnpj;
        private string _cep;
        private string _telefone;
        private string _email;
        private string _senha;

        [Key]
        // public int id { get; set; }
        public int id_paciente { get; set; }
        [Column("cpf_cnpj")]
        [Display(Name = "Cpf ou Cnpj do paciente: ")]
        [Required(ErrorMessage = "CPF ou CNPJ obrigatório", AllowEmptyStrings = false)]
        public string cpf_cnpj
        {
            get => _cpf_cnpj;
            set
            {
                if (string.IsNullOrWhiteSpace(value) ||
                    (value.Length != 11 && value.Length != 14) ||
                    !long.TryParse(value, out _))
                {
                    throw new ArgumentException("CPF/CNPJ inválido.");
                }
                _cpf_cnpj = value;
            }
        }
        
        [Column("nome")]
        [Display(Name = "Nome do paciente: ")]
        [Required(ErrorMessage = "Nome obrigatório", AllowEmptyStrings = false)]
        public string nome { get; set; } = string.Empty;
        [Column("endereco")]
        [Display(Name = "Endereco do paciente: ")]
        [Required(ErrorMessage = "Endereço obrigatório", AllowEmptyStrings = false)]
        
        
        public string endereco { get; set; } = string.Empty;

        [Column("cep")]
        [Display(Name = "CEP do paciente: ")]
        [Required(ErrorMessage = "CEP obrigatório", AllowEmptyStrings = false)]
        public string cep
        {
            get => _cep;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("CEP é obrigatório.");

                if (!Regex.IsMatch(value, @"^\d{5}-?\d{3}$"))
                    throw new ArgumentException("CEP inválido. Formato: 00000-000");

                _cep = value;
            }
        }
        
        [Display(Name = "Email do paciente: ")]
        [Required(ErrorMessage = "Email obrigatório", AllowEmptyStrings = false)]
        public string email
        {
            get => _email;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Email é obrigatório.");

                if (!new EmailAddressAttribute().IsValid(value))
                    throw new ArgumentException("Email inválido.");

                _email = value;
            }
        }
        
        [Display(Name = "Senha do paciente: ")]
        [Required(ErrorMessage = "Senha obrigatória", AllowEmptyStrings = false)]
        public string senha
        {
            get => _senha;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Senha é obrigatória.");

                _senha = value;
            }
        }
        private bool CpfValido(string valor) => valor.Length == 11 && valor.All(char.IsDigit);
        private bool CnpjValido(string valor) => valor.Length == 14 && valor.All(char.IsDigit);
    }
}
