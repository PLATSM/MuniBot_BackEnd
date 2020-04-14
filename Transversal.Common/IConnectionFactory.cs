using System.Data;

namespace MuniBot_BackEnd.Transversal.Common
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection { get; }
    }
}
