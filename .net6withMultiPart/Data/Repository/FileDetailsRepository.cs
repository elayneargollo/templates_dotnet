using arquivoApi.Data.Interface;
using arquivoApi.Models;

namespace arquivoApi.Data.Repository
{
    public class FileDetailsRepository : BaseRepository<FileDetails>, IFileRepository
    {
        public FileDetailsRepository(MySqlContext context) : base(context) { }
    }
}