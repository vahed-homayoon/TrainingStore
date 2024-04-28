using System.Data;

namespace Shared.Data;

public interface ISqlConnectionFactory
{
	IDbConnection CreateConnection();
}