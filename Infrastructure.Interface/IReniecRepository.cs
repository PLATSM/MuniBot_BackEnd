using MuniBot_BackEnd.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MuniBot_BackEnd.Infrastructure.Interface
{
    public interface IReniecRepository
    {
        Task<Reniec> GetAsync(string nuDni);
    }
}
