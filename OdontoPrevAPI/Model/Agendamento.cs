using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OdontoPrevAPI.Model
{
    [Table("Api_Agendamentos")]
    public class Agendamento
    {
        [Key]
        // public int id { get; set; }
        public int id_agendamento { get; set; }

        [Column("data_agendamento ")]
        [Display(Name = "data do agendamento: ")]
        [Required(ErrorMessage = "Data de Agendamento obrigatória", AllowEmptyStrings = false)]
        public DateTime data_agendamento { get; set; }


        [Column("data_atendimento ")]
        [Display(Name = "data do atendimento: ")]
        [Required(ErrorMessage = "Data do atendimento obrigatória", AllowEmptyStrings = false)]
        public DateTime data_atendimento { get; set; }

        [Column("id_paciente ")]
        [Display(Name = "id do paciente: ")]
        public int id_paciente { get; set; }

        [Column("id_dentista  ")]
        [Display(Name = "id do dentista : ")]
        public int id_dentista { get; set; }

        [Column("id_clinica  ")]
        [Display(Name = "id da clinica : ")]
        public int id_clinica { get; set; }

    }
}
