using System.Data;

namespace FileUpload.Repository.Database
{
    public interface ISqlConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
