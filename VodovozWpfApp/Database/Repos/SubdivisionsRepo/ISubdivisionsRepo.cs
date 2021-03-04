using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vodovoz.Models.ClientSide.Database;

namespace VodovozWpfApp
{
    public interface ISubdivisionsRepo
    {
        IEnumerable<Subdivision> Subdivisions { get; }
        Task<Subdivision> GetSubdivisionAsync(long id);
        Task<Subdivision> UpdateOrAddSubdivisionAsync(Subdivision Subdivision);
        Task DeleteSubdivisionAsync(Subdivision Subdivision);
    }
}
