using CsvHelper.Configuration;
using Model;

namespace Mapping
{
    public class AtendimentoMap : ClassMap<Atendimento>
    {
        public AtendimentoMap()
        {
            Map(m => m.Id).Name("Sequência");
            Map(m => m.NomeClinica).Name("Clínica");
            Map(m => m.NomePaciente).Name("Paciente");
            Map(m => m.DataNascimento).Name("Data Nascimento").TypeConverterOption.Format("dd/MM/yyyy");
            Map(m => m.DataAtendimento).Name("Data Atendimento").TypeConverterOption.Format("dd/MM/yyyy");
            Map(m => m.Especialidade).Name("Especialidade");
        }
    }
}