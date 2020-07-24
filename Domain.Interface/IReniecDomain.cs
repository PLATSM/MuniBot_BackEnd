using MuniBot_BackEnd.Domain.Entity;
using System.Threading.Tasks;

namespace MuniBot_BackEnd.Domain.Interface
{
    public interface IReniecDomain
    {
        Task<Reniec> GetAsync(string nuDNI);
    }
}
