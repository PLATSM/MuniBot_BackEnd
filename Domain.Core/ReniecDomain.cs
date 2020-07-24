using System.Threading.Tasks;
using MuniBot_BackEnd.Domain.Entity;
using MuniBot_BackEnd.Domain.Interface;
using MuniBot_BackEnd.Infrastructure.Interface;

namespace MuniBot_BackEnd.Domain.Core
{
    public class ReniecDomain: IReniecDomain
    {
        private readonly IReniecRepository _reniecRepository;

        public ReniecDomain(IReniecRepository reniecRepository)
        {
            _reniecRepository = reniecRepository;
        }
        public async Task<Reniec> GetAsync(string nuDNI)
        {
            return await _reniecRepository.GetAsync(nuDNI);
        }

    }
}
