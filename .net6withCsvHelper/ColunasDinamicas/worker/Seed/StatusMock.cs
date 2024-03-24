using Model;

namespace Seed
{
    public static class StatusMock
    {
        public static List<StatusModel> GetAllStatus()
        {
            return new List<StatusModel>()
            {
                new StatusModel() { Identificador = "AT", Description = "ATIVO" },
                new StatusModel() { Identificador = "IN", Description = "INATIVO" },
                new StatusModel() { Identificador = "CA", Description = "CANCELADO" },
                new StatusModel() { Identificador = "FI", Description = "FINALIZADO" }
            };              
        }

        public static List<StatusModel> GetStatusFound()
        {
            return new List<StatusModel>()
            {
                new StatusModel() { Identificador = "AT", Description = "ATIVO" },
                new StatusModel() { Identificador = "AT", Description = "ATIVO" },
                new StatusModel() { Identificador = "IN", Description = "INATIVO" },
                new StatusModel() { Identificador = "CA", Description = "CANCELADO" },
                new StatusModel() { Identificador = "FI", Description = "FINALIZADO" }
            };              
        }
    }
}