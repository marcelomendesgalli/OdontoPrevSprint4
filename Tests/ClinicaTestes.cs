using OdontoPrevAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class ClinicaTestes
    {
        
        [Fact]
        public void Cnpj14Digitos_Excecao()
        {
            var clinica = new Clinica();

            var ex = Assert.Throws<ArgumentException>(() => clinica.cnpj = "158393718");
            Assert.Equal("CNPJ inválido.", ex.Message);
        }
        
        [Fact]
        public void CnpjLetras_Excecao()
        {
            var clinica = new Clinica();

            var ex = Assert.Throws<ArgumentException>(() => clinica.cnpj = "12b23jn21h1");
            Assert.Equal("CNPJ inválido. Deve conter apenas números.", ex.Message);
        }
    }
}
