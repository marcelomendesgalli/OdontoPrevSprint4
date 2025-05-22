using OdontoPrevAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class DentistaTestes
    {
        [Fact]
        public void CpfInvalido_Excecao()
        {
            var dentista = new Dentista();

            var ex = Assert.Throws<ArgumentException>(() => dentista.cpf = "478IjK5599xyZ");
            Assert.Equal("CPF/CNPJ inválido.", ex.Message);
        }

        [Fact]
        public void DentistaDadosValidos()
        {
            var dentista = new Dentista
            {
                nome = "Dr. Andre",
                email = "andre@odontoprev.com.br",
                telefone = "91178219833",
                cpf = "47899047177",
                numero_cro = "CRO55999"
            };

            Assert.Equal("Dr. Andre", dentista.nome);
            Assert.Equal("andre@odontoprev.com.br", dentista.email);
            Assert.Equal("91178219833", dentista.telefone);
            Assert.Equal("47899047177", dentista.cpf);
            Assert.Equal("CRO55999", dentista.numero_cro);
        }
    }
}
