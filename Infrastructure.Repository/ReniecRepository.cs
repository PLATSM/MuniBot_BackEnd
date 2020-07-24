using System.Data;
using System.Threading.Tasks;
using Dapper;
using MuniBot_BackEnd.Domain.Entity;
using MuniBot_BackEnd.Infrastructure.Interface;
using MuniBot_BackEnd.Transversal.Common;

namespace MuniBot_BackEnd.Infrastructure.Repository
{
    public class ReniecRepository : IReniecRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public ReniecRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<Reniec> GetAsync(string nuDNI)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "sps_mae_reniec";
                var parameters = new DynamicParameters();
                parameters.Add("@pi_nuDNI", nuDNI);
                parameters.Add("@pi_id_usuario_login", 0);
                parameters.Add("@po_error_number", 0, direction: ParameterDirection.Output);
                parameters.Add("@po_error_message", "", direction: ParameterDirection.Output);

                var reniec = await connection.QuerySingleOrDefaultAsync<Reniec>(query, param: parameters, commandType: CommandType.StoredProcedure);

                if (reniec == null)
                {
                    Reniec contribuyenteError = new Reniec();
                    contribuyenteError.error_number = parameters.Get<int>("@po_error_number");
                    contribuyenteError.error_message = parameters.Get<string>("@po_error_message");
                    return contribuyenteError;
                }
                else
                {
                    return reniec;
                }
            }
        }
    }
}
