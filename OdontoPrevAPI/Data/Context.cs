using Microsoft.EntityFrameworkCore;
using OdontoPrevAPI.Model;

namespace OdontoPrevAPI.Data
{
   
       public class Context : DbContext
        {
            public Context(DbContextOptions<Context> options) : base(options)


            {
                //          Database.EnsureCreated();
            }
            public DbSet<Paciente> Api_Pacientes { set; get; }
            public DbSet<Dentista> Api_Dentistas { set; get; }
            public DbSet<Clinica> Api_Clinicas { set; get; }
            public DbSet<Agendamento> Api_Agendamentos { set; get; }



            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                if (!optionsBuilder.IsConfigured)
                    //optionsBuilder.UseSqlServer(GetStringConectionConfig());
                    optionsBuilder.UseOracle(GetStringConectionConfig());

                base.OnConfiguring(optionsBuilder);
            }


            private string GetStringConectionConfig()
            {
                string strCon = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fiap.com.br)(PORT=1521))) (CONNECT_DATA=(SERVER=DEDICATED)(SID=ORCL)));User Id=;Password=;";
                return strCon;
            }



        }
    }

