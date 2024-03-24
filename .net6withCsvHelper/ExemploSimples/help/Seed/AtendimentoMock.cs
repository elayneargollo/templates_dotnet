using Bogus;
using Model;

namespace Seed
{
    public static class AtendimentoMock
    {
        static Faker faker = new Faker();

        public static List<Atendimento> ObterAtendimentos()
        {
            return new List<Atendimento>()
            {
                new Atendimento()
                {
                    Id = 1,
                    NomeClinica = faker.Company.CompanyName(),
                    NomePaciente = faker.Person.FullName,
                    DataAtendimento =  DateTime.Now,
                    DataNascimento = faker.Person.DateOfBirth,
                    Especialidade = faker.Name.JobArea()
                },
                new Atendimento()
                {
                    Id = 2,
                    NomeClinica =  faker.Company.CompanyName(),
                    NomePaciente = faker.Person.LastName,
                    DataAtendimento =  DateTime.Now,
                    DataNascimento =  faker.Person.DateOfBirth,
                    Especialidade = faker.Name.JobArea()
                }
            };
        }
    }
}