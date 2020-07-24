using MuniBot_BackEnd.Application.DTO;
using MuniBot_BackEnd.Transversal.Common;
using System.Threading.Tasks;

namespace MuniBot_BackEnd.Application.Interface
{
    public interface IReniecApplication
    {
        Task<Response<ReniecDTO>> GetAsync(string nuDNI);
    }
}
