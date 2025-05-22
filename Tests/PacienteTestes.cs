using OdontoPrevAPI.Model;
using Xunit;

namespace Tests;

public class PacienteTestes
{

    [Fact]
    public void CpfCnpjComLetras_Excecao()
    {
        var paciente = new Paciente();

        var ex = Assert.Throws<ArgumentException>(() => paciente.cpf_cnpj = "478IjK5599xyZ");
        Assert.Equal("CPF/CNPJ inválido.", ex.Message);
    }
    
}