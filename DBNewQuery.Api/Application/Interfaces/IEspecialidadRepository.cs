using DBNewQuery.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DBNewQuery.Api.Application.Interfaces
{
    public interface IEspecialidadRepository : IGenericRepository<Especialidad>
    {
        Task<List<Especialidad>> GetEspecialidadesAsync();
    }
}
