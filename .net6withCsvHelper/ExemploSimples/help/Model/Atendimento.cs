namespace Model
{
    public class Atendimento
    {
        public int Id { get; set; }
        public string NomeClinica { get; set; }
        public string NomePaciente { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataAtendimento { get; set; }
        public string Especialidade { get; set; }
    }
}

